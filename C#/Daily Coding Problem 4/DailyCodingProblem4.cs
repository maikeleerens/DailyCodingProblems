﻿using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Xunit;

namespace Daily_Coding_Problem_4
{
    /// <summary>
    /// Given an array of integers, find the first missing positive integer in linear time and constant space. In other words, find the lowest positive integer that does not exist in the array. The array can contain duplicates and negative numbers as well.
    /// For example, the input[3, 4, -1, 1] should give 2. The input[1, 2, 0] should give 3.
    /// You can modify the input array in-place.
    /// </summary>
    public class DailyCodingProblem4
    {
        [Fact]
        public void DailyCodingProblem4SolutionTest()
        {
            var intArray1 = new[] {3, 4, -1, 1};
            var intArray2 = new[] {1, 2, 0};

            Assert.Equal(2, LowestMissingPositiveIntegerFromIntArray(intArray1));
            Assert.Equal(3, LowestMissingPositiveIntegerFromIntArray(intArray2));
        }

        /// <summary>
        /// Finds the lowest positive number that is not in the array
        /// </summary>
        /// <param name="intArray"></param>
        /// <returns></returns>
        private static int LowestMissingPositiveIntegerFromIntArray(int[] intArray)
        {
            var lowestNumber = 1;
            while (intArray.Contains(lowestNumber))
            {
                lowestNumber++;
            }

            return lowestNumber;
        }
    }
}
