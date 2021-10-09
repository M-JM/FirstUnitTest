using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstUnitTest
{
    [TestFixture]
    public class FiboNUnitTest
    {

        
        private Fibo fibo;

        [SetUp]
        public void setUp()
        {
            fibo = new Fibo();
        }

        [Test]
        public void Fibo_InputRange1_OutputListwith1Element()
        {
            fibo.Range = 1;

            List<int> expectedResult = new List<int>() { 0 };
            List<int> result = fibo.GetFiboSeries();

            Assert.That(result, Is.EquivalentTo(expectedResult));
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result, Is.Ordered);
        }


        [Test]
        public void Fibo_InputRange6_OutputListwith1Element()
        {
            fibo.Range = 6;
            List<int> expectedResult = new List<int>() { 0,1,1,2,3,5 };
            List<int> result = fibo.GetFiboSeries();

            Assert.That(result, Is.EquivalentTo(expectedResult));
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count, Is.EqualTo(6));
            Assert.That(result, Is.Ordered);
            Assert.That(result, Does.Contain(3));
            Assert.That(result,Does.Not.Contain(4));
        }

    }
}
