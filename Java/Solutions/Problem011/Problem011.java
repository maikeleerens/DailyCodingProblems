package Problem011;

import org.junit.Assert;
import org.junit.Test;

import java.util.*;

/**
 * This problem was asked by Twitter.
 *
 * Implement an autocomplete system. That is, given a query string s and a set of all possible query strings, return all strings in the set that have s as a prefix.
 *
 * For example, given the query string de and the set of strings [dog, deer, deal], return [deer, deal].
 *
 * Hint: Try preprocessing the dictionary into a more efficient data structure to speed up queries.
 */
public class Problem011 {

    @Test
    public void problem011SolutionTest() {
        var trie = new Trie();
        trie.add("dog");
        trie.add("dear");
        trie.add("deal");

        Assert.assertEquals(2, trie.search("de").size());
    }
}

