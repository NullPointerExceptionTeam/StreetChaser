using System.IO;
using SQLite4Unity3d;
using UnityEngine;

public class IGT_saveLevelData
{
	private SQLiteConnection sqlliteConn;

	private string dbName = "LevelInfo.db";

	public IGT_saveLevelData()
	{
		DBSettings(dbName);
		sqlliteConn.CreateTable<SQL_ByteArrayTab>();
	}

	private void DBSettings(string DatabaseName)
	{
		string text = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);
		if (!File.Exists(text))
		{
			Debug.Log("Database not in Persistent path ");
			WWW wWW = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);
			while (!wWW.isDone)
			{
			}
			File.WriteAllBytes(text, wWW.bytes);
			Debug.Log("Database written");
		}
		string databasePath = text;
		sqlliteConn = new SQLiteConnection(databasePath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
	}

	public void dropTable()
	{
		sqlliteConn.DeleteAll<SQL_ByteArrayTab>();
		sqlliteConn.DropTable<SQL_ByteArrayTab>();
	}

	public void insertTableInfo(int _leveID, int _type, byte[] _byteData)
	{
		sqlliteConn.Insert(new SQL_ByteArrayTab
		{
			LevelID = _leveID,
			Type = _type,
			byteArray = _byteData
		});
	}

	public void updateTableInfo(int _leveID, int _type, byte[] _byteData)
	{
		string query = "update SQL_ByteArrayTab set byteArray = ? where LevelID =" + _leveID + " and Type = " + _type;
		sqlliteConn.Execute(query, _byteData);
	}

	public bool isAlreadyPresent(int _leveID, int _type)
	{
		int num = 0;
		TableQuery<SQL_ByteArrayTab> tableQuery = sqlliteConn.Table<SQL_ByteArrayTab>();
		foreach (SQL_ByteArrayTab item in tableQuery)
		{
			if (item.Type == _type && item.LevelID == _leveID)
			{
				num++;
			}
		}
		if (num > 0)
		{
			return true;
		}
		return false;
	}

	public byte[] getTableData(int _leveID, int _type)
	{
		byte[] result = null;
		TableQuery<SQL_ByteArrayTab> tableQuery = sqlliteConn.Table<SQL_ByteArrayTab>();
		foreach (SQL_ByteArrayTab item in tableQuery)
		{
			if (item.LevelID == _leveID && item.Type == _type)
			{
				result = IGT_EncodeDecode.decrypt(item.byteArray);
			}
		}
		return result;
	}

	public int getTotalRowsCount()
	{
		int num = 0;
		TableQuery<SQL_ByteArrayTab> tableQuery = sqlliteConn.Table<SQL_ByteArrayTab>();
		foreach (SQL_ByteArrayTab item in tableQuery)
		{
			num++;
		}
		return num;
	}
}
