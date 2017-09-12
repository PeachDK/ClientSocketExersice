using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.IO;
using System.Net.Sockets;

namespace ClientSocketExersice
{
    class FacadeServer
    {
        TcpClient server;
        NetworkStream stream;
        StreamReader streamReader;
        StreamWriter streamWriter;

        public FacadeServer()
        {
            Connect_to_Server();
        }
        public void Read()
        {
            try
            {
                streamReader = new StreamReader(stream);
                while (true)
                {
                    Console.WriteLine(streamReader.ReadLine());
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Connection to server lost.");
                Close_Connection_to_Server();
            }
        }
        public void Write()
        {
            try
            {
                streamWriter = new StreamWriter(stream);
                streamWriter.AutoFlush = true;
                while (true)
                {
                    streamWriter.WriteLine(Console.ReadLine());
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Connection to server lost.");
                Close_Connection_to_Server();
            }
        }

        public void Connect_to_Server()
        {
            try
            {
                server = new TcpClient("localhost", 20001);
                stream = server.GetStream();

            }
            catch (Exception)
            {
                Console.WriteLine("Server Offline......");
                Thread.Sleep(1000);
                Connect_to_Server();
            }
        }

        public void Close_Connection_to_Server()
        {
            streamWriter.Close();
            streamReader.Close();
            stream.Close();
        }




    }
}
