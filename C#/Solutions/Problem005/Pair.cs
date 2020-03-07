namespace DailyCodingProblems.Solutions.Problem005
{
    /// <summary>
    /// Creates a pair of <see cref="T"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Pair<T>
    {
        private readonly T _a;
        private readonly T _b;

        private Pair(T a, T b)
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
