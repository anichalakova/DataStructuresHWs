using System;

namespace _07_LinkedQueue
{
    public class LinkedQueue<T>
    {
        private QueueNode<T> head;
        private QueueNode<T> tail;
        
        public int Count { get; private set; }
      
        public void Enqueue(T element)
        {
            var newNode = new QueueNode<T>(element);
            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
            }
            else
            {
                newNode.PrevNode = this.tail;
                this.tail.NextNode = newNode;
                this.tail = newNode;
            }
            this.Count++;
        }

        public T Dequeue()
        {
            T headValue = default (T);
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Cannot dequeue from an empty queue!");
            }
            else if (this.Count == 1)
            {
                headValue = this.head.Value;
                this.head = this.tail = null;
            }
            else
            {
                headValue = this.head.Value;
                this.head.NextNode.PrevNode = null;
                this.head = this.head.NextNode;
            }
            this.Count--;
            return headValue;
        }

        public T[] ToArray()
        {

            var currentElement = this.head;
            var result = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                result[i] = currentElement.Value;
                currentElement = currentElement.NextNode;
            }
            return result;
        }

        private class QueueNode<T>
        {
            public T Value { get; private set; }
            public QueueNode<T> NextNode { get; set; }
            public QueueNode<T> PrevNode { get; set; }

            public QueueNode(T value = default (T))
            {
                this.Value = value;
            }
        }
    }
}
