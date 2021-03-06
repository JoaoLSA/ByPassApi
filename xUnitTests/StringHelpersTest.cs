using BypassApi.Helpers;
using Xunit;

namespace xUnitTests
{
    public class StringHelpersTests
    {
        private readonly StringHelpers _stringHelpers;
        public StringHelpersTests()
        {
            _stringHelpers = new StringHelpers();
        }

        [Fact]
        public void WhenReceivesStringReturnsItReversed()
        {
            var result1 = _stringHelpers.InvertString("ab");
            Assert.Equal("ba", result1);
            var result2 = _stringHelpers.InvertString("*/");
            Assert.Equal("/*", result2);
        }

        [Fact]
        public void WhenReceivesNullStringReturnsNull()
        {
            var result = _stringHelpers.InvertString(null);
            Assert.Null(result);
        }

        [Fact]
        public void WhenReceivesWhitespacesStringReturnsWhitespaces()
        {
            var result = _stringHelpers.InvertString("  ");
            Assert.Equal("  ", result);
        }
    }
}
