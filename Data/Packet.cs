using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    [Serializable]
    public class Packet
    {
        public PacketType type;
        public string uid;
        public string destinationUID;
        public string publicKey;
        public string singleStringData;
        public byte[] messageData;
        public DateTime messageTimeStamp;
        public List<object> data;

        public Packet(PacketType type)
        {
            this.type = type;
            this.data = new List<object>();
        }

        public Packet(PacketType type, string singleStringData)
        {
            this.type = type;
            this.singleStringData = singleStringData;
        }

        public Packet(PacketType type, List<object> dataList)
        {
            this.type = type;
            this.data = dataList;
        }

        public Packet(PacketType type, string uid, string publicKey)
        {
            this.type = type;
            this.uid = uid;
            this.publicKey = publicKey;
        }      

        public Packet(PacketType type, DateTime messageTimeStamp, string uid, string destinationUID, byte[] messageData)
        {
            this.type = type;
            this.messageTimeStamp = messageTimeStamp;
            this.uid = uid;
            this.destinationUID = destinationUID;
            this.messageData = messageData;
            
        }

        /// <summary>
        /// Сериализует заданный массив байтов в объект пакета (из JSON обратно в объект).
        /// </summary>
        /// <param name="packetType">Packet-Objekt как ByteArray</param>
        public Packet(byte[] packetBytes)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(packetBytes);

            Packet p = (Packet)bf.Deserialize(ms); //Десериализует ByteArray в объект (из JSON в объект)

            ms.Close();

            type = p.type;
            uid = p.uid;
            destinationUID = p.destinationUID;
            publicKey = p.publicKey;
            messageData = p.messageData;
            data = p.data;
            singleStringData = p.singleStringData;
            messageTimeStamp = p.messageTimeStamp;
        }

        /// <summary>
        /// Возвращает собственный IPv4-адрес. Если адрес не назначен, возвращается 127.0.0.1.
        /// </summary>
        /// <returns>IPv4-Adress как string</returns>
        public static string GetThisIPv4Adress()
        {
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (IPAddress ip in ips)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            return "127.0.0.1";
        }

        /// <summary>
        /// Сериализирует этот объект в ByteArray (аналогично тому, как PHP сериализует объект в JSON).
        /// </summary>
        /// <returns>Сериализованный массив байтов этого объекта</returns>
        public byte[] ConvertToBytes()
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();

            bf.Serialize(ms, this); //Сериализует этот объект в массив байтов (работает аналогично JSON)
            byte[] serializedObject = ms.ToArray();
            Console.WriteLine(ms.Length);
            ms.Close();

            return serializedObject;
        }

        public enum PacketType
        {
            Registration,
            RegistrationSuccess,
            RegistrationFail,
            Message,
            ClientDisconnected,
            ClientConnected,
            GetClientList,
            ClientList
        }
    }
}
