using System;
using System.Collections;
using System.IO;
using UnityEngine;

public class webView
{
	private Rect rectTitlePos;

	private Rect rectCloseBtn;

	public WebViewObject webViewObject;

	private int webViewLeft;

	private int webViewTop;

	private int webViewRight;

	private int webViewBottom;

	public webView(IGT_Textures _txtTitle = null, string _textureKey = null)
	{
	}

	public void OnClose()
	{
		webViewObject.SetVisibility(false);
		UnityEngine.Object.Destroy(webViewObject);
	}

	public void setWebViewMargins(int _left = 25, int _top = 50, int _right = 25, int _bottom = 20)
	{
		webViewLeft = _left;
		webViewTop = _top;
		webViewRight = _right;
		webViewBottom = _bottom;
		rectCloseBtn = new Rect((int)scaleX(320 - _right - 29), (int)scaleY(_top - 29), (int)scaleX(30f), (int)scaleY(30f));
		rectTitlePos = new Rect((int)scaleX(25f), (int)scaleY(webViewTop - 35), (int)scaleX(270f), (int)scaleY(35f));
	}

	public Rect getCloseBtnPos()
	{
		return rectCloseBtn;
	}

	public void draw(IGT_Textures tex2d, string _txtTitleKey)
	{
		if (webViewObject.enabled)
		{
			tex2d.DrawTexture(_txtTitleKey, rectTitlePos.x, rectTitlePos.y, rectTitlePos.width, rectTitlePos.height);
		}
	}

	public string androidInstalledApps()
	{
		webViewObject = new GameObject("WebViewObject").AddComponent<WebViewObject>();
		return webViewObject.androidInstalledAppList();
	}

	public bool isInstalledApp(string _bundleId)
	{
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
		AndroidJavaObject androidJavaObject2 = androidJavaObject.Call<AndroidJavaObject>("getPackageManager", new object[0]);
		Debug.Log(" ********LaunchOtherApp ");
		AndroidJavaObject androidJavaObject3 = null;
		try
		{
			androidJavaObject3 = androidJavaObject2.Call<AndroidJavaObject>("getLaunchIntentForPackage", new object[1] { _bundleId });
		}
		catch (Exception ex)
		{
			Debug.Log("exception" + ex.Message);
		}
		if (androidJavaObject3 == null)
		{
			return false;
		}
		return true;
	}

	public IEnumerator LoadUrl(string Url)
	{
		if (Url == null)
		{
			yield break;
		}
		webViewObject = new GameObject("WebViewObject").AddComponent<WebViewObject>();
		webViewObject.Init(delegate(string msg)
		{
			Debug.Log(string.Format("CallFromJS[{0}]", msg));
		}, false, "Mozilla/5.0 (iPhone; CPU iPhone OS 7_1_2 like Mac OS X) AppleWebKit/537.51.2 (KHTML, like Gecko) Version/7.0 Mobile/11D257 Safari/9537.53", delegate(string msg)
		{
			Debug.Log(string.Format("CallOnError[{0}]", msg));
		}, true);
		webViewObject.SetMargins((int)scaleX(webViewLeft), (int)scaleY(webViewTop), (int)scaleX(webViewRight), (int)scaleY(webViewBottom));
		webViewObject.SetVisibility(true);
		if (Url.StartsWith("https"))
		{
			webViewObject.LoadURL(Url.Replace(" ", "%20"));
			yield break;
		}
		string[] exts = new string[2] { ".jpg", ".html" };
		string[] array = exts;
		foreach (string ext in array)
		{
			string url = Url.Replace(".html", ext);
			string src = Path.Combine(Application.streamingAssetsPath, url);
			string dst = Path.Combine(Application.persistentDataPath, url);
			byte[] result = null;
			if (src.Contains("://"))
			{
				WWW www = new WWW(src);
				yield return www;
				result = www.bytes;
			}
			else
			{
				result = File.ReadAllBytes(src);
			}
			File.WriteAllBytes(dst, result);
			if (ext == ".html")
			{
				webViewObject.LoadURL("file://" + dst.Replace(" ", "%20"));
				break;
			}
		}
	}

	private float scaleX(float x)
	{
		return x * (float)Screen.width / 320f;
	}

	private float scaleY(float y)
	{
		return y * (float)Screen.height / 480f;
	}
}
