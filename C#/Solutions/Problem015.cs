using System;
using System.Collections.Generic;

namespace Solutions
{
    /// <summary>
    /// This problem was asked by Facebook.
    /// 
    /// Given a stream of elements too large to store in memory, pick a random element from the stream with uniform probability.
    /// </summary>
    public static class Problem015
    {
        /// <summary>
        /// Functions for a stream of <see cref="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static class Stream<T>
        {
            public static T GetRandomElementFromStream(IReadOnlyList<T> stream)
            {
                var random = new Random();
                var randomElement = random.Next(0, stream.Count);

                return stream[randomElement];
            }
        }
    }
}
