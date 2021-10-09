using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstUnitTest
{

   [TestFixture]
   public class CustomerNUnitTest
    {
        private Customer customer;

        [SetUp]
        public void Setup()
        {
            customer = new Customer();
        }


        [Test]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
    
            string fullName = customer.GreetAndCombineName("Jimmy", "Miels");


            Assert.Multiple(() =>
            {
                Assert.That(fullName, Is.EqualTo("Hello, Jimmy Miels"));
                Assert.AreEqual(fullName, "Hello, Jimmy Miels");
                Assert.That(fullName, Does.StartWith("hello").IgnoreCase);
                Assert.That(fullName, Does.Contain(","));
                Assert.That(fullName, Does.EndWith("Miels"));
                Assert.That(fullName, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
            });
        }

        [Test]

        public void GreetMessage_NotGreeted_ReturnsNull()
        {
 

            Assert.IsNull(customer.GreetMessage);

        }
        [Test]
        public void GreetMessage_NotGreeted_ReturnsIsNotNull()
        {
         
            
            customer.GreetAndCombineName("Jimmy", "Miels");

            Assert.IsNotNull(customer.GreetMessage);

        }

        [Test]
        public void DiscountCheckerDefaultCustomer_RetunsDiscountInRange()
        {
            int result = customer.Discount;

            Assert.That(result, Is.InRange(15,20));

    }

        [Test]
        public void GreetMessage_GreetedwithoutLastName_ReturnNotNull()
        {
            customer.GreetAndCombineName("ben", "");

            Assert.IsNotNull(customer.GreetMessage);

        }

        [Test]
        public void GreetChecker_EmptyFirstName_ThrowsExpection()
        {
            customer.GreetAndCombineName("ben", "");

            var expectionsdetails = Assert.Throws<ArgumentException>(() => customer.GreetAndCombineName("", "jimmy"));

            Assert.AreEqual("Empty First Name", expectionsdetails.Message);
            Assert.That(() => 
            customer.GreetAndCombineName("", "jimmy"),
            Throws.ArgumentException.With.Message.EqualTo("Empty First Name"));


            Assert.Throws<ArgumentException>(() => customer.GreetAndCombineName("", "jimmy"));

            Assert.That(() =>
            customer.GreetAndCombineName("", "jimmy"),
            Throws.ArgumentException);
        }

    }

}