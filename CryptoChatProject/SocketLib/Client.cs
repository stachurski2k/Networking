using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
namespace SocketLib
{
    public class Client
    {
        Socket socket;
        public string ID { get; private set; }
        NetworkStream ns;
        public ManualResetEvent connectDone =
       new ManualResetEvent(false);
        public Client(Socket _socket,string _id)
        {
            socket = _socket;
            ns = new NetworkStream(socket);
            ID = _id;
        }
        public Client()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public void Start(IPEndPoint endPoint)
        {
            socket.BeginConnect(endPoint, new AsyncCallback(OnConnected), socket);
            connectDone.WaitOne();
        }
        void OnConnected(IAsyncResult result)
        {
            try
            {
                socket = (Socket)result.AsyncState;
                
                socket.EndConnect(result);
                ns = new NetworkStream(socket);
                connectDone.Set();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public NetworkStream GetStream()
        {
            return ns;
        }
        public IPEndPoint GetRemoteEndPoint()
        {
            return (IPEndPoint)socket.RemoteEndPoint;
        }
        public bool isConnected()
        {
            return socket.Connected;
        }
        public void Close()
        {
            socket.Close();
        }
        public override string ToString()
        {
            return ID.ToString();
        }
    }
}
