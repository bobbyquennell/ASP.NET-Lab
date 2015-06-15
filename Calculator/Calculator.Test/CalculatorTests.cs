using NUnit.Framework;


namespace Calculator.Test
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void ShouldAddTwoNumbers()
        {
            var sut = new SimpleCalculator();
            var result = sut.Add(1, 2);

            Assert.That(result, Is.EqualTo(3));
        }
        [Test]
        public void ShouldMultiplyTwoNumbers()
        {
            var sut = new SimpleCalculator();
            var result = sut.Multiply(2, 10);
            Assert.That(result, Is.EqualTo(20));
        }
    }
}
