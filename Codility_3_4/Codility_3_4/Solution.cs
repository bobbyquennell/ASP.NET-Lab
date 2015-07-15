using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_3_4
{
    public class Solution
    {
        public int solution(int[] A)
        {
            int StartIndex_2Slice = 0;
            int StartIndex_3Slice = 0;


            if (A.Length == 2)
                return StartIndex_2Slice;
            int minSum2Slice = A[0] + A[1];
            int minSum3Slice = A[0] + A[1] + A[2];

            int[] PrefixSum2Slice = new int[A.Length - 1];
            int[] PrefixSum3Slice = new int[A.Length - 2];

            for (int i = 0; i < PrefixSum2Slice.Length; i++)
            {
                PrefixSum2Slice[i] += A[i] + A[i + 1];
                if (i > 0) { 
                    if (PrefixSum2Slice[i] < minSum2Slice) {
                        minSum2Slice = PrefixSum2Slice[i];
                        StartIndex_2Slice = i;
                    }
                }
            }
            for (int i = 0; i < PrefixSum3Slice.Length; i++)
            {
                PrefixSum3Slice[i] += A[i] + A[i + 1] + A[i+2];
                if (i > 0)
                {
                    if (PrefixSum3Slice[i] < minSum3Slice)
                    {
                        minSum3Slice = PrefixSum3Slice[i];
                        StartIndex_3Slice = i;
                    }
                }
            }
            float minAvg3Slice = minSum3Slice / 3f;
            float minAvg2Slice = minSum2Slice / 2f;
            if (minAvg3Slice > minAvg2Slice)
            {
                return StartIndex_2Slice;
            }
            else if (minAvg3Slice == minAvg2Slice)
            {
                return Math.Min(StartIndex_2Slice, StartIndex_3Slice);
            }
            else
                return StartIndex_3Slice;
        }
    }
}
