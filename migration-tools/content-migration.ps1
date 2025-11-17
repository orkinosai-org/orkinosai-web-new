#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Automates migration of custom content from orkinosai-org/website to orkinosai-org/orkinosai-web-new

.DESCRIPTION
    This script automates the migration of:
    - Documentation (README, docs folders, guides)
    - Branding assets (images, logos, stylesheets)
    - Content pages (company info, about pages, legal)
    - Custom code and features
    - Configuration files

.PARAMETER SourcePath
    Path to the source repository (orkinosai-org/website)

.PARAMETER DestinationPath
    Path to the destination repository (orkinosai-org/orkinosai-web-new)

.PARAMETER WhatIf
    Shows what would be migrated without actually performing the migration

.EXAMPLE
    ./content-migration.ps1 -SourcePath "../website" -DestinationPath "." -WhatIf
#>

param(
    [Parameter(Mandatory=$true)]
    [string]$SourcePath,
    
    [Parameter(Mandatory=$false)]
    [string]$DestinationPath = ".",
    
    [Parameter(Mandatory=$false)]
    [switch]$WhatIf
)

# Migration configuration
$MigrationConfig = @{
    # Documentation files to migrate
    Documentation = @(
        @{ Source = "README.md"; Destination = "docs/WEBSITE_README.md"; Action = "Copy" }
        @{ Source = "docs/**/*"; Destination = "docs/website/"; Action = "CopyTree" }
        @{ Source = "CONTRIBUTING.md"; Destination = "docs/WEBSITE_CONTRIBUTING.md"; Action = "Copy" }
        @{ Source = "*.md"; Destination = "docs/website/"; Action = "CopyPattern" }
    )
    
    # Branding assets to migrate
    BrandingAssets = @(
        @{ Source = "assets/images/**/*"; Destination = "Oqtane.Server/wwwroot/images/branding/"; Action = "CopyTree" }
        @{ Source = "images/**/*"; Destination = "Oqtane.Server/wwwroot/images/content/"; Action = "CopyTree" }
        @{ Source = "assets/css/**/*"; Destination = "Oqtane.Server/wwwroot/css/custom/"; Action = "CopyTree" }
        @{ Source = "styles/**/*"; Destination = "Oqtane.Server/wwwroot/css/custom/"; Action = "CopyTree" }
        @{ Source = "*.ico"; Destination = "Oqtane.Server/wwwroot/"; Action = "CopyPattern" }
        @{ Source = "*.png"; Destination = "Oqtane.Server/wwwroot/images/"; Action = "CopyPattern" }
        @{ Source = "*.svg"; Destination = "Oqtane.Server/wwwroot/images/"; Action = "CopyPattern" }
    )
    
    # Content pages and components
    ContentPages = @(
        @{ Source = "Pages/**/*"; Destination = "Oqtane.Server/Pages/Custom/"; Action = "CopyTree" }
        @{ Source = "Components/**/*"; Destination = "Oqtane.Client/UI/Custom/"; Action = "CopyTree" }
        @{ Source = "Views/**/*"; Destination = "Oqtane.Server/Views/Custom/"; Action = "CopyTree" }
    )
    
    # Custom themes
    CustomThemes = @(
        @{ Source = "Themes/**/*"; Destination = "Oqtane.Client/Themes/Custom/"; Action = "CopyTree" }
        @{ Source = "wwwroot/Themes/**/*"; Destination = "Oqtane.Server/wwwroot/Themes/Custom/"; Action = "CopyTree" }
    )
    
    # Configuration and settings
    Configuration = @(
        @{ Source = "appsettings.*.json"; Destination = "config/website/"; Action = "CopyPattern" }
        @{ Source = "web.config"; Destination = "config/website/"; Action = "Copy" }
        @{ Source = "package.json"; Destination = "config/website/"; Action = "Copy" }
    )
    
    # Legal and policy documents
    LegalDocuments = @(
        @{ Source = "legal/**/*"; Destination = "docs/legal/"; Action = "CopyTree" }
        @{ Source = "privacy*"; Destination = "docs/legal/"; Action = "CopyPattern" }
        @{ Source = "terms*"; Destination = "docs/legal/"; Action = "CopyPattern" }
        @{ Source = "LICENSE*"; Destination = "docs/legal/"; Action = "CopyPattern" }
    )
}

