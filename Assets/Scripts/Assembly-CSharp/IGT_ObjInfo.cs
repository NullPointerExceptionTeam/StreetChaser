using UnityEngine;

public class IGT_ObjInfo
{
	public int objPlaceType;

	public int nPathId;

	public float fDistFrmStrtPnt;

	public float fOffset;

	public Vector3 ObjPos;

	public Vector3 objRot;

	public int objID;

	public int objType;

	public string objName;

	public float fLength;

	public float fWidth;

	public float fHeight;

	public float fHeight1;

	public bool bplyrCrsd;

	public float fObjPlacedTime;

	public float fLifeTime;

	public float fMinDstBwObj;

	public float fVechicleSpeed;

	public bool bvehicleMoveEnabled;

	public bool bvehicleReachd;

	public bool bdataInit;

	public bool bTravRev;

	public int CurPointID;

	public int NextPointID;

	public int NoOfTarReached;

	public Vector3 VehicleDestPos;

	public Vector3 VehicleAnimPoint;

	public float VehicleReachTime;

	public int VehicleDestPathID;

	public int VehicleDestPathCurPointID;

	public int VehicleDestPathNextPntID;

	public bool bVehicleDestPathTravRev;

	public bool bVehicleCrossedCurPath;

	public float fdistBtw2points;

	public bool bDisabled;

	public IGT_ObjInfo(int objplceTyp, int pid, float dist, float ofset, Vector3 pos, Vector3 rot, int obId, int typ, string obName, float len, float wid, float hei, float hei1, bool plyrcrsd, float plcedtme, float lfeTme, float mindist, bool disabled)
	{
		objPlaceType = objplceTyp;
		nPathId = pid;
		fDistFrmStrtPnt = dist;
		fOffset = ofset;
		ObjPos = pos;
		objRot = rot;
		objID = obId;
		objType = typ;
		objName = obName;
		fLength = len;
		fWidth = wid;
		fHeight = hei;
		fHeight1 = hei1;
		bplyrCrsd = plyrcrsd;
		fObjPlacedTime = plcedtme;
		fLifeTime = lfeTme;
		fMinDstBwObj = mindist;
		bDisabled = disabled;
	}

	public IGT_ObjInfo(float vehicleSpd, int objplceTyp, int pid, float ofset, Vector3 pos, Vector3 rot, int obId, int typ, string obName, float len, float wid, float hei, float hei1, bool movEnable, bool reachd, bool init, int curpnt, Vector3 dstPos, Vector3 AnimPnt, int dstPid, int nxtPnt, bool travrev, int noOfTarRchd, int dstpathCurPntId, bool dstPathTravRev, bool CrsdCurPath, int dstpathNxtPntID, float distfrmStrt, float reachTme = 0f, float distbtw2pnts = 0f, float mindist = 3f)
	{
		fVechicleSpeed = vehicleSpd;
		objPlaceType = objplceTyp;
		nPathId = pid;
		fOffset = ofset;
		ObjPos = pos;
		objRot = rot;
		objID = obId;
		objType = typ;
		objName = obName;
		fLength = len;
		fWidth = wid;
		fHeight = hei;
		fHeight1 = hei1;
		bvehicleMoveEnabled = movEnable;
		bvehicleReachd = reachd;
		bdataInit = init;
		CurPointID = curpnt;
		NextPointID = nxtPnt;
		bTravRev = travrev;
		NoOfTarReached = noOfTarRchd;
		VehicleDestPos = dstPos;
		VehicleAnimPoint = AnimPnt;
		VehicleReachTime = reachTme;
		VehicleDestPathID = dstPid;
		VehicleDestPathCurPointID = dstpathCurPntId;
		bVehicleDestPathTravRev = dstPathTravRev;
		bVehicleCrossedCurPath = CrsdCurPath;
		VehicleDestPathNextPntID = dstpathNxtPntID;
		fDistFrmStrtPnt = distfrmStrt;
		fdistBtw2points = distbtw2pnts;
		fMinDstBwObj = mindist;
	}

	public IGT_ObjInfo(int objTypID, int pid, float dist, float ofset)
	{
		objPlaceType = objTypID;
		nPathId = pid;
		fDistFrmStrtPnt = dist;
		fOffset = ofset;
	}
}
