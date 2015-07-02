using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_1_3
{
    public class Solution
    {
        public int solution(int[] A){
            int missedValue;
            int totalSumWithoutMissNum;
            int SumOfA = 0;
            int length = A.Length;

            if ((length+1) % 2 == 0)
                totalSumWithoutMissNum = (1 + (length+1)) * ((length+1)/2);
            else//length % 2 == 0
                totalSumWithoutMissNum = (1 + length) * (length / 2) + (length + 1);

            for (int i = 0; i < length; i++)
            {
                SumOfA += A[i];
            }
            missedValue = totalSumWithoutMissNum - SumOfA;
            return missedValue;
        }
    }
}
