using System;

namespace SoliteraxLibrary.Soliterax_Hub.Exceptions
{
    class ServerStreamException : Exception
    {

        public ServerStreamException()
        {

        }

        public ServerStreamException(string reason)
        {
            Console.WriteLine("ServerStreamException : " + reason);
        }

    }
}
