using UnityEngine;
using System.Collections;

public class PropCreator: MonoBehaviour 
{
	public GameObject[] trees;
	public GameObject rock;
	public float distanceFromPlatforms;
	public float rockHeight;
	
	void Awake ()
	{
		MakePlatform.OnPlatformInstantiated += OnPlatformInstantiated;
	}

	void OnDisable ()
	{
		MakePlatform.OnPlatformInstantiated -= OnPlatformInstantiated;
	}

	void OnPlatformInstantiated (Vector3 position, Vector3 finalPosition)
	{
		InstantiateTrees (Random.Range (1, 5), position, finalPosition);
		InstantiateRocks (Random.Range (1, 6), position, finalPosition);
	}

	void InstantiateTrees (int howMany, Vector3 from, Vector3 to)
	{
		float diff = (to - from).magnitude;
		for (float f = 0; f < diff; f += diff/howMany) 
		{
			InstantiateTree (from + (Vector3.right * f) + (Vector3.forward * distanceFromPlatforms));
		}
	}

	void InstantiateRocks (int howMany, Vector3 from, Vector3 to)
	{
		float diff = (to - from).magnitude;
		for (float f = 0; f < diff; f += diff/howMany)
		{
			InstantiateRock (from + (Vector3.right * f) - (Vector3.forward * distanceFromPlatforms) + (Vector3.up * rockHeight));
		}
	}

	void InstantiateTree (Vector3 position)
	{
		Quaternion rot = Quaternion.Euler (new Vector3 (-90, Random.Range (0, 270), 0));
		GameObject tree = (GameObject) Instantiate (trees[Random.Range(0, trees.Length)], position, rot);
		tree.transform.localScale = Vector3.one * Random.Range (0.7f, 1f);
	}

	void InstantiateRock (Vector3 position)
	{
		Quaternion rot = Quaternion.Euler (new Vector3 (-90, Random.Range (0, 270), 0));
		GameObject newRock = (GameObject)Instantiate (rock, position, rot);
		newRock.transform.localScale = Vector3.one * Random.Range (0.3f, 1f);
	}
}
