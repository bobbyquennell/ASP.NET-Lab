using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithm
{
    public class SelectSortAlg: ISortAlgorithm
    {
        public int[] sort(int[] A)
        {
            int N = A.Length;
            int minIndex = 0;
            for (int i = 0; i < N; i++)
            {
                minIndex = i;

                for (int j = i + 1; j < N; j++)
                {
                    if (A[minIndex] > A[j])
                    {
                        minIndex = j;
                    }
                }
                int temp = A[i];
                A[i] = A[minIndex];
                A[minIndex] = temp;
            }
            return A;
        }
    }
}
