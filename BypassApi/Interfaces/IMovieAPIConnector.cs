
using System.Net.Http;

namespace BypassApi.Interfaces
{
    public interface IMovieAPIConnector
    {
        public HttpClient MovieAPIConnection();
    }
}
