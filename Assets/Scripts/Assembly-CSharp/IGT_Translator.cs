using System.Collections;
using System.IO;
using System.Xml;
using UnityEngine;

public class IGT_Translator
{
	private Hashtable Strings;

	public IGT_Translator(string path, string language, bool web)
	{
		if (!web)
		{
			setLanguage(path, language);
		}
		else
		{
			setLanguageWeb(path, language);
		}
	}

	public void setLanguage(string path, string language)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(path);
		Strings = new Hashtable();
		XmlElement xmlElement = xmlDocument.DocumentElement[language];
		if (xmlElement != null)
		{
			IEnumerator enumerator = xmlElement.GetEnumerator();
			while (enumerator.MoveNext())
			{
				XmlElement xmlElement2 = (XmlElement)enumerator.Current;
				Strings.Add(xmlElement2.GetAttribute("name"), xmlElement2.InnerText);
			}
		}
		else
		{
			setLanguage(path, "English");
			Debug.LogError("The specified language does not exist: " + language);
		}
	}

	public void setLanguageWeb(string xmlText, string language)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(new StringReader(xmlText));
		Strings = new Hashtable();
		XmlElement xmlElement = xmlDocument.DocumentElement[language];
		if (xmlElement != null)
		{
			IEnumerator enumerator = xmlElement.GetEnumerator();
			while (enumerator.MoveNext())
			{
				XmlElement xmlElement2 = (XmlElement)enumerator.Current;
				Strings.Add(xmlElement2.GetAttribute("name"), xmlElement2.InnerText);
			}
		}
		else
		{
			setLanguage(xmlText, "English");
			Debug.LogError("The specified language does not exist: " + language);
		}
	}

	public string getString(string name)
	{
		if (!Strings.ContainsKey(name))
		{
			Debug.LogError("The specified string does not exist: " + name);
			return string.Empty;
		}
		return (string)Strings[name];
	}
}
