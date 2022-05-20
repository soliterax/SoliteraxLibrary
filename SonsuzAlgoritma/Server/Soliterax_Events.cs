using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SonsuzAlgoritma.Server
{
    public abstract class Soliterax_Events
    {

        public abstract void ServerCloseEvent(String reason);
        public abstract void ServerListenerEvent(String text);
        public abstract void ServerStreamEvent(String ip, String value);
        public abstract void ServerTimeoutEvent(String reason);
        public abstract void ServerPluginLoadEvent(Soliterax_Plugin name);
        public abstract void ServerPluginUnloadEvent(Soliterax_Plugin name);


        public abstract void ServerNotResponseEvent();
        public abstract void ClientListenerEvent(String text);
        public abstract void ClientStreamEvent(String text);
    }
}
