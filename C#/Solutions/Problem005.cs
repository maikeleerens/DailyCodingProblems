namespace Solutions
{
    /// <summary>
    /// This problem was asked by Jane Street.
    /// cons(a, b) constructs a pair, and car(pair) and cdr(pair) returns the first and last element of that pair. For example, car(cons(3, 4)) returns 3, and cdr(cons(3, 4)) returns 4.
    /// 
    /// Given this implementation of cons: 
    /// def cons(a, b):
    ///     return lambda f : f(a, b)
    /// 
    /// Implement car and cdr.
    /// </summary>
    public static class Problem005
    {
        /// <summary>
        /// Creates a pair of <see cref="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public sealed class Pair<T>
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
}
