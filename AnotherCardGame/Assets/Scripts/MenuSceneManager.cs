using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour
{
    private GameSettings _Settings { get; set; }

    public void Start()
    {
        _Settings = GameObject.Find("GameSettings").GetComponent<GameSettings>();
    }

    public void goToTrucoOptionsScene()
	{
		SceneManager.LoadScene("TrucoOptionsScene", LoadSceneMode.Single);
	}

	public void goToTrucoScene()
	{
		SceneManager.LoadScene("TrucoScene", LoadSceneMode.Single);
	}

	public void goToChinScene()
	{
		
	}

	public void goToLibreScene()
	{
		
	}

    public void GoToNetworkManuScene(int PlayerAmmount)
    {
        _Settings._PlayerAmmount = PlayerAmmount;
        SceneManager.LoadScene("NetworkMenuScene", LoadSceneMode.Single);
    }
}
