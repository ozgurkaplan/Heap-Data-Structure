using System;

namespace Heap
{
    public class MinHeap<T> : BaseHeap<T> where T : IComparable<T>
    {

        protected override void MoveUp(int index)
        {
            if (index == 0)
            {
                return;
            }
            var parent = GetParent(index);
            if (IsLess(index, parent))
            {
                Exchange(parent, index);
                MoveUp(parent);
            }
        }

        protected override void MoveDown(int index)
        {
            if (index * 2 + 1 >= Count)
            {
                return;
            }

            var min = GetLeft(index);
            var right = GetRight(index);
            if (right < Count && IsLess(right, min))
            {
                min = right;
            }
            if (IsLess(min, index))
            {
                Exchange(min, index);
                MoveDown(min);
            }
        }
    }
}