package Problem013;

import org.junit.Assert;
import org.junit.Test;

import java.util.ArrayList;

/**
 * This problem was asked by Amazon.
 *
 * Given an integer k and a string s, find the length of the longest substring that contains at most k distinct characters.
 *
 * For example, given s = "abcba" and k = 2, the longest substring with k distinct characters is "bcb".
 */
public class Problem013 {

    @Test
    public void problem013SolutionTest() {
        Assert.assertEquals(3, longestSubStringWithDistinctCharacters(2, "abcba"));
    }

    public static int longestSubStringWithDistinctCharacters(int k, String s) {
        return findLongestSubString(k, s);
    }

    private static int findLongestSubString(int k, String s) {
        var currentMaxLength = 0;

        while (s.length() > 0) {
            var foundCharacters = new ArrayList<Character>();

            for (var i = 0; i < s.length(); i++) {
                if (foundCharacters.size() >= k && !foundCharacters.contains(s.charAt(i))) break;
                foundCharacters.add(s.charAt(i));
            }

            s = s.substring(1);
            currentMaxLength = foundCharacters.size() > currentMaxLength ? foundCharacters.size() : currentMaxLength;
        }

        return currentMaxLength;
    }
}
