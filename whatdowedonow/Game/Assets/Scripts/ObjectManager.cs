using UnityEngine;
using System.Collections;

public class ObjectManager : MonoBehaviour {

	private int randomObjectNumber;
	private int firstTimeObjective2 = 1;

	public GameObject goalObject1;
	public GameObject goalObject2;
	public GameObject goalObject3;
	public GameObject goalObject4;
	public GameObject goalObject5;
	public GameObject goalObject6;
	public GameObject player;

	protected int count;

	// Use this for initialization
	void Start () {

		randomObjectNumber = Random.Range (1, 6);

		Debug.Log (randomObjectNumber);

		checkObjectInistiate ();
	}

	void checkObjectInistiate(){
		// Vector3 moet hardcoded gedaan worden per vlag.
		if (randomObjectNumber == 1) {
			if(count == 1){
				Instantiate(goalObject1, new Vector3(-20, 4,5f, 0), Quaternion.identity);
			}
			if(count == 2){
				Instantiate(goalObject1, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
			}
			if(count == 3){
				Instantiate(goalObject1, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
			}
				}
		if (randomObjectNumber == 2) {
			if(count == 1){
				Instantiate(goalObject1, new Vector3(-20, 4,5f, 0), Quaternion.identity);
			}
			if(count == 2){
				Instantiate(goalObject1, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
			}
			if(count == 3){
				Instantiate(goalObject1, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
			}
		}
		if (randomObjectNumber == 3) {
			if(count == 1){
				Instantiate(goalObject1, new Vector3(-20, 4,5f, 0), Quaternion.identity);
			}
			if(count == 2){
				Instantiate(goalObject1, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
			}
			if(count == 3){
				Instantiate(goalObject1, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
			}
		}
		if (randomObjectNumber == 4) {
			if(count == 1){
				Instantiate(goalObject1, new Vector3(-20, 4,5f, 0), Quaternion.identity);
			}
			if(count == 2){
				Instantiate(goalObject1, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
			}
			if(count == 3){
				Instantiate(goalObject1, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
			}
		}
		if (randomObjectNumber == 5) {
			if(count == 1){
				Instantiate(goalObject1, new Vector3(-20, 4,5f, 0), Quaternion.identity);
			}
			if(count == 2){
				Instantiate(goalObject1, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
			}
			if(count == 3){
				Instantiate(goalObject1, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
			}
		}
		if (randomObjectNumber == 6) {
			if(count == 1){
				Instantiate(goalObject1, new Vector3(-20, 4,5f, 0), Quaternion.identity);
			}
			if(count == 2){
				Instantiate(goalObject1, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
			}
			if(count == 3){
				Instantiate(goalObject1, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
			}
		}
		}
	
	// Update is called once per frame
	void Update () 
	{
		if (Character.alive == false && firstTimeObjective2 != 0) 
		{
			Objective(2);
			firstTimeObjective2 = 0;
		}
		if(Input.GetKey(KeyCode.R))
		{
			Debug.Log("player?" + Player1.alive);
			if(Player1.alive == true){
				Player1.FindObjectOfType<Player1>().Respawn();
			}
			else if(Player1.alive == false){
				Time.timeScale = 1;
				Player1.alive = true;
				//player.transform.position = new Vector3(0f,10f,0f);
				player.particleSystem.Stop();
				Instantiate(player, new Vector3(2, 10, 0), Quaternion.identity);
				//Network.Instantiate(player, new Vector3(0f, 10f, 0f), Quaternion.identity, 0);

			}
		}
	}

	public void Objective(int objectiveNumber)
	{
		if (randomObjectNumber == objectiveNumber) 
		{
			switch (objectiveNumber)
			{
			case 1:
				Debug.Log ("Objective 1 reached!");
				break;
			case 2:
				Debug.Log ("Objective 2 reached!");
				break;
			case 3:
				Debug.Log ("Objective 3 reached!");
				break;
			case 4:
				Debug.Log ("Objective 4 reached!");
				break;
			case 5:
				Debug.Log ("Objective 5 reached!");
				break;
			case 6:
				Debug.Log ("Objective 6 reached!");
				break;
			default:
				Debug.Log ("No valid objective...");
				break;
			}
		}
	}
}
