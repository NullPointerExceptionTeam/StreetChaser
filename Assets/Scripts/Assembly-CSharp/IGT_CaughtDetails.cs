public class IGT_CaughtDetails
{
	public int nCaughtCount;

	public int nAttempts;

	public string Name;

	public IGT_CaughtDetails(string name, int caughtcount, int attempts)
	{
		Name = name;
		nCaughtCount = caughtcount;
		nAttempts = attempts;
	}
}
