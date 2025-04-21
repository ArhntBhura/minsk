using Minsk.CodeAnalysis.Text;

namespace Minsk.Tests.CodeAnalysis.Text
{
    public class SourceTextTests
    {
        [Theory]
        [InlineData(".", 1)]
        [InlineData(".\r\n", 2)]
        [InlineData(".\r\n\r\n", 3)]
        public void SourceText_IncludesLastLine(string text, int exprectedCount)
        {
            var sourceText = SourceText.From(text);
            Assert.Equal(exprectedCount, sourceText.Lines.Length);
        }
    }
}