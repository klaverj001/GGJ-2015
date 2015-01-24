using UnityEngine;
using System.Collections;

public class Crusher : MonoBehaviour {
	
	private float useSpeed;
	public float directionSpeed = 9.0f;
	float origY;
	public float distance = 10.0f;
	private float timer = 0f;
	public float timerSeconds = 5.0f;

	// Use this for initialization
	void Start () 
	{
		origY = transform.position.y;
		useSpeed = -directionSpeed;
	}
	
	// Update is called once per frame
	void Update () 
	{	
		timer -= Time.deltaTime;

		if (timer <= 0) 
		{
			if (origY - transform.position.y > distance) {
				useSpeed = directionSpeed; //flip direction
				timer = timerSeconds;
			} else if (origY - transform.position.y < -distance) {
				useSpeed = -directionSpeed; //flip direction
				timer = timerSeconds;
			}

			transform.Translate (0, useSpeed * Time.deltaTime, 0);
		}
	}
}
