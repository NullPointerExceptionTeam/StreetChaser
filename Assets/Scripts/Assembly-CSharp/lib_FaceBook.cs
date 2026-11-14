using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Facebook.MiniJSON;
using Facebook.Unity;
using SQLite4Unity3d;
using UnityEngine;

public class lib_FaceBook
{
	public int status = IGT_Preference.getInstance()._Get("liststatus", 0);

	private const string kFBLISTSTATUS = "liststatus";

	private const string kFBLOGINCHECK = "loginkey";

	private SQLiteConnection sqlliteConn;

	private static readonly List<string> readPermissions = new List<string> { "public_profile", "user_friends" };

	private static readonly List<string> publishPermissions = new List<string> { "publish_actions" };

	public bool bFBLoginSucess;

	public int nPicSize = 64;

	public int nTotUserLim = 100;

	public Dictionary<string, FBFriendInfoList> UserFrndsInfo = new Dictionary<string, FBFriendInfoList>();

	public Dictionary<string, FBFriendInfoList> Chase_Friends = new Dictionary<string, FBFriendInfoList>();

	public Dictionary<string, FBFriendInfoList> Chase_Global = new Dictionary<string, FBFriendInfoList>();

	public Dictionary<string, FBFriendInfoList> Mission_Friends = new Dictionary<string, FBFriendInfoList>();

	public Dictionary<string, FBFriendInfoList> Mission_Global = new Dictionary<string, FBFriendInfoList>();

	private Action<int> getDataSucess;

	private string strDeviceID;

	public bool bGlobalTop5inChase;

	public bool bGlobalTop5inMission;

	public List<string> strInvitedList = new List<string>();

	public Dictionary<string, string> dictAskReqID = new Dictionary<string, string>();

	public Dictionary<string, string> dictSendReqID = new Dictionary<string, string>();

	public Dictionary<string, string> dictPicUrl = new Dictionary<string, string>();

	public string sMeUserID;

	public string sMeUserName;

	public string strUrl;

	private Action pInitActivateSucess;

	private Action<int> processDeleteAppReqSucess;

	private Action<int> processDeleteAppReqFailed;

	public bool HavePublishPermission
	{
		get
		{
			return (FB.IsLoggedIn && (AccessToken.CurrentAccessToken.Permissions as List<string>).Contains("publish_actions")) ? true : false;
		}
		private set
		{
		}
	}

	public bool HaveFrndListPermission
	{
		get
		{
			return (FB.IsLoggedIn && (AccessToken.CurrentAccessToken.Permissions as List<string>).Contains("user_friends")) ? true : false;
		}
		private set
		{
		}
	}

