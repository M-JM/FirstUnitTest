//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace FirstUnitTest
//{

//    public class BankAccountXUnitTest
//    {

//        private BankAccount bankAccount;
     
    

//        //[Test]
//        //public void BankDepositLogBookFake_Add100_ReturnTrueAndBalance100()
//        //{
//        //    bankAccount = new(new LogBookFake());
//        //    var result = bankAccount.Deposit(100);
//        //    Assert.IsTrue(result);
//        //    Assert.That(bankAccount.getBalance(), Is.EqualTo(100));
//        //}

//        [Fact]
//        public void BankDeposit_Add100_ReturnTrueAndBalance100()
//        {
//            var LogMock = new Mock<ILogBook>();
//            BankAccount bankAccount = new(LogMock.Object);


//            var result = bankAccount.Deposit(100);
//            Assert.True(result);
//            Assert.Equal(100, bankAccount.getBalance());
//        }


//        [Fact]
//        public void BankWithdraw_Withdraw100With200Blance_ReturnsTrue()
//        {
//            var LogMock = new Mock<ILogBook>();
//            LogMock.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true);
//            LogMock.Setup(u => u.LogBalanceAfterWithdrawal(It.IsAny<int>())).Returns(true);

//            BankAccount bankAccount = new(LogMock.Object);
//            bankAccount.Deposit(200);
//            var result = bankAccount.Withdraw(100);
//            Assert.True(result);
//        }

//        [Theory]
//        [InlineData(200,100)]
//        [InlineData(400,200)]
//        [InlineData(350,150)]
//        public void BankWithdraw_WithdrawXWithYBlance_ReturnsTrue(int balance, int withdraw)
//        {
//            var LogMock = new Mock<ILogBook>();
//            LogMock.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true);
//            LogMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x>0))).Returns(true);

//            BankAccount bankAccount = new(LogMock.Object);
//            bankAccount.Deposit(balance);
//            var result = bankAccount.Withdraw(withdraw);
//            Assert.True(result);
//        }

//        [Fact]
//        public void BankWithdraw_Withdraw300With200Blance_ReturnsFalse()
//        {
//            var LogMock = new Mock<ILogBook>();
//            LogMock.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true);
//            LogMock.Setup(u => u.LogBalanceAfterWithdrawal(It.IsAny<int>())).Returns(false);
//            LogMock.Setup(u => u.LogBalanceAfterWithdrawal(It.IsInRange<int>(int.MinValue,-1,Moq.Range.Inclusive))).Returns(false);

//            BankAccount bankAccount = new(LogMock.Object);
//            bankAccount.Deposit(200);
//            var result = bankAccount.Withdraw(300);
//            Assert.False(result);
//        }


//        [Fact]
//        public void BankLogDummy_LogMockString_ReturnTrue()
//        {
//            var LogMock = new Mock<ILogBook>();
//            string desiredOutput = "Hello";

//            LogMock.Setup(u => u.MessageWithReturnStr(It.IsAny<string>())).Returns((string str) => str);

//            Assert.Equal(desiredOutput,LogMock.Object.MessageWithReturnStr("Hello"));


//        }

//        [Fact]
//        public void BankLogDummy_LogMockStringOutputStr_ReturnTrue()
//        {
//            var logMock = new Mock<ILogBook>();
//            string desiredOutput = "hello";

//            logMock.Setup(u => u.LogWithOutputResult(It.IsAny<string>(), out desiredOutput)).Returns(true);
//            string result = "";
//            Assert.True(logMock.Object.LogWithOutputResult("Ben", out result));
//            Assert.Equal(desiredOutput,result);
//        }

//        [Fact]
//        public void BankLogDummy_LogRefChecker_ReturnTrue()
//        {
//            var logMock = new Mock<ILogBook>();
//            Customer customer = new();
//            Customer customerNotUsed = new();


//            logMock.Setup(u => u.LogWithRefObj(ref customer)).Returns(true);


//            Assert.False(logMock.Object.LogWithRefObj(ref customerNotUsed));
//            Assert.True(logMock.Object.LogWithRefObj(ref customer));

//        }

//        [Fact]
//        public void BankLogDummy_SetAndGetLogTypeAndSeveirtyMock_MockTest()
//        {
//            var logMock = new Mock<ILogBook>();
//            logMock.SetupAllProperties();
//            logMock.Setup(u => u.LogSeverity).Returns(10);
//            logMock.Setup(u => u.LogType).Returns("warning");


//            logMock.Object.LogSeverity = 100;
//            Assert.Equal(100, logMock.Object.LogSeverity);
//            Assert.Equal("warning", logMock.Object.LogType);

//            //callbacks
//            string logTemp = "Hello, ";
//            logMock.Setup(u => u.LogToDb(It.IsAny<string>()))
//                .Returns(true).Callback((string str) => logTemp += str);
//            logMock.Object.LogToDb("Ben");
//            Assert.Equal("Hello, Ben", logTemp);

//            //callbacks
//            int counter = 5;
//            logMock.Setup(u => u.LogToDb(It.IsAny<string>()))
//                .Callback(() => counter++)
//                .Returns(true)
//                .Callback(() => counter++);
//            logMock.Object.LogToDb("Ben");
//            logMock.Object.LogToDb("Ben");
//            Assert.Equal(9, counter);

//        }

//        [Fact]
//        public void BankLogDummy_VerfiyExample()
//        {
//            var logMock = new Mock<ILogBook>();
//            BankAccount bankAccount = new(logMock.Object);
//            bankAccount.Deposit(100);
//            Assert.Equal(100,bankAccount.getBalance());

//            //verfication
//            logMock.Verify(u => u.Message(It.IsAny<string>()), Times.Exactly(2));
//            logMock.Verify(u => u.Message("Test"), Times.AtLeastOnce);
//            logMock.VerifySet(u => u.LogSeverity = 101, Times.Once);
//            logMock.VerifyGet(u => u.LogSeverity, Times.Once);
//        }

//    }

//}
