using System.Net;
using System.Net.Sockets;
using System.Text;

string welcomeMessage = "Welcome to your local server!";

int port = 52100;
var hostAddress = IPAddress.Parse("127.0.0.1");

//Setup and start tcp server
TcpListener tcpListener = new TcpListener(hostAddress, port);
tcpListener.Start();

Console.WriteLine("Server Started!");

//1024 bite size for incoming messages
byte[] buffer = new byte[1024];
string inputtedMessage;

//Enter Listening loop
while (true)
{
    TcpClient client = tcpListener.AcceptTcpClient();
    ThreadPool.QueueUserWorkItem(HandleClient,client);
}

void HandleClient(object? obj) {
    
    TcpClient client = (TcpClient)obj;

    var tcpStream = client.GetStream();

    var message = Encoding.UTF8.GetBytes(welcomeMessage);
    client.GetStream().Write(message, 0, message.Length);

    int readTotal;

    //Listen for client input
    while ((readTotal = tcpStream.Read(buffer, 0, buffer.Length)) != 0)
    {
        inputtedMessage = Encoding.UTF8.GetString(buffer, 0, buffer.Length);

        //Just sends the message back to user for now
        client.GetStream().Write(buffer, 0, buffer.Length);

        buffer = new byte[1024];
    }
}
