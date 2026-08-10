using Microsoft.AspNetCore.Mvc;
using NZwalks.UI.Models;
using System.Text;
using System.Text.Json;

namespace NZwalks.UI.Controllers
{
    public class RegionsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegionsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://127.0.0.1:5150/api/regions");

            response.EnsureSuccessStatusCode();

            var regions = await response.Content.ReadFromJsonAsync<List<RegionDto>>();

            return View(regions ?? new List<RegionDto>());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRegionViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://127.0.0.1:5150/api/regions");

            request.Content = new StringContent(
                JsonSerializer.Serialize(model),
                Encoding.UTF8,
                "application/json");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return RedirectToAction(nameof(Index));
        }
    }
}
