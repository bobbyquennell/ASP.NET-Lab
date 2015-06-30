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
            LeftSum = A[0];
            rightSum -= A[0];
            CurrentDifferValue = (rightSum - LeftSum > 0) ? (rightSum - LeftSum) : (LeftSum - rightSum);
            LastDifferValue = CurrentDifferValue;

            for (int i = 1; i < A.Length; i++)
            {
                LeftSum += A[i];
                rightSum -= A[i];
                
                CurrentDifferValue = (rightSum - LeftSum > 0) ? (rightSum - LeftSum) : (LeftSum - rightSum);
                if (CurrentDifferValue < LastDifferValue)
                    LastDifferValue = CurrentDifferValue;
                
            }
            return LastDifferValue;

        }
    }
}
