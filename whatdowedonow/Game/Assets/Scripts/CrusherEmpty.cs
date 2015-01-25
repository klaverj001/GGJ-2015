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
			if(networkView.isMine){
				Character.alive = false;
				Time.timeScale = 0.1f;
				other.gameObject.GetComponent("Player1").GetComponent<Player1>();
				Destroy(other.gameObject, 0.1f);
			}
		}
	}
}
