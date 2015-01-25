using UnityEngine;
using System.Collections;

public class Objective3 : MonoBehaviour {

	//The gameobject that contains the ObjectManager script.
	public GameObject game;
	private float timer = 0f;
	public float timerSeconds = 5.0f;
	private bool timerActive = false;
	Player1 p1;


	void Update () 
	{
		if (timerActive == true) 
		{
			timer += Time.deltaTime;

			if(timer >= timerSeconds)
			{
				timerActive = false;
				game.GetComponent<ObjectManager>().Objective(3);
				if(p1.objectivenr == 3)
				{
					p1.Level1 = false;
					if(p1.Level2 == true)
					{
						p1.Level2 = false;
						p1.Level3 = true;
					}
					else
					{
						p1.Level2 = true;
					}
					p1.Respawn();
				}
			}
		}
	}


	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			p1 = other.gameObject.GetComponent<Player1>();
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
