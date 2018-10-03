using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	[SerializeField] private GameObject pausePanel;

	public static bool GamePaused;
	
	void Start()
	{
		pausePanel.SetActive(false);
	}
	void Update()
	{
		Debug.Log(Time.timeScale);
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if(!GamePaused)
			{
				PauseGame();
			}
			else
			{
				ContinueGame();
			}	
		}
	}

	private void FixedUpdate()
	{
		
		
	}

	private void PauseGame()
	{
		Debug.Log("DAAAAAALE");
		pausePanel.SetActive(true);
		Time.timeScale = 0;
		GamePaused = true;

		//Disable scripts that still work while timescale is set to 0
	} 
	private void ContinueGame()
	{
		Debug.Log("Tokio tomare");
		pausePanel.SetActive(false);
		Time.timeScale = 1;
		GamePaused = false;

		//enable the scripts again
	}
}
