using System.Net;
using System.Net.Sockets;

namespace NetworkingChatApp
{
    public partial class Form1 : Form
    {

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
            ConnectButton.Text= "Connected!";
        }
    }
}