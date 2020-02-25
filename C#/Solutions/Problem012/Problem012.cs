using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Solutions.Problem012
{
    /// <summary>
    /// This problem was asked by Amazon.
    /// 
    /// There exists a staircase with N steps, and you can climb up either 1 or 2 steps at a time. Given N, write a function that returns the number of unique ways you can climb the staircase. The order of the steps matters.
    /// 
    /// For example, if N is 4, then there are 5 unique ways:
    /// 1, 1, 1, 1
    /// 2, 1, 1
    /// 1, 2, 1
    /// 1, 1, 2
    /// 2, 2
    /// 
    /// What if, instead of being able to climb 1 or 2 steps at a time, you could climb any number from a set of positive integers X? For example, if X = { 1, 3, 5}, you could climb 1, 3, or 5 steps at a time.
    /// </summary>
    public class Problem012
    {
        [Fact]
        public void Problem012SolutionTest()
        {
            var intArray = new[] {1, 2};
            var intArray2 = new[] {1, 3, 5};

            Assert.Equal(5, NumberOfWaysToClimbStaircase(4, intArray));
            Assert.Equal(3, NumberOfWaysToClimbStaircase(4, intArray2));
        }

        public static int NumberOfWaysToClimbStaircase(int totalSteps, IReadOnlyList<int> stepClimbCollection)
        {
            return NumberOfWaysRecursive(totalSteps, stepClimbCollection);
        }

        private static int NumberOfWaysRecursive(int totalSteps, IReadOnlyList<int> stepClimbCollection, int totalStepsClimbed = 0)
        {
            var counter = 0;

            if (totalStepsClimbed > totalSteps) return 0;

            if (totalStepsClimbed == totalSteps) return 1;

            for (var i = 0; i < stepClimbCollection.Count; i++)
            {
                var nextStep = totalStepsClimbed + stepClimbCollection[i];

                counter += NumberOfWaysRecursive(totalSteps, stepClimbCollection, nextStep);
            }

            return counter;
        }
    }
}
