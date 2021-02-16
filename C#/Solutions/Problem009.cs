using System;
using System.Collections.Generic;

namespace Solutions
{
    /// <summary>
    /// This problem was asked by Airbnb.
    /// 
    /// Given a list of integers, write a function that returns the largest sum of non-adjacent numbers. Numbers can be 0 or negative.
    /// For example, [2, 4, 6, 2, 5] should return 13, since we pick 2, 6, and 5. [5, 1, 1, 5] should return 10, since we pick 5 and 5.
    /// 
    /// Follow-up: Can you do this in O(N) time and constant space?
    /// </summary>
    public static class Problem009
    {
        public static int FindLargestSumNonAdjacent(IReadOnlyList<int> numberCollection)
        {
            var lastSum = 0;
            var currentSum = numberCollection[0];

            for (var i = 1; i < numberCollection.Count; i++)
            {
                var possibleSum = Math.Max(numberCollection[i] + lastSum, numberCollection[i]);
                lastSum = currentSum;
                if (possibleSum > currentSum)
                {
                    currentSum = possibleSum;
                }   
            }

            return currentSum;
        }

    }
}