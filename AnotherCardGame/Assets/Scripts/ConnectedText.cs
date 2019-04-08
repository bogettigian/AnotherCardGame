using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking;

public class ConnectedText : ConnectedTextBehavior
{


    void Start()
    {
        if(networkObject.IsServer){
            networkObject.players = 0;
        }
        networkObject.players++;
        gameObject.GetComponent<Text>().text = "Players: " + networkObject.players;
        networkObject.SendRpc(RPC_ADD_CONNECTED_PLAYER, Receivers.All);
    }


    public override void addConnectedPlayer(RpcArgs args){
        print("se llamo rpc");
        print(networkObject.players);
        gameObject.GetComponent<Text>().text = "Players: " + (networkObject.players + 1);
    }
}
