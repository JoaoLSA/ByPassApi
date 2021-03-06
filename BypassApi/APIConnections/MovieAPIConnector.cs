using BypassApi.Interfaces;
using System;
using System.Net.Http;

namespace BypassApi.APIConnections
{
    public class MovieAPIConnector : IMovieAPIConnector
    {
        public HttpClient HttpClient { get; }
        public MovieAPIConnector()
        {
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri($"https://api.themoviedb.org/3/movie/550?api_key=82e1a6e0bc65e50a5fd5ea2b171e83da")
            };
        }
    }
}
