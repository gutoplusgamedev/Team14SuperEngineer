using UnityEngine;
using System.Collections;

public class BeetleController : MonoBehaviour 
{
	public GameObject smokeParticle;

	void OnCollisionEnter (Collision c)
	{
		Instantiate (smokeParticle, transform.position, Quaternion.identity);
	}
}