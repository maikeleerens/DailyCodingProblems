package Problem019;

import org.junit.Assert;
import org.junit.Test;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.stream.IntStream;

/**
 * This problem was asked by Facebook.
 *
 * A builder is looking to build a row of N houses that can be of K different colors. He has a goal of minimizing cost while ensuring that no two neighboring houses are of the same color.
 *
 * Given an N by K matrix where the nth row and kth column represents the cost to build the nth house with kth color, return the minimum cost which achieves this goal.
 */
public class Problem019 {

    @Test
    public void problem019SolutionTest() {
        var customTestList = Arrays.asList(new int[]{ 14, 2, 11 }, new int[]{ 11, 14, 5 }, new int[]{ 14, 3, 10 } );

        Assert.assertEquals(4, getMinimumPaintCost(3, 3));
        Assert.assertEquals(6, getMinimumPaintCost(4, 4));
        Assert.assertEquals(10, getMinimumPaintCost(customTestList));
    }

    public static int getMinimumPaintCost(int n, int k) {
        var costs = new ArrayList<int[]>();

        for (var i = 0; i < n; i++) {
            var colors = new int[k];

            for (var j = 0; j < k; j++) {
                colors[j] = j + 1;
            }
            costs.add(colors);
        }
        return getMinimumPaintCost(costs);
    }

    public static int getMinimumPaintCost(List<int[]> costs) {
        var currentMinimumCost = 0;
        var lastUsedColorIndex = -1;

        for (var colors:
             costs) {
            var lowestCostValue = Arrays.stream(colors).min().getAsInt();
            var indexOfLowestCostValue = IntStream.range(0, colors.length).filter(i -> lowestCostValue == colors[i]).findFirst().orElse(-1);

            if (lastUsedColorIndex != indexOfLowestCostValue) {
                currentMinimumCost += lowestCostValue;
                lastUsedColorIndex = indexOfLowestCostValue;
            } else {
                var secondLowestCostValue = Arrays.stream(colors).sorted().skip(1).findFirst().getAsInt();
                var secondLowestValueIndex  = Arrays.asList(colors).indexOf(secondLowestCostValue);

                currentMinimumCost += secondLowestCostValue;
                lastUsedColorIndex = secondLowestValueIndex;
            }
        }
        return currentMinimumCost;
    }
}
