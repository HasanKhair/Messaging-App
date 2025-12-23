// ChatServer/Program.cs
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ChatServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 5000);
            server.Start();
            Console.WriteLine("Server started... Waiting for a connection...");

            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("Client connected.");

            NetworkStream stream = client.GetStream();

            while (true)
            {
                byte[] buffer = new byte[1024];
                int bytes = stream.Read(buffer, 0, buffer.Length);
                string message = Encoding.UTF8.GetString(buffer, 0, bytes);
                Console.WriteLine("Received: " + message);

                string response = "Echo: " + message;
                byte[] responseData = Encoding.UTF8.GetBytes(response);
                stream.Write(responseData, 0, responseData.Length);
            }
        }
    }
}
