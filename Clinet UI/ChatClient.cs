using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Client_Side_Logic;
using System.IO;

namespace Clinet_UI
{
    /// <summary>
    /// chat interface class
    /// </summary>
    public partial class ChatClient : Form
    {
        Client cl;                          //  client logic object instance
        Connecting win;                     //  connectingToChat windows instance
        PrivateList winWishList;            //  privateList windows instance 
        string UserName = "";               //  user name def 
        string UserColor = "Black";         //  default font color
        List<string> PrivetWishList;        //  private list obj 
        public List<string> ConnectionList;        //  list all current connection 
        string fileName = "";               //  image location file

        string IPaddress = "127.0.0.1";    // ip
        int port = 4001;                   // port
        /// <summary>
        /// form c'tor
        /// </summary>
        public ChatClient()
        {
            InitializeComponent();
            label1.Text = UserName;
            PrivetWishList = new List<string>();
            ConnectionList = new List<string>();
            win = new Connecting();
            win.FormClosed += Win_FormClosed;   // connectig win close event register
            this.FormClosing += ChatClient_FormClosing;  // chat windows closing event register
        }

        /// <summary>
        /// run before closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChatClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UserName != "")
            {

                try
                {
                    // sending disconnecting message
                    cl.SendMessage(new MessageType.Message(UserName, "DISCONNECT", win.Color));

                }
                finally
                {
                    // disposing connection
                    cl.Dispose();
                }

            }
        }

