using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NetworkingChatApp
{
    public partial class Form1 : Form
    {
        TcpClient tcpClient = new TcpClient();
        byte[] buffer = new byte[1024];

        //Will change for user to input these later
        int port = 52100;
        IPAddress hostAddress = IPAddress.Parse("127.0.0.1");

        public Form1()
        {
            InitializeComponent();

        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {

            if (!tcpClient.Connected) tcpClient.Connect(hostAddress, port);
            tcpClient.GetStream().BeginRead(buffer, 0, buffer.Length, ServerMessageReceived, null);

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
            var message = Encoding.UTF8.GetBytes(InputBox.Text);
            tcpClient.GetStream().Write(message, 0, message.Length);
            
            InputBox.Clear();
            InputBox.Focus();
        }

        private void ServerMessageReceived(IAsyncResult result) {
            if (result.IsCompleted) {
                MessageListBox.Items.Add("Server sent message!");
            }
        }
    }
}