# OrkinosAI Theme Documentation

## Overview

The OrkinosAI Theme is a professional, modern theme designed specifically for AI companies and technology businesses. It features a sleek design with AI-focused branding, gradient color schemes, and interactive components.

## Features

### Visual Design
- **Modern gradient-based color scheme** with professional blue and purple tones
- **AI-themed iconography** using Open Iconic icons
- **Responsive design** that works on all devices
- **Professional typography** with custom font weights and spacing
- **Smooth animations and transitions** for enhanced user experience

### Layout Components
- **Hero Section** - Full-width banner area perfect for main messaging
- **Features Section** - Showcase AI solutions and capabilities
- **Call to Action** - Conversion-focused sections
- **Flexible Content Areas** - Multiple column layouts (2, 3, 4 columns)
- **Professional Footer** - Multi-column footer with company information

### Customization Options
- **Footer Style** - Choose between dark and light footer themes
- **Navigation Options** - Control display of login, register, search, and user profile
- **Container Styles** - Multiple container color schemes (primary, secondary, success, etc.)

## Theme Structure

### Core Files
- **ThemeInfo.cs** - Theme registration and resource definitions
- **Default.razor** - Main theme layout with all panes and structure
- **ThemeSettings.razor** - Theme configuration interface
- **Container.razor** - Module container styling
- **ContainerSettings.razor** - Container configuration interface
- **Theme.css** - Complete CSS styling for the theme

### Available Panes
The theme provides numerous content panes for flexible page layouts:
- Hero
- Default (main content)
- Left/Right 50% (two-column)
- Left/Center/Right 33% (three-column)
- 25% columns (four-column)
- Sidebar layouts (66%/33%)
- Call to Action
- Features
- Testimonials
- Footer areas

## Site Template

The OrkinosAI Site Template creates a complete AI company website with:

### Pages Included
1. **Home** - Hero section with company overview and feature highlights
2. **About** - Company mission, vision, and values
3. **Services** - AI consulting, development, integration, and training services
4. **Products** - OrkinosAI Analytics, Assistant, and Security solutions
5. **Founder** - Leadership profile and achievements
6. **Contact** - Contact form and company information

### Content Features
- Professional AI-focused copy and messaging
- Modern card-based layouts
- Interactive feature showcases
- Contact forms and business information
- Responsive design elements

## Styling Guide

### Color Variables
```css
:root {
    --orkinosai-primary: #007BFF;
    --orkinosai-secondary: #6C757D;
    --orkinosai-accent: #28A745;
    --orkinosai-gradient: linear-gradient(135deg, #007BFF 0%, #6610f2 100%);
}
```

### Key CSS Classes
- `.gradient-text` - Applies gradient text effect
- `.feature-card` - Styled card component with hover effects
- `.hero-section` - Full-width hero area with background
- `.feature-icon` - Circular icon containers
- `.fade-in` - Fade-in animation
- `.cta-section` - Call-to-action styling

## Installation

The theme is automatically available when the Oqtane solution is built. To use:

1. During site creation, select "OrkinosAI Business Template"
2. Or manually select "OrkinosAI Theme" in Theme settings
3. Configure theme options through Site Settings > Theme Settings

## Browser Support

The theme supports all modern browsers:
- Chrome 90+
- Firefox 88+
- Safari 14+
- Edge 90+

## Performance Features

- Optimized CSS with minimal redundancy
- CDN-hosted Bootstrap for faster loading
- Compressed assets and images
- Modern CSS features for better performance

## Customization

### Modifying Colors
Update the CSS custom properties in Theme.css:
```css
:root {
    --orkinosai-primary: #your-color;
    --orkinosai-gradient: linear-gradient(135deg, #color1 0%, #color2 100%);
}
```

### Adding Custom Panes
Add new panes to the theme layout in Default.razor and update the Panes property.

### Theme Settings
Extend ThemeSettings.razor to add new configuration options.

## Support

For theme support and customization requests, refer to the main Oqtane documentation or contact the development team.