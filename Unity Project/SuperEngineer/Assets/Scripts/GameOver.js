#pragma strict

var isRestarting = false;
var maxFallDistance = -8;
var gameOverAudio : AudioClip;

function Update () {

if(transform.position.y < maxFallDistance)
{
if (isRestarting == false) {
 RestartLevel();
}
}

}



function RestartLevel() 
{
isRestarting = true;
audio.clip = gameOverAudio;
audio.Play();
yield WaitForSeconds(audio.clip.length);
Application.LoadLevel("MainMenu");
}

