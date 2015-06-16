using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator
    {
        public int AddInts(int a, int b)
        {
            return a + b;
        }
        public double AddDoubles(double a, double b)
        {
            return a + b;
        }
        public int Divide(int value, int by)
        {
            if (value > 100)
            {
                throw new ArgumentOutOfRangeException("by"); //bug for demo purposes 
            }
            return value / by;
        }
    }
}
