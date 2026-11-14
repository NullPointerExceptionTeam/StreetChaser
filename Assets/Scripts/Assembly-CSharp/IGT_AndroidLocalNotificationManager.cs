using UnityEngine;

public class IGT_AndroidLocalNotificationManager
{
	private const string ActivityName = "com.unity3d.player.UnityPlayerActivity";

	private const string ClassName = "com.igoldtech.an.androidlocalnotification.AndroidNotification";

	private const string Game_Notification_FunctionName = "setGameNotification";

	private const string Life_Notification_FunctionName = "setLifeNotification";

	private const string Cancel_Notification_FunctionName = "cancelAll_Notification";

	private const string NotificationPause_FunctionName = "onNotificationPause";

	private const string NotificationResume_FunctionName = "onNotificationResume";

	private const string Cancel_LifeNotification_FunctionName = "cancel_Life_Notification";

	private AndroidJavaObject jo;

	private static IGT_AndroidLocalNotificationManager pIGT_LocalNotify;

	public IGT_AndroidLocalNotificationManager()
	{
#if UNITY_ANDROID
		jo = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
#endif
	}

	public static IGT_AndroidLocalNotificationManager getInstance()
	{
		if (pIGT_LocalNotify == null)
		{
			pIGT_LocalNotify = new IGT_AndroidLocalNotificationManager();
		}
		return pIGT_LocalNotify;
	}

	public void setGameNotification(int firstAlarm_Interval, int secondAlarm_Interval, int repeatAlarm_Interval)
	{
#if UNITY_ANDROID
		cancelAllNotification();
		new AndroidJavaClass("com.igoldtech.an.androidlocalnotification.AndroidNotification").CallStatic("setGameNotification", jo, "com.unity3d.player.UnityPlayerActivity", firstAlarm_Interval, secondAlarm_Interval, repeatAlarm_Interval);
#endif
	}

	public void onPause()
	{
#if UNITY_ANDROID
		new AndroidJavaClass("com.igoldtech.an.androidlocalnotification.AndroidNotification").CallStatic("onNotificationPause", jo, "com.unity3d.player.UnityPlayerActivity");
#endif
	}

	public void onResume()
	{
#if UNITY_ANDROID
		new AndroidJavaClass("com.igoldtech.an.androidlocalnotification.AndroidNotification").CallStatic("onNotificationResume", jo, "com.unity3d.player.UnityPlayerActivity");
#endif
	}

	public void setLifeNotification(long delayInSeconds)
	{
#if UNITY_ANDROID
		new AndroidJavaClass("com.igoldtech.an.androidlocalnotification.AndroidNotification").CallStatic("setLifeNotification", jo, delayInSeconds * 1000, "com.unity3d.player.UnityPlayerActivity");
#endif
	}

	public void cancelAllNotification()
	{
#if UNITY_ANDROID
		new AndroidJavaClass("com.igoldtech.an.androidlocalnotification.AndroidNotification").CallStatic("cancelAll_Notification", jo, "com.unity3d.player.UnityPlayerActivity");
#endif
	}

	public void cancelLifeNotification()
	{
#if UNITY_ANDROID
		new AndroidJavaClass("com.igoldtech.an.androidlocalnotification.AndroidNotification").CallStatic("cancel_Life_Notification", jo, "com.unity3d.player.UnityPlayerActivity");
#endif
	}
}
