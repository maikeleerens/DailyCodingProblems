using System.Collections.Generic;
using Xunit;

namespace DailyCodingProblems.Solutions.Problem013
{
    /// <summary>
    /// This problem was asked by Amazon.
    /// 
    /// Given an integer k and a string s, find the length of the longest substring that contains at most k distinct characters.
    /// 
    /// For example, given s = "abcba" and k = 2, the longest substring with k distinct characters is "bcb".
    /// </summary>
    public class Problem013
    {
        [Fact]
        public void Problem013SolutionTest()
        {
            Assert.Equal(3, LongestSubStringWithDistinctCharacters(2, "abcba"));
        }

        public static int LongestSubStringWithDistinctCharacters(int k, string s)
        {
            return FindLongestSubString(k, s);
        }

        private static int FindLongestSubString(int k, string s)
        {
            var currentMaxLength = 0;
            while (s.Length > 0)
            {
                var foundCharacters = new List<char>();

                for (var i = 0; i < s.Length; i++)
                {
                    if (foundCharacters.Count >= k && !foundCharacters.Contains(s[i])) break;
                    foundCharacters.Add(s[i]);
                }

                s = s[1..];
                currentMaxLength = foundCharacters.Count > currentMaxLength ? foundCharacters.Count : currentMaxLength;
            }

            return currentMaxLength;
        }
    }
}
