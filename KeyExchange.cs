using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace CryptChatAsync
{
    /// <summary>
    /// Предназначен для соединения узлов и обмена ключами шифрования
    /// </summary>
    class KeyExchange
    {
        private string publicRsaKey;
        private AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
        private RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

        /// <summary>
        /// Ожидание публичного ключа RSA и отправка зашифрованного им ключа AES-256
        /// </summary>
        /// <param name="myip">Ip-адрес сетевой карты, к которой ожидается подключение</param>
        public Task<bool> WaitForKeyAsync(string myip)
        {
            byte[] receiveBytes = new byte[256], sendingBytes = new byte[256];
            return Task.Run(() =>
            {
                try
                {
                    IPAddress ip = IPAddress.Parse(myip);
                    IPEndPoint iep = new IPEndPoint(ip, 45402);
                    Socket socketListener = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    socketListener.Bind(iep);
                    socketListener.Listen(1);
                    Socket socketClient = socketListener.Accept();
                    CryptedMessages.clientIp = socketClient.RemoteEndPoint.ToString().Split(':')[0];
                    CryptedMessages.myIp = socketClient.LocalEndPoint.ToString().Split(':')[0];
                    socketClient.Receive(receiveBytes);
                    publicRsaKey = receiveBytes.toString();
                    rsa.FromXmlString(publicRsaKey);
                    aes.GenerateKey();
                    CryptedMessages.aeskey = aes.Key;
                    sendingBytes = rsa.Encrypt(aes.Key, false);
                    socketClient.Send(sendingBytes);
                    socketClient.Shutdown(SocketShutdown.Both);
                    CryptedMessages.PortI = 45600;
                    CryptedMessages.PortO = 45700;
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }


        /// <summary>
        /// Устанавливает соединение с узлом, получает зашифрованный AES ключ
        /// и расшифровывает его закрытым RSA ключом
        /// </summary>
        /// <param name="clientIp">IP узла</param>
        public Task<bool> ConnectAsync(string clientIp)
        {
            byte[] receiveBytes = new byte[128], decryptedBytes;
            return Task.Run(() =>
            {
                try
                {
                    string privateRsaKey = rsa.ToXmlString(true);
                    publicRsaKey = rsa.ToXmlString(false);
                    IPAddress ip = IPAddress.Parse(clientIp);
                    IPEndPoint iep = new IPEndPoint(ip, 45402);
                    Socket socket = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    socket.Connect(iep);
                    socket.Send(publicRsaKey.toBytes());
                    socket.Receive(receiveBytes);
                    rsa.FromXmlString(privateRsaKey);
                    decryptedBytes = rsa.Decrypt(receiveBytes, false);
                    CryptedMessages.aeskey = decryptedBytes;
                    socket.Shutdown(SocketShutdown.Both);
                    CryptedMessages.clientIp = socket.RemoteEndPoint.ToString().Split(':')[0];
                    CryptedMessages.myIp = socket.LocalEndPoint.ToString().Split(':')[0];
                    CryptedMessages.PortI = 45700;
                    CryptedMessages.PortO = 45600;
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

    }
}
