using System;
using UnityEngine;

public class IGT_EaseFunction
{
	public static float Linear_ease(float t, float fCurrentPos, float fTargetPos, float fDuration)
	{
		return (fTargetPos - fCurrentPos) * t / fDuration + fCurrentPos;
	}

	public static float Cubic_easeIn(float fTime, float startVal, float endVal, float fDuration)
	{
		return (endVal - startVal) * (fTime /= fDuration) * fTime * fTime + startVal;
	}

	public static float Cubic_easeOut(float fTime, float startVal, float endVal, float fDuration)
	{
		return (endVal - startVal) * ((fTime = fTime / fDuration - 1f) * fTime * fTime + 1f) + startVal;
	}

	public static float Cubic_easeInOut(float fTime, float startVal, float endVal, float fDuration)
	{
		if ((fTime /= fDuration / 2f) < 1f)
		{
			return (endVal - startVal) / 2f * fTime * fTime * fTime + startVal;
		}
		return (endVal - startVal) / 2f * ((fTime -= 2f) * fTime * fTime + 2f) + startVal;
	}

	public static float Expo_easeIn(float fTime, float startVal, float endVal, float fDuration)
	{
		return (fTime != 0f) ? ((endVal - startVal) * Mathf.Pow(2f, 10f * (fTime / fDuration - 1f)) + startVal) : startVal;
	}

	public static float Expo_easeOut(float fTime, float startVal, float endVal, float fDuration)
	{
		return (fTime != fDuration) ? ((endVal - startVal) * (0f - Mathf.Pow(2f, -10f * fTime / fDuration) + 1f) + startVal) : (startVal + (endVal - startVal));
	}

	public static float Expo_easeInOut(float fTime, float startVal, float endVal, float fDuration)
	{
		if (fTime == 0f)
		{
			return startVal;
		}
		if (fTime == fDuration)
		{
			return startVal + (endVal - startVal);
		}
		if ((fTime /= fDuration / 2f) < 1f)
		{
			return (endVal - startVal) / 2f * Mathf.Pow(2f, 10f * (fTime - 1f)) + startVal;
		}
		return (endVal - startVal) / 2f * (0f - Mathf.Pow(2f, -10f * (fTime -= 1f)) + 2f) + startVal;
	}

	public static float Circle_easeIn(float fTime, float startVal, float endVal, float fDuration)
	{
		return (0f - (endVal - startVal)) * (Mathf.Sqrt(1f - (fTime /= fDuration) * fTime) - 1f) + startVal;
	}

	public static float Circle_easeOut(float fTime, float startVal, float endVal, float fDuration)
	{
		return (endVal - startVal) * Mathf.Sqrt(1f - (fTime = fTime / fDuration - 1f) * fTime) + startVal;
	}

	public static float Circle_easeInOut(float fTime, float startVal, float endVal, float fDuration)
	{
		if ((fTime /= fDuration / 2f) < 1f)
		{
			return (0f - (endVal - startVal)) / 2f * (Mathf.Sqrt(1f - fTime * fTime) - 1f) + startVal;
		}
		return (endVal - startVal) / 2f * (Mathf.Sqrt(1f - (fTime -= 2f) * fTime) + 1f) + startVal;
	}

	public static float Quad_easeIn(float fTime, float startVal, float endVal, float fDuration)
	{
		return (endVal - startVal) * (fTime /= fDuration) * fTime + startVal;
	}

	public static float Quad_easeOut(float fTime, float startVal, float endVal, float fDuration)
	{
		return (0f - (endVal - startVal)) * (fTime /= fDuration) * (fTime - 2f) + startVal;
	}

	public static float Quad_easeInOut(float fTime, float startVal, float endVal, float fDuration)
	{
		if ((fTime /= fDuration / 2f) < 1f)
		{
			return (endVal - startVal) / 2f * fTime * fTime + startVal;
		}
		return (0f - (endVal - startVal)) / 2f * ((fTime -= 1f) * (fTime - 2f) - 1f) + startVal;
	}

