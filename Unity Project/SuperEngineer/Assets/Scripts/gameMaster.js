#pragma strict

static var currentScore : int = 0;
var test : int;
function Update(){
	test = currentScore;
}

function OnGUI()
{
	GUI.Box(new Rect(Screen.height*1.1, Screen.width*.05,100 , 50), "Score: ");
}