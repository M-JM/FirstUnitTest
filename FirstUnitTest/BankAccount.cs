using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstUnitTest
{
 public class BankAccount
    {
        private readonly ILogBook _logBook;
        public int Balance { get; set; }

        public BankAccount(ILogBook logBook)
        {
            _logBook = logBook;
            Balance = 0;
        }

        public bool Deposit(int amount)
        {
            _logBook.Message("Deposit invoked");
            Balance += amount;
            return true;
        }

        public bool Withdraw(int amount)
        {
            if(amount <= Balance)
            {
                _logBook.Message("Withdraw invoked");
                Balance -= amount;
                return true;
            }
            _logBook.Message("Withdraw invoked but failed due to insufficient balance");
            return false;
        }

        public int getBalance()
        {
            return Balance;
        }

    }
}
