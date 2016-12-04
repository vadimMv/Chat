using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
namespace Chat_Vadim_Mukovozov_326960382
{
    public partial class Server : Form
    {
        /// <summary>
        /// server ui 
        /// </summary>
        ServerSettings serverSettWin = null;        // server settings window instance
        string ipAddress = "127.0.0.1";             // ip address
        int port = 4001;                            // port 

        public Server()
        {
            InitializeComponent();
        }


        private void Server_Load(object sender, EventArgs e)
        {       ///starting server logic code
            new Thread(() =>
            {

                Server_Side_Logic.Server newListner;
                newListner = new Server_Side_Logic.Server();
                newListner.messagesHandler += NewListner_messagesHandler;
                newListner.clientRegistor += NewListner_clientRegistor;
                newListner.ServerStart(ipAddress, port);

            }).Start();
        }
        /// <summary>
        /// connection & disconnection handling
        /// </summary>
        /// <param name="nickName">client name </param>
        /// <param name="connected">true & false</param>
        private void NewListner_clientRegistor(string nickName, bool connected)
        {
            try
            {
                if (connected)
                {
                    // update current users list
                    EventLogList.Invoke(new Action(() =>
                       {
                           EventLogList.Items.Add(new ListViewItem(new string[] { nickName, "connected", DateTime.Now.ToString() }));
                       }));

                }
                else
                {
                    ListViewItem listViewItem = null;

                    // delete from current list
                    EventLogList.Invoke(new Action(() =>
                    {
                        listViewItem = FindListViewItemForName(nickName);
                        if (listViewItem != null)
                        {
                            EventLogList.Items.Remove(listViewItem);
                        }
                    }));
                    // history list update
                    HistoryListView.Invoke(new Action(() =>
                    {

                        HistoryListView.Items.Add(new ListViewItem(new string[] { nickName, listViewItem.SubItems[2].Text, DateTime.Now.ToString() }));
                    }));
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// finding item by string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private ListViewItem FindListViewItemForName(string s)
        {
            foreach (ListViewItem lvi in EventLogList.Items)
            {
                if (StringComparer.OrdinalIgnoreCase.Compare(lvi.Text, s) == 0)
                {
                    return lvi;
                }
            }

            return null;
        }/// <summary>
         /// recieving messages and sending over clients 
         /// </summary>
         /// <param name="m">message</param>
         /// <param name="clients">clients list</param>
        private static void NewListner_messagesHandler(MessageType.Message m, Dictionary<TcpClient, string> clients)
        {
            BinaryFormatter formater = new BinaryFormatter();
            NetworkStream stream = null;

            foreach (KeyValuePair<TcpClient, string> clientAndName in clients.ToList())
            {
                if (m.PrivateList.Count == 1)   // private list empty send to all
                {
                    stream = clientAndName.Key.GetStream();
                    formater.Serialize(stream, m);
                }
                else
                {
                    // sending by private list

                    string Name = m.PrivateList.Find(name => name == clientAndName.Value);

                    if (Name != "" && Name != null)
                    {
                        stream = clientAndName.Key.GetStream();
                        formater.Serialize(stream, m);
                    }

                }
            }
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serverSettWin = new ServerSettings();   // settings window obj 
            serverSettWin.FormClosing += ServerSettWin_FormClosing;
            // open server settings win
            serverSettWin.Show();
        }
        /// <summary>
        /// restarting server 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ServerSettWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            ipAddress = serverSettWin.IPAdress;
            port = serverSettWin.Port;
            if (ipAddress != null && port != 0)
            {
                DialogResult dialogResult = MessageBox.Show("Server will be restarted, please close all connections... ", "Restart", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Refresh();
                    //         Server_Load(null, null);

                }
            }
        }


    }
}
