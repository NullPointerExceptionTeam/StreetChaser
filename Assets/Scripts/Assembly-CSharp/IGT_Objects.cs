using System.Collections.Generic;
using UnityEngine;

public class IGT_Objects
{
	public List<IGT_ObjInfo> staticObj_TotalDetails;

	public List<IGT_ObjInfo> staticObj_PlacedDetails;

	public List<IGT_ObjInfo> objFrDraw;

	public List<IGT_ObjInfo> movingObj;

	public List<IGT_ObjInfo> pCoinDatas;

	public List<IGT_ObjInfo> missionObj_PlacedDetails;

	public List<IGT_ObjInfo> splPowersObj_PlacedDetails;

	public List<IGT_ObjInfo> patternBasedTrapItemsDetails;

	public IGT_ObjInfo[] obj;

	public List<IGT_ObjInfo> ObjListInCurPathOfHero;

	public GameObject[] StaticGameObjectsArray;

	public int[] nNoOfStaticObjInEachPath;

	public IGT_LineVector[] playerLines;

	public int[,] DynamicObjIndexBasedProbability = new int[IGT_Constants.OBJMAXSIZE, 4];

	public int[,] StaticObjIndexBasedProbability = new int[IGT_Constants.OBJMAXSIZE, 4];

	public int[,] CoinObjIndexBasedProbability = new int[IGT_Constants.OBJMAXSIZE, 4];

	public int[,] specialPowersIndexBasedProbability = new int[IGT_Constants.OBJMAXSIZE, 4];

	public int nPathID;

	public int nTotObjinCurPath;

	private Vector3 minBound;

	private Vector3 maxBound;

	public static int kickObj_InstanceID = -1;

	public int kickObjId = -1;

	public int PickObjId = -1;

	public float fDistfrmPlyrTo_KickObj;

	public float fDistfrmPlyrTo_pickObj;

	public static Vector3 ThrowObj_Placed_Pos = Vector3.zero;

	public static int PickedObj_InstanceID = -1;

	public IGT_Objects()
	{
		objFrDraw = new List<IGT_ObjInfo>();
		obj = new IGT_ObjInfo[IGT_Constants.OBJMAXSIZE];
		staticObj_PlacedDetails = new List<IGT_ObjInfo>();
		staticObj_TotalDetails = new List<IGT_ObjInfo>();
		movingObj = new List<IGT_ObjInfo>();
		pCoinDatas = new List<IGT_ObjInfo>();
		missionObj_PlacedDetails = new List<IGT_ObjInfo>();
		splPowersObj_PlacedDetails = new List<IGT_ObjInfo>();
		patternBasedTrapItemsDetails = new List<IGT_ObjInfo>();
		playerLines = new IGT_LineVector[4];
		nTotObjinCurPath = 0;
	}

