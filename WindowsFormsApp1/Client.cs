using Packets;
using Game1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    public class Client
    {
        private TcpClient m_TcpClient;
        private UdpClient m_UdpClient;
        private NetworkStream m_Stream;
        private BinaryWriter m_Writer;
        private BinaryReader m_Reader;
        private ClientForm m_clientForm;
        private BinaryFormatter m_Formatter;

        public Client()
        {
            m_TcpClient = new TcpClient();
            m_UdpClient = new UdpClient();
        }

        public bool Connect(string ipAddress, int port)
        {
            try
            {
                m_TcpClient.Connect(ipAddress, port);
                m_Stream = m_TcpClient.GetStream();
                m_Writer = new BinaryWriter(m_Stream, Encoding.UTF8);
                m_Reader = new BinaryReader(m_Stream, Encoding.UTF8);
                m_Formatter = new BinaryFormatter();

                //m_UdpClient.Connect(ipAddress, port);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return false;
            }
        }

        public void Run()
        {
            m_clientForm = new ClientForm(this);

            Thread tcpThread = new Thread(() => { TcpProcessServerResponse(); });
            tcpThread.Start();

            //Thread udpThread = new Thread(() => { UdpProcessServerResponse(); });
            //udpThread.Start();
            //Login(); //TODO FIX

            m_clientForm.ShowDialog();
        }

        public void TcpSendMessage(Packet packet)
        {
            Console.WriteLine("TCP SendMessage Processing");
            MemoryStream memoryStream = new MemoryStream();
            m_Formatter.Serialize(memoryStream, packet);
            byte[] buffer = memoryStream.GetBuffer();
            m_Writer.Write(buffer.Length);
            m_Writer.Write(buffer);
            m_Writer.Flush();
        }

        public void UdpSendMessage(Packet packet)
        {
            Console.WriteLine("UDP SendMessage Processing");
            MemoryStream memoryStream = new MemoryStream();
            m_Formatter.Serialize(memoryStream, packet);
            byte[] buffer = memoryStream.GetBuffer();
            m_UdpClient.Send(buffer, buffer.Length);
        }

        public void Login() //might not be right TODO fix
        {
            Console.WriteLine("Login Processing");
            Packet packet = new LoginPacket((IPEndPoint)m_UdpClient.Client.LocalEndPoint);
            MemoryStream memoryStream = new MemoryStream();
            m_Formatter.Serialize(memoryStream, packet);
            byte[] buffer = memoryStream.GetBuffer();
            m_Writer.Write(buffer.Length);
            m_Writer.Write(buffer);
            m_Writer.Flush();
        }

        public void Close()
        {
            m_TcpClient.GetStream().Close();
            m_TcpClient.Close();
            //m_UdpClient.Close();
            Console.WriteLine("Connection ending");
        }

        public void RunGame()
        {
            using (var game = new TankGame())
                game.Run();
        }

        private void TcpProcessServerResponse()
        {
            try
            {
                int numberOfBytes;
                while ((numberOfBytes = m_Reader.ReadInt32()) != -1)
                {
                    byte[] buffer = m_Reader.ReadBytes(numberOfBytes);
                    MemoryStream memoryStream = new MemoryStream(buffer);
                    Packet packet = m_Formatter.Deserialize(memoryStream) as Packet;

                    switch (packet.packetType)
                    {
                        case PacketType.CHATMESSAGE:
                            ChatMessagePacket chatMessage = (ChatMessagePacket)packet;
                            m_clientForm.UpdateChatWindow(chatMessage.message);
                            break;
                        case PacketType.PRIVATEMESSAGE:
                            break;
                        case PacketType.CLIENTNAME:
                            ClientNamePacket clientName = (ClientNamePacket)packet;
                            m_clientForm.UpdatePeopleList(clientName.name);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("Client TCP Read Method exception: " + e.Message);
            }
        }

        private void UdpProcessServerResponse()
        {
            try
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
                while (true)
                {
                    byte[] bytes = m_UdpClient.Receive(ref endPoint);
                    MemoryStream memoryStream = new MemoryStream(bytes);
                    Packet packet = m_Formatter.Deserialize(memoryStream) as Packet;
                    //Do something with the data.
                    break;
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("Client UDP Read Method exception: " + e.Message);
            }

        }
    }
}