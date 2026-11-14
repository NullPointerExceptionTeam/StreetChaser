using System;
using UnityEngine;

public class WebViewObject : MonoBehaviour
{
	private Action<string> onJS;

	private Action<string> onError;

	private bool visibility;

	public AndroidJavaObject webView;

	private bool mIsKeyboardVisible;

	public bool IsKeyboardVisible
	{
		get
		{
			return mIsKeyboardVisible;
		}
	}

	public void SetKeyboardVisible(string pIsVisible)
	{
		mIsKeyboardVisible = pIsVisible == "true";
	}

	public void Init(Action<string> cb = null, bool transparent = false, string ua = "Mozilla/5.0 (iPhone; CPU iPhone OS 7_1_2 like Mac OS X) AppleWebKit/537.51.2 (KHTML, like Gecko) Version/7.0 Mobile/11D257 Safari/9537.53", Action<string> err = null, bool enableWKWebView = false)
	{
		onJS = cb;
		onError = err;
		webView = new AndroidJavaObject("com.igoldtech.webview.WebViewPlugin");
		webView.Call("Init", base.name, transparent);
	}

	protected virtual void OnDestroy()
	{
		if (webView != null)
		{
			webView.Call("Destroy");
			webView = null;
		}
	}

	public void SetCenterPositionWithScale(Vector2 center, Vector2 scale)
	{
	}

	public void SetMargins(int left, int top, int right, int bottom)
	{
		if (webView != null)
		{
			webView.Call("SetMargins", left, top, right, bottom);
		}
	}

	public void SetVisibility(bool v)
	{
		if (webView != null)
		{
			webView.Call("SetVisibility", v);
			visibility = v;
		}
	}

	public bool GetVisibility()
	{
		return visibility;
	}

	public void LoadURL(string url)
	{
		if (!string.IsNullOrEmpty(url) && webView != null)
		{
			webView.Call("LoadURL", url);
		}
	}

	public string androidInstalledAppList()
	{
		AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.igoldtech.webview.WebViewPlugin");
		androidJavaObject.Call("Init", base.name, true);
		string text = androidJavaObject.Call<string>("getInstalledAppList", new object[0]);
		Debug.Log(" : installedList  : " + text);
		return text;
	}

	public bool isInstalledApp(string _bundleID)
	{
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
		AndroidJavaObject androidJavaObject2 = androidJavaObject.Call<AndroidJavaObject>("getPackageManager", new object[0]);
		Debug.Log(" ********LaunchOtherApp ");
		AndroidJavaObject androidJavaObject3 = null;
		try
		{
			androidJavaObject3 = androidJavaObject2.Call<AndroidJavaObject>("getLaunchIntentForPackage", new object[1] { _bundleID });
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

	public void EvaluateJS(string js)
	{
		if (webView != null)
		{
			webView.Call("LoadURL", "javascript:" + js);
		}
	}

	public void GoBack()
	{
		if (webView != null)
		{
			webView.Call("GoBack");
		}
	}

	public void GoForward()
	{
		if (webView != null)
		{
			webView.Call("GoForward");
		}
	}

	public void CallOnError(string message)
	{
		if (onError != null)
		{
			onError(message);
		}
	}

	public void CallFromJS(string message)
	{
		if (onJS != null)
		{
			onJS(message);
		}
	}
}
