using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Codility_2_3;
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
            int[] A = new int[]{1,3,6,4,1,2};
            //act
            var result = sut.solution(A);
            //assert
            Assert.That(result, Is.EqualTo(5));
        }
        [Test]
        public void Test2()
        {
            //arrange
            var sut = new Solution();
            int[] A = new int[] { 1, 3, 6, 3, 1, 2 };
            //act
            var result = sut.solution(A);
            //assert
            Assert.That(result, Is.EqualTo(4));
        }
        [Test]
        public void Test3()
        {
            //arrange
            var sut = new Solution();
            int[] A = new int[] { -2147483648, 1, 2, 3, 5, 2147483647 };
            //act
            var result = sut.solution(A);
            //assert
            Assert.That(result, Is.EqualTo(4));
        }
        [Test]
        public void Test4()
        {
            //arrange
            var sut = new Solution();
            int[] A = new int[] { 1, 2, 3, 4, 5, 6 };
            //act
            var result = sut.solution(A);
            //assert
            Assert.That(result, Is.EqualTo(7));
        }
        [Test]
        public void Test5()
        {
            //arrange
            var sut = new Solution();
            int[] A = new int[] { -1, -2, -3, -4, -5, -6 };
            //act
            var result = sut.solution(A);
            //assert
            Assert.That(result, Is.EqualTo(1));
        }
        [Test]
        public void Test6()
        {
            //arrange
            var sut = new Solution();
            int[] A = new int[] { 1, 2, 3, 4, 5, 6,7,8 };
            //act
            var result = sut.solution(A);
            //assert
            Assert.That(result, Is.EqualTo(9));
        }
    }
}