	public static float Bounce_easeIn(float fTime, float startVal, float endVal, float fDuration)
	{
		return endVal - startVal - Bounce_easeOut(fDuration - fTime, 0f, endVal - startVal, fDuration) + startVal;
	}

	public static float Bounce_easeOut(float fTime, float startVal, float endVal, float fDuration)
	{
		if ((fTime /= fDuration) < 0.36363637f)
		{
			return (endVal - startVal) * (7.5625f * fTime * fTime) + startVal;
		}
		if (fTime < 0.72727275f)
		{
			return (endVal - startVal) * (7.5625f * (fTime -= 0.54545456f) * fTime + 0.75f) + startVal;
		}
		if ((double)fTime < 0.9090909090909091)
		{
			return (endVal - startVal) * (7.5625f * (fTime -= 0.8181818f) * fTime + 0.9375f) + startVal;
		}
		return (endVal - startVal) * (7.5625f * (fTime -= 21f / 22f) * fTime + 63f / 64f) + startVal;
	}

	public static float Bounce_easeInOut(float fTime, float startVal, float endVal, float fDuration)
	{
		if (fTime < fDuration / 2f)
		{
			return Bounce_easeIn(fTime * 2f, 0f, endVal, fDuration) * 0.5f + startVal;
		}
		return Bounce_easeOut(fTime * 2f - fDuration, 0f, endVal, fDuration) * 0.5f + (endVal - startVal) * 0.5f + startVal;
	}

	public static float Elastic_easeIn(float fTime, float startVal, float endVal, float fDuration)
	{
		if (fTime == 0f)
		{
			return startVal;
		}
		if ((fTime /= fDuration) == 1f)
		{
			return startVal + (endVal - startVal);
		}
		float num = fDuration * 0.3f;
		float num2 = endVal - startVal;
		float num3 = num / 4f;
		return 0f - num2 * Mathf.Pow(2f, 10f * (fTime -= 1f)) * Mathf.Sin((fTime * fDuration - num3) * ((float)Math.PI * 2f) / num) + startVal;
	}

	public static float Elastic_easeOut(float fTime, float startVal, float endVal, float fDuration)
	{
		if (fTime == 0f)
		{
			return startVal;
		}
		if ((fTime /= fDuration) == 1f)
		{
			return startVal + (endVal - startVal);
		}
		float num = fDuration * 0.3f;
		float num2 = endVal - startVal;
		float num3 = num / 4f;
		return num2 * Mathf.Pow(2f, -10f * fTime) * Mathf.Sin((fTime * fDuration - num3) * ((float)Math.PI * 2f) / num) + (endVal - startVal) + startVal;
	}

	public static float easeOutElastic(float t, float fBeginPos, float fTargetPos, float fDuration, float fAmplitude, float fPeriod)
	{
		if (t == 0f)
		{
			return fBeginPos;
		}
		if ((t /= fDuration) == 1f)
		{
			return fTargetPos;
		}
		fPeriod = fDuration * 0.3f;
		float num = 0f;
		if (fAmplitude < Mathf.Abs(fTargetPos))
		{
			fAmplitude = fTargetPos;
			num = fPeriod / 4f;
		}
		else
		{
			num = fPeriod / ((float)Math.PI * 2f) * Mathf.Asin(fTargetPos / fAmplitude);
		}
		return fAmplitude * Mathf.Pow(2f, -10f * t) * Mathf.Sin((t * fDuration - num) * ((float)Math.PI * 2f) / fPeriod) + fTargetPos + fBeginPos;
	}

	public static float Elastic_easeInOut(float fTime, float startVal, float endVal, float fDuration)
	{
		if (fTime == 0f)
		{
			return startVal;
		}
		if ((fTime /= fDuration / 2f) == 2f)
		{
			return startVal + (endVal - startVal);
		}
		float num = fDuration * 0.45000002f;
		float num2 = endVal - startVal;
		float num3 = num / 4f;
		if (fTime < 1f)
		{
			return -0.5f * (num2 * Mathf.Pow(2f, 10f * (fTime -= 1f)) * Mathf.Sin((fTime * fDuration - num3) * ((float)Math.PI * 2f) / num)) + startVal;
		}
		return num2 * Mathf.Pow(2f, -10f * (fTime -= 1f)) * Mathf.Sin((fTime * fDuration - num3) * ((float)Math.PI * 2f) / num) * 0.5f + (endVal - startVal) + startVal;
	}

