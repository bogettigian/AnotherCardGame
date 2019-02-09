using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour
{

	public Scene actualScene { get; set; }
	
	void Start()
	{
		actualScene = SceneManager.GetActiveScene();
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


}
