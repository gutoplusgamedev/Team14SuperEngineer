using UnityEngine;
using System.Collections.Generic;

public enum StructureType
{
	SyntaxItem,
	If,
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
		done = false;
		
		foreach (StructureType type in this.Keys) 
		{
			if(CheckIfMatches (code, type, out done))
			{
				return true;
			}
		}
		
		return false;
	}	

	private bool CheckIfMatches (List<string> code, StructureType type, out bool done)
	{
		done = false;

		foreach (Code c in this[type])
		{
			if (code.Count > c.Count)
			{
				continue;
			}
			else
			{
				done = c.Count == code.Count;
				if(FromListToString(c).Contains (FromListToString (code)))
				{
					return false;
				}
				else
				{
					continue;
				}
			}
		}

		return false;
	}

	private string FromListToString (List<CodePiece> list)
	{
		string str = string.Empty;
		foreach (CodePiece cp in list) 
		{
			str += cp.Item;
		}

		return str;
	}

	private string FromListToString (List<string> list)
	{
		string str = string.Empty;
		foreach (string s in list) 
		{
			str += s;
		}

		return str;
	}
}