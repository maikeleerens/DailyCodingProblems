using Xunit;

namespace Daily_Coding_Problems.Problem_002
{
    /// <summary>
    /// This problem was asked by Uber. <br></br>
    /// Given an array of integers, return a new array such that each element at index i of the new array is the product of all the numbers in the original array except the one at i. <br></br>
    /// For example, if our input was[1, 2, 3, 4, 5], the expected output would be[120, 60, 40, 30, 24]. If our input was [3, 2, 1], the expected output would be[2, 3, 6]. <br></br>
    /// Follow-up: what if you can't use division?
    /// </summary>
    public class Problem002
    {
        [Fact]
        public void Problem002SolutionTest()
        {
            var intArray = new[] {1, 2, 3, 4, 5};
            var intArray2 = new[] {3, 2, 1};

            Assert.Equal(new[] {120, 60, 40, 30, 24 }, CalculateNewIntArray(intArray));
            Assert.Equal(new[] {2, 3, 6}, CalculateNewIntArray(intArray2));
        }

        private static int[] CalculateNewIntArray(int[] intArray)
        {
            var returnIntArray = new int[intArray.Length];

            for (var i = 0; i < returnIntArray.Length; i++)
            {
                returnIntArray[i] = 1;

                for (var j = 0; j < intArray.Length; j++)
                {
                    if (j != i) returnIntArray[i] *= intArray[j];
                }
            }
            return returnIntArray;
        }
    }
}
