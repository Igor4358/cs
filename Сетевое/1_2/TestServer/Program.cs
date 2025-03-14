﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace TestServer
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            
            //настройка ip адреса и порта
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint ep = new IPEndPoint(ip, 1024);

            //привязка сокета и прослушивание
            s.Bind(ep);
            s.Listen(10);

            try
            {
                while (true)
                {
                    //ожидаение подключений 
                    Socket ns = s.Accept();

                    Console.WriteLine(ns.RemoteEndPoint.ToString());

                    //обработка
                    ns.Send(System.Text.Encoding.ASCII.GetBytes(DateTime.Now.ToString()));
                    ns.Shutdown(SocketShutdown.Both);
                    ns.Close();

                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}
