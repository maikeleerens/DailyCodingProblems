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
    public void Problem011SolutionTest() {
        var trie = new Trie();
        trie.Add("dog");
        trie.Add("dear");
        trie.Add("deal");

        Assert.assertEquals(2, trie.Search("de").size());
    }
}

/**
 * Prefix tree. https://en.wikipedia.org/wiki/Trie
 */
class Trie {
    private final TrieNode head = new TrieNode("");

    public void Add(String word) {
        AddRecursive(head, word, "");
    }

    private void AddRecursive(TrieNode node, String subString, String currentString) {
        while(true) {
            if (subString.length() == 0) {
                break;
            }

            var prefixChar = subString.charAt(0);
            if (!node.SubNodes.containsKey(prefixChar)) {
                node.SubNodes.put(prefixChar, new TrieNode(currentString + prefixChar));
            }

            var remainingSubString = subString.substring(1);
            if (remainingSubString.length() == 0) {
                node.SubNodes.get(prefixChar).IsWord = true;
                break;
            }

            node = node.SubNodes.get(prefixChar);
            subString = remainingSubString;
            currentString += prefixChar;
        }
    }

    public List<String> Search(String searchString) {
        var node = head;
        var charArray = new char[searchString.length()];
        searchString.getChars(0, searchString.length(), charArray, 0);

        for (var searchChar:
             charArray) {
            if (!node.SubNodes.containsKey(searchChar)) {
                return Collections.emptyList();
            }
            node = node.SubNodes.get(searchChar);
        }
        return SearchRecursive(node);
    }

    private List<String> SearchRecursive(TrieNode node) {
        var returnList = new ArrayList<String>();
        if (node.IsWord) {
            returnList.add(node.Word);
        }

        for (var subNode:
             node.SubNodes.entrySet()) {
            for (var result:
                 SearchRecursive(subNode.getValue())) {
                returnList.add(result);
            }
        }
        return returnList;
    }

    /**
     * Node in a Trie
     */
    protected class TrieNode {
        public final Map<Character, TrieNode> SubNodes;
        public final String Word;
        public boolean IsWord;

        public TrieNode(String word) {
            SubNodes = new HashMap<>();
            Word = word;
            IsWord = false;
        }
    }
}
