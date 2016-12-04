
using System.Windows.Forms;
using System.Linq;
namespace Chat_Vadim_Mukovozov_326960382
{
    public partial class ServerSettings : Form
    {


        public string IPAdress { get; private set; }   //ip 

        public int Port { get; private set; }      //port
        public ServerSettings()
        {
            InitializeComponent();
        }




        #region validation_funcs
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
        #endregion

        private void OkButton_Click(object sender, System.EventArgs e)
        {

            // validation ip address
            if (!ValidateIPv4(IPText.Text))
                MessageBox.Show("IP address not valid !!!!!!!!!!");
            // validation port 
            if (!ValidatePort(PortUpDown.Value.ToString()))
                MessageBox.Show("Port not valid!!!!!!!!");

            if (ValidateIPv4(IPText.Text) && ValidatePort(PortUpDown.Value.ToString()))
            {  // updating ip and port 
                IPAdress = IPText.Text;
                Port = (int)PortUpDown.Value;
                Close();
            }

        }

            
    }
}
