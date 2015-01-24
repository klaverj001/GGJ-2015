using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
    }
}
