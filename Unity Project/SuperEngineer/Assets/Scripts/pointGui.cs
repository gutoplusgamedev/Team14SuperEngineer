using UnityEngine;
using System.Collections;

public class pointGui : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		string s = "";
		if (SyntaxCollector.syntaxCollection != null) 
		{
			foreach ( string i in SyntaxCollector.syntaxCollection )
			{
				s += (i + " ");
			}
		}
		GUI.Box(new Rect(10, 40, 100, 20), "Score: " + SyntaxCollector.points );
		GUI.Box(new Rect(10, 10, Screen.width - 20, 20), s );
	}
}
