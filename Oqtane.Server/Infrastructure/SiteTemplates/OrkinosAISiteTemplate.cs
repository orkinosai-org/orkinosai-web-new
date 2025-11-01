using System.Collections.Generic;
using Oqtane.Models;
using Oqtane.Infrastructure;

namespace Oqtane.SiteTemplates
{
    public class OrkinosAISiteTemplate : ISiteTemplate
    {
        public string Name => "OrkinosAI Site Template";

        // Required by ISiteTemplate
        public List<PageTemplate> CreateSite(Site site)
        {
            return new List<PageTemplate>
            {
                CreateHtmlPage("Founder", GetFounderHtml()),
                CreateHtmlPage("Contact", GetContactHtml()),
                CreateHtmlPage("About", GetAboutHtml()),
                CreateHtmlPage("Privacy Policy", GetPrivacyHtml()),
                CreateHtmlPage("Terms and Conditions", GetTermsHtml()),
            };
        }

        // ---------- helper methods BELOW THIS LINE (class-level, NOT nested) ----------

        private PageTemplate CreateHtmlPage(string title, string html)
        {
            return new PageTemplate
            {
                Name = title,
                Path = title.ToLowerInvariant().Replace(" ", "-"),
                Order = 0,
                IsNavigation = true,
                PageTemplateModules = new List<PageTemplateModule>
                {
                    new PageTemplateModule
                    {
                        ModuleDefinitionName = "Oqtane.Modules.HtmlText",
                        Title = title,
                        Pane = "Default", // change if your theme uses another pane name
                        Order = 0,
                        Content = html
                    }
                }
            };
        }

        private string GetFounderHtml() => @"
<div class='section-padding'>
  <div class='container'>
    <div class='row'>
      <div class='col-lg-6'>
        <h1 class='gradient-text'>Founder</h1>
        <p>Dr. Ismail Kucukdurgut is the visionary behind OrkinosAI Ltd...</p>
      </div>
    </div>
  </div>
</div>";

        private string GetContactHtml() => @"
<div class='section-padding'>
  <div class='container'>
    <div class='row'>
      <div class='col-lg-6'>
        <h1 class='gradient-text'>Contact Us</h1>
        <p>Reach out to OrkinosAI Ltd via email or LinkedIn...</p>
      </div>
    </div>
  </div>
</div>";

        private string GetAboutHtml() => @"
<div class='section-padding'>
  <div class='container'>
    <div class='row'>
      <div class='col-lg-6'>
        <h1 class='gradient-text'>About OrkinosAI</h1>
        <p>We specialize in AI-powered ecommerce and development solutions...</p>
      </div>
    </div>
  </div>
</div>";

        private string GetPrivacyHtml() => @"
<div class='section-padding'>
  <div class='container'>
    <div class='row'>
      <div class='col-lg-6'>
        <h1 class='gradient-text'>Privacy Policy</h1>
        <p>Your privacy is important to us. This policy outlines how we handle data...</p>
      </div>
    </div>
  </div>
</div>";

        private string GetTermsHtml() => @"
<div class='section-padding'>
  <div class='container'>
    <div class='row'>
      <div class='col-lg-6'>
        <h1 class='gradient-text'>Terms and Conditions</h1>
        <p>By using our services, you agree to the following terms...</p>
      </div>
    </div>
  </div>
</div>";
    }
}
