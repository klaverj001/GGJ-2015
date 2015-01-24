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
        }
    }
}
