using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Solutions.Problem001
{
    /// <summary>
    /// This problem was recently asked by Google.
    /// Given a list of numbers and a number k, return whether any two numbers from the list add up to k.
    /// For example, given[10, 15, 3, 7] and k of 17, return true since 10 + 7 is 17.
    /// Bonus: Can you do this in one pass?
    /// </summary>
    public class Problem001
    {
        [Fact]
        public void Problem001SolutionTest()
        {
            var numberList = new List<int> {10, 15, 3, 7};
            const int k = 17;

            Assert.True(NumbersInListAddUpToValue(numberList, k));
        }

        public static bool NumbersInListAddUpToValue(IReadOnlyCollection<int> numberCollection, int k)
        {
            return numberCollection.Select(number => k - number).Where(numberCollection.Contains).Any();
        }
    }
}
