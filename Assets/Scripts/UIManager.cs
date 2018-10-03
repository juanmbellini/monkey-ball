using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	public GameController GM;
	[SerializeField] private GameObject pausePanel;

	// Use this for initialization
	void Start ()
	{
		//--------------------------------------------------------------------------
		// Game Settings Related Code

		GM = GameObject.Find("GameController").GetComponent<GameController>();
		pausePanel = GameObject.Find("PauseMenuPanel").GetComponent<GameObject>();
		pausePanel.SetActive(false);

	}
	
	// Update is called once per frame
	void Update ()
	{
		ScanForKeyStroke();
	}

	void ScanForKeyStroke()
	{
		if(Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (!pausePanel.activeInHierarchy) 
			{
				PauseGame();
			}
			if (pausePanel.activeInHierarchy) 
			{
				ContinueGame();   
			}
		}
	}

	private void PauseGame()
	{
		Time.timeScale = 0;
		pausePanel.SetActive(true);
		//Disable scripts that still work while timescale is set to 0
	} 
	private void ContinueGame()
	{
		Time.timeScale = 1;
		pausePanel.SetActive(false);
		//enable the scripts again
	}
}
