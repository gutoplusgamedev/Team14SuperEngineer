using UnityEngine;
using System.Collections;
using System.Xml;

public class SyntaxInstantiator : MonoBehaviour 
{
	private string[] parsedSyntax;
	public GameObject textPrefab;

	void Start ()
	{
		ParseSyntaxInformation ();
		MakePlatform.OnPlatformInstantiated += OnPlatformInstantiated;
	}

	void ParseSyntaxInformation ()
	{
		XmlDocument doc = new XmlDocument();
		doc.Load("Assets/Resources/ValidSyntax.xml");
		XmlNodeList nodes = doc.DocumentElement.SelectNodes("/validSyntax/symbol");
		
		parsedSyntax = new string[nodes.Count];

		for (int i = 0; i < nodes.Count; i++) 
		{
			parsedSyntax[i] = nodes[i].InnerText;
		}
	}

	void OnDisable ()
	{
		MakePlatform.OnPlatformInstantiated += OnPlatformInstantiated;
	}

	void OnPlatformInstantiated (Vector3 position, Vector3 finalPosition)
	{
		if (Random.Range (0f, 1f) <= 0.5f) 
		{
			InstantiateSyntax (position + Vector3.up);
		}
	}

	void InstantiateSyntax (Vector3 position)
	{
		GameObject go = (GameObject)Instantiate (textPrefab, position, Quaternion.identity);
		string syntax = parsedSyntax [Random.Range (0, parsedSyntax.Length)];
		foreach (TextMesh m in go.GetComponentsInChildren<TextMesh>()) 
		{
			m.text = syntax;
		}
	}
}
