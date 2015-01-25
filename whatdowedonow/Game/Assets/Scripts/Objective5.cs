using UnityEngine;
using System.Collections;

public class Objective5 : MonoBehaviour {

	//The gameobject that contains the ObjectManager script.
	public GameObject game;
	public float timer = 30.0f;

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
			if(timer > 0)
			{
				game.GetComponent<ObjectManager>().Objective(5);
			}
		}
	}
}
