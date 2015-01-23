using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GUIText goalText;
	public GUIText timerText;
	public GUIText endStateText;
	public GUIText winStateText;
	
	public static int numberOfKeysLeft = 10;
	public static float globalTime = 30;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		// Set the goal text equals to how much keys are left
		goalText.text = numberOfKeysLeft.ToString();

		// Count down the globalTime
		if (globalTime > 0 && numberOfKeysLeft > 0) {
			globalTime -= (Time.deltaTime * 0.25f);		
		}

		// Checks if the timer is 0
		if (globalTime <= 0 && numberOfKeysLeft != 0) {
				Player1.GameOver ();
				endStateText.text = "Game Over!!";
				//endStateText.enabled = true;

			} else if (numberOfKeysLeft == 0 && globalTime > 0) {
				Player1.GameWon();
				winStateText.text = "Level complete!";
				}

		timerText.text = "Time: " + globalTime.ToString("f0");
	}
}
