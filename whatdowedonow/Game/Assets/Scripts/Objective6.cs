using UnityEngine;
using System.Collections;

public class Objective6 : MonoBehaviour {

	public GameObject game;
    Player1 p1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player" && !CharacterAnims.checkObjective6) {
			p1 = other.GetComponent<Player1>();
			if(p1.objectivenr == 5)
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
