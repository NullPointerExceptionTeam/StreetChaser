using System.Collections.Generic;
using UnityEngine;

public class IGT_AIPlayer : MonoBehaviour
{
	public static IGT_PathInfo AI_PlayerObj;

	public static IGT_Hero pHero;

	public static GameObject AI_Player;

	public static float AI_offset_Laneoffset;

	public static float AI_DestinationOffset;

	public static float AI_fprevOffet;

	public static int nInputFrAIPlayer;

	public static bool AI_bGameOver = false;

	public static bool AI_bNxtPathAvail;

	private int AI_playerCollisionStates;

	public static bool AI_bSelectDataFrMovingBWPath = false;

	private int AI_pathIDFrFindingPosBasedGivenDist = -1;

	private int AI_StrtPosIDFrFindingPosBasedGivenDist = -1;

	public static Vector3 AI_prevAnimpointVec = Vector3.zero;

	public static Vector3 AI_crossProductVal = Vector3.zero;

	public static Vector3 AI_nextExpectedPos = Vector3.zero;

	public static Vector3 AI_movingDirOfPlayer = Vector3.zero;

	public static Vector3 AI_animPointVec = Vector3.zero;

	public static Vector3 AI_animPointVec_Spline = Vector3.zero;

	public static float AI_fDistBw2Points = 0f;

	public static Vector3 AI_PlayerprevPos = Vector3.zero;

	public static Vector3 AI_PlayerCurPos = Vector3.zero;

	public static float fCurVelocity = 0f;

	public static float fAvgVelocity;

	public static bool bPauseAIPlayer = false;

	public static bool bRePositionsFinished = false;

	public static bool bUTurnAnimationPlaying = false;

	private static Texture[] AiPlayerTextures;

	private static float fTexBlendVal;

	public static int nIntelligenceValue;

	public static IGT_AIPlayerAnimStateCtrl pAIPlayerAnimController;

	public static GameObject AI_Wrist;

	public static GameObject AI_Head;

	public static GameObject AI_Headforshadow;

	public static List<IGT_ObjInfo> ObjListInCurPathOfAIPlayer;

	public static float fAIavgSpdFluct;

	public static float fAiSpdChangeVal = 0f;

	public static bool bAttacked;

	public static float dAttackedStartTime;

	public static float dAttackedTotTime;

	public static bool bRobberDisconnect;

	public static bool bRobberHighSpd;

	public static float fRobberHighSpdStrtTime;

	private Vector3 lastCollidedEnergyItemPos = Vector3.zero;

	private int[] nxtPathDet;

	public static float fTimeOffsetChange = 0f;

	public static float fTarTime = 0.75f;

	private Vector3[] NeededPos = new Vector3[6];

	public void init(int strtPath = 25, int strtPoint = 2)
	{
		init_AiplayerComponents();
		AI_PlayerObj = new IGT_PathInfo();
		setDatas(strtPath, strtPoint);
		AI_Player.transform.position = AI_PlayerCurPos;
	}

	public static void AI_player_Restart(int StrtPath = 25, int StrtPoint = 2)
	{
		if (pHero.nGameMode == 0 && pHero.nAIPlayerIndex != 0)
		{
			pHero.DestroyAllAIPlayersUsingTags();
			pHero.nAIPlayerIndex = 0;
			GameObject gameObject = Object.Instantiate(Resources.Load(IGT_Constants.Path_AIPlayerModels_Low + IGT_Constants.AIPlayerString + pHero.nAIPlayerIndex), new Vector3(0.5f, 0.08f, -63.59f), Quaternion.identity) as GameObject;
			SkinnedMeshRenderer componentInChildren = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
			componentInChildren.material = (Material)Resources.Load(IGT_Constants.Path_AIPlayerMaterials + IGT_Constants.AIPlayerString + pHero.nAIPlayerIndex, typeof(Material));
			gameObject.name = pHero.pAIPlayerData[pHero.nAIPlayerIndex].Name;
			init_AiplayerComponents();
		}
		if (AI_Player == null)
		{
			Debug.Log(" null ");
			init_AiplayerComponents();
		}
		setDatas(StrtPath, StrtPoint);
		AI_Player.transform.position = new Vector3(AI_PlayerObj.pointPos[AI_PlayerObj.nGameStrtPath, AI_PlayerObj.nGameStrtPoint, 0], AI_PlayerObj.pointPos[AI_PlayerObj.nGameStrtPath, AI_PlayerObj.nGameStrtPoint, 1], AI_PlayerObj.pointPos[AI_PlayerObj.nGameStrtPath, AI_PlayerObj.nGameStrtPoint, 2]);
		pAIPlayerAnimController.AIHeroAnimator.Play("Idle", 0);
		pAIPlayerAnimController.nHeroAnimState = 1;
	}

	public void init_AiPlayerDatas(int strtPath = 25, int strtPoint = 0)
	{
		init_AiplayerComponents();
		AI_PlayerObj = new IGT_PathInfo();
		setDatas(strtPath, strtPoint);
		IGT_Hero.bAIplayerStart = false;
	}

	private static void setDatas(int path, int point)
	{
		AI_PlayerObj.nGameStrtPath = path;
		AI_PlayerObj.nGameStrtPoint = point;
		AI_PlayerObj.PathInit(AI_PlayerObj.nGameStrtPath, AI_PlayerObj.nGameStrtPoint);
		if (!AI_PlayerObj.bTraverseReverse)
		{
			AI_PlayerObj.animPointX = AI_PlayerObj.waypoints[AI_PlayerObj.currentPoint].position.x;
			AI_PlayerObj.animPointY = AI_PlayerObj.waypoints[AI_PlayerObj.currentPoint].position.y;
			AI_PlayerObj.animPointZ = AI_PlayerObj.waypoints[AI_PlayerObj.currentPoint].position.z;
		}
		else
		{
			AI_PlayerObj.animPointX = AI_PlayerObj.waypoints[AI_PlayerObj.currentPoint - 1].position.x;
			AI_PlayerObj.animPointY = AI_PlayerObj.waypoints[AI_PlayerObj.currentPoint - 1].position.y;
			AI_PlayerObj.animPointZ = AI_PlayerObj.waypoints[AI_PlayerObj.currentPoint - 1].position.z;
		}
		AI_PlayerprevPos = (AI_PlayerCurPos = (AI_animPointVec = (AI_animPointVec_Spline = (AI_prevAnimpointVec = new Vector3(AI_PlayerObj.animPointX, AI_PlayerObj.animPointY, AI_PlayerObj.animPointZ)))));
		AI_PlayerObj.fDistFrmStrtPnt = AI_PlayerObj.objDistFrmStrtPoint(AI_PlayerObj.currentPathIndex, AI_PlayerObj.currentPoint, AI_PlayerObj.waypoints[AI_PlayerObj.currentPoint].position);
		if (AI_PlayerObj.bTraverseReverse)
		{
			AI_PlayerObj.fDistFrmStrtPnt = AI_PlayerObj.pathLength[AI_PlayerObj.currentPathIndex] - AI_PlayerObj.fDistFrmStrtPnt;
		}
		AI_PlayerObj.fTotDistTraveled = AI_PlayerObj.fDistFrmStrtPnt;
		fCurVelocity = 0f;
		fAvgVelocity = AI_PlayerObj.speed;
		fTexBlendVal = 0f;
		setTextureBlendVal(fTexBlendVal);
		AI_bGameOver = false;
		AI_offset_Laneoffset = (AI_fprevOffet = (AI_DestinationOffset = pHero.centerOffset));
		IGT_Constants.AI_dStrtTimefrOffsetSwitchng = Time.time;
		AI_bNxtPathAvail = true;
		nInputFrAIPlayer = -1;
		AI_fDistBw2Points = 0f;
		AI_PlayerObj.bIncraseSpeed_SplPower = false;
		AI_PlayerObj.dIncreaseSpdTotTime = 5.0;
		AI_PlayerObj.dEnergyIncreasingStrtTime = Time.time;
		IGT_GameView.nHelath_Enemy = 1f;
		AI_PlayerObj.nEnergyMeter = (AI_PlayerObj.nEnergyMeterPrev = (AI_PlayerObj.nEnergyMeterNext = 1f));
		AI_PlayerObj.bEnergyMeterChangesinBezier = false;
		AI_PlayerObj.fTimeForEnergyMeterChanges = 0f;
		IGT_GameView.bLowEnergy_Enemy = false;
		IGT_GameView.fLowEnergy_Enemy_StrtTime = 0f;
		bPauseAIPlayer = false;
		bRePositionsFinished = false;
		AI_bSelectDataFrMovingBWPath = false;
		AI_PlayerObj.bMovingFinishdInPath = false;
		bUTurnAnimationPlaying = false;
		pAIPlayerAnimController.AIHeroAnimator.speed = IGT_Constants.nAnimation_Default_Spd;
		bAttacked = false;
		dAttackedTotTime = 2f;
		ObjListInCurPathOfAIPlayer = pHero.PlayerObj.objDetInGivenPath(AI_PlayerObj.currentPathIndex);
		bRobberDisconnect = (bRobberHighSpd = false);
		fRobberHighSpdStrtTime = 0f;
		fAIavgSpdFluct = 0f;
		fAiSpdChangeVal = 0f;
	}

	public static void init_AiplayerComponents()
	{
		pHero = GameObject.FindGameObjectWithTag("Player").GetComponent<IGT_Hero>();
		AI_Player = GameObject.FindGameObjectWithTag(IGT_Constants.AIPlayerString + pHero.nAIPlayerIndex);
		if (GameObject.Find(pHero.pAIPlayerData[pHero.nAIPlayerIndex].Name + IGT_Constants.Path_AIPlayerWrist_Left + "/" + IGT_Constants.String_AIWrist) == null)
		{
			GameObject gameObject = new GameObject(IGT_Constants.String_AIWrist);
			gameObject.transform.SetParent(GameObject.Find(pHero.pAIPlayerData[pHero.nAIPlayerIndex].Name + IGT_Constants.Path_AIPlayerWrist_Left).transform);
			gameObject.transform.localPosition = new Vector3(0f, 0.00059f, 0f);
			gameObject.transform.localScale = Vector3.one;
			gameObject.transform.localRotation = Quaternion.Euler(Vector3.zero);
		}
		AI_Wrist = GameObject.Find(pHero.pAIPlayerData[pHero.nAIPlayerIndex].Name + IGT_Constants.Path_AIPlayerWrist_Left + "/" + IGT_Constants.String_AIWrist);
		AI_Head = GameObject.Find(pHero.pAIPlayerData[pHero.nAIPlayerIndex].Name + IGT_Constants.Path_AIPlayer_Head);
		if (AI_Player.GetComponent<IGT_AIPlayerAnimStateCtrl>() == null)
		{
			AI_Player.AddComponent<IGT_AIPlayerAnimStateCtrl>();
		}
		pAIPlayerAnimController = AI_Player.GetComponent<IGT_AIPlayerAnimStateCtrl>();
		if (AI_Player.GetComponent<Animator>() == null)
		{
			AI_Player.AddComponent<Animator>();
		}
		pAIPlayerAnimController.AIHeroAnimator = AI_Player.GetComponent<Animator>();
		pAIPlayerAnimController.AIHeroAnimator.runtimeAnimatorController = Resources.Load(IGT_Constants.Path_Controller_AIPlayer) as RuntimeAnimatorController;
		pAIPlayerAnimController.AIHeroAnimator.applyRootMotion = true;
		pAIPlayerAnimController.nHeroAnimState = 0;
		pAIPlayerAnimController.AIHeroAnimator.speed = IGT_Constants.nAnimation_Default_Spd;
		if (AI_Player.GetComponent<BoxCollider>() == null)
		{
			Debug.Log("Add box collider to the AiPlayer " + pHero.nAIPlayerIndex + " for checking  the collisions");
		}
		AI_Headforshadow = GameObject.Find(pHero.pAIPlayerData[pHero.nAIPlayerIndex].Name + IGT_Constants.Path_AIPlayer_HeadforShadow);
		pHero.shadowprojectorCreation(false);
	}

