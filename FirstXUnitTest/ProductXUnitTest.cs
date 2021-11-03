using Moq;
using Xunit;

namespace FirstUnitTest
{

   public class ProductXUnitTest
    {

        [Fact]
        public void GetProductPrice_PlatinumCustomer_ReturnPriceWith20Discount()
        {
            Product product = new() { Price = 50 };
            var result = product.GetPrice(new Customer { IsPlatinum = true });

            Assert.Equal(40, result);

        }

        // It is not always good to use mOq where it is not needed. If customer did not have an interface there is no need
        // to create a entirely new interface for the sake of using Moq.

        [Fact]
        public void GetProductPriceMoqAbuse_PlatinumCustomer_ReturnPriceWith20Discount()
        {
            var customer = new Mock<ICustomer>();
            customer.Setup(u => u.IsPlatinum).Returns(true);

            Product product = new() { Price = 50 };
            var result = product.GetPrice(customer.Object);

            Assert.Equal(40, result);

        }

    }
}
