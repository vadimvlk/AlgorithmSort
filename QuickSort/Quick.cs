using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    public class Quick<T> : AlgorithmBase<T> where T : IComparable
    {
        internal Quick(IEnumerable<T> items) : base(items) { }
        protected override void MakeSort()
        {
            Qsort(0, Items.Count - 1);
        }

        private void Qsort(int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            var pivot = Sorting(left, right);
            Qsort(left, pivot - 1);
            Qsort(pivot + 1, right);
        }

        private int Sorting(int left, int right)
        {
            var pointer = left;           
            for (int i = left; i <= right; i++)
            {
                if (Compare(Items[i], Items[right]) == -1)
                {
                    Swap(pointer, i);
                    pointer++;
                }
            }

            Swap(pointer, right);
            return pointer;
        }
    }
}
