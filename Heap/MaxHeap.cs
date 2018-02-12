using System;

namespace Heap
{
    public class MaxHeap<T> : BaseHeap<T> where T : IComparable<T>
    {

        protected override void MoveUp(int index)
        {
            if (index == 0)
            {
                return;
            }
            var parent = GetParent(index);
            if (IsLess(parent, index))
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

            var max = GetLeft(index);
            var right = GetRight(index);
            if (right < Count && IsLess(max, right))
            {
                max = right;
            }
            if (IsLess(index, max))
            {
                Exchange(max, index);
                MoveDown(max);
            }
        }
    }
}