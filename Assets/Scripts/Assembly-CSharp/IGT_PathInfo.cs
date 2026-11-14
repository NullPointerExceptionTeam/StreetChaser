using System;
using System.Collections.Generic;
using System.Linq;
using SWS;
using UnityEngine;

public class IGT_PathInfo
{
	public IGT_Objects pObj;

	private IGT_PatternDataLoading pIGT_PatternDataLoading;

	public float[,,] pointPos = new float[50, 100, 3];

	public int[] pointCount = new int[50];

	public float[] pathWidth = new float[50];

	public float[] pathLength = new float[50];

	public int[] pathLocation = new int[50];

	public int[] path_Shape_Type = new int[50];

	public PathManager pathContainer;

	public Transform[] waypoints;

	public int nGameStrtPath;

	public int nGameStrtPoint;

	public float fGameStrtDist;

	public int currentPathIndex;

	public int currentPoint;

	public int nStartPoint;

	public int noOfTargetReached;

	public bool bTargetReached;

	public bool bTotalTarReached;

	public bool bTraverseReverse;

	public Vector3 _prevPos;

	public Vector3 _curPos;

	public Vector3 _nextPos;

	public Vector3 _nextToTarPos;

	public Vector3 _prevPathEndPos;

	public Vector3 _prevPath_BeforeEndPos;

	public int prevPathIndex = -1;

	public bool bTravRevFrPrevPath;

	public int[,] prevPathID_LastPointID = new int[1, 2];

	public int[,] prevPathID_BeforeLastPointID = new int[1, 2];

	public List<int> nAdjpathToCurPath = new List<int>();

	public float animPointX;

	public float animPointY;

	public float animPointZ;

	public float speed = 3.5f;

	public float setSpeed = 3.5f;

	public float PrevSpeed = 3.5f;

	public float MaxSpeed = 3.5f;

	public float PrevMaxSpeed = 3.5f;

	public float MinSpeed;

	public float BaseSpeed;

	public float prevBaseSpeed;

	public float SpeedAccelerationFactor;

	public float EnergyDeAcceleratorFactorPerSecond;

	public float prevSpeedProportion;

	public float EnergyReductionValue;

	public float EnergyIncreasingTotValue;

	public float EnergyDecMinVal;

	public float EnergyDecMaxVal;

	public float fMinAngle = 9999f;

	public float fMinPathIdx;

	public float fMinPathCurPntIdx;

	public float fDistFrmStrtPnt;

	public float fTotDistTraveled;

	public List<int> nAdjPIDs = new List<int>();

	public Vector3 posFrFndngRot;

	public Vector3 prevPosFrFndngRot;

	public bool bMovingFinishdInPath;

	public float fDeviceWidth = 320f;

	public float fDeviceHeight = 480f;

	public float fTotalOffsetDeviation = 0.4f;

	public float fCenterOffset;

	public string[] AnimationCurvesSpeed = new string[20];

	public bool bIncraseSpeed_SplPower;

	public double dIncreaseSpdStrtTime;

	public double dIncreaseSpdTotTime;

	public float dEnergyIncreasingStrtTime;

	public float dEnergyIncValWhenNotVisibleToHero;

	public int[] EnergyLevelsArr = new int[5];

	public int[] EnergyPickingProbArr = new int[5];

	public float nEnergyMeter = 1f;

	public float nEnergyMeterPrev = 1f;

	public float nEnergyMeterNext = 1f;

	public bool bEnergyMeterChangesinBezier;

	public float fTimeForEnergyMeterChanges;

	public float[] collItemPlacdTimeInPath = new float[WaypointManager.Paths.Count];

	private int[,] nPatternPlacementDetails = new int[5, 5];

	private int nPatternPlacedCount;

	public IGT_PathInfo()
	{
		pObj = new IGT_Objects();
		pIGT_PatternDataLoading = new IGT_PatternDataLoading();
		for (int i = 0; i < WaypointManager.Paths.Count; i++)
		{
			KeyValuePair<string, PathManager> keyValuePair = WaypointManager.Paths.ElementAt(i);
			PathManager value = keyValuePair.Value;
			string key = keyValuePair.Key;
			pathWidth[i] = float.Parse(getCurPathIdx_Width(key, 2));
			pathLocation[i] = int.Parse(getCurPathIdx_Width(key, 3));
			path_Shape_Type[i] = int.Parse(getCurPathIdx_Width(key, 4));
			pointCount[i] = value.waypoints.Length;
			pathLength[i] = TotPathDistance(value.waypoints, value.waypoints.Length);
			for (int j = 0; j < pointCount[i]; j++)
			{
				Vector3 position = value.waypoints[j].position;
				pointPos[i, j, 0] = position.x;
				pointPos[i, j, 1] = position.y;
				pointPos[i, j, 2] = position.z;
			}
		}
		AnimationCurvesSpeed[0] = "1~1~1~1~1~1~1~1~1~1";
		AnimationCurvesSpeed[1] = "1~1~1~1~1~1~1~1~1~1";
		AnimationCurvesSpeed[2] = "1~1~1~1~1~1~1~1~1~1";
		AnimationCurvesSpeed[3] = "1~1~1~1~1~1~1~1~1~1";
		AnimationCurvesSpeed[4] = "1~1~1~1~1~1~1~1~1~1";
		AnimationCurvesSpeed[5] = "1~1~1~1~1~1~1~1~1~1";
		AnimationCurvesSpeed[6] = "1~1~1~1~1~1~1~1~1~1";
		AnimationCurvesSpeed[7] = "1~1~1~1~1~1~1~1~1~1";
		AnimationCurvesSpeed[8] = "1~1~1~1~1~1~1~1~1~1";
		AnimationCurvesSpeed[9] = "1~1~1~1~1~1~1~1~1~1";
		AnimationCurvesSpeed[10] = "1~1~1~1~1~1~1~1~1~1";
		AnimationCurvesSpeed[11] = "1~1~1~1~1~1~1~1~1~1";
		AnimationCurvesSpeed[12] = "1~1~1~1~1~1~1~1~1~1";
		AnimationCurvesSpeed[13] = "1~1~1~1~1~1~1~1~1~1";
		AnimationCurvesSpeed[14] = "1~1~0.9~0.85~0.8~0.8~0.9~1~1~1";
		AnimationCurvesSpeed[15] = "1~0.8~0.85~0.85~0.9~0.9~0.95~1~1~1";
		AnimationCurvesSpeed[16] = "1~1~1~1~1~1~1~1~1~1";
	}

	public void PathInit(int pathID, int curPoint)
	{
		KeyValuePair<string, PathManager> keyValuePair = WaypointManager.Paths.ElementAt(pathID);
		SetPath(WaypointManager.Paths[keyValuePair.Key]);
		fDistFrmStrtPnt = 0f;
		currentPoint = curPoint;
		nStartPoint = curPoint;
		currentPathIndex = int.Parse(getCurPathIdx_Width(pathContainer.name, 1));
		bTargetReached = false;
		bTotalTarReached = false;
		fMinAngle = 9999f;
		if (currentPoint < pointCount[pathID] / 2)
		{
			bTraverseReverse = false;
			noOfTargetReached = currentPoint + 1;
		}
		else
		{
			bTraverseReverse = true;
			noOfTargetReached = pointCount[currentPathIndex] - currentPoint + 1;
		}
	}

	public void SelectStaticObjectsDetailsFromFile()
	{
		pObj.staticObj_TotalDetails.Clear();
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		string text = "null";
		float num4 = 0f;
		float num5 = 0f;
		float num6 = 0f;
		float num7 = 0f;
		float num8 = 0f;
		int num9 = 100;
		float num10 = 0f;
		Vector3 zero = Vector3.zero;
		Vector3 zero2 = Vector3.zero;
		bool flag = false;
		bool disabled = true;
		float num11 = 0f;
		float num12 = 0f;
		for (int i = 0; i < IGT_FileReading.nobjLen; i++)
		{
			string text2 = IGT_FileReading.data[i];
			if (text2.StartsWith("0"))
			{
				string[] array = text2.Split('~');
				num = int.Parse(array[0]);
				num2 = int.Parse(array[1]);
				num3 = int.Parse(array[2]);
				text = array[3];
				num4 = float.Parse(array[4]);
				num5 = float.Parse(array[5]);
				num6 = float.Parse(array[6]);
				num7 = float.Parse(array[7]);
				num8 = float.Parse(array[8]);
				num9 = int.Parse(array[9]);
				float dist = float.Parse(array[10]);
				num10 = float.Parse(array[11]);
				zero2 = new Vector3(270f, 90f, 0f);
				zero = new Vector3(0f, 0f, 0f);
				flag = false;
				num11 = 0f;
				num12 = float.Parse(array[14]);
				pObj.staticObj_TotalDetails.Add(new IGT_ObjInfo(num, num9, dist, num10, zero, zero2, num2, num3, text, num4, num5, num6, num7, flag, num11, num12, num8, disabled));
			}
		}
		pObj.StaticGameObjectsArray = new GameObject[pObj.staticObj_TotalDetails.Count];
		for (int j = 0; j < pObj.staticObj_TotalDetails.Count; j++)
		{
			if (pObj.staticObj_TotalDetails[j].objID / 100 == 3)
			{
				pObj.StaticGameObjectsArray[j] = GameObject.Find(IGT_Constants.Path_StaticObjString + pObj.staticObj_TotalDetails[j].objName + IGT_Constants.Cap);
				continue;
			}
			pObj.StaticGameObjectsArray[j] = GameObject.Find(pObj.staticObj_TotalDetails[j].objName);
			if (pObj.StaticGameObjectsArray[j].GetComponent<AudioSource>() == null)
			{
				pObj.StaticGameObjectsArray[j].AddComponent<AudioSource>();
			}
			if (Resources.Load(IGT_Constants.AudioClipsPath + "construction") != null)
			{
				pObj.StaticGameObjectsArray[j].GetComponent<AudioSource>().clip = Resources.Load(IGT_Constants.AudioClipsPath + "construction") as AudioClip;
			}
			else
			{
				Debug.Log("No audio clips found in name Constrution sound ");
			}
			pObj.StaticGameObjectsArray[j].GetComponent<AudioSource>().volume = 0.2f;
			pObj.StaticGameObjectsArray[j].GetComponent<AudioSource>().spatialBlend = 1f;
			pObj.StaticGameObjectsArray[j].GetComponent<AudioSource>().rolloffMode = AudioRolloffMode.Linear;
			pObj.StaticGameObjectsArray[j].GetComponent<AudioSource>().minDistance = 1f;
			pObj.StaticGameObjectsArray[j].GetComponent<AudioSource>().maxDistance = 3f;
			pObj.StaticGameObjectsArray[j].GetComponent<AudioSource>().playOnAwake = false;
			pObj.StaticGameObjectsArray[j].GetComponent<AudioSource>().loop = true;
		}
		pObj.nNoOfStaticObjInEachPath = new int[WaypointManager.Paths.Count];
		for (int k = 0; k < WaypointManager.Paths.Count; k++)
		{
			int num13 = 0;
			for (int l = 0; l < pObj.staticObj_TotalDetails.Count; l++)
			{
				if (k == pObj.staticObj_TotalDetails[l].nPathId)
				{
					num13++;
				}
			}
			pObj.nNoOfStaticObjInEachPath[k] = num13;
		}
		IGT_Constants.nValfrStaticObjEnablingInPath = 20;
		IGT_Constants.nValArrForEachStaticObjEnableProbability[0] = 10;
		IGT_Constants.nValArrForEachStaticObjEnableProbability[1] = 25;
		IGT_Constants.nValArrForEachStaticObjEnableProbability[2] = 40;
	}

	public void CumulativeProbCalc()
	{
		IGT_Constants.nSumOfProb_DynamicObj = 0;
		IGT_Constants.nSumOfProb_StaticObj = 0;
		IGT_Constants.nSumOfProb_CoinObj = 0;
		IGT_Constants.nSumOfProb_SplPowersObj = 0;
		int num = 0;
		IGT_Constants.nNoOfStaticObj = 0;
		for (int i = 0; i < pObj.staticObj_TotalDetails.Count; i++)
		{
			string text = IGT_FileReading.data[i];
			string[] array = text.Split('~');
			pObj.StaticObjIndexBasedProbability[num, 0] = i;
			pObj.StaticObjIndexBasedProbability[num, 1] = int.Parse(array[12]);
			pObj.StaticObjIndexBasedProbability[num, 2] = int.Parse(array[13]);
			pObj.StaticObjIndexBasedProbability[num, 3] = pObj.StaticObjIndexBasedProbability[num, 1] * pObj.StaticObjIndexBasedProbability[num, 2];
			IGT_Constants.nSumOfProb_StaticObj += pObj.StaticObjIndexBasedProbability[num, 3];
			num++;
			IGT_Constants.nNoOfStaticObj++;
		}
		num = 0;
		IGT_Constants.nNoOfDynamicObj = 0;
		for (int j = pObj.staticObj_TotalDetails.Count; j <= IGT_FileReading.nobjLen - IGT_Constants.nNoOfMovingObj - IGT_Constants.nNoOfEnergyItems - IGT_Constants.nNoOfSplPowers; j++)
		{
			string text = IGT_FileReading.data[j];
			string[] array = text.Split('~');
			pObj.DynamicObjIndexBasedProbability[num, 0] = j;
			pObj.DynamicObjIndexBasedProbability[num, 1] = int.Parse(array[10]);
			pObj.DynamicObjIndexBasedProbability[num, 2] = int.Parse(array[11]);
			if (IGT_GameView.pHero.nGameMode == 1 && IGT_GameView.pHero.pMissionData.nMissionType == 1)
			{
				switch (IGT_GameView.pHero.pMissionData.nChallengesInnerItemType)
				{
				case 0:
					if (int.Parse(array[2]) == 4)
					{
						pObj.DynamicObjIndexBasedProbability[num, 1] += IGT_GameView.pHero.pMissionData.nChallengeItem_BaseProb;
						pObj.DynamicObjIndexBasedProbability[num, 2] += IGT_GameView.pHero.pMissionData.nChallengeItem_DiffProb;
					}
					break;
				case 1:
					if (int.Parse(array[2]) == 6)
					{
						pObj.DynamicObjIndexBasedProbability[num, 1] += IGT_GameView.pHero.pMissionData.nChallengeItem_BaseProb;
						pObj.DynamicObjIndexBasedProbability[num, 2] += IGT_GameView.pHero.pMissionData.nChallengeItem_DiffProb;
					}
					break;
				case 2:
					if (int.Parse(array[2]) == 0)
					{
						pObj.DynamicObjIndexBasedProbability[num, 1] += IGT_GameView.pHero.pMissionData.nChallengeItem_BaseProb;
						pObj.DynamicObjIndexBasedProbability[num, 2] += IGT_GameView.pHero.pMissionData.nChallengeItem_DiffProb;
					}
					break;
				case 3:
					if (int.Parse(array[2]) == 1)
					{
						pObj.DynamicObjIndexBasedProbability[num, 1] += IGT_GameView.pHero.pMissionData.nChallengeItem_BaseProb;
						pObj.DynamicObjIndexBasedProbability[num, 2] += IGT_GameView.pHero.pMissionData.nChallengeItem_DiffProb;
					}
					break;
				}
			}
			pObj.DynamicObjIndexBasedProbability[num, 3] = pObj.DynamicObjIndexBasedProbability[num, 1] * pObj.DynamicObjIndexBasedProbability[num, 2];
			int num2 = int.Parse(array[2]);
			if (num2 == 6)
			{
				pObj.DynamicObjIndexBasedProbability[num, 3] = (int)((float)pObj.DynamicObjIndexBasedProbability[num, 3] * IGT_Constants.nKick_Throw_AdjFactor * IGT_Constants.Multiplier_Bottle);
			}
			if (num2 == 4)
			{
				pObj.DynamicObjIndexBasedProbability[num, 3] = (int)((float)pObj.DynamicObjIndexBasedProbability[num, 3] * IGT_Constants.nKick_Throw_AdjFactor * IGT_Constants.Multiplier_Ball);
			}
			if (IGT_GameView.pHero.nGameMode == 1 && (num2 == 6 || num2 == 4))
			{
				float num3 = IGT_Constants.fDiffSpd_CurVal_Mission;
				if (num3 >= 1f)
				{
					num3 = 1f;
				}
				pObj.DynamicObjIndexBasedProbability[num, 3] = (int)((float)pObj.DynamicObjIndexBasedProbability[num, 3] / num3);
			}
			IGT_Constants.nSumOfProb_DynamicObj += pObj.DynamicObjIndexBasedProbability[num, 3];
			num++;
			IGT_Constants.nNoOfDynamicObj++;
		}
		num = 0;
		for (int k = IGT_Constants.nNoOfStaticObj + IGT_Constants.nNoOfDynamicObj; k < IGT_FileReading.nobjLen - IGT_Constants.nNoOfMovingObj - IGT_Constants.nNoOfSplPowers; k++)
		{
			string text = IGT_FileReading.data[k];
			string[] array = text.Split('~');
			pObj.CoinObjIndexBasedProbability[num, 0] = k;
			pObj.CoinObjIndexBasedProbability[num, 1] = int.Parse(array[10]);
			pObj.CoinObjIndexBasedProbability[num, 2] = int.Parse(array[11]);
			pObj.CoinObjIndexBasedProbability[num, 3] = pObj.CoinObjIndexBasedProbability[num, 1] * pObj.CoinObjIndexBasedProbability[num, 2];
			IGT_Constants.nSumOfProb_CoinObj += pObj.CoinObjIndexBasedProbability[num, 3];
			num++;
		}
		num = 0;
		for (int l = IGT_FileReading.nobjLen - IGT_Constants.nNoOfSplPowers; l < IGT_FileReading.nobjLen; l++)
		{
			string text = IGT_FileReading.data[l];
			string[] array = text.Split('~');
			pObj.specialPowersIndexBasedProbability[num, 0] = l;
			pObj.specialPowersIndexBasedProbability[num, 1] = int.Parse(array[10]);
			pObj.specialPowersIndexBasedProbability[num, 2] = int.Parse(array[11]);
			pObj.specialPowersIndexBasedProbability[num, 3] = pObj.specialPowersIndexBasedProbability[num, 1] * pObj.specialPowersIndexBasedProbability[num, 2];
			int num4 = int.Parse(array[1]);
			switch (num4)
			{
			case 900:
			case 901:
			case 902:
			case 903:
			case 904:
			case 907:
				pObj.specialPowersIndexBasedProbability[num, 3] *= IGT_Constants.nSplPow_Pos_AdjFactor;
				break;
			case 905:
			case 906:
			case 908:
			case 909:
				pObj.specialPowersIndexBasedProbability[num, 3] *= IGT_Constants.nSplPow_Neg_AdjFactor;
				break;
			}
			switch (num4)
			{
			case 901:
				pObj.specialPowersIndexBasedProbability[num, 3] *= IGT_Constants.nUpgrade_CurState[2] + 1;
				break;
			case 902:
				pObj.specialPowersIndexBasedProbability[num, 3] *= IGT_Constants.nUpgrade_CurState[3] + 1;
				break;
			}
			IGT_Constants.nSumOfProb_SplPowersObj += pObj.specialPowersIndexBasedProbability[num, 3];
			num++;
		}
	}

	public void objplaceInfo(int Index)
	{
		switch (Index)
		{
		case 0:
			objDiffcultySelection();
			pObj.nPathID = currentPathIndex;
			nAdjPIDs.Clear();
			nAdjPIDs = findAdjPathFrObjPlacing(currentPathIndex, bTraverseReverse);
			break;
		case 1:
			RemoveTimeExceeded_StaticObj();
			break;
		case 2:
			StaticObjPlacingInfoselection(nAdjPIDs);
			break;
		case 3:
			Enable_PlacedStaticObjects();
			break;
		case 7:
			RemoveTimeExceeded_DynamiObj(ref pObj.objFrDraw);
			pObj.patternBasedTrapItemsDetails.Clear();
			break;
		case 8:
			DynamicObjInfoSelection(nAdjPIDs);
			patternBasedDynamicObjPlacement();
			AdjustThrowObjOffset();
			break;
		case 9:
			IGT_ObjPlacing.objDestruction();
			IGT_ObjPlacing.objPlaceAtRuntime(ref pObj.objFrDraw);
			pObj.ObjListInCurPathOfHero = objDetInGivenPath(pObj.nPathID);
			if (IGT_GameView.pHero.isAIplayerAvailable)
			{
				IGT_AIPlayer.ObjListInCurPathOfAIPlayer = objDetInGivenPath(IGT_AIPlayer.AI_PlayerObj.currentPathIndex);
			}
			break;
		case 10:
			if (IGT_GameView.pHero.nGameMode == 1 && (IGT_GameView.pHero.pMissionData.nMissionType == 0 || IGT_GameView.pHero.pMissionData.nMissionType == 5 || IGT_GameView.pHero.pMissionData.nMissionType == 3))
			{
				removingTimeExceeded_missionItemDatas();
			}
			RemoveTimeExceeded_DynamiObj(ref pObj.pCoinDatas);
			break;
		case 11:
			Coin_PlacingInfoSel(nAdjPIDs);
			if (IGT_GameView.pHero.nGameMode != 1)
			{
				break;
			}
			if (IGT_GameView.pHero.pMissionData.nMissionType == 0)
			{
				if (IGT_GameView.pHero.pMissionData.nCollectionInnerItemType == 0)
				{
					Coin_PlacingInfoSel(nAdjPIDs, true);
				}
				else if (IGT_GameView.pHero.pMissionData.nCollectionInnerItemType != 0)
				{
					CollectionObjPlacementInObjstacles(nAdjPIDs);
				}
			}
			else if (IGT_GameView.pHero.pMissionData.nMissionType == 5)
			{
				CollectionObjPlacementInObjstacles(nAdjPIDs);
			}
			else if (IGT_GameView.pHero.pMissionData.nMissionType == 3)
			{
				WF_CharPlacementSel(nAdjPIDs, IGT_GameView.pHero.pMissionData.nWF_OringinalCharPlacingProb, IGT_GameView.pHero.pMissionData.nWF_NoOfCharPer_20Meters);
			}
			break;
		case 12:
			if (IGT_GameView.pHero.nGameMode == 1 && (IGT_GameView.pHero.pMissionData.nMissionType == 0 || IGT_GameView.pHero.pMissionData.nMissionType == 5))
			{
				IGT_ObjPlacing.collectionItemsDestruction();
				IGT_ObjPlacing.CollectionItemPlacing(ref pObj.missionObj_PlacedDetails);
				if (IGT_GameView.pHero.pMissionData.nMissionType == 0 && IGT_GameView.pHero.pMissionData.nCollectionInnerItemType == 0)
				{
					IGT_ObjPlacing.Rotate_CollectionItems_Coins();
				}
			}
			IGT_ObjPlacing.Coin_Destruction();
			IGT_ObjPlacing.Coin_Placing(ref pObj.pCoinDatas);
			IGT_ObjPlacing.Rotation_Coin();
			break;
		case 13:
			removingTimeExceeded_SplPowersDatas();
			splPowersInfoSelection(nAdjPIDs);
			IGT_ObjPlacing.splPowersobjDestruction();
			IGT_ObjPlacing.splPowersPlacing(ref pObj.splPowersObj_PlacedDetails);
			break;
		case 14:
			IGT_GameView.pHero.SurpriseAIPlayerDataSelection();
			break;
		case 4:
		case 5:
		case 6:
			break;
		}
	}

	public void DestroyAllTypesofObjects(bool bDestroyOnlyObjstacles = false)
	{
		pObj.objFrDraw.Clear();
		IGT_ObjPlacing.objDestruction();
		pObj.staticObj_PlacedDetails.Clear();
		Enable_PlacedStaticObjects();
		pObj.movingObj.Clear();
		IGT_MovingObjPlacing.MovObjDestruction();
		if (!bDestroyOnlyObjstacles)
		{
			pObj.pCoinDatas.Clear();
			IGT_ObjPlacing.Coin_Destruction();
			pObj.missionObj_PlacedDetails.Clear();
			IGT_ObjPlacing.collectionItemsDestruction();
			pObj.splPowersObj_PlacedDetails.Clear();
			IGT_ObjPlacing.splPowersobjDestruction();
			pObj.patternBasedTrapItemsDetails.Clear();
			IGT_ObjPlacing.glowObjDestruction();
			if (IGT_GameView.pHero != null)
			{
				IGT_GameView.pHero.destroyUnwantedGameobjects();
			}
		}
	}

	public void RemoveTimeExceeded_Vehicles(ref List<IGT_ObjInfo> datas)
	{
		for (int num = datas.Count - 1; num >= 0; num--)
		{
			if (datas[num].objType == 3)
			{
				int num2 = datas[num].nPathId;
				if (datas[num].bVehicleCrossedCurPath)
				{
					num2 = datas[num].VehicleDestPathID;
				}
				if (num2 != currentPathIndex && !nAdjPIDs.Contains(num2) && ((datas[num].bvehicleReachd && Time.timeSinceLevelLoad - datas[num].VehicleReachTime > 5f) || (!datas[num].bdataInit && !datas[num].bvehicleMoveEnabled && datas[num].VehicleReachTime == 0f)))
				{
					datas.RemoveAt(num);
				}
			}
		}
	}

	public void RemoveTimeExceeded_StaticObj()
	{
		for (int num = pObj.staticObj_PlacedDetails.Count - 1; num >= 0; num--)
		{
			if (pObj.staticObj_PlacedDetails[num].objPlaceType == 0 && !nAdjPIDs.Contains(pObj.staticObj_PlacedDetails[num].nPathId) && pObj.staticObj_PlacedDetails[num].nPathId != currentPathIndex && Time.timeSinceLevelLoad - pObj.staticObj_PlacedDetails[num].fObjPlacedTime > pObj.staticObj_PlacedDetails[num].fLifeTime)
			{
				pObj.staticObj_PlacedDetails.RemoveAt(num);
			}
		}
	}

	public void Enable_PlacedStaticObjects()
	{
		for (int i = 0; i < pObj.StaticGameObjectsArray.Length; i++)
		{
			if (pObj.StaticGameObjectsArray[i].name.EndsWith(IGT_Constants.Cap))
			{
				pObj.StaticGameObjectsArray[i].SetActive(true);
				continue;
			}
			pObj.StaticGameObjectsArray[i].GetComponent<AudioSource>().Stop();
			pObj.StaticGameObjectsArray[i].SetActive(false);
		}
		for (int j = 0; j < pObj.staticObj_PlacedDetails.Count; j++)
		{
			if (pObj.staticObj_PlacedDetails[j].bDisabled)
			{
				continue;
			}
			for (int k = 0; k < pObj.StaticGameObjectsArray.Length; k++)
			{
				if (pObj.staticObj_PlacedDetails[j].objID / 100 == 3 && pObj.StaticGameObjectsArray[k].name.Equals(pObj.staticObj_PlacedDetails[j].objName + IGT_Constants.Cap))
				{
					pObj.StaticGameObjectsArray[k].SetActive(false);
					break;
				}
				if (pObj.StaticGameObjectsArray[k].name.Equals(pObj.staticObj_PlacedDetails[j].objName))
				{
					pObj.StaticGameObjectsArray[k].SetActive(true);
					if (IGT_GameView.pHero.nSound == 0)
					{
						pObj.StaticGameObjectsArray[k].GetComponent<AudioSource>().Play();
					}
					break;
				}
			}
		}
	}

