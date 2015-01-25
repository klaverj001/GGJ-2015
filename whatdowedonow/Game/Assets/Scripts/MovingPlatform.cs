using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	//Empty gameobject platform needed for scaling problem. When the platform is scaled, the player will not scale when it jumps on the platform.
	//The player will become a child of the empty gameobject and the empty gameobject will become a child of the platform.
	public GameObject emptyPlatform;

	//Floats used for the calculation of movement and speed
	private float useSpeed;
	public float directionSpeed = 9.0f;
	float origX;
	public float distance = 10.0f;

	// Use this for initialization
	void Start () 
	{
		origX = transform.position.x;
		useSpeed = -directionSpeed;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(origX - transform.position.x > distance)
		{
			useSpeed = directionSpeed; //flip direction
		}
		else if(origX - transform.position.x < -distance)
		{
			useSpeed = -directionSpeed; //flip direction
		}

		transform.Translate(useSpeed*Time.deltaTime,0,0);
	}
	
	//OncollisionEnter
	void OnCollisionStay2D (Collision2D other) 
	{
				if (other.gameObject.GetComponent ("Player1")) {
						emptyPlatform.transform.parent = transform;
				}
	}
	//OncollisionExit
	void OnCollisionExit2D (Collision2D other) 
	{
		if (other.gameObject.GetComponent("Player1")) 
		{
			other.transform.parent = null;
		}
		
	}
}
