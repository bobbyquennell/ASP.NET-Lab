using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Codility3_2;
/*Write a function:

class Solution { public int solution(int A, int B, int K); }

that, given three integers A, B and K, returns the number of integers within the range [A..B] that are divisible by K, i.e.:

{ i : A ≤ i ≤ B, i mod K = 0 }

For example, for A = 6, B = 11 and K = 2, your function should return 3, because there are three numbers divisible by 2 within the range [6..11], namely 6, 8 and 10.

Assume that:

A and B are integers within the range [0..2,000,000,000];
K is an integer within the range [1..2,000,000,000];
A ≤ B.
Complexity:

expected worst-case time complexity is O(1);
expected worst-case space complexity is O(1).*/
namespace Test
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void test1()
        {
            //arrange
            var sut = new Solution();
            int A = 6;
            int B = 11;
            int K = 2;
            
            //act
            var result = sut.solution(A, B, K);
            //assert
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void test2()
        {
            //arrange
            var sut = new Solution();
            int A = 1000;
            int B = 1009;
            int K = 8;

            //act
            var result = sut.solution(A, B, K);
            //assert
            Assert.That(result, Is.EqualTo(2));
        }
        [Test]
        public void test3()
        {
            //arrange
            var sut = new Solution();
            int A = 11;
            int B = 345;
            int K = 17;

            //act
            var result = sut.solution(A, B, K);
            //assert
            Assert.That(result, Is.EqualTo(20));
        }
    }
}
