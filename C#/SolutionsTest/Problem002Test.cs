using System.Collections.Generic;
using Solutions;
using Xunit;

namespace SolutionsTest
{
    /// <summary>
    /// This problem was asked by Uber.
    /// 
    /// Given an array of integers, return a new array such that each element at index i of the new array is the product of all the numbers in the original array except the one at i.
    /// 
    /// For example, if our input was[1, 2, 3, 4, 5], the expected output would be[120, 60, 40, 30, 24]. If our input was [3, 2, 1], the expected output would be[2, 3, 6].
    /// 
    /// Follow-up: what if you can't use division?
    /// </summary>
    public class Problem002Test
    {
        [Fact]
        public void Problem002SolutionTest()
        {
            var intArray = new[] {1, 2, 3, 4, 5};
            var intArray2 = new[] {3, 2, 1};

            Assert.Equal(new[] {120, 60, 40, 30, 24 }, Problem002.CalculateNewArray(intArray));
            Assert.Equal(new[] {2, 3, 6}, Problem002.CalculateNewArray(intArray2));
        }
    }
}
