using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Solutions.Problem018
{
    /// <summary>
    /// This problem was asked by Google.
    /// 
    /// Given an array of integers and a number k, where 1 <= k <= length of the array, compute the maximum values of each subarray of length k.
    /// 
    /// For example, given array = [10, 5, 2, 7, 8, 7] and k = 3, we should get: [10, 7, 8, 8], since:
    /// 10 = max(10, 5, 2)
    /// 7 = max(5, 2, 7)
    /// 8 = max(2, 7, 8)
    /// 8 = max(7, 8, 7)
    /// 
    /// Do this in O(n) time and O(k) space. You can modify the input array in-place and you do not need to store the results. You can simply print them out as you compute them.
    /// </summary>
    public class Problem018
    {
        [Fact]
        public void Problem018SolutionTest()
        {
            Assert.Equal(new[] {10, 7, 8, 8}, GetMaximumSubArrayValuesOfGivenLength(new[] {10, 5, 2, 7, 8, 7}, 3));
        }

        public static IReadOnlyCollection<int> GetMaximumSubArrayValuesOfGivenLength(IReadOnlyList<int> numberCollection,
            int k)
        {
            if (k < 1 || k > numberCollection.Count)
                throw new ArgumentException();

            var returnArray = new int[numberCollection.Count-(k-1)];
            for (var i = 0; i < returnArray.Length; i++)
            {
                returnArray[i] = numberCollection.Skip(i).Take(k).Max();
            }

            return returnArray;
        }
    }
}
