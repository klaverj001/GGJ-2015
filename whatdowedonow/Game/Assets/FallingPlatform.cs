using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour {
    float timeToDrop = 0.8f;
    float dropTimer;
    bool wannadrop = false;

	// Use this for initialization
	void Start () {
        dropTimer = timeToDrop;
	}
	
	// Update is called once per frame
	void Update () {
        if (wannadrop)
        {
            dropTimer -= Time.deltaTime;
            if (dropTimer <= 0.0f)
            {
                this.transform.FindChild("Spikes").rigidbody2D.AddForce(new Vector2(0, -10.0f), ForceMode2D.Impulse);
                wannadrop = false;
                dropTimer = timeToDrop;
            }
        }
	}
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            Debug.Log("We gonna DROP");
            wannadrop = true;
        }
    }
}
