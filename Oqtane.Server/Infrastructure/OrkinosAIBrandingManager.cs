using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Oqtane.Models;
using Oqtane.Repository;
using Oqtane.Shared;
using System;
using System.IO;
using System.Linq;

namespace Oqtane.Infrastructure
{
    public interface IOrkinosAIBrandingManager
    {
        bool ApplyOrkinosAIBranding(int siteId);
        bool IsOrkinosAISite(int siteId);
    }

    public class OrkinosAIBrandingManager : IOrkinosAIBrandingManager
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ISiteRepository _siteRepository;
        private readonly IFolderRepository _folderRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IPageRepository _pageRepository;
        private readonly ILogger<OrkinosAIBrandingManager> _logger;

        public OrkinosAIBrandingManager(
            IWebHostEnvironment environment,
            ISiteRepository siteRepository,
            IFolderRepository folderRepository,
            IFileRepository fileRepository,
            IPageRepository pageRepository,
            ILogger<OrkinosAIBrandingManager> logger)
        {
            _environment = environment;
            _siteRepository = siteRepository;
            _folderRepository = folderRepository;
            _fileRepository = fileRepository;
            _pageRepository = pageRepository;
            _logger = logger;
        }

        public bool IsOrkinosAISite(int siteId)
        {
            try
            {
                var site = _siteRepository.GetSite(siteId);
                if (site == null) return false;

                // Check if site name indicates OrkinosAI usage
                if (site.Name != null && site.Name.Contains("OrkinosAI", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                // Check if any pages use OrkinosAI theme
                var pages = _pageRepository.GetPages(siteId);
                if (pages.Any(p => p.ThemeType != null && p.ThemeType.Contains("OrkinosAITheme")))
                {
                    return true;
                }

                // Check if OrkinosAI logo exists in site files
                var folders = _folderRepository.GetFolders(siteId);
                foreach (var folder in folders)
                {
                    var files = _fileRepository.GetFiles(folder.FolderId);
                    if (files.Any(f => f.Name != null && f.Name.Contains("orkinosai", StringComparison.OrdinalIgnoreCase)))
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking if site {SiteId} is OrkinosAI site", siteId);
                return false;
            }
        }

        public bool ApplyOrkinosAIBranding(int siteId)
        {
            try
            {
                var site = _siteRepository.GetSite(siteId);
                if (site == null)
                {
                    _logger.LogWarning("Site {SiteId} not found", siteId);
                    return false;
                }

                _logger.LogInformation("Applying OrkinosAI branding to site {SiteId}: {SiteName}", siteId, site.Name);

                // Apply OrkinosAI logo
                var logoApplied = ApplyOrkinosAILogo(site);

                // Apply OrkinosAI theme to pages
                var themeApplied = ApplyOrkinosAITheme(site);

                if (logoApplied || themeApplied)
                {
                    _logger.LogInformation("OrkinosAI branding successfully applied to site {SiteId}", siteId);
                    return true;
                }
                else
                {
                    _logger.LogWarning("No OrkinosAI branding changes were made to site {SiteId}", siteId);
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error applying OrkinosAI branding to site {SiteId}", siteId);
                return false;
            }
        }

        private bool ApplyOrkinosAILogo(Site site)
        {
            try
            {
                // Skip if logo is already set
                if (site.LogoFileId != null)
                {
                    _logger.LogDebug("Site {SiteId} already has a logo set", site.SiteId);
                    return false;
                }

                var logoPath = Path.Combine(_environment.WebRootPath, "images", "orkinosai-logo.png");
                if (!System.IO.File.Exists(logoPath))
                {
                    _logger.LogWarning("OrkinosAI logo file not found at {LogoPath}", logoPath);
                    return false;
                }

                // Create site content directory if it doesn't exist
                string folderpath = Utilities.PathCombine(_environment.ContentRootPath, "Content", "Tenants", 
                    site.TenantId.ToString(), "Sites", site.SiteId.ToString(), Path.DirectorySeparatorChar.ToString());
                System.IO.Directory.CreateDirectory(folderpath);

                // Copy logo to site content directory
                var siteLogoPath = Path.Combine(folderpath, "orkinosai-logo.png");
                if (!System.IO.File.Exists(siteLogoPath))
                {
                    System.IO.File.Copy(logoPath, siteLogoPath, true);
                }

                // Get or create root folder
                var folder = _folderRepository.GetFolder(site.SiteId, "");
                if (folder == null)
                {
                    _logger.LogError("Could not find root folder for site {SiteId}", site.SiteId);
                    return false;
                }

                // Check if file already exists in database
                var existingFiles = _fileRepository.GetFiles(folder.FolderId);
                var existingLogoFile = existingFiles.FirstOrDefault(f => f.Name == "orkinosai-logo.png");

                if (existingLogoFile != null)
                {
                    site.LogoFileId = existingLogoFile.FileId;
                }
                else
                {
                    // Add file to database
                    var file = _fileRepository.AddFile(new Oqtane.Models.File
                    {
                        FolderId = folder.FolderId,
                        Name = "orkinosai-logo.png",
                        Extension = "png",
                        Size = 8192,
                        ImageHeight = 80,
                        ImageWidth = 250
                    });
                    site.LogoFileId = file.FileId;
                }

                _siteRepository.UpdateSite(site);
                _logger.LogInformation("OrkinosAI logo applied to site {SiteId}", site.SiteId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error applying OrkinosAI logo to site {SiteId}", site.SiteId);
                return false;
            }
        }

        private bool ApplyOrkinosAITheme(Site site)
        {
            try
            {
                var pages = _pageRepository.GetPages(site.SiteId);
                var pagesUpdated = 0;

                foreach (var page in pages.Where(p => string.IsNullOrEmpty(p.ThemeType) || 
                    p.ThemeType.Contains("OqtaneTheme") || p.ThemeType.Contains("BlazorTheme")))
                {
                    page.ThemeType = "Oqtane.Themes.OrkinosAITheme.Default, Oqtane.Client";
                    _pageRepository.UpdatePage(page);
                    pagesUpdated++;
                }

                if (pagesUpdated > 0)
                {
                    _logger.LogInformation("OrkinosAI theme applied to {PagesCount} pages in site {SiteId}", pagesUpdated, site.SiteId);
                    return true;
                }
                else
                {
                    _logger.LogDebug("No pages needed theme update in site {SiteId}", site.SiteId);
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error applying OrkinosAI theme to site {SiteId}", site.SiteId);
                return false;
            }
        }
    }
}