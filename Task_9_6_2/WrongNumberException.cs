using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_9_6_2
{
    [Serializable]
    class WrongNumberException : Exception
    {
        public WrongNumberException()
        { }

        public WrongNumberException(string message)
            : base(message)
        { }

        public WrongNumberException(string message, Exception innerException)
            : base(message, innerException)
        { }

    }
}
