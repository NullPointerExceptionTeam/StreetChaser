using System.Collections.Generic;
using UnityEngine;

public class IGT_Lable
{
	private Dictionary<string, Font> FontDict = new Dictionary<string, Font>();

	public void LoadFont(string key)
	{
		if (!FontDict.ContainsKey(key))
		{
			FontDict.Add(key, (Font)Resources.Load(key));
		}
		else
		{
			Debug.Log(" Already Font loaded : " + key);
		}
	}

	public Font getFont(string key)
	{
		if (!FontDict.ContainsKey(key))
		{
			return null;
		}
		return FontDict[key];
	}

	public void DrawLableFromCenter(Rect position, string text, string fontKey, int fontSize, TextAnchor txtAlignment, bool isWordWrapNeed, Color fontColor, float strokeWidth, Color strokeColor, Vector2 ShadowWidth, Color shadowColor, float rotaionAngle, Vector2 rotationPivot)
	{
		text = IGT_CN.Translate(text);
		position.x -= position.width / 2f;
		position.y -= position.height / 2f;
		GUIStyle gUIStyle = new GUIStyle();
		if (fontSize <= 0)
		{
			fontSize = 1;
		}
		gUIStyle.fontSize = fontSize;
		gUIStyle.alignment = txtAlignment;
		gUIStyle.wordWrap = isWordWrapNeed;
		if (FontDict.ContainsKey(fontKey))
		{
			gUIStyle.font = FontDict[fontKey];
			Matrix4x4 matrix = GUI.matrix;
			GUIUtility.RotateAroundPivot(rotaionAngle, new Vector2(position.x + position.width * rotationPivot.x, position.y + position.height * rotationPivot.y));
			gUIStyle.normal.textColor = strokeColor;
			position.x -= strokeWidth;
			GUI.Label(position, text, gUIStyle);
			position.x += strokeWidth * 2f;
			GUI.Label(position, text, gUIStyle);
			position.x -= strokeWidth;
			position.y -= strokeWidth;
			GUI.Label(position, text, gUIStyle);
			position.y += strokeWidth * 2f;
			GUI.Label(position, text, gUIStyle);
			position.y -= strokeWidth;
			gUIStyle.normal.textColor = fontColor;
			GUI.Label(position, text, gUIStyle);
			gUIStyle.normal.textColor = shadowColor;
			position.x += ShadowWidth.x;
			position.y += ShadowWidth.y;
			GUI.Label(position, text, gUIStyle);
			gUIStyle.normal.textColor = fontColor;
			position.x -= ShadowWidth.x;
			position.y -= ShadowWidth.y;
			GUI.Label(position, text, gUIStyle);
			GUI.matrix = matrix;
		}
		else
		{
			Debug.Log("Specified font not present ");
		}
	}

	public void DrawLable(Rect position, string text, string fontKey, int fontSize, TextAnchor txtAlignment, bool isWordWrapNeed, Color fontColor, float strokeWidth, Color strokeColor, Vector2 ShadowWidth, Color shadowColor, float rotaionAngle, Vector2 rotationPivot)
	{
		text = IGT_CN.Translate(text);
		GUIStyle gUIStyle = new GUIStyle();
		if (fontSize <= 0)
		{
			fontSize = 1;
		}
		gUIStyle.fontSize = fontSize;
		gUIStyle.alignment = txtAlignment;
		gUIStyle.wordWrap = isWordWrapNeed;
		if (FontDict.ContainsKey(fontKey))
		{
			gUIStyle.font = FontDict[fontKey];
			Matrix4x4 matrix = GUI.matrix;
			GUIUtility.RotateAroundPivot(rotaionAngle, new Vector2(position.x + position.width * rotationPivot.x, position.y + position.height * rotationPivot.y));
			gUIStyle.normal.textColor = strokeColor;
			position.x -= strokeWidth;
			GUI.Label(position, text, gUIStyle);
			position.x += strokeWidth * 2f;
			GUI.Label(position, text, gUIStyle);
			position.x -= strokeWidth;
			position.y -= strokeWidth;
			GUI.Label(position, text, gUIStyle);
			position.y += strokeWidth * 2f;
			GUI.Label(position, text, gUIStyle);
			position.y -= strokeWidth;
			gUIStyle.normal.textColor = fontColor;
			GUI.Label(position, text, gUIStyle);
			gUIStyle.normal.textColor = shadowColor;
			position.x += ShadowWidth.x;
			position.y += ShadowWidth.y;
			GUI.Label(position, text, gUIStyle);
			gUIStyle.normal.textColor = fontColor;
			position.x -= ShadowWidth.x;
			position.y -= ShadowWidth.y;
			GUI.Label(position, text, gUIStyle);
			GUI.matrix = matrix;
		}
		else
		{
			Debug.Log("Specified font not present ");
		}
	}

