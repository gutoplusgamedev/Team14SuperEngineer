using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour 
{
	public static void OnGameOver ()
	{
		Application.LoadLevel ("MainMenu");
	}
}
