using UnityEngine;

public class IGT_ScrollData
{
	public string Id;

	public string Rank;

	public string Name;

	public string Score;

	public Texture2D pTexture;

	public IGT_ScrollData(string id, string rank, string name, string score, Texture2D tex)
	{
		Id = id;
		Rank = rank;
		Name = name;
		Score = score;
		pTexture = tex;
	}
}
