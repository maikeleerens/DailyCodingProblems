using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Solutions.Problem015
{
    /// <summary>
    /// This problem was asked by Facebook.
    /// 
    /// Given a stream of elements too large to store in memory, pick a random element from the stream with uniform probability.
    /// </summary>
    public class Problem015
    {
        [Fact]
        public void Problem015SolutionTest()
        {
            var stream = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};

            Assert.Contains(StreamHelper<int>.GetRandomElementFromStream(stream), stream);
        }
    }

    /// <summary>
    /// Functions for a stream of <see cref="T"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StreamHelper<T>
    {
        public static T GetRandomElementFromStream(IReadOnlyList<T> stream)
        {
            var random = new Random();
            var randomElement = random.Next(0, stream.Count);

            return stream[randomElement];
        }
    }
}
