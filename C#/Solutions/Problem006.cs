using System;
using System.Collections.Generic;

namespace Solutions
{
    /// <summary>
    /// This problem was asked by Google.
    /// 
    /// An XOR linked list is a more memory efficient doubly linked list.
    /// Instead of each node holding next and prev fields, it holds a field named both, which is an XOR of the next node and the previous node.
    /// 
    /// Implement an XOR linked list; it has an add(element) which adds the element to the end, and a get(index) which returns the node at index.
    /// 
    /// If using a language that has no pointers(such as Python), you can assume you have access to get_pointer and dereference_pointer functions that converts between nodes and memory addresses.
    /// </summary>
    public static class Problem006
    {
        /// <summary>
        /// XOR linked list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class XorList<T>
        {
            private readonly IDictionary<int, XorListNode> _memory = new Dictionary<int, XorListNode>();
            private int _memoryAddress = 1;
            private bool _hasNodes;

            /// <summary>
            /// Nodes in a <see cref="XorList{T}"/>
            /// </summary>
            internal class XorListNode
            {
                public int Address { get; }
                public int Both { get; set; }
                public T Value { get; }

                public XorListNode(int address, int both, T value)
                {
                    Address = address;
                    Both = both;
                    Value = value;
                }
            }

            public void Add(T value)
            {
                if (!_hasNodes)
                {
                    _memory.Add(_memoryAddress, new XorListNode(_memoryAddress, 0, value));
                    _hasNodes = true;
                }
                else
                {
                    var currentNode = _memory[1];
                    var previousNode = (XorListNode)null;

                    while (true)
                    {
                        var nextNodeAddress = currentNode.Both ^ (previousNode?.Address ?? 0);
                        if (nextNodeAddress == 0) break;

                        previousNode = currentNode;
                        currentNode = _memory[nextNodeAddress];
                    }

                    var nodeToAdd = new XorListNode(_memoryAddress, currentNode.Address, value);
                    currentNode.Both ^= nodeToAdd.Address;
                    _memory.Add(_memoryAddress, nodeToAdd);
                }

                _memoryAddress++;
            }

            public T Get(int index)
            {
                if (index >= _memory.Count) throw new IndexOutOfRangeException("Index out of bounds");
                var currentNode = _memory[1];
                var previousNode = (XorListNode)null;

                for (var i = 0; i < index; i++)
                {
                    var nextNodeAddress = currentNode.Both ^ (previousNode?.Address ?? 0);

                    previousNode = currentNode;
                    currentNode = _memory[nextNodeAddress];
                }

                return currentNode.Value;
            }
        }
    }
}
