using SQLite4Unity3d;

public class SQL_FBFrndTableMission
{
	[PrimaryKey]
	[AutoIncrement]
	public int Id { get; set; }

	public string UID { get; set; }

	public string Name { get; set; }

	public int userCurrentLevel { get; set; }

	public int Score { get; set; }

	public byte[] picData { get; set; }

	public bool isImageLoad { get; set; }

	public string userAskMsg { get; set; }

	public string userSendMsg { get; set; }

	public string gameType { get; set; }

	public int rank { get; set; }

	public override string ToString()
	{
		return string.Format("[Id={0}, UserID={1}, UserName={2},CurrentLevel={3}, Score={4}, picData={5},isImgLoad={6},gameType={7}]", Id, UID, Name, userCurrentLevel, Score, picData, isImageLoad, gameType);
	}
}
