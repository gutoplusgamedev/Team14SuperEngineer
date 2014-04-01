using UnityEngine;

public class GapDetector : MonoBehaviour 
{
	public delegate void OnPlayerCollisionEventHandler ();
	public static event OnPlayerCollisionEventHandler OnPlayerCollision;

	void OnCollisionEnter (Collision c)
	{
		if (c.gameObject.GetComponent <PlayerControl>())
		{
			if (OnPlayerCollision != null)
			{
				Destroy (GetComponent <BoxCollider>());
				OnPlayerCollision ();
			}
		}
	}
}
