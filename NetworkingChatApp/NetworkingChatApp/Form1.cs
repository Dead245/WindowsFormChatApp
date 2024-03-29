using System.CodeDom.Compiler;
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
            
            //Clear and refocus text box so user can keep typing
            InputBox.Clear();
            InputBox.Focus();
        }

        private void ServerMessageReceived(IAsyncResult result) {
            if (result.IsCompleted && tcpClient.Connected) {
                var bytesIn = tcpClient.GetStream().EndRead(result);
                if (bytesIn > 0) { 
                    byte[] temp = new byte[bytesIn];
                    Array.Copy(buffer, 0, temp, 0, bytesIn);
                    string stringInput = Encoding.UTF8.GetString(temp);
                    
                    //Use BeginInvoke to solve accessing MessageListBox on a different thread
                    BeginInvoke((Action)(() => {
                        MessageListBox.Items.Add(stringInput);
                        MessageListBox.SelectedIndex = MessageListBox.Items.Count - 1;
                    }));
                    
                }
                Array.Clear(buffer, 0, bytesIn);

                //Restart reading for more input from server
                tcpClient.GetStream().BeginRead(buffer, 0, buffer.Length, ServerMessageReceived, null);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
                //Close Stream and Client once user closes the form window
                tcpClient.GetStream().Close();
                tcpClient.Close();
        }
    }
}