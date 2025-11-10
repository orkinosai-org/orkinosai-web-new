
using System.Collections.Generic;
using Oqtane.Models;
using Oqtane.Infrastructure;

namespace Oqtane.SiteTemplates
{
    public class OrkinosAISiteTemplate : ISiteTemplate
    {
        public string Name => "OrkinosAI Site Template";

        public List<PageTemplate> CreateSite(Site site)
        {
            return new List<PageTemplate>
            {
                CreateHtmlPage("Home", GetHomeHtml()),
                CreateHtmlPage("Founder", GetFounderHtml()),
                CreateHtmlPage("Contact", GetContactHtml()),
                CreateHtmlPage("About", GetAboutHtml()),
                CreateHtmlPage("Privacy Policy", GetPrivacyHtml()),
                CreateHtmlPage("Terms and Conditions", GetTermsHtml()),
            };
        }

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
                        Pane = "Default",
                        Order = 0,
                        Content = html
                    }
                }
            };
        }

        private string GetHomeHtml() => @"
<div class=""text-center mb-4""><img class=""founder-photo"" src=""/images/logo.png"" alt=""logo""><h2>Supported by Microsoft for Startups</h2><img src=""/images/ms-startups-banner.png"" alt=""Microsoft startup support""></div><div class=""hero-section""><div class=""container""><div class=""hero-content""><h1 class=""display-3 mb-4 fade-in""><strong>Revolutionizing AI Solutions</strong></h1><p class=""lead mb-5 fade-in"">OrkinosAI delivers cutting-edge artificial intelligence solutions that transform businesses and drive innovation. Experience the future of AI technology today.</p>
<div class=""fade-in"">/aboutLearn More</a>/contactGet Started</a></div></div></div></div>";

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
