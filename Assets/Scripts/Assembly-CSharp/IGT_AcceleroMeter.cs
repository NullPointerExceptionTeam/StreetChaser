using UnityEngine;

public class IGT_AcceleroMeter
{
	public float LowPassFilterFactor = 0.1f;

	public float xFilt;

	public float yFilt;

	public float zFilt;

	public Vector3 LowPassFilter(Vector3 AccelValue)
	{
		xFilt = AccelValue.x * LowPassFilterFactor + xFilt * (1f - LowPassFilterFactor);
		yFilt = AccelValue.y * LowPassFilterFactor + yFilt * (1f - LowPassFilterFactor);
		zFilt = AccelValue.z * LowPassFilterFactor + zFilt * (1f - LowPassFilterFactor);
		return new Vector3(xFilt, yFilt, zFilt);
	}
}
