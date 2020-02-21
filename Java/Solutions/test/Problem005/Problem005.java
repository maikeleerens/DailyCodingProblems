package Problem005;

import org.junit.Assert;
import org.junit.Test;

/**
 * This problem was asked by Jane Street.
 * cons(a, b) constructs a pair, and car(pair) and cdr(pair) returns the first and last element of that pair. For example, car(cons(3, 4)) returns 3, and cdr(cons(3, 4)) returns 4.
 *
 * Given this implementation of cons:
 * def cons(a, b):
 *     return lambda f : f(a, b)
 *
 * Implement car and cdr.
 */
public class Problem005 {

    @Test
    public void problem005SolutionTest(){
        var pair = Pair.cons(3, 4);

        Assert.assertEquals(3, (int)Pair.car(pair));
        Assert.assertEquals(4, (int)Pair.cdr(pair));
    }
}

/**
 * Creates a pair of T
 */
class Pair<T> {
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
