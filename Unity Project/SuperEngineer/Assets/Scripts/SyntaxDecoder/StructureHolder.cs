using UnityEngine;
using System.Collections.Generic;

public class StructureHolder : MonoBehaviour
{
	public CodeStructures structures;
	private static StructureHolder _instance;

	public static bool IsCorrect (List<string> code, out bool isDone)
	{
		return _instance.structures.IsCorrect (code, out isDone);
	}

	void Start ()
	{
		_instance = this;
		structures = DataParser.ParseStructures ("syntaxStructure");
		List<string> stringList = new List<string> ();
		stringList.Add ("if");
		stringList.Add ("(");
		stringList.Add ("booleanExpression");
		stringList.Add (")");
		stringList.Add ("{");
		stringList.Add ("variableName");
		stringList.Add ("=");
		stringList.Add ("variableValue");
		stringList.Add (";");
		stringList.Add ("}");
		bool done = false;
		if (structures.IsCorrect (stringList, out done)) {
			print ("this structure is correct and the value for done is " + done);
		}
	}
}