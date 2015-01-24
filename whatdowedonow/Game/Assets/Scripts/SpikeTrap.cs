using UnityEngine;
using System.Collections;

public class SpikeTrap : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("in on trigger");
		if(other.gameObject.GetComponent("Player1")){
			other.particleSystem.Play();
			Character.alive = false;
			Time.timeScale = 0.1f;
			other.gameObject.GetComponent("Player1").GetComponent<Player1>();
			Destroy(other.gameObject, 0.2f);
			Debug.Log("destroyed");
		}
	}
}
