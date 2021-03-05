using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BypassApi.APIConnections
{
    public class MovieAPIConnector
    {
        public HttpClient MovieAPIConnection()
        {
            using var client = new HttpClient
            {
                BaseAddress = new Uri($"https://api.themoviedb.org/3/api_key=82e1a6e0bc65e50a5fd5ea2b171e83da")
            };
            return client;
        }
    }
}