	public int CheckCollisions(float PlayerdistFrmStrtPnt, Vector3 playerPos, float offset, bool TravRev, float TotPathLength, float playerSpd)
	{
		float num = 0f;
		if (TravRev)
		{
			offset = 0f - offset;
		}
		int num2 = -1;
		float num3 = -1f;
		for (int i = 0; i < ObjListInCurPathOfHero.Count; i++)
		{
			num = (TravRev ? (TotPathLength - ObjListInCurPathOfHero[i].fDistFrmStrtPnt) : ObjListInCurPathOfHero[i].fDistFrmStrtPnt);
			if (ObjListInCurPathOfHero[i].objPlaceType == 1 && ObjListInCurPathOfHero[i].objType == 4 && !ObjListInCurPathOfHero[i].bplyrCrsd)
			{
				if (num + 0.15f >= PlayerdistFrmStrtPnt)
				{
					if (nPathID == ObjListInCurPathOfHero[i].nPathId && offset >= ObjListInCurPathOfHero[i].fOffset - ObjListInCurPathOfHero[i].fLength / 2f - IGT_Constants.HeroWidth && offset <= ObjListInCurPathOfHero[i].fOffset + ObjListInCurPathOfHero[i].fLength / 2f + IGT_Constants.HeroWidth && PlayerdistFrmStrtPnt <= num + 0.15f && PlayerdistFrmStrtPnt >= num - 4f)
					{
						kickObjId = i;
						fDistfrmPlyrTo_KickObj = num - PlayerdistFrmStrtPnt;
						return 4;
					}
				}
				else
				{
					ObjListInCurPathOfHero[i].bplyrCrsd = true;
					IGT_Hero.bKickWithinAnimRange = false;
					IGT_Hero.bKickAnimCanEnable = false;
				}
			}
			else if (ObjListInCurPathOfHero[i].objPlaceType == 1 && ObjListInCurPathOfHero[i].objType == 6 && !ObjListInCurPathOfHero[i].bplyrCrsd)
			{
				if (num + 0.15f >= PlayerdistFrmStrtPnt)
				{
					if (nPathID == ObjListInCurPathOfHero[i].nPathId && offset >= ObjListInCurPathOfHero[i].fOffset - ObjListInCurPathOfHero[i].fLength / 2f - IGT_Constants.HeroWidth && offset <= ObjListInCurPathOfHero[i].fOffset + ObjListInCurPathOfHero[i].fLength / 2f + IGT_Constants.HeroWidth && PlayerdistFrmStrtPnt <= num + 0.1f && PlayerdistFrmStrtPnt >= num - 0.75f)
					{
						PickObjId = i;
						fDistfrmPlyrTo_pickObj = num - PlayerdistFrmStrtPnt;
						return 6;
					}
				}
				else
				{
					ObjListInCurPathOfHero[i].bplyrCrsd = true;
				}
			}
			else if (ObjListInCurPathOfHero[i].objPlaceType == 0 && !ObjListInCurPathOfHero[i].bplyrCrsd)
			{
				if (num + ObjListInCurPathOfHero[i].fWidth / 2f >= PlayerdistFrmStrtPnt)
				{
					if (nPathID == ObjListInCurPathOfHero[i].nPathId && offset >= ObjListInCurPathOfHero[i].fOffset - ObjListInCurPathOfHero[i].fLength / 2f && offset <= ObjListInCurPathOfHero[i].fOffset + ObjListInCurPathOfHero[i].fLength / 2f && PlayerdistFrmStrtPnt <= num - 0.25f + ObjListInCurPathOfHero[i].fWidth / 2f && PlayerdistFrmStrtPnt >= num + 0.25f - ObjListInCurPathOfHero[i].fWidth / 2f && playerPos.y + ObjListInCurPathOfHero[i].fHeight >= IGT_AnimStatesCntrler.fjmpFeetPosFrPit && ObjListInCurPathOfHero[i].objType == 2 && !ObjListInCurPathOfHero[i].bDisabled)
					{
						return 2;
					}
				}
				else
				{
					ObjListInCurPathOfHero[i].bplyrCrsd = true;
				}
			}
			if (IGT_GameView.pHero.nGameMode != 1)
			{
				continue;
			}
			if (IGT_GameView.pHero.pMissionData.nMissionType == 0)
			{
				if (nPathID == ObjListInCurPathOfHero[i].nPathId && ObjListInCurPathOfHero[i].objPlaceType == 1 && ObjListInCurPathOfHero[i].objType == -1 && !ObjListInCurPathOfHero[i].bplyrCrsd && PlayerdistFrmStrtPnt <= num + ObjListInCurPathOfHero[i].fWidth / 2f && PlayerdistFrmStrtPnt >= num - ObjListInCurPathOfHero[i].fWidth / 2f)
				{
					if (ObjListInCurPathOfHero[i].nPathId != num2 || ObjListInCurPathOfHero[i].fDistFrmStrtPnt != num3)
					{
						IGT_GameView.pHero.nNoOfCollectionObjHeroCrossed++;
						num2 = ObjListInCurPathOfHero[i].nPathId;
						num3 = ObjListInCurPathOfHero[i].fDistFrmStrtPnt;
					}
					ObjListInCurPathOfHero[i].bplyrCrsd = true;
				}
			}
			else if (IGT_GameView.pHero.pMissionData.nMissionType == 5)
			{
				if (nPathID != ObjListInCurPathOfHero[i].nPathId || ObjListInCurPathOfHero[i].objPlaceType != 1 || ObjListInCurPathOfHero[i].objType != -1 || ObjListInCurPathOfHero[i].bplyrCrsd || !(PlayerdistFrmStrtPnt <= num + ObjListInCurPathOfHero[i].fWidth / 2f) || !(PlayerdistFrmStrtPnt >= num - ObjListInCurPathOfHero[i].fWidth / 2f))
				{
					continue;
				}
				ObjListInCurPathOfHero[i].bplyrCrsd = true;
				for (int j = 0; j < IGT_GameView.pHero.pMissionData.nNumOfMultipleCollection; j++)
				{
					if (IGT_GameView.pHero.pMissionData.nMultipleCollectionDatas[j, 0] == ObjListInCurPathOfHero[i].objID)
					{
						IGT_GameView.pHero.nNoOfMulitpleCollObjHeroCrossed[j]++;
						if (IGT_GameView.pHero.nCollectedMultipleItemCount[j] <= IGT_GameView.pHero.pMissionData.nMultipleCollectionDatas[j, 2])
						{
							IGT_GameView.pHero.nNoOfMultiColObjCrossedUntillTargetAcheived[j]++;
						}
						break;
					}
				}
			}
			else if (IGT_GameView.pHero.pMissionData.nMissionType == 1)
			{
				if (nPathID == ObjListInCurPathOfHero[i].nPathId && ObjListInCurPathOfHero[i].objPlaceType == 1 && !ObjListInCurPathOfHero[i].bDisabled && ((IGT_GameView.pHero.pMissionData.nChallengesInnerItemType == 1 && ObjListInCurPathOfHero[i].objType == 6) || (IGT_GameView.pHero.pMissionData.nChallengesInnerItemType == 0 && ObjListInCurPathOfHero[i].objType == 4) || (IGT_GameView.pHero.pMissionData.nChallengesInnerItemType == 2 && ObjListInCurPathOfHero[i].objType == 0) || (IGT_GameView.pHero.pMissionData.nChallengesInnerItemType == 3 && ObjListInCurPathOfHero[i].objType == 1)) && PlayerdistFrmStrtPnt >= num - 0.25f && PlayerdistFrmStrtPnt < num + 0.25f)
				{
					IGT_GameView.pHero.nNoOfCollectionObjHeroCrossed++;
					ObjListInCurPathOfHero[i].bDisabled = true;
				}
				if (!ObjListInCurPathOfHero[i].bplyrCrsd && ObjListInCurPathOfHero[i].objPlaceType == 1 && (ObjListInCurPathOfHero[i].objType == 0 || ObjListInCurPathOfHero[i].objType == 1) && nPathID == ObjListInCurPathOfHero[i].nPathId && offset >= ObjListInCurPathOfHero[i].fOffset - ObjListInCurPathOfHero[i].fLength / 2f && offset <= ObjListInCurPathOfHero[i].fOffset + ObjListInCurPathOfHero[i].fLength / 2f && PlayerdistFrmStrtPnt >= num - 0.05f && PlayerdistFrmStrtPnt < num + 0.25f)
				{
					if (IGT_GameView.pHero.pMissionData.nChallengesInnerItemType == 2 && playerPos.y + ObjListInCurPathOfHero[i].fHeight <= IGT_AnimStatesCntrler.feetPos && ObjListInCurPathOfHero[i].objType == 0)
					{
						ObjListInCurPathOfHero[i].bplyrCrsd = true;
						IGT_GameView.pHero.nCollectedItemCount++;
					}
					else if (IGT_GameView.pHero.pMissionData.nChallengesInnerItemType == 3 && playerPos.y + ObjListInCurPathOfHero[i].fHeight1 >= IGT_AnimStatesCntrler.HeadPos && ObjListInCurPathOfHero[i].objType == 1)
					{
						ObjListInCurPathOfHero[i].bplyrCrsd = true;
						IGT_GameView.pHero.nCollectedItemCount++;
					}
				}
			}
			else
			{
				if (IGT_GameView.pHero.pMissionData.nMissionType != 3 || nPathID != ObjListInCurPathOfHero[i].nPathId || ObjListInCurPathOfHero[i].objPlaceType != 1 || ObjListInCurPathOfHero[i].objType != -1 || ObjListInCurPathOfHero[i].bplyrCrsd || !(PlayerdistFrmStrtPnt <= num + ObjListInCurPathOfHero[i].fWidth / 2f) || !(PlayerdistFrmStrtPnt >= num - ObjListInCurPathOfHero[i].fWidth / 2f))
				{
					continue;
				}
				if (ObjListInCurPathOfHero[i].nPathId != num2 || ObjListInCurPathOfHero[i].fDistFrmStrtPnt != num3)
				{
					for (int num4 = IGT_GameView.pHero.pCharArray.Length - 1; num4 >= 0; num4--)
					{
						if ((ushort)IGT_ObjPlacing.Alphabetics[ObjListInCurPathOfHero[i].objID] == IGT_GameView.pHero.pCharArray[num4].character && !IGT_GameView.pHero.pCharArray[num4].isEnable)
						{
							IGT_GameView.pHero.nNoOf_WF_CharCrossed++;
							break;
						}
					}
				}
				ObjListInCurPathOfHero[i].bplyrCrsd = true;
			}
		}
		return 11;
	}

