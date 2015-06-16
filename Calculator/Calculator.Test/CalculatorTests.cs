using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Test
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void ShouldAddInts()
        {
            var sut = new Calculator();
            var result = sut.AddInts(1, 2);
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void ShouldAddDoubles()
        {
            var sut = new Calculator();
            var result = sut.AddDoubles(1.1, 2.2);
            Assert.That(result, Is.EqualTo(3.3));
        }
        [Test]
        public void ShouldAddDoubles_WithTolerance()
        {
            var sut = new Calculator();
            var result = sut.AddDoubles(1.1, 2.2);
            Assert.That(result, Is.EqualTo(3.3).Within(0.01));
        }
        [Test]
        public void ShouldAddDoubles_WithPercentTolerance()
        {
            var sut = new Calculator();
            var result = sut.AddDoubles(500, 500);
            Assert.That(result, Is.EqualTo(1002).Within(1).Percent);
        }

        //Also available:
          //Is.Positive
          //Is.Negative
          //Is.NaN (Not a Number)
    }
}
