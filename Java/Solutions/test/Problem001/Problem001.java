package Problem001;

import org.junit.Assert;
import org.junit.Test;

import java.util.Arrays;
import java.util.List;

/**
 * This problem was recently asked by Google.
 * Given a list of numbers and a number k, return whether any two numbers from the list add up to k.
 * For example, given [10, 15, 3, 7] and k of 17, return true since 10 + 7 is 17.
 * Bonus: Can you do this in one pass?
 */
public class Problem001 {

    @Test
    public void Problem001SolutionTest(){
        var numberList = Arrays.asList(10, 15, 3, 7);
        final int k = 17;

        Assert.assertTrue(NumbersInListAddUpToValue(numberList, k));
    }

    private static boolean NumbersInListAddUpToValue(List<Integer> numberList, int k) {
        return numberList.stream().mapToInt(number -> k - number).anyMatch(numberList::contains);
    }
}