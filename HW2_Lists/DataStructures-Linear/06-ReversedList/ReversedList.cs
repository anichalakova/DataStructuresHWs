namespace ReversedList
{
    using System;
    using System.Collections.Generic;
    using System.Collections;

    public class ReversedList<T> : IEnumerable<T>
    {
        private T[] arr = new T[0];

        public int Count { get; private set; }

        public T this[int indexReversed]
        {
            get
            {
                return this.arr[this.arr.Length- 2- indexReversed];
            }
        }

        public int Capacity
        {
            get
            {
                return this.arr.Length;
            }
        }

        public void Add(T element)
        {
            if (this.arr.Length == 0)
            {
                var newArray = new T[3];
                this.arr.CopyTo(newArray, 0);
                newArray[0] = element;
                this.arr = newArray;                
            }
            else
            {
                if (this.Count == this.Capacity)
                {
                    var newArray = new T[this.Capacity * 2];
                    Array.Copy(this.arr, newArray, this.arr.Length);
                    newArray[Count] = element;
                    this.arr = newArray;
                }
                else
                {
                    this.arr[Count] = element;
                }
            }
            this.Count++;
        }

        public T Remove(int indexReversed)
        {
            var index = this.arr.Length - 1 - indexReversed;
            var elementToRemove = this.arr[index];
            var newArray = new T[this.Capacity-1];
            Array.Copy(this.arr, newArray, index);
            Array.Copy(this.arr, index +1, newArray, index, this.arr.Length - index-1);
            this.arr = newArray;
            this.Count--;
            return elementToRemove;
        }

        public void ForEach(Action<T> action)
        {
            
            if (this.arr.Length > 0)
            {
                var index = 0;
                var currentElement = this.arr[this.arr.Length - 1 - index];
                while (index < this.Count-1)
                {
                    action(currentElement);
                    index++;
                    currentElement = this.arr[this.arr.Length - 1 - index];
                }
                action(currentElement);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var index = 0;
            var currentNode = this.arr[index];
            while (currentNode != null)
            {
                yield return currentNode;
                index++;
                currentNode = this.arr[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }
}
