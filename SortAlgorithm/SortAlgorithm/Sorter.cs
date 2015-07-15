using SortAlgorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortAlgorithm
{
    public class Sorter
    {
        ISortAlgorithm _alg;
        public Sorter (ISortAlgorithm alg)
	    {
            _alg = alg;
	    }
        public int[] sort(int[] A)
        {
            return _alg.sort(A);
        }
    }
}
