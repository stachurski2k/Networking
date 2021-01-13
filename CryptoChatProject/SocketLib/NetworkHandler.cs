using System;
namespace SocketLib
{
    public class NetworkHandler
    {
        protected SocketClient mClient;
        protected SocketServer mServer;
        public string name { get; private set; } = "Anonymus";
        string chatId;
        public Event<SetupArgs> SetupDoneEvent;
        public Event EndConnectionEvent;
        public NetworkHandler()
        {
            name = "Anonymus";
        }
        public void SetName(string _name)
        {
            if (string.IsNullOrEmpty(_name))
            {
                name = "Anonymus";
            }
            if (_name.Length > 10)
            {
                name = _name.Substring(0, 9);
            }
            else
            {
                name = _name;
            }
        }
        public bool isServer
        {
            get { return mServer != null; }
        }
        public bool isClient
        {
            get { return mClient != null; }
        }
        protected void OnSetupDone(object sender, SetupArgs e)
        {
            if (SetupDoneEvent != null)
                SetupDoneEvent(this, e);
        }
        public void OnEndConncection(object sender, Args e)
        {
            if (EndConnectionEvent != null)
                EndConnectionEvent();
        }
        #region Server
        public virtual void StartServer(string _key="",int port=23000)
        {
            mServer = new SocketServer();
            mServer.MsgReceivedEvent += OnServerMsgReceived;
            mServer.ClientConnectedEvent += OnServerClientConnected;
            mServer.ClientDisconnectedEvent += OnServerClientDisconnected;
            mServer.StartServerEvent += OnStartServer;
            mServer.StopServerEvent += OnEndConncection;
            chatId = mServer.GetHostName();
            mServer.StartServer();
        }
        protected virtual void OnServerMsgReceived(object sender,MsgReceivedArgs args)
        {
        }
        protected virtual void OnServerClientConnected(object sender, ClientConnectedArgs args)
        {
        }
        protected virtual void OnServerClientDisconnected(object sender, ClientDisconnectedArgs args)
        {
        }
        public virtual void OnStartServer(object sender, StartServerArgs args)
        {

        }
        public virtual void OnStopServer()
        {
            mServer.MsgReceivedEvent -= OnServerMsgReceived;
            mServer.ClientConnectedEvent -= OnServerClientConnected;
            mServer.ClientDisconnectedEvent -= OnServerClientDisconnected;
            mServer.StartServerEvent -= OnStartServer;
        }
        #endregion
        #region Client
        public virtual void StartClient(string hostName)
        {
            mClient = new SocketClient();
            mClient.MsgReceivedEvent += OnClientMsgReceived;
            mClient.SetupDoneEvent += OnSetupDone;
            mClient.ServerDisconnectedEvent += OnEndConncection;
            //mClient.ServerConnectedEvent += OnClientServerConnected;
            mClient.ConnectToServer(hostName);
            chatId = hostName;
        }
        protected virtual void OnClientServerConnected(object sender, ClientConnectingArgs e)
        {
        }
        protected virtual void OnClientMsgReceived(object sender, MsgReceivedArgs args)
        {
        }
        #endregion
        public virtual void Send(string msg)
        {
            if (string.IsNullOrEmpty(msg)) return;
            msg = ConverToMsg(msg);
            if (isServer)
            {
                mServer.SendToAll(msg);
            }
            else if(isClient)
            {
                mClient.Send(msg);
            }
        }
        protected virtual string ConverToMsg(string msg)
        {
            return $"{name} : {msg}";
        }
        public void StopAll()
        {
            if (mServer != null)
            {
                mServer.StopServer();
                mServer = null;
            }
            if (mClient != null)
            {
                mClient.StopClient();
                mClient = null;
            }
        }
        public string GetChatId()
        {
            return chatId;
        }
    }
}
