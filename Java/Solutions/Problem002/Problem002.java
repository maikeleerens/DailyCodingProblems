package Problem002;

import org.junit.Assert;
import org.junit.Test;

/**
 * This problem was asked by Uber.
 * Given an array of integers, return a new array such that each element at index i of the new array is the product of all the numbers in the original array except the one at i.
 * For example, if our input was [1, 2, 3, 4, 5], the expected output would be [120, 60, 40, 30, 24]. If our input was [3, 2, 1], the expected output would be [2, 3, 6].
 * Follow-up: what if you can't use division?
 */
public class Problem002 {

    @Test
    public void problem002SolutionTest() {
        var intArray = new int[] {1, 2, 3, 4, 5};
        var intArray2 = new int[] {3, 2, 1};

        Assert.assertArrayEquals(new int[] {120, 60, 40, 30, 24}, calculateNewArray(intArray));
        Assert.assertArrayEquals(new int[] {2, 3, 6}, calculateNewArray(intArray2));
    }

    public static int[] calculateNewArray(int[] intArray) {
        var returnIntArray = new int[intArray.length];
        for (int i = 0; i < returnIntArray.length; i++) {
            returnIntArray[i] = 1;

            for (int j = 0; j < intArray.length; j++){
                if (j != i) returnIntArray[i] *= intArray[j];
            }
        }
        return returnIntArray;
    }
}
