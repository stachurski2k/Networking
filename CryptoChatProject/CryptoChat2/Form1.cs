using System;
using System.Drawing;
using System.Windows.Forms;
using SocketLib;

namespace CryptoChat
{
    public partial class MainForm : Form
    {
        CryptoNetworkHandler networkHandler;
        bool wantsServer = false;
        public MainForm()
        {
            InitializeComponent();
            networkHandler = new CryptoNetworkHandler();
            networkHandler.DrawDataEvent += OnDrawData;
            networkHandler.SetupDoneEvent += OnSetupDone;
            networkHandler.EndConnectionEvent += OnEndConnection;
            EnableMainPage(true);
            EnableChatPage(false);
            EnableLogPage(false);
        }
        void Send(string msg)
        {
            networkHandler.Send(SendTextBox.Text);
            SendTextBox.Text = string.Empty;
        }
        private void OnDrawData(object sender, Args e)
        {
            Label newData = new Label();
            newData.AutoSize = true;
            newData.Font = new Font("Showcard Gothic", 12, FontStyle.Bold);
            newData.Text = e.ToString();
            FlowChatPanel.Controls.Add(newData);
        }

        private void OnExit(object sender, FormClosingEventArgs e)
        {
            networkHandler.StopAll();
        }
        void EnableMainPage(bool enabled)
        {
            MainPage.Visible = enabled;
            StartChatBtn.Visible = true;
        }
        void EnableChatPage(bool enabled)
        {
            ChatPage.Visible = enabled;
        }
        void EnableLogPage(bool enabled)
        {
            LogPage.Visible = enabled;
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            Send(SendTextBox.Text);
        }

        private void SendTextBox_TextChanged(object sender, EventArgs e)
        {
            if (SendTextBox.Text.EndsWith("\n"))
            {
                SendTextBox.Text.Replace("\n", "");
                Send(SendTextBox.Text);
            }
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            networkHandler.SetName(NameTextBox.Text);
            if (wantsServer)
            {
                networkHandler.StartServer(ChatIdTextBox.Text);
            }
            else
            {
                if (string.IsNullOrEmpty(ChatIdTextBox.Text))
                {
                    return;
                }
                networkHandler.StartClient(ChatIdTextBox.Text);
            }
        }

        void OnSetupDone(object sender, SetupArgs e)
        {
            if (e.resoult)
            {
                EnableChatPage(true);
                EnableLogPage(false);
                CurrentChatIdTextBox.Text = $"Chat id : {networkHandler.GetChatId()}";
            }
        }
        private void StartChatBtn_Click_1(object sender, EventArgs e)
        {
            EnableMainPage(false);
            EnableLogPage(true);
            wantsServer = true;
            EnterIdOrKeyLabel.Text = "Create secret key";
        }

        private void JoinChatBtn_Click(object sender, EventArgs e)
        {
            EnableMainPage(false);
            EnableLogPage(true);
            wantsServer = false;
            EnterIdOrKeyLabel.Text = "Enter chat id";
        }

        private void LeaveBtn_Click(object sender, EventArgs e)
        {
            networkHandler.StopAll();
            for (int i = 0; i < FlowChatPanel.Controls.Count; i++)
            {
                Control c = FlowChatPanel.Controls[i];
                FlowChatPanel.Controls.Remove(c);
                c.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EnableChatPage(false);
            EnableLogPage(false);
            EnableMainPage(true);
        }
        void OnEndConnection()
        {
            EnableChatPage(false);
            EnableLogPage(false);
            EnableMainPage(true);
        }
    }
}
