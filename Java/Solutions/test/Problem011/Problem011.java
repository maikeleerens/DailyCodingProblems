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

/**
 * Prefix tree. https://en.wikipedia.org/wiki/Trie
 */
class Trie {
    private final TrieNode _head = new TrieNode("");

    public void add(String word) {
        addRecursive(_head, word, "");
    }

    private void addRecursive(TrieNode node, String subString, String currentString) {
        while(true) {
            if (subString.length() == 0) {
                break;
            }

            var prefixChar = subString.charAt(0);
            if (!node.getSubNodes().containsKey(prefixChar)) {
                node.getSubNodes().put(prefixChar, new TrieNode(currentString + prefixChar));
            }

            var remainingSubString = subString.substring(1);
            if (remainingSubString.length() == 0) {
                node.getSubNodes().get(prefixChar).setWord(true);
                break;
            }

            node = node.getSubNodes().get(prefixChar);
            subString = remainingSubString;
            currentString += prefixChar;
        }
    }

    public List<String> search(String searchString) {
        var node = _head;
        var charArray = new char[searchString.length()];
        searchString.getChars(0, searchString.length(), charArray, 0);

        for (var searchChar:
             charArray) {
            if (!node.getSubNodes().containsKey(searchChar)) {
                return Collections.emptyList();
            }
            node = node.getSubNodes().get(searchChar);
        }
        return searchRecursive(node);
    }

    private List<String> searchRecursive(TrieNode node) {
        var returnList = new ArrayList<String>();
        if (node.isWord()) {
            returnList.add(node.getWord());
        }

        for (var subNode:
             node.getSubNodes().entrySet()) {
            for (var result:
                 searchRecursive(subNode.getValue())) {
                returnList.add(result);
            }
        }
        return returnList;
    }

    /**
     * Node in a Trie
     */
    protected class TrieNode {
        private final Map<Character, TrieNode> subNodes;
        private final String word;
        private boolean isWord;

        public TrieNode(String word) {
            this.subNodes = new HashMap<>();
            this.word = word;
            this.isWord = false;
        }

        public Map<Character, TrieNode> getSubNodes() {
            return subNodes;
        }

        public String getWord() {
            return word;
        }

        public boolean isWord() {
            return isWord;
        }

        public void setWord(boolean word) {
            isWord = word;
        }
    }
}
