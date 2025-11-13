
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
<div class=""text-center mb-4"">
  <img class=""founder-photo"" src=""/images/logo.png"" alt=""logo"">
  <h2>Supported by Microsoft for Startups</h2>
  <img src=""/images/ms-startups-banner.png"" alt=""Microsoft startup support"">
</div>

<div class=""hero-section"">
  <div class=""container"">
    <div class=""hero-content"">
      <h1 class=""display-3 mb-4 fade-in""><strong>Revolutionizing AI Solutions</strong></h1>
      <p class=""lead mb-5 fade-in"">
        OrkinosAI delivers cutting-edge artificial intelligence solutions that transform businesses and drive innovation.
        Experience the future of AI technology today.
      </p>
      <div class=""fade-in"">
        <a class=""btn btn-primary"" href=""/about"">Learn More</a>
        <a class=""btn btn-outline-secondary ms-2"" href=""/contact"">Get Started</a>
      </div>
    </div>
  </div>
</div>
";

        private string GetFounderHtml() => @"
<div class='section-padding'>
  <div class='container'>
    <div class='row'>
      <div class='col-lg-8'>
        <p><em>founder image</em></p>
        <h4>Dr. Ismail Kucukdurgut</h4>
        <p><strong>Founder & CEO</strong></p>

        <h2>AI Innovator and Visionary</h2>
        <p>
          Dr. Ismail Kucukdurgut holds a Ph.D. in Intelligent Systems and Artificial Intelligence and has hands-on experience delivering Azure-based AI, SharePoint, and conversational solutions.
          His work spans intelligent automation, AI-driven CMS, and enterprise integrations, with a mission to make advanced AI practical and accessible for organizations of all sizes.
        </p>

        <h5>Achievements & Expertise</h5>
        <ul>
          <li>Ph.D. in Intelligent Systems (Computational Intelligence &amp; Granular Computing)</li>
          <li>Microsoft-centric stack: Azure AI, .NET/Blazor, and SharePoint</li>
          <li>Builder of conversational platforms and AI-powered CMS</li>
          <li>Advocate for responsible, human-centered AI</li>
        </ul>

        <blockquote>
          ""The future is conversational. At OrkinosAI, we empower businesses to harness AI for growth and transformation.""
        </blockquote>
      </div>
    </div>
  </div>
</div>
";

        private string GetContactHtml() => @"
<div class='section-padding'>
  <div class='container'>
    <div class='row'>
      <div class='col-lg-8'>
        <h2 class='gradient-text'>Contact OrkinosAI</h2>
        <p>Ready to transform your business with AI? We'd love to hear from you.</p>

        <h5>Send us a Message</h5>
        <p>
          <em>First Name</em><br/>
          <em>Last Name</em><br/>
          <em>Email</em><br/>
          <em>Company</em><br/>
          <em>How can we help you? AI Consulting · Custom Development · Product Demo · Partnership · Other</em><br/>
          <em>Message</em><br/>
          <button class='btn btn-primary mt-2' disabled>Send Message</button>
        </p>

        <h5>Contact Information</h5>
        <p>
          <strong>Email</strong><br/>
          mailto:contact@orkinosai.comcontact@orkinosai.com</a><br/><br/>

          <strong>WhatsApp</strong><br/>
          +44 7902 437236<br/><br/>

          <strong>Business Hours</strong><br/>
          Monday - Friday: 9:00 AM - 6:00 PM GMT<br/>
          Saturday - Sunday: Closed
        </p>
      </div>
    </div>
  </div>
</div>
";

        private string GetAboutHtml() => @"
