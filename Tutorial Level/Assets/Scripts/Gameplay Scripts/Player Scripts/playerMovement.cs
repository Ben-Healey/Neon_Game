using UnityEngine;
using System.Collections;

// http://wiki.unity3d.com/index.php?title=FPSWalkerEnhanced - surplus features edited out

[RequireComponent (typeof(CharacterController))]
public class playerMovement : MonoBehaviour {

	public Attributes Att_Script;
	//float Speed_Test = Att_Script.Get_Player_Speed();

	public float walkSpeed = 6.0f;
	public float runSpeed = 11.0f;

	// Normally, moving diagonally will multiply forwards and side movement moving you at 1.4x speed at diagonal
	public bool limitDiagonalSpeed = true;

	// Allow a switch between toggle or hold run key - bind "Run" in InputManager
	public bool toggleRun = true;

	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;

	// How many units can you fall before taking fall damage (change to "infinity" in Inspector to disable)
	public float fallDamageLimit = 10.0f;

	// Prevents standard character controllers from bouncing when moving on slopes
	public float antiBumpFactor = .75f;

	// Number of physics frames you must be grounded before jumping again - 0 enables BH
	public int antiBunnyhopFactor = 1;

	private Vector3 moveDirection = Vector3.zero; // Vector3.zero == Vector3(0, 0, 0)
	private bool grounded = false; // Check whether the player is on a floor
	private CharacterController controller;
	private Transform myTransform;
	private float speed;

	private float fallStartHeight;
	private bool falling;
	private int jumpTimer;

	void Start () {
		controller = GetComponent<CharacterController> ();
		myTransform = transform;
		speed = walkSpeed;
		jumpTimer = antiBunnyhopFactor;
		Cursor.lockState = CursorLockMode.Confined; // keep confined in the game window
		Cursor.lockState = CursorLockMode.Locked;   // keep confined to center of screen
		Cursor.lockState = CursorLockMode.None;     // set to default default
		// rayDistance = controller.height * .5f + controller.radius;
	}

	void FixedUpdate () {
		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");
		float inputModifyFactor = (inputX != 0.0f && inputY != 0.0f && limitDiagonalSpeed) ? .7071f : 1.0f;

		if (grounded) {

			if (falling) {
				falling = false;
				if (myTransform.position.y < fallStartHeight - fallDamageLimit)
					FallDamageAlert (fallStartHeight - myTransform.position.y);
			}

			if (!toggleRun) {
				speed = Input.GetButton ("Run") ? runSpeed : walkSpeed;
			}

			moveDirection = new Vector3 (inputX * inputModifyFactor, -antiBumpFactor, inputY * inputModifyFactor);
			moveDirection = myTransform.TransformDirection (moveDirection) * speed;
			//			playerControl = true;

			// Jumping controls are defined by whether the button is not pressed and that the time delay has been reached
			if (!Input.GetButton ("Jump"))
				jumpTimer++;
			else if (jumpTimer >= antiBunnyhopFactor) {
				moveDirection.y = jumpSpeed;
				jumpTimer = 0;
			}
		}
		else {
			if (!falling) { // Check every frame whether we are falling, as it gets reset when we are grounded
				falling = true;
				fallStartHeight = myTransform.position.y;
			}
		}

		// Apply gravity movement
		moveDirection.y -= gravity * Time.deltaTime;

		// Apply the move and determine whether we are on the ground
		grounded = (controller.Move (moveDirection * Time.deltaTime) & CollisionFlags.Below) !=0;

	

	}

	void Update () {
		// FixedUpdate may not run every frame and might miss a toggle to toggleRun, so it should be checked in Update instead
		if (toggleRun && grounded && Input.GetButtonDown ("Run"))
			speed = (speed == walkSpeed ? runSpeed : walkSpeed);

		if(Input.GetButtonDown("Crouch"))
		{
			int cr = -1;
			moveDirection.y -= cr * Time.deltaTime;
		}
	}

	void OnControllerColliderHit (ControllerColliderHit hit) {
		// contactPoint = hit.point;
	}

	void FallDamageAlert(float fallDistance) {
		Debug.Log ("Falling damage taken - went " + fallDistance + "units"); 
	}
}
