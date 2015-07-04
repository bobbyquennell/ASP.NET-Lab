using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_2_4
{
    public class Solution
    {
        public int[] solution(int N, int[] A)
        {
            int MaxCount = 0;
            int M = A.Length;
            int[] Counter = new int[N];
            bool isMaxCountUpdated = false;
            for (int i = 0; i < N; i++)
            {
                Counter[i] = 0;
            }

            for (int i = 0; i < M; i++)
            {
                if ((A[i] >= 1) && (A[i] <= N))
                {
                    Counter[A[i]-1] += 1;
                    MaxCount = Math.Max(MaxCount, Counter[A[i]-1]);
                    isMaxCountUpdated = true;
                }
                else if (A[i] == N + 1)
                {
                    if (isMaxCountUpdated)
                    {
                        for (int x = 0; x < N; x++)
                        {
                            Counter[x] = MaxCount;
                        }
                        isMaxCountUpdated = false;
                    }
                }
            }
            
            return Counter;
        }
    }
}
