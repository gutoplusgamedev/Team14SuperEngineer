using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour 
{
	public static int points;

	void Start ()
	{
		points = 0;
	}

	void OnGUI ()
	{
		GUI.skin.textArea.alignment = TextAnchor.MiddleCenter;
		GUI.Label (new Rect (0, 0, Screen.width, 40), "Score: " + points);
	}
}
