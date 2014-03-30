using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour 
{
	void Start ()
	{
		animation ["RunCycle"].speed = 6f;
		animation ["Jump"].speed = 2f;
	}

	void Update ()
	{
		if (Input.GetKey (KeyCode.W))
		{
			animation.Play ("RunCycle");
		}

		if (Input.GetKey (KeyCode.Space)) 
		{
			animation.Play ("Jump");
		}
	}
}
