package Problem004;

import org.junit.Assert;
import org.junit.Test;

/**
 * This problem was asked by Stripe.
 * Given an array of integers, find the first missing positive integer in linear time and constant space. In other words, find the lowest positive integer that does not exist in the array. The array can contain duplicates and negative numbers as well.
 * For example, the input [3, 4, -1, 1] should give 2. The input [1, 2, 0] should give 3.
 * You can modify the input array in-place.
 */
public class Problem004 {

    @Test
    public void problem004SolutionTest() {
        var intArray = new int[] {3, 4, -1, 1};
        var intArray2 = new int[] {1, 2, 0};

        Assert.assertEquals(2, lowestMissingPositiveIntegerFromIntArray(intArray));
        Assert.assertEquals(3, lowestMissingPositiveIntegerFromIntArray(intArray2));
    }

    public static int lowestMissingPositiveIntegerFromIntArray(int[] intArray) {
        var lowestNumber = 1;

        for (var number:
             intArray) {
            if (number == lowestNumber) {
                lowestNumber++;
            }
        }
        return lowestNumber;
    }
}
