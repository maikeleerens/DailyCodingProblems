package Problem014;

import org.junit.Assert;
import org.junit.Test;

import java.math.BigDecimal;
import java.math.RoundingMode;
import java.util.Random;

/**
 * This problem was asked by Google.
 *
 * The area of a circle is defined as πr^2. Estimate π to 3 decimal places using a Monte Carlo method.
 *
 * Hint: The basic equation of a circle is x2 + y2 = r2.
 */
public class Problem014 {

    @Test
    public void problem014SolutionTest(){
        Assert.assertEquals(new BigDecimal(3.141).setScale(3, RoundingMode.FLOOR), estimatePi(100000000).setScale(3, RoundingMode.FLOOR));
    }

    public static BigDecimal estimatePi(int numberOfRuns) {
        var circlePoints = 0;

        var random = new Random();

        for (var i = 0; i < numberOfRuns; i++) {
            var x = Math.pow(random.nextDouble(), 2);
            var y = Math.pow(random.nextDouble(), 2);

            if (Math.sqrt(x + y) <= 1.0)
                circlePoints++;
        }

        return new BigDecimal(4 * ((double)circlePoints / numberOfRuns));
    }
}
