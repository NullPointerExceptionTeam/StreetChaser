using UnityEngine;

public class IGT_UIcommonFunc
{
	public static float reScaleX(float x)
	{
		return x / (float)Screen.width * 320f;
	}

	public static float reScaleY(float y)
	{
		return y / (float)Screen.height * 480f;
	}

	public static float ScaleX(float x)
	{
		return x / 320f * (float)Screen.width;
	}

	public static float ScaleY(float y)
	{
		return y / 480f * (float)Screen.height;
	}
}
