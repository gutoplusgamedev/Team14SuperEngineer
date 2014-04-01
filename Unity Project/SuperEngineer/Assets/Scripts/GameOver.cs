using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour 
{
	public static void OnGameOver ()
	{
		Application.LoadLevel ("MainMenu");
	}

	public static IEnumerator OnGameOverDueToGettingWrongSyntax ()
	{
		Instantiate (Resources.Load<GameObject> ("VwBeetle"), PlayerControl.PlayerInstance.transform.position + (Vector3.up * 3), Quaternion.identity);
		Destroy (PlayerControl.PlayerInstance.gameObject);
		yield return new WaitForSeconds (5);
		OnGameOver ();
	}
}
