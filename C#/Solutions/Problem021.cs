using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    /// <summary>
    /// This problem was asked by Snapchat.
    /// 
    /// Given an array of time intervals (start, end) for classroom lectures (possibly overlapping), find the minimum number of rooms required.
    /// 
    /// For example, given[(30, 75), (0, 50), (60, 150)], you should return 2
    /// </summary>
    public static class Problem021
    {
        public static int CalculateMinimumNumberOfRooms(IReadOnlyCollection<Tuple<int, int>> timeIntervals)
        {
            //Return 0 if list is empty
            if (!timeIntervals.Any()) return 0;

            //Create new list with start & end time interval separated, sorted ascending. +1 for a start time & -1 for end time 
            var sortedTimes = timeIntervals
                .Select(timeInterval => new Tuple<int, int>(timeInterval.Item1, 1))
                .Concat(timeIntervals.Select(timeInterval => new Tuple<int, int>(timeInterval.Item2, -1)))
                .OrderBy(t => t.Item1);

            //follow and count the sequence of the sorted list
            var currentRoomCounter = 0;
            var maxRequiredRooms = 1;
            foreach (var time in sortedTimes)
            {
                currentRoomCounter += time.Item2;
                if (currentRoomCounter > maxRequiredRooms)
                    maxRequiredRooms++;
            }

            return maxRequiredRooms;
        }
    }
}
