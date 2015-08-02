using System;
using System.Collections.Generic;

namespace _02_RoundDance
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Parent { get; set; }

        public Node(T value, Node<T> parent = null)
        {
            this.Value = value;
            this.Parent = parent;
        }
    }
}
