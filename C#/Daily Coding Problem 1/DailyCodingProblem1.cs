using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Daily_Coding_Problem_1
{
    /// <summary>
    /// This problem was recently asked by Google. <br></br>
    /// Given a list of numbers and a number k, return whether any two numbers from the list add up to k. <br></br>
    /// For example, given[10, 15, 3, 7] and k of 17, return true since 10 + 7 is 17. <br></br>
    /// Bonus: Can you do this in one pass?
    /// </summary>
    public class DailyCodingProblem1
    {
        [Fact]
        public void DailyCodingProblem1SolutionTest()
        {
            var numberList = new List<int> {10, 15, 3, 7};
            const int k = 17;

            Assert.True(NumbersInListAddUpToValue(numberList, k));
        }

        private static bool NumbersInListAddUpToValue(IEnumerable<int> numberList, int k)
        {
            return numberList.Select(number => k - number).Where(numberList.Contains).Any();
        }
    }
}
