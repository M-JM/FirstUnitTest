using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstUnitTest
{
    [TestFixture]
    public class BankAccountNUnitTest
    {

        private BankAccount bankAccount;
        [SetUp]

        public void Setup()
        {
           
        }


        [Test]
        public void BankDepositLogBookFake_Add100_ReturnTrueAndBalance100()
        {
            bankAccount = new(new LogBookFake());
            var result = bankAccount.Deposit(100);
            Assert.IsTrue(result);
            Assert.That(bankAccount.getBalance(), Is.EqualTo(100));
        }

        [Test]
        public void BankDeposit_Add100_ReturnTrueAndBalance100()
        {
            var LogMock = new Mock<ILogBook>();
            BankAccount bankAccount = new(LogMock.Object);


            var result = bankAccount.Deposit(100);
            Assert.IsTrue(result);
            Assert.That(bankAccount.getBalance(), Is.EqualTo(100));
        }

    }

}