	public static float Quart_easeIn(float fTime, float startVal, float endVal, float fDuration)
	{
		return (endVal - startVal) * (fTime /= fDuration) * fTime * fTime * fTime + startVal;
	}

	public static float Quart_easeOut(float fTime, float startVal, float endVal, float fDuration)
	{
		return (0f - (endVal - startVal)) * ((fTime = fTime / fDuration - 1f) * fTime * fTime * fTime - 1f) + startVal;
	}

	public static float Quart_easeInOut(float fTime, float startVal, float endVal, float fDuration)
	{
		if ((fTime /= fDuration / 2f) < 1f)
		{
			return (endVal - startVal) / 2f * fTime * fTime * fTime * fTime + startVal;
		}
		return (0f - (endVal - startVal)) / 2f * ((fTime -= 2f) * fTime * fTime * fTime - 2f) + startVal;
	}

	public static float Quint_easeIn(float fTime, float startVal, float endVal, float fDuration)
	{
		return (endVal - startVal) * (fTime /= fDuration) * fTime * fTime * fTime * fTime + startVal;
	}

	public static float Quint_easeOut(float fTime, float startVal, float endVal, float fDuration)
	{
		return (endVal - startVal) * ((fTime = fTime / fDuration - 1f) * fTime * fTime * fTime * fTime + 1f) + startVal;
	}

	public static float Quint_easeInOut(float fTime, float startVal, float endVal, float fDuration)
	{
		if ((fTime /= fDuration / 2f) < 1f)
		{
			return (endVal - startVal) / 2f * fTime * fTime * fTime * fTime * fTime + startVal;
		}
		return (endVal - startVal) / 2f * ((fTime -= 2f) * fTime * fTime * fTime * fTime + 2f) + startVal;
	}

	public static float Sine_easeIn(float fTime, float startVal, float endVal, float fDuration)
	{
		return (0f - (endVal - startVal)) * Mathf.Cos(fTime / fDuration * ((float)Math.PI / 2f)) + (endVal - startVal) + startVal;
	}

	public static float Sine_easeOut(float fTime, float startVal, float endVal, float fDuration)
	{
		return (endVal - startVal) * Mathf.Sin(fTime / fDuration * ((float)Math.PI / 2f)) + startVal;
	}

	public static float Sine_easeInOut(float fTime, float startVal, float endVal, float fDuration)
	{
		return (0f - (endVal - startVal)) / 2f * (Mathf.Cos((float)Math.PI * fTime / fDuration) - 1f) + startVal;
	}

	public static float Back_easeIn(float fTime, float startVal, float endVal, float fDuration)
	{
		float num = 1.70158f;
		return (endVal - startVal) * (fTime /= fDuration) * fTime * ((num + 1f) * fTime - num) + startVal;
	}

	public static float Back_easeOut(float fTime, float startVal, float endVal, float fDuration)
	{
		float num = 1.70158f;
		return (endVal - startVal) * ((fTime = fTime / fDuration - 1f) * fTime * ((num + 1f) * fTime + num) + 1f) + startVal;
	}

	public static float Back_easeInOut(float fTime, float startVal, float endVal, float fDuration)
	{
		float num = 1.70158f;
		if ((fTime /= fDuration / 2f) < 1f)
		{
			return (endVal - startVal) / 2f * (fTime * fTime * (((num *= 1.525f) + 1f) * fTime - num)) + startVal;
		}
		return (endVal - startVal) / 2f * ((fTime -= 2f) * fTime * (((num *= 1.525f) + 1f) * fTime + num) + 2f) + startVal;
	}

	public static float customeBounce(float ftime, float fAmplitude, float fFrequency, float fDecay)
	{
		return fAmplitude * Mathf.Sin(ftime * fFrequency * (float)Math.PI * 2f) / Mathf.Exp(ftime * fDecay);
	}
}
