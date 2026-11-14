using System.IO;
using UnityEngine;

public class IGT_FileReading
{
	public static string[] data;

	public static int nobjLen;

	public TextAsset objData;

	public StringReader StrRdr;

	public static string[] AIPlayerData;

	public static int nAIPlayerCount;

	public static string[] HeroDatas;

	public static int nHeroTotCount;

	public static string[] purchaseItemsDatas_store;

	public static string[] purchaseItemsDatas_Deals;

	public static string[] purchaseItemsDatas_Free;

	public static int nPurchaseItemsCount_store;

	public static int nPurchaseItemsCount_Deals;

	public static int nPurchaseItemsCount_Free;

	public IGT_FileReading()
	{
		data = new string[IGT_Constants.OBJMAXSIZE];
		nobjLen = 0;
		FileRead();
		data = LoadDatafrmFile();
		for (int i = 0; i < data.Length; i++)
		{
			if (data[i] != null)
			{
				nobjLen++;
			}
		}
		AIPlayerData = new string[IGT_Constants.OBJMAXSIZE];
		nAIPlayerCount = 0;
		AIPlayerData = LoadDatafrmFile();
		for (int j = 0; j < AIPlayerData.Length; j++)
		{
			if (AIPlayerData[j] != null)
			{
				nAIPlayerCount++;
			}
		}
		HeroDatas = new string[IGT_Constants.OBJMAXSIZE];
		nHeroTotCount = 0;
		HeroDatas = LoadDatafrmFile();
		for (int k = 0; k < HeroDatas.Length; k++)
		{
			if (HeroDatas[k] != null)
			{
				nHeroTotCount++;
			}
		}
		purchaseItemsDatas_store = new string[IGT_Constants.OBJMAXSIZE];
		nPurchaseItemsCount_store = 0;
		purchaseItemsDatas_store = LoadDatafrmFile();
		for (int l = 0; l < purchaseItemsDatas_store.Length; l++)
		{
			if (purchaseItemsDatas_store[l] != null)
			{
				nPurchaseItemsCount_store++;
			}
		}
		purchaseItemsDatas_Deals = new string[IGT_Constants.OBJMAXSIZE];
		nPurchaseItemsCount_Deals = 0;
		purchaseItemsDatas_Deals = LoadDatafrmFile();
		for (int m = 0; m < purchaseItemsDatas_Deals.Length; m++)
		{
			if (purchaseItemsDatas_Deals[m] != null)
			{
				nPurchaseItemsCount_Deals++;
			}
		}
		purchaseItemsDatas_Free = new string[IGT_Constants.OBJMAXSIZE];
		nPurchaseItemsCount_Free = 0;
		purchaseItemsDatas_Free = LoadDatafrmFile();
		for (int n = 0; n < purchaseItemsDatas_Free.Length; n++)
		{
			if (purchaseItemsDatas_Free[n] != null)
			{
				nPurchaseItemsCount_Free++;
			}
		}
	}

	public void FileRead()
	{
		objData = (TextAsset)Resources.Load("Info/objDetails", typeof(TextAsset));
		StrRdr = new StringReader(objData.text);
	}

	public string[] LoadDatafrmFile()
	{
		int num = 0;
		int num2 = int.Parse(GetLineCnt());
		string[] array = new string[num2];
		for (int i = 0; i < num2; i++)
		{
			string lineCnt = GetLineCnt();
			if (lineCnt == null && lineCnt.Length == 0)
			{
				break;
			}
			array[num] = lineCnt;
			num++;
		}
		return array;
	}

	public string GetLineCnt()
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
