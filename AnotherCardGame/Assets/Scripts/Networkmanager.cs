using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Unity;
using UnityEngine.SceneManagement;
using BeardedManStudios.SimpleJSON;

public class Networkmanager : MonoBehaviour
{
    private GameSettings _Settings { get; set; }
    private GameObject ForgeNetworkManager { get; set; }
    private string _IP { get; set; }
    private ushort _Port { get; set; }
    private NetworkManager mgr { get; set; }

    public void Start()
    {
        _Settings = GameObject.Find("GameSettings").GetComponent<GameSettings>();
        _IP = "127.0.0.1.";
        _Port = 15937;
    }

    public void StartServer()
    {
        NetWorker server = new TCPServer(_Settings._PlayerAmmount);
        ((TCPServer)server).Connect();

        ForgeNetworkManager = new GameObject("ForgeNetworkManager");
        mgr = ForgeNetworkManager.AddComponent<NetworkManager>();

        JSONNode MasterServerData = mgr.MasterServerRegisterData(server, "asd1", "asd2", "asd3", "asd4");
        mgr.Initialize(server, _IP, _Port, MasterServerData);

        SceneManager.LoadScene("NetworkLoadScene", LoadSceneMode.Single);
    }

    public void ConnectServer()
    {
        NetWorker client = new TCPClient();
        ((TCPClient)client).Connect(_IP ,_Port);

        ForgeNetworkManager = new GameObject("ForgeNetworkManager");
        mgr = ForgeNetworkManager.AddComponent<NetworkManager>();

        JSONNode MasterServerData = mgr.MasterServerRegisterData(client, "asd1", "asd2", "asd3", "asd4");
        mgr.Initialize(client, _IP, _Port, MasterServerData);

        SceneManager.LoadScene("NetworkLoadScene", LoadSceneMode.Single);
    }
}
