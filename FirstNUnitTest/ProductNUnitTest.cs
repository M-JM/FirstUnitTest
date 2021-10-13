﻿using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstUnitTest
{
   [TestFixture]
   public class ProductNUnitTest
    {

        [Test]
        public void GetProductPrice_PlatinumCustomer_ReturnPriceWith20Discount()
        {
            Product product = new() { Price = 50 };
            var result = product.GetPrice(new Customer { IsPlatinum = true });

            Assert.That(result, Is.EqualTo(40));

        }

        [Test]
        public void GetProductPriceMoqAbuse_PlatinumCustomer_ReturnPriceWith20Discount()
        {
            var customer = new Mock<ICustomer>();
            customer.Setup(u => u.IsPlatinum).Returns(true);

            Product product = new() { Price = 50 };
            var result = product.GetPrice(customer.Object);

            Assert.That(result, Is.EqualTo(40));

        }

    }
}
