using UnityEngine;

public class IGT_CoinAnimation
{
	public Vector3 StrtPos;

	public Vector3 IntermediatePos;

	public Vector3 TarPos;

	public float fTime;

	public IGT_CoinAnimation(Vector3 strt, Vector3 centre, Vector3 end, float strTime)
	{
		StrtPos = strt;
		IntermediatePos = centre;
		TarPos = end;
		fTime = strTime;
	}
}
