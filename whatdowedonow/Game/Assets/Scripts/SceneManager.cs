using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

	public int randomSceneNumber;

	// Use this for initialization
	void Start () {

		// Create a random int between 0 and the maxium amount of scenes
		randomSceneNumber = Random.Range (0, Application.levelCount);

		// Loops till the random number is different then the current Scene
		while (randomSceneNumber == Application.loadedLevel) {
			randomSceneNumber = Random.Range (0, Application.levelCount);
				}
	}
	
	// Update is called once per frame
	void Update () {
	
		// When pressing Space the game will go to the next Random Scene
		if (Input.GetKeyDown (KeyCode.Q))
						Application.LoadLevel (randomSceneNumber);
	}
}
