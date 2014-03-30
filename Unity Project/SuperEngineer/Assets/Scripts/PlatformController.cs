using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour 
{
	IEnumerator OnBecameInvisible ()
	{
		yield return new WaitForSeconds (1);
		if (transform.renderer.isVisible) 
		{
			OnBecameInvisible ();
		} 
		else 
		{
			Destroy (gameObject);
		}
	}
}
