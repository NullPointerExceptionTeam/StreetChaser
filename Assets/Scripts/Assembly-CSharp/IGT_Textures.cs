using System.Collections.Generic;
using UnityEngine;

public class IGT_Textures
{
	private Dictionary<string, Texture> ImageDict = new Dictionary<string, Texture>();

	public void LoadTexture(string key)
	{
		if (!ImageDict.ContainsKey(key))
		{
			ImageDict.Add(key, Resources.Load(key) as Texture);
		}
	}

	public void LoadTextureByData(byte[] datas, string Key)
	{
		Texture2D texture2D = new Texture2D(100, 100);
		texture2D.LoadImage(datas);
		if (!ImageDict.ContainsKey(Key))
		{
			ImageDict.Add(Key, texture2D);
		}
	}

	public void forceLoadTexture(string key)
	{
		if (!ImageDict.ContainsKey(key))
		{
			ImageDict.Add(key, Resources.Load(key) as Texture);
		}
		else
		{
			ImageDict[key] = Resources.Load(key) as Texture;
		}
	}

	public void forceLoadTextureByData(byte[] datas, string Key)
	{
		Texture2D texture2D = new Texture2D(1, 1);
		texture2D.LoadImage(datas);
		if (!ImageDict.ContainsKey(Key))
		{
			ImageDict.Add(Key, texture2D);
		}
		else
		{
			ImageDict[Key] = texture2D;
		}
	}

	public Texture GetTexture(string key)
	{
		if (ImageDict.ContainsKey(key))
		{
			return ImageDict[key];
		}
		return null;
	}

	public void DrawTexture(string texKey, float x, float y, float width, float height)
	{
		if (ImageDict.ContainsKey(texKey))
		{
			GUI.DrawTexture(new Rect(x, y, width, height), ImageDict[texKey]);
		}
	}

	public void DrawTexture(string texKey, Rect ImgRect, bool isSameRatio)
	{
		if (ImageDict.ContainsKey(texKey))
		{
			if (!isSameRatio)
			{
				GUI.DrawTexture(ImgRect, ImageDict[texKey]);
			}
			else
			{
				GUI.DrawTexture(new Rect(ImgRect.x, ImgRect.y, ImgRect.width, IGT_UIcommonFunc.reScaleX(ImgRect.width) / IGT_UIcommonFunc.reScaleY(ImgRect.height) * ImgRect.width), ImageDict[texKey]);
			}
		}
	}

	public void DrawTextureFromCenter(string texKey, Rect ImgRect, float angle = 0f, Vector2 pivot = default(Vector2))
	{
		if (ImageDict.ContainsKey(texKey))
		{
			if (angle != 0f)
			{
				Matrix4x4 matrix = GUI.matrix;
				GUIUtility.RotateAroundPivot(angle, new Vector2(ImgRect.x + ImgRect.width * pivot.x, ImgRect.y + ImgRect.height * pivot.y));
				GUI.DrawTexture(new Rect(ImgRect.x - ImgRect.width / 2f, ImgRect.y - ImgRect.height / 2f, ImgRect.width, IGT_UIcommonFunc.reScaleX(ImgRect.width) / IGT_UIcommonFunc.reScaleY(ImgRect.height) * ImgRect.width), ImageDict[texKey]);
				GUI.matrix = matrix;
			}
			else
			{
				GUI.DrawTexture(new Rect(ImgRect.x - ImgRect.width / 2f, ImgRect.y - ImgRect.height / 2f, ImgRect.width, ImgRect.height), ImageDict[texKey]);
			}
		}
	}

	public void DrawTexture(string texKey, Rect ImgRect, float angle, Vector2 pivot)
	{
		if (ImageDict.ContainsKey(texKey))
		{
			Matrix4x4 matrix = GUI.matrix;
			GUIUtility.RotateAroundPivot(angle, new Vector2(ImgRect.x + ImgRect.width * pivot.x, ImgRect.y + ImgRect.height * pivot.y));
			GUI.DrawTexture(ImgRect, ImageDict[texKey]);
			GUI.matrix = matrix;
		}
	}

	public void DrawTexture_SameRatio(string texKey, float x, float y, float width, float height)
	{
		if (ImageDict.ContainsKey(texKey))
		{
			GUI.DrawTexture(new Rect(x, y, width, IGT_UIcommonFunc.reScaleX(width) / IGT_UIcommonFunc.reScaleY(height) * width), ImageDict[texKey]);
		}
	}

	public void Draw_MirroredTexture(string texKey, Rect ImgDrawRect, Rect whatToMirrorRect, bool isCenterPoint)
	{
		if (ImageDict.ContainsKey(texKey))
		{
			if (!isCenterPoint)
			{
				GUI.DrawTextureWithTexCoords(ImgDrawRect, ImageDict[texKey], whatToMirrorRect);
			}
			else
			{
				GUI.DrawTextureWithTexCoords(new Rect(ImgDrawRect.x, ImgDrawRect.y, ImgDrawRect.width, IGT_UIcommonFunc.reScaleX(ImgDrawRect.width) / IGT_UIcommonFunc.reScaleY(ImgDrawRect.height) * ImgDrawRect.width), ImageDict[texKey], whatToMirrorRect);
			}
		}
	}

	public void drawBorder(Rect rectDimension, float borderWidth, Texture pTex)
	{
		GUI.DrawTexture(new Rect(rectDimension.xMin, rectDimension.yMin, rectDimension.width, borderWidth), pTex);
		GUI.DrawTexture(new Rect(rectDimension.xMin, rectDimension.yMin, borderWidth, rectDimension.height), pTex);
		GUI.DrawTexture(new Rect(rectDimension.xMax - borderWidth, rectDimension.yMin, borderWidth, rectDimension.height), pTex);
		GUI.DrawTexture(new Rect(rectDimension.xMin, rectDimension.yMax - borderWidth, rectDimension.width, borderWidth), pTex);
	}

	public void DrawTexture_coords(string texkey, Rect ImgRect, Rect CropRect)
	{
		if (ImageDict.ContainsKey(texkey))
		{
			GUI.DrawTextureWithTexCoords(ImgRect, ImageDict[texkey], CropRect);
		}
	}

	public Texture2D Get_MirroredTexture(Texture2D original)
	{
		Texture2D texture2D = new Texture2D(original.width, original.height);
		int width = original.width;
		int height = original.height;
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				texture2D.SetPixel(width - i - 1, j, original.GetPixel(i, j));
			}
		}
		texture2D.Apply();
		return texture2D;
	}
}
