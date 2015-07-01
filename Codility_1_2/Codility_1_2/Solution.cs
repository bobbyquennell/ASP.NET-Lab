using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_1_2
{
    public class Solution
    {
        public int solution(int x, int y, int D)
        {
            double distance = y - x;
            return (int)Math.Ceiling(distance /D);
        }
    }
}
