using SQLite4Unity3d;

public class SQL_LevelStarCount
{
	[PrimaryKey]
	public int LevelID { get; set; }

	public int LevelStarCount { get; set; }

	public override string ToString()
	{
		return string.Format("[LevelID={0}, LevelStarCount={1}]", LevelID, LevelStarCount);
	}
}
