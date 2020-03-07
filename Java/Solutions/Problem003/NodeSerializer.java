package Problem003;

/**
 * Serializes and deserializes all Nodes from a binary tree
 */
public class NodeSerializer {
    private static int _index;

    public static String serialize(Node node) {
        return node == null ? "empty" : node.getValue() + "-" + serialize(node.getLeft()) + "-" + serialize(node.getRight());
    }

    public static Node deserialize(String serializedNode) {
        var nodeList = serializedNode.split("-");

        if (_index >= nodeList.length) _index = 0;

        if (nodeList[_index].contains("empty"))
        {
            _index++;
            return null;
        }

        var nodeToReturn = new Node(nodeList[_index], null, null);
        _index++;
        nodeToReturn.setLeft(deserialize(serializedNode));
        nodeToReturn.setRight(deserialize(serializedNode));
        return nodeToReturn;
    }
}
