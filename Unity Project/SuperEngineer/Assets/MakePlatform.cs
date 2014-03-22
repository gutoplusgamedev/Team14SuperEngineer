using UnityEngine;
using System.Collections;

public class MakePlatform : MonoBehaviour 
{
	public GameObject[] platforms; //create platform of this type
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
		}
	}
}