	public List<IGT_ObjInfo> objDetInGivenPath(int pid)
	{
		List<IGT_ObjInfo> list = new List<IGT_ObjInfo>();
		for (int i = 0; i < pObj.staticObj_PlacedDetails.Count; i++)
		{
			if (pid == pObj.staticObj_PlacedDetails[i].nPathId)
			{
				list.Add(new IGT_ObjInfo(pObj.staticObj_PlacedDetails[i].objPlaceType, pObj.staticObj_PlacedDetails[i].nPathId, pObj.staticObj_PlacedDetails[i].fDistFrmStrtPnt, pObj.staticObj_PlacedDetails[i].fOffset, pObj.staticObj_PlacedDetails[i].ObjPos, pObj.staticObj_PlacedDetails[i].objRot, pObj.staticObj_PlacedDetails[i].objID, pObj.staticObj_PlacedDetails[i].objType, pObj.staticObj_PlacedDetails[i].objName, pObj.staticObj_PlacedDetails[i].fLength, pObj.staticObj_PlacedDetails[i].fWidth, pObj.staticObj_PlacedDetails[i].fHeight, pObj.staticObj_PlacedDetails[i].fHeight1, pObj.staticObj_PlacedDetails[i].bplyrCrsd, pObj.staticObj_PlacedDetails[i].fObjPlacedTime, pObj.staticObj_PlacedDetails[i].fLifeTime, pObj.staticObj_PlacedDetails[i].fMinDstBwObj, pObj.staticObj_PlacedDetails[i].bDisabled));
			}
		}
		for (int j = 0; j < pObj.objFrDraw.Count; j++)
		{
			if (pid == pObj.objFrDraw[j].nPathId)
			{
				list.Add(new IGT_ObjInfo(pObj.objFrDraw[j].objPlaceType, pObj.objFrDraw[j].nPathId, pObj.objFrDraw[j].fDistFrmStrtPnt, pObj.objFrDraw[j].fOffset, pObj.objFrDraw[j].ObjPos, pObj.objFrDraw[j].objRot, pObj.objFrDraw[j].objID, pObj.objFrDraw[j].objType, pObj.objFrDraw[j].objName, pObj.objFrDraw[j].fLength, pObj.objFrDraw[j].fWidth, pObj.objFrDraw[j].fHeight, pObj.objFrDraw[j].fHeight1, pObj.objFrDraw[j].bplyrCrsd, pObj.objFrDraw[j].fObjPlacedTime, pObj.objFrDraw[j].fLifeTime, pObj.objFrDraw[j].fMinDstBwObj, pObj.objFrDraw[j].bDisabled));
			}
		}
		for (int k = 0; k < pObj.movingObj.Count; k++)
		{
			int num = pObj.movingObj[k].nPathId;
			if (pObj.movingObj[k].bVehicleCrossedCurPath)
			{
				num = pObj.movingObj[k].VehicleDestPathID;
			}
			if (pid == num)
			{
				if (!pObj.movingObj[k].bVehicleCrossedCurPath)
				{
					list.Add(new IGT_ObjInfo(pObj.movingObj[k].fVechicleSpeed, pObj.movingObj[k].objPlaceType, pObj.movingObj[k].nPathId, pObj.movingObj[k].fOffset, pObj.movingObj[k].ObjPos, pObj.movingObj[k].objRot, pObj.movingObj[k].objID, pObj.movingObj[k].objType, pObj.movingObj[k].objName, pObj.movingObj[k].fLength, pObj.movingObj[k].fWidth, pObj.movingObj[k].fHeight, pObj.movingObj[k].fHeight1, pObj.movingObj[k].bvehicleMoveEnabled, pObj.movingObj[k].bvehicleReachd, pObj.movingObj[k].bdataInit, pObj.movingObj[k].CurPointID, pObj.movingObj[k].VehicleDestPos, pObj.movingObj[k].VehicleAnimPoint, pObj.movingObj[k].VehicleDestPathID, pObj.movingObj[k].NextPointID, pObj.movingObj[k].bTravRev, pObj.movingObj[k].NoOfTarReached, pObj.movingObj[k].VehicleDestPathCurPointID, pObj.movingObj[k].bVehicleDestPathTravRev, pObj.movingObj[k].bVehicleCrossedCurPath, pObj.movingObj[k].VehicleDestPathNextPntID, pObj.movingObj[k].fDistFrmStrtPnt));
				}
				else
				{
					list.Add(new IGT_ObjInfo(pObj.movingObj[k].fVechicleSpeed, pObj.movingObj[k].objPlaceType, pObj.movingObj[k].VehicleDestPathID, pObj.movingObj[k].fOffset, pObj.movingObj[k].ObjPos, pObj.movingObj[k].objRot, pObj.movingObj[k].objID, pObj.movingObj[k].objType, pObj.movingObj[k].objName, pObj.movingObj[k].fLength, pObj.movingObj[k].fWidth, pObj.movingObj[k].fHeight, pObj.movingObj[k].fHeight1, pObj.movingObj[k].bvehicleMoveEnabled, pObj.movingObj[k].bvehicleReachd, pObj.movingObj[k].bdataInit, pObj.movingObj[k].CurPointID, pObj.movingObj[k].VehicleDestPos, pObj.movingObj[k].VehicleAnimPoint, pObj.movingObj[k].VehicleDestPathID, pObj.movingObj[k].NextPointID, pObj.movingObj[k].bVehicleDestPathTravRev, pObj.movingObj[k].NoOfTarReached, pObj.movingObj[k].VehicleDestPathCurPointID, pObj.movingObj[k].bVehicleDestPathTravRev, pObj.movingObj[k].bVehicleCrossedCurPath, pObj.movingObj[k].VehicleDestPathNextPntID, pObj.movingObj[k].fDistFrmStrtPnt));
				}
			}
		}
		for (int l = 0; l < pObj.missionObj_PlacedDetails.Count; l++)
		{
			if (pid == pObj.missionObj_PlacedDetails[l].nPathId)
			{
				list.Add(new IGT_ObjInfo(pObj.missionObj_PlacedDetails[l].objPlaceType, pObj.missionObj_PlacedDetails[l].nPathId, pObj.missionObj_PlacedDetails[l].fDistFrmStrtPnt, pObj.missionObj_PlacedDetails[l].fOffset, pObj.missionObj_PlacedDetails[l].ObjPos, pObj.missionObj_PlacedDetails[l].objRot, pObj.missionObj_PlacedDetails[l].objID, pObj.missionObj_PlacedDetails[l].objType, pObj.missionObj_PlacedDetails[l].objName, pObj.missionObj_PlacedDetails[l].fLength, pObj.missionObj_PlacedDetails[l].fWidth, pObj.missionObj_PlacedDetails[l].fHeight, pObj.missionObj_PlacedDetails[l].fHeight1, pObj.missionObj_PlacedDetails[l].bplyrCrsd, pObj.missionObj_PlacedDetails[l].fObjPlacedTime, pObj.missionObj_PlacedDetails[l].fLifeTime, pObj.missionObj_PlacedDetails[l].fMinDstBwObj, pObj.missionObj_PlacedDetails[l].bDisabled));
			}
		}
		for (int m = 0; m < pObj.splPowersObj_PlacedDetails.Count; m++)
		{
			if (pid == pObj.splPowersObj_PlacedDetails[m].nPathId)
			{
				list.Add(new IGT_ObjInfo(pObj.splPowersObj_PlacedDetails[m].objPlaceType, pObj.splPowersObj_PlacedDetails[m].nPathId, pObj.splPowersObj_PlacedDetails[m].fDistFrmStrtPnt, pObj.splPowersObj_PlacedDetails[m].fOffset, pObj.splPowersObj_PlacedDetails[m].ObjPos, pObj.splPowersObj_PlacedDetails[m].objRot, pObj.splPowersObj_PlacedDetails[m].objID, pObj.splPowersObj_PlacedDetails[m].objType, pObj.splPowersObj_PlacedDetails[m].objName, pObj.splPowersObj_PlacedDetails[m].fLength, pObj.splPowersObj_PlacedDetails[m].fWidth, pObj.splPowersObj_PlacedDetails[m].fHeight, pObj.splPowersObj_PlacedDetails[m].fHeight1, pObj.splPowersObj_PlacedDetails[m].bplyrCrsd, pObj.splPowersObj_PlacedDetails[m].fObjPlacedTime, pObj.splPowersObj_PlacedDetails[m].fLifeTime, pObj.splPowersObj_PlacedDetails[m].fMinDstBwObj, pObj.splPowersObj_PlacedDetails[m].bDisabled));
			}
		}
		return list;
	}

	public void objDetInCurPath(int pid)
	{
		int num = 0;
		for (int i = 0; i < pObj.staticObj_PlacedDetails.Count; i++)
		{
			if (pid == pObj.staticObj_PlacedDetails[i].nPathId)
			{
				pObj.obj[num] = new IGT_ObjInfo(pObj.staticObj_PlacedDetails[i].objPlaceType, pObj.staticObj_PlacedDetails[i].nPathId, pObj.staticObj_PlacedDetails[i].fDistFrmStrtPnt, pObj.staticObj_PlacedDetails[i].fOffset, pObj.staticObj_PlacedDetails[i].ObjPos, pObj.staticObj_PlacedDetails[i].objRot, pObj.staticObj_PlacedDetails[i].objID, pObj.staticObj_PlacedDetails[i].objType, pObj.staticObj_PlacedDetails[i].objName, pObj.staticObj_PlacedDetails[i].fLength, pObj.staticObj_PlacedDetails[i].fWidth, pObj.staticObj_PlacedDetails[i].fHeight, pObj.staticObj_PlacedDetails[i].fHeight1, pObj.staticObj_PlacedDetails[i].bplyrCrsd, pObj.staticObj_PlacedDetails[i].fObjPlacedTime, pObj.staticObj_PlacedDetails[i].fLifeTime, pObj.staticObj_PlacedDetails[i].fMinDstBwObj, pObj.staticObj_PlacedDetails[i].bDisabled);
				num++;
			}
		}
		for (int j = 0; j < pObj.objFrDraw.Count; j++)
		{
			if (pid == pObj.objFrDraw[j].nPathId)
			{
				pObj.obj[num] = new IGT_ObjInfo(pObj.objFrDraw[j].objPlaceType, pObj.objFrDraw[j].nPathId, pObj.objFrDraw[j].fDistFrmStrtPnt, pObj.objFrDraw[j].fOffset, pObj.objFrDraw[j].ObjPos, pObj.objFrDraw[j].objRot, pObj.objFrDraw[j].objID, pObj.objFrDraw[j].objType, pObj.objFrDraw[j].objName, pObj.objFrDraw[j].fLength, pObj.objFrDraw[j].fWidth, pObj.objFrDraw[j].fHeight, pObj.objFrDraw[j].fHeight1, pObj.objFrDraw[j].bplyrCrsd, pObj.objFrDraw[j].fObjPlacedTime, pObj.objFrDraw[j].fLifeTime, pObj.objFrDraw[j].fMinDstBwObj, pObj.objFrDraw[j].bDisabled);
				num++;
			}
		}
		for (int k = 0; k < pObj.movingObj.Count; k++)
		{
			int num2 = pObj.movingObj[k].nPathId;
			if (pObj.movingObj[k].bVehicleCrossedCurPath)
			{
				num2 = pObj.movingObj[k].VehicleDestPathID;
			}
			if (pid == num2)
			{
				if (!pObj.movingObj[k].bVehicleCrossedCurPath)
				{
					pObj.obj[num] = new IGT_ObjInfo(pObj.movingObj[k].fVechicleSpeed, pObj.movingObj[k].objPlaceType, pObj.movingObj[k].nPathId, pObj.movingObj[k].fOffset, pObj.movingObj[k].ObjPos, pObj.movingObj[k].objRot, pObj.movingObj[k].objID, pObj.movingObj[k].objType, pObj.movingObj[k].objName, pObj.movingObj[k].fLength, pObj.movingObj[k].fWidth, pObj.movingObj[k].fHeight, pObj.movingObj[k].fHeight1, pObj.movingObj[k].bvehicleMoveEnabled, pObj.movingObj[k].bvehicleReachd, pObj.movingObj[k].bdataInit, pObj.movingObj[k].CurPointID, pObj.movingObj[k].VehicleDestPos, pObj.movingObj[k].VehicleAnimPoint, pObj.movingObj[k].VehicleDestPathID, pObj.movingObj[k].NextPointID, pObj.movingObj[k].bTravRev, pObj.movingObj[k].NoOfTarReached, pObj.movingObj[k].VehicleDestPathCurPointID, pObj.movingObj[k].bVehicleDestPathTravRev, pObj.movingObj[k].bVehicleCrossedCurPath, pObj.movingObj[k].VehicleDestPathNextPntID, pObj.movingObj[k].fDistFrmStrtPnt);
				}
				else
				{
					pObj.obj[num] = new IGT_ObjInfo(pObj.movingObj[k].fVechicleSpeed, pObj.movingObj[k].objPlaceType, pObj.movingObj[k].VehicleDestPathID, pObj.movingObj[k].fOffset, pObj.movingObj[k].ObjPos, pObj.movingObj[k].objRot, pObj.movingObj[k].objID, pObj.movingObj[k].objType, pObj.movingObj[k].objName, pObj.movingObj[k].fLength, pObj.movingObj[k].fWidth, pObj.movingObj[k].fHeight, pObj.movingObj[k].fHeight1, pObj.movingObj[k].bvehicleMoveEnabled, pObj.movingObj[k].bvehicleReachd, pObj.movingObj[k].bdataInit, pObj.movingObj[k].CurPointID, pObj.movingObj[k].VehicleDestPos, pObj.movingObj[k].VehicleAnimPoint, pObj.movingObj[k].VehicleDestPathID, pObj.movingObj[k].NextPointID, pObj.movingObj[k].bVehicleDestPathTravRev, pObj.movingObj[k].NoOfTarReached, pObj.movingObj[k].VehicleDestPathCurPointID, pObj.movingObj[k].bVehicleDestPathTravRev, pObj.movingObj[k].bVehicleCrossedCurPath, pObj.movingObj[k].VehicleDestPathNextPntID, pObj.movingObj[k].fDistFrmStrtPnt);
				}
				num++;
			}
		}
		for (int l = 0; l < pObj.missionObj_PlacedDetails.Count; l++)
		{
			if (pid == pObj.missionObj_PlacedDetails[l].nPathId)
			{
				pObj.obj[num] = new IGT_ObjInfo(pObj.missionObj_PlacedDetails[l].objPlaceType, pObj.missionObj_PlacedDetails[l].nPathId, pObj.missionObj_PlacedDetails[l].fDistFrmStrtPnt, pObj.missionObj_PlacedDetails[l].fOffset, pObj.missionObj_PlacedDetails[l].ObjPos, pObj.missionObj_PlacedDetails[l].objRot, pObj.missionObj_PlacedDetails[l].objID, pObj.missionObj_PlacedDetails[l].objType, pObj.missionObj_PlacedDetails[l].objName, pObj.missionObj_PlacedDetails[l].fLength, pObj.missionObj_PlacedDetails[l].fWidth, pObj.missionObj_PlacedDetails[l].fHeight, pObj.missionObj_PlacedDetails[l].fHeight1, pObj.missionObj_PlacedDetails[l].bplyrCrsd, pObj.missionObj_PlacedDetails[l].fObjPlacedTime, pObj.missionObj_PlacedDetails[l].fLifeTime, pObj.missionObj_PlacedDetails[l].fMinDstBwObj, pObj.missionObj_PlacedDetails[l].bDisabled);
				num++;
			}
		}
		for (int m = 0; m < pObj.splPowersObj_PlacedDetails.Count; m++)
		{
			if (pid == pObj.splPowersObj_PlacedDetails[m].nPathId)
			{
				pObj.obj[num] = new IGT_ObjInfo(pObj.splPowersObj_PlacedDetails[m].objPlaceType, pObj.splPowersObj_PlacedDetails[m].nPathId, pObj.splPowersObj_PlacedDetails[m].fDistFrmStrtPnt, pObj.splPowersObj_PlacedDetails[m].fOffset, pObj.splPowersObj_PlacedDetails[m].ObjPos, pObj.splPowersObj_PlacedDetails[m].objRot, pObj.splPowersObj_PlacedDetails[m].objID, pObj.splPowersObj_PlacedDetails[m].objType, pObj.splPowersObj_PlacedDetails[m].objName, pObj.splPowersObj_PlacedDetails[m].fLength, pObj.splPowersObj_PlacedDetails[m].fWidth, pObj.splPowersObj_PlacedDetails[m].fHeight, pObj.splPowersObj_PlacedDetails[m].fHeight1, pObj.splPowersObj_PlacedDetails[m].bplyrCrsd, pObj.splPowersObj_PlacedDetails[m].fObjPlacedTime, pObj.splPowersObj_PlacedDetails[m].fLifeTime, pObj.splPowersObj_PlacedDetails[m].fMinDstBwObj, pObj.splPowersObj_PlacedDetails[m].bDisabled);
				num++;
			}
		}
		pObj.nTotObjinCurPath = num;
	}

	public void RemoveTimeExceeded_DynamiObj(ref List<IGT_ObjInfo> datas)
	{
		for (int num = datas.Count - 1; num >= 0; num--)
		{
			if (datas[num].objType != 7 && datas[num].objType != 8)
			{
				if (!nAdjPIDs.Contains(datas[num].nPathId) && datas[num].nPathId != currentPathIndex && datas[num].objPlaceType != 0 && Time.timeSinceLevelLoad - datas[num].fObjPlacedTime > datas[num].fLifeTime && (datas[num].objType != 6 || !(datas[num].ObjPos == IGT_Objects.ThrowObj_Placed_Pos) || !IGT_Hero.bThrwObjPicked))
				{
					datas.RemoveAt(num);
				}
			}
			else if (datas[num].objType == 7 || datas[num].objType == 8)
			{
				if (datas[num].nPathId == currentPathIndex || datas[num].objPlaceType == 0)
				{
					if (datas[num].bplyrCrsd)
					{
						datas.RemoveAt(num);
					}
				}
				else if (Time.timeSinceLevelLoad - datas[num].fObjPlacedTime > datas[num].fLifeTime || datas[num].bplyrCrsd)
				{
					datas.RemoveAt(num);
				}
			}
		}
	}

	private void objDiffcultySelection()
	{
		if (IGT_Hero.startFrame - IGT_Hero.fTimeFrObjDiffculty > 20.0 && IGT_Constants.nDynamicObj_PlacingProb <= 100)
		{
			IGT_Constants.nDynamicObj_PlacingProb += 3;
			IGT_Constants.nValArrForEachStaticObjEnableProbability[2] += 2;
			CumulativeProbCalc();
			IGT_Constants.fRandValFrObjPlacing = IGT_Constants.fInitRandValfrObjPlacing / (float)IGT_Constants.nDynamicObj_PlacingProb + (float)IGT_Constants.nConsValFrRandValSelection;
			IGT_Hero.fTimeFrObjDiffculty = IGT_Hero.startFrame;
		}
	}

	private int getRandomNumber()
	{
		System.Random random = new System.Random();
		return random.Next() % 89 + random.Next() % 9349 + random.Next() % 98179;
	}

	public int getRandomNumber(int maxRange)
	{
		System.Random random = new System.Random();
		int num = random.Next() % 89 + random.Next() % 9349 + random.Next() % 98179;
		return num % maxRange;
	}

	public int DynObjSeletion(int PathID)
	{
		int num = -1;
		int num2 = 0;
		while (num == -1)
		{
			num2 = 0;
			int num3 = UnityEngine.Random.Range(0, IGT_Constants.nSumOfProb_DynamicObj);
			for (int i = 0; i < IGT_FileReading.nobjLen - IGT_Constants.nNoOfMovingObj - IGT_Constants.nNoOfEnergyItems - pObj.staticObj_TotalDetails.Count; i++)
			{
				num2 += pObj.DynamicObjIndexBasedProbability[i, 3];
				if (num2 < num3)
				{
					continue;
				}
				int num4 = pObj.DynamicObjIndexBasedProbability[i, 0];
				string text = IGT_FileReading.data[num4];
				string[] array = text.Split('~');
				string source = array[12];
				int[] array2 = new int[10];
				array2 = source.Select((char c) => int.Parse(c.ToString())).ToArray();
				switch (pathLocation[PathID])
				{
				case 0:
					if (array2[0] == 1)
					{
						num = num4;
					}
					break;
				case 1:
					if (array2[1] == 1)
					{
						num = num4;
					}
					break;
				case 2:
					if (array2[2] == 1)
					{
						num = num4;
					}
					break;
				case 3:
					if (array2[3] == 1)
					{
						num = num4;
					}
					break;
				}
				if (IGT_GameView.pHero.nGameMode == 1 && (IGT_GameView.pHero.pMissionData.nMissionType == 4 || IGT_GameView.pHero.pMissionData.nMissionType == 0 || IGT_GameView.pHero.pMissionData.nMissionType == 5 || IGT_GameView.pHero.pMissionData.nMissionType == 3))
				{
					if (int.Parse(array[2]) == 4 || int.Parse(array[2]) == 6)
					{
						num = -1;
					}
				}
				else if (IGT_GameView.pHero.nGameMode == 1 && IGT_GameView.pHero.pMissionData.nMissionType == 1)
				{
					if ((int.Parse(array[2]) == 4 && IGT_GameView.pHero.pMissionData.nChallengesInnerItemType == 1) || (int.Parse(array[2]) == 6 && IGT_GameView.pHero.pMissionData.nChallengesInnerItemType == 0))
					{
						num = -1;
					}
					if ((IGT_GameView.pHero.pMissionData.nChallengesInnerItemType == 3 && (int.Parse(array[2]) == 4 || int.Parse(array[2]) == 6)) || (IGT_GameView.pHero.pMissionData.nChallengesInnerItemType == 2 && (int.Parse(array[2]) == 4 || int.Parse(array[2]) == 6)))
					{
						num = -1;
					}
				}
				if (int.Parse(array[2]) == 4 && (PathID == 4 || PathID == 5 || PathID == 25) && UnityEngine.Random.Range(0, 100) > 2)
				{
					num = -1;
				}
				break;
			}
		}
		return num;
	}

	public int EnergyObjIndexSeletion(int PathID)
	{
		int num = -1;
		int num2 = 0;
		while (num == -1)
		{
			num2 = 0;
			int num3 = UnityEngine.Random.Range(0, IGT_Constants.nSumOfProb_CoinObj);
			for (int i = 0; i < IGT_Constants.nNoOfEnergyItems; i++)
			{
				num2 += pObj.CoinObjIndexBasedProbability[i, 3];
				if (num2 < num3)
				{
					continue;
				}
				int num4 = pObj.CoinObjIndexBasedProbability[i, 0];
				string text = IGT_FileReading.data[num4];
				string[] array = text.Split('~');
				string source = array[12];
				int[] array2 = new int[10];
				array2 = source.Select((char c) => int.Parse(c.ToString())).ToArray();
				switch (pathLocation[PathID])
				{
				case 0:
					if (array2[0] == 1)
					{
						num = num4;
					}
					break;
				case 1:
					if (array2[1] == 1)
					{
						num = num4;
					}
					break;
				case 2:
					if (array2[2] == 1)
					{
						num = num4;
					}
					break;
				case 3:
					if (array2[3] == 1)
					{
						num = num4;
					}
					break;
				}
				break;
			}
		}
		return num;
	}

	public int specialPowerObjIndexSeletion(int PathID)
	{
		int num = -1;
		int num2 = 0;
		if (IGT_Constants.nSumOfProb_SplPowersObj == 0)
		{
			return 72;
		}
		int num3 = 0;
		while (num == -1 && num3 < 50)
		{
			num2 = 0;
			int randomNumber = getRandomNumber(IGT_Constants.nSumOfProb_SplPowersObj);
			for (int i = 0; i < IGT_Constants.nNoOfSplPowers; i++)
			{
				num2 += pObj.specialPowersIndexBasedProbability[i, 3];
				if (num2 >= randomNumber)
				{
					num = pObj.specialPowersIndexBasedProbability[i, 0];
					break;
				}
			}
			num3++;
		}
		if (IGT_GameView.pHero.nGameMode == 0)
		{
			if (num == 67 || num == 70 || num == 71 || num == 74 || num == 75)
			{
				num = specialPowerObjIndexSeletion(PathID);
			}
		}
		else if (IGT_GameView.pHero.nGameMode == 1)
		{
			if (IGT_GameView.pHero.pMissionData.nMissionType == 0 || IGT_GameView.pHero.pMissionData.nMissionType == 5)
			{
				if (num == 67 || num == 68 || num == 69 || num == 70 || num == 71 || num == 76)
				{
					num = specialPowerObjIndexSeletion(PathID);
				}
			}
			else if (IGT_GameView.pHero.pMissionData.nMissionType == 1 || IGT_GameView.pHero.pMissionData.nMissionType == 2)
			{
				num = ((IGT_GameView.pHero.pMissionData.nMissionType == 1 && (IGT_GameView.pHero.pMissionData.nChallengesInnerItemType == 2 || IGT_GameView.pHero.pMissionData.nChallengesInnerItemType == 3)) ? 72 : ((UnityEngine.Random.Range(0, 100) >= 80) ? 72 : 68));
			}
			else if ((IGT_GameView.pHero.pMissionData.nMissionType == 4 || IGT_GameView.pHero.pMissionData.nMissionType == 3) && (num == 67 || num == 69 || num == 70 || num == 71 || num == 73 || num == 74))
			{
				num = specialPowerObjIndexSeletion(PathID);
			}
		}
		return num;
	}

	public int specialPowerObjIndexSeletion_Chase()
	{
		int result = -1;
		if (IGT_Constants.splPowers_Chase_placedObj[0, 0] == 1f && IGT_Constants.splPowers_Chase_placedObj[1, 0] == 1f && IGT_Constants.splPowers_Chase_placedObj[2, 0] == 1f)
		{
			IGT_Constants.splPowers_Chase_placedObj[0, 0] = 0f;
			IGT_Constants.splPowers_Chase_placedObj[1, 0] = 0f;
			IGT_Constants.splPowers_Chase_placedObj[2, 0] = 0f;
		}
		List<int> list = new List<int>();
		for (int i = 0; i < 3; i++)
		{
			if (IGT_Constants.splPowers_Chase_placedObj[i, 0] == 0f)
			{
				float num = 0f;
				switch (i)
				{
				case 0:
					num = IGT_Constants.Interval_Magnet;
					break;
				case 1:
					num = IGT_Constants.Interval_Coin;
					break;
				case 2:
					num = IGT_Constants.Interval_Shield;
					break;
				}
				if (Time.time - IGT_Constants.splPowers_Chase_placedObj[i, 1] > num)
				{
					list.Add(i);
				}
			}
		}
		if (list.Count > 0)
		{
			int index = UnityEngine.Random.Range(0, list.Count);
			switch (list.ElementAt(index))
			{
			case 0:
				result = 67;
				break;
			case 1:
				result = ((UnityEngine.Random.Range(0, 100) >= 66) ? 71 : 70);
				break;
			case 2:
				result = 74;
				break;
			}
		}
		return result;
	}

