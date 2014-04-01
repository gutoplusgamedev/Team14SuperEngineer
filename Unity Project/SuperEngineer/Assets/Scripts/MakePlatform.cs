using UnityEngine;
using System.Collections;

using System.Xml;
using System.IO;
using System.Text;

public class MakePlatform : MonoBehaviour 
{
	public GameObject[] platforms; //create platform of this type
	public GameObject[] trees;
	public GameObject[] trees1;
	private float counter;	//keeps track of the time so we create a new object every 1 second
	private float treecounter;
	public static float currentDisplacement = -10; //keeps track of where we are in x
	private float xPostree;
	private int i; //so we can destroy objects
	private int j;
	private int k;


	private GameObject[] currentSyntax;
	public GameObject floatingSyntax;

	// Use this for initialization
	void Start () 
	{

		InitializePlatforms (5);
		StartCoroutine (CreationCoroutine ());
	}

	void InstantiatePlatform ()
	{
		GameObject platform = platforms [Random.Range (0, platforms.Length)];
		Vector3 position = new Vector3 (currentDisplacement, 0, 0);
		Instantiate (platform, position, Quaternion.Euler (270, 0, 270));
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

