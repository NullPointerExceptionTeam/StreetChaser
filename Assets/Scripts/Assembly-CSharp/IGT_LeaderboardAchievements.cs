using System;
using GooglePlayGames;
using UnityEngine;

public class IGT_LeaderboardAchievements
{
	private static IGT_LeaderboardAchievements pLeaderBoardObj;

	private bool bShowSignInAlert;

	private string KEY_LEADERBOARD_SIGNIN = "kleaderboardachivementsignin";

	private string KEY_GAME_LAUNCHES_GPLUS_SIGN_IN_ALERT = "kgamelunchgplusesignin";

	public IGT_LeaderboardAchievements()
	{
		PlayGamesPlatform.DebugLogEnabled = true;
		PlayGamesPlatform.Activate();
		if (IGT_Preference.getInstance()._Get(KEY_LEADERBOARD_SIGNIN, 0) == 1)
		{
			LeaderAchivLogin();
		}
	}

	public static IGT_LeaderboardAchievements getInstance()
	{
		if (pLeaderBoardObj == null)
		{
			pLeaderBoardObj = new IGT_LeaderboardAchievements();
		}
		return pLeaderBoardObj;
	}

	public bool isGpluseSigninChecking()
	{
		if (isLogInSucess())
		{
			bShowSignInAlert = false;
		}
		else if (IGT_Preference.getInstance()._Get(KEY_LEADERBOARD_SIGNIN, 0) == 0)
		{
			int num = IGT_Preference.getInstance()._Get(KEY_GAME_LAUNCHES_GPLUS_SIGN_IN_ALERT, 0);
			if (num <= 21 && num % 5 == 0)
			{
				bShowSignInAlert = true;
				IGT_Preference.getInstance()._Set(KEY_GAME_LAUNCHES_GPLUS_SIGN_IN_ALERT, ++num);
			}
			else
			{
				bShowSignInAlert = false;
				IGT_Preference.getInstance()._Set(KEY_GAME_LAUNCHES_GPLUS_SIGN_IN_ALERT, ++num);
			}
		}
		return bShowSignInAlert;
	}

	public bool isLogInSucess()
	{
		return Social.localUser.authenticated;
	}

	public void LeaderAchivLogin()
	{
		try
		{
			if (Social.localUser.authenticated)
			{
				return;
			}
			Social.localUser.Authenticate(delegate(bool sucess)
			{
				IGT_GameView.sTitle = "LogIn : " + sucess;
				if (sucess)
				{
					IGT_Preference.getInstance()._Set(KEY_LEADERBOARD_SIGNIN, 1);
				}
				else
				{
					Debug.Log("Login failed");
				}
			});
		}
		catch (Exception ex)
		{
			Debug.Log("Login execp :" + ex.Message);
		}
	}

	public void OnShowLeaderBoard()
	{
		Social.ShowLeaderboardUI();
	}

	public void OnShowAchievements()
	{
		Social.ShowAchievementsUI();
	}

	public void OnCompleteAchievements(string achivmentId, double progress)
	{
		if (!Social.localUser.authenticated)
		{
			return;
		}
		Social.ReportProgress(achivmentId, progress, delegate(bool success)
		{
			if (success)
			{
				Debug.Log("Update Score Success");
			}
			else
			{
				Debug.Log("Update Score Fail");
			}
		});
	}

	public void OnAddScoreToLeaderBorad(string leaderboardId, long score)
	{
		if (!Social.localUser.authenticated)
		{
			return;
		}
		Social.ReportScore(score, leaderboardId, delegate(bool success)
		{
			if (success)
			{
				Debug.Log("Update Score Success");
			}
			else
			{
				Debug.Log("Update Score Fail");
			}
		});
	}

	public void gpluseSignOut()
	{
		((PlayGamesPlatform)Social.Active).SignOut();
	}
}
