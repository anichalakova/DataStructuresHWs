using System;

namespace _03_StackDataStructure
{
    public class ArrayStack<T>
    {
        private T[] elements;
        public int Count { get; private set; }

        private const int InitialCapacity = 16;

        public ArrayStack(int capacity = InitialCapacity)
        {
            this.elements = new T[capacity];
            this.Count = 0;
        }

        public void Push(T element)
        {
            if (this.Count == this.elements.Length)
            {
                Grow();
            }

            this.elements[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count>0)
            {
                T lastElement = this.elements[this.Count - 1];
                this.elements[this.Count - 1] = default(T);
                this.Count--;
                return lastElement;
            }
            else
            {
                throw new InvalidOperationException("The stack is empty!");
            }
        }

        public T[] ToArray()
        {
            T[] result = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                result[i] = this.elements[Count-i-1];
            }
            return result;
        }

        private void Grow()
        {
            T[] newArray = new T[this.Count*2];
            Array.Copy(this.elements, newArray, this.Count);
            this.elements = newArray;
        }
    }
}
