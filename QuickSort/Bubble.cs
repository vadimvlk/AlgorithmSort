using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
   internal class Bubble<T> : AlgorithmBase<T> where T : IComparable
    {      
        internal Bubble(IEnumerable<T> items) : base(items) { }      
      
        protected override void MakeSort()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                for (int j = i + 1; j < Items.Count; j++)
                {                    
                    if (Compare(Items[i],Items[j]) == 1)
                    {
                        Swap(i, j);
                    }
                }
            }
        }
    }
}
