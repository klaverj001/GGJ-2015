using UnityEngine;
using System.Collections;

public class ObjectiveEnd : MonoBehaviour {

	//The gameobject that contains the ObjectManager script.
	public GameObject game;
	
	void OnTriggerEnter2D (Collider2D other)
	{
        if (other.gameObject.tag == "Player")
        {
            game.GetComponent<ObjectManager>().Objective(1);
        }
	}
}
