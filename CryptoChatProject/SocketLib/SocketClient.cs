using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
namespace SocketLib
{
    public class SocketClient
    {
        IPAddress serverIPAddress;
        int serverPort;
        IPEndPoint serverEndPoint;
        Client client;
        bool isRunning = false;
        public Event<ClientConnectingArgs> ServerConnectedEvent;
        public Event<DisconnectedArgs> ServerDisconnectedEvent;
        public Event<MsgReceivedArgs> MsgReceivedEvent;
        public Event<SetupArgs> SetupDoneEvent;

        public virtual void OnServerConnected(ClientConnectingArgs args)
        {
            if(ServerConnectedEvent!=null)
            ServerConnectedEvent(this,args);
        }
        public virtual void OnServerDisconnected(DisconnectedArgs args)
        {
            if(ServerDisconnectedEvent!=null)
            ServerDisconnectedEvent(this, args);
        }
        public virtual void OnMsgReceived(MsgReceivedArgs args)
        {
            if(MsgReceivedEvent!=null)
            MsgReceivedEvent(this, args);
        }
        public virtual void OnSetupDone(SetupArgs e)
        {
            if (SetupDoneEvent != null)
                SetupDoneEvent(this, e);
        }
        public static IPAddress ResolveHostNameToIP(string name)
        {
            //To do 
            try
            {
                IPAddress[] ips = Dns.GetHostAddresses(name);
                foreach (var ip in ips)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return ip;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }
        public void ConnectToServer(string name)
        {
            IPAddress ip=null;
            try
            {
              ip=  ResolveHostNameToIP(name);
            }
            catch (Exception)
            {
                OnSetupDone(new SetupArgs(false));
            }
            finally
            {
                ConnectToServer(ip);
            }
        }
        public void ConnectToServer(IPAddress ip=null, int port=23000)
        {
            if (isRunning) return;
            isRunning = true;
            if (ip == null && serverIPAddress == null) return;
            else if (ip != null) serverIPAddress = ip;
            serverPort =(port<=0)?23000:port;
            serverEndPoint = new IPEndPoint(serverIPAddress, serverPort);

            if (client == null)
            {
                client = new Client();
            }
            try
            {
                client.Start(serverEndPoint);
                StartListening();
            }
            catch (Exception)
            {
                throw;
            }
            OnSetupDone(new SetupArgs(client.isConnected()));
        }
        void StartListening(object sender, ClientConnectingArgs args)
        {
            OnServerConnected(args);
            if (!args.result)
            {
                return;
            }
            StartListening();
        }
        async Task StartListening()
        {
            try
            {
                byte[] buff = new byte[1024];
                int bytesReceived;
                NetworkStream ns = client.GetStream();
                while (isRunning)
                {
                    bytesReceived = await ns.ReadAsync(buff, 0, buff.Length);
                    if (bytesReceived == 0)
                    {
                        Disconnect();
                        break;
                    }
                    string msg = Encoding.ASCII.GetString(buff).Replace("\0", string.Empty);
                    OnMsgReceived(new MsgReceivedArgs(msg));
                    Array.Clear(buff, 0, buff.Length);
                }
            }
            catch (Exception)
            {
                Disconnect();
            }
        }
        public async Task Send(string msg)
        {
            if (string.IsNullOrEmpty(msg)) return;
            byte[] buff = Encoding.ASCII.GetBytes(msg);
            await Send(buff);
        }
        public async Task Send(byte[] buff)
        {
            if (client == null || !client.isConnected()) return;
            NetworkStream ns = client.GetStream();
            await ns.WriteAsync(buff, 0, buff.Length);
        }
        void Disconnect()
        {
            if (client == null) return;
            try
            {
                OnServerDisconnected(new DisconnectedArgs(client.GetRemoteEndPoint()));
            }
            catch (Exception)
            {
                OnServerDisconnected(new DisconnectedArgs(null));
            }
            client.Close();
        }
        public void StopClient()
        {
            Disconnect();
        }

    }
}
