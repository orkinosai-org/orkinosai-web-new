# OrkinosAI Theme Documentation

## Overview

The OrkinosAI theme is a modern, professional business theme for Oqtane CMS that showcases OrkinosAI as a leading artificial intelligence company. The theme provides a complete branded experience with comprehensive business content and modern design patterns.

## Features

### Theme Components
- **Modern Layout**: Responsive design with Bootstrap 5 integration
- **Professional Branding**: Custom OrkinosAI color scheme and typography
- **Multiple Containers**: Flexible module container options
- **Comprehensive Content**: Complete business website structure

### Pages Included
1. **Home Page**: Hero section, feature highlights, and company overview
2. **About**: Company mission, vision, and values
3. **Services**: AI consulting, development, integration, and support services
4. **Products**: OrkinosAI Analytics, Assistant, and Security solutions
5. **Founder**: Leadership profile and company background
6. **Contact**: Contact form, company information, and location details

### Design Elements
- **Color Scheme**: Professional blue gradient (#2563eb to #06b6d4)
- **Typography**: Modern Inter font with clear hierarchy
- **Animations**: Smooth transitions and hover effects
- **Responsive**: Mobile-first design approach
- **Accessibility**: WCAG compliant focus states and contrast

## File Structure

```
Oqtane.Client/Themes/OrkinosAITheme/
├── ThemeInfo.cs                 # Theme metadata and resources
├── Themes/
│   ├── Default.razor           # Main theme layout
│   └── ThemeSettings.razor     # Theme configuration options
└── Containers/
    ├── Container.razor         # Default module container
    ├── DefaultTitle.razor      # Container with title
    ├── DefaultNoTitle.razor    # Container without title
    └── ContainerSettings.razor # Container configuration

Oqtane.Server/Infrastructure/SiteTemplates/
└── OrkinosAISiteTemplate.cs    # Site template with business content

Oqtane.Server/wwwroot/
├── Themes/OrkinosAITheme/
│   └── Theme.css              # Custom theme styles
└── images/
    ├── orkinosai-logo.png     # Company logo
    └── orkinosai-logo.svg     # Vector logo
```

## Configuration

The theme is set as the default theme in `Oqtane.Shared/Shared/Constants.cs`:

```csharp
public const string DefaultTheme = "Oqtane.Themes.OrkinosAITheme.Default, Oqtane.Client";
public const string DefaultContainer = "Oqtane.Themes.OrkinosAITheme.DefaultTitle, Oqtane.Client";
public const string DefaultSiteTemplate = "Oqtane.Infrastructure.SiteTemplates.OrkinosAISiteTemplate, Oqtane.Server";
```

## Theme Settings

The theme includes configurable options:
- **Login Display**: Show/hide login link
- **Registration**: Show/hide registration link
- **Search**: Show/hide search functionality
- **User Profile**: Show/hide user profile display
- **Footer Style**: Dark or light footer themes

## Container Options

Multiple container styles are available:
- **Default**: Basic content container
- **Primary/Secondary/Success/Info/Warning/Danger**: Colored containers
- **Light/Dark**: Light and dark themed containers

## Business Content

### Company Information
- **Name**: OrkinosAI
- **Focus**: Artificial Intelligence solutions
- **Services**: AI Consulting, Custom Development, Integration, Training
- **Products**: Analytics, Assistant, Security platforms
- **Contact**: Silicon Valley headquarters with full contact details

### Content Sections
- Professional hero section with call-to-action
- Feature highlights with modern card layouts
- Comprehensive service descriptions
- Product showcases with detailed specifications
- Leadership profile and company background
- Complete contact information and forms

## Customization

To customize the theme:

1. **Colors**: Update CSS variables in `Theme.css`
2. **Content**: Modify `OrkinosAISiteTemplate.cs`
3. **Layout**: Edit `Default.razor` for structural changes
4. **Branding**: Replace logo files in `wwwroot/images/`

## Technical Notes

- Built with Bootstrap 5 for modern responsive design
- Uses CSS Grid and Flexbox for layout
- Implements CSS custom properties for easy theming
- Includes modern animations and transitions
- Follows Oqtane theme development patterns
- Supports both light and dark color schemes

## Deployment

The theme is automatically active after building the Oqtane application. No additional installation steps are required as it's integrated directly into the framework as the default theme and site template.