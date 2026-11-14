using System;
using System.Collections;
using UnityEngine;

public class IGT_RateIt : ButtonClickListner
{
	private string PREF_RateIt_Finished = "juairunvm4tnbjaseb";

	private string PREF_LastShownTime = "vukodhvo84t94ubf";

	private string PREF_ShownCount = "gre9jg0asndkmokpo9jgr";

	private string PREF_On10thMissionFirstTime = "sdnfjcbpiw7ef737rjngl";

	private const int nTotRateItAlertCount = 7;

	private const string iosRateAppID = "1190360439";

	private const string androidRateAppID = "com.igoldtech.streetchaser";

	private int starWaitingTime = 1;

	private GUIStyle guiStyle;

	private Texture starBtn;

	private Texture starGrayBtn;

	private IGT_Button btnSend;

	private IGT_Button btnClose;

	private IGT_Button btnRateNow;

	private IGT_Button btnStar1;

	private IGT_Button btnStar2;

	private IGT_Button btnStar3;

	private IGT_Button btnStar4;

	private IGT_Button btnStar5;

	private bool bEnableStars;

	private int nRateItFinished;

	public bool bShowRateItAlert;

	private float lastRateItShowTime;

	private int nRateItShownCount;

	private int nRateAlertWindow;

	private DateTime Jan1st1970 = new DateTime(2017, 8, 1, 0, 0, 0, DateTimeKind.Utc);

	private string gameName;

	private string rateitTxt;

	private string ratenowTitle;

	private string ratenowTxt;

	private string toSupportMail;

	private string subjTxt;

	private string bodyTxt;

	private string defaultBodyText;

	private Rect rectTxtArea;

	private bool bDefaultBodytxtEnabled;

	private bool bThankFeedBack;

	private bool bThankFeedback_Close;

	private float fThankFeedback_StrtTime;

	private IGT_Animator pAnimator_Ask;

	private Rect rect_AskRateBg;

	private Rect rect_RatenowBg;

	private GUIStyle guiStyle_FeedBack;

	private Texture2D rectBgTexture;

