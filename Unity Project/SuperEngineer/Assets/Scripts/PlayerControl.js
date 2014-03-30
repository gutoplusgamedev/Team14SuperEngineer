#pragma strict


private var moveSpeed : float = 7;
private var jumpSpeed:	float = 15;

var distToGround : float;

function Start () {
	// Getting the distance from the center to the ground.
	//distToGround = collider.bounds.extents.height /2 ;
distToGround = 2.5f;
}

function Update () {

rigidbody.velocity.x = moveSpeed;



if( (Input.GetKeyDown(KeyCode.W)) && (IsGrounded () || IsGrounded1 () || IsGrounded2 () )                ) {
animation.Play("Jump", PlayMode.StopAll);
rigidbody.velocity.y = jumpSpeed;

}
else if(IsGrounded ()|| IsGrounded1 () || IsGrounded2 ())
{
	animation.Play("RunCycle", PlayMode.StopSameLayer);	
}

}
function IsGrounded () : boolean { //Check if we are on the ground. Return true if we are else return null.

		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1);
	
}
function IsGrounded1 () : boolean { //Check if we are on the ground. Return true if we are else return null.

		return Physics.Raycast(transform.position + Vector3(-1,-.2,0), -Vector3.up, distToGround + 0.1);
}
function IsGrounded2 () : boolean { //Check if we are on the ground. Return true if we are else return null.

		return Physics.Raycast(transform.position + Vector3(1,-.2,0), -Vector3.up, distToGround + 0.1);	
}


