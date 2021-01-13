using System;
using System.Collections.Generic;
using System.Text;
using SocketLib;
using CryptoLib;
namespace CryptoChat
{
    class CryptoNetworkHandler:NetworkHandler
    {
        Crypter crypter;
        const string cmdStr = "$cmd";
        public Event<Args> DrawDataEvent;
        
        public override void StartClient(string hostName)
        {
            crypter = new Crypter();
            base.StartClient(hostName);
        }
        protected override void OnClientMsgReceived(object sender, MsgReceivedArgs args)
        {
            string msg = args.msg;
            if (msg.StartsWith(cmdStr))
            {
                msg = msg.Replace(cmdStr, string.Empty);
                crypter.SetKey(msg);
            }
            else
            {
                args.SetMsg(DecryptMsg(msg));
            }
            DrawDataEvent(this, args);
        }
        protected override void OnClientServerConnected(object sender, ClientConnectingArgs e)
        {
            DrawDataEvent(sender, e);
        }
        #region Server
        protected override void OnServerClientConnected(object sender, ClientConnectedArgs args)
        {
            var toExclude = new List<Client>();
            toExclude.Add(args.newClient);
            string msg = "New person Joined chat!";
            DrawDataEvent(msg, new MsgReceivedArgs(msg));
            mServer.SendTo(cmdStr + crypter.GetKey(), args.newClient);
            mServer.SendToAll(EncryptMsg(msg), toExclude);
        }
        protected override void OnServerClientDisconnected(object sender, ClientDisconnectedArgs args)
        {
            var toExclude = new List<Client>();
            toExclude.Add(args.client);
            string msg = "Person Left Chat!";
            DrawDataEvent(msg, new MsgReceivedArgs(msg));
            mServer.SendToAll(EncryptMsg(msg), toExclude);
        }
        protected override void OnServerMsgReceived(object sender, MsgReceivedArgs args)
        {
            //To do decrypt msg
            var toExclude = new List<Client>();
            toExclude.Add(args.sender);
            string msg = args.msg;
            args.SetMsg(DecryptMsg(msg));
            DrawDataEvent(sender, args);
            mServer.SendToAll(msg, toExclude);
        }
        public override void OnStartServer(object sender, StartServerArgs args)
        {
            OnSetupDone(sender, new SetupArgs(true));
            DrawDataEvent(this, args);
        }
        public override void OnStopServer()
        {
            base.OnStopServer();
        }
        public override void StartServer(string _key, int port = 23000)
        {
            crypter = new Crypter(_key);
            base.StartServer(_key, port);
        }
        #endregion
        public override void Send(string msg)
        {
            if (string.IsNullOrEmpty(msg)) return;
            msg = ConverToMsg(msg);
            if (isServer)
            {
                mServer.SendToAll(EncryptMsg(msg));
            }
            else if (isClient)
            {
                mClient.Send(EncryptMsg(msg));
            }
            DrawDataEvent(this, new MsgReceivedArgs(msg));
        }
        byte[] EncryptMsg(string msg)
        {
            return crypter.Encrypt(msg);
        }
        string DecryptMsg(string msg)
        {
            return crypter.Decrypt(msg);
        }
    }
}
