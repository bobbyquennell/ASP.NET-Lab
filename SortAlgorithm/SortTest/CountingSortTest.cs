using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SortAlgorithm;


namespace SortTest
{
    [TestFixture]
    class CountingSortTest
    {
        [Test]
        public void CountingSort_With_2Values()
        {
            //arrange
            int[] arr = new int[] { 5, 2 };
            CountingSortAlg alg = new CountingSortAlg(5);
            var sut = new Sorter(alg);
            //act
            var result = sut.sort(arr);
            //assert
            Assert.That(result, Is.EqualTo(new int[] { 2, 5 }));
        }
        [Test]
        public void CountingSort_With_3Values()
        {
            //arrange
            int[] arr = new int[] { 5, 2,8 };
            CountingSortAlg alg = new CountingSortAlg(8);
            var sut = new Sorter(alg);
            //act
            var result = sut.sort(arr);
            //assert
            Assert.That(result, Is.EqualTo(new int[] { 2, 5, 8 }));
        }
        [Test]
        public void CountingSort_With_6Values()
        {
            //arrange
            int[] arr = new int[] { 5, 2, 8,14,1,16 };
            CountingSortAlg alg = new CountingSortAlg(16);
            var sut = new Sorter(alg);
            //act
            var result = sut.sort(arr);
            //assert
            Assert.That(result, Is.EqualTo(new int[] { 1, 2, 5, 8,14,16 }));
        }
    }
}
