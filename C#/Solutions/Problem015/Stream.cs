using System;
using System.Collections.Generic;

namespace DailyCodingProblems.Solutions.Problem015
{
    /// <summary>
    /// Functions for a stream of <see cref="T"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Stream<T>
    {
        public static T GetRandomElementFromStream(IReadOnlyList<T> stream)
        {
            var random = new Random();
            var randomElement = random.Next(0, stream.Count);

            return stream[randomElement];
        }
    }
}
