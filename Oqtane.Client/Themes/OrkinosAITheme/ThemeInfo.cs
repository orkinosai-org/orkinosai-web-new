using System.Collections.Generic;
using Oqtane.Documentation;
using Oqtane.Models;
using Oqtane.Shared;

namespace Oqtane.Themes.OrkinosAITheme
{
    [PrivateApi("Mark OrkinosAI Theme-Info classes as private, since it's not very useful in the public docs")]
    public class ThemeInfo : ITheme
    {
        public Theme Theme => new Theme
        {
            Name = "OrkinosAI Theme",
            Version = "1.0.0",
            ThemeSettingsType = "Oqtane.Themes.OrkinosAITheme.ThemeSettings, Oqtane.Client",
            ContainerSettingsType = "Oqtane.Themes.OrkinosAITheme.ContainerSettings, Oqtane.Client",
            Resources = new List<Resource>()
            {
                // Use modern Bootstrap 5 with professional color scheme
                new Stylesheet("https://cdnjs.cloudflare.com/ajax/libs/bootstrap/5.3.2/css/bootstrap.min.css", "sha512-b2QcS5SsA8tZodcDtGRELiGv5SaKSk1vDHDaQRda0htPYWZ6046lr3kJ5bAAQdpV2mmA/4v0wQF9MyU6/pDIAg==", "anonymous"),
                new Stylesheet("_content/Oqtane.Server/Themes/OrkinosAITheme/Theme.css"),
                new Script(Constants.BootstrapScriptUrl, Constants.BootstrapScriptIntegrity, "anonymous")
            }
        };
    }
}