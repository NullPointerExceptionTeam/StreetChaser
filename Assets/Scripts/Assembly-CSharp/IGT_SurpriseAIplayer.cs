using System;
using System.Collections.Generic;
using UnityEngine;

public class IGT_SurpriseAIplayer : MonoBehaviour
{
	private const string ANIMATOR_VALUE = "SurpriseAIstate";

	public static Animator surpriseAIAnimator;

	private IGT_Hero phero;

	public static GameObject SurpriseAI;

	public static int playerAction;

	public static bool bCanStart;

	private Vector3 Standing_Pos;

	public static int nCurPathID;

	public static float fDistfrmStart;

	private GameObject Wrist;

	public GameObject ThrwObj;

	private float[] offsetRange;

	private int[] nxtPathDet;

	public static IGT_PathInfo Surprise_PlayerObj;

	public static float offset_Laneoffset = 0f;

	public static float fDestinationLaneOffset = 0f;

	public static float fprevOffet = 0f;

	public static float centerOffset = 0f;

	private float fTimeOffsetChange;

	private Vector3 AI_crossProductVal = Vector3.zero;

	private Vector3 AI_movOffset = Vector3.zero;

	private Vector3 AI_movingDirOfPlayer = Vector3.zero;

	private Vector3 AI_animPointVec = Vector3.zero;

	private Vector3 AI_animPointVec_Spline = Vector3.zero;

	private float AI_fDistBw2Points;

	public bool AI_bNxtPathAvail;

	public static Vector3 AI_PlayerprevPos = Vector3.zero;

	public static Vector3 AI_PlayerCurPos = Vector3.zero;

	public static Vector3 AI_prevAnimpointVec = Vector3.zero;

	private int AI_pathIDFrFindingPosBasedGivenDist = -1;

	private int AI_StrtPosIDFrFindingPosBasedGivenDist = -1;

	private int nInputFrAIPlayer;

	private bool AI_bSelectDataFrMovingBWPath;

	private List<IGT_ObjInfo> ObjListInCurPathOfAIPlayer;

	private Vector3[] NeededPos = new Vector3[6];