	public IGT_RateIt()
	{
		gameName = "Street Chaser";
		ratenowTitle = "Like " + gameName + " ?";
		ratenowTxt = "Thanks for playing " + gameName + ",\n Please take a moment to rate us. \n\n We appreciate your reviews and ratings.\n It will help us in improving this game.";
		subjTxt = gameName + " feedback ";
		rateitTxt = "How would you like to Rate your Experience?";
		toSupportMail = "support@igoldtech.com";
		defaultBodyText = "please provide us the reason for your low rating. Your valuable feedback will help us to improve the game";
		bEnableStars = false;
		rectTxtArea = new Rect(IGT_UIcommonFunc.ScaleX(65f), IGT_UIcommonFunc.ScaleY(204f), IGT_UIcommonFunc.ScaleX(180f), IGT_UIcommonFunc.ScaleY(90f));
		starBtn = Resources.Load<Texture>(IGT_Constants._StarImg);
		starGrayBtn = Resources.Load<Texture>(IGT_Constants._Star_Empty);
		btnClose = new IGT_Button(Resources.Load<Texture>(IGT_Constants._CloseRect), 0, IGT_UIcommonFunc.ScaleX(260f), IGT_UIcommonFunc.ScaleY(100f), IGT_UIcommonFunc.ScaleX(36f), IGT_UIcommonFunc.ScaleY(36f));
		btnClose.setListener(this);
		btnStar1 = new IGT_Button(starGrayBtn, 3, IGT_UIcommonFunc.ScaleX(65f), IGT_UIcommonFunc.ScaleY(242f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f));
		btnStar1.setListener(this);
		btnStar2 = new IGT_Button(starGrayBtn, 4, IGT_UIcommonFunc.ScaleX(105f), IGT_UIcommonFunc.ScaleY(242f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f));
		btnStar2.setListener(this);
		btnStar3 = new IGT_Button(starGrayBtn, 5, IGT_UIcommonFunc.ScaleX(145f), IGT_UIcommonFunc.ScaleY(242f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f));
		btnStar3.setListener(this);
		btnStar4 = new IGT_Button(starGrayBtn, 6, IGT_UIcommonFunc.ScaleX(185f), IGT_UIcommonFunc.ScaleY(242f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f));
		btnStar4.setListener(this);
		btnStar5 = new IGT_Button(starGrayBtn, 7, IGT_UIcommonFunc.ScaleX(225f), IGT_UIcommonFunc.ScaleY(242f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f));
		btnStar5.setListener(this);
		btnRateNow = new IGT_Button(Resources.Load<Texture>("Images/UI/Btn_select"), 1, IGT_UIcommonFunc.ScaleX(115f), IGT_UIcommonFunc.ScaleY(290f), IGT_UIcommonFunc.ScaleX(90f), IGT_UIcommonFunc.ScaleY(38f));
		btnRateNow.setListener(this);
		btnSend = new IGT_Button(Resources.Load<Texture>("Images/UI/Btn_select"), 2, IGT_UIcommonFunc.ScaleX(120f), IGT_UIcommonFunc.ScaleY(310f), IGT_UIcommonFunc.ScaleX(70f), IGT_UIcommonFunc.ScaleY(32f));
		btnSend.setListener(this);
		bShowRateItAlert = false;
		lastRateItShowTime = IGT_Preference.getInstance()._Get(PREF_LastShownTime, 0f);
		nRateItShownCount = IGT_Preference.getInstance()._Get(PREF_ShownCount, 0);
		nRateItFinished = IGT_Preference.getInstance()._Get(PREF_RateIt_Finished, 0);
		if (!IGT_Preference.getInstance()._isKey_AlreadyPresent(PREF_On10thMissionFirstTime))
		{
			IGT_Preference.getInstance()._Set(PREF_On10thMissionFirstTime, 0);
		}
		pAnimator_Ask = new IGT_Animator();
		rect_AskRateBg = new Rect(IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleY(170f), IGT_UIcommonFunc.ScaleX(240f), IGT_UIcommonFunc.ScaleY(130f));
		rect_RatenowBg = new Rect(IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(110f), IGT_UIcommonFunc.ScaleX(260f), IGT_UIcommonFunc.ScaleY(230f));
		guiStyle_FeedBack = new GUIStyle();
		guiStyle_FeedBack.font = Resources.Load<Font>(IGT_Constants.Font_LemonR);
		guiStyle_FeedBack.fontSize = (int)IGT_UIcommonFunc.ScaleX(11f);
		guiStyle_FeedBack.normal.textColor = Color.black;
		guiStyle_FeedBack.alignment = TextAnchor.UpperLeft;
		guiStyle_FeedBack.wordWrap = true;
		guiStyle_FeedBack.normal.background = Texture2D.whiteTexture;
	}

	private float currentTimeInSeconds()
	{
		return (float)(DateTime.UtcNow - Jan1st1970).TotalSeconds;
	}

	public void canShowRateItAlert(int missionIDx)
	{
		if (nRateItShownCount >= 7 || nRateItFinished != 0)
		{
			return;
		}
		if (missionIDx == 10 && IGT_Preference.getInstance()._Get(PREF_On10thMissionFirstTime, 0) == 0)
		{
			OnShowEvent();
			IGT_Preference.getInstance()._Set(PREF_On10thMissionFirstTime, 1);
		}
		else if (nRateItShownCount > 0)
		{
			float num = ((nRateItShownCount >= 4) ? 7f : 2f);
			if ((float)(long)(currentTimeInSeconds() - lastRateItShowTime) >= num * 24f * 60f * 60f)
			{
				OnShowEvent();
			}
		}
	}

	private void OnShowEvent()
	{
		lastRateItShowTime = currentTimeInSeconds();
		IGT_Preference.getInstance()._Set(PREF_LastShownTime, lastRateItShowTime);
		nRateItShownCount++;
		IGT_Preference.getInstance()._Set(PREF_ShownCount, nRateItShownCount);
		InitAskRateit();
	}

	public void ForceShowRateitAlert()
	{
		if (nRateItFinished == 0)
		{
			InitAskRateit();
		}
	}

