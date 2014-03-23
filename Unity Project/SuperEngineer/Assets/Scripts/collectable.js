#pragma strict
var points = 1;
function OnTriggerEnter (info : Collider) 
{
	if(info.name == "Player")
	{
		gameMaster.currentScore += points;
		Destroy(gameObject);
	}
}
