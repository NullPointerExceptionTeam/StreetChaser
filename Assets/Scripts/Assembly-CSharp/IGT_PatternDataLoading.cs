using System.IO;
using UnityEngine;

public class IGT_PatternDataLoading
{
	private TextAsset FileInputDatas;

	private StringReader StrRdr;

	public int nTotalPatternCount;

	public int[][] nPatternParams;

	public int[][][] nPatternDatas;

	public IGT_PatternDataLoading()
	{
		FileInputDatas = (TextAsset)Resources.Load("Info/Patterns", typeof(TextAsset));
		StrRdr = new StringReader(FileInputDatas.text);
		nTotalPatternCount = int.Parse(GetLinesDatas());
		nPatternParams = new int[nTotalPatternCount][];
		nPatternDatas = new int[nTotalPatternCount][][];
		for (int i = 0; i < nTotalPatternCount; i++)
		{
			string[] array = GetLinesDatas().Split('~');
			nPatternParams[i] = new int[array.Length];
			for (int j = 0; j < array.Length; j++)
			{
				nPatternParams[i][j] = int.Parse(array[j]);
			}
			string[] array2 = readLinesBasedGivenCount(int.Parse(array[0]));
			nPatternDatas[i] = new int[array2.Length][];
			for (int k = 0; k < array2.Length; k++)
			{
				string[] array3 = array2[k].Split('\t');
				nPatternDatas[i][k] = new int[array3.Length];
				for (int l = 0; l < array3.Length; l++)
				{
					nPatternDatas[i][k][l] = int.Parse(array3[l]);
				}
			}
		}
	}

	private string[] readLinesBasedGivenCount(int count)
	{
		int num = 0;
		string[] array = new string[count];
		for (int i = 0; i < count; i++)
		{
			string linesDatas = GetLinesDatas();
			if (linesDatas == null && linesDatas.Length == 0)
			{
				break;
			}
			array[num] = linesDatas;
			num++;
		}
		return array;
	}

	private string GetLinesDatas()
	{
		string text = null;
		do
		{
			text = StrRdr.ReadLine();
		}
		while (text != null && (text.StartsWith("//") || text.Length == 0));
		if (text == null)
		{
			StrRdr.Close();
		}
		return text;
	}
}
