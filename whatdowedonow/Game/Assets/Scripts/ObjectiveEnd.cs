using UnityEngine;
using System.Collections;

public class ObjectiveEnd : MonoBehaviour {

	//The gameobject that contains the ObjectManager script.
	public GameObject game;
	
	void OnTriggerEnter2D (Collider2D other)
	{
        if (other.gameObject.tag == "Player")
        {
			Player1 p1 = other.GetComponent<Player1>();
			if(p1.objectivenr == 1)
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
