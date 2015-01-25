using UnityEngine;
using System.Collections;

public class SpikeTrap : MonoBehaviour {

    Vector3 oriPos;
	bool waitActive = false;
    // Use this for initialization
	void Start () {
        oriPos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Wait(){
		Debug.Log("wait");
		waitActive = true;
		yield return new WaitForSeconds(50);
		waitActive = false;
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("in on trigger");
        if (other.gameObject.GetComponent("Player1"))
        {
			if(networkView.isMine){
				if(!waitActive){
					other.particleSystem.Play();
					StartCoroutine(Wait());
					//other.particleSystem.Stop();
				}
            	//Character.alive = false;
            	Time.timeScale = 0.1f;
            	other.gameObject.GetComponent("Player1").GetComponent<Player1>().Respawn();

            	//Destroy(other.gameObject, 0.1f);
			}
        }
	}

	
}
