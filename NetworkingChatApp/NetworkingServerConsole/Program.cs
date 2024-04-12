using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;

int port = 52100;
var hostAddress = IPAddress.Parse("127.0.0.1");

Dictionary<TcpClient,string> clientDict = new Dictionary<TcpClient,string>();

string welcomeMessage = "Welcome to your local server!";
string userCountMessage;

//Setup and start tcp server
TcpListener tcpListener = new TcpListener(hostAddress, port);
tcpListener.Start();

Console.WriteLine("Server Started!");

//Enter Listening loop
while (true)
{
    TcpClient client = tcpListener.AcceptTcpClient();

    if (client != null) Console.WriteLine("Accepted Connection!");

    //TODO: Get username from client and add it into value of clientDict.
    clientDict.Add(client, "");

    ThreadPool.QueueUserWorkItem(HandleClientConnection,client);
    client = null;
}

void HandleClientConnection(object obj) {
    
    TcpClient client = (TcpClient)obj;

    var tcpStream = client.GetStream();

    userCountMessage = "User Count : " + clientDict.Count;
    
    var serverMessage = Encoding.UTF8.GetBytes(welcomeMessage + " " + userCountMessage);
    client.GetStream().Write(serverMessage, 0, serverMessage.Length);


    int readTotal;

    //1024 bite size for incoming messages
    byte[] buffer = new byte[1024];

    //Listen for client input
    while ((readTotal = tcpStream.Read(buffer, 0, buffer.Length)) != 0)
    {
        HandleClientMessage(buffer);
        
        //Clear byte data
        buffer = new byte[1024];
    }
    //Only continues once client disconnects, as Read() completes immediately with '0'
    Console.WriteLine("Client Disconnected");
    clientDict.Remove(client);
}

void HandleClientMessage(byte[] buffer) {
    //TODO: parse message in buffer to determine username and etc
    
    foreach (KeyValuePair<TcpClient,string> entry in clientDict)
    {
        entry.Key.GetStream().Write(buffer, 0, buffer.Length);
    }
}
