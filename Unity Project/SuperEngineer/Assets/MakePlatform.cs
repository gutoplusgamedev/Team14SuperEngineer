using UnityEngine;
using System.Collections;

using System.Xml;
using System.IO;
using System.Text;

public class MakePlatform : MonoBehaviour 
{
	//stores platform
	public GameObject[] platforms; //create platform of this type

	//stores text
	public GameObject floatingSyntax;

	private string[] parsedSyntax;
	private GameObject[] currentSyntax;

	private float counter;	//keeps track of the time so we create a new object every 1 second
	private float xPos; //keeps track of where we are in x

	private GameObject[] currentPlatform;
	private int i; //so we can destroy objects

	// Use this for initialization
	void Start () 
	{
		currentPlatform = new GameObject[platforms.Length];
		counter = 0;
		i = 0;
		xPos = 0;

		//parsing
		XmlDocument doc = new XmlDocument();
		doc.Load("Assets/ValidSyntax.xml");
		XmlNodeList nodes = doc.DocumentElement.SelectNodes("/validSyntax/symbol");

		parsedSyntax = new string[nodes.Count];

		int j = 0;
		foreach (XmlNode node in nodes)
		{
			//Debug.Log(string.Format("{0}", node.InnerText));
			parsedSyntax[j] = node.InnerText;
			j++;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		counter += Time.deltaTime;
		if (counter > 1) 
		{
			xPos += 7.3f;
			counter--;
			i++;
			i = i % platforms.Length;

			if (currentPlatform[i] != null ) 
			{
				Destroy(currentPlatform[i]);
			}

			int platformNumber = Random.Range (0, platforms.Length);
			currentPlatform[i] = (GameObject) Instantiate (platforms [platformNumber], new Vector3(xPos,0,0), Quaternion.Euler (270, 0, 270));

			GameObject go = (GameObject) Instantiate (floatingSyntax, new Vector3(xPos,5,0), Quaternion.Euler (0, 0, 0));
			go.GetComponent<TextMesh>().text = parsedSyntax[Random.Range (0, parsedSyntax.Length)];
		}
	}
}
