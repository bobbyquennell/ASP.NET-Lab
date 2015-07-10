using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_3_1
{
    public class Solution
    {
        public int solution(int[] A)
        {
            int counter = 0;
            int numberofCarMovingRight = 0;
            foreach (var car in A)
            {
                if (car == 0)//found a car moving right
                {
                    numberofCarMovingRight += 1;

                }
                if (car == 1)//found a car moving left, with pass all the car moving right which is found previously
                {


                    counter += numberofCarMovingRight;
                    if (counter > 1000000000)
                    {
                        return -1;
                    }

                }
            }
            return counter;
        }
    }
}
