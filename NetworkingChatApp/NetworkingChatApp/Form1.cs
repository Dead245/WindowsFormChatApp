using System.Net;
using System.Net.Sockets;
using System.Text;

/*If setting up over local connection, will not work if you use your IP*/

namespace NetworkingChatApp
{
    public partial class Form1 : Form
    {
        byte[] username;
        int port, localport = 52100;
        IPAddress localAddress = IPAddress.Parse("127.0.0.1"), ipAddress;
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
                
                //Get IP Address
                string addressInput = ServerAddressBox.Text;
                addressInput.Trim();
                addressInput = addressInput.Split(new[] { '\0' }, 2)[0];

                //If IP Address is blank, use local IP
                if (addressInput.Equals("")) {
                    ipAddress = localAddress;
                }
                else { 
                    ipAddress= IPAddress.Parse(addressInput);
                }

                //Get Port
                addressInput = PortBox.Text;
                addressInput.Trim();
                addressInput = addressInput.Split(new[] { '\0' }, 2)[0];
                if (addressInput.Equals(""))
                {
                    port = localport;
                }
                else
                {
                    port = Int32.Parse(addressInput);
                }

                //Attempt Connection
                AddMessage($"Connecting to {ipAddress}:{port}...");
                try { 
                    tcpClient.Connect(ipAddress, port);
                } catch {
                    AddMessage("Could not connect to server!");
                    MessageBox.Show("Could not connect to server!");
                }

                tcpClient.GetStream().BeginRead(buffer, 0, buffer.Length, ServerMessageReceived, null);

                //Send server username as first message from this client connection
                username = Encoding.UTF8.GetBytes(UsernameBox.Text);
                //Set username to default if user did not enter anything.
                if (UsernameBox.Text.Equals("")) username = Encoding.UTF8.GetBytes("?:Def");

                tcpClient.GetStream().Write(username, 0, username.Length);

                ConnectButton.Text = "Disconnect";
                AddMessage($"Connected to Server: {ipAddress}:{port}");

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
                ConnectButton.Text = "Connect";
                UsernameBox.Enabled = true;
                ServerAddressBox.Enabled = true;
                PortBox.Enabled = true;

                InputBox.Enabled = false;
                SendMessageButton.Enabled = false;
            }

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
                        AddMessage(stringInput);
                        InputBox.Focus();
                    }));
                    
                }
                Array.Clear(buffer, 0, bytesIn);

                //Restart reading for more input from server
                tcpClient.GetStream().BeginRead(buffer, 0, buffer.Length, ServerMessageReceived, null);
            }
        }
        private void DisconnectClient()
        {
            if (tcpClient.Connected) {
                tcpClient.GetStream().Close();
                tcpClient.Close();
            }
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Close Stream and Client once user closes the form window
            DisconnectClient();
        }

        private void AddMessage(string msg) {
            MsgRichTextBox.AppendText($"{msg}\n");
        }
    }
}