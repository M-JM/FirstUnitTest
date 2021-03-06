using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstUnitTest
{
    public class Customer : ICustomer
    {
        public string GreetMessage { get; set; }

        public int OrderTotal { get; set; }

        public int Discount { get; set; }

        public bool IsPlatinum { get; set; }

        public Customer()
        {
            Discount = 15;
            IsPlatinum = false;
        }

        public string GreetAndCombineName(string firstName, string LastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("Empty First Name");
            }

            GreetMessage = $"Hello, {firstName} {LastName}";

            return GreetMessage;
        }

        public CustomerType GetCustomerDetails()
        {
            if (OrderTotal < 100)
            {
                return new BasisCustomer();
            }
            else
            {
                return new PlatinumCustomer();
            }
        }

    }


    public class CustomerType { }

    public class BasisCustomer : CustomerType { }

    public class PlatinumCustomer : CustomerType { }
}
