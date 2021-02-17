using System;
using Solutions;
using Xunit;

namespace SolutionsTest
{
    /// <summary>
    /// This problem was asked by Snapchat.
    /// 
    /// Given an array of time intervals (start, end) for classroom lectures (possibly overlapping), find the minimum number of rooms required.
    /// 
    /// For example, given[(30, 75), (0, 50), (60, 150)], you should return 2
    /// </summary>
    public class Problem021Test
    {
        [Fact]
        public void Problem021SolutionTest()
        {
            var timeIntervals = new[] { new Tuple<int, int>(30, 75), new Tuple<int, int>(0, 50), new Tuple<int, int>(60, 150) };

            Assert.Equal(2, Problem021.CalculateMinimumNumberOfRooms(timeIntervals));
        }
    }
}