	public void CheckCollisions_Tutorial(float PlayerdistFrmStrtPnt, Vector3 playerPos, float offset, bool TravRev, float TotPathLength, float playerSpd, int playerPathID, bool bPickdobj, int missionId)
	{
		IGT_GameView.nArrowAnimType = -1;
		float num = 0f;
		if (TravRev)
		{
			offset = 0f - offset;
		}
		if (missionId == 0 && (playerPathID == 23 || playerPathID == 11) && PlayerdistFrmStrtPnt >= TotPathLength - 3f)
		{
			IGT_GameView.nArrowAnimType = 3;
		}
		if (missionId < 3 && playerPathID == 17 && IGT_GameView.pHero.missionEndWall != null && PlayerdistFrmStrtPnt >= TotPathLength - 1.75f && !IGT_GameView.pHero.missionEndWall.GetComponent<Animation>().playAutomatically)
		{
			IGT_GameView.pHero.missionEndWall.GetComponent<Animation>().Play();
			IGT_GameView.pHero.missionEndWall.GetComponent<Animation>().playAutomatically = true;
			IGT_GameView.pHero.playSound(34);
		}
		for (int i = 0; i < ObjListInCurPathOfHero.Count; i++)
		{
			num = (TravRev ? (TotPathLength - ObjListInCurPathOfHero[i].fDistFrmStrtPnt) : ObjListInCurPathOfHero[i].fDistFrmStrtPnt);
			if (ObjListInCurPathOfHero[i].nPathId != playerPathID)
			{
				continue;
			}
			if (ObjListInCurPathOfHero[i].objPlaceType == 1 && ObjListInCurPathOfHero[i].objType != 4 && ObjListInCurPathOfHero[i].objType != 6)
			{
				if (!(offset >= ObjListInCurPathOfHero[i].fOffset - ObjListInCurPathOfHero[i].fLength / 2f) || !(offset <= ObjListInCurPathOfHero[i].fOffset + ObjListInCurPathOfHero[i].fLength / 2f) || !(PlayerdistFrmStrtPnt >= num - ObjListInCurPathOfHero[i].fWidth - 2.5f) || !(PlayerdistFrmStrtPnt <= num + ObjListInCurPathOfHero[i].fWidth / 2f))
				{
					continue;
				}
				if (ObjListInCurPathOfHero[i].objType == 0)
				{
					IGT_GameView.nArrowAnimType = 0;
				}
				else if (ObjListInCurPathOfHero[i].objType == 1)
				{
					IGT_GameView.nArrowAnimType = 1;
				}
				else if (ObjListInCurPathOfHero[i].objType == 5)
				{
					if (offset == 0f - IGT_GameView.pHero.PlayerObj.fTotalOffsetDeviation)
					{
						IGT_GameView.nArrowAnimType = 3;
					}
					else if (offset == IGT_GameView.pHero.PlayerObj.fTotalOffsetDeviation)
					{
						IGT_GameView.nArrowAnimType = 2;
					}
					else if (offset == IGT_GameView.pHero.centerOffset)
					{
						IGT_GameView.nArrowAnimType = 3;
					}
				}
			}
			else if (missionId == 0 && ObjListInCurPathOfHero[i].objPlaceType == 1 && ObjListInCurPathOfHero[i].objType == 6 && !bPickdobj)
			{
				if (PlayerdistFrmStrtPnt >= num - ObjListInCurPathOfHero[i].fWidth - 5f && PlayerdistFrmStrtPnt <= num + ObjListInCurPathOfHero[i].fWidth / 2f && offset != ObjListInCurPathOfHero[i].fOffset)
				{
					IGT_GameView.nArrowAnimType = findTarOffset(ObjListInCurPathOfHero[i].fOffset, offset, TravRev);
				}
			}
			else if (ObjListInCurPathOfHero[i].objPlaceType == 1 && ObjListInCurPathOfHero[i].objType == 4 && PlayerdistFrmStrtPnt >= num - ObjListInCurPathOfHero[i].fWidth - 2.5f && PlayerdistFrmStrtPnt <= num + ObjListInCurPathOfHero[i].fWidth / 2f && offset == ObjListInCurPathOfHero[i].fOffset)
			{
				IGT_GameView.nArrowAnimType = 4;
			}
		}
	}

