using BypassApi.Interfaces;
using BypassApi.ViewModels;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BypassApi.Repositories
{
    public class MovieAPIRepository : IMovieAPIRepository
    {
        private IStringHelpers _stringHelpers;

        public MovieAPIRepository(IStringHelpers stringHelpers)
        {
            _stringHelpers = stringHelpers;
        }

        public async Task<MovieViewModel> GetMovieById(int Id)
        {
            using var client = new HttpClient
            {
                BaseAddress = new Uri($"https://api.themoviedb.org/3/movie/{Id}?api_key=82e1a6e0bc65e50a5fd5ea2b171e83da")
            };
            //HTTP GET
            var result = await client.GetAsync("");

            MovieViewModel movie = null;
            if (result.IsSuccessStatusCode)
            {

                string responseBody = await result.Content.ReadAsStringAsync();
                movie = JsonSerializer.Deserialize<MovieViewModel>(responseBody);
                movie.invertedTitle = _stringHelpers.InvertString(movie.title);
            } else if (result.StatusCode == HttpStatusCode.NotFound) {
                throw new Exception("Movie not found");
            }
            return movie;
        }
    }
}
