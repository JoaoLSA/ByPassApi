using BypassApi.Interfaces;
using BypassApi.ViewModels;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace BypassApi.Repositories
{
    public class MovieAPIRepository : IMovieAPIRepository
    {
        private IStringHelpers _stringHelpers;
        private readonly IMovieAPIConnector _movieAPIConnection;

        public MovieAPIRepository(IMovieAPIConnector movieAPIConnection, IStringHelpers stringHelpers)
        {
            _movieAPIConnection = movieAPIConnection;
            _stringHelpers = stringHelpers;
        }

        public async Task<MovieViewModel> GetMovieById(int Id)
        {
            var result = await _movieAPIConnection.HttpClient.GetAsync($"");

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
