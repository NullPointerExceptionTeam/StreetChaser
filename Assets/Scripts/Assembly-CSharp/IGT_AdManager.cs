using System;
using System.Collections;
using GoogleMobileAds.Api;
using UnityEngine;

public class IGT_AdManager
{
	private Action<string, double> delegateRewardedVideoAd;

	private Action<bool> delegateRewardedVideoAdClosed;

	private Action<bool> delegateAdView;

	private string kStratupAd = "kShowStartupAd";

	private string kInetrShowIntervel = "kInetrShowIntervel";

	private string kInetrStartupAdShow = "kInetrStartupAdShow";

	private const int DEF_INTERSHOWINTERVAL = 3;

	private const int DEF_STARTUPAD = 1;

	private int interShowIntervel = 3;

	private int startupAd = 1;

	public double lastIntetAdShown;

	public webView pWebViewObj;

	public BannerView bannerView;

	private InterstitialAd interstitial;

	private RewardBasedVideoAd rewardBasedVideo;

	private string iosBannerAdID;

	private string iosInterAdID;

	private string andBannerAdID;

	private string andInterAdID;

	private string iosRewardedAdID;

	private string andRewardedAdID;

	private string iosPanelAdUrl;

	private string andPanelAdUrl;

	private float fStartupAdTime = 5f;

	private DateTime Jan1st2017 = new DateTime(2017, 1, 1, 0, 0, 0, DateTimeKind.Utc);

	private static string outputMessage;

	public string outputMsg = "Ad Test";

	public string testMsg = "Test";

	private bool bRewardedVideoCompleted;

	public bool bLogoScrn { get; set; }

	public bool bDisabledAd { get; set; }

	public static string OutputMessage
	{
		set
		{
			outputMessage = value;
		}
	}

	public IGT_AdManager(string timeInterUrl = null, AdPosition _adPos = AdPosition.Bottom)
	{
		bDisabledAd = true;
		bLogoScrn = false;
		bRewardedVideoCompleted = false;
		if (PlayerPrefs.HasKey(kInetrShowIntervel))
		{
			interShowIntervel = PlayerPrefs.GetInt(kInetrShowIntervel, 3);
		}
		if (PlayerPrefs.HasKey(kInetrStartupAdShow))
		{
			startupAd = PlayerPrefs.GetInt(kInetrStartupAdShow, 1);
		}
		if (timeInterUrl != null)
		{
			Coroutiner.StartCoroutine(geturlData(new WWW(timeInterUrl)));
		}
		pWebViewObj = new webView();
		pWebViewObj.setWebViewMargins();
		lastIntetAdShown = 0.0;
	}

	public void Log(string str)
	{
		IGT_GameView.sTitle = "Log: " + str;
		outputMsg = str;
	}

	public void setStartupAdTime(float _fStartupAdTime)
	{
		fStartupAdTime = _fStartupAdTime;
	}

	public void setAdViewDelegate(Action<bool> _delegateAdView)
	{
		delegateAdView = _delegateAdView;
	}

	public void setRewardedVideoAdDelegate(Action<string, double> _methodInfo, Action<bool> _delegateClosed = null)
	{
		delegateRewardedVideoAd = _methodInfo;
		delegateRewardedVideoAdClosed = _delegateClosed;
	}

	public bool isInstalledApp(string bundleID)
	{
		return false;
	}

	private IEnumerator geturlData(WWW timeInterUrl)
	{
		yield return timeInterUrl;
		if (timeInterUrl.error == null)
		{
			string[] array = timeInterUrl.text.Split(' ');
			PlayerPrefs.SetInt(kInetrStartupAdShow, Convert.ToInt32(array[0]));
			startupAd = PlayerPrefs.GetInt(kInetrStartupAdShow, 1);
			PlayerPrefs.SetInt(kInetrShowIntervel, Convert.ToInt32(array[1]));
			interShowIntervel = PlayerPrefs.GetInt(kInetrShowIntervel, 3);
		}
		else
		{
			Debug.Log(timeInterUrl.error);
		}
	}

