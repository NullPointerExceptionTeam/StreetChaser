using System.Collections.Generic;

public class IGT_Comparator : IComparer<IGT_PlayerInfo>
{
	public int Compare(IGT_PlayerInfo a, IGT_PlayerInfo b)
	{
		if (a.DistanceTraveled < b.DistanceTraveled)
		{
			return 1;
		}
		if (a.DistanceTraveled > b.DistanceTraveled)
		{
			return -1;
		}
		return 0;
	}
}
