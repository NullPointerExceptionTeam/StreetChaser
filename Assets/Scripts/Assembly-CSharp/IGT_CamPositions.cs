using UnityEngine;

public class IGT_CamPositions
{
	public Vector3 centerPosition;

	public Vector3 MovingPosition;

	public float fDistFrmLastPos;

	public int nPathId;

	public int nCurrentPointId;

	public Vector3 prevPointPos;

	public Vector3 CurPointPos;

	public Vector3 NextPointPos;

	public Vector3 EndPointPos;

	public bool bMovingBetweenPath;

	public float fTimeSinceLastUpdate;

	public IGT_CamPositions(Vector3 cenPos, Vector3 movPos, float dist, int pId, int curPointID, Vector3 prevposition, Vector3 curposition, Vector3 nextposition, Vector3 endposition, bool movingBetweenpath, float timesinceLastUpdat)
	{
		centerPosition = cenPos;
		MovingPosition = movPos;
		fDistFrmLastPos = dist;
		nPathId = pId;
		nCurrentPointId = curPointID;
		prevPointPos = prevposition;
		CurPointPos = curposition;
		NextPointPos = nextposition;
		EndPointPos = endposition;
		bMovingBetweenPath = movingBetweenpath;
		fTimeSinceLastUpdate = timesinceLastUpdat;
	}
}
