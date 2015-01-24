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

			//UpdateMovement();
		FixedUpdate ();
		


	}

	public void FixedUpdate()
	{
				// inputstate is none unless one of the movement keys are pressed
				currentInputState = inputState.None;
				currentControlType = controltype.Controls2;
						if (Character.alive == true) 
						{
							if (networkView.isMine) 
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
								if (Input.GetKeyDown (KeyCode.DownArrow)) { 
										currentInputState = inputState.Duck;
								}
							}
								UpdatePhysics ();
						}
		else
		{
			SyncedMovement();
		}
	}
	
	private void SyncedMovement()
	{
		syncTime += Time.deltaTime;
		//rigidbody2D.position = Vector2.Lerp(syncStartPosition, syncEndPosition, syncTime / syncDelay);
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


	private float lastSynchronizationTime = 0f;
	private float syncDelay = 0f;
	private float syncTime = 0f;
	private Vector3 syncStartPosition = Vector3.zero;
	private Vector3 syncEndPosition = Vector3.zero;
	
	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
	{
		Vector3 syncPosition = Vector3.zero;
		Vector3 syncVelocity = Vector3.zero;
		if (stream.isWriting)
		{
			syncPosition = rigidbody2D.position;
			stream.Serialize(ref syncPosition);
			
			syncVelocity = rigidbody2D.velocity;
			stream.Serialize(ref syncVelocity);


		}
		else
		{
			stream.Serialize(ref syncPosition);
			stream.Serialize(ref syncVelocity);

			
			syncTime = 0f;
			syncDelay = Time.time - lastSynchronizationTime;
			lastSynchronizationTime = Time.time;
			
			syncEndPosition = syncPosition + syncVelocity * syncDelay;
			syncStartPosition = rigidbody2D.position;
		}
	}
	}

