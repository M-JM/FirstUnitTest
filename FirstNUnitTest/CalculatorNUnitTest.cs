using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstUnitTest
{

    [TestFixture]
   public class CalculatorNUnitTest
    {
        [Test]
        public void AddNumbers_InputTwoInt_OutputGetCorrectAddition()
        {
            //Arrange - intialisation
            Calculator calc = new();

            //Act

            int result = calc.AddNumbers(10, 20);

            //Assert

            Assert.AreEqual(30, result);
        }

    }
}