	private void InitAskRateit()
	{
		bShowRateItAlert = true;
		nRateAlertWindow = 0;
		bThankFeedBack = false;
		bThankFeedback_Close = false;
		IGT_GameView.pHero.post_Analytics_Popup("RateIt");
		IGT_GameView.pHero.post_Analytics_RateIt("AskRateIt");
		pAnimator_Ask.resetAllValues();
		btnStar1.changeButtonTexture(starGrayBtn);
		btnStar2.changeButtonTexture(starGrayBtn);
		btnStar3.changeButtonTexture(starGrayBtn);
		btnStar4.changeButtonTexture(starGrayBtn);
		btnStar5.changeButtonTexture(starGrayBtn);
	}

	public void setCloseButEvents(bool bcloseButton)
	{
		if (bcloseButton)
		{
			if (nRateAlertWindow == 0)
			{
				if (pAnimator_Ask.isAnimFinished())
				{
					pAnimator_Ask.resetAllValues();
					pAnimator_Ask.setIsReverse(true);
					bThankFeedback_Close = false;
				}
			}
			else
			{
				bShowRateItAlert = false;
				nRateAlertWindow = 3;
			}
		}
		else
		{
			bShowRateItAlert = false;
			nRateAlertWindow = 3;
			if (bThankFeedBack)
			{
				setRateitFinished();
			}
		}
	}

	private void setRateitFinished()
	{
		nRateItFinished = 1;
		IGT_Preference.getInstance()._Set(PREF_RateIt_Finished, nRateItFinished);
		nRateAlertWindow = 3;
		bShowRateItAlert = false;
		bThankFeedBack = false;
	}

	public void ButtonBounceChecking(float _touchX, float _touchY, TouchPhase _touchPhase)
	{
		switch (nRateAlertWindow)
		{
		case 0:
			if (!bEnableStars)
			{
				btnClose.checkBounce(_touchX, _touchY, _touchPhase);
				btnStar1.checkBounce(_touchX, _touchY, _touchPhase);
				btnStar2.checkBounce(_touchX, _touchY, _touchPhase);
				btnStar3.checkBounce(_touchX, _touchY, _touchPhase);
				btnStar4.checkBounce(_touchX, _touchY, _touchPhase);
				btnStar5.checkBounce(_touchX, _touchY, _touchPhase);
			}
			break;
		case 1:
			btnClose.checkBounce(_touchX, _touchY, _touchPhase);
			btnRateNow.checkBounce(_touchX, _touchY, _touchPhase);
			break;
		case 2:
			btnClose.checkBounce(_touchX, _touchY, _touchPhase);
			btnSend.checkBounce(_touchX, _touchY, _touchPhase);
			break;
		case 3:
			break;
		}
	}

	public void OnButtonClick(IGT_Button button)
	{
		int num = 0;
		switch (button.getID())
		{
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
			num = ((button.getID() == 3) ? 1 : ((button.getID() == 4) ? 2 : ((button.getID() == 5) ? 3 : ((button.getID() != 6) ? 5 : 4))));
			Coroutiner.StartCoroutine(timeDelay(num));
			break;
		case 1:
			RateitNow();
			setRateitFinished();
			break;
		case 2:
			sendMail();
			setRateitFinished();
			break;
		case 0:
			setCloseButEvents(true);
			break;
		}
	}

