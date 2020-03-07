package Problem005;

/**
 * Creates a pair of T
 */
public class Pair<T> {
    private T _a;
    private T _b;

    private Pair(T a, T b) {
        _a = a;
        _b = b;
    }

    public static <T> Pair<T> cons(T a, T b) {
        return new Pair<T>(a, b);
    }

    public static <T> T car(Pair<T> pair) {
        return pair._a;
    }

    public static <T> T cdr(Pair<T> pair) {
        return pair._b;
    }
}