	public void StaticObjPlacingInfoselection(List<int> PIDx)
	{
		bool flag = false;
		for (int i = 0; i < PIDx.Count; i++)
		{
			if (!flag)
			{
				int randomNumber = getRandomNumber(100);
				if (randomNumber > IGT_Constants.nValfrStaticObjEnablingInPath)
				{
					continue;
				}
				int num = IGT_Constants.nValArrForEachStaticObjEnableProbability[0];
				List<IGT_ObjInfo> list = new List<IGT_ObjInfo>();
				list = StaticObjDetailsInGivenPath(PIDx[i]);
				for (int j = 0; j < list.Count; j++)
				{
					if (!isStaticObjAlreadyPlaced(list[j].objID) && !isSelectedStaticObjCollidedWithAlreadyPlacedObjects(list[j]))
					{
						int num2 = UnityEngine.Random.Range(0, 100);
						if (num2 <= num)
						{
							pObj.staticObj_PlacedDetails.Add(new IGT_ObjInfo(list[j].objPlaceType, list[j].nPathId, list[j].fDistFrmStrtPnt, list[j].fOffset, list[j].ObjPos, list[j].objRot, list[j].objID, list[j].objType, list[j].objName, list[j].fLength, list[j].fWidth, list[j].fHeight, list[j].fHeight1, list[j].bplyrCrsd, Time.time, list[j].fLifeTime, list[j].fMinDstBwObj, false));
						}
					}
				}
				continue;
			}
			for (int k = 0; k < pObj.staticObj_TotalDetails.Count; k++)
			{
				if (PIDx[i] == pObj.staticObj_TotalDetails[k].nPathId)
				{
					pObj.staticObj_PlacedDetails.Add(new IGT_ObjInfo(pObj.staticObj_TotalDetails[k].objPlaceType, pObj.staticObj_TotalDetails[k].nPathId, pObj.staticObj_TotalDetails[k].fDistFrmStrtPnt, pObj.staticObj_TotalDetails[k].fOffset, pObj.staticObj_TotalDetails[k].ObjPos, pObj.staticObj_TotalDetails[k].objRot, pObj.staticObj_TotalDetails[k].objID, pObj.staticObj_TotalDetails[k].objType, pObj.staticObj_TotalDetails[k].objName, pObj.staticObj_TotalDetails[k].fLength, pObj.staticObj_TotalDetails[k].fWidth, pObj.staticObj_TotalDetails[k].fHeight, pObj.staticObj_TotalDetails[k].fHeight1, pObj.staticObj_TotalDetails[k].bplyrCrsd, Time.time, pObj.staticObj_TotalDetails[k].fLifeTime, pObj.staticObj_TotalDetails[k].fMinDstBwObj, false));
				}
			}
		}
	}

	private bool isSelectedStaticObjCollidedWithAlreadyPlacedObjects(IGT_ObjInfo pobjInfo)
	{
		bool flag = false;
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		int num4 = -1;
		objDetInCurPath(pobjInfo.nPathId);
		num4 = findNxtObjIdBasedDistinFrwdPath(pobjInfo.fDistFrmStrtPnt);
		if (num4 != -1)
		{
			num = pObj.obj[num4].fDistFrmStrtPnt;
			num2 = pObj.obj[num4].fMinDstBwObj;
			num3 = pObj.obj[num4].fWidth;
			if (pobjInfo.fDistFrmStrtPnt + pobjInfo.fWidth / 2f + pobjInfo.fMinDstBwObj > num - num3 / 2f - num2)
			{
				flag = true;
				if (pObj.obj[num4].objPlaceType == 0 && pObj.obj[num4].fOffset != pobjInfo.fOffset)
				{
					flag = false;
				}
			}
			if (pObj.obj[num4].objType == 3)
			{
				if (pObj.obj[num4].bVehicleCrossedCurPath && pObj.obj[num4].bTravRev)
				{
					num = pathLength[pObj.obj[num4].nPathId] - num;
				}
				if (pobjInfo.fDistFrmStrtPnt + pobjInfo.fWidth / 2f + pobjInfo.fMinDstBwObj > num - 5f)
				{
					flag = true;
				}
			}
		}
		if (!flag)
		{
			num4 = findNxtObjIdBasedDistinRevPath(pobjInfo.fDistFrmStrtPnt);
			if (num4 != -1)
			{
				num = pObj.obj[num4].fDistFrmStrtPnt;
				num2 = pObj.obj[num4].fMinDstBwObj;
				num3 = pObj.obj[num4].fWidth;
				if (num + num3 / 2f + num2 > pobjInfo.fDistFrmStrtPnt - pobjInfo.fWidth / 2f - pobjInfo.fMinDstBwObj)
				{
					flag = true;
					if (pObj.obj[num4].objPlaceType == 0 && pObj.obj[num4].fOffset != pobjInfo.fOffset)
					{
						flag = false;
					}
				}
				if (pObj.obj[num4].objType == 3)
				{
					if (pObj.obj[num4].bVehicleCrossedCurPath && pObj.obj[num4].bTravRev)
					{
						num = pathLength[pObj.obj[num4].nPathId] - num;
					}
					if (num + 5f > pobjInfo.fDistFrmStrtPnt - pobjInfo.fWidth / 2f - pobjInfo.fMinDstBwObj)
					{
						flag = true;
					}
				}
			}
		}
		return flag;
	}

	public bool isStaticObjAlreadyPlaced(int objId)
	{
		bool result = false;
		for (int i = 0; i < pObj.staticObj_PlacedDetails.Count; i++)
		{
			if (pObj.staticObj_PlacedDetails[i].objID.Equals(objId))
			{
				result = true;
				break;
			}
		}
		return result;
	}

	public List<IGT_ObjInfo> StaticObjDetailsInGivenPath(int pid)
	{
		List<IGT_ObjInfo> list = new List<IGT_ObjInfo>();
		for (int i = 0; i < pObj.staticObj_TotalDetails.Count; i++)
		{
			if (pid == pObj.staticObj_TotalDetails[i].nPathId)
			{
				list.Add(new IGT_ObjInfo(pObj.staticObj_TotalDetails[i].objPlaceType, pObj.staticObj_TotalDetails[i].nPathId, pObj.staticObj_TotalDetails[i].fDistFrmStrtPnt, pObj.staticObj_TotalDetails[i].fOffset, pObj.staticObj_TotalDetails[i].ObjPos, pObj.staticObj_TotalDetails[i].objRot, pObj.staticObj_TotalDetails[i].objID, pObj.staticObj_TotalDetails[i].objType, pObj.staticObj_TotalDetails[i].objName, pObj.staticObj_TotalDetails[i].fLength, pObj.staticObj_TotalDetails[i].fWidth, pObj.staticObj_TotalDetails[i].fHeight, pObj.staticObj_TotalDetails[i].fHeight1, pObj.staticObj_TotalDetails[i].bplyrCrsd, Time.time, pObj.staticObj_TotalDetails[i].fLifeTime, pObj.staticObj_TotalDetails[i].fMinDstBwObj, false));
			}
		}
		return list;
	}

