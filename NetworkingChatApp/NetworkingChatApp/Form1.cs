using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NetworkingChatApp
{
    public partial class Form1 : Form
    {   /*
        Username is saved as byte[32]
        Messages are byte[1024]
        
        Sent messages are 'username + message'
        
        Utilize the difference of the size of the byte[]
        to determine what type of message is being received
        */

        string username, ipAddresss;
        //Will change for user to input these later
        int port = 52100;
        IPAddress hostAddress = IPAddress.Parse("127.0.0.1");

        TcpClient tcpClient = new TcpClient();
        byte[] buffer = new byte[1024];


        public Form1()
        {
            InitializeComponent();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {

            if (!tcpClient.Connected)
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(hostAddress, port);
                tcpClient.GetStream().BeginRead(buffer, 0, buffer.Length, ServerMessageReceived, null);

                username = UsernameBox.Text;

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
            else {
                DisconnectClient();
                UsernameBox.Enabled = true;
                ServerAddressBox.Enabled = true;
                PortBox.Enabled = true;

                InputBox.Enabled = false;
                SendMessageButton.Enabled = false;
            }

        }

        private void SendMessageButton_Click(object sender, EventArgs e)
        {   //TODO: encode message with username and etc before writing to server
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
        void DisconnectClient()
        {
            if (tcpClient.Connected) {
                tcpClient.GetStream().Close();
                tcpClient.Close();
            }
            //TODO: Tell server who is disconnecting
            
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Close Stream and Client once user closes the form window
            DisconnectClient();
        }
    }
}