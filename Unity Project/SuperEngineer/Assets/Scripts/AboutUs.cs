using UnityEngine;
using System.Collections;


public class AboutUs : MonoBehaviour {

	public bool aboutUs = false;

	void OnMouseEnter() 
	{
		renderer.material.color = Color.red;
	}
	
	void OnMouseExit () 
	{
		renderer.material.color = Color.white;
	}
	
	void OnMouseDown() 
	{
		if (aboutUs)
		{
			Application.LoadLevel("AboutUs");
		}
		
	}
}