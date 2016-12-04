using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
namespace Clinet_UI
{           
    /// <summary>
    /// connecting windows class
    /// </summary>
    public partial class Connecting : Form
    {
        public string IPAdress { get; private set; }   //ip 

        public int Port { get; private set; }      //port

        public string NickName { get; private set; }  //name

        public string Color { get; private set; }   // color

        public Connecting()
        {
            InitializeComponent();
            LoadColors();    // loading colors to colBox
        }
        /// <summary>
        /// fields validation by click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkButton_Click(object sender, EventArgs e)
        {

            if (!ValidateIPv4(IPtext.Text))
                MessageBox.Show("IP address not valid !!!!!!!!!!");

            if (!ValidateNickName(NickTextBox.Text))
                MessageBox.Show("Name not valid !!!!!!!!");

            if (!ValidatePort(PortUpDown.Value.ToString()))
                MessageBox.Show("Port not valid!!!!!!!!");
            if (Color == null)
                MessageBox.Show("Color not selected!!!!");

            if (ValidateIPv4(IPtext.Text) && ValidateNickName(NickTextBox.Text) 
                                          && ValidatePort(PortUpDown.Value.ToString()) && Color!=null) {

                IPAdress = IPtext.Text;
                NickName = NickTextBox.Text;
                Port = (int)PortUpDown.Value;

                Close();
            }
               
          
        }

        #region Validate_Functions


        /// <summary>
        /// ip validation
        /// </summary>
        /// <param name="ipString">ip string</param>
        /// <returns></returns>
        private bool ValidateIPv4(string ipString)
        {

            if (string.IsNullOrWhiteSpace(ipString))
            {

                return false;
            }

            string[] splitValues = ipString.Split('.');

            if (splitValues.Length != 4)
            {
                return false;
            }

            byte tempForParsing;

            return splitValues.All(r => byte.TryParse(r, out tempForParsing));
        }
        /// <summary>
        /// port validation
        /// </summary>
        /// <param name="portString">port string</param>
        /// <returns></returns>
        private bool ValidatePort(string portString)
        {

            if (string.IsNullOrWhiteSpace(portString))
            {

                return false;
            }

            int tempForParsing;

            if (int.TryParse(portString, out tempForParsing) && (tempForParsing >= 1 && tempForParsing <= 65535))
            {

                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// nick name simple validation
        /// </summary>
        /// <param name="nickString">name</param>
        /// <returns></returns>
        private bool ValidateNickName(string nickString)
        {

            if (string.IsNullOrWhiteSpace(nickString))
            {

                return false;
            }

            int tempForParsing;

            if (int.TryParse(nickString, out tempForParsing))
            {

                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
        /// <summary>
        /// colors loding to combobox 
        /// </summary>
        private void LoadColors()
        {

            foreach (PropertyInfo item in typeof(Color).GetProperties())
            {
                if (item.PropertyType.FullName == "System.Drawing.Color")
                    ColorComboBox.Items.Add(item.Name);
            }
        }
        /// <summary>
        /// selecting color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Color = (string)ColorComboBox.SelectedItem;
        }
    }
}
