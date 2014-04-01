using UnityEngine;
using System.Xml;
using System.IO;
using System;
using System.Collections.Generic;

public class DataParser
{
	public static CodeStructures ParseStructures (string path)
	{
		TextAsset asset = Resources.Load <TextAsset> (path);
		XmlReader reader = XmlReader.Create (new StringReader (asset.text));
		CodeStructures structures = new CodeStructures ();
		StructureType currentType = StructureType.SyntaxItem;
		Code currentCode = null;
		
		while (reader.Read()) 
		{
			if (reader.IsStartElement ("code"))
			{
				if (currentCode != null && currentCode.Count > 0 && structures.ContainsKey (currentType))
				{
					structures [currentType].Add (currentCode);
					currentCode = new Code();
				}
				currentType = (StructureType) Enum.Parse (typeof (StructureType), reader.GetAttribute ("type"));
				structures.Add (currentType, new List<Code>());
			}
			
			if (reader.IsStartElement ("structure"))
			{
				if (currentCode != null && currentCode.Count > 0)
				{
					structures[currentType].Add (currentCode);
				}
				
				currentCode = new Code();
			}
			
			if (reader.IsStartElement ("syntax"))
			{
				string currentPiece = reader.ReadElementContentAsString ();
				StructureType pieceStructure = StructureType.SyntaxItem;
				if (currentPiece [0] == '@')
				{
					currentPiece = currentPiece.Substring (1);
					pieceStructure = (StructureType) Enum.Parse (typeof (StructureType), currentPiece);
				}
				
				currentCode.Add (new CodePiece (currentPiece, pieceStructure));
			}
		}
		
		return structures;
	}
}