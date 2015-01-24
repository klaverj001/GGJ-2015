using UnityEngine;
using System.Collections;

public class CrusherEmpty : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//OncollisionEnter
	void OnCollisionEnter2D (Collision2D other) 
	{
		if (other.gameObject.GetComponent("Player1")) 
		{
			Destroy(other.gameObject);
		}
	}
}
