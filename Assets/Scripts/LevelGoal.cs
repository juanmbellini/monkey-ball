using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGoal : MonoBehaviour {

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "Sphere")
		{
			Debug.Log("Win");
		}
	}
}
