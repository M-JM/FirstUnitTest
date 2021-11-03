using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FirstUnitTest
{

  
    public class CustomerXUnitTest
    {
        private Customer customer;

        public CustomerXUnitTest()
        {
            customer = new Customer();
        }


        [Fact]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {

            string fullName = customer.GreetAndCombineName("Jimmy", "Miels");


            Assert.Equal("Hello, Jimmy Miels", customer.GreetMessage);
            Assert.Contains("jimmy Miels".ToLower(), customer.GreetMessage.ToLower());
            Assert.StartsWith("Hello,", customer.GreetMessage);
            Assert.EndsWith("Miels", customer.GreetMessage);

            Assert.Matches("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", customer.GreetMessage);
        }

        [Fact]

        public void GreetMessage_NotGreeted_ReturnsNull()
        {


            Assert.Null(customer.GreetMessage);

        }
        [Fact]
        public void GreetMessage_NotGreeted_ReturnsIsNotNull()
        {


            customer.GreetAndCombineName("Jimmy", "Miels");

            Assert.NotNull(customer.GreetMessage);

        }

        [Fact]
        public void DiscountCheckerDefaultCustomer_RetunsDiscountInRange()
        {
            int result = customer.Discount;

            Assert.InRange(result, 10, 25);

        }

        [Fact]
        public void GreetMessage_GreetedwithoutLastName_ReturnNotNull()
        {
            customer.GreetAndCombineName("ben", "");

            Assert.NotNull(customer.GreetMessage);
            Assert.False(string.IsNullOrEmpty(customer.GreetMessage));

        }

        [Fact]
        public void GreetChecker_EmptyFirstName_ThrowsExpection()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GreetAndCombineName("", "jimmy"));
            Assert.Equal("Empty First Name", exceptionDetails.Message);

            Assert.Throws<ArgumentException>(() => customer.GreetAndCombineName("", "jimmy"));

        }


        [Fact]
        public void CustomerType_CreateCustomerWithLessthan100POrder_returnBasicCustomer()
        {
            customer.OrderTotal = 10;

            var result = customer.GetCustomerDetails();

            Assert.IsType<BasisCustomer>(result);

        }


        [Fact]
        public void CustomerType_CreateCustomerWithmorethan100POrder_returnPlatinumCustomer()
        {
            customer.OrderTotal = 110;

            var result = customer.GetCustomerDetails();

            Assert.IsType<PlatinumCustomer>(result);

        }


    }

}