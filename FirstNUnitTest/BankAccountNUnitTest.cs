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

        [Test]
        public void BankLogDummy_LogMockStringOutputStr_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "hello";

            logMock.Setup(u => u.LogWithOutputResult(It.IsAny<string>(), out desiredOutput)).Returns(true);
            string result = "";
            Assert.IsTrue(logMock.Object.LogWithOutputResult("Ben", out result));
            Assert.That(result, Is.EqualTo(desiredOutput));
        }

        [Test]
        public void BankLogDummy_LogRefChecker_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            Customer customer = new();
            Customer customerNotUsed = new();


            logMock.Setup(u => u.LogWithRefObj(ref customer)).Returns(true);


            Assert.IsFalse(logMock.Object.LogWithRefObj(ref customerNotUsed));
            Assert.IsTrue(logMock.Object.LogWithRefObj(ref customer));

        }

        [Test]
        public void BankLogDummy_SetAndGetLogTypeAndSeveirtyMock_MockTest()
        {
            var logMock = new Mock<ILogBook>();
            logMock.SetupAllProperties();
            logMock.Setup(u => u.LogSeverity).Returns(10);
            logMock.Setup(u => u.LogType).Returns("warning");


            logMock.Object.LogSeverity = 100;
            Assert.That(logMock.Object.LogSeverity, Is.EqualTo(100));
            Assert.That(logMock.Object.LogType, Is.EqualTo("warning"));

            //callbacks
            string logTemp = "Hello, ";
            logMock.Setup(u => u.LogToDb(It.IsAny<string>()))
                .Returns(true).Callback((string str) => logTemp += str);
            logMock.Object.LogToDb("Ben");
            Assert.That(logTemp, Is.EqualTo("Hello, Ben"));

            //callbacks
            int counter = 5;
            logMock.Setup(u => u.LogToDb(It.IsAny<string>()))
                .Callback(() => counter++)
                .Returns(true)
                .Callback(() => counter++);
            logMock.Object.LogToDb("Ben");
            logMock.Object.LogToDb("Ben");
            Assert.That(counter, Is.EqualTo(9));

        }

        [Test]
        public void BankLogDummy_VerfiyExample()
        {
            var logMock = new Mock<ILogBook>();
            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(100);
            Assert.That(bankAccount.getBalance, Is.EqualTo(100));

            //verfication
            logMock.Verify(u => u.Message(It.IsAny<string>()), Times.Exactly(2));
            logMock.Verify(u => u.Message("Test"), Times.AtLeastOnce);
            logMock.VerifySet(u => u.LogSeverity = 101, Times.Once);
            logMock.VerifyGet(u => u.LogSeverity, Times.Once);
        }

    }

}