	private int findTarOffset(float objOff, float heroOffset, bool travRev)
	{
		int num = -1;
		if (objOff == 0f)
		{
			num = ((!(heroOffset > 0f)) ? 3 : 2);
		}
		else if (objOff < 0f)
		{
			num = 2;
		}
		else if (objOff > 0f)
		{
			num = 3;
		}
		if (travRev)
		{
			switch (num)
			{
			case 2:
				num = 3;
				break;
			case 3:
				num = 2;
				break;
			}
		}
		return num;
	}

	public int CollisionCheckFrMovingObj(int ObjId, Vector3 playerPos)
	{
		minBound = new Vector3(movingObj[ObjId].ObjPos.x - movingObj[ObjId].fLength / 2f, movingObj[ObjId].ObjPos.y - movingObj[ObjId].fHeight / 2f, movingObj[ObjId].ObjPos.z - movingObj[ObjId].fWidth / 2f);
		maxBound = new Vector3(movingObj[ObjId].ObjPos.x + movingObj[ObjId].fLength / 2f, movingObj[ObjId].ObjPos.y + movingObj[ObjId].fHeight / 2f, movingObj[ObjId].ObjPos.z + movingObj[ObjId].fWidth / 2f);
		Vector3 Hit = Vector3.zero;
		playerLines[0] = new IGT_LineVector(new Vector3(playerPos.x, playerPos.y + IGT_Constants.HeroHeight / 2f, playerPos.z), new Vector3(playerPos.x, playerPos.y + IGT_Constants.HeroHeight / 2f, playerPos.z + IGT_Constants.HeroWidth));
		playerLines[1] = new IGT_LineVector(new Vector3(playerPos.x, playerPos.y + IGT_Constants.HeroHeight / 2f, playerPos.z), new Vector3(playerPos.x, playerPos.y + IGT_Constants.HeroHeight / 2f, playerPos.z - IGT_Constants.HeroWidth));
		playerLines[2] = new IGT_LineVector(new Vector3(playerPos.x, playerPos.y + IGT_Constants.HeroHeight / 2f, playerPos.z), new Vector3(playerPos.x + IGT_Constants.HeroWidth, playerPos.y + IGT_Constants.HeroHeight / 2f, playerPos.z));
		playerLines[3] = new IGT_LineVector(new Vector3(playerPos.x, playerPos.y + IGT_Constants.HeroHeight / 2f, playerPos.z), new Vector3(playerPos.x - IGT_Constants.HeroWidth, playerPos.y + IGT_Constants.HeroHeight / 2f, playerPos.z));
		for (int i = 0; i < 4; i++)
		{
			if (CheckLineBox(minBound, maxBound, playerLines[i].strtLinePnts, playerLines[i].endLinePnts, ref Hit) && movingObj[ObjId].fHeight1 >= IGT_AnimStatesCntrler.feetPos)
			{
				return 10;
			}
		}
		return 11;
	}

