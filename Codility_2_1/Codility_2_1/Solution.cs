using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_2_1
{
    public class Solution
    {
        public int solution(int X, int[] A)
        {
            int PositionFilledWithLeaf = 0;
            int TimeCanCross = -1;
            int[] Count = new int[X];
            for (int i = 0; i < Count.Length; i++)
			{
			    Count[i] = 0;
			}

            for (int i = 0; i < A.Length; i++)
            {
                if(Count[A[i] - 1] == 0){
                    Count[A[i] -1] = 1;
                    PositionFilledWithLeaf += 1;
                }
                if (PositionFilledWithLeaf == X)
                {
                    TimeCanCross = i;
                    break;
                }
            }
            return TimeCanCross;
        }
    }
}
