using System;
using UnityEngine;

public class IGT_Animator
{
	private float fAnimStartTime;

	private float fAnimCurTime;

	private float fEndAnimCurTime;

	private bool bEndingAnimStart;

	private bool bAnimFinished;

	private bool isReverse;

	public void resetAllValues()
	{
		fAnimCurTime = 0f;
		fEndAnimCurTime = 0f;
		fAnimStartTime = Time.time;
		bEndingAnimStart = false;
		bAnimFinished = false;
		isReverse = false;
	}

	public bool isAnimFinished()
	{
		return bAnimFinished;
	}

	public void setAnimFinished(bool flag)
	{
		bAnimFinished = flag;
	}

	public void setIsReverse(bool flag)
	{
		isReverse = flag;
	}

	public bool getIsReverse()
	{
		return isReverse;
	}

	public float easeFunctions(float strt, float end, float fTotDuration, int EaseType)
	{
		float result = end;
		if (isReverse)
		{
			result = strt;
		}
		if (fAnimCurTime <= fTotDuration)
		{
			switch (EaseType)
			{
			case 29:
				result = (isReverse ? IGT_EaseFunction.Back_easeOut(fAnimCurTime, end, strt, fTotDuration) : IGT_EaseFunction.Back_easeOut(fAnimCurTime, strt, end, fTotDuration));
				break;
			case 28:
				result = (isReverse ? IGT_EaseFunction.Back_easeIn(fAnimCurTime, end, strt, fTotDuration) : IGT_EaseFunction.Back_easeIn(fAnimCurTime, strt, end, fTotDuration));
				break;
			case 30:
				result = (isReverse ? IGT_EaseFunction.Back_easeInOut(fAnimCurTime, end, strt, fTotDuration) : IGT_EaseFunction.Back_easeInOut(fAnimCurTime, strt, end, fTotDuration));
				break;
			case 2:
				result = (isReverse ? IGT_EaseFunction.Cubic_easeOut(fAnimCurTime, end, strt, fTotDuration) : IGT_EaseFunction.Cubic_easeOut(fAnimCurTime, strt, end, fTotDuration));
				break;
			case 1:
				result = (isReverse ? IGT_EaseFunction.Cubic_easeIn(fAnimCurTime, end, strt, fTotDuration) : IGT_EaseFunction.Cubic_easeIn(fAnimCurTime, strt, end, fTotDuration));
				break;
			case 3:
				result = (isReverse ? IGT_EaseFunction.Cubic_easeInOut(fAnimCurTime, end, strt, fTotDuration) : IGT_EaseFunction.Cubic_easeInOut(fAnimCurTime, strt, end, fTotDuration));
				break;
			case 14:
				result = (isReverse ? IGT_EaseFunction.Bounce_easeOut(fAnimCurTime, end, strt, fTotDuration) : IGT_EaseFunction.Bounce_easeOut(fAnimCurTime, strt, end, fTotDuration));
				break;
			case 13:
				result = (isReverse ? IGT_EaseFunction.Bounce_easeIn(fAnimCurTime, end, strt, fTotDuration) : IGT_EaseFunction.Bounce_easeIn(fAnimCurTime, strt, end, fTotDuration));
				break;
			case 15:
				result = (isReverse ? IGT_EaseFunction.Bounce_easeInOut(fAnimCurTime, end, strt, fTotDuration) : IGT_EaseFunction.Bounce_easeInOut(fAnimCurTime, strt, end, fTotDuration));
				break;
			case 10:
				result = (isReverse ? IGT_EaseFunction.Quad_easeIn(fAnimCurTime, end, strt, fTotDuration) : IGT_EaseFunction.Quad_easeIn(fAnimCurTime, strt, end, fTotDuration));
				break;
			case 11:
				result = (isReverse ? IGT_EaseFunction.Quad_easeOut(fAnimCurTime, end, strt, fTotDuration) : IGT_EaseFunction.Quad_easeOut(fAnimCurTime, strt, end, fTotDuration));
				break;
			case 12:
				result = (isReverse ? IGT_EaseFunction.Quad_easeInOut(fAnimCurTime, end, strt, fTotDuration) : IGT_EaseFunction.Quad_easeInOut(fAnimCurTime, strt, end, fTotDuration));
				break;
			case 16:
				result = (isReverse ? IGT_EaseFunction.Elastic_easeIn(fAnimCurTime, end, strt, fTotDuration) : IGT_EaseFunction.Elastic_easeIn(fAnimCurTime, strt, end, fTotDuration));
				break;
			case 17:
				result = (isReverse ? IGT_EaseFunction.Elastic_easeOut(fAnimCurTime, end, strt, fTotDuration) : IGT_EaseFunction.Elastic_easeOut(fAnimCurTime, strt, end, fTotDuration));
				break;
			case 18:
				result = (isReverse ? IGT_EaseFunction.Elastic_easeInOut(fAnimCurTime, end, strt, fTotDuration) : IGT_EaseFunction.Elastic_easeInOut(fAnimCurTime, strt, end, fTotDuration));
				break;
			case 4:
				result = (isReverse ? IGT_EaseFunction.Expo_easeIn(fAnimCurTime, end, strt, fTotDuration) : IGT_EaseFunction.Expo_easeIn(fAnimCurTime, strt, end, fTotDuration));
				break;
			case 5:
				result = (isReverse ? IGT_EaseFunction.Expo_easeOut(fAnimCurTime, end, strt, fTotDuration) : IGT_EaseFunction.Expo_easeOut(fAnimCurTime, strt, end, fTotDuration));
				break;
			case 6:
				result = (isReverse ? IGT_EaseFunction.Expo_easeInOut(fAnimCurTime, end, strt, fTotDuration) : IGT_EaseFunction.Expo_easeInOut(fAnimCurTime, strt, end, fTotDuration));
				break;
			case 7:
				result = (isReverse ? IGT_EaseFunction.Circle_easeIn(fAnimCurTime, end, strt, fTotDuration) : IGT_EaseFunction.Circle_easeIn(fAnimCurTime, strt, end, fTotDuration));
				break;
			case 8:
				result = (isReverse ? IGT_EaseFunction.Circle_easeOut(fAnimCurTime, end, strt, fTotDuration) : IGT_EaseFunction.Circle_easeOut(fAnimCurTime, strt, end, fTotDuration));
				break;
			case 9:
				result = (isReverse ? IGT_EaseFunction.Circle_easeInOut(fAnimCurTime, end, strt, fTotDuration) : IGT_EaseFunction.Circle_easeInOut(fAnimCurTime, strt, end, fTotDuration));
				break;
			case 25:
				result = (isReverse ? IGT_EaseFunction.Sine_easeIn(fAnimCurTime, end, strt, fTotDuration) : IGT_EaseFunction.Sine_easeIn(fAnimCurTime, strt, end, fTotDuration));
				break;
			case 26:
				result = (isReverse ? IGT_EaseFunction.Sine_easeOut(fAnimCurTime, end, strt, fTotDuration) : IGT_EaseFunction.Sine_easeOut(fAnimCurTime, strt, end, fTotDuration));
				break;
			case 27:
				result = (isReverse ? IGT_EaseFunction.Sine_easeInOut(fAnimCurTime, end, strt, fTotDuration) : IGT_EaseFunction.Sine_easeInOut(fAnimCurTime, strt, end, fTotDuration));
				break;
			case 22:
				result = (isReverse ? IGT_EaseFunction.Quint_easeIn(fAnimCurTime, end, strt, fTotDuration) : IGT_EaseFunction.Quint_easeIn(fAnimCurTime, strt, end, fTotDuration));
				break;
			case 23:
				result = (isReverse ? IGT_EaseFunction.Quint_easeOut(fAnimCurTime, end, strt, fTotDuration) : IGT_EaseFunction.Quint_easeOut(fAnimCurTime, strt, end, fTotDuration));
				break;
			case 24:
				result = (isReverse ? IGT_EaseFunction.Quint_easeInOut(fAnimCurTime, end, strt, fTotDuration) : IGT_EaseFunction.Quint_easeInOut(fAnimCurTime, strt, end, fTotDuration));
				break;
			case 19:
				result = (isReverse ? IGT_EaseFunction.Quart_easeIn(fAnimCurTime, end, strt, fTotDuration) : IGT_EaseFunction.Quart_easeIn(fAnimCurTime, strt, end, fTotDuration));
				break;
			case 20:
				result = (isReverse ? IGT_EaseFunction.Quart_easeOut(fAnimCurTime, end, strt, fTotDuration) : IGT_EaseFunction.Quart_easeOut(fAnimCurTime, strt, end, fTotDuration));
				break;
			case 21:
				result = (isReverse ? IGT_EaseFunction.Quart_easeInOut(fAnimCurTime, end, strt, fTotDuration) : IGT_EaseFunction.Quart_easeInOut(fAnimCurTime, strt, end, fTotDuration));
				break;
			default:
				result = (isReverse ? IGT_EaseFunction.Linear_ease(fAnimCurTime, end, strt, fTotDuration) : IGT_EaseFunction.Linear_ease(fAnimCurTime, strt, end, fTotDuration));
				break;
			}
			fAnimCurTime = Time.time - fAnimStartTime;
		}
		else
		{
			bAnimFinished = true;
		}
		return result;
	}

