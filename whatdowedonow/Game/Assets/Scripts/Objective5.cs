using UnityEngine;
using System.Collections;

public class Objective5 : MonoBehaviour {

	//The gameobject that contains the ObjectManager script.
	public GameObject game;
	public float timer = 30.0f;
	Player1 p1;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer -= Time.deltaTime;

		if (timer <= 0) 
		{
			Debug.Log ("If you had objective 5, you failed!");
			timer = 30.0f;
		}
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			p1 = other.gameObject.GetComponent<Player1>();
			if(timer > 0)
			{
				if(p1.objectivenr == 4)
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
				};
			}
		}
	}
}
