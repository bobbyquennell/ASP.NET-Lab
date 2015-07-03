using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_2_3
{
    public class Solution
    {
        public int solution(int[] A)
        {
            int N = A.Length;
            int[] CheckArray = new int[N];
            int minLost = 1;
            for (int i = 0; i < N; i++)
            {
                CheckArray[i] = 1 + i;
            }
            for (int i = 0; i < N; i++)
            {
                
                if ((A[i] > 0)&&(A[i]<=N))
                {
                    CheckArray[A[i] - 1] = 0;
                }
            }
            for (int i = 0; i < N; i++)
            {
                if (CheckArray[i] > 0)
                {
                    minLost = CheckArray[i];
                    break;
                }
                if(CheckArray[i] == 0)
                {
                    minLost = i + 2;
                }
            }
            return minLost;
        }
    }
}
