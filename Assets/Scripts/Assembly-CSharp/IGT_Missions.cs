using System;

public class IGT_Missions
{
	public int nMissionType;

	public int nCollectionInnerItemType;

	public int nTargetCount;

	public int nHeroIdx;

	public bool bIsAiPlayerNeed;

	public int nAIplayerIdx;

	public int nStaticObjEnablingInPathVal;

	public int StaticObjPlacingDifficulty;

	public int nDynamicObjPlacingProb;

	public float fMinDistBtwCollectionObj;

	public int nCollectionItemPlacingProb;

	public int fBringBackitem_AbsDistfrmStrt;

	public int nCatchingInnerItemType;

	public int nChallengesInnerItemType;

	public int nChallengeItem_BaseProb;

	public int nChallengeItem_DiffProb;

	public string WordTobeFind;

	public int nWF_OringinalCharPlacingProb;

	public int nWF_NoOfCharPer_20Meters;

	public int nSurpriseplayerProb;

	public int nSplPowersProb;

	public int nVehicleProb;

	public float nKickThrowAdjVal;

	public int nSpl_Pos_AdjVal;

	public int nSpl_Neg_AdjVal;

	public int nCoinPlacingProb;

	public int nZoneID;

	public int nStartPathID;

	public int nStartPointID;

	public bool bTravRev;

	public int nNumOfMultipleCollection;

	public int[,] nMultipleCollectionDatas = new int[3, Enum.GetNames(typeof(MultipleCollectionDetails)).Length];

	public string pMultipleCollectionDatasString;

	public int nRetryCount;

	public int nLevelStarCount;

	public int nLevelScore;

	public float fCollectionItem_MissingProb;

	public float fChallengeCrossedProb;

	public float spdFactor;

	public int HeroStartEnergy;

	public int EnemyStartEnergy;

	public int AIEndIdx;

	public string incrementData;

	public int nBaseLevelIdx;

	public int nBringBackItemInnerType;
}
