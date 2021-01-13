using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
namespace SocketLib
{
    public class Args {}
    public delegate void Event<Args>(object sender, Args e);
    public delegate void Event();
    public class MsgReceivedArgs : Args
    {
        public Client sender { get; private set; }
        public string msg { get; private set; }
        public MsgReceivedArgs(Client _sender, string _msg)
        {
            sender = _sender;
            msg = _msg;
        }
        public void SetMsg(string _msg)
        {
            msg = _msg;
        }
        public MsgReceivedArgs(string _msg)
        {
            msg = _msg;
        }
        public override string ToString()
        {
            return msg;
        }
    }
    public class ClientConnectedArgs : Args
    {
        public Client newClient { get; private set; }
        public ClientConnectedArgs(Client _newClient)
        {
            newClient = _newClient;
        }
    }
    public class ClientDisconnectedArgs : Args
    {
        public Client client { get; private set; }
        public ClientDisconnectedArgs(Client _Client)
        {
            client = _Client;
        }
    }
    public class StartServerArgs : Args
    {
        public IPAddress ip { get; private set; }
        public int port { get; private set; }
        public StartServerArgs(IPAddress _ip, int _port)
        {
            ip = _ip;
            port = _port;
        }
        public override string ToString()
        {
            return $"Starting chat at : {ip} : {port}";
        }
    }
    public class StopServerArgs : Args
    {
        public int numOfClients{ get; private set; }
        public StopServerArgs(int _n)
        {
            numOfClients = _n;
        }
    }
    public class ClientConnectingArgs : Args
    {
        public bool result { get; private set; }
        public IPEndPoint remoteEndPoint { get; private set; }
        public ClientConnectingArgs(bool _result,IPEndPoint ep)
        {
            result = _result;
            remoteEndPoint = ep; 
        }
        public override string ToString()
        {
            return $"Connecting : {result}";
        }
    }
    public class DisconnectedArgs: Args
    {
        public IPEndPoint endPoint { get; private set; }
        public DisconnectedArgs(IPEndPoint ep)
        {
            endPoint = ep;
        }
    }
    public class SetupArgs: Args
    {
        public bool resoult { get; private set; }
        public SetupArgs(bool _resoult)
        {
            resoult = _resoult;
        }
    }
}
