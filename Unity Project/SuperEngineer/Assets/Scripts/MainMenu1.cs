using UnityEngine;
using System.Collections;

public class MainMenu1 : MonoBehaviour 
{
	public Texture2D splashImage;
	public GUISkin skin;
	public Vector2 buttonSize;

	void OnGUI ()
	{
		GUI.skin = skin;
		GUI.DrawTexture (new Rect (Screen.width * 0.5f - (splashImage.width * 0.5f), Screen.height * 0.2f, splashImage.width, splashImage.height), splashImage);
		int splashEnd = (int)(Screen.height * 0.2f) + splashImage.height;
		GUI.skin.label.fontSize = 50;
		GUI.Label (new Rect (0, splashEnd - 100, Screen.width, 100), "SuperEngineer");
		GUI.skin.label.fontSize = 10;
		GUI.Label (new Rect (Screen.width * 0.15f, splashEnd - 70, Screen.width, 100), "a Team14 game");
		int buttonOffset = 10;
		if (GUI.Button (new Rect (Screen.width * 0.5f - (buttonSize.x * 0.5f), splashEnd, buttonSize.x, buttonSize.y), "Start game")) 
		{
			Application.LoadLevel ("Main");
		}

		if (GUI.Button (new Rect (Screen.width * 0.5f - (buttonSize.x * 0.5f), splashEnd + buttonOffset + buttonSize.y, buttonSize.x, buttonSize.y), "Quit")) 
		{
			Application.Quit ();
		}
	}
}
