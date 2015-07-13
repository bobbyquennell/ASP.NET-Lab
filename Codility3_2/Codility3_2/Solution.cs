using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility3_2
{
    public class Solution
    {
        public int solution(int A, int B, int K)
        {
            //int count = 0;
            //int[] p = new int[B+1];
            //p[0] = 1;
            //for (int i = 1; i <= B; i++)
            //{
            //    if (i % K == 0)
            //    {
            //        p[i] = p[i - 1] + 1;
            //    }
            //    else
            //    {
            //        p[i] = p[i - 1];
            //    }
            //}
            //if(A%K == 0)
            //{
            //    count = p[B] - p[A] + 1;
            //}else
            //    count=  p[B] - p[A];
            //return count;
            int count = 0;
            if(A%K !=0){
                int remainder = A % K;
                int StepsToMakeA_DivisibleByK = K - remainder;
                A = A + StepsToMakeA_DivisibleByK;
                if (A <= B)
                    count += 1;
            }
            else
            {
                count = 1;
            }
            int distance = B - A;
            if (distance >= K)
            {
                count += distance / K;
            }
            return count;
        }
    }
}
