using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class IGT_File
{
	public List<string> readFile(string _filePath)
	{
		List<string> list = new List<string>();
		TextAsset textAsset = (TextAsset)Resources.Load(_filePath, typeof(TextAsset));
		StringReader stringReader = new StringReader(textAsset.text);
		while (true)
		{
			string text = stringReader.ReadLine();
			if (text == null)
			{
				break;
			}
			list.Add(text);
		}
		return list;
	}

	public void writeFile(string _filePath, object _writeTxt)
	{
		using (StreamWriter streamWriter = File.AppendText(_filePath))
		{
			streamWriter.Write(_writeTxt);
			streamWriter.Write(Environment.NewLine);
			streamWriter.Close();
		}
	}
}
