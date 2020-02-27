using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Solutions.Problem019
{
    /// <summary>
    /// This problem was asked by Facebook.
    /// 
    /// A builder is looking to build a row of N houses that can be of K different colors.He has a goal of minimizing cost while ensuring that no two neighboring houses are of the same color.
    /// 
    /// Given an N by K matrix where the nth row and kth column represents the cost to build the nth house with kth color, return the minimum cost which achieves this goal.
    /// </summary>
    public class Problem019
    {
        [Fact]
        public void Problem019SolutionTest()
        {
            Assert.Equal(4, GetMinimumCost(3, 3));
            Assert.Equal(6, GetMinimumCost(4, 4));
        }

        public static int GetMinimumCost(int n, int k)
        {
           var costs = new List<int[]>();

           for (var i = 0; i < n; i++)
           {
               var colors = new int[k];
               for (var j = 0; j < k; j++)
               {
                   colors[j] = j + 1;
               }
               costs.Add(colors);
           }

           return GetMinimumCost(costs);
        }

        private static int GetMinimumCost(IEnumerable<int[]> costs)
        {
            var currentMinimumCost = 0;
            var lastUsedColorIndex = -1;
            
            foreach (var colors in costs)
            {
                var lowestCostValue = colors.Min();
                var indexOfLowestCostValue = Array.IndexOf(colors, lowestCostValue);
                if (lastUsedColorIndex != indexOfLowestCostValue)
                {
                    currentMinimumCost += lowestCostValue;
                    lastUsedColorIndex = indexOfLowestCostValue;
                }
                else
                {
                    var secondLowestMinimumCost = colors.OrderBy(x => x).Skip(1).FirstOrDefault();
                    var secondLowestValueIndex = Array.IndexOf(colors, secondLowestMinimumCost);

                    currentMinimumCost += secondLowestMinimumCost;
                    lastUsedColorIndex = secondLowestValueIndex;
                }
            }
            return currentMinimumCost;
        }
    }
}
