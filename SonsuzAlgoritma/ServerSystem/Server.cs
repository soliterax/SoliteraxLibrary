using SoliteraxLibrary.Soliterax_Hub.Exceptions;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SoliteraxLibrary
{
    public class Server : SoliteraxLibrary.Soliterax_Hub.Events
    {

        int Port;
        string Server_IP;
        byte[] _buffer;

        Socket _ServerSocket;
        /// <summary>
        /// Connect to locked veriables
        /// </summary>
        /// <param name="Server_IP">IP Adress</param>
        /// <param name="Port">Port</param>
        /// <param name="_buffer">Buffer Size</param>
        public void Connect(string Server_IP, int Port, byte[] _buffer)
        {
            this.Server_IP = Server_IP;
            this.Port = Port;
            this._buffer = _buffer;
        }
        /// <summary>
        /// Connect to locked Port but ip: 127.0.0.1 and Buffer Size: 4096 default
        /// </summary>
        /// <param name="Port"></param>
        public void Connect(int Port)
        {
            Server_IP = "127.0.0.1";
            this.Port = Port;
            _buffer = new byte[4096];
        }
        /// <summary>
        /// Connect to locked ip but Port: 100 and Buffer Size: 4096 is default
        /// </summary>
        /// <param name="Server_IP"></param>
        public void Connect(string Server_IP)
        {
            this.Server_IP = Server_IP;
            Port = 100;
            _buffer = new byte[4096];
        }
        /// <summary>
        /// Connect to locked ip and port but Buffer Size is default 4096
        /// </summary>
        /// <param name="Server_IP"></param>
        /// <param name="Port"></param>
        public void Connect(string Server_IP, int Port)
        {
            this.Server_IP = Server_IP;
            this.Port = Port;
            _buffer = new byte[4096];
        }
        /// <summary>
        /// Connect to locked ip and Buffer Size but Port is default 100
        /// </summary>
        /// <param name="Server_IP">IP Adress</param>
        /// <param name="_buffer">Buffer Size</param>
        public void Connect(string Server_IP, byte[] _buffer)
        {
            this.Server_IP = Server_IP;
            Port = 100;
            this._buffer = _buffer;
        }
        /// <summary>
        /// Connect to default ip and locked port and Buffer Size
        /// </summary>
        /// <param name="Port">Port</param>
        /// <param name="_buffer">Buffer Size</param>
        public void Connect(int Port, byte[] _buffer)
        {
            Server_IP = "127.0.0.1";
            this.Port = Port;
            this._buffer = _buffer;
        }
        /// <summary>
        /// Shutdown to Server
        /// </summary>
        public void Disconnect()
        {
            _ServerSocket.Disconnect(false);
            ServerCloseEvent("Disconnect");
        }

        public void StartConnection(AddressFamily family, SocketType type, ProtocolType protocol)
        {
            _ServerSocket = new Socket(family, type, protocol);
            _ServerSocket.Bind(new IPEndPoint(IPAddress.Parse(Server_IP), Port));
            _ServerSocket.Listen(1);
            _ServerSocket.BeginAccept(new AsyncCallback(AcceptConnection), null);
        }
        /// <summary>
        /// if Client push the connect wish this method accept
        /// Please don't change this method codes
        /// </summary>
        /// <param name="ar"></param>
        private void AcceptConnection(IAsyncResult ar)
        {

            Socket socket = _ServerSocket.EndAccept(ar);

            ServerStreamEvent(socket, "login");

            socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ClientReceiveCallBack), socket);

        }
        /// <summary>
        /// if Client send the message this method get and return to ClientMessage method 
        /// please not change this method codes
        /// </summary>
        /// <param name="ar"></param>
        private void ClientReceiveCallBack(IAsyncResult ar)
        {

            Socket socket = (Socket)ar.AsyncState;

            if (socket.Connected)
            {
                int received;
                try
                {
                    received = socket.EndReceive(ar);
                }
                catch (ServerStreamException e)
                {

                    throw new ServerStreamException(e.Message);

                }

                if (received != 0)
                {
                    byte[] dataBuıffer = new byte[received];

                    Array.Copy(_buffer, dataBuıffer, received);

                    ServerListenerEvent(Encoding.ASCII.GetString(dataBuıffer));
                }
            }
            else
            {
                ServerStreamEvent(socket, "exit");
                return;
            }
            socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ClientReceiveCallBack), socket);
        }
        /// <summary>
        /// this method send the message to target Client
        /// </summary>
        /// <param name="socket">Client veriable</param>
        /// <param name="text">Message</param>
        public void sendText(Socket socket, string text)
        {
            byte[] data = Encoding.ASCII.GetBytes(text);
            socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallBack), socket);
        }

        /// <summary>
        /// Send message to target Client
        /// </summary>
        /// <param name="ar"></param>
        private void SendCallBack(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            socket.EndSend(ar);
        }



        /// <summary>
        /// Server get port
        /// </summary>
        /// <returns>return port</returns>
        public int getPort()
        {
            return Port;
        }

        /// <summary>
        /// Server get IP Adress
        /// </summary>
        /// <returns>return IP Adress</returns>
        public string getServer_IP()
        {
            return Server_IP;
        }

        /// <summary>
        /// get the Server bufferSize
        /// </summary>
        /// <returns>return bufferSize</returns>
        public byte[] getBuffer()
        {
            return _buffer;
        }
        /// <summary>
        /// Server set Port
        /// </summary>
        /// <param name="Port">Port Number</param>
        public void setPort(int Port)
        {
            this.Port = Port;
        }

        /// <summary>
        /// Server set IP Adress
        /// </summary>
        /// <param name="Server_IP">Server IP Adress</param>
        public void setServer_IP(string Server_IP)
        {
            this.Server_IP = Server_IP;
        }

        /// <summary>
        /// Server set Buffer Size
        /// </summary>
        /// <param name="_buffer">Buffer Size default 4096</param>
        public void setBuffer(byte[] _buffer)
        {
            this._buffer = _buffer;
        }

    }
}
