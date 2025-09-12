# OrkinosAI Branding Setup Script

This script helps set up OrkinosAI branding elements for the Oqtane installation.

## Manual Setup Steps

If the automatic upgrade doesn't restore OrkinosAI branding properly, follow these steps:

### 1. Favicon Update
The current favicon (oqtane.ico) shows Oqtane branding. To use OrkinosAI branding:

1. Convert the OrkinosAI logo to ICO format:
   - Use the `orkinosai-logo.png` file in `wwwroot/images/`
   - Convert to ICO format (16x16 and 32x32 sizes)
   - Replace `wwwroot/oqtane.ico` with the new OrkinosAI favicon

### 2. Logo Configuration
Ensure the site logo is properly configured:

1. Check if the site's LogoFileId is set to the OrkinosAI logo
2. Use the admin API endpoint: `POST /api/OrkinosAI/branding/apply/{siteId}`
3. Or manually upload the OrkinosAI logo through the admin interface

### 3. Theme Configuration
Ensure pages are using the OrkinosAI theme:

1. Check if pages are using `Oqtane.Themes.OrkinosAITheme.Default, Oqtane.Client`
2. Update page themes through the admin interface or use the branding API

### 4. Site Template
For new sites, ensure the OrkinosAI site template is selected during creation:
- Select "OrkinosAI Business Template" during site creation
- This will automatically set up all OrkinosAI branding, theme, and content

## API Endpoints

### Check OrkinosAI Branding Status
```
GET /api/OrkinosAI/branding/check/{siteId}
```

### Apply OrkinosAI Branding
```
POST /api/OrkinosAI/branding/apply/{siteId}
```

## Troubleshooting

### Theme Not Loading
If the OrkinosAI theme is not loading:
1. Check that the theme files exist in `Oqtane.Client/Themes/OrkinosAITheme/`
2. Verify the theme CSS is accessible at `/Themes/Oqtane.Themes.OrkinosAITheme/Theme.css`
3. Check browser console for any CSS loading errors

### Logo Not Displaying
If the OrkinosAI logo is not displaying:
1. Verify the logo file exists in the site's content folder
2. Check that the site's LogoFileId is properly set
3. Ensure the file is accessible through the file service

### Default Content Showing
If default Oqtane content is showing instead of OrkinosAI content:
1. The site may not have been created with the OrkinosAI template
2. Consider recreating the site with the OrkinosAI Business Template
3. Or manually update the page content to match the OrkinosAI template

## File Locations

- **Logo**: `wwwroot/images/orkinosai-logo.png`
- **Favicon**: `wwwroot/oqtane.ico` (should be replaced with OrkinosAI version)
- **Theme CSS**: `wwwroot/Themes/Oqtane.Themes.OrkinosAITheme/Theme.css`
- **Theme Components**: `Oqtane.Client/Themes/OrkinosAITheme/`
- **Site Template**: `Oqtane.Server/Infrastructure/SiteTemplates/OrkinosAISiteTemplate.cs`