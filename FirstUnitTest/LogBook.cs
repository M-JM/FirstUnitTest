﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstUnitTest
{
    public class LogBook : ILogBook
    {
        public void Message(string message)
        {
            Console.WriteLine(message);
        }
    }


    // When Unit testing we do not want to make are tests with real dependencies.
    // This would fall under the category of Integrations Test thus mixin two seperate types of tests.
    // To avoid this problem we create a fake implementation of LogBook with void methods -> null object
    public class LogBookFake : ILogBook
    {
        public void Message(string message)
        {
        }
    }

}
