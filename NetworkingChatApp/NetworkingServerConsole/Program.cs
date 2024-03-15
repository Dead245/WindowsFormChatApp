using System.Net;
using System.Net.Sockets;
using System.Text;

Console.WriteLine("Nothing done yet!");

int port = 52100;
var hostAddress = IPAddress.Parse("127.0.0.1");

//Setup and start tcp server
TcpListener tcpListener = new TcpListener(hostAddress, port);
tcpListener.Start();

Console.WriteLine("Server Started!");

//1024 bite size for incoming messages
byte[] buffer = new byte[1024];
string inputtedMessage;

using TcpClient client = tcpListener.AcceptTcpClient();
var tcpStream = client.GetStream();

int readTotal;

Console.WriteLine("Client Connected!");
//Listen for client input
while ((readTotal = tcpStream.Read(buffer, 0,buffer.Length)) != 0){
    Console.WriteLine("Client Connected!");
    inputtedMessage = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
}
