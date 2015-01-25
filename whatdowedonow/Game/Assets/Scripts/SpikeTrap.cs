using UnityEngine;
using System.Collections;

public class SpikeTrap : MonoBehaviour
{

		Vector3 oriPos;
		private float timer = 0f;
		public float timerSeconds = 5.0f;
		private bool timerActive = false;
		private Collider2D player;
		Player1 p1;
		// Use this for initialization
		void Start ()
		{
				oriPos = this.transform.position;
		}
	
		// Update is called once per frame
		void Update ()
		{
		if (timerActive == true) 
		{
			timer += Time.deltaTime;
			
			if(timer >= timerSeconds)
			{
				timerActive = false;
				player.gameObject.GetComponent ("Player1").GetComponent<Player1> ().Respawn ();
				timer = 0f;
				player.particleSystem.Stop();
				p1 = player.GetComponent<Player1>();
				p1.setPlayerAlive(true);
				//GameObject.Find("Game").GetComponent<ObjectManager>().Objective();
			}
		}
		}


		void OnTriggerEnter2D (Collider2D other)
		{
				if (other.gameObject.GetComponent ("Player1")) {
						other.particleSystem.Play();
						Player1 p1 = other.GetComponent<Player1>();	
						p1.setPlayerAlive(false);
						timerActive = true;
						this.player = other;
				}
		}

	
}
