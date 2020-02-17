package Problem007;

import org.junit.Assert;
import org.junit.Test;

/**
 * This problem was asked by Facebook.
 *
 * Given the mapping a = 1, b = 2, ... z = 26, and an encoded message, count the number of ways it can be decoded. *
 * For example, the message '111' would give 3, since it could be decoded as 'aaa', 'ka', and 'ak'. *
 * You can assume that the messages are decodable. For example, '001' is not allowed.
 */
public class Problem007 {

    @Test
    public void Problem007SolutionTest() {
        Assert.assertEquals(3, numberOfWaysToDecodeMessage(111));
    }

    private static int numberOfWaysToDecodeMessage(int message) {
        var messageAsString = String.valueOf(message);
        var count = 0;

        if (messageAsString.length() > 2) {
            count += isValidMappedLetter(Integer.parseInt(messageAsString.substring(0, 2)))
                    ? numberOfWaysToDecodeMessage(Integer.parseInt(messageAsString.substring(2)))
                    : 0;
            count += numberOfWaysToDecodeMessage(Integer.parseInt(messageAsString.substring(1)));
        }
        else if (messageAsString.length() == 2) {
            count += isValidMappedLetter(Integer.parseInt(messageAsString)) ? 2 : 1;
        }
        else if (messageAsString.length() == 1) {
            count = 1;
        }

        return count;
    }

    private static boolean isValidMappedLetter(int number) {
        return number < 27 && number > 0;
    }
}