        private void singleChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //// open connectig windows and registration to close event
            win = new Connecting();
            win.Show();
            win.FormClosed += Win_FormClosed;
        }



        private void Win_FormClosed(object sender, FormClosedEventArgs e)
        {
            /// send messages to server with registration data
            if (win.NickName != "" && win.NickName != null)
            {

                UserName = win.NickName;
                UserColor = win.Color;
                label1.Text = UserName;

                try
                {
                    cl.SendMessage(new MessageType.Message(UserName, "SERVER", win.Color));
                }
                catch (Exception exc)
                {

                    MessageBox.Show("Connection was lose...  " + exc.Data);
                    Close();
                }

            }
        }

        private void choiceImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserName != "")
            {

                /// chose image location 
                DialogResult dialogResult = openFileDialog1.ShowDialog();
                if (dialogResult != DialogResult.Cancel)
                {
                    fileName = openFileDialog1.FileName;
                    richTextChat.SelectionColor = Color.FromName("Black");
                    richTextChat.AppendText("Image :" + fileName + "\n" + "was selected  check private list & click sending..." + "\n");
                }
            }
            else
                MessageBox.Show("You must be connected!");
        }

        private void privateListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ///// open private list win 
            winWishList = new PrivateList();
            winWishList.Show();
            winWishList.FormClosed += WinWishList_FormClosed;
            ////  search all connected clients 
            if (UserName != "")
            {
                try
                {
                    cl.SendMessage(new MessageType.Message(UserName, "All_CONN", "Black"));
                }
                catch (Exception exc)
                {

                    MessageBox.Show("Connection was lose...  " + exc.Data);
                    Close();
                }
            }
            else
            {

                MessageBox.Show("You must be connected!");
            }
        }


        private void WinWishList_FormClosed(object sender, FormClosedEventArgs e)
        {
            /// saving private list
            PrivetWishList = winWishList.wishList;
        }

        private void ChatClient_Load(object sender, EventArgs e)
        {
            /// start server listen after 
            cl = new Client();
            cl.recived += Cl_recived;   // message recived event registration

            try
            {
                cl.ClientStartListen(IPaddress, port);
            }
            catch (Exception exc)
            {

                MessageBox.Show("Connection was lose...  " + exc.Data);
                Close();
            }
        }
        /// <summary>
        /// message displaying method
        /// </summary>
        /// <param name="m"></param>
        private void Cl_recived(MessageType.Message m)
        {
            if (m.Text == "SERVER")   // registration message
            {
                if (richTextChat.InvokeRequired)
                {

                    richTextChat.Invoke(new Action(() =>
                    {
                        richTextChat.SelectionColor = Color.FromName("Black");
                        richTextChat.AppendText("Server said:\n " + m.Name + ", has connected!!! " + " \n");

                    }));
                }
                else if (!richTextChat.IsDisposed)
                {
                    richTextChat.SelectionColor = Color.FromName("Black");
                    richTextChat.AppendText("Server said:\n " + m.Name + ", has connected!!! " + " \n");
                }
            }
            else if (UserName != "" && m.Text == "DISCONNECT")  // disconnection message
            {
                if (richTextChat.InvokeRequired)
                {
                    richTextChat.Invoke(new Action(() =>
                           {
                               richTextChat.SelectionColor = Color.FromName("Black");
                               richTextChat.AppendText("Server said:\n " + m.Name + ", has disconnected!!! " + " \n");

                           }));
                }
                else if (!richTextChat.IsDisposed)
                {
                    richTextChat.SelectionColor = Color.FromName("Black");
                    richTextChat.AppendText("Server said:\n " + m.Name + ", has disconnected!!! " + " \n");
                }
            }
            else if (UserName != "" && m.Text == "All_CONN")
            {
                ConnectionList.Clear();
                ConnectionList = m.PrivateList;
                //  search all connected clients 
                // use private list for sending all connection
                if (winWishList != null)
                    winWishList.connList = ConnectionList;
            }
            else if (UserName != "" && m.Text != "SERVER" && m.Text != "All_CONN")   //  text message
            {
                if (richTextChat.InvokeRequired)
                {
                    richTextChat.Invoke(new Action(() =>
                           {
                               richTextChat.SelectionColor = Color.FromName(m.Color);
                               if (m.Text == "")
                                   richTextChat.AppendText(m.ToString() + " Image ." + " \n");
                               else
                                   richTextChat.AppendText(m.ToString());
                               richTextChat.ScrollToCaret();
                           }));
                }
                else if (!richTextChat.IsDisposed)
                {

                    richTextChat.SelectionColor = Color.FromName(m.Color);
                    if (m.Text == "")
                        richTextChat.AppendText(m.ToString() + " Image ." + " \n");
                    else
                        richTextChat.AppendText(m.ToString());
                    richTextChat.ScrollToCaret();
                }
            }

            if (m.ImageArray != null)        //  image message
            {
                if (pictureBox.InvokeRequired)
                {

                    pictureBox.Invoke(new Action(() =>
                    {

                        pictureBox.Image = byteArrayToImage(m.ImageArray);
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    }));
                }
                else if (!pictureBox.IsDisposed)
                {

                    pictureBox.Image = byteArrayToImage(m.ImageArray);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }

            }


        }
        /// <summary>
        /// sending message by click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendButton_Click(object sender, EventArgs e)
        {

            if (UserName != "")
            {    //  message obj creting
                MessageType.Message message = new MessageType.Message(UserName, messagBox.Text, UserColor);
                // checking private list
                if (checkPrivateList.Checked && PrivetWishList.Capacity >= 1)
                {
                    message.PrivateList = PrivetWishList;
                    checkPrivateList.Checked = false;
                    if (fileName != "")  // checking image location
                    {
                   /// sending image over private list
                        // converting image stream to bytes array
                        byte[] arr = imageByteArray(Image.FromFile(fileName));
                        message.ImageArray = arr;  //saving image bytes array in message

                    }
                    else
                    {
                        message.ImageArray = null;
                    }

                }
                else {

                    //sending image to all clients
                    if (fileName != "")  // checking image location
                    {
                        // converting image stream to bytes array
                        byte[] arr = imageByteArray(Image.FromFile(fileName));
                        message.ImageArray = arr;  //saving image bytes array in message

                    }
                    else
                    {
                        message.ImageArray = null;
                    }

                }
                try
                {

                    cl.SendMessage(message);    //sending
                    fileName = "";
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Connection was lose...  " + exc.Data);
                    Close();
                }
                messagBox.Clear();          //clearing screen
            }
            else
            {
                if (win.IsDisposed)
                {
                    win = new Connecting();
                    win.FormClosed += Win_FormClosed;   // connectig win close event register
                }
                win.Show();           // show connection screen if user not determinated
            }
        }
        /// <summary>
        /// marking private list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkPrivateList_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPrivateList.Checked == true)
                privateListToolStripMenuItem_Click(sender, e);
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserName != "")
            {
                try
                {
                    // sending disconnecting message
                    cl.SendMessage(new MessageType.Message(UserName, "DISCONNECT", win.Color));
                    // disposing connection
                    cl.Dispose();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Connection was lose...  " + exc.Data);
                    Close();
                }
                UserName = "";
                label1.Text = "";
                Refresh();
                richTextChat.Clear();
                pictureBox.Image = null;
                ChatClient_Load(sender, e);

            }
            else
            {

                MessageBox.Show("You must be connected!");
            }
        }
        /// <summary>
        ///   image to array converting func
        /// </summary>
        /// <param name="imageIn"></param>
        /// <returns></returns>
        #region Image processing help methods

        private byte[] imageByteArray(Image imageIn)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        /// <summary>
        /// bytes array to Image 
        /// </summary>
        /// <param name="ByteArrayIn"></param>
        /// <returns></returns>
        private Image byteArrayToImage(byte[] ByteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(ByteArrayIn))
            {
                Image img = Image.FromStream(ms);
                return img;
            }
        }

        #endregion


    }
}
