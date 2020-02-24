package Problem015;

import org.junit.Assert;
import org.junit.Test;

import java.util.*;

/**
 * This problem was asked by Facebook.
 *
 * Given a stream of elements too large to store in memory, pick a random element from the stream with uniform probability.
 */
public class Problem015 {

    @Test
    public void problem015SolutionTest() {
        var stream = Arrays.asList(1, 2, 3, 4, 5, 6, 7, 8, 9);
        Assert.assertTrue(stream.contains(StreamHelper.GetRandomElementFromStream(stream)));
    }
}

/**
 * Functions for a stream of T
 */
class StreamHelper<T> {
    public static <T> T GetRandomElementFromStream(List<T> stream) {
        var random = new Random();
        var randomElement = random.nextInt(stream.size());

        return stream.get(randomElement);
    }
}
