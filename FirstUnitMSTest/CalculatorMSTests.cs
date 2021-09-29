using FirstUnitTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FirstUnitMSTest
{
  [TestClass]
   public class CalculatorMSTests
    {
        [TestMethod]
        public void AddNumbers_InputTwoInt_OutputGetCorrectAddition()
        {
            //Arrange - intialisation
            Calculator calc = new();

            //Act

            int result = calc.AddNumbers(10, 20);

            //Assert

            Assert.AreEqual(30, result);
        }

        [TestMethod]
        public void AddNumbers_InputTwoInt_OutputGetInCorrectAddition()
        {
            //Arrange - intialisation
            Calculator calc = new();

            //Act

            int result = calc.AddNumbers(10, 20);

            //Assert

            Assert.AreNotEqual(3, result);
        }

    }
}

// testclasses have to be decorated with Testclass.
