using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BypassApi.Controllers
{
    public class Movie
    {
        public string title { get; set; }
    }

    [ApiController]
    [Route("/api")]
    public class ByPassApiController : ControllerBase
    {

        public ByPassApiController()
        {
        }

        [HttpGet]
        public async Task<Movie> Get(int Id)
        {
            try
            {
                using var client = new HttpClient
                {
                    BaseAddress = new Uri($"https://api.themoviedb.org/3/movie/{Id}?api_key=82e1a6e0bc65e50a5fd5ea2b171e83da")
                };
                //HTTP GET
                var result = await client.GetAsync("");

                Movie movie = null;
                if (result.IsSuccessStatusCode)
                {

                    string responseBody = await result.Content.ReadAsStringAsync();
                    movie = JsonSerializer.Deserialize<Movie>(responseBody);
                }
                return movie;
            } catch (Exception)
            {
                throw new Exception("Un unexpected error occurred");
            }
        }
    }
}
