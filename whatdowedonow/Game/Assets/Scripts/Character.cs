using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour 
{
	public MyTeam myTeam = MyTeam.Team1;

	public enum controltype
	{
		Controls1,
		Controls2,
		Controls3

	}
	public enum inputState 
	{ 
		None, 
		WalkLeft, 
		WalkRight, 
		Jump, 
		Duck,
		Pass
	}
	[HideInInspector] public inputState currentInputState;
	[HideInInspector] public controltype currentControlType;
	[HideInInspector] public enum facing { Right, Left }
	[HideInInspector] public facing facingDir;

	[HideInInspector] public static bool alive = true;
	[HideInInspector] public Vector3 spawnPos;
	
	protected Transform _transform;
	protected Rigidbody2D _rigidbody;

	// edit these to tune character movement	
	private float runVel = 2.5f; 	// run speed when not carrying the ball
	private float walkVel = 2f; 	// walk speed while carrying ball
	private float jumpVel = 4f; 	// jump velocity
	private float jump2Vel = 2f; 	// double jump velocity
	private float fallVel = 1f;		// fall velocity, gravity

	public static float moveVel;
	public static float pVel = 0f;
	
	private int jumps = 0;
    private int maxJumps = 2; 		// set to 2 for double jump
		
	protected bool hasBall = false;
	protected string team = "";

	// raycast stuff
	private RaycastHit2D hit;
	private Vector2 physVel = new Vector2();
	[HideInInspector] public bool grounded = false;
	private int groundMask = 1 << 8; // Ground layer mask

	public virtual void Awake()
	{
		_transform = transform;
		_rigidbody = rigidbody2D;
	}
	
	// Use this for initialization
	public virtual void Start () 
	{
		this.particleSystem.Stop();
		moveVel = walkVel;
	}
	
	// Update is called once per frame
	public virtual void UpdateMovement() 
	{
		if(xa.gameOver == true || alive == false) return;

		// teleport me to the other side of the screen when I reach the edge
		if(_transform.position.x > 5.8f)
		{
			_transform.position = new Vector3(-5.8f,_transform.position.y, 0);
		}
		if(_transform.position.x < -5.8f)
		{
			_transform.position = new Vector3(5.8f,_transform.position.y, 0);
		}

	}
	
	// ============================== FIXEDUPDATE ============================== 

	public virtual void UpdatePhysics()
	{
				if (xa.gameOver == true || alive == false)
						return;

				if (alive == true) {

						physVel = Vector2.zero;
					if (networkView.isMine)
					{
				if (currentControlType == controltype.Controls1)
				{
					// move left
					if (currentInputState == inputState.WalkLeft) {
						physVel.x = -moveVel;
					}
					
					// move right
					if (currentInputState == inputState.WalkRight) {
						physVel.x = moveVel;
					}
					if (currentInputState == inputState.Duck) {
						//play duck animation;
					}
					// jump
					if (currentInputState == inputState.Jump) {
						if (jumps < maxJumps && _transform.position.y < 3.4) {
							jumps += 1;
							_rigidbody.velocity = new Vector2 (physVel.x, jumpVel);
							
						}
					}
				}
				if (currentControlType == controltype.Controls2)
				{
						// move left
						if (currentInputState == inputState.WalkLeft) {
								physVel.x = moveVel;
						}

						// move right
						if (currentInputState == inputState.WalkRight) {
								physVel.x = -moveVel;
						}
						if (currentInputState == inputState.Duck) {
						if (jumps < maxJumps && _transform.position.y < 3.4) {
							jumps += 1;
							_rigidbody.velocity = new Vector2 (physVel.x, jumpVel);
						}
						// jump
						if (currentInputState == inputState.Jump) {
								// play duck animation
								}
						}
					}
				if (currentControlType == controltype.Controls3)
				{
					// move left
					if (currentInputState == inputState.WalkLeft) {
						physVel.x = -moveVel;
					}
					
					// move right
					if (currentInputState == inputState.WalkRight) {
						physVel.x = moveVel;
					}
					if (currentInputState == inputState.Duck) {
						//play duck animation;
					}
					if (currentInputState == inputState.Jump) {
						if(facingDir == facing.Right)
							physVel.x = moveVel*20;
						if(facingDir == facing.Left)
							physVel.x = -moveVel*20;
						}
					}
				}

				}
						// use raycasts to determine if the player is standing on the ground or not
						if (Physics2D.Raycast (new Vector2 (_transform.position.x - 0.1f, _transform.position.y), -Vector2.up, .6f, groundMask) 
								|| Physics2D.Raycast (new Vector2 (_transform.position.x + 0.1f, _transform.position.y), -Vector2.up, .6f, groundMask)) {
								print ("i touch the ground");
								grounded = true;
								jumps = 0;
						} else {
								print ("i dont touch the ground");
								grounded = false;
								_rigidbody.AddForce (-Vector3.up * fallVel);
						}

						// actually move the player
						_rigidbody.velocity = new Vector2 (physVel.x, _rigidbody.velocity.y);
				}
	

}

public enum MyTeam 
{
	Team1,
	Team2,
	None
}
