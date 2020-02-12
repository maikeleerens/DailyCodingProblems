using System;
using System.Collections.Generic;
using Xunit;

namespace Solutions.Problem006
{
    /// <summary>
    /// This problem was asked by Google.
    /// An XOR linked list is a more memory efficient doubly linked list. Instead of each node holding next and prev fields, it holds a field named both, which is an XOR of the next node and the previous node.
    /// Implement an XOR linked list; it has an add(element) which adds the element to the end, and a get(index) which returns the node at index.
    /// If using a language that has no pointers(such as Python), you can assume you have access to get_pointer and dereference_pointer functions that converts between nodes and memory addresses.
    /// </summary>
    public class Problem006
    {
        [Fact]
        public void Problem006SolutionTest()
        {
            var XORList = new XORList<int>();
            XORList.Add(10);
            XORList.Add(20);
            XORList.Add(30);

            Assert.Equal(10, XORList.Get(0));
            Assert.Equal(20, XORList.Get(1));
            Assert.Equal(30, XORList.Get(2));
        }
    }

    /// <summary>
    /// XOR linked list containing <see cref="XORListNode{T}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class XORList<T>
    {
        private readonly IDictionary<int, XORListNode<T>> _memory = new Dictionary<int, XORListNode<T>>();
        private int _memoryAddress = 1;
        private bool _hasNodes;

        public void Add(T value)
        {
            if (!_hasNodes)
            {
                _memory.Add(_memoryAddress, new XORListNode<T>(_memoryAddress, 0, value));
                _hasNodes = true;
            }
            else
            {
                var currentNode = _memory[1];
                var previousNode = (XORListNode<T>)null;

                while (true)
                {
                    var nextNodeAddress = currentNode.Both ^ (previousNode?.Address ?? 0);
                    if (nextNodeAddress == 0) break;

                    previousNode = currentNode;
                    currentNode = _memory[nextNodeAddress];
                }

                var nodeToAdd = new XORListNode<T>(_memoryAddress, currentNode.Address, value);
                currentNode.Both ^= nodeToAdd.Address;
                _memory.Add(_memoryAddress, currentNode);
            }

            _memoryAddress++;
        }

        public T Get(int index)
        {
            if (index >= _memory.Count) throw new IndexOutOfRangeException("Index out of bounds");
            var currentNode = _memory[1];
            var previousNode = (XORListNode<T>)null;

            for (var i = 0; i < index; i++)
            {
                var nextNodeAddress = currentNode.Both ^ (previousNode?.Address ?? 0);

                previousNode = currentNode;
                currentNode = _memory[nextNodeAddress];
            }

            return currentNode.Value;
        }
    }

    /// <summary>
    /// Nodes in a <see cref="XORList{T}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class XORListNode<T>
    {
        public int Address { get; set; }
        public int Both { get; set; }
        public T Value { get; set; }

        public XORListNode(int address, int both, T value)
        {
            Address = address;
            Both = both;
            Value = value;
        }
    }
}
