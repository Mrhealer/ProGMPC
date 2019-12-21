using System;
using System.Collections;
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
namespace ServerSoket
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        TcpListener server = null;
        TcpClient client;
        Byte[] bytes = new Byte[10024];
        String data = null;
        string clientIPAddress;
        public static Hashtable clientsList = new Hashtable();
        NetworkStream stream;
        IDictionary<string, string> dict = new Dictionary<string, string>();
        private async void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                // Set the TcpListener on port 13000.

                Int32 port = 13000;
                IPAddress localAddr = IPAddress.Parse("192.168.1.3");
                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, port);
                // Start listening for client requests.
                server.Start();
                lblMsg.Text = "Server is started !";
                Task<int> taskRun = GetListAsync(lblMsg);
                lblMsg.Text = "Waiting client connect ...";
                int x = await taskRun;
            }
            catch (Exception ex) { }
        }
        private Task<int> GetListAsync(Label lblMsg)
        {
            return Task.Run(() => RunConvergence(lblMsg));
        }
        private Task WaitData()
        {
            return Task.Run(() => HandleAsyncConnection());
        }
        public int RunConvergence(Label lblMsg)
        {
            try
            {
                while (true)
                {
                    client = server.AcceptTcpClient(); //proceed
                    clientIPAddress = IPAddress.Parse(((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString()) + "";
                    clientsList.Add(clientIPAddress, client);
                    lblMsg.Text = "" + lstClient.Items.Count + " connected";
                    StartAccept();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex + ""); }
            return 1;
        }
        private void StartAccept()
        {
            //server.BeginAcceptTcpClient(HandleAsyncConnection, server);
            Thread ctThread = new Thread(HandleAsyncConnection);
            ctThread.Start();
        }
        private void HandleAsyncConnection()
        {
            try
            {
                //int i;
                ////clientsList.Add(clientIPAddress, client);
                //// Loop to receive all the data sent by the client.
                //stream = client.GetStream();

                //while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                //{
                //    // Translate data bytes to a ASCII string.
                //    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                //    if (data == "Connected")
                //    {
                //        lstClient.Items.Add("Address: " + clientIPAddress + " " + data);
                //    }
                //    else
                //    {
                //        if (data == "Diconnect")
                //        {
                //            if (clientsList.Count > 0)
                //            {
                //                lstClient.Items.Add("Address: " + clientIPAddress + " " + data);
                //                string key = "192.168.1.3";
                //                TcpClient broadcastSocket = (TcpClient)clientsList[key];
                //                broadcastSocket.Close();
                //                clientsList.Remove(clientIPAddress);
                //            }
                //        }
                //        else
                //        {
                //            lstClient.Items.Add("Address: " + clientIPAddress + " " + data);
                //            // clientsList.Remove(clientIPAddress);
                //        }

                //    }
                //}
                //stream.Close();
                //client.Close();

                // Shutdown and end connection
                while (true)
                {
                    stream = client.GetStream();
                    if (stream.CanRead)
                    {
                        byte[] myReadBuffer = new byte[1024];
                        StringBuilder myCompleteMessage = new StringBuilder();
                        int numberOfBytesRead = 0;
                        // Incoming message may be larger than the buffer size.
                        do
                        {
                            numberOfBytesRead = stream.Read(myReadBuffer, 0, myReadBuffer.Length);
                            clientIPAddress = IPAddress.Parse(((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString()) + "";
                            myCompleteMessage.AppendFormat("{0}", Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead));
                            //Check response
                            if (myCompleteMessage.ToString() == "Connected")
                             {
                                 lstClient.Items.Add("Address: " + clientIPAddress + " " + myCompleteMessage.ToString());
                                 lblMsg.Text = "Client already connected: " + clientsList.Count;
                                 dict.Add(clientIPAddress, clientIPAddress);
                                 ddlClient.DataSource = new BindingSource(dict, null);
                                 ddlClient.DisplayMember = "Value";
                                 ddlClient.ValueMember = "Key";
                             }
                             else
                             {
                                 if (myCompleteMessage.ToString() == "Diconnect")
                                 {
                                     if (clientsList.Count > 0)
                                     {
                                         string key = ddlClient.Text;
                                         TcpClient broadcastSocket = (TcpClient)clientsList[key];
                                         clientIPAddress = IPAddress.Parse(((IPEndPoint)broadcastSocket.Client.RemoteEndPoint).Address.ToString()) + "";
                                         //broadcastSocket.Close();
                                         clientsList.Remove(clientIPAddress);
                                         lstClient.Items.Add("Address: " + clientIPAddress + " " + myCompleteMessage.ToString());
                                        
                                     }
                                 }
                                 else
                                 {
                                     lstClient.Items.Add("Address: " + clientIPAddress + " " + myCompleteMessage.ToString());
                                     // clientsList.Remove(clientIPAddress);
                                 }

                             }
                        }
                        while (stream.DataAvailable);
                    }
                }
            }
            catch (Exception) { }

        }
        public async void SentData()
        {
            string key =  ddlClient.Text;
            TcpClient broadcastSocket = (TcpClient)clientsList[key];
            NetworkStream stream = broadcastSocket.GetStream();
            bytes = System.Text.Encoding.ASCII.GetBytes(txtMsgSent.Text);
            // Send back a response.
            stream.Write(bytes, 0, bytes.Length);
            //  stream.Write(bytes, 0, bytes.Length);
            stream = client.GetStream();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                CancellationTokenSource cts = new CancellationTokenSource();
                cts.Cancel();
                stream.Close();
                client.Close();
                server.Stop();
                Application.Exit();
            }
            catch (Exception) { }
            finally
            {
                Application.Exit();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //CancellationTokenSource cts = new CancellationTokenSource();
            //cts.Cancel();
            //close = true;
            //stream.Close();
            //client.Close();
            //server.Stop();
            //Application.Exit();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SentData();
        }


    }

}