using UnityEngine;

public class CamControl : MonoBehaviour 
{

	public float distanceFromTarget;
	public float lift;
	public bool lookAtTarget;
	public Transform target;
	
	void Update () 
	{
		transform.position = Vector3.Lerp(transform.position, (target.position - (Vector3.forward * distanceFromTarget)) + (Vector3.up * lift), Time.deltaTime);
		if(lookAtTarget)
		{
			transform.rotation = Quaternion.LookRotation (target.position - transform.position);
		}
	}
}
