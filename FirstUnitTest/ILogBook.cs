using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstUnitTest
{
   public interface ILogBook
    {
        void Message(string message);

        bool LogToDb(string message);

        bool LogBalanceAfterWithdrawal(int balanceAfterWithdrawal);

        string MessageWithReturnStr(string message);

        bool LogWithOutputResult(string str, out string outputStr);

        bool LogWithRefObj(ref Customer customer);

        public int LogSeverity { get; set; }
        public string LogType { get; set; }
    }
}
