using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NetMQ;
using NetMQ.Sockets;

namespace Yibi.NetMQ
{
    public class NetMqTest
    {
        public static void Run()
        {
            var t1 = new Thread(() =>
            {
                Client();
            });
            t1.Start();

            var t2 = new Thread(() =>
            {
                Server();
            });
            t2.Start();

        }

        static void Server()
        {
            using (var server = new ResponseSocket())
            {
                server.Bind("tcp://*:5555");
                while (true)
                {
                    var message = server.ReceiveFrameString();
                    Console.WriteLine("Server Received {0}", message);
                    // processing the request
                    Thread.Sleep(100);
                    Console.WriteLine("Server Sending World");
                    server.SendFrame(System.Text.Encoding.UTF8.GetBytes(message));
                }
            }
        }

        static void Client()
        {
            using (var client = new RequestSocket())
            {
                client.Connect("tcp://localhost:5555");

                int index = 0;
                while (true)
                {
                    Console.WriteLine("client Sending Hello" + index);
                    client.SendFrame($"hello {index}");

                    var message = client.ReceiveFrameString();
                    Console.WriteLine("client Received {0}", message);

                    Thread.Sleep(1000);

                    index++;
                }
            }
        }
    }
}
