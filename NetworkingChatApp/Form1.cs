using System.Net;
using System.Net.Sockets;

namespace NetworkingChatApp
{
    public partial class Form1 : Form
    {
        public TcpClient tcpClient = new TcpClient();
        int port = 52100;
        IPAddress hostAddress = IPAddress.Parse("127.0.0.1");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            tcpClient.Connect(hostAddress,port);
        }
    }
}