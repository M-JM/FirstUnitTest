using System;

namespace FirstUnitTest
{
    public class Calculator
    {
        public int AddNumbers(int a, int b)
        {
            return a + b;
        }

        public double AddNumbersDouble(double a, double b)
        {
            return Math.Round(a + b, 2);
        }


        public bool IsOddNumber(int a)
        {
            return a % 2 != 0;
        }
    
    }



}