	public Rect comingfrm_Top(Rect originalDimension, float srcY, float fTotDuration, float fAmplitude, float fFrequency, float fDecay)
	{
		Rect result = originalDimension;
		if (fAnimCurTime <= fTotDuration)
		{
			float num = 0f;
			float y = originalDimension.y;
			y = IGT_EaseFunction.Bounce_easeOut(fAnimCurTime, srcY, originalDimension.y, fTotDuration);
			fAnimCurTime = Time.time - fAnimStartTime;
			if (y >= originalDimension.y - originalDimension.height)
			{
				bEndingAnimStart = true;
			}
			if (bEndingAnimStart)
			{
				num = fAmplitude * Mathf.Sin(fAnimCurTime * fFrequency * (float)Math.PI * 2f) / Mathf.Exp(fAnimCurTime * fDecay);
				fEndAnimCurTime += Time.deltaTime;
			}
			result.x = originalDimension.x + num * 0.5f;
			result.y = y - num * 0.25f;
			result.width = originalDimension.width - num * 0.5f;
			result.height = originalDimension.height + num * 0.5f;
		}
		else
		{
			bAnimFinished = true;
		}
		return result;
	}

	public Vector2 Bezier_2D(Vector2 srcPos, Vector2 cenPos, Vector2 tarPos, float curTime)
	{
		if (curTime >= 1f)
		{
			curTime = 1f;
		}
		float x = (1f - curTime) * (1f - curTime) * srcPos.x + 2f * (1f - curTime) * curTime * cenPos.x + curTime * curTime * tarPos.x;
		float y = (1f - curTime) * (1f - curTime) * srcPos.y + 2f * (1f - curTime) * curTime * cenPos.y + curTime * curTime * tarPos.y;
		return new Vector2(x, y);
	}

	public static Vector3 Bezier_3D(Vector3 strt, Vector3 centre, Vector3 endpos, float curTime, float totTime = 1f)
	{
		if (curTime >= totTime)
		{
			curTime = totTime;
		}
		float x = (1f - curTime) * (1f - curTime) * strt.x + 2f * (1f - curTime) * curTime * centre.x + curTime * curTime * endpos.x;
		float y = (1f - curTime) * (1f - curTime) * strt.y + 2f * (1f - curTime) * curTime * centre.y + curTime * curTime * endpos.y;
		float z = (1f - curTime) * (1f - curTime) * strt.z + 2f * (1f - curTime) * curTime * centre.z + curTime * curTime * endpos.z;
		return new Vector3(x, y, z);
	}
}
