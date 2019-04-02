using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour
{
    private bool _IsCopy { get; set; }

    public int _PlayerAmmount { get; set; }

    private void Awake()
    {
        if(!_IsCopy)
        {
            _IsCopy = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
