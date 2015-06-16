using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Test
{
    [TestFixture]
    class NameJoinerTests
    {
        [Test]
        public void ShouldJoinNames()
        {
            
            var sut = new NameJoiner();
            var result = sut.JoinName("Tonny", "Albert");
            Assert.That(result, Is.EqualTo("Tonny Albert"));
            
        }
        [Test]
        public void ShouldJoinNames_CaseInsensitive()
        {
            var sut = new NameJoiner();
            var result = sut.JoinName("tonny", "albert");
            Assert.That(result, Is.EqualTo("TONNY ALBERT").IgnoreCase);
        }
        [Test]
        public void ShouldJoinName_NotEqual()
        {
            var sut = new NameJoiner();
            var result = sut.JoinName("Tonny", "Albert");
            Assert.That(result, Is.Not.EqualTo("Barack Obama"));
        }
    }
}
