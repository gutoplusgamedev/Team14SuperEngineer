using UnityEngine;
using System.Collections;

public class SyntaxObject : MonoBehaviour {

	void OnTriggerEnter (Collider c)
	{
		if (c.GetComponent<PlayerControl> () != null) 
		{
			GameMaster.points += 10;
			Destroy (gameObject);
		}
	}
}
