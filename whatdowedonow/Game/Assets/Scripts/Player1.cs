using UnityEngine;
using System.Collections;

public class Player1 : Character 
{	
	public static Object player;


	// Use this for initialization
	public override void Start () 
	{
		base.Start();
		player = GameObject.FindGameObjectWithTag("Player");

		// grab the players position at startup and use it for the spawn position when starting new rounds
		spawnPos = _transform.position;
	}
	
	public void Update () 
	{

		// reload the scene to reset scores etc
		if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.T))
		{
			Application.LoadLevel(0);
		}

			UpdateMovement();
		


	}

	public void FixedUpdate()
	{
				// inputstate is none unless one of the movement keys are pressed
				currentInputState = inputState.None;
				if (networkView.isMine) {
						if (Character.alive == true) 
						{

								// move left
								if (Input.GetKey (KeyCode.LeftArrow)) { 
										currentInputState = inputState.WalkLeft;
										facingDir = facing.Left;
								}

								// move right
								if (Input.GetKey (KeyCode.RightArrow) && currentInputState != inputState.WalkLeft) { 
										currentInputState = inputState.WalkRight;
										facingDir = facing.Right;
								}

								// jump
								if (Input.GetKeyDown (KeyCode.UpArrow)) { 
										currentInputState = inputState.Jump;
								}

								UpdatePhysics ();
						}
				}
		}
	
	public void Respawn()
	{
		if(alive == true)
		{
			_transform.position = spawnPos;
			hasBall = false;
		}
	}

	public static void GameOver()
	{
		Destroy (player);
		Character.alive = false;

	}

	public static void GameWon()
	{
		Destroy (player);
		Character.alive = false;
	}

}
