using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Codility_1_2;
/*A small frog wants to get to the other side of the road. The frog is currently located at position X and wants to get to a position greater than or equal to Y. The small frog always jumps a fixed distance, D.

Count the minimal number of jumps that the small frog must perform to reach its target.

Write a function:

class Solution { public int solution(int X, int Y, int D); }

that, given three integers X, Y and D, returns the minimal number of jumps from position X to a position equal to or greater than Y.

For example, given:

  X = 10
  Y = 85
  D = 30
the function should return 3, because the frog will be positioned as follows:

after the first jump, at position 10 + 30 = 40
after the second jump, at position 10 + 30 + 30 = 70
after the third jump, at position 10 + 30 + 30 + 30 = 100
Assume that:

X, Y and D are integers within the range [1..1,000,000,000];
X ≤ Y.
Complexity:

expected worst-case time complexity is O(1);
expected worst-case space complexity is O(1).*/
namespace Test
{
    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void Test1()
        {
            //arrange
            var sut = new Solution();

            //act
            var result = sut.solution(10, 85, 30);
            //assert
            Assert.That(result, Is.EqualTo(3));
        }
        [Test]
        public void Test2()
        {
            //arrange
            var sut = new Solution();

            //act
            var result = sut.solution(10, 185, 30);
            //assert
            Assert.That(result, Is.EqualTo(6));
        }
        [Test]
        public void Test3()
        {
            //arrange
            var sut = new Solution();

            //act
            var result = sut.solution(1, 1, 1);
            //assert
            Assert.That(result, Is.EqualTo(0));
        }
        [Test]
        public void Test4()
        {
            //arrange
            var sut = new Solution();

            //act
            var result = sut.solution(1, 1000000000, 1);
            //assert
            Assert.That(result, Is.EqualTo(999999999));
        }
        [Test]
        public void Test5()
        {
            //arrange
            var sut = new Solution();

            //act
            var result = sut.solution(1, 1, 1000000000);
            //assert
            Assert.That(result, Is.EqualTo(0));
        }
    }
}