	private void OnCollisionEnter(Collision col)
	{
		if (lastCollidedEnergyItemPos == col.gameObject.transform.position)
		{
			return;
		}
		lastCollidedEnergyItemPos = col.gameObject.transform.position;
		if (col.gameObject.tag == IGT_Constants.Tag_KickObj || col.gameObject.tag == IGT_Constants.Tag_ThrowObj)
		{
			pAIPlayerAnimController.nHeroAnimState = 14;
			EnergyMeterCalcFrEnemy(col.gameObject.tag);
			col.gameObject.GetComponent<BoxCollider>().isTrigger = true;
			if (col.gameObject.tag == IGT_Constants.Tag_ThrowObj)
			{
				col.gameObject.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
				GameObject gameObject = Object.Instantiate(IGT_ObjPlacing.Throw_BottleCrackAnim, new Vector3(col.gameObject.transform.position.x, col.gameObject.transform.position.y + 0.2f, col.gameObject.transform.position.z), col.gameObject.transform.rotation);
				gameObject.AddComponent<Rigidbody>();
				Object.Destroy(gameObject, 4f);
				pHero.playSound(4);
				spdCalc_inAttackedState(0);
				pHero.nTot_ThrowCount++;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_ThrowCount, pHero.nTot_ThrowCount);
				IGT_Achivements.completeAchivements(6, pHero.nTot_ThrowCount, 6);
			}
			else if (col.gameObject.tag == IGT_Constants.Tag_KickObj)
			{
				pHero.playSound(11);
				spdCalc_inAttackedState(1);
				pHero.nTot_KickCount++;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_KickCount, pHero.nTot_KickCount);
				IGT_Achivements.completeAchivements(6, pHero.nTot_KickCount, 4);
			}
		}
	}

	public void EnergyMeterCalcFrEnemy(string tag)
	{
		AI_PlayerObj.nEnergyMeterPrev = AI_PlayerObj.nEnergyMeter;
		if (pHero.nGameMode == 1 && pHero.nMissionID < pHero.nTutorialLevelCount)
		{
			switch (pHero.nMissionID)
			{
			case 0:
				AI_PlayerObj.nEnergyMeterNext = 0.05f;
				pHero.PlayerObj.speed = 3f;
				AI_PlayerObj.speed = 2.2f;
				if (AI_PlayerObj.currentPathIndex == 17 && AI_PlayerObj.fDistFrmStrtPnt < AI_PlayerObj.pathLength[AI_PlayerObj.currentPathIndex] - 1.75f)
				{
					pHero.PlayerObj.speed = 3.25f;
					AI_PlayerObj.speed = 1.75f;
				}
				break;
			case 1:
				AI_PlayerObj.nEnergyMeterNext = AI_PlayerObj.nEnergyMeter - 0.4f;
				if (AI_PlayerObj.nEnergyMeterNext < 0f)
				{
					AI_PlayerObj.nEnergyMeterNext = 0f;
				}
				if (AI_PlayerObj.nEnergyMeterNext < 0.25f)
				{
					AI_PlayerObj.speed *= 0.75f;
				}
				pHero.nCollectedItemCount++;
				break;
			case 2:
				AI_PlayerObj.nEnergyMeterNext = AI_PlayerObj.nEnergyMeter - 0.45f;
				if (AI_PlayerObj.nEnergyMeterNext < 0f)
				{
					AI_PlayerObj.nEnergyMeterNext = 0f;
				}
				if (AI_PlayerObj.nEnergyMeterNext < 0.25f)
				{
					AI_PlayerObj.speed *= 0.75f;
				}
				pHero.nCollectedItemCount++;
				break;
			case 3:
				AI_PlayerObj.nEnergyMeterNext = AI_PlayerObj.nEnergyMeter - 0.3f;
				if (AI_PlayerObj.nEnergyMeterNext < 0f)
				{
					AI_PlayerObj.nEnergyMeterNext = 0f;
				}
				AI_PlayerObj.speed *= 0.75f;
				break;
			}
		}
		else if (pHero.nGameMode == 1 && pHero.pMissionData.nMissionType == 1)
		{
			if ((tag == IGT_Constants.Tag_ThrowObj && pHero.pMissionData.nChallengesInnerItemType == 1) || (tag == IGT_Constants.Tag_KickObj && pHero.pMissionData.nChallengesInnerItemType == 0))
			{
				AI_PlayerObj.nEnergyMeterNext = AI_PlayerObj.nEnergyMeter - 1f / (float)pHero.pMissionData.nTargetCount;
				pHero.nCollectedItemCount++;
				fTexBlendVal = (float)pHero.nCollectedItemCount / (float)pHero.pMissionData.nTargetCount;
				if (fTexBlendVal > 1f)
				{
					fTexBlendVal = 1f;
				}
				if (fTexBlendVal < 0f)
				{
					fTexBlendVal = 0f;
				}
				setTextureBlendVal(fTexBlendVal);
			}
		}
		else
		{
			int num = 2;
			if (tag == IGT_Constants.Tag_ThrowObj)
			{
				num = IGT_Constants.Wanted_Throw_Count[pHero.nAIPlayerIndex];
			}
			else if (tag == IGT_Constants.Tag_KickObj)
			{
				num = IGT_Constants.Wanted_Kick_Count[pHero.nAIPlayerIndex];
			}
			AI_PlayerObj.nEnergyMeterNext = AI_PlayerObj.nEnergyMeter - 0.6f / (float)num;
			if (AI_PlayerObj.nEnergyMeterNext <= 0.02f)
			{
				AI_PlayerObj.nEnergyMeterNext = 0.02f;
			}
		}
		AI_PlayerObj.fTimeForEnergyMeterChanges = 0f;
		AI_PlayerObj.bEnergyMeterChangesinBezier = true;
		IGT_GameView.bLowEnergy_Enemy = true;
		IGT_GameView.fLowEnergy_Enemy_StrtTime = Time.time;
	}

	private void SpeedCalc_AI()
	{
		if (pHero.nAIPlayerActionState == 0 && IGT_Hero.bRobbingSceneFinished)
		{
			float distBTWHerotoAI = Vector3.Distance(new Vector3(pHero.player.transform.position.x, 0f, pHero.player.transform.position.z), new Vector3(AI_Player.transform.position.x, 0f, AI_Player.transform.position.z));
			AI_EnergyMeterChanges(distBTWHerotoAI);
			if (bAttacked)
			{
				if (Time.time - dAttackedStartTime > dAttackedTotTime)
				{
					bAttacked = false;
				}
			}
			else if (AI_PlayerObj.nEnergyMeter < 0.05f)
			{
				AI_PlayerObj.speed -= 0.0015f;
				if (!IGT_GameView.bLowEnergy_Enemy)
				{
					IGT_GameView.bLowEnergy_Enemy = true;
					IGT_GameView.fLowEnergy_Enemy_StrtTime = Time.time;
				}
			}
			else if (!bRobberDisconnect)
			{
				if (Vector3.Distance(pHero.player.transform.position, AI_Player.transform.position) > IGT_Constants.INITIAL_DISTGAP_BTW_HERO_ENEMY)
				{
					AI_PlayerObj.speed -= 0.015f;
				}
				else if (Vector3.Distance(pHero.player.transform.position, AI_Player.transform.position) < IGT_Constants.INITIAL_DISTGAP_BTW_HERO_ENEMY - 0.25f)
				{
					AI_PlayerObj.speed += 0.05f;
				}
				else
				{
					AI_PlayerObj.speed = pHero.PlayerObj.BaseSpeed;
					if (pHero.nGameMode == 0)
					{
						AI_PlayerObj.speed *= IGT_Constants.fGlobal_Spd_Multiplier;
					}
					else
					{
						AI_PlayerObj.speed = AI_PlayerObj.speed * IGT_Constants.fDiffSpd_CurVal_Mission * IGT_Constants.fMission_Spd_Multiplier;
					}
				}
			}
			else if (bRobberDisconnect)
			{
				if (bRobberHighSpd)
				{
					if (Time.time - fRobberHighSpdStrtTime > 5f)
					{
						bRobberHighSpd = false;
					}
					else
					{
						AI_PlayerObj.speed = pHero.PlayerObj.BaseSpeed * 1.25f;
					}
				}
				else
				{
					AI_PlayerObj.speed = pHero.PlayerObj.BaseSpeed;
				}
			}
		}
		if (AI_PlayerObj.speed > AI_PlayerObj.MaxSpeed)
		{
			AI_PlayerObj.speed = AI_PlayerObj.MaxSpeed;
		}
		if (AI_PlayerObj.speed < 2f)
		{
			AI_PlayerObj.speed = 2f;
		}
		AI_PlayerObj.PrevSpeed = AI_PlayerObj.speed;
		pAIPlayerAnimController.AIHeroAnimator.speed = IGT_Constants.nAnimation_Default_Spd - 0.1f;
		if (AI_PlayerObj.nEnergyMeter > 0.06f && IGT_GameView.bLowEnergy_Enemy && Time.time - IGT_GameView.fLowEnergy_Enemy_StrtTime > 2f)
		{
			IGT_GameView.bLowEnergy_Enemy = false;
		}
		if (bRobberDisconnect && !bRobberHighSpd && Vector3.Distance(pHero.player.transform.position, AI_Player.transform.position) < IGT_Constants.INITIAL_DISTGAP_BTW_HERO_ENEMY * 1.1f)
		{
			bRobberDisconnect = false;
		}
		else if (!bRobberDisconnect && pHero.PlayerObj.currentPathIndex != AI_PlayerObj.currentPathIndex && Vector3.Distance(pHero.player.transform.position, AI_Player.transform.position) > 13f)
		{
			setDissconnectSpdCalc();
		}
	}

	public static void setDissconnectSpdCalc()
	{
		bRobberDisconnect = true;
		bRobberHighSpd = true;
		fRobberHighSpdStrtTime = Time.time;
	}

	private void spdCalc_inAttackedState(int type)
	{
		if (pHero.nGameMode != 1 || pHero.pMissionData.nMissionType != 1)
		{
			dAttackedStartTime = Time.time;
			bAttacked = true;
			float num = 0.5f;
			float num2 = IGT_Constants.ChasingRadius - IGT_Constants.fLevelUpOuterRadius;
			num = ((type != 0) ? (num2 / (float)IGT_Constants.Wanted_Kick_Count[pHero.nAIPlayerIndex]) : (num2 / (float)IGT_Constants.Wanted_Throw_Count[pHero.nAIPlayerIndex]));
			float num3 = dAttackedTotTime * pHero.PlayerObj.speed;
			float num4 = IGT_Constants.INITIAL_DISTGAP_BTW_HERO_ENEMY - num;
			float num5 = num3 + num4 - IGT_Constants.INITIAL_DISTGAP_BTW_HERO_ENEMY;
			float speed = num5 / dAttackedTotTime;
			if (pHero.nGameMode == 0 || (pHero.nGameMode == 1 && pHero.nMissionID > pHero.nTutorialLevelCount))
			{
				AI_PlayerObj.speed = speed;
			}
			IGT_Constants.INITIAL_DISTGAP_BTW_HERO_ENEMY = num4;
			fTexBlendVal = 1f - (num4 - IGT_Constants.fLevelUpOuterRadius) / num2;
			if (fTexBlendVal > 1f)
			{
				fTexBlendVal = 1f;
			}
			if (fTexBlendVal < 0f)
			{
				fTexBlendVal = 0f;
			}
			setTextureBlendVal(fTexBlendVal);
		}
	}

	public void AI_EnergyMeterChanges(float distBTWHerotoAI)
	{
		if (!AI_PlayerObj.bEnergyMeterChangesinBezier)
		{
			if (pHero.PlayerObj.currentPathIndex != AI_PlayerObj.currentPathIndex && Vector3.Distance(pHero.player.transform.position, AI_Player.transform.position) > 25f)
			{
				AI_PlayerObj.nEnergyMeter += Time.deltaTime * AI_PlayerObj.EnergyDeAcceleratorFactorPerSecond;
			}
			else
			{
				AI_PlayerObj.nEnergyMeter -= Time.deltaTime * AI_PlayerObj.EnergyDeAcceleratorFactorPerSecond;
			}
			AI_PlayerObj.nEnergyMeterPrev = AI_PlayerObj.nEnergyMeter;
		}
		else
		{
			AI_PlayerObj.nEnergyMeter = (1f - AI_PlayerObj.fTimeForEnergyMeterChanges) * AI_PlayerObj.nEnergyMeterPrev + AI_PlayerObj.fTimeForEnergyMeterChanges * AI_PlayerObj.nEnergyMeterNext;
			AI_PlayerObj.fTimeForEnergyMeterChanges += Time.deltaTime * 0.5f;
			if (AI_PlayerObj.fTimeForEnergyMeterChanges > 1f)
			{
				AI_PlayerObj.fTimeForEnergyMeterChanges = 1f;
				AI_PlayerObj.bEnergyMeterChangesinBezier = false;
			}
		}
		if (AI_PlayerObj.nEnergyMeter <= 0.02f)
		{
			AI_PlayerObj.nEnergyMeter = 0.02f;
		}
		if (AI_PlayerObj.nEnergyMeter > 1f)
		{
			AI_PlayerObj.nEnergyMeter = 1f;
		}
		IGT_GameView.nHelath_Enemy = AI_PlayerObj.nEnergyMeter;
	}

	private void energyMeterChanges_ChallengeMode()
	{
		if (AI_PlayerObj.bEnergyMeterChangesinBezier)
		{
			AI_PlayerObj.nEnergyMeter = (1f - AI_PlayerObj.fTimeForEnergyMeterChanges) * AI_PlayerObj.nEnergyMeterPrev + AI_PlayerObj.fTimeForEnergyMeterChanges * AI_PlayerObj.nEnergyMeterNext;
			AI_PlayerObj.fTimeForEnergyMeterChanges += Time.deltaTime * 0.5f;
			if (AI_PlayerObj.fTimeForEnergyMeterChanges > 1f)
			{
				AI_PlayerObj.fTimeForEnergyMeterChanges = 1f;
				AI_PlayerObj.bEnergyMeterChangesinBezier = false;
			}
		}
		if (AI_PlayerObj.nEnergyMeter < 0f)
		{
			AI_PlayerObj.nEnergyMeter = 0f;
		}
		if (AI_PlayerObj.nEnergyMeter > 1f)
		{
			AI_PlayerObj.nEnergyMeter = 1f;
		}
		IGT_GameView.nHelath_Enemy = AI_PlayerObj.nEnergyMeter;
		if (Vector3.Distance(pHero.player.transform.position, AI_Player.transform.position) > IGT_Constants.INITIAL_DISTGAP_BTW_HERO_ENEMY)
		{
			AI_PlayerObj.speed -= 0.015f;
		}
		else if (Vector3.Distance(pHero.player.transform.position, AI_Player.transform.position) < IGT_Constants.INITIAL_DISTGAP_BTW_HERO_ENEMY - 0.25f)
		{
			AI_PlayerObj.speed += 0.05f;
		}
		else
		{
			AI_PlayerObj.speed = pHero.PlayerObj.BaseSpeed;
			AI_PlayerObj.speed *= IGT_Constants.fDiffSpd_CurVal_Mission;
		}
		if (AI_PlayerObj.speed > AI_PlayerObj.MaxSpeed)
		{
			AI_PlayerObj.speed = AI_PlayerObj.MaxSpeed;
		}
		if (AI_PlayerObj.speed < 2f)
		{
			AI_PlayerObj.speed = 2f;
		}
		AI_PlayerObj.PrevSpeed = AI_PlayerObj.speed;
		pAIPlayerAnimController.AIHeroAnimator.speed = IGT_Constants.nAnimation_Default_Spd - 0.1f;
		if (IGT_GameView.bLowEnergy_Enemy && Time.time - IGT_GameView.fLowEnergy_Enemy_StrtTime > 2f)
		{
			IGT_GameView.bLowEnergy_Enemy = false;
		}
	}

	public void SpeedChangesBasedOnIntelligenceWhileClasheswithHero()
	{
		if (AI_PlayerObj.currentPathIndex == pHero.PlayerObj.currentPathIndex || !(AI_PlayerObj.fDistFrmStrtPnt > AI_PlayerObj.pathLength[AI_PlayerObj.currentPathIndex] * 0.45f) || !(pHero.PlayerObj.fDistFrmStrtPnt > pHero.PlayerObj.pathLength[pHero.PlayerObj.currentPathIndex] * 0.25f))
		{
			return;
		}
		bool flag = false;
		int[] array = new int[6];
		for (int i = 0; i < 3; i++)
		{
			array = AI_PlayerObj.findPathBasedInput(AI_PlayerObj.currentPathIndex, AI_PlayerObj.bTraverseReverse, i);
			if (array[0] == -1)
			{
				continue;
			}
			flag = ((array[1] != 0) ? true : false);
			if (array[0] == pHero.PlayerObj.currentPathIndex && flag != pHero.PlayerObj.bTraverseReverse)
			{
				float num = AI_PlayerObj.pathLength[AI_PlayerObj.currentPathIndex] - AI_PlayerObj.fDistFrmStrtPnt;
				float num2 = num / AI_PlayerObj.speed;
				float num3 = pHero.PlayerObj.pathLength[pHero.PlayerObj.currentPathIndex] - pHero.PlayerObj.fDistFrmStrtPnt;
				float num4 = num3 / pHero.PlayerObj.speed;
				if (num2 <= num4 + 2f)
				{
					AI_PlayerObj.speed = pHero.PlayerObj.speed + 0.65f;
					AI_PlayerObj.fTimeForEnergyMeterChanges = 0f;
					AI_PlayerObj.bEnergyMeterChangesinBezier = true;
					AI_PlayerObj.nEnergyMeterPrev = AI_PlayerObj.nEnergyMeter;
					AI_PlayerObj.nEnergyMeterNext = AI_PlayerObj.nEnergyMeter + Random.Range(AI_PlayerObj.EnergyDecMinVal, AI_PlayerObj.EnergyDecMaxVal);
				}
			}
		}
	}

	public static void AIPlayerTexturesSelection(int index)
	{
		AiPlayerTextures = new Texture[3];
		AiPlayerTextures[0] = (Texture)Resources.Load(IGT_Constants.Path_AIPlayerWoundedTexures + IGT_Constants.AIPlayerString + index + "_0", typeof(Texture));
		AiPlayerTextures[1] = (Texture)Resources.Load(IGT_Constants.Path_AIPlayerWoundedTexures + IGT_Constants.AIPlayerString + index + "_1", typeof(Texture));
		AiPlayerTextures[2] = (Texture)Resources.Load(IGT_Constants.Path_AIPlayerWoundedTexures + IGT_Constants.AIPlayerString + index + "_2", typeof(Texture));
	}

	private static void ChangingTextures(int index)
	{
		SkinnedMeshRenderer componentInChildren = AI_Player.GetComponentInChildren<SkinnedMeshRenderer>();
		if (componentInChildren != null)
		{
			componentInChildren.material.mainTexture = AiPlayerTextures[index];
		}
		else
		{
			Debug.Log(" null point exception in changin textures ");
		}
	}

	private static void setTextureBlendVal(float val)
	{
		if (AI_Player != null)
		{
			SkinnedMeshRenderer componentInChildren = AI_Player.GetComponentInChildren<SkinnedMeshRenderer>();
			if (componentInChildren != null && componentInChildren.material != null)
			{
				componentInChildren.material.SetFloat("_BlendValue", val);
			}
		}
	}

	private void Update()
	{
		if (IGT_Hero.bStrtButton && !IGT_Hero.bPauseButton && IGT_Hero.bAIplayerStart && IGT_Hero.bMissionIntro)
		{
			if (IGT_Hero.bGameOver)
			{
				if (pHero.nGameMode == 0 || (pHero.nGameMode == 1 && (pHero.pMissionData.nMissionType == 2 || pHero.nMissionID < pHero.nTutorialLevelCount)))
				{
					if (!pHero.bLevelUpButtonPressed)
					{
						if (!IGT_Hero.bLevelUp)
						{
							if (pHero.nGameMode == 1 && (pHero.nMissionID == 1 || pHero.nMissionID == 2))
							{
								pAIPlayerAnimController.nHeroAnimState = 30;
							}
							else if (pHero.nGameMode == 1 && pHero.pMissionData.nMissionType == 2 && pHero.bMissionManualEnding)
							{
								Movement_AiPlayer();
							}
							else
							{
								pAIPlayerAnimController.nHeroAnimState = 0;
							}
						}
						else if (IGT_AnimStatesCntrler.nHeroAnimState == 8)
						{
							pAIPlayerAnimController.nHeroAnimState = 0;
						}
						else if (IGT_GameView.nScreenMode != 4)
						{
							pAIPlayerAnimController.nHeroAnimState = 5;
						}
						if (IGT_Hero.bLevelUp && IGT_AnimStatesCntrler.nGameOverAnimFinshd != 1 && !IGT_AnimStatesCntrler.HeroAnimator.GetCurrentAnimatorStateInfo(0).IsName("MissionSuccess"))
						{
							Movement_AiPlayer();
						}
						else if (IGT_Hero.bLevelUp && IGT_AnimStatesCntrler.nGameOverAnimFinshd == 1 && IGT_GameView.nScreenMode != 4)
						{
							pAIPlayerAnimController.nHeroAnimState = 16;
						}
					}
					else if (pHero.bLevelUpButtonPressed && IGT_AnimStatesCntrler.nGameOverAnimFinshd != 0)
					{
						pAIPlayerAnimController.nHeroAnimState = 17;
					}
				}
				else if (pHero.nGameMode == 1)
				{
					if (pHero.pMissionData.nMissionType == 1)
					{
						if (pHero.bMissionManualEnding)
						{
							Movement_AiPlayer();
						}
						else if (!IGT_Hero.bLevelUp && !pHero.bMissionCompleted)
						{
							pAIPlayerAnimController.nHeroAnimState = 0;
						}
						else
						{
							pAIPlayerAnimController.nHeroAnimState = 30;
						}
					}
					else
					{
						pAIPlayerAnimController.nHeroAnimState = 0;
					}
				}
			}
			else
			{
				if (!bPauseAIPlayer && !bUTurnAnimationPlaying)
				{
					OffsetFixing_AIPlayer();
					if (pHero.bEnergyItemsAnimation && pHero.pCoinObj.Count > 0)
					{
						pHero.GameOverScreen_CoinAnimation(5f);
					}
					Movement_AiPlayer();
					if (!IGT_Hero.bLevelUp)
					{
						if (pHero.nGameMode == 1 && pHero.nMissionID >= pHero.nTutorialLevelCount && pHero.pMissionData.nMissionType == 1)
						{
							energyMeterChanges_ChallengeMode();
						}
						else if (pHero.nGameMode == 1 && pHero.nMissionID < pHero.nTutorialLevelCount)
						{
							if (pHero.nMissionID == 3 || pHero.nMissionID == 0)
							{
								float distBTWHerotoAI = Vector3.Distance(new Vector3(pHero.player.transform.position.x, 0f, pHero.player.transform.position.z), new Vector3(AI_Player.transform.position.x, 0f, AI_Player.transform.position.z));
								AI_EnergyMeterChanges(distBTWHerotoAI);
								pAIPlayerAnimController.AIHeroAnimator.speed = IGT_Constants.nAnimation_Default_Spd;
								if (pHero.nMissionID == 0)
								{
									if (AI_PlayerObj.nEnergyMeter < 0.1f)
									{
										AI_PlayerObj.speed -= 0.04f;
									}
									if (AI_PlayerObj.speed < 1.5f)
									{
										AI_PlayerObj.speed = 1.5f;
									}
								}
								else
								{
									if (AI_PlayerObj.nEnergyMeter < 0.1f)
									{
										AI_PlayerObj.speed -= 0.005f;
										pAIPlayerAnimController.AIHeroAnimator.speed = IGT_Constants.nAnimation_Default_Spd * 0.75f;
									}
									if (AI_PlayerObj.speed < 2f)
									{
										AI_PlayerObj.speed = 2f;
									}
								}
							}
						}
						else if (!pHero.bSpdInc && (pHero.nGameMode == 0 || (pHero.nGameMode == 1 && pHero.pMissionData.nMissionType == 2)))
						{
							SpeedCalc_AI();
						}
					}
					AI_playerCollisionStates = AI_CheckCollisions(AI_PlayerObj.fDistFrmStrtPnt, AI_Player.transform.position, AI_offset_Laneoffset, AI_PlayerObj.bTraverseReverse, AI_PlayerObj.pathLength[AI_PlayerObj.currentPathIndex], AI_PlayerObj.speed, AI_PlayerObj.currentPathIndex);
					switch (AI_playerCollisionStates)
					{
					case 0:
						pAIPlayerAnimController.nHeroAnimState = 2;
						break;
					case 1:
						pAIPlayerAnimController.nHeroAnimState = 3;
						break;
					case 2:
						pAIPlayerAnimController.nHeroAnimState = 2;
						break;
					}
				}
				UTurn();
			}
			if (pHero.Endless_Bag != null && !IGT_Hero.bBagMovingInCurve)
			{
				pHero.Endless_Bag.transform.position = AI_Wrist.transform.position;
				pHero.Endless_Bag.transform.rotation = AI_Player.transform.rotation;
			}
		}
		if (AI_Headforshadow != null)
		{
			IGT_Hero.AI_shadow_projector.transform.position = AI_Headforshadow.transform.position;
		}
		if (pHero.Endless_Bag != null && !IGT_Hero.bBagMovingInCurve && pHero.nGameMode == 1 && pHero.nMissionID >= 3)
		{
			pHero.Endless_Bag.transform.position = AI_Wrist.transform.position;
			pHero.Endless_Bag.transform.rotation = AI_Player.transform.rotation;
		}
	}

	private void UTurn()
	{
		if (!bUTurnAnimationPlaying && AI_PlayerObj.currentPathIndex == pHero.PlayerObj.currentPathIndex && AI_PlayerObj.bTraverseReverse != pHero.PlayerObj.bTraverseReverse && Vector3.Distance(pHero.player.transform.position, AI_Player.transform.position) < 8f)
		{
			if (!AI_PlayerObj.bTraverseReverse)
			{
				AI_PlayerObj.noOfTargetReached = AI_PlayerObj.pointCount[AI_PlayerObj.currentPathIndex] - AI_PlayerObj.noOfTargetReached;
				AI_PlayerObj.currentPoint = AI_PlayerObj.pointCount[AI_PlayerObj.currentPathIndex] - AI_PlayerObj.noOfTargetReached + 1;
			}
			else
			{
				AI_PlayerObj.noOfTargetReached = AI_PlayerObj.pointCount[AI_PlayerObj.currentPathIndex] - AI_PlayerObj.noOfTargetReached;
				AI_PlayerObj.currentPoint = AI_PlayerObj.noOfTargetReached - 1;
			}
			AI_PlayerObj.bTraverseReverse = pHero.PlayerObj.bTraverseReverse;
			AI_PlayerObj.nStartPoint = AI_PlayerObj.currentPoint;
			AI_PlayerObj.fDistFrmStrtPnt = AI_PlayerObj.pathLength[AI_PlayerObj.currentPathIndex] - AI_PlayerObj.fDistFrmStrtPnt;
			pAIPlayerAnimController.nHeroAnimState = 15;
			AI_PlayerObj.bTotalTarReached = false;
			AI_bSelectDataFrMovingBWPath = false;
			bUTurnAnimationPlaying = true;
			IGT_Constants.AI_dStrtTimefrOffsetSwitchng = Time.time;
			AI_DestinationOffset = (AI_fprevOffet = (AI_offset_Laneoffset = 0f - AI_offset_Laneoffset));
			AI_fDistBw2Points = Vector3.Distance(AI_PlayerObj._curPos, AI_PlayerObj._nextPos) - AI_fDistBw2Points;
		}
	}

	private bool isAIclashesWithHeroInjunction()
	{
		bool result = false;
		if (AI_PlayerObj.currentPathIndex != pHero.PlayerObj.currentPathIndex && Vector3.Distance(pHero.player.transform.position, AI_Player.transform.position) < 8f)
		{
			bool flag = false;
			int[] array = new int[6];
			for (int i = 0; i < 3; i++)
			{
				array = AI_PlayerObj.findPathBasedInput(AI_PlayerObj.currentPathIndex, AI_PlayerObj.bTraverseReverse, i);
				if (array[0] != -1)
				{
					flag = ((array[1] != 0) ? true : false);
					if (array[0] == pHero.PlayerObj.currentPathIndex && flag != pHero.PlayerObj.bTraverseReverse)
					{
						result = true;
						break;
					}
				}
			}
		}
		return result;
	}

	private int SelectNextPathIDBasedOnIntelligence()
	{
		float[] array = new float[3];
		Vector3 zero = Vector3.zero;
		int[] array2 = new int[6];
		float num = 9999f;
		float num2 = 0f;
		int num3 = 0;
		int num4 = Random.Range(0, 101);
		int num5 = 100;
		bool flag = false;
		bool flag2 = false;
		int num6 = num5 - (100 - nIntelligenceValue);
		if (num4 >= 0 && num4 <= num6)
		{
			flag = true;
		}
		else if (num4 > num6 && num4 <= num5)
		{
			flag2 = true;
		}
		Vector3 vector = new Vector3(pHero.player.transform.position.x - AI_Player.transform.position.x, pHero.player.transform.position.y - AI_Player.transform.position.y, pHero.player.transform.position.z - AI_Player.transform.position.z);
		vector.Normalize();
		AI_movingDirOfPlayer = new Vector3(AI_PlayerCurPos.x - AI_PlayerprevPos.x, AI_PlayerCurPos.y - AI_PlayerprevPos.y, AI_PlayerCurPos.z - AI_PlayerprevPos.z);
		AI_movingDirOfPlayer.Normalize();
		Vector3 vector2 = AI_PlayerObj.waypoints[AI_PlayerObj.currentPoint].position + AI_movingDirOfPlayer * 0.25f;
		for (int i = 0; i < 3; i++)
		{
			array2 = AI_PlayerObj.findPathBasedInput(AI_PlayerObj.currentPathIndex, AI_PlayerObj.bTraverseReverse, i);
			if (array2[0] == -1)
			{
				array[i] = -1000f;
				continue;
			}
			int num7 = array2[1];
			num7 = ((array2[1] != 0) ? (array2[1] - 1) : array2[1]);
			Vector3 vector3 = new Vector3(AI_PlayerObj.pointPos[array2[0], num7, 0], AI_PlayerObj.pointPos[array2[0], num7, 1], AI_PlayerObj.pointPos[array2[0], num7, 2]);
			zero = new Vector3(vector3.x - vector2.x, vector3.y - vector2.y, vector3.z - vector2.z);
			zero.Normalize();
			array[i] = Vector3.Angle(vector, zero);
		}
		for (int j = 0; j < 3; j++)
		{
			if (flag2 && array[j] != -1000f && num >= array[j])
			{
				num = array[j];
				num3 = j;
			}
			if (flag && array[j] != -1000f && num2 <= array[j])
			{
				num2 = array[j];
				num3 = j;
			}
		}
		array2 = AI_PlayerObj.findPathBasedInput(AI_PlayerObj.currentPathIndex, AI_PlayerObj.bTraverseReverse, num3);
		if (array2[0] == pHero.PlayerObj.currentPathIndex)
		{
			int num8 = 0;
			array2[0] = -1;
			while (array2[0] == -1 && num8 < 50)
			{
				num3 = Random.Range(0, 3);
				array2 = AI_PlayerObj.findPathBasedInput(AI_PlayerObj.currentPathIndex, AI_PlayerObj.bTraverseReverse, num3);
				if (array2[0] == pHero.PlayerObj.currentPathIndex)
				{
					array2[0] = -1;
				}
				num8++;
			}
		}
		return num3;
	}

	private void RePositioning_AIPlayer()
	{
		if ((!bPauseAIPlayer & !bRePositionsFinished) && pHero.PlayerObj.currentPathIndex != AI_PlayerObj.currentPathIndex)
		{
			int[] array = AI_PlayerObj.findPathBasedInput(pHero.PlayerObj.currentPathIndex, pHero.PlayerObj.bTraverseReverse, 0);
			if (array[0] != AI_PlayerObj.currentPathIndex && Vector3.Distance(pHero.player.transform.position, AI_Player.transform.position) > 15f)
			{
				bPauseAIPlayer = true;
				IGT_Constants.AI_dStrtTimeFrAIPlayerHiding = Time.time;
				pAIPlayerAnimController.nHeroAnimState = 0;
			}
		}
		if (bPauseAIPlayer && !bRePositionsFinished && (double)Time.time - IGT_Constants.AI_dStrtTimeFrAIPlayerHiding > IGT_Constants.AI_dTotHiddingTime)
		{
			nxtPathDet = AI_PlayerObj.findPathBasedInput(pHero.PlayerObj.currentPathIndex, pHero.PlayerObj.bTraverseReverse, Random.Range(0, 3));
			if (nxtPathDet[0] == pHero.PlayerObj.currentPathIndex)
			{
				nxtPathDet[0] = -1;
			}
			while (nxtPathDet[0] == -1)
			{
				nxtPathDet = AI_PlayerObj.findPathBasedInput(pHero.PlayerObj.currentPathIndex, pHero.PlayerObj.bTraverseReverse, Random.Range(0, 3));
				if (nxtPathDet[0] == pHero.PlayerObj.currentPathIndex)
				{
					nxtPathDet[0] = -1;
				}
			}
			bRePositionsFinished = true;
		}
		if (bRePositionsFinished && bPauseAIPlayer)
		{
			float num = AI_PlayerObj.pathLength[pHero.PlayerObj.currentPathIndex];
			if (pHero.PlayerObj.fDistFrmStrtPnt > num - 2f * pHero.PlayerObj.speed)
			{
				int num2 = nxtPathDet[3];
				Vector3 a = new Vector3(AI_PlayerObj.pointPos[nxtPathDet[0], num2, 0], AI_PlayerObj.pointPos[nxtPathDet[0], num2, 1], AI_PlayerObj.pointPos[nxtPathDet[0], num2, 2]);
				int num3 = -1;
				num3 = ((num2 > AI_PlayerObj.pointCount[nxtPathDet[0]] / 2) ? (AI_PlayerObj.pointCount[nxtPathDet[0]] - 1) : 0);
				Vector3 b = new Vector3(AI_PlayerObj.pointPos[nxtPathDet[0], num3, 0], AI_PlayerObj.pointPos[nxtPathDet[0], num3, 1], AI_PlayerObj.pointPos[nxtPathDet[0], num3, 2]);
				float num4 = (num - pHero.PlayerObj.fDistFrmStrtPnt) / pHero.PlayerObj.speed;
				float num5 = Vector3.Distance(a, b) / AI_PlayerObj.speed;
				if (num5 * 2f < num4)
				{
					AI_PlayerObj.PathInit(nxtPathDet[0], num2);
					if (AI_PlayerObj.currentPoint > AI_PlayerObj.pointCount[AI_PlayerObj.currentPathIndex] / 2)
					{
						AI_PlayerObj.bTraverseReverse = false;
						AI_PlayerObj.noOfTargetReached = AI_PlayerObj.currentPoint;
						AI_PlayerObj.currentPoint--;
						AI_PlayerObj.nStartPoint = AI_PlayerObj.currentPoint;
					}
					else
					{
						AI_PlayerObj.bTraverseReverse = true;
						AI_PlayerObj.noOfTargetReached = AI_PlayerObj.pointCount[AI_PlayerObj.currentPathIndex] - AI_PlayerObj.currentPoint;
						AI_PlayerObj.currentPoint++;
						AI_PlayerObj.nStartPoint = AI_PlayerObj.currentPoint;
					}
					AI_fDistBw2Points = 0f;
					bRePositionsFinished = false;
					bPauseAIPlayer = false;
					pAIPlayerAnimController.nHeroAnimState = 1;
				}
				else
				{
					bRePositionsFinished = false;
				}
			}
		}
		if (!bPauseAIPlayer || !(Vector3.Distance(pHero.player.transform.position, AI_Player.transform.position) < 3f))
		{
			return;
		}
		bPauseAIPlayer = false;
		bRePositionsFinished = false;
		pAIPlayerAnimController.nHeroAnimState = 1;
		if (AI_PlayerObj.bTraverseReverse != pHero.PlayerObj.bTraverseReverse)
		{
			AI_PlayerObj.bTraverseReverse = pHero.PlayerObj.bTraverseReverse;
			if (!AI_PlayerObj.bTraverseReverse)
			{
				AI_PlayerObj.noOfTargetReached = AI_PlayerObj.currentPoint + 1;
			}
			else
			{
				AI_PlayerObj.noOfTargetReached = AI_PlayerObj.pointCount[AI_PlayerObj.currentPathIndex] - AI_PlayerObj.currentPoint;
			}
		}
	}

	private void Movement_AiPlayer()
	{
		if (!AI_PlayerObj.bMovingFinishdInPath)
		{
			AI_PlayerMovement();
			return;
		}
		if (!AI_bSelectDataFrMovingBWPath)
		{
			if (!AI_PlayerObj.bTraverseReverse)
			{
				AI_PlayerObj._nextPos = AI_PlayerObj.waypoints[AI_PlayerObj.currentPoint].position;
				AI_PlayerObj._nextToTarPos = AI_PlayerObj.waypoints[AI_PlayerObj.currentPoint + 1].position;
				AI_pathIDFrFindingPosBasedGivenDist = AI_PlayerObj.currentPathIndex;
				AI_StrtPosIDFrFindingPosBasedGivenDist = AI_PlayerObj.currentPoint;
			}
			else
			{
				AI_PlayerObj._nextPos = AI_PlayerObj.waypoints[AI_PlayerObj.currentPoint - 1].position;
				AI_PlayerObj._nextToTarPos = AI_PlayerObj.waypoints[AI_PlayerObj.currentPoint - 2].position;
				AI_pathIDFrFindingPosBasedGivenDist = AI_PlayerObj.currentPathIndex;
				AI_StrtPosIDFrFindingPosBasedGivenDist = AI_PlayerObj.currentPoint - 1;
			}
			AI_PlayerObj._prevPos.x = AI_PlayerObj.pointPos[AI_PlayerObj.prevPathID_BeforeLastPointID[0, 0], AI_PlayerObj.prevPathID_BeforeLastPointID[0, 1], 0];
			AI_PlayerObj._prevPos.y = AI_PlayerObj.pointPos[AI_PlayerObj.prevPathID_BeforeLastPointID[0, 0], AI_PlayerObj.prevPathID_BeforeLastPointID[0, 1], 1];
			AI_PlayerObj._prevPos.z = AI_PlayerObj.pointPos[AI_PlayerObj.prevPathID_BeforeLastPointID[0, 0], AI_PlayerObj.prevPathID_BeforeLastPointID[0, 1], 2];
			AI_PlayerObj._curPos.x = AI_PlayerObj.pointPos[AI_PlayerObj.prevPathID_LastPointID[0, 0], AI_PlayerObj.prevPathID_LastPointID[0, 1], 0];
			AI_PlayerObj._curPos.y = AI_PlayerObj.pointPos[AI_PlayerObj.prevPathID_LastPointID[0, 0], AI_PlayerObj.prevPathID_LastPointID[0, 1], 1];
			AI_PlayerObj._curPos.z = AI_PlayerObj.pointPos[AI_PlayerObj.prevPathID_LastPointID[0, 0], AI_PlayerObj.prevPathID_LastPointID[0, 1], 2];
			AI_bSelectDataFrMovingBWPath = true;
		}
		if (!MovingInBetweenPath_AIPlayer(AI_PlayerObj._curPos, AI_PlayerObj._nextPos, AI_PlayerObj._prevPos, AI_PlayerObj._nextToTarPos) && !AI_PlayerObj.bMovingFinishdInPath)
		{
			AI_prevAnimpointVec = new Vector3(AI_PlayerObj.animPointX, AI_PlayerObj.animPointY, AI_PlayerObj.animPointZ);
			AI_bSelectDataFrMovingBWPath = false;
			ObjListInCurPathOfAIPlayer = pHero.PlayerObj.objDetInGivenPath(AI_PlayerObj.currentPathIndex);
		}
	}

	private void OffsetFixing_AIPlayer()
	{
		if ((double)Time.time - IGT_Constants.AI_dStrtTimefrOffsetSwitchng > IGT_Constants.AI_dOffsetSwitchingTime + (double)Random.Range(0, 5))
		{
			IGT_Constants.AI_dStrtTimefrOffsetSwitchng = Time.time;
			AI_fprevOffet = AI_offset_Laneoffset;
			AI_DestinationOffset = FindDestinationOffset(AI_offset_Laneoffset, 0f, 0.2f, AI_PlayerObj.bTraverseReverse);
		}
		if (AI_offset_Laneoffset != AI_DestinationOffset)
		{
			AI_offset_Laneoffset = IGT_EaseFunction.Linear_ease(fTimeOffsetChange, AI_fprevOffet, AI_DestinationOffset, fTarTime);
			fTimeOffsetChange += Time.deltaTime;
			if (fTimeOffsetChange >= fTarTime)
			{
				fTimeOffsetChange = 0f;
				AI_offset_Laneoffset = AI_DestinationOffset;
			}
		}
	}

	public void EnergyItemsCollisions()
	{
		for (int i = 0; i < pHero.PlayerObj.pObj.pCoinDatas.Count; i++)
		{
			if (AI_PlayerObj.currentPathIndex != pHero.PlayerObj.pObj.pCoinDatas[i].nPathId || pHero.PlayerObj.pObj.pCoinDatas[i].objType != 8)
			{
				continue;
			}
			float num = 0f;
			num = (AI_PlayerObj.bTraverseReverse ? (AI_PlayerObj.pathLength[AI_PlayerObj.currentPathIndex] - pHero.PlayerObj.pObj.pCoinDatas[i].fDistFrmStrtPnt) : pHero.PlayerObj.pObj.pCoinDatas[i].fDistFrmStrtPnt);
			if (pHero.PlayerObj.pObj.pCoinDatas[i].bdataInit || !(AI_PlayerObj.fDistFrmStrtPnt <= num + 2f) || !(AI_PlayerObj.fDistFrmStrtPnt >= num - 2f))
			{
				continue;
			}
			pHero.PlayerObj.pObj.pCoinDatas[i].bdataInit = true;
			if (AIPlayerCanPickEnergyItems())
			{
				pHero.PlayerObj.pObj.pCoinDatas[i].bplyrCrsd = true;
				AI_fprevOffet = AI_offset_Laneoffset;
				if (!AI_PlayerObj.bTraverseReverse)
				{
					AI_DestinationOffset = pHero.PlayerObj.pObj.pCoinDatas[i].fOffset;
				}
				else
				{
					AI_DestinationOffset = 0f - pHero.PlayerObj.pObj.pCoinDatas[i].fOffset;
				}
				continue;
			}
			float num2 = pHero.PlayerObj.pObj.pCoinDatas[i].fOffset;
			if (AI_PlayerObj.bTraverseReverse)
			{
				num2 = 0f - pHero.PlayerObj.pObj.pCoinDatas[i].fOffset;
			}
			if (AI_offset_Laneoffset == num2)
			{
				AI_fprevOffet = AI_offset_Laneoffset;
				if (AI_offset_Laneoffset == AI_PlayerObj.fTotalOffsetDeviation || AI_offset_Laneoffset == 0f - AI_PlayerObj.fTotalOffsetDeviation)
				{
					AI_DestinationOffset = pHero.centerOffset;
				}
				else if (AI_offset_Laneoffset == pHero.centerOffset)
				{
					AI_DestinationOffset = 0f - AI_PlayerObj.fTotalOffsetDeviation;
				}
			}
		}
	}

	private bool AIPlayerCanPickEnergyItems()
	{
		bool result = false;
		int num = Random.Range(0, 100);
		int num2 = (int)(AI_PlayerObj.nEnergyMeter * 100f);
		if (num2 > AI_PlayerObj.EnergyLevelsArr[0])
		{
			if (num < AI_PlayerObj.EnergyPickingProbArr[0])
			{
				result = true;
			}
		}
		else if (num2 > AI_PlayerObj.EnergyLevelsArr[1])
		{
			if (num < AI_PlayerObj.EnergyPickingProbArr[1] && num > AI_PlayerObj.EnergyPickingProbArr[0])
			{
				result = true;
			}
		}
		else if (num2 > AI_PlayerObj.EnergyLevelsArr[2])
		{
			if (num < AI_PlayerObj.EnergyPickingProbArr[2] && num > AI_PlayerObj.EnergyPickingProbArr[1])
			{
				result = true;
			}
		}
		else if (num2 > AI_PlayerObj.EnergyLevelsArr[3])
		{
			if (num < AI_PlayerObj.EnergyPickingProbArr[3] && num > AI_PlayerObj.EnergyPickingProbArr[2])
			{
				result = true;
			}
		}
		else if (num2 > AI_PlayerObj.EnergyLevelsArr[4] && num < AI_PlayerObj.EnergyPickingProbArr[4] && num > AI_PlayerObj.EnergyPickingProbArr[3])
		{
			result = true;
		}
		return result;
	}

	public int AI_CheckCollisions(float PlayerdistFrmStrtPnt, Vector3 playerPos, float offset, bool TravRev, float TotPathLength, float playerSpd, int AIPlayerPathID)
	{
		float num = 0f;
		if (TravRev)
		{
			offset = 0f - offset;
		}
		for (int i = 0; i < pHero.PlayerObj.pObj.movingObj.Count; i++)
		{
			float num2 = pHero.PlayerObj.pObj.movingObj[i].fDistFrmStrtPnt - pHero.PlayerObj.pObj.movingObj[i].fWidth;
			float num3 = PlayerdistFrmStrtPnt;
			float num4 = pHero.PlayerObj.pObj.movingObj[i].fOffset;
			int num5;
			bool flag;
			if (pHero.PlayerObj.pObj.movingObj[i].bVehicleCrossedCurPath)
			{
				num5 = pHero.PlayerObj.pObj.movingObj[i].VehicleDestPathID;
				flag = pHero.PlayerObj.pObj.movingObj[i].bVehicleDestPathTravRev;
			}
			else
			{
				num5 = pHero.PlayerObj.pObj.movingObj[i].nPathId;
				flag = pHero.PlayerObj.pObj.movingObj[i].bTravRev;
			}
			if (flag)
			{
				num4 = 0f - num4;
				if (pHero.PlayerObj.pObj.movingObj[i].bVehicleCrossedCurPath)
				{
					num2 = TotPathLength - pHero.PlayerObj.pObj.movingObj[i].fDistFrmStrtPnt;
				}
			}
			if (TravRev)
			{
				num3 = TotPathLength - PlayerdistFrmStrtPnt - 1.5f;
			}
			if (AIPlayerPathID == num5 && num3 <= num2 + 1f && num3 >= num2 - 1f && offset >= num4 - AI_PlayerObj.fTotalOffsetDeviation && offset <= num4 + AI_PlayerObj.fTotalOffsetDeviation)
			{
				AI_fprevOffet = AI_offset_Laneoffset;
				if (num4 < 0f)
				{
					AI_DestinationOffset = AI_PlayerObj.fTotalOffsetDeviation;
				}
				else
				{
					AI_DestinationOffset = 0f - AI_PlayerObj.fTotalOffsetDeviation;
				}
				if (TravRev)
				{
					AI_DestinationOffset = 0f - AI_DestinationOffset;
				}
			}
		}
		if (pHero.nGameMode == 1 && pHero.bMissionManualEnding && pHero.missionEndWall != null && AI_PlayerObj.currentPathIndex == pHero.PlayerObj.currentPathIndex && (float)IGT_Constants.nDistBtwHero_MissionEndGate - 4f < AI_PlayerObj.fDistFrmStrtPnt && (double)IGT_Constants.nDistBtwHero_MissionEndGate - 3.8 > (double)AI_PlayerObj.fDistFrmStrtPnt)
		{
			AI_PlayerObj.speed *= 1.25f;
			AI_fprevOffet = AI_offset_Laneoffset;
			AI_DestinationOffset = 0f;
			IGT_Constants.AI_dStrtTimefrOffsetSwitchng = Time.time;
			return 1;
		}
		for (int j = 0; j < ObjListInCurPathOfAIPlayer.Count; j++)
		{
			num = (TravRev ? (TotPathLength - ObjListInCurPathOfAIPlayer[j].fDistFrmStrtPnt) : ObjListInCurPathOfAIPlayer[j].fDistFrmStrtPnt);
			if (ObjListInCurPathOfAIPlayer[j].objPlaceType == 1 && ObjListInCurPathOfAIPlayer[j].objType != 4 && ObjListInCurPathOfAIPlayer[j].objType != 6)
			{
				if (AIPlayerPathID == ObjListInCurPathOfAIPlayer[j].nPathId && offset >= ObjListInCurPathOfAIPlayer[j].fOffset - ObjListInCurPathOfAIPlayer[j].fLength / 2f && offset <= ObjListInCurPathOfAIPlayer[j].fOffset + ObjListInCurPathOfAIPlayer[j].fLength / 2f && PlayerdistFrmStrtPnt <= num - 0.75f && PlayerdistFrmStrtPnt >= num - ObjListInCurPathOfAIPlayer[j].fWidth / 2f - 1.05f)
				{
					if (ObjListInCurPathOfAIPlayer[j].objType == 0 && pAIPlayerAnimController.nHeroAnimState != 2)
					{
						return 0;
					}
					if (ObjListInCurPathOfAIPlayer[j].objType == 1 && pAIPlayerAnimController.nHeroAnimState != 3)
					{
						return 1;
					}
					if (ObjListInCurPathOfAIPlayer[j].objType == 5 || ObjListInCurPathOfAIPlayer[j].objType == 9 || (ObjListInCurPathOfAIPlayer[j].objType == 3 && ObjListInCurPathOfAIPlayer[j].fVechicleSpeed <= 0f))
					{
						AI_fprevOffet = AI_offset_Laneoffset;
						AI_DestinationOffset = FindDestinationOffset(offset, ObjListInCurPathOfAIPlayer[j].fOffset, ObjListInCurPathOfAIPlayer[j].fLength / 2f, TravRev);
						IGT_Constants.AI_dStrtTimefrOffsetSwitchng = Time.time;
					}
				}
			}
			else
			{
				if (ObjListInCurPathOfAIPlayer[j].objPlaceType != 0 || !(num + ObjListInCurPathOfAIPlayer[j].fWidth / 2f >= PlayerdistFrmStrtPnt) || AIPlayerPathID != ObjListInCurPathOfAIPlayer[j].nPathId || !(offset >= ObjListInCurPathOfAIPlayer[j].fOffset - ObjListInCurPathOfAIPlayer[j].fLength / 2f - IGT_Constants.AIPlayerWidth / 3f) || !(offset <= ObjListInCurPathOfAIPlayer[j].fOffset + ObjListInCurPathOfAIPlayer[j].fLength / 2f + IGT_Constants.AIPlayerWidth / 3f) || !(PlayerdistFrmStrtPnt <= num) || !(PlayerdistFrmStrtPnt >= num - 1.6f - ObjListInCurPathOfAIPlayer[j].fWidth / 2f))
				{
					continue;
				}
				if (ObjListInCurPathOfAIPlayer[j].objType == 2)
				{
					if (ObjListInCurPathOfAIPlayer[j].fOffset == 0f)
					{
						return 0;
					}
					AI_fprevOffet = AI_offset_Laneoffset;
					AI_DestinationOffset = FindDestinationOffset(offset, ObjListInCurPathOfAIPlayer[j].fOffset, ObjListInCurPathOfAIPlayer[j].fLength / 2f, TravRev);
					IGT_Constants.AI_dStrtTimefrOffsetSwitchng = Time.time;
				}
				if (ObjListInCurPathOfAIPlayer[j].objType == 5)
				{
					AI_fprevOffet = AI_offset_Laneoffset;
					AI_DestinationOffset = FindDestinationOffset(offset, ObjListInCurPathOfAIPlayer[j].fOffset, ObjListInCurPathOfAIPlayer[j].fLength / 2f, TravRev);
					IGT_Constants.AI_dStrtTimefrOffsetSwitchng = Time.time;
				}
			}
		}
		if (pHero.isSurpriseAiAvailable && IGT_SurpriseAIplayer.SurpriseAI != null)
		{
			int currentPathIndex = IGT_SurpriseAIplayer.Surprise_PlayerObj.currentPathIndex;
			float num6 = IGT_SurpriseAIplayer.offset_Laneoffset;
			if (IGT_SurpriseAIplayer.Surprise_PlayerObj.bTraverseReverse)
			{
				num6 = 0f - num6;
			}
			if (AI_PlayerObj.currentPathIndex == currentPathIndex && offset == num6 && Vector3.Distance(AI_Player.transform.position, IGT_SurpriseAIplayer.SurpriseAI.transform.position) < 3f)
			{
				AI_fprevOffet = AI_offset_Laneoffset;
				AI_DestinationOffset = FindDestinationOffset(offset, num6, pHero.PlayerObj.fTotalOffsetDeviation, TravRev);
				IGT_Constants.AI_dStrtTimefrOffsetSwitchng = Time.time;
			}
		}
		if (pHero.bSpdInc && AI_PlayerObj.currentPathIndex == pHero.PlayerObj.currentPathIndex)
		{
			if (AI_PlayerObj.bTraverseReverse == pHero.PlayerObj.bTraverseReverse && AI_offset_Laneoffset == pHero.offset_Laneoffset && AI_PlayerObj.fDistFrmStrtPnt - pHero.PlayerObj.fDistFrmStrtPnt < 2f && AI_PlayerObj.fDistFrmStrtPnt - pHero.PlayerObj.fDistFrmStrtPnt > 0.25f)
			{
				AI_fprevOffet = AI_offset_Laneoffset;
				AI_DestinationOffset = FindDestinationOffset(AI_offset_Laneoffset, pHero.offset_Laneoffset, pHero.PlayerObj.fTotalOffsetDeviation, TravRev);
				IGT_Constants.AI_dStrtTimefrOffsetSwitchng = Time.time;
			}
			else if (AI_PlayerObj.bTraverseReverse != pHero.PlayerObj.bTraverseReverse)
			{
				float num7 = AI_offset_Laneoffset;
				if (num7 != 0f)
				{
					num7 = 0f - num7;
				}
				if (num7 == pHero.offset_Laneoffset)
				{
					AI_fprevOffet = AI_offset_Laneoffset;
					IGT_Constants.AI_dStrtTimefrOffsetSwitchng = Time.time;
					if (num7 == 0f)
					{
						AI_DestinationOffset = 0f - pHero.PlayerObj.fTotalOffsetDeviation;
					}
					else
					{
						AI_DestinationOffset = 0f - AI_offset_Laneoffset;
					}
				}
			}
		}
		return 11;
	}

	public static float FindDestinationOffset(float curOff, float objOff, float objLen, bool TravRev)
	{
		float num = 0f;
		if (objOff == pHero.centerOffset)
		{
			num = pHero.PlayerObj.fTotalOffsetDeviation;
		}
		else if (objOff < pHero.centerOffset)
		{
			num = ((!(objOff + objLen < pHero.centerOffset)) ? pHero.PlayerObj.fTotalOffsetDeviation : pHero.centerOffset);
		}
		else if (objOff > pHero.centerOffset)
		{
			num = ((!(objOff - objLen > pHero.centerOffset)) ? (0f - pHero.PlayerObj.fTotalOffsetDeviation) : pHero.centerOffset);
		}
		if (TravRev)
		{
			num = 0f - num;
		}
		return num;
	}

	private void AI_PlayerMovement()
	{
		int[] array = new int[6];
		if (!AI_PlayerObj.bTraverseReverse && !AI_PlayerObj.bTotalTarReached)
		{
			AI_PlayerObj._curPos.x = AI_PlayerObj.pointPos[AI_PlayerObj.currentPathIndex, AI_PlayerObj.nStartPoint, 0];
			AI_PlayerObj._curPos.y = AI_PlayerObj.pointPos[AI_PlayerObj.currentPathIndex, AI_PlayerObj.nStartPoint, 1];
			AI_PlayerObj._curPos.z = AI_PlayerObj.pointPos[AI_PlayerObj.currentPathIndex, AI_PlayerObj.nStartPoint, 2];
			AI_PlayerObj._nextPos.x = AI_PlayerObj.pointPos[AI_PlayerObj.currentPathIndex, AI_PlayerObj.nStartPoint + 1, 0];
			AI_PlayerObj._nextPos.y = AI_PlayerObj.pointPos[AI_PlayerObj.currentPathIndex, AI_PlayerObj.nStartPoint + 1, 1];
			AI_PlayerObj._nextPos.z = AI_PlayerObj.pointPos[AI_PlayerObj.currentPathIndex, AI_PlayerObj.nStartPoint + 1, 2];
			AI_pathIDFrFindingPosBasedGivenDist = AI_PlayerObj.currentPathIndex;
			AI_StrtPosIDFrFindingPosBasedGivenDist = AI_PlayerObj.nStartPoint + 1;
			if (AI_PlayerObj.nStartPoint == 0)
			{
				array = AI_PlayerObj.findPathBasedInput(AI_PlayerObj.currentPathIndex, true, 0);
				if (array[0] != -1)
				{
					int num = -1;
					num = ((array[1] != 0) ? (array[1] - 1) : array[1]);
					AI_PlayerObj._prevPos.x = AI_PlayerObj.pointPos[array[0], num, 0];
					AI_PlayerObj._prevPos.y = AI_PlayerObj.pointPos[array[0], num, 1];
					AI_PlayerObj._prevPos.z = AI_PlayerObj.pointPos[array[0], num, 2];
				}
				else
				{
					float x = AI_PlayerObj._nextPos.x - AI_PlayerObj._curPos.x;
					float y = AI_PlayerObj._nextPos.y - AI_PlayerObj._curPos.y;
					float z = AI_PlayerObj._nextPos.z - AI_PlayerObj._curPos.z;
					Vector3 vector = new Vector3(x, y, z);
					vector.Normalize();
					float num2 = Vector3.Distance(AI_PlayerObj._curPos, AI_PlayerObj._nextPos);
					AI_PlayerObj._prevPos = AI_PlayerObj._curPos - vector * num2;
				}
				AI_PlayerObj._nextToTarPos.x = AI_PlayerObj.pointPos[AI_PlayerObj.currentPathIndex, AI_PlayerObj.nStartPoint + 2, 0];
				AI_PlayerObj._nextToTarPos.y = AI_PlayerObj.pointPos[AI_PlayerObj.currentPathIndex, AI_PlayerObj.nStartPoint + 2, 1];
				AI_PlayerObj._nextToTarPos.z = AI_PlayerObj.pointPos[AI_PlayerObj.currentPathIndex, AI_PlayerObj.nStartPoint + 2, 2];
			}
			else
			{
				AI_PlayerObj._prevPos.x = AI_PlayerObj.pointPos[AI_PlayerObj.currentPathIndex, AI_PlayerObj.nStartPoint - 1, 0];
				AI_PlayerObj._prevPos.y = AI_PlayerObj.pointPos[AI_PlayerObj.currentPathIndex, AI_PlayerObj.nStartPoint - 1, 1];
				AI_PlayerObj._prevPos.z = AI_PlayerObj.pointPos[AI_PlayerObj.currentPathIndex, AI_PlayerObj.nStartPoint - 1, 2];
				if (AI_PlayerObj.nStartPoint + 2 < AI_PlayerObj.pointCount[AI_PlayerObj.currentPathIndex])
				{
					AI_PlayerObj._nextToTarPos.x = AI_PlayerObj.pointPos[AI_PlayerObj.currentPathIndex, AI_PlayerObj.nStartPoint + 2, 0];
					AI_PlayerObj._nextToTarPos.y = AI_PlayerObj.pointPos[AI_PlayerObj.currentPathIndex, AI_PlayerObj.nStartPoint + 2, 1];
					AI_PlayerObj._nextToTarPos.z = AI_PlayerObj.pointPos[AI_PlayerObj.currentPathIndex, AI_PlayerObj.nStartPoint + 2, 2];
				}
				else
				{
					array = AI_PlayerObj.findPathBasedInput(AI_PlayerObj.currentPathIndex, false, 0);
					if (array[0] != -1)
					{
						int num3 = -1;
						num3 = ((array[1] != 0) ? (array[1] - 1) : array[1]);
						AI_PlayerObj._nextToTarPos.x = AI_PlayerObj.pointPos[array[0], num3, 0];
						AI_PlayerObj._nextToTarPos.y = AI_PlayerObj.pointPos[array[0], num3, 1];
						AI_PlayerObj._nextToTarPos.z = AI_PlayerObj.pointPos[array[0], num3, 2];
					}
					else
					{
						float x2 = AI_PlayerObj._nextPos.x - AI_PlayerObj._curPos.x;
						float y2 = AI_PlayerObj._nextPos.y - AI_PlayerObj._curPos.y;
						float z2 = AI_PlayerObj._nextPos.z - AI_PlayerObj._curPos.z;
						Vector3 vector2 = new Vector3(x2, y2, z2);
						vector2.Normalize();
						float num4 = Vector3.Distance(AI_PlayerObj._curPos, AI_PlayerObj._nextPos);
						AI_PlayerObj._nextToTarPos = AI_PlayerObj._nextPos + vector2 * num4;
					}
				}
			}
		}
		else if (AI_PlayerObj.bTraverseReverse && !AI_PlayerObj.bTotalTarReached)
		{
			AI_PlayerObj._curPos.x = AI_PlayerObj.pointPos[AI_PlayerObj.currentPathIndex, AI_PlayerObj.nStartPoint - 1, 0];
			AI_PlayerObj._curPos.y = AI_PlayerObj.pointPos[AI_PlayerObj.currentPathIndex, AI_PlayerObj.nStartPoint - 1, 1];
			AI_PlayerObj._curPos.z = AI_PlayerObj.pointPos[AI_PlayerObj.currentPathIndex, AI_PlayerObj.nStartPoint - 1, 2];
			AI_PlayerObj._nextPos.x = AI_PlayerObj.pointPos[AI_PlayerObj.currentPathIndex, AI_PlayerObj.nStartPoint - 2, 0];
			AI_PlayerObj._nextPos.y = AI_PlayerObj.pointPos[AI_PlayerObj.currentPathIndex, AI_PlayerObj.nStartPoint - 2, 1];
			AI_PlayerObj._nextPos.z = AI_PlayerObj.pointPos[AI_PlayerObj.currentPathIndex, AI_PlayerObj.nStartPoint - 2, 2];
			AI_pathIDFrFindingPosBasedGivenDist = AI_PlayerObj.currentPathIndex;
			AI_StrtPosIDFrFindingPosBasedGivenDist = AI_PlayerObj.nStartPoint - 2;
			if (AI_PlayerObj.pointCount[AI_PlayerObj.currentPathIndex] == AI_PlayerObj.nStartPoint)
			{
				array = AI_PlayerObj.findPathBasedInput(AI_PlayerObj.currentPathIndex, false, 0);
				if (array[0] != -1)
				{
					int num5 = -1;
					num5 = ((array[1] != 0) ? (array[1] - 1) : array[1]);
					AI_PlayerObj._prevPos.x = AI_PlayerObj.pointPos[array[0], num5, 0];
					AI_PlayerObj._prevPos.y = AI_PlayerObj.pointPos[array[0], num5, 1];
					AI_PlayerObj._prevPos.z = AI_PlayerObj.pointPos[array[0], num5, 2];
				}
				else
				{
					float x3 = AI_PlayerObj._nextPos.x - AI_PlayerObj._curPos.x;
					float y3 = AI_PlayerObj._nextPos.y - AI_PlayerObj._curPos.y;
					float z3 = AI_PlayerObj._nextPos.z - AI_PlayerObj._curPos.z;
					Vector3 vector3 = new Vector3(x3, y3, z3);
					vector3.Normalize();
					float num6 = Vector3.Distance(AI_PlayerObj._curPos, AI_PlayerObj._nextPos);
					AI_PlayerObj._prevPos = AI_PlayerObj._curPos - vector3 * num6;
				}
				AI_PlayerObj._nextToTarPos.x = AI_PlayerObj.pointPos[AI_PlayerObj.currentPathIndex, AI_PlayerObj.nStartPoint - 3, 0];
				AI_PlayerObj._nextToTarPos.y = AI_PlayerObj.pointPos[AI_PlayerObj.currentPathIndex, AI_PlayerObj.nStartPoint - 3, 1];
				AI_PlayerObj._nextToTarPos.z = AI_PlayerObj.pointPos[AI_PlayerObj.currentPathIndex, AI_PlayerObj.nStartPoint - 3, 2];
			}
			else
			{
				AI_PlayerObj._prevPos.x = AI_PlayerObj.pointPos[AI_PlayerObj.currentPathIndex, AI_PlayerObj.nStartPoint, 0];
				AI_PlayerObj._prevPos.y = AI_PlayerObj.pointPos[AI_PlayerObj.currentPathIndex, AI_PlayerObj.nStartPoint, 1];
				AI_PlayerObj._prevPos.z = AI_PlayerObj.pointPos[AI_PlayerObj.currentPathIndex, AI_PlayerObj.nStartPoint, 2];
				if (AI_PlayerObj.nStartPoint - 3 > 0)
				{
					AI_PlayerObj._nextToTarPos.x = AI_PlayerObj.pointPos[AI_PlayerObj.currentPathIndex, AI_PlayerObj.nStartPoint - 3, 0];
					AI_PlayerObj._nextToTarPos.y = AI_PlayerObj.pointPos[AI_PlayerObj.currentPathIndex, AI_PlayerObj.nStartPoint - 3, 1];
					AI_PlayerObj._nextToTarPos.z = AI_PlayerObj.pointPos[AI_PlayerObj.currentPathIndex, AI_PlayerObj.nStartPoint - 3, 2];
				}
				else
				{
					array = AI_PlayerObj.findPathBasedInput(AI_PlayerObj.currentPathIndex, true, 0);
					if (array[0] != -1)
					{
						int num7 = -1;
						num7 = ((array[1] != 0) ? (array[1] - 1) : array[1]);
						AI_PlayerObj._nextToTarPos.x = AI_PlayerObj.pointPos[array[0], num7, 0];
						AI_PlayerObj._nextToTarPos.y = AI_PlayerObj.pointPos[array[0], num7, 1];
						AI_PlayerObj._nextToTarPos.z = AI_PlayerObj.pointPos[array[0], num7, 2];
					}
					else
					{
						float x4 = AI_PlayerObj._nextPos.x - AI_PlayerObj._curPos.x;
						float y4 = AI_PlayerObj._nextPos.y - AI_PlayerObj._curPos.y;
						float z4 = AI_PlayerObj._nextPos.z - AI_PlayerObj._curPos.z;
						Vector3 vector4 = new Vector3(x4, y4, z4);
						vector4.Normalize();
						float num8 = Vector3.Distance(AI_PlayerObj._curPos, AI_PlayerObj._nextPos);
						AI_PlayerObj._nextToTarPos = AI_PlayerObj._nextPos + vector4 * num8;
					}
				}
			}
		}
		if (!AI_PlayerObj.bTotalTarReached && !MovingInPath_AIPlayer(AI_PlayerObj._curPos, AI_PlayerObj._nextPos, AI_PlayerObj._prevPos, AI_PlayerObj._nextToTarPos) && AI_PlayerObj.bTargetReached)
		{
			AI_PlayerObj.noOfTargetReached++;
			AI_PlayerObj.bTargetReached = false;
			if (!AI_PlayerObj.bTraverseReverse)
			{
				AI_PlayerObj.nStartPoint++;
				AI_PlayerObj.currentPoint++;
			}
			else
			{
				AI_PlayerObj.nStartPoint--;
				AI_PlayerObj.currentPoint--;
			}
			if (AI_PlayerObj.waypoints.Length - 1 <= AI_PlayerObj.noOfTargetReached)
			{
				AI_PlayerObj.bTotalTarReached = true;
			}
		}
		if (!AI_PlayerObj.bTotalTarReached)
		{
			return;
		}
		if (pHero.bNextAIPlayerGonnaPickPurse && pHero.PlayerObj.currentPathIndex != AI_PlayerObj.currentPathIndex)
		{
			int num9 = 0;
			nInputFrAIPlayer = Random.Range(0, 3);
			nxtPathDet = AI_PlayerObj.findPathBasedInput(AI_PlayerObj.currentPathIndex, AI_PlayerObj.bTraverseReverse, nInputFrAIPlayer);
			if (nxtPathDet[0] != pHero.PlayerObj.currentPathIndex)
			{
				nxtPathDet[0] = -1;
			}
			while (nxtPathDet[0] == -1 && num9 < 50)
			{
				nInputFrAIPlayer = Random.Range(0, 3);
				nxtPathDet = AI_PlayerObj.findPathBasedInput(AI_PlayerObj.currentPathIndex, AI_PlayerObj.bTraverseReverse, nInputFrAIPlayer);
				if (nxtPathDet[0] != pHero.PlayerObj.currentPathIndex && num9 < 50)
				{
					nxtPathDet[0] = -1;
				}
				num9++;
			}
		}
		else if ((pHero.bNextAIPlayerGonnaPickPurse && pHero.PlayerObj.currentPathIndex == AI_PlayerObj.currentPathIndex) || pHero.nAIPlayerActionState == 1)
		{
			nInputFrAIPlayer = 0;
			nxtPathDet = AI_PlayerObj.findPathBasedInput(AI_PlayerObj.currentPathIndex, AI_PlayerObj.bTraverseReverse, nInputFrAIPlayer);
			if (nxtPathDet[0] == -1)
			{
				nInputFrAIPlayer = 1;
				nxtPathDet = AI_PlayerObj.findPathBasedInput(AI_PlayerObj.currentPathIndex, AI_PlayerObj.bTraverseReverse, nInputFrAIPlayer);
				if (nxtPathDet[0] == -1)
				{
					nInputFrAIPlayer = 2;
				}
			}
		}
		else if (IGT_Hero.bLevelUp || pAIPlayerAnimController.AIHeroAnimator.GetCurrentAnimatorStateInfo(0).IsName(IGT_Constants.AI_AttackedState) || (pHero.nGameMode == 1 && pHero.nMissionID < pHero.nTutorialLevelCount))
		{
			nInputFrAIPlayer = 0;
			nxtPathDet = AI_PlayerObj.findPathBasedInput(AI_PlayerObj.currentPathIndex, AI_PlayerObj.bTraverseReverse, nInputFrAIPlayer);
			if (nxtPathDet[0] == -1)
			{
				nInputFrAIPlayer = 1;
				nxtPathDet = AI_PlayerObj.findPathBasedInput(AI_PlayerObj.currentPathIndex, AI_PlayerObj.bTraverseReverse, nInputFrAIPlayer);
				if (nxtPathDet[0] == -1)
				{
					nInputFrAIPlayer = 2;
				}
			}
		}
		else if (AI_PlayerObj.currentPathIndex == pHero.PlayerObj.currentPathIndex && AI_PlayerObj.bTraverseReverse == pHero.PlayerObj.bTraverseReverse)
		{
			int[] array2 = new int[6];
			int num10 = 0;
			nInputFrAIPlayer = Random.Range(0, 3);
			array2 = AI_PlayerObj.findPathBasedInput(AI_PlayerObj.currentPathIndex, AI_PlayerObj.bTraverseReverse, nInputFrAIPlayer);
			while (array2[0] == -1 && num10 < 50)
			{
				nInputFrAIPlayer = Random.Range(0, 3);
				array2 = AI_PlayerObj.findPathBasedInput(AI_PlayerObj.currentPathIndex, AI_PlayerObj.bTraverseReverse, nInputFrAIPlayer);
				num10++;
			}
		}
		else
		{
			nInputFrAIPlayer = SelectNextPathIDBasedOnIntelligence();
		}
		AI_PlayerObj.nAdjpathToCurPath.Clear();
		for (int i = 0; i < 3; i++)
		{
			int[] array3 = new int[6];
			array3 = AI_PlayerObj.findPathBasedInput(AI_PlayerObj.currentPathIndex, AI_PlayerObj.bTraverseReverse, i);
			AI_PlayerObj.nAdjpathToCurPath.Add(array3[0]);
		}
		if (!AI_PlayerObj.bTraverseReverse)
		{
			AI_PlayerObj.prevPathIndex = AI_PlayerObj.currentPathIndex;
			AI_PlayerObj.bTravRevFrPrevPath = AI_PlayerObj.bTraverseReverse;
			AI_PlayerObj.prevPathID_LastPointID[0, 0] = AI_PlayerObj.currentPathIndex;
			AI_PlayerObj.prevPathID_LastPointID[0, 1] = AI_PlayerObj.currentPoint;
			AI_PlayerObj.prevPathID_BeforeLastPointID[0, 0] = AI_PlayerObj.currentPathIndex;
			AI_PlayerObj.prevPathID_BeforeLastPointID[0, 1] = AI_PlayerObj.currentPoint - 1;
			AI_bNxtPathAvail = AI_PlayerObj.findNearstPath(AI_PlayerObj.currentPathIndex, AI_PlayerObj.waypoints[AI_PlayerObj.pointCount[AI_PlayerObj.currentPathIndex] - 2].position, AI_PlayerObj.waypoints[AI_PlayerObj.pointCount[AI_PlayerObj.currentPathIndex] - 1].position, nInputFrAIPlayer);
		}
		else
		{
			AI_PlayerObj.prevPathIndex = AI_PlayerObj.currentPathIndex;
			AI_PlayerObj.bTravRevFrPrevPath = AI_PlayerObj.bTraverseReverse;
			AI_PlayerObj.prevPathID_LastPointID[0, 0] = AI_PlayerObj.currentPathIndex;
			AI_PlayerObj.prevPathID_LastPointID[0, 1] = AI_PlayerObj.currentPoint - 1;
			AI_PlayerObj.prevPathID_BeforeLastPointID[0, 0] = AI_PlayerObj.currentPathIndex;
			AI_PlayerObj.prevPathID_BeforeLastPointID[0, 1] = AI_PlayerObj.currentPoint;
			AI_bNxtPathAvail = AI_PlayerObj.findNearstPath(AI_PlayerObj.currentPathIndex, AI_PlayerObj.waypoints[1].position, AI_PlayerObj.waypoints[0].position, nInputFrAIPlayer);
		}
		if (AI_bNxtPathAvail)
		{
			AI_PlayerObj.bMovingFinishdInPath = true;
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

	private bool MovingInPath_AIPlayer(Vector3 curpos, Vector3 nextpos, Vector3 prevpos, Vector3 endpos)
	{
		AI_fDistBw2Points += AI_PlayerObj.speed * Time.deltaTime;
		AI_PlayerprevPos = AI_PlayerCurPos;
		if (Vector3.Distance(curpos, nextpos) < AI_fDistBw2Points)
		{
			AI_fDistBw2Points -= Vector3.Distance(curpos, nextpos);
			NeededPos = AI_PlayerObj.PositionBasedGivenDistBw2Points(AI_pathIDFrFindingPosBasedGivenDist, AI_StrtPosIDFrFindingPosBasedGivenDist, AI_fDistBw2Points, AI_PlayerObj.bTraverseReverse, nInputFrAIPlayer);
			AI_fDistBw2Points = Vector3.Distance(NeededPos[0], NeededPos[2]);
			AI_animPointVec_Spline = AI_PlayerObj.CurvePoints(NeededPos[1], NeededPos[2], NeededPos[3], NeededPos[4], AI_fDistBw2Points);
			AI_PlayerCurPos = AI_animPointVec_Spline;
			AI_movingDirOfPlayer = new Vector3(AI_PlayerCurPos.x - AI_PlayerprevPos.x, AI_PlayerCurPos.y - AI_PlayerprevPos.y, AI_PlayerCurPos.z - AI_PlayerprevPos.z);
			AI_movingDirOfPlayer.Normalize();
			AI_crossProductVal = Vector3.Cross(Vector3.up, AI_movingDirOfPlayer);
			AI_nextExpectedPos = AI_animPointVec_Spline + AI_crossProductVal * AI_offset_Laneoffset;
			fCurVelocity = Vector3.Distance(AI_PlayerprevPos, AI_PlayerCurPos) / Time.deltaTime;
			if (!(fCurVelocity > AI_PlayerObj.speed * 0.98f) || !(fCurVelocity < AI_PlayerObj.speed * 1.02f))
			{
				AI_animPointVec_Spline = pHero.VelocityOptimization(AI_PlayerObj.speed, AI_PlayerprevPos, AI_PlayerCurPos, Time.deltaTime, ref AI_fDistBw2Points, NeededPos[1], NeededPos[2], NeededPos[3], NeededPos[4]);
				AI_PlayerCurPos = AI_animPointVec_Spline;
				AI_movingDirOfPlayer = new Vector3(AI_PlayerCurPos.x - AI_PlayerprevPos.x, AI_PlayerCurPos.y - AI_PlayerprevPos.y, AI_PlayerCurPos.z - AI_PlayerprevPos.z);
				AI_movingDirOfPlayer.Normalize();
				AI_crossProductVal = Vector3.Cross(Vector3.up, AI_movingDirOfPlayer);
				AI_nextExpectedPos = AI_animPointVec_Spline + AI_crossProductVal * AI_offset_Laneoffset;
			}
			AI_PlayerObj.fDistFrmStrtPnt += Vector3.Distance(AI_PlayerCurPos, AI_PlayerprevPos);
			AI_PlayerObj.fTotDistTraveled += Vector3.Distance(AI_Player.transform.position, AI_nextExpectedPos);
			fCurVelocity = Vector3.Distance(AI_PlayerprevPos, AI_PlayerCurPos) / Time.deltaTime;
			AI_Player.transform.position = AI_nextExpectedPos;
			AI_PlayerObj.bTargetReached = true;
		}
		else
		{
			AI_animPointVec_Spline = AI_PlayerObj.CurvePoints(prevpos, curpos, nextpos, endpos, AI_fDistBw2Points);
			AI_PlayerCurPos = AI_animPointVec_Spline;
			AI_movingDirOfPlayer = new Vector3(AI_PlayerCurPos.x - AI_PlayerprevPos.x, AI_PlayerCurPos.y - AI_PlayerprevPos.y, AI_PlayerCurPos.z - AI_PlayerprevPos.z);
			AI_movingDirOfPlayer.Normalize();
			AI_crossProductVal = Vector3.Cross(Vector3.up, AI_movingDirOfPlayer);
			AI_nextExpectedPos = AI_animPointVec_Spline + AI_crossProductVal * AI_offset_Laneoffset;
			fCurVelocity = Vector3.Distance(AI_PlayerprevPos, AI_PlayerCurPos) / Time.deltaTime;
			if (!(fCurVelocity > AI_PlayerObj.speed * 0.98f) || !(fCurVelocity < AI_PlayerObj.speed * 1.02f))
			{
				AI_animPointVec_Spline = pHero.VelocityOptimization(AI_PlayerObj.speed, AI_PlayerprevPos, AI_PlayerCurPos, Time.deltaTime, ref AI_fDistBw2Points, prevpos, curpos, nextpos, endpos);
				AI_PlayerCurPos = AI_animPointVec_Spline;
				AI_movingDirOfPlayer = new Vector3(AI_PlayerCurPos.x - AI_PlayerprevPos.x, AI_PlayerCurPos.y - AI_PlayerprevPos.y, AI_PlayerCurPos.z - AI_PlayerprevPos.z);
				AI_movingDirOfPlayer.Normalize();
				AI_crossProductVal = Vector3.Cross(Vector3.up, AI_movingDirOfPlayer);
				AI_nextExpectedPos = AI_animPointVec_Spline + AI_crossProductVal * AI_offset_Laneoffset;
			}
			AI_PlayerObj.fDistFrmStrtPnt += Vector3.Distance(AI_PlayerCurPos, AI_PlayerprevPos);
			AI_PlayerObj.fTotDistTraveled += Vector3.Distance(AI_Player.transform.position, AI_nextExpectedPos);
			fCurVelocity = Vector3.Distance(AI_PlayerprevPos, AI_PlayerCurPos) / Time.deltaTime;
			AI_Player.transform.position = AI_nextExpectedPos;
			if (AI_fDistBw2Points + AI_fDistBw2Points / 2f < Vector3.Distance(nextpos, curpos))
			{
				AI_Player.transform.LookAt(AI_PlayerObj.CurvePoints(prevpos, curpos, nextpos, endpos, AI_fDistBw2Points + AI_fDistBw2Points / 2f) + AI_crossProductVal * AI_offset_Laneoffset);
			}
			else
			{
				float givenDistance = AI_fDistBw2Points + AI_fDistBw2Points / 2f - Vector3.Distance(nextpos, curpos);
				NeededPos = AI_PlayerObj.PositionBasedGivenDistBw2Points(AI_pathIDFrFindingPosBasedGivenDist, AI_StrtPosIDFrFindingPosBasedGivenDist, givenDistance, AI_PlayerObj.bTraverseReverse, nInputFrAIPlayer);
				Vector3 rhs = new Vector3(NeededPos[0].x - NeededPos[1].x, NeededPos[0].y - NeededPos[1].y, NeededPos[0].z - NeededPos[1].z);
				rhs.Normalize();
				Vector3 vector = Vector3.Cross(Vector3.up, rhs);
				AI_Player.transform.LookAt(AI_PlayerObj.CurvePoints(NeededPos[1], NeededPos[2], NeededPos[3], NeededPos[4], Vector3.Distance(NeededPos[0], NeededPos[2])) + vector * AI_offset_Laneoffset);
			}
		}
		fAvgVelocity = fCurVelocity * 0.1f + fAvgVelocity * 0.9f;
		return false;
	}

	private bool MovingInBetweenPath_AIPlayer(Vector3 curpos, Vector3 nextpos, Vector3 prevpos, Vector3 endpos)
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 1.5f;
		if (AI_PlayerObj.currentPathIndex == AI_PlayerObj.nAdjpathToCurPath[0])
		{
			num4 = 1f;
		}
		AI_fDistBw2Points += num4 * AI_PlayerObj.speed * Time.deltaTime;
		AI_movingDirOfPlayer = new Vector3(curpos.x - prevpos.x, curpos.y - prevpos.y, curpos.z - prevpos.z);
		AI_movingDirOfPlayer.Normalize();
		AI_crossProductVal = Vector3.Cross(Vector3.up, AI_movingDirOfPlayer);
		Vector3 prev = prevpos + AI_crossProductVal * AI_offset_Laneoffset;
		Vector3 vector = curpos + AI_crossProductVal * AI_offset_Laneoffset;
		AI_movingDirOfPlayer = new Vector3(endpos.x - nextpos.x, endpos.y - nextpos.y, endpos.z - nextpos.z);
		AI_movingDirOfPlayer.Normalize();
		AI_crossProductVal = Vector3.Cross(Vector3.up, AI_movingDirOfPlayer);
		Vector3 vector2 = nextpos + AI_crossProductVal * AI_offset_Laneoffset;
		Vector3 end = endpos + AI_crossProductVal * AI_offset_Laneoffset;
		AI_PlayerprevPos = AI_PlayerCurPos;
		if (Vector3.Distance(vector, vector2) < AI_fDistBw2Points)
		{
			float givenDistance = AI_fDistBw2Points - Vector3.Distance(vector, vector2);
			NeededPos = AI_PlayerObj.PositionBasedGivenDistBw2Points(AI_pathIDFrFindingPosBasedGivenDist, AI_StrtPosIDFrFindingPosBasedGivenDist, givenDistance, AI_PlayerObj.bTraverseReverse, nInputFrAIPlayer);
			AI_fDistBw2Points = Vector3.Distance(NeededPos[0], NeededPos[2]);
			AI_movingDirOfPlayer = new Vector3(NeededPos[2].x - NeededPos[1].x, NeededPos[2].y - NeededPos[1].y, NeededPos[2].z - NeededPos[1].z);
			AI_movingDirOfPlayer.Normalize();
			AI_crossProductVal = Vector3.Cross(Vector3.up, AI_movingDirOfPlayer);
			prev = NeededPos[1] + AI_crossProductVal * AI_offset_Laneoffset;
			vector = NeededPos[2] + AI_crossProductVal * AI_offset_Laneoffset;
			AI_movingDirOfPlayer = new Vector3(NeededPos[4].x - NeededPos[3].x, NeededPos[4].y - NeededPos[3].y, NeededPos[4].z - NeededPos[3].z);
			AI_movingDirOfPlayer.Normalize();
			AI_crossProductVal = Vector3.Cross(Vector3.up, AI_movingDirOfPlayer);
			vector2 = NeededPos[3] + AI_crossProductVal * AI_offset_Laneoffset;
			end = NeededPos[4] + AI_crossProductVal * AI_offset_Laneoffset;
			AI_movingDirOfPlayer = new Vector3(NeededPos[0].x - NeededPos[2].x, NeededPos[0].y - NeededPos[2].y, NeededPos[0].z - NeededPos[2].z);
			AI_movingDirOfPlayer.Normalize();
			AI_crossProductVal = Vector3.Cross(Vector3.up, AI_movingDirOfPlayer);
			Vector3 a = NeededPos[0] + AI_crossProductVal * AI_offset_Laneoffset;
			num2 = Vector3.Distance(curpos, nextpos);
			num = Vector3.Distance(vector, vector2);
			num3 = num2 * AI_fDistBw2Points / num;
			AI_animPointVec_Spline = pHero.MovingInBtwPathsUsingEqualDist(NeededPos[1], NeededPos[2], NeededPos[3], NeededPos[4], AI_fDistBw2Points);
			AI_PlayerCurPos = AI_animPointVec_Spline;
			AI_nextExpectedPos = pHero.MovingInBtwPathsUsingEqualDist(prev, vector, vector2, end, Vector3.Distance(a, vector));
			AI_PlayerObj.fTotDistTraveled += Vector3.Distance(AI_Player.transform.position, AI_nextExpectedPos);
			fCurVelocity = Vector3.Distance(AI_nextExpectedPos, AI_Player.transform.position) / Time.deltaTime;
			AI_Player.transform.position = AI_nextExpectedPos;
			AI_PlayerObj.bMovingFinishdInPath = false;
		}
		else
		{
			num2 = Vector3.Distance(curpos, nextpos);
			num = Vector3.Distance(vector, vector2);
			num3 = num2 * AI_fDistBw2Points / num;
			AI_animPointVec_Spline = pHero.MovingInBtwPathsUsingEqualDist(prevpos, curpos, nextpos, endpos, num3);
			AI_PlayerCurPos = AI_animPointVec_Spline;
			AI_nextExpectedPos = pHero.MovingInBtwPathsUsingEqualDist(prev, vector, vector2, end, AI_fDistBw2Points);
			AI_PlayerObj.fTotDistTraveled += Vector3.Distance(AI_Player.transform.position, AI_nextExpectedPos);
			fCurVelocity = Vector3.Distance(AI_nextExpectedPos, AI_Player.transform.position) / Time.deltaTime;
			AI_Player.transform.position = AI_nextExpectedPos;
			if (AI_fDistBw2Points + AI_fDistBw2Points / 2f < Vector3.Distance(vector2, vector))
			{
				AI_Player.transform.LookAt(pHero.MovingInBtwPathsUsingEqualDist(prev, vector, vector2, end, AI_fDistBw2Points + AI_fDistBw2Points / 2f));
			}
			else
			{
				float givenDistance2 = AI_fDistBw2Points + AI_fDistBw2Points / 2f - Vector3.Distance(vector2, vector);
				NeededPos = AI_PlayerObj.PositionBasedGivenDistBw2Points(AI_pathIDFrFindingPosBasedGivenDist, AI_StrtPosIDFrFindingPosBasedGivenDist, givenDistance2, AI_PlayerObj.bTraverseReverse, nInputFrAIPlayer);
				AI_movingDirOfPlayer = new Vector3(NeededPos[2].x - NeededPos[1].x, NeededPos[2].y - NeededPos[1].y, NeededPos[2].z - NeededPos[1].z);
				AI_movingDirOfPlayer.Normalize();
				AI_crossProductVal = Vector3.Cross(Vector3.up, AI_movingDirOfPlayer);
				prev = NeededPos[1] + AI_crossProductVal * AI_offset_Laneoffset;
				vector = NeededPos[2] + AI_crossProductVal * AI_offset_Laneoffset;
				AI_movingDirOfPlayer = new Vector3(NeededPos[4].x - NeededPos[3].x, NeededPos[4].y - NeededPos[3].y, NeededPos[4].z - NeededPos[3].z);
				AI_movingDirOfPlayer.Normalize();
				AI_crossProductVal = Vector3.Cross(Vector3.up, AI_movingDirOfPlayer);
				vector2 = NeededPos[3] + AI_crossProductVal * AI_offset_Laneoffset;
				end = NeededPos[4] + AI_crossProductVal * AI_offset_Laneoffset;
				AI_movingDirOfPlayer = new Vector3(NeededPos[0].x - NeededPos[2].x, NeededPos[0].y - NeededPos[2].y, NeededPos[0].z - NeededPos[2].z);
				AI_movingDirOfPlayer.Normalize();
				AI_crossProductVal = Vector3.Cross(Vector3.up, AI_movingDirOfPlayer);
				AI_Player.transform.LookAt(pHero.MovingInBtwPathsUsingEqualDist(prev, vector, vector2, end, Vector3.Distance(vector, vector2)));
			}
		}
		fAIavgSpdFluct += AI_PlayerObj.speed - Vector3.Distance(AI_PlayerprevPos, AI_PlayerCurPos) / Time.deltaTime;
		fAvgVelocity = fCurVelocity * 0.1f + fAvgVelocity * 0.9f;
		return false;
	}
}
