using System.Collections.Generic;
using Solutions;
using Xunit;

namespace SolutionsTest
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
    public class Problem022Test
    {
        [Fact]
        public void Problem022SolutionTest()
        {
            var stringList1 = new HashSet<string> {"the", "quick", "brown", "fox"};
            var stringList2 = new HashSet<string> {"bed", "bath", "bedbath", "and", "beyond"};

            Assert.Equal(new List<string>{ "the", "quick", "brown", "fox" }, Problem022.CreateStringList(stringList1, "thequickbrownfox"));
            Assert.Equal(new List<string>{ "bed", "bath", "and", "beyond" }, Problem022.CreateStringList(stringList2, "bedbathandbeyond"));
            Assert.Null(Problem022.CreateStringList(stringList1, "shouldbenull"));
        }
    }
}
