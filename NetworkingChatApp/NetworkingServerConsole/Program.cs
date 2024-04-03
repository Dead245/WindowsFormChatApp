using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Text;

string welcomeMessage = "Welcome to your local server!";

int port = 52100;
var hostAddress = IPAddress.Parse("127.0.0.1");

ArrayList clientList = new ArrayList();

//Setup and start tcp server
TcpListener tcpListener = new TcpListener(hostAddress, port);
tcpListener.Start();

Console.WriteLine("Server Started!");

//Enter Listening loop
while (true)
{
    TcpClient client = tcpListener.AcceptTcpClient();

    if (client != null) Console.WriteLine("Accepted Connection!");
    clientList.Add(client);

    ThreadPool.QueueUserWorkItem(HandleClientConnection,client);
    client = null;
}

void HandleClientConnection(object obj) {
    
    TcpClient client = (TcpClient)obj;

    var tcpStream = client.GetStream();

    var serverMessage = Encoding.UTF8.GetBytes(welcomeMessage);
    client.GetStream().Write(serverMessage, 0, serverMessage.Length);

    serverMessage = Encoding.UTF8.GetBytes("Users Online: " + clientList.Count);
    client.GetStream().Write(serverMessage, 0, serverMessage.Length);

    int readTotal;

    //1024 bite size for incoming messages
    byte[] buffer = new byte[1024];
    string inputtedMessage;

    //Listen for client input
    while ((readTotal = tcpStream.Read(buffer, 0, buffer.Length)) != 0)
    {
        HandleClientMessage(buffer);
        
        //Clear byte data
        buffer = new byte[1024];
    }
}

void HandleClientMessage(byte[] buffer) {
    
    foreach (TcpClient client in clientList)
    {
        client.GetStream().Write(buffer, 0, buffer.Length);
    }
}
