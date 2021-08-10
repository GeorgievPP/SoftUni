using System;

namespace CirQueue
{
    public class CircularQueue<T>
    {
        private const int DefaultCapacity = 4;
        private T[] elements;
        private int startIndex = 0;
        private int endIndex = 0;

        public CircularQueue(int capacity = DefaultCapacity)
        {
            this.elements = new T[capacity];
        }

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            if(this.Count == this.elements.Length)
            {
                this.Grow();
            }

            this.elements[this.endIndex] = element;
            this.endIndex = (this.endIndex + 1) % this.elements.Length;
            this.Count++;
        }

        public T Dequeue()
        {
            if(this.Count == 0)
            {
                throw new InvalidOperationException("The Queue is full!");
            }

            var result = this.elements[this.startIndex];
            this.startIndex = (this.startIndex + 1) % this.elements.Length;
            this.Count--;
            return result;
        }

        public T[] ToArray()
        {
            var resultArray = new T[this.Count];
            this.CopyAllElements(resultArray);
            return resultArray;
        }

        private void CopyAllElements(T[] newArray)
        {
            int sourceIndex = this.startIndex;

            for(int i = 0; i < this.Count; i++)
            {
                newArray[i] = this.elements[sourceIndex];
                sourceIndex = (sourceIndex + 1) % this.elements.Length;
            }
        }

        private void Grow()
        {
            var newElements = new T[this.elements.Length * 2];
            this.CopyAllElements(newElements);
            this.elements = newElements;
            this.startIndex = 0;
            this.endIndex = this.Count;
        }
    }
}
