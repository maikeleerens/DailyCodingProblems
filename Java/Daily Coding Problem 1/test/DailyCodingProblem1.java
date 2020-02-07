import org.junit.Assert;
import org.junit.Test;

import java.util.Arrays;
import java.util.List;

public class DailyCodingProblem1 {

    @Test
    public void DailyCodingProblem1SolutionTest(){
        var numberList = Arrays.asList(10, 15, 3, 7);
        var k = 17;

        Assert.assertTrue(numbersAreEqual(numberList, k));
    }

    private static boolean numbersAreEqual(List<Integer> numberList, int k){
        return numberList.stream().mapToInt(number -> k - number).anyMatch(numberList::contains);
    }
}
