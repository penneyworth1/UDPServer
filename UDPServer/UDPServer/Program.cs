using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Data.SqlClient;

namespace UDPServer
{
    class Program
    {
        static byte[] data;
        static Socket udpServerSocket;

        static void Main(string[] args)
        {
            data = new byte[256];

            IPEndPoint epReceiver = new IPEndPoint(IPAddress.Any, 58642);
            udpServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            udpServerSocket.Bind(epReceiver);

            IPEndPoint ipeSender = new IPEndPoint(IPAddress.Any, 0);
            //The epSender identifies the incoming clients
            EndPoint epSender = (EndPoint)ipeSender;

            Console.WriteLine("Begin receiving data...");

            //Start receiving data
            udpServerSocket.BeginReceiveFrom(data,0,data.Length,SocketFlags.None,ref epSender,new AsyncCallback(OnReceive),epSender);

            Console.WriteLine("exiting...");
            Console.ReadLine();
        }

        private static void OnReceive(IAsyncResult ar)
        {

        }
    }
}

//test connection to db
/*
SqlConnection myConnection = new SqlConnection(
                            "user id=gps_app;" +
                            "password=Suite1500!;server=PARKSQL1;" +
                            "Trusted_Connection=yes;" +
                            "database=GPS; " +
                            "connection timeout=10");
try
{
    myConnection.Open();

    SqlCommand myCommand= new SqlCommand("INSERT INTO table (Column1, Column2) Values ('string', 1)", myConnection);

    myCommand.CommandText = "INSERT INTO table (Column1, Column2) Values ('string', 1)";
    myCommand.ExecuteNonQuery();

}
catch (Exception e)
{
    Console.WriteLine(e.ToString());
}
*/


/*
            int recv;
            byte[] data = new byte[1024];
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 58642);
            Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            newsock.Bind(ipep);
            Console.WriteLine("Waiting for a client...");
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint Remote = (EndPoint)(sender);
            recv = newsock.ReceiveFrom(data, ref Remote);
            Console.WriteLine("Message received from {0}:", Remote.ToString());
            Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));
            string welcome = "Welcome to my test serverz";
            data = Encoding.ASCII.GetBytes(welcome);
            newsock.SendTo(data, data.Length, SocketFlags.None, Remote);
            while (true)
            {
                data = new byte[1024];
                recv = newsock.ReceiveFrom(data, ref Remote);

                Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));
                data = Encoding.ASCII.GetBytes("Holy frijoles batman, you received data");
                newsock.SendTo(data, recv, SocketFlags.None, Remote);
            }
            */