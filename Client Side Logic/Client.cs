using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using MessageType;
using System.Threading;
namespace Client_Side_Logic
{
    /// <summary>
    /// delegate for message detection event
    /// </summary>
    /// <param name="m">message</param>
    public delegate void MessageRecived(Message m);
    public class Client : IDisposable
    {

        private NetworkStream stream;         //  network strem instance
        private BinaryFormatter formater;     //  formater instance
        private TcpClient client;             //  tcp client instance
        public event MessageRecived recived;  //  message recive event
        public bool run = true;               //  listen loop running 
        /// <summary>
        /// connecting to ip-listener beginnnig listen to new message from server 
        /// </summary>
        public void ClientStartListen(string ipa, int port)     
        {
            IPAddress ip = IPAddress.Parse(ipa);
            client = new TcpClient();
            formater = new BinaryFormatter();
            client.Connect(ip, port);
            stream = client.GetStream();
            //   listing for new messages in separeted thread 
            new Thread(() =>
            {
                do
                {
                    Message m1 =null;
                    lock (formater)
                    {
                        try
                        {
                            m1 = (Message)formater.Deserialize(stream);  // get new message
                        }
                        catch (Exception)
                        {

                          
                        }
                        if (!run)
                        {
                            client.Close();
                            stream.Close();
                            break;
                        }
                    }

                    if (m1 != null)
                    {

                        OnMessageRecived(m1);   // message event raise

                    }
                } while (run);
            }).Start();

        }
        private void OnMessageRecived(Message m)
        {
            if (recived != null)
                recived(m);     // raise event
        }
        /// <summary>
        /// sending message to server
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(Message message)
        {
            formater.Serialize(stream, message); ///sending messege to server

        }

        /// <summary>
        /// closing connection & stream
        /// </summary>
        public void Dispose()
        {
            run = false;

        }
    }
}
