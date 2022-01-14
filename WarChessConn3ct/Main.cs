using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarChessConn3ct.IRC;

namespace WarChessConn3ct
{
    public partial class Main : Form
    {
        public static string nickname = "";
        public static string server = "singapore.sg.as.undernet.org"; //singapore.sg.as.undernet.org
        public static string channel = "";
        IrcClient client;
        public static string ServerPass = "";

        public UdpClient c1 = new UdpClient(6073);
        public IPEndPoint recv = new IPEndPoint(0, 0);
        public IPEndPoint send = new IPEndPoint(0, 0);
        public UdpClient c2 = new UdpClient(5555);
        public string ip = "";

        public string join = "";

        public Main()
        {
            InitializeComponent();
            bgrWorker.DoWork += BgrWorker_DoWork;
        }

        private void BgrWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread udp6 = new Thread(() =>
            {
                while (true)
                {
                    var a = c1.Receive(ref recv);
                    client.SendMessage(channel, $"B {Convert.ToBase64String(a)}");
                }
            });
            udp6.Start();

            Thread udp2 = new Thread(() =>
            {
                while (true)
                {
                    var a = c2.Receive(ref send);
                    ip = send.Address.ToString();
                    string base64 = Convert.ToBase64String(a);
                    if(base64.Length > 456)
                    {
                        while(base64.Length > 456)
                        {
                            string basecut = base64.Substring(0, 456);
                            client.SendMessage(channel, $"K {basecut}");
                            base64 = base64.Remove(0, 456);
                        }
                        client.SendMessage(channel, $"F {base64}");
                    }
                    else
                    {
                        client.SendMessage(channel, $"C {base64}");
                    }
                }
            });
            udp2.Start();
        }

        private void DoConnect()
        {
            client = new IrcClient(server, 6667, false, ServerPass);
            AddEvents();
            client.Nick = nickname;
            chatRtb.Clear();
            client.Connect();
        }

        private void AddEvents()
        {
            client.ChannelMessage += client_ChannelMessage;
            client.ExceptionThrown += client_ExceptionThrown;
            client.NoticeMessage += client_NoticeMessage;
            client.OnConnect += client_OnConnect;
            client.PrivateMessage += client_PrivateMessage;
            client.ServerMessage += client_ServerMessage;
            client.UpdateUsers += client_UpdateUsers;
            client.UserJoined += client_UserJoined;
            client.UserLeft += client_UserLeft;
            client.UserNickChange += client_UserNickChange;
        }

        private void AddToChatWindow(string message)
        {
            chatRtb.AppendText(message + "\n");
            chatRtb.ScrollToCaret();
        }

        private void client_UserNickChange(object sender, UserNickChangedEventArgs e)
        {
            listUser.Items[listUser.Items.IndexOf(e.Old)] = e.New;
        }

        private void client_UserLeft(object sender, UserLeftEventArgs e)
        {
            listUser.Items.Remove(e.User);
        }

        private void client_UserJoined(object sender, UserJoinedEventArgs e)
        {
            listUser.Items.Add(e.User);
        }

        private void client_UpdateUsers(object sender, UpdateUsersEventArgs e)
        {
            listUser.Items.Clear();
            listUser.Items.AddRange(e.UserList);
        }

        private void client_PrivateMessage(object sender, PrivateMessageEventArgs e)
        {
            AddToChatWindow("PM FROM " + e.From + ": " + e.Message);
        }

        private void client_ServerMessage(object sender, StringEventArgs e)
        {
            //AddToChatWindow("PM FROM Server: " + e.Result);
        }

        private void client_OnConnect(object sender, EventArgs e)
        {
            contentRtb.Focus();

            if (channel.StartsWith("#"))
                client.JoinChannel(channel.Trim());
            else
                client.JoinChannel("#" + channel.Trim());
            this.Enabled = true;
            if (!bgrWorker.IsBusy)
                bgrWorker.RunWorkerAsync();
        }

        private void client_NoticeMessage(object sender, NoticeMessageEventArgs e)
        {
            AddToChatWindow("NOTICE FROM " + e.From + ": " + e.Message);
        }

        private void client_ExceptionThrown(object sender, ExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }

        private void client_ChannelMessage(object sender, ChannelMessageEventArgs e)
        {
            if (e.Message[0] == 'B' && e.Message[1] == ' ')
            {
                byte[] data = Convert.FromBase64String(e.Message.Remove(0, 2));
                c2.Send(data, data.Length, ip, 6073);
            }
            else if (e.Message[0] == 'K' && e.Message[1] == ' ')
            {
                join += e.Message.Remove(0, 2);
            }
            else if (e.Message[0] == 'F' && e.Message[1] == ' ')
            {
                join += e.Message.Remove(0, 2);
                byte[] data = Convert.FromBase64String(join);
                join = "";
                c2.Send(data, data.Length, ip, 2302);
            }
            else if (e.Message[0] == 'C' && e.Message[1] == ' ')
            {
                byte[] data = Convert.FromBase64String(e.Message.Remove(0, 2));
                c2.Send(data, data.Length, ip, 2302);
            }
            else
                AddToChatWindow(e.From + ": " + e.Message);
        }

        private void contentRtb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (client.Connected && !String.IsNullOrEmpty(contentRtb.Text.Trim()))
            {
                if (channel.StartsWith("#"))
                    client.SendMessage(channel.Trim(), contentRtb.Text.Trim());
                else
                    client.SendMessage("#" + channel.Trim(), contentRtb.Text.Trim());

                AddToChatWindow("Me: " + contentRtb.Text.Trim());
                contentRtb.Clear();
                contentRtb.Focus();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (Login.Show() == DialogResult.OK)
            {
                this.Enabled = false;
                if (!File.Exists("path.txt"))
                {
                    StreamWriter wt = new StreamWriter("path.txt");
                    wt.Close();
                }
                StreamReader file = new StreamReader("path.txt");
                pathGame.Text = file.ReadLine();
                file.Close();
                DoConnect();
            }
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(pathGame.Text.Trim()))
            {
                Process runProc = new Process();
                runProc.StartInfo.FileName = pathGame.Text;
                runProc.StartInfo.WorkingDirectory = Path.GetDirectoryName(pathGame.Text);
                runProc.Start();
            }
            else
            {
                MessageBox.Show("No Game Directory!");
            }
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "WarChess.exe|*.exe";
            if(opf.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(opf.FileName))
                {
                    pathGame.Text = opf.FileName;
                    StreamWriter wt = new StreamWriter("path.txt");
                    wt.WriteLine(opf.FileName);
                    wt.Close();
                }
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
