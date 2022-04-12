using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerHandle 
{

    public static void WelcomeReceived(int _fromClient, Packet _packet)
    {
        int _clientIdCheck = _packet.ReadInt();
        string _username = _packet.ReadString();

        Debug.Log($"{MyServer.clients[_fromClient].tcp.socket.Client.RemoteEndPoint} connected succesfully and is now player {_fromClient}.");
        if (_fromClient != _clientIdCheck)
        {
            Debug.Log($"player \"{_username}\"(ID: {_fromClient}) has assumed the wrong client ID ({_clientIdCheck})!");
        }
        MyServer.clients[_fromClient].SendIntoGame(_username);
    }

    public static void PlayerMovement(int _formClient, Packet _packet)
    {
        /*bool[] _inputs = new bool[_packet.ReadInt()];
        for (int i = 0; i < _inputs.Length; i++)
        {
            _inputs[i] = _packet.ReadBool();
        }*/
        Vector3 _position = _packet.ReadVector3();
        Quaternion _rotation = _packet.ReadQuaternion();

        MyServer.clients[_formClient].player.SetInput(_position, _rotation);
        Debug.Log("cam position" + _position + "cam rotation" + _rotation);
    }
}
