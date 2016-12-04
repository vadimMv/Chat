using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using MessageType;
using System.Threading;
namespace Server_Side_Logic
{
    /// <summary>
    /// delegate type for event realization
    /// </summary>
    /// <param name="m"></param>
    /// <param name="list"></param>
    public delegate void CathMessage(Message m, Dictionary<TcpClient, string> list);
    /// <summary>
    /// delegate type for client-registration realization
    /// <paramref name="nickName"/>
    /// </summary>
    public delegate void ClientsRegistrator(string nickName, bool connected);
    /// <summary>
    /// Class implemmentation server- side logic
    /// </summary>
    public sealed class Server : IDisposable
    {
        private TcpListener tcplistener;  // tcp obj instance
        Dictionary<TcpClient, string> clientTable = new Dictionary<TcpClient, string>(); // ductionary table regist news cleints
        public event CathMessage messagesHandler = null; //evnt message handler
        public event ClientsRegistrator clientRegistor = null; //event client registor
        /// <summary>
        /// public method initialize  tcp_listener  and start listening
        /// </summary>
        public void ServerStart(string ipAdd, int port)
        {
            IPAddress ip = IPAddress.Parse(ipAdd);
            tcplistener = new TcpListener(ip, port);
            ListenForClients();
        }

        /// <summary>
        /// start listen
        /// </summary>
        private void ListenForClients()
        {
            tcplistener.Start();

            while (true)
            {
                // create separted thread per each client
                TcpClient client = tcplistener.AcceptTcpClient();
                clientTable.Add(client, "");
                Thread clientThread = new Thread(HandleClientComm);
                clientThread.Start(client);

            }
        }
        /// <summary>
        /// event message handling rasing
        /// </summary>
        /// <param name="m">message object</param>
        private void OnMessageHandle(Message m)
        {
            if (messagesHandler != null)
                messagesHandler(m, clientTable);  // event invoke
        }
        /// <summary>
        /// client register unregister event raise
        /// </summary>
        /// <param name="nickName"> client name</param>
        /// <param name="connected">connection or disconnection </param>
        private void OnClientRegister(string nickName, bool connected)
        {

            if (clientRegistor != null)
                clientRegistor(nickName, connected);  //event invoke
        }
        /// <summary>
        /// client communication methods 
        /// </summary>
        /// <param name="tcpClient"></param>
        private void HandleClientComm(object tcpClient)
        {
            bool run = true;
            TcpClient client = (TcpClient)tcpClient;   //get client
            string Name = "";
            BinaryFormatter formater = new BinaryFormatter();    // formater
            NetworkStream stream = null;                         //  stream
            do
            {
                if (!run)
                    break;
                stream = client.GetStream();                       //   get stream
                Message m = (Message)formater.Deserialize(stream); //recieving messege from connected client          
                if (Name != m.Name)
                {
                    Name = m.Name;
                    clientTable[client] = m.Name;       // adding new client to list
                    OnClientRegister(m.Name, true);      //  detection new connection
                }

                if (m.Text == "All_CONN")
                {
                    m.PrivateList.Clear();
                    foreach (KeyValuePair<TcpClient, string> clientAndName in clientTable)
                    {
                        // copying clients name to list(using private list for sending connected cliets names)
                        m.PrivateList.Add(clientAndName.Value);
                    }
                }
                if (m.Text == "DISCONNECT")
                {
                    Name = "";
                    clientTable.Remove(client);        //  removing client from lidt
                    OnClientRegister(m.Name, false);    //  detection disconnection
                    run = false;
                }
                OnMessageHandle(m);                   //  detection new message

            } while (run);

        }

        /// <summary>
        /// closing connection & stream
        /// </summary>
        public void Dispose()
        {

          
        }
    }
}
