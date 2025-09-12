# OrkinosAI Favicon Creation

To create an OrkinosAI favicon to replace the default Oqtane favicon:

## Option 1: Using online converter
1. Take the `orkinosai-logo.png` file from `wwwroot/images/`
2. Go to an online ICO converter (e.g., favicon.io, converticon.com)
3. Upload the PNG file and generate ICO with sizes: 16x16, 32x32, 48x48
4. Download the generated `favicon.ico`
5. Replace `wwwroot/oqtane.ico` with the new OrkinosAI favicon

## Option 2: Using ImageMagick (if available)
```bash
# Install ImageMagick if not available
# Convert PNG to ICO with multiple sizes
magick wwwroot/images/orkinosai-logo.png -resize 16x16 -background transparent -gravity center -extent 16x16 wwwroot/favicon-16.ico
magick wwwroot/images/orkinosai-logo.png -resize 32x32 -background transparent -gravity center -extent 32x32 wwwroot/favicon-32.ico
magick wwwroot/favicon-16.ico wwwroot/favicon-32.ico wwwroot/orkinosai-favicon.ico
```

## Option 3: Manual setup in HTML
Instead of replacing the ICO file, you can also add favicon links in the theme:

```html
<link rel="icon" type="image/png" sizes="32x32" href="/images/orkinosai-logo.png">
<link rel="icon" type="image/png" sizes="16x16" href="/images/orkinosai-logo.png">
<link rel="apple-touch-icon" href="/images/orkinosai-logo.png">
```

## Quick Solution
For immediate OrkinosAI branding, copy the OrkinosAI logo as the favicon:
```bash
cp wwwroot/images/orkinosai-logo.png wwwroot/favicon.png
```

Then reference it in the theme head section.