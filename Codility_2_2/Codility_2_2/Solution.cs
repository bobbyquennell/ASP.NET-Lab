using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_2_2
{
    public class Solution
    {
        public int solution(int[] A)
        {
            int N = A.Length;
            int permutationLength = 0;
            //1......N once and only once
            int[] CheckArray = new int[N];
            for (int i = 0; i < N; i++)
			{
			     CheckArray[i] = 0;
			}
            for (int i = 0; i < N; i++)
			{
                 if(A[i]>N)
                    break;
                 if (CheckArray[(A[i]-1)] == 0){
                    CheckArray[A[i] -1] +=1;
                     permutationLength++;
                 }
			}
            return (permutationLength== N) ? 1:0;
        } 
    }
}
