#!/bin/bash
# Content Migration Script for orkinosai-org/website to orkinosai-org/orkinosai-web-new
# Usage: ./content-migration.sh <source_path> [destination_path] [--dry-run]

set -e

SOURCE_PATH="$1"
DESTINATION_PATH="${2:-.}"
DRY_RUN=false

# Check for dry-run flag
if [[ "$3" == "--dry-run" || "$2" == "--dry-run" ]]; then
    DRY_RUN=true
    echo "Running in DRY RUN mode - no files will be modified"
fi

if [ -z "$SOURCE_PATH" ]; then
    echo "Usage: $0 <source_path> [destination_path] [--dry-run]"
    echo "Example: $0 ../website . --dry-run"
    exit 1
fi

if [ ! -d "$SOURCE_PATH" ]; then
    echo "Error: Source path '$SOURCE_PATH' does not exist"
    exit 1
fi

MIGRATION_LOG="$DESTINATION_PATH/migration-tools/migration-log.txt"

log_message() {
    local message="[$(date '+%Y-%m-%d %H:%M:%S')] $1"
    echo "$message"
    if [ "$DRY_RUN" = false ]; then
        echo "$message" >> "$MIGRATION_LOG"
    fi
}

safe_copy() {
    local src="$1"
    local dest="$2"
    local type="$3"
    
    if [ -e "$src" ]; then
        if [ "$DRY_RUN" = false ]; then
            mkdir -p "$(dirname "$dest")"
            if [ "$type" = "directory" ]; then
                cp -r "$src" "$dest"
            else
                cp "$src" "$dest"
            fi
        fi
        log_message "Copied: $src -> $dest"
    else
        log_message "Source not found: $src"
    fi
}

# Initialize migration log
if [ "$DRY_RUN" = false ]; then
    mkdir -p "$(dirname "$MIGRATION_LOG")"
    echo "Content Migration Log - $(date)" > "$MIGRATION_LOG"
fi

log_message "Starting content migration from $SOURCE_PATH to $DESTINATION_PATH"

cd "$SOURCE_PATH"

# Documentation Migration
log_message "=== MIGRATING DOCUMENTATION ==="
safe_copy "README.md" "$DESTINATION_PATH/docs/WEBSITE_README.md" "file"
safe_copy "CONTRIBUTING.md" "$DESTINATION_PATH/docs/WEBSITE_CONTRIBUTING.md" "file"

if [ -d "docs" ]; then
    safe_copy "docs" "$DESTINATION_PATH/docs/website" "directory"
fi

# Find and copy other markdown files
find . -maxdepth 1 -name "*.md" -type f | while read -r file; do
    filename=$(basename "$file")
    if [[ "$filename" != "README.md" && "$filename" != "CONTRIBUTING.md" ]]; then
        safe_copy "$file" "$DESTINATION_PATH/docs/website/$filename" "file"
    fi
done

# Branding Assets Migration
log_message "=== MIGRATING BRANDING ASSETS ==="

# Images
if [ -d "assets/images" ]; then
    safe_copy "assets/images" "$DESTINATION_PATH/Oqtane.Server/wwwroot/images/branding" "directory"
fi

if [ -d "images" ]; then
    safe_copy "images" "$DESTINATION_PATH/Oqtane.Server/wwwroot/images/content" "directory"
fi

# Stylesheets
if [ -d "assets/css" ]; then
    safe_copy "assets/css" "$DESTINATION_PATH/Oqtane.Server/wwwroot/css/custom" "directory"
fi

if [ -d "styles" ]; then
    safe_copy "styles" "$DESTINATION_PATH/Oqtane.Server/wwwroot/css/custom" "directory"
fi

# Icon files
find . -maxdepth 1 -name "*.ico" -type f | while read -r file; do
    safe_copy "$file" "$DESTINATION_PATH/Oqtane.Server/wwwroot/$(basename "$file")" "file"
done

# Logo files
find . -maxdepth 1 \( -name "*.png" -o -name "*.svg" -o -name "logo*" \) -type f | while read -r file; do
    safe_copy "$file" "$DESTINATION_PATH/Oqtane.Server/wwwroot/images/$(basename "$file")" "file"
done

# Content Pages Migration
log_message "=== MIGRATING CONTENT PAGES ==="

if [ -d "Pages" ]; then
    safe_copy "Pages" "$DESTINATION_PATH/Oqtane.Server/Pages/Custom" "directory"
fi

if [ -d "Components" ]; then
    safe_copy "Components" "$DESTINATION_PATH/Oqtane.Client/UI/Custom" "directory"
fi

if [ -d "Views" ]; then
    safe_copy "Views" "$DESTINATION_PATH/Oqtane.Server/Views/Custom" "directory"
fi

# Custom Themes Migration
log_message "=== MIGRATING CUSTOM THEMES ==="

if [ -d "Themes" ]; then
    safe_copy "Themes" "$DESTINATION_PATH/Oqtane.Client/Themes/Custom" "directory"
fi

if [ -d "wwwroot/Themes" ]; then
    safe_copy "wwwroot/Themes" "$DESTINATION_PATH/Oqtane.Server/wwwroot/Themes/Custom" "directory"
fi

# Configuration Migration
log_message "=== MIGRATING CONFIGURATION ==="

if [ "$DRY_RUN" = false ]; then
    mkdir -p "$DESTINATION_PATH/config/website"
fi

find . -maxdepth 1 -name "appsettings*.json" -type f | while read -r file; do
    safe_copy "$file" "$DESTINATION_PATH/config/website/$(basename "$file")" "file"
done

if [ -f "web.config" ]; then
    safe_copy "web.config" "$DESTINATION_PATH/config/website/web.config" "file"
fi

if [ -f "package.json" ]; then
    safe_copy "package.json" "$DESTINATION_PATH/config/website/package.json" "file"
fi

# Legal Documents Migration
log_message "=== MIGRATING LEGAL DOCUMENTS ==="

if [ -d "legal" ]; then
    safe_copy "legal" "$DESTINATION_PATH/docs/legal" "directory"
fi

find . -maxdepth 1 \( -name "privacy*" -o -name "terms*" -o -name "LICENSE*" \) -type f | while read -r file; do
    safe_copy "$file" "$DESTINATION_PATH/docs/legal/$(basename "$file")" "file"
done

log_message "=== MIGRATION COMPLETED ==="
log_message "Review the migration log at: $MIGRATION_LOG"

echo
echo "Migration Summary:"
echo "Source: $SOURCE_PATH"
echo "Destination: $DESTINATION_PATH"
echo "Dry Run: $DRY_RUN"
echo "Log file: $MIGRATION_LOG"