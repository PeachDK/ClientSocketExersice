using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace ClientSocketExersice
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient server = new TcpClient("localhost", 20001);
            NetworkStream stream = server.GetStream();
            StreamReader streamReader = new StreamReader(stream);
            StreamWriter streamWriter = new StreamWriter(stream);
            streamWriter.AutoFlush = true;

            new Thread(read =>  Read(streamReader)).Start();
            new Thread(write =>  Write(streamWriter)).Start();      
            
        }
        static public void Read(StreamReader reader)
        {
            while (true)
            {
                Console.WriteLine(reader.ReadLine());
            }            
        }

        static public void Write(StreamWriter writer)
        {
            while (true)
            {
                writer.WriteLine(Console.ReadLine());
            }            
        }
    }
}
