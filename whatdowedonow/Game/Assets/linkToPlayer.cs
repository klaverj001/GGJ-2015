using UnityEngine;
using System.Collections;

public class linkToPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    private bool find = false;
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("Player2(Clone)") && !false)
        {
            GameObject f = GameObject.Find("Player2(Clone)");
            this.transform.position = new Vector3(f.transform.position.x, f.transform.position.y, this.transform.position.z);
            find = true;
        }
	}
}
