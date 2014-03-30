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
	private float xPos; //keeps track of where we are in x
	private float xPostree;

	private GameObject[] currentPlatform;
	private GameObject[] currentTree;
	private GameObject[] currentTree1;
	private int i; //so we can destroy objects
	private int j;
	private int k;

	private string[] parsedSyntax;
	private GameObject[] currentSyntax;
	public GameObject floatingSyntax;

	// Use this for initialization
	void Start () 
	{
		currentPlatform = new GameObject[platforms.Length];
		currentTree = new GameObject[trees.Length];
		currentTree1 = new GameObject[trees1.Length];
		counter = 0;
		treecounter = 0;
		i = 0;
		j = 0;
		k = 0;
		xPos = 0;
		xPostree = 0;

		//parsing
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
	
	// Update is called once per frame
	void Update () 
	{
		counter += Time.deltaTime;
		treecounter += Time.deltaTime;
		if (counter > 0.6) 
		{
			xPos += 7.3f;

			counter = 0;

			i++;
			i = i % platforms.Length;

			int platformNumber = Random.Range (0, platforms.Length);
			//int platformNumber = i;
			currentPlatform[i] = (GameObject) Instantiate (platforms [platformNumber], new Vector3(xPos,0,0), Quaternion.Euler (270, 0, 270));

			GameObject go;

			//spawns at different place
			//depending on the platformn
			switch(platformNumber)
			{
			case 0:
				go = (GameObject) Instantiate (floatingSyntax, new Vector3(xPos-1,2,0), Quaternion.Euler (0, 0, 0));
				break;
			case 1:
				go = (GameObject) Instantiate (floatingSyntax, new Vector3(xPos-2,2,0), Quaternion.Euler (0, 0, 0));//ok
				break;
			case 2:
				go = (GameObject) Instantiate (floatingSyntax, new Vector3(xPos+1.5f,3,0), Quaternion.Euler (0, 0, 0));//ok
				break;
			case 3:
				go = (GameObject) Instantiate (floatingSyntax, new Vector3(xPos+1,2,0), Quaternion.Euler (0, 0, 0));
				break;
			case 4:
				go = (GameObject) Instantiate (floatingSyntax, new Vector3(xPos,5,0), Quaternion.Euler (0, 0, 0));
				break;
			default:
				go = (GameObject) Instantiate (floatingSyntax, new Vector3(xPos,2,0), Quaternion.Euler (0, 0, 0));
				break;
			}

			//5/6 chance to spawn text
			if (Random.Range (0,6) < 5)
				go.GetComponent<TextMesh>().text = parsedSyntax[Random.Range (0, parsedSyntax.Length)];
			else
				Destroy (go);


		}
		if (treecounter > 0.38) 
		{
			treecounter = 0;
			xPostree += 3.3f;

			j++;
			k++;

			j = j % trees.Length;
			k = k % trees1.Length;


			int treeNumber = Random.Range( 0,trees.Length);
			int treeNumber1 = Random.Range( 0,trees1.Length);
			currentTree[j] = (GameObject) Instantiate(trees [treeNumber], new Vector3(xPostree,0,5), Quaternion.Euler (270, 0, 270));
			currentTree1[k] = (GameObject) Instantiate(trees1 [treeNumber1], new Vector3(xPostree,0,-5), Quaternion.Euler (270, 0, 270));


		}
	}

}

