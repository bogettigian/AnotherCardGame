using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Unity;
using UnityEngine.SceneManagement;
using BeardedManStudios.SimpleJSON;

// ejemplo sacado de:
// https://github.com/guser9822/unity-forge-markui

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

        Connected(server);

        SceneManager.LoadScene("NetworkLoadScene", LoadSceneMode.Single);
    }

    public void ConnectServer()
    {
        NetWorker client = new TCPClient();
        ((TCPClient)client).Connect(_IP ,_Port);

        Connected(client);
    }

    private void Connected(NetWorker networker)
    {
        if (!networker.IsBound){
            print("Networker failed to bind");
            return;
        }

        if(mgr == null && ForgeNetworkManager == null){
            ForgeNetworkManager = new GameObject("ForgeNetworkManager");
            mgr = ForgeNetworkManager.AddComponent<NetworkManager>();
        }else{
            mgr = Instantiate(ForgeNetworkManager).GetComponent<NetworkManager>();
        }

        mgr.Initialize(networker);
    }
}
