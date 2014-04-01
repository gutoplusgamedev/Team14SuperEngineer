using UnityEngine;
using System.Collections;

using System.Xml;
using System.IO;
using System.Text;

public class MakePlatform : MonoBehaviour 
{
	public GameObject[] platforms; //create platform of this type
	public GameObject background;
	public static float currentDisplacement = -10; //keeps track of where we are in x

	// Use this for initialization
	void Start () 
	{
		currentDisplacement = -10;
		InitializePlatforms (5);
		StartCoroutine (CreationCoroutine ());
	}

	void InstantiatePlatform ()
	{
		GameObject platform = platforms [Random.Range (0, platforms.Length)];
		Vector3 position = new Vector3 (currentDisplacement, 0, 0);
		Instantiate (platform, position, Quaternion.Euler (270, 0, 270));
		InstantiateBackground ();
		currentDisplacement += 4.345427f;
		if (OnPlatformInstantiated != null) 
		{
			OnPlatformInstantiated (position, new Vector3 (currentDisplacement, 0, 0));
		}
	}

	void InitializePlatforms (int howMany)
	{
		for (int i = 0; i < howMany; i++) 
		{
			InstantiatePlatform ();
		}
	}

	void InstantiateBackground ()
	{
		Quaternion rot = Quaternion.Euler (270, 270, 0);
		Instantiate (background, new Vector3 (currentDisplacement, 0, 0), rot);
	}

	IEnumerator CreationCoroutine ()
	{
		while (true) 
		{
			InstantiatePlatform ();
			yield return new WaitForSeconds (PlayerControl.PlayerInstance.velocity * 0.5f);
		}
	}

	public delegate void OnPlatformInstantiatedEventHandler (Vector3 position, Vector3 finalPosition);
	public static event OnPlatformInstantiatedEventHandler OnPlatformInstantiated;

}

