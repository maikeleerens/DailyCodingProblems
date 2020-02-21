package Problem012;

import org.junit.Assert;
import org.junit.Test;

/**
 * This problem was asked by Amazon.
 *
 * There exists a staircase with N steps, and you can climb up either 1 or 2 steps at a time. Given N, write a function that returns the number of unique ways you can climb the staircase. The order of the steps matters.
 *
 * For example, if N is 4, then there are 5 unique ways: *
 * 1, 1, 1, 1
 * 2, 1, 1
 * 1, 2, 1
 * 1, 1, 2
 * 2, 2
 *
 * What if, instead of being able to climb 1 or 2 steps at a time, you could climb any number from a set of positive integers X? For example, if X = {1, 3, 5}, you could climb 1, 3, or 5 steps at a time.
 */
public class Problem012 {

    @Test
    public void problem012SolutionTest() {
        var intArray = new int[] {1, 2};
        var intArray2 = new int[] {1, 3, 5};

        Assert.assertEquals(5, numberOfWaysToClimbStaircase(4, intArray));
        Assert.assertEquals(3, numberOfWaysToClimbStaircase(4, intArray2));
    }

    public static int numberOfWaysToClimbStaircase(int totalSteps, int[] stepClimbCollection) {
        return numberOfWaysRecrusive(totalSteps, stepClimbCollection, 0);
    }

    private static int numberOfWaysRecrusive(int totalSteps, int[] stepClimbCollection, int totalStepsClimbed) {
        var counter = 0;

        if (totalStepsClimbed > totalSteps) return 0;

        if (totalStepsClimbed == totalSteps) return 1;

        for (var i = 0; i < stepClimbCollection.length; i++) {
            var nextStep = totalStepsClimbed + stepClimbCollection[i];

            counter += numberOfWaysRecrusive(totalSteps, stepClimbCollection, nextStep);
        }

        return counter;
    }
}
