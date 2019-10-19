using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Linq;
using UnityEngine;
using System.Net;
using System.Text;

public class SoccerController : SoccerElement
{
    static private NetworkStream stream;
    static private StreamWriter streamw;
    static private StreamReader streamr;
    static private TcpClient client = new TcpClient();
    private string nick = "unknown";
    private string s = "";
    public void Start()
    {
        //Debug.Log(app.Name.getName());
        //nick = app.Name.getName();
        s = app.view.getP1().getMove().x.ToString() + "|" + app.view.getP1().getMove().y.ToString();
        nick = app.duc.getNickName();
        connectUDP();
        connect();
        

    }

    public void setName(string Name)
    {
        nick = Name;
    }

    public void FixedUpdate()
    {
        s = app.view.getP1().getMove().x.ToString() + "|" + app.view.getP1().getMove().y.ToString();
    }

    void Listen()
    {
        while (client.Connected)
        {
            try
            {
                streamw.WriteLine(s);
                streamw.Flush();
                string p = streamr.ReadLine();
                Debug.Log(p);
                if (p.Equals("Begin"))
                {
                    app.view.temp.setBegin(true);
                }
                float[] o = p.Split('|').Select(x => float.Parse(x)).ToArray();

                app.view.getP2().setMove(new Vector2(-o[0], -o[1]));
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }

    public void connect()
    {
        try
        {
            //client.Connect("192.168.1.57", 8000);
            client.Connect("172.30.184.76", 8000);

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
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    public void connectUDP()
    {
        var client = new UdpClient();
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse("192.168.1.57"), 11000); // endpoint where server is listening
        client.Connect(ep);

        // send data
        byte[] m = Encoding.ASCII.GetBytes(".");
        client.Send(m, m.Length);

        // then receive data
        client.Client.ReceiveTimeout = 5000;
        int h = 0;
        try
        {
            while (true)
            {
                var data = client.Receive(ref ep);
                Console.WriteLine("Packet received {0}", h);
                //Bitmap x = (Bitmap)new ImageConverter().ConvertFrom(data);
                //x.Save("Image" + h + ".jpeg", ImageFormat.Jpeg);
                h++;
            }
        }
        catch (Exception)
        {

            Console.WriteLine("Ended");
            Console.Read();
        }

    }
}
