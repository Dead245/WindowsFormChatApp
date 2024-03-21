using System.Net;
using System.Net.Sockets;

namespace NetworkingChatApp
{
    public partial class Form1 : Form
    {
        //Will change for user to input these later
        int port = 52100;
        IPAddress hostAddress = IPAddress.Parse("127.0.0.1");

        public Form1()
        {
            InitializeComponent();

        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            using TcpClient tcpClient = new TcpClient();

            if (!tcpClient.Connected) tcpClient.Connect(hostAddress, port);
            ConnectButton.Text = "Disconnect";
            MessageListBox.Items.Add("Connected to Server: " + hostAddress + ":" + port);
            
            /*Disable input for username/server boxes when connected to a server 
              And Enable the text/send box */
            UsernameBox.Enabled = false;
            ServerAddressBox.Enabled = false;
            PortBox.Enabled = false;
            
            InputBox.Enabled = true;
            SendMessageButton.Enabled = true;

        }

        private void SendMessageButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Send Button Clicked");
        }
    }
}