using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Oqtane.Infrastructure;
using Oqtane.Shared;

namespace Oqtane.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class OrkinosAIController : Controller
    {
        private readonly IOrkinosAIBrandingManager _brandingManager;
        private readonly ILogger<OrkinosAIController> _logger;

        public OrkinosAIController(IOrkinosAIBrandingManager brandingManager, ILogger<OrkinosAIController> logger)
        {
            _brandingManager = brandingManager;
            _logger = logger;
        }

        // GET: api/OrkinosAI/branding/check/{siteId}
        [HttpGet("branding/check/{siteId:int}")]
        [Authorize(Roles = RoleNames.Admin)]
        public IActionResult CheckOrkinosAIBranding(int siteId)
        {
            try
            {
                var isOrkinosAISite = _brandingManager.IsOrkinosAISite(siteId);
                return Ok(new { SiteId = siteId, IsOrkinosAISite = isOrkinosAISite });
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error checking OrkinosAI branding for site {SiteId}", siteId);
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/OrkinosAI/branding/apply/{siteId}
        [HttpPost("branding/apply/{siteId:int}")]
        [Authorize(Roles = RoleNames.Admin)]
        public IActionResult ApplyOrkinosAIBranding(int siteId)
        {
            try
            {
                var success = _brandingManager.ApplyOrkinosAIBranding(siteId);
                return Ok(new { SiteId = siteId, Success = success, Message = success ? "OrkinosAI branding applied successfully" : "No changes were made" });
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error applying OrkinosAI branding to site {SiteId}", siteId);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}