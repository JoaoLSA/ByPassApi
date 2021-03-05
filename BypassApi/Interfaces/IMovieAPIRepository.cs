using BypassApi.ViewModels;
using System.Threading.Tasks;

namespace BypassApi.Interfaces
{
    public interface IMovieAPIRepository
    {
        public Task<MovieViewModel> GetMovieById(int Id);
    }
}
