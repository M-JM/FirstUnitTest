using System.Collections.Generic;
using Xunit;

namespace FirstUnitTest
{

    public class CalculatorXUnitTest
    {
        [Fact]
        public void AddNumbers_InputTwoInt_OutputGetCorrectAddition()
        {
            //Arrange - intialisation
            Calculator calc = new();

            //Act
            int result = calc.AddNumbers(10, 20);

            //Assert
            Assert.Equal(30, result);
        }

        [Fact]

        public void IsOddNumber_InputOneInt_OutputGetTrue()
        {
            //Arrange - intialisation
            Calculator calc = new();

            //Act
            bool result = calc.IsOddNumber(3);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void IsOddNumber_InputOneInt_OutputGetFalse()
        {
            //Arrange - intialisation
            Calculator calc = new();

            //Act
            bool result = calc.IsOddNumber(2);

            //Assert
            Assert.False(result);
        
        }


        [Theory]
        [InlineData(10)]
        [InlineData(12)]
        [InlineData(14)]
        [InlineData(16)]
        public void IsOddNumber_InputOneInt_multipleCases_OutputGetFalse(int a)
        {
            //Arrange - intialisation
            Calculator calc = new();

            //Act
            bool result = calc.IsOddNumber(a);

            //Assert
            Assert.False(result);
      
        }
        [Theory]
        [InlineData(10, false)]
        [InlineData(11, true)]

        public void IsOddChecker_InputNumber_ReturnTrueIfOdd_ReturnFalseIfEven(int a, bool expectedResult)
        {
            //Arrange - intialisation
            Calculator calc = new();
            var result = calc.IsOddNumber(a);
            //Act
            Assert.Equal(expectedResult, result);

            // the assert is being done with the expected return type of the method being equal to the second param
            // given in the Testcase
        }

        [Theory]
        [InlineData(5.4, 10.5)] // 15.9
        [InlineData(5.43, 10.53)] // 15.96
        [InlineData(5.49, 10.59)] // 16.08
        public void AddNumbersDouble_InputTwoDouble_OutputGetCorrectAddition(double a, double b)
        {
            //Arrange - intialisation
            Calculator calc = new();

            //Act
            double result = calc.AddNumbersDouble(a, b);

            //Assert
            Assert.Equal(15.9, result, 0);
        }

        [Theory]
        [InlineData(5.40, 10.50, 15.90)] // 15.9
        [InlineData(5.43, 10.53, 15.96)] // 15.96
        [InlineData(5.49, 10.59, 16.08)] // 16.08
        public void AddNumbersDouble_InputTwoDouble_OutputGetCorrectAdditionExpectedResult(double a, double b, double expectedResult)
        {
            //Arrange - intialisation
            Calculator calc = new();
            var result = calc.AddNumbersDouble(a, b);
            //Act
            Assert.Equal(expectedResult, result);

        }

        [Fact]
        public void Oddranger_InputMinAndMaxRange_ReturnsValidOddNumberRange()
        {
            Calculator calc = new();
            
            List<int> expectedOddRange = new() { 5, 7, 9 };

            List<int> result = calc.GetOddRange(5, 10);

            
            Assert.Equal(expectedOddRange, result);
            Assert.Contains(7, result);
         

    }
}
}
