using System;

[Serializable]
public class FBFriendInfoList
{
	public string userID;

	public string userName;

	public int userCurrentLevel;

	public int userScore;

	public byte[] userProfilePicData;

	public bool isImageLoad;

	public string userAskMsg;

	public string userSendMsg;

	public string gameType;

	public int rank;

	public bool isCheckBoxTicked;

	public string picUrl;

	public FBFriendInfoList()
	{
		rank = 0;
		userID = null;
		userName = null;
		userScore = 0;
		userCurrentLevel = 0;
		userProfilePicData = null;
		isImageLoad = false;
		userAskMsg = null;
		userSendMsg = null;
		gameType = null;
		picUrl = null;
		isCheckBoxTicked = false;
	}
}
