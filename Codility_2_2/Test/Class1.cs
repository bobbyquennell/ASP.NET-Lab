using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Codility_2_2;
/*A non-empty zero-indexed array A consisting of N integers is given.

A permutation is a sequence containing each element from 1 to N once, and only once.

For example, array A such that:

    A[0] = 4
    A[1] = 1
    A[2] = 3
    A[3] = 2
is a permutation, but array A such that:

    A[0] = 4
    A[1] = 1
    A[2] = 3
is not a permutation, because value 2 is missing.

The goal is to check whether array A is a permutation.

Write a function:

class Solution { public int solution(int[] A); }

that, given a zero-indexed array A, returns 1 if array A is a permutation and 0 if it is not.

For example, given array A such that:

    A[0] = 4
    A[1] = 1
    A[2] = 3
    A[3] = 2
the function should return 1.

Given array A such that:

    A[0] = 4
    A[1] = 1
    A[2] = 3
the function should return 0.

Assume that:

N is an integer within the range [1..100,000];
each element of array A is an integer within the range [1..1,000,000,000].
Complexity:

expected worst-case time complexity is O(N);
expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).
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
            int[] A = new int[] { 4, 1, 3, 2 };
            var sut = new Solution();
            //act
            var result = sut.solution(A);
            //assert
            Assert.That(result, Is.EqualTo(1));
        }
        [Test]
        public void Test2()
        {
            //arrange
            int[] A = new int[] { 4, 1, 3 };
            var sut = new Solution();
            //act
            var result = sut.solution(A);
            //assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Test3()
        {
            //arrange
            int[] A = new int[] { 4, 1, 3, 5 };
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
            int[] A = new int[] { 4, 1, 3, 5,2 };
            var sut = new Solution();
            //act
            var result = sut.solution(A);
            //assert
            Assert.That(result, Is.EqualTo(1));
        }
        [Test]
        public void Test5()
        {
            //arrange
            int[] A = new int[] { 4, 1, 1, 5, 2 };
            var sut = new Solution();
            //act
            var result = sut.solution(A);
            //assert
            Assert.That(result, Is.EqualTo(0));
        }
    }
}
