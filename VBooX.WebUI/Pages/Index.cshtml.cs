using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using VBooX.WebUI.Helper;

namespace VBooX.WebUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApiConfig _apiConfig;

        public IndexModel(ILogger<IndexModel> logger, IOptions<ApiConfig> apiConfig)
        {
            _logger = logger;
            _apiConfig = apiConfig.Value;
        }

        public void OnGet()
        {
            var siteLocation = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
            HttpContext.Session.SetString("BaseUrl", _apiConfig.BaseUrl);
            HttpContext.Session.SetString("siteLocation", siteLocation);
        }
    }
}
