using UnityEngine;

public class IGT_DisplayProperties
{
	public int ID;

	public Rect drawPos;

	public Texture pTexture;

	public float fStrtTime;

	public float fTotTime;

	public float fAnimStrtTime;

	public float fAnimTotTime;

	public IGT_DisplayProperties(int id, Rect pos, Texture tex, float strtTime, float totTime)
	{
		ID = id;
		drawPos = pos;
		pTexture = tex;
		fStrtTime = strtTime;
		fTotTime = totTime;
		fAnimStrtTime = 0f;
		fAnimTotTime = 1f;
	}
}
