using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Server
{
    class ServerHandle
    {
        public static void WelcomeReceived(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            string _username = _packet.ReadString();

            Console.WriteLine($"{MyServer.clients[_fromClient].tcp.socket.Client.RemoteEndPoint} connected succesfully and is now player {_fromClient}.");
            if (_fromClient != _clientIdCheck)
            {
                Console.WriteLine($"player \"{_username}\"(ID: {_fromClient}) has assumed the wrong client ID ({_clientIdCheck})!");
            }
            MyServer.clients[_fromClient].SendIntoGame(_username);
        }

       public static void PlayerMovement(int _formClient, Packet _packet)
        {
            bool[] _inputs = new bool[_packet.ReadInt()];
            for (int i = 0; i < _inputs.Length; i++)
            {
                _inputs[i] = _packet.ReadBool();
            }
            Quaternion _rotation = _packet.ReadQuaternion();

            MyServer.clients[_formClient].player.SetInput(_inputs, _rotation);
        }
    }
}
