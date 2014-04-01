using UnityEngine;
using System.Collections;

public class BeetleController : MonoBehaviour 
{
	public GameObject smokeParticle;

	void Start ()
	{
		transform.rotation = Quaternion.Euler (new Vector3 (270, 270, 0));
		transform.localScale = Vector3.one * 0.59f;
	}

	void OnCollisionEnter (Collision c)
	{
		Instantiate (smokeParticle, transform.position, Quaternion.identity);
	}
}