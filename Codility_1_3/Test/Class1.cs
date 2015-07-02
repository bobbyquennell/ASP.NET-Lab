using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Codility_1_3;
/*A zero-indexed array A consisting of N different integers is given. The array contains integers in the range [1..(N + 1)], which means that exactly one element is missing.

Your goal is to find that missing element.

Write a function:

class Solution { public int solution(int[] A); }

that, given a zero-indexed array A, returns the value of the missing element.

For example, given array A such that:

  A[0] = 2
  A[1] = 3
  A[2] = 1
  A[3] = 5
the function should return 4, as it is the missing element.

Assume that:

N is an integer within the range [0..100,000];
the elements of A are all distinct;
each element of array A is an integer within the range [1..(N + 1)].
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
            var sut = new Solution();
            int[] A = new int[4]{2,3,1,5};
            //act
            var result = sut.solution(A);
            //assert
            Assert.That(result, Is.EqualTo(4));
        }
        [Test]
        public void Test2()
        {
            //arrange
            var sut = new Solution();
            int[] A = new int[4] { 2, 4, 1, 5 };
            //act
            var result = sut.solution(A);
            //assert
            Assert.That(result, Is.EqualTo(3));
        }
        [Test]
        public void Test3()
        {
            //arrange
            var sut = new Solution();
            int[] A = new int[5] { 2, 4, 1, 5,6 };
            //act
            var result = sut.solution(A);
            //assert
            Assert.That(result, Is.EqualTo(3));
        }
    }
}
