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
    public string Ip = "192.168.1.57";
    public void Start()
    {
        //Debug.Log(app.Name.getName());
        //nick = app.Name.getName();
        s = app.view.getP1().getMove().x.ToString() + "|" + app.view.getP1().getMove().y.ToString();
        nick = app.duc.getNickName();
        Thread t2 = new Thread(connectTCP);
        t2.Start();
        

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
                if(p.Equals("Restart"))
                {
                    app.view.temp.restart();
                    app.view.bc.restart();
                }
                if(p.Equals("Wait"))
                {
                    app.view.temp.waiting();
                }
                if(p.Equals("givemelove"))
                {
                    streamw.WriteLine(app.view.bc.getResume());
                    streamw.Flush();
                }
                if(p.Equals("takeyourlove"))
                {
                    string rec = streamr.ReadLine();
                    var data = rec.Split('#');
                    var d = data[0].Split('|');
                    app.view.bc.goalblue = int.Parse(d[0]);
                    app.view.bc.goalred = int.Parse(d[1]);
                    app.view.bc.SetText();
                    app.view.bc.hist.setGoals(int.Parse(d[0]), int.Parse(d[1]));
                    app.view.temp.setTime(int.Parse(d[2]));
                    app.view.temp.setST(bool.Parse(d[3]));
                    app.view.bc.hist.setHist(data[1].Split(',').ToList());
                }
                if(p.Equals("keep"))
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

    public void connectTCP()
    {
        try
        {
            Debug.Log("connecting");
            //client.Connect("192.168.1.57", 8000);
            client.Connect(Ip, 8000);

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

    
}