# Migration log
$MigrationLog = @()

function Write-MigrationLog {
    param($Message, $Type = "Info")
    $LogEntry = "[$(Get-Date -Format 'yyyy-MM-dd HH:mm:ss')] [$Type] $Message"
    Write-Host $LogEntry -ForegroundColor $(if($Type -eq "Error") {"Red"} elseif($Type -eq "Warning") {"Yellow"} else {"Green"})
    $script:MigrationLog += $LogEntry
}

function Test-Path-Safe {
    param($Path)
    try {
        return Test-Path $Path
    }
    catch {
        return $false
    }
}

function Copy-Files {
    param($SourcePattern, $DestinationPath, $Action)
    
    if (-not (Test-Path-Safe $DestinationPath)) {
        if (-not $WhatIf) {
            New-Item -ItemType Directory -Path $DestinationPath -Force | Out-Null
        }
        Write-MigrationLog "Created directory: $DestinationPath"
    }
    
    switch ($Action) {
        "Copy" {
            if (Test-Path-Safe $SourcePattern) {
                if (-not $WhatIf) {
                    Copy-Item $SourcePattern $DestinationPath -Force
                }
                Write-MigrationLog "Copied: $SourcePattern -> $DestinationPath"
            }
        }
        "CopyTree" {
            if (Test-Path-Safe $SourcePattern) {
                if (-not $WhatIf) {
                    Copy-Item $SourcePattern $DestinationPath -Recurse -Force
                }
                Write-MigrationLog "Copied tree: $SourcePattern -> $DestinationPath"
            }
        }
        "CopyPattern" {
            $files = Get-ChildItem $SourcePattern -ErrorAction SilentlyContinue
            foreach ($file in $files) {
                if (-not $WhatIf) {
                    Copy-Item $file.FullName $DestinationPath -Force
                }
                Write-MigrationLog "Copied: $($file.FullName) -> $DestinationPath"
            }
        }
    }
}

function Start-Migration {
    Write-MigrationLog "Starting content migration from $SourcePath to $DestinationPath"
    
    if ($WhatIf) {
        Write-MigrationLog "Running in WhatIf mode - no files will be modified" "Warning"
    }
    
    # Validate source path
    if (-not (Test-Path-Safe $SourcePath)) {
        Write-MigrationLog "Source path not found: $SourcePath" "Error"
        return
    }
    
    # Change to source directory
    Push-Location $SourcePath
    
    try {
        # Migrate each category
        foreach ($category in $MigrationConfig.Keys) {
            Write-MigrationLog "Migrating $category..."
            
            foreach ($item in $MigrationConfig[$category]) {
                $sourcePath = $item.Source
                $destinationPath = Join-Path $DestinationPath $item.Destination
                $action = $item.Action
                
                Copy-Files $sourcePath $destinationPath $action
            }
        }
        
        Write-MigrationLog "Migration completed successfully"
    }
    finally {
        Pop-Location
    }
}

function Export-MigrationReport {
    $reportPath = Join-Path $DestinationPath "migration-tools/migration-report.txt"
    
    if (-not $WhatIf) {
        $script:MigrationLog | Out-File -FilePath $reportPath -Encoding UTF8
    }
    
    Write-MigrationLog "Migration report saved to: $reportPath"
}

# Execute migration
Start-Migration
Export-MigrationReport

Write-Host "`nMigration Summary:" -ForegroundColor Cyan
Write-Host "Source: $SourcePath" -ForegroundColor Gray
Write-Host "Destination: $DestinationPath" -ForegroundColor Gray
Write-Host "WhatIf Mode: $WhatIf" -ForegroundColor Gray
Write-Host "Log Entries: $($MigrationLog.Count)" -ForegroundColor Gray