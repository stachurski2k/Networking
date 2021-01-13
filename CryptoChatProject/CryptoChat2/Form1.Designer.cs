namespace CryptoChat
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ChatPage = new System.Windows.Forms.Panel();
            this.FlowChatPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.LabelPanel = new System.Windows.Forms.Panel();
            this.LeaveBtn = new System.Windows.Forms.Button();
            this.CurrentChatIdTextBox = new System.Windows.Forms.Label();
            this.SendMsgPanel = new System.Windows.Forms.Panel();
            this.SendBtn = new System.Windows.Forms.Button();
            this.SendTextBox = new System.Windows.Forms.TextBox();
            this.LogPage = new System.Windows.Forms.Panel();
            this.ReturnBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.EnterIdOrKeyLabel = new System.Windows.Forms.Label();
            this.ChatIdTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.ConfirmBtn = new System.Windows.Forms.Button();
            this.MainPage = new System.Windows.Forms.Panel();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.JoinChatBtn = new System.Windows.Forms.Button();
            this.StartChatBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ChatPage.SuspendLayout();
            this.LabelPanel.SuspendLayout();
            this.SendMsgPanel.SuspendLayout();
            this.LogPage.SuspendLayout();
            this.MainPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChatPage
            // 
            this.ChatPage.Controls.Add(this.FlowChatPanel);
            this.ChatPage.Controls.Add(this.LabelPanel);
            this.ChatPage.Controls.Add(this.SendMsgPanel);
            this.ChatPage.Location = new System.Drawing.Point(48, 24);
            this.ChatPage.Name = "ChatPage";
            this.ChatPage.Size = new System.Drawing.Size(783, 480);
            this.ChatPage.TabIndex = 5;
            // 
            // FlowChatPanel
            // 
            this.FlowChatPanel.AutoScroll = true;
            this.FlowChatPanel.BackColor = System.Drawing.Color.Silver;
            this.FlowChatPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FlowChatPanel.Location = new System.Drawing.Point(0, 37);
            this.FlowChatPanel.Name = "FlowChatPanel";
            this.FlowChatPanel.Size = new System.Drawing.Size(783, 401);
            this.FlowChatPanel.TabIndex = 6;
            this.FlowChatPanel.WrapContents = false;
            // 
            // LabelPanel
            // 
            this.LabelPanel.Controls.Add(this.LeaveBtn);
            this.LabelPanel.Controls.Add(this.CurrentChatIdTextBox);
            this.LabelPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelPanel.Location = new System.Drawing.Point(0, 0);
            this.LabelPanel.Name = "LabelPanel";
            this.LabelPanel.Size = new System.Drawing.Size(783, 37);
            this.LabelPanel.TabIndex = 4;
            // 
            // LeaveBtn
            // 
            this.LeaveBtn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.LeaveBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeaveBtn.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LeaveBtn.Location = new System.Drawing.Point(0, 0);
            this.LeaveBtn.Name = "LeaveBtn";
            this.LeaveBtn.Size = new System.Drawing.Size(132, 37);
            this.LeaveBtn.TabIndex = 1;
            this.LeaveBtn.Text = "Leave";
            this.LeaveBtn.UseVisualStyleBackColor = false;
            this.LeaveBtn.Click += new System.EventHandler(this.LeaveBtn_Click);
            // 
            // CurrentChatIdTextBox
            // 
            this.CurrentChatIdTextBox.AutoSize = true;
            this.CurrentChatIdTextBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.CurrentChatIdTextBox.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CurrentChatIdTextBox.Location = new System.Drawing.Point(441, 0);
            this.CurrentChatIdTextBox.Name = "CurrentChatIdTextBox";
            this.CurrentChatIdTextBox.Size = new System.Drawing.Size(342, 33);
            this.CurrentChatIdTextBox.TabIndex = 0;
            this.CurrentChatIdTextBox.Text = "Chat id : qwertyuiop";
            this.CurrentChatIdTextBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SendMsgPanel
            // 
            this.SendMsgPanel.Controls.Add(this.SendBtn);
            this.SendMsgPanel.Controls.Add(this.SendTextBox);
            this.SendMsgPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SendMsgPanel.Location = new System.Drawing.Point(0, 438);
            this.SendMsgPanel.Name = "SendMsgPanel";
            this.SendMsgPanel.Size = new System.Drawing.Size(783, 42);
            this.SendMsgPanel.TabIndex = 3;
            // 
            // SendBtn
            // 
            this.SendBtn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SendBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.SendBtn.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SendBtn.Location = new System.Drawing.Point(658, 0);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(125, 42);
            this.SendBtn.TabIndex = 1;
            this.SendBtn.Text = "Send";
            this.SendBtn.UseVisualStyleBackColor = false;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // SendTextBox
            // 
            this.SendTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SendTextBox.Font = new System.Drawing.Font("Sitka Small", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SendTextBox.Location = new System.Drawing.Point(0, 0);
            this.SendTextBox.Multiline = true;
            this.SendTextBox.Name = "SendTextBox";
            this.SendTextBox.PlaceholderText = "Enter message...";
            this.SendTextBox.Size = new System.Drawing.Size(783, 42);
            this.SendTextBox.TabIndex = 0;
            this.SendTextBox.TextChanged += new System.EventHandler(this.SendTextBox_TextChanged);
            // 
            // LogPage
            // 
            this.LogPage.Controls.Add(this.ReturnBtn);
            this.LogPage.Controls.Add(this.label4);
            this.LogPage.Controls.Add(this.EnterIdOrKeyLabel);
            this.LogPage.Controls.Add(this.ChatIdTextBox);
            this.LogPage.Controls.Add(this.NameTextBox);
            this.LogPage.Controls.Add(this.ConfirmBtn);
            this.LogPage.Location = new System.Drawing.Point(62, 24);
            this.LogPage.Name = "LogPage";
            this.LogPage.Size = new System.Drawing.Size(783, 512);
            this.LogPage.TabIndex = 6;
            // 
            // ReturnBtn
            // 
            this.ReturnBtn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ReturnBtn.Font = new System.Drawing.Font("Showcard Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ReturnBtn.Location = new System.Drawing.Point(0, 0);
            this.ReturnBtn.Name = "ReturnBtn";
            this.ReturnBtn.Size = new System.Drawing.Size(150, 44);
            this.ReturnBtn.TabIndex = 7;
            this.ReturnBtn.Text = "Return";
            this.ReturnBtn.UseVisualStyleBackColor = false;
            this.ReturnBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(259, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 33);
            this.label4.TabIndex = 6;
            this.label4.Text = "Enter name";
            // 
            // EnterIdOrKeyLabel
            // 
            this.EnterIdOrKeyLabel.AutoSize = true;
            this.EnterIdOrKeyLabel.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.EnterIdOrKeyLabel.Location = new System.Drawing.Point(253, 85);
            this.EnterIdOrKeyLabel.Name = "EnterIdOrKeyLabel";
            this.EnterIdOrKeyLabel.Size = new System.Drawing.Size(221, 33);
            this.EnterIdOrKeyLabel.TabIndex = 5;
            this.EnterIdOrKeyLabel.Text = "Enter Chat id";
            // 
            // ChatIdTextBox
            // 
            this.ChatIdTextBox.Font = new System.Drawing.Font("Showcard Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ChatIdTextBox.Location = new System.Drawing.Point(253, 137);
            this.ChatIdTextBox.Name = "ChatIdTextBox";
            this.ChatIdTextBox.PlaceholderText = "Chat id";
            this.ChatIdTextBox.Size = new System.Drawing.Size(291, 37);
            this.ChatIdTextBox.TabIndex = 4;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Font = new System.Drawing.Font("Showcard Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NameTextBox.Location = new System.Drawing.Point(253, 231);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.PlaceholderText = "Anonymus";
            this.NameTextBox.Size = new System.Drawing.Size(291, 37);
            this.NameTextBox.TabIndex = 3;
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.Font = new System.Drawing.Font("Showcard Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ConfirmBtn.Location = new System.Drawing.Point(253, 298);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(291, 76);
            this.ConfirmBtn.TabIndex = 2;
            this.ConfirmBtn.Text = "Confirm";
            this.ConfirmBtn.UseVisualStyleBackColor = true;
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click);
            // 
            // MainPage
            // 
            this.MainPage.Controls.Add(this.ExitBtn);
            this.MainPage.Controls.Add(this.JoinChatBtn);
            this.MainPage.Controls.Add(this.StartChatBtn);
            this.MainPage.Controls.Add(this.label1);
            this.MainPage.Location = new System.Drawing.Point(81, 12);
            this.MainPage.Name = "MainPage";
            this.MainPage.Size = new System.Drawing.Size(709, 525);
            this.MainPage.TabIndex = 7;
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ExitBtn.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ExitBtn.Location = new System.Drawing.Point(242, 306);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(257, 46);
            this.ExitBtn.TabIndex = 3;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = false;
            // 
            // JoinChatBtn
            // 
            this.JoinChatBtn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.JoinChatBtn.Font = new System.Drawing.Font("Showcard Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.JoinChatBtn.Location = new System.Drawing.Point(205, 220);
            this.JoinChatBtn.Name = "JoinChatBtn";
            this.JoinChatBtn.Size = new System.Drawing.Size(325, 60);
            this.JoinChatBtn.TabIndex = 2;
            this.JoinChatBtn.Text = "Join Chat";
            this.JoinChatBtn.UseVisualStyleBackColor = false;
            this.JoinChatBtn.Click += new System.EventHandler(this.JoinChatBtn_Click);
            // 
            // StartChatBtn
            // 
            this.StartChatBtn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.StartChatBtn.Font = new System.Drawing.Font("Showcard Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StartChatBtn.Location = new System.Drawing.Point(205, 132);
            this.StartChatBtn.Name = "StartChatBtn";
            this.StartChatBtn.Size = new System.Drawing.Size(326, 66);
            this.StartChatBtn.TabIndex = 1;
            this.StartChatBtn.Text = "Start Chat";
            this.StartChatBtn.UseVisualStyleBackColor = false;
            this.StartChatBtn.Click += new System.EventHandler(this.StartChatBtn_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 32.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(205, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "Crypto Chat";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.ChatPage);
            this.Controls.Add(this.LogPage);
            this.Controls.Add(this.MainPage);
            this.Name = "MainForm";
            this.Text = "Crypto Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnExit);
            this.ChatPage.ResumeLayout(false);
            this.LabelPanel.ResumeLayout(false);
            this.LabelPanel.PerformLayout();
            this.SendMsgPanel.ResumeLayout(false);
            this.SendMsgPanel.PerformLayout();
            this.LogPage.ResumeLayout(false);
            this.LogPage.PerformLayout();
            this.MainPage.ResumeLayout(false);
            this.MainPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel ChatPage;
        private System.Windows.Forms.Panel SendMsgPanel;
        private System.Windows.Forms.Panel LabelPanel;
        private System.Windows.Forms.Label CurrentChatIdTextBox;
        private System.Windows.Forms.FlowLayoutPanel FlowChatPanel;
        private System.Windows.Forms.TextBox SendTextBox;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.Panel LogPage;
        private System.Windows.Forms.TextBox ChatIdTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Button ConfirmBtn;
        private System.Windows.Forms.Panel MainPage;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Button JoinChatBtn;
        private System.Windows.Forms.Button StartChatBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label EnterIdOrKeyLabel;
        private System.Windows.Forms.Button LeaveBtn;
        private System.Windows.Forms.Button ReturnBtn;
    }
}

