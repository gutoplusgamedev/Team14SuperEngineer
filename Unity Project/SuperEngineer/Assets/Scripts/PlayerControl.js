#pragma strict

private var rotationSpeed : float = 100 ;
private var moveSpeed : float = 7.3;
private var jumpSpeed:	float = 10;
private var downSpeed: float = -10;
private var canJump = true;


function Update () {
/*
var rotation: float = Input.GetAxis ("Vertical") * rotationSpeed;
rotation *= Time.deltaTime;
rigidbody.AddRelativeTorque (Vector3.back * rotation);
*/
rigidbody.velocity.x = moveSpeed;

if (transform.position.y > 2) {
canJump = false;
}
else {
canJump = true;
}

if( Input.GetKeyDown(KeyCode.W) && canJump == true) {
rigidbody.velocity.y = jumpSpeed;
}
if( Input.GetKeyDown(KeyCode.S) && canJump == true) {
rigidbody.velocity.y = downSpeed;
}



}
