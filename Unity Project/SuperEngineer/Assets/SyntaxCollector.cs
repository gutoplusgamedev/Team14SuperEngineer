using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SyntaxCollector : MonoBehaviour {
	
	public int pointsPerSyntax = 10;
	public int pointsPerCompletion = 50;
	public int pointsPerSecond = 1;
	public int pointsPerIncorrect = -10;
	public static int points;
	
	private List<string> syntaxCollection;
	private float counter;
	
	// Use this for initialization
	void Start() 
	{
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
			//}
			
			//if (done)
			//{
			//	points += pointsPerCompletion;
			//	syntaxCollection = new List<string> ();
			//}
			
			points += pointsPerSyntax;
		}
	}
}
