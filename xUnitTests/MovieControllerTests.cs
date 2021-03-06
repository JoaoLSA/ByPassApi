using BypassApi.Controllers;
using BypassApi.Interfaces;
using BypassApi.ViewModels;
using NSubstitute;
using System;
using Xunit;

namespace xUnitTests
{
    public class MovieControllerTests
    {
        private readonly MovieController _movieController;
        private readonly IMovieAPIRepository _movieAPIRepository;

        public MovieControllerTests()
        {
            _movieAPIRepository = Substitute.For<IMovieAPIRepository>();
            _movieController = new MovieController(_movieAPIRepository);
            _movieAPIRepository.GetMovieById(1).ReturnsForAnyArgs(new MovieViewModel { });
        }
        [Fact]
        public void WhenRequestIsValidThenSuccess()
        {
            var result = _movieController.Get(1);
            Assert.NotNull(result);
        }
    }
}
