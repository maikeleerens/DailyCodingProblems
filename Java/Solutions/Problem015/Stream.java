package Problem015;

import java.util.List;
import java.util.Random;

/**
 * Functions for a stream of T
 */
public class Stream<T> {
    public static <T> T GetRandomElementFromStream(List<T> stream) {
        var random = new Random();
        var randomElement = random.nextInt(stream.size());

        return stream.get(randomElement);
    }
}
