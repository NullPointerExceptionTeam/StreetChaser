using SQLite4Unity3d;

public class SQL_GlobalListTableMission
{
	[PrimaryKey]
	[AutoIncrement]
	public int Id { get; set; }

	public string UID { get; set; }

	public string Name { get; set; }

	public int userCurrentLevel { get; set; }

	public int Score { get; set; }

	public string gameType { get; set; }

	public int rank { get; set; }

	public override string ToString()
	{
		return string.Format("[Id={0}, UserID={1}, UserName={2},CurrentLevel={3}, Score={4}, gameType={5}]", Id, UID, Name, userCurrentLevel, Score, gameType);
	}
}
