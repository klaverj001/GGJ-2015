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

	// Use this for initialization
	void Start () {
		randomObjectNumber = Random.Range (1, 6);
		Debug.Log (randomObjectNumber);

		checkObjectInistiate ();
	}

	void checkObjectInistiate(){

		if (randomObjectNumber == 1) {
			Instantiate(goalObject1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

				}
		if (randomObjectNumber == 2) {
			Instantiate(goalObject2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
				}
		if (randomObjectNumber == 3) {
			Instantiate(goalObject3, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
				}
		if (randomObjectNumber == 4) {
			Instantiate(goalObject4, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
				}
		if (randomObjectNumber == 5) {
			Instantiate(goalObject5, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
				}
		if (randomObjectNumber == 6) {
			Instantiate(goalObject6, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
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
