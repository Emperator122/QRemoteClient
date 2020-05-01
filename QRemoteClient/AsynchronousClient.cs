using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QRemoteClient
{
    // State object for receiving data from remote device.  
    public class StateObject
    {
        // Client socket.  
        public Socket workSocket = null;
        // Size of receive buffer.  
        public int BufferSize = 256;
        // Receive buffer.  
        public byte[] buffer = new byte[256];
        public byte[] imgBuffer = new byte[0];
        public int imgBufferFill = 0;
        // Received data string.  
        public Image img;
    }

    public class AsynchronousClient
    {
        // ManualResetEvent instances signal completion.  
        private ManualResetEvent connectDone =
            new ManualResetEvent(false);
        private ManualResetEvent sendDone =
            new ManualResetEvent(false);
        private ManualResetEvent receiveDone =
            new ManualResetEvent(false);
        private ManualResetEvent isStoped =
             new ManualResetEvent(false);
        // The response from the remote device.  
        private Image response;
        private bool job;
        StateObject state = new StateObject();
        public async void StartClient(PictureBox pb, int quality, string serverIP, int serverPort = 11000 ,int updateTimeout = 0)
        {
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
           
            var progress = new Progress<Image>(img => {  pb.Image = img; pb.Update(); });
            await Task.Factory.StartNew<bool>(
                () => this.StartClient(progress, quality, serverIP, serverPort, updateTimeout), TaskCreationOptions.LongRunning);
        }
        private bool StartClient(IProgress<Image> progress, int quality, string serverIP, int serverPort, int updateTimeout)
        {
            // Connect to a remote device.  
            try
            {
                IPAddress ipAddress = IPAddress.Parse(serverIP);
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, serverPort);

                // Create a TCP/IP socket.  
                Socket client = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect to the remote endpoint.  
                client.BeginConnect(remoteEP,
                    new AsyncCallback(ConnectCallback), client);
                connectDone.WaitOne();
                job = true;
                while (job)
                {
                    //Получение размера
                    sendDone.Reset();
                    receiveDone.Reset();
                    //Console.WriteLine("Отправил на получение размера картинки");
                    Send(client, "scrSize="+quality);
                    sendDone.WaitOne();
                    //Console.WriteLine("Жду картинку");
                    ReceiveInt(client);
                    receiveDone.WaitOne();
                    //Получение картинки
                    sendDone.Reset();
                    receiveDone.Reset();
                    //Console.WriteLine("Отправил запрос");
                    Send(client, "scr");
                    sendDone.WaitOne();
                    //Console.WriteLine("Жду картинку");
                    ReceiveImg(client);
                    receiveDone.WaitOne();
                    //Console.WriteLine("Получил картинку");
                    progress.Report(response);
                    Thread.Sleep(updateTimeout);
                }
                // Шлем команду на отключение серва
                Send(client, "fuckOff");
                // И отключаемся сами
                client.Shutdown(SocketShutdown.Both);
                client.Close();
                client.Dispose();
                isStoped.Set();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                job = false;
                isStoped.Set();
            }
            return true;
        }
        public void StopClient()
        {
            if (job)
            {
                isStoped.Reset();
                job = false;
                isStoped.WaitOne();
            }
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete the connection.  
                client.EndConnect(ar);

                Console.WriteLine("Socket connected to {0}",
                    client.RemoteEndPoint.ToString());

                // Signal that the connection has been made.  
                connectDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                job = false;
                isStoped.Set();
            }
        }

        private void ReceiveInt(Socket client)
        {
            try
            {
                // Create the state object.  
                //StateObject state = new StateObject();
                state.workSocket = client;
                state.buffer = new byte[state.BufferSize];
                state.imgBufferFill = 0;
                // Begin receiving the data from the remote device.  
                client.BeginReceive(state.buffer, 0, state.BufferSize, 0,
                    new AsyncCallback(ReceiveIntCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        private void ReceiveImg(Socket client)
        {
            try
            {
                // Create the state object.  
                //StateObject state = new StateObject();
                state.workSocket = client;
                state.buffer = new byte[state.BufferSize];
                state.imgBufferFill = 0;
                // Begin receiving the data from the remote device.  
                client.BeginReceive(state.buffer, 0, state.BufferSize, 0,
                    new AsyncCallback(ReceiveImgCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void ReceiveIntCallback(IAsyncResult ar)
        {
            // Retrieve the state object and the handler socket  
            // from the asynchronous state object.  
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;
            try
            {
                // Read data from the client socket.
                int bytesRead = handler.EndReceive(ar);
                if (bytesRead > 0)
                {
                    int imgBiteCount = BitConverter.ToInt32(state.buffer, 0);
                    state.BufferSize = imgBiteCount;
                    //state.imgBuffer = new byte[imgBiteCount];

                    Console.WriteLine("Размер картинки в байтах: " + imgBiteCount);
                    Console.WriteLine(state.buffer.Length);
                    receiveDone.Set();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                job = false;
                receiveDone.Set();
                isStoped.Set();
            }
        }
        private void ReceiveImgCallback(IAsyncResult ar)
        {
            // Retrieve the state object and the handler socket  
            // from the asynchronous state object.  
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;
            try
            {
                // Read data from the client socket.
                int bytesRead = handler.EndReceive(ar);
                state.imgBufferFill += bytesRead;
                Console.WriteLine("Считано: " + bytesRead + " из " + state.imgBufferFill);
                if (state.imgBufferFill < state.BufferSize)
                {
                    handler.BeginReceive(state.buffer, state.imgBufferFill, 
                        state.BufferSize - state.imgBufferFill, 0, new AsyncCallback(ReceiveImgCallback), state);
                    return;
                }

                response = state.img;
                receiveDone.Set();
                state.img = Utils.byteArrayToImage(state.buffer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                job = false;
                receiveDone.Set();
                isStoped.Set();
            }
        }
        private void Send(Socket client, string data)
        {
            // Convert the string data to byte data using ASCII encoding.  
            byte[] byteData = Encoding.ASCII.GetBytes(data);
            try
            {
                // Begin sending the data to the remote device.  
                client.BeginSend(byteData, 0, byteData.Length, 0,
                    new AsyncCallback(SendStringCallback), client);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                sendDone.Set();
                job = false;
                isStoped.Set();
            }
        }
        private void SendStringCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                // Signal that all bytes have been sent. 
                sendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /*public static int Main(String[] args)
        {
            StartClient();
            return 0;
        }*/
    }
}
