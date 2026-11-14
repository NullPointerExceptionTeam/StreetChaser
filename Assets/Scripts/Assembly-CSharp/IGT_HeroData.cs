public class IGT_HeroData
{
	public string Name;

	public int nIndex;

	public float BaseSpeed;

	public float MinSpeed;

	public float MaxSpeed;

	public float prevSpdProPortion;

	public float SpdAccelerationFactor;

	public float EnergyDeAccelerationFactorPerSecond;

	public float EnergyIncreasingMinValue;

	public float EnergyIncreasingMaxVal;

	public IGT_HeroData(int idx, string name, float BaseSpd, float MinSpd, float MaxSpd, float spdAccelFactor, float spdDeAccelFactor, float EnergyIncMinVal, float EnergyIncMaxVal, float prevSpdProp)
	{
		nIndex = idx;
		Name = name;
		BaseSpeed = BaseSpd;
		MinSpeed = MinSpd;
		MaxSpeed = MaxSpd;
		SpdAccelerationFactor = spdAccelFactor;
		EnergyDeAccelerationFactorPerSecond = spdDeAccelFactor;
		EnergyIncreasingMinValue = EnergyIncMinVal;
		EnergyIncreasingMaxVal = EnergyIncMaxVal;
		prevSpdProPortion = prevSpdProp;
	}
}
