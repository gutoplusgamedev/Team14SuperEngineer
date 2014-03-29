using UnityEngine;
using System.Collections;

public class CodePiece 
{
	private string _item;
	private StructureType _codeType;

	public CodePiece (string item, StructureType type = StructureType.SyntaxItem)
	{
		_item = item;
		_codeType = type;
	}

	public bool IsBreakInSequence 
	{
		get { return _codeType != StructureType.SyntaxItem; }
	}

	public string Item
	{
		get { return _item; }
	}

	public StructureType Type
	{
		get { return _codeType; }
	}
}