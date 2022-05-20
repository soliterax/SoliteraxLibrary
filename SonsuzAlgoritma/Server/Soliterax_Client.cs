using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;

namespace SonsuzAlgoritma
{
    public class Soliterax_Client : SonsuzAlgoritma.Server.Soliterax_Events
    {

        Socket _clientSocket;
        string Server_IP;
        int Port;
        byte[] _buffer;
        bool isConnected;

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
            if(_clientSocket.Connected)
            {
                byte[] bufferData = Encoding.ASCII.GetBytes(text);
                _clientSocket.Send(bufferData);
            }
        }

        private void ServerMessageCallBack(IAsyncResult ar)
        {
            try
            {
                Socket socket = (Socket)ar.AsyncState;

                int received = socket.EndReceive(ar);

                byte[] dataBuffer = new byte[received];

                Array.Copy(_buffer, dataBuffer, received);

                ServerReceiveEvent(Encoding.ASCII.GetString(dataBuffer).ToString());
            } catch(Exception e)
            {
                ServerReceiveFailedEvent(e);
            }

            _clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ServerMessageCallBack), _clientSocket);

        }

        private void ServerConnectLoop()
        {
            while(true)
            {
                if(!_clientSocket.Connected)
                {
                    int attempts = 0;
                    try
                    {
                        attempts++;
                        _clientSocket.Connect(Server_IP, Port);
                        _clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ServerMessageCallBack), _clientSocket);
                        isConnected = true;
                    }
                    catch(SocketException)
                    {
                        isConnected = false;
                    }
                }
                Thread.Sleep(3000);
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
    }
}
