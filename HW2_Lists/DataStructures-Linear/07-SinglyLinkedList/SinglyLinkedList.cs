namespace _07_SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        private class ListNode<T>
        {
            public T Value { get; private set; }

            public ListNode<T> NextNode { get; set; }

            public ListNode(T value)
            {
                this.Value = value;
            }

        }
        private ListNode<T> head { get; set; }
        
        public int Count { get; private set; }

        public void Add(T element)
        {
            var newNode = new ListNode<T>(element);

            if (this.Count == 0)
            {
                this.head = newNode;
            }
            else
            {
                var currentNode = this.head;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    currentNode = currentNode.NextNode;
                }

                currentNode.NextNode = newNode;
            }

            this.Count++;
        }

        public void Add(T element, int index)
        {
            if (index < 0 || index > this.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid index!");
            }
           
            var newNode = new ListNode<T>(element);

            if (this.Count == 0)
            {
                this.head = newNode;
            }
            else
            {
                var currentNode = this.head;
                for (int i = 0; i < index - 1; i++)
                {
                    currentNode = currentNode.NextNode;
                }

                var nodeAfterIndex = currentNode.NextNode;
                newNode.NextNode = nodeAfterIndex;
                currentNode.NextNode = newNode;
            }

            this.Count++;
        }

        public void Remove(int index)
        {
            if (index < 0 || index > this.Count-1)
            {
                throw new ArgumentOutOfRangeException("Invalid index!");
            }
            else
            {
                var currentNode = this.head;
                for (int i = 0; i < index-1; i++)
                {
                    currentNode = currentNode.NextNode;
                }

                var nodeToDelete = currentNode.NextNode;
                var nodeAfterDeleted = nodeToDelete.NextNode;
                currentNode.NextNode = nodeAfterDeleted;
                nodeToDelete = null;
            }

            this.Count--;
        }

        public int FirstIndexOf(T item)
        {
            var currentNode = this.head;

            for (int i = 0; i < this.Count; i++)
            {
                if (currentNode.Value.Equals(item))
                {
                    return i;
                }
                currentNode = currentNode.NextNode;

            }
            return -1;
        }


        public int LastIndexOf(T item)
        {
            var currentNode = this.head;
            int lastIndexOfItem = -1;

            for (int i = 0; i < this.Count; i++)
            {
                if (currentNode.Value.Equals(item))
                {
                    lastIndexOfItem =  i;
                }
                currentNode = currentNode.NextNode;
            }
            return lastIndexOfItem;
        }

        public void ForEach(Action<T> action)
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
