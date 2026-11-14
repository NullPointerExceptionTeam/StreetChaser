using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class igtSocialShare
{
	public string appInstalledMsg;

	public static Texture2D scrnCapture()
	{
		Texture2D texture2D = new Texture2D(Screen.width, Screen.height);
		texture2D.ReadPixels(new Rect(0f, 0f, Screen.width, Screen.height), 0, 0);
		texture2D.Apply();
		return texture2D;
	}

	[DllImport("__Internal")]
	private static extern bool _isAppInstalled(string _bundleID);

	public bool isAppInstalled(string bundleID)
	{
		Debug.Log(string.Concat(Application.platform, " : ", bundleID));
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
		AndroidJavaObject androidJavaObject2 = androidJavaObject.Call<AndroidJavaObject>("getPackageManager", new object[0]);
		AndroidJavaObject androidJavaObject3 = null;
		try
		{
			androidJavaObject3 = androidJavaObject2.Call<AndroidJavaObject>("getLaunchIntentForPackage", new object[1] { bundleID });
		}
		catch (Exception ex)
		{
			Debug.Log("isAppInstal excep : " + ex.Message);
		}
		if (androidJavaObject3 == null)
		{
			return false;
		}
		return true;
	}

	public void shareToTwitter(string _title, string _description, string _gameLink, Action shareTwitterSucess = null)
	{
		IGT_GameView.bAppNotInstalledAlert = false;
		try
		{
			Application.OpenURL("https://twitter.com/intent/tweet?text=" + WWW.EscapeURL(_description + "\n" + _gameLink));
			if (shareTwitterSucess != null)
			{
				shareTwitterSucess();
			}
		}
		catch (Exception ex)
		{
			Debug.Log("shareToTwitter exp : " + ex);
		}
	}

	public void shareToWhatsApp(string _title, string _description, string _gameLink, Action shareWhatsAppSucess = null)
	{
		IGT_GameView.bAppNotInstalledAlert = false;
		if (isAppInstalled("com.whatsapp"))
		{
			try
			{
				Application.OpenURL("whatsapp://send?text=" + WWW.EscapeURL(_title + "\n" + _description + "\n" + _gameLink));
				if (shareWhatsAppSucess != null)
				{
					shareWhatsAppSucess();
				}
				return;
			}
			catch (Exception ex)
			{
				Debug.Log("shareToWhatsApp exp : " + ex);
				return;
			}
		}
		appInstalledMsg = "WhatsApp not installed";
		IGT_GameView.bAppNotInstalledAlert = true;
		IGT_GameView.fChaseLockAlert_StartTime = Time.time;
	}

	[DllImport("__Internal")]
	private static extern void _postToInstagram(string message, string imagePath);

	public void shareToInstagram(string _description, string _imgPath, Action shareInstaSucess = null)
	{
		IGT_GameView.bAppNotInstalledAlert = false;
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("android.content.Intent");
		AndroidJavaObject androidJavaObject = new AndroidJavaObject("android.content.Intent");
		AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject androidJavaObject2 = androidJavaClass2.GetStatic<AndroidJavaObject>("currentActivity");
		AndroidJavaObject androidJavaObject3 = androidJavaObject2.Call<AndroidJavaObject>("getPackageManager", new object[0]);
		androidJavaObject = androidJavaObject3.Call<AndroidJavaObject>("getLaunchIntentForPackage", new object[1] { "com.instagram.android" });
		AndroidJavaClass androidJavaClass3 = new AndroidJavaClass("android.net.Uri");
		string text = Application.persistentDataPath + "Images/UI/Life.png";
		AndroidJavaObject androidJavaObject4 = androidJavaClass3.CallStatic<AndroidJavaObject>("parse", new object[1] { "file://" + text });
		Debug.Log("Destination = " + text);
		androidJavaObject.Call<AndroidJavaObject>("setType", new object[1] { "image/*" });
		androidJavaObject.Call<AndroidJavaObject>("putExtra", new object[2]
		{
			androidJavaClass.GetStatic<string>("EXTRA_STREAM"),
			androidJavaObject4
		});
		androidJavaObject.Call<AndroidJavaObject>("setAction", new object[1] { androidJavaClass.GetStatic<string>("ACTION_SEND") });
		androidJavaObject2.Call("startActivity", androidJavaObject);
	}

	public void shareToMail(string _email, string _subject, string _body, Action shareMailSucess = null)
	{
		IGT_GameView.bAppNotInstalledAlert = false;
		try
		{
			Application.OpenURL("mailto:" + _email + "?subject=" + _subject + "&body=" + WWW.EscapeURL(_body));
			if (shareMailSucess != null)
			{
				shareMailSucess();
			}
		}
		catch (Exception ex)
		{
			Debug.Log("shareToMail exp : " + ex);
		}
	}

	public void shareToMessage(string _num, string _message, Action shareSMSSucess = null)
	{
		IGT_GameView.bAppNotInstalledAlert = false;
		try
		{
			string arg = ((Application.platform != RuntimePlatform.IPhonePlayer) ? "?" : ";");
			Application.OpenURL(string.Format("sms:{0}{1}body={2}", _num, arg, _message));
			if (shareSMSSucess != null)
			{
				shareSMSSucess();
			}
		}
		catch (Exception ex)
		{
			Debug.Log("shareToMessage exp : " + ex);
		}
	}

	public void shareToGooglePluse(string _title, string _description, string _gameLink)
	{
	}
}
