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
    /// <summary>
    /// Сокет клиент
    /// </summary>
    public class SynchronousClient
    {
        // Сокет
        public Socket WorkSocket = null;
        // Размер буффера   
        public int BufferSize = 256;
        // Буффер, в котором будут храниться данные
        public byte[] Buffer = new byte[256];
        // Флажок, следует ли продолжать общение с сервом 
        private bool job;
        // Экземпляр обекта для получения данных

        /// <summary>
        /// Асинхронная оболочка для старта общения с сервером
        /// </summary>
        /// <param name="pb">pictureBox для вывода изображения с сервера</param>
        /// <param name="quality">Качество изображения [0-100]</param>
        /// <param name="serverIP">IP сервера</param>
        /// <param name="serverPort">Порт</param>
        /// <param name="updateTimeout">Таймаут между запросами на получение изобаржения (ms.)</param>
        public async void StartClient(PictureBox pb, int quality, string serverIP, int serverPort = 11000 ,int updateTimeout = 0)
        {
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            var progress = new Progress<Image>(
                img => {
                    if (pb.Image != null)
                        pb.Image.Dispose();
                    pb.Image = img;
                    pb.Update();
                });
            await Task.Factory.StartNew<bool>(
                () => this.StartClient(progress, quality, serverIP, serverPort, updateTimeout), TaskCreationOptions.LongRunning);
        }

        /// <summary>
        /// Старт общения с сервером
        /// </summary>
        /// <param name="progress"></param>
        /// <param name="quality">Качество изображения [0-100]</param>
        /// <param name="serverIP">IP сервера</param>
        /// <param name="serverPort">Порт</param>
        /// <param name="updateTimeout">Таймаут между запросами на получение изобаржения (ms.)</param>
        /// <returns>Сигнал об окончании работы</returns>
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
                WorkSocket = client;

                // Connect to the remote endpoint.
                client.Connect(remoteEP);
                job = true;
                while (job)
                {
                    //Получение размера
                    Console.WriteLine("Отправил на получение размера картинки");
                    Send(client, "scrSize="+quality);
                    Console.WriteLine("Жду размер");
                    BufferSize = ReceiveInt(client);
                    //Получение картинки
                    Console.WriteLine("Отправил запрос на получение картинки");
                    Send(client, "scr");
                    Console.WriteLine("Жду картинку");
                    progress.Report(ReceiveImg(client));
                    Thread.Sleep(updateTimeout);
                }
                // Шлем команду на отключение от серва
                Send(client, "fuckOff");
                // И отключаемся сами
                client.Shutdown(SocketShutdown.Both);
                client.Close();
                client.Dispose();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                StopClient();
            }
            return true;
        }

        /// <summary>
        /// Остановка общения с сервером
        /// </summary>
        public void StopClient()
        {
            job = false;
            if(WorkSocket != null && !WorkSocket.Connected)
            {
                WorkSocket.Close();
                WorkSocket.Dispose();
            }
        }

        /// <summary>
        /// Логика получения целочисленного значения
        /// </summary>
        /// <param name="client"></param>
        private int ReceiveInt(Socket client)
        {
            Buffer = new byte[BufferSize];
            // Получаем данные от серва 
            try
            {
                // Читаем данные из сокета
                int bytesRead = client.Receive(Buffer, 0, BufferSize, 0);
                if (bytesRead > 0)
                {
                    int val = BitConverter.ToInt32(Buffer, 0);
                    return val;
                }
                return ReceiveInt(client);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                StopClient();
                return 0;
            }
        }

        /// <summary>
        /// Логика получения изображения
        /// </summary>
        /// <param name="client"></param>
        private Image ReceiveImg(Socket client)
        {
            WorkSocket = client;
            Buffer = new byte[BufferSize];
            // Обнуляем прогресс получения изображения
            int imgBufferFill = 0;
            // Получаем данные от серва 
            try
            {

                do // Пока все изображение не считано, читаем данные из сокета
                {
                    int bytesRead = client.Receive(Buffer, imgBufferFill,
                        BufferSize - imgBufferFill, 0);
                    imgBufferFill += bytesRead;
                }
                while (imgBufferFill < BufferSize);
                // После полного считывания изображения возвращаем
                return Utils.byteArrayToImage(Buffer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                StopClient();
                return new Bitmap(0, 0);
            }
        }

        /// <summary>
        /// Отправка строки на сервер
        /// </summary>
        /// <param name="client"></param>
        /// <param name="data"></param>
        private void Send(Socket client, string data)
        {
            // Конвертируем строку в байты  
            byte[] byteData = Encoding.ASCII.GetBytes(data);
            // Отправляем данные
            Send(client, byteData);
        }

        /// <summary>
        /// Отправка массива байт на сервер
        /// </summary>
        /// <param name="state"></param>
        /// <param name="byteData"></param>
        private void Send(Socket client, byte[] byteData)
        {
            try
            {
                client.Send(byteData, 0, byteData.Length, 0);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                StopClient();
            }
        }

        public static bool CheckServer(string serverIP, int serverPort)
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse(serverIP);
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, serverPort);
                using (Socket client = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp))
                {
                    client.Connect(remoteEP);
                    byte[] msg = Encoding.ASCII.GetBytes("qhi");
                    client.Send(msg, 0, msg.Length, 0);
                    Thread.Sleep(100);
                    byte[] buff = new byte[16];
                    int bytesRead = client.Receive(buff, 0, buff.Length, 0);
                    if (bytesRead > 0 &&
                        Encoding.ASCII.GetString(buff, 0, bytesRead) == "qhi")
                    {
                        msg = Encoding.ASCII.GetBytes("fuckOff");
                        client.Send(msg, 0, msg.Length, 0);
                        client.Shutdown(SocketShutdown.Both);
                        return true;
                    }
                    return false;

                
                }
            }
                catch
            {
                return false;
            }
        }
    }
}