	private void Start()
	{
		phero = GameObject.FindGameObjectWithTag("Player").GetComponent<IGT_Hero>();
		SurpriseAI = GameObject.FindGameObjectWithTag(IGT_Constants.SurpriseAIplayer);
		surpriseAIAnimator = GetComponent<Animator>();
		Surprise_PlayerObj = new IGT_PathInfo();
		bCanStart = false;
		offsetRange = new float[3]
		{
			0f - phero.PlayerObj.fTotalOffsetDeviation,
			0f,
			phero.PlayerObj.fTotalOffsetDeviation
		};
		playerAction = playerActionSel();
		if (playerAction == 0 || playerAction == 1)
		{
			idle_StandingPos_Selection();
			if (playerAction == 1)
			{
				Wrist = GameObject.Find(IGT_Constants.SurpriseAIplayer + IGT_Constants.Path_AIPlayerWrist_Right);
				ThrwObj = UnityEngine.Object.Instantiate(IGT_ObjPlacing.Throw_Bottle, Wrist.transform.position, Quaternion.Euler(Wrist.transform.rotation.x, Wrist.transform.rotation.y, Wrist.transform.rotation.z));
				ThrwObj.name = IGT_Constants.SurpriseAIplayer + IGT_Constants.Tag_ThrowObj;
				ThrwObj.tag = "Untagged";
				ThrwObj.transform.position = Wrist.transform.position;
				ThrwObj.transform.rotation = Wrist.transform.rotation;
				ThrwObj.transform.localScale = new Vector3(75f, 75f, 75f);
			}
		}
		else if (playerAction == 2)
		{
			nxtPathDet = new int[6];
			nxtPathDet = phero.PlayerObj.findPathBasedInput(phero.PlayerObj.currentPathIndex, phero.PlayerObj.bTraverseReverse, 0);
			int num = 0;
			while (nxtPathDet[0] == -1)
			{
				nxtPathDet = phero.PlayerObj.findPathBasedInput(phero.PlayerObj.currentPathIndex, phero.PlayerObj.bTraverseReverse, UnityEngine.Random.Range(0, 3));
				num++;
			}
			nCurPathID = nxtPathDet[0];
			int num2 = 0;
			num2 = ((nxtPathDet[1] == 0) ? 3 : (Surprise_PlayerObj.pointCount[nCurPathID] - 3));
			Surprise_PlayerObj.nGameStrtPath = nCurPathID;
			Surprise_PlayerObj.nGameStrtPoint = num2;
			Surprise_PlayerObj.PathInit(Surprise_PlayerObj.nGameStrtPath, Surprise_PlayerObj.nGameStrtPoint);
			base.transform.position = new Vector3(Surprise_PlayerObj.pointPos[Surprise_PlayerObj.nGameStrtPath, Surprise_PlayerObj.nGameStrtPoint, 0], Surprise_PlayerObj.pointPos[Surprise_PlayerObj.nGameStrtPath, Surprise_PlayerObj.nGameStrtPoint, 1], Surprise_PlayerObj.pointPos[Surprise_PlayerObj.nGameStrtPath, Surprise_PlayerObj.nGameStrtPoint, 2]);
			if (!Surprise_PlayerObj.bTraverseReverse)
			{
				Surprise_PlayerObj.noOfTargetReached = Surprise_PlayerObj.pointCount[Surprise_PlayerObj.currentPathIndex] - Surprise_PlayerObj.noOfTargetReached;
				Surprise_PlayerObj.currentPoint = Surprise_PlayerObj.pointCount[Surprise_PlayerObj.currentPathIndex] - Surprise_PlayerObj.noOfTargetReached + 1;
			}
			else
			{
				Surprise_PlayerObj.noOfTargetReached = Surprise_PlayerObj.pointCount[Surprise_PlayerObj.currentPathIndex] - Surprise_PlayerObj.noOfTargetReached;
				Surprise_PlayerObj.currentPoint = Surprise_PlayerObj.noOfTargetReached - 1;
			}
			Surprise_PlayerObj.bTraverseReverse = !Surprise_PlayerObj.bTraverseReverse;
			Surprise_PlayerObj.nStartPoint = Surprise_PlayerObj.currentPoint;
			Surprise_PlayerObj.fDistFrmStrtPnt = Surprise_PlayerObj.pathLength[Surprise_PlayerObj.currentPathIndex] - Surprise_PlayerObj.fDistFrmStrtPnt;
			AI_bSelectDataFrMovingBWPath = false;
			offset_Laneoffset = (fprevOffet = (fDestinationLaneOffset = 0f));
			AI_bNxtPathAvail = true;
			if (!Surprise_PlayerObj.bTraverseReverse)
			{
				Surprise_PlayerObj.animPointX = Surprise_PlayerObj.waypoints[Surprise_PlayerObj.currentPoint].position.x;
				Surprise_PlayerObj.animPointY = Surprise_PlayerObj.waypoints[Surprise_PlayerObj.currentPoint].position.y;
				Surprise_PlayerObj.animPointZ = Surprise_PlayerObj.waypoints[Surprise_PlayerObj.currentPoint].position.z;
				base.transform.LookAt(Surprise_PlayerObj.waypoints[Surprise_PlayerObj.currentPoint + 1].position);
				Surprise_PlayerObj._prevPos.x = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint - 1, 0];
				Surprise_PlayerObj._prevPos.y = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint - 1, 1];
				Surprise_PlayerObj._prevPos.z = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint - 1, 2];
				Surprise_PlayerObj._nextToTarPos.x = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint + 2, 0];
				Surprise_PlayerObj._nextToTarPos.y = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint + 2, 1];
				Surprise_PlayerObj._nextToTarPos.z = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint + 2, 2];
			}
			else
			{
				Surprise_PlayerObj.animPointX = Surprise_PlayerObj.waypoints[Surprise_PlayerObj.currentPoint - 1].position.x;
				Surprise_PlayerObj.animPointY = Surprise_PlayerObj.waypoints[Surprise_PlayerObj.currentPoint - 1].position.y;
				Surprise_PlayerObj.animPointZ = Surprise_PlayerObj.waypoints[Surprise_PlayerObj.currentPoint - 1].position.z;
				base.transform.LookAt(Surprise_PlayerObj.waypoints[Surprise_PlayerObj.currentPoint - 1].position);
			}
			AI_PlayerprevPos = new Vector3(Surprise_PlayerObj.animPointX, Surprise_PlayerObj.animPointY, Surprise_PlayerObj.animPointZ);
			AI_PlayerCurPos = new Vector3(Surprise_PlayerObj.animPointX, Surprise_PlayerObj.animPointY, Surprise_PlayerObj.animPointZ);
			AI_animPointVec = new Vector3(Surprise_PlayerObj.animPointX, Surprise_PlayerObj.animPointY, Surprise_PlayerObj.animPointZ);
			AI_animPointVec_Spline = new Vector3(Surprise_PlayerObj.animPointX, Surprise_PlayerObj.animPointY, Surprise_PlayerObj.animPointZ);
			AI_prevAnimpointVec = new Vector3(Surprise_PlayerObj.animPointX, Surprise_PlayerObj.animPointY, Surprise_PlayerObj.animPointZ);
			Surprise_PlayerObj.fDistFrmStrtPnt = Surprise_PlayerObj.objDistFrmStrtPoint(Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.currentPoint, Surprise_PlayerObj.waypoints[Surprise_PlayerObj.currentPoint].position);
			if (Surprise_PlayerObj.bTraverseReverse)
			{
				Surprise_PlayerObj.fDistFrmStrtPnt = Surprise_PlayerObj.pathLength[Surprise_PlayerObj.currentPathIndex] - Surprise_PlayerObj.fDistFrmStrtPnt;
			}
			ObjListInCurPathOfAIPlayer = phero.PlayerObj.objDetInGivenPath(Surprise_PlayerObj.currentPathIndex);
			Surprise_PlayerObj.speed = 1.75f;
		}
	}

	private int playerActionSel()
	{
		int num = 0;
		int num2 = UnityEngine.Random.Range(0, 100);
		if (num2 <= 60)
		{
			num = ((num2 <= 30) ? 1 : 0);
		}
		else
		{
			num = 2;
			nxtPathDet = new int[6];
			nxtPathDet = phero.PlayerObj.findPathBasedInput(phero.PlayerObj.currentPathIndex, phero.PlayerObj.bTraverseReverse, 0);
			if (nxtPathDet[0] == -1)
			{
				num = playerActionSel();
			}
		}
		return num;
	}

	private void Update()
	{
		if (!IGT_Hero.bStrtButton || IGT_Hero.bPauseButton || !IGT_Hero.bRobbingSceneFinished || !bCanStart)
		{
			return;
		}
		switch (playerAction)
		{
		case 0:
		{
			if (!IGT_Hero.bGameOver)
			{
				base.transform.LookAt(new Vector3(phero.player.transform.position.x, phero.player.transform.position.y, phero.player.transform.position.z));
			}
			if (surpriseAIAnimator.GetInteger("SurpriseAIstate") == 26 || surpriseAIAnimator.GetInteger("SurpriseAIstate") == 9 || surpriseAIAnimator.GetInteger("SurpriseAIstate") == 27 || surpriseAIAnimator.GetInteger("SurpriseAIstate") == 28)
			{
				break;
			}
			if (!bCanAttack())
			{
				surpriseAIAnimator.SetInteger("SurpriseAIstate", 25);
				break;
			}
			int num2 = UnityEngine.Random.Range(0, 100);
			switch (num2 % 4)
			{
			case 0:
				surpriseAIAnimator.SetInteger("SurpriseAIstate", 26);
				break;
			case 1:
				surpriseAIAnimator.SetInteger("SurpriseAIstate", 9);
				break;
			case 2:
				surpriseAIAnimator.SetInteger("SurpriseAIstate", 28);
				break;
			case 3:
				surpriseAIAnimator.SetInteger("SurpriseAIstate", 27);
				break;
			}
			break;
		}
		case 1:
			base.transform.LookAt(new Vector3(phero.player.transform.position.x, phero.player.transform.position.y, phero.player.transform.position.z));
			if (surpriseAIAnimator.GetInteger("SurpriseAIstate") != 13)
			{
				if (!bCanThrow())
				{
					surpriseAIAnimator.SetInteger("SurpriseAIstate", 23);
				}
				else
				{
					surpriseAIAnimator.SetInteger("SurpriseAIstate", 13);
					if (SurpriseAI.GetComponent<AudioSource>() == null)
					{
						SurpriseAI.AddComponent<AudioSource>().spatialBlend = 1f;
					}
					if (phero.nSound == 0)
					{
						SurpriseAI.GetComponent<AudioSource>().PlayOneShot(IGT_GameView.pHero._AudioClips[12]);
					}
				}
			}
			if (ThrwObj != null && ThrwObj.GetComponent<Rigidbody>() == null)
			{
				ThrwObj.transform.position = Wrist.transform.position;
				ThrwObj.transform.rotation = Wrist.transform.rotation;
			}
			break;
		case 2:
		{
			SlideTacklingWithRunnigAction();
			if (Surprise_PlayerObj.currentPathIndex != phero.PlayerObj.currentPathIndex || phero.PlayerObj.bTraverseReverse == Surprise_PlayerObj.bTraverseReverse)
			{
				break;
			}
			float num = Surprise_PlayerObj.pathLength[Surprise_PlayerObj.currentPathIndex] - Surprise_PlayerObj.fDistFrmStrtPnt;
			if (!IGT_Hero.bGameOver && num - phero.PlayerObj.fDistFrmStrtPnt > 5f && num - phero.PlayerObj.fDistFrmStrtPnt > 0f && 0f - offset_Laneoffset != phero.offset_Laneoffset)
			{
				fprevOffet = offset_Laneoffset;
				fDestinationLaneOffset = 0f - phero.offset_Laneoffset;
			}
			if (IGT_Hero.bGameOver && num - phero.PlayerObj.fDistFrmStrtPnt > 5f && num - phero.PlayerObj.fDistFrmStrtPnt > 0f && 0f - offset_Laneoffset == phero.offset_Laneoffset)
			{
				fprevOffet = offset_Laneoffset;
				if (phero.offset_Laneoffset == 0f)
				{
					fDestinationLaneOffset = phero.PlayerObj.fTotalOffsetDeviation;
				}
				else
				{
					fDestinationLaneOffset = phero.offset_Laneoffset;
				}
			}
			if (!IGT_Hero.bGameOver && num - phero.PlayerObj.fDistFrmStrtPnt < 2f && num - phero.PlayerObj.fDistFrmStrtPnt > 0f && surpriseAIAnimator.GetInteger("SurpriseAIstate") != 3)
			{
				surpriseAIAnimator.SetInteger("SurpriseAIstate", 3);
				if (SurpriseAI.GetComponent<AudioSource>() == null)
				{
					SurpriseAI.AddComponent<AudioSource>().spatialBlend = 1f;
				}
				if (phero.nSound == 0)
				{
					SurpriseAI.GetComponent<AudioSource>().PlayOneShot(IGT_GameView.pHero._AudioClips[8]);
				}
			}
			break;
		}
		}
	}

	public static void setSurprisePlayerAction(int action)
	{
		surpriseAIAnimator.SetInteger("SurpriseAIstate", action);
	}

	private void SlideTacklingWithRunnigAction()
	{
		if (offset_Laneoffset != fDestinationLaneOffset)
		{
			offset_Laneoffset = IGT_EaseFunction.Linear_ease(fTimeOffsetChange, fprevOffet, fDestinationLaneOffset, 0.25f);
			fTimeOffsetChange += Time.deltaTime;
			if (fTimeOffsetChange >= 0.25f)
			{
				fTimeOffsetChange = 0f;
				offset_Laneoffset = fDestinationLaneOffset;
			}
		}
		Movement_AiPlayer();
		switch (AI_CheckCollisions(Surprise_PlayerObj.fDistFrmStrtPnt + 1.2f, base.transform.position, offset_Laneoffset, Surprise_PlayerObj.bTraverseReverse, Surprise_PlayerObj.pathLength[Surprise_PlayerObj.currentPathIndex], Surprise_PlayerObj.speed, Surprise_PlayerObj.currentPathIndex))
		{
		case 0:
			surpriseAIAnimator.SetInteger("SurpriseAIstate", 2);
			break;
		case 1:
			surpriseAIAnimator.SetInteger("SurpriseAIstate", 3);
			break;
		case 2:
			surpriseAIAnimator.SetInteger("SurpriseAIstate", 2);
			break;
		}
	}

	public int AI_CheckCollisions(float PlayerdistFrmStrtPnt, Vector3 playerPos, float offset, bool TravRev, float TotPathLength, float playerSpd, int AIPlayerPathID)
	{
		float num = 0f;
		if (TravRev)
		{
			offset = 0f - offset;
		}
		for (int i = 0; i < Surprise_PlayerObj.pObj.movingObj.Count; i++)
		{
			float num2 = Surprise_PlayerObj.pObj.movingObj[i].fDistFrmStrtPnt - Surprise_PlayerObj.pObj.movingObj[i].fWidth;
			float num3 = PlayerdistFrmStrtPnt;
			float num4 = Surprise_PlayerObj.pObj.movingObj[i].fOffset;
			int num5;
			bool flag;
			if (Surprise_PlayerObj.pObj.movingObj[i].bVehicleCrossedCurPath)
			{
				num5 = Surprise_PlayerObj.pObj.movingObj[i].VehicleDestPathID;
				flag = Surprise_PlayerObj.pObj.movingObj[i].bVehicleDestPathTravRev;
			}
			else
			{
				num5 = Surprise_PlayerObj.pObj.movingObj[i].nPathId;
				flag = Surprise_PlayerObj.pObj.movingObj[i].bTravRev;
			}
			if (flag)
			{
				num4 = 0f - num4;
				if (Surprise_PlayerObj.pObj.movingObj[i].bVehicleCrossedCurPath)
				{
					num2 = TotPathLength - Surprise_PlayerObj.pObj.movingObj[i].fDistFrmStrtPnt;
				}
			}
			if (TravRev)
			{
				num3 = TotPathLength - PlayerdistFrmStrtPnt - 1.5f;
			}
			if (AIPlayerPathID == num5 && num3 <= num2 + 1f && num3 >= num2 - 1f && offset >= num4 - Surprise_PlayerObj.fTotalOffsetDeviation && offset <= num4 + Surprise_PlayerObj.fTotalOffsetDeviation)
			{
				fprevOffet = offset_Laneoffset;
				if (num4 < 0f)
				{
					fDestinationLaneOffset = Surprise_PlayerObj.fTotalOffsetDeviation;
				}
				else
				{
					fDestinationLaneOffset = 0f - Surprise_PlayerObj.fTotalOffsetDeviation;
				}
				if (TravRev)
				{
					fDestinationLaneOffset = 0f - fDestinationLaneOffset;
				}
			}
		}
		for (int j = 0; j < ObjListInCurPathOfAIPlayer.Count; j++)
		{
			num = (TravRev ? (TotPathLength - ObjListInCurPathOfAIPlayer[j].fDistFrmStrtPnt) : ObjListInCurPathOfAIPlayer[j].fDistFrmStrtPnt);
			if (ObjListInCurPathOfAIPlayer[j].objPlaceType == 1 && ObjListInCurPathOfAIPlayer[j].objType != 4 && ObjListInCurPathOfAIPlayer[j].objType != 6)
			{
				if (AIPlayerPathID == ObjListInCurPathOfAIPlayer[j].nPathId && offset >= ObjListInCurPathOfAIPlayer[j].fOffset - ObjListInCurPathOfAIPlayer[j].fLength / 2f && offset <= ObjListInCurPathOfAIPlayer[j].fOffset + ObjListInCurPathOfAIPlayer[j].fLength / 2f && PlayerdistFrmStrtPnt <= num && PlayerdistFrmStrtPnt >= num - ObjListInCurPathOfAIPlayer[j].fWidth / 2f - 0.5f)
				{
					if (ObjListInCurPathOfAIPlayer[j].objType == 0)
					{
						return 0;
					}
					if (ObjListInCurPathOfAIPlayer[j].objType == 1)
					{
						return 1;
					}
					if (ObjListInCurPathOfAIPlayer[j].objType == 5 || ObjListInCurPathOfAIPlayer[j].objType == 9 || (ObjListInCurPathOfAIPlayer[j].objType == 3 && ObjListInCurPathOfAIPlayer[j].fVechicleSpeed <= 0f))
					{
						fprevOffet = offset_Laneoffset;
						fDestinationLaneOffset = FindDestinationOffset(offset, ObjListInCurPathOfAIPlayer[j].fOffset, ObjListInCurPathOfAIPlayer[j].fLength / 2f, TravRev);
					}
				}
			}
			else
			{
				if (ObjListInCurPathOfAIPlayer[j].objPlaceType != 0 || !(num + ObjListInCurPathOfAIPlayer[j].fWidth / 2f >= PlayerdistFrmStrtPnt) || AIPlayerPathID != ObjListInCurPathOfAIPlayer[j].nPathId || !(offset >= ObjListInCurPathOfAIPlayer[j].fOffset - ObjListInCurPathOfAIPlayer[j].fLength / 2f - IGT_Constants.AIPlayerWidth / 3f) || !(offset <= ObjListInCurPathOfAIPlayer[j].fOffset + ObjListInCurPathOfAIPlayer[j].fLength / 2f + IGT_Constants.AIPlayerWidth / 3f) || !(PlayerdistFrmStrtPnt <= num + ObjListInCurPathOfAIPlayer[j].fWidth / 2f) || !(PlayerdistFrmStrtPnt >= num - ObjListInCurPathOfAIPlayer[j].fWidth / 2f))
				{
					continue;
				}
				if (ObjListInCurPathOfAIPlayer[j].objType == 2)
				{
					if (ObjListInCurPathOfAIPlayer[j].fOffset == 0f)
					{
						return 0;
					}
					fprevOffet = offset_Laneoffset;
					fDestinationLaneOffset = FindDestinationOffset(offset, ObjListInCurPathOfAIPlayer[j].fOffset, ObjListInCurPathOfAIPlayer[j].fLength / 2f, TravRev);
				}
				if (ObjListInCurPathOfAIPlayer[j].objType == 5)
				{
					fprevOffet = offset_Laneoffset;
					fDestinationLaneOffset = FindDestinationOffset(offset, ObjListInCurPathOfAIPlayer[j].fOffset, ObjListInCurPathOfAIPlayer[j].fLength / 2f, TravRev);
				}
			}
		}
		return 11;
	}

	private float FindDestinationOffset(float curOff, float objOff, float objLen, bool TravRev)
	{
		float num = 0f;
		if (objOff == centerOffset)
		{
			num = Surprise_PlayerObj.fTotalOffsetDeviation;
		}
		else if (objOff < centerOffset)
		{
			num = ((!(objOff + objLen < centerOffset)) ? Surprise_PlayerObj.fTotalOffsetDeviation : centerOffset);
		}
		else if (objOff > centerOffset)
		{
			num = ((!(objOff - objLen > centerOffset)) ? (0f - Surprise_PlayerObj.fTotalOffsetDeviation) : centerOffset);
		}
		if (TravRev)
		{
			num = 0f - num;
		}
		return num;
	}

	private void idle_StandingPos_Selection()
	{
		Standing_Pos = Vector3.zero;
		offset_Laneoffset = offsetRange[UnityEngine.Random.Range(0, offsetRange.Length)];
		nxtPathDet = new int[6];
		nxtPathDet = phero.PlayerObj.findPathBasedInput(phero.PlayerObj.currentPathIndex, phero.PlayerObj.bTraverseReverse, UnityEngine.Random.Range(0, 3));
		int num = 0;
		while (nxtPathDet[0] == -1)
		{
			nxtPathDet = phero.PlayerObj.findPathBasedInput(phero.PlayerObj.currentPathIndex, phero.PlayerObj.bTraverseReverse, UnityEngine.Random.Range(0, 3));
			num++;
		}
		nCurPathID = nxtPathDet[0];
		fDistfrmStart = DistanceSel();
		offset_Laneoffset = phero.PlayerObj.offset_Adjustment_fr_Splpowers(offset_Laneoffset, nCurPathID, fDistfrmStart);
		Standing_Pos = phero.PlayerObj.findPos(nCurPathID, fDistfrmStart, offset_Laneoffset);
		Surprise_PlayerObj.currentPathIndex = nCurPathID;
		Surprise_PlayerObj.fDistFrmStrtPnt = fDistfrmStart;
		Surprise_PlayerObj.bTraverseReverse = false;
		base.transform.position = Standing_Pos;
		base.transform.LookAt(new Vector3(phero.player.transform.position.x, phero.player.transform.position.y, phero.player.transform.position.z));
	}

	private float DistanceSel()
	{
		float num = 0f;
		bool flag = false;
		bool flag2 = false;
		float num2 = 4f;
		float num3 = 4f;
		float num4 = 0f;
		float num5 = 0f;
		float num6 = 0f;
		float num7 = 2f;
		float num8 = 1f;
		int num9 = -1;
		float num10 = 3f;
		phero.PlayerObj.objDetInCurPath(nCurPathID);
		int num11 = 0;
		while (!flag2 && num2 < phero.PlayerObj.pathLength[nCurPathID] - num10 && num11 < 200)
		{
			num9 = phero.PlayerObj.findNxtObjIdBasedDistinFrwdPath(num3);
			if (num9 == -1)
			{
				num4 = phero.PlayerObj.pathLength[nCurPathID] - 3.5f;
				num5 = 0f;
				num6 = 0f;
			}
			else
			{
				num4 = phero.PlayerObj.pObj.obj[num9].fDistFrmStrtPnt;
				num5 = phero.PlayerObj.pObj.obj[num9].fMinDstBwObj;
				num6 = phero.PlayerObj.pObj.obj[num9].fWidth;
				if (phero.PlayerObj.pObj.obj[num9].objType == 3 && phero.PlayerObj.pObj.obj[num9].bVehicleCrossedCurPath && phero.PlayerObj.pObj.obj[num9].bVehicleDestPathTravRev)
				{
					num4 = phero.PlayerObj.pathLength[phero.PlayerObj.pObj.obj[num9].nPathId] - num4;
				}
			}
			if (num3 + num7 < num4 - num6 / 2f - num5 / 2f)
			{
				num = num3 + num7;
				num3 = num + num8 / 2f;
				num2 = num;
				flag = true;
			}
			else
			{
				num3 = num4 + num6 / 2f;
				num2 = num3;
				flag = false;
			}
			if (flag && num < phero.PlayerObj.pathLength[nCurPathID] - num10 && !phero.PlayerObj.isSelectedObjColllidedWithAlreadyPlacedPattern(nCurPathID, num, num8, num7))
			{
				flag2 = true;
			}
			num11++;
		}
		if (!flag2)
		{
			num = UnityEngine.Random.Range(3f, 5f);
		}
		return num;
	}

	private void Movement_AiPlayer()
	{
		if (!Surprise_PlayerObj.bMovingFinishdInPath)
		{
			AI_PlayerMovement();
			return;
		}
		if (!AI_bSelectDataFrMovingBWPath)
		{
			if (!Surprise_PlayerObj.bTraverseReverse)
			{
				Surprise_PlayerObj._nextPos = Surprise_PlayerObj.waypoints[Surprise_PlayerObj.currentPoint].position;
				Surprise_PlayerObj._nextToTarPos = Surprise_PlayerObj.waypoints[Surprise_PlayerObj.currentPoint + 1].position;
				AI_pathIDFrFindingPosBasedGivenDist = Surprise_PlayerObj.currentPathIndex;
				AI_StrtPosIDFrFindingPosBasedGivenDist = Surprise_PlayerObj.currentPoint;
			}
			else
			{
				Surprise_PlayerObj._nextPos = Surprise_PlayerObj.waypoints[Surprise_PlayerObj.currentPoint - 1].position;
				Surprise_PlayerObj._nextToTarPos = Surprise_PlayerObj.waypoints[Surprise_PlayerObj.currentPoint - 2].position;
				AI_pathIDFrFindingPosBasedGivenDist = Surprise_PlayerObj.currentPathIndex;
				AI_StrtPosIDFrFindingPosBasedGivenDist = Surprise_PlayerObj.currentPoint - 1;
			}
			Surprise_PlayerObj._prevPos.x = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.prevPathID_BeforeLastPointID[0, 0], Surprise_PlayerObj.prevPathID_BeforeLastPointID[0, 1], 0];
			Surprise_PlayerObj._prevPos.y = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.prevPathID_BeforeLastPointID[0, 0], Surprise_PlayerObj.prevPathID_BeforeLastPointID[0, 1], 1];
			Surprise_PlayerObj._prevPos.z = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.prevPathID_BeforeLastPointID[0, 0], Surprise_PlayerObj.prevPathID_BeforeLastPointID[0, 1], 2];
			Surprise_PlayerObj._curPos.x = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.prevPathID_LastPointID[0, 0], Surprise_PlayerObj.prevPathID_LastPointID[0, 1], 0];
			Surprise_PlayerObj._curPos.y = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.prevPathID_LastPointID[0, 0], Surprise_PlayerObj.prevPathID_LastPointID[0, 1], 1];
			Surprise_PlayerObj._curPos.z = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.prevPathID_LastPointID[0, 0], Surprise_PlayerObj.prevPathID_LastPointID[0, 1], 2];
			AI_bSelectDataFrMovingBWPath = true;
		}
		if (!MovingInBetweenPath_AIPlayer(Surprise_PlayerObj._curPos, Surprise_PlayerObj._nextPos, Surprise_PlayerObj._prevPos, Surprise_PlayerObj._nextToTarPos) && !Surprise_PlayerObj.bMovingFinishdInPath)
		{
			AI_prevAnimpointVec = new Vector3(Surprise_PlayerObj.animPointX, Surprise_PlayerObj.animPointY, Surprise_PlayerObj.animPointZ);
			AI_bSelectDataFrMovingBWPath = false;
			ObjListInCurPathOfAIPlayer = phero.PlayerObj.objDetInGivenPath(Surprise_PlayerObj.currentPathIndex);
		}
	}

	private void AI_PlayerMovement()
	{
		int[] array = new int[6];
		if (!Surprise_PlayerObj.bTraverseReverse && !Surprise_PlayerObj.bTotalTarReached)
		{
			Surprise_PlayerObj._curPos.x = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint, 0];
			Surprise_PlayerObj._curPos.y = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint, 1];
			Surprise_PlayerObj._curPos.z = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint, 2];
			Surprise_PlayerObj._nextPos.x = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint + 1, 0];
			Surprise_PlayerObj._nextPos.y = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint + 1, 1];
			Surprise_PlayerObj._nextPos.z = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint + 1, 2];
			AI_pathIDFrFindingPosBasedGivenDist = Surprise_PlayerObj.currentPathIndex;
			AI_StrtPosIDFrFindingPosBasedGivenDist = Surprise_PlayerObj.nStartPoint + 1;
			if (Surprise_PlayerObj.nStartPoint == 0)
			{
				array = Surprise_PlayerObj.findPathBasedInput(Surprise_PlayerObj.currentPathIndex, true, 0);
				if (array[0] != -1)
				{
					int num = -1;
					num = ((array[1] != 0) ? (array[1] - 1) : array[1]);
					Surprise_PlayerObj._prevPos.x = Surprise_PlayerObj.pointPos[array[0], num, 0];
					Surprise_PlayerObj._prevPos.y = Surprise_PlayerObj.pointPos[array[0], num, 1];
					Surprise_PlayerObj._prevPos.z = Surprise_PlayerObj.pointPos[array[0], num, 2];
				}
				else
				{
					float x = Surprise_PlayerObj._nextPos.x - Surprise_PlayerObj._curPos.x;
					float y = Surprise_PlayerObj._nextPos.y - Surprise_PlayerObj._curPos.y;
					float z = Surprise_PlayerObj._nextPos.z - Surprise_PlayerObj._curPos.z;
					Vector3 vector = new Vector3(x, y, z);
					vector.Normalize();
					float num2 = Vector3.Distance(Surprise_PlayerObj._curPos, Surprise_PlayerObj._nextPos);
					Surprise_PlayerObj._prevPos = Surprise_PlayerObj._curPos - vector * num2;
				}
				Surprise_PlayerObj._nextToTarPos.x = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint + 2, 0];
				Surprise_PlayerObj._nextToTarPos.y = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint + 2, 1];
				Surprise_PlayerObj._nextToTarPos.z = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint + 2, 2];
			}
			else
			{
				Surprise_PlayerObj._prevPos.x = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint - 1, 0];
				Surprise_PlayerObj._prevPos.y = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint - 1, 1];
				Surprise_PlayerObj._prevPos.z = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint - 1, 2];
				if (Surprise_PlayerObj.nStartPoint + 2 < Surprise_PlayerObj.pointCount[Surprise_PlayerObj.currentPathIndex])
				{
					Surprise_PlayerObj._nextToTarPos.x = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint + 2, 0];
					Surprise_PlayerObj._nextToTarPos.y = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint + 2, 1];
					Surprise_PlayerObj._nextToTarPos.z = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint + 2, 2];
				}
				else
				{
					array = Surprise_PlayerObj.findPathBasedInput(Surprise_PlayerObj.currentPathIndex, false, 0);
					if (array[0] != -1)
					{
						int num3 = -1;
						num3 = ((array[1] != 0) ? (array[1] - 1) : array[1]);
						Surprise_PlayerObj._nextToTarPos.x = Surprise_PlayerObj.pointPos[array[0], num3, 0];
						Surprise_PlayerObj._nextToTarPos.y = Surprise_PlayerObj.pointPos[array[0], num3, 1];
						Surprise_PlayerObj._nextToTarPos.z = Surprise_PlayerObj.pointPos[array[0], num3, 2];
					}
					else
					{
						float x2 = Surprise_PlayerObj._nextPos.x - Surprise_PlayerObj._curPos.x;
						float y2 = Surprise_PlayerObj._nextPos.y - Surprise_PlayerObj._curPos.y;
						float z2 = Surprise_PlayerObj._nextPos.z - Surprise_PlayerObj._curPos.z;
						Vector3 vector2 = new Vector3(x2, y2, z2);
						vector2.Normalize();
						float num4 = Vector3.Distance(Surprise_PlayerObj._curPos, Surprise_PlayerObj._nextPos);
						Surprise_PlayerObj._nextToTarPos = Surprise_PlayerObj._nextPos + vector2 * num4;
					}
				}
			}
		}
		else if (Surprise_PlayerObj.bTraverseReverse && !Surprise_PlayerObj.bTotalTarReached)
		{
			Surprise_PlayerObj._curPos.x = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint - 1, 0];
			Surprise_PlayerObj._curPos.y = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint - 1, 1];
			Surprise_PlayerObj._curPos.z = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint - 1, 2];
			Surprise_PlayerObj._nextPos.x = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint - 2, 0];
			Surprise_PlayerObj._nextPos.y = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint - 2, 1];
			Surprise_PlayerObj._nextPos.z = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint - 2, 2];
			AI_pathIDFrFindingPosBasedGivenDist = Surprise_PlayerObj.currentPathIndex;
			AI_StrtPosIDFrFindingPosBasedGivenDist = Surprise_PlayerObj.nStartPoint - 2;
			if (Surprise_PlayerObj.pointCount[Surprise_PlayerObj.currentPathIndex] == Surprise_PlayerObj.nStartPoint)
			{
				array = Surprise_PlayerObj.findPathBasedInput(Surprise_PlayerObj.currentPathIndex, false, 0);
				if (array[0] != -1)
				{
					int num5 = -1;
					num5 = ((array[1] != 0) ? (array[1] - 1) : array[1]);
					Surprise_PlayerObj._prevPos.x = Surprise_PlayerObj.pointPos[array[0], num5, 0];
					Surprise_PlayerObj._prevPos.y = Surprise_PlayerObj.pointPos[array[0], num5, 1];
					Surprise_PlayerObj._prevPos.z = Surprise_PlayerObj.pointPos[array[0], num5, 2];
				}
				else
				{
					float x3 = Surprise_PlayerObj._nextPos.x - Surprise_PlayerObj._curPos.x;
					float y3 = Surprise_PlayerObj._nextPos.y - Surprise_PlayerObj._curPos.y;
					float z3 = Surprise_PlayerObj._nextPos.z - Surprise_PlayerObj._curPos.z;
					Vector3 vector3 = new Vector3(x3, y3, z3);
					vector3.Normalize();
					float num6 = Vector3.Distance(Surprise_PlayerObj._curPos, Surprise_PlayerObj._nextPos);
					Surprise_PlayerObj._prevPos = Surprise_PlayerObj._curPos - vector3 * num6;
				}
				Surprise_PlayerObj._nextToTarPos.x = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint - 3, 0];
				Surprise_PlayerObj._nextToTarPos.y = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint - 3, 1];
				Surprise_PlayerObj._nextToTarPos.z = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint - 3, 2];
			}
			else
			{
				Surprise_PlayerObj._prevPos.x = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint, 0];
				Surprise_PlayerObj._prevPos.y = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint, 1];
				Surprise_PlayerObj._prevPos.z = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint, 2];
				if (Surprise_PlayerObj.nStartPoint - 3 > 0)
				{
					Surprise_PlayerObj._nextToTarPos.x = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint - 3, 0];
					Surprise_PlayerObj._nextToTarPos.y = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint - 3, 1];
					Surprise_PlayerObj._nextToTarPos.z = Surprise_PlayerObj.pointPos[Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.nStartPoint - 3, 2];
				}
				else
				{
					array = Surprise_PlayerObj.findPathBasedInput(Surprise_PlayerObj.currentPathIndex, true, 0);
					if (array[0] != -1)
					{
						int num7 = -1;
						num7 = ((array[1] != 0) ? (array[1] - 1) : array[1]);
						Surprise_PlayerObj._nextToTarPos.x = Surprise_PlayerObj.pointPos[array[0], num7, 0];
						Surprise_PlayerObj._nextToTarPos.y = Surprise_PlayerObj.pointPos[array[0], num7, 1];
						Surprise_PlayerObj._nextToTarPos.z = Surprise_PlayerObj.pointPos[array[0], num7, 2];
					}
					else
					{
						float x4 = Surprise_PlayerObj._nextPos.x - Surprise_PlayerObj._curPos.x;
						float y4 = Surprise_PlayerObj._nextPos.y - Surprise_PlayerObj._curPos.y;
						float z4 = Surprise_PlayerObj._nextPos.z - Surprise_PlayerObj._curPos.z;
						Vector3 vector4 = new Vector3(x4, y4, z4);
						vector4.Normalize();
						float num8 = Vector3.Distance(Surprise_PlayerObj._curPos, Surprise_PlayerObj._nextPos);
						Surprise_PlayerObj._nextToTarPos = Surprise_PlayerObj._nextPos + vector4 * num8;
					}
				}
			}
		}
		if (!Surprise_PlayerObj.bTotalTarReached && !MovingInPath_AIPlayer(Surprise_PlayerObj._curPos, Surprise_PlayerObj._nextPos, Surprise_PlayerObj._prevPos, Surprise_PlayerObj._nextToTarPos) && Surprise_PlayerObj.bTargetReached)
		{
			Surprise_PlayerObj.noOfTargetReached++;
			Surprise_PlayerObj.bTargetReached = false;
			if (!Surprise_PlayerObj.bTraverseReverse)
			{
				Surprise_PlayerObj.nStartPoint++;
				Surprise_PlayerObj.currentPoint++;
			}
			else
			{
				Surprise_PlayerObj.nStartPoint--;
				Surprise_PlayerObj.currentPoint--;
			}
			if (Surprise_PlayerObj.waypoints.Length - 1 <= Surprise_PlayerObj.noOfTargetReached)
			{
				Surprise_PlayerObj.bTotalTarReached = true;
			}
		}
		if (Surprise_PlayerObj.bTotalTarReached)
		{
			nInputFrAIPlayer = selectpathNearToAI();
			if (!Surprise_PlayerObj.bTraverseReverse)
			{
				Surprise_PlayerObj.prevPathIndex = Surprise_PlayerObj.currentPathIndex;
				Surprise_PlayerObj.bTravRevFrPrevPath = Surprise_PlayerObj.bTraverseReverse;
				Surprise_PlayerObj.prevPathID_LastPointID[0, 0] = Surprise_PlayerObj.currentPathIndex;
				Surprise_PlayerObj.prevPathID_LastPointID[0, 1] = Surprise_PlayerObj.currentPoint;
				Surprise_PlayerObj.prevPathID_BeforeLastPointID[0, 0] = Surprise_PlayerObj.currentPathIndex;
				Surprise_PlayerObj.prevPathID_BeforeLastPointID[0, 1] = Surprise_PlayerObj.currentPoint - 1;
				AI_bNxtPathAvail = Surprise_PlayerObj.findNearstPath(Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.waypoints[Surprise_PlayerObj.pointCount[Surprise_PlayerObj.currentPathIndex] - 2].position, Surprise_PlayerObj.waypoints[Surprise_PlayerObj.pointCount[Surprise_PlayerObj.currentPathIndex] - 1].position, nInputFrAIPlayer);
			}
			else
			{
				Surprise_PlayerObj.prevPathIndex = Surprise_PlayerObj.currentPathIndex;
				Surprise_PlayerObj.bTravRevFrPrevPath = Surprise_PlayerObj.bTraverseReverse;
				Surprise_PlayerObj.prevPathID_LastPointID[0, 0] = Surprise_PlayerObj.currentPathIndex;
				Surprise_PlayerObj.prevPathID_LastPointID[0, 1] = Surprise_PlayerObj.currentPoint - 1;
				Surprise_PlayerObj.prevPathID_BeforeLastPointID[0, 0] = Surprise_PlayerObj.currentPathIndex;
				Surprise_PlayerObj.prevPathID_BeforeLastPointID[0, 1] = Surprise_PlayerObj.currentPoint;
				AI_bNxtPathAvail = Surprise_PlayerObj.findNearstPath(Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.waypoints[1].position, Surprise_PlayerObj.waypoints[0].position, nInputFrAIPlayer);
			}
			if (AI_bNxtPathAvail)
			{
				Surprise_PlayerObj.bMovingFinishdInPath = true;
			}
			else if (!AI_bNxtPathAvail && IGT_Hero.bLevelUp)
			{
				IGT_AnimStatesCntrler.nGameOverAnimFinshd = 1;
			}
			else
			{
				Debug.Log("Next path not found");
			}
			nInputFrAIPlayer = 0;
		}
	}

	private int selectpathNearToAI()
	{
		float[] array = new float[3];
		Vector3 zero = Vector3.zero;
		int[] array2 = new int[6];
		float num = 9999f;
		int result = 0;
		for (int i = 0; i < 3; i++)
		{
			array2 = Surprise_PlayerObj.findPathBasedInput(Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.bTraverseReverse, i);
			if (array2[0] == phero.PlayerObj.currentPathIndex)
			{
				return i;
			}
		}
		Vector3 vector = new Vector3(phero.player.transform.position.x - base.transform.position.x, phero.player.transform.position.y - base.transform.position.y, phero.player.transform.position.z - base.transform.position.z);
		vector.Normalize();
		Vector3 vector2 = new Vector3(AI_PlayerCurPos.x - AI_PlayerprevPos.x, AI_PlayerCurPos.y - AI_PlayerprevPos.y, AI_PlayerCurPos.z - AI_PlayerprevPos.z);
		vector2.Normalize();
		Vector3 vector3 = Surprise_PlayerObj.waypoints[Surprise_PlayerObj.currentPoint].position + vector2 * 0.25f;
		for (int j = 0; j < 3; j++)
		{
			array2 = Surprise_PlayerObj.findPathBasedInput(Surprise_PlayerObj.currentPathIndex, Surprise_PlayerObj.bTraverseReverse, j);
			if (array2[0] == -1)
			{
				array[j] = -1000f;
				continue;
			}
			int num2 = array2[1];
			num2 = ((array2[1] != 0) ? (array2[1] - 1) : array2[1]);
			Vector3 vector4 = new Vector3(Surprise_PlayerObj.pointPos[array2[0], num2, 0], Surprise_PlayerObj.pointPos[array2[0], num2, 1], Surprise_PlayerObj.pointPos[array2[0], num2, 2]);
			zero = new Vector3(vector4.x - vector3.x, vector4.y - vector3.y, vector4.z - vector3.z);
			zero.Normalize();
			array[j] = Vector3.Angle(vector, zero);
		}
		for (int k = 0; k < 3; k++)
		{
			if (array[k] != -1000f && num >= array[k])
			{
				num = array[k];
				result = k;
			}
		}
		return result;
	}

	private bool MovingInPath_AIPlayer(Vector3 curpos, Vector3 nextpos, Vector3 prevpos, Vector3 endpos)
	{
		float x = nextpos.x - curpos.x;
		float y = nextpos.y - curpos.y;
		float z = nextpos.z - curpos.z;
		AI_movingDirOfPlayer = new Vector3(x, y, z);
		AI_movingDirOfPlayer.Normalize();
		Surprise_PlayerObj.animPointX += AI_movingDirOfPlayer.x * Surprise_PlayerObj.speed * Time.deltaTime;
		Surprise_PlayerObj.animPointY += AI_movingDirOfPlayer.y * Surprise_PlayerObj.speed * Time.deltaTime;
		Surprise_PlayerObj.animPointZ += AI_movingDirOfPlayer.z * Surprise_PlayerObj.speed * Time.deltaTime;
		AI_animPointVec = new Vector3(Surprise_PlayerObj.animPointX, Surprise_PlayerObj.animPointY, Surprise_PlayerObj.animPointZ);
		AI_fDistBw2Points += Surprise_PlayerObj.speed * Time.deltaTime;
		if (Vector3.Distance(curpos, nextpos) < AI_fDistBw2Points)
		{
			float num = AI_fDistBw2Points - Vector3.Distance(curpos, nextpos);
			NeededPos = Surprise_PlayerObj.PositionBasedGivenDistBw2Points(AI_pathIDFrFindingPosBasedGivenDist, AI_StrtPosIDFrFindingPosBasedGivenDist, num, Surprise_PlayerObj.bTraverseReverse, nInputFrAIPlayer);
			AI_animPointVec = NeededPos[0];
			Surprise_PlayerObj.animPointX = AI_animPointVec.x;
			Surprise_PlayerObj.animPointY = AI_animPointVec.y;
			Surprise_PlayerObj.animPointZ = AI_animPointVec.z;
			AI_PlayerprevPos = AI_animPointVec_Spline;
			AI_fDistBw2Points = Vector3.Distance(NeededPos[0], NeededPos[2]);
			AI_animPointVec_Spline = Surprise_PlayerObj.CurvePoints(NeededPos[1], NeededPos[2], NeededPos[3], NeededPos[4], AI_fDistBw2Points);
			AI_PlayerCurPos = AI_animPointVec_Spline;
			AI_movingDirOfPlayer = new Vector3(AI_PlayerCurPos.x - AI_PlayerprevPos.x, AI_PlayerCurPos.y - AI_PlayerprevPos.y, AI_PlayerCurPos.z - AI_PlayerprevPos.z);
			AI_movingDirOfPlayer.Normalize();
			AI_crossProductVal = Vector3.Cross(Vector3.up, AI_movingDirOfPlayer);
			AI_movOffset = AI_animPointVec_Spline + AI_crossProductVal * offset_Laneoffset;
			Surprise_PlayerObj.fDistFrmStrtPnt += Vector3.Distance(AI_prevAnimpointVec, AI_animPointVec);
			AI_prevAnimpointVec = AI_animPointVec;
			Surprise_PlayerObj.fTotDistTraveled += Vector3.Distance(base.transform.position, AI_movOffset);
			AI_fDistBw2Points = num;
			Surprise_PlayerObj.bTargetReached = true;
			base.transform.position = AI_movOffset;
			base.transform.LookAt(Surprise_PlayerObj.CurvePoints(NeededPos[1], NeededPos[2], NeededPos[3], NeededPos[4], Vector3.Distance(NeededPos[0], NeededPos[2])) + AI_crossProductVal * offset_Laneoffset);
			return false;
		}
		AI_PlayerprevPos = AI_animPointVec_Spline;
		AI_animPointVec_Spline = Surprise_PlayerObj.CurvePoints(prevpos, curpos, nextpos, endpos, AI_fDistBw2Points);
		AI_PlayerCurPos = AI_animPointVec_Spline;
		AI_movingDirOfPlayer = new Vector3(AI_PlayerCurPos.x - AI_PlayerprevPos.x, AI_PlayerCurPos.y - AI_PlayerprevPos.y, AI_PlayerCurPos.z - AI_PlayerprevPos.z);
		AI_movingDirOfPlayer.Normalize();
		AI_crossProductVal = Vector3.Cross(Vector3.up, AI_movingDirOfPlayer);
		AI_movOffset = AI_animPointVec_Spline + AI_crossProductVal * offset_Laneoffset;
		Surprise_PlayerObj.fDistFrmStrtPnt += Vector3.Distance(AI_prevAnimpointVec, AI_animPointVec);
		AI_prevAnimpointVec = AI_animPointVec;
		Surprise_PlayerObj.fTotDistTraveled += Vector3.Distance(base.transform.position, AI_movOffset);
		base.transform.position = AI_movOffset;
		if (AI_fDistBw2Points + AI_fDistBw2Points / 2f < Vector3.Distance(nextpos, curpos))
		{
			base.transform.LookAt(Surprise_PlayerObj.CurvePoints(prevpos, curpos, nextpos, endpos, AI_fDistBw2Points + AI_fDistBw2Points / 2f) + AI_crossProductVal * offset_Laneoffset);
		}
		else
		{
			base.transform.LookAt(Surprise_PlayerObj.CurvePoints(prevpos, curpos, nextpos, endpos, Vector3.Distance(nextpos, curpos)) + AI_crossProductVal * offset_Laneoffset);
		}
		return false;
	}

	private bool MovingInBetweenPath_AIPlayer(Vector3 curpos, Vector3 nextpos, Vector3 prevpos, Vector3 endpos)
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		AI_fDistBw2Points += Surprise_PlayerObj.speed * Time.deltaTime;
		Vector3 rhs = new Vector3(curpos.x - prevpos.x, curpos.y - prevpos.y, curpos.z - prevpos.z);
		rhs.Normalize();
		AI_crossProductVal = Vector3.Cross(Vector3.up, rhs);
		Vector3 prev = prevpos + AI_crossProductVal * offset_Laneoffset;
		Vector3 vector = curpos + AI_crossProductVal * offset_Laneoffset;
		rhs = new Vector3(endpos.x - nextpos.x, endpos.y - nextpos.y, endpos.z - nextpos.z);
		rhs.Normalize();
		AI_crossProductVal = Vector3.Cross(Vector3.up, rhs);
		Vector3 vector2 = nextpos + AI_crossProductVal * offset_Laneoffset;
		Vector3 end = endpos + AI_crossProductVal * offset_Laneoffset;
		if (Vector3.Distance(vector, vector2) < AI_fDistBw2Points)
		{
			float num4 = AI_fDistBw2Points - Vector3.Distance(vector, vector2);
			NeededPos = Surprise_PlayerObj.PositionBasedGivenDistBw2Points(AI_pathIDFrFindingPosBasedGivenDist, AI_StrtPosIDFrFindingPosBasedGivenDist, num4, Surprise_PlayerObj.bTraverseReverse, nInputFrAIPlayer);
			AI_fDistBw2Points = Vector3.Distance(NeededPos[0], NeededPos[2]);
			AI_animPointVec = NeededPos[0];
			Surprise_PlayerObj.animPointX = AI_animPointVec.x;
			Surprise_PlayerObj.animPointY = AI_animPointVec.y;
			Surprise_PlayerObj.animPointZ = AI_animPointVec.z;
			rhs = new Vector3(NeededPos[2].x - NeededPos[1].x, NeededPos[2].y - NeededPos[1].y, NeededPos[2].z - NeededPos[1].z);
			rhs.Normalize();
			AI_crossProductVal = Vector3.Cross(Vector3.up, rhs);
			prev = NeededPos[1] + AI_crossProductVal * offset_Laneoffset;
			vector = NeededPos[2] + AI_crossProductVal * offset_Laneoffset;
			rhs = new Vector3(NeededPos[4].x - NeededPos[3].x, NeededPos[4].y - NeededPos[3].y, NeededPos[4].z - NeededPos[3].z);
			rhs.Normalize();
			AI_crossProductVal = Vector3.Cross(Vector3.up, rhs);
			vector2 = NeededPos[3] + AI_crossProductVal * offset_Laneoffset;
			end = NeededPos[4] + AI_crossProductVal * offset_Laneoffset;
			rhs = new Vector3(NeededPos[0].x - NeededPos[2].x, NeededPos[0].y - NeededPos[2].y, NeededPos[0].z - NeededPos[2].z);
			rhs.Normalize();
			AI_crossProductVal = Vector3.Cross(Vector3.up, rhs);
			Vector3 a = NeededPos[0] + AI_crossProductVal * offset_Laneoffset;
			num2 = Vector3.Distance(curpos, nextpos);
			num = Vector3.Distance(vector, vector2);
			num3 = num2 * AI_fDistBw2Points / num;
			AI_PlayerprevPos = AI_animPointVec_Spline;
			AI_animPointVec_Spline = phero.MovingInBtwPathsUsingEqualDist(NeededPos[1], NeededPos[2], NeededPos[3], NeededPos[4], AI_fDistBw2Points);
			AI_PlayerCurPos = AI_animPointVec_Spline;
			Vector3 vector3 = phero.MovingInBtwPathsUsingEqualDist(prev, vector, vector2, end, Vector3.Distance(a, vector));
			Surprise_PlayerObj.fTotDistTraveled += Vector3.Distance(base.transform.position, vector3);
			AI_fDistBw2Points = num4;
			base.transform.position = vector3;
			AI_movOffset = vector3;
			base.transform.LookAt(phero.MovingInBtwPathsUsingEqualDist(prev, vector, vector2, end, Vector3.Distance(vector, vector2)));
			Surprise_PlayerObj.bMovingFinishdInPath = false;
			return false;
		}
		num2 = Vector3.Distance(curpos, nextpos);
		num = Vector3.Distance(vector, vector2);
		num3 = num2 * AI_fDistBw2Points / num;
		AI_PlayerprevPos = AI_animPointVec_Spline;
		AI_animPointVec_Spline = phero.MovingInBtwPathsUsingEqualDist(prevpos, curpos, nextpos, endpos, num3);
		AI_PlayerCurPos = AI_animPointVec_Spline;
		Vector3 vector4 = phero.MovingInBtwPathsUsingEqualDist(prev, vector, vector2, end, AI_fDistBw2Points);
		Surprise_PlayerObj.fTotDistTraveled += Vector3.Distance(base.transform.position, vector4);
		base.transform.position = vector4;
		AI_movOffset = vector4;
		if (AI_fDistBw2Points + AI_fDistBw2Points / 2f < Vector3.Distance(vector2, vector))
		{
			base.transform.LookAt(phero.MovingInBtwPathsUsingEqualDist(prev, vector, vector2, end, AI_fDistBw2Points + AI_fDistBw2Points / 2f));
		}
		else
		{
			float givenDistance = AI_fDistBw2Points + AI_fDistBw2Points / 2f - Vector3.Distance(vector2, vector);
			NeededPos = Surprise_PlayerObj.PositionBasedGivenDistBw2Points(AI_pathIDFrFindingPosBasedGivenDist, AI_StrtPosIDFrFindingPosBasedGivenDist, givenDistance, Surprise_PlayerObj.bTraverseReverse, nInputFrAIPlayer);
			rhs = new Vector3(NeededPos[2].x - NeededPos[1].x, NeededPos[2].y - NeededPos[1].y, NeededPos[2].z - NeededPos[1].z);
			rhs.Normalize();
			AI_crossProductVal = Vector3.Cross(Vector3.up, rhs);
			prev = NeededPos[1] + AI_crossProductVal * offset_Laneoffset;
			vector = NeededPos[2] + AI_crossProductVal * offset_Laneoffset;
			rhs = new Vector3(NeededPos[4].x - NeededPos[3].x, NeededPos[4].y - NeededPos[3].y, NeededPos[4].z - NeededPos[3].z);
			rhs.Normalize();
			AI_crossProductVal = Vector3.Cross(Vector3.up, rhs);
			vector2 = NeededPos[3] + AI_crossProductVal * offset_Laneoffset;
			end = NeededPos[4] + AI_crossProductVal * offset_Laneoffset;
			base.transform.LookAt(phero.MovingInBtwPathsUsingEqualDist(prev, vector, vector2, end, Vector3.Distance(vector, vector2)));
		}
		return false;
	}

	private bool bCanAttack()
	{
		bool result = false;
		if (phero.PlayerObj.currentPathIndex == nCurPathID && Vector3.Distance(phero.player.transform.position, base.transform.position) < 1.5f)
		{
			result = true;
		}
		return result;
	}

	private bool bCanThrow()
	{
		bool result = false;
		if (phero.PlayerObj.currentPathIndex == nCurPathID && Vector3.Distance(phero.player.transform.position, base.transform.position) < 6f)
		{
			result = true;
		}
		return result;
	}

	private void surprisePlayerThrowobj()
	{
		float num = 0.25f;
		float num2 = Vector3.Distance(base.transform.position, phero.player.transform.position);
		Vector3[] array = new Vector3[6];
		float num3 = phero.PlayerObj.speed * num;
		if (!phero.PlayerObj.bTraverseReverse)
		{
			int currentPoint = phero.PlayerObj.currentPoint;
			if (phero.PlayerObj.currentPoint == phero.PlayerObj.pointCount[phero.PlayerObj.currentPathIndex] - 1)
			{
				currentPoint = phero.PlayerObj.currentPoint - 1;
			}
			num3 = phero.PlayerObj.fDistFrmStrtPnt + phero.PlayerObj.speed * num;
		}
		else
		{
			int currentPoint = phero.PlayerObj.currentPoint - 1;
			if (currentPoint - 1 <= 0)
			{
				currentPoint = 1;
			}
			num3 = phero.PlayerObj.pathLength[phero.PlayerObj.currentPathIndex] - (phero.PlayerObj.fDistFrmStrtPnt + phero.PlayerObj.speed * num);
		}
		array = phero.PlayerObj.TarPosFindngfrKickThrowObjBasedDist(phero.PlayerObj.currentPathIndex, 0, num3, false, 0);
		Vector3 rhs = new Vector3(array[0].x - array[1].x, array[0].y - array[1].y, array[0].z - array[1].z);
		rhs.Normalize();
		Vector3 vector = Vector3.Cross(Vector3.up, rhs);
		Vector3 vector2 = array[0] + vector * phero.offset_Laneoffset;
		float num4 = 10f;
		Vector3 dRotCenter = new Vector3(Wrist.transform.position.x, Wrist.transform.position.y, Wrist.transform.position.z);
		Vector3 vector3 = new Vector3(vector2.x, 0.25f + vector2.y, vector2.z);
		num2 = Vector3.Distance(base.transform.position, vector3);
		float num5 = Mathf.Sqrt(num2 * (0f - Physics.gravity.y) / Mathf.Sin((float)Math.PI / 180f * (num4 * 2f)));
		Vector3 lhs = new Vector3(vector3.x - dRotCenter.x, vector3.y - dRotCenter.y, vector3.z - dRotCenter.z);
		lhs.Normalize();
		Vector3 dRotAxis = Vector3.Cross(lhs, Vector3.up);
		Vector3 vector4 = IGT_Math.RotatePoint_ByAxis(vector3, num4, dRotAxis, dRotCenter);
		lhs = new Vector3(vector4.x - dRotCenter.x, vector4.y - dRotCenter.y, vector4.z - dRotCenter.z);
		lhs.Normalize();
		ThrwObj.AddComponent<Rigidbody>();
		ThrwObj.GetComponent<Rigidbody>().velocity = lhs * num5;
		ThrwObj.GetComponent<Rigidbody>().isKinematic = false;
		ThrwObj.GetComponent<Rigidbody>().useGravity = true;
		UnityEngine.Object.Destroy(ThrwObj, 4f);
	}

	public void EndOfAnimCheck(int val)
	{
		switch (val)
		{
		case 3:
			surprisePlayerThrowobj();
			break;
		case 2:
			surpriseAIAnimator.SetInteger("SurpriseAIstate", 1);
			break;
		}
	}
}
