using UnityEngine;
using System.Collections;

public class ObjectManager : MonoBehaviour
{

		private int randomObjectNumber;
		private int firstTimeObjective2 = 1;
		public GameObject goalObject1;
		public GameObject goalObject2;
		public GameObject goalObject3;
		public GameObject goalObject4;
		public GameObject goalObject5;
		public GameObject player;
		public static int count = 1;
	private bool checkUpdate = false;
	private bool checkUpdate2 = false;

		// Use this for initialization
		public void Start ()
		{
				randomNumber ();	
		}

		public void randomNumber ()
		{
				randomObjectNumber = Random.Range (3, 3);
				Debug.Log (randomObjectNumber);
		
				checkObjectInistiate ();
		}

		public void checkObjectInistiate ()
		{
				// Vector3 moet hardcoded gedaan worden per vlag.
				if (randomObjectNumber == 1) {

				}
				if (randomObjectNumber == 2) {
						if (count == 1) {
								Instantiate (goalObject2, new Vector3 (27.9f, 3.3f, 0), Quaternion.identity);
						}
						if (count == 2) {
								Instantiate (goalObject2, new Vector3 (70.8f, 3.1f, 0), Quaternion.identity);

						}
						if (count == 3) {
								Instantiate (goalObject2, new Vector3 (113.7f, 1.3f, 0), Quaternion.identity);
						}
				}
				if (randomObjectNumber == 3) {
						if (count == 1) {
								Instantiate (goalObject3, new Vector3 (27.9f, 3.3f, 0), Quaternion.identity);

						}
						if (count == 2) {
								Instantiate (goalObject3, new Vector3 (70.8f, 3.1f, 0), Quaternion.identity);

						}
						if (count == 3) {
								Instantiate (goalObject3, new Vector3 (113.7f, 1.3f, 0), Quaternion.identity);
						}
				}
				if (randomObjectNumber == 4) {

				}
				if (randomObjectNumber == 5) {
						if (count == 1) {
								Instantiate (goalObject5, new Vector3 (27.9f, 3.3f, 0), Quaternion.identity);
						}
						if (count == 2) {
								Instantiate (goalObject5, new Vector3 (70.8f, 3.1f, 0), Quaternion.identity);
						}
						if (count == 3) {
								Instantiate (goalObject5, new Vector3 (113.7f, 1.3f, 0), Quaternion.identity);
						}
				}
		}
	
		// Update is called once per frame
		void Update ()
		{
				player.particleSystem.Stop ();
				if (Character.alive == false && firstTimeObjective2 != 0) {
						Objective (2);
						firstTimeObjective2 = 0;
				}
				if (Input.GetKey (KeyCode.R)) {
						Player1.FindObjectOfType<Player1> ().Respawn ();
				}

			if (count == 2) {
						if (!checkUpdate) {
								checkUpdate = true;
								checkObjectInistiate ();

						}
				} else if (count == 3) {
						if (!checkUpdate2){
				checkUpdate2 = true;
				checkObjectInistiate();
			}
				}

		}

		public void Objective (int objectiveNumber)
		{
				if (randomObjectNumber == objectiveNumber) {
						switch (objectiveNumber) {
						case 1:
								Debug.Log ("Objective 1 reached!");
								if (Player1.Level1 && !Player1.Level2) {
										Player1.FindObjectOfType<Player1> ().SpawnToLevel2 ();
								} else if (Player1.Level2 && !Player1.Level3) {
										Player1.FindObjectOfType<Player1> ().SpawnToLevel3 ();
								}
								break;
						case 2:
								Debug.Log ("Objective 2 reached!");
								if (Player1.Level1) {
										Player1.FindObjectOfType<Player1> ().SpawnToLevel2 ();
								} else if (Player1.Level2) {
										Player1.FindObjectOfType<Player1> ().SpawnToLevel3 ();
								}
								break;
						case 3:
								Debug.Log ("Objective 3 reached!");
								if (Player1.Level1) {
										Player1.FindObjectOfType<Player1> ().SpawnToLevel2 ();
								} else if (Player1.Level2) {
										Player1.FindObjectOfType<Player1> ().SpawnToLevel3 ();
								}
								break;
						case 4:
								Debug.Log ("Objective 4 reached!");
								if (Player1.Level1) {
										Player1.FindObjectOfType<Player1> ().SpawnToLevel2 ();
								} else if (Player1.Level2) {
										Player1.FindObjectOfType<Player1> ().SpawnToLevel3 ();
								}
								break;
						case 5:
								Debug.Log ("Objective 5 reached!");
								if (Player1.Level1) {
										Player1.FindObjectOfType<Player1> ().SpawnToLevel2 ();
								} else if (Player1.Level2) {
										Player1.FindObjectOfType<Player1> ().SpawnToLevel3 ();
								}
								break;
						default:
								Debug.Log ("No valid objective...");
								break;
						}
				}
		}
}
