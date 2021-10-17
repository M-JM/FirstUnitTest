using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstUnitTest
{
    public class LogBook : ILogBook
    {
        public int LogSeverity { get; set; }
        public string LogType { get; set; }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public bool LogToDb(string message)
        {
            Console.WriteLine(message);
            return true;
        }

        public bool LogBalanceAfterWithdrawal(int balanceAfterWithdrawal)
        {
            if(balanceAfterWithdrawal >= 0)
            {
                Console.WriteLine("Succes");
                return true;
            }
            Console.WriteLine("Fails");
            return false;
        }

        public string MessageWithReturnStr(string message)
        {
            Console.WriteLine(message);

            return message;
        }

        public bool LogWithOutputResult(string str, out string outputStr)
        {
            outputStr = "Hello " + str;
            return true;
        }

        public bool LogWithRefObj(ref Customer customer)
        {
            return true;
        }


    }


    // When Unit testing we do not want to make are tests with real dependencies.
    // This would fall under the category of Integrations Test thus mixin two seperate types of tests.
    // To avoid this problem we create a fake implementation of LogBook with void methods -> null object
    //public class LogBookFake : ILogBook
    //{
    //    public void Message(string message)
    //    {
    //    }
    //}

}
