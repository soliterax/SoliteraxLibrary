using SoliteraxLibrary.Soliterax_Hub.Exceptions;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
namespace SoliteraxLibrary.Soliterax_Hub
{
    public class Client : SoliteraxLibrary.Soliterax_Hub.Events
    {

        Socket _clientSocket;
        string Server_IP;
        int Port;
        byte[] _buffer;
        bool isConnected;
        ClientMessageReceiveEvent messageEvent;
        int ReconnectWait;

        public void Connect(string Server_IP, int Port, byte[] _buffer)
        {
            this.Server_IP = Server_IP;
            this.Port = Port;
            this._buffer = _buffer;
        }

        public void Connect(int Port)
        {
            Server_IP = "127.0.0.1";
            this.Port = Port;
            _buffer = new byte[4096];
        }

        public void Connect(string Server_IP)
        {
            this.Server_IP = Server_IP;
            Port = 100;
            _buffer = new byte[4096];
        }

        public void Connect(string Server_IP, int Port)
        {
            this.Server_IP = Server_IP;
            this.Port = Port;
            _buffer = new byte[4096];
        }

        public void Connect(string Server_IP, byte[] _buffer)
        {
            this.Server_IP = Server_IP;
            Port = 100;
            this._buffer = _buffer;
        }

        public void Connect(int Port, byte[] _buffer)
        {
            Server_IP = "127.0.0.1";
            this.Port = Port;
            this._buffer = _buffer;
        }

        public void ConnectServer()
        {
            Thread th = new Thread(new ThreadStart(ServerConnectLoop));
            th.Name = "Server_Connect_Thread";
            th.IsBackground = true;
            th.Start();
        }

        public void sendText(string text)
        {
            if (_clientSocket.Connected)
            {
                byte[] bufferData = Encoding.ASCII.GetBytes(text);
                _clientSocket.Send(bufferData);
            }
        }

        public void Send(Object packet)
        {

        }

        public delegate void ClientMessageReceiveEvent(string result);

        private void ServerMessageCallBack(IAsyncResult ar)
        {
            try
            {
                Socket socket = (Socket)ar.AsyncState;

                int received = socket.EndReceive(ar);

                byte[] dataBuffer = new byte[received];

                Array.Copy(_buffer, dataBuffer, received);

                if (messageEvent == null)
                    throw new ArgumentNullException();

                messageEvent.DynamicInvoke(Encoding.ASCII.GetString(dataBuffer).ToString());

                //ClientListenerEvent(Encoding.ASCII.GetString(dataBuffer).ToString());
            }
            catch (ClientListenerException e)
            {
                throw new ClientListenerException(e.Message);
            }

            _clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ServerMessageCallBack), _clientSocket);

        }

        private void ServerConnectLoop()
        {
            while (true)
            {
                if (!_clientSocket.Connected)
                {
                    int attempts = 0;
                    try
                    {
                        attempts++;
                        _clientSocket.Connect(Server_IP, Port);
                        _clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ServerMessageCallBack), _clientSocket);
                        isConnected = true;
                    }
                    catch (SocketException)
                    {
                        isConnected = false;
                    }
                }
                Thread.Sleep(ReconnectWait * 1000);
            }
        }


        //Getter And Setter

        public int getPort()
        {
            return Port;
        }

        public string getServer_IP()
        {
            return Server_IP;
        }

        public byte[] getBuffer()
        {
            return _buffer;
        }

        public bool getConnection()
        {
            return isConnected;
        }

        public Socket getSocket()
        {
            return _clientSocket;
        }

        public void setPort(int Port)
        {
            this.Port = Port;
        }

        public void setServer_IP(string Server_IP)
        {
            this.Server_IP = Server_IP;
        }

        public void setBuffer(byte[] _buffer)
        {
            this._buffer = _buffer;
        }

        public void setConnection(bool isConnected)
        {
            this.isConnected = isConnected;
        }

        public void setSocket(Socket _clientSocket)
        {
            this._clientSocket = _clientSocket;
        }

        public void setClientReceiveEvent(ClientMessageReceiveEvent eventMethod)
        {
            messageEvent = eventMethod;
        }

        public void SetReconnectTime(int reconnectTime)
        {
            ReconnectWait = reconnectTime;
        }
    }
}
