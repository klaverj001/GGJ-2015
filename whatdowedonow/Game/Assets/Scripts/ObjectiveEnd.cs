using UnityEngine;
using System.Collections;

public class ObjectiveEnd : MonoBehaviour {

	//The gameobject that contains the ObjectManager script.
	public GameObject game;
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.GetComponent ("Player1")) 
		{
			game.GetComponent<ObjectManager>().Objective1();
		}
	}
}
