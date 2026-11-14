public class IGT_Achivements
{
	public static void completeAchivements(int _achivementsType, int _data, int refType = -1)
	{
		if (!IGT_LeaderboardAchievements.getInstance().isLogInSucess())
		{
			return;
		}
		switch (_achivementsType)
		{
		case 4:
			if (_data == 1 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQEA", 0) == 0)
			{
				IGT_GameView.pLeaderBoard.OnCompleteAchievements("CgkInKbEoZQHEAIQEA", 100.0);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQEA", 1);
				IGT_GameView.start_AchievementAlert("Catch the First Robber in Chase");
			}
			else if (_data == 3 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQEQ", 0) == 0)
			{
				IGT_GameView.pLeaderBoard.OnCompleteAchievements("CgkInKbEoZQHEAIQEQ", 100.0);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQEQ", 1);
				IGT_GameView.start_AchievementAlert("Catch the Third Robber in Chase");
			}
			else if (_data == 6 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQEg", 0) == 0)
			{
				IGT_GameView.pLeaderBoard.OnCompleteAchievements("CgkInKbEoZQHEAIQEg", 100.0);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQEg", 1);
				IGT_GameView.start_AchievementAlert("Catch the Sixth Robber in Chase");
			}
			else if (_data == 8 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQEw", 0) == 0)
			{
				IGT_GameView.pLeaderBoard.OnCompleteAchievements("CgkInKbEoZQHEAIQEw", 100.0);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQEw", 1);
				IGT_GameView.start_AchievementAlert("Catch the Eighth Robber in Chase");
			}
			else if (_data == 10 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQFA", 0) == 0)
			{
				IGT_GameView.pLeaderBoard.OnCompleteAchievements("CgkInKbEoZQHEAIQFA", 100.0);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQFA", 1);
				IGT_GameView.start_AchievementAlert("Catch the Tenth Robber in Chase");
			}
			break;
		case 3:
			if (_data >= 15000000 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQDw", 0) == 0)
			{
				IGT_GameView.pLeaderBoard.OnCompleteAchievements("CgkInKbEoZQHEAIQDw", 100.0);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQDw", 1);
				IGT_GameView.start_AchievementAlert("Cross 15 Million score in Mission");
			}
			else if (_data >= 5000000 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQDg", 0) == 0)
			{
				IGT_GameView.pLeaderBoard.OnCompleteAchievements("CgkInKbEoZQHEAIQDg", 100.0);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQDg", 1);
				IGT_GameView.start_AchievementAlert("Cross 5 Million score in Mission");
			}
			else if (_data >= 1000000 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQDQ", 0) == 0)
			{
				IGT_GameView.pLeaderBoard.OnCompleteAchievements("CgkInKbEoZQHEAIQDQ", 100.0);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQDQ", 1);
				IGT_GameView.start_AchievementAlert("Cross 1 Million score in Mission");
			}
			break;
		case 2:
			if (_data >= 10000000 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQJg", 0) == 0)
			{
				IGT_GameView.pLeaderBoard.OnCompleteAchievements("CgkInKbEoZQHEAIQJg", 100.0);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQJg", 1);
				IGT_GameView.start_AchievementAlert("Cross 10 Million Score in Chase");
			}
			else if (_data >= 5000000 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQJQ", 0) == 0)
			{
				IGT_GameView.pLeaderBoard.OnCompleteAchievements("CgkInKbEoZQHEAIQJQ", 100.0);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQJQ", 1);
				IGT_GameView.start_AchievementAlert("Cross 5 Million Score in Chase");
			}
			else if (_data >= 2000000 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQJA", 0) == 0)
			{
				IGT_GameView.pLeaderBoard.OnCompleteAchievements("CgkInKbEoZQHEAIQJA", 100.0);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQJA", 1);
				IGT_GameView.start_AchievementAlert("Cross 2 Million Score in Chase");
			}
			if (_data >= 1000000 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQDA", 0) == 0)
			{
				IGT_GameView.pLeaderBoard.OnCompleteAchievements("CgkInKbEoZQHEAIQDA", 100.0);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQDA", 1);
				IGT_GameView.start_AchievementAlert("Cross 1 Million Score in chase");
			}
			if (_data >= 500000 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQCw", 0) == 0)
			{
				IGT_GameView.pLeaderBoard.OnCompleteAchievements("CgkInKbEoZQHEAIQCw", 100.0);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQCw", 1);
				IGT_GameView.start_AchievementAlert("Cross 500K Score in chase");
			}
			if (_data >= 100000 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQCQ", 0) == 0)
			{
				IGT_GameView.pLeaderBoard.OnCompleteAchievements("CgkInKbEoZQHEAIQCQ", 100.0);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQCQ", 1);
				IGT_GameView.start_AchievementAlert("Cross 100K  Score in chase");
			}
			break;
		case 1:
			if (_data == 20 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQBA", 0) == 0)
			{
				IGT_GameView.pLeaderBoard.OnCompleteAchievements("CgkInKbEoZQHEAIQBA", 100.0);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQBA", 1);
				IGT_GameView.start_AchievementAlert("Complete 20 Missions");
			}
			else if (_data == 50 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQBQ", 0) == 0)
			{
				IGT_GameView.pLeaderBoard.OnCompleteAchievements("CgkInKbEoZQHEAIQBQ", 100.0);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQBQ", 1);
				IGT_GameView.start_AchievementAlert("Complete 50 Missions");
			}
			else if (_data == 100 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQBg", 0) == 0)
			{
				IGT_GameView.pLeaderBoard.OnCompleteAchievements("CgkInKbEoZQHEAIQBg", 100.0);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQBg", 1);
				IGT_GameView.start_AchievementAlert("Complete 100 Missions");
			}
			else if (_data == 250 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQBw", 0) == 0)
			{
				IGT_GameView.pLeaderBoard.OnCompleteAchievements("CgkInKbEoZQHEAIQBw", 100.0);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQBw", 1);
				IGT_GameView.start_AchievementAlert("Complete 250 Missions");
			}
			else if (_data == 500 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQCA", 0) == 0)
			{
				IGT_GameView.pLeaderBoard.OnCompleteAchievements("CgkInKbEoZQHEAIQCA", 100.0);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQCA", 1);
				IGT_GameView.start_AchievementAlert("Complete 500 Missions");
			}
			break;
		case 6:
			if (_data == 50 && refType == 6 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQGQ", 0) == 0)
			{
				IGT_GameView.pLeaderBoard.OnCompleteAchievements("CgkInKbEoZQHEAIQGQ", 100.0);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQGQ", 1);
			}
			else if (_data == 300 && refType == 6 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQGg", 0) == 0)
			{
				IGT_GameView.pLeaderBoard.OnCompleteAchievements("CgkInKbEoZQHEAIQGg", 100.0);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQGg", 1);
			}
			else if (_data == 100 && refType == 4 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQGw", 0) == 0)
			{
				IGT_GameView.pLeaderBoard.OnCompleteAchievements("CgkInKbEoZQHEAIQGw", 100.0);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQGw", 1);
			}
			else if (_data == 500 && refType == 4 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQHA", 0) == 0)
			{
				IGT_GameView.pLeaderBoard.OnCompleteAchievements("CgkInKbEoZQHEAIQHA", 100.0);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQHA", 1);
			}
			break;
		case 8:
			if (_data == 1 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQIA", 0) == 0)
			{
				IGT_GameView.pLeaderBoard.OnCompleteAchievements("CgkInKbEoZQHEAIQIA", 100.0);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQIA", 1);
				IGT_GameView.start_AchievementAlert("Upgrade Magnet Duration to Level 1");
			}
			else if (_data == 2 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQIQ", 0) == 0)
			{
				IGT_GameView.pLeaderBoard.OnCompleteAchievements("CgkInKbEoZQHEAIQIQ", 100.0);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQIQ", 1);
				IGT_GameView.start_AchievementAlert("Upgrade score multiplier to  Level 2");
			}
			else if (_data == 3 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQIg", 0) == 0)
			{
				IGT_GameView.pLeaderBoard.OnCompleteAchievements("CgkInKbEoZQHEAIQIg", 100.0);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQIg", 1);
				IGT_GameView.start_AchievementAlert("Upgrade Bottle Availability to Level 3");
			}
			else if (_data == 5 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQIw", 0) == 0)
			{
				IGT_GameView.pLeaderBoard.OnCompleteAchievements("CgkInKbEoZQHEAIQIw", 100.0);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQIw", 1);
				IGT_GameView.start_AchievementAlert("Upgrade Health Booster to  Level 5");
			}
			break;
		case 5:
			if (_data == 30 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQFQ", 0) == 0)
			{
				IGT_GameView.pLeaderBoard.OnCompleteAchievements("CgkInKbEoZQHEAIQFQ", 100.0);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQFQ", 1);
				IGT_GameView.start_AchievementAlert("Get All Stars in first 10 Missions");
			}
			else if (_data == 25 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQFg", 0) == 0)
			{
				IGT_GameView.pLeaderBoard.OnCompleteAchievements("CgkInKbEoZQHEAIQFg", 100.0);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQFg", 1);
				IGT_GameView.start_AchievementAlert("Get 25 Three Stars in Mission");
			}
			else if (_data == 100 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQFw", 0) == 0)
			{
				IGT_GameView.pLeaderBoard.OnCompleteAchievements("CgkInKbEoZQHEAIQFw", 100.0);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQFw", 1);
				IGT_GameView.start_AchievementAlert("Get 100 Three stars in mission");
			}
			else if (_data == 200 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQGA", 0) == 0)
			{
				IGT_GameView.pLeaderBoard.OnCompleteAchievements("CgkInKbEoZQHEAIQGA", 100.0);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQGA", 1);
				IGT_GameView.start_AchievementAlert("Get 200 Three stars in mission");
			}
			break;
		case 7:
			if (_data == 5 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQHQ", 0) == 0)
			{
				IGT_GameView.pLeaderBoard.OnCompleteAchievements("CgkInKbEoZQHEAIQHQ", 100.0);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQHQ", 1);
				IGT_GameView.start_AchievementAlert("Compete with 5 FB Friends and Top among them in Missions");
			}
			if (_data == 10 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQHw", 0) == 0)
			{
				IGT_GameView.pLeaderBoard.OnCompleteAchievements("CgkInKbEoZQHEAIQHw", 100.0);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQHw", 1);
				IGT_GameView.start_AchievementAlert("Top 10 in Mission overall Leaderboard");
			}
			if (_data == 100 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQHg", 0) == 0)
			{
				IGT_GameView.pLeaderBoard.OnCompleteAchievements("CgkInKbEoZQHEAIQHg", 100.0);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQHg", 1);
				IGT_GameView.start_AchievementAlert("Top 100 in Mission overall Leaderboard");
			}
			break;
		}
	}
}
