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
	}
}