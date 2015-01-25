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
				//player.gameObject.GetComponent ("Player1").GetComponent<Player1> ().Respawn ();

				timer = 0f;
				p1.particleSystem.Stop();
				p1.Respawn();
				p1.setPlayerAlive(true);
				GameObject.Find("Game").GetComponent<ObjectManager>().randomNumber();
			}
		}
		}


		void OnTriggerEnter2D (Collider2D other)
		{
			if (other.gameObject.GetComponent ("Player1")) {
				other.particleSystem.Play();
				p1 = other.GetComponent<Player1>();	
				p1.setPlayerAlive(false);
				timerActive = true;
				this.player = other;

			if(p1.objectivenr == 2)
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
