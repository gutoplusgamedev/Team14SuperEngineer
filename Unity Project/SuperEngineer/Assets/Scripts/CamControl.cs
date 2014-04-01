using UnityEngine;

public class CamControl : MonoBehaviour 
{

	public float distanceFromTarget;
	public float lift;
	public float xOffset;
	public bool lookAtTarget;
	public Transform target;
	
	void Update () 
	{
		transform.position = target.position - (Vector3.forward * distanceFromTarget) + (Vector3.up * lift) + (Vector3.right * xOffset);
		if(lookAtTarget)
		{
			transform.rotation = Quaternion.LookRotation (target.position - transform.position);
		}
	}
}
