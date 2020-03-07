package Problem018;

import org.junit.Assert;
import org.junit.Test;

import java.util.Arrays;

/**
 * This problem was asked by Google.
 *
 * Given an array of integers and a number k, where 1 <= k <= length of the array, compute the maximum values of each subarray of length k.
 *
 * For example, given array = [10, 5, 2, 7, 8, 7] and k = 3, we should get: [10, 7, 8, 8], since:
 * 10 = max(10, 5, 2)
 * 7 = max(5, 2, 7)
 * 8 = max(2, 7, 8)
 * 8 = max(7, 8, 7)
 *
 * Do this in O(n) time and O(k) space. You can modify the input array in-place and you do not need to store the results. You can simply print them out as you compute them.
 */
public class Problem018 {

    @Test
    public void problem018SolutionTest() {
        Assert.assertArrayEquals(new int[] {10, 7, 8, 8}, getMaximumSubArrayValuesOfGivenLength(new int[] {10, 5, 2, 7, 8, 7}, 3));
    }

    public static int[] getMaximumSubArrayValuesOfGivenLength(int[] numberCollection, int k) {
        if (k < 1 || k > numberCollection.length)
            throw new IllegalArgumentException();

        var returnArray = new int[numberCollection.length-(k-1)];
        for (var i = 0; i < returnArray.length; i++) {
            returnArray[i] = Arrays.stream(numberCollection).skip(i).limit(k).max().getAsInt();
        }

        return returnArray;
    }
}
