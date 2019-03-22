using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;
using UdpKit;
using System;
using UnityEngine.SceneManagement;

public class NetworkMenu : GlobalEventListener
{
    public void StartServer()
    {
        SceneManager.LoadScene("NetworkLoadScene", LoadSceneMode.Single);
        BoltLauncher.StartServer();
    }

    public void StartClient()
    {
        SceneManager.LoadScene("NetworkLoadScene", LoadSceneMode.Single);
        BoltLauncher.StartClient();
    }

    public override void BoltStartDone()
    {
        if(BoltNetwork.IsServer)
        {
            string matchName = Guid.NewGuid().ToString();

            BoltNetwork.SetServerInfo(matchName, null);
        }
    }

    public override void SessionListUpdated(Map<Guid, UdpSession> sessionList)
    {
        Debug.LogFormat("Session list updated: {0} total sessions", sessionList.Count);

        foreach (var session in sessionList)
        {
            UdpSession photonSession = session.Value as UdpSession;

            if (photonSession.Source == UdpSessionSource.Photon)
            {
                BoltNetwork.Connect(photonSession);
            }
        }
    }
}
