using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FirstUnitTest
{
    
    public class FiboXUnitTest
    {


        private Fibo _fibo;

        
      
        [Fact]
        public void Fibo_InputRange1_OutputListwith1Element()
        {
            _fibo = new Fibo
            {
                Range = 1
            };

            List<int> expectedResult = new() { 0 };
            List<int> result = _fibo.GetFiboSeries();

            Assert.Equal(expectedResult, result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            Assert.True(result.SequenceEqual(expectedResult));

        }


        [Fact]
        public void Fibo_InputRange6_OutputListwith1Element()
        {
            _fibo = new Fibo
            {
                Range = 6
            };
            List<int> expectedResult = new() { 0, 1, 1, 2, 3, 5 };
            List<int> result = _fibo.GetFiboSeries();

            Assert.Equal(result,expectedResult);
            Assert.Contains(3, result);
            Assert.NotEmpty(result);
            Assert.DoesNotContain(4, result);
            Assert.Equal(6, result.Count);
        
        }

    }
}