	private double currentTimeMillis()
	{
		return (DateTime.UtcNow - Jan1st2017).TotalMilliseconds;
	}

	public void initInterAdIDs(string _iosInterAdID, string _andInterAdID)
	{
		iosInterAdID = _iosInterAdID;
		andInterAdID = _andInterAdID;
	}

	public void initRewardAdIDs(string _iosRewardedAdID, string _andRewardedAdID)
	{
		iosRewardedAdID = _iosRewardedAdID;
		andRewardedAdID = _andRewardedAdID;
	}

	public void initPanelAdURL(string _iosPanelAdUrl, string _andPanelAdUrl, string closeBtn = null)
	{
		iosPanelAdUrl = _iosPanelAdUrl;
		andPanelAdUrl = _andPanelAdUrl;
	}

	public void showBannerAd()
	{
	}

	public void hideBannerAd()
	{
	}

	public void destroyBannerAd()
	{
	}

	private void RequestBanner()
	{
	}

	public void RequestInterstitial()
	{
	}

	private AdRequest createAdRequest()
	{
		return new AdRequest.Builder().Build();
	}

	public void RequestRewardBasedVideo()
	{
	}

	public bool isInterstitialAdAvailable()
	{
		return false;
	}

	public bool isRewardBasedVideoAvailable()
	{
		return false;
	}

	public void loadReqRewardBasedVideo()
	{
	}

	public void ShowStartupAd()
	{
	}

	private IEnumerator ShowStartupInter()
	{
		yield break;
	}

	private bool isConnectedInternet()
	{
		return false;
	}

	public void ShowInterstitial()
	{
	}

	public void ShowRewardBasedVideo()
	{
	}

	public void ShowPanelAds()
	{
	}

	public void OnClosePanelAdView()
	{
	}

	public void HandleAdLoaded(object sender, EventArgs args)
	{
	}

	public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
	}

	public void HandleAdOpened(object sender, EventArgs args)
	{
	}

	private void HandleAdClosing(object sender, EventArgs args)
	{
	}

	public void HandleAdClosed(object sender, EventArgs args)
	{
	}

	public void HandleAdLeftApplication(object sender, EventArgs args)
	{
	}

	public void HandleInterstitialLoaded(object sender, EventArgs args)
	{
	}

	public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
	}

	public void HandleInterstitialOpened(object sender, EventArgs args)
	{
		if (delegateAdView != null)
		{
			delegateAdView(true);
		}
	}

	private void HandleInterstitialClosing(object sender, EventArgs args)
	{
	}

	public void HandleInterstitialClosed(object sender, EventArgs args)
	{
		if (delegateAdView != null)
		{
			delegateAdView(false);
		}
	}

	public void HandleInterstitialLeftApplication(object sender, EventArgs args)
	{
	}

	public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
	{
	}

	public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
	}

	public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
	{
		bRewardedVideoCompleted = false;
		if (delegateAdView != null)
		{
			delegateAdView(true);
		}
		lastIntetAdShown = currentTimeMillis();
	}

	public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
	{
	}

	public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
	{
		lastIntetAdShown = currentTimeMillis();
		if (delegateAdView != null)
		{
			delegateAdView(false);
		}
		if (delegateRewardedVideoAdClosed != null && bRewardedVideoCompleted)
		{
			delegateRewardedVideoAdClosed(true);
		}
		else if (delegateRewardedVideoAdClosed != null)
		{
			delegateRewardedVideoAdClosed(false);
		}
	}

	public void HandleRewardBasedVideoRewarded(object sender, Reward args)
	{
		string type = args.Type;
		double amount = args.Amount;
		Log("HandleRewardBasedVideoRewarded event received for " + amount + " " + type);
		bRewardedVideoCompleted = true;
		if (delegateRewardedVideoAd != null)
		{
			delegateRewardedVideoAd(type, amount);
		}
	}

	public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
	{
	}
}