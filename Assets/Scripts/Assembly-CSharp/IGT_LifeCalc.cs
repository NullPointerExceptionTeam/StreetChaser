using System;

public class IGT_LifeCalc
{
	private int nTotGivenLifeCount;

	private int nTotLifeCount;

	private int nCurLifeCount;

	private float fLife_ReSpawn_Interval;

	private float fLastLifeAddedTime;

	private DateTime referenceDateTime;

	private string CURRENTLIFECOUNT;

	private string LASTLIFEADDEDTIME;

	private string TOTALLIFECOUNT;

	public IGT_LifeCalc(int TotalLifeCount, float lifeIntervalInMinutes, string currentLifeKey, string lastlifeAddedTimeKey)
	{
		referenceDateTime = new DateTime(2016, 10, 3, 0, 0, 0, DateTimeKind.Utc);
		CURRENTLIFECOUNT = currentLifeKey;
		LASTLIFEADDEDTIME = lastlifeAddedTimeKey;
		TOTALLIFECOUNT = currentLifeKey + "Tot";
		nTotGivenLifeCount = TotalLifeCount;
		nCurLifeCount = nTotGivenLifeCount;
		nCurLifeCount = IGT_Preference.getInstance()._Get(CURRENTLIFECOUNT, nCurLifeCount);
		fLife_ReSpawn_Interval = lifeIntervalInMinutes * 60f;
		fLastLifeAddedTime = getLastlifeAddedTime();
		nTotLifeCount = getTotalLifeCount();
	}

	public int getCurrentLifeCount()
	{
		return nCurLifeCount;
	}

	public int getTotalGivenLifeCount()
	{
		return nTotGivenLifeCount;
	}

	public int getTotalLifeCount()
	{
		return IGT_Preference.getInstance()._Get(TOTALLIFECOUNT, nTotGivenLifeCount);
	}

	public float getLastlifeAddedTime()
	{
		return IGT_Preference.getInstance()._Get(LASTLIFEADDEDTIME, (float)getSeconds_sinceReferenceTime());
	}

	public int getRemainingLifeCount()
	{
		return nTotGivenLifeCount - getCurrentLifeCount();
	}

	public float getEachLife_RespawnInterval()
	{
		return fLife_ReSpawn_Interval;
	}

	public void addLifeCount(int count)
	{
		nCurLifeCount += count;
		if (nCurLifeCount > nTotGivenLifeCount)
		{
			nCurLifeCount = nTotGivenLifeCount;
		}
		saveDatas();
	}

	public void forceAddLifeCount(int count)
	{
		nCurLifeCount += count;
		nTotLifeCount = nCurLifeCount;
		saveDatas();
	}

	public void decreaseLifeCount(int count)
	{
		if (nCurLifeCount == nTotGivenLifeCount)
		{
			fLastLifeAddedTime = getSeconds_sinceReferenceTime();
		}
		nCurLifeCount -= count;
		if (nCurLifeCount < 0)
		{
			nCurLifeCount = 0;
		}
		saveDatas();
	}

	private void saveDatas()
	{
		IGT_Preference.getInstance()._Set(CURRENTLIFECOUNT, nCurLifeCount);
		IGT_Preference.getInstance()._Set(LASTLIFEADDEDTIME, fLastLifeAddedTime);
		IGT_Preference.getInstance()._Set(TOTALLIFECOUNT, nTotLifeCount);
		IGT_Preference.getInstance()._SaveAll();
	}

	public void lifeAddingProcessCalc()
	{
		if (nCurLifeCount < nTotGivenLifeCount && !(fLastLifeAddedTime > (float)getSeconds_sinceReferenceTime()))
		{
			float num = (float)getSeconds_sinceReferenceTime() - fLastLifeAddedTime;
			int num2 = (int)(num / fLife_ReSpawn_Interval);
			float num3 = num % fLife_ReSpawn_Interval;
			if (num2 >= 1)
			{
				fLastLifeAddedTime = getSeconds_sinceReferenceTime() - (long)num3;
				addLifeCount(num2);
			}
		}
	}

	public long getRemainingTimeFrLifeAdding()
	{
		return (long)fLife_ReSpawn_Interval - (getSeconds_sinceReferenceTime() - (long)fLastLifeAddedTime);
	}

	public long getSeconds_sinceReferenceTime()
	{
		return (long)(DateTime.UtcNow - referenceDateTime).TotalSeconds;
	}
}
