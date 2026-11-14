public class SQL_ByteArrayTab
{
	public int LevelID { get; set; }

	public int Type { get; set; }

	public byte[] byteArray { get; set; }

	public override string ToString()
	{
		return string.Format("[LevelID={0},Type={1}, byteArray={2}]", LevelID, Type, byteArray);
	}
}
