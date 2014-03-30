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
	public static float currentDisplacement; //keeps track of where we are in x
	private float xPostree;
	private int i; //so we can destroy objects
	private int j;
	private int k;

	private string[] parsedSyntax;
	private GameObject[] currentSyntax;
	public GameObject floatingSyntax;

	// Use this for initialization
	void Start () 
	{
		ParseSyntaxInformation ();
		InitializePlatforms (5);
		StartCoroutine (CreationCoroutine ());
	}

	void ParseSyntaxInformation ()
	{
		XmlDocument doc = new XmlDocument();
		doc.Load("Assets/ValidSyntax.xml");
		XmlNodeList nodes = doc.DocumentElement.SelectNodes("/validSyntax/symbol");
		
		parsedSyntax = new string[nodes.Count];
		
		int z = 0;
		foreach (XmlNode node in nodes)
		{
			//Debug.Log(string.Format("{0}", node.InnerText));
			parsedSyntax[z] = node.InnerText;
			z++;
		}
	}

	void InstantiatePlatform ()
	{
		GameObject platform = platforms [Random.Range (0, platforms.Length)];
		Instantiate (platform, new Vector3(currentDisplacement, 0, 0), Quaternion.Euler (270, 0, 270));
		currentDisplacement += 7.3f;
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
			yield return new WaitForSeconds (0.6f);
		}
	}
}

