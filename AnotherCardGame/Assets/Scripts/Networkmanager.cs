using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking;

public class Networkmanager : MonoBehaviour
{
    private GameSettings _Settings { get; set; }
    private string _IP { get; set; }
    private ushort _Port { get; set; }

    public void Start()
    {
        _Settings = GameObject.Find("GameSettings").GetComponent<GameSettings>();
        _IP = "192.168.1.10";
        _Port = 8085;
    }

    public void StartServer()
    {
        TCPServer server = new TCPServer(_Settings._PlayerAmmount);
        server.Connect(_IP, _Port);
    }

    public void ConnectServer()
    {
        TCPClient client = new TCPClient();
        client.Connect(_IP ,_Port);
    }
}
