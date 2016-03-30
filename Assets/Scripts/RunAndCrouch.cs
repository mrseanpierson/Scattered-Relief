using UnityEngine;
using System.Collections;

public class RunAndCrouch : MonoBehaviour 
{
	public float walkSpeed = 7; // regular speed
	public float crchSpeed = 3; // crouching speed
	public float runSpeed = 20; // run speed
	
	private CharacterMotor chMotor;
	private Transform tr;
	private float dist; // distance to ground
	
	// Use this for initialization
	void Start () 
	{
		chMotor =  GetComponent<CharacterMotor>();
		tr = transform;
		CharacterController ch = GetComponent<CharacterController>();
		dist = ch.height/2; // calculate distance to ground
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		float vScale = 2.0f;
		float speed = walkSpeed;
		float bckSpeed = walkSpeed - 2;
		
		if ((Input.GetKey("left shift") || Input.GetKey("right shift")) && chMotor.grounded)
		{
			speed = runSpeed;
			bckSpeed = runSpeed - 3;
		}
		
		if (Input.GetKey("c"))
		{ // press C to crouch
			vScale = 1f;
			speed = crchSpeed; // slow down when crouching
			bckSpeed = crchSpeed - 1;
		}
		
		chMotor.movement.maxForwardSpeed = speed; // set max speed
		chMotor.movement.maxSidewaysSpeed = speed;
		chMotor.movement.maxBackwardsSpeed = bckSpeed;
		float ultScale = tr.localScale.y; // crouch/stand up smoothly 
		
		Vector3 tmpScale = tr.localScale;
		Vector3 tmpPosition = tr.position;
		
		tmpScale.y = Mathf.Lerp(tr.localScale.y, vScale, 5 * Time.deltaTime);
		tr.localScale = tmpScale;
		
		tmpPosition.y += dist * (tr.localScale.y - ultScale); // fix vertical position        
		tr.position = tmpPosition;
	}
}
