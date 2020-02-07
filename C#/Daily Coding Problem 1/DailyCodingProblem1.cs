using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Daily_Coding_Problem_1
{
    /// <summary>
    /// 
    /// </summary>
    public class DailyCodingProblem1
    {
        [Fact]
        public void DailyCodingProblem1SolutionTest()
        {
            var numberList = new List<int> {10, 15, 3, 7};
            var k = 1000;

            Assert.True(NumbersAreEqual(numberList, k));
        }

        private bool NumbersAreEqual(IEnumerable<int> numberList, int k)
        {
            return numberList.Select(number => k - number).Any(numberList.Contains);
        }
    }
}
