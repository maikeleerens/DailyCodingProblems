using Xunit;

namespace Daily_Coding_Problem_2
{
    /// <summary>
    /// This problem was asked by Uber. <br></br>
    /// Given an array of integers, return a new array such that each element at index i of the new array is the product of all the numbers in the original array except the one at i. <br></br>
    /// For example, if our input was[1, 2, 3, 4, 5], the expected output would be[120, 60, 40, 30, 24]. If our input was [3, 2, 1], the expected output would be[2, 3, 6]. <br></br>
    /// Follow-up: what if you can't use division?
    /// </summary>
    public class DailyCodingProblem2
    {
        [Fact]
        public void DailyCodingProblem2SolutionTest()
        {
            var intArray = new[] {1, 2, 3, 4, 5};
            var newIntArray = new int[intArray.Length];

            for (var i = 0; i < newIntArray.Length; i++)
            {
                newIntArray[i] = 1;

                for (var j = 0; j < intArray.Length; j++)
                {
                    if (j == i) continue;

                    newIntArray[i] *= intArray[j];
                }
            }

            Assert.Equal(new[] {120, 60, 40, 30, 24 }, newIntArray);
        }
    }
}
