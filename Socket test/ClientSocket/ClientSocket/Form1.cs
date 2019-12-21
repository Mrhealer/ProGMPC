using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientSocket
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        FormState formax = new FormState();
        Byte[] data = new Byte[1024];
        NetworkStream stream;
        public async void Form1_Load(object sender, EventArgs e)
        {

            Int32 port = 13000;
            clientSocket = new System.Net.Sockets.TcpClient();
            clientSocket.Connect("192.168.1.3", port);
            label1.Text = "Client Socket Program - Server Connected ...";
            data = System.Text.Encoding.ASCII.GetBytes("Connected");
            stream = clientSocket.GetStream();
            stream.Write(data, 0, data.Length);
            Task<int> taskRun = GetListAsync();
            int x = await taskRun;
            Microsoft.Win32.SystemEvents.PowerModeChanged += OnPowerChange;

        }
        private Task<int> GetListAsync()
        {
            return Task.Run(() => RunConvergence());
        }
        public int RunConvergence()
        {
            try
            {
                while (true)
                {
                    WaitConnect();
                }
            }
            catch (Exception ex) { }
            return 1;
        }
        public void WaitConnect()
        {
            stream = clientSocket.GetStream();
            if (stream.CanRead)
            {
                byte[] myReadBuffer = new byte[1024];
                StringBuilder myCompleteMessage = new StringBuilder();
                int numberOfBytesRead = 0;
                // Incoming message may be larger than the buffer size.
                do
                {
                    numberOfBytesRead = stream.Read(myReadBuffer, 0, myReadBuffer.Length);

                    myCompleteMessage.AppendFormat("{0}", Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead));
                    txtReceiver.Text = myCompleteMessage.ToString();
                }
                while (stream.DataAvailable);
                data = System.Text.Encoding.ASCII.GetBytes("OK");
                stream.Write(data, 0, data.Length);

            }
            //int i;
            //clientsList.Add(clientIPAddress, client);
            // Loop to receive all the data sent by the client.
            //stream = clientSocket.GetStream();
            //string result = "";
            //while ((i = stream.Read(data, 0, data.Length)) != 0)
            //{
            //    // Translate data bytes to a ASCII string.
            //    result = System.Text.Encoding.ASCII.GetString(data, 0, i);
            //    txtReceiver.Text = result;
            //}
            //data = System.Text.Encoding.ASCII.GetBytes("OK");
            //stream.Write(data, 0, data.Length);

        }

        public void OnPowerChange(object s, PowerModeChangedEventArgs e)
        {
            switch (e.Mode)
            {
                case PowerModes.Resume:
                    //clientSocket = new System.Net.Sockets.TcpClient();
                    //Int32 port = 13000;
                    //clientSocket.Connect("192.168.1.3", port);
                    //label1.Text = "Client Socket Program - Server Connected again";
                    txtSent.Focus();
                    Taskbar.Hide();
                    formax.Maximize(this);
                    break;
                case PowerModes.Suspend:
                    Taskbar.Hide();
                    formax.Maximize(this);
                    clientSocket.Close();
                    break;
                case PowerModes.StatusChange:
                    Microsoft.Win32.SystemEvents.PowerModeChanged += OnPowerChange;
                    txtSent.Focus();
                    Taskbar.Hide();
                    formax.Maximize(this);
                    break;

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            stream = clientSocket.GetStream();
            Byte[] data = new Byte[1024];
            data = System.Text.Encoding.ASCII.GetBytes("Diconnect");
            stream.Write(data, 0, data.Length);
            //CancellationTokenSource cts = new CancellationTokenSource();
            //cts.Cancel();
            //stream.Close();
            //clientSocket.Close();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                button2.Enabled = false;
                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = new Byte[256];
                data = System.Text.Encoding.ASCII.GetBytes(txtSent.Text);

                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();

                NetworkStream stream = clientSocket.GetStream();

                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);


                label1.Text = "Already sent data to server";

                // Receive the TcpServer.response.

                // Buffer to store the response bytes.
                data = new Byte[256];

                // String to store the response ASCII representation.
                String responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                txtReceiver.Text = responseData + "";
                // Close everything.
                //stream.Close();
                //clientSocket.Close();
                //Task<int> taskRun = GetListAsync();
                //int x = await taskRun;
                button2.Enabled = true;

            }
            catch (Exception ex) { MessageBox.Show("" + ex); }
        }


        private void button3_Click(object sender, EventArgs e)
        {

            //Taskbar.Hide();

            formax.Maximize(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Taskbar.Show();
            formax.Restore(this);
        }

    }
}
