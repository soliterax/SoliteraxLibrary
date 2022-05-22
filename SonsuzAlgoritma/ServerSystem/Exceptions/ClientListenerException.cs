using System;

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
