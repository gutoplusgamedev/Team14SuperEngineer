using UnityEngine;
using System.Collections;

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
			currentPlatform[i] = (GameObject) Instantiate (platforms [platformNumber], new Vector3(xPos,0,0), Quaternion.Euler (270, 0, 270));


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

