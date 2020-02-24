package Problem016;

import org.junit.Assert;
import org.junit.Test;

import java.util.ArrayList;
import java.util.List;

/**
 * This problem was asked by Twitter.
 *
 * You run an e-commerce website and want to record the last N order ids in a log. Implement a data structure to accomplish this, with the following API:
 *
 * record(order_id): adds the order_id to the log
 *
 * get_last(i): gets the ith last element from the log. i is guaranteed to be smaller than or equal to N.
 *
 * You should be as efficient with time and space as possible.
 */
public class Problem016 {

    @Test
    public void problem016SolutionTest() {
        var log = new Log(3);
        log.record(1);
        log.record(2);
        log.record(3);

        Assert.assertEquals(1, log.getLast(3));
        Assert.assertEquals(2, log.getLast(2));
        Assert.assertEquals(3, log.getLast(1));
    }
}

/**
 * Log that contains the orderIds
 */
class Log {
    private final List<Integer> log;
    private int size;

    public Log(int size) {
        log = new ArrayList<>();
        this.size = size;
    }

    public void record(int orderId) {
        if (log.size() == size)
            log.remove(0);

        log.add(orderId);
    }

    public int getLast(int i) {
        return log.get(log.size() - i);
    }
}
