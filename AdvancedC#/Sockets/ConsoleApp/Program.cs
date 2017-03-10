using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var uri = new Uri(args[0]);
            var result = GetResource(uri);
            Console.WriteLine(result);
        }

        private static string GetResource(Uri uri)
        {
            var host = uri.Host;
            var resource = uri.PathAndQuery;
            var hostEntry = Dns.GetHostEntry(host);

            var socket = CreateSocket(hostEntry);
            SendRequest(socket, host, resource);
            return GetResponse(socket);
        }

        private static string GetResponse(Socket socket)
        {
            int bytes = 0;
            byte[] buffer = new byte[256];
            var result = new StringBuilder();

            do
            {
                bytes = socket.Receive(buffer);
                result.Append(Encoding.ASCII.GetString(buffer, 0, bytes));
            } while (bytes > 0);

            return result.ToString();
        }

        private static void SendRequest(Socket socket, string host, string resource)
        {
            var requestMessage = $"GET {resource} HTTP/1.1\r\nHost: {host}\r\n\r\n";
            var requestBytes = Encoding.ASCII.GetBytes(requestMessage);
            socket.Send(requestBytes);
        }

        private static Socket CreateSocket(IPHostEntry hostEntry)
        {
            const int httpPort = 80;

            // open socket
            var endPoint = new IPEndPoint(hostEntry.AddressList[0], httpPort);
            var socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            socket.Connect(endPoint);

            if (socket.Connected)
            {
                return socket;
            }

            return null;
        }

    }
}
