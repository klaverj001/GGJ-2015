using UnityEngine;
using System.Collections;

public class Objective3 : MonoBehaviour {

	//The gameobject that contains the ObjectManager script.
	public GameObject game;
	private float timer = 0f;
	public float timerSeconds = 5.0f;
	private bool timerActive = false;


	void Update () 
	{
		if (timerActive == true) 
		{
			timer += Time.deltaTime;

			if(timer >= timerSeconds)
			{
				timerActive = false;
				game.GetComponent<ObjectManager>().Objective(3);
			}
		}
	}


	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			timerActive = true;
		}
	}

	void OnCollisionExit2D (Collision2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			timerActive = false;
			timer = 0f;
		}
	}
}
