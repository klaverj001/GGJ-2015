using UnityEngine;
using System.Collections;

public class Player1 : Character
{	
		public static Object player;
		public static Vector3 Spawn2;
		public static Vector3 Spawn3;
		public static bool Level1 = true;
		public static bool Level2 = false;
		public static bool Level3 = false;

<<<<<<< HEAD
	private ObjectManager objectmanager;


=======
>>>>>>> f2eabfe3ffb03fdc22168a2f5a83748a652e9531
		// Use this for initialization
		public override void Start ()
		{
				base.Start ();
				player = GameObject.FindGameObjectWithTag ("Player");

				// grab the players position at startup and use it for the spawn position when starting new rounds
				spawnPos = _transform.position;
		}
	
		public void Update ()
		{

				// reload the scene to reset scores etc
				if (Input.GetKey (KeyCode.LeftShift) && Input.GetKeyDown (KeyCode.T)) {
						Application.LoadLevel (0);
				}

				//UpdateMovement();
				FixedUpdate ();
		


		}

		public void SpawnToLevel2 ()
		{
				GameObject.Find("Game").GetComponent<ObjectManager>().randomNumber();
				Spawn2 = GameObject.FindGameObjectWithTag ("Level2").transform.position;
				if (alive == true) {
						_transform.position = Spawn2;
						Level1 = false;
						Level2 = true;
			ObjectManager.count++;
			//objectmanager.checkObjectInistiate();
				}
		}

		public void SpawnToLevel3 ()
		{
				GameObject.Find("Game").GetComponent<ObjectManager>().randomNumber();
				Spawn3 = GameObject.FindGameObjectWithTag ("Level3").transform.position;
				if (alive == true) {
						_transform.position = Spawn3;
						Level2 = false;
						Level3 = true;
			ObjectManager.count++;
			//objectmanager.checkObjectInistiate();
				}
		}

		public void FixedUpdate ()
		{
				// inputstate is none unless one of the movement keys are pressed
				currentInputState = inputState.None;
		
				// Check the controls for the current level
				if (Level1 == true) {
						currentControlType = controltype.Controls1;
				} else if (Level2 == true) {
						currentControlType = controltype.Controls2;
				} else if (Level3 == true) {
						currentControlType = controltype.Controls3;
				}
				if (Character.alive == true) {
						if (networkView.isMine) {	
								
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

		}
	
		public void Respawn ()
		{

		if (alive == true && Level1) {
						_transform.position = spawnPos;
				}
				if (alive == true && Level2) {
						SpawnToLevel2 ();
				}
				if (alive == true && Level3) {
						SpawnToLevel3 ();
				}
		}

		public void setPlayerAlive (bool boolean)
		{
				Character.alive = boolean;
		}

		public static void GameOver ()
		{
				Destroy (player);
				Character.alive = false;

		}

		public static void GameWon ()
		{
				Destroy (player);
				Character.alive = false;
		}
	
		void OnSerializeNetworkView (BitStream stream, NetworkMessageInfo info)
		{
				Vector3 syncPos = rigidbody2D.position;
				Vector3 velocity = rigidbody2D.velocity;
		
				stream.Serialize (ref syncPos);
				stream.Serialize (ref velocity);
		
				if (stream.isReading) {
						transform.position = syncPos;
						physVel = velocity;
				}

		}
}

