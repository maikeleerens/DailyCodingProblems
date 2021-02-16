using System.Collections.Generic;
using Solutions;
using Xunit;

namespace SolutionsTest
{
    /// <summary>
    /// This problem was asked by Facebook.
    /// 
    /// A builder is looking to build a row of N houses that can be of K different colors.He has a goal of minimizing cost while ensuring that no two neighboring houses are of the same color.
    /// 
    /// Given an N by K matrix where the nth row and kth column represents the cost to build the nth house with kth color, return the minimum cost which achieves this goal.
    /// </summary>
    public class Problem019Test
    {
        [Fact]
        public void Problem019SolutionTest()
        {
            var customTestList = new List<int[]>{new []{ 14, 2, 11 }, new []{ 11, 14, 5 }, new []{ 14, 3, 10 } };
            
            Assert.Equal(4, Problem019.GetMinimumPaintCost(3, 3));
            Assert.Equal(6, Problem019.GetMinimumPaintCost(4, 4));
            Assert.Equal(10, Problem019.GetMinimumPaintCost(customTestList));
        }
    }
}
