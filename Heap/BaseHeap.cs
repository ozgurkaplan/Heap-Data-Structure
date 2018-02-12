using System;
using System.Collections.Generic;

namespace Heap
{
    public abstract class BaseHeap<T> where T : IComparable<T>
    {
        protected List<T> Items;
        public int Count => Items.Count;
        private bool HasCapacity;
        private int _size = 0;
        protected bool AtCapacity => HasCapacity && Count == _size;
        public BaseHeap()
        {
            Items = new List<T>();
            HasCapacity = false;
        }

        public BaseHeap(int size)
        {
            _size = size;
            Items = new List<T>(size);
            HasCapacity = true;
        }

        public T Peek() => Items[0];

        public void Add(T t)
        {
            if (!AtCapacity)
            {
                Items.Add(t);
                MoveUp(Items.Count - 1);
            }
            else
            {
                Items[0] = t;
                MoveDown(0);
            }
        }

        public T Pop()
        {
            var temp = Items[0];
            Items[0] = Items[Items.Count - 1];
            Items.RemoveAt(Items.Count - 1);
            MoveDown(0);
            return temp;
        }

        protected bool IsLess(int first, int second)
        {
            return Items[first].CompareTo(Items[second]) == -1;
        }

        protected void Exchange(int first, int second)
        {
            var temp = Items[first];
            Items[first] = Items[second];
            Items[second] = temp;
        }

        protected int GetParent(int i) => (i - 1) / 2;
        protected int GetLeft(int i) => i * 2 + 1;
        protected int GetRight(int i) => i * 2 + 2;

        protected abstract void MoveUp(int index);
        protected abstract void MoveDown(int index);


    }
}