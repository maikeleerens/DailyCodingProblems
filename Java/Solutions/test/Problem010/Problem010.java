package Problem010;

import org.junit.Assert;
import org.junit.Test;

import java.util.function.Function;

/**
 * This problem was asked by Apple.
 *
 * Implement a job scheduler which takes in a function f and an integer n, and calls f after n milliseconds.
 */
public class Problem010 {

    @Test
    public void Problem010SolutionTest() {
        Assert.assertEquals("done", jobScheduler((Void) -> function(), 5000));
    }

    private static String function() {
        return "done";
    }

    private static String jobScheduler(Function<Void, String> f, int n) {
        try {
            Thread.sleep(n);
        } catch (InterruptedException ex) {
            return null;
        }
        return f.apply(null);
    }
}
