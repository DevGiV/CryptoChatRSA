using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using Data;
using System.Threading;
using System.IO;


namespace Server
{
    class Server
    {
        const int PORT = 6666;
        private static TcpListener listener;
        private static List<ClientData> clients = new List<ClientData>();

        static void Main(string[] args)
        {
            clients = new List<ClientData>();

            Console.Title = "Server";

            StartServer();
        }

        private static void StartServer()
        {
            Console.WriteLine("Запуск сервера по IP-адресу: " + Packet.GetThisIPv4Adress());

            listener = new TcpListener(new IPEndPoint(IPAddress.Parse(Packet.GetThisIPv4Adress()), PORT));

            Console.WriteLine("Сервер запущен. Ожидание подключения Пользователей...\n");

            Thread listenForNewClients = new Thread(ListenForNewClients);
            listenForNewClients.Start();
        }

        private static void ListenForNewClients()
        {
            listener.Start();

            while (true)
            {
                // Как только клиент захочет подключиться, создайте ClientData и поместите его в ClientList
                clients.Add(new ClientData(listener.AcceptTcpClient()));
                Console.WriteLine("Новый Пользователь присоединился");
            }            
        }

        public static void DataIn(object tcpClient)          //clientData
        {
            TcpClient client = (TcpClient)tcpClient;
            NetworkStream clientStream = client.GetStream();
            try
            {
                while (true)
                {
                    byte[] buffer; //Данные
                    byte[] dataSize = new byte[4]; //Длинна

                    int readBytes = clientStream.Read(dataSize, 0, 4);

                    while (readBytes != 4)
                    {
                        readBytes += clientStream.Read(dataSize, readBytes, 4 - readBytes);
                    }
                    var contentLength = BitConverter.ToInt32(dataSize, 0);

                    buffer = new byte[contentLength];
                    readBytes = 0;
                    while (readBytes != buffer.Length)
                    {
                        readBytes += clientStream.Read(buffer, readBytes, buffer.Length - readBytes);
                    }

                    //Данные находятся в буферном массиве
                    DataManagerForIncommingClientData(new Packet(buffer), client);
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine("No: " + ex.ErrorCode + " Message: " + ex.Message);
            }
            catch (IOException)
            {
                ClientData disconnectedClient = GetClientFromList(client);
                Console.WriteLine("Пользователь отключился UserID: " + GetClientFromList(client).UserID);
                clients.Remove(disconnectedClient);
                Console.WriteLine("Пользователь удалился из списка активных пользователей\n");

                //Уведомление других клиентов об отключении клиента.
                foreach (ClientData c in clients)
                {
                    c.SendDataPacketToClient(new Packet(Packet.PacketType.ClientDisconnected, disconnectedClient.UserID + ";" + disconnectedClient.PublicKey));
                    Console.WriteLine(c.UserID + " уведомил, что " + disconnectedClient.UserID + " отключился");
                }
                Console.ReadLine();
                Environment.Exit(0);
            }
        }

        private static void DataManagerForIncommingClientData(Packet p, TcpClient clientSocket)
        {
            ClientData client;
            switch (p.type)
            {
                case Packet.PacketType.Registration:
                    Console.WriteLine("Пользователь хочет присоединиться UserID: " + p.uid + " and Public-Key: " + p.publicKey);
                    client = GetClientFromList(clientSocket);

                    foreach (ClientData c in clients)
                    {
                        if(c.UserID.ToLower() == p.uid.ToLower())
                        {
                            client.SendDataPacketToClient(new Packet(Packet.PacketType.RegistrationFail, "Пользователь с этим UserID уже существует!"));
                        }
                    }
                    client.UserID = p.uid;
                    client.PublicKey = p.publicKey;
                    client.SendDataPacketToClient(new Packet(Packet.PacketType.RegistrationSuccess));

                    //Уведомление клиентов о подключении нового клиента
                    foreach (ClientData c in clients)
                    {
                        if (c.UserID != p.uid)
                        {
                            c.SendDataPacketToClient(new Packet(Packet.PacketType.ClientConnected, p.uid + ";" + p.publicKey));
                        }
                    }
                    break;
                case Packet.PacketType.GetClientList:
                    client = GetClientFromList(clientSocket);
                    Console.WriteLine("Пользователь " + client.UserID + " создается в списке активных пользователей. Генерация...");

                    List<object> dataList = new List<object>();
                    foreach (ClientData c in clients)
                    {
                        if (c.UserID != client.UserID)
                        {
                            dataList.Add(c.UserID + ";" + c.PublicKey);
                        }
                    }
                    client.SendDataPacketToClient(new Packet(Packet.PacketType.ClientList, dataList));
                    break;
                case Packet.PacketType.Message:
                    Console.WriteLine("Пришло сообщение " + p.uid + " в " + p.messageTimeStamp.ToString("HH:mm:ss") + " к " + p.destinationUID + " данные: " + Encoding.UTF8.GetString(p.messageData));
                    foreach (ClientData c in clients)
                    {
                        if(c.UserID == p.destinationUID)
                        {
                            c.SendDataPacketToClient(new Packet(Packet.PacketType.Message, p.messageTimeStamp, p.uid, p.destinationUID, p.messageData));
                            Console.WriteLine("Сообщение отправлено к " + c.UserID);
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Находит соответствующий клиент, который подключен к серверу через этот сокет.
        /// </summary>
        /// <param name="clientSocket">Сокет, с помощью которого клиент подключается к серверу</param>
        /// <returns>Найден клиент, в противном случае null.</returns>
        private static ClientData GetClientFromList(TcpClient tcpClient)
        {
            foreach (ClientData client in clients)
            {
                if (client.TcpClient == tcpClient)
                {
                    return client;
                }
            }

            return null;
        }

        /// <summary>
        /// Находит соответствующий клиент, который подключен к серверу с этим UserID.
        /// </summary>
        /// <param name="uid">UserID Пользователя</param>
        /// <returns>Найден Пользователь, иначе null.</returns>
        private static ClientData GetClientFromList(string uid)
        {
            foreach (ClientData client in clients)
            {
                if (client.UserID == uid)
                {
                    return client;
                }
            }

            return null;
        }
    }
}
