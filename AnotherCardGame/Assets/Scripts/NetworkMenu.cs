using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;
using UdpKit;
using System;

public class NetworkMenu : GlobalEventListener
{
    public void StartServer()
    {
        BoltLauncher.StartServer();
        BoltNetwork.LoadScene("NetworkLoad");
    }

    public void StartClient()
    {
        BoltLauncher.StartClient();
        BoltNetwork.LoadScene("NetworkLoad");
    }

    public override void BoltStartDone()
    {
        if(BoltNetwork.IsServer)
        {
            string matchName = Guid.NewGuid().ToString();

            BoltNetwork.SetServerInfo(matchName, null);
        }
    }
}