	private IEnumerator timeDelay(int _clickedStarCnt)
	{
		switch (_clickedStarCnt)
		{
		case 5:
			btnStar1.changeButtonTexture(starBtn);
			btnStar2.changeButtonTexture(starBtn);
			btnStar3.changeButtonTexture(starBtn);
			btnStar4.changeButtonTexture(starBtn);
			btnStar5.changeButtonTexture(starBtn);
			break;
		case 4:
			btnStar1.changeButtonTexture(starBtn);
			btnStar2.changeButtonTexture(starBtn);
			btnStar3.changeButtonTexture(starBtn);
			btnStar4.changeButtonTexture(starBtn);
			break;
		case 3:
			btnStar1.changeButtonTexture(starBtn);
			btnStar2.changeButtonTexture(starBtn);
			btnStar3.changeButtonTexture(starBtn);
			break;
		case 2:
			btnStar1.changeButtonTexture(starBtn);
			btnStar2.changeButtonTexture(starBtn);
			break;
		case 1:
			btnStar1.changeButtonTexture(starBtn);
			break;
		}
		bEnableStars = true;
		yield return new WaitForSeconds(starWaitingTime);
		bEnableStars = false;
		switch (_clickedStarCnt)
		{
		case 4:
			bThankFeedBack = true;
			bThankFeedback_Close = true;
			fThankFeedback_StrtTime = Time.time;
			IGT_GameView.pHero.post_Analytics_RateIt("star_4");
			break;
		case 5:
			nRateAlertWindow = 1;
			break;
		default:
			nRateAlertWindow = 2;
			bodyTxt = " ";
			bDefaultBodytxtEnabled = false;
			break;
		}
	}

	public void drawRateItAlert()
	{
		switch (nRateAlertWindow)
		{
		case 0:
			DrawAskRateit();
			break;
		case 1:
			DrawRateNow();
			break;
		case 2:
			DrawfeedbackView();
			break;
		case 3:
			break;
		}
	}