	public void DynamicObjInfoSelection(List<int> PIDx)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		string text = "null";
		float num4 = 0f;
		float num5 = 0f;
		float num6 = 0f;
		float num7 = 0f;
		float num8 = 0f;
		int num9 = -1;
		float num10 = 0f;
		Vector3 zero = Vector3.zero;
		Vector3 zero2 = Vector3.zero;
		bool flag = false;
		bool flag2 = false;
		float num11 = 0f;
		float num12 = 0f;
		float num13 = 0f;
		bool flag3 = false;
		float num14 = 0f;
		float num15 = 0f;
		float num16 = 0f;
		float num17 = 0f;
		float num18 = 0f;
		int num19 = -1;
		int num20 = 0;
		float num21 = 4f;
		nPatternPlacedCount = 0;
		nPatternPlacementDetails = new int[10, 5];
		for (int i = 0; i < nPatternPlacementDetails.GetLength(0); i++)
		{
			for (int j = 0; j < nPatternPlacementDetails.GetLength(1); j++)
			{
				nPatternPlacementDetails[i, j] = -1;
			}
		}
		for (int k = 0; k < PIDx.Count; k++)
		{
			num9 = PIDx[k];
			num13 = 0f;
			objDetInCurPath(num9);
			num14 = (num15 = num21);
			num16 = 0f;
			num17 = 0f;
			num18 = 0f;
			num19 = -1;
			flag3 = false;
			num20 = 0;
			float num22 = 1f;
			if (UnityEngine.Random.Range(0, 100) < IGT_Constants.nValfrStaticObjEnablingInPath)
			{
				num22 = 0.75f;
			}
			int num23 = 0;
			while (num14 < pathLength[num9] - num21 && num23 < 200)
			{
				bool flag4 = false;
				if ((IGT_GameView.pHero.nGameMode == 0 && UnityEngine.Random.Range(0, 100) > 75) || (IGT_GameView.pHero.nGameMode == 1 && ((IGT_GameView.pHero.pMissionData.nMissionType == 1 && UnityEngine.Random.Range(0, 100) > 30) || (IGT_GameView.pHero.pMissionData.nMissionType == 2 && UnityEngine.Random.Range(0, 100) > 30))))
				{
					flag4 = false;
				}
				else if (UnityEngine.Random.Range(0, 100) < IGT_Constants.nDynamicObj_PlacingProb)
				{
					int num24 = patternIDselectionMethod(IGT_Constants.nDynamicObj_PlacingProb, num9);
					int num25 = pIGT_PatternDataLoading.nPatternParams[num24][UnityEngine.Random.Range(1, 3)];
					int num26 = (int)num14 + pIGT_PatternDataLoading.nPatternParams[num24][4] + 2;
					int num27 = num26 + num25;
					if ((float)num27 < pathLength[num9] - num21 && !isSelectedPatternColllidedWithAlreadyPlacedObjects(num9, num26, num27 + pIGT_PatternDataLoading.nPatternParams[num24][4]))
					{
						nPatternPlacementDetails[nPatternPlacedCount, 0] = num9;
						nPatternPlacementDetails[nPatternPlacedCount, 1] = num24;
						nPatternPlacementDetails[nPatternPlacedCount, 2] = num25;
						nPatternPlacementDetails[nPatternPlacedCount, 3] = num26;
						nPatternPlacementDetails[nPatternPlacedCount, 4] = num27;
						nPatternPlacedCount++;
						flag4 = true;
						num15 = (num14 = num27 + pIGT_PatternDataLoading.nPatternParams[num24][4] + 1);
					}
				}
				if (IGT_GameView.pHero.nGameMode == 1 && IGT_GameView.pHero.pMissionData.nRetryCount >= 7 && (IGT_GameView.pHero.pMissionData.nMissionType == 1 || IGT_GameView.pHero.pMissionData.nMissionType == 2))
				{
					flag4 = false;
				}
				if (!flag4)
				{
					int num28 = DynObjSeletion(num9);
					string text2 = IGT_FileReading.data[num28];
					string[] array = text2.Split('~');
					num = int.Parse(array[0]);
					num2 = int.Parse(array[1]);
					num3 = int.Parse(array[2]);
					text = array[3];
					num4 = float.Parse(array[4]);
					num5 = float.Parse(array[5]);
					num6 = float.Parse(array[6]);
					num7 = float.Parse(array[7]);
					num8 = float.Parse(array[8]);
					flag = false;
					flag2 = false;
					num11 = Time.timeSinceLevelLoad;
					num12 = float.Parse(array[9]);
					if ((num20 == 6 || num20 == 4) && (num3 == 6 || num3 == 4))
					{
						num23++;
						continue;
					}
					num19 = findNxtObjIdBasedDistinFrwdPath(num15);
					if (num19 == -1)
					{
						num16 = pathLength[num9] - num21;
						num17 = 0f;
						num18 = 0f;
					}
					else
					{
						num16 = pObj.obj[num19].fDistFrmStrtPnt;
						num17 = pObj.obj[num19].fMinDstBwObj;
						num18 = pObj.obj[num19].fWidth;
						if (pObj.obj[num19].objType == 3 && pObj.obj[num19].bVehicleCrossedCurPath && pObj.obj[num19].bVehicleDestPathTravRev)
						{
							num16 = pathLength[pObj.obj[num19].nPathId] - num16;
						}
					}
					float num29 = UnityEngine.Random.Range(IGT_Constants.fRandValFrObjPlacing * 0.3f, IGT_Constants.fRandValFrObjPlacing);
					num17 *= num22;
					num29 *= num22;
					if (num15 + num8 + num29 < num16 - num18 / 2f - num17)
					{
						num13 = num15 + num8 + num29;
						num15 = num13 + num5 / 2f;
						num14 = num13;
						flag3 = true;
					}
					else
					{
						num15 = num16 + num18 / 2f;
						num14 = num15;
						flag3 = false;
					}
					if (flag3 && num13 < pathLength[num9] - num21 && UnityEngine.Random.Range(0, 100) < IGT_Constants.nDynamicObj_PlacingProb)
					{
						num10 = fndRandOffset(num3, num4, num9);
						zero = findPos(num9, num13, num10);
						zero2 = findRotation(posFrFndngRot, prevPosFrFndngRot);
						pObj.objFrDraw.Add(new IGT_ObjInfo(num, num9, num13, num10, zero, zero2, num2, num3, text, num4, num5, num6, num7, flag, num11, num12, num8, flag2));
						num20 = num3;
					}
				}
				num23++;
			}
		}
	}

	private void AdjustThrowObjOffset()
	{
		int[] array = new int[6];
		for (int i = 0; i < 3; i++)
		{
			array = findPathBasedInput(currentPathIndex, bTraverseReverse, i);
			if (array[0] == -1 || array[1] == 0)
			{
				continue;
			}
			for (int j = 0; j < pObj.objFrDraw.Count; j++)
			{
				if (array[0] == pObj.objFrDraw[j].nPathId && pObj.objFrDraw[j].objType == 6 && pObj.objFrDraw[j].fOffset != 0f)
				{
					if (pObj.objFrDraw[j].fOffset < 0f)
					{
						pObj.objFrDraw[j].fOffset = -0.5f;
					}
					else
					{
						pObj.objFrDraw[j].fOffset = 0.35f;
					}
					pObj.objFrDraw[j].ObjPos = findPos(pObj.objFrDraw[j].nPathId, pObj.objFrDraw[j].fDistFrmStrtPnt, pObj.objFrDraw[j].fOffset);
				}
			}
		}
	}

	public void placingObjAtStartPah(int pathID)
	{
		nPatternPlacedCount = 0;
		float num = fGameStrtDist;
		if (bTraverseReverse)
		{
			num = pathLength[pathID] - num;
		}
		int num2 = Mathf.CeilToInt(num + 5f);
		int num3 = 3;
		if (bTraverseReverse)
		{
			num2 = 5;
			num3 = Mathf.CeilToInt(num + 6f);
		}
		int num4 = 0;
		while ((float)num2 < pathLength[pathID] - (float)num3 && num4 < 50)
		{
			int num5 = patternIDselectionMethod(IGT_Constants.nDynamicObj_PlacingProb, pathID);
			int num6 = pIGT_PatternDataLoading.nPatternParams[num5][3];
			int num7 = num2 + pIGT_PatternDataLoading.nPatternParams[num5][4] + 3;
			int num8 = num7 + num6;
			if ((float)num8 < pathLength[pathID] - (float)num3)
			{
				nPatternPlacementDetails[nPatternPlacedCount, 0] = pathID;
				nPatternPlacementDetails[nPatternPlacedCount, 1] = num5;
				nPatternPlacementDetails[nPatternPlacedCount, 2] = num6;
				nPatternPlacementDetails[nPatternPlacedCount, 3] = num7;
				nPatternPlacementDetails[nPatternPlacedCount, 4] = num8;
				nPatternPlacedCount++;
			}
			num2 = num8 + pIGT_PatternDataLoading.nPatternParams[num5][4] + 2;
			num4++;
		}
		pObj.objFrDraw.Clear();
		IGT_ObjPlacing.objDestruction();
		patternBasedDynamicObjPlacement();
		IGT_ObjPlacing.objPlaceAtRuntime(ref pObj.objFrDraw);
		pObj.ObjListInCurPathOfHero = objDetInGivenPath(pathID);
		if (IGT_GameView.pHero.isAIplayerAvailable)
		{
			IGT_AIPlayer.ObjListInCurPathOfAIPlayer = objDetInGivenPath(IGT_AIPlayer.AI_PlayerObj.currentPathIndex);
		}
	}

	public void tutorial_ObjPlacing_atStarting(int pathID, int missionID)
	{
		pObj.objFrDraw.Clear();
		IGT_ObjPlacing.objDestruction();
		switch (missionID)
		{
		case 0:
		{
			string text;
			string[] array;
			int objplceTyp;
			int obId;
			int typ;
			string obName;
			float len;
			float wid;
			float hei;
			float hei2;
			float mindist;
			float lfeTme;
			for (int i = 0; i < 5; i++)
			{
				int num = -1;
				float dist = 0f;
				float num2 = 0f;
				switch (i)
				{
				case 0:
					num = 59;
					dist = 10f;
					break;
				case 1:
					num = 42;
					dist = 16f;
					break;
				case 2:
					num = 58;
					dist = 22f;
					num2 = 0f - fTotalOffsetDeviation;
					break;
				case 3:
					num = 59;
					dist = 25f;
					num2 = fTotalOffsetDeviation;
					break;
				case 4:
					num = 48;
					dist = 30f;
					break;
				}
				text = IGT_FileReading.data[num];
				array = text.Split('~');
				objplceTyp = int.Parse(array[0]);
				obId = int.Parse(array[1]);
				typ = int.Parse(array[2]);
				obName = array[3];
				len = float.Parse(array[4]);
				wid = float.Parse(array[5]);
				hei = float.Parse(array[6]);
				hei2 = float.Parse(array[7]);
				mindist = float.Parse(array[8]);
				lfeTme = float.Parse(array[9]);
				Vector3 pos = findPos(pathID, dist, num2);
				Vector3 rot = findRotation(posFrFndngRot, prevPosFrFndngRot);
				pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, pathID, dist, num2, pos, rot, obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			}
			text = IGT_FileReading.data[57];
			array = text.Split('~');
			objplceTyp = int.Parse(array[0]);
			obId = int.Parse(array[1]);
			typ = int.Parse(array[2]);
			obName = array[3];
			len = float.Parse(array[4]);
			wid = float.Parse(array[5]);
			hei = float.Parse(array[6]);
			hei2 = float.Parse(array[7]);
			mindist = float.Parse(array[8]);
			lfeTme = float.Parse(array[9]);
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 10, 5f, 0f, findPos(10, 5f, 0f), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 10, 18f, 0f - fTotalOffsetDeviation, findPos(10, 18f, 0f - fTotalOffsetDeviation), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 11, 5f, 0f, findPos(11, 5f, 0f), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 11, 12f, fTotalOffsetDeviation, findPos(11, 12f, fTotalOffsetDeviation), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 11, 18f, 0f - fTotalOffsetDeviation, findPos(11, 18f, 0f - fTotalOffsetDeviation), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 17, 5f, 0f, findPos(17, 5f, 0f), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 17, 12f, fTotalOffsetDeviation, findPos(17, 12f, fTotalOffsetDeviation), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			text = IGT_FileReading.data[59];
			array = text.Split('~');
			objplceTyp = int.Parse(array[0]);
			obId = int.Parse(array[1]);
			typ = int.Parse(array[2]);
			obName = array[3];
			len = float.Parse(array[4]);
			wid = float.Parse(array[5]);
			hei = float.Parse(array[6]);
			hei2 = float.Parse(array[7]);
			mindist = float.Parse(array[8]);
			lfeTme = float.Parse(array[9]);
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 12, 0.1f, 0f, findPos(12, 0.1f, 0f), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 12, 0.1f, fTotalOffsetDeviation, findPos(12, 0.1f, fTotalOffsetDeviation), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 12, 0.1f, 0f - fTotalOffsetDeviation, findPos(12, 0.1f, 0f - fTotalOffsetDeviation), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 9, 0.1f, 0f, findPos(9, 0.1f, 0f), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 9, 0.1f, fTotalOffsetDeviation, findPos(9, 0.1f, fTotalOffsetDeviation), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 9, 0.1f, 0f - fTotalOffsetDeviation, findPos(9, 0.1f, 0f - fTotalOffsetDeviation), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 8, pathLength[8], 0f, findPos(8, pathLength[8], 0f), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 8, pathLength[8], fTotalOffsetDeviation, findPos(8, pathLength[8], fTotalOffsetDeviation), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 8, pathLength[8], 0f - fTotalOffsetDeviation, findPos(8, pathLength[8], 0f - fTotalOffsetDeviation), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			break;
		}
		case 1:
		{
			string text = IGT_FileReading.data[57];
			string[] array = text.Split('~');
			int objplceTyp = int.Parse(array[0]);
			int obId = int.Parse(array[1]);
			int typ = int.Parse(array[2]);
			string obName = array[3];
			float len = float.Parse(array[4]);
			float wid = float.Parse(array[5]);
			float hei = float.Parse(array[6]);
			float hei2 = float.Parse(array[7]);
			float mindist = float.Parse(array[8]);
			float lfeTme = float.Parse(array[9]);
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, pathID, 1f * (pathLength[pathID] / 4f), 0f, findPos(pathID, 1f * (pathLength[pathID] / 4f), 0f), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, pathID, 2f * (pathLength[pathID] / 4f), fTotalOffsetDeviation, findPos(pathID, 2f * (pathLength[pathID] / 4f), fTotalOffsetDeviation), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, pathID, 3f * (pathLength[pathID] / 4f), 0f - fTotalOffsetDeviation, findPos(pathID, 3f * (pathLength[pathID] / 4f), 0f - fTotalOffsetDeviation), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			text = IGT_FileReading.data[59];
			array = text.Split('~');
			objplceTyp = int.Parse(array[0]);
			obId = int.Parse(array[1]);
			typ = int.Parse(array[2]);
			obName = array[3];
			len = float.Parse(array[4]);
			wid = float.Parse(array[5]);
			hei = float.Parse(array[6]);
			hei2 = float.Parse(array[7]);
			mindist = float.Parse(array[8]);
			lfeTme = float.Parse(array[9]);
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 12, 0.1f, 0f, findPos(12, 0.1f, 0f), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 12, 0.1f, fTotalOffsetDeviation, findPos(12, 0.1f, fTotalOffsetDeviation), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 12, 0.1f, 0f - fTotalOffsetDeviation, findPos(12, 0.1f, 0f - fTotalOffsetDeviation), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 9, 0.1f, 0f, findPos(9, 0.1f, 0f), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 9, 0.1f, fTotalOffsetDeviation, findPos(9, 0.1f, fTotalOffsetDeviation), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 9, 0.1f, 0f - fTotalOffsetDeviation, findPos(9, 0.1f, 0f - fTotalOffsetDeviation), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 8, pathLength[8], 0f, findPos(8, pathLength[8], 0f), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 8, pathLength[8], fTotalOffsetDeviation, findPos(8, pathLength[8], fTotalOffsetDeviation), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 8, pathLength[8], 0f - fTotalOffsetDeviation, findPos(8, pathLength[8], 0f - fTotalOffsetDeviation), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			break;
		}
		case 2:
		{
			string text = IGT_FileReading.data[54];
			string[] array = text.Split('~');
			int objplceTyp = int.Parse(array[0]);
			int obId = int.Parse(array[1]);
			int typ = int.Parse(array[2]);
			string obName = array[3];
			float len = float.Parse(array[4]);
			float wid = float.Parse(array[5]);
			float hei = float.Parse(array[6]);
			float hei2 = float.Parse(array[7]);
			float mindist = float.Parse(array[8]);
			float lfeTme = float.Parse(array[9]);
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, pathID, 4.5f, 0f, findPos(pathID, 4.5f, 0f), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, pathID, 3f * (pathLength[pathID] / 4f), 0f - fTotalOffsetDeviation, findPos(pathID, 3f * (pathLength[pathID] / 4f), 0f - fTotalOffsetDeviation), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			text = IGT_FileReading.data[59];
			array = text.Split('~');
			objplceTyp = int.Parse(array[0]);
			obId = int.Parse(array[1]);
			typ = int.Parse(array[2]);
			obName = array[3];
			len = float.Parse(array[4]);
			wid = float.Parse(array[5]);
			hei = float.Parse(array[6]);
			hei2 = float.Parse(array[7]);
			mindist = float.Parse(array[8]);
			lfeTme = float.Parse(array[9]);
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 12, 0.1f, 0f, findPos(12, 0.1f, 0f), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 12, 0.1f, fTotalOffsetDeviation, findPos(12, 0.1f, fTotalOffsetDeviation), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 12, 0.1f, 0f - fTotalOffsetDeviation, findPos(12, 0.1f, 0f - fTotalOffsetDeviation), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 9, 0.1f, 0f, findPos(9, 0.1f, 0f), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 9, 0.1f, fTotalOffsetDeviation, findPos(9, 0.1f, fTotalOffsetDeviation), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 9, 0.1f, 0f - fTotalOffsetDeviation, findPos(9, 0.1f, 0f - fTotalOffsetDeviation), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 8, pathLength[8], 0f, findPos(8, pathLength[8], 0f), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 8, pathLength[8], fTotalOffsetDeviation, findPos(8, pathLength[8], fTotalOffsetDeviation), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 8, pathLength[8], 0f - fTotalOffsetDeviation, findPos(8, pathLength[8], 0f - fTotalOffsetDeviation), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			break;
		}
		case 13:
		{
			string text = IGT_FileReading.data[59];
			string[] array = text.Split('~');
			int objplceTyp = int.Parse(array[0]);
			int obId = int.Parse(array[1]);
			int typ = int.Parse(array[2]);
			string obName = array[3];
			float len = float.Parse(array[4]);
			float wid = float.Parse(array[5]);
			float hei = float.Parse(array[6]);
			float hei2 = float.Parse(array[7]);
			float mindist = float.Parse(array[8]);
			float lfeTme = float.Parse(array[9]);
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 22, 0.1f, 0f, findPos(22, 0.1f, 0f), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 22, 0.1f, fTotalOffsetDeviation, findPos(22, 0.1f, fTotalOffsetDeviation), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 22, 0.1f, 0f - fTotalOffsetDeviation, findPos(22, 0.1f, 0f - fTotalOffsetDeviation), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 6, 0.1f, 0f, findPos(6, 0.1f, 0f), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 6, 0.1f, fTotalOffsetDeviation, findPos(6, 0.1f, fTotalOffsetDeviation), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 6, 0.1f, 0f - fTotalOffsetDeviation, findPos(6, 0.1f, 0f - fTotalOffsetDeviation), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 1, pathLength[1], 0f, findPos(1, pathLength[1], 0f), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 1, pathLength[1], fTotalOffsetDeviation, findPos(1, pathLength[1], fTotalOffsetDeviation), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, 1, pathLength[1], 0f - fTotalOffsetDeviation, findPos(1, pathLength[1], 0f - fTotalOffsetDeviation), findRotation(posFrFndngRot, prevPosFrFndngRot), obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
			break;
		}
		}
		IGT_ObjPlacing.objPlaceAtRuntime(ref pObj.objFrDraw);
		pObj.nPathID = currentPathIndex;
		pObj.ObjListInCurPathOfHero = objDetInGivenPath(pathID);
		if (IGT_GameView.pHero.isAIplayerAvailable)
		{
			IGT_AIPlayer.ObjListInCurPathOfAIPlayer = objDetInGivenPath(IGT_AIPlayer.AI_PlayerObj.currentPathIndex);
		}
	}

	public void tutorial_ObjPlacing_AdjPath(int missionID, int curPid, bool travRev)
	{
		List<int> list = findAdjPathFrObjPlacing(curPid, travRev);
		switch (missionID)
		{
		case 1:
		case 2:
		{
			int num = ((missionID != 1) ? 54 : 57);
			string text = IGT_FileReading.data[num];
			string[] array = text.Split('~');
			int objplceTyp = int.Parse(array[0]);
			int obId = int.Parse(array[1]);
			int typ = int.Parse(array[2]);
			string obName = array[3];
			float len = float.Parse(array[4]);
			float wid = float.Parse(array[5]);
			float hei = float.Parse(array[6]);
			float hei2 = float.Parse(array[7]);
			float mindist = float.Parse(array[8]);
			float lfeTme = float.Parse(array[9]);
			float dist = 2f;
			float num2 = 0f;
			for (int i = 0; i < list.Count; i++)
			{
				int num3 = list[i];
				for (int j = 0; j < 3; j++)
				{
					switch (j)
					{
					case 0:
						dist = 1f * (pathLength[num3] / 4f);
						num2 = 0f;
						break;
					case 1:
						dist = 2f * (pathLength[num3] / 4f);
						num2 = 0f - fTotalOffsetDeviation;
						break;
					case 2:
						dist = 3f * (pathLength[num3] / 4f);
						num2 = fTotalOffsetDeviation;
						break;
					}
					Vector3 pos = findPos(num3, dist, num2);
					Vector3 rot = findRotation(posFrFndngRot, prevPosFrFndngRot);
					pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, num3, dist, num2, pos, rot, obId, typ, obName, len, wid, hei, hei2, false, Time.timeSinceLevelLoad, lfeTme, mindist, false));
				}
			}
			break;
		}
		}
		IGT_ObjPlacing.objDestruction();
		IGT_ObjPlacing.objPlaceAtRuntime(ref pObj.objFrDraw);
		pObj.nPathID = currentPathIndex;
		pObj.ObjListInCurPathOfHero = objDetInGivenPath(pObj.nPathID);
		if (IGT_GameView.pHero.isAIplayerAvailable)
		{
			IGT_AIPlayer.ObjListInCurPathOfAIPlayer = objDetInGivenPath(IGT_AIPlayer.AI_PlayerObj.currentPathIndex);
		}
	}

	public void removingTimeExceeded_SplPowersDatas()
	{
		for (int num = pObj.splPowersObj_PlacedDetails.Count - 1; num >= 0; num--)
		{
			if (!nAdjPIDs.Contains(pObj.splPowersObj_PlacedDetails[num].nPathId) && pObj.splPowersObj_PlacedDetails[num].nPathId != currentPathIndex)
			{
				pObj.splPowersObj_PlacedDetails.RemoveAt(num);
			}
		}
	}

	public void splPowersInfoSelection(List<int> PIDx)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		string text = "null";
		float num4 = 0f;
		float num5 = 0f;
		float num6 = 0f;
		float num7 = 0f;
		float num8 = 0f;
		int num9 = -1;
		float num10 = 0f;
		Vector3 zero = Vector3.zero;
		Vector3 zero2 = Vector3.zero;
		bool flag = false;
		bool flag2 = false;
		float num11 = 0f;
		float num12 = 0f;
		float num13 = 0f;
		bool flag3 = false;
		bool flag4 = false;
		float num14 = 0f;
		float num15 = 0f;
		float num16 = 0f;
		float num17 = 0f;
		float num18 = 0f;
		int num19 = -1;
		float num20 = 3f;
		bool flag5 = false;
		for (int i = 0; i < PIDx.Count; i++)
		{
			num9 = PIDx[i];
			flag5 = false;
			patternBased_TrapItems_Placement(num9, 20);
			for (int j = 0; j < pObj.splPowersObj_PlacedDetails.Count; j++)
			{
				if (pObj.splPowersObj_PlacedDetails[j].nPathId == num9)
				{
					flag5 = true;
					break;
				}
			}
			if (flag5)
			{
				continue;
			}
			float[] array = new float[3]
			{
				0f - fTotalOffsetDeviation,
				0f,
				fTotalOffsetDeviation
			};
			if (UnityEngine.Random.Range(0, 100) >= IGT_Constants.nSplPowers_PlacingProb)
			{
				continue;
			}
			num13 = 0f;
			objDetInCurPath(num9);
			num14 = (num15 = 4f);
			num16 = 0f;
			num17 = 0f;
			num18 = 0f;
			num19 = -1;
			flag3 = false;
			int num21 = 0;
			flag4 = false;
			while (!flag4 && num14 < pathLength[num9] - num20 && num21 < 100)
			{
				num8 = 2.5f;
				num5 = 0.4f;
				num19 = findNxtObjIdBasedDistinFrwdPath(num15);
				if (num19 == -1)
				{
					num16 = pathLength[num9] - 3.5f;
					num17 = 0f;
					num18 = 0f;
				}
				else
				{
					num16 = pObj.obj[num19].fDistFrmStrtPnt;
					num17 = pObj.obj[num19].fMinDstBwObj;
					num18 = pObj.obj[num19].fWidth;
					if (pObj.obj[num19].objType == 3 && pObj.obj[num19].bVehicleCrossedCurPath && pObj.obj[num19].bVehicleDestPathTravRev)
					{
						num16 = pathLength[pObj.obj[num19].nPathId] - num16;
					}
				}
				if (num15 + num8 < num16 - num18 / 2f - num17 / 2f)
				{
					num13 = num15 + num8;
					num15 = num13 + num5 / 2f;
					num14 = num13;
					flag3 = true;
				}
				else
				{
					num15 = num16 + num18 / 2f;
					num14 = num15;
					flag3 = false;
				}
				if (flag3 && num13 < pathLength[num9] - num20 && !isSelectedObjColllidedWithAlreadyPlacedPattern(num9, num13, num5, num8))
				{
					int num22 = specialPowerObjIndexSeletion(num9);
					string text2 = IGT_FileReading.data[num22];
					string[] array2 = text2.Split('~');
					num = int.Parse(array2[0]);
					num2 = int.Parse(array2[1]);
					num3 = int.Parse(array2[2]);
					text = array2[3];
					num4 = float.Parse(array2[4]);
					num5 = float.Parse(array2[5]);
					num6 = float.Parse(array2[6]);
					num7 = float.Parse(array2[7]);
					num8 = 0.5f + float.Parse(array2[8]);
					flag = false;
					flag2 = false;
					num11 = Time.timeSinceLevelLoad;
					num12 = float.Parse(array2[9]);
					if (num2 != 905 && num2 != 906)
					{
						if (num19 != -1 && (pObj.obj[num19].objType == 4 || pObj.obj[num19].objType == 6))
						{
							num10 = ((pObj.obj[num19].fOffset != fCenterOffset) ? (0f - pObj.obj[num19].fOffset) : array[0]);
						}
						int num23 = findNxtObjIdBasedDistinRevPath(num15);
						if (num23 != -1 && (pObj.obj[num23].objType == 4 || pObj.obj[num23].objType == 6))
						{
							num10 = ((pObj.obj[num23].fOffset != fCenterOffset) ? (0f - pObj.obj[num23].fOffset) : array[0]);
						}
					}
					else if (num2 == 905 || num2 == 906)
					{
						if (num19 != -1 && (pObj.obj[num19].objType == 4 || pObj.obj[num19].objType == 6))
						{
							num10 = pObj.obj[num19].fOffset;
						}
						int num24 = findNxtObjIdBasedDistinRevPath(num15);
						if (num24 != -1 && (pObj.obj[num24].objType == 4 || pObj.obj[num24].objType == 6))
						{
							num10 = pObj.obj[num24].fOffset;
						}
					}
					else
					{
						num10 = array[UnityEngine.Random.Range(0, array.Length)];
					}
					num10 = offset_Adjustment_fr_Splpowers(num10, num9, num13);
					zero = findPos(num9, num13, num10);
					zero2 = findRotation(posFrFndngRot, prevPosFrFndngRot);
					pObj.splPowersObj_PlacedDetails.Add(new IGT_ObjInfo(num, num9, num13, num10, zero, zero2, num2, num3, text, num4, num5, num6, num7, flag, num11, num12, num8, flag2));
					flag4 = true;
				}
				num21++;
			}
		}
	}

	public void splPowersInfoSelection_Chase(int givenPathId)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		string text = "null";
		float num4 = 0f;
		float num5 = 0f;
		float num6 = 0f;
		float num7 = 0f;
		float num8 = 0f;
		int num9 = -1;
		float num10 = 0f;
		Vector3 zero = Vector3.zero;
		Vector3 zero2 = Vector3.zero;
		bool flag = false;
		bool flag2 = false;
		float num11 = 0f;
		float num12 = 0f;
		float num13 = 0f;
		bool flag3 = false;
		bool flag4 = false;
		float num14 = 0f;
		float num15 = 0f;
		float num16 = 0f;
		float num17 = 0f;
		float num18 = 0f;
		int num19 = -1;
		float num20 = 3f;
		num9 = givenPathId;
		float[] array = new float[3]
		{
			0f - fTotalOffsetDeviation,
			0f,
			fTotalOffsetDeviation
		};
		num13 = 0f;
		objDetInCurPath(num9);
		num14 = (num15 = 4f);
		num16 = 0f;
		num17 = 0f;
		num18 = 0f;
		num19 = -1;
		flag3 = false;
		int num21 = 0;
		flag4 = false;
		int num22 = specialPowerObjIndexSeletion_Chase();
		if (num22 == -1)
		{
			return;
		}
		string text2 = IGT_FileReading.data[num22];
		string[] array2 = text2.Split('~');
		num = int.Parse(array2[0]);
		num2 = int.Parse(array2[1]);
		num3 = int.Parse(array2[2]);
		text = array2[3];
		num4 = float.Parse(array2[4]);
		num5 = float.Parse(array2[5]);
		num6 = float.Parse(array2[6]);
		num7 = float.Parse(array2[7]);
		num8 = 0.5f + float.Parse(array2[8]);
		flag = false;
		flag2 = false;
		num11 = Time.timeSinceLevelLoad;
		num12 = float.Parse(array2[9]);
		while (!flag4 && num14 < pathLength[num9] - num20 && num21 < 50)
		{
			num19 = findNxtObjIdBasedDistinFrwdPath(num15);
			if (num19 == -1)
			{
				num16 = pathLength[num9] - 3.5f;
				num17 = 0f;
				num18 = 0f;
			}
			else
			{
				num16 = pObj.obj[num19].fDistFrmStrtPnt;
				num17 = pObj.obj[num19].fMinDstBwObj;
				num18 = pObj.obj[num19].fWidth;
				if (pObj.obj[num19].objType == 3 && pObj.obj[num19].bVehicleCrossedCurPath && pObj.obj[num19].bVehicleDestPathTravRev)
				{
					num16 = pathLength[pObj.obj[num19].nPathId] - num16;
				}
			}
			if (num15 + num8 < num16 - num18 / 2f - num17 / 2f)
			{
				num13 = num15 + num8;
				num15 = num13 + num5 / 2f;
				num14 = num13;
				flag3 = true;
			}
			else
			{
				num15 = num16 + num18 / 2f;
				num14 = num15;
				flag3 = false;
			}
			if (flag3 && num13 < pathLength[num9] - num20 && !isSelectedObjColllidedWithAlreadyPlacedPattern(num9, num13, num5, num8))
			{
				if (num2 != 905 && num2 != 906)
				{
					if (num19 != -1 && (pObj.obj[num19].objType == 4 || pObj.obj[num19].objType == 6))
					{
						num10 = ((pObj.obj[num19].fOffset != fCenterOffset) ? (0f - pObj.obj[num19].fOffset) : array[0]);
					}
					int num23 = findNxtObjIdBasedDistinRevPath(num15);
					if (num23 != -1 && (pObj.obj[num23].objType == 4 || pObj.obj[num23].objType == 6))
					{
						num10 = ((pObj.obj[num23].fOffset != fCenterOffset) ? (0f - pObj.obj[num23].fOffset) : array[0]);
					}
				}
				else if (num2 == 905 || num2 == 906)
				{
					if (num19 != -1 && (pObj.obj[num19].objType == 4 || pObj.obj[num19].objType == 6))
					{
						num10 = pObj.obj[num19].fOffset;
					}
					int num24 = findNxtObjIdBasedDistinRevPath(num15);
					if (num24 != -1 && (pObj.obj[num24].objType == 4 || pObj.obj[num24].objType == 6))
					{
						num10 = pObj.obj[num24].fOffset;
					}
				}
				else
				{
					num10 = array[UnityEngine.Random.Range(0, array.Length)];
				}
				num10 = offset_Adjustment_fr_Splpowers(num10, num9, num13);
				zero = findPos(num9, num13, num10);
				zero2 = findRotation(posFrFndngRot, prevPosFrFndngRot);
				pObj.splPowersObj_PlacedDetails.Add(new IGT_ObjInfo(num, num9, num13, num10, zero, zero2, num2, num3, text, num4, num5, num6, num7, flag, num11, num12, num8, flag2));
				flag4 = true;
				IGT_ObjPlacing.splPowersobjDestruction();
				IGT_ObjPlacing.splPowersPlacing(ref pObj.splPowersObj_PlacedDetails);
				switch (num22)
				{
				case 67:
					IGT_Constants.splPowers_Chase_placedObj[0, 0] = 1f;
					IGT_Constants.splPowers_Chase_placedObj[0, 1] = Time.time;
					break;
				case 70:
				case 71:
					IGT_Constants.splPowers_Chase_placedObj[1, 0] = 1f;
					IGT_Constants.splPowers_Chase_placedObj[1, 1] = Time.time;
					if (IGT_Constants.Interval_Coin == 60f)
					{
						IGT_Constants.Interval_Coin = 120f;
					}
					break;
				case 74:
					IGT_Constants.splPowers_Chase_placedObj[2, 0] = 1f;
					IGT_Constants.splPowers_Chase_placedObj[2, 1] = Time.time;
					break;
				}
				IGT_Constants.splPowers_Chase_LastPlacedTime = Time.time;
			}
			num21++;
		}
	}

	public float offset_Adjustment_fr_Splpowers(float oldOffset, int curPid, float distFrmStrt)
	{
		float result = oldOffset;
		int count = pObj.pCoinDatas.Count;
		for (int i = 0; i < count; i++)
		{
			if (pObj.pCoinDatas.ElementAt(i).nPathId != curPid)
			{
				continue;
			}
			float num = pObj.pCoinDatas.ElementAt(i).fDistFrmStrtPnt;
			if (distFrmStrt > num - 1f && distFrmStrt < num + 1f)
			{
				if (pObj.pCoinDatas.ElementAt(i).fOffset == 0f && oldOffset == 0f)
				{
					result = 0f - fTotalOffsetDeviation;
				}
				else if ((pObj.pCoinDatas.ElementAt(i).fOffset < 0f && oldOffset < 0f) || (pObj.pCoinDatas.ElementAt(i).fOffset > 0f && oldOffset > 0f))
				{
					result = 0f - oldOffset;
				}
				break;
			}
		}
		for (int j = 0; j < pObj.missionObj_PlacedDetails.Count; j++)
		{
			if (pObj.missionObj_PlacedDetails.ElementAt(j).nPathId != curPid)
			{
				continue;
			}
			float num2 = pObj.missionObj_PlacedDetails.ElementAt(j).fDistFrmStrtPnt;
			if (distFrmStrt > num2 - 1f && distFrmStrt < num2 + 1f)
			{
				if (pObj.missionObj_PlacedDetails.ElementAt(j).fOffset == 0f && oldOffset == 0f)
				{
					result = 0f - fTotalOffsetDeviation;
				}
				else if ((pObj.missionObj_PlacedDetails.ElementAt(j).fOffset < 0f && oldOffset < 0f) || (pObj.missionObj_PlacedDetails.ElementAt(j).fOffset > 0f && oldOffset > 0f))
				{
					result = 0f - oldOffset;
				}
				break;
			}
		}
		return result;
	}

	public void removingTimeExceeded_missionItemDatas()
	{
		for (int num = pObj.missionObj_PlacedDetails.Count - 1; num >= 0; num--)
		{
			if (!nAdjPIDs.Contains(pObj.missionObj_PlacedDetails[num].nPathId) && pObj.missionObj_PlacedDetails[num].nPathId != currentPathIndex)
			{
				pObj.missionObj_PlacedDetails.RemoveAt(num);
			}
		}
	}

	public void collectionItemPlacementDataSel_Dynamic(List<int> PIDx)
	{
		int objplceTyp = 1;
		int obId = 1;
		int typ = -1;
		string obName = "null";
		float len = 0.25f;
		float num = 0.25f;
		float hei = 0.35f;
		float hei2 = 0.25f;
		int num2 = -1;
		float num3 = 0f;
		Vector3 zero = Vector3.zero;
		Vector3 zero2 = Vector3.zero;
		bool plyrcrsd = false;
		bool disabled = false;
		float deltaTime = Time.deltaTime;
		float lfeTme = 10f;
		float num4 = 0f;
		bool flag = false;
		float num5 = 0f;
		float num6 = 0f;
		float num7 = 0f;
		float num8 = 0f;
		int num9 = -1;
		float[] array = new float[3]
		{
			0f - fTotalOffsetDeviation,
			0f,
			fTotalOffsetDeviation
		};
		int num10 = 0;
		float fMinDistBtwCollectionItems = IGT_Constants.fMinDistBtwCollectionItems;
		float num11 = 3f;
		for (int i = 0; i < PIDx.Count; i++)
		{
			num2 = PIDx[i];
			num4 = 0f;
			objDetInCurPath(num2);
			num5 = (num6 = 4f + UnityEngine.Random.Range(2f, 4f));
			num7 = 0f;
			num8 = 0f;
			num9 = -1;
			flag = false;
			int num12 = 0;
			while (num5 < pathLength[num2] - num11 && num12 < 200)
			{
				num9 = findNxtObjIdBasedDistinFrwdPath(num6);
				if (num9 == -1)
				{
					num7 = pathLength[num2] - num11;
					num8 = 0f;
				}
				else
				{
					num7 = pObj.obj[num9].fDistFrmStrtPnt;
					num8 = pObj.obj[num9].fWidth;
					if (pObj.obj[num9].objType == 3 && pObj.obj[num9].bVehicleCrossedCurPath && pObj.obj[num9].bVehicleDestPathTravRev)
					{
						num7 = pathLength[pObj.obj[num9].nPathId] - num7;
					}
				}
				float num13 = UnityEngine.Random.Range(IGT_Constants.fRandValFrObjPlacing * 0.1f, IGT_Constants.fRandValFrObjPlacing * 0.3f);
				if (num6 + fMinDistBtwCollectionItems + num13 < num7 - num8 / 2f - 0.5f)
				{
					num4 = num6 + fMinDistBtwCollectionItems + num13;
					num6 = num4 + num / 2f;
					num5 = num4;
					flag = true;
				}
				else
				{
					num6 = num7 + num8 / 2f;
					num5 = num6;
					flag = false;
				}
				if (flag && num4 < pathLength[num2] - num11 && UnityEngine.Random.Range(0, 100) < IGT_Constants.nCollItemPlacingProb)
				{
					num3 = array[num10];
					zero = findPos(num2, num4, num3);
					zero2 = findRotation(posFrFndngRot, prevPosFrFndngRot);
					pObj.missionObj_PlacedDetails.Add(new IGT_ObjInfo(objplceTyp, num2, num4, num3, zero, zero2, obId, typ, obName, len, num, hei, hei2, plyrcrsd, deltaTime, lfeTme, fMinDistBtwCollectionItems, disabled));
				}
				num12++;
				num10++;
				if (num10 > 2)
				{
					num10 = 0;
				}
			}
		}
	}

	private void CollectionObjPlacementInObjstacles(List<int> PIDx)
	{
		int objplceTyp = 1;
		int obId = 1;
		int typ = -1;
		string obName = "null";
		float len = 0.25f;
		float num = 0.25f;
		float hei = 0.3f;
		float hei2 = 0.25f;
		int num2 = -1;
		float num3 = 0f;
		Vector3 zero = Vector3.zero;
		Vector3 zero2 = Vector3.zero;
		bool plyrcrsd = false;
		bool disabled = false;
		float deltaTime = Time.deltaTime;
		float lfeTme = 2f;
		float num4 = 0f;
		bool flag = false;
		float num5 = 0f;
		float num6 = 0f;
		float num7 = 0f;
		float num8 = 0f;
		float num9 = 0f;
		int num10 = -1;
		float num11 = 0f;
		int num12 = -1;
		float[] array = new float[3]
		{
			0f - fTotalOffsetDeviation,
			0f,
			fTotalOffsetDeviation
		};
		int num13 = 0;
		float num14 = IGT_Constants.fMinDistBtwCollectionItems;
		float num15 = 3f;
		int num16 = IGT_Constants.nCollItemPlacingProb;
		bool flag2 = false;
		for (int i = 0; i < PIDx.Count; i++)
		{
			num2 = PIDx[i];
			num4 = 0f;
			patternBased_TrapItems_Placement(num2, 10);
			if (collItemPlacdTimeInPath[num2] != 0f && Time.time - collItemPlacdTimeInPath[num2] < 30f)
			{
				continue;
			}
			collItemPlacdTimeInPath[num2] = Time.time;
			objDetInCurPath(num2);
			num5 = (num6 = 4f);
			num7 = 0f;
			num8 = 0f;
			num9 = 0f;
			num10 = -1;
			flag2 = false;
			int num17 = 0;
			while (num5 < pathLength[num2] - num15 && num17 < 200)
			{
				if (IGT_GameView.pHero.pMissionData.nMissionType == 0)
				{
					obId = IGT_GameView.pHero.pMissionData.nCollectionInnerItemType;
					num14 = IGT_Constants.fMinDistBtwCollectionItems;
					num16 = IGT_Constants.nCollItemPlacingProb;
				}
				else if (IGT_GameView.pHero.pMissionData.nMissionType == 5)
				{
					int num18 = 0;
					int num19 = UnityEngine.Random.Range(0, 100);
					for (int j = 0; j < IGT_GameView.pHero.pMissionData.nNumOfMultipleCollection; j++)
					{
						num18 += IGT_GameView.pHero.pMissionData.nMultipleCollectionDatas[j, 1];
						if (num18 >= num19)
						{
							obId = IGT_GameView.pHero.pMissionData.nMultipleCollectionDatas[j, 0];
							num14 = IGT_GameView.pHero.pMissionData.nMultipleCollectionDatas[j, 3];
							num16 = IGT_GameView.pHero.pMissionData.nMultipleCollectionDatas[j, 4];
							break;
						}
					}
				}
				flag = false;
				num10 = findNxtObjIdBasedDistinFrwdPath(num6);
				if (num10 == -1)
				{
					num7 = pathLength[num2] - num15;
					num8 = 0f;
					num9 = 0f;
					num11 = 0f;
					num12 = -1;
				}
				else
				{
					num7 = pObj.obj[num10].fDistFrmStrtPnt;
					num8 = pObj.obj[num10].fMinDstBwObj;
					num9 = pObj.obj[num10].fWidth;
					num11 = pObj.obj[num10].fOffset;
					num12 = pObj.obj[num10].objType;
					if (pObj.obj[num10].objType == 3 && pObj.obj[num10].bVehicleCrossedCurPath && pObj.obj[num10].bVehicleDestPathTravRev)
					{
						num7 = pathLength[pObj.obj[num10].nPathId] - num7;
					}
				}
				float num20 = UnityEngine.Random.Range(IGT_Constants.fRandValFrObjPlacing * 0.1f, IGT_Constants.fRandValFrObjPlacing * 0.3f);
				if (!flag2 && UnityEngine.Random.Range(0, 100) < num16 && num7 - num9 / 2f - num5 > 6f && UnityEngine.Random.Range(0, 100) < 10)
				{
					flag2 = true;
					num4 = num6 + num14 * 1.5f;
					num5 = (num6 = num4 + num / 2f);
					num3 = offset_Adjustment_fr_Splpowers(array[UnityEngine.Random.Range(0, 3)], num2, num4);
					int num21 = UnityEngine.Random.Range(2, 4);
					for (int k = 0; k < num21; k++)
					{
						hei = 0.3f;
						zero = findPos(num2, num4, num3);
						zero2 = findRotation(posFrFndngRot, prevPosFrFndngRot);
						pObj.missionObj_PlacedDetails.Add(new IGT_ObjInfo(objplceTyp, num2, num4, num3, zero, zero2, obId, typ, obName, len, num, hei, hei2, plyrcrsd, deltaTime, lfeTme, num14, disabled));
						num4 = num6 + 1.5f;
						num5 = (num6 = num4 + num + 2f);
						if (num5 > pathLength[num2] - num15)
						{
							break;
						}
					}
					continue;
				}
				if (UnityEngine.Random.Range(0, 100) < 20 && UnityEngine.Random.Range(0, 100) < num16 && (num12 == 0 || num12 == 1) && num7 - num6 < num + num14 + num8 + num9 / 2f)
				{
					num4 = num7;
					num5 = (num6 = num4 + num14 + num + num20);
					flag = true;
					switch (num12)
					{
					case 0:
						hei = 0.75f;
						break;
					case 1:
						hei = 0f;
						break;
					}
					num3 = num11;
					num3 = ((num3 < -0.2f) ? array[0] : ((!(num3 > 0.2f)) ? array[1] : array[2]));
				}
				if (!flag)
				{
					if (num6 + num14 + num20 < num7 - num9 / 2f - num8 / 2f)
					{
						num4 = num6 + num14 + num20;
						num5 = (num6 = num4 + num / 2f);
						flag = true;
						hei = 0.3f;
						num3 = array[num13];
					}
					else
					{
						num6 = num7 + num9 / 2f;
						num5 = num6;
						flag = false;
					}
				}
				if (flag && num4 < pathLength[num2] - num15 && UnityEngine.Random.Range(0, 100) < num16)
				{
					num3 = offset_Adjustment_fr_Splpowers(num3, num2, num4);
					zero = findPos(num2, num4, num3);
					zero2 = findRotation(posFrFndngRot, prevPosFrFndngRot);
					pObj.missionObj_PlacedDetails.Add(new IGT_ObjInfo(objplceTyp, num2, num4, num3, zero, zero2, obId, typ, obName, len, num, hei, hei2, plyrcrsd, deltaTime, lfeTme, num14, disabled));
				}
				num17++;
				num13++;
				if (num13 > 2)
				{
					num13 = 0;
				}
			}
		}
	}

	public Vector3 bringBackHere_DataSel(int curPathID)
	{
		int objplceTyp = 1;
		int obId = -1;
		int typ = -1;
		string obName = "null";
		float len = 0.5f;
		float num = 0.25f;
		float hei = 0.35f;
		float hei2 = 0.25f;
		int num2 = -1;
		float num3 = 0f;
		Vector3 vector = Vector3.zero;
		Vector3 zero = Vector3.zero;
		bool plyrcrsd = false;
		bool disabled = false;
		float deltaTime = Time.deltaTime;
		float lfeTme = 10f;
		float num4 = 0f;
		bool flag = false;
		float num5 = 0f;
		float num6 = 0f;
		float num7 = 0f;
		float num8 = 0f;
		int num9 = -1;
		float[] array = new float[3]
		{
			0f - fTotalOffsetDeviation,
			0f,
			fTotalOffsetDeviation
		};
		float fMinDistBtwCollectionItems = IGT_Constants.fMinDistBtwCollectionItems;
		float num10 = 3f;
		int num11 = 0;
		while (!flag && num11 < 200)
		{
			num2 = UnityEngine.Random.Range(0, WaypointManager.Paths.Count);
			while (num2 == 28 || num2 == curPathID)
			{
				num2 = UnityEngine.Random.Range(0, WaypointManager.Paths.Count);
			}
			num4 = 0f;
			objDetInCurPath(num2);
			num5 = 5f + UnityEngine.Random.Range(2f, 4f);
			num9 = findNxtObjIdBasedDistinFrwdPath(num5);
			if (num9 == -1)
			{
				num6 = pathLength[num2] - num10;
				num7 = 0f;
				num8 = 0f;
			}
			else
			{
				num6 = pObj.obj[num9].fDistFrmStrtPnt;
				num7 = pObj.obj[num9].fMinDstBwObj;
				num8 = pObj.obj[num9].fWidth;
				if (pObj.obj[num9].objType == 3 && pObj.obj[num9].bVehicleCrossedCurPath && pObj.obj[num9].bVehicleDestPathTravRev)
				{
					num6 = pathLength[pObj.obj[num9].nPathId] - num6;
				}
			}
			float num12 = UnityEngine.Random.Range(IGT_Constants.fRandValFrObjPlacing * 0.1f, IGT_Constants.fRandValFrObjPlacing * 0.3f);
			if (num5 + fMinDistBtwCollectionItems + num12 < num6 - num8 / 2f - num7 / 2f)
			{
				num4 = num5 + fMinDistBtwCollectionItems + num12;
				num5 = num4 + num / 2f;
				flag = true;
				hei = 0.35f;
				num3 = array[UnityEngine.Random.Range(0, array.Length)];
			}
			else
			{
				num5 = num6 + num8 / 2f;
				flag = false;
			}
			if (flag && num4 < pathLength[num2] - num10)
			{
				vector = findPos(num2, num4, num3);
				zero = findRotation(posFrFndngRot, prevPosFrFndngRot);
				pObj.missionObj_PlacedDetails.Add(new IGT_ObjInfo(objplceTyp, num2, num4, num3, vector, zero, obId, typ, obName, len, num, hei, hei2, plyrcrsd, deltaTime, lfeTme, fMinDistBtwCollectionItems, disabled));
			}
			num11++;
		}
		return vector;
	}

	public Vector3 findPos_Based_GivenDist(int strtPID, int strtPointID, float dist, bool travRev)
	{
		float num = 0f;
		float num2 = 0f;
		bool flag = false;
		int[] array = new int[6];
		Vector3 result = Vector3.zero;
		num2 = objDistFrmStrtPoint(strtPID, strtPointID, new Vector3(pointPos[strtPID, strtPointID, 0], pointPos[strtPID, strtPointID, 1], pointPos[strtPID, strtPointID, 2]));
		if (!travRev)
		{
			num2 = pathLength[strtPID] - num2;
		}
		num = num2;
		int num3 = 0;
		while (!flag && num3 < 500)
		{
			array = findPathBasedInput(strtPID, travRev, UnityEngine.Random.Range(0, 3));
			if (array[0] != -1)
			{
				strtPID = array[0];
				strtPointID = array[1];
				travRev = ((strtPointID != 0) ? true : false);
				num2 = pathLength[strtPID];
				if (num + num2 > dist)
				{
					flag = true;
					float num4 = dist - num;
					if (travRev)
					{
						num4 = pathLength[strtPID] - num4;
					}
					result = findPos(strtPID, num4, 0f);
				}
				else
				{
					num += num2;
				}
			}
			num3++;
		}
		return result;
	}

	public Vector3 findPos_Based_AbsoluteDist(int strtPID, int strtPointID, bool travRev, float absDist)
	{
		bool flag = false;
		Vector3 zero = Vector3.zero;
		Vector3 a = new Vector3(pointPos[strtPID, strtPointID, 0], pointPos[strtPID, strtPointID, 1], pointPos[strtPID, strtPointID, 2]);
		float num = 0f;
		float num2 = 0f;
		int num3 = -1;
		List<int> list = new List<int>();
		for (int i = 0; i < WaypointManager.Paths.Count; i++)
		{
			if (i != strtPID && i != 28)
			{
				list.Add(i);
			}
		}
		list.Shuffle();
		for (int j = 0; j < list.Count; j++)
		{
			num3 = list[j];
			num = UnityEngine.Random.Range(1f, 3f);
			int num4 = 0;
			while (!flag && num < pathLength[num3] - 2.5f && num4 < 50)
			{
				zero = findPos(num3, num, num2);
				float num5 = Vector3.Distance(a, zero);
				if (num5 >= absDist - absDist * 0.2f && num5 <= absDist + absDist * 0.5f)
				{
					flag = true;
					pObj.missionObj_PlacedDetails.Add(new IGT_ObjInfo(1, num3, num, num2, zero, findRotation(posFrFndngRot, prevPosFrFndngRot), -1, -1, "null", 0.25f, 0.25f, 0.35f, 0.35f, false, Time.time, 10f, IGT_Constants.fMinDistBtwCollectionItems, false));
					return zero;
				}
				num += UnityEngine.Random.Range(1f, 3f);
				num4++;
			}
		}
		return Vector3.zero;
	}

	public float findShortestDistToBringBackTarget(Vector3 heroCurPos, int heroCurPathID, bool isRev)
	{
		return Vector3.Distance(heroCurPos, pObj.missionObj_PlacedDetails[0].ObjPos);
	}

	public void collectionItemPlacementDataSel_Static(IGT_Missions pIgtMission)
	{
		pObj.missionObj_PlacedDetails.Clear();
		int objplceTyp = 1;
		int obId = 1;
		int typ = -1;
		string obName = "null";
		float len = 0.25f;
		float wid = 0.25f;
		float hei = 0.35f;
		float hei2 = 0.25f;
		float num = 5f;
		int num2 = -1;
		float num3 = 0f;
		Vector3 zero = Vector3.zero;
		Vector3 zero2 = Vector3.zero;
		bool plyrcrsd = false;
		bool disabled = false;
		float deltaTime = Time.deltaTime;
		float lfeTme = 10f;
		float num4 = 0f;
		float num5 = 0f;
		int num6 = 0;
		int num7 = 0;
		while (num7 < pIgtMission.nTargetCount && num6 < 2000)
		{
			num2 = UnityEngine.Random.Range(0, WaypointManager.Paths.Count);
			objDetInCurPath(num2);
			if (num2 == 28)
			{
				num6++;
				continue;
			}
			num4 = 0f;
			if (pObj.nTotObjinCurPath == 0)
			{
				num5 = 2f + UnityEngine.Random.Range(1f, 2f);
			}
			else if (pObj.nTotObjinCurPath == 1)
			{
				num5 = pObj.obj[0].fDistFrmStrtPnt + pObj.obj[0].fWidth + UnityEngine.Random.Range(0.5f, 1.25f);
			}
			else
			{
				if (pObj.nTotObjinCurPath != 2)
				{
					num6++;
					continue;
				}
				num5 = pObj.obj[1].fDistFrmStrtPnt + pObj.obj[1].fWidth;
			}
			num4 = num5 + num + UnityEngine.Random.Range(IGT_Constants.fRandValFrObjPlacing * 0.5f, IGT_Constants.fRandValFrObjPlacing);
			if (num4 < pathLength[num2] - 2.5f)
			{
				float[] array = new float[3]
				{
					0f - fTotalOffsetDeviation,
					0f,
					fTotalOffsetDeviation
				};
				num3 = array[UnityEngine.Random.Range(0, array.Length)];
				zero = findPos(num2, num4, num3);
				zero2 = findRotation(posFrFndngRot, prevPosFrFndngRot);
				pObj.missionObj_PlacedDetails.Add(new IGT_ObjInfo(objplceTyp, num2, num4, num3, zero, zero2, obId, typ, obName, len, wid, hei, hei2, plyrcrsd, deltaTime, lfeTme, num, disabled));
				num7++;
			}
			num6++;
		}
	}

	private int findLetterIdx(string givenWord, bool isSelectOriginalChar)
	{
		int num = -1;
		if (!isSelectOriginalChar && Time.time - IGT_Constants.fWF_OriginalCharPlacedTime > 20f)
		{
			IGT_Constants.fWF_OriginalCharPlacedTime = Time.time;
			int num2 = 0;
			bool flag = false;
			while (num == -1 && num2 < 50)
			{
				num = getIndexBasedonGivenValueinArray(ref IGT_ObjPlacing.Alphabetics, givenWord.ElementAt(UnityEngine.Random.Range(0, givenWord.Length)));
				for (int i = 0; i < IGT_GameView.pHero.pCharArray.Length; i++)
				{
					if (IGT_GameView.pHero.pCharArray[i].character == (ushort)IGT_ObjPlacing.Alphabetics[num] && !IGT_GameView.pHero.pCharArray[i].isEnable)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					num = -1;
				}
				num2++;
			}
		}
		else
		{
			int num3 = UnityEngine.Random.Range(0, 100);
			if (!isSelectOriginalChar && num3 < IGT_GameView.pHero.pMissionData.nWF_OringinalCharPlacingProb)
			{
				int num4 = 0;
				bool flag2 = false;
				while (num == -1 && num4 < 50)
				{
					num = getIndexBasedonGivenValueinArray(ref IGT_ObjPlacing.Alphabetics, givenWord.ElementAt(UnityEngine.Random.Range(0, givenWord.Length)));
					for (int j = 0; j < IGT_GameView.pHero.pCharArray.Length; j++)
					{
						if (IGT_GameView.pHero.pCharArray[j].character == (ushort)IGT_ObjPlacing.Alphabetics[num] && !IGT_GameView.pHero.pCharArray[j].isEnable)
						{
							flag2 = true;
							break;
						}
					}
					if (!flag2)
					{
						num = -1;
					}
					num4++;
				}
			}
			else
			{
				num3 = UnityEngine.Random.Range(0, 100);
				if (num3 < 20)
				{
					int num5 = 0;
					while (num == -1 && num5 < 10)
					{
						int num6 = UnityEngine.Random.Range(0, IGT_GameView.pHero.pCharArray.Length);
						if (IGT_GameView.pHero.pCharArray[num6].isEnable)
						{
							num = getIndexBasedonGivenValueinArray(ref IGT_ObjPlacing.Alphabetics, IGT_GameView.pHero.pCharArray[num6].character);
						}
						num5++;
					}
				}
				int num7 = 0;
				while (num == -1 && num7 < 50)
				{
					num = UnityEngine.Random.Range(0, IGT_ObjPlacing.Alphabetics.Length);
					if (givenWord.Contains((char)IGT_ObjPlacing.Alphabetics[num]))
					{
						num = -1;
					}
					num7++;
				}
			}
		}
		if (num == -1)
		{
			num = UnityEngine.Random.Range(0, IGT_ObjPlacing.Alphabetics.Length);
		}
		return num;
	}

	private void WF_CharPlacementSel(List<int> PIDx, int originalcharProb, int charPer20m)
	{
		int num = charPer20m;
		string wordTobeFind = IGT_GameView.pHero.pMissionData.WordTobeFind;
		float hei = 0.35f;
		float hei2 = 0.35f;
		float num2 = 1f;
		float len = 0.25f;
		Vector3 zero = Vector3.zero;
		Vector3 zero2 = Vector3.zero;
		float num3 = 0f;
		float num4 = 1f;
		bool flag = false;
		for (int i = 0; i < PIDx.Count; i++)
		{
			int num5 = 0;
			int num6 = PIDx[i];
			num = (int)((float)charPer20m * pathLength[num6] / 20f);
			if (collItemPlacdTimeInPath[num6] != 0f && Time.time - collItemPlacdTimeInPath[num6] < 20f)
			{
				continue;
			}
			collItemPlacdTimeInPath[num6] = Time.time;
			float num7 = 0f;
			Vector3 zero3 = Vector3.zero;
			float[] array = new float[3]
			{
				0f - fTotalOffsetDeviation,
				0f,
				fTotalOffsetDeviation
			};
			float num8 = 4f;
			float num9 = 4f;
			float num10 = 3f;
			float num11 = 5f;
			float num12 = 0f;
			float num13 = 0f;
			float num14 = 0f;
			int num15 = -1;
			float num16 = 0f;
			int num17 = -1;
			bool flag2 = false;
			int num18 = 0;
			objDetInCurPath(num6);
			flag = false;
			int num19 = 0;
			while (num5 < num && num8 < pathLength[num6] - num10 && num19 < 50)
			{
				flag2 = false;
				num15 = findNxtObjIdBasedDistinFrwdPath(num9);
				if (num15 == -1)
				{
					num12 = pathLength[num6] - num10;
					num13 = 0.5f;
					num14 = 0f;
					num16 = 0f;
					num17 = -1;
				}
				else
				{
					num12 = pObj.obj[num15].fDistFrmStrtPnt;
					num13 = pObj.obj[num15].fMinDstBwObj;
					num14 = pObj.obj[num15].fWidth;
					num16 = pObj.obj[num15].fOffset;
					num17 = pObj.obj[num15].objType;
					if (pObj.obj[num15].objType == 3 && pObj.obj[num15].bVehicleCrossedCurPath && pObj.obj[num15].bVehicleDestPathTravRev)
					{
						num12 = pathLength[pObj.obj[num15].nPathId] - num12;
					}
				}
				float num20 = UnityEngine.Random.Range(IGT_Constants.fRandValFrObjPlacing * 0.1f, IGT_Constants.fRandValFrObjPlacing * 0.3f);
				if (UnityEngine.Random.Range(0, 100) < 20 && (num17 == 0 || num17 == 1) && num12 - num9 < num2 + num4 + num13 + num14 / 2f)
				{
					num3 = num12;
					num8 = (num9 = num3 + num4 + num13 + num2 + num20 + num11);
					flag2 = true;
					switch (num17)
					{
					case 0:
						hei = 0.75f;
						break;
					case 1:
						hei = 0f;
						break;
					}
					num7 = num16;
					num7 = ((num7 < -0.2f) ? array[0] : ((!(num7 > 0.2f)) ? array[1] : array[2]));
				}
				if (!flag2)
				{
					if (num9 + num4 + num20 < num12 - num14 / 2f - num13 / 2f)
					{
						num3 = num9;
						num8 = (num9 = num3 + num2 + num4 + num20 + num13 + num11);
						flag2 = true;
						hei = 0.3f;
						num7 = array[num18];
						int num21 = findNxtObjIdBasedDistinRevPath(num3);
						if (num21 != -1 && num3 < pObj.obj[num21].fDistFrmStrtPnt + 1f && num3 > pObj.obj[num21].fDistFrmStrtPnt - 1f)
						{
							flag2 = false;
						}
					}
					else
					{
						num9 = num12 + num14 / 2f;
						num8 = num9;
						flag2 = false;
					}
				}
				if (flag2 && num3 < pathLength[num6] - num10 && UnityEngine.Random.Range(0, 100) < 100)
				{
					num7 = offset_Adjustment_fr_Splpowers(num7, num6, num3);
					zero = findPos(num6, num3, num7);
					int num22 = findLetterIdx(wordTobeFind, flag);
					if (wordTobeFind.Contains((char)IGT_ObjPlacing.Alphabetics[num22]))
					{
						flag = true;
					}
					pObj.missionObj_PlacedDetails.Add(new IGT_ObjInfo(1, num6, num3, num7, zero, findRotation(posFrFndngRot, prevPosFrFndngRot), num22, -1, "null", len, num2, hei, hei2, false, Time.time, 10f, 4f, false));
					num5++;
				}
				num19++;
				num18++;
				if (num18 > 2)
				{
					num18 = 0;
				}
			}
		}
		IGT_ObjPlacing.wordPlacing(ref pObj.missionObj_PlacedDetails);
	}

	private int noOfMaxCharCalc(int wordLength)
	{
		int num = wordLength * 2;
		num = ((wordLength >= 2 && wordLength <= 4) ? (wordLength * 4) : ((wordLength != 5 && wordLength != 6) ? (wordLength * 2) : (wordLength * 3)));
		if (num > 20)
		{
			num = 20;
		}
		return num;
	}

	public void wordPlacement(int strtPid, int strtPoint, string word, float absDist, float noOfTimesLettersinWordCanPlaced)
	{
		bool flag = ((strtPoint >= pointCount[strtPid] / 2) ? true : false);
		Vector3 a = new Vector3(pointPos[strtPid, strtPoint, 0], pointPos[strtPid, strtPoint, 1], pointPos[strtPid, strtPoint, 2]);
		bool flag2 = true;
		int num = 25;
		int num2 = (int)Mathf.Ceil((float)word.Length * noOfTimesLettersinWordCanPlaced);
		if (num2 > num)
		{
			num2 = num;
		}
		char[] array = word.ToCharArray();
		char[] array2 = new char[num2];
		for (int i = 0; i < num2; i++)
		{
			if (i < array.Length)
			{
				array2[i] = array[i];
			}
			else
			{
				array2[i] = array[UnityEngine.Random.Range(0, array.Length)];
			}
		}
		int num3 = -1;
		float num4 = 0f;
		bool flag3 = false;
		Vector3 zero = Vector3.zero;
		float[] array3 = new float[3]
		{
			0f - fTotalOffsetDeviation,
			0f,
			fTotalOffsetDeviation
		};
		float num5 = 0f;
		int num6 = 0;
		List<int> list = new List<int>();
		for (int j = 0; j < WaypointManager.Paths.Count; j++)
		{
			if (j != strtPid && j != 28)
			{
				list.Add(j);
			}
		}
		list.Shuffle();
		for (int k = 0; k < list.Count; k++)
		{
			if (num6 >= num2)
			{
				break;
			}
			num3 = list[k];
			num4 = UnityEngine.Random.Range(1f, 3f);
			int num7 = 0;
			flag3 = false;
			num5 = array3[UnityEngine.Random.Range(0, array3.Length)];
			while (!flag3 && num4 < pathLength[num3] - 2.5f && num7 < 50)
			{
				zero = findPos(num3, num4, num5);
				float num8 = Vector3.Distance(a, zero);
				if (num8 >= absDist - absDist * 0.25f && num8 <= absDist + absDist * 0.5f && !isGivenPathAlreadyInMissionObjPlacdDetatils(num3))
				{
					flag3 = true;
					int indexBasedonGivenValueinArray = getIndexBasedonGivenValueinArray(ref IGT_ObjPlacing.Alphabetics, array2[num6]);
					pObj.missionObj_PlacedDetails.Add(new IGT_ObjInfo(1, num3, num4, num5, zero, findRotation(posFrFndngRot, prevPosFrFndngRot), indexBasedonGivenValueinArray, -1, "null", 0.25f, 0.25f, 0.35f, 0.35f, false, Time.time, 10f, 4f, false));
					num6++;
				}
				else
				{
					num4 += UnityEngine.Random.Range(1f, 3f);
				}
				num7++;
			}
		}
		if (num6 < num2)
		{
			list.Shuffle();
			for (int l = 0; l < list.Count; l++)
			{
				if (num6 >= num2)
				{
					break;
				}
				num3 = list[l];
				num4 = UnityEngine.Random.Range(2f, 4f);
				int num9 = 0;
				flag3 = false;
				num5 = array3[UnityEngine.Random.Range(0, array3.Length)];
				while (!flag3 && num4 < pathLength[num3] - 2.5f && num9 < 50)
				{
					zero = findPos(num3, num4, num5);
					float num10 = Vector3.Distance(a, zero);
					if (num10 >= absDist - absDist * 0.75f && num10 <= absDist + absDist * 0.5f && !isGivenDistCollideWithAlreadyPlacedObjInMissionObjPlacdDetatils(num3, num4))
					{
						flag3 = true;
						int indexBasedonGivenValueinArray2 = getIndexBasedonGivenValueinArray(ref IGT_ObjPlacing.Alphabetics, array2[num6]);
						pObj.missionObj_PlacedDetails.Add(new IGT_ObjInfo(1, num3, num4, num5, zero, findRotation(posFrFndngRot, prevPosFrFndngRot), indexBasedonGivenValueinArray2, -1, "null", 0.25f, 0.25f, 0.35f, 0.35f, false, Time.time, 10f, 4f, false));
						num6++;
					}
					else
					{
						num4 += UnityEngine.Random.Range(4f, 6f);
					}
					num9++;
				}
			}
		}
		if (!flag2)
		{
			return;
		}
		list.Clear();
		for (int m = 0; m < WaypointManager.Paths.Count; m++)
		{
			if (m != 28 && !isGivenPathAlreadyInMissionObjPlacdDetatils(m))
			{
				list.Add(m);
			}
		}
		int num11 = list.Count;
		if (num11 < 0)
		{
			num11 = 0;
		}
		char[] array4 = new char[num11];
		if (num11 <= 0)
		{
			return;
		}
		int num12 = 0;
		int num13 = 0;
		while (num12 < num11 && num13 < 100)
		{
			int num14 = UnityEngine.Random.Range(0, IGT_ObjPlacing.Alphabetics.Length);
			if (!word.Contains((char)IGT_ObjPlacing.Alphabetics[num14]))
			{
				array4[num12] = (char)IGT_ObjPlacing.Alphabetics[num14];
				num12++;
			}
			num13++;
		}
		int num15 = 0;
		for (int n = 0; n < num11; n++)
		{
			num3 = list[n];
			num5 = array3[UnityEngine.Random.Range(0, array3.Length)];
			num4 = UnityEngine.Random.Range(6f, pathLength[num3] - 3f);
			if (num3 == strtPid)
			{
				num4 = UnityEngine.Random.Range(pathLength[num3] / 2f, pathLength[num3] - 3f);
				if (flag)
				{
					num4 = pathLength[strtPid] - num4;
				}
			}
			zero = findPos(num3, num4, num5);
			int indexBasedonGivenValueinArray3 = getIndexBasedonGivenValueinArray(ref IGT_ObjPlacing.Alphabetics, array4[num15]);
			pObj.missionObj_PlacedDetails.Add(new IGT_ObjInfo(1, num3, num4, num5, zero, findRotation(posFrFndngRot, prevPosFrFndngRot), indexBasedonGivenValueinArray3, -1, "null", 0.25f, 0.25f, 0.35f, 0.35f, false, Time.time, 10f, 4f, false));
			num15++;
		}
	}

	private bool isGivenPathAlreadyInMissionObjPlacdDetatils(int pid)
	{
		bool result = false;
		for (int i = 0; i < pObj.missionObj_PlacedDetails.Count; i++)
		{
			if (pid == pObj.missionObj_PlacedDetails[i].nPathId)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	private int getIndexBasedonGivenValueinArray(ref int[] arr, int val)
	{
		return Array.IndexOf(arr, val);
	}

	private bool isGivenDistCollideWithAlreadyPlacedObjInMissionObjPlacdDetatils(int pid, float dist)
	{
		bool result = false;
		for (int i = 0; i < pObj.missionObj_PlacedDetails.Count; i++)
		{
			if (pid != pObj.missionObj_PlacedDetails[i].nPathId)
			{
				continue;
			}
			if (dist < pObj.missionObj_PlacedDetails[i].fDistFrmStrtPnt)
			{
				if (dist + pObj.missionObj_PlacedDetails[i].fMinDstBwObj > pObj.missionObj_PlacedDetails[i].fDistFrmStrtPnt)
				{
					result = true;
				}
			}
			else if (dist - pObj.missionObj_PlacedDetails[i].fMinDstBwObj < pObj.missionObj_PlacedDetails[i].fDistFrmStrtPnt)
			{
				result = true;
			}
			break;
		}
		return result;
	}

	public int findNxtObjIdBasedDistinFrwdPath(float givenDist)
	{
		int result = -1;
		float num = 0f;
		for (int i = 0; i < pObj.nTotObjinCurPath; i++)
		{
			if (givenDist < pObj.obj[i].fDistFrmStrtPnt)
			{
				if (num == 0f)
				{
					num = pObj.obj[i].fDistFrmStrtPnt;
					result = i;
				}
				else if (num > pObj.obj[i].fDistFrmStrtPnt)
				{
					num = pObj.obj[i].fDistFrmStrtPnt;
					result = i;
				}
			}
		}
		return result;
	}

	public int findNxtObjIdBasedDistinRevPath(float givenDist)
	{
		int result = -1;
		float num = 0f;
		for (int i = 0; i < pObj.nTotObjinCurPath; i++)
		{
			if (givenDist > pObj.obj[i].fDistFrmStrtPnt)
			{
				if (num == 0f)
				{
					num = pObj.obj[i].fDistFrmStrtPnt;
					result = i;
				}
				else if (num < pObj.obj[i].fDistFrmStrtPnt)
				{
					num = pObj.obj[i].fDistFrmStrtPnt;
					result = i;
				}
			}
		}
		return result;
	}

	public void MovingObjInfoSelection()
	{
		int nVehicle_SelProb = IGT_Constants.nVehicle_SelProb;
		int randomNumber = getRandomNumber(100);
		if (randomNumber > nVehicle_SelProb)
		{
			return;
		}
		int[] array = new int[8];
		array = findPathBasedInput(currentPathIndex, bTraverseReverse, 1);
		if (array[0] == -1)
		{
			array = findPathBasedInput(currentPathIndex, bTraverseReverse, 2);
		}
		if (path_Shape_Type[array[0]] == 2 || path_Shape_Type[array[0]] == 0 || array[4] < 2)
		{
			return;
		}
		int num = array[0];
		for (int i = 0; i < pObj.movingObj.Count; i++)
		{
			if (nAdjPIDs.Contains(pObj.movingObj[i].nPathId) || nAdjPIDs.Contains(pObj.movingObj[i].VehicleDestPathID))
			{
				return;
			}
		}
		string text = IGT_FileReading.data[UnityEngine.Random.Range(IGT_FileReading.nobjLen - IGT_Constants.nNoOfMovingObj - IGT_Constants.nNoOfSplPowers, IGT_FileReading.nobjLen - IGT_Constants.nNoOfSplPowers)];
		string[] array2 = text.Split('~');
		int objplceTyp = int.Parse(array2[0]);
		int obId = int.Parse(array2[1]);
		int typ = int.Parse(array2[2]);
		string obName = array2[3];
		float len = float.Parse(array2[4]);
		float wid = float.Parse(array2[5]);
		float hei = float.Parse(array2[6]);
		float hei2 = float.Parse(array2[7]);
		float vehicleSpd = float.Parse(array2[8]) + UnityEngine.Random.Range(0.5f, 1.5f);
		bool movEnable = false;
		bool reachd = false;
		bool init = false;
		int num2 = pointCount[num] / 2;
		bool flag;
		int num3;
		int nxtPnt;
		int num4;
		int noOfTarRchd;
		if (array[1] == 0)
		{
			flag = true;
			num3 = num2;
			nxtPnt = num2 - 1;
			num4 = num2 + 1;
			noOfTarRchd = pointCount[num] - num3;
		}
		else
		{
			flag = false;
			num3 = pointCount[num] - num2;
			nxtPnt = pointCount[num] - (num2 - 1);
			num4 = pointCount[num] - (num2 + 1);
			noOfTarRchd = num3 + 1;
		}
		Vector3 vector = new Vector3(pointPos[num, num3, 0], pointPos[num, num3, 1], pointPos[num, num3, 2]);
		Vector3 vector2 = new Vector3(pointPos[num, num4, 0], pointPos[num, num4, 1], pointPos[num, num4, 2]);
		float[] array3 = new float[2]
		{
			0f - fTotalOffsetDeviation / 1.5f,
			fTotalOffsetDeviation / 1.5f
		};
		float num5 = array3[UnityEngine.Random.Range(0, array3.Length)];
		float x = vector.x - vector2.x;
		float y = vector.y - vector2.y;
		float z = vector.z - vector2.z;
		Vector3 rhs = new Vector3(x, y, z);
		rhs.Normalize();
		Vector3 vector3 = Vector3.Cross(Vector3.up, rhs);
		Vector3 vector4 = vector + vector3 * num5;
		Vector3 rot = findRotation(vector4, vector2 + vector3 * num5);
		float num6 = objDistFrmStrtPoint(num, num3, vector);
		if (flag)
		{
			num6 = pathLength[num] - num6;
		}
		int[] array4 = new int[8];
		array4 = findPathBasedInput(num, flag, 0);
		if (array4[0] == -1 || array4[0] == 4 || array4[0] == 5 || array4[0] == 25)
		{
			return;
		}
		int num7 = array4[0];
		int num8 = array4[3];
		int num9 = array4[1];
		int dstpathNxtPntID = array4[2];
		bool crsdCurPath = false;
		bool dstPathTravRev;
		if (num9 == 0)
		{
			dstPathTravRev = false;
		}
		else
		{
			dstPathTravRev = true;
			num9--;
		}
		for (int j = 0; j < pObj.movingObj.Count; j++)
		{
			if (pObj.movingObj[j].VehicleDestPathID == num7)
			{
				return;
			}
		}
		Vector3 dstPos = new Vector3(pointPos[num7, num8, 0], pointPos[num7, num8, 1], pointPos[num7, num8, 2]);
		if (!isSelectedVEHICLEObjCollidedWithAlreadyPlacedObjects(new IGT_ObjInfo(vehicleSpd, objplceTyp, num, num5, vector, rot, obId, typ, obName, len, wid, hei, hei2, movEnable, reachd, init, num3, dstPos, vector4, num7, nxtPnt, flag, noOfTarRchd, num9, dstPathTravRev, crsdCurPath, dstpathNxtPntID, num6)))
		{
			pObj.movingObj.Add(new IGT_ObjInfo(vehicleSpd, objplceTyp, num, num5, vector, rot, obId, typ, obName, len, wid, hei, hei2, movEnable, reachd, init, num3, dstPos, vector4, num7, nxtPnt, flag, noOfTarRchd, num9, dstPathTravRev, crsdCurPath, dstpathNxtPntID, num6));
		}
	}

	private bool isSelectedVEHICLEObjCollidedWithAlreadyPlacedObjects(IGT_ObjInfo pobjInfo)
	{
		bool flag = false;
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		int num4 = -1;
		objDetInCurPath(pobjInfo.nPathId);
		num4 = findNxtObjIdBasedDistinFrwdPath(pobjInfo.fDistFrmStrtPnt);
		if (num4 != -1)
		{
			num = pObj.obj[num4].fDistFrmStrtPnt;
			num2 = pObj.obj[num4].fMinDstBwObj;
			num3 = pObj.obj[num4].fWidth;
			if (pobjInfo.fDistFrmStrtPnt + pobjInfo.fWidth / 2f + pobjInfo.fMinDstBwObj / 2f > num - num3 / 2f - num2 / 2f)
			{
				flag = true;
			}
			if (pObj.obj[num4].objType == 3)
			{
				if (pObj.obj[num4].bVehicleCrossedCurPath && pObj.obj[num4].bTravRev)
				{
					num = pathLength[pObj.obj[num4].nPathId] - num;
				}
				if (pobjInfo.fDistFrmStrtPnt + pobjInfo.fWidth / 2f + pobjInfo.fMinDstBwObj > num - 5f)
				{
					flag = true;
				}
			}
		}
		if (!flag)
		{
			num4 = findNxtObjIdBasedDistinRevPath(pobjInfo.fDistFrmStrtPnt);
			if (num4 != -1)
			{
				num = pObj.obj[num4].fDistFrmStrtPnt;
				num2 = pObj.obj[num4].fMinDstBwObj;
				num3 = pObj.obj[num4].fWidth;
				if (num + num3 / 2f + num2 / 2f > pobjInfo.fDistFrmStrtPnt - pobjInfo.fWidth / 2f - pobjInfo.fMinDstBwObj / 2f)
				{
					flag = true;
				}
				if (pObj.obj[num4].objType == 3)
				{
					if (pObj.obj[num4].bVehicleCrossedCurPath && pObj.obj[num4].bTravRev)
					{
						num = pathLength[pObj.obj[num4].nPathId] - num;
					}
					if (num + 5f > pobjInfo.fDistFrmStrtPnt - pobjInfo.fWidth / 2f - pobjInfo.fMinDstBwObj)
					{
						flag = true;
					}
				}
			}
		}
		return flag;
	}

	public void Coin_PlacingInfoSel(List<int> PIDx, bool bCoinMission = false)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		string text = "null";
		float num4 = 0f;
		float num5 = 0f;
		float num6 = 0f;
		float num7 = 0f;
		float num8 = 0f;
		int num9 = -1;
		float num10 = 0f;
		Vector3 zero = Vector3.zero;
		Vector3 zero2 = Vector3.zero;
		bool flag = false;
		bool flag2 = false;
		float num11 = 0f;
		float num12 = 0f;
		float num13 = 0f;
		string text2 = IGT_FileReading.data[pObj.CoinObjIndexBasedProbability[0, 0]];
		string[] array = text2.Split('~');
		float num14 = 3f;
		int num15 = 0;
		int num16 = 8;
		float num17 = 2.5f;
		float fCurrentPos = 0f;
		float num18 = 0f;
		float num19 = 0f;
		bool flag3 = false;
		float num20 = 0f;
		List<float> list = new List<float>();
		for (int i = 0; i < PIDx.Count; i++)
		{
			num9 = PIDx[i];
			if (!bCoinMission && IGT_GameView.pHero.nGameMode == 1 && UnityEngine.Random.Range(1, 100) >= IGT_Constants.nCoin_PlacingProb)
			{
				continue;
			}
			if (bCoinMission)
			{
				if ((collItemPlacdTimeInPath[num9] != 0f && Time.time - collItemPlacdTimeInPath[num9] < 30f) || UnityEngine.Random.Range(1, 100) >= IGT_Constants.nCollItemPlacingProb)
				{
					continue;
				}
				collItemPlacdTimeInPath[num9] = Time.time;
			}
			int num21 = pObj.CoinObjIndexBasedProbability[0, 0];
			text2 = IGT_FileReading.data[num21];
			array = text2.Split('~');
			num = int.Parse(array[0]);
			num2 = int.Parse(array[1]);
			num3 = int.Parse(array[2]);
			text = array[3];
			num4 = float.Parse(array[4]);
			num5 = float.Parse(array[5]);
			num6 = float.Parse(array[6]);
			num7 = float.Parse(array[7]);
			num8 = float.Parse(array[8]);
			flag = false;
			flag2 = false;
			num11 = Time.timeSinceLevelLoad;
			num12 = float.Parse(array[9]);
			float[] array2 = new float[3]
			{
				0f - pathWidth[num9] / 2f * fTotalOffsetDeviation,
				0f,
				pathWidth[num9] / 2f * fTotalOffsetDeviation
			};
			num10 = array2[UnityEngine.Random.Range(0, array2.Length)];
			flag3 = false;
			num20 = 0f;
			num16 = ((pathLength[num9] < 25f) ? 8 : ((!(pathLength[num9] < 35f)) ? 15 : 10));
			list.Clear();
			int num22 = 8;
			bool flag4 = false;
			bool flag5 = false;
			List<IGT_ObjInfo> list2 = objDetInGivenPath(num9);
			for (int j = 0; j < list2.Count; j++)
			{
				if (list2[j].objType == 0 || (list2[j].objType == 2 && list2[j].fWidth < 1f))
				{
					flag4 = true;
					num20 = 0f;
					num13 = list2[j].fDistFrmStrtPnt - list2[j].fMinDstBwObj / 2f - list2[j].fWidth / 2f;
					num10 = ((list2[j].fOffset < 0f) ? array2[0] : ((!(list2[j].fOffset > 0f)) ? list2[j].fOffset : array2[2]));
					if (num13 + (float)num22 * num8 > pathLength[num9] - num14)
					{
						flag4 = false;
					}
					for (int k = 0; k < list.Count; k++)
					{
						if (num13 > list.ElementAt(k) && num13 < list.ElementAt(k) + (float)num22 * num8)
						{
							flag4 = false;
							break;
						}
					}
					if (!flag4)
					{
						continue;
					}
					int num23 = 0;
					num15 = 0;
					list.Add(num13);
					while (num15 < num22 && num13 < pathLength[num9] - num14 && num23 < 200)
					{
						num13 = num13 + num8 + num5 / 2f;
						zero = findPos(num9, num13, num10);
						zero2 = findRotation(posFrFndngRot, prevPosFrFndngRot);
						float num24 = 0f;
						if (num20 <= 180f)
						{
							num24 = 0.295f * Mathf.Sin((float)Math.PI / 180f * num20);
							num20 += 22.5f;
						}
						if (num20 != 0f && num20 != 180f)
						{
							zero.y += num24;
						}
						if (!bCoinMission)
						{
							if (!isCoinAlreadyPlaced(ref pObj.pCoinDatas, num9, zero))
							{
								pObj.pCoinDatas.Add(new IGT_ObjInfo(num, num9, num13, num10, zero, zero2, num2, num3, text, num4, num5, num6, num7, flag, num11, num12, num8, flag2));
							}
						}
						else if (!isCoinAlreadyPlaced(ref pObj.missionObj_PlacedDetails, num9, zero))
						{
							pObj.missionObj_PlacedDetails.Add(new IGT_ObjInfo(num, num9, num13, num10, zero, zero2, 0, -1, text, num4, 1f, num6 * 2f, num7, flag, num11, num12, num8, flag2));
						}
						num15++;
						num23++;
					}
				}
				else
				{
					if (list2[j].objType != 1)
					{
						continue;
					}
					flag5 = true;
					num13 = list2[j].fDistFrmStrtPnt - list2[j].fMinDstBwObj / 2f - list2[j].fWidth / 2f;
					num10 = ((list2[j].fOffset < 0f) ? array2[0] : ((!(list2[j].fOffset > 0f)) ? list2[j].fOffset : array2[2]));
					if (num13 + (float)num22 * num8 > pathLength[num9] - num14)
					{
						flag5 = false;
					}
					for (int l = 0; l < list.Count; l++)
					{
						if (num13 > list.ElementAt(l) && num13 < list.ElementAt(l) + (float)num22 * num8)
						{
							flag5 = false;
							break;
						}
					}
					if (!flag5 || UnityEngine.Random.Range(0, 100) >= 80)
					{
						continue;
					}
					int num25 = 0;
					num15 = 0;
					list.Add(num13);
					while (num15 < num22 && num13 < pathLength[num9] - num14 && num25 < 200)
					{
						num13 = num13 + num8 + num5 / 2f;
						zero = findPos(num9, num13, num10);
						zero2 = findRotation(posFrFndngRot, prevPosFrFndngRot);
						if (!bCoinMission)
						{
							if (!isCoinAlreadyPlaced(ref pObj.pCoinDatas, num9, zero))
							{
								pObj.pCoinDatas.Add(new IGT_ObjInfo(num, num9, num13, num10, zero, zero2, num2, num3, text, num4, num5, num6, num7, flag, num11, num12, num8, flag2));
							}
						}
						else if (!isCoinAlreadyPlaced(ref pObj.missionObj_PlacedDetails, num9, zero))
						{
							pObj.missionObj_PlacedDetails.Add(new IGT_ObjInfo(num, num9, num13, num10, zero, zero2, 0, -1, text, num4, 1f, num6 * 2f, num7, flag, num11, num12, num8, flag2));
						}
						num15++;
						num25++;
					}
				}
			}
			num13 = num14 + UnityEngine.Random.Range(1f, 2f);
			int num26 = 0;
			float num27 = num13;
			bool flag6 = false;
			while (num13 + (float)num16 * num8 < pathLength[num9] - num14 && num26 < 50)
			{
				flag6 = false;
				for (int m = 0; m < list.Count; m++)
				{
					num27 = num13;
					for (int n = 0; n < num16; n++)
					{
						if (num27 > list.ElementAt(m) && num27 < list.ElementAt(m) + (float)num22 * (num8 + num5 / 2f))
						{
							num13 = list.ElementAt(m) + (float)num16 * num8 + num17 + UnityEngine.Random.Range(1f, 2f);
							num10 = array2[UnityEngine.Random.Range(0, array2.Length)];
							flag3 = false;
							fCurrentPos = (num18 = num10);
							num19 = 0f;
							flag6 = true;
							break;
						}
						num27 += num8 + num5 / 2f;
					}
					if (flag6)
					{
						break;
					}
				}
				if (!flag6)
				{
					if (UnityEngine.Random.Range(0, 100) < 50)
					{
						float num28 = num13;
						if (list.Count > 0)
						{
							num28 = list.ElementAt(list.Count - 1);
							num13 = num28 + (float)num16 * num8 + num17 + UnityEngine.Random.Range(5f, 8f);
						}
						else
						{
							num13 = num28 + (float)num16 * num8 + num17 + UnityEngine.Random.Range(7f, 10f);
						}
					}
					int num29 = 0;
					num15 = 0;
					while (num15 < num16 && num13 < pathLength[num9] - num14 && num29 < 200)
					{
						num13 = num13 + num8 + num5 / 2f;
						for (int num30 = 0; num30 < list2.Count; num30++)
						{
							if (num13 >= list2[num30].fDistFrmStrtPnt - list2[num30].fWidth / 2f - list2[num30].fMinDstBwObj && num13 <= list2[num30].fDistFrmStrtPnt + list2[num30].fWidth / 2f + list2[num30].fMinDstBwObj && num10 >= list2[num30].fOffset - list2[num30].fLength / 2f && num10 <= list2[num30].fOffset + list2[num30].fLength / 2f && !flag3 && list2[num30].objType != 1)
							{
								fCurrentPos = num10;
								num18 = IGT_GameView.pHero.FindAImodeDestinationOffset(num10, list2[num30].fOffset, list2[num30].fLength / 2f, list2[num30].bTravRev);
								flag3 = true;
								break;
							}
						}
						if (flag3 && num10 != num18)
						{
							num10 = IGT_EaseFunction.Linear_ease(num19, fCurrentPos, num18, 0.1f);
							num19 += Time.deltaTime * 2f;
							if (num19 >= 0.1f)
							{
								num19 = 0f;
								num10 = num18;
								flag3 = false;
							}
						}
						zero = findPos(num9, num13, num10);
						zero2 = findRotation(posFrFndngRot, prevPosFrFndngRot);
						if (!bCoinMission)
						{
							if (!isCoinAlreadyPlaced(ref pObj.pCoinDatas, num9, zero))
							{
								pObj.pCoinDatas.Add(new IGT_ObjInfo(num, num9, num13, num10, zero, zero2, num2, num3, text, num4, num5, num6, num7, flag, num11, num12, num8, flag2));
							}
						}
						else if (!isCoinAlreadyPlaced(ref pObj.missionObj_PlacedDetails, num9, zero))
						{
							pObj.missionObj_PlacedDetails.Add(new IGT_ObjInfo(num, num9, num13, num10, zero, zero2, 0, -1, text, num4, 1f, num6 * 2f, num7, flag, num11, num12, num8, flag2));
						}
						num15++;
						num29++;
					}
					num13 += num17 + UnityEngine.Random.Range(1f, 2f);
					num10 = array2[UnityEngine.Random.Range(0, array2.Length)];
					flag3 = false;
					fCurrentPos = (num18 = num10);
					num19 = 0f;
				}
				num26++;
			}
		}
	}

	public void coinPlacing_In_GivenPath(int PId, bool bcoinMissionMode)
	{
		if (bcoinMissionMode)
		{
			pObj.missionObj_PlacedDetails.Clear();
		}
		else
		{
			pObj.pCoinDatas.Clear();
		}
		List<int> list = new List<int>();
		list.Add(PId);
		Coin_PlacingInfoSel(list, bcoinMissionMode);
		if (bcoinMissionMode)
		{
			IGT_ObjPlacing.collectionItemsDestruction();
			IGT_ObjPlacing.CollectionItemPlacing(ref pObj.missionObj_PlacedDetails);
			IGT_ObjPlacing.Rotate_CollectionItems_Coins();
		}
		else
		{
			IGT_ObjPlacing.Coin_Destruction();
			IGT_ObjPlacing.Coin_Placing(ref pObj.pCoinDatas);
			IGT_ObjPlacing.Rotation_Coin();
		}
	}

	private bool isCoinAlreadyPlaced(ref List<IGT_ObjInfo> datas, int pid, Vector3 pos)
	{
		bool result = false;
		for (int num = datas.Count - 1; num >= 0; num--)
		{
			if (datas[num].nPathId == pid && datas[num].ObjPos == pos)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	private void CollectionObjPlacement_Coin(List<int> PIDx)
	{
		int objplceTyp = 1;
		int obId = 0;
		int typ = -1;
		string obName = "null";
		float len = 0.25f;
		float num = 0.25f;
		float hei = 0.35f;
		float hei2 = 0.15f;
		float fMinDistBtwCollectionItems = IGT_Constants.fMinDistBtwCollectionItems;
		int num2 = -1;
		float num3 = 0f;
		Vector3 zero = Vector3.zero;
		Vector3 zero2 = Vector3.zero;
		bool plyrcrsd = false;
		bool disabled = false;
		float time = Time.time;
		float lfeTme = 2f;
		float num4 = 0f;
		bool flag = true;
		int num5 = 0;
		int num6 = 0;
		for (int i = 0; i < PIDx.Count; i++)
		{
			num2 = PIDx[i];
			num4 = (int)UnityEngine.Random.Range(2.5f, pathLength[num2] * 0.2f);
			if (collItemPlacdTimeInPath[num2] != 0f && Time.time - collItemPlacdTimeInPath[num2] < 60f)
			{
				continue;
			}
			collItemPlacdTimeInPath[num2] = Time.time;
			num6 = (int)UnityEngine.Random.Range(pathLength[num2] * 0.45f, pathLength[num2] * 0.65f);
			flag = true;
			int num7 = 0;
			while (flag && num7 < 10)
			{
				float[] array = new float[3]
				{
					0f - pathWidth[num2] / 2f * fTotalOffsetDeviation,
					0f,
					pathWidth[num2] / 2f * fTotalOffsetDeviation
				};
				num3 = array[UnityEngine.Random.Range(0, array.Length)];
				int num8 = 0;
				num5 = 0;
				while (num5 < num6 && num4 < pathLength[num2] - 3.5f && num8 < 250)
				{
					num4 = num4 + fMinDistBtwCollectionItems + num / 2f;
					zero = findPos(num2, num4, num3);
					zero2 = findRotation(posFrFndngRot, prevPosFrFndngRot);
					pObj.missionObj_PlacedDetails.Add(new IGT_ObjInfo(objplceTyp, num2, num4, num3, zero, zero2, obId, typ, obName, len, num, hei, hei2, plyrcrsd, time, lfeTme, fMinDistBtwCollectionItems, disabled));
					num5++;
					num8++;
				}
				if (num4 < pathLength[num2] - 3.5f)
				{
					num4 += (float)UnityEngine.Random.Range(3, 6);
				}
				else
				{
					flag = false;
				}
				num7++;
			}
		}
	}

	public int selectRandom_StartPath(int curPid = 1000)
	{
		int num = UnityEngine.Random.Range(0, WaypointManager.Paths.Count);
		while (num == -1 || num == 28 || num == curPid)
		{
			num = UnityEngine.Random.Range(0, WaypointManager.Paths.Count);
		}
		return num;
	}

	public List<int> findAdjPathFrObjPlacing(int pid, bool bTravRevers)
	{
		List<int> list = new List<int>();
		int[] array = new int[6];
		for (int i = 0; i < 3; i++)
		{
			array = findPathBasedInput(pid, bTravRevers, i);
			if (array[0] != -1)
			{
				list.Add(array[0]);
			}
		}
		return list;
	}

	public bool findNearstPath(int curPathID, Vector3 prevPos, Vector3 endPos, int userIp)
	{
		if (userIp != 1 && userIp != 2)
		{
			userIp = 0;
		}
		fMinAngle = 9999f;
		float num = 0f;
		float x = endPos.x - prevPos.x;
		float y = endPos.y - prevPos.y;
		float z = endPos.z - prevPos.z;
		Vector3 vector = new Vector3(x, y, z);
		vector.Normalize();
		for (int i = 0; i < WaypointManager.Paths.Count; i++)
		{
			for (int j = 0; j < pointCount[i]; j++)
			{
				if (j != 0 && j + 1 != pointCount[i])
				{
					continue;
				}
				Vector3 a = new Vector3(pointPos[i, j, 0], pointPos[i, j, 1], pointPos[i, j, 2]);
				float num2 = Vector3.Distance(a, endPos);
				float x2 = a.x - endPos.x;
				float y2 = a.y - endPos.y;
				float z2 = a.z - endPos.z;
				Vector3 vector2 = new Vector3(x2, y2, z2);
				vector2.Normalize();
				if (!(num2 < (float)IGT_Constants.nWAY_SEARCH_RADIUS) || i == curPathID || i == 28)
				{
					continue;
				}
				Vector3 vector3 = Vector3.Cross(vector, Vector3.up);
				switch (userIp)
				{
				case 1:
					num = Vector3.Angle(vector3, vector2);
					break;
				case 2:
					vector3 = -vector3;
					num = Vector3.Angle(vector2, vector3);
					break;
				case 0:
					num = Vector3.Angle(vector, vector2);
					break;
				}
				if (fMinAngle >= num)
				{
					fMinAngle = num;
					fMinPathIdx = i;
					if (j + 1 == pointCount[i])
					{
						fMinPathCurPntIdx = j + 1;
					}
					else
					{
						fMinPathCurPntIdx = j;
					}
				}
			}
		}
		if (userIp == 0 && fMinAngle > 10f)
		{
			return false;
		}
		PathInit((int)fMinPathIdx, (int)fMinPathCurPntIdx);
		return true;
	}

	public int[] findPathBasedInput(int pid, bool travRev, int side)
	{
		int[] array = new int[6] { -1, 0, 0, 0, 0, 0 };
		float num = 0f;
		float num2 = 9999f;
		int num3 = 0;
		Vector3 b;
		Vector3 vector;
		if (!travRev)
		{
			b = new Vector3(pointPos[pid, pointCount[pid] - 1, 0], pointPos[pid, pointCount[pid] - 1, 1], pointPos[pid, pointCount[pid] - 1, 2]);
			vector = new Vector3(pointPos[pid, pointCount[pid] - 2, 0], pointPos[pid, pointCount[pid] - 2, 1], pointPos[pid, pointCount[pid] - 2, 2]);
		}
		else
		{
			b = new Vector3(pointPos[pid, 0, 0], pointPos[pid, 0, 1], pointPos[pid, 0, 2]);
			vector = new Vector3(pointPos[pid, 1, 0], pointPos[pid, 1, 1], pointPos[pid, 1, 2]);
		}
		float x = b.x - vector.x;
		float y = b.y - vector.y;
		float z = b.z - vector.z;
		Vector3 vector2 = new Vector3(x, y, z);
		vector2.Normalize();
		for (int i = 0; i < WaypointManager.Paths.Count; i++)
		{
			for (int j = 0; j < pointCount[i]; j++)
			{
				if (j != 0 && j + 1 != pointCount[i])
				{
					continue;
				}
				Vector3 a = new Vector3(pointPos[i, j, 0], pointPos[i, j, 1], pointPos[i, j, 2]);
				float num4 = Vector3.Distance(a, b);
				float x2 = a.x - b.x;
				float y2 = a.y - b.y;
				float z2 = a.z - b.z;
				Vector3 vector3 = new Vector3(x2, y2, z2);
				vector3.Normalize();
				if (!(num4 < (float)IGT_Constants.nWAY_SEARCH_RADIUS) || i == pid || i == 28)
				{
					continue;
				}
				num3++;
				Vector3 vector4 = Vector3.Cross(vector2, Vector3.up);
				switch (side)
				{
				case 1:
					num = Vector3.Angle(vector4, vector3);
					break;
				case 2:
					vector4 = -vector4;
					num = Vector3.Angle(vector3, vector4);
					break;
				case 0:
					num = Vector3.Angle(vector2, vector3);
					break;
				}
				if (num2 >= num)
				{
					num2 = num;
					array[0] = i;
					if (j + 1 == pointCount[i])
					{
						array[1] = j + 1;
						array[2] = j - 1;
						array[3] = j - 2;
					}
					else
					{
						array[1] = j;
						array[2] = j + 1;
						array[3] = j + 2;
					}
				}
			}
		}
		array[4] = num3;
		if ((side == 0 && num2 > 10f) || (side == 1 && num2 > 80f) || (side == 2 && num2 > 80f))
		{
			array[0] = -1;
			return array;
		}
		return array;
	}

	public bool isTargetReached(Vector3 SrcPoint, Vector3 MovingPoint, Vector3 DestPoint)
	{
		float x = DestPoint.x - SrcPoint.x;
		float y = DestPoint.y - SrcPoint.y;
		float z = DestPoint.z - SrcPoint.z;
		Vector3 lhs = new Vector3(x, y, z);
		lhs.Normalize();
		float x2 = DestPoint.x - MovingPoint.x;
		float y2 = DestPoint.y - MovingPoint.y;
		float z2 = DestPoint.z - MovingPoint.z;
		Vector3 rhs = new Vector3(x2, y2, z2);
		rhs.Normalize();
		return Vector3.Dot(lhs, rhs) <= 0f;
	}

	public void SetPath(PathManager newPath)
	{
		pathContainer = newPath;
		waypoints = pathContainer.waypoints;
	}

	public string getCurPathIdx_Width(string str, int retIdx)
	{
		string[] array = str.Split('_');
		return array[retIdx];
	}

	public float TotPathDistance(Transform[] wayPnts, int waypntLen)
	{
		float num = 0f;
		for (int i = 0; i < waypntLen - 1; i++)
		{
			float num2 = Vector3.Distance(wayPnts[i].position, wayPnts[i + 1].position);
			num += num2;
		}
		return num;
	}

	public float objDistFrmStrtPoint(int Pid, int EndPnt, Vector3 objPos)
	{
		float num = 0f;
		for (int i = 0; i < EndPnt; i++)
		{
			float num2 = Vector3.Distance(new Vector3(pointPos[Pid, i, 0], pointPos[Pid, i, 1], pointPos[Pid, i, 2]), new Vector3(pointPos[Pid, i + 1, 0], pointPos[Pid, i + 1, 1], pointPos[Pid, i + 1, 2]));
			num += num2;
			if (i + 1 == EndPnt)
			{
				num2 = Vector3.Distance(new Vector3(pointPos[Pid, EndPnt, 0], pointPos[Pid, EndPnt, 1], pointPos[Pid, EndPnt, 2]), objPos);
				num += num2;
			}
		}
		return num;
	}

	public Vector3 findPos(int Pid, float dist, float offset)
	{
		if (dist > pathLength[Pid])
		{
			dist = pathLength[Pid];
		}
		if (dist < 0f)
		{
			dist = 0.05f;
		}
		float num = 0f;
		float num2 = 0f;
		for (int i = 0; i < pointCount[Pid]; i++)
		{
			float num3 = Vector3.Distance(new Vector3(pointPos[Pid, i, 0], pointPos[Pid, i, 1], pointPos[Pid, i, 2]), new Vector3(pointPos[Pid, i + 1, 0], pointPos[Pid, i + 1, 1], pointPos[Pid, i + 1, 2]));
			num2 += num3;
			if (num2 < dist)
			{
				num = num2;
				continue;
			}
			float num4 = dist - num;
			Vector3 vector = new Vector3(pointPos[Pid, i, 0], pointPos[Pid, i, 1], pointPos[Pid, i, 2]);
			Vector3 vector2 = new Vector3(pointPos[Pid, i + 1, 0], pointPos[Pid, i + 1, 1], pointPos[Pid, i + 1, 2]);
			Vector3 vector3 = new Vector3(vector2.x - vector.x, vector2.y - vector.y, vector2.z - vector.z);
			vector3.Normalize();
			Vector3 vector4 = vector + vector3 * num4;
			Vector3 rhs = new Vector3(vector4.x - vector.x, vector4.y - vector.y, vector4.z - vector.z);
			rhs.Normalize();
			Vector3 vector5 = Vector3.Cross(Vector3.up, rhs);
			Vector3 result = (posFrFndngRot = vector4 + vector5 * offset);
			Vector3 vector6 = Vector3.Cross(Vector3.up, vector3);
			prevPosFrFndngRot = vector + vector6 * offset;
			return result;
		}
		return Vector3.zero;
	}

	public void find_CurPos_PrevPos_BasedGivenDist(int Pid, float dist, float offset, ref Vector3 curPos, ref Vector3 prevWaypointPos, ref Vector3 nextWaypointPos)
	{
		if (dist > pathLength[Pid])
		{
			dist = pathLength[Pid];
		}
		if (dist < 0f)
		{
			dist = 0.05f;
		}
		float num = 0f;
		float num2 = 0f;
		for (int i = 0; i < pointCount[Pid]; i++)
		{
			float num3 = Vector3.Distance(new Vector3(pointPos[Pid, i, 0], pointPos[Pid, i, 1], pointPos[Pid, i, 2]), new Vector3(pointPos[Pid, i + 1, 0], pointPos[Pid, i + 1, 1], pointPos[Pid, i + 1, 2]));
			num2 += num3;
			if (num2 < dist)
			{
				num = num2;
				continue;
			}
			float num4 = dist - num;
			Vector3 vector = new Vector3(pointPos[Pid, i, 0], pointPos[Pid, i, 1], pointPos[Pid, i, 2]);
			Vector3 vector2 = new Vector3(pointPos[Pid, i + 1, 0], pointPos[Pid, i + 1, 1], pointPos[Pid, i + 1, 2]);
			Vector3 vector3 = new Vector3(vector2.x - vector.x, vector2.y - vector.y, vector2.z - vector.z);
			vector3.Normalize();
			Vector3 vector4 = vector + vector3 * num4;
			Vector3 rhs = new Vector3(vector4.x - vector.x, vector4.y - vector.y, vector4.z - vector.z);
			rhs.Normalize();
			Vector3 vector5 = Vector3.Cross(Vector3.up, rhs);
			curPos = vector4 + vector5 * offset;
			prevWaypointPos = vector + vector5 * offset;
			rhs = vector2 - vector4;
			rhs.Normalize();
			vector5 = Vector3.Cross(Vector3.up, rhs);
			nextWaypointPos = vector2 + vector5 * offset;
			break;
		}
	}

	public Vector3 findRotation(Vector3 pos, Vector3 prevpos)
	{
		Vector3 vector = new Vector3(pos.x - prevpos.x, pos.y - prevpos.y, pos.z - prevpos.z);
		vector.Normalize();
		Vector3 vector2 = Vector3.Cross(vector, Vector3.up);
		float num = Vector3.Angle(vector, Vector3.forward);
		if (vector2.z < 0f)
		{
			num = 0f - num;
		}
		float num2 = Vector3.Angle(vector, Vector3.forward);
		if (vector2.x < 0f)
		{
			num2 = 0f - num2;
		}
		return new Vector3(num2, 0f, num);
	}

	public Vector3 findRotationSample(Vector3 pos, Vector3 prevpos, Vector3 refForward, Vector3 refUp)
	{
		Vector3 vector = new Vector3(pos.x - prevpos.x, pos.y - prevpos.y, pos.z - prevpos.z);
		vector.Normalize();
		float num = Vector3.Angle(vector, refForward);
		if (Vector3.Cross(vector, refUp).z < 0f)
		{
			num = 0f - num;
		}
		return new Vector3(0f, 0f, num);
	}

	public float fndRandOffset(int Objtyp, float objLen, int pId)
	{
		float num = 0f;
		float[] array = new float[3]
		{
			0f - num,
			0f,
			num
		};
		float num2 = array[UnityEngine.Random.Range(0, array.Length)];
		switch (Objtyp)
		{
		case 4:
			num = fTotalOffsetDeviation + 0.15f;
			array = new float[3]
			{
				0f - num,
				0f,
				num
			};
			num2 = array[UnityEngine.Random.Range(0, array.Length)];
			break;
		case 6:
			array = new float[2] { -0.35f, 0.5f };
			num2 = array[UnityEngine.Random.Range(0, array.Length)];
			break;
		default:
			num = pathWidth[pId] / 2f * 0.7f;
			array = new float[3]
			{
				0f - num,
				0f,
				num
			};
			num2 = array[UnityEngine.Random.Range(0, array.Length)];
			break;
		}
		if (num2 == 0f && objLen >= 0.8f && (Objtyp == 5 || Objtyp == 1))
		{
			num = pathWidth[pId] / 2f * 0.7f;
			array = new float[2]
			{
				0f - num,
				num
			};
			num2 = array[UnityEngine.Random.Range(0, array.Length)];
		}
		if (Objtyp != 6)
		{
			if (num2 < 0f)
			{
				float num3 = num2 - objLen / 2f;
				if (num3 < 0f - num)
				{
					float num4 = num3 + num;
					num2 -= num4;
				}
			}
			else if (num2 > 0f)
			{
				float num5 = num2 + objLen / 2f;
				if (num5 > num)
				{
					float num6 = num5 - num;
					num2 -= num6;
				}
			}
		}
		return num2;
	}

	public Vector3 ScaleDownObject(Vector3 curSize, Vector3 tarSize, float scaleFactor)
	{
		return Vector3.Lerp(curSize, tarSize, scaleFactor * Time.deltaTime);
	}

	public Vector3[] GetBounds(Vector3 pos, float wid, float height, float len)
	{
		Vector3 vector = new Vector3(pos.x - len / 2f, pos.y - height / 2f, pos.z - wid / 2f);
		Vector3 vector2 = new Vector3(pos.x - len / 2f, pos.y - height / 2f, pos.z + wid / 2f);
		Vector3 vector3 = new Vector3(pos.x + len / 2f, pos.y - height / 2f, pos.z - wid / 2f);
		Vector3 vector4 = new Vector3(pos.x + len / 2f, pos.y - height / 2f, pos.z + wid / 2f);
		Vector3[] array = new Vector3[3];
		array[0] = vector;
		array[1] = vector2;
		array[2] = vector3;
		array[3] = vector4;
		return array;
	}

	public Vector3 CurvePoints(Vector3 prevPt, Vector3 firstPt, Vector3 secondPt, Vector3 nextPt, float dist)
	{
		float num = 0f;
		num = Vector3.Distance(firstPt, secondPt);
		if (dist > num)
		{
			dist = num;
		}
		float num2 = dist / num;
		float num3 = 0f;
		float num4 = 0f;
		float num5 = num2;
		float num6 = num5 * num5;
		float num7 = num6 * num5;
		float num8 = 2f * num7 - 3f * num6 + 1f;
		float num9 = num7 - 2f * num6 + num5;
		float num10 = num7 - num6;
		float num11 = -2f * num7 + 3f * num6;
		float num12 = (firstPt.x - prevPt.x) * (1f + num4) * (1f - num3) / 2f;
		num12 += (secondPt.x - firstPt.x) * (1f - num4) * (1f - num3) / 2f;
		float num13 = (secondPt.x - firstPt.x) * (1f + num4) * (1f - num3) / 2f;
		num13 += (nextPt.x - secondPt.x) * (1f - num4) * (1f - num3) / 2f;
		float x = num8 * firstPt.x + num9 * num12 + num10 * num13 + num11 * secondPt.x;
		num12 = (firstPt.y - prevPt.y) * (1f + num4) * (1f - num3) / 2f;
		num12 += (secondPt.y - firstPt.y) * (1f - num4) * (1f - num3) / 2f;
		num13 = (secondPt.y - firstPt.y) * (1f + num4) * (1f - num3) / 2f;
		num13 += (nextPt.y - secondPt.y) * (1f - num4) * (1f - num3) / 2f;
		float y = num8 * firstPt.y + num9 * num12 + num10 * num13 + num11 * secondPt.y;
		num12 = (firstPt.z - prevPt.z) * (1f + num4) * (1f - num3) / 2f;
		num12 += (secondPt.z - firstPt.z) * (1f - num4) * (1f - num3) / 2f;
		num13 = (secondPt.z - firstPt.z) * (1f + num4) * (1f - num3) / 2f;
		num13 += (nextPt.z - secondPt.z) * (1f - num4) * (1f - num3) / 2f;
		float z = num8 * firstPt.z + num9 * num12 + num10 * num13 + num11 * secondPt.z;
		return new Vector3(x, y, z);
	}

	public Vector3[] PositionBasedGivenDistBw2Points(int curPathID, int StartingPosID, float GivenDistance, bool TraverseReverse, int side)
	{
		if (side != 1 && side != 2)
		{
			side = 0;
		}
		int num = curPathID;
		int num2 = StartingPosID;
		bool flag = TraverseReverse;
		Vector3[] array = new Vector3[5];
		int[] array2 = new int[6];
		bool flag2 = false;
		float num3 = 0f;
		float num4 = 0f;
		while (!flag2)
		{
			if (!flag)
			{
				for (int i = num2; i + 1 < pointCount[num]; i++)
				{
					float num5 = Vector3.Distance(new Vector3(pointPos[num, i, 0], pointPos[num, i, 1], pointPos[num, i, 2]), new Vector3(pointPos[num, i + 1, 0], pointPos[num, i + 1, 1], pointPos[num, i + 1, 2]));
					num4 += num5;
					if (num4 <= GivenDistance)
					{
						num3 = num4;
						continue;
					}
					float num6 = GivenDistance - num3;
					Vector3 vector = new Vector3(pointPos[num, i, 0], pointPos[num, i, 1], pointPos[num, i, 2]);
					Vector3 vector2 = new Vector3(pointPos[num, i + 1, 0], pointPos[num, i + 1, 1], pointPos[num, i + 1, 2]);
					Vector3 vector3 = new Vector3(vector2.x - vector.x, vector2.y - vector.y, vector2.z - vector.z);
					vector3.Normalize();
					Vector3 vector4 = vector + vector3 * num6;
					array[0] = vector4;
					array[2] = vector;
					array[3] = vector2;
					if (i - 1 >= 0)
					{
						array[1] = new Vector3(pointPos[num, i - 1, 0], pointPos[num, i - 1, 1], pointPos[num, i - 1, 2]);
					}
					else
					{
						array2 = findPathBasedInput(num, true, side);
						if (array2[0] != -1)
						{
							int num7 = -1;
							num7 = ((array2[1] != 0) ? (array2[1] - 1) : array2[1]);
							array[1].x = pointPos[array2[0], num7, 0];
							array[1].y = pointPos[array2[0], num7, 1];
							array[1].z = pointPos[array2[0], num7, 2];
						}
						else
						{
							array[1] = vector - vector3 * (num6 * 2f);
						}
					}
					if (i + 2 < pointCount[num])
					{
						array[4] = new Vector3(pointPos[num, i + 2, 0], pointPos[num, i + 2, 1], pointPos[num, i + 2, 2]);
					}
					else
					{
						array2 = findPathBasedInput(num, false, side);
						if (array2[0] != -1)
						{
							int num8 = -1;
							num8 = ((array2[1] != 0) ? (array2[1] - 1) : array2[1]);
							array[4].x = pointPos[array2[0], num8, 0];
							array[4].y = pointPos[array2[0], num8, 1];
							array[4].z = pointPos[array2[0], num8, 2];
						}
						else
						{
							array[4] = vector2 + vector3 * (num6 * 2f);
						}
					}
					flag2 = true;
					break;
				}
				if (flag2)
				{
					continue;
				}
				Vector3 zero = Vector3.zero;
				Vector3 zero2 = Vector3.zero;
				zero = new Vector3(pointPos[num, num2, 0], pointPos[num, num2, 1], pointPos[num, num2, 2]);
				zero2 = ((num2 - 1 < 0) ? new Vector3(pointPos[num, num2, 0], pointPos[num, num2, 1], pointPos[num, num2, 2]) : new Vector3(pointPos[num, num2 - 1, 0], pointPos[num, num2 - 1, 1], pointPos[num, num2 - 1, 2]));
				array2 = findPathBasedInput(num, false, side);
				if (array2[0] != -1)
				{
					num = array2[0];
					flag = ((array2[1] != 0) ? true : false);
					int num9 = -1;
					int num10 = -1;
					num9 = ((array2[1] != 0) ? (array2[1] - 1) : array2[1]);
					num10 = ((array2[1] != 0) ? array2[2] : array2[2]);
					num2 = num9;
					num4 += Vector3.Distance(zero, new Vector3(pointPos[num, num9, 0], pointPos[num, num9, 1], pointPos[num, num9, 2]));
					if (num4 <= GivenDistance)
					{
						num3 = num4;
						continue;
					}
					float num11 = GivenDistance - num3;
					Vector3 vector5 = new Vector3(pointPos[num, num9, 0] - zero.x, pointPos[num, num9, 1] - zero.y, pointPos[num, num9, 2] - zero.z);
					vector5.Normalize();
					array[0] = zero + vector5 * num11;
					array[1] = zero2;
					array[2] = zero;
					array[3] = new Vector3(pointPos[num, num9, 0], pointPos[num, num9, 1], pointPos[num, num9, 2]);
					array[4] = new Vector3(pointPos[num, num10, 0], pointPos[num, num10, 1], pointPos[num, num10, 2]);
					flag2 = true;
				}
				else
				{
					float num12 = GivenDistance - num3;
					Vector3 vector6 = new Vector3(zero.x - zero2.x, zero.y - zero2.y, zero.z - zero2.z);
					vector6.Normalize();
					array[0] = zero + vector6 * num12;
					array[1] = zero2;
					array[2] = zero;
					array[3] = zero + vector6 * Vector3.Distance(zero2, zero);
					array[4] = array[3] + vector6 * Vector3.Distance(zero2, zero);
					flag2 = true;
				}
				continue;
			}
			int num13 = num2;
			while (num13 - 1 >= 0)
			{
				float num14 = Vector3.Distance(new Vector3(pointPos[num, num13, 0], pointPos[num, num13, 1], pointPos[num, num13, 2]), new Vector3(pointPos[num, num13 - 1, 0], pointPos[num, num13 - 1, 1], pointPos[num, num13 - 1, 2]));
				num4 += num14;
				if (num4 <= GivenDistance)
				{
					num3 = num4;
					num13--;
					continue;
				}
				float num15 = GivenDistance - num3;
				Vector3 vector7 = new Vector3(pointPos[num, num13, 0], pointPos[num, num13, 1], pointPos[num, num13, 2]);
				Vector3 vector8 = new Vector3(pointPos[num, num13 - 1, 0], pointPos[num, num13 - 1, 1], pointPos[num, num13 - 1, 2]);
				Vector3 vector9 = new Vector3(vector8.x - vector7.x, vector8.y - vector7.y, vector8.z - vector7.z);
				vector9.Normalize();
				Vector3 vector10 = vector7 + vector9 * num15;
				array[0] = vector10;
				array[2] = vector7;
				array[3] = vector8;
				if (num13 + 1 < pointCount[num])
				{
					array[1] = new Vector3(pointPos[num, num13, 0], pointPos[num, num13, 1], pointPos[num, num13, 2]);
				}
				else
				{
					array2 = findPathBasedInput(num, false, side);
					int num16 = -1;
					num16 = ((array2[1] != 0) ? (array2[1] - 1) : array2[1]);
					if (array2[0] != -1)
					{
						array[1].x = pointPos[array2[0], num16, 0];
						array[1].y = pointPos[array2[0], num16, 1];
						array[1].z = pointPos[array2[0], num16, 2];
					}
					else
					{
						array[1] = vector7 - vector9 * (num15 * 2f);
					}
				}
				if (num13 - 2 >= 0)
				{
					array[4] = new Vector3(pointPos[num, num13 - 2, 0], pointPos[num, num13 - 2, 1], pointPos[num, num13 - 2, 2]);
				}
				else
				{
					array2 = findPathBasedInput(num, true, side);
					int num17 = -1;
					num17 = ((array2[1] != 0) ? (array2[1] - 1) : array2[1]);
					if (array2[0] != -1)
					{
						array[4].x = pointPos[array2[0], num17, 0];
						array[4].y = pointPos[array2[0], num17, 1];
						array[4].z = pointPos[array2[0], num17, 2];
					}
					else
					{
						array[4] = vector8 + vector9 * (num15 * 2f);
					}
				}
				flag2 = true;
				break;
			}
			if (flag2)
			{
				continue;
			}
			Vector3 zero3 = Vector3.zero;
			Vector3 zero4 = Vector3.zero;
			zero3 = new Vector3(pointPos[num, num2, 0], pointPos[num, num2, 1], pointPos[num, num2, 2]);
			zero4 = new Vector3(pointPos[num, num2 + 1, 0], pointPos[num, num2 + 1, 1], pointPos[num, num2 + 1, 2]);
			array2 = findPathBasedInput(num, true, side);
			if (array2[0] != -1)
			{
				num = array2[0];
				flag = ((array2[1] != 0) ? true : false);
				int num18 = -1;
				int num19 = -1;
				num18 = ((array2[1] != 0) ? (array2[1] - 1) : array2[1]);
				num19 = ((array2[1] != 0) ? array2[2] : array2[2]);
				num2 = num18;
				num4 += Vector3.Distance(zero3, new Vector3(pointPos[num, num18, 0], pointPos[num, num18, 1], pointPos[num, num18, 2]));
				if (num4 <= GivenDistance)
				{
					num3 = num4;
					continue;
				}
				float num20 = GivenDistance - num3;
				Vector3 vector11 = new Vector3(pointPos[num, num18, 0] - zero3.x, pointPos[num, num18, 1] - zero3.y, pointPos[num, num18, 2] - zero3.z);
				vector11.Normalize();
				array[0] = zero3 + vector11 * num20;
				array[1] = zero4;
				array[2] = zero3;
				array[3] = new Vector3(pointPos[num, num18, 0], pointPos[num, num18, 1], pointPos[num, num18, 2]);
				array[4] = new Vector3(pointPos[num, num19, 0], pointPos[num, num19, 1], pointPos[num, num19, 2]);
				flag2 = true;
			}
			else
			{
				float num21 = GivenDistance - num3;
				Vector3 vector12 = new Vector3(zero3.x - zero4.x, zero3.y - zero4.y, zero3.z - zero4.z);
				vector12.Normalize();
				array[0] = zero3 + vector12 * num21;
				array[1] = zero4;
				array[2] = zero3;
				array[3] = zero3 + vector12 * Vector3.Distance(zero4, zero3);
				array[4] = array[3] + vector12 * Vector3.Distance(zero4, zero3);
				flag2 = true;
			}
		}
		return array;
	}

	public Vector3 DeviceCoordinatesToGraphCoordinates(Vector3 deviceCoorinates, float devicewidth, float deviceHeight)
	{
		float num = 2f * deviceCoorinates.x / devicewidth;
		num = -1f + num;
		float num2 = 2f * deviceCoorinates.y / deviceHeight;
		num2 = -1f + num2;
		return new Vector3(num, num2, 0f);
	}

	public Vector3[] TarPosFindngfrKickThrowObjBasedDist(int curPathID, int StartingPosID, float GivenDistance, bool TraverseReverse, int side)
	{
		if (side != 1 && side != 2)
		{
			side = 0;
		}
		int num = curPathID;
		int num2 = StartingPosID;
		bool flag = TraverseReverse;
		Vector3[] array = new Vector3[5];
		int[] array2 = new int[6];
		bool flag2 = false;
		float num3 = 0f;
		float num4 = 0f;
		Vector3 vector = Vector3.zero;
		Vector3 vector2 = Vector3.zero;
		while (!flag2)
		{
			if (!flag)
			{
				for (int i = num2; i + 1 < pointCount[num]; i++)
				{
					float num5 = Vector3.Distance(new Vector3(pointPos[num, i, 0], pointPos[num, i, 1], pointPos[num, i, 2]), new Vector3(pointPos[num, i + 1, 0], pointPos[num, i + 1, 1], pointPos[num, i + 1, 2]));
					num4 += num5;
					vector = new Vector3(pointPos[num, i + 1, 0], pointPos[num, i + 1, 1], pointPos[num, i + 1, 2]);
					vector2 = new Vector3(pointPos[num, i, 0], pointPos[num, i, 1], pointPos[num, i, 2]);
					if (num4 < GivenDistance)
					{
						num3 = num4;
						continue;
					}
					float num6 = GivenDistance - num3;
					Vector3 vector3 = new Vector3(pointPos[num, i, 0], pointPos[num, i, 1], pointPos[num, i, 2]);
					Vector3 vector4 = new Vector3(pointPos[num, i + 1, 0], pointPos[num, i + 1, 1], pointPos[num, i + 1, 2]);
					Vector3 vector5 = new Vector3(vector4.x - vector3.x, vector4.y - vector3.y, vector4.z - vector3.z);
					vector5.Normalize();
					Vector3 vector6 = vector3 + vector5 * num6;
					array[0] = vector6;
					array[2] = vector3;
					array[3] = vector4;
					if (i - 1 >= 0)
					{
						array[1] = new Vector3(pointPos[num, i - 1, 0], pointPos[num, i - 1, 1], pointPos[num, i - 1, 2]);
					}
					else
					{
						array2 = findPathBasedInput(num, true, side);
						if (array2[0] != -1)
						{
							int num7 = -1;
							num7 = ((array2[1] != 0) ? (array2[1] - 1) : array2[1]);
							array[1].x = pointPos[array2[0], num7, 0];
							array[1].y = pointPos[array2[0], num7, 1];
							array[1].z = pointPos[array2[0], num7, 2];
						}
						else
						{
							array[1] = vector3 - vector5 * (num6 * 2f);
						}
					}
					if (i + 2 < pointCount[num])
					{
						array[4] = new Vector3(pointPos[num, i + 2, 0], pointPos[num, i + 2, 1], pointPos[num, i + 2, 2]);
					}
					else
					{
						array2 = findPathBasedInput(num, false, side);
						if (array2[0] != -1)
						{
							int num8 = -1;
							num8 = ((array2[1] != 0) ? (array2[1] - 1) : array2[1]);
							array[4].x = pointPos[array2[0], num8, 0];
							array[4].y = pointPos[array2[0], num8, 1];
							array[4].z = pointPos[array2[0], num8, 2];
						}
						else
						{
							array[4] = vector4 + vector5 * (num6 * 2f);
						}
					}
					flag2 = true;
					break;
				}
				if (flag2)
				{
					continue;
				}
				array2 = findPathBasedInput(num, false, side);
				if (array2[0] != -1)
				{
					num = array2[0];
					flag = ((array2[1] != 0) ? true : false);
					int num9 = -1;
					int num10 = -1;
					num9 = ((array2[1] != 0) ? (array2[1] - 1) : array2[1]);
					num10 = ((array2[1] != 0) ? array2[2] : array2[2]);
					num2 = num9;
					num4 += Vector3.Distance(vector, new Vector3(pointPos[num, num9, 0], pointPos[num, num9, 1], pointPos[num, num9, 2]));
					if (num4 < GivenDistance)
					{
						num3 = num4;
						continue;
					}
					float num11 = GivenDistance - num3;
					Vector3 vector7 = new Vector3(pointPos[num, num9, 0] - vector.x, pointPos[num, num9, 1] - vector.y, pointPos[num, num9, 2] - vector.z);
					vector7.Normalize();
					array[0] = vector + vector7 * num11;
					array[1] = vector2;
					array[2] = vector;
					array[3] = new Vector3(pointPos[num, num9, 0], pointPos[num, num9, 1], pointPos[num, num9, 2]);
					array[4] = new Vector3(pointPos[num, num10, 0], pointPos[num, num10, 1], pointPos[num, num10, 2]);
					flag2 = true;
				}
				else
				{
					float num12 = GivenDistance - num3;
					Vector3 vector8 = new Vector3(vector.x - vector2.x, vector.y - vector2.y, vector.z - vector2.z);
					vector8.Normalize();
					array[0] = vector + vector8 * num12;
					array[1] = vector2;
					array[2] = vector;
					array[3] = vector + vector8 * Vector3.Distance(vector2, vector);
					array[4] = array[3] + vector8 * Vector3.Distance(vector2, vector);
					flag2 = true;
				}
				continue;
			}
			int num13 = num2;
			while (num13 - 1 >= 0)
			{
				float num14 = Vector3.Distance(new Vector3(pointPos[num, num13, 0], pointPos[num, num13, 1], pointPos[num, num13, 2]), new Vector3(pointPos[num, num13 - 1, 0], pointPos[num, num13 - 1, 1], pointPos[num, num13 - 1, 2]));
				num4 += num14;
				vector = new Vector3(pointPos[num, num13 - 1, 0], pointPos[num, num13 - 1, 1], pointPos[num, num13 - 1, 2]);
				vector2 = new Vector3(pointPos[num, num13, 0], pointPos[num, num13, 1], pointPos[num, num13, 2]);
				if (num4 < GivenDistance)
				{
					num3 = num4;
					num13--;
					continue;
				}
				float num15 = GivenDistance - num3;
				Vector3 vector9 = new Vector3(pointPos[num, num13, 0], pointPos[num, num13, 1], pointPos[num, num13, 2]);
				Vector3 vector10 = new Vector3(pointPos[num, num13 - 1, 0], pointPos[num, num13 - 1, 1], pointPos[num, num13 - 1, 2]);
				Vector3 vector11 = new Vector3(vector10.x - vector9.x, vector10.y - vector9.y, vector10.z - vector9.z);
				vector11.Normalize();
				Vector3 vector12 = vector9 + vector11 * num15;
				array[0] = vector12;
				array[2] = vector9;
				array[3] = vector10;
				if (num13 + 1 < pointCount[num])
				{
					array[1] = new Vector3(pointPos[num, num13, 0], pointPos[num, num13, 1], pointPos[num, num13, 2]);
				}
				else
				{
					array2 = findPathBasedInput(num, false, side);
					int num16 = -1;
					num16 = ((array2[1] != 0) ? (array2[1] - 1) : array2[1]);
					if (array2[0] != -1)
					{
						array[1].x = pointPos[array2[0], num16, 0];
						array[1].y = pointPos[array2[0], num16, 1];
						array[1].z = pointPos[array2[0], num16, 2];
					}
					else
					{
						array[1] = vector9 - vector11 * (num15 * 2f);
					}
				}
				if (num13 - 2 >= 0)
				{
					array[4] = new Vector3(pointPos[num, num13 - 2, 0], pointPos[num, num13 - 2, 1], pointPos[num, num13 - 2, 2]);
				}
				else
				{
					array2 = findPathBasedInput(num, true, side);
					int num17 = -1;
					num17 = ((array2[1] != 0) ? (array2[1] - 1) : array2[1]);
					if (array2[0] != -1)
					{
						array[4].x = pointPos[array2[0], num17, 0];
						array[4].y = pointPos[array2[0], num17, 1];
						array[4].z = pointPos[array2[0], num17, 2];
					}
					else
					{
						array[4] = vector10 + vector11 * (num15 * 2f);
					}
				}
				flag2 = true;
				break;
			}
			if (flag2)
			{
				continue;
			}
			array2 = findPathBasedInput(num, true, side);
			if (array2[0] != -1)
			{
				num = array2[0];
				flag = ((array2[1] != 0) ? true : false);
				int num18 = -1;
				int num19 = -1;
				num18 = ((array2[1] != 0) ? (array2[1] - 1) : array2[1]);
				num19 = ((array2[1] != 0) ? array2[2] : array2[2]);
				num2 = num18;
				num4 += Vector3.Distance(vector, new Vector3(pointPos[num, num18, 0], pointPos[num, num18, 1], pointPos[num, num18, 2]));
				if (num4 < GivenDistance)
				{
					num3 = num4;
					continue;
				}
				float num20 = GivenDistance - num3;
				Vector3 vector13 = new Vector3(pointPos[num, num18, 0] - vector.x, pointPos[num, num18, 1] - vector.y, pointPos[num, num18, 2] - vector.z);
				vector13.Normalize();
				array[0] = vector + vector13 * num20;
				array[1] = vector2;
				array[2] = vector;
				array[3] = new Vector3(pointPos[num, num18, 0], pointPos[num, num18, 1], pointPos[num, num18, 2]);
				array[4] = new Vector3(pointPos[num, num19, 0], pointPos[num, num19, 1], pointPos[num, num19, 2]);
				flag2 = true;
			}
			else
			{
				float num21 = GivenDistance - num3;
				Vector3 vector14 = new Vector3(vector.x - vector2.x, vector.y - vector2.y, vector.z - vector2.z);
				vector14.Normalize();
				array[0] = vector + vector14 * num21;
				array[1] = vector2;
				array[2] = vector;
				array[3] = vector + vector14 * Vector3.Distance(vector2, vector);
				array[4] = array[3] + vector14 * Vector3.Distance(vector2, vector);
				flag2 = true;
			}
		}
		return array;
	}

	public Vector3[] findPos_FrmGivenDatas(int given_PathID, int given_StartPointID, float given_DistFrmStartPoint, bool given_TraverseReverse, ref bool bMovingBtwPaths, int given_direction = 0)
	{
		if (given_direction != 1 && given_direction != 2)
		{
			given_direction = 0;
		}
		Vector3[] array = new Vector3[5];
		int num = given_PathID;
		int num2 = given_StartPointID;
		float num3 = Mathf.Abs(given_DistFrmStartPoint);
		bool flag = given_TraverseReverse;
		int num4 = 0;
		num4 = (flag ? (pointCount[num] - num2 + 1) : (num2 + 1));
		bool flag2 = false;
		float num5 = 0f;
		float num6 = 0f;
		bool flag3 = false;
		Vector3 zero = Vector3.zero;
		Vector3 vector = Vector3.zero;
		Vector3 vector2 = Vector3.zero;
		Vector3 vector3 = Vector3.zero;
		Vector3 vector4 = Vector3.zero;
		int[] array2 = new int[6];
		while (!flag2)
		{
			if (pointCount[num] <= num4)
			{
				if (flag3)
				{
					array2 = findPathBasedInput(num, flag, given_direction);
					if (array2[0] != -1)
					{
						flag3 = false;
						num = array2[0];
						num2 = array2[1];
						if (array2[1] == 0)
						{
							flag = false;
							num4 = num2 + 1;
						}
						else
						{
							flag = true;
							num4 = pointCount[num] - num2 + 1;
						}
					}
				}
				else
				{
					flag3 = true;
					if (!flag)
					{
						vector2 = new Vector3(pointPos[num, num2, 0], pointPos[num, num2, 1], pointPos[num, num2, 2]);
						vector = new Vector3(pointPos[num, num2 - 1, 0], pointPos[num, num2 - 1, 1], pointPos[num, num2 - 1, 2]);
					}
					else
					{
						vector2 = new Vector3(pointPos[num, 0, 0], pointPos[num, 0, 1], pointPos[num, 0, 2]);
						vector = new Vector3(pointPos[num, 1, 0], pointPos[num, 1, 1], pointPos[num, 1, 2]);
					}
					array2 = findPathBasedInput(num, flag, given_direction);
					if (array2[0] != -1)
					{
						int num7 = -1;
						int num8 = -1;
						if (array2[1] == 0)
						{
							num7 = array2[1];
							num8 = array2[1] + 1;
						}
						else
						{
							num7 = array2[1] - 1;
							num8 = array2[1] - 2;
						}
						vector3 = new Vector3(pointPos[array2[0], num7, 0], pointPos[array2[0], num7, 1], pointPos[array2[0], num7, 2]);
						vector4 = new Vector3(pointPos[array2[0], num8, 0], pointPos[array2[0], num8, 1], pointPos[array2[0], num8, 2]);
					}
					else
					{
						float x = vector2.x - vector.x;
						float y = vector2.y - vector.y;
						float z = vector2.z - vector.z;
						Vector3 vector5 = new Vector3(x, y, z);
						vector5.Normalize();
						float num9 = Vector3.Distance(vector2, vector);
						vector3 = vector2 + vector5 * num9;
						vector4 = vector2 + vector5 * num9 * 2f;
					}
				}
			}
			if (!flag3)
			{
				if (!flag)
				{
					vector2.x = pointPos[num, num2, 0];
					vector2.y = pointPos[num, num2, 1];
					vector2.z = pointPos[num, num2, 2];
					vector3.x = pointPos[num, num2 + 1, 0];
					vector3.y = pointPos[num, num2 + 1, 1];
					vector3.z = pointPos[num, num2 + 1, 2];
					if (num2 == 0)
					{
						array2 = findPathBasedInput(num, true, 0);
						if (array2[0] != -1)
						{
							int num10 = -1;
							num10 = ((array2[1] != 0) ? (array2[1] - 1) : array2[1]);
							vector.x = pointPos[array2[0], num10, 0];
							vector.y = pointPos[array2[0], num10, 1];
							vector.z = pointPos[array2[0], num10, 2];
						}
						else
						{
							float x2 = vector3.x - vector2.x;
							float y2 = vector3.y - vector2.y;
							float z2 = vector3.z - vector2.z;
							Vector3 vector6 = new Vector3(x2, y2, z2);
							vector6.Normalize();
							float num11 = Vector3.Distance(vector2, vector3);
							vector = vector2 - vector6 * num11;
						}
						vector4.x = pointPos[num, num2 + 2, 0];
						vector4.y = pointPos[num, num2 + 2, 1];
						vector4.z = pointPos[num, num2 + 2, 2];
					}
					else
					{
						vector.x = pointPos[num, num2 - 1, 0];
						vector.y = pointPos[num, num2 - 1, 1];
						vector.z = pointPos[num, num2 - 1, 2];
						if (num2 + 2 < pointCount[num])
						{
							vector4.x = pointPos[num, num2 + 2, 0];
							vector4.y = pointPos[num, num2 + 2, 1];
							vector4.z = pointPos[num, num2 + 2, 2];
						}
						else
						{
							array2 = findPathBasedInput(num, false, 0);
							if (array2[0] != -1)
							{
								int num12 = -1;
								num12 = ((array2[1] != 0) ? (array2[1] - 1) : array2[1]);
								vector4.x = pointPos[array2[0], num12, 0];
								vector4.y = pointPos[array2[0], num12, 1];
								vector4.z = pointPos[array2[0], num12, 2];
							}
							else
							{
								float x3 = vector3.x - vector2.x;
								float y3 = vector3.y - vector2.y;
								float z3 = vector3.z - vector2.z;
								Vector3 vector7 = new Vector3(x3, y3, z3);
								vector7.Normalize();
								float num13 = Vector3.Distance(vector2, vector3);
								vector4 = vector3 + vector7 * num13;
							}
						}
					}
				}
				else
				{
					vector2.x = pointPos[num, num2 - 1, 0];
					vector2.y = pointPos[num, num2 - 1, 1];
					vector2.z = pointPos[num, num2 - 1, 2];
					vector3.x = pointPos[num, num2 - 2, 0];
					vector3.y = pointPos[num, num2 - 2, 1];
					vector3.z = pointPos[num, num2 - 2, 2];
					if (pointCount[num] == num2)
					{
						array2 = findPathBasedInput(num, false, 0);
						if (array2[0] != -1)
						{
							int num14 = -1;
							num14 = ((array2[1] != 0) ? (array2[1] - 1) : array2[1]);
							vector.x = pointPos[array2[0], num14, 0];
							vector.y = pointPos[array2[0], num14, 1];
							vector.z = pointPos[array2[0], num14, 2];
						}
						else
						{
							float x4 = vector3.x - vector2.x;
							float y4 = vector3.y - vector2.y;
							float z4 = vector3.z - vector2.z;
							Vector3 vector8 = new Vector3(x4, y4, z4);
							vector8.Normalize();
							float num15 = Vector3.Distance(vector2, vector3);
							vector = vector2 - vector8 * num15;
						}
						vector4.x = pointPos[num, num2 - 3, 0];
						vector4.y = pointPos[num, num2 - 3, 1];
						vector4.z = pointPos[num, num2 - 3, 2];
					}
					else
					{
						vector.x = pointPos[num, num2, 0];
						vector.y = pointPos[num, num2, 1];
						vector.z = pointPos[num, num2, 2];
						if (num2 - 3 > 0)
						{
							vector4.x = pointPos[num, num2 - 3, 0];
							vector4.y = pointPos[num, num2 - 3, 1];
							vector4.z = pointPos[num, num2 - 3, 2];
						}
						else
						{
							array2 = findPathBasedInput(num, true, 0);
							if (array2[0] != -1)
							{
								int num16 = -1;
								num16 = ((array2[1] != 0) ? (array2[1] - 1) : array2[1]);
								vector4.x = pointPos[array2[0], num16, 0];
								vector4.y = pointPos[array2[0], num16, 1];
								vector4.z = pointPos[array2[0], num16, 2];
							}
							else
							{
								float x5 = vector3.x - vector2.x;
								float y5 = vector3.y - vector2.y;
								float z5 = vector3.z - vector2.z;
								Vector3 vector9 = new Vector3(x5, y5, z5);
								vector9.Normalize();
								float num17 = Vector3.Distance(vector2, vector3);
								vector4 = vector3 + vector9 * num17 * 2f;
							}
						}
					}
				}
				num4++;
				num2 = (flag ? (num2 - 1) : (num2 + 1));
			}
			float num18 = Vector3.Distance(vector2, vector3);
			num6 += num18;
			if (num6 <= num3)
			{
				num5 = num6;
				continue;
			}
			float num19 = num3 - num5;
			Vector3 vector10 = new Vector3(vector3.x - vector2.x, vector3.y - vector2.y, vector3.z - vector2.z);
			vector10.Normalize();
			zero = vector2 + vector10 * num19;
			array[0] = zero;
			flag2 = true;
		}
		array[1] = vector;
		array[2] = vector2;
		array[3] = vector3;
		array[4] = vector4;
		bMovingBtwPaths = flag3;
		return array;
	}

	public float GetAnimSpeedBasedNormalizeTime(int HumanAnimationState, float fNorTime)
	{
		if (fNorTime > 1f)
		{
			fNorTime = 1f;
		}
		fNorTime = Mathf.Round(fNorTime * 10f);
		fNorTime -= 1f;
		if (fNorTime < 0f)
		{
			fNorTime = 0f;
		}
		float[] array = new float[10];
		if (AnimationCurvesSpeed[HumanAnimationState] == null)
		{
			HumanAnimationState = 0;
		}
		string text = AnimationCurvesSpeed[HumanAnimationState];
		string[] array2 = text.Split('~');
		for (int i = 0; i < 10; i++)
		{
			array[i] = float.Parse(array2[i]);
		}
		return array[(int)fNorTime];
	}

	private string getDynamicObjDatasBasedonObjIndex(int index)
	{
		string text = "null";
		for (int i = IGT_FileReading.nobjLen - IGT_Constants.nNoOfMovingObj - IGT_Constants.nNoOfSplPowers; i < IGT_FileReading.nobjLen - IGT_Constants.nNoOfSplPowers; i++)
		{
			text = IGT_FileReading.data[i];
			string[] array = text.Split('~');
			int num = int.Parse(array[1]);
			if (num == index)
			{
				return text;
			}
		}
		for (int j = pObj.staticObj_TotalDetails.Count; j < IGT_FileReading.nobjLen - IGT_Constants.nNoOfMovingObj - IGT_Constants.nNoOfEnergyItems - IGT_Constants.nNoOfSplPowers; j++)
		{
			text = IGT_FileReading.data[j];
			string[] array = text.Split('~');
			int num = int.Parse(array[1]);
			if (num == index)
			{
				return text;
			}
		}
		return text;
	}

	private int patternIDselectionMethod(int difficulty, int pathid)
	{
		int num = UnityEngine.Random.Range(0, pIGT_PatternDataLoading.nTotalPatternCount);
		int num2 = 0;
		while (!isSelectedPatternCanPlace(pathid, num) && num2 < 25)
		{
			num = UnityEngine.Random.Range(0, pIGT_PatternDataLoading.nTotalPatternCount);
			num2++;
		}
		return num;
	}

	public void patternBasedDynamicObjPlacement()
	{
		for (int i = 0; i < nPatternPlacedCount; i++)
		{
			int num = nPatternPlacementDetails[i, 0];
			int num2 = nPatternPlacementDetails[i, 1];
			int num3 = nPatternPlacementDetails[i, 2];
			float num4 = nPatternPlacementDetails[i, 3];
			float num5 = num3 / (pIGT_PatternDataLoading.nPatternParams[num2][0] - 1);
			int num6 = -1;
			for (int j = 0; j < pIGT_PatternDataLoading.nPatternDatas[num2].Length; j++)
			{
				if (j != 0)
				{
					num4 += num5;
				}
				num6 = -1;
				for (int k = 0; k < pIGT_PatternDataLoading.nPatternDatas[num2][j].Length; k++)
				{
					int num7 = pIGT_PatternDataLoading.nPatternDatas[num2][j][k];
					if (num7 != num6 && num7 != -1)
					{
						if (num7.ToString().Length == 3)
						{
							string dynamicObjDatasBasedonObjIndex = getDynamicObjDatasBasedonObjIndex(num7);
							string[] array = dynamicObjDatasBasedonObjIndex.Split('~');
							int objplceTyp = int.Parse(array[0]);
							int obId = int.Parse(array[1]);
							int num8 = int.Parse(array[2]);
							string obName = array[3];
							float num9 = float.Parse(array[4]);
							float wid = float.Parse(array[5]);
							float hei = float.Parse(array[6]);
							float hei2 = float.Parse(array[7]);
							bool disabled = false;
							float timeSinceLevelLoad = Time.timeSinceLevelLoad;
							bool plyrcrsd = false;
							float mindist;
							float lfeTme;
							if (num8 == 3)
							{
								mindist = 3f;
								lfeTme = 5f;
							}
							else
							{
								mindist = float.Parse(array[8]);
								lfeTme = float.Parse(array[9]);
							}
							float num10 = patternBasedOffsetSel(num8, num9, num, k);
							Vector3 pos = findPos(num, num4, num10);
							Vector3 rot = findRotation(posFrFndngRot, prevPosFrFndngRot);
							pObj.objFrDraw.Add(new IGT_ObjInfo(objplceTyp, num, num4, num10, pos, rot, obId, num8, obName, num9, wid, hei, hei2, plyrcrsd, timeSinceLevelLoad, lfeTme, mindist, disabled));
						}
						else if (num7.ToString().Length == 2)
						{
							pObj.patternBasedTrapItemsDetails.Add(new IGT_ObjInfo(num7, num, num4, k));
						}
					}
					num6 = num7;
				}
			}
		}
	}

	private void patternBased_TrapItems_Placement(int pid, int objTypId)
	{
		for (int i = 0; i < pObj.patternBasedTrapItemsDetails.Count; i++)
		{
			if (pObj.patternBasedTrapItemsDetails.ElementAt(i).nPathId != pid || pObj.patternBasedTrapItemsDetails.ElementAt(i).objPlaceType != objTypId)
			{
				continue;
			}
			float timeSinceLevelLoad = Time.timeSinceLevelLoad;
			bool flag = false;
			bool flag2 = false;
			switch (pObj.patternBasedTrapItemsDetails.ElementAt(i).objPlaceType)
			{
			case 20:
			{
				bool flag3 = false;
				for (int k = 0; k < pObj.splPowersObj_PlacedDetails.Count; k++)
				{
					if (pObj.splPowersObj_PlacedDetails[k].nPathId == pObj.patternBasedTrapItemsDetails.ElementAt(i).nPathId && Mathf.Abs(pObj.patternBasedTrapItemsDetails.ElementAt(i).fDistFrmStrtPnt - pObj.splPowersObj_PlacedDetails[k].fDistFrmStrtPnt) < 10f)
					{
						flag3 = true;
						break;
					}
				}
				if (!flag3 && UnityEngine.Random.Range(0, 100) < IGT_Constants.nSplPowers_PlacingProb)
				{
					int num7 = specialPowerObjIndexSeletion(pObj.patternBasedTrapItemsDetails.ElementAt(i).nPathId);
					string text = IGT_FileReading.data[num7];
					string[] array = text.Split('~');
					int objplceTyp = int.Parse(array[0]);
					int obId = int.Parse(array[1]);
					int num = int.Parse(array[2]);
					string obName = array[3];
					float num2 = float.Parse(array[4]);
					float wid = float.Parse(array[5]);
					float hei = float.Parse(array[6]);
					float hei2 = float.Parse(array[7]);
					float mindist = float.Parse(array[8]);
					flag = false;
					flag2 = false;
					timeSinceLevelLoad = Time.timeSinceLevelLoad;
					float lfeTme = float.Parse(array[9]);
					float num3 = patternBasedOffsetSel(num, num2, pObj.patternBasedTrapItemsDetails.ElementAt(i).nPathId, (int)pObj.patternBasedTrapItemsDetails.ElementAt(i).fOffset);
					Vector3 pos = findPos(pid, pObj.patternBasedTrapItemsDetails.ElementAt(i).fDistFrmStrtPnt, num3);
					Vector3 rot = findRotation(posFrFndngRot, prevPosFrFndngRot);
					pObj.splPowersObj_PlacedDetails.Add(new IGT_ObjInfo(objplceTyp, pObj.patternBasedTrapItemsDetails.ElementAt(i).nPathId, pObj.patternBasedTrapItemsDetails.ElementAt(i).fDistFrmStrtPnt, num3, pos, rot, obId, num, obName, num2, wid, hei, hei2, flag, timeSinceLevelLoad, lfeTme, mindist, flag2));
				}
				break;
			}
			case 10:
			{
				int objplceTyp = 1;
				int num = -1;
				string obName = "null";
				float num2 = 0.4f;
				float wid = 0.25f;
				float hei = 0.35f;
				float hei2 = 0.25f;
				flag = false;
				flag2 = false;
				timeSinceLevelLoad = Time.deltaTime;
				float lfeTme = 2f;
				int obId = IGT_GameView.pHero.pMissionData.nCollectionInnerItemType;
				float mindist = 1.5f;
				float num3 = patternBasedOffsetSel(num, num2, pObj.patternBasedTrapItemsDetails.ElementAt(i).nPathId, (int)pObj.patternBasedTrapItemsDetails.ElementAt(i).fOffset);
				Vector3 pos = findPos(pid, pObj.patternBasedTrapItemsDetails.ElementAt(i).fDistFrmStrtPnt, num3);
				Vector3 rot = findRotation(posFrFndngRot, prevPosFrFndngRot);
				int num4 = IGT_Constants.nCollItemPlacingProb;
				if (IGT_GameView.pHero.pMissionData.nMissionType == 0)
				{
					obId = IGT_GameView.pHero.pMissionData.nCollectionInnerItemType;
					mindist = IGT_Constants.fMinDistBtwCollectionItems;
					num4 = IGT_Constants.nCollItemPlacingProb;
				}
				else if (IGT_GameView.pHero.pMissionData.nMissionType == 5)
				{
					int num5 = 0;
					int num6 = UnityEngine.Random.Range(0, 100);
					for (int j = 0; j < IGT_GameView.pHero.pMissionData.nNumOfMultipleCollection; j++)
					{
						num5 += IGT_GameView.pHero.pMissionData.nMultipleCollectionDatas[j, 1];
						if (num5 >= num6)
						{
							obId = IGT_GameView.pHero.pMissionData.nMultipleCollectionDatas[j, 0];
							mindist = IGT_GameView.pHero.pMissionData.nMultipleCollectionDatas[j, 3];
							num4 = IGT_GameView.pHero.pMissionData.nMultipleCollectionDatas[j, 4];
							break;
						}
					}
				}
				if (UnityEngine.Random.Range(0, 100) < num4)
				{
					pObj.missionObj_PlacedDetails.Add(new IGT_ObjInfo(objplceTyp, pObj.patternBasedTrapItemsDetails.ElementAt(i).nPathId, pObj.patternBasedTrapItemsDetails.ElementAt(i).fDistFrmStrtPnt, num3, pos, rot, obId, num, obName, num2, wid, hei, hei2, flag, timeSinceLevelLoad, lfeTme, mindist, flag2));
				}
				break;
			}
			}
		}
	}

	public float patternBasedOffsetSel(int Objtyp, float objLen, int pId, int offsetPatternID)
	{
		float num = 0f;
		float num2 = 0f;
		switch (Objtyp)
		{
		case 4:
			num = fTotalOffsetDeviation + 0.15f;
			break;
		case 6:
			num = fTotalOffsetDeviation + 0.1f;
			break;
		case -1:
		case 9:
			num = fTotalOffsetDeviation;
			break;
		default:
			num = pathWidth[pId] / 2f * 0.7f;
			break;
		}
		switch (offsetPatternID)
		{
		case 0:
			num2 = 0f - num;
			break;
		case 2:
			num2 = num;
			break;
		default:
			num2 = 0f;
			break;
		}
		if (Objtyp == -1 || Objtyp == 9)
		{
			return num2;
		}
		if (num2 < 0f)
		{
			float num3 = num2 - objLen / 2f;
			if (num3 < 0f - num)
			{
				float num4 = num3 + num;
				num2 -= num4;
			}
		}
		else if (num2 > 0f)
		{
			float num5 = num2 + objLen / 2f;
			if (num5 > num)
			{
				float num6 = num5 - num;
				num2 -= num6;
			}
		}
		return num2;
	}

	private bool isSelectedPatternColllidedWithAlreadyPlacedObjects(int pathID, float strtDist, float endDist)
	{
		bool result = false;
		List<IGT_ObjInfo> list = objDetInGivenPath(pathID);
		for (int i = 0; i < list.Count; i++)
		{
			float num = list[i].fDistFrmStrtPnt - list[i].fWidth / 2f;
			float num2 = list[i].fDistFrmStrtPnt + list[i].fWidth / 2f;
			if ((strtDist > num && strtDist < num2) || (list[i].fDistFrmStrtPnt > strtDist && list[i].fDistFrmStrtPnt < endDist) || (list[i].fDistFrmStrtPnt + list[i].fWidth / 2f > strtDist && list[i].fDistFrmStrtPnt + list[i].fWidth / 2f < endDist) || (list[i].fDistFrmStrtPnt - list[i].fWidth / 2f > strtDist && list[i].fDistFrmStrtPnt - list[i].fWidth / 2f < endDist))
			{
				result = true;
				break;
			}
		}
		return result;
	}

	public bool isSelectedObjColllidedWithAlreadyPlacedPattern(int pathID, float ObjDistFrmStart, float ObjWid, float minDist)
	{
		bool result = false;
		for (int i = 0; i < nPatternPlacedCount; i++)
		{
			if (nPatternPlacementDetails[i, 0] == pathID)
			{
				if (ObjDistFrmStart + minDist + ObjWid / 2f > (float)nPatternPlacementDetails[i, 3] && ObjDistFrmStart + minDist + ObjWid / 2f < (float)nPatternPlacementDetails[i, 4])
				{
					result = true;
					break;
				}
				if (ObjDistFrmStart - minDist - ObjWid / 2f > (float)nPatternPlacementDetails[i, 3] && ObjDistFrmStart - minDist - ObjWid / 2f < (float)nPatternPlacementDetails[i, 4])
				{
					result = true;
					break;
				}
			}
		}
		return result;
	}

	private bool isSelectedPatternCanPlace(int pathId, int patternID)
	{
		bool result = true;
		bool flag = false;
		for (int i = 0; i < pIGT_PatternDataLoading.nPatternDatas[patternID].Length; i++)
		{
			for (int j = 0; j < pIGT_PatternDataLoading.nPatternDatas[patternID][i].Length; j++)
			{
				int num = pIGT_PatternDataLoading.nPatternDatas[patternID][i][j];
				num /= 100;
				if (num == 4)
				{
					flag = true;
					break;
				}
			}
		}
		if (flag && (path_Shape_Type[pathId] == 0 || path_Shape_Type[pathId] == 2))
		{
			result = false;
		}
		return result;
	}
}
