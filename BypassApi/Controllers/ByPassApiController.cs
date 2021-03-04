using System;
using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BypassApi.Controllers
{
    class PopularMovie
    {
        public string title { get; set; }
    }

    [ApiController]
    [Route("/api")]
    public class ByPassApiController : ControllerBase
    {

        private readonly ILogger<ByPassApiController> _logger;

        public ByPassApiController(ILogger<ByPassApiController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async void Get()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.themoviedb.org/3/movie/550?api_key=82e1a6e0bc65e50a5fd5ea2b171e83da");
                //HTTP GET
                var result = await client.GetAsync("");

                if (result.IsSuccessStatusCode)
                {

                    string responseBody = await result.Content.ReadAsStringAsync();
                    var test = JsonSerializer.Deserialize<PopularMovie>(responseBody);
                    Console.WriteLine(test);
                }
            }
        }
    }
}
