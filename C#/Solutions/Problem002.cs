using System.Collections.Generic;

namespace Solutions
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
    public static class Problem002
    {
        public static int[] CalculateNewArray(IReadOnlyList<int> numberCollection)
        {
            var returnIntArray = new int[numberCollection.Count];

            for (var i = 0; i < returnIntArray.Length; i++)
            {
                returnIntArray[i] = 1;

                for (var j = 0; j < numberCollection.Count; j++)
                {
                    if (j != i) returnIntArray[i] *= numberCollection[j];
                }
            }
            return returnIntArray;
        }
    }
}
