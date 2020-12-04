using System;
using System.Net;

namespace Packets
{
    public enum PacketType
    {
        CHATMESSAGE = 0,
        PRIVATEMESSAGE,
        CLIENTNAME,
        LOGIN,
        TANK,
    }

    [Serializable]
    public abstract class Packet
    {
        public PacketType packetType
        {
            get; protected set;
        }
    }

    [Serializable]
    public class ChatMessagePacket : Packet
    {
        public string message;

        public ChatMessagePacket(string _message)
        {
            message = _message;
            packetType = PacketType.CHATMESSAGE;
        }
    }

    [Serializable]
    public class ClientNamePacket : Packet
    {
        public string name;

        public ClientNamePacket(string _name)
        {
            name = _name;
            packetType = PacketType.CLIENTNAME;
        }
    }

    [Serializable]
    public class LoginPacket : Packet
    {
        public IPEndPoint IPEndPoint;

        public LoginPacket(IPEndPoint _IPEndPoint)
        {
            IPEndPoint = _IPEndPoint;
            packetType = PacketType.LOGIN;
        }
    }

    [Serializable]
    public class TankPacket : Packet
    {
        public float tankPositionX;
        public float tankPositionY;
        public float tank2PositionX;
        public float tank2PositionY;
        public int tankRotation;
        public int tank2Rotation;

        public TankPacket(float _tankPositionX, float _tankPositionY, float _tank2PositionX, float _tank2PositionY, int _tankRotation, int _tank2Rotation)
        {
            tankPositionX = _tankPositionX;
            tankPositionY = _tankPositionY;
            tank2PositionX = _tank2PositionX;
            tank2PositionY = _tank2PositionY;
            tankRotation = _tankRotation;
            tank2Rotation = _tank2Rotation;
            packetType = PacketType.TANK;
        }
    }
}