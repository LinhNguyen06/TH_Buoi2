using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    public partial class Form1 : Form
    {
        byte[] data = new byte[1024];
        IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
        Socket server;
        string gui, stringData, stringGui, cgui;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);
            }catch(SocketException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            textBox1.Text = ipep.Address.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            server.Send(Encoding.ASCII.GetBytes(textBox2.Text));
            stringGui = ("Client: " + textBox2.Text);
            listBox1.Items.Add(stringGui);
            data = new byte[1024];
            int rec = server.Receive(data);
            stringData = Encoding.UTF8.GetString(data, 0, rec);
            gui = ("Server: " + stringData);
            listBox1.Items.Add(gui);
            textBox2.Clear();
            //string text = textBox2.Text;
            //data = new byte[1024];
            //data = Encoding.ASCII.GetBytes(text);
            //textBox2.Text = "";
            //listBox1.Items.Add(text);
            //server.Send(data);
            //data = new byte[1024];
            //server.Receive(data);
            //text = Encoding.ASCII.GetString(data);
            //listBox1.Items.Add(text);
        }
    }
}
