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


        //[Test]
        //public void BankDepositLogBookFake_Add100_ReturnTrueAndBalance100()
        //{
        //    bankAccount = new(new LogBookFake());
        //    var result = bankAccount.Deposit(100);
        //    Assert.IsTrue(result);
        //    Assert.That(bankAccount.getBalance(), Is.EqualTo(100));
        //}

        [Test]
        public void BankDeposit_Add100_ReturnTrueAndBalance100()
        {
            var LogMock = new Mock<ILogBook>();
            BankAccount bankAccount = new(LogMock.Object);


            var result = bankAccount.Deposit(100);
            Assert.IsTrue(result);
            Assert.That(bankAccount.getBalance(), Is.EqualTo(100));
        }


        [Test]
        public void BankWithdraw_Withdraw100With200Blance_ReturnsTrue()
        {
            var LogMock = new Mock<ILogBook>();
            LogMock.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true);
            LogMock.Setup(u => u.LogBalanceAfterWithdrawal(It.IsAny<int>())).Returns(true);

            BankAccount bankAccount = new(LogMock.Object);
            bankAccount.Deposit(200);
            var result = bankAccount.Withdraw(100);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase(200,100)]
        [TestCase(400,200)]
        [TestCase(350,150)]
        public void BankWithdraw_WithdrawXWithYBlance_ReturnsTrue(int balance, int withdraw)
        {
            var LogMock = new Mock<ILogBook>();
            LogMock.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true);
            LogMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x>0))).Returns(true);

            BankAccount bankAccount = new(LogMock.Object);
            bankAccount.Deposit(balance);
            var result = bankAccount.Withdraw(withdraw);
            Assert.IsTrue(result);
        }

        [Test]
        public void BankWithdraw_Withdraw300With200Blance_ReturnsFalse()
        {
            var LogMock = new Mock<ILogBook>();
            LogMock.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true);
            LogMock.Setup(u => u.LogBalanceAfterWithdrawal(It.IsAny<int>())).Returns(false);
            LogMock.Setup(u => u.LogBalanceAfterWithdrawal(It.IsInRange<int>(int.MinValue,-1,Moq.Range.Inclusive))).Returns(false);

            BankAccount bankAccount = new(LogMock.Object);
            bankAccount.Deposit(200);
            var result = bankAccount.Withdraw(300);
            Assert.IsFalse(result);
        }


        [Test]
        public void BankLogDummy_LogMockString_ReturnTrue()
        {
            var LogMock = new Mock<ILogBook>();
            string desiredOutput = "Hello";

            LogMock.Setup(u => u.MessageWithReturnStr(It.IsAny<string>())).Returns((string str) => str);

            Assert.That(LogMock.Object.MessageWithReturnStr("Hello"), Is.EqualTo(desiredOutput));


        }


    }

}
