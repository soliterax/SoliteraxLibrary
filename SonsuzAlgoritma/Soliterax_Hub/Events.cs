using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace SoliteraxLibrary.Soliterax_Hub
{
    public abstract class Events
    {

        public void ServerCloseEvent(String reason) { }
        public void ServerListenerEvent(String text) { }
        public void ServerStreamEvent(Socket ip, String value) { }
        public void ServerTimeoutEvent(String reason) { }
        public void ServerPluginLoadEvent(Soliterax_Plugin name) { }
        public void ServerPluginUnloadEvent(Soliterax_Plugin name) { }


        public void ServerNotResponseEvent() { }
        public void ClientListenerEvent(String text) { }
        public void ClientStreamEvent(String text) { }
    }
}
