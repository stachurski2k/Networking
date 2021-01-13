using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
namespace SocketLib
{
    public class SocketServer
    {
        IPAddress iPAddress;
        int port;
        IPEndPoint endPoint;
        Socket listener;
        List<Client> clients;
        bool isRunning = false;
        public int bufferSize;
        public Event<MsgReceivedArgs> MsgReceivedEvent;
        public Event<ClientConnectedArgs> ClientConnectedEvent;
        public Event<ClientDisconnectedArgs> ClientDisconnectedEvent;
        public Event<StartServerArgs> StartServerEvent;
        public Event<StopServerArgs> StopServerEvent;
        public SocketServer(int _bufferSize=1024)
        {
            clients = new List<Client>();
            bufferSize = _bufferSize;
        }
        public string GetHostName()
        {
            return Dns.GetHostName();
        }
        #region UnnecessaryMethodsForChildren
        public virtual void OnServerMsgRecived(Client sender, string msg)
        {
            if (MsgReceivedEvent != null && isRunning)
                MsgReceivedEvent(this, new MsgReceivedArgs(sender, msg));
        }
        public virtual void OnClientConnected(Client sender)
        {
            if(ClientConnectedEvent!=null && isRunning)
            ClientConnectedEvent(this, new ClientConnectedArgs(sender));
        }
        public virtual void OnClientDisconnected(Client sender)
        {
            if (ClientDisconnectedEvent != null&&isRunning)
                ClientDisconnectedEvent(this, new ClientDisconnectedArgs(sender));
        }
        public virtual void OnStartServer(IPAddress ip, int port)
        {
            if(StartServerEvent!=null)
            StartServerEvent(this, new StartServerArgs(ip, port));
        }
        public virtual void OnStopServer(int numOfClients)
        {
            if (StopServerEvent != null)
                StopServerEvent(this, new StopServerArgs(numOfClients));
        }
        #endregion
        #region MainServerStuff
        public async Task StartServer(IPAddress _ip=null, int _port=23000)
        {
            if (isRunning) return;
            isRunning = true;

            iPAddress = (_ip == null) ? IPAddress.Any : _ip;
            port = (_port <=0) ? 23000 : _port;

            if (listener == null) listener = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            endPoint = new IPEndPoint(iPAddress, port);
            listener.Bind(endPoint);
            OnStartServer(iPAddress, port);
            try
            {
                listener.Listen(100);
                while (isRunning)
                {
                    Client newClient =new Client( await listener.AcceptAsync(),clients.Count.ToString());
                    HandleClientConnected(newClient);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void StopServer()
        {
            if (!isRunning && listener == null) return;
            try
            {
                OnStopServer(clients.Count);
                listener.Close();
                foreach (var client in clients)
                {
                    client.Close();
                }
                clients.Clear();
            }
            catch (Exception)
            {
                throw;
            }
            isRunning = false;
        }
        #endregion
        #region HandlingClient
        async Task HandleClientConnected(Client client)
        {
            clients.Add(client);
            OnClientConnected(client);
            NetworkStream ns = client.GetStream();
            try
            {
                byte[] buff = new byte[bufferSize];
                int recivedBytes = 0;
                while (isRunning)
                {
                    recivedBytes = await ns.ReadAsync(buff,0,buff.Length);
                    if (recivedBytes<=0)
                    {
                        DisconnectClient(client);
                        break;
                    }
                    OnServerMsgRecived(client, Encoding.ASCII.GetString(buff).Replace("\0",string.Empty));
                    Array.Clear(buff, 0, buff.Length);
                }
            }
            catch (Exception)
            {
                DisconnectClient(client);
                throw;
            }
        }
        void DisconnectClient(Client client)
        {
            OnClientDisconnected(client);
            clients.Remove(client);
            try
            {
                client.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task SendToAll(byte[] buff, List<Client> toExclude = null)
        {
            foreach (var client in clients)
            {
                if (toExclude != null && toExclude.Contains(client))
                {
                    continue;
                }
                await SendTo(buff, client);
            }
        }
        public async Task SendToAll(string msg, List<Client> toExclude=null)
        {
            byte[] buff = Encoding.ASCII.GetBytes(msg);
            await SendToAll(buff, toExclude);
        }
        public async Task SendTo(string msg, Client client)
        {
          
            byte[] buff = Encoding.ASCII.GetBytes(msg);
            await SendTo(buff, client);
         
        }
        public async Task SendTo(byte[] buff, Client client)
        {
            try
            {
                await client.GetStream().WriteAsync(buff, 0, buff.Length);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
