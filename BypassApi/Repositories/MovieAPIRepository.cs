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
        private readonly IMovieAPIConnector _movieAPIConnection;

        public MovieAPIRepository(IMovieAPIConnector movieAPIConnection)
        {
            _movieAPIConnection = movieAPIConnection;
        }
        private string InvertString(string toInvert)
        {
            if (toInvert == null) return null;
            char[] toInvertArray = toInvert.ToCharArray();
            Array.Reverse(toInvertArray);
            return new string(toInvertArray);
        }

        public async Task<MovieViewModel> GetMovieById(int Id)
        {
            var result = await _movieAPIConnection.GetAsync($"movie/{Id}");

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
