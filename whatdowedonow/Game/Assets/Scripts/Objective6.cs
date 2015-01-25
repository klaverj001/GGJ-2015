using UnityEngine;
using System.Collections;

public class Objective6 : MonoBehaviour {
	
	public GameObject game;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player" && CharacterAnims.checkObjective6 == false) {
						game.GetComponent<ObjectManager> ().Objective (6);
				} else if (other.gameObject.tag == "Player" && CharacterAnims.checkObjective6 == true) {
			Debug.Log("LEVEL FAILED BIATCH");
				}
	}
}
