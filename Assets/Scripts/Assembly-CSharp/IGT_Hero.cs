using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SWS;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Rendering;

public class IGT_Hero : MonoBehaviour, IGT_PurchaseFlowListner
{
	private int[] GeneratedLevelDatas = new int[2000]
	{
		9, 12, 20, 10, 13, 7, 4, 23, 18, 5,
		16, 17, 25, 24, 8, 9, 0, 19, 6, 18,
		11, 23, 2, 28, 5, 16, 9, 22, 12, 24,
		18, 14, 23, 10, 17, 27, 11, 19, 13, 21,
		12, 3, 15, 16, 8, 10, 5, 29, 6, 27,
		9, 14, 19, 18, 11, 24, 10, 12, 4, 15,
		16, 6, 7, 14, 5, 2, 9, 3, 8, 27,
		13, 19, 15, 28, 10, 7, 24, 9, 4, 6,
		17, 8, 12, 0, 16, 27, 10, 14, 23, 28,
		29, 6, 8, 19, 15, 12, 13, 9, 17, 10,
		18, 23, 14, 7, 3, 21, 6, 5, 12, 1,
		27, 10, 11, 23, 15, 9, 22, 17, 8, 6,
		21, 5, 12, 10, 24, 23, 9, 0, 7, 28,
		15, 13, 19, 16, 5, 11, 18, 14, 29, 12,
		23, 6, 15, 3, 2, 24, 19, 18, 7, 26,
		5, 0, 16, 8, 12, 6, 23, 10, 29, 4,
		17, 19, 22, 0, 24, 9, 21, 7, 10, 5,
		12, 8, 6, 19, 23, 15, 0, 28, 4, 10,
		9, 5, 18, 21, 22, 7, 12, 13, 16, 6,
		15, 14, 20, 24, 28, 9, 2, 5, 17, 10,
		13, 7, 22, 16, 23, 11, 12, 9, 6, 3,
		2, 5, 10, 19, 8, 15, 24, 13, 7, 9,
		26, 20, 21, 12, 18, 17, 4, 0, 19, 23,
		5, 10, 24, 2, 3, 13, 9, 6, 12, 7,
		15, 16, 8, 11, 28, 21, 0, 17, 14, 27,
		9, 19, 29, 13, 1, 18, 10, 6, 12, 0,
		14, 5, 23, 15, 13, 17, 28, 27, 19, 22,
		12, 4, 9, 7, 15, 24, 6, 8, 13, 1,
		23, 21, 16, 17, 12, 18, 10, 20, 6, 0,
		19, 8, 2, 5, 14, 9, 29, 26, 22, 6,
		12, 19, 18, 13, 10, 15, 28, 8, 11, 7,
		14, 1, 0, 22, 6, 12, 16, 18, 5, 3,
		10, 8, 13, 2, 24, 6, 12, 22, 1, 9,
		21, 17, 11, 19, 8, 10, 5, 23, 12, 6,
		14, 28, 20, 9, 19, 11, 13, 7, 5, 2,
		10, 18, 12, 8, 14, 19, 27, 6, 21, 24,
		5, 9, 11, 4, 28, 22, 10, 14, 17, 12,
		7, 13, 21, 9, 6, 4, 16, 8, 28, 10,
		3, 29, 17, 22, 9, 20, 5, 7, 23, 27,
		11, 28, 13, 10, 24, 22, 18, 14, 20, 8,
		27, 6, 16, 5, 11, 21, 15, 22, 17, 18,
		8, 9, 12, 23, 10, 1, 16, 13, 2, 5,
		4, 21, 25, 8, 14, 24, 18, 23, 27, 12,
		13, 5, 10, 11, 9, 3, 15, 19, 7, 1,
		14, 16, 18, 29, 28, 10, 12, 22, 25, 6,
		23, 19, 17, 24, 21, 8, 4, 9, 11, 10,
		6, 5, 12, 27, 13, 19, 8, 14, 23, 9,
		16, 18, 0, 10, 12, 15, 5, 7, 13, 14,
		6, 23, 27, 18, 16, 22, 10, 12, 7, 9,
		17, 21, 5, 27, 23, 18, 14, 13, 29, 19,
		15, 8, 17, 22, 12, 9, 7, 28, 5, 20,
		13, 18, 19, 14, 11, 22, 23, 7, 21, 3,
		0, 12, 16, 6, 19, 9, 5, 29, 14, 17,
		7, 8, 12, 16, 18, 22, 9, 23, 28, 2,
		6, 17, 10, 26, 13, 15, 0, 11, 22, 7,
		5, 28, 12, 16, 10, 9, 19, 3, 8, 18,
		24, 22, 6, 0, 7, 4, 5, 17, 10, 9,
		23, 18, 1, 8, 13, 15, 19, 24, 21, 4,
		9, 12, 2, 23, 10, 18, 16, 13, 5, 8,
		27, 17, 19, 6, 28, 9, 12, 7, 14, 22,
		1, 13, 8, 17, 11, 6, 19, 2, 24, 18,
		9, 14, 12, 7, 29, 16, 23, 19, 8, 5,
		18, 13, 14, 9, 15, 6, 20, 12, 19, 29,
		5, 18, 24, 13, 11, 16, 7, 17, 10, 19,
		12, 6, 21, 14, 4, 8, 28, 7, 13, 15,
		22, 19, 23, 9, 5, 14, 4, 21, 12, 26,
		10, 6, 17, 24, 2, 13, 8, 20, 16, 21,
		4, 23, 19, 18, 6, 28, 9, 12, 8, 10,
		7, 13, 15, 20, 4, 11, 6, 16, 19, 24,
		1, 14, 17, 21, 7, 4, 18, 23, 16, 19,
		12, 22, 8, 13, 20, 5, 24, 0, 26, 17,
		19, 12, 7, 23, 9, 18, 4, 14, 5, 1,
		10, 27, 24, 13, 22, 16, 9, 17, 6, 18,
		23, 12, 8, 14, 11, 26, 5, 20, 15, 9,
		3, 16, 12, 4, 18, 10, 19, 6, 11, 26,
		17, 25, 14, 24, 12, 8, 5, 19, 18, 3,
		13, 22, 23, 26, 28, 10, 17, 6, 15, 14,
		12, 7, 5, 19, 8, 9, 4, 3, 6, 21,
		10, 18, 11, 12, 24, 13, 15, 22, 26, 16,
		14, 28, 23, 6, 12, 17, 5, 9, 10, 11,
		20, 14, 29, 0, 1, 23, 8, 3, 9, 10,
		16, 17, 4, 13, 21, 15, 14, 23, 7, 5,
		18, 0, 10, 16, 13, 4, 26, 15, 14, 27,
		11, 12, 29, 2, 5, 6, 28, 8, 17, 20,
		13, 18, 11, 26, 12, 23, 7, 10, 27, 17,
		24, 8, 19, 0, 2, 28, 29, 23, 9, 6,
		1, 24, 15, 12, 13, 8, 17, 22, 0, 4,
		21, 6, 5, 14, 11, 23, 18, 19, 24, 12,
		27, 17, 6, 21, 9, 13, 22, 16, 3, 0,
		15, 5, 14, 24, 19, 27, 8, 6, 12, 11,
		9, 17, 13, 10, 5, 7, 0, 8, 18, 12,
		1, 4, 27, 19, 16, 10, 2, 17, 6, 14,
		11, 23, 8, 12, 21, 15, 10, 5, 17, 6,
		9, 4, 14, 18, 22, 28, 19, 23, 29, 5,
		27, 24, 6, 1, 8, 4, 10, 12, 25, 20,
		26, 22, 21, 6, 16, 14, 9, 13, 17, 11,
		1, 5, 7, 21, 6, 12, 28, 9, 27, 26,
		14, 24, 1, 0, 23, 18, 13, 10, 7, 9,
		17, 6, 14, 24, 19, 5, 22, 13, 10, 15,
		9, 0, 12, 8, 11, 4, 16, 18, 13, 10,
		21, 7, 14, 9, 27, 12, 1, 17, 6, 4,
		18, 8, 5, 3, 19, 11, 9, 2, 17, 6,
		13, 21, 22, 8, 7, 16, 4, 29, 1, 12,
		6, 23, 17, 11, 20, 10, 22, 15, 0, 16,
		12, 19, 8, 23, 7, 11, 5, 9, 3, 15,
		16, 12, 6, 14, 1, 7, 13, 10, 23, 11,
		8, 18, 5, 19, 15, 14, 12, 0, 7, 9,
		24, 16, 2, 11, 5, 17, 6, 18, 10, 4,
		14, 9, 19, 12, 11, 22, 8, 7, 21, 23,
		0, 4, 29, 17, 6, 11, 10, 24, 12, 18,
		8, 14, 4, 15, 26, 19, 7, 16, 13, 27,
		17, 23, 28, 14, 22, 11, 9, 12, 10, 0,
		20, 5, 6, 18, 24, 13, 8, 4, 22, 1,
		12, 28, 27, 10, 17, 16, 7, 2, 11, 9,
		19, 5, 12, 23, 13, 18, 17, 10, 7, 27,
		21, 14, 16, 9, 12, 6, 22, 15, 20, 7,
		11, 4, 5, 13, 24, 9, 29, 8, 26, 10,
		28, 18, 1, 12, 19, 4, 13, 27, 16, 9,
		6, 0, 23, 7, 28, 18, 1, 5, 4, 8,
		12, 17, 14, 19, 11, 10, 9, 20, 18, 4,
		24, 1, 12, 7, 22, 5, 19, 9, 10, 8,
		17, 11, 29, 14, 12, 22, 3, 18, 0, 9,
		21, 24, 6, 5, 11, 4, 10, 15, 12, 18,
		9, 27, 19, 6, 7, 11, 8, 5, 28, 12,
		13, 21, 10, 14, 15, 3, 16, 11, 18, 6,
		4, 23, 9, 5, 20, 0, 10, 12, 19, 21,
		6, 17, 11, 9, 13, 23, 15, 14, 5, 4,
		28, 19, 8, 6, 18, 16, 9, 12, 22, 27,
		0, 21, 17, 15, 10, 29, 7, 6, 1, 16,
		5, 9, 12, 25, 24, 14, 0, 10, 26, 19,
		23, 7, 16, 4, 29, 8, 6, 28, 9, 10,
		12, 19, 13, 11, 23, 0, 24, 2, 7, 16,
		18, 4, 10, 19, 9, 6, 14, 17, 23, 0,
		13, 8, 15, 12, 16, 27, 4, 6, 3, 28,
		19, 5, 22, 24, 9, 26, 15, 12, 6, 13,
		27, 8, 18, 17, 14, 9, 5, 15, 10, 23,
		13, 7, 11, 8, 6, 22, 3, 4, 9, 20,
		14, 18, 12, 16, 7, 0, 5, 6, 3, 13,
		22, 19, 11, 18, 28, 4, 23, 5, 21, 7,
		12, 17, 0, 6, 14, 13, 20, 11, 10, 5,
		9, 16, 26, 1, 28, 2, 14, 12, 23, 10,
		11, 19, 4, 15, 17, 8, 16, 7, 9, 18,
		3, 6, 12, 5, 13, 11, 23, 22, 1, 10,
		9, 7, 18, 8, 16, 5, 24, 14, 13, 25,
		6, 9, 29, 21, 17, 7, 26, 11, 19, 23,
		24, 3, 10, 6, 12, 5, 22, 9, 21, 15,
		7, 17, 8, 18, 10, 23, 19, 25, 20, 9,
		12, 4, 17, 8, 14, 10, 24, 16, 18, 13,
		6, 0, 4, 19, 1, 3, 15, 12, 10, 9,
		7, 11, 5, 17, 6, 14, 29, 28, 18, 21,
		9, 23, 19, 10, 13, 5, 12, 0, 15, 14,
		26, 24, 18, 6, 23, 7, 10, 21, 12, 8,
		28, 5, 11, 24, 15, 18, 9, 17, 6, 10,
		0, 7, 4, 22, 13, 19, 5, 24, 14, 17,
		18, 23, 16, 6, 9, 10, 20, 4, 0, 13,
		8, 12, 19, 22, 5, 14, 24, 1, 6, 10,
		0, 17, 9, 29, 22, 23, 12, 8, 13, 11,
		24, 14, 4, 9, 7, 26, 5, 10, 16, 12,
		18, 19, 22, 4, 11, 24, 23, 6, 9, 10,
		14, 0, 12, 22, 17, 15, 8, 13, 16, 23,
		4, 20, 21, 1, 6, 5, 15, 17, 12, 0,
		11, 9, 24, 27, 19, 8, 23, 16, 6, 10,
		7, 0, 26, 14, 11, 17, 12, 9, 8, 4,
		27, 23, 7, 13, 18, 10, 0, 11, 1, 8,
		12, 26, 28, 14, 6, 24, 19, 13, 10, 5,
		11, 23, 0, 12, 16, 17, 6, 19, 15, 14,
		7, 9, 18, 29, 8, 5, 1, 24, 12, 13,
		19, 6, 16, 10, 20, 23, 18, 1, 11, 9,
		28, 17, 6, 12, 5, 20, 22, 10, 23, 0,
		3, 27, 29, 14, 9, 4, 2, 13, 22, 7,
		19, 8, 16, 6, 14, 12, 9, 17, 23, 5,
		27, 19, 8, 18, 28, 11, 2, 24, 12, 15,
		9, 27, 16, 25, 6, 14, 10, 18, 29, 12,
		2, 7, 24, 9, 3, 11, 17, 5, 6, 15,
		13, 14, 16, 27, 12, 10, 9, 24, 11, 1,
		19, 28, 8, 16, 22, 17, 10, 14, 7, 23,
		13, 1, 9, 18, 19, 11, 24, 17, 27, 0,
		12, 5, 4, 10, 13, 8, 6, 18, 19, 21,
		16, 28, 9, 24, 22, 10, 11, 6, 12, 1,
		5, 13, 15, 14, 16, 8, 4, 9, 10, 18,
		17, 5, 7, 12, 21, 16, 23, 14, 22, 3,
		4, 10, 6, 19, 12, 17, 24, 5, 16, 13,
		28, 1, 0, 27, 11, 6, 29, 9, 19, 23,
		5, 15, 10, 12, 1, 24, 6, 8, 22, 9,
		28, 13, 16, 27, 4, 14, 15, 26, 6, 11,
		9, 18, 0, 17, 10, 23, 14, 24, 3, 4,
		20, 19, 18, 8, 7, 27, 12, 9, 14, 1,
		4, 6, 19, 22, 16, 17, 21, 23, 12, 14,
		28, 24, 20, 19, 0, 10, 7, 9, 21, 4,
		16, 13, 15, 22, 19, 5, 6, 24, 12, 2,
		9, 17, 18, 13, 10, 4, 16, 5, 6, 14,
		7, 15, 8, 9, 28, 18, 17, 1, 10, 21,
		13, 12, 16, 19, 7, 28, 14, 0, 27, 6,
		9, 11, 12, 16, 5, 20, 15, 13, 29, 19,
		10, 17, 22, 23, 6, 9, 25, 5, 8, 24,
		7, 20, 2, 19, 12, 11, 9, 23, 10, 22,
		5, 8, 0, 4, 6, 19, 13, 3, 14, 23,
		17, 9, 20, 11, 0, 21, 28, 12, 1, 10,
		14, 22, 6, 18, 7, 0, 8, 15, 28, 26,
		11, 5, 10, 1, 24, 9, 7, 21, 13, 18
	};

	private string puplicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAhjIcxGzsE1uQnVbhlLdStL91RMf8khb/LSuDuYzIOlexVYm3lU0hTiISb+K25+8EuvDCXXGz1K5IjI8qaqM9Bn8Es6Agbhvc1NepOdJ++IMt/KOVW8gYAGNioLkmSX9E0kaHG/t3fLvcbnbXUKsASUlLrW+av62LVxP8pkzOXoMAvxN7qUUHTb+AkVBIQgAqSDXvk9i9VM7ut47eVnH60WZXqfCX4nxadef1o0YlElpZ6/ZN3nJSHFsIzT1luaYKdoDdoXvr+QdwpUccXS17ZuEArMevkc0E2xC7pi7KuA0JUr7wNJjEF/s5jEZGN0haJvaLwJhXBOUV4Vrc53bRRQIDAQAB";

	private string currentLang = "English";

	public IGT_PathInfo PlayerObj;

	public IGT_AcceleroMeter AccObj;

	public IGT_TouchHandler TchObj;

	public IGT_FileReading fileDatas;

	private IGT_ThrowObjects pThrow;

	private bool bDontShowAdOnAppPause;

	public static Func<int, int> pGetMissionInfo;

	public GameObject player;

	public GameObject Heroine;

	public static GameObject Hero_shadow_projector;

	public static GameObject AI_shadow_projector;

	public static GameObject Hero_shadow_projector1;

	private GameObject Hero_headPath;

	private Vector3 Acceleration = Vector3.zero;

	public float offset_Laneoffset;

	public float fLaneTempOffset;

	public float centerOffset;

	public float fDestinationLaneOffset;

	public float fprevOffet;

	public static int nUserInput;

	public static Queue<int> userInputQueue = new Queue<int>();

	public static bool bGameOver = false;

	public static bool bLevelUp = false;

	private bool bNxtPathAvail;

	public int playerCollisionStates;

	public int playerCollisionStatesfrMovingObj;

	public static bool bStrtButton = false;

	public static bool bPauseButton = false;

	public static bool bRobbingSceneFinished = false;

	public static bool bAIplayerStart = false;

	public static bool bBagInHeroinHand = false;

	public static bool bCamStartFollow = false;

	public static bool bMissionIntro = false;

	public static float fdist_robbingscene;

	public static float fTime_robbScene;

	public static float fTime_CamJoint;

	public Vector3 crossProductVal = Vector3.zero;

	public Vector3 nextExpectedPos = Vector3.zero;

	public Vector3 movingDirOfPlayer = Vector3.zero;

	private Vector3 animPointVec_Spline = Vector3.zero;

	public float fDistBw2Points;

	public Vector3 PlayerprevPos = Vector3.zero;

	public Vector3 PlayerCurPos = Vector3.zero;

	public Vector3 playerbeforePrevPos = Vector3.zero;

	public float fCurVelocity;

	public static List<IGT_CamPositions> pIgtCamPos = new List<IGT_CamPositions>();

	public static bool bKickWithinAnimRange = false;

	public static bool bKickAnimCanEnable = false;

	public static bool bKickAnimMissed = false;

	public static bool bkickObjFly = false;

	public static bool bKickObjMoving = false;

	public static bool bKickobjCanMove = true;

	public static bool bThrwObjPicked = false;

	public static bool bPickdObjCanThrow = false;

	public static bool bThrowObjCanMove = true;

	public static bool bThrowObjMoving = false;

	public static bool bPickObjSelected = false;

	private double dPickobjSelectdTime;

	private bool bLeftLaneShift;

	private bool bRightLaneShift;

	public static bool bAcceleroMeterEnabled = false;

	private bool bTurning;

	private float initAccDiff = 10000f;

	private float fInitAccAngle;

	private float fMinAccRange;

	private float fMaxAccRange;

	public static int nPixelFrTouchCalc = 0;

	public static double startFrame;

	public static double fLastFPSTick;

	public static double fTimeFrObjDiffculty;

	private int nDispFrames;

	private int nDispFPS;

	private int nMinFrameCount;

	private double fDispFPS;

	public GameObject Hero_HandWristPos;

	public GameObject Hero_HandWristPos_Left;

	public GameObject Heroine_Wrist;

	public GameObject Hero_HeadPos;

	public List<IGT_CoinAnimation> pCoinAnim = new List<IGT_CoinAnimation>();

	public List<GameObject> pCoinObj = new List<GameObject>();

	public int pathIDFrFindingPosBasedGivenDist = -1;

	public int StrtPosIDFrFindingPosBasedGivenDist = -1;

	private bool bSelectDataFrMovingBWPath;

	public static bool bLevelFailed = false;

	public bool bCanResume;

	public bool bUseKey;

	public List<IGT_FacebookData> FacebookDatas = new List<IGT_FacebookData>();

	private SkinnedMeshRenderer pHero_MeshRenderer;

	private Material[] pHeroMaterials;

	private Material pKick_TrailFireMaterial;

	private Material pHeroTransperent_Material;

	public float fGameoverAnimTime;

	public bool bEnergyItemsAnimation;

	public bool bAutoMaticModefrTesting;

	public bool bTestingTeamPurpose;

	private bool bAIMode;

	public int nAIPlayerIndex;

	public bool bNextAIPlayerGonnaPickPurse;

	public bool bLevelUpButtonPressed;

	public GameObject Endless_Bag;

	public static bool bBagMovingInCurve = false;

	private float fEndlessBag_offset_inPicking;

	private Vector3 PlayerToAIStrtVecwhileGonnaPickPurse;

	private Vector3 PlayerToAICurVecwhileGonnaPickPurse;

	private Vector3 AIplayerToHeroStrtVecInGameLevelUpScreen;

	private Vector3 AIplayerToHeroCurVecInGameLevelUpScreen;

	public List<IGT_AIPlayerData> pAIPlayerData;

	public List<IGT_HeroData> pHeroData;

	public int nHeroIndex;

	private bool bHeroPathSelctionUptoReachAnotherPathEndFinishd = true;

	public int PartialObjPlacement_curStep;

	public float PartialObjPlacement_MinDist;

	public IGT_LagrangeInterPolation pLegrangeInterPolation_Hero;

	public IGT_LagrangeInterPolation pLegrangeInterPolation_AI;

	public int nAIPlayerActionState;

	public bool isSurpriseAiAvailable;

	public IGT_IAPManagerAssist pIGT_IAPManagerAssist;

	public List<IGT_PurchaseItemsData> pPurchaseItemsData_Store;

	public List<IGT_PurchaseItemsData> pPurchaseItemsData_Deals;

	public List<IGT_PurchaseItemsData> pPurchaseItemsData_Free;

	public List<IGT_PurchaseItemsData> pPurchaseItemsData_Boost;

	private IGT_Translator pIgtTranslator;

	private TextAsset xmlTextAsset;

	public bool isAIplayerAvailable;

	public IGT_Missions pMissionData;

	public int nGameMode;

	public int nMissionID;

	public bool bMissionCompleted;

	public bool bMissionManualEnding;

	public GameObject missionEndWall;

	public int nCollectedItemCount;

	public int nNoOfCollectionObjHeroCrossed;

	public int nNoOfChallengeObjHeroMissed;

	public int nNoOf_WF_CharCrossed;

	public int[] nCollectedMultipleItemCount;

	public int[] nNoOfMulitpleCollObjHeroCrossed;

	public int[] nNoOfMultiColObjCrossedUntillTargetAcheived;

	public double dChaseModeStrtTime;

	public double dMissionStrtTime;

	public double dLiftTime_of_WordFindingMode;

	public double dLifeTime_of_BringBackMode;

	public int nTimeLeft_in_WordFindingMode;

	public int nTimeLeft_in_BringBackMode;

	private GameObject BB_CollectionItem;

	private GameObject BB_CollectionItemGlow;

	public bool bHasPicked_BBitem;

	private float BB_TarAbsDistfrmStrt;

	public IGT_CharArray[] pCharArray;

	private List<IGT_ZoneData>[] ZoneData = new List<IGT_ZoneData>[IGT_Constants.nZoneCount];

	private IGT_ZoneData pIgtZoneData;

	public IGT_saveLevelData pIgtSavelevelData;

	public AudioSource _AudioSource;

	public AudioSource _AudioSource2;

	public AudioSource _AudioSource3;

	public AudioSource _AudioSource4;

	public AudioSource _AudioSource5;

	public AudioClip[] _AudioClips;

	public AudioClip[] _AudioClips_Coin;

	public AudioClip[] _AudioClips_BGM;

	private int nCoinSoundIdx;

	private GameObject _AudioSourceGameObject;

	private GameObject _AudioSource2GameObject;

	private GameObject _AudioSource3GameObject;

	private GameObject _AudioSource4GameObject;

	private GameObject _AudioSource5GameObject;

	public int nMusic;

	public int nSound;

	public int nGameNotification;

	private IGT_LevelGenerator pIGT_LevGenerator;

	public List<IGT_BezierAnimation> pBezierAnimation = new List<IGT_BezierAnimation>();

	public List<IGT_BezierAnimation> pBezierAnimation_Group = new List<IGT_BezierAnimation>();

	public float fBezierGroupAnimTime;

	public IGT_LifeCalc pIGt_LifeCalc;

	private int curArrpnt;

	private int grapLimitval;

	private Vector3[] graph1;

	private Vector3[] graph2;

	private float fAvgSpdFluctuation;

	public bool bSplPowersActivated;

	public bool bMagnet;

	public bool bCoin_2x;

	public bool bCoin_3x;

	public bool bInvisibleMode;

	public bool bSpdInc;

	public bool bSpdDec;

	private GameObject _Go_Magnet;

	private GameObject _Go_Smoke;

	private float fSpd_Dec_PrevSpd;

	private float fSpd_Inc_PrevSpd;

	private GameObject heartSound;

	private AudioSource heartSource;

	public int nTutorial;

	public int nTutorialLevelCount;

	public int nChaseNewBadge;

	public int[] nTutorialStartPath;

	public int[] nTutorialAIindex;

	public IGT_CamControl pIgtCamControl;

	public int nScore_Current;

	public int nScore_Coin_Chase;

	public int nStar_Current = -1;

	public int nTotScore_Chase;

	public int nTotScore_Mission;

	public int nHigh_Score_Chase;

	public int nHigh_Score_Mission;

	public int nDealComboOffer_1;

	public int nDealComboOffer_2;

	private int[,] nPreDefinedMissionLevelInfo;

	private bool bReduceAlpha;

	public int nTot_KickCount;

	public int nTot_ThrowCount;

	public List<IGT_CaughtDetails> pIGT_CaughtDet;

	private float fTempMissionSpdStrtUpAdj;

	private float fTempChaseSpdStrtUpAdj;

	private GameObject[] HeroCharacters_Low;

	public bool bFpsBased3dModelUsage_FirstTime;

	public float fTimeForFpsBased3dModelUsage;

	public int nDispFrames_3dModelUsage;

	public int nTargetFrameRate;

	public int n3dModelUsageMode;

	public int n3dModelUsageMode_Prev;

	public float fLowFpsMode_StrtTime;

	public float fMediumFpsMode_StrtTime;

	public float nTotFrameSamples;

	public float nTotFps;

	public bool bRemoveAds;

	public bool bCanShowAdOnForeGround;

	private GameObject pDirLight;

	private IGT_Animator pDirLightAnimator;

	private float fDirLight_Src;

	private float fDirLight_Dest;

	private List<int> nHeroAdjPath;

	private GameObject Building_High;

	private GameObject Building_Low;

	private const double fbProPicRefreshInterval = 21600.0;

	public int nChaseTotAttemps;

	public bool b30FpsMode;

	public bool bRestart;

	private Vector3 lastCollidedCoinPosition = Vector3.zero;

	private Vector3 lastCollidedEnergyItemPos = Vector3.zero;

	public float fBB_DirMapAngle;

	private float fTimeOffsetChange;

	private Vector3[] NeededPos = new Vector3[6];

	private int surprisePlayerId;

	private float fMinFrameTime = 999f;

	private int nMinFramTime;

	private void Start()
	{
		fLastFPSTick = Time.time;
		PlayerObj = new IGT_PathInfo();
		AccObj = new IGT_AcceleroMeter();
		TchObj = new IGT_TouchHandler();
		fileDatas = new IGT_FileReading();
		pIGt_LifeCalc = new IGT_LifeCalc(5, 15f, IGT_Constants.playerPref_currentLifeCount, IGT_Constants.playerPref_LifeLastAddedTime);
		pIGT_LevGenerator = new IGT_LevelGenerator();
		pIgtSavelevelData = new IGT_saveLevelData();
		pMissionData = new IGT_Missions();
		loadPredefinedMissionLevelInfo();
		pIgtCamControl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<IGT_CamControl>();
		pIgtCamControl._Start();
		pLegrangeInterPolation_Hero = new IGT_LagrangeInterPolation();
		pLegrangeInterPolation_Hero.addReferenceValues(0.1f, 0.95f, 0.08f, 0.8f, 0.06f, 0.5f, 0.04f, 0.3f, 0.02f, 0.1f, 0f, 0f);
		pLegrangeInterPolation_AI = new IGT_LagrangeInterPolation();
		pLegrangeInterPolation_AI.addReferenceValues(1f, 1f, 0.75f, 0.97f, 0.5f, 0.9f, 0.25f, 0.75f, 0.1f, 0.65f, 0f, 0.6f);
		IGT_ObjPlacing.objInstantiating();
		IGT_MovingObjPlacing.MovingObjInstantiating();
		splPowers_Instantiation();
		PlayerObj.SelectStaticObjectsDetailsFromFile();
		_AudioSourceGameObject = new GameObject("AudioSource_1");
		_AudioSourceGameObject.AddComponent<AudioSource>();
		_AudioSource = _AudioSourceGameObject.GetComponent<AudioSource>();
		_AudioSource.loop = true;
		_AudioSource5GameObject = new GameObject("AudioSource_5");
		_AudioSource5GameObject.AddComponent<AudioSource>();
		_AudioSource5 = _AudioSource5GameObject.GetComponent<AudioSource>();
		HeroDataSelection();
		HeroCharInstantiation();
		AIPlayerDataSelfrmFile();
		getSavedDatas();
		PurchaseItemsDataSelectionFromFile();
		INAPP_Init();
		MultiLanguageDataSel();
		Load_ZoneDatas();
		loadAudios();
		Game_Notification();
		bStrtButton = false;
		Input.multiTouchEnabled = false;
		nPixelFrTouchCalc = Screen.width / 320 * 9 / 2 + Screen.height / 480 * 9 / 2;
		Acceleration = Input.acceleration;
		PlayerObj.fDeviceWidth = Screen.width;
		PlayerObj.fDeviceHeight = Screen.height;
		nAIPlayerIndex = -1;
		bFpsBased3dModelUsage_FirstTime = true;
		b30FpsMode = false;
		MusicAudioSelector();
		InvokeRepeating("PlayMusicWithFade", 0f, 0.2f);
		bCanShowAdOnForeGround = true;
		pGetMissionInfo = getMissionModeInfo;
		bDontShowAdOnAppPause = true;
		post_Analytics_Screen_Button_Datas("GameStart", string.Empty, false);
		bAutoMaticModefrTesting = false;
		bTestingTeamPurpose = false;
		bAIMode = false;
	}

	private void loadPredefinedMissionLevelInfo()
	{
		nPreDefinedMissionLevelInfo = new int[35, 2];
		nPreDefinedMissionLevelInfo[0, 0] = -1;
		nPreDefinedMissionLevelInfo[0, 1] = -1;
		nPreDefinedMissionLevelInfo[1, 0] = -1;
		nPreDefinedMissionLevelInfo[1, 1] = -1;
		nPreDefinedMissionLevelInfo[2, 0] = -1;
		nPreDefinedMissionLevelInfo[2, 1] = -1;
		nPreDefinedMissionLevelInfo[3, 0] = -1;
		nPreDefinedMissionLevelInfo[3, 1] = -1;
		nPreDefinedMissionLevelInfo[4, 0] = -1;
		nPreDefinedMissionLevelInfo[4, 1] = -1;
		nPreDefinedMissionLevelInfo[5, 0] = 1;
		nPreDefinedMissionLevelInfo[5, 1] = 0;
		nPreDefinedMissionLevelInfo[6, 0] = 2;
		nPreDefinedMissionLevelInfo[6, 1] = 3;
		nPreDefinedMissionLevelInfo[7, 0] = 1;
		nPreDefinedMissionLevelInfo[7, 1] = 2;
		nPreDefinedMissionLevelInfo[8, 0] = 0;
		nPreDefinedMissionLevelInfo[8, 1] = 2;
		nPreDefinedMissionLevelInfo[9, 0] = 1;
		nPreDefinedMissionLevelInfo[9, 1] = 4;
		nPreDefinedMissionLevelInfo[10, 0] = 3;
		nPreDefinedMissionLevelInfo[10, 1] = 0;
		nPreDefinedMissionLevelInfo[11, 0] = 3;
		nPreDefinedMissionLevelInfo[11, 1] = 1;
		nPreDefinedMissionLevelInfo[12, 0] = 5;
		nPreDefinedMissionLevelInfo[12, 1] = 0;
		nPreDefinedMissionLevelInfo[13, 0] = 4;
		nPreDefinedMissionLevelInfo[13, 1] = 0;
		nPreDefinedMissionLevelInfo[14, 0] = 4;
		nPreDefinedMissionLevelInfo[14, 1] = 1;
		nPreDefinedMissionLevelInfo[15, 0] = 0;
		nPreDefinedMissionLevelInfo[15, 1] = 0;
		nPreDefinedMissionLevelInfo[16, 0] = 2;
		nPreDefinedMissionLevelInfo[16, 1] = 1;
		nPreDefinedMissionLevelInfo[17, 0] = 3;
		nPreDefinedMissionLevelInfo[17, 1] = 2;
		nPreDefinedMissionLevelInfo[18, 0] = 1;
		nPreDefinedMissionLevelInfo[18, 1] = 1;
		nPreDefinedMissionLevelInfo[19, 0] = 5;
		nPreDefinedMissionLevelInfo[19, 1] = 1;
		nPreDefinedMissionLevelInfo[20, 0] = 4;
		nPreDefinedMissionLevelInfo[20, 1] = 2;
		nPreDefinedMissionLevelInfo[21, 0] = 2;
		nPreDefinedMissionLevelInfo[21, 1] = 4;
		nPreDefinedMissionLevelInfo[22, 0] = 0;
		nPreDefinedMissionLevelInfo[22, 1] = 4;
		nPreDefinedMissionLevelInfo[23, 0] = 3;
		nPreDefinedMissionLevelInfo[23, 1] = 3;
		nPreDefinedMissionLevelInfo[24, 0] = 5;
		nPreDefinedMissionLevelInfo[24, 1] = 2;
		nPreDefinedMissionLevelInfo[25, 0] = 2;
		nPreDefinedMissionLevelInfo[25, 1] = 2;
		nPreDefinedMissionLevelInfo[26, 0] = 0;
		nPreDefinedMissionLevelInfo[26, 1] = 1;
		nPreDefinedMissionLevelInfo[27, 0] = 4;
		nPreDefinedMissionLevelInfo[27, 1] = 3;
		nPreDefinedMissionLevelInfo[28, 0] = 5;
		nPreDefinedMissionLevelInfo[28, 1] = 3;
		nPreDefinedMissionLevelInfo[29, 0] = 2;
		nPreDefinedMissionLevelInfo[29, 1] = 0;
		nPreDefinedMissionLevelInfo[30, 0] = 0;
		nPreDefinedMissionLevelInfo[30, 1] = 3;
		nPreDefinedMissionLevelInfo[31, 0] = 4;
		nPreDefinedMissionLevelInfo[31, 1] = 4;
		nPreDefinedMissionLevelInfo[32, 0] = 1;
		nPreDefinedMissionLevelInfo[32, 1] = 3;
		nPreDefinedMissionLevelInfo[33, 0] = 3;
		nPreDefinedMissionLevelInfo[33, 1] = 4;
		nPreDefinedMissionLevelInfo[34, 0] = 5;
		nPreDefinedMissionLevelInfo[34, 1] = 4;
	}

	private void select_LevelGenerationDatas()
	{
		int[] array = new int[30]
		{
			100, 75, 50, 50, 100, 200, 250, 150, 175, 250,
			225, 125, 250, 150, 150, 100, 125, 150, 200, 200,
			75, 100, 125, 150, 150, 25, 50, 50, 100, 75
		};
		int num = 0;
		int num2 = 2000;
		System.Random random = new System.Random();
		int[,] array2 = new int[num2, 3];
		while (num < num2)
		{
			bool flag = false;
			int num3 = 0;
			int num4 = UnityEngine.Random.Range(0, array.Length);
			int num5 = (random.Next() % 89 + random.Next() % 991 + random.Next() % 9967) % 3975;
			for (int i = 0; i < array.Length; i++)
			{
				num3 += array[i];
				if (num3 >= num5)
				{
					num4 = i;
					break;
				}
			}
			int num6 = num4 / 5 % 6;
			int num7 = num4 % 5;
			if (num > 3)
			{
				int num8 = array2[num - 1, 0];
				int num9 = array2[num - 2, 0];
				if (num6 == num8 && num6 == num9)
				{
					flag = true;
				}
			}
			int num10 = 0;
			if (num > 10)
			{
				num10 = num - 10;
			}
			for (int num11 = num - 1; num11 >= num10; num11--)
			{
				if (num6 == array2[num11, 0] && num7 == array2[num11, 1])
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				array2[num, 0] = num6;
				array2[num, 1] = num7;
				array2[num, 2] = num4;
				num++;
			}
		}
		string text = "{";
		for (int j = 0; j < array2.GetLength(0); j++)
		{
			text = ((j == array2.GetLength(0) - 1) ? (text + array2[j, 2] + "}") : (text + array2[j, 2] + ","));
		}
		File.WriteAllText("Assets/Resources/Info/GeneratedLevels.txt", text);
	}

	private void write_GeneratedDatasInfo()
	{
		int[,] array = new int[6, 5];
		int num = 35;
		string path = "Assets/Resources/Info/GeneratedLevelInfo.txt";
		for (int i = 0; i < GeneratedLevelDatas.Length; i++)
		{
			string text = string.Empty;
			int num2 = GeneratedLevelDatas[i] / 5 % 6;
			int num3 = GeneratedLevelDatas[i] % 5;
			switch (num2)
			{
			case 0:
				text = num.ToString() + "," + GeneratedLevelDatas[num - nPreDefinedMissionLevelInfo.GetLength(0)].ToString() + ",Collection," + num3.ToString() + "," + array[0, num3];
				array[0, num3]++;
				break;
			case 1:
				text = num.ToString() + "," + GeneratedLevelDatas[num - nPreDefinedMissionLevelInfo.GetLength(0)].ToString() + ",Challenge," + num3.ToString() + "," + array[1, num3];
				array[1, num3]++;
				break;
			case 2:
				text = num.ToString() + "," + GeneratedLevelDatas[num - nPreDefinedMissionLevelInfo.GetLength(0)].ToString() + ",Catch," + num3.ToString() + "," + array[2, num3];
				array[2, num3]++;
				break;
			case 3:
				text = num.ToString() + "," + GeneratedLevelDatas[num - nPreDefinedMissionLevelInfo.GetLength(0)].ToString() + ",Word," + num3.ToString() + "," + array[3, num3];
				array[3, num3]++;
				break;
			case 4:
				text = num.ToString() + "," + GeneratedLevelDatas[num - nPreDefinedMissionLevelInfo.GetLength(0)].ToString() + ",BB," + num3.ToString() + "," + array[4, num3];
				array[4, num3]++;
				break;
			case 5:
				text = num.ToString() + "," + GeneratedLevelDatas[num - nPreDefinedMissionLevelInfo.GetLength(0)].ToString() + ",MultiColl," + num3.ToString() + "," + array[5, num3];
				array[5, num3]++;
				break;
			}
			num++;
			if (i == 0)
			{
				File.WriteAllText(path, text);
				continue;
			}
			string text2 = File.ReadAllText(path);
			text2 = text2 + "\n" + text;
			File.WriteAllText(path, text2);
		}
	}

	public void post_Analytics_Screen_Button_Datas(string screenName, string buttonName, bool bHasParameters = true)
	{
		if (bHasParameters)
		{
			Analytics.CustomEvent("Buttons", new Dictionary<string, object>
			{
				{ "ScreenName", screenName },
				{ "But_Name", buttonName }
			});
		}
		else
		{
			Analytics.CustomEvent(screenName);
		}
	}

	private void post_Analytics_Purchase(int screenName, string PurchaseItemName, int PurchaseStatus)
	{
		Analytics.CustomEvent("Purchase", new Dictionary<string, object>
		{
			{ "ScreenName", screenName },
			{ "PurchaseObjName", PurchaseItemName },
			{ "PurchaseStatus", PurchaseStatus }
		});
	}

	private void post_Analytics_EndlessRun(int RobberIdx)
	{
		Analytics.CustomEvent("EndlessRun", new Dictionary<string, object> { 
		{
			"Robber_",
			RobberIdx + 1
		} });
	}

	private void post_Analytics_Missions(int levelID, string missionName, int attempts)
	{
		Analytics.CustomEvent("Mission", new Dictionary<string, object>
		{
			{ "Lev_", levelID },
			{ "MissionType", missionName },
			{ "Attempts", attempts }
		});
	}

	public void post_Analytics_Popup(string popupName)
	{
		Analytics.CustomEvent("Popup", new Dictionary<string, object> { { "Name", popupName } });
	}

	public void post_Analytics_RateIt(string windowName)
	{
		Analytics.CustomEvent("RateIt", new Dictionary<string, object> { { "Name", windowName } });
	}

	private void post_Analytics_Performance(int fps, int Gmode)
	{
		Analytics.CustomEvent("Performance", new Dictionary<string, object>
		{
			{ "fps", fps },
			{ "Graphics", Gmode }
		});
	}

	public void shadowprojectorCreation(bool bheroforshadow = true)
	{
		if (Hero_shadow_projector1 != null)
		{
			Hero_shadow_projector1.SetActive(true);
		}
		Material material = Resources.Load("HeroMaterials/Materials/ShadowProjector") as Material;
		Hero_headPath = GameObject.Find(IGT_Constants.Hero_String + nHeroIndex + IGT_Constants.Hero_headfor_shadow);
		if (bheroforshadow)
		{
			if (GameObject.Find("shadow_projector") == null)
			{
				Hero_shadow_projector = new GameObject("shadow_projector");
			}
			else
			{
				Hero_shadow_projector = GameObject.Find("shadow_projector");
			}
			if (Hero_shadow_projector.GetComponent<Projector>() == null)
			{
				Hero_shadow_projector.AddComponent<Projector>();
			}
			Projector component = Hero_shadow_projector.GetComponent<Projector>();
			component.transform.position = new Vector3(1.10705f, 0.61981f, -69.663f);
			component.transform.rotation = Quaternion.Euler(new Vector3(90f, 0f, 0f));
			component.nearClipPlane = 0.1f;
			component.farClipPlane = 4.52f;
			component.fieldOfView = 50.75f;
			component.aspectRatio = 1f;
			component.material = material;
			component.ignoreLayers |= 1 << LayerMask.NameToLayer(IGT_Constants.layer_Characters);
			Hero_shadow_projector.SetActive(false);
			if (GameObject.Find("shadow_projector1") == null)
			{
				Hero_shadow_projector1 = new GameObject("shadow_projector1");
				if (Hero_shadow_projector1.GetComponent<Projector>() == null)
				{
					Hero_shadow_projector1.AddComponent<Projector>();
				}
				Projector component2 = Hero_shadow_projector1.GetComponent<Projector>();
				component2.transform.position = new Vector3(1.103f, 0.689f, -69.724f);
				component2.transform.rotation = Quaternion.Euler(new Vector3(86.4f, 154.33f, -11.4f));
				component2.nearClipPlane = 0.1f;
				component2.farClipPlane = 4.52f;
				component2.fieldOfView = 25.75f;
				component2.aspectRatio = 1f;
				component2.material = material;
				component2.ignoreLayers |= 1 << LayerMask.NameToLayer(IGT_Constants.layer_Characters);
			}
			else
			{
				Hero_shadow_projector1 = GameObject.Find("shadow_projector1");
			}
			Hero_shadow_projector1.transform.parent = Hero_headPath.transform;
		}
		else
		{
			if (GameObject.Find("shadow_projector_AI") == null)
			{
				AI_shadow_projector = new GameObject("shadow_projector_AI");
			}
			else
			{
				AI_shadow_projector = GameObject.Find("shadow_projector_AI");
			}
			if (AI_shadow_projector.GetComponent<Projector>() == null)
			{
				AI_shadow_projector.AddComponent<Projector>();
			}
			Projector component3 = AI_shadow_projector.GetComponent<Projector>();
			component3.transform.position = new Vector3(IGT_AIPlayer.AI_Headforshadow.transform.position.x, IGT_AIPlayer.AI_Headforshadow.transform.position.y, IGT_AIPlayer.AI_Headforshadow.transform.position.z);
			component3.transform.rotation = Quaternion.Euler(new Vector3(83.843f, -169.4f, -15.991f));
			component3.nearClipPlane = 0.1f;
			component3.farClipPlane = 4.52f;
			component3.fieldOfView = 45.75f;
			component3.aspectRatio = 1f;
			component3.material = material;
			component3.ignoreLayers |= 1 << LayerMask.NameToLayer(IGT_Constants.layer_Characters);
		}
	}

	private void Game_Notification()
	{
		if (nGameNotification == 0)
		{
			IGT_AndroidLocalNotificationManager.getInstance().setGameNotification(3, 7, 14);
			if (pIGt_LifeCalc.getCurrentLifeCount() >= pIGt_LifeCalc.getTotalGivenLifeCount())
			{
				IGT_AndroidLocalNotificationManager.getInstance().cancelLifeNotification();
			}
		}
	}

	private void schedule_LocalNotificationFor_IOS()
	{
	}

	private void splPowers_Instantiation()
	{
		_Go_Magnet = UnityEngine.Object.Instantiate(IGT_ObjPlacing.spl_MagnetYellow, new Vector3(300f, -100f, 300f), Quaternion.identity);
		_Go_Magnet.transform.localScale = Vector3.one * 0.5f;
		_Go_Magnet.name = "MagnetPower";
		_Go_Magnet.SetActive(false);
		_Go_Smoke = UnityEngine.Object.Instantiate(Resources.Load("Objects/WhiteSmoke"), new Vector3(300f, -100f, 300f), Quaternion.identity) as GameObject;
		_Go_Smoke.transform.Rotate(new Vector3(-90f, 0f, 0f));
		_Go_Smoke.name = "Smoke";
		_Go_Smoke.GetComponent<ParticleSystem>().Stop();
		_Go_Smoke.SetActive(false);
	}

	private void splPower_Hide()
	{
		if (bSpdInc)
		{
			PlayerObj.speed = fSpd_Inc_PrevSpd;
		}
		else if (bSpdDec)
		{
			PlayerObj.speed = fSpd_Dec_PrevSpd;
			if (isAIplayerAvailable)
			{
				IGT_AIPlayer.bRobberDisconnect = false;
			}
		}
		bSplPowersActivated = false;
		bMagnet = (bCoin_2x = (bCoin_3x = (bInvisibleMode = (bSpdInc = (bSpdDec = false)))));
		_Go_Magnet.SetActive(false);
		IGT_ObjPlacing.Change_CoinTexture(1);
		IGT_GameView.pIgtDispProp.Clear();
		if (bHasPicked_BBitem && BB_CollectionItem != null)
		{
			BB_CollectionItem.SetActive(false);
		}
	}

	private void OnApplicationPause(bool isPause)
	{
		if (isPause)
		{
			if (IGT_GameView.nScreenMode == 1 || IGT_GameView.nScreenMode == 2 || IGT_GameView.nScreenMode == 3)
			{
				canDecrease_Life();
			}
			IGT_AndroidLocalNotificationManager.getInstance().onPause();
			if (IGT_GameView.nScreenMode == 1 || IGT_GameView.nScreenMode == 21)
			{
				IGT_GameView.pauseButtonEvents();
			}
		}
		else
		{
			IGT_AndroidLocalNotificationManager.getInstance().onResume();
			if (!bRemoveAds && IGT_GameView.CanIgnoreAdOnFirstInstall() && bCanShowAdOnForeGround && IGT_GameView.nScreenMode != 1 && IGT_GameView.nScreenMode != 2 && IGT_GameView.nScreenMode != 8 && IGT_GameView.nScreenMode != 3 && IGT_GameView.nScreenMode != 4 && IGT_GameView.nScreenMode != 20)
			{
				if (!bDontShowAdOnAppPause)
				{
					if (IGT_GameView.pAds != null)
					{
						if (!IGT_GameView.pAds.isInterstitialAdAvailable())
						{
							IGT_GameView.pAds.RequestInterstitial();
						}
						IGT_GameView.pAds.ShowInterstitial();
					}
				}
				else
				{
					bDontShowAdOnAppPause = false;
				}
			}
			bCanShowAdOnForeGround = true;
			if ((double)IGT_GameView.currentTimeSecs() - IGT_GameView.timeTorRefreshFBlistDict >= 21600.0 && IGT_GameView.pFacebook != null && IGT_GameView.pFacebook.isFBLoginSucess() && isConnectedInternet())
			{
				IGT_GameView.timeTorRefreshFBlistDict = IGT_GameView.currentTimeSecs();
				if (IGT_GameView.pRefreshFBlistAction != null)
				{
					IGT_GameView.pRefreshFBlistAction(IGT_GameView.pGetCompleted, null, null, null);
				}
			}
			if ((IGT_GameView.nScreenMode == 1 || IGT_GameView.nScreenMode == 2 || IGT_GameView.nScreenMode == 3) && ((nGameMode == 0 && nChaseTotAttemps > 5) || (nGameMode == 1 && nMissionID >= nTutorialLevelCount)))
			{
				pIGt_LifeCalc.forceAddLifeCount(1);
			}
		}
		if (IGT_GameView.bHS_mailbox && IGT_GameView.listAskSend != null)
		{
			IGT_GameView.MailBoxScroll_CurPos.y = IGT_UIcommonFunc.ScaleY(0f);
		}
		else if (IGT_GameView.bHS_asklife && IGT_GameView.listAskLife != null)
		{
			IGT_GameView.AskLifeScroll_CurPos.y = IGT_UIcommonFunc.ScaleY(0f);
		}
		else if (IGT_GameView.bHS_sendlife && IGT_GameView.listSendLife != null)
		{
			IGT_GameView.SendLifeScroll_CurPos.y = IGT_UIcommonFunc.ScaleY(0f);
		}
	}

	private void OnApplicationQuit()
	{
		IGT_AndroidLocalNotificationManager.getInstance().onPause();
	}

	public void canDecrease_Life()
	{
		if (nGameMode == 0)
		{
			nChaseTotAttemps++;
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_chaseTotAttempts, nChaseTotAttemps);
		}
		if ((nGameMode == 0 && nChaseTotAttemps > 5) || (nGameMode == 1 && nMissionID >= nTutorialLevelCount))
		{
			decrease_LifeCount(1);
		}
	}

	public void decrease_LifeCount(int count)
	{
		pIGt_LifeCalc.decreaseLifeCount(1);
		if (pIGt_LifeCalc.getCurrentLifeCount() < pIGt_LifeCalc.getTotalGivenLifeCount())
		{
			long lifeNotification = (long)((float)pIGt_LifeCalc.getRemainingLifeCount() * pIGt_LifeCalc.getEachLife_RespawnInterval());
			if (nGameNotification == 0)
			{
				IGT_AndroidLocalNotificationManager.getInstance().setLifeNotification(lifeNotification);
			}
		}
	}

	private void getSavedDatas()
	{
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_HighScore_Chase))
		{
			nHigh_Score_Chase = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_HighScore_Chase, 0);
		}
		else
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_HighScore_Chase, 0);
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_HighScore_Mission))
		{
			nHigh_Score_Mission = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_HighScore_Mission, 0);
		}
		else
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_HighScore_Mission, 0);
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_TotScore_Chase))
		{
			nTotScore_Chase = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_TotScore_Chase, 0);
		}
		else
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotScore_Chase, 0);
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_TotScore_Mission))
		{
			nTotScore_Mission = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_TotScore_Mission, 0);
		}
		else
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotScore_Mission, 0);
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_TotCoins))
		{
			IGT_Constants.nTotNoOfCoins = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_TotCoins, IGT_Constants.nTotNoOfCoins);
		}
		else
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotCoins, IGT_Constants.nTotNoOfCoins);
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_Music))
		{
			nMusic = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_Music, 0);
		}
		else
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_Music, 0);
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_Sound))
		{
			nSound = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_Sound, 0);
		}
		else
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_Sound, 0);
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_Notification))
		{
			nGameNotification = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_Notification, 0);
		}
		else
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_Notification, 0);
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_TotKeyCount))
		{
			IGT_Constants.nTotKeysCount = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_TotKeyCount, IGT_Constants.nTotKeysCount);
		}
		else
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotKeyCount, IGT_Constants.nTotKeysCount);
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_Tutorial))
		{
			nTutorial = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_Tutorial, 0);
		}
		else
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_Tutorial, 0);
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_chaseNewBadge))
		{
			nChaseNewBadge = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_chaseNewBadge, 1);
		}
		else
		{
			nChaseNewBadge = 1;
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_chaseNewBadge, nChaseNewBadge);
		}
		nDealComboOffer_1 = (nDealComboOffer_2 = 1);
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_Combo1))
		{
			nDealComboOffer_1 = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_Combo1, 1);
		}
		else
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_Combo1, 1);
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_Combo2))
		{
			nDealComboOffer_2 = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_Combo2, 1);
		}
		else
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_Combo2, 1);
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_KickCount))
		{
			nTot_KickCount = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_KickCount, 0);
		}
		else
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_KickCount, nTot_KickCount);
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_ThrowCount))
		{
			nTot_ThrowCount = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_ThrowCount, 0);
		}
		else
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_ThrowCount, nTot_ThrowCount);
		}
		pIGT_CaughtDet = new List<IGT_CaughtDetails>();
		if (!IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_CaugthDatas))
		{
			for (int i = 0; i < pAIPlayerData.Count; i++)
			{
				pIGT_CaughtDet.Add(new IGT_CaughtDetails(pAIPlayerData[i].Name, 0, 0));
			}
			save_CaugthDetails();
		}
		else
		{
			retrive_CaughtDetails();
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_RemoveAds))
		{
			float num = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_RemoveAds, 0);
			if (num == 0f)
			{
				bRemoveAds = false;
			}
			else
			{
				bRemoveAds = true;
			}
		}
		else
		{
			bRemoveAds = false;
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_RemoveAds, 0);
		}
		if (!IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_AdsIgonreFirstInstall))
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_AdsIgonreFirstInstall, 0);
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_AdsIgonreFirstInstall_StrtTime, (float)IGT_GameView.currentTimeSecs());
		}
		if (!IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_Tot3StarCount))
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_Tot3StarCount, 0);
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_chaseTotAttempts))
		{
			nChaseTotAttemps = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_chaseTotAttempts, 0);
		}
		else
		{
			nChaseTotAttemps = 0;
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_chaseTotAttempts, nChaseTotAttemps);
		}
		IGT_Preference.getInstance()._SaveAll();
		nTutorialLevelCount = 5;
		nTutorialStartPath = new int[nTutorialLevelCount];
		nTutorialStartPath[0] = 25;
		nTutorialStartPath[1] = 25;
		nTutorialStartPath[2] = 25;
		nTutorialStartPath[3] = 29;
		nTutorialStartPath[4] = 15;
		nTutorialAIindex = new int[5];
		nTutorialAIindex[0] = 0;
		nTutorialAIindex[1] = 1;
		nTutorialAIindex[2] = 2;
		nTutorialAIindex[3] = 0;
		nTutorialAIindex[4] = 0;
	}

	private void save_CaugthDetails()
	{
		string text = string.Empty;
		for (int i = 0; i < pIGT_CaughtDet.Count; i++)
		{
			text = text + JsonUtility.ToJson(pIGT_CaughtDet[i]) + "~";
		}
		IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_CaugthDatas, text);
		IGT_Preference.getInstance()._SaveAll();
	}

	private void retrive_CaughtDetails()
	{
		string text = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_CaugthDatas, "null");
		if (text == "null")
		{
			for (int i = 0; i < pAIPlayerData.Count; i++)
			{
				pIGT_CaughtDet.Add(new IGT_CaughtDetails(pAIPlayerData[i].Name, 0, 0));
			}
			save_CaugthDetails();
			return;
		}
		string[] array = text.Split('~');
		for (int j = 0; j < 10; j++)
		{
			pIGT_CaughtDet.Add(JsonUtility.FromJson<IGT_CaughtDetails>(array[j]));
		}
	}

	private void EndlessBag_Creation(Transform trans)
	{
		if (nHeroIndex != 1)
		{
			Endless_Bag = UnityEngine.Object.Instantiate(IGT_ObjPlacing.Bag, trans.position, trans.rotation);
		}
		else
		{
			Endless_Bag = UnityEngine.Object.Instantiate(IGT_ObjPlacing.Suitcase, trans.position, trans.rotation);
		}
		Endless_Bag.name = IGT_Constants.EndlessBag;
		Endless_Bag.tag = IGT_Constants.Tag_Bag;
	}

	public void ReStartGame()
	{
		bRestart = true;
		setLevelData();
		player.transform.position = new Vector3(PlayerObj.pointPos[PlayerObj.nGameStrtPath, PlayerObj.nGameStrtPoint, 0], PlayerObj.pointPos[PlayerObj.nGameStrtPath, PlayerObj.nGameStrtPoint, 1], PlayerObj.pointPos[PlayerObj.nGameStrtPath, PlayerObj.nGameStrtPoint, 2]);
	}

	public void setLevelData(int missionNum = -1)
	{
		isSurpriseAiAvailable = false;
		userInputQueue.Clear();
		nUserInput = 0;
		removeCoinAnimationDatas();
		fGameoverAnimTime = 0f;
		bEnergyItemsAnimation = false;
		pBezierAnimation.Clear();
		pBezierAnimation_Group.Clear();
		fBezierGroupAnimTime = 0f;
		bPauseButton = false;
		bGameOver = false;
		bNxtPathAvail = true;
		bSelectDataFrMovingBWPath = false;
		PlayerObj.bMovingFinishdInPath = false;
		centerOffset = 0f;
		fLaneTempOffset = 0f;
		fDestinationLaneOffset = 0f;
		offset_Laneoffset = centerOffset;
		fprevOffet = offset_Laneoffset;
		initAccDiff = 10000f;
		bAcceleroMeterEnabled = false;
		fInitAccAngle = 0f;
		fMinAccRange = 0f;
		fMaxAccRange = 0f;
		bTurning = false;
		bLeftLaneShift = false;
		bRightLaneShift = false;
		IGT_Constants.useKeyLifeStartTime = -100f;
		bReduceAlpha = false;
		bCanResume = false;
		bUseKey = false;
		IGT_Constants.fResumeCountDownStartTime = 0f;
		IGT_Constants.fUseKeyCountDownStrtTime = 0f;
		IGT_Constants.fPauseScreenStrtTime = 0f;
		IGT_Constants.nNoOfKeysToRevive = 1;
		fDistBw2Points = 0f;
		nScore_Current = 0;
		nScore_Coin_Chase = 0;
		nStar_Current = -1;
		PlayerObj.fTotDistTraveled = 0f;
		player.transform.localScale = new Vector3(1f, 1f, 1f);
		PlayerObj.pObj.kickObjId = -1;
		IGT_Objects.kickObj_InstanceID = -1;
		PlayerObj.pObj.PickObjId = -1;
		IGT_Objects.PickedObj_InstanceID = -1;
		IGT_Objects.ThrowObj_Placed_Pos = Vector3.zero;
		bkickObjFly = false;
		bKickObjMoving = false;
		bKickobjCanMove = true;
		bKickWithinAnimRange = false;
		bKickAnimCanEnable = false;
		bKickAnimMissed = false;
		bLevelUp = false;
		bThrwObjPicked = false;
		bPickdObjCanThrow = false;
		bThrowObjCanMove = true;
		bThrowObjMoving = false;
		bPickObjSelected = false;
		nAIPlayerActionState = 0;
		IGT_AnimStatesCntrler.nGameOverAnimFinshd = 0;
		PlayerObj.nEnergyMeter = 1f;
		IGT_Constants.nNoOfCollectedCoins = 0;
		IGT_GameView.nHealth_hero = 1f;
		lastCollidedCoinPosition = Vector3.zero;
		bHeroPathSelctionUptoReachAnotherPathEndFinishd = true;
		PlayerObj.nEnergyMeter = (PlayerObj.nEnergyMeterPrev = (PlayerObj.nEnergyMeterNext = 1f));
		PlayerObj.bEnergyMeterChangesinBezier = false;
		PlayerObj.fTimeForEnergyMeterChanges = 0f;
		IGT_GameView.bLowEnergy_Hero = false;
		IGT_GameView.fLowEnergy_Hero_StrtTime = 0f;
		IGT_GameView.bDirMapBlink = false;
		IGT_GameView.fDirMapBlink_StartTime = 0f;
		fEndlessBag_offset_inPicking = 0f;
		PlayerObj.collItemPlacdTimeInPath = new float[WaypointManager.Paths.Count];
		bMissionCompleted = false;
		bMissionManualEnding = false;
		nCoinSoundIdx = 0;
		IGT_Constants.fGlobal_Spd_Multiplier = IGT_Constants.fGlobal_Spd_Multiplier_Min;
		bSplPowersActivated = false;
		bMagnet = (bCoin_2x = (bCoin_3x = (bInvisibleMode = (bSpdInc = (bSpdDec = false)))));
		fSpd_Dec_PrevSpd = (fSpd_Inc_PrevSpd = PlayerObj.speed);
		_Go_Smoke.SetActive(false);
		fAvgSpdFluctuation = 0f;
		nMinFrameCount = 100;
		IGT_GameView.bCatchMode_End = false;
		PlayerObj.DestroyAllTypesofObjects();
		IGT_Constants.fMission_Spd_Multiplier = 1f;
		ReducingPlayerAlphaWhileUsingUseKey(true);
		IGT_GameView.pIgtDispProp.Clear();
		if (IGT_AnimStatesCntrler.HeroAnimator != null)
		{
			IGT_AnimStatesCntrler.HeroAnimator.speed = IGT_Constants.nAnimation_Default_Spd;
			IGT_AnimStatesCntrler.HeroAnimator.StopPlayback();
		}
		if (isAIplayerAvailable && IGT_AIPlayer.pAIPlayerAnimController.AIHeroAnimator != null)
		{
			IGT_AIPlayer.pAIPlayerAnimController.AIHeroAnimator.StopPlayback();
		}
		switch (nGameMode)
		{
		case 0:
			isAIplayerAvailable = true;
			dChaseModeStrtTime = Time.time;
			PlayerObj.nGameStrtPath = 25;
			PlayerObj.nGameStrtPoint = 1;
			bNextAIPlayerGonnaPickPurse = false;
			bLevelUpButtonPressed = false;
			bBagMovingInCurve = false;
			IGT_Constants.nCoin_PlacingProb = 100;
			pIGT_CaughtDet.ElementAt(nAIPlayerIndex).nAttempts++;
			save_CaugthDetails();
			break;
		case 1:
			nMissionID = missionNum;
			IGT_GameView.pMissionInfo_TextureName = "Null";
			if (nMissionID < nTutorialLevelCount)
			{
				pMissionData.nMissionType = -1;
				pMissionData.nHeroIdx = 0;
				pMissionData.bIsAiPlayerNeed = true;
				pMissionData.nAIplayerIdx = nTutorialAIindex[nMissionID];
				pMissionData.nStaticObjEnablingInPathVal = 0;
				pMissionData.StaticObjPlacingDifficulty = 0;
				pMissionData.nDynamicObjPlacingProb = 0;
				pMissionData.nSurpriseplayerProb = 0;
				pMissionData.nSplPowersProb = 0;
				pMissionData.nVehicleProb = 0;
				switch (nMissionID)
				{
				case 0:
					pIgtZoneData = new IGT_ZoneData(nTutorialStartPath[nMissionID], false);
					pMissionData.nStartPathID = pIgtZoneData.nPathID;
					pMissionData.bTravRev = pIgtZoneData.bIsReverse;
					pMissionData.nStartPointID = 1;
					IGT_GameView.MissionInfo = " LEARN TO CHASE ";
					break;
				case 1:
					pIgtZoneData = new IGT_ZoneData(nTutorialStartPath[nMissionID], false);
					pMissionData.nStartPathID = pIgtZoneData.nPathID;
					pMissionData.bTravRev = pIgtZoneData.bIsReverse;
					pMissionData.nStartPointID = 1;
					pMissionData.nTargetCount = 2;
					IGT_GameView.MissionInfo = " THROW 2 BOTTLES ";
					IGT_GameView.pMissionInfo_TextureName = IGT_Constants._Bottle;
					break;
				case 2:
					pIgtZoneData = new IGT_ZoneData(nTutorialStartPath[nMissionID], false);
					pMissionData.nStartPathID = pIgtZoneData.nPathID;
					pMissionData.bTravRev = pIgtZoneData.bIsReverse;
					pMissionData.nStartPointID = 1;
					pMissionData.nTargetCount = 2;
					IGT_GameView.MissionInfo = " KICK 2 BALLS ";
					IGT_GameView.pMissionInfo_TextureName = IGT_Constants._Ball;
					break;
				case 3:
					pIgtZoneData = new IGT_ZoneData(nTutorialStartPath[nMissionID], false);
					pMissionData.nStartPathID = pIgtZoneData.nPathID;
					pMissionData.bTravRev = pIgtZoneData.bIsReverse;
					if (pIgtZoneData.bIsReverse)
					{
						pMissionData.nStartPointID = PlayerObj.pointCount[pIgtZoneData.nPathID] - 3;
					}
					else
					{
						pMissionData.nStartPointID = 0;
					}
					pMissionData.nStaticObjEnablingInPathVal = 0;
					pMissionData.StaticObjPlacingDifficulty = 0;
					pMissionData.nDynamicObjPlacingProb = 15;
					pMissionData.nSurpriseplayerProb = 20;
					pMissionData.nSplPowersProb = 10;
					pMissionData.nVehicleProb = 0;
					pMissionData.nKickThrowAdjVal = 1.25f;
					pMissionData.nSpl_Pos_AdjVal = 5;
					pMissionData.nSpl_Neg_AdjVal = 5;
					pMissionData.nCoinPlacingProb = 30;
					IGT_GameView.MissionInfo = " CATCH THE ROBBER ";
					break;
				case 4:
					pIgtZoneData = new IGT_ZoneData(nTutorialStartPath[nMissionID], false);
					pMissionData.nStartPathID = pIgtZoneData.nPathID;
					pMissionData.bTravRev = pIgtZoneData.bIsReverse;
					if (pIgtZoneData.bIsReverse)
					{
						pMissionData.nStartPointID = PlayerObj.pointCount[pIgtZoneData.nPathID] - 3;
					}
					else
					{
						pMissionData.nStartPointID = 0;
					}
					pMissionData.bIsAiPlayerNeed = false;
					pMissionData.nMissionType = 0;
					pMissionData.nTargetCount = 75;
					pMissionData.nCollectionInnerItemType = 0;
					pMissionData.fMinDistBtwCollectionObj = 1f;
					pMissionData.nCollectionItemPlacingProb = 100;
					pMissionData.nStaticObjEnablingInPathVal = 5;
					pMissionData.StaticObjPlacingDifficulty = 10;
					pMissionData.nDynamicObjPlacingProb = 30;
					pMissionData.nSurpriseplayerProb = 20;
					pMissionData.nSplPowersProb = 10;
					pMissionData.nVehicleProb = 0;
					pMissionData.nKickThrowAdjVal = 0f;
					pMissionData.nSpl_Pos_AdjVal = 2;
					pMissionData.nSpl_Neg_AdjVal = 5;
					pMissionData.nCoinPlacingProb = 0;
					pMissionData.fCollectionItem_MissingProb = 0.1f;
					pMissionData.spdFactor = 0.8f;
					break;
				}
				if (pMissionData.bIsAiPlayerNeed)
				{
					if (nMissionID == 3)
					{
						if (!bRestart)
						{
							if (nAIPlayerIndex != pMissionData.nAIplayerIdx)
							{
								if (pIgtZoneData.bIsReverse)
								{
									AIPlayerSelection(pMissionData.nAIplayerIdx, pMissionData.nStartPathID, pMissionData.nStartPointID - 3);
								}
								else
								{
									AIPlayerSelection(pMissionData.nAIplayerIdx, pMissionData.nStartPathID, pMissionData.nStartPointID + 2);
								}
							}
							else if (pIgtZoneData.bIsReverse)
							{
								IGT_AIPlayer.AI_player_Restart(pMissionData.nStartPathID, pMissionData.nStartPointID - 3);
							}
							else
							{
								IGT_AIPlayer.AI_player_Restart(pMissionData.nStartPathID, pMissionData.nStartPointID + 2);
							}
						}
						else
						{
							IGT_AIPlayer.AI_player_Restart(IGT_AIPlayer.AI_PlayerObj.nGameStrtPath, IGT_AIPlayer.AI_PlayerObj.nGameStrtPoint);
						}
					}
					bNextAIPlayerGonnaPickPurse = false;
					bLevelUpButtonPressed = false;
					bBagMovingInCurve = false;
				}
				if (!pIgtSavelevelData.isAlreadyPresent(nMissionID, 1))
				{
					pMissionData.nLevelStarCount = -1;
					pMissionData.nRetryCount = 0;
					pMissionData.nLevelScore = 0;
					Save_LevelData(nMissionID, 1, pMissionData);
				}
				else
				{
					pMissionData = retrive_Saved_LevelData(nMissionID, 1);
				}
				post_Analytics_Missions(nMissionID, "Demo", pMissionData.nRetryCount);
			}
			else
			{
				if (!pIgtSavelevelData.isAlreadyPresent(nMissionID, 1))
				{
					if (nMissionID < nPreDefinedMissionLevelInfo.GetLength(0))
					{
						pMissionData = pIGT_LevGenerator.StarterLevelDatas(nMissionID, nPreDefinedMissionLevelInfo[nMissionID, 0], nPreDefinedMissionLevelInfo[nMissionID, 1]);
					}
					else if (nMissionID - nPreDefinedMissionLevelInfo.GetLength(0) < GeneratedLevelDatas.Length)
					{
						int num = GeneratedLevelDatas[nMissionID - nPreDefinedMissionLevelInfo.GetLength(0)];
						int givenMode = num / 5 % 6;
						int givenBaseLevel = num % 5;
						pMissionData = pIGT_LevGenerator.LevelGenerationDatas(nMissionID, givenMode, givenBaseLevel);
					}
					else
					{
						pMissionData = pIGT_LevGenerator.LevelGenerationDatas(nMissionID);
					}
					pIgtZoneData = selectStartPathInfo(pMissionData.nZoneID);
					pMissionData.nStartPathID = pIgtZoneData.nPathID;
					pMissionData.bTravRev = pIgtZoneData.bIsReverse;
					if (pMissionData.nMissionType != 4)
					{
						if (pIgtZoneData.bIsReverse)
						{
							pMissionData.nStartPointID = PlayerObj.pointCount[pIgtZoneData.nPathID] - 3;
						}
						else
						{
							pMissionData.nStartPointID = 2;
						}
					}
					else if (pIgtZoneData.bIsReverse)
					{
						pMissionData.nStartPointID = PlayerObj.pointCount[pIgtZoneData.nPathID] - 7;
					}
					else
					{
						pMissionData.nStartPointID = 7;
					}
					pMissionData.nRetryCount = 0;
					pMissionData.nLevelStarCount = -1;
					pMissionData.spdFactor = Mission_Spd_Adjustments(nMissionID);
					Save_LevelData(nMissionID, 1, pMissionData);
				}
				else
				{
					pMissionData = retrive_Saved_LevelData(nMissionID, 1);
					if (pMissionData.nLevelStarCount == -1 && pMissionData.nRetryCount != 0 && pMissionData.nRetryCount % 2 == 0)
					{
						pIGT_LevGenerator.Level_Prob_Decrement(ref pMissionData);
						Save_LevelData(nMissionID, 1, pMissionData);
					}
					pIgtZoneData = new IGT_ZoneData(pMissionData.nStartPathID, pMissionData.bTravRev);
				}
				Endless_Mode_DataSel();
				post_Analytics_Missions(nMissionID, Enum.GetNames(typeof(MissionTypes)).GetValue(pMissionData.nMissionType).ToString(), pMissionData.nRetryCount);
			}
			PlayerObj.nGameStrtPath = pMissionData.nStartPathID;
			PlayerObj.nGameStrtPoint = pMissionData.nStartPointID;
			PlayerObj.bTraverseReverse = pMissionData.bTravRev;
			fCurVelocity = 0f;
			isAIplayerAvailable = pMissionData.bIsAiPlayerNeed;
			nNoOfCollectionObjHeroCrossed = 0;
			nNoOfChallengeObjHeroMissed = 0;
			nNoOf_WF_CharCrossed = 0;
			nCollectedItemCount = 0;
			dMissionStrtTime = Time.time;
			nCollectedMultipleItemCount = new int[3];
			nNoOfMulitpleCollObjHeroCrossed = new int[3];
			nNoOfMultiColObjCrossedUntillTargetAcheived = new int[3];
			if ((nMissionID >= nTutorialLevelCount - 1 && pMissionData.nMissionType != 2 && pMissionData.nMissionType != 1) || (pMissionData.nMissionType == 1 && (pMissionData.nChallengesInnerItemType == 2 || pMissionData.nChallengesInnerItemType == 3)))
			{
				DestroyAllAIPlayersUsingTags();
			}
			if (pMissionData.HeroStartEnergy < 25)
			{
				pMissionData.HeroStartEnergy = 25;
			}
			switch (pMissionData.nMissionType)
			{
			case 0:
				IGT_GameView.MissionInfo = " Collect " + pMissionData.nTargetCount.ToString() + " " + Enum.GetNames(typeof(CollectionItemTypes)).GetValue(pMissionData.nCollectionInnerItemType);
				IGT_GameView.pMissionInfo_TextureName = IGT_Constants.collectionItemsImg[pMissionData.nCollectionInnerItemType];
				IGT_Constants.fMinDistBtwCollectionItems = pMissionData.fMinDistBtwCollectionObj;
				IGT_Constants.nCollItemPlacingProb = pMissionData.nCollectionItemPlacingProb;
				IGT_Constants.fMissionItemMissingProb = pMissionData.fCollectionItem_MissingProb;
				if (pMissionData.nCollectionInnerItemType == 0)
				{
					PlayerObj.speed = 3.75f;
				}
				else
				{
					PlayerObj.speed = 3.25f;
				}
				IGT_Constants.fDiffSpd_CurVal_Mission = Mission_Spd_Adjustments_DecOnRetry(pMissionData.nRetryCount, pMissionData.spdFactor);
				PlayerObj.speed *= IGT_Constants.fDiffSpd_CurVal_Mission;
				break;
			case 5:
				IGT_GameView.MissionInfo = " Collect Below Objects  ";
				IGT_GameView.pMissionInfo_TextureName = IGT_Constants.collectionItemsImg[pMissionData.nMultipleCollectionDatas[0, 0]];
				IGT_Constants.fMissionItemMissingProb = pMissionData.fCollectionItem_MissingProb;
				IGT_Constants.fDiffSpd_CurVal_Mission = Mission_Spd_Adjustments_DecOnRetry(pMissionData.nRetryCount, pMissionData.spdFactor);
				PlayerObj.speed = 3.25f * IGT_Constants.fDiffSpd_CurVal_Mission;
				break;
			case 4:
			{
				IGT_GameView.MissionInfo = " Bring Back " + Enum.GetNames(typeof(BringBackItems)).GetValue(pMissionData.nBringBackItemInnerType);
				IGT_GameView.pMissionInfo_TextureName = IGT_Constants.BringBackItemsImg[pMissionData.nBringBackItemInnerType];
				PlayerObj.pObj.missionObj_PlacedDetails.Clear();
				Vector3 vector;
				if (nMissionID != 13)
				{
					if ((pMissionData.nLevelStarCount == -1 && pMissionData.nRetryCount != 0 && pMissionData.nRetryCount % 2 == 0) || !pIgtSavelevelData.isAlreadyPresent(nMissionID, 0))
					{
						vector = PlayerObj.findPos_Based_AbsoluteDist(PlayerObj.nGameStrtPath, PlayerObj.nGameStrtPoint, PlayerObj.bTraverseReverse, pMissionData.fBringBackitem_AbsDistfrmStrt);
						if (vector == Vector3.zero)
						{
							PlayerObj.bringBackHere_DataSel(PlayerObj.currentPathIndex);
						}
						Save_MissionObjPlacedInfo(nMissionID, 0, PlayerObj.pObj.missionObj_PlacedDetails);
					}
					else
					{
						PlayerObj.pObj.missionObj_PlacedDetails = retrive_Saved_MissionObjPlacedInfos(nMissionID, 0);
						vector = PlayerObj.pObj.missionObj_PlacedDetails.ElementAt(0).ObjPos;
					}
					PlayerObj.speed = PlayerObj.BaseSpeed;
					IGT_Constants.fDiffSpd_CurVal_Mission = Mission_Spd_Adjustments_DecOnRetry(pMissionData.nRetryCount, pMissionData.spdFactor);
					PlayerObj.speed = PlayerObj.speed * IGT_Constants.fDiffSpd_CurVal_Mission * IGT_Constants.fMission_Spd_Multiplier;
				}
				else
				{
					PlayerObj.nGameStrtPath = (pMissionData.nStartPathID = 22);
					PlayerObj.nGameStrtPoint = (pMissionData.nStartPointID = 5);
					PlayerObj.bTraverseReverse = (pMissionData.bTravRev = false);
					vector = PlayerObj.findPos(7, 10f, 0f);
					PlayerObj.speed = 2.75f;
					PlayerObj.pObj.missionObj_PlacedDetails.Add(new IGT_ObjInfo(1, 7, 10f, 0f, vector, Vector3.zero, -1, -1, "null", 0.5f, 0.25f, 0.35f, 0.25f, false, Time.time, 5f, 2f, false));
				}
				BringBackItem_instantiation(pMissionData.nBringBackItemInnerType, vector);
				dLifeTime_of_BringBackMode = 180.0;
				nTimeLeft_in_BringBackMode = (int)dLifeTime_of_BringBackMode;
				PlayerObj.nEnergyMeter = (PlayerObj.nEnergyMeterPrev = (IGT_GameView.nHealth_hero = (PlayerObj.nEnergyMeterNext = (float)pMissionData.HeroStartEnergy / 100f)));
				IGT_GameView.bBringBackDemoTapToContinueAlert = false;
				IGT_GameView.bBringBackAlert = false;
				break;
			}
			case 2:
				switch (pMissionData.nCatchingInnerItemType)
				{
				case 0:
					IGT_GameView.MissionInfo = " Catch the Robber in  \n" + pMissionData.nTargetCount + " seconds";
					IGT_Constants.fMission_Spd_Multiplier = 1.05f;
					if (pMissionData.nRetryCount > 4)
					{
						pMissionData.nKickThrowAdjVal = 3f;
					}
					break;
				case 1:
					IGT_GameView.MissionInfo = " Catch the Robber in  \n  " + pMissionData.nTargetCount + " meters";
					if (pMissionData.nStaticObjEnablingInPathVal > 0)
					{
						IGT_Constants.fMission_Spd_Multiplier = 1.12f;
					}
					else
					{
						IGT_Constants.fMission_Spd_Multiplier = 1.08f;
					}
					break;
				case 2:
					IGT_GameView.MissionInfo = " Catch the Robber ";
					IGT_Constants.fMission_Spd_Multiplier = 1.1f;
					break;
				}
				if (!bRestart)
				{
					if (nAIPlayerIndex != pMissionData.nAIplayerIdx)
					{
						if (pIgtZoneData.bIsReverse)
						{
							AIPlayerSelection(pMissionData.nAIplayerIdx, PlayerObj.nGameStrtPath, PlayerObj.nGameStrtPoint - 4);
						}
						else
						{
							AIPlayerSelection(pMissionData.nAIplayerIdx, PlayerObj.nGameStrtPath, PlayerObj.nGameStrtPoint + 4);
						}
					}
					else if (pIgtZoneData.bIsReverse)
					{
						IGT_AIPlayer.AI_player_Restart(PlayerObj.nGameStrtPath, PlayerObj.nGameStrtPoint - 4);
					}
					else
					{
						IGT_AIPlayer.AI_player_Restart(PlayerObj.nGameStrtPath, PlayerObj.nGameStrtPoint + 4);
					}
				}
				else if (isAIplayerAvailable)
				{
					IGT_AIPlayer.AI_player_Restart(IGT_AIPlayer.AI_PlayerObj.nGameStrtPath, IGT_AIPlayer.AI_PlayerObj.nGameStrtPoint);
				}
				bNextAIPlayerGonnaPickPurse = false;
				bLevelUpButtonPressed = false;
				bBagMovingInCurve = false;
				IGT_Constants.fDiffSpd_CurVal_Mission = Mission_Spd_Adjustments_DecOnRetry(pMissionData.nRetryCount, pMissionData.spdFactor);
				PlayerObj.nEnergyMeter = (PlayerObj.nEnergyMeterPrev = (IGT_GameView.nHealth_hero = (PlayerObj.nEnergyMeterNext = (float)pMissionData.HeroStartEnergy / 100f)));
				IGT_AIPlayer.AI_PlayerObj.nEnergyMeter = (IGT_AIPlayer.AI_PlayerObj.nEnergyMeterPrev = (IGT_AIPlayer.AI_PlayerObj.nEnergyMeterNext = (IGT_GameView.nHelath_Enemy = (float)pMissionData.EnemyStartEnergy / 100f)));
				break;
			case 1:
				switch (pMissionData.nChallengesInnerItemType)
				{
				case 2:
					IGT_GameView.MissionInfo = "JUMP " + pMissionData.nTargetCount + " HURDLES ";
					IGT_GameView.pMissionInfo_TextureName = IGT_Constants._Jump;
					break;
				case 3:
					IGT_GameView.MissionInfo = "SLIDE " + pMissionData.nTargetCount + " OBSTACLES ";
					IGT_GameView.pMissionInfo_TextureName = IGT_Constants._Slide;
					break;
				case 0:
					IGT_GameView.pMissionInfo_TextureName = IGT_Constants._Ball;
					IGT_GameView.MissionInfo = "KICK " + pMissionData.nTargetCount + " BALLS ";
					break;
				case 1:
					IGT_GameView.pMissionInfo_TextureName = IGT_Constants._Bottle;
					IGT_GameView.MissionInfo = "THROW " + pMissionData.nTargetCount + " BOTTLES ";
					break;
				}
				if (isAIplayerAvailable)
				{
					if (!bRestart)
					{
						if (nAIPlayerIndex != pMissionData.nAIplayerIdx)
						{
							if (pIgtZoneData.bIsReverse)
							{
								AIPlayerSelection(pMissionData.nAIplayerIdx, PlayerObj.nGameStrtPath, PlayerObj.nGameStrtPoint - 4);
							}
							else
							{
								AIPlayerSelection(pMissionData.nAIplayerIdx, PlayerObj.nGameStrtPath, PlayerObj.nGameStrtPoint + 4);
							}
						}
						else if (pIgtZoneData.bIsReverse)
						{
							IGT_AIPlayer.AI_player_Restart(PlayerObj.nGameStrtPath, PlayerObj.nGameStrtPoint - 4);
						}
						else
						{
							IGT_AIPlayer.AI_player_Restart(PlayerObj.nGameStrtPath, PlayerObj.nGameStrtPoint + 4);
						}
					}
					else
					{
						IGT_AIPlayer.AI_player_Restart(IGT_AIPlayer.AI_PlayerObj.nGameStrtPath, IGT_AIPlayer.AI_PlayerObj.nGameStrtPoint);
					}
					IGT_AIPlayer.AI_PlayerObj.BaseSpeed = (IGT_AIPlayer.AI_PlayerObj.speed = pHeroData[nHeroIndex].BaseSpeed);
				}
				bNextAIPlayerGonnaPickPurse = false;
				bLevelUpButtonPressed = false;
				bBagMovingInCurve = false;
				IGT_Constants.fMissionItemMissingProb = pMissionData.fCollectionItem_MissingProb;
				IGT_Constants.fChallengeItemCrossedProb = pMissionData.fChallengeCrossedProb;
				IGT_Constants.fDiffSpd_CurVal_Mission = Mission_Spd_Adjustments_DecOnRetry(pMissionData.nRetryCount, pMissionData.spdFactor);
				PlayerObj.nEnergyMeter = (PlayerObj.nEnergyMeterPrev = (PlayerObj.nEnergyMeterNext = (IGT_GameView.nHealth_hero = (float)pMissionData.HeroStartEnergy / 100f)));
				if (isAIplayerAvailable)
				{
					IGT_AIPlayer.AI_PlayerObj.nEnergyMeter = (IGT_AIPlayer.AI_PlayerObj.nEnergyMeterPrev = (IGT_AIPlayer.AI_PlayerObj.nEnergyMeterNext = (IGT_GameView.nHelath_Enemy = (float)pMissionData.EnemyStartEnergy / 100f)));
				}
				IGT_Constants.INITIAL_DISTGAP_BTW_HERO_ENEMY = 3f;
				break;
			case 3:
			{
				IGT_GameView.MissionInfo = "Find the Word ";
				IGT_Constants.fWF_OriginalCharPlacedTime = Time.time;
				char[] array = pMissionData.WordTobeFind.ToCharArray();
				pCharArray = new IGT_CharArray[array.Length];
				float num2 = IGT_UIcommonFunc.ScaleX(20f);
				float height = IGT_UIcommonFunc.ScaleY(20f);
				float y = IGT_UIcommonFunc.ScaleY(4f);
				float num3 = IGT_UIcommonFunc.ScaleX(235f);
				int fontSize = (int)IGT_UIcommonFunc.ScaleX(20f);
				if (array.Length >= 7)
				{
					num3 = IGT_UIcommonFunc.ScaleX(205f);
					y = IGT_UIcommonFunc.ScaleY(6f);
					num2 = IGT_UIcommonFunc.ScaleX(16f);
					height = IGT_UIcommonFunc.ScaleY(16f);
					fontSize = (int)IGT_UIcommonFunc.ScaleX(12f);
				}
				else if (array.Length == 6)
				{
					num3 = IGT_UIcommonFunc.ScaleX(212f);
					num2 = IGT_UIcommonFunc.ScaleX(18f);
					height = IGT_UIcommonFunc.ScaleY(18f);
					fontSize = (int)IGT_UIcommonFunc.ScaleX(14f);
				}
				else if (array.Length == 5)
				{
					num3 = IGT_UIcommonFunc.ScaleX(215f);
					fontSize = (int)IGT_UIcommonFunc.ScaleX(15f);
				}
				else if (array.Length == 4)
				{
					num3 = IGT_UIcommonFunc.ScaleX(225f);
				}
				for (int i = 0; i < array.Length; i++)
				{
					pCharArray[i] = new IGT_CharArray(array[i], false, num3 + (float)i * num2, y, num2, height, fontSize);
				}
				if (pMissionData.WordTobeFind.Length >= 2 && pMissionData.WordTobeFind.Length <= 4)
				{
					dLiftTime_of_WordFindingMode = 90.0;
				}
				else if (pMissionData.WordTobeFind.Length == 5 || pMissionData.WordTobeFind.Length == 6)
				{
					dLiftTime_of_WordFindingMode = 120.0;
				}
				else
				{
					dLiftTime_of_WordFindingMode = 150.0;
				}
				nTimeLeft_in_WordFindingMode = (int)dLiftTime_of_WordFindingMode;
				PlayerObj.nEnergyMeter = (PlayerObj.nEnergyMeterPrev = (IGT_GameView.nHealth_hero = (PlayerObj.nEnergyMeterNext = (float)pMissionData.HeroStartEnergy / 100f)));
				PlayerObj.speed = PlayerObj.BaseSpeed;
				IGT_Constants.fDiffSpd_CurVal_Mission = Mission_Spd_Adjustments_DecOnRetry(pMissionData.nRetryCount, pMissionData.spdFactor);
				PlayerObj.speed = PlayerObj.speed * IGT_Constants.fDiffSpd_CurVal_Mission * IGT_Constants.fMission_Spd_Multiplier;
				break;
			}
			}
			IGT_Constants.nValfrStaticObjEnablingInPath = pMissionData.nStaticObjEnablingInPathVal;
			IGT_Constants.nValArrForEachStaticObjEnableProbability[0] = pMissionData.StaticObjPlacingDifficulty;
			IGT_Constants.nValArrForEachStaticObjEnableProbability[1] = pMissionData.StaticObjPlacingDifficulty;
			IGT_Constants.nValArrForEachStaticObjEnableProbability[2] = pMissionData.StaticObjPlacingDifficulty;
			IGT_Constants.nDynamicObj_PlacingProb = pMissionData.nDynamicObjPlacingProb;
			IGT_Constants.nSurpriseAI_SelProb = pMissionData.nSurpriseplayerProb;
			IGT_Constants.nSplPowers_PlacingProb = pMissionData.nSplPowersProb;
			IGT_Constants.nVehicle_SelProb = pMissionData.nVehicleProb;
			IGT_Constants.nKick_Throw_AdjFactor = pMissionData.nKickThrowAdjVal;
			IGT_Constants.nSplPow_Pos_AdjFactor = pMissionData.nSpl_Pos_AdjVal;
			IGT_Constants.nSplPow_Neg_AdjFactor = pMissionData.nSpl_Neg_AdjVal;
			IGT_Constants.nCoin_PlacingProb = pMissionData.nCoinPlacingProb;
			if (bRobbingSceneFinished)
			{
				if (IGT_AnimStatesCntrler.HeroAnimator != null)
				{
					IGT_AnimStatesCntrler.HeroAnimator.Play("Idle", 0);
					IGT_AnimStatesCntrler.nHeroAnimState = 0;
					IGT_AnimStatesCntrler.HeroAnimator.speed = IGT_Constants.nAnimation_Default_Spd;
				}
				if (isAIplayerAvailable)
				{
					IGT_AIPlayer.pAIPlayerAnimController.AIHeroAnimator.Play("Idle", 0);
					IGT_AIPlayer.pAIPlayerAnimController.nHeroAnimState = 0;
				}
			}
			fTempMissionSpdStrtUpAdj = PlayerObj.speed;
			break;
		}
		bRestart = false;
		PlayerObj.PathInit(PlayerObj.nGameStrtPath, PlayerObj.nGameStrtPoint);
		if (!PlayerObj.bTraverseReverse)
		{
			PlayerObj.animPointX = PlayerObj.waypoints[PlayerObj.currentPoint].position.x;
			PlayerObj.animPointY = PlayerObj.waypoints[PlayerObj.currentPoint].position.y;
			PlayerObj.animPointZ = PlayerObj.waypoints[PlayerObj.currentPoint].position.z;
		}
		else
		{
			PlayerObj.animPointX = PlayerObj.waypoints[PlayerObj.currentPoint - 1].position.x;
			PlayerObj.animPointY = PlayerObj.waypoints[PlayerObj.currentPoint - 1].position.y;
			PlayerObj.animPointZ = PlayerObj.waypoints[PlayerObj.currentPoint - 1].position.z;
		}
		PlayerObj.fGameStrtDist = PlayerObj.objDistFrmStrtPoint(PlayerObj.nGameStrtPath, PlayerObj.nGameStrtPoint, new Vector3(PlayerObj.animPointX, PlayerObj.animPointY, PlayerObj.animPointZ));
		playerbeforePrevPos = (PlayerprevPos = (PlayerCurPos = (animPointVec_Spline = (nextExpectedPos = new Vector3(PlayerObj.animPointX, PlayerObj.animPointY, PlayerObj.animPointZ)))));
		PlayerObj.fDistFrmStrtPnt = PlayerObj.objDistFrmStrtPoint(PlayerObj.currentPathIndex, PlayerObj.currentPoint, PlayerObj.waypoints[PlayerObj.currentPoint].position);
		if (PlayerObj.bTraverseReverse)
		{
			PlayerObj.fDistFrmStrtPnt = PlayerObj.pathLength[PlayerObj.currentPathIndex] - PlayerObj.fDistFrmStrtPnt;
		}
		fTimeFrObjDiffculty = Time.time;
		IGT_Constants.fRandValFrObjPlacing = IGT_Constants.fInitRandValfrObjPlacing / (float)IGT_Constants.nDynamicObj_PlacingProb + (float)IGT_Constants.nConsValFrRandValSelection;
		PlayerObj.CumulativeProbCalc();
		PartialObjPlacement_curStep = 0;
		PartialObjPlacement_MinDist = PlayerObj.pathLength[PlayerObj.currentPathIndex] * 0.4f / (float)IGT_Constants.PartialObjPlacement_MaxStep;
		PlayerObj.pObj.ObjListInCurPathOfHero = PlayerObj.objDetInGivenPath(PlayerObj.currentPathIndex);
		PlayerObj.nAdjpathToCurPath.Clear();
		if (bRobbingSceneFinished)
		{
			player.transform.position = PlayerCurPos;
			if (!PlayerObj.bTraverseReverse)
			{
				player.transform.LookAt(PlayerObj.waypoints[PlayerObj.currentPoint + 1].position);
			}
			else
			{
				player.transform.LookAt(PlayerObj.waypoints[PlayerObj.currentPoint - 2].position);
			}
			if (pMissionData.nMissionType == 4)
			{
				BB_TarAbsDistfrmStrt = Vector3.Distance(player.transform.position, BB_CollectionItem.transform.position);
				Vector3 vector2 = new Vector3(PlayerObj.pointPos[PlayerObj.nGameStrtPath, 0, 0], PlayerObj.pointPos[PlayerObj.nGameStrtPath, 0, 1], PlayerObj.pointPos[PlayerObj.nGameStrtPath, 0, 2]);
				if (PlayerObj.bTraverseReverse)
				{
					vector2 = new Vector3(PlayerObj.pointPos[PlayerObj.nGameStrtPath, PlayerObj.pointCount[PlayerObj.nGameStrtPath] - 1, 0], PlayerObj.pointPos[PlayerObj.nGameStrtPath, PlayerObj.pointCount[PlayerObj.nGameStrtPath] - 1, 1], PlayerObj.pointPos[PlayerObj.nGameStrtPath, PlayerObj.pointCount[PlayerObj.nGameStrtPath] - 1, 2]);
				}
				Vector3 vector3 = PlayerCurPos - vector2;
				vector3.Normalize();
				heroine_DataSel(PlayerCurPos + vector3 * 0.3f + Vector3.Cross(Vector3.up, vector3) * 0.25f, player.transform.rotation);
				Heroine.transform.LookAt(player.transform);
				PlayerObj.pObj.missionObj_PlacedDetails.Add(new IGT_ObjInfo(1, PlayerObj.nGameStrtPath, PlayerObj.fDistFrmStrtPnt, PlayerObj.fTotalOffsetDeviation, Heroine.transform.position, Vector3.zero, -1, -1, "null", 0.5f, 0.5f, 0.25f, 0.25f, false, Time.time, 10f, 7f, false));
			}
		}
		if (nGameMode == 1 && nMissionID < nTutorialLevelCount)
		{
			tutorial_DataSel();
		}
		else if (nGameMode == 0 || (nGameMode == 1 && nMissionID >= nTutorialLevelCount))
		{
			PlayerObj.placingObjAtStartPah(PlayerObj.nGameStrtPath);
			if (nGameMode == 0)
			{
				PlayerObj.coinPlacing_In_GivenPath(PlayerObj.nGameStrtPath, false);
			}
			else if (nGameMode == 1 && nMissionID >= nTutorialLevelCount)
			{
				pIgtCamControl.pCamFollow.currentRotation = Quaternion.Euler(0f, Mathf.LerpAngle(Camera.main.transform.eulerAngles.y, pIgtCamControl.pCamFollow.camTarget.eulerAngles.y, 0.9f), 0f);
				pIgtCamControl.pCamFollow.CamCurPos = player.transform.position - pIgtCamControl.pCamFollow.currentRotation * Vector3.forward * pIgtCamControl.pCamFollow.CamdistFrmTarget;
				Camera.main.transform.position = new Vector3(pIgtCamControl.pCamFollow.CamCurPos.x, player.transform.position.y + pIgtCamControl.pCamFollow.CamheightFrmGround + IGT_Constants.fDist_GroundTo_HeroHead * 0.75f, pIgtCamControl.pCamFollow.CamCurPos.z);
				pIgtCamControl.pCamFollow.mCamPrevPos = pIgtCamControl.pCamFollow.CamCurPos;
				pIgtCamControl.pCamFollow.camPrevDir_Lookat = new Vector3(pIgtCamControl.pCamFollow.camTarget.position.x - Camera.main.transform.position.x, pIgtCamControl.pCamFollow.camTarget.position.y - Camera.main.transform.position.y, pIgtCamControl.pCamFollow.camTarget.position.z - Camera.main.transform.position.z);
				pIgtCamControl.pCamFollow.camPrevDir_Lookat.Normalize();
				pIgtCamControl.pCamFollow.fAvgAngleToRotate = (pIgtCamControl.pCamFollow.fAngleNeedtoRotate = 0f);
				Camera.main.transform.rotation = player.transform.rotation;
				if (Heroine != null && Heroine.activeSelf && pMissionData.nMissionType != 4)
				{
					Heroine.SetActive(false);
				}
				if (nMissionID == 13)
				{
					PlayerObj.tutorial_ObjPlacing_atStarting(PlayerObj.nGameStrtPath, nMissionID);
				}
			}
		}
		if (Endless_Bag == null && isAIplayerAvailable && IGT_AIPlayer.AI_Wrist.transform != null)
		{
			EndlessBag_Creation(IGT_AIPlayer.AI_Wrist.transform);
		}
		nHeroAdjPath = new List<int>();
		for (int j = 0; j < 3; j++)
		{
			int[] array2 = new int[6];
			array2 = PlayerObj.findPathBasedInput(PlayerObj.currentPathIndex, PlayerObj.bTraverseReverse, j);
			nHeroAdjPath.Add(array2[0]);
		}
		if (nGameMode == 1 && nMissionID > 2)
		{
			Vector3 one = Vector3.one;
			Vector3 one2 = Vector3.one;
			if (!PlayerObj.bTraverseReverse)
			{
				one = PlayerObj.waypoints[PlayerObj.currentPoint].position;
				one2 = PlayerObj.waypoints[PlayerObj.currentPoint + 1].position;
			}
			else
			{
				one = PlayerObj.waypoints[PlayerObj.currentPoint - 1].position;
				one2 = PlayerObj.waypoints[PlayerObj.currentPoint - 2].position;
			}
			Vector3 vector4 = PlayerObj.findRotation(new Vector3(one2.x, 0f, one2.z), new Vector3(one.x, 0f, one.z));
			pDirLight.transform.rotation = Quaternion.Euler(0f, vector4.z - 30f, 0f);
		}
		Hero_shadow_projector.SetActive(false);
		Hero_shadow_projector1.SetActive(true);
		IGT_Constants.splPowers_Chase_placedObj = new float[4, 4];
		IGT_Constants.splPowers_Chase_LastPlacedTime = Time.time;
		IGT_Constants.Interval_Coin = 60f;
		if (IGT_GameView.bRewardedVideoTimeUp && !IGT_GameView.pAds.isRewardBasedVideoAvailable())
		{
			IGT_GameView.pAds.RequestRewardBasedVideo();
		}
	}

	public int getMissionModeInfo(int index)
	{
		int result = -1;
		if (index < nTutorialLevelCount)
		{
			switch (index)
			{
			case 0:
				result = 4;
				break;
			case 1:
				result = 6;
				break;
			case 2:
				result = 5;
				break;
			case 3:
				result = 4;
				break;
			case 4:
				result = 0;
				break;
			}
		}
		else if (index < nPreDefinedMissionLevelInfo.GetLength(0))
		{
			switch (nPreDefinedMissionLevelInfo[index, 0])
			{
			case 0:
				result = 0;
				break;
			case 5:
				result = 0;
				break;
			case 2:
				result = 4;
				break;
			case 3:
				result = 3;
				break;
			case 4:
				result = 2;
				break;
			case 1:
				result = ((nPreDefinedMissionLevelInfo[index, 1] != 0 && nPreDefinedMissionLevelInfo[index, 1] != 1) ? ((nPreDefinedMissionLevelInfo[index, 1] != 2 && nPreDefinedMissionLevelInfo[index, 1] != 3) ? 7 : 5) : 6);
				break;
			}
		}
		else if (index - nPreDefinedMissionLevelInfo.GetLength(0) < GeneratedLevelDatas.Length)
		{
			int num = GeneratedLevelDatas[index - nPreDefinedMissionLevelInfo.GetLength(0)];
			int num2 = num / 5 % 6;
			int num3 = num % 5;
			switch (num2)
			{
			case 0:
				result = 0;
				break;
			case 5:
				result = 0;
				break;
			case 2:
				result = 4;
				break;
			case 3:
				result = 3;
				break;
			case 4:
				result = 2;
				break;
			case 1:
				switch (num3)
				{
				case 0:
				case 1:
					result = 6;
					break;
				case 2:
				case 3:
					result = 5;
					break;
				default:
					result = 7;
					break;
				}
				break;
			}
		}
		else
		{
			IGT_Missions iGT_Missions = retrive_Saved_LevelData(index, 1);
			if (iGT_Missions != null)
			{
				switch (iGT_Missions.nMissionType)
				{
				case 0:
					result = 0;
					break;
				case 5:
					result = 0;
					break;
				case 2:
					result = 4;
					break;
				case 3:
					result = 3;
					break;
				case 4:
					result = 2;
					break;
				case 1:
					result = ((iGT_Missions.nBaseLevelIdx != 0 && iGT_Missions.nBaseLevelIdx != 1) ? ((iGT_Missions.nBaseLevelIdx != 2 && iGT_Missions.nBaseLevelIdx != 3) ? 7 : 5) : 6);
					break;
				}
			}
		}
		return result;
	}

	private float Mission_Spd_Adjustments(int curMissionID)
	{
		if (curMissionID < nTutorialLevelCount)
		{
			return 0.8f;
		}
		IGT_Missions iGT_Missions = retrive_Saved_LevelData(curMissionID - 1, 1);
		float num = ((iGT_Missions != null) ? iGT_Missions.spdFactor : 0.8f);
		if (num < 0.1f)
		{
			num = 0.8f;
		}
		iGT_Missions = retrive_Saved_LevelData(curMissionID - 1, 1);
		float num2 = ((iGT_Missions != null) ? ((float)iGT_Missions.nRetryCount * 0.7f) : 0f);
		iGT_Missions = retrive_Saved_LevelData(curMissionID - 2, 1);
		float num3 = ((iGT_Missions != null) ? ((float)iGT_Missions.nRetryCount * 0.3f) : 0f);
		float num4 = num2 + num3;
		if (num4 < 0.3f)
		{
			num += 0.15f;
		}
		else if (num4 < 0.7f)
		{
			num += 0.1f;
		}
		else if (num4 < 1.4f)
		{
			num += 0.07f;
		}
		else if (num4 < 2f)
		{
			num += 0.04f;
		}
		else if (num4 < 3f)
		{
			num += 0.02f;
		}
		else if (num4 >= 6f)
		{
			num -= 0.15f;
		}
		else if (num4 >= 5f)
		{
			num -= 0.1f;
		}
		else if (num4 >= 4.4f)
		{
			num -= 0.07f;
		}
		else if (num4 >= 3.7f)
		{
			num -= 0.04f;
		}
		else if (num4 >= 3f)
		{
			num -= 0.02f;
		}
		if (num < IGT_Constants.fDiffSpd_MinVal_Mission)
		{
			num = IGT_Constants.fDiffSpd_MinVal_Mission;
		}
		if (num > IGT_Constants.fDiffSpd_MaxVal_Mission)
		{
			num = IGT_Constants.fDiffSpd_MaxVal_Mission;
		}
		return num;
	}

	private float Mission_Spd_Adjustments_DecOnRetry(int retryCount, float curFactor)
	{
		if (retryCount < 3)
		{
			return curFactor;
		}
		float num = curFactor - (float)(retryCount - 3) * 0.03f;
		if (num < curFactor - 0.15f)
		{
			num = curFactor - 0.15f;
		}
		if (num < IGT_Constants.fDiffSpd_MinVal_Mission)
		{
			num = IGT_Constants.fDiffSpd_MinVal_Mission;
		}
		if (num > IGT_Constants.fDiffSpd_MaxVal_Mission)
		{
			num = IGT_Constants.fDiffSpd_MaxVal_Mission;
		}
		return num;
	}

	private void tutorial_DataSel()
	{
		if (missionEndWall != null)
		{
			UnityEngine.Object.Destroy(missionEndWall);
		}
		PlayerObj.tutorial_ObjPlacing_atStarting(pMissionData.nStartPathID, nMissionID);
		if (nMissionID < 3)
		{
			Vector3 vector = PlayerObj.findPos(17, PlayerObj.pathLength[17], 0.4f);
			Vector3 prevpos = PlayerObj.findPos(17, PlayerObj.pathLength[17] - 2f, 0.4f);
			Vector3 vector2 = PlayerObj.findRotation(vector, prevpos);
			missionEndWall = UnityEngine.Object.Instantiate(IGT_ObjPlacing.EndWall, vector, Quaternion.Euler(0f, vector2.z, 0f));
			missionEndWall.tag = IGT_Constants.Tag_MissionFailedGate;
			missionEndWall.name = "EndGate";
			missionEndWall.GetComponent<Animation>().playAutomatically = false;
		}
		if (nMissionID == 1 || nMissionID == 2)
		{
			PlayerObj.tutorial_ObjPlacing_AdjPath(nMissionID, pMissionData.nStartPathID, PlayerObj.bTraverseReverse);
		}
		else if (nMissionID == 3 || nMissionID == 4)
		{
			PlayerObj.placingObjAtStartPah(PlayerObj.nGameStrtPath);
			if (nMissionID == 4)
			{
				PlayerObj.coinPlacing_In_GivenPath(PlayerObj.nGameStrtPath, true);
			}
		}
		if (isAIplayerAvailable)
		{
			if (nMissionID == 3)
			{
				fTempMissionSpdStrtUpAdj = (PlayerObj.speed = 3.25f);
				IGT_AIPlayer.AI_PlayerObj.speed = (IGT_AIPlayer.AI_PlayerObj.BaseSpeed = 3.31f);
				IGT_AIPlayer.AI_PlayerObj.EnergyDeAcceleratorFactorPerSecond = 0.047f;
				IGT_AIPlayer.AI_PlayerObj.nEnergyMeter = 1f;
				PlayerObj.EnergyDeAcceleratorFactorPerSecond = pHeroData[nHeroIndex].EnergyDeAccelerationFactorPerSecond;
			}
			else
			{
				PlayerObj.speed = (IGT_AIPlayer.AI_PlayerObj.speed = 2.5f);
			}
		}
		else if (nMissionID == 4)
		{
			PlayerObj.speed = 3.25f;
		}
		dMissionStrtTime = Time.time;
		bMissionManualEnding = false;
		IGT_GameView.nArrowAnimType = -1;
	}

	private void loadAudios()
	{
		_AudioClips = new AudioClip[Enum.GetNames(typeof(SoundIdx)).Length];
		_AudioClips[2] = Resources.Load(IGT_Constants.AudioClipsPath + "coin") as AudioClip;
		_AudioClips[3] = Resources.Load(IGT_Constants.AudioClipsPath + "levelup") as AudioClip;
		_AudioClips[4] = Resources.Load(IGT_Constants.AudioClipsPath + "glassbreaking") as AudioClip;
		_AudioClips[10] = Resources.Load(IGT_Constants.AudioClipsPath + "glassfalling") as AudioClip;
		_AudioClips[5] = Resources.Load(IGT_Constants.AudioClipsPath + "slap") as AudioClip;
		_AudioClips[6] = Resources.Load(IGT_Constants.AudioClipsPath + "buttonclick") as AudioClip;
		_AudioClips[7] = Resources.Load(IGT_Constants.AudioClipsPath + "powerpick") as AudioClip;
		_AudioClips[9] = Resources.Load(IGT_Constants.AudioClipsPath + "jump") as AudioClip;
		_AudioClips[8] = Resources.Load(IGT_Constants.AudioClipsPath + "slide") as AudioClip;
		_AudioClips[11] = Resources.Load(IGT_Constants.AudioClipsPath + "kick") as AudioClip;
		_AudioClips[12] = Resources.Load(IGT_Constants.AudioClipsPath + "throwing") as AudioClip;
		_AudioClips[13] = Resources.Load(IGT_Constants.AudioClipsPath + "water") as AudioClip;
		_AudioClips[14] = Resources.Load(IGT_Constants.AudioClipsPath + "forest") as AudioClip;
		_AudioClips[15] = Resources.Load(IGT_Constants.AudioClipsPath + "wind") as AudioClip;
		_AudioClips[16] = Resources.Load(IGT_Constants.AudioClipsPath + "scoreup") as AudioClip;
		_AudioClips[17] = Resources.Load(IGT_Constants.AudioClipsPath + "car") as AudioClip;
		_AudioClips[18] = Resources.Load(IGT_Constants.AudioClipsPath + "market") as AudioClip;
		_AudioClips[21] = Resources.Load(IGT_Constants.AudioClipsPath + "shortscream_and_barrelhit") as AudioClip;
		_AudioClips[22] = Resources.Load(IGT_Constants.AudioClipsPath + "aihit") as AudioClip;
		_AudioClips[23] = Resources.Load(IGT_Constants.AudioClipsPath + "shortscream_and_woodhit1") as AudioClip;
		_AudioClips[24] = Resources.Load(IGT_Constants.AudioClipsPath + "shortscream_and_woodhit3") as AudioClip;
		_AudioClips[25] = Resources.Load(IGT_Constants.AudioClipsPath + "swipe") as AudioClip;
		_AudioClips[19] = Resources.Load(IGT_Constants.AudioClipsPath + "icecreamtruck") as AudioClip;
		_AudioClips[20] = Resources.Load(IGT_Constants.AudioClipsPath + "policevehicle") as AudioClip;
		_AudioClips[26] = Resources.Load(IGT_Constants.AudioClipsPath + "humanroll") as AudioClip;
		_AudioClips[27] = Resources.Load(IGT_Constants.AudioClipsPath + "footstep") as AudioClip;
		_AudioClips[28] = Resources.Load(IGT_Constants.AudioClipsPath + "pitfalling") as AudioClip;
		_AudioClips[29] = Resources.Load(IGT_Constants.AudioClipsPath + "manscreaming") as AudioClip;
		_AudioClips[30] = Resources.Load(IGT_Constants.AudioClipsPath + "countdown") as AudioClip;
		_AudioClips[31] = Resources.Load(IGT_Constants.AudioClipsPath + "ballbounce") as AudioClip;
		_AudioClips[32] = Resources.Load(IGT_Constants.AudioClipsPath + "construction") as AudioClip;
		_AudioClips[33] = Resources.Load(IGT_Constants.AudioClipsPath + "ballmiss") as AudioClip;
		_AudioClips[34] = Resources.Load(IGT_Constants.AudioClipsPath + "gateclose") as AudioClip;
		_AudioClips[35] = Resources.Load(IGT_Constants.AudioClipsPath + "invinsiblestate") as AudioClip;
		_AudioClips[36] = Resources.Load(IGT_Constants.AudioClipsPath + "shortscream_and_carhit") as AudioClip;
		_AudioClips[37] = Resources.Load(IGT_Constants.AudioClipsPath + "lowenergy") as AudioClip;
		_AudioClips[1] = Resources.Load(IGT_Constants.AudioClipsPath + "shortscream_and_smokebomb") as AudioClip;
		_AudioClips_BGM = new AudioClip[Enum.GetNames(typeof(BGM)).Length];
		_AudioClips_BGM[0] = Resources.Load(IGT_Constants.AudioClipsPath + "bg_matrix") as AudioClip;
		_AudioClips_BGM[1] = Resources.Load(IGT_Constants.AudioClipsPath + "bg_chaseaction") as AudioClip;
		_AudioClips_BGM[2] = Resources.Load(IGT_Constants.AudioClipsPath + "bg_hybridtension") as AudioClip;
		_AudioClips_BGM[3] = Resources.Load(IGT_Constants.AudioClipsPath + "bg_chase") as AudioClip;
		_AudioClips_BGM[4] = Resources.Load(IGT_Constants.AudioClipsPath + "bg_menu") as AudioClip;
		_AudioClips_Coin = new AudioClip[6];
		for (int i = 0; i < 6; i++)
		{
			_AudioClips_Coin[i] = Resources.Load(IGT_Constants.AudioClipsPath_Coins + i) as AudioClip;
		}
		MusicAudioSelector();
		InvokeRepeating("PlayMusicWithFade", 0f, 0.1f);
		_AudioSource2GameObject = new GameObject("AudioSource_2");
		_AudioSource2GameObject.AddComponent<AudioSource>();
		_AudioSource2 = _AudioSource2GameObject.GetComponent<AudioSource>();
		_AudioSource2.playOnAwake = true;
		_AudioSource2.loop = true;
		_AudioSource2.volume = 0.6f;
		_AudioSource2.spread = 0f;
		_AudioSource2.spatialBlend = 1f;
		_AudioSource2.minDistance = 6f;
		_AudioSource2.maxDistance = 14f;
		_AudioSource2.rolloffMode = AudioRolloffMode.Linear;
		_AudioSource3GameObject = new GameObject("HeartSound");
		_AudioSource3 = _AudioSource3GameObject.AddComponent<AudioSource>();
		_AudioSource3.clip = _AudioClips[37];
		_AudioSource3.loop = true;
		_AudioSource4GameObject = new GameObject("SoundEffects Source");
		_AudioSource4 = _AudioSource4GameObject.AddComponent<AudioSource>();
		_AudioSource4.loop = false;
	}

	public void playSound(int idx, float _volumeScale = 1f, bool bIsCoinSound = false)
	{
		if (nSound != 0)
		{
			return;
		}
		if (!bIsCoinSound)
		{
			if (nHeroIndex == 1 && (idx == 9 || idx == 23 || idx == 36 || idx == 24 || idx == 21 || idx == 26 || idx == 28 || idx == 27 || idx == 8 || idx == 12 || idx == 22))
			{
				_AudioSource5.PlayOneShot(_AudioClips[idx], _volumeScale);
			}
			else
			{
				_AudioSource4.PlayOneShot(_AudioClips[idx], _volumeScale);
			}
		}
		else
		{
			_AudioSource4.PlayOneShot(_AudioClips_Coin[idx], _volumeScale);
		}
	}

	public void PlayMusic()
	{
		if (nMusic == 0)
		{
			_AudioSource.Play();
		}
		else if (nMusic == 1)
		{
			_AudioSource.Stop();
		}
	}

	public void PlayMusicWithFade()
	{
		if (IsInvoking("StopMusicWithFade"))
		{
			CancelInvoke("StopMusicWithFade");
		}
		else if (nMusic == 1)
		{
			CancelInvoke("PlayMusicWithFade");
		}
		else if (IsInvoking("ResumeMusicWithFade"))
		{
			CancelInvoke("ResumeMusicWithFade");
		}
		else if (IsInvoking("StopMusicWithFadeAndPlayAnother"))
		{
			CancelInvoke("StopMusicWithFadeAndPlayAnother");
		}
		else if (IsInvoking("StopMusicWithFadeAndPlayAfterDelay"))
		{
			CancelInvoke("StopMusicWithFadeAndPlayAfterDelay");
		}
		if (_AudioSource.isPlaying && _AudioSource.volume >= 0.4f)
		{
			_AudioSource.volume = 0.4f;
			CancelInvoke("PlayMusicWithFade");
		}
		else if (_AudioSource.isPlaying && _AudioSource.volume < 0.4f)
		{
			_AudioSource.volume += 0.01f;
		}
		else if (!_AudioSource.isPlaying && nMusic == 0)
		{
			_AudioSource.volume = 0f;
			_AudioSource.Play();
		}
		else if (nMusic == 1)
		{
			_AudioSource.Stop();
			CancelInvoke("PlayMusicWithFade");
		}
	}

	public void StopMusicWithFadeAndPlayAfterDelay()
	{
		if (IsInvoking("PlayMusicWithFade"))
		{
			CancelInvoke("PlayMusicWithFade");
		}
		else if (IsInvoking("PlayMusicWithFadeAfterDelay"))
		{
			CancelInvoke("PlayMusicWithFadeAfterDelay");
		}
		if (_AudioSource.isPlaying && _AudioSource.volume <= 0f)
		{
			_AudioSource.Stop();
			CancelInvoke("StopMusicWithFadeAndPlayAfterDelay");
			MusicAudioSelector();
			InvokeRepeating("PlayMusicWithFadeAfterDelay", 5f, 0.1f);
		}
		else if (_AudioSource.isPlaying && _AudioSource.volume > 0f)
		{
			_AudioSource.volume -= 0.03f;
		}
		else if (!_AudioSource.isPlaying && nMusic == 0)
		{
			InvokeRepeating("PlayMusicWithFadeAfterDelay", 5f, 0.1f);
		}
		if (nMusic == 1)
		{
			_AudioSource.Stop();
			CancelInvoke("StopMusicWithFadeAndPlayAfterDelay");
		}
	}

	public void PlayMusicWithFadeAfterDelay()
	{
		if (IsInvoking("PlayMusicWithFade"))
		{
			CancelInvoke("PlayMusicWithFade");
		}
		else if (IsInvoking("StopMusicWithFade"))
		{
			CancelInvoke("StopMusicWithFade");
		}
		else if (IsInvoking("StopMusicWithFadeAndPlayAnother"))
		{
			CancelInvoke("StopMusicWithFadeAndPlayAnother");
		}
		else if (nMusic == 1)
		{
			CancelInvoke("PlayMusicWithFadeAfterDelay");
		}
		else if (IsInvoking("ResumeMusicWithFade"))
		{
			CancelInvoke("ResumeMusicWithFade");
		}
		if (_AudioSource.isPlaying && _AudioSource.volume >= 0.4f)
		{
			_AudioSource.volume = 0.4f;
			CancelInvoke("PlayMusicWithFadeAfterDelay");
		}
		else if (_AudioSource.isPlaying && _AudioSource.volume < 0.4f)
		{
			_AudioSource.volume += 0.01f;
		}
		else if (!_AudioSource.isPlaying && nMusic == 0)
		{
			_AudioSource.volume = 0f;
			_AudioSource.Play();
		}
		else if (nMusic == 1)
		{
			_AudioSource.Stop();
			CancelInvoke("PlayMusicWithFadeAfterDelay");
		}
	}

	public void StopMusicWithFade()
	{
		if (IsInvoking("PlayMusicWithFade"))
		{
			CancelInvoke("PlayMusicWithFade");
		}
		else if (IsInvoking("StopMusicWithFadeAndPlayAnother"))
		{
			CancelInvoke("StopMusicWithFadeAndPlayAnother");
		}
		else if (IsInvoking("PlayMusicWithFadeAfterDelay"))
		{
			CancelInvoke("PlayMusicWithFadeAfterDelay");
		}
		if (_AudioSource.isPlaying && _AudioSource.volume <= 0f)
		{
			_AudioSource.Stop();
			CancelInvoke("StopMusicWithFade");
		}
		else if (_AudioSource.isPlaying && _AudioSource.volume > 0f)
		{
			_AudioSource.volume -= 0.03f;
		}
	}

	public void StopMusic()
	{
		_AudioSource.volume = 0f;
		_AudioSource.Stop();
	}

	public void MusicAudioSelector()
	{
		if (IGT_GameView.nScreenMode == 0 || IGT_GameView.nScreenMode == 9 || IGT_GameView.nScreenMode == 11 || IGT_GameView.nScreenMode == 10 || IGT_GameView.nScreenMode == 5 || IGT_GameView.nScreenMode == 20 || IGT_GameView.nScreenMode == 12)
		{
			_AudioSource.clip = _AudioClips_BGM[4];
		}
		else if (nGameMode == 0 || IGT_GameView.nScreenMode == 3)
		{
			if (_AudioSource.clip == _AudioClips_BGM[0])
			{
				if (UnityEngine.Random.Range(0, 2) == 0)
				{
					_AudioSource.clip = _AudioClips_BGM[3];
				}
				else
				{
					_AudioSource.clip = _AudioClips_BGM[1];
				}
			}
			else if (_AudioSource.clip == _AudioClips_BGM[1])
			{
				if (UnityEngine.Random.Range(0, 2) == 0)
				{
					_AudioSource.clip = _AudioClips_BGM[0];
				}
				else
				{
					_AudioSource.clip = _AudioClips_BGM[3];
				}
			}
			else if (_AudioSource.clip == _AudioClips_BGM[3])
			{
				if (UnityEngine.Random.Range(0, 2) == 0)
				{
					_AudioSource.clip = _AudioClips_BGM[0];
				}
				else
				{
					_AudioSource.clip = _AudioClips_BGM[1];
				}
			}
			else
			{
				switch (UnityEngine.Random.Range(0, 3))
				{
				case 0:
					_AudioSource.clip = _AudioClips_BGM[0];
					break;
				case 1:
					_AudioSource.clip = _AudioClips_BGM[3];
					break;
				default:
					_AudioSource.clip = _AudioClips_BGM[1];
					break;
				}
			}
			IGT_GameView.audioclipLength = _AudioSource.clip.length;
			IGT_GameView.audioclipstartTime = Time.time;
		}
		else
		{
			if (nGameMode != 1)
			{
				return;
			}
			if (nMissionID < nTutorialLevelCount)
			{
				switch (nMissionID)
				{
				case 0:
					_AudioSource.clip = _AudioClips_BGM[3];
					break;
				case 1:
					_AudioSource.clip = _AudioClips_BGM[1];
					break;
				case 2:
					_AudioSource.clip = _AudioClips_BGM[3];
					break;
				case 3:
					_AudioSource.clip = _AudioClips_BGM[1];
					break;
				case 4:
					_AudioSource.clip = _AudioClips_BGM[3];
					break;
				}
				return;
			}
			switch (pMissionData.nMissionType)
			{
			case 4:
				_AudioSource.clip = _AudioClips_BGM[2];
				break;
			case 2:
				_AudioSource.clip = _AudioClips_BGM[1];
				break;
			case 1:
				_AudioSource.clip = _AudioClips_BGM[0];
				break;
			case 0:
				_AudioSource.clip = _AudioClips_BGM[3];
				break;
			case 5:
				_AudioSource.clip = _AudioClips_BGM[3];
				break;
			case 3:
				_AudioSource.clip = _AudioClips_BGM[2];
				break;
			}
		}
	}

	public void StopMusicWithFadeAndPlayAnother()
	{
		if (IsInvoking("StopMusicWithFade"))
		{
			CancelInvoke("StopMusicWithFade");
		}
		else if (nMusic == 1)
		{
			CancelInvoke("PlayMusicWithFade");
		}
		else if (IsInvoking("ResumeMusicWithFade"))
		{
			CancelInvoke("ResumeMusicWithFade");
		}
		else if (IsInvoking("StopMusicWithFadeAndPlayAfterDelay"))
		{
			CancelInvoke("StopMusicWithFadeAndPlayAfterDelay");
		}
		else if (IsInvoking("PlayMusicWithFadeAfterDelay"))
		{
			CancelInvoke("PlayMusicWithFadeAfterDelay");
		}
		if (_AudioSource.isPlaying && _AudioSource.volume <= 0f)
		{
			_AudioSource.Stop();
			if (nGameMode == 0)
			{
				MusicAudioSelector();
			}
			CancelInvoke("StopMusicWithFadeAndPlayAnother");
			InvokeRepeating("PlayMusicWithFade", 0f, 0.1f);
		}
		else if (_AudioSource.isPlaying && _AudioSource.volume > 0f)
		{
			_AudioSource.volume -= 0.03f;
		}
		else if (!_AudioSource.isPlaying && nMusic == 0)
		{
			InvokeRepeating("PlayMusicWithFade", 0f, 0.1f);
		}
		if (nMusic == 1)
		{
			_AudioSource.Stop();
			CancelInvoke();
		}
	}

	public void PauseMusicWithFade()
	{
		if (IsInvoking("StopMusicWithFade"))
		{
			CancelInvoke("StopMusicWithFade");
		}
		else if (IsInvoking("StopMusicWithFadeAndPlayAnother"))
		{
			CancelInvoke("StopMusicWithFadeAndPlayAnother");
		}
		else if (IsInvoking("ResumeMusicWithFade"))
		{
			CancelInvoke("ResumeMusicWithFade");
		}
		else if (IsInvoking("PlayMusicWithFade"))
		{
			CancelInvoke("PlayMusicWithFade");
		}
		_AudioSource.volume = 0f;
		_AudioSource.Pause();
	}

	public void ResumeMusicWithFade()
	{
		if (IsInvoking("StopMusicWithFade"))
		{
			CancelInvoke("StopMusicWithFade");
		}
		else if (IsInvoking("StopMusicWithFadeAndPlayAnother"))
		{
			CancelInvoke("StopMusicWithFadeAndPlayAnother");
		}
		else if (IsInvoking("PlayMusicWithFade"))
		{
			CancelInvoke("PlayMusicWithFade");
		}
		if (!_AudioSource.isPlaying && nMusic == 0)
		{
			_AudioSource.UnPause();
			if (!_AudioSource.isPlaying)
			{
				_AudioSource.Play();
			}
		}
		if (_AudioSource.volume >= 0.4f)
		{
			_AudioSource.volume = 0.4f;
			CancelInvoke("ResumeMusicWithFade");
		}
		else if (_AudioSource.volume < 0.4f)
		{
			_AudioSource.volume += 0.01f;
		}
	}

	public void playEnvironmentSound(int SoundID, int action, Vector3 pos, float volume = 0.6f, bool is3dSound = false, bool isloop = true, float mindistanceVal = 0f, float maxdistanceVal = 0f)
	{
		switch (action)
		{
		case 1:
			if (_AudioSource2.isPlaying)
			{
				_AudioSource2.Stop();
			}
			break;
		case 0:
			_AudioSource2.clip = _AudioClips[SoundID];
			_AudioSource2.loop = isloop;
			_AudioSource2.volume = volume;
			if (is3dSound)
			{
				_AudioSource2.spatialBlend = 1f;
				_AudioSource2.minDistance = mindistanceVal;
				_AudioSource2.maxDistance = maxdistanceVal;
			}
			else
			{
				_AudioSource2.spatialBlend = 0f;
			}
			_AudioSource2GameObject.transform.position = pos;
			_AudioSource2.Play();
			break;
		}
	}

	public void isPausedSounds(bool flag)
	{
		if (flag)
		{
			PauseMusicWithFade();
			_AudioSource2.Pause();
			_AudioSource3.Pause();
		}
		else
		{
			InvokeRepeating("ResumeMusicWithFade", 0f, 0.1f);
			_AudioSource2.UnPause();
			_AudioSource3.UnPause();
		}
		if (isSurpriseAiAvailable && IGT_SurpriseAIplayer.SurpriseAI != null && IGT_SurpriseAIplayer.SurpriseAI.GetComponent<AudioSource>() != null)
		{
			if (flag)
			{
				IGT_SurpriseAIplayer.SurpriseAI.GetComponent<AudioSource>().Pause();
			}
			else
			{
				IGT_SurpriseAIplayer.SurpriseAI.GetComponent<AudioSource>().UnPause();
			}
		}
		foreach (GameObject dynObj in IGT_ObjPlacing.dynObjList)
		{
			if (dynObj.GetComponent<AudioSource>() != null)
			{
				if (flag)
				{
					dynObj.GetComponent<AudioSource>().Pause();
				}
				else
				{
					dynObj.GetComponent<AudioSource>().UnPause();
				}
			}
		}
		foreach (GameObject movObj in IGT_MovingObjPlacing.MovObjList)
		{
			if (movObj.GetComponent<AudioSource>() != null)
			{
				if (flag)
				{
					movObj.GetComponent<AudioSource>().Pause();
				}
				else
				{
					movObj.GetComponent<AudioSource>().UnPause();
				}
			}
		}
		GameObject[] staticGameObjectsArray = PlayerObj.pObj.StaticGameObjectsArray;
		foreach (GameObject gameObject in staticGameObjectsArray)
		{
			if (gameObject.GetComponent<AudioSource>() != null)
			{
				if (flag)
				{
					gameObject.GetComponent<AudioSource>().Pause();
				}
				else
				{
					gameObject.GetComponent<AudioSource>().UnPause();
				}
			}
		}
	}

	public void Change_BGM()
	{
		_AudioSource.clip = _AudioClips_BGM[UnityEngine.Random.Range(0, _AudioClips_BGM.Length)];
	}

	private void Save_MissionObjPlacedInfo(int _levelID, int _Type, List<IGT_ObjInfo> pObjInfo)
	{
		List<string> list = new List<string>();
		for (int i = 0; i < pObjInfo.Count; i++)
		{
			string item = JsonUtility.ToJson(pObjInfo.ElementAt(i));
			list.Add(item);
		}
		byte[] array = list.SelectMany((string s) => Encoding.ASCII.GetBytes(s + '\0')).ToArray();
		if (!pIgtSavelevelData.isAlreadyPresent(_levelID, _Type))
		{
			pIgtSavelevelData.insertTableInfo(_levelID, _Type, IGT_EncodeDecode.encrypt(array));
		}
		else
		{
			pIgtSavelevelData.updateTableInfo(_levelID, _Type, IGT_EncodeDecode.encrypt(array));
		}
	}

	private List<IGT_ObjInfo> retrive_Saved_MissionObjPlacedInfos(int _levelID, int _Type)
	{
		byte[] tableData = pIgtSavelevelData.getTableData(_levelID, _Type);
		if (tableData == null)
		{
			return null;
		}
		List<string> list = new List<string>();
		int num;
		for (num = 0; num < tableData.Length; num++)
		{
			int i;
			for (i = num; tableData[i] != 0; i++)
			{
			}
			int num2 = i - num;
			byte[] array = new byte[num2];
			Array.Copy(tableData, num, array, 0, num2);
			list.Add(Encoding.ASCII.GetString(array));
			num += num2;
		}
		List<IGT_ObjInfo> list2 = new List<IGT_ObjInfo>();
		for (int j = 0; j < list.Count; j++)
		{
			list2.Add(JsonUtility.FromJson<IGT_ObjInfo>(list.ElementAt(j)));
		}
		return list2;
	}

	private void Save_LevelData(int _levelID, int _Type, IGT_Missions pMission)
	{
		if (pMission.nMissionType == 5)
		{
			pIGT_LevGenerator.ConvertArrayToString(ref pMission);
		}
		byte[] bytes = Encoding.UTF8.GetBytes(JsonUtility.ToJson(pMission));
		if (!pIgtSavelevelData.isAlreadyPresent(_levelID, _Type))
		{
			pIgtSavelevelData.insertTableInfo(_levelID, _Type, IGT_EncodeDecode.encrypt(bytes));
		}
		else
		{
			pIgtSavelevelData.updateTableInfo(_levelID, _Type, IGT_EncodeDecode.encrypt(bytes));
		}
	}

	private IGT_Missions retrive_Saved_LevelData(int _levelID, int _Type)
	{
		byte[] tableData = pIgtSavelevelData.getTableData(_levelID, _Type);
		if (tableData == null)
		{
			return null;
		}
		IGT_Missions pMission = JsonUtility.FromJson<IGT_Missions>(Encoding.UTF8.GetString(tableData));
		if (pMission.nMissionType == 5)
		{
			pIGT_LevGenerator.GetArrayFromString(ref pMission);
		}
		return pMission;
	}

	private IGT_ZoneData selectStartPathInfo(int index_zone = -1)
	{
		if (index_zone == -1)
		{
			index_zone = UnityEngine.Random.Range(0, ZoneData.Count());
		}
		int index = UnityEngine.Random.Range(0, ZoneData[index_zone].Count);
		return ZoneData[index_zone].ElementAt(index);
	}

	private void MultiLanguageDataSel()
	{
		currentLang = "Chinese";
		xmlTextAsset = (TextAsset)Resources.Load("Info/TranslationDATAS", typeof(TextAsset));
		pIgtTranslator = new IGT_Translator(xmlTextAsset.text, currentLang, false);
		IGT_Constants.StoreLableName = pIgtTranslator.getString("StoreLableName");
		IGT_Constants.ComboLableName = pIgtTranslator.getString("ComboLableName");
		IGT_Constants.BoostLableName = pIgtTranslator.getString("BoostLableName");
		IGT_Constants.FreeLableName = pIgtTranslator.getString("FreeLableName");
		IGT_Constants.HomeScreen_MissionLableName = pIgtTranslator.getString("HomeScreen_MissionLableName");
		IGT_Constants.Music = pIgtTranslator.getString("Music");
		IGT_Constants.Sound = pIgtTranslator.getString("Sound");
		IGT_Constants.Settings = pIgtTranslator.getString("Settings");
		IGT_Constants.MailBox = pIgtTranslator.getString("MailBox");
		IGT_Constants.SendLife = pIgtTranslator.getString("SendLife");
		IGT_Constants.AskLife = pIgtTranslator.getString("AskLife");
		IGT_Constants.AllShare = pIgtTranslator.getString("AllShare");
		IGT_Constants.HS_Shop_Name = pIgtTranslator.getString("HS_Shop_Name");
		IGT_Constants.HS_Fconnect_Name = pIgtTranslator.getString("HS_Fconnect_Name");
		IGT_Constants.HS_Menu_Name = pIgtTranslator.getString("HS_Menu_Name");
		IGT_Constants.Notification = pIgtTranslator.getString("Notification");
		IGT_Constants.RestorePurchase = pIgtTranslator.getString("RestorePurchase");
		IGT_Constants.FbLogOut = pIgtTranslator.getString("FbLogOut");
		IGT_Constants.FbConnect = pIgtTranslator.getString("FbConnect");
		IGT_Constants.EditName = pIgtTranslator.getString("EditNickName");
	}

	private void PurchaseItemsDataSelectionFromFile()
	{
		pPurchaseItemsData_Store = new List<IGT_PurchaseItemsData>();
		pPurchaseItemsData_Store.Clear();
		for (int i = 0; i < IGT_FileReading.nPurchaseItemsCount_store; i++)
		{
			string text = IGT_FileReading.purchaseItemsDatas_store[i];
			string[] array = text.Split('~');
			string pID_Android = array[0];
			string pID_Ios = array[1];
			string pTitle = array[2];
			string pDescrip = array[3];
			string pPrice = array[4];
			string sImgName = array[5];
			int prdType = int.Parse(array[6]);
			int purType = int.Parse(array[7]);
			pPurchaseItemsData_Store.Add(new IGT_PurchaseItemsData(pID_Android, pID_Ios, pTitle, pDescrip, pPrice, sImgName, prdType, purType));
		}
		pPurchaseItemsData_Deals = new List<IGT_PurchaseItemsData>();
		pPurchaseItemsData_Deals.Clear();
		for (int j = 0; j < IGT_FileReading.nPurchaseItemsCount_Deals; j++)
		{
			string text2 = IGT_FileReading.purchaseItemsDatas_Deals[j];
			string[] array2 = text2.Split('~');
			string pID_Android = array2[0];
			string pID_Ios = array2[1];
			string pTitle = array2[2];
			string pDescrip = array2[3];
			string pPrice = array2[4];
			string sImgName = array2[5];
			int prdType = int.Parse(array2[6]);
			int purType = int.Parse(array2[7]);
			pPurchaseItemsData_Deals.Add(new IGT_PurchaseItemsData(pID_Android, pID_Ios, pTitle, pDescrip, pPrice, sImgName, prdType, purType));
		}
		pPurchaseItemsData_Free = new List<IGT_PurchaseItemsData>();
		pPurchaseItemsData_Free.Clear();
		for (int k = 0; k < IGT_FileReading.nPurchaseItemsCount_Free; k++)
		{
			string text3 = IGT_FileReading.purchaseItemsDatas_Free[k];
			string[] array3 = text3.Split('~');
			string pID_Android = array3[0];
			string pID_Ios = array3[1];
			string pTitle = array3[2];
			string pDescrip = array3[3];
			string pPrice = array3[4];
			string sImgName = array3[5];
			int prdType = int.Parse(array3[6]);
			int purType = int.Parse(array3[7]);
			pPurchaseItemsData_Free.Add(new IGT_PurchaseItemsData(pID_Android, pID_Ios, pTitle, pDescrip, pPrice, sImgName, prdType, purType));
		}
		pPurchaseItemsData_Boost = new List<IGT_PurchaseItemsData>();
		pPurchaseItemsData_Boost.Clear();
		List<IGT_UpgradeData> list = new List<IGT_UpgradeData>();
		IGT_Constants.playerPref_Upgrade_CurStateKey = new string[9];
		IGT_Constants.playerPref_Upgrade_CurStateKey[0] = "sdfewerfwh4ghnvfkhty23r2eghradh";
		IGT_Constants.playerPref_Upgrade_CurStateKey[1] = "h25ythahewerfwh4ghnawedhgegartgj5dh";
		IGT_Constants.playerPref_Upgrade_CurStateKey[2] = "l67aerhgmgsaertheat76kjfugtjn";
		IGT_Constants.playerPref_Upgrade_CurStateKey[3] = "ihgphtm8836543lknu4t498t2bua";
		IGT_Constants.playerPref_Upgrade_CurStateKey[4] = "gkjiwuhg3562350mfbzhgwueytgsmiuhgn";
		IGT_Constants.playerPref_Upgrade_CurStateKey[5] = "kmiie9tu4t32nnwdsufuwtbgf4t354tsf";
		IGT_Constants.playerPref_Upgrade_CurStateKey[6] = "nvnt90eig9q65nbnvmngknknhc6745rh5rh";
		IGT_Constants.playerPref_Upgrade_CurStateKey[7] = "cvasngarthgo88t2467mnmnxclrklajukg";
		IGT_Constants.playerPref_Upgrade_CurStateKey[8] = "sdfewerfwh4ghnvfkhty23r2eghradh";
		IGT_Constants.nUpgrade_CurState = new int[9];
		IGT_Constants.nUpgrade_CurState[0] = 0;
		IGT_Constants.nUpgrade_CurState[1] = 0;
		IGT_Constants.nUpgrade_CurState[2] = 0;
		IGT_Constants.nUpgrade_CurState[3] = 0;
		IGT_Constants.nUpgrade_CurState[4] = 0;
		IGT_Constants.nUpgrade_CurState[5] = 0;
		IGT_Constants.nUpgrade_CurState[6] = 0;
		IGT_Constants.nUpgrade_CurState[7] = 0;
		IGT_Constants.nUpgrade_CurState[8] = 0;
		list = new List<IGT_UpgradeData>();
		list.Clear();
		list.Add(new IGT_UpgradeData("Bottle availability increases by 1.2 Times", "20"));
		list.Add(new IGT_UpgradeData("Bottle availability increases by 1.5 Times ", "75"));
		list.Add(new IGT_UpgradeData("Bottle availability increases by 1.9 Times ", "150"));
		list.Add(new IGT_UpgradeData("Bottle availability increases by 3 Times ", "300"));
		list.Add(new IGT_UpgradeData("Bottle availability increases by 5 Times ", "500"));
		pPurchaseItemsData_Boost.Add(new IGT_PurchaseItemsData("Bottle Availability", "Images/UI/Bottle", "Images/UI/Key", IGT_Constants.nUpgrade_CurState[0], list));
		list = new List<IGT_UpgradeData>();
		list.Clear();
		list.Add(new IGT_UpgradeData("Ball availability increases by 1.2 Times ", "75,000"));
		list.Add(new IGT_UpgradeData("Ball availability increases by 1.5 Times ", "250,000"));
		list.Add(new IGT_UpgradeData("Ball availability increases by 1.9 Times ", "1,000,000"));
		list.Add(new IGT_UpgradeData("Ball availability increases by 3 Times ", "2,000,000"));
		list.Add(new IGT_UpgradeData("Ball availability increases by 5 Times ", "5,000,000"));
		pPurchaseItemsData_Boost.Add(new IGT_PurchaseItemsData("Ball Availability", "Images/UI/Ball", "Images/UI/Coin", IGT_Constants.nUpgrade_CurState[1], list));
		list = new List<IGT_UpgradeData>();
		list.Clear();
		list.Add(new IGT_UpgradeData("Health increases by 7 % ", "25"));
		list.Add(new IGT_UpgradeData("Health increases by 9 % ", "100"));
		list.Add(new IGT_UpgradeData("Health increases by 11 % ", "200"));
		list.Add(new IGT_UpgradeData("Health increases by 14 % ", "350"));
		list.Add(new IGT_UpgradeData("Health increases by 18 % ", "500"));
		pPurchaseItemsData_Boost.Add(new IGT_PurchaseItemsData("Health Booster", "Images/UI/MedPlus", "Images/UI/Life", IGT_Constants.nUpgrade_CurState[2], list));
		list = new List<IGT_UpgradeData>();
		list.Clear();
		list.Add(new IGT_UpgradeData("Health increases by 13 % ", "15"));
		list.Add(new IGT_UpgradeData("Health increases by 15 % ", "50"));
		list.Add(new IGT_UpgradeData("Health increases by 18 % ", "100"));
		list.Add(new IGT_UpgradeData("Health increases by 20 % ", "200"));
		list.Add(new IGT_UpgradeData("Health increases by 25 % ", "300"));
		pPurchaseItemsData_Boost.Add(new IGT_PurchaseItemsData("Mega Health Booster", "Images/UI/MedKit", "Images/UI/Life", IGT_Constants.nUpgrade_CurState[3], list));
		list = new List<IGT_UpgradeData>();
		list.Clear();
		list.Add(new IGT_UpgradeData("Score multiplies by 2 ", "100,000"));
		list.Add(new IGT_UpgradeData("Score multiplies by 3 ", "300,000"));
		list.Add(new IGT_UpgradeData("Score multiplies by 4 ", "1,500,000"));
		list.Add(new IGT_UpgradeData("Score multiplies by 5 ", "3,000,000"));
		list.Add(new IGT_UpgradeData("Score multiplies by 6 ", "5,000,000"));
		pPurchaseItemsData_Boost.Add(new IGT_PurchaseItemsData("Score Multiplier", "Images/UI/ScoreMultiplier", "Images/UI/Coin", IGT_Constants.nUpgrade_CurState[4], list));
		list = new List<IGT_UpgradeData>();
		list.Clear();
		list.Add(new IGT_UpgradeData("2X Coins duration lasts upto 15 sec", "40,000"));
		list.Add(new IGT_UpgradeData("2X Coins duration lasts upto 20 sec", "100,000"));
		list.Add(new IGT_UpgradeData("2X Coins duration lasts upto 30 sec ", "500,000"));
		list.Add(new IGT_UpgradeData("2X Coins duration lasts upto 45 sec ", "1,000,000"));
		list.Add(new IGT_UpgradeData("2X Coins duration lasts upto 60 sec ", "2,000,000"));
		pPurchaseItemsData_Boost.Add(new IGT_PurchaseItemsData("Coin 2X Duration", "Images/UI/coin_2x_Store", "Images/UI/Coin", IGT_Constants.nUpgrade_CurState[5], list));
		list = new List<IGT_UpgradeData>();
		list.Clear();
		list.Add(new IGT_UpgradeData("3X Coins duration lasts upto 15 sec", "25,000"));
		list.Add(new IGT_UpgradeData("2X Coins duration lasts upto 20 sec", "75,000"));
		list.Add(new IGT_UpgradeData("2X Coins duration lasts upto 30 sec ", "250,000"));
		list.Add(new IGT_UpgradeData("2X Coins duration lasts upto 45 sec ", "500,000"));
		list.Add(new IGT_UpgradeData("2X Coins duration lasts upto 60 sec ", "1,000,000"));
		pPurchaseItemsData_Boost.Add(new IGT_PurchaseItemsData("Coin 3X Duration", "Images/UI/coin_3x_Store", "Images/UI/Coin", IGT_Constants.nUpgrade_CurState[6], list));
		list = new List<IGT_UpgradeData>();
		list.Clear();
		list.Add(new IGT_UpgradeData("Magnet duration lasts upto 20 sec", "50,000"));
		list.Add(new IGT_UpgradeData("Magnet duration lasts upto 30 sec", "150,000"));
		list.Add(new IGT_UpgradeData("Magnet duration lasts upto 45 sec ", "500,000"));
		list.Add(new IGT_UpgradeData("Magnet duration lasts upto 60 sec ", "1,500,000"));
		list.Add(new IGT_UpgradeData("Magnet duration lasts upto 90 sec ", "3,000,000"));
		pPurchaseItemsData_Boost.Add(new IGT_PurchaseItemsData("Magnet Duration", "Images/UI/magnet", "Images/UI/Coin", IGT_Constants.nUpgrade_CurState[7], list));
		list = new List<IGT_UpgradeData>();
		list.Clear();
		list.Add(new IGT_UpgradeData("Shield duration lasts upto 15 sec", "10"));
		list.Add(new IGT_UpgradeData("Shield duration lasts upto 20 sec", "25"));
		list.Add(new IGT_UpgradeData("Shield duration lasts upto 25 sec ", "50"));
		list.Add(new IGT_UpgradeData("Shield duration lasts upto 30 sec ", "100"));
		list.Add(new IGT_UpgradeData("Shield duration lasts upto 40 sec ", "200"));
		pPurchaseItemsData_Boost.Add(new IGT_PurchaseItemsData("Shield Duration", "Images/UI/invisible", "Images/UI/Key", IGT_Constants.nUpgrade_CurState[8], list));
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_Upgrade_CurStateKey[0]))
		{
			IGT_Constants.nUpgrade_CurState[0] = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_Upgrade_CurStateKey[0], 0);
		}
		else
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_Upgrade_CurStateKey[0], IGT_Constants.nUpgrade_CurState[0]);
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_Upgrade_CurStateKey[1]))
		{
			IGT_Constants.nUpgrade_CurState[1] = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_Upgrade_CurStateKey[1], 0);
		}
		else
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_Upgrade_CurStateKey[1], IGT_Constants.nUpgrade_CurState[1]);
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_Upgrade_CurStateKey[2]))
		{
			IGT_Constants.nUpgrade_CurState[2] = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_Upgrade_CurStateKey[2], 0);
		}
		else
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_Upgrade_CurStateKey[2], IGT_Constants.nUpgrade_CurState[2]);
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_Upgrade_CurStateKey[3]))
		{
			IGT_Constants.nUpgrade_CurState[3] = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_Upgrade_CurStateKey[3], 0);
		}
		else
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_Upgrade_CurStateKey[3], IGT_Constants.nUpgrade_CurState[3]);
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_Upgrade_CurStateKey[4]))
		{
			IGT_Constants.nUpgrade_CurState[4] = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_Upgrade_CurStateKey[4], 0);
		}
		else
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_Upgrade_CurStateKey[4], IGT_Constants.nUpgrade_CurState[4]);
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_Upgrade_CurStateKey[5]))
		{
			IGT_Constants.nUpgrade_CurState[5] = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_Upgrade_CurStateKey[5], 0);
		}
		else
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_Upgrade_CurStateKey[5], IGT_Constants.nUpgrade_CurState[5]);
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_Upgrade_CurStateKey[6]))
		{
			IGT_Constants.nUpgrade_CurState[6] = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_Upgrade_CurStateKey[6], 0);
		}
		else
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_Upgrade_CurStateKey[6], IGT_Constants.nUpgrade_CurState[6]);
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_Upgrade_CurStateKey[7]))
		{
			IGT_Constants.nUpgrade_CurState[7] = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_Upgrade_CurStateKey[7], 0);
		}
		else
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_Upgrade_CurStateKey[7], IGT_Constants.nUpgrade_CurState[7]);
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_Upgrade_CurStateKey[8]))
		{
			IGT_Constants.nUpgrade_CurState[8] = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_Upgrade_CurStateKey[8], 0);
		}
		else
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_Upgrade_CurStateKey[8], IGT_Constants.nUpgrade_CurState[8]);
		}
		for (int l = 0; l < pPurchaseItemsData_Boost.Count; l++)
		{
			pPurchaseItemsData_Boost.ElementAt(l).nCurUpgradeState = IGT_Constants.nUpgrade_CurState[l];
		}
		update_UpgradeInfo();
	}

	public void update_UpgradeInfo()
	{
		float num = 0f;
		float num2 = pHeroData[nHeroIndex].EnergyIncreasingMaxVal * 100f;
		switch (IGT_Constants.nUpgrade_CurState[0])
		{
		case 1:
			num = 1.2f;
			break;
		case 2:
			num = 1.5f;
			break;
		case 3:
			num = 1.9f;
			IGT_Achivements.completeAchivements(8, 3);
			break;
		case 4:
			num = 3f;
			break;
		case 5:
			num = 5f;
			break;
		default:
			num = 1f;
			break;
		}
		IGT_Constants.Multiplier_Bottle = num;
		switch (IGT_Constants.nUpgrade_CurState[1])
		{
		case 1:
			num = 1.2f;
			break;
		case 2:
			num = 1.5f;
			break;
		case 3:
			num = 1.9f;
			break;
		case 4:
			num = 3f;
			break;
		case 5:
			num = 5f;
			break;
		default:
			num = 1f;
			break;
		}
		IGT_Constants.Multiplier_Ball = num;
		switch (IGT_Constants.nUpgrade_CurState[2])
		{
		case 1:
			num = num2 + 2f;
			break;
		case 2:
			num = num2 + 4f;
			break;
		case 3:
			num = num2 + 6f;
			break;
		case 4:
			num = num2 + 9f;
			break;
		case 5:
			num = num2 + 13f;
			IGT_Achivements.completeAchivements(8, 5);
			break;
		default:
			num = num2;
			break;
		}
		IGT_Constants.Multiplier_MedPlus = num / 100f;
		switch (IGT_Constants.nUpgrade_CurState[3])
		{
		case 1:
			num = 2f * num2 + 3f;
			break;
		case 2:
			num = 2f * num2 + 5f;
			break;
		case 3:
			num = 2f * num2 + 8f;
			break;
		case 4:
			num = 2f * num2 + 10f;
			break;
		case 5:
			num = 2f * num2 + 15f;
			break;
		default:
			num = 2f * num2;
			break;
		}
		IGT_Constants.Multiplier_MedKit = num / 100f;
		IGT_Constants.Multiplier_Score = 1 + IGT_Constants.nUpgrade_CurState[4];
		if (IGT_Constants.nUpgrade_CurState[4] == 2)
		{
			IGT_Achivements.completeAchivements(8, 2);
		}
		switch (IGT_Constants.nUpgrade_CurState[5])
		{
		case 1:
			num = 15f;
			break;
		case 2:
			num = 20f;
			break;
		case 3:
			num = 30f;
			break;
		case 4:
			num = 45f;
			break;
		case 5:
			num = 60f;
			break;
		default:
			num = 10f;
			break;
		}
		IGT_Constants.fCoin_2x_TotTime = num;
		switch (IGT_Constants.nUpgrade_CurState[6])
		{
		case 1:
			num = 15f;
			break;
		case 2:
			num = 20f;
			break;
		case 3:
			num = 30f;
			break;
		case 4:
			num = 45f;
			break;
		case 5:
			num = 60f;
			break;
		default:
			num = 10f;
			break;
		}
		IGT_Constants.fCoin_3x_TotTime = num;
		switch (IGT_Constants.nUpgrade_CurState[7])
		{
		case 1:
			num = 20f;
			IGT_Achivements.completeAchivements(8, 1);
			break;
		case 2:
			num = 30f;
			break;
		case 3:
			num = 45f;
			break;
		case 4:
			num = 60f;
			break;
		case 5:
			num = 90f;
			break;
		default:
			num = 10f;
			break;
		}
		IGT_Constants.fMagnetPowerTotTime = num;
		switch (IGT_Constants.nUpgrade_CurState[8])
		{
		case 1:
			num = 15f;
			break;
		case 2:
			num = 20f;
			break;
		case 3:
			num = 25f;
			break;
		case 4:
			num = 30f;
			break;
		case 5:
			num = 40f;
			break;
		default:
			num = 10f;
			break;
		}
		IGT_Constants.fInvisbleMode_TotTime = num;
	}

	private void HeroDataSelection()
	{
		nHeroIndex = 0;
		pHeroData = new List<IGT_HeroData>();
		pHeroData.Clear();
		for (int i = 0; i < IGT_FileReading.nHeroTotCount; i++)
		{
			string text = IGT_FileReading.HeroDatas[i];
			string[] array = text.Split('~');
			int idx = int.Parse(array[0]);
			string text2 = array[1];
			float baseSpd = float.Parse(array[2]);
			float minSpd = float.Parse(array[3]);
			float maxSpd = float.Parse(array[4]);
			float spdAccelFactor = float.Parse(array[5]);
			float spdDeAccelFactor = float.Parse(array[6]);
			float energyIncMinVal = float.Parse(array[7]);
			float energyIncMaxVal = float.Parse(array[8]);
			float prevSpdProp = float.Parse(array[9]);
			pHeroData.Add(new IGT_HeroData(idx, text2, baseSpd, minSpd, maxSpd, spdAccelFactor, spdDeAccelFactor, energyIncMinVal, energyIncMaxVal, prevSpdProp));
		}
		HeroParametersSel();
	}

	private void HeroParametersSel()
	{
		PlayerObj.speed = (PlayerObj.PrevSpeed = (PlayerObj.BaseSpeed = (PlayerObj.prevBaseSpeed = pHeroData[nHeroIndex].BaseSpeed)));
		PlayerObj.MinSpeed = pHeroData[nHeroIndex].MinSpeed;
		PlayerObj.MaxSpeed = (PlayerObj.PrevMaxSpeed = pHeroData[nHeroIndex].MaxSpeed);
		PlayerObj.SpeedAccelerationFactor = pHeroData[nHeroIndex].SpdAccelerationFactor;
		PlayerObj.EnergyDeAcceleratorFactorPerSecond = pHeroData[nHeroIndex].EnergyDeAccelerationFactorPerSecond;
		PlayerObj.EnergyDecMinVal = pHeroData[nHeroIndex].EnergyIncreasingMinValue;
		PlayerObj.EnergyDecMaxVal = pHeroData[nHeroIndex].EnergyIncreasingMaxVal;
		PlayerObj.prevSpeedProportion = pHeroData[nHeroIndex].prevSpdProPortion;
	}

	private void HeroCharInstantiation()
	{
		pHeroTransperent_Material = (Material)Resources.Load(IGT_Constants.Path_HeroMat_Transparent, typeof(Material));
		pKick_TrailFireMaterial = (Material)Resources.Load("Objects/Materials/kick_FireTrail", typeof(Material));
		pHeroMaterials = new Material[pHeroData.Count];
		for (int i = 0; i < pHeroData.Count; i++)
		{
			pHeroMaterials[i] = (Material)Resources.Load(IGT_Constants.Path_HeroMaterials + i, typeof(Material));
		}
		if (GameObject.FindGameObjectWithTag(IGT_Constants.Tag_Player).GetComponent<IGT_GameView>() == null)
		{
			GameObject.FindGameObjectWithTag(IGT_Constants.Tag_Player).AddComponent<IGT_GameView>()._Start();
		}
		HeroCharacters_Low = new GameObject[pHeroData.Count];
		for (int j = 0; j < HeroCharacters_Low.Length; j++)
		{
			HeroCharacters_Low[j] = UnityEngine.Object.Instantiate(Resources.Load(IGT_Constants.Path_Hero_Prefab_Low + j), Vector3.one * -1000f, Quaternion.Euler(0f, 180f, 0f)) as GameObject;
			HeroCharacters_Low[j].name = IGT_Constants.Hero_String + j;
			HeroCharacters_Low[j].tag = IGT_Constants.Tag_Hero + j;
			HeroCharacters_Low[j].layer = LayerMask.NameToLayer(IGT_Constants.layer_Characters);
		}
		IGT_GameView.InstantiateCharacter_select();
	}

	public void changeCharacter(int idx)
	{
		nHeroIndex = idx;
		HeroComponentsSel();
	}

	private void HeroComponentsSel()
	{
		for (int i = 0; i < HeroCharacters_Low.Length; i++)
		{
			HeroCharacters_Low[i].SetActive(true);
			HeroCharacters_Low[i].transform.position = Vector3.one * -1000f;
			if (i != nHeroIndex)
			{
				if (HeroCharacters_Low[i].GetComponent<IGT_AnimStatesCntrler>() != null)
				{
					UnityEngine.Object.Destroy(HeroCharacters_Low[i].GetComponent<IGT_AnimStatesCntrler>());
				}
				if (HeroCharacters_Low[i].GetComponent<AudioSource>() != null)
				{
					UnityEngine.Object.Destroy(HeroCharacters_Low[i].GetComponent<AudioSource>());
				}
				HeroCharacters_Low[i].GetComponent<Animator>().enabled = false;
				HeroCharacters_Low[i].SetActive(false);
			}
		}
		player = GameObject.FindGameObjectWithTag(IGT_Constants.Tag_Hero + nHeroIndex);
		pIgtCamControl.pCamFollow.camTarget = player.transform;
		if (GameObject.Find(IGT_Constants.Hero_String + nHeroIndex + IGT_Constants.Path_Hero_Wrist + "/" + IGT_Constants.String_AIWrist) == null)
		{
			GameObject gameObject = new GameObject(IGT_Constants.String_AIWrist);
			gameObject.transform.SetParent(GameObject.Find(IGT_Constants.Hero_String + nHeroIndex + IGT_Constants.Path_Hero_Wrist).transform);
			gameObject.transform.localPosition = new Vector3(-0.00052f, 0.00027f, 0.00054f);
			gameObject.transform.localScale = Vector3.one;
			gameObject.transform.localRotation = Quaternion.Euler(new Vector3(-75f, 0f, 0f));
		}
		Hero_HandWristPos = GameObject.Find(IGT_Constants.Hero_String + nHeroIndex + IGT_Constants.Path_Hero_Wrist + "/" + IGT_Constants.String_AIWrist);
		Hero_HandWristPos_Left = GameObject.Find(IGT_Constants.Hero_String + nHeroIndex + IGT_Constants.Path_Hero_Wrist_Left);
		Hero_HeadPos = GameObject.Find(IGT_Constants.Hero_String + nHeroIndex + IGT_Constants.Path_Hero_Head);
		pHero_MeshRenderer = player.GetComponentInChildren<SkinnedMeshRenderer>();
		pHero_MeshRenderer.material = pHeroMaterials[nHeroIndex];
		Animator component = player.GetComponent<Animator>();
		component.runtimeAnimatorController = Resources.Load(IGT_Constants.Path_Controller_Hero) as RuntimeAnimatorController;
		component.applyRootMotion = false;
		component.enabled = true;
		if (player.GetComponent<IGT_AnimStatesCntrler>() == null)
		{
			player.AddComponent<IGT_AnimStatesCntrler>();
		}
		GameObject gameObject2 = GameObject.Find(IGT_Constants.Hero_String + nHeroIndex + IGT_Constants.Path_Hero_thingR);
		if (gameObject2.GetComponent<Rigidbody>() == null)
		{
			Rigidbody rigidbody = gameObject2.AddComponent<Rigidbody>();
			rigidbody.isKinematic = true;
			rigidbody.useGravity = false;
			BoxCollider boxCollider = gameObject2.AddComponent<BoxCollider>();
			boxCollider.isTrigger = true;
			boxCollider.center = new Vector3(-0.0005f, 0.005f, 0f);
			boxCollider.size = new Vector3(0.004f, 0.01f, 0.002f);
			gameObject2.AddComponent<IGT_EnergyItemCollision>();
		}
		GameObject gameObject3 = GameObject.Find(IGT_Constants.Hero_String + nHeroIndex + IGT_Constants.Path_Hero_Chest);
		if (gameObject3.GetComponent<Rigidbody>() == null)
		{
			Rigidbody rigidbody2 = gameObject3.AddComponent<Rigidbody>();
			rigidbody2.isKinematic = true;
			rigidbody2.useGravity = false;
			BoxCollider boxCollider2 = gameObject3.AddComponent<BoxCollider>();
			boxCollider2.isTrigger = true;
			boxCollider2.center = Vector3.zero;
			boxCollider2.size = new Vector3(0.004f, 0.008f, 0.002f);
			gameObject3.AddComponent<IGT_EnergyItemCollision>();
		}
		int num = nAIPlayerIndex;
		if (nGameMode == 0 || (nGameMode == 1 && nMissionID <= 2) || IGT_GameView.nScreenMode == 0)
		{
			Chase_RobbScene_DataSel();
		}
		nAIPlayerIndex = num;
		HeroParametersSel();
		if ((n3dModelUsageMode != 0 || n3dModelUsageMode_Prev != 1) && (n3dModelUsageMode != 1 || n3dModelUsageMode_Prev != 0))
		{
			shadowprojectorCreation();
		}
		if (nHeroIndex == 1)
		{
			_AudioSource5.pitch = 1.35f;
		}
		else
		{
			_AudioSource5.pitch = 1f;
		}
	}

	public void Chase_RobbScene_DataSel()
	{
		player.transform.position = new Vector3(1.1f, 0.042f, -69.751f);
		player.transform.rotation = Quaternion.Euler(new Vector3(0f, -30f, 0f));
		player.transform.localScale = new Vector3(1f, 1f, 1f);
		if (IGT_AnimStatesCntrler.HeroAnimator != null)
		{
			IGT_AnimStatesCntrler.HeroAnimator.StopPlayback();
			IGT_AnimStatesCntrler.HeroAnimator.Play("Idle", 0);
			IGT_AnimStatesCntrler.nHeroAnimState = 0;
		}
		DestroyAllAIPlayersUsingTags();
		PlayerObj.DestroyAllTypesofObjects();
		heroine_DataSel(new Vector3(0.887f, 0.042f, -69.669f), Quaternion.Euler(new Vector3(0f, 150f, 0f)));
		UnityEngine.Object.Destroy(Endless_Bag);
		EndlessBag_Creation(Heroine_Wrist.transform);
		bStrtButton = false;
		bPauseButton = false;
		bRobbingSceneFinished = false;
		bAIplayerStart = false;
		bBagInHeroinHand = false;
		bCamStartFollow = false;
		pIgtCamControl.pCamFollow._Go_CamIntro.GetComponent<GameIntro>().resetAll();
		pDirLight = GameObject.Find("ShadowLight");
		pDirLight.transform.rotation = Quaternion.Euler(0f, -30f, 0f);
		pDirLightAnimator = new IGT_Animator();
	}

	private void heroine_DataSel(Vector3 pos, Quaternion rot)
	{
		UnityEngine.Object.Destroy(Heroine);
		if (nHeroIndex != 1)
		{
			Heroine = UnityEngine.Object.Instantiate(Resources.Load("HeroMaterials/Girl"), pos, rot) as GameObject;
			SkinnedMeshRenderer[] componentsInChildren = Heroine.GetComponentsInChildren<SkinnedMeshRenderer>();
			for (int i = 0; i < componentsInChildren.Count(); i++)
			{
				componentsInChildren[i].material = (Material)Resources.Load("HeroMaterials/Materials/Girl", typeof(Material));
			}
		}
		else
		{
			Heroine = UnityEngine.Object.Instantiate(Resources.Load("HeroMaterials/Hero_0"), pos, rot) as GameObject;
			SkinnedMeshRenderer componentInChildren = Heroine.GetComponentInChildren<SkinnedMeshRenderer>();
			componentInChildren.material = pHeroMaterials[0];
		}
		Heroine.name = IGT_Constants.Heroine_String;
		Animator component = Heroine.GetComponent<Animator>();
		component.runtimeAnimatorController = Resources.Load(IGT_Constants.Path_Controller_Heroine) as RuntimeAnimatorController;
		component.applyRootMotion = false;
		Heroine_Wrist = GameObject.Find(IGT_Constants.Heroine_String + IGT_Constants.Path_Hero_Wrist);
		setLayerToAllChildrens(Heroine, IGT_Constants.layer_Characters);
	}

	private void fogSelection(bool enable)
	{
		if (enable)
		{
			RenderSettings.fog = true;
			RenderSettings.fogColor = new Color(0.41960785f, 56f / 85f, 0.8980392f, 1f);
			RenderSettings.fogMode = FogMode.Linear;
			RenderSettings.fogStartDistance = 12f;
			RenderSettings.fogEndDistance = 20f;
			RenderSettings.fogDensity = 0.05f;
		}
		else
		{
			RenderSettings.fog = false;
		}
	}

	private void Awake()
	{
		Application.targetFrameRate = (nTargetFrameRate = 60);
		n3dModelUsageMode = (n3dModelUsageMode_Prev = 0);
		ChangeTerrain(true);
	}

	public bool isConnectedInternet()
	{
		if (IGT_GameView.nGetCurrentPlatform() == 2)
		{
			return false;
		}
		if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork || Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
		{
			return true;
		}
		return false;
	}

	private void DestroyAllObjectsUsingTAG(string tagName)
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag(tagName);
		for (int i = 0; i < array.Length; i++)
		{
			UnityEngine.Object.Destroy(array[i]);
		}
	}

	public void DestroyAllAIPlayersUsingTags()
	{
		for (int i = 0; i < IGT_FileReading.nAIPlayerCount; i++)
		{
			UnityEngine.Object.Destroy(GameObject.FindGameObjectWithTag(IGT_Constants.AIPlayerString + i));
		}
		nAIPlayerIndex = -1;
	}

	public void destroyUnwantedGameobjects()
	{
		destroy_SurprisePlayer();
		DestroyAllObjectsUsingTAG(IGT_Constants.Tag_ThrowObj);
		if (IGT_SurpriseAIplayer.SurpriseAI == null || (IGT_SurpriseAIplayer.SurpriseAI != null && IGT_SurpriseAIplayer.playerAction != 1))
		{
			UnityEngine.Object.Destroy(GameObject.Find(IGT_Constants.SurpriseAIplayer + IGT_Constants.Tag_ThrowObj));
		}
		UnityEngine.Object.Destroy(GameObject.Find("700"));
		DestroyAllObjectsUsingTAG(IGT_Constants.Tag_KickObj);
		DestroyAllObjectsUsingTAG(IGT_Constants.Tag_Finish);
		IGT_Objects.PickedObj_InstanceID = -1;
		bThrwObjPicked = false;
		if (BB_CollectionItem != null)
		{
			UnityEngine.Object.Destroy(BB_CollectionItem);
		}
		if (BB_CollectionItemGlow != null)
		{
			UnityEngine.Object.Destroy(BB_CollectionItemGlow);
		}
		if (missionEndWall != null)
		{
			UnityEngine.Object.Destroy(missionEndWall);
		}
		if (Endless_Bag != null)
		{
			UnityEngine.Object.Destroy(Endless_Bag);
		}
		BB_CollectionItem = null;
		BB_CollectionItemGlow = null;
		missionEndWall = null;
		Endless_Bag = null;
	}

	public void _OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == IGT_Constants.Tag_Coin)
		{
			if (lastCollidedCoinPosition == col.gameObject.transform.position)
			{
				return;
			}
			lastCollidedCoinPosition = col.gameObject.transform.position;
			UnityEngine.Object.Destroy(col.gameObject);
			bEnergyItemsAnimation = false;
			if (nGameMode == 1 && pMissionData.nMissionType == 0 && pMissionData.nCollectionInnerItemType == 0)
			{
				if (!bGameOver)
				{
					nCollectedItemCount++;
					if (bCoin_2x)
					{
						nCollectedItemCount++;
					}
					else if (bCoin_3x)
					{
						nCollectedItemCount += 2;
					}
					Vector3 vector = Camera.main.WorldToScreenPoint(col.gameObject.transform.position);
					Vector3 strt = new Vector3(vector.x, PlayerObj.fDeviceHeight - vector.y, 0f);
					Vector3 end = new Vector3(IGT_GameView.rect_MultipleCollectionItemImg[0].x + IGT_GameView.rect_MultipleCollectionItemImg[0].width / 2f, IGT_GameView.rect_MultipleCollectionItemImg[0].y + IGT_GameView.rect_MultipleCollectionItemImg[0].height / 2f, 0f);
					Vector3 centre = new Vector3(IGT_UIcommonFunc.ScaleX(300f), IGT_UIcommonFunc.ScaleY(240f), -10f);
					float num = IGT_GameView.rect_MultipleCollectionItemImg[0].width * 0.5f;
					float centerWidth = num + num * 0.7f;
					float endWidth = num - num * 0.25f;
					float num2 = IGT_GameView.rect_MultipleCollectionItemImg[0].height * 0.5f;
					float centerHeight = num2 + num2 * 0.7f;
					float endHeight = num2 - num2 * 0.25f;
					pBezierAnimation.Add(new IGT_BezierAnimation(strt, centre, end, 0f, 0.5f, num, num2, centerWidth, centerHeight, endWidth, endHeight, IGT_GameView.pIgt_Textures.GetTexture(IGT_Constants.collectionItemsImg[pMissionData.nCollectionInnerItemType])));
				}
				for (int num3 = PlayerObj.pObj.missionObj_PlacedDetails.Count - 1; num3 >= 0; num3--)
				{
					if (PlayerObj.pObj.missionObj_PlacedDetails[num3].ObjPos.x == col.gameObject.transform.position.x && PlayerObj.pObj.missionObj_PlacedDetails[num3].ObjPos.z == col.gameObject.transform.position.z)
					{
						PlayerObj.pObj.missionObj_PlacedDetails.RemoveAt(num3);
						break;
					}
				}
			}
			else if (bCoin_2x)
			{
				IGT_Constants.nNoOfCollectedCoins += 2;
				nScore_Coin_Chase = 500 * (int)Mathf.Pow(nAIPlayerIndex + 1, 2f);
			}
			else if (bCoin_3x)
			{
				IGT_Constants.nNoOfCollectedCoins += 3;
				nScore_Coin_Chase = 750 * (int)Mathf.Pow(nAIPlayerIndex + 1, 2f);
			}
			else
			{
				IGT_Constants.nNoOfCollectedCoins++;
				nScore_Coin_Chase = 250 * (int)Mathf.Pow(nAIPlayerIndex + 1, 2f);
			}
			playSound(nCoinSoundIdx, 1f, true);
			if (IGT_Constants.nNoOfCollectedCoins % 3 == 0)
			{
				nCoinSoundIdx++;
				if (nCoinSoundIdx >= _AudioClips_Coin.Length - 1)
				{
					nCoinSoundIdx = 0;
				}
			}
		}
		if (bGameOver && !bMissionCompleted)
		{
			return;
		}
		if (col.gameObject.name == IGT_Constants.SurpriseAIplayer + IGT_Constants.Tag_ThrowObj)
		{
			if (lastCollidedEnergyItemPos == col.gameObject.transform.position)
			{
				return;
			}
			if (!(Time.time - IGT_Constants.useKeyLifeStartTime < IGT_Constants.useKeyTotLifeTime) && !bInvisibleMode)
			{
				PlayerObj.nEnergyMeterPrev = PlayerObj.nEnergyMeter;
				PlayerObj.nEnergyMeterNext = PlayerObj.nEnergyMeter - UnityEngine.Random.Range(PlayerObj.EnergyDecMinVal, PlayerObj.EnergyDecMaxVal);
				PlayerObj.fTimeForEnergyMeterChanges = 0f;
				PlayerObj.bEnergyMeterChangesinBezier = true;
				IGT_GameView.bLowEnergy_Hero = true;
				IGT_GameView.fLowEnergy_Hero_StrtTime = Time.time;
				col.gameObject.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
				GameObject gameObject = UnityEngine.Object.Instantiate(IGT_ObjPlacing.Throw_BottleCrackAnim, new Vector3(col.gameObject.transform.position.x, col.gameObject.transform.position.y + 0.2f, col.gameObject.transform.position.z), col.gameObject.transform.rotation);
				gameObject.AddComponent<Rigidbody>();
				UnityEngine.Object.Destroy(gameObject, 4f);
				playSound(4);
			}
			UnityEngine.Object.Destroy(col.gameObject);
		}
		if (col.gameObject.tag == IGT_Constants.Tag_DynamicObj || col.gameObject.tag == IGT_Constants.SurpriseAIplayer)
		{
			if (bGameOver && col.gameObject.tag == IGT_Constants.SurpriseAIplayer)
			{
				return;
			}
			if (!(Time.time - IGT_Constants.useKeyLifeStartTime < IGT_Constants.useKeyTotLifeTime) && !bInvisibleMode && !bAIMode && !bAutoMaticModefrTesting)
			{
				int flag = -1;
				if (col.gameObject.tag == IGT_Constants.SurpriseAIplayer)
				{
					if (IGT_SurpriseAIplayer.playerAction == 0)
					{
						flag = 2;
					}
					else if (IGT_SurpriseAIplayer.playerAction == 1)
					{
						flag = 1;
					}
				}
				else if (col.name == "Brick29" || col.name == "BrokenWall29")
				{
					flag = 1;
				}
				else
				{
					switch (int.Parse(col.name))
					{
					case 200:
					case 201:
					case 202:
					case 203:
					case 204:
					case 205:
					case 206:
					case 400:
					case 401:
					case 402:
					case 403:
					case 605:
					case 606:
					case 607:
					case 608:
						flag = 3;
						break;
					}
				}
				GameOver_AnimationSelection(flag);
				IGT_GameView.nArrowAnimType = -1;
				if (nSound == 0)
				{
					if (col.gameObject.tag == IGT_Constants.SurpriseAIplayer)
					{
						playSound(22);
					}
					else if (col.name == "Brick29" || col.name == "BrokenWall29")
					{
						playSound(26);
					}
					else
					{
						switch (int.Parse(col.name))
						{
						case 102:
						case 103:
						case 200:
						case 201:
						case 204:
						case 205:
						case 206:
						case 607:
						case 608:
							playSound(23);
							break;
						case 100:
						case 101:
							playSound(24);
							break;
						case 400:
						case 401:
						case 402:
						case 403:
							playSound(36);
							break;
						case 202:
						case 203:
						case 605:
						case 606:
							playSound(21);
							break;
						}
						playSound(26);
					}
				}
			}
		}
		if (col.gameObject.tag == IGT_Constants.Tag_MissionFailedGate)
		{
			playSound(36, 0.6f);
			playSound(26);
			GameOver_AnimationSelection(3);
		}
		if (!bHasPicked_BBitem && col.gameObject.tag == IGT_Constants.Tag_BB_Item)
		{
			bHasPicked_BBitem = true;
			if (BB_CollectionItemGlow != null)
			{
				UnityEngine.Object.Destroy(BB_CollectionItemGlow);
			}
			IGT_GameView.bBringBackAlert = true;
			IGT_GameView.bBringBackAlert_Alpha = false;
			IGT_GameView.fBringBack_Alert_StrtTime = Time.time;
			IGT_GameView.sBringBackAlertText = " Coming back...";
			IGT_GameView.sBringBackDemoText = "Use Map to locate \n Your Companion";
			IGT_GameView.fBringBack_Alert_Alpha_StartTime = Time.time;
		}
		if (col.gameObject.tag == IGT_Constants.Tag_CollectionObj)
		{
			if (lastCollidedCoinPosition == col.gameObject.transform.position)
			{
				return;
			}
			lastCollidedCoinPosition = col.gameObject.transform.position;
			UnityEngine.Object.Destroy(col.gameObject);
			if (nGameMode == 1 && pMissionData.nMissionType == 0)
			{
				nCollectedItemCount++;
				Vector3 vector2 = Camera.main.WorldToScreenPoint(col.gameObject.transform.position);
				Vector3 strt2 = new Vector3(vector2.x, PlayerObj.fDeviceHeight - vector2.y, 0f);
				Vector3 end2 = new Vector3(IGT_GameView.rect_MultipleCollectionItemImg[0].x, IGT_GameView.rect_MultipleCollectionItemImg[0].y, 0f);
				Vector3 centre2 = new Vector3(end2.x, strt2.y - IGT_UIcommonFunc.ScaleY(40f), -10f);
				float width = IGT_GameView.rect_MultipleCollectionItemImg[0].width;
				float centerWidth2 = width + width * 2.5f;
				float endWidth2 = width - width * 0.5f;
				float height = IGT_GameView.rect_MultipleCollectionItemImg[0].height;
				float centerHeight2 = height + height * 2.5f;
				float endHeight2 = height - height * 0.5f;
				pBezierAnimation.Add(new IGT_BezierAnimation(strt2, centre2, end2, 0f, 0.75f, width, height, centerWidth2, centerHeight2, endWidth2, endHeight2, IGT_GameView.pIgt_Textures.GetTexture(IGT_Constants.collectionItemsImg[pMissionData.nCollectionInnerItemType])));
			}
			else if (nGameMode == 1 && pMissionData.nMissionType == 5)
			{
				for (int i = 0; i < pMissionData.nNumOfMultipleCollection; i++)
				{
					if (pMissionData.nMultipleCollectionDatas[i, 0] != int.Parse(col.gameObject.name))
					{
						continue;
					}
					nCollectedMultipleItemCount[i]++;
					Vector3 vector3 = Camera.main.WorldToScreenPoint(col.gameObject.transform.position);
					Vector3 strt3 = new Vector3(vector3.x, PlayerObj.fDeviceHeight - vector3.y, 0f);
					Vector3 end3;
					if (pMissionData.nNumOfMultipleCollection == 3)
					{
						switch (i)
						{
						case 0:
							end3 = new Vector3(IGT_GameView.rect_MultipleCollectionItemImg[3].x, IGT_GameView.rect_MultipleCollectionItemImg[3].y, 0f);
							break;
						case 1:
							end3 = new Vector3(IGT_GameView.rect_MultipleCollectionItemImg[4].x, IGT_GameView.rect_MultipleCollectionItemImg[4].y, 0f);
							break;
						default:
							end3 = new Vector3(IGT_GameView.rect_MultipleCollectionItemImg[5].x, IGT_GameView.rect_MultipleCollectionItemImg[5].y, 0f);
							break;
						}
					}
					else
					{
						end3 = new Vector3(IGT_GameView.rect_MultipleCollectionItemImg[i + 1].x, IGT_GameView.rect_MultipleCollectionItemImg[i + 1].y, 0f);
					}
					Vector3 centre3 = new Vector3(end3.x, strt3.y - IGT_UIcommonFunc.ScaleY(40f), -10f);
					float width2 = IGT_GameView.rect_MultipleCollectionItemImg[0].width;
					float centerWidth3 = width2 + width2 * 2.5f;
					float endWidth3 = width2 - width2 * 0.5f;
					float height2 = IGT_GameView.rect_MultipleCollectionItemImg[0].height;
					float centerHeight3 = height2 + height2 * 2.5f;
					float endHeight3 = height2 - height2 * 0.5f;
					pBezierAnimation.Add(new IGT_BezierAnimation(strt3, centre3, end3, 0f, 0.75f, width2, height2, centerWidth3, centerHeight3, endWidth3, endHeight3, IGT_GameView.pIgt_Textures.GetTexture(IGT_Constants.collectionItemsImg[pMissionData.nMultipleCollectionDatas[i, 0]])));
					break;
				}
			}
			for (int j = 0; j < PlayerObj.pObj.missionObj_PlacedDetails.Count; j++)
			{
				Vector3 vector4 = new Vector3(PlayerObj.pObj.missionObj_PlacedDetails.ElementAt(j).ObjPos.x, 0f, PlayerObj.pObj.missionObj_PlacedDetails.ElementAt(j).ObjPos.z);
				Vector3 vector5 = new Vector3(col.gameObject.transform.position.x, 0f, col.gameObject.transform.position.z);
				if (vector4 == vector5)
				{
					PlayerObj.pObj.missionObj_PlacedDetails.RemoveAt(j);
					break;
				}
			}
			playSound(7);
		}
		if (col.gameObject.tag == IGT_Constants.Tag_Letter)
		{
			if (lastCollidedCoinPosition == col.gameObject.transform.position)
			{
				return;
			}
			playSound(7);
			lastCollidedCoinPosition = col.gameObject.transform.position;
			UnityEngine.Object.Destroy(col.gameObject);
			if (nGameMode == 1 && pMissionData.nMissionType == 3)
			{
				bool flag2 = false;
				for (int num4 = pCharArray.Length - 1; num4 >= 0; num4--)
				{
					if (char.Parse(col.gameObject.name) == pCharArray[num4].character && !pCharArray[num4].isEnable)
					{
						pCharArray[num4].isEnable = true;
						Vector3 vector6 = Camera.main.WorldToScreenPoint(col.gameObject.transform.position);
						Vector3 strt4 = new Vector3(vector6.x, PlayerObj.fDeviceHeight - vector6.y, 0f);
						Vector3 end4 = new Vector3(pCharArray[num4].X, pCharArray[num4].Y, 0f);
						Vector3 centre4 = new Vector3(end4.x, strt4.y - IGT_UIcommonFunc.ScaleY(40f), -10f);
						float num5 = IGT_UIcommonFunc.ScaleX(40f);
						float centerWidth4 = num5 + num5 * 2.5f;
						float endWidth4 = num5 - num5 * 0.5f;
						float num6 = IGT_UIcommonFunc.ScaleY(40f);
						float centerHeight4 = num6 + num6 * 2.5f;
						float endHeight4 = num6 - num6 * 0.5f;
						pBezierAnimation.Add(new IGT_BezierAnimation(strt4, centre4, end4, 0f, 0.75f, num5, num6, centerWidth4, centerHeight4, endWidth4, endHeight4, pCharArray[num4].character.ToString(), Color.yellow, 50f));
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					Vector3 vector7 = Camera.main.WorldToScreenPoint(col.gameObject.transform.position);
					Vector3 strt5 = new Vector3(vector7.x, PlayerObj.fDeviceHeight - vector7.y, 0f);
					Vector3 end5 = new Vector3(IGT_UIcommonFunc.ScaleX(10f), Screen.height, 0f);
					Vector3 centre5 = new Vector3(end5.x, strt5.y - IGT_UIcommonFunc.ScaleY(200f), -10f);
					float num7 = IGT_UIcommonFunc.ScaleX(40f);
					float centerWidth5 = num7 + num7 * 2f;
					float endWidth5 = num7 * 0f;
					float num8 = IGT_UIcommonFunc.ScaleY(40f);
					float centerHeight5 = num8 + num8 * 2f;
					float endHeight5 = num8 * 0f;
					pBezierAnimation.Add(new IGT_BezierAnimation(strt5, centre5, end5, 0f, 0.75f, num7, num8, centerWidth5, centerHeight5, endWidth5, endHeight5, char.Parse(col.gameObject.name).ToString(), Color.yellow, 50f));
				}
			}
		}
		if (col.gameObject.tag == IGT_Constants.Tag_SplPowers)
		{
			if (lastCollidedCoinPosition == col.gameObject.transform.position)
			{
				return;
			}
			lastCollidedCoinPosition = col.gameObject.transform.position;
			switch (int.Parse(col.gameObject.name))
			{
			case 900:
				playSound(7, 0.8f);
				bSplPowersActivated = true;
				bMagnet = true;
				IGT_Constants.fMagnetPowerStartTime = Time.time;
				_Go_Magnet.SetActive(true);
				remove_SplPowerDisplayPos(900);
				IGT_GameView.pIgtDispProp.Add(new IGT_DisplayProperties(900, new Rect(0f, 0f, 0f, 0f), IGT_GameView.pIgt_Textures.GetTexture(IGT_Constants._Magnet), IGT_Constants.fMagnetPowerStartTime, IGT_Constants.fMagnetPowerTotTime));
				update_SplPowerDisplayPos();
				break;
			case 901:
			{
				playSound(7, 0.8f);
				Vector3 vector8 = Camera.main.WorldToScreenPoint(col.gameObject.transform.position);
				Vector3 strt6 = new Vector3(vector8.x, PlayerObj.fDeviceHeight - vector8.y, 0f);
				Vector3 end6 = new Vector3(IGT_GameView.rect_HeroHealthBar.x + IGT_GameView.rect_HeroHealthBar.width / 2f, IGT_GameView.rect_HeroHealthBar.y, 0f);
				Vector3 centre6 = new Vector3(end6.x, strt6.y - IGT_UIcommonFunc.ScaleY(40f), -10f);
				float num9 = IGT_UIcommonFunc.ScaleX(32f);
				float centerWidth6 = num9 + num9 * 2.5f;
				float endWidth6 = num9 - num9 * 0.5f;
				float num10 = IGT_UIcommonFunc.ScaleY(32f);
				float centerHeight6 = num10 + num10 * 2.5f;
				float endHeight6 = num10 - num10 * 0.5f;
				pBezierAnimation.Add(new IGT_BezierAnimation(strt6, centre6, end6, 0f, 0.75f, num9, num10, centerWidth6, centerHeight6, endWidth6, endHeight6, IGT_GameView.pIgt_Textures.GetTexture(IGT_Constants._MedPlus)));
				PlayerObj.nEnergyMeterPrev = PlayerObj.nEnergyMeter;
				PlayerObj.nEnergyMeterNext = PlayerObj.nEnergyMeter + IGT_Constants.Multiplier_MedPlus;
				PlayerObj.fTimeForEnergyMeterChanges = 0f;
				PlayerObj.bEnergyMeterChangesinBezier = true;
				IGT_GameView.bLowEnergy_Hero = true;
				IGT_GameView.fLowEnergy_Hero_StrtTime = Time.time;
				if (_AudioSource3.isPlaying && PlayerObj.nEnergyMeterNext > 0.05f)
				{
					_AudioSource3.Stop();
				}
				break;
			}
			case 902:
			{
				playSound(7, 0.8f);
				Vector3 vector8 = Camera.main.WorldToScreenPoint(col.gameObject.transform.position);
				Vector3 strt6 = new Vector3(vector8.x, PlayerObj.fDeviceHeight - vector8.y, 0f);
				Vector3 end6 = new Vector3(IGT_GameView.rect_HeroHealthBar.x + IGT_GameView.rect_HeroHealthBar.width / 2f, IGT_GameView.rect_HeroHealthBar.y, 0f);
				Vector3 centre6 = new Vector3(end6.x, strt6.y - IGT_UIcommonFunc.ScaleY(40f), -10f);
				float num9 = IGT_UIcommonFunc.ScaleX(32f);
				float centerWidth6 = num9 + num9 * 2.5f;
				float endWidth6 = num9 - num9 * 0.5f;
				float num10 = IGT_UIcommonFunc.ScaleY(32f);
				float centerHeight6 = num10 + num10 * 2.5f;
				float endHeight6 = num10 - num10 * 0.5f;
				pBezierAnimation.Add(new IGT_BezierAnimation(strt6, centre6, end6, 0f, 0.75f, num9, num10, centerWidth6, centerHeight6, endWidth6, endHeight6, IGT_GameView.pIgt_Textures.GetTexture(IGT_Constants._MedKit)));
				PlayerObj.nEnergyMeterPrev = PlayerObj.nEnergyMeter;
				PlayerObj.nEnergyMeterNext = PlayerObj.nEnergyMeter + IGT_Constants.Multiplier_MedKit;
				PlayerObj.fTimeForEnergyMeterChanges = 0f;
				PlayerObj.bEnergyMeterChangesinBezier = true;
				IGT_GameView.bLowEnergy_Hero = true;
				IGT_GameView.fLowEnergy_Hero_StrtTime = Time.time;
				if (_AudioSource3.isPlaying && PlayerObj.nEnergyMeterNext > 0.05f)
				{
					_AudioSource3.Stop();
				}
				break;
			}
			case 903:
				playSound(7, 0.8f);
				bSplPowersActivated = true;
				bCoin_2x = true;
				IGT_Constants.fCoin_2x_StartTime = Time.time;
				bCoin_3x = false;
				Debug.Log("coin 2 x");
				IGT_ObjPlacing.Change_CoinTexture(2);
				remove_SplPowerDisplayPos(903);
				IGT_GameView.pIgtDispProp.Add(new IGT_DisplayProperties(903, new Rect(0f, 0f, 0f, 0f), IGT_GameView.pIgt_Textures.GetTexture(IGT_Constants._coin2X), IGT_Constants.fCoin_2x_StartTime, IGT_Constants.fCoin_2x_TotTime));
				update_SplPowerDisplayPos();
				break;
			case 904:
				playSound(7, 0.8f);
				bSplPowersActivated = true;
				bCoin_3x = true;
				IGT_Constants.fCoin_3x_StartTime = Time.time;
				bCoin_2x = false;
				Debug.Log("coin 3 x");
				IGT_ObjPlacing.Change_CoinTexture(3);
				remove_SplPowerDisplayPos(904);
				IGT_GameView.pIgtDispProp.Add(new IGT_DisplayProperties(904, new Rect(0f, 0f, 0f, 0f), IGT_GameView.pIgt_Textures.GetTexture(IGT_Constants._coin3x), IGT_Constants.fCoin_3x_StartTime, IGT_Constants.fCoin_3x_TotTime));
				update_SplPowerDisplayPos();
				break;
			case 905:
				if (!(Time.time - IGT_Constants.useKeyLifeStartTime < IGT_Constants.useKeyTotLifeTime) && !bInvisibleMode && !bAIMode && !bAutoMaticModefrTesting)
				{
					playSound(1);
					playSound(26);
					GameOver_AnimationSelection(1);
					_Go_Smoke.SetActive(true);
					_Go_Smoke.transform.position = player.transform.position;
					_Go_Smoke.GetComponent<ParticleSystem>().Play();
					IGT_ObjPlacing.destroy_GlowObjBased_GivenPos(col.gameObject.transform.position);
				}
				break;
			case 906:
				if (!(Time.time - IGT_Constants.useKeyLifeStartTime < IGT_Constants.useKeyTotLifeTime) && !bInvisibleMode && !bAIMode && !bAutoMaticModefrTesting)
				{
					playSound(21);
					playSound(26);
					GameOver_AnimationSelection();
				}
				break;
			case 907:
				if (!bAIMode && !bAutoMaticModefrTesting)
				{
					playSound(7, 0.8f);
					bSplPowersActivated = true;
					bInvisibleMode = true;
					IGT_Constants.fInvisbleMode_StartTime = Time.time;
					bReduceAlpha = true;
					remove_SplPowerDisplayPos(907);
					IGT_GameView.pIgtDispProp.Add(new IGT_DisplayProperties(907, new Rect(0f, 0f, 0f, 0f), IGT_GameView.pIgt_Textures.GetTexture(IGT_Constants._Invisble), IGT_Constants.fInvisbleMode_StartTime, IGT_Constants.fInvisbleMode_TotTime));
					update_SplPowerDisplayPos();
					Vector3 vector8 = Camera.main.WorldToScreenPoint(col.gameObject.transform.position);
					Vector3 strt6 = new Vector3(vector8.x, PlayerObj.fDeviceHeight - vector8.y, 0f);
					Vector3 end6 = new Vector3(IGT_GameView.pIgtDispProp.ElementAt(IGT_GameView.pIgtDispProp.Count - 1).drawPos.x + IGT_GameView.pIgtDispProp.ElementAt(IGT_GameView.pIgtDispProp.Count - 1).drawPos.width / 2f, IGT_GameView.pIgtDispProp.ElementAt(IGT_GameView.pIgtDispProp.Count - 1).drawPos.y, 0f);
					Vector3 centre6 = new Vector3(end6.x, strt6.y - IGT_UIcommonFunc.ScaleY(40f), -10f);
					float num9 = IGT_UIcommonFunc.ScaleX(32f);
					float centerWidth6 = num9 + num9 * 2.5f;
					float endWidth6 = num9 - num9 * 0.5f;
					float num10 = IGT_UIcommonFunc.ScaleY(32f);
					float centerHeight6 = num10 + num10 * 2.5f;
					float endHeight6 = num10 - num10 * 0.5f;
					pBezierAnimation.Add(new IGT_BezierAnimation(strt6, centre6, end6, 0f, 0.75f, num9, num10, centerWidth6, centerHeight6, endWidth6, endHeight6, IGT_GameView.pIgt_Textures.GetTexture(IGT_Constants._Invisble)));
				}
				break;
			case 908:
				if (!(Time.time - IGT_Constants.useKeyLifeStartTime < IGT_Constants.useKeyTotLifeTime) && !bInvisibleMode && !bAIMode && !bAutoMaticModefrTesting)
				{
					playSound(7, 0.8f);
					bSplPowersActivated = true;
					bSpdInc = true;
					IGT_Constants.fSpdInc_StartTime = Time.time;
					fSpd_Inc_PrevSpd = PlayerObj.speed;
					PlayerObj.speed *= 1.25f;
					remove_SplPowerDisplayPos(908);
					IGT_GameView.pIgtDispProp.Add(new IGT_DisplayProperties(908, new Rect(0f, 0f, 0f, 0f), IGT_GameView.pIgt_Textures.GetTexture(IGT_Constants._SpdInc), IGT_Constants.fSpdInc_StartTime, IGT_Constants.fSpdInc_TotTime));
					update_SplPowerDisplayPos();
					Vector3 vector8 = Camera.main.WorldToScreenPoint(col.gameObject.transform.position);
					Vector3 strt6 = new Vector3(vector8.x, PlayerObj.fDeviceHeight - vector8.y, 0f);
					Vector3 end6 = new Vector3(IGT_GameView.pIgtDispProp.ElementAt(IGT_GameView.pIgtDispProp.Count - 1).drawPos.x + IGT_GameView.pIgtDispProp.ElementAt(IGT_GameView.pIgtDispProp.Count - 1).drawPos.width / 2f, IGT_GameView.pIgtDispProp.ElementAt(IGT_GameView.pIgtDispProp.Count - 1).drawPos.y, 0f);
					Vector3 centre6 = new Vector3(end6.x, strt6.y - IGT_UIcommonFunc.ScaleY(40f), -10f);
					float num9 = IGT_UIcommonFunc.ScaleX(32f);
					float centerWidth6 = num9 + num9 * 2.5f;
					float endWidth6 = num9 - num9 * 0.5f;
					float num10 = IGT_UIcommonFunc.ScaleY(32f);
					float centerHeight6 = num10 + num10 * 2.5f;
					float endHeight6 = num10 - num10 * 0.5f;
					pBezierAnimation.Add(new IGT_BezierAnimation(strt6, centre6, end6, 0f, 0.75f, num9, num10, centerWidth6, centerHeight6, endWidth6, endHeight6, IGT_GameView.pIgt_Textures.GetTexture(IGT_Constants._SpdInc)));
				}
				break;
			case 909:
				if (!(Time.time - IGT_Constants.useKeyLifeStartTime < IGT_Constants.useKeyTotLifeTime) && !bInvisibleMode && !bAIMode && !bAutoMaticModefrTesting)
				{
					playSound(7, 0.8f);
					bSplPowersActivated = true;
					bSpdDec = true;
					IGT_Constants.fSpdDec_StartTime = Time.time;
					fSpd_Dec_PrevSpd = PlayerObj.speed;
					PlayerObj.speed *= 0.6f;
					remove_SplPowerDisplayPos(909);
					IGT_GameView.pIgtDispProp.Add(new IGT_DisplayProperties(909, new Rect(0f, 0f, 0f, 0f), IGT_GameView.pIgt_Textures.GetTexture(IGT_Constants._SpdDec), IGT_Constants.fSpdDec_StartTime, IGT_Constants.fSpdDec_TotTime));
					update_SplPowerDisplayPos();
					Vector3 vector8 = Camera.main.WorldToScreenPoint(col.gameObject.transform.position);
					Vector3 strt6 = new Vector3(vector8.x, PlayerObj.fDeviceHeight - vector8.y, 0f);
					Vector3 end6 = new Vector3(IGT_GameView.pIgtDispProp.ElementAt(IGT_GameView.pIgtDispProp.Count - 1).drawPos.x + IGT_GameView.pIgtDispProp.ElementAt(IGT_GameView.pIgtDispProp.Count - 1).drawPos.width / 2f, IGT_GameView.pIgtDispProp.ElementAt(IGT_GameView.pIgtDispProp.Count - 1).drawPos.y, 0f);
					Vector3 centre6 = new Vector3(end6.x, strt6.y - IGT_UIcommonFunc.ScaleY(40f), -10f);
					float num9 = IGT_UIcommonFunc.ScaleX(32f);
					float centerWidth6 = num9 + num9 * 2.5f;
					float endWidth6 = num9 - num9 * 0.5f;
					float num10 = IGT_UIcommonFunc.ScaleY(32f);
					float centerHeight6 = num10 + num10 * 2.5f;
					float endHeight6 = num10 - num10 * 0.5f;
					pBezierAnimation.Add(new IGT_BezierAnimation(strt6, centre6, end6, 0f, 0.75f, num9, num10, centerWidth6, centerHeight6, endWidth6, endHeight6, IGT_GameView.pIgt_Textures.GetTexture(IGT_Constants._SpdDec)));
					if (isAIplayerAvailable)
					{
						IGT_AIPlayer.setDissconnectSpdCalc();
					}
				}
				break;
			}
			if (int.Parse(col.gameObject.name) != 906)
			{
				for (int k = 0; k < PlayerObj.pObj.splPowersObj_PlacedDetails.Count; k++)
				{
					Vector3 vector9 = new Vector3(PlayerObj.pObj.splPowersObj_PlacedDetails.ElementAt(k).ObjPos.x, 0f, PlayerObj.pObj.splPowersObj_PlacedDetails.ElementAt(k).ObjPos.z);
					Vector3 vector10 = new Vector3(col.gameObject.transform.position.x, 0f, col.gameObject.transform.position.z);
					if (vector9 == vector10)
					{
						PlayerObj.pObj.splPowersObj_PlacedDetails.RemoveAt(k);
						break;
					}
				}
				UnityEngine.Object.Destroy(col.gameObject);
			}
		}
		if (col.gameObject.tag == IGT_Constants.Tag_Glow)
		{
			UnityEngine.Object.Destroy(col.gameObject);
			IGT_ObjPlacing.destroy_GlowObjBased_GivenPos(col.gameObject.transform.position);
		}
	}

	private void BagMovementinCurveShape()
	{
		for (int i = 0; i < pCoinObj.Count; i++)
		{
			float x = (1f - pCoinAnim.ElementAt(i).fTime) * (1f - pCoinAnim.ElementAt(i).fTime) * pCoinAnim.ElementAt(i).StrtPos.x + 2f * (1f - pCoinAnim.ElementAt(i).fTime) * pCoinAnim.ElementAt(i).fTime * pCoinAnim.ElementAt(i).IntermediatePos.x + pCoinAnim.ElementAt(i).fTime * pCoinAnim.ElementAt(i).fTime * pCoinAnim.ElementAt(i).TarPos.x;
			float y = (1f - pCoinAnim.ElementAt(i).fTime) * (1f - pCoinAnim.ElementAt(i).fTime) * pCoinAnim.ElementAt(i).StrtPos.y + 2f * (1f - pCoinAnim.ElementAt(i).fTime) * pCoinAnim.ElementAt(i).fTime * pCoinAnim.ElementAt(i).IntermediatePos.y + pCoinAnim.ElementAt(i).fTime * pCoinAnim.ElementAt(i).fTime * pCoinAnim.ElementAt(i).TarPos.y;
			float z = (1f - pCoinAnim.ElementAt(i).fTime) * (1f - pCoinAnim.ElementAt(i).fTime) * pCoinAnim.ElementAt(i).StrtPos.z + 2f * (1f - pCoinAnim.ElementAt(i).fTime) * pCoinAnim.ElementAt(i).fTime * pCoinAnim.ElementAt(i).IntermediatePos.z + pCoinAnim.ElementAt(i).fTime * pCoinAnim.ElementAt(i).fTime * pCoinAnim.ElementAt(i).TarPos.z;
			pCoinObj.ElementAt(i).transform.position = new Vector3(x, y, z);
			pCoinAnim.ElementAt(i).fTime += Time.deltaTime * 1.5f;
			if (pCoinAnim.ElementAt(i).fTime > 1f)
			{
				pCoinAnim.ElementAt(i).fTime = 1f;
			}
		}
		for (int j = 0; j < pCoinAnim.Count; j++)
		{
			if (pCoinAnim.ElementAt(j).fTime >= 1f)
			{
				pCoinAnim.RemoveAt(j);
				pCoinObj.RemoveAt(j);
				NextAIplayerDataSelectionAftrLevelUp();
				pIGT_CaughtDet.ElementAt(nAIPlayerIndex).nAttempts++;
				save_CaugthDetails();
			}
		}
	}

	private void splPowersFunctionalities()
	{
		if (bMagnet)
		{
			if (Time.time - IGT_Constants.fMagnetPowerStartTime < IGT_Constants.fMagnetPowerTotTime)
			{
				List<IGT_ObjInfo> list;
				List<GameObject> list2;
				if (nGameMode == 1 && pMissionData.nMissionType == 0 && pMissionData.nCollectionInnerItemType == 0)
				{
					list = PlayerObj.pObj.missionObj_PlacedDetails;
					list2 = IGT_ObjPlacing.missionObjInstanceList;
				}
				else
				{
					list = PlayerObj.pObj.pCoinDatas;
					list2 = IGT_ObjPlacing.Coin_PlacingList;
				}
				for (int i = 0; i < list.Count; i++)
				{
					if (list.ElementAt(i).nPathId != PlayerObj.currentPathIndex)
					{
						continue;
					}
					float num = list.ElementAt(i).fDistFrmStrtPnt;
					if (PlayerObj.bTraverseReverse)
					{
						num = PlayerObj.pathLength[list.ElementAt(i).nPathId] - num;
					}
					if (!(num - PlayerObj.fDistFrmStrtPnt < IGT_Constants.fMagnetPowerRadius) || !(num - PlayerObj.fDistFrmStrtPnt > 0f))
					{
						continue;
					}
					for (int j = 0; j < list2.Count; j++)
					{
						if (!(list2[j] != null))
						{
							continue;
						}
						Vector3 vector = new Vector3(list2[j].transform.position.x, 0f, list2[j].transform.position.z);
						Vector3 vector2 = new Vector3(list.ElementAt(i).ObjPos.x, 0f, list.ElementAt(i).ObjPos.z);
						if (!(vector == vector2))
						{
							continue;
						}
						Vector3 position = list2[j].transform.position;
						Vector3 position2 = Hero_HandWristPos_Left.transform.position;
						pCoinAnim.Add(new IGT_CoinAnimation(position, position2, Hero_HandWristPos_Left.transform.position, 0f));
						if (bCoin_2x)
						{
							pCoinObj.Add(UnityEngine.Object.Instantiate(IGT_ObjPlacing.Anim_coin_2x, list2[j].transform.position, Quaternion.identity));
							if (nGameMode == 1 && pMissionData.nMissionType == 0 && pMissionData.nCollectionInnerItemType == 0)
							{
								nCollectedItemCount += 2;
							}
							else
							{
								IGT_Constants.nNoOfCollectedCoins += 2;
								nScore_Coin_Chase = 500 * (int)Mathf.Pow(nAIPlayerIndex + 1, 2f);
							}
						}
						else if (bCoin_3x)
						{
							pCoinObj.Add(UnityEngine.Object.Instantiate(IGT_ObjPlacing.Anim_coin_3x, list2[j].transform.position, Quaternion.identity));
							if (nGameMode == 1 && pMissionData.nMissionType == 0 && pMissionData.nCollectionInnerItemType == 0)
							{
								nCollectedItemCount += 3;
							}
							else
							{
								IGT_Constants.nNoOfCollectedCoins += 3;
								nScore_Coin_Chase = 750 * (int)Mathf.Pow(nAIPlayerIndex + 1, 2f);
							}
						}
						else
						{
							pCoinObj.Add(UnityEngine.Object.Instantiate(IGT_ObjPlacing.Anim_coin, list2[j].transform.position, Quaternion.identity));
							if (nGameMode == 1 && pMissionData.nMissionType == 0 && pMissionData.nCollectionInnerItemType == 0)
							{
								nCollectedItemCount++;
							}
							else
							{
								IGT_Constants.nNoOfCollectedCoins++;
								nScore_Coin_Chase = 250 * (int)Mathf.Pow(nAIPlayerIndex + 1, 2f);
							}
						}
						UnityEngine.Object.Destroy(list2[j]);
						list2.RemoveAt(j);
						break;
					}
				}
			}
			else
			{
				bMagnet = false;
				_Go_Magnet.SetActive(false);
				remove_SplPowerDisplayPos(900);
			}
			if (_Go_Magnet.activeSelf)
			{
				_Go_Magnet.transform.position = Hero_HandWristPos_Left.transform.position;
				_Go_Magnet.transform.rotation = Hero_HandWristPos_Left.transform.rotation;
			}
		}
		if (bCoin_2x && Time.time - IGT_Constants.fCoin_2x_StartTime > IGT_Constants.fCoin_2x_TotTime)
		{
			bCoin_2x = false;
			IGT_ObjPlacing.Change_CoinTexture(1);
			remove_SplPowerDisplayPos(903);
		}
		if (bCoin_3x && Time.time - IGT_Constants.fCoin_3x_StartTime > IGT_Constants.fCoin_3x_TotTime)
		{
			bCoin_3x = false;
			IGT_ObjPlacing.Change_CoinTexture(1);
			remove_SplPowerDisplayPos(904);
		}
		if (bInvisibleMode && Time.time - IGT_Constants.fInvisbleMode_StartTime > IGT_Constants.fInvisbleMode_TotTime)
		{
			bInvisibleMode = false;
			remove_SplPowerDisplayPos(907);
		}
		if (bSpdInc && Time.time - IGT_Constants.fSpdInc_StartTime > IGT_Constants.fSpdInc_TotTime)
		{
			bSpdInc = false;
			PlayerObj.speed = fSpd_Inc_PrevSpd;
			remove_SplPowerDisplayPos(908);
		}
		if (bSpdDec && Time.time - IGT_Constants.fSpdDec_StartTime > IGT_Constants.fSpdDec_TotTime)
		{
			bSpdDec = false;
			PlayerObj.speed = fSpd_Dec_PrevSpd;
			remove_SplPowerDisplayPos(909);
		}
		if (!bMagnet && !bCoin_2x && !bCoin_3x && !bInvisibleMode && !bSpdInc && !bSpdDec)
		{
			bSplPowersActivated = false;
		}
	}

	private void removeCoinAnimationDatas()
	{
		pCoinAnim.Clear();
		for (int i = 0; i < pCoinObj.Count; i++)
		{
			UnityEngine.Object.Destroy(pCoinObj.ElementAt(i));
		}
		pCoinObj.Clear();
	}

	private void CoinAnimation()
	{
		for (int i = 0; i < pCoinObj.Count; i++)
		{
			float x = (1f - pCoinAnim.ElementAt(i).fTime) * (1f - pCoinAnim.ElementAt(i).fTime) * pCoinAnim.ElementAt(i).StrtPos.x + 2f * (1f - pCoinAnim.ElementAt(i).fTime) * pCoinAnim.ElementAt(i).fTime * pCoinAnim.ElementAt(i).IntermediatePos.x + pCoinAnim.ElementAt(i).fTime * pCoinAnim.ElementAt(i).fTime * Hero_HandWristPos_Left.transform.position.x;
			float y = (1f - pCoinAnim.ElementAt(i).fTime) * (1f - pCoinAnim.ElementAt(i).fTime) * pCoinAnim.ElementAt(i).StrtPos.y + 2f * (1f - pCoinAnim.ElementAt(i).fTime) * pCoinAnim.ElementAt(i).fTime * pCoinAnim.ElementAt(i).IntermediatePos.y + pCoinAnim.ElementAt(i).fTime * pCoinAnim.ElementAt(i).fTime * Hero_HandWristPos_Left.transform.position.y;
			float z = (1f - pCoinAnim.ElementAt(i).fTime) * (1f - pCoinAnim.ElementAt(i).fTime) * pCoinAnim.ElementAt(i).StrtPos.z + 2f * (1f - pCoinAnim.ElementAt(i).fTime) * pCoinAnim.ElementAt(i).fTime * pCoinAnim.ElementAt(i).IntermediatePos.z + pCoinAnim.ElementAt(i).fTime * pCoinAnim.ElementAt(i).fTime * Hero_HandWristPos_Left.transform.position.z;
			pCoinObj.ElementAt(i).transform.position = new Vector3(x, y, z);
			pCoinObj.ElementAt(i).transform.localScale = PlayerObj.ScaleDownObject(pCoinObj.ElementAt(i).transform.localScale, new Vector3(IGT_Constants.HeroMinimumScale, IGT_Constants.HeroMinimumScale, IGT_Constants.HeroMinimumScale), 2.5f);
			pCoinAnim.ElementAt(i).fTime += Time.deltaTime * 6f;
			if (pCoinAnim.ElementAt(i).fTime > 1f)
			{
				pCoinAnim.ElementAt(i).fTime = 1f;
			}
		}
		for (int j = 0; j < pCoinAnim.Count; j++)
		{
			if (!(pCoinAnim.ElementAt(j).fTime >= 1f))
			{
				continue;
			}
			pCoinAnim.RemoveAt(j);
			UnityEngine.Object.Destroy(pCoinObj.ElementAt(j));
			pCoinObj.RemoveAt(j);
			playSound(nCoinSoundIdx, 1f, true);
			if (IGT_Constants.nNoOfCollectedCoins % 3 == 0)
			{
				nCoinSoundIdx++;
				if (nCoinSoundIdx >= _AudioClips_Coin.Length - 1)
				{
					nCoinSoundIdx = 0;
				}
			}
		}
	}

	public void GameOverScreen_CoinAnimation(float fAnimObjSpd)
	{
		bool flag = false;
		for (int i = 0; i < pCoinObj.Count; i++)
		{
			pCoinAnim.ElementAt(i).fTime = IGT_EaseFunction.Linear_ease(fGameoverAnimTime, 0f, 1f, 2 + i);
			if (pCoinAnim.ElementAt(i).fTime > 1f)
			{
				pCoinAnim.ElementAt(i).fTime = 1f;
				pCoinObj.ElementAt(i).transform.localScale = new Vector3(0f, 0f, 0f);
			}
			float x = (1f - pCoinAnim.ElementAt(i).fTime) * (1f - pCoinAnim.ElementAt(i).fTime) * pCoinAnim.ElementAt(i).StrtPos.x + 2f * (1f - pCoinAnim.ElementAt(i).fTime) * pCoinAnim.ElementAt(i).fTime * pCoinAnim.ElementAt(i).IntermediatePos.x + pCoinAnim.ElementAt(i).fTime * pCoinAnim.ElementAt(i).fTime * pCoinAnim.ElementAt(i).TarPos.x;
			float y = (1f - pCoinAnim.ElementAt(i).fTime) * (1f - pCoinAnim.ElementAt(i).fTime) * pCoinAnim.ElementAt(i).StrtPos.y + 2f * (1f - pCoinAnim.ElementAt(i).fTime) * pCoinAnim.ElementAt(i).fTime * pCoinAnim.ElementAt(i).IntermediatePos.y + pCoinAnim.ElementAt(i).fTime * pCoinAnim.ElementAt(i).fTime * pCoinAnim.ElementAt(i).TarPos.y;
			float z = (1f - pCoinAnim.ElementAt(i).fTime) * (1f - pCoinAnim.ElementAt(i).fTime) * pCoinAnim.ElementAt(i).StrtPos.z + 2f * (1f - pCoinAnim.ElementAt(i).fTime) * pCoinAnim.ElementAt(i).fTime * pCoinAnim.ElementAt(i).IntermediatePos.z + pCoinAnim.ElementAt(i).fTime * pCoinAnim.ElementAt(i).fTime * pCoinAnim.ElementAt(i).TarPos.z;
			pCoinObj.ElementAt(i).transform.position = new Vector3(x, y, z);
			pCoinObj.ElementAt(i).transform.localScale = PlayerObj.ScaleDownObject(pCoinObj.ElementAt(i).transform.localScale, new Vector3(IGT_Constants.HeroMinimumScale, IGT_Constants.HeroMinimumScale, IGT_Constants.HeroMinimumScale), 1.5f);
			if (!((float)(2 + i) < fGameoverAnimTime))
			{
				flag = true;
			}
		}
		fGameoverAnimTime += Time.deltaTime * fAnimObjSpd;
		if (flag)
		{
			return;
		}
		for (int j = 0; j < pCoinAnim.Count; j++)
		{
			if ((float)(2 + j) < fGameoverAnimTime)
			{
				pCoinAnim.RemoveAt(j);
				UnityEngine.Object.Destroy(pCoinObj.ElementAt(j));
				pCoinObj.RemoveAt(j);
			}
		}
	}

	public void BezierMovement_UiElements()
	{
		for (int i = 0; i < pBezierAnimation.Count; i++)
		{
			float x = (1f - pBezierAnimation.ElementAt(i).fTime) * (1f - pBezierAnimation.ElementAt(i).fTime) * pBezierAnimation.ElementAt(i).StrtPos.x + 2f * (1f - pBezierAnimation.ElementAt(i).fTime) * pBezierAnimation.ElementAt(i).fTime * pBezierAnimation.ElementAt(i).IntermediatePos.x + pBezierAnimation.ElementAt(i).fTime * pBezierAnimation.ElementAt(i).fTime * pBezierAnimation.ElementAt(i).TarPos.x;
			float y = (1f - pBezierAnimation.ElementAt(i).fTime) * (1f - pBezierAnimation.ElementAt(i).fTime) * pBezierAnimation.ElementAt(i).StrtPos.y + 2f * (1f - pBezierAnimation.ElementAt(i).fTime) * pBezierAnimation.ElementAt(i).fTime * pBezierAnimation.ElementAt(i).IntermediatePos.y + pBezierAnimation.ElementAt(i).fTime * pBezierAnimation.ElementAt(i).fTime * pBezierAnimation.ElementAt(i).TarPos.y;
			float width = (1f - pBezierAnimation.ElementAt(i).fTime) * (1f - pBezierAnimation.ElementAt(i).fTime) * pBezierAnimation.ElementAt(i).fstrtWidth + 2f * (1f - pBezierAnimation.ElementAt(i).fTime) * pBezierAnimation.ElementAt(i).fTime * pBezierAnimation.ElementAt(i).fcenterWidth + pBezierAnimation.ElementAt(i).fTime * pBezierAnimation.ElementAt(i).fTime * pBezierAnimation.ElementAt(i).fendWidth;
			float height = (1f - pBezierAnimation.ElementAt(i).fTime) * (1f - pBezierAnimation.ElementAt(i).fTime) * pBezierAnimation.ElementAt(i).fstrtHeight + 2f * (1f - pBezierAnimation.ElementAt(i).fTime) * pBezierAnimation.ElementAt(i).fTime * pBezierAnimation.ElementAt(i).fcenterHeight + pBezierAnimation.ElementAt(i).fTime * pBezierAnimation.ElementAt(i).fTime * pBezierAnimation.ElementAt(i).fendHeight;
			if (pBezierAnimation.ElementAt(i).pTexture != null)
			{
				GUI.DrawTexture(new Rect(x, y, width, height), pBezierAnimation.ElementAt(i).pTexture);
			}
			else
			{
				IGT_GameView.pIgt_Lable.DrawLable(new Rect(x, y, width, height), pBezierAnimation.ElementAt(i).textToDisplay, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(pBezierAnimation.ElementAt(i).fFontSize), TextAnchor.MiddleCenter, false, pBezierAnimation.ElementAt(i).textColor, 2f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
			}
			pBezierAnimation.ElementAt(i).fTime += Time.deltaTime * pBezierAnimation.ElementAt(i).fAnimSpd;
			if (pBezierAnimation.ElementAt(i).fTime >= 1f)
			{
				pBezierAnimation.RemoveAt(i);
			}
		}
	}

	public void BezierMovementGroupAnimation()
	{
		bool flag = false;
		for (int i = 0; i < pBezierAnimation_Group.Count; i++)
		{
			pBezierAnimation_Group.ElementAt(i).fTime = IGT_EaseFunction.Linear_ease(fBezierGroupAnimTime, 0f, 1f, 2 + i);
			if (pBezierAnimation_Group.ElementAt(i).fTime > 1f)
			{
				pBezierAnimation_Group.ElementAt(i).fTime = 1f;
			}
			float x = (1f - pBezierAnimation_Group.ElementAt(i).fTime) * (1f - pBezierAnimation_Group.ElementAt(i).fTime) * pBezierAnimation_Group.ElementAt(i).StrtPos.x + 2f * (1f - pBezierAnimation_Group.ElementAt(i).fTime) * pBezierAnimation_Group.ElementAt(i).fTime * pBezierAnimation_Group.ElementAt(i).IntermediatePos.x + pBezierAnimation_Group.ElementAt(i).fTime * pBezierAnimation_Group.ElementAt(i).fTime * pBezierAnimation_Group.ElementAt(i).TarPos.x;
			float y = (1f - pBezierAnimation_Group.ElementAt(i).fTime) * (1f - pBezierAnimation_Group.ElementAt(i).fTime) * pBezierAnimation_Group.ElementAt(i).StrtPos.y + 2f * (1f - pBezierAnimation_Group.ElementAt(i).fTime) * pBezierAnimation_Group.ElementAt(i).fTime * pBezierAnimation_Group.ElementAt(i).IntermediatePos.y + pBezierAnimation_Group.ElementAt(i).fTime * pBezierAnimation_Group.ElementAt(i).fTime * pBezierAnimation_Group.ElementAt(i).TarPos.y;
			float width = (1f - pBezierAnimation_Group.ElementAt(i).fTime) * (1f - pBezierAnimation_Group.ElementAt(i).fTime) * pBezierAnimation_Group.ElementAt(i).fstrtWidth + 2f * (1f - pBezierAnimation_Group.ElementAt(i).fTime) * pBezierAnimation_Group.ElementAt(i).fTime * pBezierAnimation_Group.ElementAt(i).fcenterWidth + pBezierAnimation_Group.ElementAt(i).fTime * pBezierAnimation_Group.ElementAt(i).fTime * pBezierAnimation_Group.ElementAt(i).fendWidth;
			float height = (1f - pBezierAnimation_Group.ElementAt(i).fTime) * (1f - pBezierAnimation_Group.ElementAt(i).fTime) * pBezierAnimation_Group.ElementAt(i).fstrtHeight + 2f * (1f - pBezierAnimation_Group.ElementAt(i).fTime) * pBezierAnimation_Group.ElementAt(i).fTime * pBezierAnimation_Group.ElementAt(i).fcenterHeight + pBezierAnimation_Group.ElementAt(i).fTime * pBezierAnimation_Group.ElementAt(i).fTime * pBezierAnimation_Group.ElementAt(i).fendHeight;
			if (pBezierAnimation_Group.ElementAt(i).pTexture != null)
			{
				GUI.DrawTexture(new Rect(x, y, width, height), pBezierAnimation_Group.ElementAt(i).pTexture);
			}
			if (!((float)(2 + i) < fBezierGroupAnimTime))
			{
				flag = true;
			}
		}
		fBezierGroupAnimTime += Time.deltaTime * pBezierAnimation_Group.ElementAt(0).fAnimSpd;
		if (flag)
		{
			return;
		}
		for (int j = 0; j < pBezierAnimation_Group.Count; j++)
		{
			if ((float)(2 + j) <= fBezierGroupAnimTime)
			{
				pBezierAnimation_Group.RemoveAt(j);
			}
		}
	}

	private void CountDownAnimation()
	{
		if (bCanResume)
		{
			double num = Mathf.FloorToInt(Time.time - IGT_Constants.fResumeCountDownStartTime);
			IGT_GameView.nCountDownNum = (double)IGT_Constants.fResumeCountDownTotTime - num;
			if (num == (double)IGT_Constants.fResumeCountDownTotTime)
			{
				bPauseButton = false;
				bCanResume = false;
				IGT_AnimStatesCntrler.HeroAnimator.StopPlayback();
				if (isAIplayerAvailable)
				{
					IGT_AIPlayer.pAIPlayerAnimController.AIHeroAnimator.StopPlayback();
				}
				if (isSurpriseAiAvailable)
				{
					IGT_SurpriseAIplayer.surpriseAIAnimator.StopPlayback();
				}
				if (nGameMode == 1 && nMissionID < nTutorialLevelCount - 1)
				{
					IGT_GameView.setScreenMode(21);
				}
				else
				{
					IGT_GameView.setScreenMode(1);
				}
				if (bReduceAlpha)
				{
					IGT_Constants.useKeyLifeStartTime += Time.time - IGT_Constants.fPauseScreenStrtTime;
				}
				if (nGameMode == 1)
				{
					dMissionStrtTime += Time.time - IGT_Constants.fPauseScreenStrtTime;
					IGT_Constants.fWF_OriginalCharPlacedTime += Time.time - IGT_Constants.fPauseScreenStrtTime;
					if (nMissionID == 13 && IGT_GameView.bBringBackDemoTapToContinueAlert)
					{
						IGT_GameView.fBringBack_Demo__TaptoContinue_StartTime = Time.time;
						IGT_GameView.bBringBackDemoTapToContinueAlert = true;
						IGT_GameView.freezeGame(true);
					}
				}
				else
				{
					IGT_Constants.splPowers_Chase_LastPlacedTime += Time.time - IGT_Constants.fPauseScreenStrtTime;
					dChaseModeStrtTime += Time.time - IGT_Constants.fPauseScreenStrtTime;
				}
				if (bSplPowersActivated)
				{
					if (bMagnet)
					{
						IGT_Constants.fMagnetPowerStartTime += Time.time - IGT_Constants.fPauseScreenStrtTime;
					}
					if (bCoin_2x)
					{
						IGT_Constants.fCoin_2x_StartTime += Time.time - IGT_Constants.fPauseScreenStrtTime;
					}
					if (bCoin_3x)
					{
						IGT_Constants.fCoin_3x_StartTime += Time.time - IGT_Constants.fPauseScreenStrtTime;
					}
					if (bInvisibleMode)
					{
						IGT_Constants.fInvisbleMode_StartTime += Time.time - IGT_Constants.fPauseScreenStrtTime;
					}
					if (bSpdInc)
					{
						IGT_Constants.fSpdInc_StartTime += Time.time - IGT_Constants.fPauseScreenStrtTime;
					}
					if (bSpdDec)
					{
						IGT_Constants.fSpdDec_StartTime += Time.time - IGT_Constants.fPauseScreenStrtTime;
					}
					if (IGT_GameView.pIgtDispProp.Count > 0)
					{
						for (int i = 0; i < IGT_GameView.pIgtDispProp.Count; i++)
						{
							switch (IGT_GameView.pIgtDispProp.ElementAt(i).ID)
							{
							case 900:
								IGT_GameView.pIgtDispProp.ElementAt(i).fStrtTime = IGT_Constants.fMagnetPowerStartTime;
								break;
							case 903:
								IGT_GameView.pIgtDispProp.ElementAt(i).fStrtTime = IGT_Constants.fCoin_2x_StartTime;
								break;
							case 904:
								IGT_GameView.pIgtDispProp.ElementAt(i).fStrtTime = IGT_Constants.fCoin_3x_StartTime;
								break;
							case 907:
								IGT_GameView.pIgtDispProp.ElementAt(i).fStrtTime = IGT_Constants.fInvisbleMode_StartTime;
								break;
							case 908:
								IGT_GameView.pIgtDispProp.ElementAt(i).fStrtTime = IGT_Constants.fSpdInc_StartTime;
								break;
							case 909:
								IGT_GameView.pIgtDispProp.ElementAt(i).fStrtTime = IGT_Constants.fSpdDec_StartTime;
								break;
							}
						}
					}
				}
				isPausedSounds(false);
				IGT_GameView.audioclipstartTime = IGT_Constants.fPauseScreenStrtTime;
			}
		}
		if (bUseKey)
		{
			double num2 = Mathf.FloorToInt(Time.time - IGT_Constants.fUseKeyCountDownStrtTime);
			IGT_GameView.nCountDownNum = (double)IGT_Constants.fUseKeyCountDownTotTime - num2;
			if (num2 == (double)IGT_Constants.fUseKeyCountDownTotTime)
			{
				IGT_AnimStatesCntrler.nGameOverAnimFinshd = 0;
				bGameOver = false;
				IGT_AnimStatesCntrler.HeroAnimator.Play("IdleToRun", 0, 0.35f);
				IGT_AnimStatesCntrler.nHeroAnimState = 1;
				if (isAIplayerAvailable)
				{
					IGT_AIPlayer.pAIPlayerAnimController.AIHeroAnimator.Play("Idle", 0);
					IGT_AIPlayer.pAIPlayerAnimController.nHeroAnimState = 1;
					IGT_AIPlayer.pAIPlayerAnimController.AIHeroAnimator.Play("Running", 0);
				}
				NxtPathSelectionWhileUsing_UseKey();
				IGT_Constants.useKeyLifeStartTime = Time.time;
				bReduceAlpha = true;
				IGT_GameView.audioclipstartTime = IGT_Constants.fPauseScreenStrtTime + IGT_GameView.audioclipstartTime;
				bUseKey = false;
				nUserInput = 0;
				bPauseButton = false;
				bCanResume = false;
				IGT_GameView.pAnim_MissionCompleted_star1.resetAllValues();
				if (nGameMode == 1 && nMissionID < nTutorialLevelCount - 1)
				{
					IGT_GameView.setScreenMode(21);
				}
				else
				{
					IGT_GameView.setScreenMode(1);
				}
				if (Hero_shadow_projector != null)
				{
					Hero_shadow_projector.SetActive(false);
				}
				if (Hero_shadow_projector1 != null)
				{
					Hero_shadow_projector1.SetActive(true);
				}
				if (bHasPicked_BBitem && BB_CollectionItem != null)
				{
					BB_CollectionItem.SetActive(true);
				}
				if (PlayerObj.nEnergyMeter <= 0f)
				{
					PlayerObj.nEnergyMeter += 0.2f;
				}
				if (nGameMode == 1)
				{
					dMissionStrtTime += (double)(Time.time - IGT_Constants.fSurviveScreenStrtTime) + num2;
					IGT_Constants.fWF_OriginalCharPlacedTime += Time.time - IGT_Constants.fSurviveScreenStrtTime + (float)num2;
				}
				else
				{
					dChaseModeStrtTime += (double)(Time.time - IGT_Constants.fSurviveScreenStrtTime) + num2;
				}
			}
		}
		if (Hero_shadow_projector != null && Hero_shadow_projector.activeSelf)
		{
			Hero_shadow_projector.transform.position = new Vector3(Hero_headPath.transform.position.x, Hero_headPath.transform.position.y, Hero_headPath.transform.position.z);
		}
		if (!bFpsBased3dModelUsage_FirstTime || IGT_GameView.nScreenMode != 0)
		{
			return;
		}
		if (Time.time - fTimeForFpsBased3dModelUsage > 1f)
		{
			bFpsBased3dModelUsage_FirstTime = false;
			Application.targetFrameRate = (nTargetFrameRate = 30);
			if (nDispFrames_3dModelUsage < 20)
			{
				IGT_GameView.start_sorryAlert();
				post_Analytics_Performance(nDispFrames_3dModelUsage, 4);
			}
			else if (nDispFrames_3dModelUsage < 30)
			{
				b30FpsMode = true;
				n3dModelUsageMode = 2;
				fLowFpsMode_StrtTime = Time.time;
				FpsBased3dModelUsage(nDispFrames_3dModelUsage);
			}
		}
		nDispFrames_3dModelUsage++;
	}

	public void FpsBased3dModelUsage_Calc()
	{
		bool flag = false;
		float num = nTotFps / nTotFrameSamples;
		float num2 = num * 60f;
		if (n3dModelUsageMode == 0)
		{
			flag = true;
			if (num2 > 58.5f)
			{
				n3dModelUsageMode = 0;
			}
			else if (num2 < 50f)
			{
				n3dModelUsageMode = 2;
				fLowFpsMode_StrtTime = Time.time;
			}
			else
			{
				n3dModelUsageMode = 1;
				fMediumFpsMode_StrtTime = Time.time;
			}
		}
		else if (n3dModelUsageMode == 1)
		{
			if (num2 < 58f)
			{
				n3dModelUsageMode = 2;
				fLowFpsMode_StrtTime = Time.time;
				flag = true;
			}
			else if (num2 > 59f && Time.time - fMediumFpsMode_StrtTime > 600f)
			{
				n3dModelUsageMode = 0;
				flag = true;
			}
		}
		else if (n3dModelUsageMode == 2 && num2 > 59f && Time.time - fLowFpsMode_StrtTime > 600f)
		{
			n3dModelUsageMode = 1;
			fMediumFpsMode_StrtTime = Time.time;
			flag = true;
		}
		if (flag)
		{
			FpsBased3dModelUsage((int)num2);
		}
		nTotFps = (nTotFrameSamples = 0f);
	}

	public void FpsBased3dModelUsage(int framerate)
	{
		Application.targetFrameRate = (nTargetFrameRate = 30);
		if (n3dModelUsageMode != n3dModelUsageMode_Prev)
		{
			changeCharacter(nHeroIndex);
			ChangeTerrain();
			int gmode = n3dModelUsageMode;
			if (b30FpsMode)
			{
				gmode = 3;
			}
			post_Analytics_Performance(framerate, gmode);
			fogSelection(false);
			if (n3dModelUsageMode == 0)
			{
				Camera.main.farClipPlane = 22f;
				QualitySettings.SetQualityLevel(0, false);
			}
			else if (n3dModelUsageMode == 1)
			{
				Camera.main.farClipPlane = 19f;
				QualitySettings.SetQualityLevel(1, false);
			}
			else
			{
				Camera.main.farClipPlane = 17f;
				QualitySettings.SetQualityLevel(2, false);
			}
		}
		n3dModelUsageMode_Prev = n3dModelUsageMode;
	}

	private void ChangeTerrain(bool bLoadHigh = false)
	{
		if (Building_High == null)
		{
			Building_High = GameObject.Find("Building");
		}
		if (Building_Low == null)
		{
			Building_Low = GameObject.Find("Building_low");
		}
		if (n3dModelUsageMode == 0 || bLoadHigh)
		{
			Building_High.SetActive(true);
			Building_Low.SetActive(false);
		}
		else
		{
			Building_High.SetActive(false);
			Building_Low.SetActive(true);
		}
	}

	public void ReducingPlayerAlphaWhileUsingUseKey(bool bShowOriginal = false)
	{
		if ((Time.time - IGT_Constants.useKeyLifeStartTime < IGT_Constants.useKeyTotLifeTime || bInvisibleMode) && bReduceAlpha && !bShowOriginal)
		{
			if (!bInvisibleMode && Time.time - IGT_Constants.useKeyLifeStartTime > IGT_Constants.useKeyTotLifeTime - 1f)
			{
				float num = (Time.time - IGT_Constants.useKeyLifeStartTime) * 1000f;
				if (num > 4900f)
				{
					pHero_MeshRenderer.material = pHeroTransperent_Material;
				}
				else if (num > 4750f)
				{
					pHero_MeshRenderer.material = pHeroMaterials[nHeroIndex];
				}
				else if (num > 4550f)
				{
					pHero_MeshRenderer.material = pHeroTransperent_Material;
				}
				else if (num > 4350f)
				{
					pHero_MeshRenderer.material = pHeroMaterials[nHeroIndex];
				}
				else if (num > 4100f)
				{
					pHero_MeshRenderer.material = pHeroTransperent_Material;
				}
				else
				{
					pHero_MeshRenderer.material = pHeroMaterials[nHeroIndex];
				}
			}
			else if (bInvisibleMode && Time.time - IGT_Constants.fInvisbleMode_StartTime > IGT_Constants.fInvisbleMode_TotTime - 1f)
			{
				float num2 = (IGT_Constants.fInvisbleMode_TotTime - (Time.time - IGT_Constants.fInvisbleMode_StartTime)) * 1000f;
				if (num2 < 100f)
				{
					pHero_MeshRenderer.material = pHeroTransperent_Material;
				}
				else if (num2 < 250f)
				{
					pHero_MeshRenderer.material = pHeroMaterials[nHeroIndex];
				}
				else if (num2 < 400f)
				{
					pHero_MeshRenderer.material = pHeroTransperent_Material;
				}
				else if (num2 < 650f)
				{
					pHero_MeshRenderer.material = pHeroMaterials[nHeroIndex];
				}
				else if (num2 < 800f)
				{
					pHero_MeshRenderer.material = pHeroTransperent_Material;
				}
				else
				{
					pHero_MeshRenderer.material = pHeroMaterials[nHeroIndex];
				}
			}
			else
			{
				pHero_MeshRenderer.material = pHeroTransperent_Material;
				Color color = pHero_MeshRenderer.material.color;
				color.a = 0.4f;
				pHero_MeshRenderer.material.color = color;
			}
		}
		else
		{
			Color color2 = pHero_MeshRenderer.material.color;
			color2.a = 1f;
			pHero_MeshRenderer.material.color = color2;
			pHero_MeshRenderer.material = pHeroMaterials[nHeroIndex];
			if (!bShowOriginal)
			{
				playSound(35, 0.8f);
			}
			bReduceAlpha = false;
		}
	}

	private void DisplayDirectionOfEnemy()
	{
		Vector3 vector = new Vector3(player.transform.position.x, 0f, player.transform.position.z);
		Vector3 vector2 = new Vector3(IGT_AIPlayer.AI_Player.transform.position.x, 0f, IGT_AIPlayer.AI_Player.transform.position.z);
		float num = 180f - IGT_Math.AngleBtwPoints(vector, vector2, player.transform.forward);
		IGT_GameView.rect_DirMapEnemy.x = IGT_UIcommonFunc.ScaleX(25f * Mathf.Sin(num * 0.017444445f));
		IGT_GameView.rect_DirMapEnemy.y = IGT_UIcommonFunc.ScaleY(25f * Mathf.Cos(num * 0.017444445f));
		IGT_GameView.fDirMapDist = Mathf.Round(Vector3.Distance(vector, vector2) * 10f) / 10f;
	}

	private void display_BringBackHereMap()
	{
		Vector3 vector = new Vector3(player.transform.position.x, 0f, player.transform.position.z);
		Vector3 vector2 = (bHasPicked_BBitem ? new Vector3(Heroine.transform.position.x, 0f, Heroine.transform.position.z) : new Vector3(BB_CollectionItem.transform.position.x, 0f, BB_CollectionItem.transform.position.z));
		fBB_DirMapAngle = 180f - IGT_Math.AngleBtwPoints(vector, vector2, player.transform.forward);
		IGT_GameView.rect_BB_DirMapEnemy.x = IGT_UIcommonFunc.ScaleX(25f * Mathf.Sin(fBB_DirMapAngle * 0.017444445f));
		IGT_GameView.rect_BB_DirMapEnemy.y = IGT_UIcommonFunc.ScaleY(25f * Mathf.Cos(fBB_DirMapAngle * 0.017444445f));
		IGT_GameView.fDirMapDist = IGT_Constants.GAME_TO_REAL_WORLD_DIST_MULTIPLIER * Mathf.Round(Vector3.Distance(vector, vector2) * 10f) / 10f;
	}

	private bool HeroCanThrow(float heroDist)
	{
		bool flag = false;
		int num = -1;
		float num2 = 1000f;
		float num3 = offset_Laneoffset;
		PlayerObj.objDetInCurPath(PlayerObj.currentPathIndex);
		num = (PlayerObj.bTraverseReverse ? PlayerObj.findNxtObjIdBasedDistinRevPath(PlayerObj.pathLength[PlayerObj.currentPathIndex] - heroDist) : PlayerObj.findNxtObjIdBasedDistinFrwdPath(heroDist));
		if (num != -1)
		{
			if ((PlayerObj.pObj.obj[num].objType != 6 && PlayerObj.pObj.obj[num].objType != 9) || (PlayerObj.pObj.obj[num].objType == 9 && PlayerObj.pObj.obj[num].objID == 906) || PlayerObj.pObj.obj[num].objID == 905)
			{
				num3 = PlayerObj.pObj.obj[num].fOffset;
				num2 = PlayerObj.pObj.obj[num].fDistFrmStrtPnt;
				if (PlayerObj.bTraverseReverse)
				{
					num2 = PlayerObj.pathLength[PlayerObj.currentPathIndex] - num2;
					num3 = 0f - PlayerObj.pObj.obj[num].fOffset;
				}
			}
			else
			{
				flag = true;
			}
		}
		else
		{
			flag = true;
		}
		if (!flag && PlayerObj.pObj.obj[num].objPlaceType == 1)
		{
			flag = flag || PlayerObj.currentPathIndex != PlayerObj.pObj.obj[num].nPathId || !(offset_Laneoffset >= num3 - PlayerObj.pObj.obj[num].fLength / 2f) || !(offset_Laneoffset <= num3 + PlayerObj.pObj.obj[num].fLength / 2f) || ((!(heroDist <= num2 + PlayerObj.speed * 1f) || !(heroDist >= num2 - PlayerObj.speed * 1f)) ? true : false);
		}
		else if (!flag && PlayerObj.pObj.obj[num].objPlaceType == 0)
		{
			flag = flag || !(num2 + PlayerObj.pObj.obj[num].fWidth / 2f >= heroDist) || PlayerObj.currentPathIndex != PlayerObj.pObj.obj[num].nPathId || !(offset_Laneoffset >= num3 - PlayerObj.pObj.obj[num].fLength / 2f) || !(offset_Laneoffset <= num3 + PlayerObj.pObj.obj[num].fLength / 2f) || ((!(heroDist <= num2 + (PlayerObj.speed + PlayerObj.pObj.obj[num].fWidth / 2f)) || !(heroDist >= num2 - (PlayerObj.speed + PlayerObj.pObj.obj[num].fWidth / 2f))) ? true : false);
		}
		if (flag && num != -1 && PlayerObj.pObj.obj[num].objType == 3)
		{
			flag = HeroCanThrow(num2);
		}
		return flag;
	}

	public float findOffsetforPurseandAIinLevelup()
	{
		float result = 0f;
		if (IGT_AIPlayer.AI_offset_Laneoffset == centerOffset)
		{
			result = ((!(offset_Laneoffset < (0f - PlayerObj.fTotalOffsetDeviation) / 2f)) ? (0f - PlayerObj.fTotalOffsetDeviation) : PlayerObj.fTotalOffsetDeviation);
		}
		else if (IGT_AIPlayer.AI_offset_Laneoffset < centerOffset)
		{
			result = ((!(offset_Laneoffset > (0f - PlayerObj.fTotalOffsetDeviation) / 2f)) ? centerOffset : PlayerObj.fTotalOffsetDeviation);
		}
		else if (IGT_AIPlayer.AI_offset_Laneoffset > centerOffset)
		{
			result = ((!(offset_Laneoffset < centerOffset)) ? (0f - PlayerObj.fTotalOffsetDeviation) : centerOffset);
		}
		return result;
	}

	private void AndroidMobileButtonEvents()
	{
		if (!Input.GetKeyUp(KeyCode.Escape))
		{
			return;
		}
		if (IGT_GameView.bNoInternetAlert || IGT_GameView.bUpgradeAlert)
		{
			IGT_GameView.NoInternetAlertOkButtonEvents();
			return;
		}
		if (IGT_GameView.bPostFBAlert)
		{
			IGT_GameView.pAnim_postalert.resetAllValues();
			IGT_GameView.pAnim_postalert.setIsReverse(true);
			IGT_GameView.feedshareFailed();
			int num = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_feedDeclinedCount, 1);
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_feedDeclinedCount, ++num);
			return;
		}
		if (IGT_GameView.bAchievementAlert)
		{
			if (IGT_GameView.pAnim_GAchievement.isAnimFinished())
			{
				IGT_GameView.pAnim_GAchievement.resetAllValues();
				IGT_GameView.pAnim_GAchievement.setIsReverse(true);
			}
			return;
		}
		if (IGT_GameView.bHS_asklife)
		{
			if (IGT_GameView.pAnim_MailBox.isAnimFinished())
			{
				IGT_GameView.pAnim_MailBox.resetAllValues();
				IGT_GameView.pAnim_MailBox.setIsReverse(true);
				IGT_GameView.mailBoxCloseBtnEvent();
			}
			return;
		}
		if (IGT_GameView.bNoMoreLiveAlert)
		{
			IGT_GameView.exitAlertCloseButEvents();
			return;
		}
		if (IGT_GameView.bInappAlert)
		{
			IGT_GameView.Inapp_Alert_Window_Close_ButtonEvents();
			return;
		}
		switch (IGT_GameView.nScreenMode)
		{
		case 1:
			IGT_GameView.pauseButtonEvents();
			return;
		case 7:
			IGT_GameView.setScreenMode(9);
			return;
		case 8:
			return;
		case 2:
			if (IGT_GameView.bAbortAlert)
			{
				IGT_GameView.abortAlertCloseButEvents();
			}
			else
			{
				IGT_GameView.ResumeButtonEvents();
			}
			return;
		case 5:
			if (IGT_GameView.pRateit.bShowRateItAlert)
			{
				IGT_GameView.pRateit.setCloseButEvents(true);
			}
			else
			{
				IGT_GameView.homeScreenButtonEvents();
			}
			return;
		case 3:
			IGT_GameView.surviveCloseButEvents();
			return;
		case 0:
			if (IGT_GameView.bSorry)
			{
				IGT_GameView.stop_sorryAlert();
			}
			else if (IGT_GameView.bIsShowGPluseLoginAlert)
			{
				IGT_GameView.bIsShowGPluseLoginAlert = false;
			}
			else if (IGT_GameView.bShowNickName)
			{
				IGT_GameView.bShowNickName = false;
			}
			else if (IGT_GameView.bHS_FBbtnClick)
			{
				IGT_GameView.bHS_FBbtnClick = false;
				IGT_GameView.bFBbtnClick = false;
			}
			else if (IGT_GameView.bHS_GooglebtnClick)
			{
				IGT_GameView.bHS_GooglebtnClick = false;
				IGT_GameView.bGoogleLbbtnClick = false;
			}
			else if (!IGT_GameView.bLBwronganim)
			{
				if (!IGT_GameView.bHS_FBbtnClick)
				{
					IGT_GameView.pAnim_HS_LeaderBoard.resetAllValues();
					IGT_GameView.pAnim_HS_LeaderBoard.setIsReverse(true);
					IGT_GameView.bLBwronganim = true;
				}
			}
			else if (IGT_GameView.bHS_settings)
			{
				if (IGT_GameView.bShowNickName)
				{
					IGT_GameView.bShowNickName = false;
				}
				else if (IGT_GameView.pAnim_HS_menuBG.isAnimFinished())
				{
					IGT_GameView.settingCloseButEvents();
				}
			}
			else if (IGT_GameView.bHS_mailbox || IGT_GameView.bHS_sendlife || IGT_GameView.bHS_allshare)
			{
				if (IGT_GameView.pAnim_MailBox.isAnimFinished())
				{
					IGT_GameView.pAnim_MailBox.resetAllValues();
					IGT_GameView.pAnim_MailBox.setIsReverse(true);
					IGT_GameView.mailBoxCloseBtnEvent();
				}
			}
			else if (IGT_GameView.bHS_moregames)
			{
				IGT_GameView.pMoregame.OnClose();
				IGT_GameView.bHS_moregames = false;
			}
			else if (!IGT_GameView.bExitAlert)
			{
				IGT_GameView.bExitAlert = true;
				IGT_GameView.pAnim_Alert.resetAllValues();
			}
			else
			{
				IGT_GameView.exitAlertCloseButEvents();
			}
			return;
		case 10:
			if (IGT_GameView.pRateit.bShowRateItAlert)
			{
				IGT_GameView.pRateit.setCloseButEvents(true);
			}
			else if (IGT_GameView.bChaseLockedAlert)
			{
				IGT_GameView.bChaseLockedAlert = false;
			}
			else
			{
				IGT_GameView.setScreenMode(9);
			}
			return;
		case 9:
			IGT_GameView.mapBackButtonEvents();
			return;
		case 12:
			if (IGT_GameView.bFBbtnClick)
			{
				IGT_GameView.bFBbtnClick = false;
				IGT_GameView.bHS_FBbtnClick = false;
			}
			else if (IGT_GameView.bGoogleLbbtnClick)
			{
				IGT_GameView.bHS_GooglebtnClick = false;
				IGT_GameView.bGoogleLbbtnClick = false;
			}
			else if (!IGT_GameView.bLBwronganim)
			{
				if (!IGT_GameView.bFBbtnClick && !IGT_GameView.bGoogleLbbtnClick)
				{
					IGT_GameView.pAnim_menu_LeaderBoard.resetAllValues();
					IGT_GameView.pAnim_menu_LeaderBoard.setIsReverse(true);
					IGT_GameView.bLBwronganim = true;
				}
			}
			else if (IGT_GameView.bHS_settings)
			{
				if (IGT_GameView.bShowNickName)
				{
					IGT_GameView.bShowNickName = false;
				}
				else if (IGT_GameView.pAnim_HS_menuBG.isAnimFinished())
				{
					IGT_GameView.settingCloseButEvents();
				}
			}
			else if (IGT_GameView.bHS_allshare)
			{
				if (IGT_GameView.pAnim_MailBox.isAnimFinished())
				{
					IGT_GameView.pAnim_MailBox.resetAllValues();
					IGT_GameView.pAnim_MailBox.setIsReverse(true);
					IGT_GameView.mailBoxCloseBtnEvent();
				}
			}
			else if (IGT_GameView.bHS_moregames)
			{
				IGT_GameView.pMoregame.OnClose();
				IGT_GameView.bHS_moregames = false;
			}
			else if (IGT_GameView.bHS_about)
			{
				if (IGT_GameView.pAnim_MailBox.isAnimFinished())
				{
					IGT_GameView.pAnim_MailBox.resetAllValues();
					IGT_GameView.pAnim_MailBox.setIsReverse(true);
				}
			}
			else
			{
				IGT_GameView.menubackbtnevent();
			}
			return;
		case 6:
			if (IGT_GameView.bHS_moregames)
			{
				IGT_GameView.pMoregame.OnClose();
				IGT_GameView.bHS_moregames = false;
			}
			else if (IGT_GameView.nPurchaseType == 3 && IGT_GameView.pMoregame.webViewObject != null && IGT_GameView.pMoregame.webViewObject.GetVisibility() && IGT_GameView.bHS_like)
			{
				IGT_GameView.pMoregame.OnClose();
				IGT_GameView.bHS_like = false;
			}
			else
			{
				IGT_GameView.setScreenMode(IGT_GameView.nPrevScreenMode);
			}
			return;
		case 21:
			IGT_GameView.pauseButtonEvents();
			return;
		}
		if (IGT_GameView.nScreenMode != 20 && IGT_GameView.nPrevScreenMode != 20)
		{
			if (IGT_GameView.nPrevScreenMode == IGT_GameView.nScreenMode)
			{
				IGT_GameView.setScreenMode(IGT_GameView.nBeforePrevScreenMode);
			}
			else
			{
				IGT_GameView.setScreenMode(IGT_GameView.nPrevScreenMode);
			}
			pBezierAnimation_Group.Clear();
		}
	}

	private void Update()
	{
		startFrame = Time.time;
		if (!bRobbingSceneFinished && !bPauseButton)
		{
			if (Endless_Bag != null && !bAIplayerStart)
			{
				if (!bBagInHeroinHand)
				{
					if (Heroine_Wrist == null)
					{
						Heroine_Wrist = GameObject.Find(IGT_Constants.Heroine_String + IGT_Constants.Path_Hero_Wrist);
					}
					Endless_Bag.transform.position = Heroine_Wrist.transform.position;
					Endless_Bag.transform.rotation = Quaternion.Euler(new Vector3(Heroine.transform.rotation.eulerAngles.x, Heroine.transform.rotation.eulerAngles.y + 80f, Heroine.transform.rotation.eulerAngles.z));
				}
				else
				{
					Endless_Bag.transform.position = IGT_AIPlayer.AI_Wrist.transform.position;
					Endless_Bag.transform.rotation = IGT_AIPlayer.AI_Player.transform.rotation;
				}
			}
			if (bMissionIntro && bStrtButton && !bAIplayerStart)
			{
				Vector3 prevPt = new Vector3(-0.46f, 0.04f, -71.232f);
				Vector3 vector = new Vector3(0.346f, 0.04f, -71.007f);
				Vector3 vector2 = new Vector3(PlayerObj.pointPos[25, 0, 0], PlayerObj.pointPos[25, 0, 1], PlayerObj.pointPos[25, 0, 2]);
				Vector3 nextPt = new Vector3(PlayerObj.pointPos[25, 1, 0], PlayerObj.pointPos[25, 1, 1], PlayerObj.pointPos[25, 1, 2]);
				if (Vector3.Distance(vector, vector2) * 0.75f < fdist_robbingscene)
				{
					if (IGT_AIPlayer.pAIPlayerAnimController.nHeroAnimState != 29)
					{
						IGT_AIPlayer.pAIPlayerAnimController.nHeroAnimState = 29;
						playSound(5, 0.1f);
					}
				}
				else
				{
					if (IGT_AIPlayer.AI_Player == null)
					{
						IGT_AIPlayer.init_AiplayerComponents();
					}
					IGT_AIPlayer.AI_Player.transform.position = PlayerObj.CurvePoints(prevPt, vector, vector2, nextPt, fdist_robbingscene);
					fdist_robbingscene += 0.65f * Time.deltaTime;
					IGT_AIPlayer.pAIPlayerAnimController.nHeroAnimState = 18;
				}
				IGT_AIPlayer.AI_Player.transform.LookAt(new Vector3(0.88f, 0.042f, -68.22f));
			}
			else if (bMissionIntro && bStrtButton && bAIplayerStart && IGT_AIPlayer.AI_PlayerObj.fDistFrmStrtPnt > IGT_Constants.INITIAL_DISTGAP_BTW_HERO_ENEMY - 2f)
			{
				bCamStartFollow = true;
				if (fTime_robbScene >= 1f)
				{
					bRobbingSceneFinished = true;
					IGT_AnimStatesCntrler.HeroAnimator.speed = IGT_Constants.nAnimation_Default_Spd;
					if (nGameMode == 0 || (nGameMode == 1 && nMissionID > 2))
					{
						IGT_GameView.setScreenMode(1);
					}
					if (!IGT_AnimStatesCntrler.HeroAnimator.GetCurrentAnimatorStateInfo(0).IsName("Running"))
					{
						IGT_AnimStatesCntrler.HeroAnimator.Play("Running", 0);
					}
				}
				else
				{
					if (!IGT_AnimStatesCntrler.HeroAnimator.GetCurrentAnimatorStateInfo(0).IsName("LeftLaneShift") && fTime_robbScene < 0.05f)
					{
						IGT_AnimStatesCntrler.HeroAnimator.Play("LeftLaneShift", 0);
					}
					IGT_AnimStatesCntrler.nHeroAnimState = 1;
					player.transform.position = IGT_Animator.Bezier_3D(new Vector3(1.1f, 0.042f, -69.751f), new Vector3(0.583f, 0f, -69.652f), new Vector3(PlayerObj.pointPos[25, 1, 0], PlayerObj.pointPos[25, 1, 1], PlayerObj.pointPos[25, 1, 2]), fTime_robbScene, 1.75f);
					player.transform.LookAt(new Vector3(PlayerObj.pointPos[25, 2, 0], PlayerObj.pointPos[25, 2, 1], PlayerObj.pointPos[25, 2, 2]));
					fTime_robbScene += Time.deltaTime * 1.05f;
				}
			}
		}
		else if (bStrtButton && !bPauseButton && bRobbingSceneFinished && bMissionIntro)
		{
			if (Input.GetKeyUp(KeyCode.KeypadEnter) && bTestingTeamPurpose)
			{
				IGT_AnimStatesCntrler.nHeroAnimState = 16;
				IGT_AnimStatesCntrler.HeroAnimator.Play("GameOverHit", 1);
				nAIPlayerActionState = 2;
				IGT_AIPlayer.AI_PlayerObj.speed *= 0.85f;
				for (int num = PlayerObj.pObj.splPowersObj_PlacedDetails.Count - 1; num >= 0; num--)
				{
					if (PlayerObj.pObj.splPowersObj_PlacedDetails[num].nPathId == PlayerObj.currentPathIndex && (PlayerObj.pObj.splPowersObj_PlacedDetails[num].objID == 905 || PlayerObj.pObj.splPowersObj_PlacedDetails[num].objID == 906))
					{
						PlayerObj.pObj.splPowersObj_PlacedDetails.RemoveAt(num);
					}
				}
				IGT_ObjPlacing.splPowersobjDestruction();
				IGT_ObjPlacing.splPowersPlacing(ref PlayerObj.pObj.splPowersObj_PlacedDetails);
				Debug.Log("==testing level up : ");
			}
			if (bGameOver && !bNextAIPlayerGonnaPickPurse)
			{
				if (IGT_GameView.nScreenMode == 1)
				{
					IGT_GameView.setScreenMode(20);
				}
				if (isAIplayerAvailable && bLevelUp)
				{
					if (IGT_GameView.nScreenMode != 4 && IGT_GameView.nScreenMode != 5 && !bLevelUpButtonPressed && IGT_AnimStatesCntrler.nGameOverAnimFinshd == 1 && (Vector3.Distance(player.transform.position, IGT_AIPlayer.AI_Player.transform.position) < IGT_Constants.fLevelUpOuterRadius || Vector3.Dot(AIplayerToHeroStrtVecInGameLevelUpScreen, AIplayerToHeroCurVecInGameLevelUpScreen) <= 0.35f || Time.time - IGT_Constants.fLevelUpStartTime > IGT_Constants.fLevelUpAnimTotTime))
					{
						IGT_AIPlayer.pAIPlayerAnimController.nHeroAnimState = 16;
						IGT_AnimStatesCntrler.nHeroAnimState = 0;
						if (nGameMode == 0)
						{
							playSound(3, 0.35f);
							if (nAIPlayerIndex == 9)
							{
								IGT_GameView.setScreenMode(5);
								if (isConnectedInternet() && pIGT_CaughtDet.ElementAt(9).nCaughtCount == 1)
								{
									IGT_GameView.pRateit.ForceShowRateitAlert();
								}
								post_Analytics_Screen_Button_Datas("EndlessRunFinished", string.Empty, false);
								HighScore_calc();
							}
							else
							{
								IGT_GameView.setScreenMode(4);
							}
							if (_AudioSource3.isPlaying)
							{
								_AudioSource3.Stop();
							}
							pIGT_CaughtDet.ElementAt(nAIPlayerIndex).nCaughtCount++;
							save_CaugthDetails();
							IGT_Achivements.completeAchivements(4, nAIPlayerIndex + 1);
							if (IGT_GameView.pRateit.bShowRateItAlert)
							{
								IGT_GameView.bAchievementAlert = false;
							}
						}
						else if (nGameMode == 1 && (pMissionData.nMissionType == 2 || nMissionID < nTutorialLevelCount) && IGT_GameView.nScreenMode != 10 && IGT_GameView.nScreenMode != 9)
						{
							if (IGT_AnimStatesCntrler.HeroAnimator.GetCurrentAnimatorStateInfo(0).IsName("MissionSuccess") && IGT_AnimStatesCntrler.nGameOverAnimFinshd == 1)
							{
								IGT_GameView.setScreenMode(10);
								IGT_GameView.bChaseLockedAlert = false;
								if (_AudioSource3.isPlaying)
								{
									_AudioSource3.Stop();
								}
								PlayerObj.DestroyAllTypesofObjects();
								ScoreCalc_Missions();
							}
							else if (IGT_AnimStatesCntrler.nHeroAnimState != 24)
							{
								IGT_AnimStatesCntrler.nHeroAnimState = 24;
								IGT_AnimStatesCntrler.HeroAnimator.Play("MissionSuccess", 0);
								IGT_AnimStatesCntrler.nGameOverAnimFinshd = -1;
								playSound(3, 0.35f);
							}
						}
						else if (nGameMode == 1 && pMissionData.nMissionType == 1 && bMissionManualEnding)
						{
							bLevelFailed = true;
							bLevelUp = false;
							PlayerObj.DestroyAllTypesofObjects();
						}
					}
					else if (!bLevelUpButtonPressed && IGT_GameView.nScreenMode != 4 && IGT_GameView.nScreenMode != 5 && Vector3.Dot(AIplayerToHeroStrtVecInGameLevelUpScreen, AIplayerToHeroCurVecInGameLevelUpScreen) > 0.15f)
					{
						OffsetFixing(0.5f);
						Movement();
						AIplayerToHeroCurVecInGameLevelUpScreen = new Vector3(IGT_AIPlayer.AI_Player.transform.position.x - player.transform.position.x, IGT_AIPlayer.AI_Player.transform.position.y - player.transform.position.y, IGT_AIPlayer.AI_Player.transform.position.z - player.transform.position.z);
						AIplayerToHeroCurVecInGameLevelUpScreen.Normalize();
					}
					else if (bLevelUpButtonPressed && IGT_AnimStatesCntrler.nGameOverAnimFinshd == 6)
					{
						Vector3[] array = new Vector3[6];
						Vector3 position = IGT_AIPlayer.AI_Wrist.transform.position;
						int side = 0;
						int[] array2 = PlayerObj.findPathBasedInput(PlayerObj.currentPathIndex, PlayerObj.bTraverseReverse, side);
						if (array2[0] == -1)
						{
							side = 1;
							array2 = PlayerObj.findPathBasedInput(PlayerObj.currentPathIndex, PlayerObj.bTraverseReverse, side);
							if (array2[0] == -1)
							{
								side = 2;
							}
						}
						Vector3 centre;
						Vector3 end;
						if (!PlayerObj.bMovingFinishdInPath)
						{
							int num2;
							if (!PlayerObj.bTraverseReverse)
							{
								num2 = PlayerObj.currentPoint;
								if (PlayerObj.currentPoint == PlayerObj.pointCount[PlayerObj.currentPathIndex] - 1)
								{
									num2 = PlayerObj.currentPoint - 1;
								}
							}
							else
							{
								num2 = PlayerObj.currentPoint - 1;
								if (num2 - 1 <= 0)
								{
									num2 = 1;
								}
							}
							array = PlayerObj.TarPosFindngfrKickThrowObjBasedDist(PlayerObj.currentPathIndex, num2, 1f, PlayerObj.bTraverseReverse, side);
							centre = new Vector3(array[0].x, array[0].y + 0.85f, array[0].z);
							array = PlayerObj.TarPosFindngfrKickThrowObjBasedDist(PlayerObj.currentPathIndex, num2, 2.5f, PlayerObj.bTraverseReverse, side);
							end = new Vector3(array[0].x, array[0].y + 0.1f, array[0].z);
						}
						else
						{
							side = 0;
							array2 = PlayerObj.findPathBasedInput(PlayerObj.prevPathIndex, PlayerObj.bTravRevFrPrevPath, side);
							if (array2[0] == -1)
							{
								side = 1;
								array2 = PlayerObj.findPathBasedInput(PlayerObj.prevPathIndex, PlayerObj.bTravRevFrPrevPath, side);
								if (array2[0] == -1)
								{
									side = 2;
								}
							}
							int num2 = (PlayerObj.bTravRevFrPrevPath ? 1 : (PlayerObj.pointCount[PlayerObj.prevPathIndex] - 2));
							array = PlayerObj.TarPosFindngfrKickThrowObjBasedDist(PlayerObj.prevPathIndex, num2, 2f, PlayerObj.bTravRevFrPrevPath, side);
							centre = new Vector3(array[0].x, array[0].y + 0.85f, array[0].z);
							array = PlayerObj.TarPosFindngfrKickThrowObjBasedDist(PlayerObj.prevPathIndex, num2, 3.5f, PlayerObj.bTravRevFrPrevPath, side);
							end = new Vector3(array[0].x, array[0].y + 0.1f, array[0].z);
						}
						fEndlessBag_offset_inPicking = findOffsetforPurseandAIinLevelup();
						Vector3 rhs = new Vector3(array[0].x - array[2].x, array[0].y - array[2].y, array[0].z - array[2].z);
						rhs.Normalize();
						end += Vector3.Cross(Vector3.up, rhs) * fEndlessBag_offset_inPicking;
						pCoinAnim.Add(new IGT_CoinAnimation(position, centre, end, 0f));
						pCoinObj.Add(Endless_Bag);
						IGT_AIPlayer.pAIPlayerAnimController.nHeroAnimState = 16;
						IGT_AnimStatesCntrler.nGameOverAnimFinshd = 0;
						bBagMovingInCurve = true;
					}
					else if (bLevelUpButtonPressed && bBagMovingInCurve && pCoinObj.Count > 0)
					{
						BagMovementinCurveShape();
					}
				}
				else if (nGameMode == 1 && bMissionCompleted)
				{
					if (IGT_AnimStatesCntrler.nGameOverAnimFinshd == 1 && IGT_GameView.nScreenMode != 10 && IGT_GameView.nScreenMode != 9)
					{
						IGT_GameView.setScreenMode(10);
						IGT_AnimStatesCntrler.HeroAnimator.Play("Idle", 0);
						IGT_AnimStatesCntrler.nHeroAnimState = 0;
						if (_AudioSource3.isPlaying)
						{
							_AudioSource3.Stop();
						}
						PlayerObj.DestroyAllTypesofObjects();
						ScoreCalc_Missions();
					}
				}
				else
				{
					if (playerCollisionStates == 2 && player.transform.localScale != new Vector3(IGT_Constants.HeroMinimumScale, IGT_Constants.HeroMinimumScale, IGT_Constants.HeroMinimumScale))
					{
						player.transform.localScale = PlayerObj.ScaleDownObject(player.transform.localScale, new Vector3(IGT_Constants.HeroMinimumScale, IGT_Constants.HeroMinimumScale, IGT_Constants.HeroMinimumScale), 0.5f);
						ScaleDownObjectHeight();
					}
					if (!bLevelUp && IGT_AnimStatesCntrler.nGameOverAnimFinshd == 1 && !IGT_GameView.bOutOfEnergyTextAlert && !bUseKey && IGT_GameView.nScreenMode != 3 && IGT_GameView.nScreenMode != 16)
					{
						if (nGameMode == 1 && (nMissionID < 5 || nMissionID == 13))
						{
							IGT_GameView.mission_ButtonEvents(nMissionID);
							playSound(7);
						}
						else if (!bMissionManualEnding)
						{
							IGT_GameView.setScreenMode(3);
							IGT_Constants.useKeyLifeStartTime = Time.time;
							IGT_GameView.fSaveMeTextFillingCurTime = 0f;
							IGT_Constants.fSurviveScreenStrtTime = Time.time;
						}
						else
						{
							IGT_GameView.surviveCloseButEvents();
						}
						removeCoinAnimationDatas();
					}
					else if (!bUseKey && IGT_GameView.nScreenMode == 3 && Time.time - IGT_Constants.useKeyLifeStartTime > IGT_Constants.useKeyTotLifeTime && IGT_AnimStatesCntrler.nGameOverAnimFinshd == 1)
					{
						IGT_GameView.surviveCloseButEvents();
					}
					else if (bLevelFailed && !bUseKey)
					{
						IGT_GameView.setScreenMode(5);
						HighScore_calc();
						bLevelFailed = false;
						canDecrease_Life();
						if (nGameMode == 1)
						{
							if (pMissionData.nLevelStarCount == -1)
							{
								pMissionData.nRetryCount++;
								Save_LevelData(nMissionID, 1, pMissionData);
							}
							if (IGT_GameView.pIGT_ScrollData_MC_FbGlobal != null && IGT_GameView.pIGT_ScrollData_MC_FbGlobal.Count == 0)
							{
								IGT_GameView.CallGetScoreFunction_Action(1);
							}
						}
						else
						{
							IGT_GameView.nGameoverScrollType = UnityEngine.Random.Range(0, Enum.GetNames(typeof(GameoverScrollType)).Length);
							if (isConnectedInternet())
							{
								for (int i = 0; i < pAIPlayerData.Count; i++)
								{
									if (i < nAIPlayerIndex && pIGT_CaughtDet.ElementAt(i).nCaughtCount == 1)
									{
										IGT_GameView.pRateit.ForceShowRateitAlert();
										break;
									}
								}
							}
							if (IGT_GameView.pMissionLevelComplitedInfo != null)
							{
								IGT_GameView.pMissionLevelComplitedInfo(1, 0, nHigh_Score_Chase, 0);
							}
							post_Analytics_EndlessRun(nAIPlayerIndex);
						}
						if (IGT_GameView.pRateit.bShowRateItAlert)
						{
							IGT_GameView.bAchievementAlert = false;
						}
						PlayerObj.DestroyAllTypesofObjects();
						if (_AudioSource3.isPlaying)
						{
							_AudioSource3.Stop();
						}
						if (_AudioSource2.isPlaying)
						{
							_AudioSource2.Stop();
						}
					}
				}
			}
			else if (!bGameOver && !bNextAIPlayerGonnaPickPurse)
			{
				if (isAIplayerAvailable && !bSpdInc && !bSpdDec)
				{
					if (nGameMode == 1 && nMissionID < nTutorialLevelCount)
					{
						DemoLevels_LevelUp_Checking();
					}
					else
					{
						Checking_LevelUp();
					}
				}
				if (!bAIMode)
				{
					if (nAIPlayerActionState != 2)
					{
						TchObj.TouchProcessingArea();
						if (userInputQueue.Count > 0)
						{
							if (userInputQueue.Peek() != nUserInput)
							{
								nUserInput = userInputQueue.Dequeue();
							}
							else if (userInputQueue.Peek() != 1 && userInputQueue.Peek() != 2)
							{
								userInputQueue.Dequeue();
							}
						}
					}
					OffsetFixing(0.2f);
					Movement();
					if (PlayerObj.fDistFrmStrtPnt >= PlayerObj.pathLength[PlayerObj.currentPathIndex] - 2f)
					{
						bTurning = true;
					}
					surprisePlayerActionInit();
					switch (nUserInput)
					{
					case 3:
						if (IGT_AnimStatesCntrler.nHeroAnimState != 2 && !bLeftLaneShift && !bRightLaneShift)
						{
							IGT_AnimStatesCntrler.nHeroAnimState = 2;
							playSound(9);
						}
						break;
					case 4:
						if (!IGT_AnimStatesCntrler.HeroAnimator.GetCurrentAnimatorStateInfo(0).IsName("Pick") && IGT_AnimStatesCntrler.nHeroAnimState != 3 && !bLeftLaneShift && !bRightLaneShift)
						{
							IGT_AnimStatesCntrler.nHeroAnimState = 3;
							playSound(8, 0.9f);
						}
						break;
					case 5:
						if (IGT_GameView.nScreenMode == 1 || IGT_GameView.nScreenMode == 21)
						{
							if (bKickWithinAnimRange && IGT_AnimStatesCntrler.nHeroAnimState != 2 && !IGT_AnimStatesCntrler.HeroAnimator.GetCurrentAnimatorStateInfo(0).IsName("Leftkick") && !IGT_AnimStatesCntrler.HeroAnimator.GetCurrentAnimatorStateInfo(0).IsName("Kick"))
							{
								bKickAnimCanEnable = true;
							}
							else if (bThrwObjPicked && IGT_AnimStatesCntrler.nHeroAnimState != 2 && !IGT_AnimStatesCntrler.HeroAnimator.GetCurrentAnimatorStateInfo(0).IsName("Throw"))
							{
								IGT_AnimStatesCntrler.nHeroAnimState = 13;
								playSound(12);
							}
						}
						nUserInput = 0;
						break;
					}
					if (!bKickWithinAnimRange)
					{
						PlayerObj.pObj.kickObjId = -1;
						IGT_Objects.kickObj_InstanceID = -1;
					}
					if (bPickObjSelected && (double)Time.time - dPickobjSelectdTime > 2.0 && !IGT_AnimStatesCntrler.HeroAnimator.GetCurrentAnimatorStateInfo(0).IsName("Pick"))
					{
						IGT_AnimStatesCntrler.nHeroAnimState = 1;
						bPickObjSelected = false;
					}
					playerCollisionStates = PlayerObj.pObj.CheckCollisions(PlayerObj.fDistFrmStrtPnt, player.transform.position, offset_Laneoffset, PlayerObj.bTraverseReverse, PlayerObj.pathLength[PlayerObj.currentPathIndex], PlayerObj.speed);
					switch (playerCollisionStates)
					{
					case 10:
						if (!(Time.time - IGT_Constants.useKeyLifeStartTime < IGT_Constants.useKeyTotLifeTime) && !bInvisibleMode)
						{
							GameOver_AnimationSelection();
						}
						break;
					case 2:
						if (!(Time.time - IGT_Constants.useKeyLifeStartTime < IGT_Constants.useKeyTotLifeTime) && !bInvisibleMode && !bAutoMaticModefrTesting)
						{
							IGT_AnimStatesCntrler.nHeroAnimState = 8;
							playSound(28, 0.3f);
							bGameOver = true;
							bLevelUp = false;
							gameoverHideItems();
						}
						break;
					case 6:
						if (!PlayerObj.pObj.ObjListInCurPathOfHero[PlayerObj.pObj.PickObjId].bplyrCrsd)
						{
							pickingThrowObjects();
						}
						break;
					case 4:
						if (!PlayerObj.pObj.ObjListInCurPathOfHero[PlayerObj.pObj.kickObjId].bplyrCrsd && IGT_AnimStatesCntrler.nHeroAnimState != 2)
						{
							bKickWithinAnimRange = true;
							kickObjects();
						}
						break;
					}
					if (nGameMode == 1 && nMissionID < 3)
					{
						PlayerObj.pObj.CheckCollisions_Tutorial(PlayerObj.fDistFrmStrtPnt, player.transform.position, offset_Laneoffset, PlayerObj.bTraverseReverse, PlayerObj.pathLength[PlayerObj.currentPathIndex], PlayerObj.speed, PlayerObj.currentPathIndex, bThrwObjPicked, nMissionID);
					}
				}
				else
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
					Movement();
					switch (AIMode_CollisonCheck(PlayerObj.fDistFrmStrtPnt + 1.2f, player.transform.position, offset_Laneoffset, PlayerObj.bTraverseReverse, PlayerObj.pathLength[PlayerObj.currentPathIndex], PlayerObj.speed, PlayerObj.currentPathIndex))
					{
					case 0:
						IGT_AnimStatesCntrler.nHeroAnimState = 2;
						break;
					case 1:
						IGT_AnimStatesCntrler.nHeroAnimState = 3;
						break;
					case 2:
						IGT_AnimStatesCntrler.nHeroAnimState = 2;
						break;
					}
				}
				if (bReduceAlpha)
				{
					ReducingPlayerAlphaWhileUsingUseKey();
				}
				if (isAIplayerAvailable)
				{
					DisplayDirectionOfEnemy();
					EnergyMeterCalcHero();
					if (nAIPlayerActionState == 0 && ((!bSpdDec && !bSpdInc && nGameMode == 0) || (nGameMode == 1 && (pMissionData.nMissionType == 2 || pMissionData.nMissionType == 1))))
					{
						SpeedCalc();
					}
				}
				AnimationSpeedCalc();
				ScoreCalculation();
				if (nGameMode == 0)
				{
					GlobalSpdMultiplierCalc();
				}
				if (!bPickdObjCanThrow && bThrwObjPicked && IGT_Objects.PickedObj_InstanceID != -1 && IGT_ObjPlacing.dynObjList.ElementAt(IGT_Objects.PickedObj_InstanceID).name == "700")
				{
					IGT_ObjPlacing.dynObjList.ElementAt(IGT_Objects.PickedObj_InstanceID).transform.position = Hero_HandWristPos.transform.position;
					IGT_ObjPlacing.dynObjList.ElementAt(IGT_Objects.PickedObj_InstanceID).transform.rotation = player.transform.rotation;
					IGT_ObjPlacing.dynObjList.ElementAt(IGT_Objects.PickedObj_InstanceID).transform.localScale = new Vector3(40f, 40f, 40f);
					if (nGameMode == 1 && nMissionID < 3 && PlayerObj.currentPathIndex == IGT_AIPlayer.AI_PlayerObj.currentPathIndex && PlayerObj.fDistFrmStrtPnt > 1f && Vector3.Distance(player.transform.position, IGT_AIPlayer.AI_Player.transform.position) < 8f && (PlayerObj.currentPathIndex != 23 || nMissionID != 0))
					{
						IGT_GameView.nArrowAnimType = 4;
					}
				}
				else if (bThrwObjPicked)
				{
					IGT_Objects.PickedObj_InstanceID = -1;
					bThrwObjPicked = false;
				}
				if (nGameMode == 1 && !bMissionCompleted)
				{
					MissionCompletionChecking();
				}
				if (bSplPowersActivated)
				{
					splPowersFunctionalities();
				}
				if (pCoinObj.Count > 0)
				{
					CoinAnimation();
				}
			}
			else if (bNextAIPlayerGonnaPickPurse)
			{
				PlayerToAICurVecwhileGonnaPickPurse = new Vector3(player.transform.position.x - IGT_AIPlayer.AI_Player.transform.position.x, player.transform.position.y - IGT_AIPlayer.AI_Player.transform.position.y, player.transform.position.z - IGT_AIPlayer.AI_Player.transform.position.z);
				PlayerToAICurVecwhileGonnaPickPurse.Normalize();
				if (Vector3.Dot(PlayerToAIStrtVecwhileGonnaPickPurse, PlayerToAICurVecwhileGonnaPickPurse) <= 0f && Endless_Bag != null && Vector3.Distance(Endless_Bag.transform.position, IGT_AIPlayer.AI_Player.transform.position) < 1f && bBagMovingInCurve && IGT_AIPlayer.pAIPlayerAnimController.nHeroAnimState != 4)
				{
					IGT_AIPlayer.pAIPlayerAnimController.nHeroAnimState = 4;
					IGT_AIPlayer.AI_fprevOffet = IGT_AIPlayer.AI_offset_Laneoffset;
					IGT_AIPlayer.AI_DestinationOffset = fEndlessBag_offset_inPicking;
					IGT_AIPlayer.fTimeOffsetChange = 0f;
					IGT_Constants.AI_dStrtTimefrOffsetSwitchng = Time.time;
				}
				else if (Vector3.Dot(PlayerToAIStrtVecwhileGonnaPickPurse, PlayerToAICurVecwhileGonnaPickPurse) <= 0f && Vector3.Distance(player.transform.position, IGT_AIPlayer.AI_Player.transform.position) > IGT_Constants.fRadius_heroStrtToChaseNewAiPlayer)
				{
					bNextAIPlayerGonnaPickPurse = false;
					bBagMovingInCurve = false;
					nAIPlayerActionState = 0;
					IGT_GameView.setScreenMode(1);
					IGT_GameView.pAnim_MissionCompleted_star1.resetAllValues();
					IGT_AnimStatesCntrler.HeroAnimator.Play("IdleToRun", 0, 0.35f);
					IGT_AnimStatesCntrler.nHeroAnimState = 1;
				}
			}
		}
		AndroidMobileButtonEvents();
		calcFPS();
		CountDownAnimation();
		pIGt_LifeCalc.lifeAddingProcessCalc();
	}

	private void update_SplPowerDisplayPos()
	{
		int count = IGT_GameView.pIgtDispProp.Count;
		if (count != 0)
		{
			float y = IGT_GameView.rect_Game_ChaseHeader.y + IGT_GameView.rect_Game_ChaseHeader.height;
			float width = IGT_UIcommonFunc.ScaleY(40f);
			float height = IGT_UIcommonFunc.ScaleY(40f);
			switch (count)
			{
			case 1:
				IGT_GameView.pIgtDispProp.ElementAt(0).drawPos = new Rect(IGT_UIcommonFunc.ScaleX(144f), y, width, height);
				break;
			case 2:
				IGT_GameView.pIgtDispProp.ElementAt(0).drawPos = new Rect(IGT_UIcommonFunc.ScaleX(120f), y, width, height);
				IGT_GameView.pIgtDispProp.ElementAt(1).drawPos = new Rect(IGT_UIcommonFunc.ScaleX(170f), y, width, height);
				break;
			default:
				IGT_GameView.pIgtDispProp.ElementAt(0).drawPos = new Rect(IGT_UIcommonFunc.ScaleX(120f), y, width, height);
				IGT_GameView.pIgtDispProp.ElementAt(1).drawPos = new Rect(IGT_UIcommonFunc.ScaleX(144f), y, width, height);
				IGT_GameView.pIgtDispProp.ElementAt(2).drawPos = new Rect(IGT_UIcommonFunc.ScaleX(170f), y, width, height);
				break;
			}
		}
	}

	private void remove_SplPowerDisplayPos(int id)
	{
		for (int i = 0; i < IGT_GameView.pIgtDispProp.Count; i++)
		{
			if (IGT_GameView.pIgtDispProp.ElementAt(i).ID == id)
			{
				IGT_GameView.pIgtDispProp.RemoveAt(i);
				update_SplPowerDisplayPos();
				break;
			}
		}
	}

	private void ScoreCalculation()
	{
		if (nGameMode == 0 && Vector3.Distance(player.transform.position, IGT_AIPlayer.AI_Player.transform.position) < 30f)
		{
			nScore_Current += (int)(100f * (PlayerObj.speed * Time.deltaTime) * Mathf.Pow(nAIPlayerIndex + 1, 2f)) * IGT_Constants.Multiplier_Score;
			nScore_Current += nScore_Coin_Chase;
			nScore_Coin_Chase = 0;
		}
		if (nScore_Current < 0)
		{
			nScore_Current = 0;
		}
	}

	private void ScoreCalc_Missions()
	{
		int num = 0;
		int num2 = -1;
		if (nMissionID < nTutorialLevelCount || nMissionID == 13)
		{
			if (nMissionID == 4 && pMissionData.nLevelStarCount == -1)
			{
				IGT_Constants.nNoOfCollectedCoins += nCollectedItemCount;
			}
			num2 = pMissionData.nLevelStarCount;
			pMissionData.nLevelStarCount = 3;
			nStar_Current = 3;
			num = pMissionData.nLevelScore;
			pMissionData.nLevelScore = (nScore_Current = 50000);
			if (num <= 0)
			{
				nTotScore_Mission += nScore_Current;
			}
		}
		else
		{
			num = pMissionData.nLevelScore;
			num2 = pMissionData.nLevelStarCount;
			nScore_Current = 0;
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 0f;
			float num6 = 0f;
			switch (pMissionData.nMissionType)
			{
			case 0:
				num4 = Mathf.Ceil((float)pMissionData.nTargetCount + (float)pMissionData.nTargetCount * IGT_Constants.fMissionItemMissingProb);
				num5 = nNoOfCollectionObjHeroCrossed - pMissionData.nTargetCount;
				if (num5 < 0f)
				{
					num5 = 0f;
				}
				num6 = 35000f / num4;
				num3 = (num4 - num5) * num6;
				if (pMissionData.nCollectionInnerItemType == 0 && pMissionData.nLevelStarCount == -1)
				{
					IGT_Constants.nNoOfCollectedCoins += nCollectedItemCount;
				}
				break;
			case 1:
				num4 = Mathf.Ceil((float)pMissionData.nTargetCount + (float)pMissionData.nTargetCount * IGT_Constants.fChallengeItemCrossedProb);
				num5 = nNoOfCollectionObjHeroCrossed - pMissionData.nTargetCount;
				if (num5 < 0f)
				{
					num5 = 0f;
				}
				num6 = 35000f / num4;
				num3 = (num4 - num5) * num6;
				break;
			case 2:
				switch (pMissionData.nCatchingInnerItemType)
				{
				case 0:
					num4 = pMissionData.nTargetCount;
					num5 = (float)((double)pMissionData.nTargetCount - ((double)Time.time - dMissionStrtTime));
					if (num5 > num4)
					{
						num5 = num4;
					}
					if (num5 < 0f)
					{
						num5 = 0f;
					}
					num3 = 35000f / num4 * num5;
					break;
				case 1:
					num4 = pMissionData.nTargetCount;
					num5 = (float)pMissionData.nTargetCount - PlayerObj.fTotDistTraveled * IGT_Constants.GAME_TO_REAL_WORLD_DIST_MULTIPLIER;
					if (num5 > num4)
					{
						num5 = num4;
					}
					if (num5 < 0f)
					{
						num5 = 0f;
					}
					num3 = 35000f / num4 * num5;
					break;
				case 2:
					num4 = pMissionData.HeroStartEnergy;
					num5 = PlayerObj.nEnergyMeter * 100f;
					if (num5 > num4)
					{
						num5 = num4;
					}
					if (num5 < 0f)
					{
						num5 = 0f;
					}
					num3 = 35000f / num4 * num5;
					break;
				}
				break;
			case 3:
				num4 = pMissionData.WordTobeFind.Length;
				num5 = (float)nNoOf_WF_CharCrossed - num4;
				if (num5 > num4)
				{
					num5 = num4;
				}
				if (num5 < 0f)
				{
					num5 = 0f;
				}
				num6 = 35000f / num4;
				num3 = (num4 - num5) * num6;
				break;
			case 4:
			{
				float num10 = BB_TarAbsDistfrmStrt * 3f;
				float num11 = num10 * 1.3f;
				num4 = num10 / 2f;
				num5 = PlayerObj.fTotDistTraveled - num11;
				if (num5 > num4)
				{
					num5 = num4;
				}
				if (num5 < 0f)
				{
					num5 = 0f;
				}
				num3 = (num4 - num5) / num4;
				num3 = num3 * 10000f + 25000f;
				break;
			}
			case 5:
			{
				num4 = Mathf.Ceil((float)pMissionData.nMultipleCollectionDatas[0, 2] + (float)pMissionData.nMultipleCollectionDatas[0, 2] * IGT_Constants.fMissionItemMissingProb) + Mathf.Ceil((float)pMissionData.nMultipleCollectionDatas[1, 2] + (float)pMissionData.nMultipleCollectionDatas[1, 2] * IGT_Constants.fMissionItemMissingProb) + Mathf.Ceil((float)pMissionData.nMultipleCollectionDatas[2, 2] + (float)pMissionData.nMultipleCollectionDatas[2, 2] * IGT_Constants.fMissionItemMissingProb);
				float num7 = nNoOfMultiColObjCrossedUntillTargetAcheived[0] - pMissionData.nMultipleCollectionDatas[0, 2];
				if (num7 < 0f)
				{
					num7 = 0f;
				}
				float num8 = nNoOfMultiColObjCrossedUntillTargetAcheived[1] - pMissionData.nMultipleCollectionDatas[1, 2];
				if (num8 < 0f)
				{
					num8 = 0f;
				}
				float num9 = nNoOfMultiColObjCrossedUntillTargetAcheived[2] - pMissionData.nMultipleCollectionDatas[2, 2];
				if (num9 < 0f)
				{
					num9 = 0f;
				}
				num5 = num7 + num8 + num9;
				if (num5 < 0f)
				{
					num5 = 0f;
				}
				num6 = 35000f / num4;
				num3 = (num4 - num5) * num6;
				break;
			}
			}
			if (num3 > 35000f)
			{
				num3 = 35000f;
			}
			if (num3 < 0f)
			{
				num3 = 0f;
			}
			float num12 = 300f;
			int num13 = (int)((double)Time.time - dMissionStrtTime);
			float num14 = (num12 - (float)num13) / num12;
			num14 *= 15000f;
			if (num14 > 15000f)
			{
				num14 = 15000f;
			}
			if (num14 < 0f)
			{
				num14 = 0f;
			}
			nScore_Current = (int)(num3 + num14);
			int num15 = (nStar_Current = ((num3 > 25000f) ? 3 : ((num3 <= 10000f) ? 1 : 2)));
			if (pMissionData.nLevelStarCount == -1 && (pMissionData.nMissionType == 4 || pMissionData.nMissionType == 1 || pMissionData.nMissionType == 2))
			{
				IGT_Constants.nTotNoOfCoins = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_TotCoins, IGT_Constants.nTotNoOfCoins) + IGT_Constants.nNoOfCollectedCoins;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotCoins, IGT_Constants.nTotNoOfCoins);
			}
			if (nScore_Current >= num)
			{
				pMissionData.nLevelScore = nScore_Current;
			}
			if (num15 > num2)
			{
				pMissionData.nLevelStarCount = num15;
			}
			else
			{
				pMissionData.nLevelStarCount = num2;
			}
			if (num > 0 && num < nScore_Current)
			{
				nTotScore_Mission -= num;
			}
			if (nScore_Current > num)
			{
				nTotScore_Mission += nScore_Current;
			}
		}
		IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotScore_Mission, nTotScore_Mission);
		if (nTotScore_Mission >= 1000000)
		{
			IGT_Achivements.completeAchivements(3, nTotScore_Mission);
		}
		Save_LevelData(nMissionID, 1, pMissionData);
		HighScore_calc();
		if (nMissionID + 1 == 20 || nMissionID + 1 == 50 || nMissionID + 1 == 100 || nMissionID + 1 == 250 || nMissionID + 1 == 500)
		{
			IGT_Achivements.completeAchivements(1, nMissionID + 1);
		}
		missionStarAcheivemetnsCalc(num2, nStar_Current);
		if (IGT_GameView.pMissionLevelComplitedInfo != null)
		{
			IGT_GameView.pMissionLevelComplitedInfo(nMissionID, pMissionData.nLevelStarCount, nTotScore_Mission, 1);
		}
		if (isConnectedInternet())
		{
			IGT_GameView.pRateit.canShowRateItAlert(1 + nMissionID);
		}
		if (IGT_GameView.pRateit.bShowRateItAlert)
		{
			IGT_GameView.bAchievementAlert = false;
		}
		if (!IGT_GameView.pRateit.bShowRateItAlert)
		{
			int num16 = (1 + nMissionID) / 5;
			int num17 = (1 + nMissionID) % 5;
			if (num16 % 2 != 0 && num17 == 0 && IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_feedShareCount, 0) < num16 && IGT_GameView.currentTimeSecs() - IGT_GameView.feedShareTime >= 86400)
			{
				IGT_GameView.postFeedStory(0, (nMissionID + 1).ToString(), "0");
			}
		}
	}

	private void missionStarAcheivemetnsCalc(int prevStarVal, int CurStarVal)
	{
		if (IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQFQ", 0) == 0)
		{
			int num = 0;
			for (int i = 0; i < 10; i++)
			{
				IGT_Missions iGT_Missions = retrive_Saved_LevelData(i, 1);
				if (iGT_Missions != null && iGT_Missions.nLevelStarCount != -1)
				{
					num += iGT_Missions.nLevelStarCount;
				}
			}
			if (num == 30)
			{
				IGT_Achivements.completeAchivements(5, num);
			}
		}
		int num2 = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_Tot3StarCount, 0);
		if (prevStarVal < 3 && CurStarVal == 3)
		{
			num2++;
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_Tot3StarCount, num2);
			IGT_Preference.getInstance()._SaveAll();
		}
		if (num2 >= 25 && (IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQFg", 0) == 0 || IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQFw", 0) == 0 || IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQGA", 0) == 0) && (num2 == 25 || num2 == 100 || num2 == 200))
		{
			IGT_Achivements.completeAchivements(5, num2);
		}
	}

	private void HighScore_calc()
	{
		if (nGameMode == 0)
		{
			if (nScore_Current > IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_HighScore_Chase, 0))
			{
				nHigh_Score_Chase = nScore_Current;
				if (!IGT_GameView.pRateit.bShowRateItAlert && nScore_Current > IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_HighScore_Chase, 0) + 100000 && IGT_GameView.currentTimeSecs() - IGT_GameView.feedShareTime >= 86400)
				{
					string empty = string.Empty;
					if (nScore_Current >= 1000000)
					{
						int num = nScore_Current / 1000000;
						int num2 = nScore_Current % 1000000;
						empty = ((num2 == 0) ? (num + "M") : (num + "." + num2 + "M"));
					}
					else
					{
						int num3 = nScore_Current / 1000;
						empty = num3 + "K";
					}
					IGT_GameView.postFeedStory(1, "0", empty);
				}
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_HighScore_Chase, nHigh_Score_Chase);
			}
			nTotScore_Chase += nScore_Current;
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotScore_Chase, nTotScore_Chase);
			if (nHigh_Score_Chase >= 100000)
			{
				IGT_Achivements.completeAchivements(2, nHigh_Score_Chase);
			}
		}
		else if (nScore_Current > IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_HighScore_Mission, 0))
		{
			nHigh_Score_Mission = nScore_Current;
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_HighScore_Mission, nHigh_Score_Mission);
		}
		int num4 = IGT_Constants.nNoOfCollectedCoins;
		if (nGameMode == 1)
		{
			if (pMissionData.nMissionType == 0 && pMissionData.nCollectionInnerItemType == 0 && pMissionData.nLevelStarCount == -1)
			{
				num4 += nCollectedItemCount;
			}
			else if (pMissionData.nMissionType != 0 && pMissionData.nLevelStarCount != -1)
			{
				num4 = 0;
			}
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_TotCoins))
		{
			IGT_Constants.nTotNoOfCoins = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_TotCoins, IGT_Constants.nTotNoOfCoins) + num4;
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotCoins, IGT_Constants.nTotNoOfCoins);
		}
		else
		{
			IGT_Constants.nTotNoOfCoins += num4;
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotCoins, IGT_Constants.nTotNoOfCoins);
		}
		IGT_Preference.getInstance()._SaveAll();
		if (nGameMode == 1 && pMissionData.nMissionType == 0 && pMissionData.nCollectionInnerItemType == 0)
		{
			IGT_Constants.nNoOfCollectedCoins = nCollectedItemCount;
		}
	}

	private void setActivitySpinner(bool bStart)
	{
		if (bStart)
		{
			Handheld.StartActivityIndicator();
		}
		else
		{
			Handheld.StopActivityIndicator();
		}
	}

	private void surprisePlayerActionInit()
	{
		if (!isSurpriseAiAvailable || !(IGT_SurpriseAIplayer.SurpriseAI != null) || IGT_SurpriseAIplayer.bCanStart)
		{
			return;
		}
		switch (IGT_SurpriseAIplayer.playerAction)
		{
		case 0:
			IGT_SurpriseAIplayer.bCanStart = true;
			break;
		case 1:
			IGT_SurpriseAIplayer.bCanStart = true;
			break;
		case 2:
			if (!(Vector3.Distance(player.transform.position, IGT_SurpriseAIplayer.SurpriseAI.transform.position) < 20f))
			{
				break;
			}
			IGT_SurpriseAIplayer.bCanStart = true;
			IGT_SurpriseAIplayer.setSurprisePlayerAction(1);
			if (IGT_SurpriseAIplayer.SurpriseAI.GetComponent<AudioSource>() == null)
			{
				IGT_SurpriseAIplayer.SurpriseAI.AddComponent<AudioSource>().spatialBlend = 1f;
			}
			IGT_SurpriseAIplayer.SurpriseAI.GetComponent<AudioSource>().volume = 0.6f;
			if (nSound == 0)
			{
				if (surprisePlayerId == 1 || surprisePlayerId == 4)
				{
					IGT_SurpriseAIplayer.SurpriseAI.GetComponent<AudioSource>().pitch = 1.35f;
					IGT_SurpriseAIplayer.SurpriseAI.GetComponent<AudioSource>().PlayOneShot(IGT_GameView.pHero._AudioClips[29]);
				}
				else
				{
					IGT_SurpriseAIplayer.SurpriseAI.GetComponent<AudioSource>().pitch = 1f;
					IGT_SurpriseAIplayer.SurpriseAI.GetComponent<AudioSource>().PlayOneShot(IGT_GameView.pHero._AudioClips[29]);
				}
			}
			break;
		}
	}

	private void Checking_LevelUp()
	{
		if (nAIPlayerActionState != 2 && !bLevelUp && PlayerObj.currentPathIndex == IGT_AIPlayer.AI_PlayerObj.currentPathIndex && PlayerObj.bTraverseReverse == IGT_AIPlayer.AI_PlayerObj.bTraverseReverse && PlayerObj.fDistFrmStrtPnt != 0f && IGT_AIPlayer.AI_PlayerObj.fDistFrmStrtPnt != 0f && IGT_AnimStatesCntrler.nHeroAnimState != 16 && IGT_AnimStatesCntrler.nHeroAnimState != 18 && (nAIPlayerActionState == 1 || Vector3.Distance(player.transform.position, IGT_AIPlayer.AI_Player.transform.position) < IGT_Constants.fLevelUpOuterRadius || IGT_AIPlayer.AI_PlayerObj.fDistFrmStrtPnt - PlayerObj.fDistFrmStrtPnt < IGT_Constants.fLevelUpOuterRadius))
		{
			nAIPlayerActionState = 1;
			if (IGT_AIPlayer.AI_PlayerObj.nEnergyMeter <= 0.02f)
			{
				IGT_AIPlayer.AI_PlayerObj.nEnergyMeter = 0.02f;
			}
			else
			{
				IGT_AIPlayer.AI_PlayerObj.nEnergyMeter = IGT_AIPlayer.AI_PlayerObj.nEnergyMeter - Time.deltaTime * (IGT_AIPlayer.AI_PlayerObj.EnergyDeAcceleratorFactorPerSecond * 2f);
			}
			IGT_GameView.nHelath_Enemy = (IGT_AIPlayer.AI_PlayerObj.nEnergyMeterPrev = IGT_AIPlayer.AI_PlayerObj.nEnergyMeter);
			if (IGT_AIPlayer.AI_PlayerObj.fDistFrmStrtPnt - PlayerObj.fDistFrmStrtPnt < IGT_Constants.fLevelUpInnerRadius || Vector3.Distance(player.transform.position, IGT_AIPlayer.AI_Player.transform.position) < IGT_Constants.fLevelUpInnerRadius || PlayerObj.pObj.ObjListInCurPathOfHero.Count == 0)
			{
				IGT_AIPlayer.AI_PlayerObj.speed = IGT_AIPlayer.AI_PlayerObj.speed * 0.9f + PlayerObj.speed * 0.1f;
				if ((PlayerObj.pObj.ObjListInCurPathOfHero.Count == 0 && PlayerObj.fDistFrmStrtPnt > 1.5f) || CanPlayLevelUpSeq())
				{
					offsetSel_HeroMovingTowardsAI();
					if (Vector3.Distance(player.transform.position, IGT_AIPlayer.AI_Player.transform.position) > IGT_Constants.fLevelUpInnerRadius)
					{
						IGT_AIPlayer.AI_PlayerObj.speed = PlayerObj.speed * 0.75f;
						IGT_AIPlayer.AI_PlayerObj.nEnergyMeter = 0f;
					}
					else
					{
						IGT_AnimStatesCntrler.nHeroAnimState = 16;
						IGT_AnimStatesCntrler.HeroAnimator.Play("GameOverHit", 1);
						nAIPlayerActionState = 2;
						IGT_AIPlayer.AI_PlayerObj.speed *= 0.85f;
						ReducingPlayerAlphaWhileUsingUseKey(true);
						for (int num = PlayerObj.pObj.splPowersObj_PlacedDetails.Count - 1; num >= 0; num--)
						{
							if (PlayerObj.pObj.splPowersObj_PlacedDetails[num].nPathId == PlayerObj.currentPathIndex && (PlayerObj.pObj.splPowersObj_PlacedDetails[num].objID == 905 || PlayerObj.pObj.splPowersObj_PlacedDetails[num].objID == 906))
							{
								PlayerObj.pObj.splPowersObj_PlacedDetails.RemoveAt(num);
							}
						}
						IGT_ObjPlacing.splPowersobjDestruction();
						IGT_ObjPlacing.splPowersPlacing(ref PlayerObj.pObj.splPowersObj_PlacedDetails);
					}
				}
			}
		}
		if (IGT_AnimStatesCntrler.nHeroAnimState != 16 && IGT_AnimStatesCntrler.nHeroAnimState != 18)
		{
			if (PlayerObj.currentPathIndex == IGT_AIPlayer.AI_PlayerObj.currentPathIndex && PlayerObj.bTraverseReverse == IGT_AIPlayer.AI_PlayerObj.bTraverseReverse && PlayerObj.fDistFrmStrtPnt != 0f && IGT_AIPlayer.AI_PlayerObj.fDistFrmStrtPnt != 0f && IGT_AIPlayer.AI_PlayerObj.fDistFrmStrtPnt - PlayerObj.fDistFrmStrtPnt < 0.2f)
			{
				IGT_AIPlayer.AI_PlayerObj.speed = PlayerObj.speed + 0.8f;
			}
			else if ((PlayerObj.bMovingFinishdInPath && offset_Laneoffset == IGT_AIPlayer.AI_offset_Laneoffset && Vector3.Distance(player.transform.position, IGT_AIPlayer.AI_Player.transform.position) < 0.25f) || (PlayerObj.bMovingFinishdInPath && offset_Laneoffset != IGT_AIPlayer.AI_offset_Laneoffset && Vector3.Distance(player.transform.position, IGT_AIPlayer.AI_Player.transform.position) < 0.35f))
			{
				IGT_AIPlayer.AI_PlayerObj.speed = PlayerObj.speed + 0.8f;
			}
		}
		if (nAIPlayerActionState != 0 && Vector3.Distance(player.transform.position, IGT_AIPlayer.AI_Player.transform.position) > IGT_Constants.fLevelUpOuterRadius * 2f)
		{
			bLevelUp = false;
			nAIPlayerActionState = 0;
		}
	}

	private void DemoLevels_LevelUp_Checking()
	{
		if (!bLevelUp && nAIPlayerActionState != 2 && IGT_AnimStatesCntrler.nHeroAnimState != 16 && IGT_AnimStatesCntrler.nHeroAnimState != 18 && Vector3.Distance(player.transform.position, IGT_AIPlayer.AI_Player.transform.position) < IGT_Constants.fLevelUpOuterRadius)
		{
			offsetSel_HeroMovingTowardsAI();
			if (Vector3.Distance(player.transform.position, IGT_AIPlayer.AI_Player.transform.position) > IGT_Constants.fLevelUpInnerRadius)
			{
			}
			IGT_AnimStatesCntrler.nHeroAnimState = 16;
			IGT_AnimStatesCntrler.HeroAnimator.Play("GameOverHit", 1);
			nAIPlayerActionState = 2;
		}
		if (nMissionID == 3)
		{
			if (IGT_AIPlayer.AI_PlayerObj.currentPathIndex == 13 && IGT_AIPlayer.AI_offset_Laneoffset != 0f)
			{
				IGT_Constants.AI_dStrtTimefrOffsetSwitchng = Time.time;
				IGT_AIPlayer.AI_fprevOffet = IGT_AIPlayer.AI_offset_Laneoffset;
				IGT_AIPlayer.AI_DestinationOffset = 0f;
			}
			if (PlayerObj.currentPathIndex != 29 && PlayerObj.currentPathIndex != 13)
			{
				PlayerObj.EnergyDeAcceleratorFactorPerSecond = 0.075f;
			}
		}
	}

	private void offsetSel_HeroMovingTowardsAI()
	{
		IGT_Constants.AI_dStrtTimefrOffsetSwitchng = Time.time;
		if (IGT_AIPlayer.AI_offset_Laneoffset == centerOffset)
		{
			if (offset_Laneoffset == 0f - PlayerObj.fTotalOffsetDeviation)
			{
				bRightLaneShift = true;
				fprevOffet = offset_Laneoffset;
				fDestinationLaneOffset = centerOffset;
			}
			else if (offset_Laneoffset == PlayerObj.fTotalOffsetDeviation)
			{
				bLeftLaneShift = true;
				fprevOffet = offset_Laneoffset;
				fDestinationLaneOffset = centerOffset;
			}
		}
		else if (IGT_AIPlayer.AI_offset_Laneoffset == 0f - PlayerObj.fTotalOffsetDeviation)
		{
			if (offset_Laneoffset == centerOffset)
			{
				bLeftLaneShift = true;
				fprevOffet = offset_Laneoffset;
				fDestinationLaneOffset = 0f - PlayerObj.fTotalOffsetDeviation;
			}
			else if (offset_Laneoffset == PlayerObj.fTotalOffsetDeviation)
			{
				bLeftLaneShift = true;
				fprevOffet = offset_Laneoffset;
				fDestinationLaneOffset = 0f - PlayerObj.fTotalOffsetDeviation;
			}
		}
		else if (IGT_AIPlayer.AI_offset_Laneoffset == PlayerObj.fTotalOffsetDeviation)
		{
			if (offset_Laneoffset == centerOffset)
			{
				bRightLaneShift = true;
				fprevOffet = offset_Laneoffset;
				fDestinationLaneOffset = PlayerObj.fTotalOffsetDeviation;
			}
			else if (offset_Laneoffset == 0f - PlayerObj.fTotalOffsetDeviation)
			{
				bRightLaneShift = true;
				fprevOffet = offset_Laneoffset;
				fDestinationLaneOffset = PlayerObj.fTotalOffsetDeviation;
			}
		}
	}

	private void MissionCompletionChecking()
	{
		if (!bMissionManualEnding)
		{
			manualMissionEnding();
		}
		if ((nMissionID == 1 || nMissionID == 2) && pMissionData.nTargetCount == nCollectedItemCount && !bkickObjFly && !bPickdObjCanThrow)
		{
			setData_MissionCompleted();
		}
		switch (pMissionData.nMissionType)
		{
		case 0:
			if (pMissionData.nTargetCount <= nCollectedItemCount)
			{
				setData_MissionCompleted();
			}
			break;
		case 5:
			if (nCollectedMultipleItemCount[0] >= pMissionData.nMultipleCollectionDatas[0, 2] && nCollectedMultipleItemCount[1] >= pMissionData.nMultipleCollectionDatas[1, 2] && nCollectedMultipleItemCount[2] >= pMissionData.nMultipleCollectionDatas[2, 2])
			{
				setData_MissionCompleted();
			}
			break;
		case 4:
			if (BB_CollectionItem != null && bHasPicked_BBitem)
			{
				BB_CollectionItem.transform.position = Hero_HandWristPos.transform.position;
				BB_CollectionItem.transform.rotation = player.transform.rotation;
				BB_CollectionItem.transform.localScale = new Vector3(25f, 25f, 25f);
			}
			if (Heroine.transform != null && (double)Time.time - dMissionStrtTime > 10.0)
			{
				if (bHasPicked_BBitem && (PlayerObj.nAdjPIDs.Contains(PlayerObj.nGameStrtPath) || PlayerObj.currentPathIndex == PlayerObj.nGameStrtPath))
				{
					if (!Heroine.activeSelf)
					{
						Heroine.SetActive(true);
					}
					else
					{
						Heroine.transform.LookAt(player.transform);
					}
					if (Vector3.Distance(player.transform.position, Heroine.transform.position) < 1.5f)
					{
						setData_MissionCompleted();
						if (bHasPicked_BBitem && BB_CollectionItem != null)
						{
							BB_CollectionItem.SetActive(false);
						}
					}
				}
				else if (Heroine.activeSelf)
				{
					Heroine.SetActive(false);
				}
			}
			display_BringBackHereMap();
			EnergyMeterCalcHero();
			if (IGT_GameView.bDirMapBlink && Time.time - IGT_GameView.fDirMapBlink_StartTime > 3f)
			{
				IGT_GameView.bDirMapBlink = false;
			}
			break;
		case 1:
			if (pMissionData.nTargetCount == nCollectedItemCount && !bkickObjFly && !bPickdObjCanThrow)
			{
				setData_MissionCompleted();
			}
			break;
		case 3:
		{
			bool flag = false;
			for (int i = 0; i < pCharArray.Length; i++)
			{
				if (!pCharArray[i].isEnable)
				{
					flag = true;
					break;
				}
			}
			if (!flag && pCharArray.Length > 0)
			{
				setData_MissionCompleted();
			}
			EnergyMeterCalcHero();
			break;
		}
		case 2:
			break;
		}
	}

	public void setData_MissionCompleted()
	{
		playSound(3, 0.35f);
		bMissionCompleted = true;
		bGameOver = true;
		IGT_AnimStatesCntrler.nHeroAnimState = 24;
		IGT_AnimStatesCntrler.HeroAnimator.Play("MissionSuccess", 0);
		IGT_GameView.nArrowAnimType = -1;
		PlayerObj.DestroyAllTypesofObjects(true);
		ReducingPlayerAlphaWhileUsingUseKey(true);
		if (nTutorial == 0 && nMissionID == nTutorialLevelCount - 1)
		{
			nTutorial = 1;
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_Tutorial, nTutorial);
			IGT_GameView.bChaseLockedAlert = true;
			IGT_GameView.fChaseLockAlert_StartTime = Time.time;
			nChaseNewBadge = 0;
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_chaseNewBadge, nChaseNewBadge);
			IGT_Preference.getInstance()._SaveAll();
		}
		else
		{
			IGT_GameView.bChaseLockedAlert = false;
		}
		Hero_shadow_projector.SetActive(true);
		Hero_shadow_projector1.SetActive(false);
	}

	private void manualMissionEnding()
	{
		switch (pMissionData.nMissionType)
		{
		case 0:
			if ((float)nNoOfCollectionObjHeroCrossed >= Mathf.Ceil((float)pMissionData.nTargetCount + (float)pMissionData.nTargetCount * IGT_Constants.fMissionItemMissingProb))
			{
				bMissionManualEnding = true;
			}
			break;
		case 5:
			if ((float)nNoOfMulitpleCollObjHeroCrossed[0] >= Mathf.Ceil((float)pMissionData.nMultipleCollectionDatas[0, 2] + (float)pMissionData.nMultipleCollectionDatas[0, 2] * IGT_Constants.fMissionItemMissingProb) && (float)nNoOfMulitpleCollObjHeroCrossed[1] >= Mathf.Ceil((float)pMissionData.nMultipleCollectionDatas[1, 2] + (float)pMissionData.nMultipleCollectionDatas[1, 2] * IGT_Constants.fMissionItemMissingProb) && (float)nNoOfMulitpleCollObjHeroCrossed[2] >= Mathf.Ceil((float)pMissionData.nMultipleCollectionDatas[2, 2] + (float)pMissionData.nMultipleCollectionDatas[2, 2] * IGT_Constants.fMissionItemMissingProb))
			{
				bMissionManualEnding = true;
			}
			break;
		case 2:
			switch (pMissionData.nCatchingInnerItemType)
			{
			case 0:
				if (!IGT_GameView.bCatchMode_End && (double)Time.time - dMissionStrtTime > (double)(pMissionData.nTargetCount - 3))
				{
					IGT_GameView.bCatchMode_End = true;
					IGT_GameView.fCatchMode_StartTime = Time.time;
				}
				if ((double)Time.time - dMissionStrtTime > (double)pMissionData.nTargetCount)
				{
					setMissionFailedInCatchMode();
					IGT_GameView.sAlertText = " Time's Up ";
				}
				break;
			case 1:
				if (!IGT_GameView.bCatchMode_End && PlayerObj.fTotDistTraveled * IGT_Constants.GAME_TO_REAL_WORLD_DIST_MULTIPLIER - (float)pMissionData.nTargetCount > -30f)
				{
					IGT_GameView.bCatchMode_End = true;
					IGT_GameView.fCatchMode_StartTime = Time.time;
				}
				if (PlayerObj.fTotDistTraveled * IGT_Constants.GAME_TO_REAL_WORLD_DIST_MULTIPLIER - (float)pMissionData.nTargetCount > 0f)
				{
					setMissionFailedInCatchMode();
					IGT_GameView.sAlertText = " Distance Exceeded ";
				}
				break;
			}
			break;
		case 1:
			if ((float)nNoOfCollectionObjHeroCrossed >= Mathf.Ceil((float)pMissionData.nTargetCount + (float)pMissionData.nTargetCount * IGT_Constants.fChallengeItemCrossedProb) || (float)nNoOfChallengeObjHeroMissed >= Mathf.Ceil((float)pMissionData.nTargetCount + (float)pMissionData.nTargetCount * IGT_Constants.fMissionItemMissingProb))
			{
				bMissionManualEnding = true;
			}
			break;
		case 4:
			nTimeLeft_in_BringBackMode = (int)(dLifeTime_of_BringBackMode - ((double)Time.time - dMissionStrtTime));
			if (nTimeLeft_in_BringBackMode <= 0)
			{
				bMissionManualEnding = true;
				nTimeLeft_in_BringBackMode = 0;
			}
			break;
		case 3:
			nTimeLeft_in_WordFindingMode = (int)(dLiftTime_of_WordFindingMode - ((double)Time.time - dMissionStrtTime));
			if (nTimeLeft_in_WordFindingMode <= 0)
			{
				nTimeLeft_in_WordFindingMode = 0;
				setMissionFailedInCatchMode();
				IGT_GameView.sAlertText = " Time's Up ";
			}
			break;
		default:
			if (nMissionID != 0 && (double)Time.time - dMissionStrtTime > 120.0)
			{
				bMissionManualEnding = true;
			}
			break;
		}
	}

	private void setMissionFailedInCatchMode()
	{
		bMissionManualEnding = true;
		IGT_AnimStatesCntrler.nHeroAnimState = 31;
		IGT_AnimStatesCntrler.HeroAnimator.Play("looser", 0, 0.3f);
		bGameOver = true;
		IGT_GameView.bOutOfEnergyTextAlert = true;
		IGT_GameView.fOutOfEnergyTextAlert_StrtTime = Time.time;
		IGT_GameView.pAnim_MissionCompleted_star2.resetAllValues();
		if (PlayerObj.nEnergyMeter > 0f)
		{
			PlayerObj.DestroyAllTypesofObjects();
		}
		if (!bPickdObjCanThrow && bThrwObjPicked && IGT_Objects.PickedObj_InstanceID != -1)
		{
			IGT_ObjPlacing.dynObjList.ElementAt(IGT_Objects.PickedObj_InstanceID).transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
			bThrwObjPicked = false;
			IGT_Objects.PickedObj_InstanceID = -1;
		}
		splPower_Hide();
		Hero_shadow_projector.SetActive(true);
		Hero_shadow_projector1.SetActive(false);
	}

	private void createEndingWall()
	{
		if (PlayerObj.fDistFrmStrtPnt >= 0.5f && PartialObjPlacement_curStep == 0 && PlayerObj.pathLength[PlayerObj.currentPathIndex] > 10f)
		{
			float num = IGT_Constants.nDistBtwHero_MissionEndGate;
			if (nMissionID < nTutorialLevelCount)
			{
				num = PlayerObj.pathLength[PlayerObj.currentPathIndex] - 1f;
			}
			float num2 = 0.4f;
			Vector3 vector;
			Vector3 prevpos;
			if (!PlayerObj.bTraverseReverse)
			{
				vector = PlayerObj.findPos(PlayerObj.currentPathIndex, num, num2);
				prevpos = PlayerObj.findPos(PlayerObj.currentPathIndex, num - 0.5f, num2);
			}
			else
			{
				num = PlayerObj.pathLength[PlayerObj.currentPathIndex] - num;
				num2 = 0f - num2;
				vector = PlayerObj.findPos(PlayerObj.currentPathIndex, num, num2);
				prevpos = PlayerObj.findPos(PlayerObj.currentPathIndex, num + 0.5f, num2);
			}
			Vector3 vector2 = PlayerObj.findRotation(vector, prevpos);
			missionEndWall = UnityEngine.Object.Instantiate(IGT_ObjPlacing.EndWall, vector, Quaternion.Euler(0f, vector2.z, 0f));
			missionEndWall.tag = IGT_Constants.Tag_MissionFailedGate;
			missionEndWall.name = "EndGate";
			missionEndWall.GetComponent<Animation>().playAutomatically = false;
		}
	}

	public bool CanPlayLevelUpSeq()
	{
		if (PlayerObj.pathLength[PlayerObj.currentPathIndex] - PlayerObj.fDistFrmStrtPnt < 5f || PlayerObj.fDistFrmStrtPnt < 1.5f)
		{
			return false;
		}
		if (isSurpriseAiAvailable && IGT_SurpriseAIplayer.SurpriseAI != null && IGT_SurpriseAIplayer.playerAction != 2 && PlayerObj.currentPathIndex == IGT_SurpriseAIplayer.Surprise_PlayerObj.currentPathIndex && Vector3.Distance(player.transform.position, IGT_SurpriseAIplayer.SurpriseAI.transform.position) < 8f)
		{
			return false;
		}
		float fDistFrmStrtPnt = PlayerObj.fDistFrmStrtPnt;
		bool flag = false;
		int num = -1;
		float num2 = 0f;
		List<IGT_ObjInfo> list = PlayerObj.objDetInGivenPath(PlayerObj.currentPathIndex);
		for (int i = 0; i < list.Count; i++)
		{
			float num3 = (PlayerObj.bTraverseReverse ? (PlayerObj.pathLength[PlayerObj.currentPathIndex] - list[i].fDistFrmStrtPnt) : list[i].fDistFrmStrtPnt);
			if (fDistFrmStrtPnt < num3 && list[i].objType != 6 && list[i].objType != 4 && list[i].objType != 9)
			{
				if (num2 == 0f)
				{
					num2 = num3;
					num = i;
				}
				else if (num2 > num3)
				{
					num2 = num3;
					num = i;
				}
			}
		}
		if (num != -1)
		{
			if (num2 - list[num].fWidth / 1.5f - fDistFrmStrtPnt > 8f)
			{
				flag = true;
			}
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			PlayerObj.objDetInCurPath(PlayerObj.currentPathIndex);
			num = (PlayerObj.bTraverseReverse ? PlayerObj.findNxtObjIdBasedDistinFrwdPath(PlayerObj.pathLength[PlayerObj.currentPathIndex] - fDistFrmStrtPnt) : PlayerObj.findNxtObjIdBasedDistinRevPath(fDistFrmStrtPnt));
			if (num != -1)
			{
				num2 = PlayerObj.pObj.obj[num].fDistFrmStrtPnt;
				fDistFrmStrtPnt = PlayerObj.pathLength[PlayerObj.currentPathIndex] - (fDistFrmStrtPnt - 1f);
				if (num2 - PlayerObj.pObj.obj[num].fWidth / 1.5f < fDistFrmStrtPnt)
				{
					flag = false;
				}
			}
		}
		return flag;
	}

	public void Game_LevelUp()
	{
		bGameOver = true;
		bLevelUp = true;
		if (nGameMode == 1 && pMissionData.nMissionType == 1)
		{
			bMissionManualEnding = true;
		}
		if (!bPickdObjCanThrow && bThrwObjPicked && IGT_Objects.PickedObj_InstanceID != -1)
		{
			IGT_ObjPlacing.dynObjList.ElementAt(IGT_Objects.PickedObj_InstanceID).transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
			bThrwObjPicked = false;
			IGT_Objects.PickedObj_InstanceID = -1;
		}
		IGT_GameView.setScreenMode(20);
		IGT_Constants.fLevelUpStartTime = Time.time;
		if (IGT_AIPlayer.AI_offset_Laneoffset == centerOffset)
		{
			bLeftLaneShift = true;
			fprevOffet = offset_Laneoffset;
			fDestinationLaneOffset = 0f - PlayerObj.fTotalOffsetDeviation;
		}
		else if (IGT_AIPlayer.AI_offset_Laneoffset == 0f - PlayerObj.fTotalOffsetDeviation)
		{
			bRightLaneShift = true;
			fprevOffet = offset_Laneoffset;
			fDestinationLaneOffset = centerOffset;
		}
		else if (IGT_AIPlayer.AI_offset_Laneoffset == PlayerObj.fTotalOffsetDeviation)
		{
			bLeftLaneShift = true;
			fprevOffet = offset_Laneoffset;
			fDestinationLaneOffset = centerOffset;
		}
		AIplayerToHeroStrtVecInGameLevelUpScreen = new Vector3(IGT_AIPlayer.AI_Player.transform.position.x - player.transform.position.x, IGT_AIPlayer.AI_Player.transform.position.y - player.transform.position.y, IGT_AIPlayer.AI_Player.transform.position.z - player.transform.position.z);
		AIplayerToHeroStrtVecInGameLevelUpScreen.Normalize();
		AIplayerToHeroCurVecInGameLevelUpScreen = new Vector3(IGT_AIPlayer.AI_Player.transform.position.x - player.transform.position.x, IGT_AIPlayer.AI_Player.transform.position.y - player.transform.position.y, IGT_AIPlayer.AI_Player.transform.position.z - player.transform.position.z);
		AIplayerToHeroCurVecInGameLevelUpScreen.Normalize();
		removeCoinAnimationDatas();
		IGT_Constants.fGlobal_Spd_Multiplier = IGT_Constants.fGlobal_Spd_Multiplier_Min;
		splPower_Hide();
		ReducingPlayerAlphaWhileUsingUseKey(true);
	}

	private void GameOver_AnimationSelection(int flag = -1)
	{
		IGT_AnimStatesCntrler.nHeroAnimState = 7;
		bGameOver = true;
		if (nGameMode == 1 && (nMissionID == 3 || nMissionID == 4))
		{
			bMissionManualEnding = true;
		}
		if (!IGT_GameView.bOutOfEnergyTextAlert)
		{
			switch (flag)
			{
			case 1:
				IGT_AnimStatesCntrler.HeroAnimator.Play("FallBack", 0);
				break;
			case 2:
				IGT_AnimStatesCntrler.HeroAnimator.Play("360SpinDeath", 0);
				break;
			case 3:
				IGT_AnimStatesCntrler.HeroAnimator.Play("RunToStop", 0);
				break;
			default:
				IGT_AnimStatesCntrler.nHeroAnimState = 5;
				break;
			}
		}
		gameoverHideItems();
	}

	private void gameoverHideItems()
	{
		Hero_shadow_projector.SetActive(false);
		Hero_shadow_projector1.SetActive(false);
		if (!bPickdObjCanThrow && bThrwObjPicked && IGT_Objects.PickedObj_InstanceID != -1)
		{
			IGT_ObjPlacing.dynObjList.ElementAt(IGT_Objects.PickedObj_InstanceID).transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
			bThrwObjPicked = false;
			IGT_Objects.PickedObj_InstanceID = -1;
		}
		splPower_Hide();
	}

	public void Movement()
	{
		if (!PlayerObj.bMovingFinishdInPath)
		{
			PlayerMovement();
			if (nAIPlayerActionState == 0 && PartialObjPlacement_curStep < IGT_Constants.PartialObjPlacement_MaxStep && !bMissionManualEnding)
			{
				if ((nGameMode == 0 && IGT_AIPlayer.AI_PlayerObj.nEnergyMeter > 0.1f) || (nGameMode == 1 && nMissionID > 3 && nMissionID != 13))
				{
					PartialObjPlacementTechnique();
				}
			}
			else if (bMissionManualEnding && missionEndWall == null)
			{
				createEndingWall();
			}
			else if (bMissionManualEnding && missionEndWall != null && (float)IGT_Constants.nDistBtwHero_MissionEndGate - 3.5f < PlayerObj.fDistFrmStrtPnt && !missionEndWall.GetComponent<Animation>().playAutomatically)
			{
				missionEndWall.GetComponent<Animation>().Play();
				missionEndWall.GetComponent<Animation>().playAutomatically = true;
				playSound(34);
			}
			return;
		}
		if (!bSelectDataFrMovingBWPath)
		{
			if (!PlayerObj.bTraverseReverse)
			{
				PlayerObj._nextPos = PlayerObj.waypoints[PlayerObj.currentPoint].position;
				PlayerObj._nextToTarPos = PlayerObj.waypoints[PlayerObj.currentPoint + 1].position;
				pathIDFrFindingPosBasedGivenDist = PlayerObj.currentPathIndex;
				StrtPosIDFrFindingPosBasedGivenDist = PlayerObj.currentPoint;
			}
			else
			{
				PlayerObj._nextPos = PlayerObj.waypoints[PlayerObj.currentPoint - 1].position;
				PlayerObj._nextToTarPos = PlayerObj.waypoints[PlayerObj.currentPoint - 2].position;
				pathIDFrFindingPosBasedGivenDist = PlayerObj.currentPathIndex;
				StrtPosIDFrFindingPosBasedGivenDist = PlayerObj.currentPoint - 1;
			}
			PlayerObj._prevPos.x = PlayerObj.pointPos[PlayerObj.prevPathID_BeforeLastPointID[0, 0], PlayerObj.prevPathID_BeforeLastPointID[0, 1], 0];
			PlayerObj._prevPos.y = PlayerObj.pointPos[PlayerObj.prevPathID_BeforeLastPointID[0, 0], PlayerObj.prevPathID_BeforeLastPointID[0, 1], 1];
			PlayerObj._prevPos.z = PlayerObj.pointPos[PlayerObj.prevPathID_BeforeLastPointID[0, 0], PlayerObj.prevPathID_BeforeLastPointID[0, 1], 2];
			PlayerObj._curPos.x = PlayerObj.pointPos[PlayerObj.prevPathID_LastPointID[0, 0], PlayerObj.prevPathID_LastPointID[0, 1], 0];
			PlayerObj._curPos.y = PlayerObj.pointPos[PlayerObj.prevPathID_LastPointID[0, 0], PlayerObj.prevPathID_LastPointID[0, 1], 1];
			PlayerObj._curPos.z = PlayerObj.pointPos[PlayerObj.prevPathID_LastPointID[0, 0], PlayerObj.prevPathID_LastPointID[0, 1], 2];
			bSelectDataFrMovingBWPath = true;
			Vector3 pos = new Vector3(PlayerObj._nextToTarPos.x, 0f, PlayerObj._nextToTarPos.z);
			Vector3 prevpos = new Vector3(PlayerObj._nextPos.x, 0f, PlayerObj._nextPos.z);
			Vector3 vector = PlayerObj.findRotation(pos, prevpos);
			fDirLight_Src = pDirLight.transform.rotation.y;
			fDirLight_Dest = vector.z - 30f;
			pDirLightAnimator.resetAllValues();
		}
		pDirLight.transform.rotation = Quaternion.Euler(0f, pDirLightAnimator.easeFunctions(fDirLight_Src, fDirLight_Dest, 0.5f, 0), 0f);
		if (!MovingInBetweenPath(PlayerObj._curPos, PlayerObj._nextPos, PlayerObj._prevPos, PlayerObj._nextToTarPos) && !PlayerObj.bMovingFinishdInPath)
		{
			bSelectDataFrMovingBWPath = false;
			bHeroPathSelctionUptoReachAnotherPathEndFinishd = true;
			bTurning = false;
			nCoinSoundIdx = 0;
			PartialObjPlacement_curStep = 0;
			PartialObjPlacement_MinDist = PlayerObj.pathLength[PlayerObj.currentPathIndex] * 0.4f / (float)IGT_Constants.PartialObjPlacement_MaxStep;
			PlayerObj.pObj.ObjListInCurPathOfHero = PlayerObj.objDetInGivenPath(PlayerObj.currentPathIndex);
			PlayerObj.pObj.nPathID = PlayerObj.currentPathIndex;
			int num = PlayerObj.pointCount[PlayerObj.currentPathIndex] / 2;
			Vector3 pos2 = new Vector3(PlayerObj.pointPos[PlayerObj.currentPathIndex, num, 0], PlayerObj.pointPos[PlayerObj.currentPathIndex, num, 1], PlayerObj.pointPos[PlayerObj.currentPathIndex, num, 2]);
			float mindistanceVal = 8f;
			float maxdistanceVal = PlayerObj.pathLength[PlayerObj.currentPathIndex] / 2f - 2f;
			if (nSound == 0)
			{
				if (PlayerObj.pathLocation[PlayerObj.currentPathIndex] == 1)
				{
					playEnvironmentSound(14, 0, pos2, 1f, true, true, mindistanceVal, maxdistanceVal);
				}
				else if (PlayerObj.pathLocation[PlayerObj.currentPathIndex] == 3)
				{
					if (PlayerObj.currentPathIndex == 20 || PlayerObj.currentPathIndex == 24 || PlayerObj.currentPathIndex == 16)
					{
						playEnvironmentSound(15, 0, pos2, 0.2f, true, true, mindistanceVal, maxdistanceVal);
					}
					else
					{
						playEnvironmentSound(13, 0, pos2, 0.2f, true, true, mindistanceVal, maxdistanceVal);
					}
				}
				else if (PlayerObj.pathLocation[PlayerObj.currentPathIndex] == 2)
				{
					playEnvironmentSound(18, 0, pos2, 0.1f, true, true, mindistanceVal, maxdistanceVal);
				}
			}
			if (nGameMode == 1 && nMissionID < nTutorialLevelCount && (nMissionID == 1 || nMissionID == 2))
			{
				PlayerObj.tutorial_ObjPlacing_AdjPath(nMissionID, PlayerObj.currentPathIndex, PlayerObj.bTraverseReverse);
			}
			if (Heroine != null && Heroine.activeSelf && (nGameMode != 1 || pMissionData.nMissionType != 4))
			{
				Heroine.SetActive(false);
			}
			if (PlayerObj.bTraverseReverse)
			{
				for (int i = 0; i < PlayerObj.pObj.ObjListInCurPathOfHero.Count; i++)
				{
					if (PlayerObj.pObj.ObjListInCurPathOfHero[i].objType != 9 || (PlayerObj.pObj.ObjListInCurPathOfHero[i].objID != 908 && PlayerObj.pObj.ObjListInCurPathOfHero[i].objID != 909))
					{
						continue;
					}
					for (int j = 0; j < IGT_ObjPlacing.splPowersInstanceList.Count; j++)
					{
						if (IGT_ObjPlacing.splPowersInstanceList.ElementAt(j) == null)
						{
							continue;
						}
						Vector3 vector2 = new Vector3(IGT_ObjPlacing.splPowersInstanceList.ElementAt(j).transform.position.x, 0.1f, IGT_ObjPlacing.splPowersInstanceList.ElementAt(j).transform.position.z);
						Vector3 vector3 = new Vector3(PlayerObj.pObj.ObjListInCurPathOfHero[i].ObjPos.x, 0.1f, PlayerObj.pObj.ObjListInCurPathOfHero[i].ObjPos.z);
						if (!(vector2 == vector3))
						{
							continue;
						}
						float num2 = IGT_ObjPlacing.splPowersInstanceList.ElementAt(j).transform.rotation.eulerAngles.y - 180f;
						IGT_ObjPlacing.splPowersInstanceList.ElementAt(j).transform.rotation = Quaternion.Euler(new Vector3(IGT_ObjPlacing.splPowersInstanceList.ElementAt(j).transform.rotation.eulerAngles.x, num2, IGT_ObjPlacing.splPowersInstanceList.ElementAt(j).transform.rotation.eulerAngles.z));
						for (int k = 0; k < PlayerObj.pObj.splPowersObj_PlacedDetails.Count; k++)
						{
							vector3 = new Vector3(PlayerObj.pObj.splPowersObj_PlacedDetails[k].ObjPos.x, 0.1f, PlayerObj.pObj.splPowersObj_PlacedDetails[k].ObjPos.z);
							if (vector2 == vector3)
							{
								PlayerObj.pObj.splPowersObj_PlacedDetails[k].objRot.z = num2;
								break;
							}
						}
						break;
					}
				}
			}
			nHeroAdjPath.Clear();
			for (int l = 0; l < 3; l++)
			{
				int[] array = new int[6];
				array = PlayerObj.findPathBasedInput(PlayerObj.currentPathIndex, PlayerObj.bTraverseReverse, l);
				nHeroAdjPath.Add(array[0]);
			}
			if (IGT_GameView.pHero.nGameMode == 0 && Time.time - IGT_Constants.splPowers_Chase_LastPlacedTime > IGT_Constants.splPowers_Chase_Interval)
			{
				PlayerObj.splPowersInfoSelection_Chase(PlayerObj.currentPathIndex);
			}
		}
		if (!bHeroPathSelctionUptoReachAnotherPathEndFinishd)
		{
			pathSelctionUptoReachAnotherPathEnd();
		}
	}

	private void PartialObjPlacementTechnique()
	{
		if (PlayerObj.fDistFrmStrtPnt > PartialObjPlacement_MinDist * (float)IGT_Constants.PartialObjPlacement_MaxStep)
		{
			for (int i = PartialObjPlacement_curStep; i <= IGT_Constants.PartialObjPlacement_MaxStep; i++)
			{
				PartialObjPlacement_curStep = i;
				PlayerObj.objplaceInfo(PartialObjPlacement_curStep);
			}
		}
		else if (PlayerObj.fDistFrmStrtPnt >= (float)PartialObjPlacement_curStep * PartialObjPlacement_MinDist)
		{
			PlayerObj.objplaceInfo(PartialObjPlacement_curStep);
			PartialObjPlacement_curStep++;
		}
	}

	private void pathSelctionUptoReachAnotherPathEnd()
	{
		if (Vector3.Distance(PlayerObj._curPos, PlayerCurPos) < Vector3.Distance(PlayerObj._curPos, PlayerObj._nextPos) * 0.5f)
		{
			if ((nUserInput == 1 && PlayerObj.nAdjpathToCurPath[1] != -1 && PlayerObj.nAdjpathToCurPath[1] != PlayerObj.currentPathIndex) || (nUserInput == 2 && PlayerObj.nAdjpathToCurPath[2] != -1 && PlayerObj.nAdjpathToCurPath[2] != PlayerObj.currentPathIndex))
			{
				Vector3 endPos = new Vector3(PlayerObj.pointPos[PlayerObj.prevPathIndex, PlayerObj.prevPathID_LastPointID[0, 1], 0], PlayerObj.pointPos[PlayerObj.prevPathIndex, PlayerObj.prevPathID_LastPointID[0, 1], 1], PlayerObj.pointPos[PlayerObj.prevPathIndex, PlayerObj.prevPathID_LastPointID[0, 1], 2]);
				Vector3 prevPos = new Vector3(PlayerObj.pointPos[PlayerObj.prevPathIndex, PlayerObj.prevPathID_BeforeLastPointID[0, 1], 0], PlayerObj.pointPos[PlayerObj.prevPathIndex, PlayerObj.prevPathID_BeforeLastPointID[0, 1], 1], PlayerObj.pointPos[PlayerObj.prevPathIndex, PlayerObj.prevPathID_BeforeLastPointID[0, 1], 2]);
				bNxtPathAvail = PlayerObj.findNearstPath(PlayerObj.prevPathIndex, prevPos, endPos, nUserInput);
				nUserInput = 0;
				PlayerObj.bMovingFinishdInPath = true;
				bSelectDataFrMovingBWPath = false;
				bHeroPathSelctionUptoReachAnotherPathEndFinishd = true;
				fDistBw2Points = 0.2f;
			}
		}
		else
		{
			bHeroPathSelctionUptoReachAnotherPathEndFinishd = true;
		}
	}

	private void OffsetFixing(float OffsetSwitchingTime)
	{
		if (bTurning)
		{
			if ((nUserInput == 1 && nHeroAdjPath[1] == -1) || (nUserInput == 2 && nHeroAdjPath[2] == -1))
			{
				if (nUserInput == 1 && offset_Laneoffset != 0f - PlayerObj.fTotalOffsetDeviation && !bLeftLaneShift && !bRightLaneShift && IGT_AnimStatesCntrler.nHeroAnimState != 10)
				{
					playSound(25, 0.8f);
					bLeftLaneShift = true;
					bRightLaneShift = false;
					fprevOffet = offset_Laneoffset;
					fDestinationLaneOffset = FindNxtLaneOffset(offset_Laneoffset);
					IGT_AnimStatesCntrler.nHeroAnimState = 10;
				}
				else if (nUserInput == 2 && offset_Laneoffset != PlayerObj.fTotalOffsetDeviation && !bRightLaneShift && !bLeftLaneShift && IGT_AnimStatesCntrler.nHeroAnimState != 11)
				{
					playSound(25, 0.8f);
					bRightLaneShift = true;
					bLeftLaneShift = false;
					fprevOffet = offset_Laneoffset;
					fDestinationLaneOffset = FindNxtLaneOffset(offset_Laneoffset);
					IGT_AnimStatesCntrler.nHeroAnimState = 11;
				}
			}
		}
		else if (!bTurning && nUserInput == 1 && offset_Laneoffset != 0f - PlayerObj.fTotalOffsetDeviation && !bLeftLaneShift && !bRightLaneShift && IGT_AnimStatesCntrler.nHeroAnimState != 10)
		{
			playSound(25, 0.8f);
			bLeftLaneShift = true;
			bRightLaneShift = false;
			fprevOffet = offset_Laneoffset;
			fDestinationLaneOffset = FindNxtLaneOffset(offset_Laneoffset);
			IGT_AnimStatesCntrler.nHeroAnimState = 10;
		}
		else if (!bTurning && nUserInput == 2 && offset_Laneoffset != PlayerObj.fTotalOffsetDeviation && !bRightLaneShift && !bLeftLaneShift && IGT_AnimStatesCntrler.nHeroAnimState != 11)
		{
			playSound(25, 0.8f);
			bRightLaneShift = true;
			bLeftLaneShift = false;
			fprevOffet = offset_Laneoffset;
			fDestinationLaneOffset = FindNxtLaneOffset(offset_Laneoffset);
			IGT_AnimStatesCntrler.nHeroAnimState = 11;
		}
		else if (!bTurning && (nUserInput == 1 || nUserInput == 2) && !bLeftLaneShift && !bRightLaneShift)
		{
			nUserInput = 0;
		}
		if (bLeftLaneShift)
		{
			fLaneTempOffset = IGT_EaseFunction.Linear_ease(fTimeOffsetChange, fprevOffet, fDestinationLaneOffset, OffsetSwitchingTime);
			fTimeOffsetChange += Time.deltaTime;
			if (fTimeOffsetChange >= OffsetSwitchingTime)
			{
				fTimeOffsetChange = 0f;
				fLaneTempOffset = fDestinationLaneOffset;
				bLeftLaneShift = false;
				if (IGT_AnimStatesCntrler.nHeroAnimState != 4)
				{
					IGT_AnimStatesCntrler.nHeroAnimState = 1;
				}
				if (nUserInput != 3 && nUserInput != 4)
				{
					nUserInput = 0;
				}
			}
		}
		else if (bRightLaneShift)
		{
			fLaneTempOffset = IGT_EaseFunction.Linear_ease(fTimeOffsetChange, fprevOffet, fDestinationLaneOffset, OffsetSwitchingTime);
			fTimeOffsetChange += Time.deltaTime;
			if (fTimeOffsetChange >= OffsetSwitchingTime)
			{
				fTimeOffsetChange = 0f;
				bRightLaneShift = false;
				fLaneTempOffset = fDestinationLaneOffset;
				if (IGT_AnimStatesCntrler.nHeroAnimState != 4)
				{
					IGT_AnimStatesCntrler.nHeroAnimState = 1;
				}
				if (nUserInput != 3 && nUserInput != 4)
				{
					nUserInput = 0;
				}
			}
		}
		offset_Laneoffset = fLaneTempOffset;
	}

	private void OffsetFixing_or_AcceleroMeter(float OffsetSwitchingTime)
	{
		Acceleration = AccObj.LowPassFilter(Input.acceleration);
		if (!bAcceleroMeterEnabled)
		{
			if (PlayerObj.bMovingFinishdInPath && !bHeroPathSelctionUptoReachAnotherPathEndFinishd && isAIplayerAvailable && PlayerObj.currentPathIndex != IGT_AIPlayer.AI_PlayerObj.currentPathIndex)
			{
				if ((nUserInput == 1 && PlayerObj.nAdjpathToCurPath[1] != -1 && PlayerObj.nAdjpathToCurPath[1] != PlayerObj.currentPathIndex) || (nUserInput == 2 && PlayerObj.nAdjpathToCurPath[2] != -1 && PlayerObj.nAdjpathToCurPath[2] != PlayerObj.currentPathIndex))
				{
					bTurning = true;
				}
				else
				{
					bTurning = false;
				}
			}
			if (!bTurning && nUserInput == 1 && offset_Laneoffset != 0f - PlayerObj.fTotalOffsetDeviation && !bLeftLaneShift && !bRightLaneShift && IGT_AnimStatesCntrler.nHeroAnimState != 10)
			{
				bLeftLaneShift = true;
				bRightLaneShift = false;
				fprevOffet = offset_Laneoffset;
				fDestinationLaneOffset = FindNxtLaneOffset(offset_Laneoffset);
				IGT_AnimStatesCntrler.nHeroAnimState = 10;
			}
			else if (!bTurning && nUserInput == 2 && offset_Laneoffset != PlayerObj.fTotalOffsetDeviation && !bRightLaneShift && !bLeftLaneShift && IGT_AnimStatesCntrler.nHeroAnimState != 11)
			{
				bRightLaneShift = true;
				bLeftLaneShift = false;
				fprevOffet = offset_Laneoffset;
				fDestinationLaneOffset = FindNxtLaneOffset(offset_Laneoffset);
				IGT_AnimStatesCntrler.nHeroAnimState = 11;
			}
			else if (!bTurning && (nUserInput == 1 || nUserInput == 2) && !bLeftLaneShift && !bRightLaneShift)
			{
				nUserInput = 0;
			}
			if (bLeftLaneShift)
			{
				fLaneTempOffset = IGT_EaseFunction.Linear_ease(fTimeOffsetChange, fprevOffet, fDestinationLaneOffset, OffsetSwitchingTime);
				fTimeOffsetChange += Time.deltaTime;
				if (fTimeOffsetChange >= OffsetSwitchingTime)
				{
					fTimeOffsetChange = 0f;
					fLaneTempOffset = fDestinationLaneOffset;
					bLeftLaneShift = false;
					if (IGT_AnimStatesCntrler.nHeroAnimState != 4)
					{
						IGT_AnimStatesCntrler.nHeroAnimState = 1;
					}
					if (nUserInput != 3 && nUserInput != 4)
					{
						nUserInput = 0;
					}
				}
			}
			else if (bRightLaneShift)
			{
				fLaneTempOffset = IGT_EaseFunction.Linear_ease(fTimeOffsetChange, fprevOffet, fDestinationLaneOffset, OffsetSwitchingTime);
				fTimeOffsetChange += Time.deltaTime;
				if (fTimeOffsetChange >= OffsetSwitchingTime)
				{
					fTimeOffsetChange = 0f;
					bRightLaneShift = false;
					fLaneTempOffset = fDestinationLaneOffset;
					if (IGT_AnimStatesCntrler.nHeroAnimState != 4)
					{
						IGT_AnimStatesCntrler.nHeroAnimState = 1;
					}
					if (nUserInput != 3 && nUserInput != 4)
					{
						nUserInput = 0;
					}
				}
			}
			offset_Laneoffset = fLaneTempOffset;
			return;
		}
		if (initAccDiff == 10000f)
		{
			initAccDiff = Mathf.Round(Input.acceleration.x * 1000f) / 1000f;
			fInitAccAngle = TchObj.angleBtwTwoPts(0f, 0f, Input.acceleration.x, Input.acceleration.z);
			fMinAccRange = (fInitAccAngle - 45f) % 360f;
			if (fMinAccRange < 0f)
			{
				fMinAccRange = 360f + fMinAccRange;
			}
			fMaxAccRange = (fInitAccAngle + 45f) % 360f;
			offset_Laneoffset = 0f;
		}
		Vector2 vector = new Vector2(Acceleration.x, Acceleration.z);
		float num = TchObj.angleBtwTwoPts(0f, 0f, vector.x, vector.y);
		if (num > fMinAccRange || num < fMaxAccRange)
		{
			float num2 = num - fInitAccAngle;
			float num3 = num2 * PlayerObj.fTotalOffsetDeviation / 45f;
			num3 = Mathf.Clamp(Mathf.Round(num3 * 1000f) / 1000f, 0f - PlayerObj.pathWidth[PlayerObj.currentPathIndex] / 2f * PlayerObj.fTotalOffsetDeviation, PlayerObj.pathWidth[PlayerObj.currentPathIndex] / 2f * PlayerObj.fTotalOffsetDeviation);
			offset_Laneoffset = num3;
		}
	}

	private float FindNxtLaneOffset(float curOffset)
	{
		float fTotalOffsetDeviation = PlayerObj.fTotalOffsetDeviation;
		if (curOffset == 0f - fTotalOffsetDeviation)
		{
			if (bLeftLaneShift)
			{
				return 0f - fTotalOffsetDeviation;
			}
			if (bRightLaneShift)
			{
				return centerOffset;
			}
		}
		else if (curOffset == centerOffset)
		{
			if (bLeftLaneShift)
			{
				return 0f - fTotalOffsetDeviation;
			}
			if (bRightLaneShift)
			{
				return fTotalOffsetDeviation;
			}
		}
		else if (curOffset == fTotalOffsetDeviation)
		{
			if (bLeftLaneShift)
			{
				return centerOffset;
			}
			if (bRightLaneShift)
			{
				return fTotalOffsetDeviation;
			}
		}
		return curOffset;
	}

	public void EnergyMeterCalcHero()
	{
		if (!PlayerObj.bEnergyMeterChangesinBezier)
		{
			float num = PlayerObj.EnergyDeAcceleratorFactorPerSecond;
			if (nGameMode == 1)
			{
				num *= IGT_Constants.fDiffSpd_CurVal_Mission;
			}
			if (isAIplayerAvailable && PlayerObj.currentPathIndex != IGT_AIPlayer.AI_PlayerObj.currentPathIndex && Vector3.Distance(player.transform.position, IGT_AIPlayer.AI_Player.transform.position) > 25f)
			{
				PlayerObj.nEnergyMeter -= Time.deltaTime * (num * 2f);
			}
			else if (nAIPlayerActionState == 0)
			{
				PlayerObj.nEnergyMeter -= Time.deltaTime * num;
			}
			PlayerObj.nEnergyMeterPrev = PlayerObj.nEnergyMeter;
		}
		else
		{
			PlayerObj.nEnergyMeter = (1f - PlayerObj.fTimeForEnergyMeterChanges) * PlayerObj.nEnergyMeterPrev + PlayerObj.fTimeForEnergyMeterChanges * PlayerObj.nEnergyMeterNext;
			PlayerObj.fTimeForEnergyMeterChanges += Time.deltaTime * 0.5f;
			if (PlayerObj.fTimeForEnergyMeterChanges > 1f)
			{
				PlayerObj.fTimeForEnergyMeterChanges = 1f;
				PlayerObj.bEnergyMeterChangesinBezier = false;
			}
		}
		if (PlayerObj.nEnergyMeter < 0f)
		{
			PlayerObj.nEnergyMeter = 0f;
		}
		if (PlayerObj.nEnergyMeter > 1f)
		{
			PlayerObj.nEnergyMeter = 1f;
		}
		IGT_GameView.nHealth_hero = PlayerObj.nEnergyMeter;
		if (PlayerObj.nEnergyMeter < 0.05f)
		{
			if (nSound == 0 && !_AudioSource3.isPlaying)
			{
				_AudioSource3.Play();
			}
			if (PlayerObj.nEnergyMeter <= 0f)
			{
				_AudioSource3.Stop();
				IGT_GameView.sAlertText = " Out of Energy ";
				setMissionFailedInCatchMode();
			}
			if (!IGT_GameView.bLowEnergy_Hero)
			{
				IGT_GameView.bLowEnergy_Hero = true;
				IGT_GameView.fLowEnergy_Hero_StrtTime = Time.time;
			}
		}
		else if (IGT_GameView.bLowEnergy_Hero && PlayerObj.nEnergyMeter > 0.05f && Time.time - IGT_GameView.fLowEnergy_Hero_StrtTime > 2f)
		{
			IGT_GameView.bLowEnergy_Hero = false;
		}
	}

	private void SpeedCalc()
	{
		PlayerObj.speed = PlayerObj.BaseSpeed;
		if (nGameMode == 0)
		{
			PlayerObj.speed = (fTempChaseSpdStrtUpAdj = PlayerObj.speed * IGT_Constants.fGlobal_Spd_Multiplier);
		}
		else
		{
			PlayerObj.speed = (fTempMissionSpdStrtUpAdj = PlayerObj.speed * IGT_Constants.fDiffSpd_CurVal_Mission * IGT_Constants.fMission_Spd_Multiplier);
		}
		if (PlayerObj.speed > PlayerObj.MaxSpeed)
		{
			PlayerObj.speed = PlayerObj.MaxSpeed;
		}
		PlayerObj.PrevSpeed = PlayerObj.speed;
	}

	private void AnimationSpeedCalc()
	{
		if (nGameMode == 1 && nMissionID > 2 && !IGT_GameView.pAnim_MissionCompleted_star1.isAnimFinished())
		{
			float num = IGT_GameView.pAnim_MissionCompleted_star1.easeFunctions(0.1f, 1f, 1.5f, 0);
			PlayerObj.speed = fTempMissionSpdStrtUpAdj * num;
		}
		if (nGameMode == 0 && !IGT_GameView.pAnim_MissionCompleted_star1.isAnimFinished())
		{
			float num2 = IGT_GameView.pAnim_MissionCompleted_star1.easeFunctions(0.1f, 1f, 1f, 0);
			PlayerObj.speed = fTempChaseSpdStrtUpAdj * num2;
		}
		if (PlayerObj.nEnergyMeter >= 0.05f)
		{
			IGT_AnimStatesCntrler.HeroAnimator.speed = 0.15f + pLegrangeInterPolation_AI.getResultValue(PlayerObj.speed / PlayerObj.BaseSpeed);
		}
	}

	private void GlobalSpdMultiplierCalc()
	{
		IGT_Constants.fGlobal_Spd_Multiplier += (IGT_Constants.fGlobal_Spd_Multiplier_Max - IGT_Constants.fGlobal_Spd_Multiplier_Min) / IGT_Constants.fGlobal_Spd_Multiplier_Interval * Time.deltaTime;
		if (IGT_Constants.fGlobal_Spd_Multiplier < IGT_Constants.fGlobal_Spd_Multiplier_Min)
		{
			IGT_Constants.fGlobal_Spd_Multiplier = IGT_Constants.fGlobal_Spd_Multiplier_Min;
		}
		else if (IGT_Constants.fGlobal_Spd_Multiplier > IGT_Constants.fGlobal_Spd_Multiplier_Max)
		{
			IGT_Constants.fGlobal_Spd_Multiplier = IGT_Constants.fGlobal_Spd_Multiplier_Max;
		}
	}

	public void Throw_pickedObjects()
	{
		if (bGameOver)
		{
			return;
		}
		if (IGT_Objects.PickedObj_InstanceID != -1 && IGT_ObjPlacing.dynObjList.ElementAt(IGT_Objects.PickedObj_InstanceID).GetComponent<Rigidbody>() == null)
		{
			IGT_ObjPlacing.dynObjList.ElementAt(IGT_Objects.PickedObj_InstanceID).tag = IGT_Constants.Tag_ThrowObj;
			IGT_ObjPlacing.dynObjList.ElementAt(IGT_Objects.PickedObj_InstanceID).AddComponent<Rigidbody>();
			IGT_ObjPlacing.dynObjList.ElementAt(IGT_Objects.PickedObj_InstanceID).AddComponent<IGT_ThrowObjects>();
			pThrow = IGT_ObjPlacing.dynObjList.ElementAt(IGT_Objects.PickedObj_InstanceID).GetComponent<IGT_ThrowObjects>();
		}
		if (IGT_Objects.PickedObj_InstanceID == -1)
		{
			return;
		}
		pThrow = IGT_ObjPlacing.dynObjList.ElementAt(IGT_Objects.PickedObj_InstanceID).GetComponent<IGT_ThrowObjects>();
		float fTravelTime = 0.5f;
		float dist = 0f;
		if (isAIplayerAvailable && Vector3.Distance(player.transform.position, IGT_AIPlayer.AI_Player.transform.position) < 1.5f)
		{
			fTravelTime = 0.35f;
			if (Vector3.Distance(player.transform.position, IGT_AIPlayer.AI_Player.transform.position) < 1.25f)
			{
				fTravelTime = 0.25f;
			}
		}
		Vector3 vector = FindTarPosForKick_ThrowObjects(fTravelTime, ref dist);
		float num = 10f;
		Vector3 position = Hero_HandWristPos.transform.position;
		Vector3 dSrcPt = new Vector3(vector.x, IGT_Constants.HeroHeight / 4f + vector.y, vector.z);
		float num2 = Mathf.Sqrt(dist * (0f - Physics.gravity.y) / Mathf.Sin((float)Math.PI / 180f * (num * 2f)));
		Vector3 lhs = new Vector3(dSrcPt.x - position.x, dSrcPt.y - position.y, dSrcPt.z - position.z);
		lhs.Normalize();
		Vector3 dRotAxis = Vector3.Cross(lhs, Vector3.up);
		Vector3 vector2 = IGT_Math.RotatePoint_ByAxis(dSrcPt, num, dRotAxis, position);
		lhs = new Vector3(vector2.x - position.x, vector2.y - position.y, vector2.z - position.z);
		lhs.Normalize();
		Vector3 vel = lhs * num2;
		pThrow.vel = vel;
		pThrow.dir = lhs;
		bPickdObjCanThrow = true;
		IGT_AnimStatesCntrler.dThrowObjTrueTime = Time.timeSinceLevelLoad;
		for (int i = 0; i < PlayerObj.pObj.objFrDraw.Count; i++)
		{
			if (IGT_Objects.ThrowObj_Placed_Pos == PlayerObj.pObj.objFrDraw.ElementAt(i).ObjPos)
			{
				PlayerObj.pObj.objFrDraw.RemoveAt(i);
				break;
			}
		}
		if (nGameMode == 1 && pMissionData.nMissionType == 1 && pMissionData.nChallengesInnerItemType == 1)
		{
			nNoOfChallengeObjHeroMissed++;
		}
	}

	private void pickingThrowObjects()
	{
		if (!bThrwObjPicked && !bPickObjSelected)
		{
			if (PlayerObj.pObj.fDistfrmPlyrTo_pickObj <= 2f && PlayerObj.pObj.fDistfrmPlyrTo_pickObj > 1.95f && !bPickObjSelected)
			{
				IGT_AnimStatesCntrler.nHeroAnimState = 4;
				bPickObjSelected = true;
				dPickobjSelectdTime = Time.time;
			}
			else if (PlayerObj.pObj.fDistfrmPlyrTo_pickObj <= 1.95f && PlayerObj.pObj.fDistfrmPlyrTo_pickObj > 1f && !bPickObjSelected)
			{
				IGT_AnimStatesCntrler.nHeroAnimState = 4;
				IGT_AnimStatesCntrler.HeroAnimator.Play("Pick", 0, 0.25f);
				bPickObjSelected = true;
				dPickobjSelectdTime = Time.time;
			}
			else if (PlayerObj.pObj.fDistfrmPlyrTo_pickObj < 1f && PlayerObj.pObj.fDistfrmPlyrTo_pickObj > 0.2f && !bPickObjSelected)
			{
				IGT_AnimStatesCntrler.nHeroAnimState = 4;
				IGT_AnimStatesCntrler.HeroAnimator.Play("Pick", 0, 0.35f);
				bPickObjSelected = true;
				dPickobjSelectdTime = Time.time;
			}
		}
		if (IGT_AnimStatesCntrler.HeroAnimator.GetCurrentAnimatorStateInfo(0).IsName("Pick") && PlayerObj.pObj.fDistfrmPlyrTo_pickObj < 0.05f && !bThrwObjPicked && bPickObjSelected)
		{
			for (int i = 0; i < IGT_ObjPlacing.dynObjList.Count; i++)
			{
				Vector3 vector = new Vector3(IGT_ObjPlacing.dynObjList.ElementAt(i).transform.position.x, 0.1f, IGT_ObjPlacing.dynObjList.ElementAt(i).transform.position.z);
				Vector3 vector2 = new Vector3(PlayerObj.pObj.ObjListInCurPathOfHero[PlayerObj.pObj.PickObjId].ObjPos.x, 0.1f, PlayerObj.pObj.ObjListInCurPathOfHero[PlayerObj.pObj.PickObjId].ObjPos.z);
				if (vector == vector2 && IGT_ObjPlacing.dynObjList.ElementAt(i).GetComponent<Rigidbody>() == null && PlayerObj.pObj.ObjListInCurPathOfHero[PlayerObj.pObj.PickObjId].objType == 6)
				{
					IGT_Objects.PickedObj_InstanceID = i;
					break;
				}
			}
			bThrwObjPicked = true;
			bPickObjSelected = false;
			bPickdObjCanThrow = false;
			IGT_Objects.ThrowObj_Placed_Pos = PlayerObj.pObj.ObjListInCurPathOfHero[PlayerObj.pObj.PickObjId].ObjPos;
			if (IGT_Objects.PickedObj_InstanceID != -1)
			{
			}
		}
		else if (PlayerObj.pObj.fDistfrmPlyrTo_pickObj < 0f && !bThrowObjMoving && !bPickObjSelected && IGT_AnimStatesCntrler.nHeroAnimState != 2)
		{
			for (int j = 0; j < IGT_ObjPlacing.dynObjList.Count; j++)
			{
				Vector3 vector3 = new Vector3(IGT_ObjPlacing.dynObjList.ElementAt(j).transform.position.x, 0.1f, IGT_ObjPlacing.dynObjList.ElementAt(j).transform.position.z);
				Vector3 vector4 = new Vector3(PlayerObj.pObj.ObjListInCurPathOfHero[PlayerObj.pObj.PickObjId].ObjPos.x, 0.1f, PlayerObj.pObj.ObjListInCurPathOfHero[PlayerObj.pObj.PickObjId].ObjPos.z);
				if (!(vector3 == vector4) || !(IGT_ObjPlacing.dynObjList.ElementAt(j).GetComponent<Rigidbody>() == null) || PlayerObj.pObj.ObjListInCurPathOfHero[PlayerObj.pObj.PickObjId].objType != 6)
				{
					continue;
				}
				IGT_ObjPlacing.dynObjList.ElementAt(j).AddComponent<Rigidbody>();
				IGT_ObjPlacing.dynObjList.ElementAt(j).AddComponent<IGT_ThrowObjects>();
				IGT_ThrowObjects component = IGT_ObjPlacing.dynObjList.ElementAt(j).GetComponent<IGT_ThrowObjects>();
				component.fMovForce = 3.5f;
				component.dir = Vector3.right;
				for (int k = 0; k < PlayerObj.pObj.objFrDraw.Count; k++)
				{
					if (vector4 == new Vector3(PlayerObj.pObj.objFrDraw.ElementAt(k).ObjPos.x, 0.1f, PlayerObj.pObj.objFrDraw.ElementAt(k).ObjPos.z))
					{
						PlayerObj.pObj.objFrDraw.RemoveAt(k);
						playSound(10);
						break;
					}
				}
				break;
			}
			bThrowObjMoving = true;
			IGT_AnimStatesCntrler.dThrowObjMovTrueTime = Time.timeSinceLevelLoad;
		}
		else if (PlayerObj.pObj.fDistfrmPlyrTo_pickObj < 0f && bPickObjSelected && !bThrwObjPicked)
		{
			bPickObjSelected = false;
			IGT_AnimStatesCntrler.nHeroAnimState = 1;
			IGT_AnimStatesCntrler.HeroAnimator.Play("Running", 0);
		}
	}

	private void kickObjects()
	{
		if (bKickAnimCanEnable)
		{
			if (PlayerObj.pObj.fDistfrmPlyrTo_KickObj < 2.5f && PlayerObj.pObj.fDistfrmPlyrTo_KickObj >= 1.85f && bKickAnimCanEnable)
			{
				float num = PlayerObj.pObj.ObjListInCurPathOfHero[PlayerObj.pObj.kickObjId].fOffset;
				if (PlayerObj.bTraverseReverse)
				{
					num = 0f - num;
				}
				if (num < 0f)
				{
					IGT_AnimStatesCntrler.nHeroAnimState = 12;
				}
				else
				{
					IGT_AnimStatesCntrler.nHeroAnimState = 9;
				}
				bKickAnimCanEnable = false;
				bKickAnimMissed = false;
				bKickobjCanMove = false;
			}
			else if (PlayerObj.pObj.fDistfrmPlyrTo_KickObj < 1.85f && PlayerObj.pObj.fDistfrmPlyrTo_KickObj > 1.04f && bKickAnimCanEnable)
			{
				float num2 = PlayerObj.pObj.ObjListInCurPathOfHero[PlayerObj.pObj.kickObjId].fOffset;
				if (PlayerObj.bTraverseReverse)
				{
					num2 = 0f - num2;
				}
				if (num2 < 0f)
				{
					IGT_AnimStatesCntrler.nHeroAnimState = 12;
					IGT_AnimStatesCntrler.HeroAnimator.Play("Leftkick", 0, 0.35f);
				}
				else
				{
					IGT_AnimStatesCntrler.nHeroAnimState = 9;
					IGT_AnimStatesCntrler.HeroAnimator.Play("Kick", 0, 0.35f);
				}
				bKickAnimCanEnable = false;
				bKickAnimMissed = false;
				bKickobjCanMove = false;
			}
			else if (PlayerObj.pObj.fDistfrmPlyrTo_KickObj < 1f && PlayerObj.pObj.fDistfrmPlyrTo_KickObj > 0.2f && bKickAnimCanEnable)
			{
				float num3 = PlayerObj.pObj.ObjListInCurPathOfHero[PlayerObj.pObj.kickObjId].fOffset;
				if (PlayerObj.bTraverseReverse)
				{
					num3 = 0f - num3;
				}
				if (num3 < 0f)
				{
					IGT_AnimStatesCntrler.nHeroAnimState = 12;
					IGT_AnimStatesCntrler.HeroAnimator.Play("Leftkick", 0, 0.5f);
				}
				else
				{
					IGT_AnimStatesCntrler.nHeroAnimState = 9;
					IGT_AnimStatesCntrler.HeroAnimator.Play("Kick", 0, 0.5f);
				}
				bKickAnimCanEnable = false;
				bKickAnimMissed = false;
				bKickobjCanMove = false;
			}
		}
		if (!bkickObjFly && PlayerObj.pObj.fDistfrmPlyrTo_KickObj < 0.05f && !bKickAnimMissed && (IGT_AnimStatesCntrler.HeroAnimator.GetCurrentAnimatorStateInfo(0).IsName("Kick") || IGT_AnimStatesCntrler.HeroAnimator.GetCurrentAnimatorStateInfo(0).IsName("Leftkick")))
		{
			playSound(11);
			bkickObjFly = true;
			IGT_AnimStatesCntrler.objFlyTrueTime = Time.timeSinceLevelLoad;
			bKickWithinAnimRange = false;
			for (int i = 0; i < IGT_ObjPlacing.dynObjList.Count; i++)
			{
				Vector3 vector = new Vector3(IGT_ObjPlacing.dynObjList.ElementAt(i).transform.position.x, 0.1f, IGT_ObjPlacing.dynObjList.ElementAt(i).transform.position.z);
				Vector3 vector2 = new Vector3(PlayerObj.pObj.ObjListInCurPathOfHero[PlayerObj.pObj.kickObjId].ObjPos.x, 0.1f, PlayerObj.pObj.ObjListInCurPathOfHero[PlayerObj.pObj.kickObjId].ObjPos.z);
				if (!(vector == vector2))
				{
					continue;
				}
				if (!(IGT_ObjPlacing.dynObjList.ElementAt(i).GetComponent<Rigidbody>() == null) || PlayerObj.pObj.ObjListInCurPathOfHero[PlayerObj.pObj.kickObjId].objType != 4)
				{
					break;
				}
				IGT_ObjPlacing.dynObjList.ElementAt(i).tag = IGT_Constants.Tag_KickObj;
				IGT_ObjPlacing.dynObjList.ElementAt(i).AddComponent<Rigidbody>();
				IGT_ObjPlacing.dynObjList.ElementAt(i).AddComponent<TrailRenderer>();
				TrailRenderer component = IGT_ObjPlacing.dynObjList.ElementAt(i).GetComponent<TrailRenderer>();
				component.autodestruct = false;
				component.endWidth = 0.005f;
				component.startWidth = 0.04f;
				component.time = 0.1f;
				component.receiveShadows = false;
				component.reflectionProbeUsage = ReflectionProbeUsage.Off;
				component.motionVectorGenerationMode = MotionVectorGenerationMode.Object;
				component.material = pKick_TrailFireMaterial;
				IGT_ObjPlacing.dynObjList.ElementAt(i).AddComponent<IGT_KickObjects>();
				IGT_KickObjects component2 = IGT_ObjPlacing.dynObjList.ElementAt(i).GetComponent<IGT_KickObjects>();
				IGT_Objects.kickObj_InstanceID = i;
				float fTravelTime = 0.65f;
				float dist = 0f;
				if (isAIplayerAvailable && Vector3.Distance(vector2, IGT_AIPlayer.AI_Player.transform.position) < 1.5f)
				{
					fTravelTime = 0.55f;
					if (Vector3.Distance(vector2, IGT_AIPlayer.AI_Player.transform.position) < 1.25f)
					{
						fTravelTime = 0.425f;
					}
				}
				Vector3 vector3 = FindTarPosForKick_ThrowObjects(fTravelTime, ref dist);
				float num4 = 15f;
				Vector3 dRotCenter = new Vector3(vector2.x, IGT_Constants.HeroHeight / 2f, vector2.z);
				Vector3 dSrcPt = new Vector3(vector3.x, IGT_Constants.HeroHeight / 2f, vector3.z);
				float num5 = Mathf.Sqrt(dist * (0f - Physics.gravity.y) / Mathf.Sin((float)Math.PI / 180f * (num4 * 2f)));
				Vector3 lhs = new Vector3(dSrcPt.x - dRotCenter.x, dSrcPt.y - dRotCenter.y, dSrcPt.z - dRotCenter.z);
				lhs.Normalize();
				Vector3 dRotAxis = Vector3.Cross(lhs, Vector3.up);
				Vector3 vector4 = IGT_Math.RotatePoint_ByAxis(dSrcPt, num4, dRotAxis, dRotCenter);
				lhs = new Vector3(vector4.x - dRotCenter.x, vector4.y - dRotCenter.y, vector4.z - dRotCenter.z);
				lhs.Normalize();
				Vector3 vel = lhs * num5;
				component2.vel = vel;
				component2.dir = lhs;
				for (int j = 0; j < PlayerObj.pObj.objFrDraw.Count; j++)
				{
					if (vector2 == new Vector3(PlayerObj.pObj.objFrDraw.ElementAt(j).ObjPos.x, 0.1f, PlayerObj.pObj.objFrDraw.ElementAt(j).ObjPos.z))
					{
						PlayerObj.pObj.objFrDraw.RemoveAt(j);
						break;
					}
				}
				if (nGameMode == 1 && pMissionData.nMissionType == 1 && pMissionData.nChallengesInnerItemType == 0)
				{
					nNoOfChallengeObjHeroMissed++;
				}
				break;
			}
		}
		else
		{
			if (!(PlayerObj.pObj.fDistfrmPlyrTo_KickObj < 0f) || !bKickobjCanMove || bKickAnimCanEnable || bkickObjFly)
			{
				return;
			}
			for (int k = 0; k < IGT_ObjPlacing.dynObjList.Count; k++)
			{
				Vector3 vector5 = new Vector3(IGT_ObjPlacing.dynObjList.ElementAt(k).transform.position.x, 0.1f, IGT_ObjPlacing.dynObjList.ElementAt(k).transform.position.z);
				Vector3 vector6 = new Vector3(PlayerObj.pObj.ObjListInCurPathOfHero[PlayerObj.pObj.kickObjId].ObjPos.x, 0.1f, PlayerObj.pObj.ObjListInCurPathOfHero[PlayerObj.pObj.kickObjId].ObjPos.z);
				if (!(vector5 == vector6))
				{
					continue;
				}
				if (!(IGT_ObjPlacing.dynObjList.ElementAt(k).GetComponent<Rigidbody>() == null) || PlayerObj.pObj.ObjListInCurPathOfHero[PlayerObj.pObj.kickObjId].objType != 4)
				{
					break;
				}
				IGT_ObjPlacing.dynObjList.ElementAt(k).AddComponent<Rigidbody>();
				IGT_ObjPlacing.dynObjList.ElementAt(k).AddComponent<IGT_KickObjects>();
				IGT_KickObjects component3 = IGT_ObjPlacing.dynObjList.ElementAt(k).GetComponent<IGT_KickObjects>();
				component3.fMovForce = 3f;
				component3.dir = Vector3.right;
				IGT_Objects.kickObj_InstanceID = k;
				for (int l = 0; l < PlayerObj.pObj.objFrDraw.Count; l++)
				{
					if (vector6 == new Vector3(PlayerObj.pObj.objFrDraw.ElementAt(l).ObjPos.x, 0.1f, PlayerObj.pObj.objFrDraw.ElementAt(l).ObjPos.z))
					{
						PlayerObj.pObj.objFrDraw.RemoveAt(l);
						break;
					}
				}
				playSound(11, 0.5f);
				break;
			}
			bKickObjMoving = true;
			bKickWithinAnimRange = false;
			IGT_AnimStatesCntrler.objMovTrueTime = Time.timeSinceLevelLoad;
		}
	}

	public Vector3 FindTarPosForKick_ThrowObjects(float fTravelTime, ref float dist)
	{
		Vector3[] array = new Vector3[6];
		dist = 8f;
		int side = 0;
		if (isAIplayerAvailable)
		{
			if (PlayerObj.currentPathIndex == IGT_AIPlayer.AI_PlayerObj.currentPathIndex)
			{
				dist = IGT_AIPlayer.AI_PlayerObj.fDistFrmStrtPnt + IGT_AIPlayer.AI_PlayerObj.speed * fTravelTime - PlayerObj.fDistFrmStrtPnt;
			}
			else
			{
				int[] array2 = new int[6];
				bool flag = false;
				array2 = PlayerObj.findPathBasedInput(PlayerObj.currentPathIndex, PlayerObj.bTraverseReverse, 0);
				if (array2[0] == IGT_AIPlayer.AI_PlayerObj.currentPathIndex)
				{
					dist = PlayerObj.pathLength[PlayerObj.currentPathIndex] - PlayerObj.fDistFrmStrtPnt + (IGT_AIPlayer.AI_PlayerObj.fDistFrmStrtPnt + IGT_AIPlayer.AI_PlayerObj.speed * fTravelTime);
					dist += 1f;
					flag = true;
				}
				if (!flag)
				{
					dist = 8f;
				}
			}
		}
		int num;
		if (!PlayerObj.bTraverseReverse)
		{
			num = PlayerObj.currentPoint;
			if (PlayerObj.currentPoint == PlayerObj.pointCount[PlayerObj.currentPathIndex] - 1)
			{
				num = PlayerObj.currentPoint - 1;
			}
		}
		else
		{
			num = PlayerObj.currentPoint - 1;
			if (num - 1 <= 0)
			{
				num = 1;
			}
		}
		if (PlayerObj.bMovingFinishdInPath)
		{
			dist += 0.55f;
		}
		array = PlayerObj.TarPosFindngfrKickThrowObjBasedDist(PlayerObj.currentPathIndex, num, dist, PlayerObj.bTraverseReverse, side);
		Vector3 rhs = new Vector3(array[0].x - array[1].x, array[0].y - array[1].y, array[0].z - array[1].z);
		rhs.Normalize();
		Vector3 vector = Vector3.Cross(Vector3.up, rhs);
		if (isAIplayerAvailable)
		{
			return array[0] + vector * IGT_AIPlayer.AI_offset_Laneoffset;
		}
		return array[0] + vector * offset_Laneoffset;
	}

	private Vector3 FindAvgVectorBasedGivenPosition(Vector3 strt, Vector3 end, float upVectPercentage)
	{
		Vector3 vector = new Vector3(end.x - strt.x, end.y - strt.y, end.z - strt.z);
		vector.Normalize();
		Vector3 vector2 = new Vector3(Vector3.up.x * upVectPercentage, Vector3.up.y * upVectPercentage, Vector3.up.z * upVectPercentage);
		Vector3 result = (vector + vector2) * 0.5f;
		result.Normalize();
		return result;
	}

	private void ScaleDownObjectHeight()
	{
		Vector3 a = new Vector3(player.transform.localPosition.x, player.transform.localPosition.y, player.transform.localPosition.z);
		Vector3 b = new Vector3(player.transform.localPosition.x, -0.5f, player.transform.localPosition.z);
		player.transform.localPosition = Vector3.Lerp(a, b, 1f * Time.deltaTime);
	}

	private void PlayerMovement()
	{
		int[] array = new int[6];
		if (!PlayerObj.bTraverseReverse && !PlayerObj.bTotalTarReached)
		{
			PlayerObj._curPos.x = PlayerObj.pointPos[PlayerObj.currentPathIndex, PlayerObj.nStartPoint, 0];
			PlayerObj._curPos.y = PlayerObj.pointPos[PlayerObj.currentPathIndex, PlayerObj.nStartPoint, 1];
			PlayerObj._curPos.z = PlayerObj.pointPos[PlayerObj.currentPathIndex, PlayerObj.nStartPoint, 2];
			PlayerObj._nextPos.x = PlayerObj.pointPos[PlayerObj.currentPathIndex, PlayerObj.nStartPoint + 1, 0];
			PlayerObj._nextPos.y = PlayerObj.pointPos[PlayerObj.currentPathIndex, PlayerObj.nStartPoint + 1, 1];
			PlayerObj._nextPos.z = PlayerObj.pointPos[PlayerObj.currentPathIndex, PlayerObj.nStartPoint + 1, 2];
			pathIDFrFindingPosBasedGivenDist = PlayerObj.currentPathIndex;
			StrtPosIDFrFindingPosBasedGivenDist = PlayerObj.nStartPoint + 1;
			if (PlayerObj.nStartPoint == 0)
			{
				array = PlayerObj.findPathBasedInput(PlayerObj.currentPathIndex, true, 0);
				if (array[0] != -1)
				{
					int num = -1;
					num = ((array[1] != 0) ? (array[1] - 1) : array[1]);
					PlayerObj._prevPos.x = PlayerObj.pointPos[array[0], num, 0];
					PlayerObj._prevPos.y = PlayerObj.pointPos[array[0], num, 1];
					PlayerObj._prevPos.z = PlayerObj.pointPos[array[0], num, 2];
				}
				else
				{
					float x = PlayerObj._nextPos.x - PlayerObj._curPos.x;
					float y = PlayerObj._nextPos.y - PlayerObj._curPos.y;
					float z = PlayerObj._nextPos.z - PlayerObj._curPos.z;
					Vector3 vector = new Vector3(x, y, z);
					vector.Normalize();
					float num2 = Vector3.Distance(PlayerObj._curPos, PlayerObj._nextPos);
					PlayerObj._prevPos = PlayerObj._curPos - vector * num2;
				}
				PlayerObj._nextToTarPos.x = PlayerObj.pointPos[PlayerObj.currentPathIndex, PlayerObj.nStartPoint + 2, 0];
				PlayerObj._nextToTarPos.y = PlayerObj.pointPos[PlayerObj.currentPathIndex, PlayerObj.nStartPoint + 2, 1];
				PlayerObj._nextToTarPos.z = PlayerObj.pointPos[PlayerObj.currentPathIndex, PlayerObj.nStartPoint + 2, 2];
			}
			else
			{
				PlayerObj._prevPos.x = PlayerObj.pointPos[PlayerObj.currentPathIndex, PlayerObj.nStartPoint - 1, 0];
				PlayerObj._prevPos.y = PlayerObj.pointPos[PlayerObj.currentPathIndex, PlayerObj.nStartPoint - 1, 1];
				PlayerObj._prevPos.z = PlayerObj.pointPos[PlayerObj.currentPathIndex, PlayerObj.nStartPoint - 1, 2];
				if (PlayerObj.nStartPoint + 2 < PlayerObj.pointCount[PlayerObj.currentPathIndex])
				{
					PlayerObj._nextToTarPos.x = PlayerObj.pointPos[PlayerObj.currentPathIndex, PlayerObj.nStartPoint + 2, 0];
					PlayerObj._nextToTarPos.y = PlayerObj.pointPos[PlayerObj.currentPathIndex, PlayerObj.nStartPoint + 2, 1];
					PlayerObj._nextToTarPos.z = PlayerObj.pointPos[PlayerObj.currentPathIndex, PlayerObj.nStartPoint + 2, 2];
				}
				else
				{
					array = PlayerObj.findPathBasedInput(PlayerObj.currentPathIndex, false, 0);
					if (array[0] != -1)
					{
						int num3 = -1;
						num3 = ((array[1] != 0) ? (array[1] - 1) : array[1]);
						PlayerObj._nextToTarPos.x = PlayerObj.pointPos[array[0], num3, 0];
						PlayerObj._nextToTarPos.y = PlayerObj.pointPos[array[0], num3, 1];
						PlayerObj._nextToTarPos.z = PlayerObj.pointPos[array[0], num3, 2];
					}
					else
					{
						float x2 = PlayerObj._nextPos.x - PlayerObj._curPos.x;
						float y2 = PlayerObj._nextPos.y - PlayerObj._curPos.y;
						float z2 = PlayerObj._nextPos.z - PlayerObj._curPos.z;
						Vector3 vector2 = new Vector3(x2, y2, z2);
						vector2.Normalize();
						float num4 = Vector3.Distance(PlayerObj._curPos, PlayerObj._nextPos);
						PlayerObj._nextToTarPos = PlayerObj._nextPos + vector2 * num4;
					}
				}
			}
		}
		else if (PlayerObj.bTraverseReverse && !PlayerObj.bTotalTarReached)
		{
			PlayerObj._curPos.x = PlayerObj.pointPos[PlayerObj.currentPathIndex, PlayerObj.nStartPoint - 1, 0];
			PlayerObj._curPos.y = PlayerObj.pointPos[PlayerObj.currentPathIndex, PlayerObj.nStartPoint - 1, 1];
			PlayerObj._curPos.z = PlayerObj.pointPos[PlayerObj.currentPathIndex, PlayerObj.nStartPoint - 1, 2];
			PlayerObj._nextPos.x = PlayerObj.pointPos[PlayerObj.currentPathIndex, PlayerObj.nStartPoint - 2, 0];
			PlayerObj._nextPos.y = PlayerObj.pointPos[PlayerObj.currentPathIndex, PlayerObj.nStartPoint - 2, 1];
			PlayerObj._nextPos.z = PlayerObj.pointPos[PlayerObj.currentPathIndex, PlayerObj.nStartPoint - 2, 2];
			pathIDFrFindingPosBasedGivenDist = PlayerObj.currentPathIndex;
			StrtPosIDFrFindingPosBasedGivenDist = PlayerObj.nStartPoint - 2;
			if (PlayerObj.pointCount[PlayerObj.currentPathIndex] == PlayerObj.nStartPoint)
			{
				array = PlayerObj.findPathBasedInput(PlayerObj.currentPathIndex, false, 0);
				if (array[0] != -1)
				{
					int num5 = -1;
					num5 = ((array[1] != 0) ? (array[1] - 1) : array[1]);
					PlayerObj._prevPos.x = PlayerObj.pointPos[array[0], num5, 0];
					PlayerObj._prevPos.y = PlayerObj.pointPos[array[0], num5, 1];
					PlayerObj._prevPos.z = PlayerObj.pointPos[array[0], num5, 2];
				}
				else
				{
					float x3 = PlayerObj._nextPos.x - PlayerObj._curPos.x;
					float y3 = PlayerObj._nextPos.y - PlayerObj._curPos.y;
					float z3 = PlayerObj._nextPos.z - PlayerObj._curPos.z;
					Vector3 vector3 = new Vector3(x3, y3, z3);
					vector3.Normalize();
					float num6 = Vector3.Distance(PlayerObj._curPos, PlayerObj._nextPos);
					PlayerObj._prevPos = PlayerObj._curPos - vector3 * num6;
				}
				PlayerObj._nextToTarPos.x = PlayerObj.pointPos[PlayerObj.currentPathIndex, PlayerObj.nStartPoint - 3, 0];
				PlayerObj._nextToTarPos.y = PlayerObj.pointPos[PlayerObj.currentPathIndex, PlayerObj.nStartPoint - 3, 1];
				PlayerObj._nextToTarPos.z = PlayerObj.pointPos[PlayerObj.currentPathIndex, PlayerObj.nStartPoint - 3, 2];
			}
			else
			{
				PlayerObj._prevPos.x = PlayerObj.pointPos[PlayerObj.currentPathIndex, PlayerObj.nStartPoint, 0];
				PlayerObj._prevPos.y = PlayerObj.pointPos[PlayerObj.currentPathIndex, PlayerObj.nStartPoint, 1];
				PlayerObj._prevPos.z = PlayerObj.pointPos[PlayerObj.currentPathIndex, PlayerObj.nStartPoint, 2];
				if (PlayerObj.nStartPoint - 3 > 0)
				{
					PlayerObj._nextToTarPos.x = PlayerObj.pointPos[PlayerObj.currentPathIndex, PlayerObj.nStartPoint - 3, 0];
					PlayerObj._nextToTarPos.y = PlayerObj.pointPos[PlayerObj.currentPathIndex, PlayerObj.nStartPoint - 3, 1];
					PlayerObj._nextToTarPos.z = PlayerObj.pointPos[PlayerObj.currentPathIndex, PlayerObj.nStartPoint - 3, 2];
				}
				else
				{
					array = PlayerObj.findPathBasedInput(PlayerObj.currentPathIndex, true, 0);
					if (array[0] != -1)
					{
						int num7 = -1;
						num7 = ((array[1] != 0) ? (array[1] - 1) : array[1]);
						PlayerObj._nextToTarPos.x = PlayerObj.pointPos[array[0], num7, 0];
						PlayerObj._nextToTarPos.y = PlayerObj.pointPos[array[0], num7, 1];
						PlayerObj._nextToTarPos.z = PlayerObj.pointPos[array[0], num7, 2];
					}
					else
					{
						float x4 = PlayerObj._nextPos.x - PlayerObj._curPos.x;
						float y4 = PlayerObj._nextPos.y - PlayerObj._curPos.y;
						float z4 = PlayerObj._nextPos.z - PlayerObj._curPos.z;
						Vector3 vector4 = new Vector3(x4, y4, z4);
						vector4.Normalize();
						float num8 = Vector3.Distance(PlayerObj._curPos, PlayerObj._nextPos);
						PlayerObj._nextToTarPos = PlayerObj._nextPos + vector4 * num8;
					}
				}
			}
		}
		if (!PlayerObj.bTotalTarReached)
		{
			if (!MovingInPath(PlayerObj._curPos, PlayerObj._nextPos, PlayerObj._prevPos, PlayerObj._nextToTarPos) && PlayerObj.bTargetReached)
			{
				PlayerObj.noOfTargetReached++;
				PlayerObj.bTargetReached = false;
				if (!PlayerObj.bTraverseReverse)
				{
					PlayerObj.nStartPoint++;
					PlayerObj.currentPoint++;
				}
				else
				{
					PlayerObj.nStartPoint--;
					PlayerObj.currentPoint--;
				}
				if (PlayerObj.waypoints.Length == PlayerObj.noOfTargetReached)
				{
					PlayerObj.bTotalTarReached = true;
				}
			}
		}
		else
		{
			if (!PlayerObj.bTotalTarReached)
			{
				return;
			}
			if (isAIplayerAvailable && bLevelUp)
			{
				int num9 = 0;
				nUserInput = UnityEngine.Random.Range(0, 3);
				int[] array2 = PlayerObj.findPathBasedInput(PlayerObj.currentPathIndex, PlayerObj.bTraverseReverse, nUserInput);
				if (array2[0] != IGT_AIPlayer.AI_PlayerObj.currentPathIndex)
				{
					array2[0] = -1;
				}
				while (array2[0] == -1 && num9 < 50)
				{
					nUserInput = UnityEngine.Random.Range(0, 3);
					array2 = PlayerObj.findPathBasedInput(PlayerObj.currentPathIndex, PlayerObj.bTraverseReverse, nUserInput);
					if (array2[0] != IGT_AIPlayer.AI_PlayerObj.currentPathIndex && num9 < 50)
					{
						array2[0] = -1;
					}
					num9++;
				}
			}
			else if ((Time.time - IGT_Constants.useKeyLifeStartTime < IGT_Constants.useKeyTotLifeTime || bInvisibleMode) && bReduceAlpha && nUserInput == 0)
			{
				nUserInput = selectpathNearToAI();
			}
			if (bAIMode || bAutoMaticModefrTesting)
			{
				nUserInput = selectpathNearToAI();
			}
			PlayerObj.nAdjpathToCurPath.Clear();
			for (int i = 0; i < 3; i++)
			{
				int[] array3 = new int[6];
				array3 = PlayerObj.findPathBasedInput(PlayerObj.currentPathIndex, PlayerObj.bTraverseReverse, i);
				PlayerObj.nAdjpathToCurPath.Add(array3[0]);
			}
			if (!PlayerObj.bTraverseReverse)
			{
				PlayerObj.prevPathIndex = PlayerObj.currentPathIndex;
				PlayerObj.bTravRevFrPrevPath = PlayerObj.bTraverseReverse;
				PlayerObj.prevPathID_LastPointID[0, 0] = PlayerObj.currentPathIndex;
				PlayerObj.prevPathID_LastPointID[0, 1] = PlayerObj.currentPoint;
				PlayerObj.prevPathID_BeforeLastPointID[0, 0] = PlayerObj.currentPathIndex;
				PlayerObj.prevPathID_BeforeLastPointID[0, 1] = PlayerObj.currentPoint - 1;
				bNxtPathAvail = PlayerObj.findNearstPath(PlayerObj.currentPathIndex, PlayerObj.waypoints[PlayerObj.currentPoint - 1].position, PlayerObj.waypoints[PlayerObj.currentPoint].position, nUserInput);
			}
			else
			{
				PlayerObj.prevPathIndex = PlayerObj.currentPathIndex;
				PlayerObj.bTravRevFrPrevPath = PlayerObj.bTraverseReverse;
				PlayerObj.prevPathID_LastPointID[0, 0] = PlayerObj.currentPathIndex;
				PlayerObj.prevPathID_LastPointID[0, 1] = PlayerObj.currentPoint - 1;
				PlayerObj.prevPathID_BeforeLastPointID[0, 0] = PlayerObj.currentPathIndex;
				PlayerObj.prevPathID_BeforeLastPointID[0, 1] = PlayerObj.currentPoint;
				bNxtPathAvail = PlayerObj.findNearstPath(PlayerObj.currentPathIndex, PlayerObj.waypoints[PlayerObj.currentPoint].position, PlayerObj.waypoints[PlayerObj.currentPoint - 1].position, nUserInput);
			}
			if (bNxtPathAvail)
			{
				PlayerObj.bMovingFinishdInPath = true;
				if (nUserInput != 1 && nUserInput != 2)
				{
					bHeroPathSelctionUptoReachAnotherPathEndFinishd = false;
				}
			}
			else if (bLevelUp && !bNxtPathAvail)
			{
				IGT_AnimStatesCntrler.nGameOverAnimFinshd = 1;
			}
			else if (HeroMovingInDeadEnds())
			{
				playSound(26);
				bGameOver = true;
				GameOver_AnimationSelection(3);
			}
			nUserInput = 0;
			playEnvironmentSound(0, 1, player.transform.position);
		}
	}

	private bool HeroMovingInDeadEnds()
	{
		Vector3 vector = new Vector3(PlayerObj.pointPos[PlayerObj.prevPathIndex, PlayerObj.prevPathID_LastPointID[0, 1], 0], PlayerObj.pointPos[PlayerObj.prevPathIndex, PlayerObj.prevPathID_LastPointID[0, 1], 1], PlayerObj.pointPos[PlayerObj.prevPathIndex, PlayerObj.prevPathID_LastPointID[0, 1], 2]);
		Vector3 vector2 = new Vector3(PlayerObj.pointPos[PlayerObj.prevPathIndex, PlayerObj.prevPathID_BeforeLastPointID[0, 1], 0], PlayerObj.pointPos[PlayerObj.prevPathIndex, PlayerObj.prevPathID_BeforeLastPointID[0, 1], 1], PlayerObj.pointPos[PlayerObj.prevPathIndex, PlayerObj.prevPathID_BeforeLastPointID[0, 1], 2]);
		Vector3 vector3 = new Vector3(vector.x - vector2.x, vector.y - vector2.y, vector.z - vector2.z);
		vector3.Normalize();
		Vector3 destPoint = vector + vector3 * 1f;
		PlayerCurPos += vector3 * PlayerObj.speed * Time.deltaTime;
		movingDirOfPlayer = new Vector3(PlayerCurPos.x - PlayerprevPos.x, PlayerCurPos.y - PlayerprevPos.y, PlayerCurPos.z - PlayerprevPos.z);
		movingDirOfPlayer.Normalize();
		crossProductVal = Vector3.Cross(Vector3.up, movingDirOfPlayer);
		nextExpectedPos = PlayerCurPos + crossProductVal * offset_Laneoffset;
		if (PlayerObj.isTargetReached(vector, PlayerCurPos, destPoint))
		{
			return true;
		}
		player.transform.position = nextExpectedPos;
		PlayerprevPos = PlayerCurPos;
		return false;
	}

	private int selectpathNearToAI()
	{
		float[] array = new float[3];
		Vector3 zero = Vector3.zero;
		int[] array2 = new int[6];
		float num = 9999f;
		int num2 = 0;
		if (!isAIplayerAvailable)
		{
			num2 = 0;
			array2 = PlayerObj.findPathBasedInput(PlayerObj.currentPathIndex, PlayerObj.bTraverseReverse, num2);
			if (array2[0] == -1)
			{
				num2 = 1;
				array2 = PlayerObj.findPathBasedInput(PlayerObj.currentPathIndex, PlayerObj.bTraverseReverse, num2);
				if (array2[0] == -1)
				{
					num2 = 2;
				}
			}
		}
		else
		{
			for (int i = 0; i < 3; i++)
			{
				array2 = PlayerObj.findPathBasedInput(PlayerObj.currentPathIndex, PlayerObj.bTraverseReverse, i);
				if (array2[0] == IGT_AIPlayer.AI_PlayerObj.currentPathIndex)
				{
					return i;
				}
			}
			Vector3 vector = new Vector3(IGT_AIPlayer.AI_Player.transform.position.x - player.transform.position.x, IGT_AIPlayer.AI_Player.transform.position.y - player.transform.position.y, IGT_AIPlayer.AI_Player.transform.position.z - player.transform.position.z);
			vector.Normalize();
			movingDirOfPlayer = new Vector3(PlayerCurPos.x - PlayerprevPos.x, PlayerCurPos.y - PlayerprevPos.y, PlayerCurPos.z - PlayerprevPos.z);
			movingDirOfPlayer.Normalize();
			Vector3 vector2 = PlayerObj.waypoints[PlayerObj.currentPoint].position + movingDirOfPlayer * 0.25f;
			for (int j = 0; j < 3; j++)
			{
				array2 = PlayerObj.findPathBasedInput(PlayerObj.currentPathIndex, PlayerObj.bTraverseReverse, j);
				if (array2[0] == -1)
				{
					array[j] = -1000f;
					continue;
				}
				int num3 = array2[1];
				num3 = ((array2[1] != 0) ? (array2[1] - 1) : array2[1]);
				Vector3 vector3 = new Vector3(PlayerObj.pointPos[array2[0], num3, 0], PlayerObj.pointPos[array2[0], num3, 1], PlayerObj.pointPos[array2[0], num3, 2]);
				zero = new Vector3(vector3.x - vector2.x, vector3.y - vector2.y, vector3.z - vector2.z);
				zero.Normalize();
				array[j] = Vector3.Angle(vector, zero);
			}
			for (int k = 0; k < 3; k++)
			{
				if (array[k] != -1000f && num >= array[k])
				{
					num = array[k];
					num2 = k;
				}
			}
		}
		return num2;
	}

	public Vector3 VelocityOptimization(float speed, Vector3 prevHeroPos, Vector3 calcHeroPos, float frameTime, ref float selectedDist, Vector3 prevPos, Vector3 curPos, Vector3 nextPos, Vector3 endPos)
	{
		if (frameTime == 0f)
		{
			return calcHeroPos;
		}
		float num = selectedDist;
		Vector3 vector = calcHeroPos;
		float num3;
		float num2 = (num3 = Vector3.Distance(curPos, nextPos) / 1000f);
		float num4 = 0f;
		for (int i = 0; i < 8; i++)
		{
			float num5 = Vector3.Distance(prevHeroPos, vector) / frameTime;
			float num6 = num5 / speed;
			if (num6 > 1.01f)
			{
				if (num4 != 0f && num4 > 0f)
				{
					num2 = num3;
				}
				else if (num4 < 0f)
				{
					num2 = ((!(num2 < num3 * 5f)) ? (num2 + num3) : (num2 * 2f));
				}
				num4 = -1f;
				num += num2 * num4;
			}
			else
			{
				if (!(num6 < 0.99f))
				{
					break;
				}
				if (num4 != 0f && num4 < 0f)
				{
					num2 = num3;
				}
				else if (num4 > 0f)
				{
					num2 = ((!(num2 < num3 * 5f)) ? (num2 + num3) : (num2 * 2f));
				}
				num4 = 1f;
				num += num2 * num4;
			}
			vector = PlayerObj.CurvePoints(prevPos, curPos, nextPos, endPos, num);
		}
		selectedDist = num;
		if (selectedDist < 0f)
		{
			selectedDist = 0f;
		}
		return vector;
	}

	private bool MovingInPath(Vector3 curpos, Vector3 nextpos, Vector3 prevpos, Vector3 endpos)
	{
		fDistBw2Points += PlayerObj.speed * Time.deltaTime;
		playerbeforePrevPos = PlayerprevPos;
		PlayerprevPos = PlayerCurPos;
		if (Vector3.Distance(curpos, nextpos) < fDistBw2Points)
		{
			fDistBw2Points -= Vector3.Distance(curpos, nextpos);
			NeededPos = PlayerObj.PositionBasedGivenDistBw2Points(pathIDFrFindingPosBasedGivenDist, StrtPosIDFrFindingPosBasedGivenDist, fDistBw2Points, PlayerObj.bTraverseReverse, nUserInput);
			fDistBw2Points = Vector3.Distance(NeededPos[0], NeededPos[2]);
			animPointVec_Spline = PlayerObj.CurvePoints(NeededPos[1], NeededPos[2], NeededPos[3], NeededPos[4], fDistBw2Points);
			PlayerCurPos = animPointVec_Spline;
			movingDirOfPlayer = new Vector3(PlayerCurPos.x - PlayerprevPos.x, PlayerCurPos.y - PlayerprevPos.y, PlayerCurPos.z - PlayerprevPos.z);
			movingDirOfPlayer.Normalize();
			crossProductVal = Vector3.Cross(Vector3.up, movingDirOfPlayer);
			nextExpectedPos = animPointVec_Spline + crossProductVal * offset_Laneoffset;
			fCurVelocity = Vector3.Distance(PlayerprevPos, PlayerCurPos) / Time.deltaTime;
			if (!(fCurVelocity > PlayerObj.speed * 0.98f) || !(fCurVelocity < PlayerObj.speed * 1.02f))
			{
				animPointVec_Spline = VelocityOptimization(PlayerObj.speed, PlayerprevPos, PlayerCurPos, Time.deltaTime, ref fDistBw2Points, NeededPos[1], NeededPos[2], NeededPos[3], NeededPos[4]);
				PlayerCurPos = animPointVec_Spline;
				movingDirOfPlayer = new Vector3(PlayerCurPos.x - PlayerprevPos.x, PlayerCurPos.y - PlayerprevPos.y, PlayerCurPos.z - PlayerprevPos.z);
				movingDirOfPlayer.Normalize();
				crossProductVal = Vector3.Cross(Vector3.up, movingDirOfPlayer);
				nextExpectedPos = animPointVec_Spline + crossProductVal * offset_Laneoffset;
			}
			PlayerObj.fDistFrmStrtPnt += Vector3.Distance(PlayerCurPos, PlayerprevPos);
			PlayerObj.fTotDistTraveled += Vector3.Distance(player.transform.position, nextExpectedPos);
			fCurVelocity = Vector3.Distance(PlayerprevPos, PlayerCurPos) / Time.deltaTime;
			player.transform.position = nextExpectedPos;
			PlayerObj.bTargetReached = true;
		}
		else
		{
			animPointVec_Spline = PlayerObj.CurvePoints(prevpos, curpos, nextpos, endpos, fDistBw2Points);
			PlayerCurPos = animPointVec_Spline;
			movingDirOfPlayer = new Vector3(PlayerCurPos.x - PlayerprevPos.x, PlayerCurPos.y - PlayerprevPos.y, PlayerCurPos.z - PlayerprevPos.z);
			movingDirOfPlayer.Normalize();
			crossProductVal = Vector3.Cross(Vector3.up, movingDirOfPlayer);
			nextExpectedPos = animPointVec_Spline + crossProductVal * offset_Laneoffset;
			fCurVelocity = Vector3.Distance(PlayerprevPos, PlayerCurPos) / Time.deltaTime;
			if (!(fCurVelocity > PlayerObj.speed * 0.98f) || !(fCurVelocity < PlayerObj.speed * 1.02f))
			{
				animPointVec_Spline = VelocityOptimization(PlayerObj.speed, PlayerprevPos, PlayerCurPos, Time.deltaTime, ref fDistBw2Points, prevpos, curpos, nextpos, endpos);
				PlayerCurPos = animPointVec_Spline;
				movingDirOfPlayer = new Vector3(PlayerCurPos.x - PlayerprevPos.x, PlayerCurPos.y - PlayerprevPos.y, PlayerCurPos.z - PlayerprevPos.z);
				movingDirOfPlayer.Normalize();
				crossProductVal = Vector3.Cross(Vector3.up, movingDirOfPlayer);
				nextExpectedPos = animPointVec_Spline + crossProductVal * offset_Laneoffset;
			}
			PlayerObj.fDistFrmStrtPnt += Vector3.Distance(PlayerCurPos, PlayerprevPos);
			PlayerObj.fTotDistTraveled += Vector3.Distance(player.transform.position, nextExpectedPos);
			fCurVelocity = Vector3.Distance(PlayerprevPos, PlayerCurPos) / Time.deltaTime;
			player.transform.position = nextExpectedPos;
			if (fDistBw2Points + fDistBw2Points / 2f < Vector3.Distance(nextpos, curpos))
			{
				player.transform.LookAt(PlayerObj.CurvePoints(prevpos, curpos, nextpos, endpos, fDistBw2Points + fDistBw2Points / 2f) + crossProductVal * offset_Laneoffset);
			}
			else
			{
				float givenDistance = fDistBw2Points + fDistBw2Points / 2f - Vector3.Distance(nextpos, curpos);
				NeededPos = PlayerObj.PositionBasedGivenDistBw2Points(pathIDFrFindingPosBasedGivenDist, StrtPosIDFrFindingPosBasedGivenDist, givenDistance, PlayerObj.bTraverseReverse, nUserInput);
				Vector3 rhs = new Vector3(NeededPos[0].x - NeededPos[1].x, NeededPos[0].y - NeededPos[1].y, NeededPos[0].z - NeededPos[1].z);
				rhs.Normalize();
				Vector3 vector = Vector3.Cross(Vector3.up, rhs);
				player.transform.LookAt(PlayerObj.CurvePoints(NeededPos[1], NeededPos[2], NeededPos[3], NeededPos[4], Vector3.Distance(NeededPos[0], NeededPos[2])) + vector * offset_Laneoffset);
			}
		}
		fAvgSpdFluctuation += PlayerObj.speed - Vector3.Distance(PlayerprevPos, PlayerCurPos) / Time.deltaTime;
		return false;
	}

	private bool MovingInBetweenPath(Vector3 curpos, Vector3 nextpos, Vector3 prevpos, Vector3 endpos)
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 1.5f;
		if (PlayerObj.nAdjpathToCurPath.Count > 0 && PlayerObj.currentPathIndex == PlayerObj.nAdjpathToCurPath[0])
		{
			num4 = 1f;
		}
		fDistBw2Points += num4 * PlayerObj.speed * Time.deltaTime;
		Vector3 rhs = new Vector3(curpos.x - prevpos.x, curpos.y - prevpos.y, curpos.z - prevpos.z);
		rhs.Normalize();
		crossProductVal = Vector3.Cross(Vector3.up, rhs);
		Vector3 prev = prevpos + crossProductVal * offset_Laneoffset;
		Vector3 vector = curpos + crossProductVal * offset_Laneoffset;
		rhs = new Vector3(endpos.x - nextpos.x, endpos.y - nextpos.y, endpos.z - nextpos.z);
		rhs.Normalize();
		crossProductVal = Vector3.Cross(Vector3.up, rhs);
		Vector3 vector2 = nextpos + crossProductVal * offset_Laneoffset;
		Vector3 end = endpos + crossProductVal * offset_Laneoffset;
		playerbeforePrevPos = PlayerprevPos;
		PlayerprevPos = PlayerCurPos;
		if (Vector3.Distance(vector, vector2) < fDistBw2Points)
		{
			float givenDistance = fDistBw2Points - Vector3.Distance(vector, vector2);
			NeededPos = PlayerObj.PositionBasedGivenDistBw2Points(pathIDFrFindingPosBasedGivenDist, StrtPosIDFrFindingPosBasedGivenDist, givenDistance, PlayerObj.bTraverseReverse, nUserInput);
			fDistBw2Points = Vector3.Distance(NeededPos[0], NeededPos[2]);
			rhs = new Vector3(NeededPos[2].x - NeededPos[1].x, NeededPos[2].y - NeededPos[1].y, NeededPos[2].z - NeededPos[1].z);
			rhs.Normalize();
			crossProductVal = Vector3.Cross(Vector3.up, rhs);
			prev = NeededPos[1] + crossProductVal * offset_Laneoffset;
			vector = NeededPos[2] + crossProductVal * offset_Laneoffset;
			rhs = new Vector3(NeededPos[4].x - NeededPos[3].x, NeededPos[4].y - NeededPos[3].y, NeededPos[4].z - NeededPos[3].z);
			rhs.Normalize();
			crossProductVal = Vector3.Cross(Vector3.up, rhs);
			vector2 = NeededPos[3] + crossProductVal * offset_Laneoffset;
			end = NeededPos[4] + crossProductVal * offset_Laneoffset;
			rhs = new Vector3(NeededPos[0].x - NeededPos[2].x, NeededPos[0].y - NeededPos[2].y, NeededPos[0].z - NeededPos[2].z);
			rhs.Normalize();
			crossProductVal = Vector3.Cross(Vector3.up, rhs);
			Vector3 a = NeededPos[0] + crossProductVal * offset_Laneoffset;
			num2 = Vector3.Distance(curpos, nextpos);
			num = Vector3.Distance(vector, vector2);
			num3 = num2 * fDistBw2Points / num;
			animPointVec_Spline = MovingInBtwPathsUsingEqualDist(NeededPos[1], NeededPos[2], NeededPos[3], NeededPos[4], fDistBw2Points);
			PlayerCurPos = animPointVec_Spline;
			nextExpectedPos = MovingInBtwPathsUsingEqualDist(prev, vector, vector2, end, Vector3.Distance(a, vector));
			PlayerObj.fTotDistTraveled += Vector3.Distance(player.transform.position, nextExpectedPos);
			fCurVelocity = Vector3.Distance(nextExpectedPos, player.transform.position) / Time.deltaTime;
			player.transform.position = nextExpectedPos;
			PlayerObj.bMovingFinishdInPath = false;
		}
		else
		{
			num2 = Vector3.Distance(curpos, nextpos);
			num = Vector3.Distance(vector, vector2);
			num3 = num2 * fDistBw2Points / num;
			animPointVec_Spline = MovingInBtwPathsUsingEqualDist(prevpos, curpos, nextpos, endpos, num3);
			PlayerCurPos = animPointVec_Spline;
			nextExpectedPos = MovingInBtwPathsUsingEqualDist(prev, vector, vector2, end, fDistBw2Points);
			PlayerObj.fTotDistTraveled += Vector3.Distance(player.transform.position, nextExpectedPos);
			fCurVelocity = Vector3.Distance(nextExpectedPos, player.transform.position) / Time.deltaTime;
			player.transform.position = nextExpectedPos;
			if (fDistBw2Points + fDistBw2Points / 2f < Vector3.Distance(vector2, vector))
			{
				player.transform.LookAt(MovingInBtwPathsUsingEqualDist(prev, vector, vector2, end, fDistBw2Points + fDistBw2Points / 2f));
			}
			else
			{
				float givenDistance2 = fDistBw2Points + fDistBw2Points / 2f - Vector3.Distance(vector2, vector);
				NeededPos = PlayerObj.PositionBasedGivenDistBw2Points(pathIDFrFindingPosBasedGivenDist, StrtPosIDFrFindingPosBasedGivenDist, givenDistance2, PlayerObj.bTraverseReverse, nUserInput);
				rhs = new Vector3(NeededPos[2].x - NeededPos[1].x, NeededPos[2].y - NeededPos[1].y, NeededPos[2].z - NeededPos[1].z);
				rhs.Normalize();
				crossProductVal = Vector3.Cross(Vector3.up, rhs);
				prev = NeededPos[1] + crossProductVal * offset_Laneoffset;
				vector = NeededPos[2] + crossProductVal * offset_Laneoffset;
				rhs = new Vector3(NeededPos[4].x - NeededPos[3].x, NeededPos[4].y - NeededPos[3].y, NeededPos[4].z - NeededPos[3].z);
				rhs.Normalize();
				crossProductVal = Vector3.Cross(Vector3.up, rhs);
				vector2 = NeededPos[3] + crossProductVal * offset_Laneoffset;
				end = NeededPos[4] + crossProductVal * offset_Laneoffset;
				rhs = new Vector3(NeededPos[0].x - NeededPos[2].x, NeededPos[0].y - NeededPos[2].y, NeededPos[0].z - NeededPos[2].z);
				rhs.Normalize();
				crossProductVal = Vector3.Cross(Vector3.up, rhs);
				Vector3 a2 = NeededPos[0] + crossProductVal * offset_Laneoffset;
				player.transform.LookAt(MovingInBtwPathsUsingEqualDist(prev, vector, vector2, end, Vector3.Distance(a2, vector)));
			}
		}
		fAvgSpdFluctuation += PlayerObj.speed - Vector3.Distance(PlayerprevPos, PlayerCurPos) / Time.deltaTime;
		return false;
	}

	public Vector3 MovingInBtwPathsUsingMidPoint(Vector3 prev, Vector3 cur, Vector3 next, Vector3 end, float dist)
	{
		Vector3 vector = new Vector3(cur.x - prev.x, cur.y - prev.y, cur.z - prev.z);
		vector.Normalize();
		Vector3 vector2 = new Vector3(next.x - end.x, next.y - end.y, next.z - end.z);
		vector2.Normalize();
		Vector3 vector3 = (vector + vector2) * 0.5f;
		Vector3 vector4 = IGT_Math.MidPointforTwo3dPoints(cur, next);
		float num = Vector3.Distance(cur, next);
		Vector3 vector5 = vector4 + vector3 * (num * 0.15f);
		if (dist > Vector3.Distance(cur, vector5))
		{
			float dist2 = dist - Vector3.Distance(cur, vector5);
			return PlayerObj.CurvePoints(cur, vector5, next, end, dist2);
		}
		return PlayerObj.CurvePoints(prev, cur, vector5, next, dist);
	}

	public Vector3 MovingInBtwPathsUsingEqualDist(Vector3 prev, Vector3 cur, Vector3 next, Vector3 end, float dist)
	{
		Vector3 vector = new Vector3(prev.x - cur.x, prev.y - cur.y, prev.z - cur.z);
		vector.Normalize();
		Vector3 vector2 = new Vector3(end.x - next.x, end.y - next.y, end.z - next.z);
		vector2.Normalize();
		float num = Vector3.Distance(cur, next);
		Vector3 prevPt = prev + vector * (num * 1f);
		Vector3 nextPt = end + vector2 * (num * 1f);
		return PlayerObj.CurvePoints(prevPt, cur, next, nextPt, dist);
	}

	private void vehicleMovementsChecking()
	{
		for (int i = 0; i < PlayerObj.pObj.movingObj.Count; i++)
		{
			if (!PlayerObj.pObj.movingObj[i].bvehicleMoveEnabled && !PlayerObj.pObj.movingObj[i].bdataInit && PlayerObj.fDistFrmStrtPnt >= PlayerObj.pathLength[PlayerObj.currentPathIndex] * 0.4f && PlayerObj.nAdjPIDs.Contains(PlayerObj.pObj.movingObj[i].nPathId) && PlayerObj.pObj.movingObj[i].VehicleDestPathID != PlayerObj.currentPathIndex && Vector3.Distance(PlayerObj.pObj.movingObj[i].VehicleAnimPoint, player.transform.position) > 15f)
			{
				PlayerObj.pObj.movingObj[i].bvehicleMoveEnabled = true;
				float num = PlayerObj.pathLength[PlayerObj.pObj.movingObj[i].nPathId] - PlayerObj.pObj.movingObj[i].fDistFrmStrtPnt;
				float num2 = num / PlayerObj.pObj.movingObj[i].fVechicleSpeed;
				float num3 = PlayerObj.pathLength[PlayerObj.currentPathIndex] - PlayerObj.fDistFrmStrtPnt;
				float num4 = num3 / PlayerObj.speed;
				if (num2 + 2f >= num4)
				{
					PlayerObj.pObj.movingObj[i].bvehicleMoveEnabled = false;
				}
			}
			if (PlayerObj.pObj.movingObj[i].bvehicleMoveEnabled && !PlayerObj.pObj.movingObj[i].bvehicleReachd)
			{
				UpdateVehicleInfo(i);
			}
		}
	}

	public void UpdateVehicleInfo(int objID)
	{
		if (PlayerObj.pObj.movingObj[objID].bvehicleReachd || PlayerObj.pObj.movingObj[objID].VehicleDestPathID == -1)
		{
			return;
		}
		Vector3 vector = PlayerObj.pObj.movingObj[objID].ObjPos;
		Vector3 vector2 = PlayerObj.pObj.movingObj[objID].VehicleDestPos;
		Vector3 vector3 = Vector3.zero;
		Vector3 vector4 = Vector3.zero;
		if (!PlayerObj.pObj.movingObj[objID].bVehicleCrossedCurPath && PlayerObj.pObj.movingObj[objID].NoOfTarReached != 0)
		{
			vector = new Vector3(PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].nPathId, PlayerObj.pObj.movingObj[objID].CurPointID, 0], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].nPathId, PlayerObj.pObj.movingObj[objID].CurPointID, 1], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].nPathId, PlayerObj.pObj.movingObj[objID].CurPointID, 2]);
			vector2 = new Vector3(PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].nPathId, PlayerObj.pObj.movingObj[objID].NextPointID, 0], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].nPathId, PlayerObj.pObj.movingObj[objID].NextPointID, 1], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].nPathId, PlayerObj.pObj.movingObj[objID].NextPointID, 2]);
			if (!PlayerObj.pObj.movingObj[objID].bTravRev)
			{
				vector3 = new Vector3(PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].nPathId, PlayerObj.pObj.movingObj[objID].CurPointID - 1, 0], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].nPathId, PlayerObj.pObj.movingObj[objID].CurPointID - 1, 1], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].nPathId, PlayerObj.pObj.movingObj[objID].CurPointID - 1, 2]);
				vector4 = ((PlayerObj.pObj.movingObj[objID].NextPointID + 1 >= PlayerObj.pointCount[PlayerObj.pObj.movingObj[objID].nPathId]) ? new Vector3(PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].VehicleDestPathID, PlayerObj.pObj.movingObj[objID].VehicleDestPathCurPointID, 0], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].VehicleDestPathID, PlayerObj.pObj.movingObj[objID].VehicleDestPathCurPointID, 1], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].VehicleDestPathID, PlayerObj.pObj.movingObj[objID].VehicleDestPathCurPointID, 2]) : new Vector3(PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].nPathId, PlayerObj.pObj.movingObj[objID].NextPointID + 1, 0], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].nPathId, PlayerObj.pObj.movingObj[objID].NextPointID + 1, 1], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].nPathId, PlayerObj.pObj.movingObj[objID].NextPointID + 1, 2]));
			}
			else
			{
				vector3 = new Vector3(PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].nPathId, PlayerObj.pObj.movingObj[objID].CurPointID + 1, 0], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].nPathId, PlayerObj.pObj.movingObj[objID].CurPointID + 1, 1], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].nPathId, PlayerObj.pObj.movingObj[objID].CurPointID + 1, 2]);
				vector4 = ((PlayerObj.pObj.movingObj[objID].NextPointID - 1 < 0) ? new Vector3(PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].VehicleDestPathID, 0, 0], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].VehicleDestPathID, 0, 1], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].VehicleDestPathID, 0, 2]) : new Vector3(PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].nPathId, PlayerObj.pObj.movingObj[objID].NextPointID - 1, 0], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].nPathId, PlayerObj.pObj.movingObj[objID].NextPointID - 1, 1], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].nPathId, PlayerObj.pObj.movingObj[objID].NextPointID - 1, 2]));
			}
		}
		else if (PlayerObj.pObj.movingObj[objID].bVehicleCrossedCurPath && PlayerObj.pObj.movingObj[objID].NoOfTarReached == 0)
		{
			vector = new Vector3(PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].nPathId, PlayerObj.pObj.movingObj[objID].NextPointID, 0], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].nPathId, PlayerObj.pObj.movingObj[objID].NextPointID, 1], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].nPathId, PlayerObj.pObj.movingObj[objID].NextPointID, 2]);
			vector2 = new Vector3(PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].VehicleDestPathID, PlayerObj.pObj.movingObj[objID].VehicleDestPathCurPointID, 0], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].VehicleDestPathID, PlayerObj.pObj.movingObj[objID].VehicleDestPathCurPointID, 1], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].VehicleDestPathID, PlayerObj.pObj.movingObj[objID].VehicleDestPathCurPointID, 2]);
			vector4 = new Vector3(PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].VehicleDestPathID, PlayerObj.pObj.movingObj[objID].VehicleDestPathNextPntID, 0], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].VehicleDestPathID, PlayerObj.pObj.movingObj[objID].VehicleDestPathNextPntID, 1], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].VehicleDestPathID, PlayerObj.pObj.movingObj[objID].VehicleDestPathNextPntID, 2]);
			vector3 = new Vector3(PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].nPathId, PlayerObj.pObj.movingObj[objID].CurPointID, 0], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].nPathId, PlayerObj.pObj.movingObj[objID].CurPointID, 1], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].nPathId, PlayerObj.pObj.movingObj[objID].CurPointID, 2]);
		}
		else if (PlayerObj.pObj.movingObj[objID].bVehicleCrossedCurPath && PlayerObj.pObj.movingObj[objID].NoOfTarReached != 0)
		{
			vector = new Vector3(PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].VehicleDestPathID, PlayerObj.pObj.movingObj[objID].VehicleDestPathCurPointID, 0], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].VehicleDestPathID, PlayerObj.pObj.movingObj[objID].VehicleDestPathCurPointID, 1], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].VehicleDestPathID, PlayerObj.pObj.movingObj[objID].VehicleDestPathCurPointID, 2]);
			vector2 = new Vector3(PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].VehicleDestPathID, PlayerObj.pObj.movingObj[objID].VehicleDestPathNextPntID, 0], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].VehicleDestPathID, PlayerObj.pObj.movingObj[objID].VehicleDestPathNextPntID, 1], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].VehicleDestPathID, PlayerObj.pObj.movingObj[objID].VehicleDestPathNextPntID, 2]);
			vector3 = ((PlayerObj.pObj.movingObj[objID].NoOfTarReached == 1) ? new Vector3(PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].nPathId, PlayerObj.pObj.movingObj[objID].NextPointID, 0], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].nPathId, PlayerObj.pObj.movingObj[objID].NextPointID, 1], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].nPathId, PlayerObj.pObj.movingObj[objID].NextPointID, 2]) : (PlayerObj.pObj.movingObj[objID].bVehicleDestPathTravRev ? new Vector3(PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].VehicleDestPathID, PlayerObj.pObj.movingObj[objID].VehicleDestPathCurPointID + 1, 0], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].VehicleDestPathID, PlayerObj.pObj.movingObj[objID].VehicleDestPathCurPointID + 1, 1], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].VehicleDestPathID, PlayerObj.pObj.movingObj[objID].VehicleDestPathCurPointID + 1, 2]) : new Vector3(PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].VehicleDestPathID, PlayerObj.pObj.movingObj[objID].VehicleDestPathCurPointID - 1, 0], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].VehicleDestPathID, PlayerObj.pObj.movingObj[objID].VehicleDestPathCurPointID - 1, 1], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].VehicleDestPathID, PlayerObj.pObj.movingObj[objID].VehicleDestPathCurPointID - 1, 2])));
			vector4 = (PlayerObj.pObj.movingObj[objID].bVehicleDestPathTravRev ? new Vector3(PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].VehicleDestPathID, PlayerObj.pObj.movingObj[objID].VehicleDestPathNextPntID - 1, 0], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].VehicleDestPathID, PlayerObj.pObj.movingObj[objID].VehicleDestPathNextPntID - 1, 1], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].VehicleDestPathID, PlayerObj.pObj.movingObj[objID].VehicleDestPathNextPntID - 1, 2]) : new Vector3(PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].VehicleDestPathID, PlayerObj.pObj.movingObj[objID].VehicleDestPathNextPntID + 1, 0], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].VehicleDestPathID, PlayerObj.pObj.movingObj[objID].VehicleDestPathNextPntID + 1, 1], PlayerObj.pointPos[PlayerObj.pObj.movingObj[objID].VehicleDestPathID, PlayerObj.pObj.movingObj[objID].VehicleDestPathNextPntID + 1, 2]));
		}
		Vector3 zero = Vector3.zero;
		Vector3 zero2 = Vector3.zero;
		Vector3 zero3 = Vector3.zero;
		Vector3 vector5 = vector;
		Vector3 prev = vector3;
		Vector3 vector6 = vector2;
		Vector3 end = vector4;
		PlayerObj.pObj.movingObj[objID].fdistBtw2points += PlayerObj.pObj.movingObj[objID].fVechicleSpeed * Time.deltaTime;
		Vector3 vehicleAnimPoint = PlayerObj.pObj.movingObj[objID].VehicleAnimPoint;
		zero3 = MovingInBtwPathsUsingMidPoint(prev, vector5, vector6, end, PlayerObj.pObj.movingObj[objID].fdistBtw2points);
		float x = vector.x - vector3.x;
		float y = vector.y - vector3.y;
		float z = vector.z - vector3.z;
		zero = new Vector3(x, y, z);
		zero.Normalize();
		zero2 = Vector3.Cross(Vector3.up, zero);
		PlayerObj.pObj.movingObj[objID].VehicleAnimPoint = zero3 + zero2 * PlayerObj.pObj.movingObj[objID].fOffset;
		IGT_MovingObjPlacing.MovObjList.ElementAt(objID).transform.position = PlayerObj.pObj.movingObj[objID].VehicleAnimPoint;
		PlayerObj.pObj.movingObj[objID].fDistFrmStrtPnt += Vector3.Distance(vehicleAnimPoint, PlayerObj.pObj.movingObj[objID].VehicleAnimPoint);
		PlayerObj.pObj.movingObj[objID].objRot = PlayerObj.findRotation(PlayerObj.pObj.movingObj[objID].VehicleAnimPoint, vehicleAnimPoint);
		float y2 = Mathf.LerpAngle(IGT_MovingObjPlacing.MovObjList.ElementAt(objID).transform.localEulerAngles.y, PlayerObj.pObj.movingObj[objID].objRot.z, 10f * Time.deltaTime);
		IGT_MovingObjPlacing.MovObjList.ElementAt(objID).transform.localEulerAngles = new Vector3(0f, y2, 0f);
		if (Vector3.Distance(vector, vector2) < PlayerObj.pObj.movingObj[objID].fdistBtw2points)
		{
			PlayerObj.pObj.movingObj[objID].fdistBtw2points = PlayerObj.pObj.movingObj[objID].fdistBtw2points - Vector3.Distance(vector5, vector6);
			PlayerObj.pObj.movingObj[objID].NoOfTarReached = PlayerObj.pObj.movingObj[objID].NoOfTarReached + 1;
			if (!PlayerObj.pObj.movingObj[objID].bVehicleCrossedCurPath)
			{
				if (PlayerObj.pointCount[PlayerObj.pObj.movingObj[objID].nPathId] == PlayerObj.pObj.movingObj[objID].NoOfTarReached)
				{
					PlayerObj.pObj.movingObj[objID].bVehicleCrossedCurPath = true;
					PlayerObj.pObj.movingObj[objID].NoOfTarReached = 0;
					PlayerObj.pObj.movingObj[objID].fDistFrmStrtPnt = 0f;
				}
				else if (!PlayerObj.pObj.movingObj[objID].bTravRev)
				{
					PlayerObj.pObj.movingObj[objID].CurPointID++;
					PlayerObj.pObj.movingObj[objID].NextPointID++;
				}
				else
				{
					PlayerObj.pObj.movingObj[objID].CurPointID--;
					PlayerObj.pObj.movingObj[objID].NextPointID--;
				}
			}
			else if (PlayerObj.pointCount[PlayerObj.pObj.movingObj[objID].VehicleDestPathID] - 8 <= PlayerObj.pObj.movingObj[objID].NoOfTarReached)
			{
				PlayerObj.pObj.movingObj[objID].bvehicleReachd = true;
				PlayerObj.pObj.movingObj[objID].bvehicleMoveEnabled = false;
				PlayerObj.pObj.movingObj[objID].bdataInit = true;
				PlayerObj.pObj.movingObj[objID].VehicleReachTime = Time.time;
				PlayerObj.pObj.movingObj[objID].VehicleAnimPoint = PlayerObj.pObj.movingObj[objID].VehicleAnimPoint;
				PlayerObj.pObj.movingObj[objID].objRot = new Vector3(IGT_MovingObjPlacing.MovObjList.ElementAt(objID).transform.localEulerAngles.x, IGT_MovingObjPlacing.MovObjList.ElementAt(objID).transform.localEulerAngles.z, IGT_MovingObjPlacing.MovObjList.ElementAt(objID).transform.localEulerAngles.y);
			}
			else
			{
				if (PlayerObj.pObj.movingObj[objID].NoOfTarReached == 1)
				{
					return;
				}
				if (!PlayerObj.pObj.movingObj[objID].bVehicleDestPathTravRev)
				{
					PlayerObj.pObj.movingObj[objID].VehicleDestPathCurPointID++;
					PlayerObj.pObj.movingObj[objID].VehicleDestPathNextPntID++;
				}
				else
				{
					PlayerObj.pObj.movingObj[objID].VehicleDestPathCurPointID--;
					PlayerObj.pObj.movingObj[objID].VehicleDestPathNextPntID--;
				}
			}
		}
		int num = Vehicle_Objects_Collision(objID);
		if (num == 10 || num == 2)
		{
			PlayerObj.pObj.movingObj[objID].bvehicleReachd = true;
			PlayerObj.pObj.movingObj[objID].bvehicleMoveEnabled = false;
			PlayerObj.pObj.movingObj[objID].bdataInit = true;
			PlayerObj.pObj.movingObj[objID].VehicleReachTime = Time.time;
			PlayerObj.pObj.movingObj[objID].VehicleAnimPoint = PlayerObj.pObj.movingObj[objID].VehicleAnimPoint;
			PlayerObj.pObj.movingObj[objID].objRot = new Vector3(IGT_MovingObjPlacing.MovObjList.ElementAt(objID).transform.localEulerAngles.x, IGT_MovingObjPlacing.MovObjList.ElementAt(objID).transform.localEulerAngles.z, IGT_MovingObjPlacing.MovObjList.ElementAt(objID).transform.localEulerAngles.y);
		}
	}

	public int Vehicle_Objects_Collision(int VehicleID)
	{
		float num = PlayerObj.pObj.movingObj[VehicleID].fDistFrmStrtPnt + 1.5f;
		if (num < 6f)
		{
			return 11;
		}
		float num2 = 0f;
		int num3;
		bool flag;
		if (PlayerObj.pObj.movingObj[VehicleID].bVehicleCrossedCurPath)
		{
			num3 = PlayerObj.pObj.movingObj[VehicleID].VehicleDestPathID;
			flag = PlayerObj.pObj.movingObj[VehicleID].bVehicleDestPathTravRev;
		}
		else
		{
			num3 = PlayerObj.pObj.movingObj[VehicleID].nPathId;
			flag = PlayerObj.pObj.movingObj[VehicleID].bTravRev;
		}
		List<IGT_ObjInfo> list = PlayerObj.objDetInGivenPath(num3);
		for (int i = 0; i < list.Count; i++)
		{
			num2 = (flag ? (PlayerObj.pathLength[num3] - list[i].fDistFrmStrtPnt) : list[i].fDistFrmStrtPnt);
			if (!(num <= num2 + list[i].fWidth / 2f) || !(num >= num2 - list[i].fWidth / 2f))
			{
				continue;
			}
			if (list[i].objType == 2 && !list[i].bDisabled)
			{
				return 2;
			}
			if (list[i].objPlaceType == 1 || list[i].objType == 5)
			{
				if (list[i].objType == 9 || list[i].objType == 6 || list[i].objType == 4 || (list[i].objType == 3 && list[i].objID == PlayerObj.pObj.movingObj[VehicleID].objID))
				{
					return 11;
				}
				return 10;
			}
		}
		return 11;
	}

	public void NextAIplayerDataSelectionAftrLevelUp()
	{
		float num = findOffsetforPurseandAIinLevelup();
		UnityEngine.Object.Destroy(GameObject.FindGameObjectWithTag(IGT_Constants.AIPlayerString + nAIPlayerIndex).GetComponent<IGT_AIPlayer>());
		UnityEngine.Object.Destroy(GameObject.FindGameObjectWithTag(IGT_Constants.AIPlayerString + nAIPlayerIndex).GetComponent<IGT_AIPlayerAnimStateCtrl>());
		UnityEngine.Object.Destroy(GameObject.FindGameObjectWithTag(IGT_Constants.AIPlayerString + nAIPlayerIndex).GetComponent<BoxCollider>());
		UnityEngine.Object.Destroy(GameObject.FindGameObjectWithTag(IGT_Constants.AIPlayerString + nAIPlayerIndex), 5f);
		IGT_AIPlayer.AI_Player.tag = "Untagged";
		int num2;
		bool flag;
		int num3;
		int noOfTargetReached;
		Vector3 vector;
		float num4;
		if (!PlayerObj.bMovingFinishdInPath)
		{
			num2 = PlayerObj.currentPathIndex;
			flag = PlayerObj.bTraverseReverse;
			if (!flag)
			{
				if (PlayerObj.nStartPoint - 3 > 0)
				{
					num3 = PlayerObj.nStartPoint - 3;
					noOfTargetReached = num3 + 1;
					vector = new Vector3(PlayerObj.pointPos[num2, num3, 0], PlayerObj.pointPos[num2, num3, 1], PlayerObj.pointPos[num2, num3, 2]);
					num4 = PlayerObj.objDistFrmStrtPoint(num2, num3, vector);
				}
				else
				{
					num2 = PlayerObj.prevPathIndex;
					flag = PlayerObj.bTravRevFrPrevPath;
					if (!flag)
					{
						num3 = PlayerObj.pointCount[num2] - 2;
						noOfTargetReached = num3 + 1;
						vector = new Vector3(PlayerObj.pointPos[num2, num3, 0], PlayerObj.pointPos[num2, num3, 1], PlayerObj.pointPos[num2, num3, 2]);
						num4 = PlayerObj.objDistFrmStrtPoint(num2, num3, vector);
					}
					else
					{
						num3 = 3;
						noOfTargetReached = PlayerObj.pointCount[num2] - num3;
						vector = new Vector3(PlayerObj.pointPos[num2, num3, 0], PlayerObj.pointPos[num2, num3, 1], PlayerObj.pointPos[num2, num3, 2]);
						num4 = PlayerObj.objDistFrmStrtPoint(num2, num3, vector);
						num4 = PlayerObj.pathLength[num2] - num4;
					}
				}
			}
			else if (PlayerObj.nStartPoint + 3 < PlayerObj.pointCount[PlayerObj.currentPathIndex])
			{
				num3 = PlayerObj.nStartPoint + 3;
				noOfTargetReached = PlayerObj.pointCount[num2] - num3;
				vector = new Vector3(PlayerObj.pointPos[num2, num3, 0], PlayerObj.pointPos[num2, num3, 1], PlayerObj.pointPos[num2, num3, 2]);
				num4 = PlayerObj.objDistFrmStrtPoint(num2, num3, vector);
				num4 = PlayerObj.pathLength[num2] - num4;
			}
			else
			{
				num2 = PlayerObj.prevPathIndex;
				flag = PlayerObj.bTravRevFrPrevPath;
				if (!flag)
				{
					num3 = PlayerObj.pointCount[num2] - 2;
					noOfTargetReached = num3 + 1;
					vector = new Vector3(PlayerObj.pointPos[num2, num3, 0], PlayerObj.pointPos[num2, num3, 1], PlayerObj.pointPos[num2, num3, 2]);
					num4 = PlayerObj.objDistFrmStrtPoint(num2, num3, vector);
				}
				else
				{
					num3 = 3;
					noOfTargetReached = PlayerObj.pointCount[num2] - num3;
					vector = new Vector3(PlayerObj.pointPos[num2, num3, 0], PlayerObj.pointPos[num2, num3, 1], PlayerObj.pointPos[num2, num3, 2]);
					num4 = PlayerObj.objDistFrmStrtPoint(num2, num3, vector);
					num4 = PlayerObj.pathLength[num2] - num4;
				}
			}
		}
		else
		{
			num2 = PlayerObj.prevPathIndex;
			flag = PlayerObj.bTravRevFrPrevPath;
			if (!flag)
			{
				num3 = PlayerObj.pointCount[num2] - 2;
				noOfTargetReached = num3 + 1;
				vector = new Vector3(PlayerObj.pointPos[num2, num3, 0], PlayerObj.pointPos[num2, num3, 1], PlayerObj.pointPos[num2, num3, 2]);
				num4 = PlayerObj.objDistFrmStrtPoint(num2, num3, vector);
			}
			else
			{
				num3 = 3;
				noOfTargetReached = PlayerObj.pointCount[num2] - num3;
				vector = new Vector3(PlayerObj.pointPos[num2, num3, 0], PlayerObj.pointPos[num2, num3, 1], PlayerObj.pointPos[num2, num3, 2]);
				num4 = PlayerObj.objDistFrmStrtPoint(num2, num3, vector);
				num4 = PlayerObj.pathLength[num2] - num4;
			}
		}
		nAIPlayerIndex++;
		if (nAIPlayerIndex >= IGT_FileReading.nAIPlayerCount)
		{
			nAIPlayerIndex = 0;
		}
		NextAIPlayerSAelection(num2, num3, vector);
		IGT_AIPlayer.AI_PlayerObj.currentPathIndex = num2;
		IGT_AIPlayer.AI_PlayerObj.currentPoint = num3;
		IGT_AIPlayer.AI_PlayerObj.nStartPoint = num3;
		IGT_AIPlayer.AI_PlayerObj.bTraverseReverse = flag;
		IGT_AIPlayer.AI_PlayerObj.fDistFrmStrtPnt = num4;
		IGT_AIPlayer.AI_PlayerObj.noOfTargetReached = noOfTargetReached;
		IGT_AIPlayer.AI_PlayerObj.fTotDistTraveled = num4;
		KeyValuePair<string, PathManager> keyValuePair = WaypointManager.Paths.ElementAt(num2);
		IGT_AIPlayer.AI_PlayerObj.SetPath(WaypointManager.Paths[keyValuePair.Key]);
		IGT_AIPlayer.AI_bGameOver = false;
		IGT_AIPlayer.AI_bNxtPathAvail = true;
		IGT_AIPlayer.AI_PlayerObj.bIncraseSpeed_SplPower = false;
		if (!IGT_AIPlayer.AI_PlayerObj.bTraverseReverse)
		{
			IGT_AIPlayer.AI_PlayerObj.animPointX = IGT_AIPlayer.AI_PlayerObj.waypoints[IGT_AIPlayer.AI_PlayerObj.currentPoint].position.x;
			IGT_AIPlayer.AI_PlayerObj.animPointY = IGT_AIPlayer.AI_PlayerObj.waypoints[IGT_AIPlayer.AI_PlayerObj.currentPoint].position.y;
			IGT_AIPlayer.AI_PlayerObj.animPointZ = IGT_AIPlayer.AI_PlayerObj.waypoints[IGT_AIPlayer.AI_PlayerObj.currentPoint].position.z;
		}
		else
		{
			IGT_AIPlayer.AI_PlayerObj.animPointX = IGT_AIPlayer.AI_PlayerObj.waypoints[IGT_AIPlayer.AI_PlayerObj.currentPoint - 1].position.x;
			IGT_AIPlayer.AI_PlayerObj.animPointY = IGT_AIPlayer.AI_PlayerObj.waypoints[IGT_AIPlayer.AI_PlayerObj.currentPoint - 1].position.y;
			IGT_AIPlayer.AI_PlayerObj.animPointZ = IGT_AIPlayer.AI_PlayerObj.waypoints[IGT_AIPlayer.AI_PlayerObj.currentPoint - 1].position.z;
		}
		IGT_AIPlayer.AI_fDistBw2Points = 0f;
		IGT_AIPlayer.AI_animPointVec = new Vector3(IGT_AIPlayer.AI_PlayerObj.animPointX, IGT_AIPlayer.AI_PlayerObj.animPointY, IGT_AIPlayer.AI_PlayerObj.animPointZ);
		IGT_AIPlayer.AI_animPointVec_Spline = new Vector3(IGT_AIPlayer.AI_PlayerObj.animPointX, IGT_AIPlayer.AI_PlayerObj.animPointY, IGT_AIPlayer.AI_PlayerObj.animPointZ);
		IGT_AIPlayer.AI_prevAnimpointVec = new Vector3(IGT_AIPlayer.AI_PlayerObj.animPointX, IGT_AIPlayer.AI_PlayerObj.animPointY, IGT_AIPlayer.AI_PlayerObj.animPointZ);
		IGT_AIPlayer.AI_PlayerObj.nEnergyMeter = 1f;
		IGT_AIPlayer.pAIPlayerAnimController.AIHeroAnimator.Play("Idle", 0);
		IGT_AIPlayer.pAIPlayerAnimController.nHeroAnimState = 1;
		IGT_GameView.nHelath_Enemy = 1f;
		IGT_AIPlayer.AI_offset_Laneoffset = num;
		IGT_AIPlayer.AI_DestinationOffset = num;
		IGT_AIPlayer.AI_fprevOffet = num;
		IGT_Constants.AI_dStrtTimefrOffsetSwitchng = Time.time;
		IGT_AIPlayer.bPauseAIPlayer = false;
		IGT_AIPlayer.bRePositionsFinished = false;
		IGT_AIPlayer.AI_bSelectDataFrMovingBWPath = false;
		IGT_AIPlayer.AI_PlayerObj.bMovingFinishdInPath = false;
		IGT_AIPlayer.bUTurnAnimationPlaying = false;
		Endless_Mode_DataSel();
		IGT_AnimStatesCntrler.HeroAnimator.Play("Idle", 0);
		nUserInput = 0;
		bPauseButton = false;
		bGameOver = false;
		bLevelUp = false;
		IGT_AnimStatesCntrler.nGameOverAnimFinshd = 0;
		bNextAIPlayerGonnaPickPurse = true;
		bLevelUpButtonPressed = false;
		PlayerToAIStrtVecwhileGonnaPickPurse = new Vector3(player.transform.position.x - vector.x, player.transform.position.y - vector.y, player.transform.position.z - vector.z);
		PlayerToAIStrtVecwhileGonnaPickPurse.Normalize();
	}

	public void NextAIPlayerSAelection(int strtPathID, int strtPointID, Vector3 Pos)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(Resources.Load(IGT_Constants.Path_AIPlayerModels_Low + IGT_Constants.AIPlayerString + nAIPlayerIndex), Pos, Quaternion.identity) as GameObject;
		SkinnedMeshRenderer componentInChildren = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
		componentInChildren.material = (Material)Resources.Load(IGT_Constants.Path_AIPlayerMaterials + IGT_Constants.AIPlayerString + nAIPlayerIndex, typeof(Material));
		gameObject.name = pAIPlayerData[nAIPlayerIndex].Name;
		if (gameObject.GetComponent<IGT_AIPlayer>() == null)
		{
			gameObject.AddComponent<IGT_AIPlayer>();
		}
		gameObject.GetComponent<IGT_AIPlayer>().init(strtPathID, strtPointID);
		gameObject.layer = LayerMask.NameToLayer(IGT_Constants.layer_Characters);
		IGT_GameView.setScreenMode(20);
	}

	private void AIPlayerDataSelfrmFile()
	{
		pAIPlayerData = new List<IGT_AIPlayerData>();
		pAIPlayerData.Clear();
		for (int i = 0; i < IGT_FileReading.nAIPlayerCount; i++)
		{
			string text = IGT_FileReading.AIPlayerData[i];
			string[] array = text.Split('~');
			int idx = int.Parse(array[0]);
			string text2 = array[1];
			int intelligence = int.Parse(array[2]);
			float baseSpd = float.Parse(array[3]);
			float minSpd = float.Parse(array[4]);
			float maxSpd = float.Parse(array[5]);
			float spdAccelFactor = float.Parse(array[6]);
			float spdDeAccelFactor = float.Parse(array[7]);
			float energyDecMinVal = float.Parse(array[8]);
			float enerDecMaxVal = float.Parse(array[9]);
			float energyIncValWhileInvisible = float.Parse(array[10]);
			float prevSpdProp = float.Parse(array[11]);
			float chseDst = float.Parse(array[12]);
			float chseTme = float.Parse(array[13]);
			int stObjEnableDisable = int.Parse(array[14]);
			string stObjPlacingArrStr = array[15];
			int dynObjPlacingProb = int.Parse(array[16]);
			float kickThrowAdjFact = float.Parse(array[17]);
			int vehicleProb = int.Parse(array[18]);
			int surAiprob = int.Parse(array[19]);
			int splpowerProb = int.Parse(array[20]);
			int posSplPowAdjFact = int.Parse(array[21]);
			int negSplPowAdjFact = int.Parse(array[22]);
			pAIPlayerData.Add(new IGT_AIPlayerData(idx, text2, intelligence, baseSpd, minSpd, maxSpd, spdAccelFactor, spdDeAccelFactor, energyDecMinVal, enerDecMaxVal, energyIncValWhileInvisible, prevSpdProp, chseDst, chseTme, stObjEnableDisable, stObjPlacingArrStr, dynObjPlacingProb, kickThrowAdjFact, vehicleProb, surAiprob, splpowerProb, posSplPowAdjFact, negSplPowAdjFact));
		}
		IGT_Constants.Wanted_Throw_Count = new int[10];
		IGT_Constants.Wanted_Throw_Count[0] = 2;
		IGT_Constants.Wanted_Throw_Count[1] = 3;
		IGT_Constants.Wanted_Throw_Count[2] = 4;
		IGT_Constants.Wanted_Throw_Count[3] = 5;
		IGT_Constants.Wanted_Throw_Count[4] = 6;
		IGT_Constants.Wanted_Throw_Count[5] = 7;
		IGT_Constants.Wanted_Throw_Count[6] = 9;
		IGT_Constants.Wanted_Throw_Count[7] = 10;
		IGT_Constants.Wanted_Throw_Count[9] = 12;
		IGT_Constants.Wanted_Throw_Count[8] = 15;
		IGT_Constants.Wanted_Kick_Count = new int[10];
		IGT_Constants.Wanted_Kick_Count[0] = 3;
		IGT_Constants.Wanted_Kick_Count[1] = 4;
		IGT_Constants.Wanted_Kick_Count[2] = 5;
		IGT_Constants.Wanted_Kick_Count[3] = 7;
		IGT_Constants.Wanted_Kick_Count[4] = 9;
		IGT_Constants.Wanted_Kick_Count[5] = 10;
		IGT_Constants.Wanted_Kick_Count[6] = 12;
		IGT_Constants.Wanted_Kick_Count[7] = 14;
		IGT_Constants.Wanted_Kick_Count[8] = 16;
		IGT_Constants.Wanted_Kick_Count[9] = 20;
	}

	public void AIPlayerSelection(int index, int path = 25, int point = 2)
	{
		DestroyAllAIPlayersUsingTags();
		nAIPlayerIndex = index;
		GameObject gameObject = UnityEngine.Object.Instantiate(Resources.Load(IGT_Constants.Path_AIPlayerModels_Low + IGT_Constants.AIPlayerString + nAIPlayerIndex), new Vector3(0.5f, 0.08f, -63.59f), Quaternion.identity) as GameObject;
		SkinnedMeshRenderer componentInChildren = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
		componentInChildren.material = (Material)Resources.Load(IGT_Constants.Path_AIPlayerMaterials + IGT_Constants.AIPlayerString + nAIPlayerIndex, typeof(Material));
		gameObject.name = pAIPlayerData[nAIPlayerIndex].Name;
		gameObject.layer = LayerMask.NameToLayer(IGT_Constants.layer_Characters);
		if (gameObject.GetComponent<IGT_AIPlayer>() == null)
		{
			gameObject.AddComponent<IGT_AIPlayer>();
		}
		gameObject.GetComponent<IGT_AIPlayer>().init(path, point);
		Endless_Mode_DataSel();
	}

	public void ChasingMode_AIPlayerInfoSel(int index, int path = 25, int point = 0)
	{
		DestroyAllAIPlayersUsingTags();
		nAIPlayerIndex = index;
		GameObject gameObject = UnityEngine.Object.Instantiate(Resources.Load(IGT_Constants.Path_AIPlayerModels_Low + IGT_Constants.AIPlayerString + nAIPlayerIndex), new Vector3(PlayerObj.pointPos[26, 1, 0], PlayerObj.pointPos[26, 1, 1], PlayerObj.pointPos[26, 1, 2]), Quaternion.identity) as GameObject;
		SkinnedMeshRenderer componentInChildren = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
		componentInChildren.material = (Material)Resources.Load(IGT_Constants.Path_AIPlayerMaterials + IGT_Constants.AIPlayerString + nAIPlayerIndex, typeof(Material));
		gameObject.name = pAIPlayerData[nAIPlayerIndex].Name;
		gameObject.layer = LayerMask.NameToLayer(IGT_Constants.layer_Characters);
		if (gameObject.GetComponent<IGT_AIPlayer>() == null)
		{
			gameObject.AddComponent<IGT_AIPlayer>();
		}
		gameObject.GetComponent<IGT_AIPlayer>().init_AiPlayerDatas(path, point);
		Endless_Mode_DataSel();
	}

	public void Endless_Mode_DataSel()
	{
		if (nAIPlayerIndex != -1)
		{
			IGT_AIPlayer.nIntelligenceValue = pAIPlayerData[nAIPlayerIndex].nIntelligence;
			IGT_AIPlayer.AI_PlayerObj.speed = (IGT_AIPlayer.AI_PlayerObj.BaseSpeed = (IGT_AIPlayer.AI_PlayerObj.PrevSpeed = (IGT_AIPlayer.AI_PlayerObj.setSpeed = pHeroData[nHeroIndex].BaseSpeed)));
			IGT_AIPlayer.AI_PlayerObj.MaxSpeed = (IGT_AIPlayer.AI_PlayerObj.PrevMaxSpeed = pHeroData[nHeroIndex].MaxSpeed);
			IGT_AIPlayer.AI_PlayerObj.MinSpeed = pHeroData[nHeroIndex].MinSpeed;
			IGT_AIPlayer.AI_PlayerObj.SpeedAccelerationFactor = pAIPlayerData[nAIPlayerIndex].SpdAccelerationFactor;
			IGT_AIPlayer.AI_PlayerObj.EnergyDeAcceleratorFactorPerSecond = pAIPlayerData[nAIPlayerIndex].SpdDeAccelerationFactorPerSecond;
			IGT_AIPlayer.AI_PlayerObj.EnergyDecMinVal = pAIPlayerData[nAIPlayerIndex].EnergyDecMinValue;
			IGT_AIPlayer.AI_PlayerObj.EnergyDecMaxVal = pAIPlayerData[nAIPlayerIndex].EnergyDecMaxVal;
			IGT_AIPlayer.AI_PlayerObj.dEnergyIncValWhenNotVisibleToHero = pAIPlayerData[nAIPlayerIndex].EnergyIncValWhileNotInVisible;
			IGT_AIPlayer.AI_PlayerObj.prevSpeedProportion = pAIPlayerData[nAIPlayerIndex].prevSpdProPortion;
			IGT_Constants.ChasingTime = pAIPlayerData[nAIPlayerIndex].fChasingTime;
			IGT_Constants.INITIAL_DISTGAP_BTW_HERO_ENEMY = (IGT_Constants.ChasingRadius = pAIPlayerData[nAIPlayerIndex].fChasingRadius);
			StaticObjEnableDisableValueSelection(nAIPlayerIndex);
			IGT_Constants.nDynamicObj_PlacingProb = pAIPlayerData[nAIPlayerIndex].DynamicObj_Placing_Prob;
			IGT_Constants.nKick_Throw_AdjFactor = pAIPlayerData[nAIPlayerIndex].DynamicObj_Kick_Throw_AdjFactor;
			IGT_Constants.nVehicle_SelProb = pAIPlayerData[nAIPlayerIndex].nVehicle_Sel_Prob;
			IGT_Constants.nSurpriseAI_SelProb = pAIPlayerData[nAIPlayerIndex].nSurpriseAi_Sel_Prob;
			IGT_Constants.nSplPowers_PlacingProb = pAIPlayerData[nAIPlayerIndex].nSplpowers_Placing_Prob;
			IGT_Constants.nSplPow_Pos_AdjFactor = pAIPlayerData[nAIPlayerIndex].nSplpowers_Positive_AdjFactor;
			IGT_Constants.nSplPow_Neg_AdjFactor = pAIPlayerData[nAIPlayerIndex].nSplpowers_Negative_AdjFactor;
			EnergyPickingProbForAIPlayer(nAIPlayerIndex);
		}
		HeroParametersSel();
		IGT_AnimStatesCntrler.HeroAnimator.speed = IGT_Constants.nAnimation_Default_Spd;
	}

	public void StaticObjEnableDisableValueSelection(int AIPlayerIdx)
	{
		IGT_Constants.nValfrStaticObjEnablingInPath = pAIPlayerData[AIPlayerIdx].nStaticObjEnableDisableinPathVal;
		string staticObjPlacingArrStrting = pAIPlayerData[AIPlayerIdx].StaticObjPlacingArrStrting;
		string[] array = staticObjPlacingArrStrting.Split('-');
		IGT_Constants.nValArrForEachStaticObjEnableProbability[0] = int.Parse(array[0]);
		IGT_Constants.nValArrForEachStaticObjEnableProbability[1] = int.Parse(array[1]);
		IGT_Constants.nValArrForEachStaticObjEnableProbability[2] = int.Parse(array[2]);
	}

	public void EnergyPickingProbForAIPlayer(int AIPlayerIndex)
	{
		IGT_AIPlayer.AI_PlayerObj.EnergyLevelsArr[0] = 90;
		IGT_AIPlayer.AI_PlayerObj.EnergyLevelsArr[1] = 70;
		IGT_AIPlayer.AI_PlayerObj.EnergyLevelsArr[2] = 50;
		IGT_AIPlayer.AI_PlayerObj.EnergyLevelsArr[3] = 25;
		IGT_AIPlayer.AI_PlayerObj.EnergyLevelsArr[4] = 0;
		string energyPickingProbString = pAIPlayerData[AIPlayerIndex].EnergyPickingProbString;
		string[] array = energyPickingProbString.Split('-');
		IGT_AIPlayer.AI_PlayerObj.EnergyPickingProbArr[0] = int.Parse(array[0]);
		IGT_AIPlayer.AI_PlayerObj.EnergyPickingProbArr[1] = int.Parse(array[1]);
		IGT_AIPlayer.AI_PlayerObj.EnergyPickingProbArr[2] = int.Parse(array[2]);
		IGT_AIPlayer.AI_PlayerObj.EnergyPickingProbArr[3] = int.Parse(array[3]);
		IGT_AIPlayer.AI_PlayerObj.EnergyPickingProbArr[4] = int.Parse(array[4]);
	}

	private void change_SurprisePlayerOffset()
	{
		if (isSurpriseAiAvailable && IGT_SurpriseAIplayer.playerAction == 2 && ((offset_Laneoffset == 0f && IGT_SurpriseAIplayer.offset_Laneoffset == 0f) || offset_Laneoffset == 0f - IGT_SurpriseAIplayer.offset_Laneoffset || offset_Laneoffset == IGT_SurpriseAIplayer.offset_Laneoffset))
		{
			fprevOffet = IGT_SurpriseAIplayer.offset_Laneoffset;
			if (nGameMode == 0 && PlayerObj.currentPathIndex == IGT_AIPlayer.AI_PlayerObj.currentPathIndex)
			{
				IGT_SurpriseAIplayer.fDestinationLaneOffset = 0f - findOffsetforPurseandAIinLevelup();
			}
			else if (offset_Laneoffset == 0f)
			{
				IGT_SurpriseAIplayer.fDestinationLaneOffset = 0f - PlayerObj.fTotalOffsetDeviation;
			}
			else
			{
				IGT_SurpriseAIplayer.fDestinationLaneOffset = offset_Laneoffset;
			}
		}
	}

	private void destroy_SurprisePlayer()
	{
		isSurpriseAiAvailable = false;
		DestroyAllObjectsUsingTAG(IGT_Constants.SurpriseAIplayer);
	}

	public void SurpriseAIPlayerDataSelection()
	{
		if (isSurpriseAiAvailable && PlayerObj.currentPathIndex != IGT_SurpriseAIplayer.nCurPathID)
		{
			destroy_SurprisePlayer();
		}
		else
		{
			if (isSurpriseAiAvailable || UnityEngine.Random.Range(0, 100) > IGT_Constants.nSurpriseAI_SelProb)
			{
				return;
			}
			surprisePlayerId = nAIPlayerIndex + 2;
			surprisePlayerId %= IGT_FileReading.nAIPlayerCount;
			if (nGameMode == 1)
			{
				surprisePlayerId = UnityEngine.Random.Range(0, IGT_FileReading.nAIPlayerCount);
				int num = 0;
				while (surprisePlayerId == nAIPlayerIndex && num < 25)
				{
					surprisePlayerId = UnityEngine.Random.Range(0, IGT_FileReading.nAIPlayerCount);
					num++;
				}
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(Resources.Load(IGT_Constants.Path_AIPlayerModels_Low + IGT_Constants.AIPlayerString + surprisePlayerId), Vector3.zero, Quaternion.identity) as GameObject;
			SkinnedMeshRenderer componentInChildren = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
			componentInChildren.material = (Material)Resources.Load(IGT_Constants.Path_AIPlayerMaterials + IGT_Constants.AIPlayerString + surprisePlayerId, typeof(Material));
			gameObject.name = IGT_Constants.SurpriseAIplayer;
			gameObject.tag = IGT_Constants.SurpriseAIplayer;
			UnityEngine.Object.Destroy(gameObject.GetComponent<IGT_AIPlayerAnimStateCtrl>());
			UnityEngine.Object.Destroy(gameObject.GetComponent<IGT_AIPlayer>());
			gameObject.GetComponent<Animator>().runtimeAnimatorController = Resources.Load(IGT_Constants.Path_Controller_SurpriseAIPlayer) as RuntimeAnimatorController;
			gameObject.AddComponent<IGT_SurpriseAIplayer>();
			isSurpriseAiAvailable = true;
		}
	}

	public void calcFPS()
	{
		if (fMinFrameTime > 1f / Time.deltaTime)
		{
			fMinFrameTime = 1f / Time.deltaTime;
		}
		if (startFrame - fLastFPSTick > 1.0)
		{
			nMinFramTime = (int)fMinFrameTime;
			fMinFrameTime = 999f;
			if (nMinFrameCount > nMinFramTime)
			{
				nMinFrameCount = nMinFramTime;
			}
			fDispFPS = (double)nDispFrames / (startFrame - fLastFPSTick);
			nDispFrames = 0;
			fLastFPSTick = startFrame;
			fDispFPS = (double)(int)(fDispFPS * 100.0) / 100.0;
			if (IGT_GameView.nScreenMode == 1 || IGT_GameView.nScreenMode == 21)
			{
				nTotFps += (float)fDispFPS;
			}
		}
		nDispFrames++;
		nDispFPS = (int)fDispFPS;
		IGT_GameView.pFps = nDispFPS.ToString();
		if (IGT_GameView.nScreenMode == 1 || IGT_GameView.nScreenMode == 21)
		{
			nTotFrameSamples += 1f;
		}
	}

	public void NxtPathSelectionWhileUsing_UseKey()
	{
		if (PlayerObj.bTotalTarReached)
		{
			nUserInput = selectpathNearToAI();
			if (!PlayerObj.bTraverseReverse)
			{
				PlayerObj.prevPathIndex = PlayerObj.currentPathIndex;
				PlayerObj.bTravRevFrPrevPath = PlayerObj.bTraverseReverse;
				PlayerObj.prevPathID_LastPointID[0, 0] = PlayerObj.currentPathIndex;
				PlayerObj.prevPathID_LastPointID[0, 1] = PlayerObj.currentPoint;
				PlayerObj.prevPathID_BeforeLastPointID[0, 0] = PlayerObj.currentPathIndex;
				PlayerObj.prevPathID_BeforeLastPointID[0, 1] = PlayerObj.currentPoint - 1;
				bNxtPathAvail = PlayerObj.findNearstPath(PlayerObj.currentPathIndex, PlayerObj.waypoints[PlayerObj.currentPoint - 1].position, PlayerObj.waypoints[PlayerObj.currentPoint].position, nUserInput);
			}
			else
			{
				PlayerObj.prevPathIndex = PlayerObj.currentPathIndex;
				PlayerObj.bTravRevFrPrevPath = PlayerObj.bTraverseReverse;
				PlayerObj.prevPathID_LastPointID[0, 0] = PlayerObj.currentPathIndex;
				PlayerObj.prevPathID_LastPointID[0, 1] = PlayerObj.currentPoint - 1;
				PlayerObj.prevPathID_BeforeLastPointID[0, 0] = PlayerObj.currentPathIndex;
				PlayerObj.prevPathID_BeforeLastPointID[0, 1] = PlayerObj.currentPoint;
				bNxtPathAvail = PlayerObj.findNearstPath(PlayerObj.currentPathIndex, PlayerObj.waypoints[PlayerObj.currentPoint].position, PlayerObj.waypoints[PlayerObj.currentPoint - 1].position, nUserInput);
			}
			if (bNxtPathAvail)
			{
				PlayerObj.bMovingFinishdInPath = true;
			}
			nUserInput = 0;
		}
		if (playerCollisionStates == 2)
		{
			player.transform.localScale = new Vector3(1f, 1f, 1f);
		}
	}

	public int AIMode_CollisonCheck(float PlayerdistFrmStrtPnt, Vector3 playerPos, float offset, bool TravRev, float TotPathLength, float playerSpd, int AIPlayerPathID)
	{
		float num = 0f;
		if (TravRev)
		{
			offset = 0f - offset;
		}
		for (int i = 0; i < PlayerObj.pObj.movingObj.Count; i++)
		{
			float num2 = PlayerObj.pObj.movingObj[i].fDistFrmStrtPnt - PlayerObj.pObj.movingObj[i].fWidth;
			float num3 = PlayerdistFrmStrtPnt;
			float num4 = PlayerObj.pObj.movingObj[i].fOffset;
			int num5;
			bool flag;
			if (PlayerObj.pObj.movingObj[i].bVehicleCrossedCurPath)
			{
				num5 = PlayerObj.pObj.movingObj[i].VehicleDestPathID;
				flag = PlayerObj.pObj.movingObj[i].bVehicleDestPathTravRev;
			}
			else
			{
				num5 = PlayerObj.pObj.movingObj[i].nPathId;
				flag = PlayerObj.pObj.movingObj[i].bTravRev;
			}
			if (flag)
			{
				num4 = 0f - num4;
				if (PlayerObj.pObj.movingObj[i].bVehicleCrossedCurPath)
				{
					num2 = TotPathLength - PlayerObj.pObj.movingObj[i].fDistFrmStrtPnt;
				}
			}
			if (TravRev)
			{
				num3 = TotPathLength - PlayerdistFrmStrtPnt - 1.5f;
			}
			if (AIPlayerPathID == num5 && num3 <= num2 + 2f && num3 >= num2 - 2f && offset >= num4 - PlayerObj.fTotalOffsetDeviation && offset <= num4 + PlayerObj.fTotalOffsetDeviation)
			{
				fprevOffet = offset_Laneoffset;
				if (num4 < 0f)
				{
					fDestinationLaneOffset = PlayerObj.fTotalOffsetDeviation;
				}
				else
				{
					fDestinationLaneOffset = 0f - PlayerObj.fTotalOffsetDeviation;
				}
				if (TravRev)
				{
					fDestinationLaneOffset = 0f - fDestinationLaneOffset;
				}
			}
		}
		for (int j = 0; j < PlayerObj.pObj.ObjListInCurPathOfHero.Count; j++)
		{
			num = (TravRev ? (TotPathLength - PlayerObj.pObj.ObjListInCurPathOfHero[j].fDistFrmStrtPnt) : PlayerObj.pObj.ObjListInCurPathOfHero[j].fDistFrmStrtPnt);
			if (PlayerObj.pObj.ObjListInCurPathOfHero[j].objPlaceType == 1 && PlayerObj.pObj.ObjListInCurPathOfHero[j].objType != 4 && PlayerObj.pObj.ObjListInCurPathOfHero[j].objType != 6)
			{
				if (AIPlayerPathID == PlayerObj.pObj.ObjListInCurPathOfHero[j].nPathId && offset >= PlayerObj.pObj.ObjListInCurPathOfHero[j].fOffset - PlayerObj.pObj.ObjListInCurPathOfHero[j].fLength / 2f && offset <= PlayerObj.pObj.ObjListInCurPathOfHero[j].fOffset + PlayerObj.pObj.ObjListInCurPathOfHero[j].fLength / 2f && PlayerdistFrmStrtPnt <= num + PlayerObj.pObj.ObjListInCurPathOfHero[j].fWidth / 2f && PlayerdistFrmStrtPnt >= num - PlayerObj.pObj.ObjListInCurPathOfHero[j].fWidth / 2f)
				{
					if (PlayerObj.pObj.ObjListInCurPathOfHero[j].objType == 0)
					{
						return 0;
					}
					if (PlayerObj.pObj.ObjListInCurPathOfHero[j].objType == 1)
					{
						return 1;
					}
					if (PlayerObj.pObj.ObjListInCurPathOfHero[j].objType == 5)
					{
						fprevOffet = offset_Laneoffset;
						fDestinationLaneOffset = FindAImodeDestinationOffset(offset, PlayerObj.pObj.ObjListInCurPathOfHero[j].fOffset, PlayerObj.pObj.ObjListInCurPathOfHero[j].fLength / 2f, TravRev);
					}
				}
			}
			else
			{
				if (PlayerObj.pObj.ObjListInCurPathOfHero[j].objPlaceType != 0 || !(num + PlayerObj.pObj.ObjListInCurPathOfHero[j].fWidth / 2f >= PlayerdistFrmStrtPnt) || AIPlayerPathID != PlayerObj.pObj.ObjListInCurPathOfHero[j].nPathId || !(offset >= PlayerObj.pObj.ObjListInCurPathOfHero[j].fOffset - PlayerObj.pObj.ObjListInCurPathOfHero[j].fLength / 2f - IGT_Constants.AIPlayerWidth / 3f) || !(offset <= PlayerObj.pObj.ObjListInCurPathOfHero[j].fOffset + PlayerObj.pObj.ObjListInCurPathOfHero[j].fLength / 2f + IGT_Constants.AIPlayerWidth / 3f) || !(PlayerdistFrmStrtPnt <= num + PlayerObj.pObj.ObjListInCurPathOfHero[j].fWidth / 2f) || !(PlayerdistFrmStrtPnt >= num - PlayerObj.pObj.ObjListInCurPathOfHero[j].fWidth / 2f))
				{
					continue;
				}
				if (PlayerObj.pObj.ObjListInCurPathOfHero[j].objType == 2)
				{
					if (PlayerObj.pObj.ObjListInCurPathOfHero[j].fOffset == 0f)
					{
						return 0;
					}
					fprevOffet = offset_Laneoffset;
					fDestinationLaneOffset = FindAImodeDestinationOffset(offset, PlayerObj.pObj.ObjListInCurPathOfHero[j].fOffset, PlayerObj.pObj.ObjListInCurPathOfHero[j].fLength / 2f, TravRev);
				}
				if (PlayerObj.pObj.ObjListInCurPathOfHero[j].objType == 5)
				{
					fprevOffet = offset_Laneoffset;
					fDestinationLaneOffset = FindAImodeDestinationOffset(offset, PlayerObj.pObj.ObjListInCurPathOfHero[j].fOffset, PlayerObj.pObj.ObjListInCurPathOfHero[j].fLength / 2f, TravRev);
				}
			}
		}
		return 11;
	}

	public float FindAImodeDestinationOffset(float curOff, float objOff, float objLen, bool TravRev)
	{
		float num = 0f;
		if (objOff == centerOffset)
		{
			num = PlayerObj.fTotalOffsetDeviation;
		}
		else if (objOff < centerOffset)
		{
			num = ((!(objOff + objLen < centerOffset)) ? PlayerObj.fTotalOffsetDeviation : centerOffset);
		}
		else if (objOff > centerOffset)
		{
			num = ((!(objOff - objLen > centerOffset)) ? (0f - PlayerObj.fTotalOffsetDeviation) : centerOffset);
		}
		if (TravRev)
		{
			num = 0f - num;
		}
		return num;
	}

	public void INAPP_Init()
	{
		pIGT_IAPManagerAssist = new IGT_IAPManagerAssist(puplicKey);
		for (int i = 0; i < pPurchaseItemsData_Store.Count; i++)
		{
			pIGT_IAPManagerAssist.AddProduct(pPurchaseItemsData_Store[i].ProductID_GooglePlayStore, pPurchaseItemsData_Store[i].ProductID_IOSAppStore, pPurchaseItemsData_Store[i].ProductType);
		}
		for (int j = 0; j < pPurchaseItemsData_Deals.Count; j++)
		{
			pIGT_IAPManagerAssist.AddProduct(pPurchaseItemsData_Deals[j].ProductID_GooglePlayStore, pPurchaseItemsData_Deals[j].ProductID_IOSAppStore, pPurchaseItemsData_Deals[j].ProductType);
		}
		pIGT_IAPManagerAssist.InitializeBuilder();
		pIGT_IAPManagerAssist.setPurchaseListner(this);
	}

	public void StartPurchase(string productID)
	{
		if (pIGT_IAPManagerAssist.isInitialisedSuccess() && !pIGT_IAPManagerAssist.isAnyPurchaseInProgress())
		{
			pIGT_IAPManagerAssist.startPurchase(productID);
		}
	}

	private int getCurPurchaseScreenName()
	{
		int result = 0;
		if (IGT_GameView.nScreenMode == 6)
		{
			result = 0;
		}
		else if (IGT_GameView.nScreenMode == 16)
		{
			result = 1;
		}
		else if (IGT_GameView.bNoMoreLiveAlert)
		{
			result = 2;
		}
		else if (IGT_GameView.bInappAlert)
		{
			if (IGT_GameView.nAlertWin == 1)
			{
				result = 3;
			}
			else if (IGT_GameView.nAlertWin == 2)
			{
				result = 4;
			}
			else if (IGT_GameView.nAlertWin == 3)
			{
				result = 5;
			}
			else if (IGT_GameView.nAlertWin == 4)
			{
				result = 6;
			}
		}
		return result;
	}

	public void PurchaseStarted(string productID)
	{
		Debug.Log("======purchase started for the id: " + productID);
		setActivitySpinner(true);
		bCanShowAdOnForeGround = false;
		post_Analytics_Purchase(getCurPurchaseScreenName(), productID, 0);
	}

	public void PurchaseSuccess(string productID)
	{
		Debug.Log("===========purchase success for the id: " + productID);
		setActivitySpinner(false);
		if (productID == pPurchaseItemsData_Store[0].ProductID_IOSAppStore || productID == pPurchaseItemsData_Store[0].ProductID_GooglePlayStore)
		{
			if (IGT_GameView.nScreenMode == 6)
			{
				IGT_GameView.purchase_Items_Adding_Anim(2, IGT_Constants.nTotNoOfCoins, IGT_Constants.nTotNoOfCoins + 6000);
			}
			else
			{
				IGT_Constants.nTotNoOfCoins += 6000;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotCoins, IGT_Constants.nTotNoOfCoins);
			}
		}
		else if (productID == pPurchaseItemsData_Store[1].ProductID_IOSAppStore || productID == pPurchaseItemsData_Store[1].ProductID_GooglePlayStore)
		{
			if (IGT_GameView.nScreenMode == 6)
			{
				IGT_GameView.purchase_Items_Adding_Anim(2, IGT_Constants.nTotNoOfCoins, IGT_Constants.nTotNoOfCoins + 30000);
			}
			else
			{
				IGT_Constants.nTotNoOfCoins += 30000;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotCoins, IGT_Constants.nTotNoOfCoins);
			}
		}
		else if (productID == pPurchaseItemsData_Store[2].ProductID_IOSAppStore || productID == pPurchaseItemsData_Store[2].ProductID_GooglePlayStore)
		{
			if (IGT_GameView.nScreenMode == 6)
			{
				IGT_GameView.purchase_Items_Adding_Anim(2, IGT_Constants.nTotNoOfCoins, IGT_Constants.nTotNoOfCoins + 125000);
			}
			else
			{
				IGT_Constants.nTotNoOfCoins += 125000;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotCoins, IGT_Constants.nTotNoOfCoins);
			}
		}
		else if (productID == pPurchaseItemsData_Store[3].ProductID_IOSAppStore || productID == pPurchaseItemsData_Store[3].ProductID_GooglePlayStore)
		{
			if (IGT_GameView.nScreenMode == 6)
			{
				IGT_GameView.purchase_Items_Adding_Anim(2, IGT_Constants.nTotNoOfCoins, IGT_Constants.nTotNoOfCoins + 400000);
			}
			else
			{
				IGT_Constants.nTotNoOfCoins += 400000;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotCoins, IGT_Constants.nTotNoOfCoins);
			}
		}
		else if (productID == pPurchaseItemsData_Store[4].ProductID_IOSAppStore || productID == pPurchaseItemsData_Store[4].ProductID_GooglePlayStore)
		{
			if (IGT_GameView.nScreenMode == 6)
			{
				IGT_GameView.purchase_Items_Adding_Anim(2, IGT_Constants.nTotNoOfCoins, IGT_Constants.nTotNoOfCoins + 1000000);
			}
			else
			{
				IGT_Constants.nTotNoOfCoins += 1000000;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotCoins, IGT_Constants.nTotNoOfCoins);
			}
		}
		else if (productID == pPurchaseItemsData_Store[5].ProductID_IOSAppStore || productID == pPurchaseItemsData_Store[5].ProductID_GooglePlayStore)
		{
			if (IGT_GameView.nScreenMode == 6)
			{
				IGT_GameView.purchase_Items_Adding_Anim(1, IGT_Constants.nTotKeysCount, IGT_Constants.nTotKeysCount + 30);
			}
			else
			{
				IGT_Constants.nTotKeysCount += 30;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotKeyCount, IGT_Constants.nTotKeysCount);
			}
		}
		else if (productID == pPurchaseItemsData_Store[6].ProductID_IOSAppStore || productID == pPurchaseItemsData_Store[6].ProductID_GooglePlayStore)
		{
			if (IGT_GameView.nScreenMode == 6)
			{
				IGT_GameView.purchase_Items_Adding_Anim(1, IGT_Constants.nTotKeysCount, IGT_Constants.nTotKeysCount + 120);
			}
			else
			{
				IGT_Constants.nTotKeysCount += 120;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotKeyCount, IGT_Constants.nTotKeysCount);
			}
		}
		else if (productID == pPurchaseItemsData_Store[7].ProductID_IOSAppStore || productID == pPurchaseItemsData_Store[7].ProductID_GooglePlayStore)
		{
			if (IGT_GameView.nScreenMode == 6)
			{
				IGT_GameView.purchase_Items_Adding_Anim(1, IGT_Constants.nTotKeysCount, IGT_Constants.nTotKeysCount + 300);
			}
			else
			{
				IGT_Constants.nTotKeysCount += 300;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotKeyCount, IGT_Constants.nTotKeysCount);
			}
		}
		else if (productID == pPurchaseItemsData_Store[8].ProductID_IOSAppStore || productID == pPurchaseItemsData_Store[8].ProductID_GooglePlayStore)
		{
			if (IGT_GameView.nScreenMode == 6)
			{
				IGT_GameView.purchase_Items_Adding_Anim(1, IGT_Constants.nTotKeysCount, IGT_Constants.nTotKeysCount + 750);
			}
			else
			{
				IGT_Constants.nTotKeysCount += 750;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotKeyCount, IGT_Constants.nTotKeysCount);
			}
		}
		else if (productID == pPurchaseItemsData_Store[9].ProductID_IOSAppStore || productID == pPurchaseItemsData_Store[9].ProductID_GooglePlayStore)
		{
			if (IGT_GameView.nScreenMode == 6)
			{
				IGT_GameView.purchase_Items_Adding_Anim(0, pIGt_LifeCalc.getCurrentLifeCount(), pIGt_LifeCalc.getCurrentLifeCount() + 5);
			}
			else
			{
				pIGt_LifeCalc.forceAddLifeCount(5);
			}
		}
		else if (productID == pPurchaseItemsData_Store[10].ProductID_IOSAppStore || productID == pPurchaseItemsData_Store[10].ProductID_GooglePlayStore)
		{
			if (IGT_GameView.nScreenMode == 6)
			{
				IGT_GameView.purchase_Items_Adding_Anim(0, pIGt_LifeCalc.getCurrentLifeCount(), pIGt_LifeCalc.getCurrentLifeCount() + 25);
			}
			else
			{
				pIGt_LifeCalc.forceAddLifeCount(25);
			}
		}
		else if (productID == pPurchaseItemsData_Store[11].ProductID_IOSAppStore || productID == pPurchaseItemsData_Store[11].ProductID_GooglePlayStore)
		{
			if (IGT_GameView.nScreenMode == 6)
			{
				IGT_GameView.purchase_Items_Adding_Anim(0, pIGt_LifeCalc.getCurrentLifeCount(), pIGt_LifeCalc.getCurrentLifeCount() + 100);
			}
			else
			{
				pIGt_LifeCalc.forceAddLifeCount(100);
			}
		}
		else if (productID == pPurchaseItemsData_Deals[0].ProductID_IOSAppStore || productID == pPurchaseItemsData_Deals[0].ProductID_GooglePlayStore)
		{
			if (IGT_GameView.nScreenMode == 6)
			{
				IGT_GameView.purchase_Items_Adding_Anim(2, IGT_Constants.nTotNoOfCoins, IGT_Constants.nTotNoOfCoins + 25000);
				IGT_GameView.purchase_Items_Adding_Anim(1, IGT_Constants.nTotKeysCount, IGT_Constants.nTotKeysCount + 25);
			}
			else
			{
				IGT_Constants.nTotNoOfCoins += 25000;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotCoins, IGT_Constants.nTotNoOfCoins);
				IGT_Constants.nTotKeysCount += 25;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotKeyCount, IGT_Constants.nTotKeysCount);
			}
		}
		else if (productID == pPurchaseItemsData_Deals[1].ProductID_IOSAppStore || productID == pPurchaseItemsData_Deals[1].ProductID_GooglePlayStore)
		{
			if (IGT_GameView.nScreenMode == 6)
			{
				IGT_GameView.purchase_Items_Adding_Anim(2, IGT_Constants.nTotNoOfCoins, IGT_Constants.nTotNoOfCoins + 50000);
				IGT_GameView.purchase_Items_Adding_Anim(0, pIGt_LifeCalc.getCurrentLifeCount(), pIGt_LifeCalc.getCurrentLifeCount() + 30);
			}
			else
			{
				IGT_Constants.nTotNoOfCoins += 50000;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotCoins, IGT_Constants.nTotNoOfCoins);
				pIGt_LifeCalc.forceAddLifeCount(30);
			}
		}
		else if (productID == pPurchaseItemsData_Deals[2].ProductID_IOSAppStore || productID == pPurchaseItemsData_Deals[2].ProductID_GooglePlayStore)
		{
			if (IGT_GameView.nScreenMode == 6)
			{
				IGT_GameView.purchase_Items_Adding_Anim(1, IGT_Constants.nTotKeysCount, IGT_Constants.nTotKeysCount + 100);
				IGT_GameView.purchase_Items_Adding_Anim(0, pIGt_LifeCalc.getCurrentLifeCount(), pIGt_LifeCalc.getCurrentLifeCount() + 50);
			}
			else
			{
				IGT_Constants.nTotKeysCount += 100;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotKeyCount, IGT_Constants.nTotKeysCount);
				pIGt_LifeCalc.forceAddLifeCount(50);
			}
		}
		else if (productID == pPurchaseItemsData_Deals[3].ProductID_IOSAppStore || productID == pPurchaseItemsData_Deals[3].ProductID_GooglePlayStore)
		{
			if (IGT_GameView.nScreenMode == 6)
			{
				IGT_GameView.purchase_Items_Adding_Anim(2, IGT_Constants.nTotNoOfCoins, IGT_Constants.nTotNoOfCoins + 150000);
				IGT_GameView.purchase_Items_Adding_Anim(1, IGT_Constants.nTotKeysCount, IGT_Constants.nTotKeysCount + 150);
				IGT_GameView.purchase_Items_Adding_Anim(0, pIGt_LifeCalc.getCurrentLifeCount(), pIGt_LifeCalc.getCurrentLifeCount() + 150);
			}
			else
			{
				IGT_Constants.nTotNoOfCoins += 150000;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotCoins, IGT_Constants.nTotNoOfCoins);
				IGT_Constants.nTotKeysCount += 150;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotKeyCount, IGT_Constants.nTotKeysCount);
				pIGt_LifeCalc.forceAddLifeCount(150);
			}
		}
		else if (productID == pPurchaseItemsData_Deals[4].ProductID_IOSAppStore || productID == pPurchaseItemsData_Deals[4].ProductID_GooglePlayStore)
		{
			if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_Combo1))
			{
				nDealComboOffer_1 = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_Combo1, 1);
			}
			else
			{
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_Combo1, 1);
			}
			if (nDealComboOffer_1 == 1)
			{
				if (IGT_GameView.nScreenMode == 6)
				{
					IGT_GameView.purchase_Items_Adding_Anim(2, IGT_Constants.nTotNoOfCoins, IGT_Constants.nTotNoOfCoins + 75000);
					IGT_GameView.purchase_Items_Adding_Anim(1, IGT_Constants.nTotKeysCount, IGT_Constants.nTotKeysCount + 50);
				}
				else
				{
					IGT_Constants.nTotNoOfCoins += 75000;
					IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotCoins, IGT_Constants.nTotNoOfCoins);
					IGT_Constants.nTotKeysCount += 50;
					IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotKeyCount, IGT_Constants.nTotKeysCount);
				}
				if (IGT_Constants.nUpgrade_CurState[4] < 2)
				{
					IGT_Constants.nUpgrade_CurState[4] = 2;
					IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_Upgrade_CurStateKey[4], IGT_Constants.nUpgrade_CurState[4]);
					for (int i = 0; i < pPurchaseItemsData_Boost.Count; i++)
					{
						pPurchaseItemsData_Boost.ElementAt(i).nCurUpgradeState = IGT_Constants.nUpgrade_CurState[i];
					}
					update_UpgradeInfo();
				}
				nDealComboOffer_1 = 0;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_Combo1, nDealComboOffer_1);
			}
		}
		else if (productID == pPurchaseItemsData_Deals[5].ProductID_IOSAppStore || productID == pPurchaseItemsData_Deals[5].ProductID_GooglePlayStore)
		{
			if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_Combo2))
			{
				nDealComboOffer_2 = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_Combo2, 1);
			}
			else
			{
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_Combo2, 1);
			}
			if (nDealComboOffer_2 == 1)
			{
				if (IGT_GameView.nScreenMode == 6)
				{
					IGT_GameView.purchase_Items_Adding_Anim(0, pIGt_LifeCalc.getCurrentLifeCount(), pIGt_LifeCalc.getCurrentLifeCount() + 75);
					IGT_GameView.purchase_Items_Adding_Anim(1, IGT_Constants.nTotKeysCount, IGT_Constants.nTotKeysCount + 75);
				}
				else
				{
					pIGt_LifeCalc.forceAddLifeCount(75);
					IGT_Constants.nTotKeysCount += 75;
					IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotKeyCount, IGT_Constants.nTotKeysCount);
				}
				if (IGT_Constants.nUpgrade_CurState[2] < 2)
				{
					IGT_Constants.nUpgrade_CurState[2] = 2;
					IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_Upgrade_CurStateKey[2], IGT_Constants.nUpgrade_CurState[2]);
					for (int j = 0; j < pPurchaseItemsData_Boost.Count; j++)
					{
						pPurchaseItemsData_Boost.ElementAt(j).nCurUpgradeState = IGT_Constants.nUpgrade_CurState[j];
					}
					update_UpgradeInfo();
				}
				nDealComboOffer_2 = 0;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_Combo2, nDealComboOffer_2);
			}
		}
		IGT_Preference.getInstance()._SaveAll();
		post_Analytics_Purchase(getCurPurchaseScreenName(), productID, 1);
		bRemoveAds = true;
		IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_RemoveAds, 1);
	}

	public void PurchaseFailed(string productID, string purchaseFailureReason)
	{
		Debug.Log("============purchase Failure for the id: " + productID + " reason: " + purchaseFailureReason);
		setActivitySpinner(false);
		post_Analytics_Purchase(getCurPurchaseScreenName(), productID, 2);
	}

	public void setLayerToAllChildrens(GameObject go, string layername)
	{
		foreach (Transform componentInChild in go.GetComponentInChildren<Transform>(true))
		{
			componentInChild.gameObject.layer = LayerMask.NameToLayer(layername);
		}
	}

	private void Load_ZoneDatas()
	{
		for (int i = 0; i < ZoneData.Count(); i++)
		{
			ZoneData[i] = new List<IGT_ZoneData>();
		}
		ZoneData[0].Add(new IGT_ZoneData(29, false));
		ZoneData[0].Add(new IGT_ZoneData(29, true));
		ZoneData[0].Add(new IGT_ZoneData(2, false));
		ZoneData[0].Add(new IGT_ZoneData(2, true));
		ZoneData[0].Add(new IGT_ZoneData(3, true));
		ZoneData[0].Add(new IGT_ZoneData(13, false));
		ZoneData[0].Add(new IGT_ZoneData(13, true));
		ZoneData[0].Add(new IGT_ZoneData(14, false));
		ZoneData[0].Add(new IGT_ZoneData(14, true));
		ZoneData[0].Add(new IGT_ZoneData(15, false));
		ZoneData[0].Add(new IGT_ZoneData(22, false));
		ZoneData[1].Add(new IGT_ZoneData(15, true));
		ZoneData[1].Add(new IGT_ZoneData(19, false));
		ZoneData[1].Add(new IGT_ZoneData(19, true));
		ZoneData[1].Add(new IGT_ZoneData(4, true));
		ZoneData[1].Add(new IGT_ZoneData(17, true));
		ZoneData[1].Add(new IGT_ZoneData(16, true));
		ZoneData[2].Add(new IGT_ZoneData(23, false));
		ZoneData[2].Add(new IGT_ZoneData(10, false));
		ZoneData[2].Add(new IGT_ZoneData(10, true));
		ZoneData[2].Add(new IGT_ZoneData(11, false));
		ZoneData[2].Add(new IGT_ZoneData(11, true));
		ZoneData[2].Add(new IGT_ZoneData(12, false));
		ZoneData[2].Add(new IGT_ZoneData(12, true));
		ZoneData[2].Add(new IGT_ZoneData(6, false));
		ZoneData[2].Add(new IGT_ZoneData(6, true));
		ZoneData[2].Add(new IGT_ZoneData(7, false));
		ZoneData[2].Add(new IGT_ZoneData(7, true));
		ZoneData[2].Add(new IGT_ZoneData(0, false));
		ZoneData[2].Add(new IGT_ZoneData(0, true));
		ZoneData[2].Add(new IGT_ZoneData(1, true));
		ZoneData[2].Add(new IGT_ZoneData(16, false));
		ZoneData[2].Add(new IGT_ZoneData(17, false));
		ZoneData[2].Add(new IGT_ZoneData(18, false));
		ZoneData[2].Add(new IGT_ZoneData(22, true));
		ZoneData[2].Add(new IGT_ZoneData(24, false));
		ZoneData[2].Add(new IGT_ZoneData(24, true));
		ZoneData[3].Add(new IGT_ZoneData(1, false));
		ZoneData[3].Add(new IGT_ZoneData(3, false));
		ZoneData[3].Add(new IGT_ZoneData(5, false));
		ZoneData[3].Add(new IGT_ZoneData(18, true));
		ZoneData[3].Add(new IGT_ZoneData(20, false));
		ZoneData[3].Add(new IGT_ZoneData(20, true));
		ZoneData[4].Add(new IGT_ZoneData(25, false));
		ZoneData[4].Add(new IGT_ZoneData(25, true));
		ZoneData[4].Add(new IGT_ZoneData(26, false));
		ZoneData[4].Add(new IGT_ZoneData(26, true));
		ZoneData[4].Add(new IGT_ZoneData(27, false));
		ZoneData[4].Add(new IGT_ZoneData(27, true));
		ZoneData[4].Add(new IGT_ZoneData(5, true));
		ZoneData[4].Add(new IGT_ZoneData(4, false));
		ZoneData[4].Add(new IGT_ZoneData(8, false));
		ZoneData[4].Add(new IGT_ZoneData(8, true));
		ZoneData[4].Add(new IGT_ZoneData(9, false));
		ZoneData[4].Add(new IGT_ZoneData(9, true));
		ZoneData[4].Add(new IGT_ZoneData(21, false));
		ZoneData[4].Add(new IGT_ZoneData(21, true));
		ZoneData[4].Add(new IGT_ZoneData(23, true));
	}

	private void BringBackItem_instantiation(int id, Vector3 pos)
	{
		GameObject original;
		switch (id)
		{
		case 0:
			original = IGT_ObjPlacing.coll_Hat;
			break;
		case 1:
			original = IGT_ObjPlacing.coll_Cooler;
			break;
		case 2:
			original = IGT_ObjPlacing.coll_Ring;
			break;
		case 3:
			original = IGT_ObjPlacing.coll_Chain;
			break;
		case 4:
			original = IGT_ObjPlacing.coll_Necklace;
			break;
		case 5:
			original = IGT_ObjPlacing.coll_Necklace1;
			break;
		case 6:
			original = IGT_ObjPlacing.coll_Necklace2;
			break;
		default:
			original = IGT_ObjPlacing.Bag;
			break;
		}
		BB_CollectionItem = UnityEngine.Object.Instantiate(original, new Vector3(pos.x, pos.y + IGT_Constants.HeroHeight / 2f, pos.z), Quaternion.Euler(0f, 0f, 0f));
		BB_CollectionItem.name = "BB_ColItem";
		BB_CollectionItem.tag = IGT_Constants.Tag_BB_Item;
		BB_CollectionItem.layer = LayerMask.NameToLayer(IGT_Constants.layer_CollisionCheck);
		if (BB_CollectionItem.GetComponent<BoxCollider>() == null)
		{
			BB_CollectionItem.AddComponent<BoxCollider>();
		}
		BB_CollectionItem.GetComponent<BoxCollider>().size = new Vector3(BB_CollectionItem.GetComponent<BoxCollider>().size.x, 0.006f, BB_CollectionItem.GetComponent<BoxCollider>().size.z);
		bHasPicked_BBitem = false;
		BB_CollectionItemGlow = UnityEngine.Object.Instantiate(IGT_ObjPlacing.BB_DestinationArea, pos, Quaternion.Euler(0f, 0f, 0f));
	}
}
