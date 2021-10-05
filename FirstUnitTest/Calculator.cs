using System;
using System.Collections.Generic;

namespace FirstUnitTest
{
    public class Calculator
    {

        public List<int> Numbers = new();

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


        public List<int> GetOddRange(int min, int max)
        {
            Numbers.Clear();
            for(int i = min; i <= max; i++)
            {
                if (i % 2 != 0)
                {
                    Numbers.Add(i);
                }
            }
            return Numbers;

        }
    
    }



}
