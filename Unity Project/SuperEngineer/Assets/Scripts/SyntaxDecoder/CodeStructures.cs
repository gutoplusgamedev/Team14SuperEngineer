using UnityEngine;
using System.Collections.Generic;

public enum StructureType
{
	SyntaxItem,
	If,
	ElseIf,
	Else,
	Method,
	VariableDefinition,
	Statement,
	Class
}

public class CodeStructures : Dictionary <StructureType, List<Code>>
{
	public CodeStructures (): base ()
	{
	}

	public bool IsCorrect (List<string> code, out bool done)
	{
		string last = code [code.Count - 1];
		done = false;

		foreach (StructureType type in this.Keys) 
		{
			if(CheckIfMatches (code, type, out done))
			{
				done = IsDone (last, type);
				return true;
			}
		}

		return false;
	}

	private bool IsDone (string last, StructureType type)
	{
		if (type == StructureType.Class | type == StructureType.Else | type == StructureType.ElseIf | type == StructureType.If | type == StructureType.Method) 
		{
			return last == "}";
		}
		else
		{
			return last == ";";
		}
	}

	private bool CheckIfMatches (List<string> code, StructureType type, out bool done)
	{
		done = false;
		bool checkNextOne = false;

		foreach (Code c in this[type]) 
		{	
			checkNextOne = false;
			Debug.Log (type + ", " + c.Count + "\n");
			PrintList (code);

			for (int i = 0; i < code.Count; i++)
			{
				if (c[i].IsBreakInSequence)
				{
					Debug.Log ("Current item '" + c[i].Item + "' is a break in the sequence.");
					return CheckIfMatches (code.GetRange (i, code.Count - (i)), c[i].Type, out done);
				}
				else
				{
					if(c[i].Item != code[i])
					{
						Debug.Log (c[i].Item + " and " + code[i] + " are different from each other.");
						checkNextOne = true;
						break;
					}
				}
			}

			if(!checkNextOne)
			{
				return true;
			}
		}

		return false;
	}

	//helper function
	private void PrintList (List<string> stringL)
	{
		string value = "";
		foreach (string s in stringL) 
		{
			value += s + " ";
		}

		Debug.Log (value);
	}
}
