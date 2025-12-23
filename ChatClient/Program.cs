using System;
using System.Net.Sockets;
using System.Text;

namespace ChatClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("127.0.0.1", 5000);
            NetworkStream stream = client.GetStream();

            Console.WriteLine("Connected to server. Type messages and press Enter.");

            while (true)
            {
                string? message = Console.ReadLine();
                if (string.IsNullOrEmpty(message))
                    continue;

                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);

                byte[] buffer = new byte[1024];
                int bytes = stream.Read(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, bytes);
                Console.WriteLine("Server: " + response);
            }
        }
    }
}