<div class='section-padding'>
  <div class='container'>
    <div class='row'>
      <div class='col-lg-10'>

        <h2 class='gradient-text'>Leading the AI Revolution</h2>
        <p>
          OrkinosAI is at the forefront of artificial intelligence innovation, developing transformative solutions that empower businesses to harness the full potential of AI technology.
          Founded by industry experts with decades of experience in machine learning, data science, and enterprise software, we specialize in creating intelligent systems that solve real-world problems.
          Our mission is to democratize AI technology, making advanced artificial intelligence accessible and practical for organizations of all sizes.
        </p>

        <h4>Our Vision</h4>
        <p>To create a world where artificial intelligence enhances human capabilities and drives sustainable innovation across all industries.</p>

        <h4>Our Values</h4>
        <ul>
          <li><strong>Innovation:</strong> Pushing the boundaries of what's possible with AI</li>
          <li><strong>Ethics:</strong> Developing responsible AI solutions</li>
          <li><strong>Excellence:</strong> Delivering superior technology and service</li>
          <li><strong>Partnership:</strong> Building lasting relationships with our clients</li>
        </ul>

        <hr/>

        <h2>Comprehensive AI Services</h2>
        <p>From consultation to implementation, we provide end-to-end AI solutions tailored to your business needs.</p>

        <h5>SharePoint Intranet &amp; M365 Modern Work</h5>
        <ul>
          <li>IA &amp; governance workshops</li>
          <li>Modern pages, hubs, and navigation</li>
          <li>Power Automate/Power Apps solutions</li>
          <li>Security, compliance, and adoption</li>
        </ul>

        <h5>Web Development &amp; Integration</h5>
        <ul>
          <li>Architecture, APIs, and data pipelines (Python/.NET)</li>
          <li>Identity (Entra ID) and role-based access</li>
          <li>Performance, SEO, and accessibility</li>
          <li>DevOps, testing, and monitoring</li>
        </ul>

        <h5>AI Consulting</h5>
        <ul>
          <li>Readiness assessment &amp; data strategy</li>
          <li>Use-case prioritization &amp; ROI analysis</li>
          <li>Responsible AI &amp; governance</li>
          <li>Pilot planning</li>
        </ul>

        <h5>Custom AI Development</h5>
        <ul>
          <li>ML/NLP/CV models and evaluators</li>
          <li>Conversational agents and tools</li>
          <li>Predictive analytics &amp; optimization</li>
          <li>MLOps on Azure</li>
        </ul>

        <hr/>

        <h2>Innovative AI Products</h2>
        <p>Explore our flagship AI products designed to transform your business operations and drive intelligent automation.</p>

        <h5>OrkinosAI Conversational CMS</h5>
        <ul>
          <li>Dynamic personalization and audience targeting</li>
          <li>AI content assistance and workflow automation</li>
          <li>Built-in analytics and A/B testing hooks</li>
          <li>Extensible on .NET/Blazor and Azure</li>
        </ul>
        <p>/contactLearn More</a></p>

        <h5>SharePoint Intranet</h5>
        <ul>
          <li>Information architecture, sites, hubs, and search</li>
          <li>Viva Connections integration and branding</li>
          <li>Power Platform workflows &amp; approvals</li>
          <li>Governance, security, and lifecycle management</li>
        </ul>
        <p>/contactLearn More</a></p>

        <h5>Web Development (Blazor/.NET)</h5>
        <ul>
          <li>Blazor SSR/Interactive with Azure hosting</li>
          <li>Accessible, responsive UI and performance best practices</li>
          <li>API integration, identity, and telemetry</li>
          <li>Conversational widgets and agent integrations</li>
        </ul>
        <p>/contactLearn More</a></p>

      </div>
    </div>
  </div>
</div>
";

        private string GetPrivacyHtml() => @"
<h2>Privacy Policy</h2>

<p>This privacy policy (""policy"") will help you understand how [PageState:Site:Name] (""us"", ""we"", ""our"") uses and protects the data you provide to us when you visit and use this website.</p>
<p>We reserve the right to change this policy at any time. If you want to make sure that you are up to date with the latest changes, we advise you to frequently visit this page.</p>

<h3>What User Data We Collect</h3>
<p>When you visit this website, we may collect the following data: your IP address, your contact information and email address, other information such as interests and preferences.</p>

<h3>Why We Collect Your Data</h3>
<p>We are collecting your data for several reasons: to better understand your needs, to improve our products and services, to send you promotional emails containing the information we think you will find interesting, to customize our website according to your online behavior and personal preferences.</p>

<h3>Safeguarding and Securing the Data</h3>
<p>[PageState:Site:Name] is committed to securing your data and keeping it confidential. [PageState:Site:Name] has done everything in its power to prevent data theft, unauthorized access, and disclosure by implementing the latest technologies and software.</p>

