using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_3_3
{
    public class Solution
    {
        public int[] solution(string S, int[] P, int[] Q)
        {
            int N = S.Length;
            int M = P.Length;
            int[] DNA = new int[N];
            int[] QueryResult = new int[M];
            for (int i = 0; i < N; i++)
            {
                switch (S[i])
                {
                    case 'A':
                        DNA[i] = 1;
                        break;
                    case 'C':
                        DNA[i] = 2;
                        break;
                    case'G':
                        DNA[i] = 3;
                        break;
                    case'T':
                        DNA[i] = 4;
                        break;
                    default:
                        break;
                }
            }
            for (int i = 0; i < M; i++)
            {
                QueryResult[i]= getMinNucleotide(DNA, P[i], Q[i]);
            }
            return QueryResult;
        }

        private int getMinNucleotide(int[] DNA, int p1, int p2)
        {
            int minNucleotide = 4;
            for (int i = p1; i <= p2; i++)
            {
                if (DNA[i]<minNucleotide)
                {
                    minNucleotide = DNA[i];
                    if (minNucleotide == 1)
                    {
                        break;
                    }
                }
            }
            return minNucleotide;
        }
    }
}
