using System;

namespace _05_LinkedStack
{
    public class LinkedStack<T>
    {
        private Node<T> firstNode;
        public int Count { get; private set; }

        public void Push(T element)
        {
            var newNode = new Node<T>(element, firstNode);
            this.firstNode = newNode;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count==0)
            {
                throw new InvalidOperationException("Can not pop from an empty stack!");
            }
            var element = this.firstNode.Value;
            this.firstNode = firstNode.NextNode;
            this.Count--;
            return element;
        }

        public T[] ToArray()
        {
            var array = new T[this.Count];
            var currentNode = this.firstNode;

            for (int i = 0; i < this.Count; i++)
            {
                array[i] = currentNode.Value;
                currentNode = currentNode.NextNode;
            }
            return array;
        }

        private void Grow()
        {
            // I don't see any reason to have grow method in a linked structure.
        }
        private class Node<T>
        {
            private T value;

            public T Value { get; set; }
            public Node<T> NextNode { get; set; }

            public Node(T value, Node<T> nextNode = null)
            {
                this.Value = value;
                this.NextNode = nextNode;
            }
        }
    }
}
