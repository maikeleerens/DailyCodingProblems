package Problem016;

import java.util.ArrayList;
import java.util.List;

/**
 * Log that contains the orderIds
 */
public class Log {
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
