using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithm
{
    public class CountingSortAlg:ISortAlgorithm
    {
        int _valueRange;
        public CountingSortAlg(int valueRange)
        {
            _valueRange = valueRange;
        }
        public int[] sort(int[] A)
        {
           int[] Counter = new int[_valueRange+1];//if values in A[] is in range of {0, 1, ...K}, then we need an array with size of k+1
           for (int i = 0; i < A.Length; i++)
			{
			    Counter[A[i]] +=1;
			}
            int p = 0;
            for (int i = 0; i < Counter.Length; i++)
			{
			    for (int j = 0; j < Counter[i]; j++)
			    {
			        A[p] = i;
                    p +=1;
			    }
			}
            return A;
        }
    }
}