	public void DrawAskRateit()
	{
		float num = 0f;
		num = (pAnimator_Ask.getIsReverse() ? pAnimator_Ask.easeFunctions(0f - rect_AskRateBg.height, IGT_UIcommonFunc.ScaleY(240f) - rect_AskRateBg.height * 0.5f, 1f, 28) : pAnimator_Ask.easeFunctions(0f, IGT_UIcommonFunc.ScaleY(240f) - rect_AskRateBg.height * 0.5f, 1.5f, 29));
		if (pAnimator_Ask.isAnimFinished() && pAnimator_Ask.getIsReverse())
		{
			setCloseButEvents(false);
			return;
		}
		IGT_GameView.pIgt_Textures.DrawTexture(IGT_Constants._RateitBg, new Rect(rect_AskRateBg.x, num, rect_AskRateBg.width, rect_AskRateBg.height), false);
		IGT_GameView.pIgt_Textures.drawBorder(new Rect(IGT_UIcommonFunc.ScaleX(40f), num, IGT_UIcommonFunc.ScaleX(240f), IGT_UIcommonFunc.ScaleY(130f)), 6f, IGT_GameView.Border_White);
		IGT_GameView.pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(56f), num, IGT_UIcommonFunc.ScaleX(210f), IGT_UIcommonFunc.ScaleY(80f)), rateitTxt, IGT_Constants.Font_LemonR, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, true, Color.white, Vector2.one, Color.black);
		IGT_GameView.pIgt_Textures.DrawTexture(IGT_Constants._ScoreMultiplier, new Rect(IGT_UIcommonFunc.ScaleX(30f), num - IGT_UIcommonFunc.ScaleY(15f), IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleY(40f)), false);
		btnClose.setDimensions(IGT_UIcommonFunc.ScaleX(255f), num - IGT_UIcommonFunc.ScaleY(1f), IGT_UIcommonFunc.ScaleX(25f), IGT_UIcommonFunc.ScaleY(25f));
		btnClose.Draw_Button();
		btnStar1.setY(num + IGT_UIcommonFunc.ScaleY(67f));
		btnStar1.Draw_Button();
		btnStar2.setY(num + IGT_UIcommonFunc.ScaleY(67f));
		btnStar2.Draw_Button();
		btnStar3.setY(num + IGT_UIcommonFunc.ScaleY(67f));
		btnStar3.Draw_Button();
		btnStar4.setY(num + IGT_UIcommonFunc.ScaleY(67f));
		btnStar4.Draw_Button();
		btnStar5.setY(num + IGT_UIcommonFunc.ScaleY(67f));
		btnStar5.Draw_Button();
		if (bThankFeedBack)
		{
			IGT_GameView.pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(60f), num + IGT_UIcommonFunc.ScaleY(95f), IGT_UIcommonFunc.ScaleX(200f), IGT_UIcommonFunc.ScaleY(40f)), "Thanks for your feedback", IGT_Constants.Font_LemonR, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, true, Color.white, Vector2.one, Color.black);
			if (Time.time - fThankFeedback_StrtTime > 2f && bThankFeedback_Close)
			{
				pAnimator_Ask.resetAllValues();
				pAnimator_Ask.setIsReverse(true);
				bThankFeedback_Close = false;
			}
		}
	}

	public void DrawRateNow()
	{
		IGT_GameView.pIgt_Textures.DrawTexture(IGT_Constants._RateitBg, rect_RatenowBg, false);
		IGT_GameView.pIgt_Lable.DrawLable(new Rect(rect_RatenowBg.x + IGT_UIcommonFunc.ScaleX(30f), rect_RatenowBg.y - IGT_UIcommonFunc.ScaleY(75f), IGT_UIcommonFunc.ScaleX(200f), IGT_UIcommonFunc.ScaleY(200f)), ratenowTitle, IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(16f), TextAnchor.MiddleCenter, true, Color.yellow, Vector2.one, Color.black);
		IGT_GameView.pIgt_Lable.DrawLable(new Rect(rect_RatenowBg.x + IGT_UIcommonFunc.ScaleX(30f), rect_RatenowBg.y + IGT_UIcommonFunc.ScaleY(5f), IGT_UIcommonFunc.ScaleX(200f), IGT_UIcommonFunc.ScaleY(200f)), ratenowTxt, IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, true, Color.white, Vector2.one, Color.black);
		IGT_GameView.pIgt_Textures.drawBorder(rect_RatenowBg, 6f, IGT_GameView.Border_White);
		IGT_GameView.pIgt_Textures.DrawTexture(IGT_Constants._ScoreMultiplier, new Rect(rect_RatenowBg.x - IGT_UIcommonFunc.ScaleX(10f), rect_RatenowBg.y - IGT_UIcommonFunc.ScaleY(15f), IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleY(40f)), false);
		btnClose.setDimensions(rect_RatenowBg.x + IGT_UIcommonFunc.ScaleX(235f), rect_RatenowBg.y - IGT_UIcommonFunc.ScaleY(1f), IGT_UIcommonFunc.ScaleX(25f), IGT_UIcommonFunc.ScaleY(25f));
		btnClose.Draw_Button();
		btnRateNow.Draw_Button();
		IGT_GameView.pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(115f), IGT_UIcommonFunc.ScaleY(290f), IGT_UIcommonFunc.ScaleX(90f), IGT_UIcommonFunc.ScaleY(38f)), "Rate It", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(17f), TextAnchor.MiddleCenter, true, Color.white, Vector2.one, Color.black);
	}

	public void DrawfeedbackView()
	{
		IGT_GameView.pIgt_Textures.DrawTexture(IGT_Constants._RateitBg, new Rect(IGT_UIcommonFunc.ScaleX(20f), IGT_UIcommonFunc.ScaleY(90f), IGT_UIcommonFunc.ScaleX(280f), IGT_UIcommonFunc.ScaleY(265f)), false);
		IGT_GameView.pIgt_Textures.drawBorder(new Rect(IGT_UIcommonFunc.ScaleX(20f), IGT_UIcommonFunc.ScaleY(90f), IGT_UIcommonFunc.ScaleX(280f), IGT_UIcommonFunc.ScaleY(265f)), 6f, IGT_GameView.Border_White);
		IGT_GameView.pIgt_Textures.DrawTexture(IGT_Constants._ScoreMultiplier, new Rect(IGT_UIcommonFunc.ScaleX(10f), IGT_UIcommonFunc.ScaleY(75f), IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleY(40f)), false);
		IGT_GameView.pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(20f), IGT_UIcommonFunc.ScaleY(100f), IGT_UIcommonFunc.ScaleX(280f), IGT_UIcommonFunc.ScaleY(30f)), "Send Feedback", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.white, Vector2.one, Color.black);
		IGT_GameView.pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(20f), IGT_UIcommonFunc.ScaleY(125f), IGT_UIcommonFunc.ScaleX(100f), IGT_UIcommonFunc.ScaleY(30f)), "To           :", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.white, Vector2.one, Color.black);
		IGT_GameView.pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(135f), IGT_UIcommonFunc.ScaleY(125f), IGT_UIcommonFunc.ScaleX(90f), IGT_UIcommonFunc.ScaleY(30f)), toSupportMail, IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.white, Vector2.one, Color.black);
		IGT_GameView.pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(20f), IGT_UIcommonFunc.ScaleY(145f), IGT_UIcommonFunc.ScaleX(100f), IGT_UIcommonFunc.ScaleY(30f)), "Subject   :", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.white, Vector2.one, Color.black);
		IGT_GameView.pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(135f), IGT_UIcommonFunc.ScaleY(145f), IGT_UIcommonFunc.ScaleX(90f), IGT_UIcommonFunc.ScaleY(30f)), subjTxt, IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.white, Vector2.one, Color.black);
		IGT_GameView.pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(20f), IGT_UIcommonFunc.ScaleY(165f), IGT_UIcommonFunc.ScaleX(100f), IGT_UIcommonFunc.ScaleY(30f)), "Message :", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.white, Vector2.one, Color.black);
		drawRect(new Rect(IGT_UIcommonFunc.ScaleX(60f), IGT_UIcommonFunc.ScaleY(200f), IGT_UIcommonFunc.ScaleX(190f), IGT_UIcommonFunc.ScaleY(100f)), Color.white);
		GUI.SetNextControlName("gopi");
		bodyTxt = GUI.TextArea(rectTxtArea, bodyTxt, guiStyle_FeedBack);
		if (!bDefaultBodytxtEnabled && GUI.GetNameOfFocusedControl() == "gopi")
		{
			bDefaultBodytxtEnabled = true;
		}
		if (!bDefaultBodytxtEnabled)
		{
			IGT_GameView.pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(60f), IGT_UIcommonFunc.ScaleY(200f), IGT_UIcommonFunc.ScaleX(190f), IGT_UIcommonFunc.ScaleY(100f)), defaultBodyText, IGT_Constants.Font_LemonR, (int)IGT_UIcommonFunc.ScaleX(11f), Color.gray, TextAnchor.UpperLeft, true);
		}
		btnClose.setDimensions(IGT_UIcommonFunc.ScaleX(275f), IGT_UIcommonFunc.ScaleY(89f), IGT_UIcommonFunc.ScaleX(25f), IGT_UIcommonFunc.ScaleY(25f));
		btnClose.Draw_Button();
		btnSend.setDimensions(IGT_UIcommonFunc.ScaleX(120f), IGT_UIcommonFunc.ScaleY(310f), IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(32f));
		btnSend.Draw_Button();
		IGT_GameView.pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(120f), IGT_UIcommonFunc.ScaleY(310f), IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(32f)), "Send", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(16f), TextAnchor.MiddleCenter, false, Color.white, Vector2.one, Color.black);
	}

	public void drawRect(Rect _position, Color _color)
	{
		if (rectBgTexture == null)
		{
			rectBgTexture = new Texture2D(1, 1);
		}
		if (guiStyle == null)
		{
			guiStyle = new GUIStyle();
		}
		rectBgTexture.SetPixel(0, 0, _color);
		rectBgTexture.Apply();
		guiStyle.normal.background = rectBgTexture;
		GUI.Box(_position, GUIContent.none, guiStyle);
	}

	public void RateitNow()
	{
		IGT_GameView.pHero.bCanShowAdOnForeGround = false;
		Application.OpenURL("market://details?id=com.igoldtech.streetchaser");
		IGT_GameView.pHero.post_Analytics_RateIt("PlayStore");
	}

	private void sendMail()
	{
		IGT_GameView.pHero.bCanShowAdOnForeGround = false;
		string text = WWW.EscapeURL(toSupportMail);
		string text2 = WWW.EscapeURL(subjTxt);
		string text3 = WWW.EscapeURL(bodyTxt);
		Application.OpenURL("mailto:" + text + "?subject=" + text2 + "&body=" + text3);
		IGT_GameView.pHero.post_Analytics_RateIt("FeedBackMail");
	}
}
