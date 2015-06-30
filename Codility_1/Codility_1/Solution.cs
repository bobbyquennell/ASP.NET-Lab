using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_1
{
    public class Solution
    {
        public int solution(int[] A)
        {
            int LastDifferValue = 0;
            int CurrentDifferValue = 0;
            int rightSum = 0;
            int LeftSum = 0;

            //List<int> leftArray = new List<int>();
            foreach (var item in A.ToList())
            {
                rightSum += item;
            }

            LastDifferValue = CurrentDifferValue;

            for (int i = 0; i < A.Length-1; i++)
            {
                LeftSum += A[i];
                rightSum -= A[i];
                
                CurrentDifferValue = (rightSum - LeftSum > 0) ? (rightSum - LeftSum) : (LeftSum - rightSum);
                if (i == 0)
                    LastDifferValue = CurrentDifferValue;

                if (CurrentDifferValue < LastDifferValue)
                    LastDifferValue = CurrentDifferValue;
                
            }
            return LastDifferValue;

        }
    }
}
