public class IGT_FacebookData
{
	public string userID;

	public string UserName;

	public long nUserTotScore;

	public IGT_FacebookData(string Name, long TotScore, string uID)
	{
		UserName = Name;
		nUserTotScore = TotScore;
		userID = uID;
	}
}
