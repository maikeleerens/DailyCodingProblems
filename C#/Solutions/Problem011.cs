using System.Collections.Generic;
using System.Linq;

namespace Solutions
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
    public static class Problem011
    {
        /// <summary>
        /// Node in a <see cref="Trie"/>
        /// </summary>
        public class TrieNode
        {
            public IDictionary<char, TrieNode> SubNodes { get; }
            public string Word { get; }
            public bool IsWord { get; set; }

            public TrieNode(string word = "")
            {
                SubNodes = new Dictionary<char, TrieNode>();
                Word = word;
                IsWord = false;
            }
        }

        /// <summary>
        /// Prefix tree. https://en.wikipedia.org/wiki/Trie
        /// </summary>
        public class Trie
        {
            private readonly TrieNode _head = new TrieNode();

            public void Add(string word)
            {
                Add(_head, word);
            }

            private static void Add(TrieNode node, string subString)
            {
                var currentString = string.Empty;

                while (true)
                {
                    if (subString.Length == 0)
                    {
                        break;
                    }

                    var prefixChar = subString[0];
                    if (!node.SubNodes.ContainsKey(prefixChar))
                    {
                        node.SubNodes.Add(prefixChar, new TrieNode(currentString + prefixChar));
                    }

                    var remainingSubString = subString[1..];

                    if (remainingSubString.Length == 0)
                    {
                        node.SubNodes[prefixChar].IsWord = true;
                        break;
                    }

                    node = node.SubNodes[prefixChar];
                    subString = remainingSubString;
                    currentString += prefixChar;
                }
            }

            public IReadOnlyCollection<string> Search(string searchString)
            {
                var node = _head;
                foreach (var searchChar in searchString)
                {
                    if (!node.SubNodes.ContainsKey(searchChar))
                    {
                        return new string[0];
                    }
                    node = node.SubNodes[searchChar];
                }

                return Search(node);
            }

            private static IReadOnlyCollection<string> Search(TrieNode node)
            {
                var returnList = new List<string>();
                if (node.IsWord)
                {
                    returnList.Add(node.Word);
                }

                returnList.AddRange(node.SubNodes.SelectMany(subNode => Search(subNode.Value)));

                return returnList;
            }
        }
    }
}
