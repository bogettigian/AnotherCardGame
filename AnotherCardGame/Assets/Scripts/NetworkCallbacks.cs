using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;

[BoltGlobalBehaviour]
public class NetworkCallbacks : GlobalEventListener
{
    public GameObject Card1;
    public GameObject Card2;
    public GameObject Card3;

    // Start is called before the first frame update
    void Start()
    {
        Card1.SetActive(false);
        Card2.SetActive(false);
        Card3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
