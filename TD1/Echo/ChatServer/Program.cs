using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.IO;

namespace Echo
{
    class EchoServer
    {
        [Obsolete]
        static void Main(string[] args)
        {

            Console.CancelKeyPress += delegate
            {
                System.Environment.Exit(0);
            };

            TcpListener ServerSocket = new TcpListener(5000);
            ServerSocket.Start();

            Console.WriteLine("Server started.");
            while (true)
            {
                TcpClient clientSocket = ServerSocket.AcceptTcpClient();
                handleClient client = new handleClient();
                client.startClient(clientSocket);
            }


        }
    }

    public class handleClient
    {
        TcpClient clientSocket;
        public void startClient(TcpClient inClientSocket)
        {
            this.clientSocket = inClientSocket;
            Thread ctThread = new Thread(get);
            ctThread.Start();
        }



        private void echo()
        {
            NetworkStream stream = clientSocket.GetStream();
            BinaryReader reader = new BinaryReader(stream);
            BinaryWriter writer = new BinaryWriter(stream);

            while (true)
            {

                string str = reader.ReadString();
                Console.WriteLine(str);
                writer.Write(str);
            }
        }

        private void get()
        {
            NetworkStream stream = clientSocket.GetStream();
            BinaryReader reader = new BinaryReader(stream);
            BinaryWriter writer = new BinaryWriter(stream);

            while (true)
            {

                string input = reader.ReadString();
                string cmd = input.Split(' ')[0];
                string path = input.Split(' ')[1];
                if(cmd == "GET")
                {
                    string file = File.ReadAllText(Environment.GetEnvironmentVariable("HTTP_ROOT") + path);
                    file = "http/1.0 200 OK\n\n " + file;

                    Console.WriteLine(file);
                    writer.Write(file);
                }
                else
                {
                    writer.Write("unknow command");
                }

            }
        }



    }

}