using System.Collections.Generic;
using System.ComponentModel;
using WordFinder;

namespace WordFinderTest
{
    public class WordFinderTests
    {
        private List<string> CreateMatrix()
        {
            return new List<string>{ "EBCDC", "RGWIO", "CHILL", "PQNSD", "UVDXY" };
        }
        [Fact]
        public void Find_WordsExistInMatrix_ReturnsFoundWords()
        {
            var matrix = new List<string>();
            matrix.Add("EBCDC");
            matrix.Add("RGWIO");
            matrix.Add("CHILL");
            matrix.Add("PQNSD");
            matrix.Add("UVDXY");
            var wordFinder = new WordFinder.WordFinder(matrix);

            var words = new List<string> { "COLD", "WIND", "CHILL", "SNOW" };
            var result = wordFinder.Find(words).ToList();

            Assert.Equal(3, result.Count);
            Assert.Contains("CHILL", result);
            Assert.Contains("COLD", result);
            Assert.Contains("WIND", result);
        }

        [Fact]
        public void Find_WordsNotInMatrix_DoesNotReturnThem()
        {
            var matrix = CreateMatrix();
            var wordFinder = new WordFinder.WordFinder(matrix);
            var words = new List<string> { "SUNNY", "SNOW" };

            var result = wordFinder.Find(words).ToList();

            Assert.DoesNotContain("SUNNY", result);
            Assert.DoesNotContain("SNOW", result);
        }
        [Fact]
        public void Find_EmptyWordList_ReturnsEmptyList()
        {
            var matrix = CreateMatrix();
            var wordFinder = new WordFinder.WordFinder(matrix);
            var words = new List<string>();

            var result = wordFinder.Find(words).ToList();

            Assert.Empty(result);
        }
    }
}