	public void DrawLable(Rect position, string text, string fontKey, int fontSize, TextAnchor txtAlignment, bool isWordWrapNeed, Color fontColor, float strokeWidth, Color strokeColor, Vector2 ShadowWidth, Color shadowColor)
	{
		text = IGT_CN.Translate(text);
		GUIStyle gUIStyle = new GUIStyle();
		if (fontSize <= 0)
		{
			fontSize = 1;
		}
		gUIStyle.fontSize = fontSize;
		gUIStyle.alignment = txtAlignment;
		gUIStyle.wordWrap = isWordWrapNeed;
		if (FontDict.ContainsKey(fontKey))
		{
			gUIStyle.font = FontDict[fontKey];
			gUIStyle.normal.textColor = strokeColor;
			position.x -= strokeWidth;
			GUI.Label(position, text, gUIStyle);
			position.x += strokeWidth * 2f;
			GUI.Label(position, text, gUIStyle);
			position.x -= strokeWidth;
			position.y -= strokeWidth;
			GUI.Label(position, text, gUIStyle);
			position.y += strokeWidth * 2f;
			GUI.Label(position, text, gUIStyle);
			position.y -= strokeWidth;
			gUIStyle.normal.textColor = fontColor;
			GUI.Label(position, text, gUIStyle);
			gUIStyle.normal.textColor = shadowColor;
			position.x += ShadowWidth.x;
			position.y += ShadowWidth.y;
			GUI.Label(position, text, gUIStyle);
			gUIStyle.normal.textColor = fontColor;
			position.x -= ShadowWidth.x;
			position.y -= ShadowWidth.y;
			GUI.Label(position, text, gUIStyle);
		}
		else
		{
			Debug.Log("Specified font not present ");
		}
	}

	public void DrawLable(Rect position, string text, string fontKey, int fontSize, TextAnchor txtAlignment, bool isWordWrapNeed, Color fontColor, float strokeWidth, Color strokeColor)
	{
		text = IGT_CN.Translate(text);
		GUIStyle gUIStyle = new GUIStyle();
		if (fontSize <= 0)
		{
			fontSize = 1;
		}
		gUIStyle.fontSize = fontSize;
		gUIStyle.alignment = txtAlignment;
		gUIStyle.wordWrap = isWordWrapNeed;
		if (FontDict.ContainsKey(fontKey))
		{
			gUIStyle.font = FontDict[fontKey];
			gUIStyle.normal.textColor = strokeColor;
			position.x -= strokeWidth;
			GUI.Label(position, text, gUIStyle);
			position.x += strokeWidth * 2f;
			GUI.Label(position, text, gUIStyle);
			position.x -= strokeWidth;
			position.y -= strokeWidth;
			GUI.Label(position, text, gUIStyle);
			position.y += strokeWidth * 2f;
			GUI.Label(position, text, gUIStyle);
			position.y -= strokeWidth;
			gUIStyle.normal.textColor = fontColor;
			GUI.Label(position, text, gUIStyle);
		}
		else
		{
			Debug.Log("Specified font not present ");
		}
	}

	public void DrawLable(Rect position, string text, string fontKey, int fontSize, TextAnchor txtAlignment, bool isWordWrapNeed, Color fontColor, Vector2 ShadowWidth, Color shadowColor)
	{
		text = IGT_CN.Translate(text);
		GUIStyle gUIStyle = new GUIStyle();
		if (fontSize <= 0)
		{
			fontSize = 1;
		}
		gUIStyle.fontSize = fontSize;
		gUIStyle.alignment = txtAlignment;
		gUIStyle.wordWrap = isWordWrapNeed;
		if (FontDict.ContainsKey(fontKey))
		{
			gUIStyle.font = FontDict[fontKey];
			gUIStyle.normal.textColor = shadowColor;
			position.x += ShadowWidth.x;
			position.y += ShadowWidth.y;
			GUI.Label(position, text, gUIStyle);
			gUIStyle.normal.textColor = fontColor;
			position.x -= ShadowWidth.x;
			position.y -= ShadowWidth.y;
			GUI.Label(position, text, gUIStyle);
		}
		else
		{
			Debug.Log("Specified font not present ");
		}
	}

	public void DrawLable(Rect position, string text, string fontKey, int fontSize, Color fontColor, TextAnchor txtAlignment, bool isWordWrapNeed, float rotationAngle = 0f, float pivotX = 0f, float pivotY = 0f)
	{
		text = IGT_CN.Translate(text);
		GUIStyle gUIStyle = new GUIStyle();
		if (fontSize <= 0)
		{
			fontSize = 1;
		}
		gUIStyle.fontSize = fontSize;
		gUIStyle.normal.textColor = fontColor;
		gUIStyle.alignment = txtAlignment;
		gUIStyle.wordWrap = isWordWrapNeed;
		if (FontDict.ContainsKey(fontKey))
		{
			gUIStyle.font = FontDict[fontKey];
			if (rotationAngle != 0f)
			{
				GUIUtility.RotateAroundPivot(rotationAngle, new Vector2(position.x + position.width * pivotX, position.y + position.height * pivotY));
				GUI.Label(position, text, gUIStyle);
				GUI.matrix = Matrix4x4.identity;
			}
			else
			{
				GUI.Label(position, text, gUIStyle);
			}
		}
		else
		{
			Debug.Log("Specified font not present :" + fontKey);
		}
	}

	public void DrawLable(float x, float y, float w, float h, string text, string fontKey, int fontSize, Color fontColor, TextAnchor txtAlignment, bool isWordWrapNeed = false, float rotaionAngle = 0f, float pivotX = 0f, float pivotY = 0f)
	{
		text = IGT_CN.Translate(text);
		GUIStyle gUIStyle = new GUIStyle();
		if (FontDict.ContainsKey(fontKey))
		{
			gUIStyle.font = FontDict[fontKey];
			if (fontSize <= 0)
			{
				fontSize = 1;
			}
			gUIStyle.fontSize = fontSize;
			gUIStyle.normal.textColor = fontColor;
			gUIStyle.alignment = txtAlignment;
			gUIStyle.wordWrap = isWordWrapNeed;
			GUIUtility.RotateAroundPivot(rotaionAngle, new Vector2(x + w * pivotX, y + h * pivotY));
			GUI.Label(new Rect(x, y, w, h), text, gUIStyle);
			GUI.matrix = Matrix4x4.identity;
		}
		else
		{
			Debug.Log("Specified font not present :" + fontKey);
		}
	}
}
