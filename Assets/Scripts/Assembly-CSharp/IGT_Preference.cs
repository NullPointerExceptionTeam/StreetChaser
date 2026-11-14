using System;
using System.Linq;
using System.Text;
using UnityEngine;

public class IGT_Preference
{
	private static IGT_Preference pIGT_Pref;

	private string key = "0123456789abcdefghijklmnopqrstuvwxyz";

	public static IGT_Preference getInstance()
	{
		if (pIGT_Pref == null)
		{
			pIGT_Pref = new IGT_Preference();
		}
		return pIGT_Pref;
	}

	public void _Set<T>(string key, T value)
	{
		switch (getDataType(value))
		{
		case 0:
		{
			int value3 = Convert.ToInt32(value);
			string text = _Encode_Int(value3);
			text = text + "@" + CRC(text);
			PlayerPrefs.SetString(key, text);
			break;
		}
		case 1:
		{
			float value2 = Convert.ToSingle(value);
			string text = _Encode_Float(value2);
			text = text + "@" + CRC(text);
			PlayerPrefs.SetString(key, text);
			break;
		}
		case 2:
		{
			string strValue2 = value.ToString();
			string text = _Encode_String(strValue2);
			text = text + "@" + CRC(text);
			PlayerPrefs.SetString(key, text);
			break;
		}
		default:
		{
			string strValue = value.ToString();
			string text = _Encode_String(strValue);
			text = text + "@" + CRC(text);
			PlayerPrefs.SetString(key, text);
			break;
		}
		}
	}

	public T _Get<T>(string key, T defaulValue)
	{
		switch (getDataType(defaulValue))
		{
		case 0:
		{
			string text5 = PlayerPrefs.GetString(key, "Null");
			int num2 = Convert.ToInt32(defaulValue);
			if (text5 != "Null")
			{
				string[] array3 = text5.Split('@');
				string text6 = array3[0];
				string value4 = array3[1];
				if (CRC(text6).ToString().Equals(value4))
				{
					num2 = _Decode_Int(text6);
				}
			}
			return (T)Convert.ChangeType(num2, typeof(T));
		}
		case 1:
		{
			string text3 = PlayerPrefs.GetString(key, "Null");
			float num = Convert.ToSingle(defaulValue);
			if (text3 != "Null")
			{
				string[] array2 = text3.Split('@');
				string text4 = array2[0];
				string value3 = array2[1];
				if (CRC(text4).ToString().Equals(value3))
				{
					num = _Decode_Float(text4);
				}
			}
			return (T)Convert.ChangeType(num, typeof(T));
		}
		case 2:
		{
			string text7 = PlayerPrefs.GetString(key, "Null");
			string value5 = Convert.ToString(defaulValue);
			if (text7 != "Null")
			{
				string[] array4 = text7.Split('@');
				string text8 = array4[0];
				string value6 = array4[1];
				if (CRC(text8).ToString().Equals(value6))
				{
					value5 = _Decode_String(text8);
				}
			}
			return (T)Convert.ChangeType(value5, typeof(T));
		}
		default:
		{
			string text = PlayerPrefs.GetString(key, "Null");
			string value = Convert.ToString(defaulValue);
			if (text != "Null")
			{
				string[] array = text.Split('@');
				string text2 = array[0];
				string value2 = array[1];
				if (CRC(text2).ToString().Equals(value2))
				{
					value = _Decode_String(text2);
				}
			}
			return (T)Convert.ChangeType(value, typeof(T));
		}
		}
	}

	public bool _isKey_AlreadyPresent(string key)
	{
		if (PlayerPrefs.HasKey(key))
		{
			return true;
		}
		return false;
	}

	public void _SaveAll()
	{
		PlayerPrefs.Save();
	}

	public void _deleteAll()
	{
		PlayerPrefs.DeleteAll();
	}

	public void _Delete_GivenKey(string key)
	{
		PlayerPrefs.DeleteKey(key);
	}

	private int getDataType<T>(T type)
	{
		if (type.GetType() == typeof(int) || type.GetType() == typeof(short) || type.GetType() == typeof(long))
		{
			return 0;
		}
		if (type.GetType() == typeof(string))
		{
			return 2;
		}
		if (type.GetType() == typeof(float))
		{
			return 1;
		}
		return 3;
	}

	public void _checkEndecode()
	{
		string text = "igt.sc.gopi";
		Debug.Log("String : " + text);
		string text2 = _Encode_String(text);
		Debug.Log("encoded string : " + text2);
		Debug.Log("decoded str: " + _Decode_String(text2));
	}

	private string _Encode_Int(int value)
	{
		int num = 29;
		string text = string.Empty;
		if (value < 0)
		{
			text = "-";
			value = Math.Abs(value);
		}
		if (value >= 0)
		{
			int num2 = 0;
			do
			{
				num2 = value % num;
				value /= num;
				text += key.ElementAt(num2);
			}
			while (value > num);
			if (value > 0)
			{
				text += key.ElementAt(value);
			}
		}
		return text;
	}

