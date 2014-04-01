using UnityEngine;
using System.Collections;

public class DialogueController : MonoBehaviour 
{
	public Texture2D dialogueBox;
	private static bool _showDialogueBox;
	public string[] dialogueArray;
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
					_currentDialogue = _instance.dialogueArray [Random.Range (0, _instance.dialogueArray.Length)];
					_instance.StartCoroutine (_instance.TurnDialoguesOff());
				}
			}
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