	private bool CheckLineBox(Vector3 B1, Vector3 B2, Vector3 L1, Vector3 L2, ref Vector3 Hit)
	{
		if (L2.x < B1.x && L1.x < B1.x)
		{
			return false;
		}
		if (L2.x > B2.x && L1.x > B2.x)
		{
			return false;
		}
		if (L2.y < B1.y && L1.y < B1.y)
		{
			return false;
		}
		if (L2.y > B2.y && L1.y > B2.y)
		{
			return false;
		}
		if (L2.z < B1.z && L1.z < B1.z)
		{
			return false;
		}
		if (L2.z > B2.z && L1.z > B2.z)
		{
			return false;
		}
		if (L1.x > B1.x && L1.x < B2.x && L1.y > B1.y && L1.y < B2.y && L1.z > B1.z && L1.z < B2.z)
		{
			Hit = L1;
			return true;
		}
		if ((GetIntersection(L1.x - B1.x, L2.x - B1.x, L1, L2, ref Hit) && InBox(Hit, B1, B2, 1)) || (GetIntersection(L1.y - B1.y, L2.y - B1.y, L1, L2, ref Hit) && InBox(Hit, B1, B2, 2)) || (GetIntersection(L1.z - B1.z, L2.z - B1.z, L1, L2, ref Hit) && InBox(Hit, B1, B2, 3)) || (GetIntersection(L1.x - B2.x, L2.x - B2.x, L1, L2, ref Hit) && InBox(Hit, B1, B2, 1)) || (GetIntersection(L1.y - B2.y, L2.y - B2.y, L1, L2, ref Hit) && InBox(Hit, B1, B2, 2)) || (GetIntersection(L1.z - B2.z, L2.z - B2.z, L1, L2, ref Hit) && InBox(Hit, B1, B2, 3)))
		{
			return true;
		}
		return false;
	}

	private bool GetIntersection(float fDst1, float fDst2, Vector3 P1, Vector3 P2, ref Vector3 Hit)
	{
		if (fDst1 * fDst2 >= 0f)
		{
			return false;
		}
		if (fDst1 == fDst2)
		{
			return false;
		}
		Hit = P1 + (P2 - P1) * ((0f - fDst1) / (fDst2 - fDst1));
		return true;
	}

	private bool InBox(Vector3 Hit, Vector3 B1, Vector3 B2, int Axis)
	{
		if (Axis == 1 && Hit.z > B1.z && Hit.z < B2.z && Hit.y > B1.y && Hit.y < B2.y)
		{
			return true;
		}
		if (Axis == 2 && Hit.z > B1.z && Hit.z < B2.z && Hit.x > B1.x && Hit.x < B2.x)
		{
			return true;
		}
		if (Axis == 3 && Hit.x > B1.x && Hit.x < B2.x && Hit.y > B1.y && Hit.y < B2.y)
		{
			return true;
		}
		return false;
	}
}
