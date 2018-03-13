using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace WindowsFormsApplication1
{
    public partial class ServerForm : Form
    {
        IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9050);

        Socket client;
        IPEndPoint clientep;
        byte[] data;
        public ServerForm()
        {
            InitializeComponent();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            data = new byte[1024];
            int rec = client.Receive(data);
            string stringData = Encoding.UTF8.GetString(data, 0, rec);
            string sgui = ("Client: " + stringData);
            listBox1.Items.Add(sgui);
            byte[] gui = Encoding.UTF8.GetBytes(textBox2.Text);
            client.Send(gui, gui.Length, SocketFlags.None);
            string stringGui = ("Server: " +textBox2.Text);
            listBox1.Items.Add(stringGui);
            textBox2.Clear();
            //string text = textBox2.Text;
            //listBox1.Items.Add(text);
            //textBox1.Text = "";
            //data = new byte[1024];
            //data = Encoding.ASCII.GetBytes(text);
            //client.Send(data, data.Length, SocketFlags.None);
            //data = new byte[1024];
            //client.Receive(data);
            //listBox1.Items.Add(Encoding.ASCII.GetString(data));
            //client.Send(data, data.Length, SocketFlags.None);
            //while (true)
            //{
            //    recv = client.Receive(data);
            //    if (recv == 0)
            //    {
            //        break;                    
            //    }
            //    listBox1.Text = (Encoding.ASCII.GetString(data, 0, recv));
            //    client.Send(data, recv, SocketFlags.None);
            //}
            //client.Close();
            //server.Close();
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(ipep);
            server.Listen(4);
            client = server.Accept();
            //lay dia chi cua EndPoint(Cleint)
            clientep = (IPEndPoint)client.RemoteEndPoint;
            textBox1.Text = clientep.Address.ToString();
        }
    }
}
