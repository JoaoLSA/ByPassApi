using BypassApi.Interfaces;
using BypassApi.ViewModels;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BypassApi.Repositories
{
    public class MovieAPIRepository : IMovieAPIRepository
    {
        private string InvertString(string toInvert)
        {
            if (toInvert == null) return null;
            char[] toInvertArray = toInvert.ToCharArray();
            Array.Reverse(toInvertArray);
            return new string(toInvertArray);
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
                movie.invertedTitle = this.InvertString(movie.title);
            }
            return movie;
        }
    }
}
