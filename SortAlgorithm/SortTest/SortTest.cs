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
    public class SelectionSortTest
    {
        [Test]
        public void SelectionSort_With2Values()
        {
            //arrange
            int[] arr = new int[] { 5, 2 };
            var alg = new SelectSortAlg();
            var sut = new Sorter(alg);
            //act
            var result = sut.sort(arr);
            //assert
            Assert.That(result, Is.EqualTo(new int[]{2,5}));
        }
        [Test]
        public void SelectionSort_With3Values()
        {
            //arrange
            int[] arr = new int[] { 5, 2, 8 };
            var alg = new SelectSortAlg();
            var sut = new Sorter(alg);
            //act
            var result = sut.sort(arr);
            //assert
            Assert.That(result, Is.EqualTo(new int[] { 2, 5, 8 }));
        }
        [Test]
        public void SelectionSort_With6Values()
        {
            //arrange
            int[] arr = new int[] { 5, 2, 8,14,1,16 };
            var alg = new SelectSortAlg();
            var sut = new Sorter(alg);
            //act
            var result = sut.sort(arr);
            //assert
            Assert.That(result, Is.EqualTo(new int[] {1, 2, 5, 8,14,16 }));
        }
    }
}
