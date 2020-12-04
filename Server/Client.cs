using Packets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Client
    {
        private Socket m_Socket;
        private NetworkStream m_Stream;
        private BinaryReader m_Reader;
        private BinaryWriter m_Writer;
        private BinaryFormatter m_Formatter;
        private object m_ReadLock;
        private object m_WriteLock;

        public IPEndPoint endPoint;

        public Client(Socket socket)
        {
            m_Formatter = new BinaryFormatter();
            m_Socket = socket;
            m_Stream = new NetworkStream(m_Socket, true);
            m_Reader = new BinaryReader(m_Stream, Encoding.UTF8);
            m_Writer = new BinaryWriter(m_Stream, Encoding.UTF8);
            m_WriteLock = new Object();
            m_ReadLock = new Object();
        }

        public void Close()
        {
            m_Stream.Close();
            m_Reader.Close();
            m_Writer.Close();
            m_Socket.Close();
        }

        public Packet Read()
        {
            lock (m_ReadLock)
            {
                //return m_Reader.ReadLine();
                int numberOfBytes;
                if ((numberOfBytes = m_Reader.ReadInt32()) != -1)
                {
                    byte[] buffer = m_Reader.ReadBytes(numberOfBytes);
                    MemoryStream memoryStream = new MemoryStream(buffer);
                    Packet packet = m_Formatter.Deserialize(memoryStream) as Packet;
                    return packet;
                }

                Console.WriteLine("Error in Client Read");
                return null;
            }
        }

        public void Send(Packet packet)
        {
            lock (m_WriteLock)
            {
                Console.WriteLine("Send Started");
                MemoryStream memoryStream = new MemoryStream();
                m_Formatter.Serialize(memoryStream, packet);
                byte[] buffer = memoryStream.GetBuffer();
                m_Writer.Write(buffer.Length);
                m_Writer.Write(buffer);
                m_Writer.Flush();
            }
        }
    }
}