using UnityEngine;
using System.Collections;

public class DialogueController : MonoBehaviour 
{
	public Texture2D dialogueBox;
	private static bool _showDialogueBox;
	public string[] badDialogueArray, goodDialogueArray;
	private static string _currentDialogue;
	private static DialogueController _instance;

	public static bool ShowDialogueBox 
	{
		get { return _showDialogueBox; }
		set {
			if (_showDialogueBox != value) 
			{
				_showDialogueBox = value;
				if (_showDialogueBox) 
				{
					_instance.StartCoroutine (_instance.TurnDialoguesOff());
				}
			}
		}
	}

	public static void GenerateDialogue (bool goodDialogue)
	{
		ShowDialogueBox = true;

		if(goodDialogue)
		{
			_currentDialogue = _instance.goodDialogueArray[Random.Range (0, _instance.goodDialogueArray.Length)];
		}
		else
		{
			_currentDialogue = _instance.badDialogueArray[Random.Range (0, _instance.badDialogueArray.Length)];
		}
	}
			
	void Awake ()
	{
		_showDialogueBox = false;
		_instance = this;
	}

	void OnGUI ()
	{
		if (_showDialogueBox)
		{
			GUI.DrawTexture (new Rect (0, 100, dialogueBox.width, dialogueBox.height), dialogueBox);
			GUI.color = Color.black;
			GUI.Label (new Rect (100, 140, 200, 200), _currentDialogue);
		}
	}

	public IEnumerator TurnDialoguesOff ()
	{
		yield return new WaitForSeconds (5);
		_showDialogueBox = false;
	}
}
