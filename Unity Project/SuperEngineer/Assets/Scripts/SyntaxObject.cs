using UnityEngine;
using System.Collections;

public class SyntaxObject : MonoBehaviour 
{
	void OnTriggerEnter (Collider c)
	{
		if (c.GetComponent<PlayerControl> () != null) 
		{
			GameMaster.points += 10;
			StartCoroutine (OnPickUpCoroutine ());
		}
	}

	IEnumerator OnPickUpCoroutine ()
	{
		Destroy (GetComponent<BoxCollider> ());
		TextMesh[] texts = GetComponentsInChildren<TextMesh> ();
		Camera c = Camera.mainCamera;
		float movVelocity = 2;

		while (true) 
		{
			foreach (TextMesh tm in texts)
			{
				tm.color -= new Color (0, 0, 0, Time.deltaTime);
			}

			transform.position += (c.transform.position - transform.position).normalized * Time.deltaTime * movVelocity;
			yield return null;
		}

		Destroy (gameObject);
	}
}
