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

	public static string GetSyntaxString ()
	{
		string returnStr = string.Empty;
		foreach (string s in syntaxCollection) 
		{
			returnStr += s;
			if (s == "{" || s == ";" || s == "}")
			{
				returnStr += "\n";
			}
			else
			{
				returnStr += " ";
			}
		}

		return returnStr;
	}

	void Update() 
	{
		counter += Time.deltaTime;
		if (counter > 1) 
		{
			counter--;
			GameMaster.points += pointsPerSecond;
		}
	}
	
	void OnTriggerEnter(Collider info) 
	{
		if (info.CompareTag("syntax"))
		{
			syntaxCollection.Add (info.gameObject.GetComponent<TextMesh> ().text);
			
			bool done;
			if (!StructureHolder.IsCorrect (syntaxCollection, out done)) 
			{
				GameMaster.points += pointsPerIncorrect;
				DialogueController.ShowDialogueBox = true;
				syntaxCollection = new List<string> ();
				deathCounter--;
				if (deathCounter == 0)
				{
					GameOver.OnGameOver ();
				}
			}
			else
			{
				GameMaster.points += pointsPerSyntax;
			
				if (done)
				{
					GameMaster.points += syntaxCollection.Count * pointsPerSyntaxCompletion;
					syntaxCollection = new List<string> ();
				}
			}
		}
	}
}
