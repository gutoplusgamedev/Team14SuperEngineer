using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour 
{
	IEnumerator OnBecameInvisible ()
	{
		// wait for one second. If the object is visible, call the function again, otherwise destroy the game object
		yield return new WaitForSeconds (1);
		if (transform.renderer.isVisible) 
		{
			StartCoroutine (OnBecameInvisible ());
		} 
		else 
		{
			if (Vector3.Distance (transform.position, PlayerControl.PlayerInstance.transform.position) > 10f)
			{
				Destroy (gameObject);
			}
		}
	}
}
