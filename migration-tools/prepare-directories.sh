#!/bin/bash
# Directory Structure Preparation Script
# Prepares the destination repository with the necessary directory structure for migration

set -e

DESTINATION_PATH="${1:-.}"

echo "Preparing directory structure for content migration..."

# Create documentation directories
mkdir -p "$DESTINATION_PATH/docs/website"
mkdir -p "$DESTINATION_PATH/docs/legal"

# Create custom content directories
mkdir -p "$DESTINATION_PATH/Oqtane.Server/wwwroot/images/branding"
mkdir -p "$DESTINATION_PATH/Oqtane.Server/wwwroot/images/content"
mkdir -p "$DESTINATION_PATH/Oqtane.Server/wwwroot/css/custom"
mkdir -p "$DESTINATION_PATH/Oqtane.Server/wwwroot/js/custom"
mkdir -p "$DESTINATION_PATH/Oqtane.Server/wwwroot/fonts"

# Create custom theme directories
mkdir -p "$DESTINATION_PATH/Oqtane.Client/Themes/Custom"
mkdir -p "$DESTINATION_PATH/Oqtane.Server/wwwroot/Themes/Custom"

# Create custom page directories
mkdir -p "$DESTINATION_PATH/Oqtane.Server/Pages/Custom"
mkdir -p "$DESTINATION_PATH/Oqtane.Client/UI/Custom"
mkdir -p "$DESTINATION_PATH/Oqtane.Server/Views/Custom"

# Create configuration backup directory
mkdir -p "$DESTINATION_PATH/config/website"

# Create migration tools directory (if not exists)
mkdir -p "$DESTINATION_PATH/migration-tools"

echo "Directory structure prepared successfully!"
echo
echo "Created directories:"
echo "  docs/website/ - For migrated documentation"
echo "  docs/legal/ - For legal and policy documents"
echo "  Oqtane.Server/wwwroot/images/branding/ - For brand assets"
echo "  Oqtane.Server/wwwroot/images/content/ - For content images"
echo "  Oqtane.Server/wwwroot/css/custom/ - For custom stylesheets"
echo "  Oqtane.Server/wwwroot/js/custom/ - For custom JavaScript"
echo "  Oqtane.Server/wwwroot/fonts/ - For custom fonts"
echo "  Oqtane.Client/Themes/Custom/ - For custom client themes"
echo "  Oqtane.Server/wwwroot/Themes/Custom/ - For custom theme assets"
echo "  Oqtane.Server/Pages/Custom/ - For custom pages"
echo "  Oqtane.Client/UI/Custom/ - For custom UI components"
echo "  Oqtane.Server/Views/Custom/ - For custom views"
echo "  config/website/ - For configuration backups"
echo "  migration-tools/ - For migration utilities"