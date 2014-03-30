using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SyntaxCollector : MonoBehaviour {
	
	public int pointsPerSyntax = 10;
	public int pointsPerSyntaxCompletion = 10;
	public int pointsPerSecond = 1;
	public int pointsPerIncorrect = -10;
	public int maxIncorrectSyntax = 5;

	public static int deathCounter;
	public static int points;
	public static List<string> syntaxCollection = null;

	private float counter;
	
	// Use this for initialization
	void Start() 
	{
		deathCounter = maxIncorrectSyntax;
		points = 0;
		counter = 0;
		syntaxCollection = new List<string>();
	}
	
	void Update() 
	{
		counter += Time.deltaTime;
		if (counter > 1) 
		{
			counter--;
			points += pointsPerSecond;
		}
	}
	
	void OnTriggerEnter(Collider info) 
	{
		if (info.CompareTag("syntax"))
		{
			syntaxCollection.Add (info.gameObject.GetComponent<TextMesh> ().text);
			Destroy (info.gameObject);
			
			//bool done;
			//if (!isCorrect (syntaxCollection, out done)) 
			//{
			//	points += pointsPerIncorrect;
			//	syntaxCollection = new List<string> ();
			//	deathCounter--;
			//	if (DeathCounter == 0)
			//	{
			//		//die!
			//	}
			//}
			//else
			//
				points += pointsPerSyntax;
			
			//if (done)
			//{
			//	points += syntaxCollection.Count * pointsPerSyntaxCompletion;
			//	syntaxCollection = new List<string> ();
			//}
		}
	}
}
