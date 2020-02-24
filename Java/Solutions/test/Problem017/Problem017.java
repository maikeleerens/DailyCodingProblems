package Problem017;

import org.junit.Assert;
import org.junit.Test;

import javafx.util.Pair;

import java.util.*;

/**
 * This problem was asked by Google.
 *
 * Suppose we represent our file system by a string in the following manner:
 *
 * The string "dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext" represents:
 * dir
 *     subdir1
 *     subdir2
 *         file.ext
 *
 * The directory dir contains an empty sub-directory subdir1 and a sub-directory subdir2 containing a file file.ext.
 *
 * The string "dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext" represents:
 * dir
 *     subdir1
 *         file1.ext
 *         subsubdir1
 *     subdir2
 *         subsubdir2
 *             file2.ext
 * The directory dir contains two sub-directories subdir1 and subdir2. subdir1 contains a file file1.ext and an empty second-level sub-directory subsubdir1.
 * subdir2 contains a second-level sub-directory subsubdir2 containing a file file2.ext.
 *
 * We are interested in finding the longest (number of characters) absolute path to a file within our file system. For example, in the second example above, the longest absolute path is "dir/subdir2/subsubdir2/file2.ext", and its length is 32 (not including the double quotes).
 *
 * Given a string representing the file system in the above format, return the length of the longest absolute path to a file in the abstracted file system.
 * If there is no file in the system, return 0.
 *
 * Note:
 * The name of a file contains at least a period and an extension.
 *
 * The name of a directory or sub-directory will not contain a period
 */
public class Problem017 {

    @Test
    public void problem017SolutionTest() {
        Assert.assertEquals(20, longestAbsolutePathToFile("dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext"));
        Assert.assertEquals(32, longestAbsolutePathToFile("dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext"));
    }

    public static int longestAbsolutePathToFile(String fileSystem) {
        if (!fileSystem.contains("."))
            return 0;

        var fileSystemStringArray = fileSystem.split("\n");

        var values = new ArrayList<Pair<String, Integer>>();
        for (var value:
             fileSystemStringArray) {
            var depthLevel = value.split("\t").length;
            values.add(new Pair<>(value, depthLevel));
        }

        var longestAbsolutePath = "";
        var deepestFile = values.stream().filter(x -> x.getKey().contains(".")).reduce((l, r) -> l.getValue() > r.getValue() ? l : r).get();

        Collections.reverse(values);
        var indexOfDeepestFile = values.indexOf(deepestFile);
        var deepestFileLevel = deepestFile.getValue();
        for (var i = indexOfDeepestFile; i < values.size(); i++) {
            if (deepestFileLevel < values.get(i).getValue()) continue;

            longestAbsolutePath = values.get(i).getKey().replace("\t", "") + "/" + longestAbsolutePath;
            deepestFileLevel--;
        }

        return longestAbsolutePath.substring(0, longestAbsolutePath.length()-1).length();
    }
}
