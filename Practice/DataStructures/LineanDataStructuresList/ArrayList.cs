﻿using System;

namespace LineanDataStructuresList
{
    public class ArrayList<T>
    {
        private const int INITIAL_CAPACITY = 2;
        private T[] items;

        public ArrayList()
        {
            this.items = new T[INITIAL_CAPACITY];
        }

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                if(index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return this.items[index];
            }

            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.items[index] = value;
            }
        }

        public void Add(T item)
        {
            if(this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.items[this.Count++] = item;
        }

        public T RemoveAtt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            T element = this.items[index];
            this.items[index] = default(T);
            this.Shift(index);
            this.Count--;

            if(this.Count <= this.items.Length / 4)
            {
                this.Shrink();
            }

            return element;
        }

        private void Resize()
        {
            T[] copy = new T[this.items.Length * 2];
            Array.Copy(this.items, copy, this.Count);
            this.items = copy;
        }

        private void Shrink()
        {
            T[] copy = new T[this.items.Length / 2];
            Array.Copy(this.items, copy, this.Count);
            this.items = copy;
        }

        private void Shift(int index)
        {
            for (int i = index; i < this.Count; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }
    }
}
