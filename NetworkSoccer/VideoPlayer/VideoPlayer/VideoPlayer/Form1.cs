using Emgu.CV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoPlayer
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", EntryPoint = "GetSystemMenu")]

        private static extern IntPtr GetSystemMenu(IntPtr hwnd, int revert);

        [DllImport("user32.dll", EntryPoint = "GetMenuItemCount")]

        private static extern int GetMenuItemCount(IntPtr hmenu);

        [DllImport("user32.dll", EntryPoint = "RemoveMenu")]

        private static extern int RemoveMenu(IntPtr hmenu, int npos, int wflags);

        [DllImport("user32.dll", EntryPoint = "DrawMenuBar")]

        private static extern int DrawMenuBar(IntPtr hwnd);

        private const int MF_BYPOSITION = 0x0400;

        private const int MF_DISABLED = 0x0002;
        private UdpClient client;
        private double seconds;
        bool b = true;

        public Form1()
        {
            InitializeComponent();
            seconds = 0;
            connectUDP();
        }

        public async void connectUDP()
        {
            client = new UdpClient();
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("192.168.1.57"), 11000); // endpoint where server is listening
            client.Connect(ep);

            // send data
            byte[] m = Encoding.ASCII.GetBytes(".");
            client.Send(m, m.Length);

            // then receive data
            client.Client.ReceiveTimeout = 5000;
            int h = 0;
            try
            {//Pass the filepath and filename to the StreamWriter Constructor


                while (true)
                {
                    var data = Decompress(client.Receive(ref ep));
                    Console.WriteLine("Packet received {0}", h);
                    Bitmap x = (Bitmap)new ImageConverter().ConvertFrom(data);
                    pictureBox1.Image = x;
                    //pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    await Task.Delay(60);
                    seconds += 0.06;
                    h++;
                }
            }
            catch
            {
                Console.WriteLine("Ended");
                if(b)
                {

                    StreamReader sw = new StreamReader(@"Name.txt");
                    string n = sw.ReadLine();
                    sw.Close();
                    Console.WriteLine(n);
                    var a = Encoding.ASCII.GetBytes(n + "," + seconds);
                    client.Send(a, a.Length);
                }
                Close();
            }

        }

        public static byte[] Decompress(byte[] gzBuffer)
        {
            MemoryStream ms = new MemoryStream();
            int msgLength = BitConverter.ToInt32(gzBuffer, 0);
            ms.Write(gzBuffer, 4, gzBuffer.Length - 4);

            byte[] buffer = new byte[msgLength];

            ms.Position = 0;
            GZipStream zip = new GZipStream(ms, CompressionMode.Decompress);
            zip.Read(buffer, 0, buffer.Length);

            return buffer;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string n;
            try
            {
                StreamReader sw = new StreamReader(@"Name.txt");
                n = sw.ReadLine();
                sw.Close();
                Console.WriteLine(n);
                var a = Encoding.ASCII.GetBytes(n + "," + seconds);
                client.Send(a, a.Length);
                Hide();
                b = false;
            }
            catch
            {

            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IntPtr hmenu = GetSystemMenu(this.Handle, 0);

            int cnt = GetMenuItemCount(hmenu);

            // remove 'close' action

            RemoveMenu(hmenu, cnt - 1, MF_DISABLED | MF_BYPOSITION);

            // remove extra menu line

            RemoveMenu(hmenu, cnt - 2, MF_DISABLED | MF_BYPOSITION);

            DrawMenuBar(this.Handle);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
