using Management.Model;
using Management.Views;
using Management.Views.DangNhap;
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
using Newtonsoft.Json;

namespace Management
{
    public partial class App : Form
    {

        private TcpListener tcpServer;
        private TcpClient tcpClient;
        private Thread th;
        private ArrayList formArray = new ArrayList();
        public ArrayList threadArray = new ArrayList();
        public delegate void ChangedEventHandler(object sender, EventArgs e);
        public event ChangedEventHandler Changed;

        public App()
        {
            InitializeComponent();
            Changed += new ChangedEventHandler(ClientAdded);
        }

        private void App_Load(object sender, EventArgs e)
        {
            StartServer();
            DangNhap dangNhap = new DangNhap(this);
            this.Hide();
            dangNhap.ShowDialog();
        }

        #region Server Start/Stop

        /// <summary>
        /// This function spawns new thread for TCP communication
        /// </summary>
        public void StartServer()
        {
            th = new Thread(new ThreadStart(StartListen));
            th.Start();
        }

        /// <summary>
        /// Server listens on the given port and accepts the connection from Client.
        /// As soon as the connection id made a dialog box opens up for Chatting.
        /// </summary>
        public void StartListen()
        {

            IPAddress localAddr = IPAddress.Parse("127.0.0.1");

            tcpServer = new TcpListener(localAddr, 8000);
            tcpServer.Start();

            // Keep on accepting Client Connection
            while (true)
            {

                // New Client connected, call Event to handle it.
                Thread t = new Thread(new ParameterizedThreadStart(NewClient));
                tcpClient = tcpServer.AcceptTcpClient();
                t.Start(tcpClient);

            }

        }

        /// <summary>
        /// Function to stop the TCP communication. It kills the thread and closes client connection
        /// </summary>
        public void StopServer()
        {

            if (tcpServer != null)
            {

                // Abort All Running Threads
                foreach (Thread t in threadArray)
                {
                    t.Abort();
                }

                // Clear all ArrayList
                threadArray.Clear();
                formArray.Clear();


                // Abort Listening Thread and Stop listening
                th.Abort();
                tcpServer.Stop();
            }
        }


        /// <summary>
        /// Fuction checks whether to start or stop the server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        #endregion
        #region Add/remove Clients
        /// <summary>
        /// 
        /// </summary>
        public void NewClient(Object obj)
        {
            ClientAdded(this, new MyEventArgs((TcpClient)obj));
        }

        /// <summary>
        /// Event Fired when a Client gets connected. Following actions are performed
        /// 1. Update Tree view
        /// 2. Open a chat box to chat with client.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClientAdded(object sender, EventArgs e)
        {
            tcpClient = ((MyEventArgs)e).clientSock;
            String remoteIP = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
            String remotePort = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Port.ToString();

            // Call Delegate Function to update Tree View
            // UpdateClientList(remoteIP + " : " + remotePort, "Add");

            //// Show Dialog Box for Chatting
            //ctd = new ChatDialog(this, tcpClient);
            //ctd.Text = "Connected to " + remoteIP + "on port number " + remotePort;

            // Add Dialog Box Object to Array List
            // formArray.Add(ctd);
            SocketHander soketHander = new SocketHander(tcpClient, Thread.CurrentThread, this);
            threadArray.Add(Thread.CurrentThread);
            // ctd.ShowDialog();

        }


        /// <summary>
        /// Delegate Function to update List box.
        /// If type parameter is "Add", then client information is added in Tree View
        /// else the entry is delete from Tree View.
        /// </summary>
        /// <param name="str"></param>
        private void UpdateClientList(string str, string type)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            //if (this.tvClientList.InvokeRequired)
            //{
            //    SetListBoxItem d = new SetListBoxItem(UpdateClientList);
            //    this.Invoke(d, new object[] { str, type });
            //}
            //else
            //{
            //    // If type is Add, the add Client info in Tree View
            //    if (type.Equals("Add"))
            //    {
            //        this.tvClientList.Nodes[0].Nodes.Add(str);
            //    }
            //    // Else delete Client information from Tree View
            //    else
            //    {
            //        foreach (TreeNode n in this.tvClientList.Nodes[0].Nodes)
            //        {
            //            if (n.Text.Equals(str))
            //                this.tvClientList.Nodes.Remove(n);
            //        }
            //    }

            //}
        }

        #endregion
    }
    public class SocketHander
    {

        public TcpClient tcpClient;
        public Thread thread;
        public frmChat frmChat;
        public App frmAPP;

        private NetworkStream clientStream;

        public SocketHander(TcpClient _tcpClient, Thread _thread,App _mainApp)
        {
            this.tcpClient = _tcpClient;
            this.thread = _thread;
            this.frmAPP = _mainApp;
            clientStream = tcpClient.GetStream();
            StateObject state = new StateObject();
            state.workSocket = tcpClient.Client;
            tcpClient.Client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(OnReceive), state);
        }
        public void OnReceive(IAsyncResult ar)
        {
            String content = String.Empty;

            // Retrieve the state object and the handler socket
            // from the asynchronous state object.
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;
            int bytesRead;

            if (handler.Connected)
            {

                // Read data from the client socket. 
                try
                {
                    bytesRead = handler.EndReceive(ar);
                    if (bytesRead > 0)
                    {
                        // There  might be more data, so store the data received so far.
                        state.sb.Remove(0, state.sb.Length);
                        state.sb.Append(Encoding.ASCII.GetString(
                                         state.buffer, 0, bytesRead));

                        // Display Text in Rich Text Box
                        content = state.sb.ToString();

                        try
                        {
                            var data = JsonConvert.DeserializeObject<SocketData>(content);
                            if (data.Type.Equals("CHAT"))
                            {
                                if (this.frmChat == null || (this.frmChat!=null && !this.frmChat.Disposing))
                                {
                                    this.frmChat = new frmChat();
                                   
                                }

                                this.frmAPP.Invoke((Action)delegate { this.frmChat.Show(); });

                            }
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                      

                        handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                            new AsyncCallback(OnReceive), state);

                    }
                }

                catch (SocketException socketException)
                {
                    //WSAECONNRESET, the other side closed impolitely
                    if (socketException.ErrorCode == 10054 || ((socketException.ErrorCode != 10004) && (socketException.ErrorCode != 10053)))
                    {
                        // Complete the disconnect request.
                        String remoteIP = ((IPEndPoint)handler.RemoteEndPoint).Address.ToString();
                        String remotePort = ((IPEndPoint)handler.RemoteEndPoint).Port.ToString();
                   //     this.owner.DisconnectClient(remoteIP, remotePort);
                        handler.Close();
                        handler = null;

                    }
                }

                // Eat up exception....Hmmmm I'm loving eat!!!
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message + "\n" + exception.StackTrace);

                }
            }
        }

    }
    #region StateObject Class Definition
    /// <summary>
    /// StateObject Class to read data from Client
    /// </summary>
    public class StateObject
    {
        // Client  socket.
        public Socket workSocket = null;
        // Size of receive buffer.
        public const int BufferSize = 1024;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        // Received data string.
        public StringBuilder sb = new StringBuilder();
    }
    #endregion


}
