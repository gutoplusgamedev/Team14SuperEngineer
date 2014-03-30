#pragma strict

var pause : boolean = false;
var pauseGUI : GUITexture;

pauseGUI.enabled = false;

function Update(){
if(Input.GetKeyDown(KeyCode.Escape)) 
{
	if(pause == true)
	{
	pause = false;
	}
	else 
	{
	pause = true;
	}
	
if(pause == true) 
{
Time.timeScale = 0.0;
pauseGUI.enabled = true;
}
else 
{
Time.timeScale = 1.0;
pauseGUI.enabled = false;
}
} 
}