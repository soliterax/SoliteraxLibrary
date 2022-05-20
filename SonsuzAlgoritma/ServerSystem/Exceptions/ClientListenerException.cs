using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliteraxLibrary.Soliterax_Hub.Exceptions
{
    class ClientListenerException : Exception
    {

        public ClientListenerException()
        {

        }

        public ClientListenerException(string reason)
        {

            Console.WriteLine($"ClientListenerException: {reason}");

        }

    }
}
