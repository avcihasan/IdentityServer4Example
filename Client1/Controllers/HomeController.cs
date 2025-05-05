using System.Diagnostics;
using Client1.Models;
using Duende.IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Client1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly IConfiguration _configuration;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }


        [Authorize]
        [Route("qqq")]
        public IActionResult test()
        {
            return Ok();
        }
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
         
            DiscoveryDocumentResponse disco = await client.GetDiscoveryDocumentAsync("https://localhost:7200");


            TokenResponse response = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest()
            {
                ClientId = _configuration["ClientInfo:ClientId"],
                ClientSecret = _configuration["ClientInfo:ClientSecret"],
                Address = disco.TokenEndpoint
            });


            client.SetBearerToken(response.AccessToken);
            var _response = await client.GetAsync("https://localhost:7279/api/Test");
            var data =await _response.Content.ReadAsStringAsync();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
