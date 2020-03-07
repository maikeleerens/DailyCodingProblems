package Problem011;

import java.util.*;

/**
 * Prefix tree. https://en.wikipedia.org/wiki/Trie
 */
public class Trie {
    private final TrieNode _head = new TrieNode("");

    public void add(String word) {
        add(_head, word);
    }

    private void add(TrieNode node, String subString) {
        var currentString = "";
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
        return search(node);
    }

    private List<String> search(TrieNode node) {
        var returnList = new ArrayList<String>();
        if (node.isWord()) {
            returnList.add(node.getWord());
        }

        for (var subNode:
             node.getSubNodes().entrySet()) {
            for (var result:
                 search(subNode.getValue())) {
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
