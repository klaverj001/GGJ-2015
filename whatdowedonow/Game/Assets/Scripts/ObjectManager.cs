using UnityEngine;
using System.Collections;

public class ObjectManager : MonoBehaviour {

	private int randomObjectNumber;

	public GameObject goalObject1;
	public GameObject goalObject2;
	public GameObject goalObject3;
	public GameObject goalObject4;
	public GameObject goalObject5;
	public GameObject goalObject6;

	protected int count;

	// Use this for initialization
	void Start () {
		randomObjectNumber = Random.Range (1, 1);
		Debug.Log (randomObjectNumber);

		checkObjectInistiate ();
	}

	void checkObjectInistiate(){
		// Vector3 moet hardcoded gedaan worden per vlag.
		if (randomObjectNumber == 1) {
			if(count == 1){
				Instantiate(goalObject1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			}
			if(count == 2){
				Instantiate(goalObject1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			}
			if(count == 3){
				Instantiate(goalObject1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			}
				}
		if (randomObjectNumber == 2) {
			if(count == 1){
				Instantiate(goalObject1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			}
			if(count == 2){
				Instantiate(goalObject1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			}
			if(count == 3){
				Instantiate(goalObject1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			}
		}
		if (randomObjectNumber == 3) {
			if(count == 1){
				Instantiate(goalObject1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			}
			if(count == 2){
				Instantiate(goalObject1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			}
			if(count == 3){
				Instantiate(goalObject1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			}
		}
		if (randomObjectNumber == 4) {
			if(count == 1){
				Instantiate(goalObject1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			}
			if(count == 2){
				Instantiate(goalObject1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			}
			if(count == 3){
				Instantiate(goalObject1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			}
		}
		if (randomObjectNumber == 5) {
			if(count == 1){
				Instantiate(goalObject1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			}
			if(count == 2){
				Instantiate(goalObject1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			}
			if(count == 3){
				Instantiate(goalObject1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			}
		}
		if (randomObjectNumber == 6) {
			if(count == 1){
				Instantiate(goalObject1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			}
			if(count == 2){
				Instantiate(goalObject1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			}
			if(count == 3){
				Instantiate(goalObject1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			}
		}
		}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Objective1()
	{
		if (randomObjectNumber == 1) 
		{
			Debug.Log ("Objective 1 reached!");
		}
	}
}