	public lib_FaceBook(string _sFBDBFileName, Action fbAppActivatedSucess = null)
	{
		if (fbAppActivatedSucess != null)
		{
			pInitActivateSucess = fbAppActivatedSucess;
		}
		if (IGT_Preference.getInstance()._Get("loginkey", 0) == 1)
		{
			bFBLoginSucess = true;
		}
		else
		{
			bFBLoginSucess = false;
		}
		if (_sFBDBFileName != null)
		{
			DBSettings(_sFBDBFileName);
		}
		if (!FB.IsInitialized)
		{
			FB.Init(InitCallback, OnHideUnity);
		}
		else
		{
			FB.ActivateApp();
			loadDataToDic();
			loadFrndsMissionDataToDic();
			if (isFBLoginSucess() && sMeUserID == null)
			{
				sMeUserID = getMEUserID();
			}
			if (fbAppActivatedSucess != null)
			{
				fbAppActivatedSucess();
			}
		}
		if (IGT_GameView.strDeviceID != null)
		{
			strDeviceID = IGT_GameView.strDeviceID;
		}
		else
		{
			strDeviceID = IGT_GameView.getDeviceID();
		}
		sqlliteConn.CreateTable<SQL_FBFrndTable>();
		sqlliteConn.CreateTable<SQL_FBFrndTableChase>();
		sqlliteConn.CreateTable<SQL_FBFrndTableMission>();
		sqlliteConn.CreateTable<SQL_GlobalListTableChase>();
		sqlliteConn.CreateTable<SQL_GlobalListTableMission>();
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

	private void InitCallback()
	{
		if (FB.IsInitialized)
		{
			FB.ActivateApp();
			if (pInitActivateSucess != null)
			{
				pInitActivateSucess();
			}
		}
	}

	private void OnHideUnity(bool isGameShown)
	{
		if (!isGameShown)
		{
			Time.timeScale = 0f;
		}
		else
		{
			Time.timeScale = 1f;
		}
	}

	public void setProfilePicSize(int _nPicSize)
	{
		nPicSize = _nPicSize;
	}

	public bool isFBLoginSucess()
	{
		if (IGT_Preference.getInstance()._Get("loginkey", 0) == 1)
		{
			bFBLoginSucess = true;
		}
		else
		{
			bFBLoginSucess = false;
		}
		return bFBLoginSucess;
	}

	public void FBLogin(Action FBLoginCompleted = null, Action FBLoginFailed = null)
	{
		status = 1;
		IGT_Preference.getInstance()._Set("liststatus", 1);
		FB.LogInWithReadPermissions(readPermissions, delegate(ILoginResult result)
		{
			if (FB.IsLoggedIn)
			{
				string query = "/me?fields=id,first_name,picture.width(" + nPicSize + ").height(" + nPicSize + ")";
				FB.API(query, HttpMethod.GET, delegate(IGraphResult graphResult)
				{
					FBFriendInfoList fBFriendInfoList = new FBFriendInfoList();
					string value;
					if (graphResult.ResultDictionary.TryGetValue<string>("id", out value))
					{
						fBFriendInfoList.userID = value;
						sMeUserID = value;
					}
					fBFriendInfoList.userName = "Me";
					if (fBFriendInfoList.userID != null)
					{
						if (!UserFrndsInfo.ContainsKey(fBFriendInfoList.userID))
						{
							UserFrndsInfo.Add(fBFriendInfoList.userID, fBFriendInfoList);
						}
						else
						{
							UserFrndsInfo[fBFriendInfoList.userID] = fBFriendInfoList;
						}
					}
					IGT_Preference.getInstance()._Set("loginkey", 1);
					bFBLoginSucess = true;
					if (FBLoginCompleted != null)
					{
						status = 2;
						IGT_Preference.getInstance()._Set("liststatus", 2);
						FBLoginCompleted();
					}
				});
			}
			else
			{
				if (result.Error != null)
				{
				}
				if (FBLoginFailed != null)
				{
					status = 3;
					IGT_Preference.getInstance()._Set("liststatus", 3);
					FBLoginFailed();
				}
			}
		});
	}

	public void getMeUserName(Action<string> updateMeUserName = null)
	{
		if (!FB.IsLoggedIn)
		{
			return;
		}
		string query = "/me?fields=first_name";
		FB.API(query, HttpMethod.GET, delegate(IGraphResult result)
		{
			if (result.Error == null)
			{
				if (updateMeUserName != null)
				{
					updateMeUserName(result.ResultDictionary["first_name"].ToString());
				}
			}
			else
			{
				Debug.Log("Error : " + result.Error);
			}
		});
	}

	public string getMEUserID()
	{
		if (!string.IsNullOrEmpty(sMeUserID))
		{
			return sMeUserID;
		}
		if (string.IsNullOrEmpty(sMeUserID))
		{
			if (!string.IsNullOrEmpty(AccessToken.CurrentAccessToken.UserId))
			{
				sMeUserID = AccessToken.CurrentAccessToken.UserId;
				if (sMeUserID != null && UserFrndsInfo != null && !UserFrndsInfo.ContainsKey(sMeUserID))
				{
					FBFriendInfoList fBFriendInfoList = new FBFriendInfoList();
					fBFriendInfoList.userID = sMeUserID;
					fBFriendInfoList.userName = "Me";
					UserFrndsInfo.Add(sMeUserID, fBFriendInfoList);
					storeDicData();
				}
				return sMeUserID;
			}
			if (UserFrndsInfo != null)
			{
				foreach (KeyValuePair<string, FBFriendInfoList> item in UserFrndsInfo)
				{
					if (item.Value.userName.Equals("Me"))
					{
						return item.Key;
					}
				}
			}
		}
		return null;
	}

	public void FBTaggableFriends(Action<Dictionary<string, FBFriendInfoList>> tagFriendsListCompleted = null, Action tagFriendsListFailed = null, Action noFriendList = null)
	{
		Dictionary<string, FBFriendInfoList> dictionary = new Dictionary<string, FBFriendInfoList>();
		if (isFBLoginSucess() && HaveFrndListPermission)
		{
			dictionary = UserFrndsInfo;
			if (tagFriendsListCompleted != null)
			{
				tagFriendsListCompleted(dictionary);
			}
		}
		else if (isFBLoginSucess() && !HaveFrndListPermission)
		{
			if (noFriendList != null)
			{
				noFriendList();
			}
		}
		else if (!isFBLoginSucess() && tagFriendsListFailed != null)
		{
			tagFriendsListFailed();
		}
	}

	public void FBFeedShare(string imageURL, Action fbfeedShareSuccess = null, Action fbfeedShareFailed = null, string friendstoTag = null)
	{
		if (isFBLoginSucess() && HavePublishPermission)
		{
			FB.API("/me/feed?link=" + imageURL + "&tags=" + friendstoTag, HttpMethod.POST, delegate(IGraphResult result)
			{
				if (result.Error == null && result.RawResult.Contains("id"))
				{
					if (fbfeedShareSuccess != null)
					{
						fbfeedShareSuccess();
					}
				}
				else if (fbfeedShareFailed != null)
				{
					fbfeedShareFailed();
				}
			});
		}
		else if (isFBLoginSucess())
		{
			FB.LogInWithPublishPermissions(publishPermissions, delegate
			{
				FB.API("/me/feed?link=" + imageURL, HttpMethod.POST, delegate(IGraphResult feedshareresult)
				{
					if (feedshareresult.Error == null && feedshareresult.RawResult.Contains("id"))
					{
						if (fbfeedShareSuccess != null)
						{
							fbfeedShareSuccess();
						}
					}
					else if (fbfeedShareFailed != null)
					{
						fbfeedShareFailed();
					}
				});
			});
		}
		else
		{
			Debug.Log("not loggedin");
		}
	}

	public void requestPublishPermission(Action<bool> permissionGiven = null)
	{
		FB.LogInWithPublishPermissions(publishPermissions, delegate(ILoginResult result)
		{
			if (result.Error == null && !result.Cancelled)
			{
				if (permissionGiven != null)
				{
					permissionGiven(true);
				}
			}
			else if (permissionGiven != null)
			{
				permissionGiven(false);
			}
		});
	}

	public void requestReadPermission(Action<bool> permissionGiven = null, Action<bool> permissionDenied = null)
	{
		FB.LogInWithPublishPermissions(readPermissions, delegate(ILoginResult result)
		{
			if (result.Error == null && !result.Cancelled)
			{
				if (permissionGiven != null)
				{
					permissionGiven(true);
				}
			}
			else if (permissionDenied != null)
			{
				permissionDenied(false);
			}
		});
	}

	public void FBLike(string _fbPageID = null, string _fbPageLink = null, Action<bool> isLikePageOpened = null)
	{
		if (!isFBLoginSucess())
		{
			return;
		}
		if (IGT_GameView.pMoregame.isInstalledApp("com.facebook.katana"))
		{
			Application.OpenURL("fb://page/" + _fbPageID);
			if (isLikePageOpened != null)
			{
				isLikePageOpened(true);
			}
		}
		else
		{
			Coroutiner.StartCoroutine(IGT_GameView.pMoregame.LoadUrl("https://www.facebook.com/" + _fbPageLink));
			if (isLikePageOpened != null)
			{
				isLikePageOpened(true);
			}
		}
	}

	public void checkUserFBLike(string _fbPageID, Action<bool> isFBPageLiked = null)
	{
		FB.API("me/likes/" + _fbPageID, HttpMethod.GET, delegate(IGraphResult result)
		{
			if (result.RawResult != null)
			{
				if (result.ResultDictionary.ContainsKey("data") && result.RawResult.Contains(_fbPageID))
				{
					if (isFBPageLiked != null)
					{
						isFBPageLiked(true);
					}
				}
				else if (isFBPageLiked != null)
				{
					isFBPageLiked(false);
				}
			}
		});
	}

	public Dictionary<string, string> getDictAskReqID()
	{
		return dictAskReqID;
	}

	public Dictionary<string, string> getDictSendReqID()
	{
		return dictSendReqID;
	}

	public void ProcessAppRequest(Action ProcessAppRequestComplete = null)
	{
		if (!FB.IsLoggedIn)
		{
			return;
		}
		FB.API("/me/apprequests", HttpMethod.GET, delegate(IGraphResult result)
		{
			if (result.Error == null && !result.Cancelled)
			{
				Dictionary<string, object> dictionary = Json.Deserialize(result.RawResult) as Dictionary<string, object>;
				List<object> list = (List<object>)dictionary["data"];
				for (int i = 0; i < list.Count; i++)
				{
					string text = null;
					object value;
					if (((Dictionary<string, object>)list[i]).TryGetValue("data", out value))
					{
						text = (string)value;
					}
					string[] array = null;
					if (text != null)
					{
						array = text.Split('~');
						if (array.Length > 1 && array[1].Equals("Ask"))
						{
							string dataValueforKey = getDataValueforKey((Dictionary<string, object>)list[i], "id");
							Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
							object value2;
							if (((Dictionary<string, object>)list[i]).TryGetValue("from", out value2))
							{
								dictionary2 = (Dictionary<string, object>)value2;
							}
							string key = (string)dictionary2["id"];
							if (dictAskReqID != null)
							{
								if (!dictAskReqID.ContainsKey(key))
								{
									dictAskReqID.Add(key, dataValueforKey);
								}
								else if (!dictAskReqID.ContainsValue(dataValueforKey))
								{
									deleteAppReq(dataValueforKey);
								}
							}
						}
						else if (array.Length > 1 && array[1].Equals("Send"))
						{
							string dataValueforKey2 = getDataValueforKey((Dictionary<string, object>)list[i], "id");
							Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
							object value3;
							if (((Dictionary<string, object>)list[i]).TryGetValue("from", out value3))
							{
								dictionary3 = (Dictionary<string, object>)value3;
							}
							string key2 = (string)dictionary3["id"];
							if (dictSendReqID != null)
							{
								if (!dictSendReqID.ContainsKey(key2))
								{
									dictSendReqID.Add(key2, dataValueforKey2);
								}
								else if (!dictSendReqID.ContainsValue(dataValueforKey2))
								{
									deleteAppReq(dataValueforKey2);
								}
							}
						}
					}
				}
			}
			else
			{
				Debug.Log("ProcessAppRequest Error : " + result.Error);
			}
			if (ProcessAppRequestComplete != null)
			{
				ProcessAppRequestComplete();
			}
		});
	}

	public void processDeleteAppReq(List<string> _ReqUserIDs, int _ActionType, Action<int> _processDeleteAppReqSucess = null, Action<int> _processDeleteAppReqFailed = null)
	{
		if (!FB.IsLoggedIn)
		{
			return;
		}
		if (_processDeleteAppReqSucess != null)
		{
			processDeleteAppReqSucess = _processDeleteAppReqSucess;
		}
		if (_processDeleteAppReqFailed != null)
		{
			processDeleteAppReqFailed = _processDeleteAppReqFailed;
		}
		switch (_ActionType)
		{
		case 1:
		{
			for (int j = 0; j < _ReqUserIDs.Count; j++)
			{
				string text2 = null;
				if (dictAskReqID.ContainsKey(_ReqUserIDs[j]))
				{
					text2 = dictAskReqID[_ReqUserIDs[j]];
					deleteAppReq(text2, _ReqUserIDs[j], appReqDeleteSucess, appReqDeleteFailed);
					continue;
				}
				break;
			}
			break;
		}
		case 0:
		{
			for (int i = 0; i < _ReqUserIDs.Count; i++)
			{
				string text = null;
				if (dictSendReqID.ContainsKey(_ReqUserIDs[i]))
				{
					text = dictSendReqID[_ReqUserIDs[i]];
					IGT_GameView.dMailBoxSentCount++;
					deleteAppReq(text, _ReqUserIDs[i], appReqDeleteSucess, appReqDeleteFailed);
					continue;
				}
				break;
			}
			break;
		}
		}
	}

	private void appReqDeleteSucess(string appReqID, string reqUserID)
	{
		if (reqUserID == null)
		{
			return;
		}
		if (dictSendReqID.ContainsValue(appReqID) && dictSendReqID.ContainsKey(reqUserID))
		{
			dictSendReqID.Remove(reqUserID);
			if (processDeleteAppReqSucess != null)
			{
				processDeleteAppReqSucess(0);
			}
		}
		else if (dictAskReqID.ContainsValue(appReqID) && dictAskReqID.ContainsKey(reqUserID))
		{
			dictAskReqID.Remove(reqUserID);
			if (processDeleteAppReqSucess != null)
			{
				processDeleteAppReqSucess(1);
			}
		}
	}

	private void appReqDeleteFailed(string appReqID, string reqUserID)
	{
		if (processDeleteAppReqFailed != null && reqUserID != null)
		{
			if (dictSendReqID.ContainsValue(appReqID) && dictSendReqID.ContainsKey(reqUserID))
			{
				processDeleteAppReqFailed(0);
			}
			else if (dictAskReqID.ContainsValue(appReqID) && dictAskReqID.ContainsKey(reqUserID))
			{
				processDeleteAppReqFailed(1);
			}
		}
		dictAskReqID.Clear();
		dictSendReqID.Clear();
	}

	private void deleteAppReq(string _appReqID, string _reqID = null, Action<string, string> appReqDeleteSucess = null, Action<string, string> appReqDeleteFailed = null)
	{
		if (FB.IsLoggedIn)
		{
			FB.API("/" + _appReqID, HttpMethod.DELETE, delegate(IGraphResult result)
			{
				if (result.Error != null || result.Cancelled)
				{
					Debug.Log("Error : " + result.Error);
					if (appReqDeleteFailed != null)
					{
						appReqDeleteFailed(_appReqID, _reqID);
					}
				}
				else
				{
					Debug.Log(result.RawResult + " Delete app req call req id : " + _appReqID);
					if (appReqDeleteSucess != null)
					{
						appReqDeleteSucess(_appReqID, _reqID);
					}
				}
			});
		}
		else
		{
			Debug.Log("FB is not logged in...");
		}
	}

	public void FBShare(string sTitle, string sMsg, string sShareURL = null, Action ShareReqSucess = null, Action ShareReqFailed = null, string sPhotoURL = null)
	{
		if (!FB.IsLoggedIn)
		{
			return;
		}
		Uri contentURL = null;
		if (sShareURL != null)
		{
			contentURL = new Uri(sShareURL);
		}
		Uri photoURL = null;
		if (sPhotoURL != null)
		{
			photoURL = new Uri(sPhotoURL);
		}
		FB.ShareLink(contentURL, sTitle, sMsg, photoURL, delegate(IShareResult result)
		{
			if (string.IsNullOrEmpty(result.Error) && !result.Cancelled)
			{
				if (ShareReqSucess != null)
				{
					ShareReqSucess();
				}
			}
			else
			{
				if (result.Cancelled)
				{
					Debug.Log("failed Share for result.Cancelled ");
				}
				if (ShareReqFailed != null)
				{
					ShareReqFailed();
				}
			}
		});
	}

	public void FBInvite(string inviteUri, Action<string> AppInviteSucess = null, Action<string> AppInviteFailed = null)
	{
		if (!FB.IsLoggedIn)
		{
			return;
		}
		FB.Mobile.AppInvite(new Uri(inviteUri), null, delegate(IAppInviteResult result)
		{
			if (result.Error != null)
			{
				Debug.Log("result.Error : " + result.Error);
				if (AppInviteFailed != null)
				{
					AppInviteFailed(result.Error);
				}
			}
			else if (!result.Cancelled && result.RawResult != null)
			{
				if (AppInviteSucess != null)
				{
					AppInviteSucess(result.RawResult);
				}
			}
			else if (AppInviteFailed != null)
			{
				AppInviteFailed(result.Error);
			}
		});
	}

	private string FindDataFromStr(string _SrcStr, string _SubStr)
	{
		int num = _SrcStr.IndexOf(_SubStr);
		return _SrcStr.ToCharArray()[num + _SubStr.Length].ToString();
	}

	public void storeDicData()
	{
		IOrderedEnumerable<FBFriendInfoList> source = UserFrndsInfo.Values.OrderByDescending((FBFriendInfoList FBFriendInfoList) => FBFriendInfoList.userScore);
		for (int num = 0; num < source.ToList().Count; num++)
		{
			UserFrndsInfo[source.ElementAt(num).userID].rank = num + 1;
		}
		sqlliteConn.DropTable<SQL_FBFrndTable>();
		sqlliteConn.CreateTable<SQL_FBFrndTable>();
		foreach (KeyValuePair<string, FBFriendInfoList> item in UserFrndsInfo)
		{
			sqlliteConn.Insert(new SQL_FBFrndTable
			{
				UID = item.Value.userID,
				Name = item.Value.userName,
				userCurrentLevel = item.Value.userCurrentLevel,
				Score = item.Value.userScore,
				picData = item.Value.userProfilePicData,
				isImageLoad = item.Value.isImageLoad,
				userAskMsg = item.Value.userAskMsg,
				userSendMsg = item.Value.userSendMsg,
				gameType = item.Value.gameType,
				rank = item.Value.rank
			});
		}
	}

	public void loadDataToDic()
	{
		if (!bFBLoginSucess)
		{
			return;
		}
		if (UserFrndsInfo.Count > 0)
		{
			UserFrndsInfo.Clear();
		}
		TableQuery<SQL_FBFrndTable> tableQuery = sqlliteConn.Table<SQL_FBFrndTable>();
		foreach (SQL_FBFrndTable item in tableQuery)
		{
			FBFriendInfoList fBFriendInfoList = new FBFriendInfoList();
			fBFriendInfoList.userID = item.UID;
			fBFriendInfoList.userName = item.Name;
			fBFriendInfoList.userCurrentLevel = item.userCurrentLevel;
			fBFriendInfoList.userScore = item.Score;
			fBFriendInfoList.userProfilePicData = item.picData;
			fBFriendInfoList.isImageLoad = item.isImageLoad;
			fBFriendInfoList.userAskMsg = item.userAskMsg;
			fBFriendInfoList.userSendMsg = item.userSendMsg;
			fBFriendInfoList.gameType = item.gameType;
			fBFriendInfoList.rank = item.rank;
			UserFrndsInfo.Add(fBFriendInfoList.userID, fBFriendInfoList);
		}
	}

	public void storeChaseFrndsData()
	{
		IOrderedEnumerable<FBFriendInfoList> source = Chase_Friends.Values.OrderByDescending((FBFriendInfoList FBFriendInfoList) => FBFriendInfoList.userScore);
		for (int num = 0; num < source.ToList().Count; num++)
		{
			Chase_Friends[source.ElementAt(num).userID].rank = num + 1;
		}
		if (getMEUserID() == null || Chase_Friends == null || !Chase_Friends.ContainsKey(getMEUserID()) || !Chase_Friends[getMEUserID()].userName.Equals("Me") || Chase_Friends.Count <= 5 || Chase_Friends[getMEUserID()].rank <= 5)
		{
		}
		sqlliteConn.DropTable<SQL_FBFrndTableChase>();
		sqlliteConn.CreateTable<SQL_FBFrndTableChase>();
		foreach (KeyValuePair<string, FBFriendInfoList> chase_Friend in Chase_Friends)
		{
			sqlliteConn.Insert(new SQL_FBFrndTableChase
			{
				UID = chase_Friend.Value.userID,
				Name = chase_Friend.Value.userName,
				userCurrentLevel = chase_Friend.Value.userCurrentLevel,
				Score = chase_Friend.Value.userScore,
				picData = chase_Friend.Value.userProfilePicData,
				isImageLoad = chase_Friend.Value.isImageLoad,
				userAskMsg = chase_Friend.Value.userAskMsg,
				userSendMsg = chase_Friend.Value.userSendMsg,
				gameType = chase_Friend.Value.gameType,
				rank = chase_Friend.Value.rank
			});
		}
	}

	public void loadChaseFrndsData()
	{
		if (!bFBLoginSucess)
		{
			return;
		}
		if (Chase_Friends.Count > 0)
		{
			Chase_Friends.Clear();
		}
		TableQuery<SQL_FBFrndTableChase> tableQuery = sqlliteConn.Table<SQL_FBFrndTableChase>();
		foreach (SQL_FBFrndTableChase item in tableQuery)
		{
			FBFriendInfoList fBFriendInfoList = new FBFriendInfoList();
			fBFriendInfoList.userID = item.UID;
			fBFriendInfoList.userName = item.Name;
			fBFriendInfoList.userCurrentLevel = item.userCurrentLevel;
			fBFriendInfoList.userScore = item.Score;
			fBFriendInfoList.userProfilePicData = item.picData;
			fBFriendInfoList.isImageLoad = item.isImageLoad;
			fBFriendInfoList.userAskMsg = item.userAskMsg;
			fBFriendInfoList.userSendMsg = item.userSendMsg;
			fBFriendInfoList.gameType = item.gameType;
			fBFriendInfoList.rank = item.rank;
			Chase_Friends.Add(fBFriendInfoList.userID, fBFriendInfoList);
		}
	}

	public void storeFrndsMissionDicData()
	{
		if (!Mission_Friends.ContainsKey(sMeUserID) && UserFrndsInfo.ContainsKey(sMeUserID))
		{
			FBFriendInfoList fBFriendInfoList = new FBFriendInfoList();
			fBFriendInfoList.userID = sMeUserID;
			fBFriendInfoList.userName = UserFrndsInfo[sMeUserID].userName;
			fBFriendInfoList.userProfilePicData = UserFrndsInfo[sMeUserID].userProfilePicData;
			fBFriendInfoList.isImageLoad = true;
			Mission_Friends.Add(sMeUserID, fBFriendInfoList);
		}
		IOrderedEnumerable<FBFriendInfoList> source = Mission_Friends.Values.OrderByDescending((FBFriendInfoList FBFriendInfoList) => FBFriendInfoList.userScore);
		for (int num = 0; num < source.ToList().Count; num++)
		{
			Mission_Friends[source.ElementAt(num).userID].rank = num + 1;
		}
		if (getMEUserID() == null || !Mission_Friends[getMEUserID()].userName.Equals("Me") || Mission_Friends.Count <= 5 || Mission_Friends[getMEUserID()].rank <= 5)
		{
		}
		sqlliteConn.DropTable<SQL_FBFrndTableMission>();
		sqlliteConn.CreateTable<SQL_FBFrndTableMission>();
		foreach (KeyValuePair<string, FBFriendInfoList> mission_Friend in Mission_Friends)
		{
			sqlliteConn.Insert(new SQL_FBFrndTableMission
			{
				UID = mission_Friend.Value.userID,
				Name = mission_Friend.Value.userName,
				userCurrentLevel = mission_Friend.Value.userCurrentLevel,
				Score = mission_Friend.Value.userScore,
				picData = mission_Friend.Value.userProfilePicData,
				isImageLoad = mission_Friend.Value.isImageLoad,
				gameType = mission_Friend.Value.gameType,
				rank = mission_Friend.Value.rank
			});
		}
	}

	public void loadFrndsMissionDataToDic()
	{
		if (!bFBLoginSucess)
		{
			return;
		}
		if (Mission_Friends.Count > 0)
		{
			Mission_Friends.Clear();
		}
		TableQuery<SQL_FBFrndTableMission> tableQuery = sqlliteConn.Table<SQL_FBFrndTableMission>();
		foreach (SQL_FBFrndTableMission item in tableQuery)
		{
			FBFriendInfoList fBFriendInfoList = new FBFriendInfoList();
			fBFriendInfoList.userID = item.UID;
			fBFriendInfoList.userName = item.Name;
			fBFriendInfoList.userCurrentLevel = item.userCurrentLevel;
			fBFriendInfoList.userScore = item.Score;
			fBFriendInfoList.userProfilePicData = item.picData;
			fBFriendInfoList.isImageLoad = item.isImageLoad;
			fBFriendInfoList.userAskMsg = item.userAskMsg;
			fBFriendInfoList.userSendMsg = item.userSendMsg;
			fBFriendInfoList.gameType = item.gameType;
			fBFriendInfoList.rank = item.rank;
			Mission_Friends.Add(fBFriendInfoList.userID, fBFriendInfoList);
		}
	}

	public void storeGlobalChaseDicData()
	{
		string text = null;
		text = ((!isFBLoginSucess()) ? strDeviceID : getMEUserID());
		if (text == null || !Chase_Global.ContainsKey(text))
		{
			return;
		}
		if (Chase_Global[text].rank <= 10)
		{
		}
		if (Chase_Global[text].rank <= 100)
		{
		}
		sqlliteConn.DropTable<SQL_GlobalListTableChase>();
		sqlliteConn.CreateTable<SQL_GlobalListTableChase>();
		foreach (KeyValuePair<string, FBFriendInfoList> item in Chase_Global)
		{
			sqlliteConn.Insert(new SQL_GlobalListTableChase
			{
				UID = item.Value.userID,
				Name = item.Value.userName,
				userCurrentLevel = item.Value.userCurrentLevel,
				Score = item.Value.userScore,
				gameType = item.Value.gameType,
				rank = item.Value.rank
			});
		}
	}

	public void loadGlobalChaseDataToDic()
	{
		if (Chase_Global.Count > 0)
		{
			Chase_Global.Clear();
		}
		TableQuery<SQL_GlobalListTableChase> tableQuery = sqlliteConn.Table<SQL_GlobalListTableChase>();
		foreach (SQL_GlobalListTableChase item in tableQuery)
		{
			FBFriendInfoList fBFriendInfoList = new FBFriendInfoList();
			fBFriendInfoList.userID = item.UID;
			fBFriendInfoList.userName = item.Name;
			fBFriendInfoList.userCurrentLevel = item.userCurrentLevel;
			fBFriendInfoList.userScore = item.Score;
			fBFriendInfoList.gameType = item.gameType;
			fBFriendInfoList.rank = item.rank;
			Chase_Global.Add(fBFriendInfoList.userID, fBFriendInfoList);
		}
	}

	public void storeGlobalMissionDicData()
	{
		string text = null;
		text = ((!isFBLoginSucess()) ? strDeviceID : getMEUserID());
		if (text == null || !Mission_Global.ContainsKey(text))
		{
			return;
		}
		if (Mission_Global[text].rank <= 10)
		{
		}
		if (Mission_Global[text].rank <= 100)
		{
		}
		sqlliteConn.DropTable<SQL_GlobalListTableMission>();
		sqlliteConn.CreateTable<SQL_GlobalListTableMission>();
		foreach (KeyValuePair<string, FBFriendInfoList> item in Mission_Global)
		{
			sqlliteConn.Insert(new SQL_GlobalListTableMission
			{
				UID = item.Value.userID,
				Name = item.Value.userName,
				userCurrentLevel = item.Value.userCurrentLevel,
				Score = item.Value.userScore,
				gameType = item.Value.gameType,
				rank = item.Value.rank
			});
		}
	}

	public void loadGlobalMissionDataToDic()
	{
		if (Mission_Global.Count > 0)
		{
			Mission_Global.Clear();
		}
		TableQuery<SQL_GlobalListTableMission> tableQuery = sqlliteConn.Table<SQL_GlobalListTableMission>();
		foreach (SQL_GlobalListTableMission item in tableQuery)
		{
			FBFriendInfoList fBFriendInfoList = new FBFriendInfoList();
			fBFriendInfoList.userID = item.UID;
			fBFriendInfoList.userName = item.Name;
			fBFriendInfoList.userCurrentLevel = item.userCurrentLevel;
			fBFriendInfoList.userScore = item.Score;
			fBFriendInfoList.gameType = item.gameType;
			fBFriendInfoList.rank = item.rank;
			Mission_Global.Add(fBFriendInfoList.userID, fBFriendInfoList);
		}
	}

	private IEnumerator getUserInfo(string _userID, Action<string, string, byte[]> delegateFunc = null)
	{
		yield return 0;
		FB.API("/" + _userID + "?fields=first_name,picture", HttpMethod.GET, delegate(IGraphResult result1)
		{
			Dictionary<string, object> dictionary = Json.Deserialize(result1.RawResult.ToString()) as Dictionary<string, object>;
			string text = null;
			if (UserFrndsInfo != null && _userID != null && UserFrndsInfo.ContainsKey(_userID) && UserFrndsInfo[_userID].userName.Equals("Me"))
			{
				text = UserFrndsInfo[_userID].userName;
			}
			else
			{
				text = (((long.Parse(_userID) < 1 || long.Parse(_userID) > 100) && dictionary.ContainsKey("first_name")) ? dictionary["first_name"].ToString() : "Player");
				if (text.Length > 8)
				{
					text = text.Substring(0, 7) + "...";
				}
				if (Chase_Global != null && Chase_Global.ContainsKey(_userID))
				{
					Chase_Global[_userID].userName = text;
				}
				if (Mission_Global != null && Mission_Global.ContainsKey(_userID))
				{
					Mission_Global[_userID].userName = text;
				}
			}
		});
	}

	private IEnumerator getProfilePic(string _userID, string _userName = null, Action<string, string, byte[]> delegateFunc = null)
	{
		string imgURL = "https://graph.facebook.com/" + _userID + "/picture?width=" + nPicSize + "&height=" + nPicSize;
		WWW www = new WWW(Uri.EscapeUriString(imgURL));
		yield return www;
		if (www.error != null)
		{
			Debug.Log(www.error);
			status = 6;
			IGT_Preference.getInstance()._Set("liststatus", 6);
			yield break;
		}
		byte[] picData = www.texture.EncodeToPNG();
		if (delegateFunc != null)
		{
			delegateFunc(_userID, _userName, picData);
		}
	}

	public IEnumerator getProfilePicture(string _userID, Texture2D profPic, int listIDX, string name, Action<int, byte[], string> success)
	{
		string imgURL = "https://graph.facebook.com/" + _userID + "/picture?width=" + nPicSize + "&height=" + nPicSize;
		WWW www = new WWW(Uri.EscapeUriString(imgURL));
		yield return www;
		if (www.error != null)
		{
			Debug.Log(www.error);
			status = 6;
			IGT_Preference.getInstance()._Set("liststatus", 6);
			yield break;
		}
		if (Chase_Global.ContainsKey(_userID) && name.Equals("Player"))
		{
			name = Chase_Global[_userID].userName;
		}
		else if (Mission_Global.ContainsKey(_userID) && name.Equals("Player"))
		{
			name = Mission_Global[_userID].userName;
		}
		success(listIDX, www.bytes, name);
	}

	public IEnumerator getDatafromURL(string _url, WWWForm _form, string _sMode, string _gameType, Action<int> GetDataSucess = null, int nCheck = 0, Action<int> GetDataFailed = null)
	{
		if (Application.internetReachability != NetworkReachability.ReachableViaLocalAreaNetwork && Application.internetReachability != NetworkReachability.ReachableViaCarrierDataNetwork)
		{
			yield break;
		}
		WWW url = new WWW(_url, _form);
		yield return url;
		if (url.error == null)
		{
			if (isFBLoginSucess() && sMeUserID == null)
			{
				sMeUserID = getMEUserID();
			}
			string datas = url.text.Trim();
			string[] arrData = datas.Split(new string[1] { Environment.NewLine }, StringSplitOptions.None);
			switch (int.Parse(_sMode))
			{
			case 1:
				if (!isFBLoginSucess())
				{
					break;
				}
				if (arrData[0].Equals("0"))
				{
					if (_gameType.Equals("0"))
					{
						for (int num = 1; num < arrData.Length; num++)
						{
							string text5 = arrData[num].Trim();
							string[] array5 = text5.Split(new string[1] { " " }, StringSplitOptions.None);
							FBFriendInfoList fBFriendInfoList6 = new FBFriendInfoList();
							fBFriendInfoList6.userID = array5[0];
							fBFriendInfoList6.userScore = int.Parse(array5[1]);
							fBFriendInfoList6.userCurrentLevel = int.Parse(array5[2]);
							fBFriendInfoList6.gameType = _gameType;
							if (!UserFrndsInfo.ContainsKey(fBFriendInfoList6.userID))
							{
								UserFrndsInfo.Add(fBFriendInfoList6.userID, fBFriendInfoList6);
							}
							else if (UserFrndsInfo.ContainsKey(fBFriendInfoList6.userID) && UserFrndsInfo[fBFriendInfoList6.userID].userScore <= fBFriendInfoList6.userScore)
							{
								UserFrndsInfo[fBFriendInfoList6.userID].userScore = fBFriendInfoList6.userScore;
								UserFrndsInfo[fBFriendInfoList6.userID].userCurrentLevel = fBFriendInfoList6.userCurrentLevel;
								UserFrndsInfo[fBFriendInfoList6.userID].gameType = fBFriendInfoList6.gameType;
							}
						}
					}
					else if (_gameType.Equals("1"))
					{
						for (int num2 = 1; num2 < arrData.Length; num2++)
						{
							string text6 = arrData[num2].Trim();
							string[] array6 = text6.Split(new string[1] { " " }, StringSplitOptions.None);
							FBFriendInfoList fBFriendInfoList7 = new FBFriendInfoList();
							fBFriendInfoList7.userID = array6[0];
							fBFriendInfoList7.userScore = int.Parse(array6[1]);
							fBFriendInfoList7.userCurrentLevel = int.Parse(array6[2]);
							fBFriendInfoList7.gameType = _gameType;
							if (!Mission_Friends.ContainsKey(fBFriendInfoList7.userID))
							{
								Mission_Friends.Add(fBFriendInfoList7.userID, fBFriendInfoList7);
								if (UserFrndsInfo.ContainsKey(fBFriendInfoList7.userID))
								{
									Mission_Friends[fBFriendInfoList7.userID].userName = UserFrndsInfo[fBFriendInfoList7.userID].userName;
								}
							}
							else if (Mission_Friends.ContainsKey(fBFriendInfoList7.userID) && Mission_Friends[fBFriendInfoList7.userID].userScore < fBFriendInfoList7.userScore)
							{
								Mission_Friends[fBFriendInfoList7.userID].userScore = fBFriendInfoList7.userScore;
								Mission_Friends[fBFriendInfoList7.userID].userCurrentLevel = fBFriendInfoList7.userCurrentLevel;
								Mission_Friends[fBFriendInfoList7.userID].gameType = fBFriendInfoList7.gameType;
								if (UserFrndsInfo.ContainsKey(fBFriendInfoList7.userID))
								{
									Mission_Friends[fBFriendInfoList7.userID].userName = UserFrndsInfo[fBFriendInfoList7.userID].userName;
								}
							}
						}
						foreach (KeyValuePair<string, FBFriendInfoList> item in UserFrndsInfo)
						{
							if (!Mission_Friends.ContainsKey(item.Key))
							{
								FBFriendInfoList fBFriendInfoList8 = new FBFriendInfoList();
								fBFriendInfoList8.userID = item.Key;
								fBFriendInfoList8.userName = item.Value.userName;
								fBFriendInfoList8.isImageLoad = item.Value.isImageLoad;
								fBFriendInfoList8.gameType = _gameType;
								Mission_Friends.Add(fBFriendInfoList8.userID, fBFriendInfoList8);
							}
						}
					}
					if (GetDataSucess != null)
					{
						GetDataSucess(nCheck);
					}
				}
				else if (GetDataFailed != null)
				{
					GetDataFailed(0);
				}
				break;
			case 2:
				if (arrData[0].Equals("0"))
				{
					if (GetDataSucess != null)
					{
						GetDataSucess(int.Parse(_gameType));
					}
				}
				else if (GetDataFailed != null)
				{
					GetDataFailed(int.Parse(_gameType));
				}
				break;
			case 4:
				if (!arrData[0].Equals("0"))
				{
					break;
				}
				if (_gameType.Equals("0"))
				{
					if (arrData[1].Equals("1"))
					{
						bGlobalTop5inChase = true;
					}
					else
					{
						bGlobalTop5inChase = false;
					}
					if (Chase_Global != null && Chase_Global.Count > 0)
					{
						Chase_Global.Clear();
					}
					for (int m = 2; m < arrData.Length; m++)
					{
						string text3 = arrData[m].Trim();
						string[] array3 = text3.Split(new string[1] { " " }, StringSplitOptions.None);
						FBFriendInfoList fBFriendInfoList4 = new FBFriendInfoList();
						fBFriendInfoList4.userID = array3[0];
						fBFriendInfoList4.userScore = int.Parse(array3[1]);
						fBFriendInfoList4.userCurrentLevel = int.Parse(array3[2]);
						fBFriendInfoList4.rank = Convert.ToInt32(array3[3]);
						if (array3.Length > 4)
						{
							fBFriendInfoList4.userName = array3[4];
						}
						else
						{
							fBFriendInfoList4.userName = "Player";
						}
						fBFriendInfoList4.gameType = _gameType;
						if (!Chase_Global.ContainsKey(fBFriendInfoList4.userID))
						{
							Chase_Global.Add(fBFriendInfoList4.userID, fBFriendInfoList4);
						}
						else if (Chase_Global.ContainsKey(fBFriendInfoList4.userID) && Chase_Global[fBFriendInfoList4.userID].userScore <= fBFriendInfoList4.userScore)
						{
							Chase_Global[fBFriendInfoList4.userID].userName = fBFriendInfoList4.userName;
							Chase_Global[fBFriendInfoList4.userID].userScore = fBFriendInfoList4.userScore;
							Chase_Global[fBFriendInfoList4.userID].userCurrentLevel = fBFriendInfoList4.userCurrentLevel;
							Chase_Global[fBFriendInfoList4.userID].rank = fBFriendInfoList4.rank;
							Chase_Global[fBFriendInfoList4.userID].gameType = fBFriendInfoList4.gameType;
						}
					}
					storeGlobalChaseDicData();
				}
				if (_gameType.Equals("1"))
				{
					if (arrData[1].Equals("1"))
					{
						bGlobalTop5inMission = true;
					}
					else
					{
						bGlobalTop5inMission = false;
					}
					if (Mission_Global != null && Mission_Global.Count > 0)
					{
						Mission_Global.Clear();
					}
					for (int n = 2; n < arrData.Length; n++)
					{
						string text4 = arrData[n].Trim();
						string[] array4 = text4.Split(new string[1] { " " }, StringSplitOptions.None);
						FBFriendInfoList fBFriendInfoList5 = new FBFriendInfoList();
						fBFriendInfoList5.userID = array4[0];
						fBFriendInfoList5.userScore = int.Parse(array4[1]);
						fBFriendInfoList5.userCurrentLevel = int.Parse(array4[2]);
						fBFriendInfoList5.rank = Convert.ToInt32(array4[3]);
						if (array4.Length > 4)
						{
							fBFriendInfoList5.userName = array4[4];
						}
						else
						{
							fBFriendInfoList5.userName = "Player";
						}
						fBFriendInfoList5.gameType = _gameType;
						if (!Mission_Global.ContainsKey(fBFriendInfoList5.userID))
						{
							Mission_Global.Add(fBFriendInfoList5.userID, fBFriendInfoList5);
						}
						else if (Mission_Global.ContainsKey(fBFriendInfoList5.userID) && Mission_Global[fBFriendInfoList5.userID].userScore <= fBFriendInfoList5.userScore)
						{
							Mission_Global[fBFriendInfoList5.userID].userName = fBFriendInfoList5.userName;
							Mission_Global[fBFriendInfoList5.userID].userScore = fBFriendInfoList5.userScore;
							Mission_Global[fBFriendInfoList5.userID].userCurrentLevel = fBFriendInfoList5.userCurrentLevel;
							Mission_Global[fBFriendInfoList5.userID].rank = fBFriendInfoList5.rank;
							Mission_Global[fBFriendInfoList5.userID].gameType = fBFriendInfoList5.gameType;
						}
					}
					storeGlobalMissionDicData();
				}
				if (GetDataSucess != null)
				{
					GetDataSucess(nCheck);
				}
				break;
			case 5:
				if (!isFBLoginSucess())
				{
					break;
				}
				if (arrData[0].Equals("0"))
				{
					if (_gameType.Equals("0"))
					{
						for (int k = 1; k < arrData.Length; k++)
						{
							string text = arrData[k].Trim();
							string[] array = text.Split(new string[1] { " " }, StringSplitOptions.None);
							FBFriendInfoList fBFriendInfoList = new FBFriendInfoList();
							fBFriendInfoList.userID = array[0];
							fBFriendInfoList.userScore = int.Parse(array[1]);
							fBFriendInfoList.userCurrentLevel = int.Parse(array[2]);
							fBFriendInfoList.gameType = _gameType;
							if (!UserFrndsInfo.ContainsKey(fBFriendInfoList.userID))
							{
								UserFrndsInfo.Add(fBFriendInfoList.userID, fBFriendInfoList);
							}
							else if (UserFrndsInfo.ContainsKey(fBFriendInfoList.userID) && UserFrndsInfo[fBFriendInfoList.userID].userScore <= fBFriendInfoList.userScore)
							{
								UserFrndsInfo[fBFriendInfoList.userID].userScore = fBFriendInfoList.userScore;
								UserFrndsInfo[fBFriendInfoList.userID].userCurrentLevel = fBFriendInfoList.userCurrentLevel;
								UserFrndsInfo[fBFriendInfoList.userID].gameType = fBFriendInfoList.gameType;
							}
						}
					}
					else if (_gameType.Equals("1"))
					{
						for (int l = 1; l < arrData.Length; l++)
						{
							string text2 = arrData[l].Trim();
							string[] array2 = text2.Split(new string[1] { " " }, StringSplitOptions.None);
							FBFriendInfoList fBFriendInfoList2 = new FBFriendInfoList();
							fBFriendInfoList2.userID = array2[0];
							fBFriendInfoList2.userScore = int.Parse(array2[1]);
							fBFriendInfoList2.userCurrentLevel = int.Parse(array2[2]);
							fBFriendInfoList2.gameType = _gameType;
							if (!Mission_Friends.ContainsKey(fBFriendInfoList2.userID))
							{
								Mission_Friends.Add(fBFriendInfoList2.userID, fBFriendInfoList2);
								if (UserFrndsInfo.ContainsKey(fBFriendInfoList2.userID))
								{
									Mission_Friends[fBFriendInfoList2.userID].userName = UserFrndsInfo[fBFriendInfoList2.userID].userName;
								}
							}
							else if (Mission_Friends.ContainsKey(fBFriendInfoList2.userID) && Mission_Friends[fBFriendInfoList2.userID].userScore <= fBFriendInfoList2.userScore)
							{
								Mission_Friends[fBFriendInfoList2.userID].userScore = fBFriendInfoList2.userScore;
								Mission_Friends[fBFriendInfoList2.userID].userCurrentLevel = fBFriendInfoList2.userCurrentLevel;
								Mission_Friends[fBFriendInfoList2.userID].gameType = fBFriendInfoList2.gameType;
								if (UserFrndsInfo.ContainsKey(fBFriendInfoList2.userID))
								{
									Mission_Friends[fBFriendInfoList2.userID].userName = UserFrndsInfo[fBFriendInfoList2.userID].userName;
								}
							}
						}
						foreach (KeyValuePair<string, FBFriendInfoList> item2 in UserFrndsInfo)
						{
							if (!Mission_Friends.ContainsKey(item2.Key))
							{
								FBFriendInfoList fBFriendInfoList3 = new FBFriendInfoList();
								fBFriendInfoList3.userID = item2.Key;
								fBFriendInfoList3.userName = item2.Value.userName;
								fBFriendInfoList3.isImageLoad = item2.Value.isImageLoad;
								fBFriendInfoList3.gameType = _gameType;
								Mission_Friends.Add(fBFriendInfoList3.userID, fBFriendInfoList3);
							}
						}
					}
					if (GetDataSucess != null)
					{
						GetDataSucess(nCheck);
					}
				}
				else if (GetDataFailed != null)
				{
					GetDataFailed(0);
				}
				break;
			case 6:
				if (arrData[0].Equals("0"))
				{
					if (_gameType.Equals("0"))
					{
						if (Chase_Global != null)
						{
							Chase_Global.Clear();
						}
						if (Chase_Friends != null)
						{
							Chase_Friends.Clear();
						}
						for (int i = 1; i < arrData.Length; i++)
						{
							string tmpArrData = arrData[i].Trim();
							string[] subArrData = tmpArrData.Split(new string[1] { " " }, StringSplitOptions.None);
							if (subArrData.Length == 1)
							{
								if (int.Parse(subArrData[0]) == 1)
								{
									bGlobalTop5inChase = true;
								}
								else
								{
									bGlobalTop5inChase = false;
								}
								continue;
							}
							FBFriendInfoList tmpFBData = new FBFriendInfoList
							{
								userID = subArrData[0],
								userScore = int.Parse(subArrData[1]),
								userCurrentLevel = int.Parse(subArrData[2]),
								gameType = _gameType
							};
							if (subArrData.Length == 4)
							{
								if (UserFrndsInfo.ContainsKey(tmpFBData.userID))
								{
									tmpFBData.userName = UserFrndsInfo[tmpFBData.userID].userName;
								}
								else
								{
									tmpFBData.userName = "Player";
								}
								Chase_Friends.Add(tmpFBData.userID, tmpFBData);
							}
							else if (subArrData.Length == 5)
							{
								tmpFBData.rank = int.Parse(subArrData[3]);
								if (Chase_Global.ContainsKey(tmpFBData.userID))
								{
									Chase_Global[tmpFBData.userID].userScore = tmpFBData.userScore;
									Chase_Global[tmpFBData.userID].userCurrentLevel = tmpFBData.userCurrentLevel;
									Chase_Global[tmpFBData.userID].gameType = tmpFBData.gameType;
									Chase_Global[tmpFBData.userID].rank = tmpFBData.rank;
								}
								else
								{
									Chase_Global.Add(tmpFBData.userID, tmpFBData);
								}
								if (UserFrndsInfo != null && UserFrndsInfo.ContainsKey(tmpFBData.userID))
								{
									Chase_Global[tmpFBData.userID].userName = UserFrndsInfo[tmpFBData.userID].userName;
									continue;
								}
								yield return Coroutiner.StartCoroutine(getUserInfo(tmpFBData.userID, getChaseGlobalUserDetails));
								getDataSucess = GetDataSucess;
							}
						}
						storeChaseFrndsData();
						storeGlobalChaseDicData();
					}
					else if (_gameType.Equals("1"))
					{
						if (Mission_Global != null)
						{
							Mission_Global.Clear();
						}
						for (int j = 1; j < arrData.Length; j++)
						{
							string tmpArrData2 = arrData[j].Trim();
							string[] subArrData2 = tmpArrData2.Split(new string[1] { " " }, StringSplitOptions.None);
							if (subArrData2.Length == 1)
							{
								if (int.Parse(subArrData2[0]) == 1)
								{
									bGlobalTop5inMission = true;
								}
								else
								{
									bGlobalTop5inMission = false;
								}
								continue;
							}
							FBFriendInfoList tmpFBData2 = new FBFriendInfoList
							{
								userID = subArrData2[0],
								userScore = int.Parse(subArrData2[1]),
								userCurrentLevel = int.Parse(subArrData2[2]),
								gameType = _gameType
							};
							if (subArrData2.Length == 4)
							{
								if (Mission_Friends.ContainsKey(tmpFBData2.userID))
								{
									Mission_Friends[tmpFBData2.userID].userScore = tmpFBData2.userScore;
									Mission_Friends[tmpFBData2.userID].userCurrentLevel = tmpFBData2.userCurrentLevel;
									Mission_Friends[tmpFBData2.userID].gameType = tmpFBData2.gameType;
								}
								else
								{
									Mission_Friends.Add(tmpFBData2.userID, tmpFBData2);
								}
								if (UserFrndsInfo != null && UserFrndsInfo.ContainsKey(tmpFBData2.userID))
								{
									Mission_Friends[tmpFBData2.userID].userName = UserFrndsInfo[tmpFBData2.userID].userName;
								}
							}
							else if (subArrData2.Length == 5)
							{
								tmpFBData2.rank = int.Parse(subArrData2[3]);
								if (Mission_Global.ContainsKey(tmpFBData2.userID))
								{
									Mission_Global[tmpFBData2.userID].userScore = tmpFBData2.userScore;
									Mission_Global[tmpFBData2.userID].userCurrentLevel = tmpFBData2.userCurrentLevel;
									Mission_Global[tmpFBData2.userID].gameType = tmpFBData2.gameType;
									Mission_Global[tmpFBData2.userID].rank = tmpFBData2.rank;
								}
								else
								{
									Mission_Global.Add(tmpFBData2.userID, tmpFBData2);
								}
								if (UserFrndsInfo != null && UserFrndsInfo.ContainsKey(tmpFBData2.userID))
								{
									Mission_Global[tmpFBData2.userID].userName = UserFrndsInfo[tmpFBData2.userID].userName;
									continue;
								}
								if (Chase_Global != null && Chase_Global.ContainsKey(tmpFBData2.userID))
								{
									Mission_Global[tmpFBData2.userID].userName = Chase_Global[tmpFBData2.userID].userName;
									continue;
								}
								yield return Coroutiner.StartCoroutine(getUserInfo(tmpFBData2.userID, getMissionGlobalUserDetails));
								getDataSucess = GetDataSucess;
							}
						}
						storeFrndsMissionDicData();
						storeGlobalMissionDicData();
					}
					if (GetDataSucess != null)
					{
						GetDataSucess(nCheck);
					}
				}
				else if (GetDataFailed != null)
				{
					GetDataFailed(0);
				}
				break;
			}
		}
		else if (GetDataFailed != null)
		{
			GetDataFailed(0);
		}
	}

	private void getChaseGlobalUserDetails(string _uid, string _name, byte[] _picData)
	{
		if (Chase_Global != null && Chase_Global.ContainsKey(_uid))
		{
			if (_name == null || _name.Equals(string.Empty))
			{
				_name = "Player";
			}
			Chase_Global[_uid].userName = _name;
			Chase_Global[_uid].userProfilePicData = _picData;
			Chase_Global[_uid].isImageLoad = true;
			storeGlobalChaseDicData();
			if (getDataSucess != null)
			{
				getDataSucess(0);
			}
		}
	}

	private void getMissionGlobalUserDetails(string _uid, string _name, byte[] _picData)
	{
		if (Mission_Global != null && Mission_Global.ContainsKey(_uid))
		{
			if (_name == null || _name.Equals(string.Empty))
			{
				_name = "Player";
			}
			Mission_Global[_uid].userName = _name;
			Mission_Global[_uid].userProfilePicData = _picData;
			Mission_Global[_uid].isImageLoad = true;
			storeGlobalMissionDicData();
			if (getDataSucess != null)
			{
				getDataSucess(0);
			}
		}
	}

	public void AppRequestPassToList(string title, string msg, List<string> toRecipientsList, string data, Action<List<string>> AppRequestSucess = null, Action<string> AppRequestFailed = null)
	{
		if (!isFBLoginSucess())
		{
			return;
		}
		FB.AppRequest(msg, toRecipientsList, null, null, null, data, title, delegate(IAppRequestResult result)
		{
			if (result.Error == null && !result.Cancelled)
			{
				List<string> list = new List<string>();
				foreach (KeyValuePair<string, object> item in result.ResultDictionary)
				{
					if (item.Key.Equals("to"))
					{
						string[] array = item.Value.ToString().Split(',');
						for (int i = 0; i < array.Length; i++)
						{
							list.Add(array[i]);
						}
					}
				}
				if (AppRequestSucess != null)
				{
					AppRequestSucess(list);
				}
			}
			else
			{
				if (result.Cancelled)
				{
					Debug.Log("AppReq is Cancelled ");
				}
				else
				{
					Debug.Log(" AppReq failed with result.Error " + result.Error);
				}
				if (AppRequestFailed != null)
				{
					AppRequestFailed(result.Error);
				}
			}
		});
	}

	public void AppRequest(string sMsg, int _actionType, string sObjectId, string sTitle, string sData, Action<int> AppRequestSucess = null, Action<int> AppRequestFailed = null)
	{
		if (!FB.IsLoggedIn)
		{
			return;
		}
		OGActionType nActionType = OGActionType.TURN;
		switch (_actionType)
		{
		case 1:
			nActionType = OGActionType.ASKFOR;
			break;
		case 0:
			nActionType = OGActionType.SEND;
			break;
		case 2:
			nActionType = OGActionType.TURN;
			break;
		}
		FB.AppRequest(sMsg, nActionType, sObjectId, new List<object> { "app_users" }, null, null, sData, sTitle, delegate(IAppRequestResult result)
		{
			if (result.Error == null && !result.Cancelled)
			{
				object value;
				if (result.ResultDictionary.TryGetValue("to", out value))
				{
				}
				if (AppRequestSucess != null)
				{
					AppRequestSucess((int)nActionType);
				}
			}
			else
			{
				if (result.Cancelled)
				{
					Debug.Log("AppReq is Cancelled ");
				}
				else
				{
					Debug.Log(" AppReq failed with result.Error " + result.Error);
				}
				if (AppRequestFailed != null)
				{
					AppRequestFailed((int)nActionType);
				}
			}
		});
	}

	public List<string> getInviteFrndList()
	{
		return strInvitedList;
	}

	public void inviteAppRequest(string title, string sMsg, string sData, Action inviteReqSucess = null, Action inviteReqFailed = null)
	{
		if (!FB.IsLoggedIn)
		{
			return;
		}
		FB.AppRequest(sMsg, null, new List<object> { "app_non_users" }, null, null, sData, title, delegate(IAppRequestResult result)
		{
			Debug.Log("Invite app : " + result.RawResult);
			if (result.Error == null && !result.Cancelled)
			{
				object value;
				if (result.ResultDictionary.TryGetValue("to", out value))
				{
					strInvitedList = (List<string>)value;
				}
				if (inviteReqSucess != null)
				{
					inviteReqSucess();
				}
			}
			else
			{
				if (result.Cancelled)
				{
					Debug.Log("failed Invite for result.Cancelled ");
				}
				else
				{
					Debug.Log("failed Invite for result.Error " + result.Error);
				}
				if (inviteReqFailed != null)
				{
					inviteReqFailed();
				}
			}
		});
	}

	public void FBLogout(Action FBLogoutCompleted = null)
	{
		if (FB.IsLoggedIn)
		{
			FB.LogOut();
			IGT_Preference.getInstance()._Set("loginkey", 0);
			if (UserFrndsInfo != null && UserFrndsInfo.Count > 0)
			{
				UserFrndsInfo.Clear();
			}
			if (Mission_Friends != null && Mission_Friends.Count > 0)
			{
				Mission_Friends.Clear();
			}
			if (Chase_Global != null && Chase_Global.Count > 0)
			{
				Chase_Global.Clear();
			}
			if (Mission_Global != null && Mission_Global.Count > 0)
			{
				Mission_Global.Clear();
			}
			if (dictAskReqID != null && dictAskReqID.Count > 0)
			{
				dictAskReqID.Clear();
			}
			if (dictSendReqID != null && dictSendReqID.Count > 0)
			{
				dictSendReqID.Clear();
			}
			sqlliteConn.DeleteAll<SQL_FBFrndTable>();
			sqlliteConn.DeleteAll<SQL_FBFrndTableChase>();
			sqlliteConn.DeleteAll<SQL_FBFrndTableMission>();
			if (FBLogoutCompleted != null)
			{
				FBLogoutCompleted();
			}
			status = 0;
			IGT_Preference.getInstance()._Set("liststatus", 0);
		}
	}

	public void GetFriendsInfo(Action getFBFriendsListCompleted = null, Action getFBFriendsListEmpty = null, Action loadFBFriendsPicSucess = null, Action loadFBFriendsPicFailed = null)
	{
		status = 4;
		IGT_Preference.getInstance()._Set("liststatus", 4);
		string query = "/me/friends?fields=id,first_name,picture.width(" + nPicSize + ").height(" + nPicSize + ")&limit=" + nTotUserLim;
		FB.API(query, HttpMethod.GET, delegate(IGraphResult result)
		{
			if (string.IsNullOrEmpty(result.Error) && !result.Cancelled)
			{
				Dictionary<string, object> dictionary = Json.Deserialize(result.RawResult) as Dictionary<string, object>;
				List<object> list = new List<object>();
				list = (List<object>)dictionary["data"];
				for (int i = 0; i < list.Count; i++)
				{
					FBFriendInfoList fBFriendInfoList = new FBFriendInfoList
					{
						userID = getDataValueforKey((Dictionary<string, object>)list[i], "id"),
						userName = getDataValueforKey((Dictionary<string, object>)list[i], "first_name")
					};
					if (fBFriendInfoList.userName.Length > 8)
					{
						fBFriendInfoList.userName = fBFriendInfoList.userName.Substring(0, 7) + "...";
					}
					if (fBFriendInfoList.userID != null)
					{
						if (!UserFrndsInfo.ContainsKey(fBFriendInfoList.userID))
						{
							UserFrndsInfo.Add(fBFriendInfoList.userID, fBFriendInfoList);
						}
						else
						{
							UserFrndsInfo[fBFriendInfoList.userID] = fBFriendInfoList;
						}
					}
				}
				Coroutiner.StartCoroutine(LoadProfilePicEnumerator(loadFBFriendsPicSucess));
				storeDicData();
				if (getFBFriendsListCompleted != null)
				{
					getFBFriendsListCompleted();
				}
			}
			else
			{
				status = 6;
				IGT_Preference.getInstance()._Set("liststatus", 6);
				if (getFBFriendsListEmpty != null)
				{
					getFBFriendsListEmpty();
				}
			}
		});
	}

	public IEnumerator LoadProfilePicEnumerator(Action loadFBFriendsPicSucess = null)
	{
		if (!isFBLoginSucess())
		{
			yield break;
		}
		List<string> fbKeys = new List<string>(UserFrndsInfo.Keys);
		foreach (string fbKey in fbKeys)
		{
			yield return Coroutiner.StartCoroutine(getProfilePic1(fbKey, loadFBFriendsPicSucess));
		}
		storeDicData();
		if (loadFBFriendsPicSucess != null)
		{
			loadFBFriendsPicSucess();
		}
		status = 5;
		IGT_Preference.getInstance()._Set("liststatus", 5);
	}

	private IEnumerator getProfilePic1(string _userID, Action loadFBFriendsPicSucess = null)
	{
		string imgURL = "https://graph.facebook.com/" + _userID + "/picture?width=" + nPicSize + "&height=" + nPicSize;
		WWW www = new WWW(Uri.EscapeUriString(imgURL));
		yield return www;
		if (www.error == null)
		{
			if (UserFrndsInfo != null && UserFrndsInfo.ContainsKey(_userID))
			{
				UserFrndsInfo[_userID].userProfilePicData = www.texture.EncodeToPNG();
				UserFrndsInfo[_userID].isImageLoad = true;
			}
			if (Mission_Friends != null && Mission_Friends.ContainsKey(_userID))
			{
				Mission_Friends[_userID].userProfilePicData = www.texture.EncodeToPNG();
				Mission_Friends[_userID].isImageLoad = true;
			}
			else if (UserFrndsInfo.ContainsKey(_userID) && !Mission_Friends.ContainsKey(_userID))
			{
				Mission_Friends.Add(_userID, UserFrndsInfo[_userID]);
			}
		}
		else
		{
			Debug.Log("img error : " + www.error);
		}
	}

	private void delegateFunction1(string _uid, string _uName, byte[] _picData)
	{
		UserFrndsInfo[_uid].userProfilePicData = _picData;
		UserFrndsInfo[_uid].isImageLoad = true;
	}

	private string getDataValueforKey(Dictionary<string, object> dict, string key)
	{
		object value;
		if (dict.TryGetValue(key, out value))
		{
			return (string)value;
		}
		return string.Empty;
	}

	public Dictionary<string, FBFriendInfoList> getFBFrndsList()
	{
		return UserFrndsInfo;
	}

	public void PromptForPublishPermissions(Action FBLoginCompleted = null, Action FBLoginFailed = null, Action loadFBFriendsPicSucess = null)
	{
		if (FB.IsLoggedIn)
		{
			FB.LogInWithPublishPermissions(publishPermissions, delegate(ILoginResult result)
			{
				if (FB.IsLoggedIn)
				{
					string query = "/me?fields=id,first_name,picture.width(" + nPicSize + ").height(" + nPicSize + ")";
					FB.API(query, HttpMethod.GET, delegate
					{
						if (FBLoginCompleted != null)
						{
							FBLoginCompleted();
						}
					});
				}
				else
				{
					if (result.Error != null)
					{
					}
					if (FBLoginFailed != null)
					{
						FBLoginFailed();
					}
				}
			});
		}
		else
		{
			PromptForPublishPermissions();
		}
	}
}