<h3>Our Cookie Policy</h3>
<p>Once you agree to allow our website to use cookies, you also agree to allow us to use the data it collects regarding your online behavior (analyze web traffic, web pages you visit and spend the most time on, etc...). The data we collect by using cookies is used to customize our website to your needs. Cookies do not allow us to gain access to your computer in any way. If you want to disable or remove cookies, you can do so by accessing the settings of your internet browser.</p>

<h3>Links to Other Websites</h3>
<p>Our website contains links that lead to other websites. If you click on these links [PageState:Site:Name] is not held responsible for your data and privacy protection. Visiting those websites is not governed by this privacy policy agreement. Make sure to read the privacy policy documentation of any website you navigate to from our website.</p>

<h3>Restricting the Collection of your Personal Data</h3>
<p>If you previously agreed to share your information with us, feel free to contact us and we will change this for you. [PageState:Site:Name] will not lease, sell or distribute your personal information to any third parties, unless we have your permission. Your personal information will only be used to send you promotional materials if you agree to this privacy policy.</p>
";

        private string GetTermsHtml() => @"
<h2>Terms and Conditions</h2>

<p>Please read these terms and conditions carefully before using this website operated by [PageState:Site:Name] (""us"", ""we"", ""our"").</p>

<h3>Conditions of Use</h3>
<p>By using this website, you certify that you have read and reviewed this Agreement and that you agree to comply with its terms. If you do not want to be bound by the terms of this Agreement, you are advised to stop using the website accordingly. [PageState:Site:Name] only grants use and access of this website, its products, and its services to those who have accepted its terms.</p>

<h3>Privacy Policy</h3>
<p>Before you continue using our website, we advise you to read our <a href=""/privacy"">privacy policy</a> regarding our user data collection. It will help you better understand our practices.</p>

<h3>Intellectual Property</h3>
<p>You agree that all materials, products, and services provided on this website are the property of [PageState:Site:Name], its affiliates, directors, officers, employees, agents, suppliers, or licensors including all copyrights, trade secrets, trademarks, patents, and other intellectual property. You also agree that you will not reproduce or redistribute the [PageState:Site:Name]’s intellectual property in any way, including electronic, digital, or new trademark registrations. You grant [PageState:Site:Name] a royalty-free and non-exclusive license to display, use, copy, transmit, and broadcast the content you upload and publish. For issues regarding intellectual property claims, you should contact us in order to come to an agreement.</p>

<h3>User Accounts</h3>
<p>As a user of this website, you may be asked to register with us and provide private information. You are responsible for ensuring the accuracy of this information, and you are responsible for maintaining the safety and security of your identifying information. You are also responsible for all activities that occur under your account or password. If you think there are any possible issues regarding the security of your account on the website, inform us immediately so we may address them accordingly. We reserve all rights to terminate accounts, edit or remove content and cancel orders at our sole discretion.</p>

<h3>Applicable Law</h3>
<p>By using this website, you agree that the laws of the jurisdiction associated to [PageState:Site:Name], without regard to principles of conflict laws, will govern these terms and conditions, or any dispute of any sort that might come between [PageState:Site:Name] and you, or its business partners and associates.</p>

<h3>Disputes</h3>
<p>Any dispute related in any way to your use of this website or to products you purchase from us shall be arbitrated by a court of law and you consent to exclusive jurisdiction and venue of such courts.</p>

<h3>Indemnification</h3>
<p>You agree to indemnify [PageState:Site:Name] and its affiliates and hold [PageState:Site:Name] harmless against legal claims and demands that may arise from your use or misuse of our services. We reserve the right to select our own legal counsel.</p>

<h3>Limitation on Liability</h3>
<p>[PageState:Site:Name] is not liable for any damages that may occur to you as a result of your misuse of our website. [PageState:Site:Name] reserves the right to edit, modify, and change this Agreement at any time. This Agreement is an understanding between [PageState:Site:Name] and the user, and this supersedes and replaces all prior agreements regarding the use of this website.</p>
";
    }

}
