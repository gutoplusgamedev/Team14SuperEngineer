#pragma strict
var lift : float  = 1.5;
var distance : float = 10;
var target: Transform;

function Update () {
transform.position = target.position - Vector3( 0, -10,0);
transform.LookAt (target);
}