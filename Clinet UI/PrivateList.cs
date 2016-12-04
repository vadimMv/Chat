using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Clinet_UI
{
    /// <summary>
    /// private list windows class
    /// </summary>
    public partial class PrivateList : Form
    {
        private int countTick = 0;

        public List<string> wishList { get; }   // checked list
        public List<string> connList { get; set; }  // all clients


        public PrivateList()
        {
            InitializeComponent();
            wishList = new List<string>();
            connList = new List<string>();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            wishList.Clear();
            clientsWishList.Items.AddRange(connList.ToArray());
            foreach (string item in clientsWishList.CheckedItems)
            {
                wishList.Add(item);   // adding checked items  to list
            }

            Close();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            countTick++;
            if (countTick == 1)
            {
                clientsWishList.Items.Clear();         // remove olds names 
                clientsWishList.Items.AddRange(connList.ToArray()); //add all connected clients name 
            }
        }
    }
}
