using Xunit;

namespace Solutions.Problem005
{
    /// <summary>
    /// This problem was asked by Jane Street.
    /// cons(a, b) constructs a pair, and car(pair) and cdr(pair) returns the first and last element of that pair.For example, car(cons(3, 4)) returns 3, and cdr(cons(3, 4)) returns 4.
    /// 
    /// Given this implementation of cons: 
    /// def cons(a, b):
    ///     return lambda f : f(a, b)
    /// 
    /// Implement car and cdr.
    /// </summary>
    public class Problem005
    {
        [Fact]
        public void Problem005SolutionTest()
        {
            var pair = Pair<int>.Cons(3, 4);

            Assert.Equal(3, Pair<int>.Car(pair));
            Assert.Equal(4, Pair<int>.Cdr(pair));
        }
    }

    /// <summary>
    /// Creates a pair of <see cref="T"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Pair<T>
    {
        private readonly T _a;
        private readonly T _b;

        public Pair(T a, T b)
        {
            _a = a;
            _b = b;
        }

        public static Pair<T> Cons(T a, T b)
        {
            return new Pair<T>(a, b);
        }

        public static T Car(Pair<T> pair)
        {
            return pair._a;
        }

        public static T Cdr(Pair<T> pair)
        {
            return pair._b;
        }
    }
}
