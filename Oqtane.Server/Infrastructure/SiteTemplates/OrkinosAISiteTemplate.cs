using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Oqtane.Documentation;
using Oqtane.Models;
using Oqtane.Repository;
using Oqtane.Shared;

namespace Oqtane.Infrastructure.SiteTemplates
{
    [PrivateApi("Mark Site-Template classes as private, since it's not very useful in the public docs")]
    public class OrkinosAISiteTemplate : ISiteTemplate
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ISiteRepository _siteRepository;
        private readonly IFolderRepository _folderRepository;
        private readonly IFileRepository _fileRepository;

        public OrkinosAISiteTemplate(IWebHostEnvironment environment, ISiteRepository siteRepository, IFolderRepository folderRepository, IFileRepository fileRepository)
        {
            _environment = environment;
            _siteRepository = siteRepository;
            _folderRepository = folderRepository;
            _fileRepository = fileRepository;
        }

        public string Name
        {
            get { return "OrkinosAI Business Template"; }
        }

        public List<PageTemplate> CreateSite(Site site)
        {
            List<PageTemplate> _pageTemplates = new List<PageTemplate>();

            // Home Page
            _pageTemplates.Add(new PageTemplate
            {
                Name = "Home",
                Parent = "",
                Order = 1,
                Path = "",
                Icon = "oi oi-home",
                IsNavigation = true,
                IsPersonalizable = false,
                ThemeType = "Oqtane.Themes.OrkinosAITheme.Default, Oqtane.Client",
                PermissionList = new List<Permission> {
                    new Permission(PermissionNames.View, RoleNames.Everyone, true),
                    new Permission(PermissionNames.View, RoleNames.Admin, true),
                    new Permission(PermissionNames.Edit, RoleNames.Admin, true)
                },
                PageTemplateModules = new List<PageTemplateModule> {
                    new PageTemplateModule { 
                        ModuleDefinitionName = "Oqtane.Modules.HtmlText, Oqtane.Client", 
                        Title = "Welcome to OrkinosAI", 
                        Pane = "Hero", 
                        PermissionList = new List<Permission> {
                            new Permission(PermissionNames.View, RoleNames.Everyone, true),
                            new Permission(PermissionNames.View, RoleNames.Admin, true),
                            new Permission(PermissionNames.Edit, RoleNames.Admin, true)
                        },
                        Content = "<div class=\"hero-section\"><div class=\"container\"><div class=\"hero-content\">" +
                        "<h1 class=\"display-3 mb-4 fade-in\"><strong>Revolutionizing AI Solutions</strong></h1>" +
                        "<p class=\"lead mb-5 fade-in\">OrkinosAI delivers cutting-edge artificial intelligence solutions that transform businesses and drive innovation. Experience the future of AI technology today.</p>" +
                        "<div class=\"fade-in\"><a href=\"/about\" class=\"btn btn-primary btn-lg me-3\">Learn More</a><a href=\"/contact\" class=\"btn btn-outline-light btn-lg\">Get Started</a></div>" +
                        "</div></div></div>"
                    },
                    new PageTemplateModule { 
                        ModuleDefinitionName = "Oqtane.Modules.HtmlText, Oqtane.Client", 
                        Title = "Our Solutions", 
                        Pane = "Features", 
                        PermissionList = new List<Permission> {
                            new Permission(PermissionNames.View, RoleNames.Everyone, true),
                            new Permission(PermissionNames.View, RoleNames.Admin, true),
                            new Permission(PermissionNames.Edit, RoleNames.Admin, true)
                        },
                        Content = "<div class=\"section-padding bg-light\"><div class=\"container\"><div class=\"row\"><div class=\"col-12 text-center mb-5\">" +
                        "<h2 class=\"gradient-text\">Powerful AI Solutions</h2>" +
                        "<p class=\"lead\">Discover our comprehensive suite of AI technologies designed to accelerate your business growth.</p></div></div>" +
                        "<div class=\"row g-4\">" +
                        "<div class=\"col-md-4\"><div class=\"feature-card\"><div class=\"feature-icon\"><i class=\"oi oi-brain\"></i></div><h4>Machine Learning</h4><p>Advanced ML algorithms that learn and adapt to your business needs, providing intelligent insights and automation.</p></div></div>" +
                        "<div class=\"col-md-4\"><div class=\"feature-card\"><div class=\"feature-icon\"><i class=\"oi oi-eye\"></i></div><h4>Computer Vision</h4><p>State-of-the-art visual recognition technology for automated analysis, quality control, and intelligent monitoring.</p></div></div>" +
                        "<div class=\"col-md-4\"><div class=\"feature-card\"><div class=\"feature-icon\"><i class=\"oi oi-chat\"></i></div><h4>Natural Language</h4><p>Sophisticated NLP solutions for chatbots, content analysis, and intelligent communication systems.</p></div></div>" +
                        "</div></div></div>"
                    }
                }
            });

            // About Page
            _pageTemplates.Add(new PageTemplate
            {
                Name = "About",
                Parent = "",
                Order = 2,
                Path = "about",
                Icon = "oi oi-info",
                IsNavigation = true,
                IsPersonalizable = false,
                ThemeType = "Oqtane.Themes.OrkinosAITheme.Default, Oqtane.Client",
                PermissionList = new List<Permission> {
                    new Permission(PermissionNames.View, RoleNames.Everyone, true),
                    new Permission(PermissionNames.View, RoleNames.Admin, true),
                    new Permission(PermissionNames.Edit, RoleNames.Admin, true)
                },
                PageTemplateModules = new List<PageTemplateModule> {
                    new PageTemplateModule { 
                        ModuleDefinitionName = "Oqtane.Modules.HtmlText, Oqtane.Client", 
                        Title = "About OrkinosAI", 
                        Pane = PaneNames.Default, 
                        PermissionList = new List<Permission> {
                            new Permission(PermissionNames.View, RoleNames.Everyone, true),
                            new Permission(PermissionNames.View, RoleNames.Admin, true),
                            new Permission(PermissionNames.Edit, RoleNames.Admin, true)
                        },
                        Content = "<div class=\"section-padding\"><div class=\"container\"><div class=\"row align-items-center\">" +
                        "<div class=\"col-lg-6\"><h1 class=\"gradient-text mb-4\">Leading the AI Revolution</h1>" +
                        "<p class=\"lead\">OrkinosAI is at the forefront of artificial intelligence innovation, developing transformative solutions that empower businesses to harness the full potential of AI technology.</p>" +
                        "<p>Founded by industry experts with decades of experience in machine learning, data science, and enterprise software, we specialize in creating intelligent systems that solve real-world problems.</p>" +
                        "<p>Our mission is to democratize AI technology, making advanced artificial intelligence accessible and practical for organizations of all sizes.</p>" +
                        "</div><div class=\"col-lg-6\"><div class=\"feature-card\"><h3>Our Vision</h3>" +
                        "<p>To create a world where artificial intelligence enhances human capabilities and drives sustainable innovation across all industries.</p>" +
                        "<h3>Our Values</h3><ul><li><strong>Innovation:</strong> Pushing the boundaries of what's possible with AI</li>" +
                        "<li><strong>Ethics:</strong> Developing responsible AI solutions</li>" +
                        "<li><strong>Excellence:</strong> Delivering superior technology and service</li>" +
                        "<li><strong>Partnership:</strong> Building lasting relationships with our clients</li></ul></div></div>" +
                        "</div></div></div>"
                    }
                }
            });

            // Services Page
            _pageTemplates.Add(new PageTemplate
            {
                Name = "Services",
                Parent = "",
                Order = 3,
                Path = "services",
                Icon = "oi oi-wrench",
                IsNavigation = true,
                IsPersonalizable = false,
                ThemeType = "Oqtane.Themes.OrkinosAITheme.Default, Oqtane.Client",
                PermissionList = new List<Permission> {
                    new Permission(PermissionNames.View, RoleNames.Everyone, true),
                    new Permission(PermissionNames.View, RoleNames.Admin, true),
                    new Permission(PermissionNames.Edit, RoleNames.Admin, true)
                },
                PageTemplateModules = new List<PageTemplateModule> {
                    new PageTemplateModule { 
                        ModuleDefinitionName = "Oqtane.Modules.HtmlText, Oqtane.Client", 
                        Title = "Our Services", 
                        Pane = PaneNames.Default, 
                        PermissionList = new List<Permission> {
                            new Permission(PermissionNames.View, RoleNames.Everyone, true),
                            new Permission(PermissionNames.View, RoleNames.Admin, true),
                            new Permission(PermissionNames.Edit, RoleNames.Admin, true)
                        },
                        Content = "<div class=\"section-padding\"><div class=\"container\"><div class=\"text-center mb-5\">" +
                        "<h1 class=\"gradient-text\">Comprehensive AI Services</h1>" +
                        "<p class=\"lead\">From consultation to implementation, we provide end-to-end AI solutions tailored to your business needs.</p></div>" +
                        "<div class=\"row g-4\">" +
                        "<div class=\"col-md-6\"><div class=\"card h-100\"><div class=\"card-body\"><h4 class=\"text-primary mb-3\">AI Consulting</h4>" +
                        "<p>Strategic guidance to identify AI opportunities, assess feasibility, and develop implementation roadmaps for your organization.</p>" +
                        "<ul><li>AI readiness assessment</li><li>Use case identification</li><li>Technology selection</li><li>ROI analysis</li></ul></div></div></div>" +
                        "<div class=\"col-md-6\"><div class=\"card h-100\"><div class=\"card-body\"><h4 class=\"text-primary mb-3\">Custom AI Development</h4>" +
                        "<p>Tailored AI solutions designed and built specifically for your unique business requirements and challenges.</p>" +
                        "<ul><li>Machine learning models</li><li>Computer vision systems</li><li>NLP applications</li><li>Predictive analytics</li></ul></div></div></div>" +
                        "<div class=\"col-md-6\"><div class=\"card h-100\"><div class=\"card-body\"><h4 class=\"text-primary mb-3\">AI Integration</h4>" +
                        "<p>Seamless integration of AI capabilities into your existing systems and workflows without disrupting operations.</p>" +
                        "<ul><li>API development</li><li>System integration</li><li>Data pipeline setup</li><li>Performance optimization</li></ul></div></div></div>" +
                        "<div class=\"col-md-6\"><div class=\"card h-100\"><div class=\"card-body\"><h4 class=\"text-primary mb-3\">AI Training & Support</h4>" +
                        "<p>Comprehensive training programs and ongoing support to ensure your team can effectively use and maintain AI systems.</p>" +
                        "<ul><li>Technical training</li><li>Best practices workshops</li><li>24/7 support</li><li>Performance monitoring</li></ul></div></div></div>" +
                        "</div></div></div>"
                    }
                }
            });

            // Products Page
            _pageTemplates.Add(new PageTemplate
            {
                Name = "Products",
                Parent = "",
                Order = 4,
                Path = "products",
                Icon = "oi oi-box",
                IsNavigation = true,
                IsPersonalizable = false,
                ThemeType = "Oqtane.Themes.OrkinosAITheme.Default, Oqtane.Client",
                PermissionList = new List<Permission> {
                    new Permission(PermissionNames.View, RoleNames.Everyone, true),
                    new Permission(PermissionNames.View, RoleNames.Admin, true),
                    new Permission(PermissionNames.Edit, RoleNames.Admin, true)
                },
                PageTemplateModules = new List<PageTemplateModule> {
                    new PageTemplateModule { 
                        ModuleDefinitionName = "Oqtane.Modules.HtmlText, Oqtane.Client", 
                        Title = "AI Products & Solutions", 
                        Pane = PaneNames.Default, 
                        PermissionList = new List<Permission> {
                            new Permission(PermissionNames.View, RoleNames.Everyone, true),
                            new Permission(PermissionNames.View, RoleNames.Admin, true),
                            new Permission(PermissionNames.Edit, RoleNames.Admin, true)
                        },
                        Content = "<div class=\"section-padding\"><div class=\"container\"><div class=\"text-center mb-5\">" +
                        "<h1 class=\"gradient-text\">Innovative AI Products</h1>" +
                        "<p class=\"lead\">Explore our flagship AI products designed to transform your business operations and drive intelligent automation.</p></div>" +
                        "<div class=\"row g-4\">" +
                        "<div class=\"col-lg-4\"><div class=\"card h-100 shadow-lg-hover\"><div class=\"card-body text-center\">" +
                        "<div class=\"feature-icon mb-3\"><i class=\"oi oi-dashboard\"></i></div>" +
                        "<h4 class=\"text-primary\">OrkinosAI Analytics</h4>" +
                        "<p>Advanced analytics platform powered by machine learning for real-time business intelligence and predictive insights.</p>" +
                        "<ul class=\"text-start\"><li>Real-time data processing</li><li>Predictive modeling</li><li>Interactive dashboards</li><li>Automated reporting</li></ul>" +
                        "<a href=\"/contact\" class=\"btn btn-primary\">Learn More</a></div></div></div>" +
                        "<div class=\"col-lg-4\"><div class=\"card h-100 shadow-lg-hover\"><div class=\"card-body text-center\">" +
                        "<div class=\"feature-icon mb-3\"><i class=\"oi oi-robot\"></i></div>" +
                        "<h4 class=\"text-primary\">OrkinosAI Assistant</h4>" +
                        "<p>Intelligent virtual assistant that understands natural language and automates complex business processes.</p>" +
                        "<ul class=\"text-start\"><li>Natural language processing</li><li>Task automation</li><li>Multi-channel support</li><li>Learning capabilities</li></ul>" +
                        "<a href=\"/contact\" class=\"btn btn-primary\">Learn More</a></div></div></div>" +
                        "<div class=\"col-lg-4\"><div class=\"card h-100 shadow-lg-hover\"><div class=\"card-body text-center\">" +
                        "<div class=\"feature-icon mb-3\"><i class=\"oi oi-shield\"></i></div>" +
                        "<h4 class=\"text-primary\">OrkinosAI Security</h4>" +
                        "<p>AI-powered cybersecurity solution that detects and prevents threats in real-time using advanced machine learning.</p>" +
                        "<ul class=\"text-start\"><li>Threat detection</li><li>Behavioral analysis</li><li>Automated response</li><li>Risk assessment</li></ul>" +
                        "<a href=\"/contact\" class=\"btn btn-primary\">Learn More</a></div></div></div>" +
                        "</div></div></div>"
                    }
                }
            });

            // Founder Page
            _pageTemplates.Add(new PageTemplate
            {
                Name = "Founder",
                Parent = "",
                Order = 5,
                Path = "founder",
                Icon = "oi oi-person",
                IsNavigation = true,
                IsPersonalizable = false,
                ThemeType = "Oqtane.Themes.OrkinosAITheme.Default, Oqtane.Client",
                PermissionList = new List<Permission> {
                    new Permission(PermissionNames.View, RoleNames.Everyone, true),
                    new Permission(PermissionNames.View, RoleNames.Admin, true),
                    new Permission(PermissionNames.Edit, RoleNames.Admin, true)
                },
                PageTemplateModules = new List<PageTemplateModule> {
                    new PageTemplateModule { 
                        ModuleDefinitionName = "Oqtane.Modules.HtmlText, Oqtane.Client", 
                        Title = "Meet Our Founder", 
                        Pane = PaneNames.Default, 
                        PermissionList = new List<Permission> {
                            new Permission(PermissionNames.View, RoleNames.Everyone, true),
                            new Permission(PermissionNames.View, RoleNames.Admin, true),
                            new Permission(PermissionNames.Edit, RoleNames.Admin, true)
                        },
                        Content = "<div class=\"section-padding\"><div class=\"container\"><div class=\"row align-items-center\">" +
                        "<div class=\"col-lg-6\"><div class=\"feature-card text-center\">" +
                        "<div style=\"width: 200px; height: 200px; margin: 0 auto 2rem; background: var(--orkinosai-gradient); border-radius: 50%; display: flex; align-items: center; justify-content: center; color: white; font-size: 4rem;\">" +
                        "<i class=\"oi oi-person\"></i></div>" +
                        "<h3>Dr. Alex Orkinos</h3><p class=\"text-muted\">Founder & CEO</p></div></div>" +
                        "<div class=\"col-lg-6\"><h1 class=\"gradient-text mb-4\">Visionary Leader in AI</h1>" +
                        "<p class=\"lead\">Dr. Alex Orkinos is a renowned AI researcher and entrepreneur with over 15 years of experience in artificial intelligence and machine learning.</p>" +
                        "<p>With a Ph.D. in Computer Science from MIT and former roles at leading tech companies, Dr. Orkinos has been instrumental in developing breakthrough AI technologies that have transformed industries.</p>" +
                        "<div class=\"mt-4\"><h4>Achievements & Recognition</h4><ul>" +
                        "<li>Published 50+ research papers in top-tier AI conferences</li>" +
                        "<li>Named in Forbes '30 Under 30' for Technology</li>" +
                        "<li>Keynote speaker at major AI conferences worldwide</li>" +
                        "<li>Former Principal Scientist at Google DeepMind</li>" +
                        "<li>Advisor to multiple AI startups and organizations</li></ul></div>" +
                        "<div class=\"mt-4\"><blockquote class=\"blockquote\"><p>\"AI has the power to solve humanity's greatest challenges. At OrkinosAI, we're committed to making that vision a reality.\"</p></blockquote></div>" +
                        "</div></div></div></div>"
                    }
                }
            });

            // Contact Page
            _pageTemplates.Add(new PageTemplate
            {
                Name = "Contact",
                Parent = "",
                Order = 6,
                Path = "contact",
                Icon = "oi oi-envelope-closed",
                IsNavigation = true,
                IsPersonalizable = false,
                ThemeType = "Oqtane.Themes.OrkinosAITheme.Default, Oqtane.Client",
                PermissionList = new List<Permission> {
                    new Permission(PermissionNames.View, RoleNames.Everyone, true),
                    new Permission(PermissionNames.View, RoleNames.Admin, true),
                    new Permission(PermissionNames.Edit, RoleNames.Admin, true)
                },
                PageTemplateModules = new List<PageTemplateModule> {
                    new PageTemplateModule { 
                        ModuleDefinitionName = "Oqtane.Modules.HtmlText, Oqtane.Client", 
                        Title = "Get in Touch", 
                        Pane = PaneNames.Default, 
                        PermissionList = new List<Permission> {
                            new Permission(PermissionNames.View, RoleNames.Everyone, true),
                            new Permission(PermissionNames.View, RoleNames.Admin, true),
                            new Permission(PermissionNames.Edit, RoleNames.Admin, true)
                        },
                        Content = "<div class=\"section-padding\"><div class=\"container\"><div class=\"text-center mb-5\">" +
                        "<h1 class=\"gradient-text\">Contact OrkinosAI</h1>" +
                        "<p class=\"lead\">Ready to transform your business with AI? We'd love to hear from you.</p></div>" +
                        "<div class=\"row g-4\">" +
                        "<div class=\"col-lg-8\"><div class=\"card\"><div class=\"card-body\"><h4 class=\"text-primary mb-4\">Send us a Message</h4>" +
                        "<form><div class=\"row\"><div class=\"col-md-6 mb-3\"><label class=\"form-label\">First Name</label><input type=\"text\" class=\"form-control\"></div>" +
                        "<div class=\"col-md-6 mb-3\"><label class=\"form-label\">Last Name</label><input type=\"text\" class=\"form-control\"></div></div>" +
                        "<div class=\"mb-3\"><label class=\"form-label\">Email</label><input type=\"email\" class=\"form-control\"></div>" +
                        "<div class=\"mb-3\"><label class=\"form-label\">Company</label><input type=\"text\" class=\"form-control\"></div>" +
                        "<div class=\"mb-3\"><label class=\"form-label\">How can we help you?</label><select class=\"form-select\"><option>AI Consulting</option><option>Custom Development</option><option>Product Demo</option><option>Partnership</option><option>Other</option></select></div>" +
                        "<div class=\"mb-3\"><label class=\"form-label\">Message</label><textarea class=\"form-control\" rows=\"5\"></textarea></div>" +
                        "<button type=\"submit\" class=\"btn btn-primary btn-lg\">Send Message</button></form></div></div></div>" +
                        "<div class=\"col-lg-4\"><div class=\"card h-100\"><div class=\"card-body\">" +
                        "<h4 class=\"text-primary mb-4\">Contact Information</h4>" +
                        "<div class=\"mb-4\"><div class=\"d-flex align-items-center mb-2\"><i class=\"oi oi-map-marker me-3 text-primary\"></i><strong>Address</strong></div>" +
                        "<p class=\"mb-0 ms-4\">123 AI Innovation Drive<br>Silicon Valley, CA 94043<br>United States</p></div>" +
                        "<div class=\"mb-4\"><div class=\"d-flex align-items-center mb-2\"><i class=\"oi oi-phone me-3 text-primary\"></i><strong>Phone</strong></div>" +
                        "<p class=\"mb-0 ms-4\">+1 (555) 123-4567</p></div>" +
                        "<div class=\"mb-4\"><div class=\"d-flex align-items-center mb-2\"><i class=\"oi oi-envelope-closed me-3 text-primary\"></i><strong>Email</strong></div>" +
                        "<p class=\"mb-0 ms-4\">hello@orkinosai.com</p></div>" +
                        "<div><div class=\"d-flex align-items-center mb-2\"><i class=\"oi oi-clock me-3 text-primary\"></i><strong>Business Hours</strong></div>" +
                        "<p class=\"mb-0 ms-4\">Monday - Friday: 9:00 AM - 6:00 PM PST<br>Saturday - Sunday: Closed</p></div>" +
                        "</div></div></div></div></div></div>"
                    },
                    new PageTemplateModule { 
                        ModuleDefinitionName = "Oqtane.Modules.HtmlText, Oqtane.Client", 
                        Title = "Ready to Get Started?", 
                        Pane = "Call to Action", 
                        PermissionList = new List<Permission> {
                            new Permission(PermissionNames.View, RoleNames.Everyone, true),
                            new Permission(PermissionNames.View, RoleNames.Admin, true),
                            new Permission(PermissionNames.Edit, RoleNames.Admin, true)
                        },
                        Content = "<div class=\"cta-section\"><div class=\"container\"><div class=\"cta-content\">" +
                        "<h2 class=\"mb-4\">Transform Your Business with AI Today</h2>" +
                        "<p class=\"lead mb-4\">Join hundreds of companies already using OrkinosAI solutions to drive innovation and growth.</p>" +
                        "<a href=\"#\" class=\"btn btn-primary btn-lg me-3\">Schedule a Demo</a>" +
                        "<a href=\"#\" class=\"btn btn-outline-light btn-lg\">Download Brochure</a>" +
                        "</div></div></div>"
                    }
                }
            });

            // Setup OrkinosAI logo if it exists
            if (System.IO.File.Exists(Path.Combine(_environment.WebRootPath, "images", "orkinosai-logo.png")))
            {
                string folderpath = Utilities.PathCombine(_environment.ContentRootPath, "Content", "Tenants", site.TenantId.ToString(), "Sites", site.SiteId.ToString(), Path.DirectorySeparatorChar.ToString());
                System.IO.Directory.CreateDirectory(folderpath);
                if (!System.IO.File.Exists(Path.Combine(folderpath, "orkinosai-logo.png")))
                {
                    System.IO.File.Copy(Path.Combine(_environment.WebRootPath, "images", "orkinosai-logo.png"), Path.Combine(folderpath, "orkinosai-logo.png"));
                }
                Folder folder = _folderRepository.GetFolder(site.SiteId, "");
                Oqtane.Models.File file = _fileRepository.AddFile(new Oqtane.Models.File { FolderId = folder.FolderId, Name = "orkinosai-logo.png", Extension = "png", Size = 8192, ImageHeight = 80, ImageWidth = 250 });
                site.LogoFileId = file.FileId;
                _siteRepository.UpdateSite(site);
            }

            // Add footer content to the home page
            if (_pageTemplates.Count > 0)
            {
                _pageTemplates[0].PageTemplateModules.Add(new PageTemplateModule
                {
                    ModuleDefinitionName = "Oqtane.Modules.HtmlText, Oqtane.Client",
                    Title = "Company Information",
                    Pane = "Footer Left",
                    PermissionList = new List<Permission> {
                        new Permission(PermissionNames.View, RoleNames.Everyone, true),
                        new Permission(PermissionNames.View, RoleNames.Admin, true),
                        new Permission(PermissionNames.Edit, RoleNames.Admin, true)
                    },
                    Content = "<h5 class=\"text-white mb-3\">OrkinosAI</h5>" +
                    "<p>Leading the AI revolution with innovative solutions that transform businesses and drive sustainable growth.</p>" +
                    "<div class=\"d-flex gap-2 mt-3\">" +
                    "<a href=\"#\" class=\"text-decoration-none\"><i class=\"oi oi-social-twitter\"></i></a>" +
                    "<a href=\"#\" class=\"text-decoration-none\"><i class=\"oi oi-social-linkedin\"></i></a>" +
                    "<a href=\"#\" class=\"text-decoration-none\"><i class=\"oi oi-social-github\"></i></a>" +
                    "</div>"
                });

                _pageTemplates[0].PageTemplateModules.Add(new PageTemplateModule
                {
                    ModuleDefinitionName = "Oqtane.Modules.HtmlText, Oqtane.Client",
                    Title = "Quick Links",
                    Pane = "Footer Center Left",
                    PermissionList = new List<Permission> {
                        new Permission(PermissionNames.View, RoleNames.Everyone, true),
                        new Permission(PermissionNames.View, RoleNames.Admin, true),
                        new Permission(PermissionNames.Edit, RoleNames.Admin, true)
                    },
                    Content = "<h5 class=\"text-white mb-3\">Quick Links</h5>" +
                    "<ul class=\"list-unstyled\">" +
                    "<li><a href=\"/about\">About Us</a></li>" +
                    "<li><a href=\"/services\">Services</a></li>" +
                    "<li><a href=\"/products\">Products</a></li>" +
                    "<li><a href=\"/founder\">Leadership</a></li>" +
                    "</ul>"
                });

                _pageTemplates[0].PageTemplateModules.Add(new PageTemplateModule
                {
                    ModuleDefinitionName = "Oqtane.Modules.HtmlText, Oqtane.Client",
                    Title = "Services",
                    Pane = "Footer Center Right",
                    PermissionList = new List<Permission> {
                        new Permission(PermissionNames.View, RoleNames.Everyone, true),
                        new Permission(PermissionNames.View, RoleNames.Admin, true),
                        new Permission(PermissionNames.Edit, RoleNames.Admin, true)
                    },
                    Content = "<h5 class=\"text-white mb-3\">Services</h5>" +
                    "<ul class=\"list-unstyled\">" +
                    "<li><a href=\"/services\">AI Consulting</a></li>" +
                    "<li><a href=\"/services\">Custom Development</a></li>" +
                    "<li><a href=\"/services\">AI Integration</a></li>" +
                    "<li><a href=\"/services\">Training & Support</a></li>" +
                    "</ul>"
                });

                _pageTemplates[0].PageTemplateModules.Add(new PageTemplateModule
                {
                    ModuleDefinitionName = "Oqtane.Modules.HtmlText, Oqtane.Client",
                    Title = "Contact Information",
                    Pane = "Footer Right",
                    PermissionList = new List<Permission> {
                        new Permission(PermissionNames.View, RoleNames.Everyone, true),
                        new Permission(PermissionNames.View, RoleNames.Admin, true),
                        new Permission(PermissionNames.Edit, RoleNames.Admin, true)
                    },
                    Content = "<h5 class=\"text-white mb-3\">Contact Info</h5>" +
                    "<div class=\"mb-2\"><i class=\"oi oi-map-marker me-2\"></i>123 AI Innovation Drive<br><span class=\"ms-4\">Silicon Valley, CA 94043</span></div>" +
                    "<div class=\"mb-2\"><i class=\"oi oi-phone me-2\"></i>+1 (555) 123-4567</div>" +
                    "<div class=\"mb-2\"><i class=\"oi oi-envelope-closed me-2\"></i>hello@orkinosai.com</div>"
                });

                _pageTemplates[0].PageTemplateModules.Add(new PageTemplateModule
                {
                    ModuleDefinitionName = "Oqtane.Modules.HtmlText, Oqtane.Client",
                    Title = "Copyright",
                    Pane = "Footer Bottom",
                    PermissionList = new List<Permission> {
                        new Permission(PermissionNames.View, RoleNames.Everyone, true),
                        new Permission(PermissionNames.View, RoleNames.Admin, true),
                        new Permission(PermissionNames.Edit, RoleNames.Admin, true)
                    },
                    Content = "<div class=\"text-center pt-4 border-top border-secondary\">" +
                    "<p class=\"mb-0\">&copy; 2024 OrkinosAI. All rights reserved. | " +
                    "<a href=\"#\" class=\"text-decoration-none\">Privacy Policy</a> | " +
                    "<a href=\"#\" class=\"text-decoration-none\">Terms of Service</a></p>" +
                    "</div>"
                });
            }

            return _pageTemplates;
        }
    }
}