using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

    Vector3 oriPos;

    bool wannaReset = false;
    float timeToReset = 0.4f;
    float resetTimer;
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
	}
    void OnTriggerEnter2D(Collider2D c)
    {
       
        if (c.gameObject.tag == "Player")
        {
            Debug.Log("FIRED");
            Destroy(this.gameObject);

            c.particleSystem.Play();
            Character.alive = false;
            Time.timeScale = 0.1f;
            c.gameObject.GetComponent("Player1").GetComponent<Player1>();
            Destroy(c.gameObject, 0.2f);
            Debug.Log("destroyed");
        }
        else
        {
            wannaReset = true;
        }
    }
    void resetThisThing()
    {
        Debug.Log("reset");
        this.transform.position = oriPos;
        this.gameObject.rigidbody2D.velocity = new Vector2(0, 0);
    }
}
