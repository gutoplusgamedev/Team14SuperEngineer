#pragma strict

static var currentScore : int = 0;
var test : int;
var style : GUIStyle = null;

function Update(){
	test = currentScore;
}

function OnGUI()
{
	GUI.color = Color.black;
	GUI.Label(Rect(Screen.height*1.1, Screen.width*.05,100 , 50),"Score: "+currentScore, style);
}