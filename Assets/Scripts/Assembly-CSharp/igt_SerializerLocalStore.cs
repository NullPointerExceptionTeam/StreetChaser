using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class igt_SerializerLocalStore
{
	public static T Load<T>(string _filenameWithExtension) where T : class
	{
		string text = Application.persistentDataPath + "/" + _filenameWithExtension;
		Debug.Log("File Load path : " + text);
		if (File.Exists(text))
		{
			try
			{
				using (Stream stream = File.OpenRead(text))
				{
					BinaryFormatter binaryFormatter = new BinaryFormatter();
					Debug.Log("Read file " + text + " is sucess " + stream.Length);
					return binaryFormatter.Deserialize(stream) as T;
				}
			}
			catch (Exception ex)
			{
				Debug.Log("Load excep : " + ex.Message);
			}
			return (T)null;
		}
		return (T)null;
	}

	public static void Save<T>(string _filenameWithExtension, T data) where T : class
	{
		string text = Application.persistentDataPath + "/" + _filenameWithExtension;
		Debug.Log("File Save path : " + text);
		using (Stream stream = File.OpenWrite(text))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			binaryFormatter.Serialize(stream, data);
			Debug.Log(string.Concat(data.GetType(), " : Data : ", stream.CanWrite));
			Debug.Log("Formatter : " + binaryFormatter.ToString());
			Debug.Log("Save file " + text + " is sucess " + stream.Length);
		}
	}

	public static void delete(string _filenameWithExtension)
	{
		string text = Application.persistentDataPath + "/" + _filenameWithExtension;
		if (File.Exists(text))
		{
			try
			{
				Debug.Log("Call delete file... : " + _filenameWithExtension + " Path : " + text);
				File.Delete(text);
				return;
			}
			catch (Exception ex)
			{
				Debug.Log("Exception for delete file : " + ex.Message);
				return;
			}
		}
		Debug.Log("file not present in path...");
	}
}
