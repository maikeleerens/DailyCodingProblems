using Solutions;
using Xunit;

namespace SolutionsTest
{
    /// <summary>
    /// This problem was asked by Twitter.
    /// 
    /// Implement an autocomplete system. That is, given a query string s and a set of all possible query strings, return all strings in the set that have s as a prefix.
    /// 
    /// For example, given the query string de and the set of strings[dog, deer, deal], return [deer, deal].
    /// 
    /// Hint: Try preprocessing the dictionary into a more efficient data structure to speed up queries.
    /// </summary>
    public class Problem011Test
    {
        [Fact]
        public void Problem011SolutionTest()
        {
            var trie = new Problem011.Trie();
            trie.Add("dog");
            trie.Add("dear");
            trie.Add("deal");

            Assert.Equal(2, trie.Search("de").Count);
        }
    }
}
