using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

	private bool isAlive;
	
	// Use this for initialization
	void Start ()
	{
		isAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isAlive && transform.position.y < -10.0f)
		{
			Debug.Log("You lose");
			isAlive = false;
		}
	}
}
