using UnityEngine;
using System.Collections;

public class PropController: MonoBehaviour 
{
	IEnumerator OnBecameInvisible ()
	{
		// wait for one second. If the object is visible, call the function again, otherwise destroy the game object
		yield return new WaitForSeconds (1);
		if (transform.renderer.isVisible) 
		{
			Destroy (gameObject, 5);
		} 
		else
		{
			Destroy (gameObject);
		}
	}
}
