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
            FacadeServer ServerConnection = new FacadeServer();
            new Thread(read => ServerConnection.Read()).Start();
            new Thread(write => ServerConnection.Write()).Start();                  
        }      
    }
}
