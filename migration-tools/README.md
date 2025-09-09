# Content Migration Tools

This directory contains automated tools and documentation for migrating all custom content, branding, docs, and company info from the previous website repository (`orkinosai-org/website`) to the current repository (`orkinosai-org/orkinosai-web-new`).

## Overview

The migration process is designed to be as automated as possible while ensuring no content is lost and all references are properly updated. The tools support both fully automated migration and manual step-by-step migration with comprehensive validation.

## Migration Tools

### 1. Automated Migration Scripts

#### PowerShell Script (`content-migration.ps1`)
```powershell
# Dry run to see what would be migrated
./content-migration.ps1 -SourcePath "../website" -DestinationPath "." -WhatIf

# Execute the migration
./content-migration.ps1 -SourcePath "../website" -DestinationPath "."
```

**Features:**
- Comprehensive logging
- Dry-run mode for validation
- Organized content categorization
- Error handling and reporting

#### Bash Script (`content-migration.sh`)
```bash
# Dry run to see what would be migrated
./content-migration.sh ../website . --dry-run

# Execute the migration
./content-migration.sh ../website .
```

**Features:**
- Cross-platform compatibility
- Safe file operations
- Detailed logging
- Directory structure creation

### 2. Directory Preparation (`prepare-directories.sh`)
Prepares the destination repository with the necessary directory structure before migration:

```bash
./prepare-directories.sh
```

Creates all required directories for:
- Documentation and legal content
- Branding assets and media
- Custom themes and components
- Configuration backups

### 3. Manual Migration Checklist (`manual-migration-checklist.md`)
Comprehensive step-by-step checklist for manual migration validation covering:
- Repository analysis
- Content validation
- Reference updates
- Testing procedures

## Migration Categories

### Documentation
- **Source**: `README.md`, `docs/`, `*.md` files
- **Destination**: `docs/website/`, `docs/WEBSITE_README.md`
- **Includes**: Guides, API docs, user manuals, contributing guidelines

### Branding Assets
- **Source**: `assets/`, `images/`, `styles/`, `*.ico`, `*.png`, `*.svg`
- **Destination**: `Oqtane.Server/wwwroot/images/`, `Oqtane.Server/wwwroot/css/custom/`
- **Includes**: Logos, icons, stylesheets, fonts, color schemes

### Content Pages
- **Source**: `Pages/`, `Components/`, `Views/`
- **Destination**: `Oqtane.Server/Pages/Custom/`, `Oqtane.Client/UI/Custom/`
- **Includes**: Company info, about pages, landing pages, custom modules

### Custom Themes
- **Source**: `Themes/`, `wwwroot/Themes/`
- **Destination**: `Oqtane.Client/Themes/Custom/`, `Oqtane.Server/wwwroot/Themes/Custom/`
- **Includes**: Theme files, layouts, styling, responsive designs

### Configuration
- **Source**: `appsettings*.json`, `web.config`, `package.json`
- **Destination**: `config/website/`
- **Includes**: App settings, environment configs, build configurations

### Legal Documents
- **Source**: `legal/`, `privacy*`, `terms*`, `LICENSE*`
- **Destination**: `docs/legal/`
- **Includes**: Privacy policies, terms of service, compliance documents

## Usage Instructions

### Prerequisites
1. Access to source repository (`orkinosai-org/website`)
2. Local clone of destination repository
3. PowerShell 5.1+ or Bash shell
4. Appropriate file system permissions

### Quick Start
1. **Prepare the environment:**
   ```bash
   ./prepare-directories.sh
   ```

2. **Run dry migration to validate:**
   ```bash
   ./content-migration.sh /path/to/source/website . --dry-run
   ```

3. **Review the dry-run output and execute migration:**
   ```bash
   ./content-migration.sh /path/to/source/website .
   ```

4. **Follow the manual checklist for validation:**
   Review `manual-migration-checklist.md` and complete all validation steps.

### Advanced Usage

#### Custom Source Path
```bash
# If source repository is in a different location
./content-migration.sh ~/repositories/orkinosai-website .
```

#### Selective Migration
For selective migration, modify the migration scripts or use manual file operations guided by the checklist.

#### PowerShell Alternative
```powershell
# Using PowerShell on Windows/Linux/macOS
pwsh ./content-migration.ps1 -SourcePath "../website" -DestinationPath "."
```

## Output and Logging

### Migration Log
- **Location**: `migration-tools/migration-log.txt` (Bash) or `migration-tools/migration-report.txt` (PowerShell)
- **Content**: Detailed record of all file operations, errors, and timestamps

### Directory Structure
After migration, the repository will have:
```
├── docs/
│   ├── website/           # Migrated documentation
│   └── legal/             # Legal documents
├── Oqtane.Server/
│   └── wwwroot/
│       ├── images/
│       │   ├── branding/  # Brand assets
│       │   └── content/   # Content images
│       ├── css/custom/    # Custom stylesheets
│       ├── js/custom/     # Custom JavaScript
│       └── Themes/Custom/ # Custom theme assets
├── Oqtane.Client/
│   ├── Themes/Custom/     # Custom client themes
│   └── UI/Custom/         # Custom components
└── config/
    └── website/           # Configuration backups
```

## Validation and Testing

### Post-Migration Checklist
1. **Build Testing**: Verify the solution builds successfully
2. **Content Validation**: Check all migrated content is accessible
3. **Reference Updates**: Ensure all links and references work
4. **Theme Testing**: Validate custom themes function correctly
5. **Responsive Testing**: Test UI across different screen sizes

### Common Issues and Solutions

#### Permission Errors
```bash
# Ensure scripts are executable
chmod +x migration-tools/*.sh
```

#### Path Resolution
```bash
# Use absolute paths if relative paths cause issues
./content-migration.sh /full/path/to/source /full/path/to/destination
```

#### Large File Handling
For repositories with large assets, consider:
- Using Git LFS for large files
- Compressing images before migration
- Selective migration of critical assets first

## Support and Troubleshooting

### Migration Fails
1. Check source path exists and is accessible
2. Verify destination path has write permissions
3. Review migration log for specific errors
4. Use dry-run mode to identify issues before execution

### Missing Content
1. Review the manual checklist for overlooked items
2. Check source repository for non-standard locations
3. Verify file patterns in migration scripts match source structure

### Performance Issues
1. Run migration on local file system (not network drives)
2. Consider migrating in batches for very large repositories
3. Use SSD storage for better I/O performance

## Contributing

To improve the migration tools:
1. Test with different repository structures
2. Add support for additional file types
3. Enhance error handling and reporting
4. Update documentation based on real-world usage

## Migration Report Template

After migration, document:
- [ ] Total files migrated
- [ ] Content categories processed
- [ ] Any issues encountered
- [ ] Manual fixes required
- [ ] Validation test results
- [ ] Performance metrics