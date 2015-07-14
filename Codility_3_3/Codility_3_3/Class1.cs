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
            int[] ACountArray = new int[N];
            int[] CCountArray = new int[N];
            int[] GCountArray = new int[N];
            int[] TCountArray = new int[N];
            int[] QueryResult = new int[M];

            for (int i = 0; i < N; i++)
            {
                switch (S[i])
                {
                    case 'A':
                        if (i == 0)
                        {
                            ACountArray[i] =  1;
                        }
                        else
                        {
                            ACountArray[i] = ACountArray[i - 1] + 1;
                            CCountArray[i] = CCountArray[i - 1];
                            GCountArray[i] = GCountArray[i - 1];
                            TCountArray[i] = TCountArray[i - 1];
                        }

                        break;
                    case 'C':
                        if (i == 0)
                        {
                            CCountArray[i] = 1;
                        }
                        else
                        {
                            ACountArray[i] = ACountArray[i - 1];
                            CCountArray[i] = CCountArray[i - 1] + 1;
                            GCountArray[i] = GCountArray[i - 1];
                            TCountArray[i] = TCountArray[i - 1];
                        }
                        
                        break;
                    case'G':
                        if (i == 0)
                        {
                            GCountArray[i] = 1;
                        }
                        else
                        {
                            ACountArray[i] = ACountArray[i - 1];
                            CCountArray[i] = CCountArray[i - 1];
                            GCountArray[i] = GCountArray[i - 1] + 1;
                            TCountArray[i] = TCountArray[i - 1];
                        }

                        break;
                    case 'T':
                        if (i == 0)
                        {
                            TCountArray[i] = 1;
                        }
                        else
                        {
                            ACountArray[i] = ACountArray[i - 1];
                            CCountArray[i] = CCountArray[i - 1];
                            GCountArray[i] = GCountArray[i - 1];
                            TCountArray[i] = TCountArray[i - 1] + 1;
                        }

                        break;
                    default:
                        break;
                }
            }
            for (int i = 0; i < M; i++)
            {
                if (P[i] == Q[i])
                    QueryResult[i] = GetImpactFactor(S[P[i]]);
                else
                 QueryResult[i] = getMinNucleotide(ACountArray,CCountArray,GCountArray,TCountArray, P[i], Q[i]);
            }
            return QueryResult;
        }

        private int GetImpactFactor(char p)
        {
            int ImpactFactor = 0;
            switch (p)
            {
                case 'A':
                    ImpactFactor = 1;
                    break;
                case 'C':
                    ImpactFactor = 2;
                    break;
                case 'G':
                    ImpactFactor = 3;
                    break;
                case 'T':
                    ImpactFactor = 4;
                    break;
                default:
                    break;
            }
            return ImpactFactor;
        }

        private int getMinNucleotide(int[] ACountArray, int[] CCountArray, int[] GCountArray, int[] TCountArray, int p1, int p2)
        {
            int minNucleotide = 4;
            if ((p1 ==0&&ACountArray[p2]>0)||(p1>0 && (ACountArray[p2] - ACountArray[p1-1]) >0))
            {
                minNucleotide = 1;
            }
            else if ((p1 == 0 && CCountArray[p2] > 0) || (p1 > 0 && (CCountArray[p2] - CCountArray[p1 - 1]) > 0))
            {
                minNucleotide = 2;
            }
            else if ((p1 == 0 && GCountArray[p2] > 0) || (p1 > 0 && (GCountArray[p2] - GCountArray[p1 - 1]) > 0))
            {
                minNucleotide = 3;
            }
            else if ((p1 == 0 && GCountArray[p2] > 0) || (p1 > 0 && (GCountArray[p2] - GCountArray[p1 - 1]) > 0))
            {
                minNucleotide = 4;
            }

            return minNucleotide;
        }
    }
}
