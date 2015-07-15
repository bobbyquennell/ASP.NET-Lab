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
    class MergSortTest
    {
        [Test]
        public void Test1()
        {
            //arrange
            int[] arr = new int[] { 38, 27,43,3,9,82,10 };
            MergeSortAlg alg = new MergeSortAlg();
            var sut = new Sorter(alg);
            //act
            var result = sut.sort(arr);
            //assert
            Assert.That(result, Is.EqualTo(new int[] { 3,9,10,27,38,43,82}));
        }
    }
}
