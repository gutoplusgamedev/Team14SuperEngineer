#pragma strict
var points = 1;
function OnTriggerEnter (info : Collider) 
{
	if(info.tag == "Player")
	{
		gameMaster.currentScore += points;
		Destroy(gameObject);
	}
}
