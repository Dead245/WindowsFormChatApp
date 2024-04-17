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
    clientDict.Add(client, "");

    ThreadPool.QueueUserWorkItem(HandleClientConnection,client);
    client = null;
}

void HandleClientConnection(object obj) {
    bool gotUsername = false;

    TcpClient client = (TcpClient)obj;

    var tcpStream = client.GetStream();

    userCountMessage = $"User Count: {clientDict.Count}";

    var serverMessage = Encoding.UTF8.GetBytes(welcomeMessage + " " + userCountMessage);
    client.GetStream().Write(serverMessage, 0, serverMessage.Length);

    //1024 bite size for incoming messages
    byte[] buffer = new byte[1024];

    //Listen for client input
    while ((tcpStream.Read(buffer, 0, buffer.Length)) != 0)
    {
        //Is there a better way?
        if (!gotUsername) {
            gotUsername = true;
            clientDict[client] = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
            clientDict[client]= clientDict[client].Split(new[] { '\0' }, 2)[0]; //.NET string aren't null terminated...

            string joinMsgString = $"{clientDict[client]} has joined!";
            byte[] joinMsgByte = Encoding.UTF8.GetBytes(joinMsgString, 0, joinMsgString.Length);
            
            serverNotification(joinMsgByte);

            continue;
        }

        HandleClientMessage(buffer, clientDict[client]);
        
        //Clear byte data
        buffer = new byte[1024];
    }
    //Only continues once client disconnects, as Read() completes immediately with '0'
    Console.WriteLine("Client Disconnected");
    clientDict.Remove(client);
}

void HandleClientMessage(byte[] buffer, string username) {

    string message = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
    message = message.Split(new[] { '\0' }, 2)[0]; //.NET string aren't null terminated...
    
    message = $"{username}: {message}";

    byte[] formattedMessage = Encoding.UTF8.GetBytes(message);

    foreach (KeyValuePair<TcpClient,string> entry in clientDict) {
        entry.Key.GetStream().Write(formattedMessage, 0, formattedMessage.Length);
    }
}

void serverNotification(byte[] notification) {
    foreach (KeyValuePair<TcpClient, string> entry in clientDict) {
        entry.Key.GetStream().Write(notification, 0, notification.Length);
    }
}
