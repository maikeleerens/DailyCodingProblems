using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    /// <summary>
    /// This problem was asked by Microsoft.
    /// 
    /// Given a dictionary of words and a string made up of those words(no spaces), return the original sentence in a list.
    /// If there is more than one possible reconstruction, return any of them.
    /// If there is no possible reconstruction, then return null.
    /// 
    /// For example, given the set of words 'quick', 'brown', 'the', 'fox', and the string "thequickbrownfox",
    /// you should return ['the', 'quick', 'brown', 'fox'].
    /// 
    /// Given the set of words 'bed', 'bath', 'bedbath', 'and', 'beyond', and the string "bedbathandbeyond",
    /// return either['bed', 'bath', 'and', 'beyond] or ['bedbath', 'and', 'beyond'].
    /// </summary>
    public static class Problem022
    {
        /// <summary>
        /// Creates new string list with given words and sentence
        /// </summary>
        /// <param name="words"></param>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public static IReadOnlyCollection<string>? CreateStringList(IReadOnlyCollection<string> dictionary, string sentence)
        {
            var returnList = new List<string>();
            var word = string.Empty;

            // Create new word letter by letter, and add to result list when word is present in dictionary
            foreach (var letter in sentence)
            {
                word += letter;

                if (!dictionary.Contains(word))
                    continue;

                returnList.Add(word);
                word = string.Empty;
            }

            return returnList.Any() ? returnList : null;
        }
    }
}