	private int _Decode_Int(string value)
	{
		bool flag = false;
		if (value.StartsWith("-"))
		{
			flag = true;
			value = value.Substring(1);
		}
		int num = 29;
		int length = value.Length;
		int num2 = 0;
		for (int i = 0; i < length; i++)
		{
			if (!char.IsDigit(value.ElementAt(i)))
			{
				int num3 = value.ElementAt(i) - 97 + 10;
				num2 = (int)((double)num2 + (double)num3 * Math.Pow(num, i));
			}
			else
			{
				num2 = (int)((double)num2 + (double)int.Parse(string.Empty + value.ElementAt(i)) * Math.Pow(num, i));
			}
		}
		if (flag)
		{
			num2 = -num2;
		}
		return num2;
	}

	private string _Encode_Float(float value)
	{
		int num = 29;
		string text = string.Empty;
		if (value < 0f)
		{
			text = "-";
			value = Math.Abs(value);
		}
		if ((string.Empty + value).Contains("."))
		{
			string text2 = string.Empty + value;
			string text3 = text2.Substring(0, text2.IndexOf("."));
			string text4 = text2.Substring(text2.IndexOf(".") + 1, text2.Length - text3.Length - 1);
			text += _Encode_Int(int.Parse(text3));
			text = text + "." + text4;
		}
		else if (value >= 0f)
		{
			int num2 = 0;
			do
			{
				num2 = (int)(value % (float)num);
				value /= (float)num;
				text += key.ElementAt(num2);
			}
			while (value > (float)num);
			if (value > 0f)
			{
				text += key.ElementAt((int)value);
			}
		}
		return text;
	}

	private float _Decode_Float(string value)
	{
		bool flag = false;
		if (value.StartsWith("-"))
		{
			flag = true;
			value = value.Substring(1);
		}
		int num = 29;
		int length = value.Length;
		float num2 = 0f;
		if (value.Contains("."))
		{
			string text = string.Empty + value;
			string text2 = text.Substring(0, text.IndexOf("."));
			string text3 = text.Substring(text.IndexOf(".") + 1, text.Length - text2.Length - 1);
			int num3 = _Decode_Int(text2);
			string s = num3 + "." + text3;
			num2 = float.Parse(s);
		}
		else
		{
			for (int i = 0; i < length; i++)
			{
				if (!char.IsDigit(value.ElementAt(i)))
				{
					int num4 = value.ElementAt(i) - 97 + 10;
					num2 = (int)((double)num2 + (double)num4 * Math.Pow(num, i));
				}
				else
				{
					num2 = (int)((double)num2 + (double)int.Parse(string.Empty + value.ElementAt(i)) * Math.Pow(num, i));
				}
			}
		}
		if (flag)
		{
			num2 = 0f - num2;
		}
		return num2;
	}

	private string _Encode_String(string strValue)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(strValue);
		bytes = _Encrypt_ByteArray(bytes);
		strValue = Encoding.UTF8.GetString(bytes);
		return strValue;
	}

	private string _Decode_String(string data)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(data);
		bytes = _Decrypt_ByteArray(bytes);
		data = Encoding.UTF8.GetString(bytes);
		return data;
	}

	private byte[] _Encrypt_ByteArray(byte[] array)
	{
		byte[] array2 = _ReverseGivenByteArray(array);
		int num = 29;
		int num2 = array.Length;
		int i = num;
		int num3 = 0;
		for (; i < num2; i++)
		{
			byte b = array2[num3];
			array2[num3] = array2[i];
			array2[i] = b;
			num3++;
		}
		return array2;
	}

	private byte[] _Decrypt_ByteArray(byte[] array)
	{
		int num = 29;
		int num2 = array.Length - 1;
		int num3 = 0;
		num3 = num2 - num;
		int num4 = num2;
		while (num3 >= 0)
		{
			byte b = array[num4];
			array[num4] = array[num3];
			array[num3] = b;
			num4--;
			num3--;
		}
		return _ReverseGivenByteArray(array);
	}

	private byte[] _ReverseGivenByteArray(byte[] array)
	{
		if (array == null)
		{
			return null;
		}
		int i = 0;
		for (int num = array.Length - 1; num > i; i++)
		{
			byte b = array[num];
			array[num] = array[i];
			array[i] = b;
			num--;
		}
		return array;
	}

	private long CRC(string str)
	{
		str += "IGT_StreetChaser04443554948";
		long num = 65521L;
		long num2 = 1L;
		long num3 = 0L;
		int length = str.Length;
		for (int i = 0; i < length; i++)
		{
			long num4 = (int)str[i];
			num2 = (num2 + num4) % num;
			num3 = (num3 + num2) % num;
		}
		return (num3 << 16) | num2;
	}
}
