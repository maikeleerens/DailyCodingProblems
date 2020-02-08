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
public class DailyCodingProblem1 {

    @Test
    public void DailyCodingProblem1SolutionTest(){
        var numberList = Arrays.asList(10, 15, 3, 7);
        var k = 17;

        var numbersInListAddUpToValue = numberList.stream().mapToInt(number -> k - number).anyMatch(numberList::contains);

        Assert.assertTrue(numbersInListAddUpToValue);
    }
}
