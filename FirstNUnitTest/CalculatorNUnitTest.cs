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

        [Test]

        public void IsOddNumber_InputOneInt_OutputGetTrue()
        {
            //Arrange - intialisation
            Calculator calc = new();

            //Act
            bool result = calc.IsOddNumber(3);

            //Assert
            Assert.IsTrue(result);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void IsOddNumber_InputOneInt_OutputGetFalse()
        {
            //Arrange - intialisation
            Calculator calc = new();

            //Act
            bool result = calc.IsOddNumber(2);

            //Assert
            Assert.IsFalse(result);
            Assert.That(result, Is.EqualTo(false));
        }


        [Test]
        [TestCase(10)]
        [TestCase(12)]
        [TestCase(14)]
        [TestCase(16)]
        public void IsOddNumber_InputOneInt_multipleCases_OutputGetFalse(int a)
        {
            //Arrange - intialisation
            Calculator calc = new();

            //Act
            bool result = calc.IsOddNumber(a);

            //Assert
            Assert.IsFalse(result);
            Assert.That(result, Is.EqualTo(false));
        }
        [Test]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(11, ExpectedResult = true)]

        public bool IsOddChecker_InputNumber_ReturnTrueIfOdd_ReturnFalseIfEven(int a)
        {
            //Arrange - intialisation
            Calculator calc = new();

            //Act
            return calc.IsOddNumber(a);

            // the assert is being done with the expected return type of the method being equal to the second param
            // given in the Testcase
        }

        [Test]
        [TestCase(5.4, 10.5)] // 15.9
        [TestCase(5.43, 10.53)] // 15.96
        [TestCase(5.49, 10.59)] // 16.08
        public void AddNumbersDouble_InputTwoDouble_OutputGetCorrectAddition(double a, double b)
        {
            //Arrange - intialisation
            Calculator calc = new();

            //Act
            double result = calc.AddNumbersDouble(a, b);

            //Assert
            Assert.AreEqual(15.9, result, .2);
        }

        [Test]
        [TestCase(5.40, 10.50, ExpectedResult = 15.90)] // 15.9
        [TestCase(5.43, 10.53, ExpectedResult = 15.96)] // 15.96
        [TestCase(5.49, 10.59, ExpectedResult = 16.08)] // 16.08
        public double AddNumbersDouble_InputTwoDouble_OutputGetCorrectAdditionExpectedResult(double a, double b)
        {
            //Arrange - intialisation
            Calculator calc = new();

            //Act
            return calc.AddNumbersDouble(a, b);

        }


    }
}
