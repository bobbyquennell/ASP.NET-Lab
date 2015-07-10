using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Codility_3_1;
/*A non-empty zero-indexed array A consisting of N integers is given. The consecutive elements of array A represent consecutive cars on a road.

Array A contains only 0s and/or 1s:

0 represents a car traveling east,
1 represents a car traveling west.
The goal is to count passing cars. We say that a pair of cars (P, Q), where 0 ≤ P < Q < N, is passing when P is traveling to the east and Q is traveling to the west.

For example, consider array A such that:

  A[0] = 0
  A[1] = 1
  A[2] = 0
  A[3] = 1
  A[4] = 1
We have five pairs of passing cars: (0, 1), (0, 3), (0, 4), (2, 3), (2, 4).

Write a function:

class Solution { public int solution(int[] A); }

that, given a non-empty zero-indexed array A of N integers, returns the number of pairs of passing cars.

The function should return −1 if the number of pairs of passing cars exceeds 1,000,000,000.

For example, given:

  A[0] = 0
  A[1] = 1
  A[2] = 0
  A[3] = 1
  A[4] = 1
the function should return 5, as explained above.

Assume that:

N is an integer within the range [1..100,000];
each element of array A is an integer that can have one of the following values: 0, 1.
Complexity:

expected worst-case time complexity is O(N);
expected worst-case space complexity is O(1), beyond input storage (not counting the storage required for input arguments).
Elements of input arrays can be modified.*/
namespace Test
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Test1()
        {
            //arrange
            int[]A = new int[]{0,1,0,1,1};
            var sut = new Solution();
            //act
            var result = sut.solution(A);
            //assert
            Assert.That(result, Is.EqualTo(5));
        }
        [Test]
        public void Test2()
        {
            //arrange
            int[] A = new int[] { 0, 1, 0, 1, 1,0,1 };
            var sut = new Solution();
            //act
            var result = sut.solution(A);
            //assert
            Assert.That(result, Is.EqualTo(8));
        }
        [Test]
        public void Test3()
        {
            //arrange
            int[] A = new int[] { 0 };
            var sut = new Solution();
            //act
            var result = sut.solution(A);
            //assert
            Assert.That(result, Is.EqualTo(0));
        }
        [Test]
        public void Test4()
        {
            //arrange
            int[] A = new int[] { 1 };
            var sut = new Solution();
            //act
            var result = sut.solution(A);
            //assert
            Assert.That(result, Is.EqualTo(0));
        }
        [Test]
        public void Test5()
        {
            //arrange
            int[] A = new int[] { 1,0 };
            var sut = new Solution();
            //act
            var result = sut.solution(A);
            //assert
            Assert.That(result, Is.EqualTo(0));
        }
        [Test]
        public void Test6()
        {
            //arrange
            int[] A = new int[] { 0, 1 };
            var sut = new Solution();
            //act
            var result = sut.solution(A);
            //assert
            Assert.That(result, Is.EqualTo(1));
        }
    }
}
