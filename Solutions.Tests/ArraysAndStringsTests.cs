using FluentAssertions;

namespace Solutions.Tests
{
    public class ArraysAndStringsTests
    {
        [Theory]
        [InlineData(new int[] { -4, -2, 1, 4, 8 }, 1)]
        [InlineData(new int[] { 2, -1, 1 }, 1)]
        public void ClosestNumberToZeroTest(int[] input, int expected)
        {
            // Act
            int result = ArraysAndStrings.ClosestNumberToZero(input);

            // Assert
            result.Should()
                .Be(expected);
        }

        [Theory]
        [InlineData("abc", "pqr", "apbqcr")]
        [InlineData("ab", "pqrs", "apbqrs")]
        [InlineData("abcd", "pq", "apbqcd")]
        public void MergeAlternatelyTest(string word1, string word2, string expected)
        {
            // Act
            string result = ArraysAndStrings.MergeAlternately(word1, word2);

            // Assert
            result.Should()
                .Be(expected);
        }

        [Theory]
        [InlineData("III", 3)]
        [InlineData("LVIII", 58)]
        [InlineData("MCMXCIV", 1994)]
        public void RomanToIntTest(string input, int expected)
        {
            // Act
            int result = ArraysAndStrings.RomanToInt(input);

            // Assert
            result.Should()
                .Be(expected);
        }

        [Theory]
        [InlineData("abc", "ahbgdc", true)]
        [InlineData("axc", "ahbgdc", false)]
        [InlineData("aec", "abcde", false)]
        public void IsSybsequenceTest(string s, string t, bool expected)
        {
            // Act
            bool result = ArraysAndStrings.IsSybsequence(s, t);

            // Assert
            result.Should()
                .Be(expected);
        }

        [Theory]
        [InlineData(new int[] { 7, 1, 5, 3, 6, 4 }, 5)]
        [InlineData(new int[] { 7, 6, 4, 3, 1 }, 0)]
        public void MaxProfitTest(int[] prices, int expected)
        {
            // Act
            int result = ArraysAndStrings.MaxProfit(prices);

            // Assert
            result.Should()
                .Be(expected);
        }

        [Theory]
        [InlineData(new string[] { "flower", "flow", "flight" }, "fl")]
        [InlineData(new string[] { "dog", "racecar", "car" }, "")]
        public void LongestCommonPrefixTest(string[] data, string expected)
        {
            // Act
            string result = ArraysAndStrings.LongestCommonPrefix(data);

            // Assert
            result.Should()
                .Be(expected);
        }

        [Theory]
        [InlineData(new int[] { 0, 1, 2, 4, 5, 7 }, new string[] { "0->2", "4->5", "7" })]
        [InlineData(new int[] { 0, 2, 3, 4, 6, 8, 9 }, new string[] { "0", "2->4", "6", "8->9" })]
        public void SummaryRangeTest(int[] data, string[] expected)
        {
            // Act
            var result = ArraysAndStrings.SummaryRange(data);

            // Assert
            result.ToList()
                .Should()
                .BeEquivalentTo(expected.ToList());
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 24, 12, 8, 6 })]
        [InlineData(new int[] { -1, 1, 0, -3, 3 }, new int[] { 0, 0, 9, 0, 0 })]
        public void ProductExceptSelfTest(int[] data, int[] expected)
        {
            // Act
            var result = ArraysAndStrings.ProductExceptSelf(data);

            // Assert
            result.Should()
                .BeEquivalentTo(expected.ToList());
        }

        

        [Fact]
        public void MergeTest()
        {
            // Arrange
            int[][] interval = [[1, 3], [2, 6], [8, 10], [15, 18]];
            int[][] expected = [[1, 6], [8, 10], [15, 18]];

            // Act
            var result = ArraysAndStrings.Merge(interval);

            // Assert
            result.Should()
                .BeEquivalentTo(expected);
        }
    }
}