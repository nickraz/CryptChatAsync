using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace CryptChatAsync
{
    class CryptedMessages
    {
        /// <summary>
        /// Ключ AES в формате потока байтов
        /// </summary>
        public static byte[] aeskey { get; set; }

        /// <summary>
        /// IP локального компьютера
        /// </summary>
        public static string myIp { get; set; }

        /// <summary>
        /// Порт приемник
        /// </summary>
        public static int PortI { get; set; }

        /// <summary>
        /// Порт отправитель
        /// </summary>
        public static int PortO { get; set; }

        /// <summary>
        /// IP клиента
        /// </summary>
        public static string clientIp { get; set; }

        private Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public static string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                //Генерируем число являющееся латинским символом в юникоде
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                //Конструируем строку со случайно сгенерированными символами
                builder.Append(ch);
            }
            return builder.ToString();
        }

        /// <summary>
        /// Шифрует исходное сообщение AES ключом
        /// </summary>
        /// <param name="src">Исходный текст</param>
        /// <returns>Возвращает зашифрованный массив байтов</returns>
        public static byte[] ToAes256(string src)
        {
            Aes aes = Aes.Create();
            aes.GenerateIV();
            aes.Key = aeskey;
            byte[] encrypted;
            ICryptoTransform crypt = aes.CreateEncryptor(aes.Key, aes.IV);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, crypt, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(src);
                    }
                }
                encrypted = ms.ToArray();
            }
            return encrypted.Concat(aes.IV).ToArray();
        }

        /// <summary>
        /// Расшифровывает криптованное сообщение
        /// </summary>
        /// <param name="shifr">Шифротекст в байтах</param>
        /// <returns>Возвращает исходную строку</returns>
        public static string FromAes256(byte[] shifr)
        {
            byte[] bytesIv = new byte[16];
            byte[] mess = new byte[shifr.Length - 16];

            for (int i = shifr.Length - 16, j = 0; i < shifr.Length; i++, j++)
                bytesIv[j] = shifr[i];

            for (int i = 0; i < shifr.Length - 16; i++)
                mess[i] = shifr[i];

            Aes aes = Aes.Create();
            aes.Key = aeskey;
            aes.IV = bytesIv;
            string text = "";
            byte[] data = mess;
            ICryptoTransform crypt = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream ms = new MemoryStream(data))
            {
                using (CryptoStream cs = new CryptoStream(ms, crypt, CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        text = sr.ReadToEnd();
                    }
                }
            }
            return text;
        }

        /// <summary>
        /// [TEST]
        /// </summary>
        public void WaitForMessage(RichTextBox rtb)
        {
            byte[] BufferMessage = new byte[2048];

            IPAddress ip = IPAddress.Parse(myIp);
            IPEndPoint iep = new IPEndPoint(ip, PortI);
            Socket socket = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(iep);
            socket.Listen(1);
            Socket accepter = socket.Accept();

            for (; ; )
            {
                int bytesRead = accepter.Receive(BufferMessage);
                byte[] ReadyMessage = new byte[bytesRead];
                Array.Copy(BufferMessage, 0, ReadyMessage, 0, bytesRead);

                string recMessage = FromAes256(ReadyMessage);
                accepter.Send(RandomString(7).toBytes());
                if (rtb.InvokeRequired)
                    rtb.Invoke(new Action<string>((t) => rtb.Text += t + Environment.NewLine), recMessage);
                else rtb.Text += recMessage + Environment.NewLine;
            }
        }

        /// <summary>
        /// [TEST]
        /// </summary>
        public void SendMessage(string message)
        {
            byte[] trash = new byte[10];
            IPAddress ip = IPAddress.Parse(clientIp);
            IPEndPoint iep = new IPEndPoint(ip, PortO);
            if (!socket.Connected)
                socket.Connect(iep);
            socket.Send(ToAes256(message));
            //socket.Receive(trash);
        }
    }
}
