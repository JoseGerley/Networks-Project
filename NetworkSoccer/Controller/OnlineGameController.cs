using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using UnityEngine;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Controller
{

    class OnlineGameController
    {
        static private NetworkStream stream;
        static private StreamWriter streamw;
        static private StreamReader streamr;
        static private TcpClient client = new TcpClient();
        static private string nick = "unknown";
        private Player1Controller p1;
        private Player2Controller p2;

        public OnlineGameController(Player1Controller a, Player2Controller b)
        {
            p1 = a;
            p2 = b;
        }
        public void Listen()
        {
            while (client.Connected)
            {
                try
                {
                    float[] s = streamr.ReadLine().Split(',').Select(x=> float.Parse(x)).ToArray();
                    Vector2 v1 = new Vector2(s[0], s[1]);
                    p2.setMove(v1);
                    Vector2 v2 = p1.getMove();
                    string o = v2.x + "," + v2.y;
                    streamw.WriteLine(o);
                    streamw.Flush();
                }
                catch
                {

                }
            }
        }

        void Conectar()
        {
            try
            {
                client.Connect("192.168.1.57", 8000);
                if (client.Connected)
                {
                    Thread t = new Thread(Listen);

                    stream = client.GetStream();
                    streamw = new StreamWriter(stream);
                    streamr = new StreamReader(stream);

                    streamw.WriteLine(nick);
                    streamw.Flush();

                    t.Start();
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                
            }
        }

    }

    


}
