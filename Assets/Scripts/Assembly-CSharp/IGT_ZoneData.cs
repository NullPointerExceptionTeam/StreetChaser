public class IGT_ZoneData
{
	public int nPathID;

	public bool bIsReverse;

	public IGT_ZoneData(int pid, bool travRev)
	{
		nPathID = pid;
		bIsReverse = travRev;
	}
}
