using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstUnitTest
{
   public class Product
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int Price { get; set; }

        public double GetPrice(Customer customer)
        {
            if (customer.IsPlatinum)
            {
                return Price * .8;
            }
            return Price;
        }

        public double GetPrice(ICustomer customer)
        {
            if (customer.IsPlatinum)
            {
                return Price * .8;
            }
            return Price;
        }


    }

}
