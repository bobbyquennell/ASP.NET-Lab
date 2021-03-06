﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Codility_1;
/*A non-empty zero-indexed array A consisting of N integers is given. Array A represents numbers on a tape.

Any integer P, such that 0 < P < N, splits this tape into two non-empty parts: A[0], A[1], ..., A[P − 1] and A[P], A[P + 1], ..., A[N − 1].

The difference between the two parts is the value of: |(A[0] + A[1] + ... + A[P − 1]) − (A[P] + A[P + 1] + ... + A[N − 1])|

In other words, it is the absolute difference between the sum of the first part and the sum of the second part.

For example, consider array A such that:

  A[0] = 3
  A[1] = 1
  A[2] = 2
  A[3] = 4
  A[4] = 3
We can split this tape in four places:

P = 1, difference = |3 − 10| = 7 
P = 2, difference = |4 − 9| = 5 
P = 3, difference = |6 − 7| = 1 
P = 4, difference = |10 − 3| = 7 
 * 
  A[0] = -3
  A[1] = 0
  A[2] = 2
  A[3] = 4
  A[4] = 3
 *A[5] = 14
P = 1, difference = |-3 − 23| = 26 
P = 2, difference = |-3 − 23| = 26 
P = 3, difference = |-1 − 21| = 22 
P = 4, difference = |3 −17| = 14 
P = 5, difference = |6 −14| = 8 
 * 
Write a function:

class Solution { public int solution(int[] A); }

that, given a non-empty zero-indexed array A of N integers, returns the minimal difference that can be achieved.

For example, given:

  A[0] = 3
  A[1] = 1
  A[2] = 2
  A[3] = 4
  A[4] = 3
the function should return 1, as explained above.

Assume that:

N is an integer within the range [2..100,000];
each element of array A is an integer within the range [−1,000..1,000].
Complexity:

expected worst-case time complexity is O(N);
expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).
Elements of input arrays can be modified.*/

namespace test
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Should_Return_1()
        {
            //arrange
             int[] A = new int[]{3,1,2,4,3};
            var computer = new Solution();
            //act
            int result =  computer.solution(A);
            //assert
            Assert.That(result, Is.EqualTo(1));
        }
        [Test]
        public void Should_Return_2()
        {
            //arrange
            int[] A = new int[] { 3, 1};
            var computer = new Solution();
            //act
            int result = computer.solution(A);
            //assert
            Assert.That(result, Is.EqualTo(2));
        }
        [Test]
        public void Should_Return_0()
        {
            //arrange
            int[] A = new int[] { 3, 1,2 };
            var computer = new Solution();
            //act
            int result = computer.solution(A);
            //assert
            Assert.That(result, Is.EqualTo(0));
        }
        [Test]
        public void Should_Return_8()
        {
            //arrange
            int[] A = new int[] { -3, 0, 2, 4, 3, 14};
            var computer = new Solution();
            //act
            int result = computer.solution(A);
            //assert
            Assert.That(result, Is.EqualTo(8));
        }
        [Test]
        public void Double()
        {
            //arrange
            int[] A = new int[] { -1000, 1000 };
            var computer = new Solution();
            //act
            int result = computer.solution(A);
            //assert
            Assert.That(result, Is.EqualTo(2000));
        }

    }
}
