using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_9_6_1
{
    [Serializable]          // Интересно, почему он должен быть сериализуемым?
    public class MyOwnException : Exception
    {
            public MyOwnException()
            { }

            public MyOwnException(string message)
                : base(message)
            { }

            public MyOwnException(string message, Exception innerException)
                : base(message, innerException)
            { }
    }
}
