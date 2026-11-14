public class IGT_AIPlayerData
{
	public string Name;

	public int nIntelligence;

	public int nIndex;

	public float BaseSpeed;

	public float MinSpeed;

	public float MaxSpeed;

	public float prevSpdProPortion;

	public float SpdAccelerationFactor;

	public float SpdDeAccelerationFactorPerSecond;

	public float EnergyDecMinValue;

	public float EnergyDecMaxVal;

	public float EnergyIncValWhileNotInVisible;

	public string EnergyPickingProbString;

	public float fChasingTime;

	public float fChasingRadius;

	public int nStaticObjEnableDisableinPathVal;

	public string StaticObjPlacingArrStrting;

	public int DynamicObj_Placing_Prob;

	public float DynamicObj_Kick_Throw_AdjFactor;

	public int nVehicle_Sel_Prob;

	public int nSurpriseAi_Sel_Prob;

	public int nSplpowers_Placing_Prob;

	public int nSplpowers_Positive_AdjFactor;

	public int nSplpowers_Negative_AdjFactor;

	public IGT_AIPlayerData(int idx, string name, int intelligence, float BaseSpd, float MinSpd, float MaxSpd, float spdAccelFactor, float spdDeAccelFactor, float EnergyDecMinVal, float EnerDecMaxVal, float EnergyIncValWhileInvisible, float prevSpdProp, float chseDst, float chseTme, int StObjEnableDisable, string StObjPlacingArrStr, int dynObjPlacingProb, float kickThrowAdjFact, int vehicleProb, int surAiprob, int splpowerProb, int posSplPowAdjFact, int negSplPowAdjFact, string EnergyProbString = "0-0-0-0-0")
	{
		nIndex = idx;
		Name = name;
		nIntelligence = intelligence;
		BaseSpeed = BaseSpd;
		MinSpeed = MinSpd;
		MaxSpeed = MaxSpd;
		SpdAccelerationFactor = spdAccelFactor;
		SpdDeAccelerationFactorPerSecond = spdDeAccelFactor;
		EnergyDecMinValue = EnergyDecMinVal;
		EnergyDecMaxVal = EnerDecMaxVal;
		EnergyIncValWhileNotInVisible = EnergyIncValWhileInvisible;
		prevSpdProPortion = prevSpdProp;
		fChasingRadius = chseDst;
		fChasingTime = chseTme;
		nStaticObjEnableDisableinPathVal = StObjEnableDisable;
		StaticObjPlacingArrStrting = StObjPlacingArrStr;
		DynamicObj_Placing_Prob = dynObjPlacingProb;
		DynamicObj_Kick_Throw_AdjFactor = kickThrowAdjFact;
		nVehicle_Sel_Prob = vehicleProb;
		nSurpriseAi_Sel_Prob = surAiprob;
		nSplpowers_Placing_Prob = splpowerProb;
		nSplpowers_Positive_AdjFactor = posSplPowAdjFact;
		nSplpowers_Negative_AdjFactor = negSplPowAdjFact;
		EnergyPickingProbString = EnergyProbString;
	}
}
