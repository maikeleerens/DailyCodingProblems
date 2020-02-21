package Problem009;

import org.junit.Assert;
import org.junit.Test;

import java.util.*;

/**
 * This problem was asked by Airbnb.
 *
 * Given a list of integers, write a function that returns the largest sum of non-adjacent numbers. Numbers can be 0 or negative. *
 * For example, [2, 4, 6, 2, 5] should return 13, since we pick 2, 6, and 5. [5, 1, 1, 5] should return 10, since we pick 5 and 5.
 *
 * Follow-up: Can you do this in O(N) time and constant space?
 */
public class Problem009 {

    @Test
    public void problem009SolutionTest() {
        var intList1 = List.of(2, 4, 6, 2, 5);
        var intList2 = List.of(5, 1, 1, 5);

        Assert.assertEquals(13, findLargestSumNonAdjacent(intList1));
        Assert.assertEquals(10, findLargestSumNonAdjacent(intList2));
    }

    public static int findLargestSumNonAdjacent(List<Integer> numberList) {
        var lastSum = 0;
        var currentSum = numberList.get(0);

        for (var i = 1; i < numberList.size(); i++) {
            var possibleSum = Integer.max(numberList.get(i) + lastSum, numberList.get(i));
            lastSum =  currentSum;
            if (possibleSum > currentSum) {
                currentSum = possibleSum;
            }
        }
        return currentSum;
    }
}
