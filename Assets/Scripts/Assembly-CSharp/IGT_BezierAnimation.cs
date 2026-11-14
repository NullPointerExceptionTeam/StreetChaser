using UnityEngine;

public class IGT_BezierAnimation
{
	public Vector3 StrtPos;

	public Vector3 IntermediatePos;

	public Vector3 TarPos;

	public float fTime;

	public float fAnimSpd;

	public Texture pTexture;

	public float fstrtWidth;

	public float fstrtHeight;

	public float fcenterWidth;

	public float fcenterHeight;

	public float fendWidth;

	public float fendHeight;

	public string textToDisplay;

	public Color textColor;

	public float fFontSize;

	public IGT_BezierAnimation(Vector3 strt, Vector3 centre, Vector3 end, float strTime, float animSpd, float strtWidth, float strtHeight, float centerWidth, float centerHeight, float endWidth, float endHeight, Texture textureToDisplay)
	{
		StrtPos = strt;
		IntermediatePos = centre;
		TarPos = end;
		fTime = strTime;
		fAnimSpd = animSpd;
		fstrtWidth = strtWidth;
		fstrtHeight = strtHeight;
		fcenterWidth = centerWidth;
		fcenterHeight = centerHeight;
		fendWidth = endWidth;
		fendHeight = endHeight;
		pTexture = textureToDisplay;
	}

	public IGT_BezierAnimation(Vector3 strt, Vector3 centre, Vector3 end, float strTime, float animSpd, float strtWidth, float strtHeight, float centerWidth, float centerHeight, float endWidth, float endHeight, string text, Color textcolor, float fontsize)
	{
		StrtPos = strt;
		IntermediatePos = centre;
		TarPos = end;
		fTime = strTime;
		fAnimSpd = animSpd;
		fstrtWidth = strtWidth;
		fstrtHeight = strtHeight;
		fcenterWidth = centerWidth;
		fcenterHeight = centerHeight;
		fendWidth = endWidth;
		fendHeight = endHeight;
		textToDisplay = text;
		textColor = textcolor;
		fFontSize = fontsize;
		pTexture = null;
	}
}
