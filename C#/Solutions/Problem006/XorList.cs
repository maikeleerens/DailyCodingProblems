using System;
using System.Collections.Generic;

namespace DailyCodingProblems.Solutions.Problem006
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

        /// <summary>
        /// Nodes in a <see cref="XorList{T}"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class XorListNode
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
    }
}
