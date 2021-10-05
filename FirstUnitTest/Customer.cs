using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstUnitTest
{
   public class Customer
    {
        public string GreetMessage{ get; set; }

        public int Discount = 15;

        public string GreetAndCombineName(string firstName, string LastName)
        {
            GreetMessage =  $"Hello, {firstName} {LastName}";

            return GreetMessage;
        }

    }
}
