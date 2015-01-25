using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

    Vector3 oriPos;

    bool wannaReset = false;
    float timeToReset = 0.4f;
    float resetTimer;

	private float timer = 0f;
	public float timerSeconds = 2.0f;
	private bool timerActive = false;
	private Collider2D player;
	Player1 p1;
	// Use this for initialization
	void Start () {
        oriPos = this.transform.position;
        resetTimer = timeToReset;
	}
	
	// Update is called once per frame
	void Update () {
        if (wannaReset)
        {
            resetTimer -= Time.deltaTime;
            if (resetTimer <= 0.0f)
            {
                resetThisThing();
                resetTimer = timeToReset;
                wannaReset = false;
            }
        }
		if (timerActive == true) 
		{
			timer += Time.deltaTime;
			
			if(timer >= timerSeconds)
			{
				timerActive = false;
				player.gameObject.GetComponent ("Player1").GetComponent<Player1>().Respawn ();
				timer = 0f;
				player.particleSystem.Stop();
				p1 = player.GetComponent<Player1>();
				p1.setPlayerAlive(true);
			}
		}
	}
    void OnTriggerEnter2D(Collider2D c)
    {
       
		if (c.gameObject.tag == "Player")
        {
			c.particleSystem.Play();
			Player1 p1 = c.GetComponent<Player1>();	
			p1.setPlayerAlive(false);
			timerActive = true;
			this.player = c;
        }
        else
        {
            wannaReset = true;
        }
    }
    void resetThisThing()
    {
        this.transform.position = oriPos;
        this.gameObject.rigidbody2D.velocity = new Vector2(0, 0);
    }
}
