using UnityEngine;
using System.Collections;

public class pointGui : MonoBehaviour {

	public Texture2D syntaxTexture, pointTexture;
	public GUISkin skin;

	void OnGUI()
	{
		GUI.skin = skin;
		GUI.skin.label.fontSize = 30;
		Rect syntaxTextureRect = new Rect (Screen.width * 0.5f - (syntaxTexture.width * 0.5f), Screen.height * 0.1f, syntaxTexture.width, syntaxTexture.height);
		Rect pointsTextureRect = new Rect (Screen.width * 0.5f - (pointTexture.width * 0.5f), syntaxTextureRect.y - pointTexture.height, pointTexture.width, pointTexture.height);
		GUI.DrawTexture (syntaxTextureRect, syntaxTexture);
		GUI.DrawTexture (pointsTextureRect, pointTexture);
		GUI.Label (new Rect (0, pointsTextureRect.y, Screen.width, pointsTextureRect.height), GameMaster.points.ToString ());
		GUI.Label (new Rect (0, syntaxTextureRect.y, Screen.width, syntaxTextureRect.height), SyntaxCollector.GetSyntaxString ());
	}
}
