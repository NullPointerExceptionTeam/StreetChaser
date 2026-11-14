using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class IGT_GameView : MonoBehaviour, ButtonClickListner, IGT_GestureDetector
{
	private string sAndInterID = "ca-app-pub-1607508849226372/1861103488";

	private string sIOSInterID = "ca-app-pub-1607508849226372/1442301082";

	private string sIOSRewardID = "ca-app-pub-1607508849226372/8965567883";

	private string sAndRewardID = "ca-app-pub-1607508849226372/3058635086";

	public static IGT_AdManager pAds;

	private string kNickNameAvailable = "knicknameavailable";

	private string kGetNickName = "kgetnickname";

	public static bool bShowNickName;

	public static bool bDefaultNickNameText;

	private IGT_Button btnNickNameOk;

	private Rect rectNickNameAlert;

	private GUIStyle styleNickName;

	private bool dMailBoxisProcessing;

	private static int dMailBoxProcessedCount = 0;

	public static int dMailBoxSentCount = 0;

	public static string strNickName = string.Empty;

	public static string strDeviceID = null;

	private bool bInviteReLogin;

	private bool bShareReLogin;

	private bool bLikeReGamePage;

	private bool bLikeReCompanyPage;

	private bool bCheckLBUpdate;

	private WWWForm formFrndChase;

	private WWWForm formFrndMission;

	private WWWForm formTopWithMeChase;

	private WWWForm formTopWithMeMission;

	public static string sTitle = string.Empty;

	public static string strTest_1 = "strTest_1 :";

	public static string strTest1 = "strTest1";

	public static string strTest = "strTest...";

	public static float audioclipLength;

	public static float audioclipstartTime;

	public static bool bRewardedVideoTimeUp = false;

	private static DateTime Junt2017 = new DateTime(2017, 6, 20, 0, 0, 0, DateTimeKind.Utc);

	private string kFBInviteLastUpdateTime = "fbinvitelastupdatetime";

	private double dLBUpdateTimeDiff;

	private string shareTitle = "StreetChaser - Addictive Chasing Game";

	private string shareMsg = "Join me in playing 'StreetChaser', this game is very addictive and interesting. Get it free by tapping below link";

	private string shareURL = "https://play.google.com/store/apps/details?id=com.igoldtech.streetchaser";

	private string whatappShareUrl = "https://f9x28.app.goo.gl/V9Hh";

	private string mailShareUrl = "https://f9x28.app.goo.gl/vqxq";

	private string twitterShareUrl = "https://f9x28.app.goo.gl/CGrB";

	private string smsShareUrl = "https://f9x28.app.goo.gl/kKht";

	private static bool bProcessDeleteAppReqCall = false;

	private double timeDiff;

	private double timeDifference = 2.0;

	private string kFBLoginfirstTime = "firsttimefblogin";

	private string fbAppInviteUri = "https://fb.me/284019718766747";

	private string sGameUrl = "https://www.veegames.com/fb/android/igt_fbinfo_streetchaser/gamescore_streetchaser.php";

	private string fbLogInTxt = "Login facebook \n to continue...";

	public static IGT_LeaderboardAchievements pLeaderBoard;

	public static bool bIsShowGPluseLoginAlert = false;

	private string sGpluseSignInTxt = "Please sign in  to use \n Google Play Game services !";

	public static Action<bool> pIsFBGameLiked = null;

	public static Action<bool> pIsFBCompanyLiked = null;

	public static Action<int, int, int, int> pMissionLevelComplitedInfo = null;

	public static Action<int> CallGetScoreFunction_Action;

	public static IGT_Hero pHero;

	public static IGT_Textures pIgt_Textures;

	public static webView pMoregame;

	public static IGT_Lable pIgt_Lable;

	private Vector2 pTouchPositon;

	private TouchPhase pTouchPhase;

	public static int nScreenMode;

	public static int nPrevScreenMode;

	public static int nBeforePrevScreenMode;

	private bool bMouseTouchNeeded;

	private Vector2 CS_touchPosition;

	private TouchPhase CS_touchPhase;

	public static IGT_Animator pAnim_HS_menudwn;

	public static IGT_Animator pAnim_HS_menuBG;

	public static IGT_Animator pAnim_Alert;

	public static IGT_Animator pAnim_MissionCompleted_star1;

	public static IGT_Animator pAnim_MissionCompleted_star2;

	public static IGT_Animator pAnim_MissionCompleted_star3;

	public static IGT_Animator pAnim_MailBox;

	public static IGT_Animator pAnim_GAchievement;

	public static IGT_Animator pAnim_NoInternet;

	public static IGT_Button But_HS_Acheivement;

	private static IGT_Button But_HS_Missions;

	private static IGT_Button But_HS_Chase;

	private static IGT_Button But_HS_LeaderBoard;

	private static IGT_Button But_HS_Settings;

	private static IGT_Button But_HS_Life;

	private static IGT_Button But_HS_Coin;

	private static IGT_Button But_HS_Key;

	private static IGT_Button But_HS_MailBox;

	private static IGT_Button But_HS_SendLife;

	private static IGT_Button But_HS_AllShare;

	private static IGT_Button But_HS_MoreGames;

	private static IGT_Button But_HS_FreeLife;

	private static IGT_Button But_HS_Shop;

	private static IGT_Button But_HS_FConnect;

	private static IGT_Button But_HS_Menu;

	private Rect rect_HS_LeaderBoardBg;

	private Rect rect_HS_SettingsBg;

	private Rect rect_HS_CoinCount;

	private Rect rect_HS_CoinImg;

	private Rect rect_HS_KeyCount;

	private Rect rect_HS_KeyImg;

	private Rect rect_HS_MenuBarBg;

	private Rect rect_HS_TopFrame;

	private int fontSize_HS_Chase_Mission;

	private int fontSize_HS_LifeCount;

	private int fontSize_HS_CoinCount;

	private int fontSize_HS_KeyCount;

	private int fontSize_HS_MenuBar;

	private float ck;

	private float zz11;

	private Rect rect_samp;

	public static bool bLBwronganim = false;

	private Texture2D Mirror_Corner_Board;

	private static IGT_Button But_HS_FBLB;

	private static IGT_Button But_HS_GoogleLB;

	public static bool bleaderboardHSbtnClick = false;

	public static bool bHS_FBbtnClick = false;

	public static bool bHS_GooglebtnClick = false;

	public static bool bHS_mailbox = false;

	public static bool bHS_sendlife = false;

	public static bool bHS_asklife = false;

	public static bool bHS_allshare = false;

	public static bool bHS_settings = false;

	public static bool bHS_moregames = false;

	public static bool bHS_about = false;

	public static bool bHS_like = false;

	public static IGT_Animator pAnim_HS_LeaderBoard;

	private Texture2D Mirror_Chs_FB;

	private Texture2D Mirror_Msn_FB;

	private static IGT_Button But_settingsClose;

	private static IGT_Button But_Settings_Music;

	private static IGT_Button But_Settings_Sound;

	private static IGT_Button But_settings_Notification;

	private static IGT_Button But_Settings_RestorePurchase;

	private static IGT_Button But_Settings_FBLogout;

	private static IGT_Button But_Settings_EditNickName;

	private Rect rect_settingWindow;

	private Rect rect_Set_MusicIcon;

	private Rect rect_Set_SoundIcon;

	private Rect rect_Set_NotifyIcon;

	private Rect rect_Set_RestorePurchaseIcon;

	private Rect rect_Set_FbIcon;

	private Rect rect_Set_EditNameIcon;

	private Rect rect_Set_EditNameLable;

	private Rect rect_Set_MusicLable;

	private Rect rect_Set_SoundLabel;

	private Rect rect_Set_NotifyLabel;

	private Rect rect_Set_RestorePurchaseLabel;

	private Rect rect_Set_FbLabel;

	private Rect rect_Set_MusicToggleImg;

	private Rect rect_Set_SoundToggleImg;

	private Rect rect_Set_Notify_ToggleImg;

	private int fontSize_Set_Music;

	private int fontSize_Set_Notification;

	private int fontSize_Set_RestorePurchase;

	private int settingsBarGap;

	private int settingsIconsGapfrmBar_Y;

	private int settingsIconsGapfrmBar_X;

	private int settingsToggleGapfrmBar_Y;

	private int settingsToggleGapfrmBar_X;

	private bool bRestoreEnabled;

	private IGT_PrograssBar pSaveMeText;

	public static float fSaveMeTextFillingCurTime;

	private static IGT_Button But_Survive_UseKey;

	private static IGT_Button But_Survive_Watchvideo;

	private static IGT_Button But_Survive_TotKey;

	private Rect rect_SurviveWindowBG;

	private static bool bSuriviveRewardedVideoAvailable;

	private Rect rect_PausescreenBG;

	private static IGT_Button But_Pause_Back;

	private static IGT_Button But_Pause_Boost;

	private static IGT_Button But_Pause_Resume;

	private Rect rect_Prob;

	public static string sProb;

	private Rect rect_AbortBg;

	private Rect rect_Abort_Heart;

	private static IGT_Button But_Abort_Ok;

	private static IGT_Button But_Abort_Cancel;

	private Rect rect_NoMoreLivesBg;

	private Rect rect_NoMoreLivs_Heart;

	private static IGT_Button But_NoLives_Close;

	private static IGT_Button But_NoLives_AskFriends;

	private static IGT_Button But_NoLives_GetFree;

	private static IGT_Button But_NoLives_Purchase1;

	private static IGT_Button But_NoLives_Purchase2;

	private static IGT_Button But_NoLives_Purchase3;

	private Rect rect_NotEnoughKeysBG;

	private static IGT_Button But_NotEnoughKeys_Close;

	private static IGT_Button But_NotEnoughKeys_Purchase1;

	private static IGT_Button But_NotEnoughKeys_Purchase2;

	private static IGT_Button But_NotEnoughKeys_Purchase3;

	private IGT_Scroller pScroller_GameoverScroll;

	private Rect rect_GameoverBg;

	private Rect rect_GameoverScrollTitleBar;

	private Rect ScrollViewRect_GameoverScreen;

	private Rect ScrollViewRectImg_GameoverScreen;

	private Rect rect_Gameover_Coins;

	private Rect rect_Gameover_Key;

	private Rect rect_Gameover_Life;

	private Rect rect_GameoverScroll_Idx;

	private Rect rect_GameoverScroll_pic;

	private Rect rect_GameoverScroll_Name;

	private Rect rect_GameoverScroll_Score;

	private Rect rect_GameoverScroll_Dot;

	private Rect rect_GameoverScroll_IdxBg;

	private static IGT_Button But_FbScroll;

	private static IGT_Button But_TopchaseScroll;

	private static IGT_Button But_BustedScroll;

	private static IGT_Button But_GameoverscreenRestart;

	private static IGT_Button But_GameoverscreenHome;

	private Vector3 GameoverScroll_CurPos;

	private Vector2 GameoverScroll_beginScrollViewScrollPos;

	public static int nBustedScrollCount;

	public static int nGameoverScrollType;

	public static int fontSize_GameoverScrollName;

	public static int fontSize_GameoverScrollScore;

	private float GameoverScroll_ScrollviwRectMaxY;

	private float GameoverScroll_ScrollviewRectMinY;

	private float GameoverScroll_BarWid;

	private float GameoverScroll_BarHeight;

	private float GameoverScroll_BarStrtPosX;

	private float GameoverScroll_BarStrtPosY;

	private float GameoverScroll_BarGap_Busted;

	private float GameoverScroll_DatasGapFrmBar;

	private float GameoverScroll_BarGap;

	private float Gameover_FBitems_StrtY;

	private Rect[] rect_Gameover_Busted_Face;

	private Rect[] rect_Gameover_Busted_Badge;

	public static Texture2D Border_White;

	private Texture2D Border_custom;

	private Texture2D Drawrect_clr1;

	private Texture2D Drawrect_clr2;

	private Texture2D Nickname_clr;

	private Texture2D Border_Black;

	private Texture2D rect_Black;

	public static List<IGT_ScrollData> pIGT_ScrollData_GameOver_Fb;

	public static List<IGT_ScrollData> pIGT_ScrollData_GameOver_Topchase;

	public static List<IGT_ScrollData> pIGT_ScrollData_MC_FbFriends;

	public static List<IGT_ScrollData> pIGT_ScrollData_MC_FbGlobal;

	private static int nCurBustedFaceIdx;

	private static int nCurBustedBadgeIdx;

	private Texture2D Mirror_MC_FBtab;

	private Texture2D Mirror_BustedTab;

	private IGT_Scroller pScroller_PuchaseWindow;

	private Rect rect_puchaseBG;

	private Rect rect_purchaseTitlebar;

	private Rect ScrollViewRect_purchaseWindow;

	private Rect ScrollViewRectImg_purchaseWindow;

	private Rect rect_purchseProductImg;

	private Rect rect_CoincountPurchasewindow;

	private Rect rect_LifecountPurchasewindow;

	private Rect rect_KeycountPurchasewindow;

	private Rect rect_purchaseProductName;

	private Rect rect_purchaseProductDescp;

	private Rect rect_purchaseBuy;

	private static IGT_Button But_BackpurchaseWindow;

	private static IGT_Button But_Store;

	private static IGT_Button But_Combo;

	private static IGT_Button But_Boost;

	private static IGT_Button But_Free;

	private Vector3 purchaseWindow_CurPos;

	private Vector2 purchaseWindow_beginScrollViewScrollPos;

	public static int nPurchaseType;

	public static int fontSize_purProdName;

	public static int fontSize_purProdDescp;

	public static int fontSize_purProdPrice;

	private float purchaseWindow_ScrollviwRectMaxY;

	private float purchaseWindow_ScrollviewRectMinY;

	private float purchaseWindow_BarWid;

	private float purchaseWindow_BarHeight;

	private float purchaseWindow_BarStrtPosX;

	private float purchaseWindow_BarStrtPosY;

	private float purchaseWindow_BarGap;

	private float PurchaseScroll_ProductNameGapFrmBar;

	private float PurchaseScroll_ProductDescpGapFrmBar;

	private float PurchaseScroll_ProductImgGapFrmBar;

	private float fScrollAnimTime;

	private float fScrollAnimTotTime;

	private bool bScrollAnim;

	private bool isPurchaseButBtnDown;

	private Rect rect_Upgrade;

	private float fUpgradeGapX;

	private static bool bBoostUpgradeAnim;

	private Rect rect_ExitBg;

	private static IGT_Button But_Exit_Ok;

	private static IGT_Button But_Exit_Cancel;

	public static bool bExitAlert;

	public static bool bNoMoreLiveAlert;

	public static bool bAbortAlert;

	public static bool bAllShareAlerts;

	public static bool bNoInternetAlert;

	private static IGT_Button But_Gamescreen_Pause;

	public static Rect rect_Game_ChaseHeader;

	public static Rect rect_Game_ScroeText;

	public static Rect rect_Game_CoinImg;

	public static Rect rect_Game_CoinBg;

	public static Rect rect_DirMap;

	public static Rect rect_DirMapHero;

	public static Rect rect_DirMapEnemy;

	public static Rect rect_DirMapDist;

	public static Rect rect_EnemyHealthBar;

	public static Rect rect_HeroHealthBar;

	private IGT_PrograssBar pEnemy_Healthprograss;

	private IGT_PrograssBar pHero_Healthprograss;

	public static float nHealth_hero;

	public static float nHelath_Enemy;

	public static float fDirMapDist;

	public static bool bLowEnergy_Enemy;

	public static bool bLowEnergy_Hero;

	public static bool bCatchMode_End;

	public static bool bDirMapBlink;

	public static float fLowEnergy_Enemy_StrtTime;

	public static float fLowEnergy_Hero_StrtTime;

	public static float fCatchMode_StartTime;

	public static float fDirMapBlink_StartTime;

	private Rect rect_CountDownBG;

	public static double nCountDownNum;

	public static Rect[] rect_MultipleCollectionItemCount;

	public static Rect[] rect_MultipleCollectionItemImg;

	private int fontSize_MissionTargetCount;

	public static Rect rect_TickMark;

	private Rect rect_Fps;

	public static string pFps;

	public static string pSpdParams;

	private int fontSize_Fps;

	private static IGT_Button But_MissonCompleted_Next;

	private static IGT_Button But_MissonCompleted_Retry;

	private static IGT_Button But_MissonCompleted_Home;

	private static IGT_Button But_ChsUnlockAlert_Play;

	private static IGT_Button But_ChsUnlockAlert_Close;

	private Rect[] rect_starPos;

	private int nMC_ScrollType;

	private static IGT_Button But_MC_FB_Friends;

	private static IGT_Button But_MC_FB_Global;

	private static IGT_Button But_Mapback;

	private Rect rect_Menu_Bg;

	private static IGT_Button But_Menu_back;

	private static IGT_Button But_Menu_Shop;

	private static IGT_Button But_Menu_LeaderBoard;

	private static IGT_Button But_Menu_Achievement;

	private static IGT_Button But_Menu_Free;

	private static IGT_Button But_Menu_Settings;

	private static IGT_Button But_Menu_Share;

	private static IGT_Button But_Menu_MoreGames;

	private static IGT_Button But_Menu_About;

	private static IGT_Button But_Menu_Key;

	private static IGT_Button But_Menu_Coin;

	private static IGT_Button But_Menu_life;

	private static IGT_Button But_Menu_GoogleLB;

	private static IGT_Button But_Menu_FBLB;

	private static IGT_Button But_FBLB_AlertChase;

	private static IGT_Button But_FBLB_AlertMission;

	private static IGT_Button But_GoogleLB_Alertclose;

	private static IGT_Button But_FBLB_Alertclose;

	private static IGT_Button But_FBLB_Friends;

	private static IGT_Button But_FBLB_Global;

	public static bool bLeaderBoardbtnClick = false;

	public static bool bGoogleLbbtnClick = false;

	public static bool bFBbtnClick = false;

	public static bool bFBLBglobal = false;

	public static bool bFB_MsnEnablebtnClick = false;

	private float menuLB_BarStrtPosX;

	private float menuLB_FBitems_startY;

	private float menuLB_BarHeight;

	private float menuLB_BarWidth;

	private float menuLB_DatasGapFrmBar;

	private float menuLB_BarGap;

	private Rect rect_menuLB_dot;

	private Rect rect_menuLB_pic;

	private Rect rect_menuLB_Idx;

	private Rect rect_menuLB_Name;

	private Rect rect_menuLB_Score;

	private Rect rect_menuLB_IdxBG;

	private Texture2D[] rankbg;

	public static IGT_Animator pAnim_menu_LeaderBoard;

	private static IGT_Button But_Menu_left;

	private static IGT_Button But_Menu_Right;

	private static IGT_Button But_Menu_Select;

	private static IGT_Button But_Menu_Ready;

	private static float menu_btn_rotAng = 0f;

	private Rect rect_Herocoins_Bg;

	private Rect rect_coinsLabel;

	private Rect rect_coinsText;

	public static IGT_Animator pAnim_coinsBG;

	public static List<IGT_DisplayProperties> pIgtDispProp;

	private Rect rect_ArrowDim;

	private Rect rect_TapGlow;

	public static int nArrowAnimType;

	private IGT_Sprites pIGT_Sprites_Tap;

	public static bool bTutorialResetAnim;

	public static bool bChaseLockedAlert;

	public static bool bChaseLock_Alpha;

	public static bool bChaseUnlockAlertAnim;

	public static float fChaseLockAlert_StartTime;

	public static float fChaseLockAlert_TotTime;

	public static float fChaseLockAlpha_StartTime;

	private Rect rect_lockBG;

	public static bool bAppNotInstalledAlert;

	private static IGT_Button But_NoInternetAlertOK;

	public static bool bInappAlert = false;

	public static bool bFacebookAlert = false;

	private IGT_Button But_Inapp_Alert_Life1;

	private IGT_Button But_Inapp_Alert_Life2;

	private IGT_Button But_Inapp_Alert_Life3;

	private IGT_Button But_Inapp__Alert_Store;

	private IGT_Button But_Inapp__Alert_Close;

	private IGT_Button But_Inapp_Alert_Key1;

	private IGT_Button But_Inapp_Alert_Key2;

	private IGT_Button But_Inapp_Alert_Key3;

	private IGT_Button But_Inapp_Alert_Coin1;

	private IGT_Button But_Inapp_Alert_Coin2;

	private IGT_Button But_Inapp_Alert_Coin3;

	private IGT_Button But_Inapp_Alert_Combo1;

	private IGT_Button But_Inapp_Alert_Combo2;

	private IGT_Button But_Inapp_Alert_Combo3;

	private IGT_Button But_Inapp_fbconnect;

	private Rect rect_Inappalert_Win;

	public static int nAlertWin;

	public static bool bOutOfEnergyTextAlert;

	private Rect rect_AlertSize;

	public static string sAlertText;

	public static float fOutOfEnergyTextAlert_StrtTime;

	public static float fOutOfEnergyTextAlert_TotTime;

	public static bool bBringBackAlert;

	public static bool bBringBackAlert_Alpha;

	public static bool bBringBackDemoTapToContinueAlert;

	public static float fBringBack_Alert_StrtTime;

	public static float fBringBack_Alert_TotTime;

	public static float fBringBack_Alert_Alpha_StartTime;

	public static float fBringBack_Demo__TaptoContinue_StartTime;

	public static string sBringBackAlertText;

	public static string sBringBackDemoText;

	private Rect rect_BringBackAlert;

	public static Rect rect_BB_DirMap;

	public static Rect rect_BB_DirMapHero;

	public static Rect rect_BB_DirMapEnemy;

	public static Rect rect_BB_DirMapDist;

	public static bool bUpgradeAlert;

	private static IGT_Button But_Upgrade_Store;

	private static IGT_Button But_Upgrade_Cancel;

	private string sUpgradeAlertItemName;

	private string sUpgradeAlertItemCount;

	private int fontSize_missionPopupInfo;

	private Rect rect_MissionPopup;

	public static string MissionInfo;

	public static string pMissionInfo_TextureName;

	private static IGT_Button But_MissonInfoTapToContinue;

	private static bool bShowMissionTapToContinue;

	private IGT_Sprites pIGT_Sprites_MissionInfoTap;

	private float fMissionInfoTapToContinue_StartTime;

	private IGT_Sprites pIGT_Sprites_ChaseNewTap;

	private static float fChaseNewTap_StrtTime;

	private static IGT_Button But_postFB_Yes;

	private static IGT_Button But_postFB_No;

	private static IGT_Button But_feedInvite_Submit;

	private static IGT_Button But_feedInvite_Prev;

	private static IGT_Button But_feedInvite_Next;

	private static IGT_Button But_feedInvite_Close;

	private static IGT_Button But_feedInvite_Checkall;

	public static IGT_Animator pAnim_postalert;

	public static IGT_Animator pAnim_feedinvite;

	private static Rect rect_postonFB;

	public static bool bpostFBYes = false;

	public static bool bpostFBNo = false;

	public static bool bPostFBAlert = false;

	public static bool bnormalFeedShare = false;

	public static bool bFeedInviteFriendAlert = false;

	private Rect rect_feedInvBG;

	public static Texture2D[] tex;

	public static Dictionary<string, FBFriendInfoList> fbTagableFriends = null;

	public static List<string> feedTagkeys = null;

	public static List<string> taggableFriendsString = null;

	public static bool showLoading = true;

	public static bool showNetworkError = false;

	public static bool showFriendListError = false;

	public static bool prevBtnEnabled = false;

	public static bool nextBtnEnabled = true;

	public static bool showPartialLoading = false;

	public static float feedLoadingTime = 0f;

	public static bool[] feedElementLoading;

	public static int currentPage = 1;

	public static int feedType = 0;

	public static string feedLeveld;

	public static string feedChaseScore;

	private Vector2 prevTouchPos = Vector2.zero;

	private float fAbtTexY = 440f;

	private bool bTouchEnabled;

	private IGT_Button btn_MoregameClose;

	private IGT_Button btn_AboutClose;

	private IGT_Button But_Levelupscreen_Play;

	private Rect rectAboutBG;

	private Rect rect_MailBoxName;

	private Rect rect_AllShareBg;

	private IGT_Button btnFBLeaderBoardInvite;

	private Rect rect_MailBoxWin;

	private IGT_Scroller pScroller_MailBoxScroll;

	private int nMailType;

	public static Vector3 MailBoxScroll_CurPos;

	private Vector2 MailBoxScroll_beginScrollViewScrollPos;

	private float MailBoxScroll_BarWid;

	private float MailBoxScroll_BarHeight;

	private float MailBoxScroll_BarStrtPosX;

	private float MailBoxScroll_BarStrtPosY;

	private float MailBoxScroll_BarGap;

	private float MailBoxScroll_ScrollviwRectMaxY;

	private float MailBoxScroll_ScrollviewRectMinY;

	private Rect ScrollViewRect_MailBoxScroll;

	public static IGT_Button But_AllShare_Close;

	public static IGT_Button But_Mail_Accept;

	public static IGT_Button But_Mail_CheckAll;

	public static IGT_Button But_MailBox_Close;

	public static IGT_Button But_SendLife_Accept;

	public static IGT_Button But_AskLife_Accept;

	public static IGT_Button But_SendLife_CheckAll;

	public static IGT_Button But_AskLife_CheckAll;

	public static IGT_Button But_MailBox_FBConnect;

	public static IGT_Button But_MailBox_FBInvite;

	public static Dictionary<string, string> dictAskReqID = new Dictionary<string, string>();

	public static Dictionary<string, string> dictSendReqID = new Dictionary<string, string>();

	public static List<MailBoxAskSendInfo> listAskSend = new List<MailBoxAskSendInfo>();

	private IGT_Scroller pScroller_SendLifeScroll;

	public static Vector3 SendLifeScroll_CurPos;

	private Vector2 SendLifeScroll_beginScrollViewScrollPos;

	private float SendLifeScroll_BarWid;

	private float SendLifeScroll_BarHeight;

	private float SendLifeScroll_BarStrtPosX;

	private float SendLifeScroll_BarStrtPosY;

	private float SendLifeScroll_BarGap;

	private float SendLifeScroll_ScrollviwRectMaxY;

	private float SendLifeScroll_ScrollviewRectMinY;

	private Rect ScrollViewRect_SendLifeScroll;

	public static List<MailBoxAskSendInfo> listSendLife = new List<MailBoxAskSendInfo>();

	private Rect rect_SendLifeNamePos;

	private IGT_Scroller pScroller_AskLifeScroll;

	public static Vector3 AskLifeScroll_CurPos;

	private Vector2 AskLifeScroll_beginScrollViewScrollPos;

	private float AskLifeScroll_BarWid;

	private float AskLifeScroll_BarHeight;

	private float AskLifeScroll_BarStrtPosX;

	private float AskLifeScroll_BarStrtPosY;

	private float AskLifeScroll_BarGap;

	private float AskLifeScroll_ScrollviwRectMaxY;

	private float AskLifeScroll_ScrollviewRectMinY;

	private Rect ScrollViewRect_AskLifeScroll;

	private Rect rect_AskLifeNamePos;

	public static List<MailBoxAskSendInfo> listAskLife = new List<MailBoxAskSendInfo>();

	private IGT_Button btnGpluseSignin;

	private IGT_Button btnGplusealertClose;

	private Rect rectGpluseSigninalert;

	private IGT_Button btn_fbLog;

	private IGT_Button btn_Whatsapp;

	private IGT_Button btn_Twitter;

	private IGT_Button btn_MailShare;

	private IGT_Button btn_SMSShare;

	private igtSocialShare pSocialShare;

	public static lib_FaceBook pFacebook;

	private Dictionary<string, FBFriendInfoList> fbList = new Dictionary<string, FBFriendInfoList>();

	public static IGT_RateIt pRateit;

	private Rect rect_MailBoxNamePos;

	private int fontSz_fbName;

	private int fontSz_fbAskSendMsg;

	public static MapAPI pMapObj;

	public static GameObject[] pOnGui_3dObj_Hero;

	public static GameObject pOnGUI_3dObj_Camera;

	public static bool is3dObjNeeded;

	public static GameObject heroSelection_onGUICam;

	public static GameObject[] characters_List;

	private float btn_SourceAngle;

	private float btn_DestinationAngle;

	private static float characters_circle_radius = 1f;

	private static float camera_circle_radius = 2.3f;

	public static float HScam_cur_angle = 270f;

	public static float HScam_start_angle = 270f;

	public static float ang_btwn_Characters;

	private static float character_angle = 270f;

	private static float source_angle = 270f;

	private static float dest_angle;

	private static float fling_dest_angle = 0f;

	public static int selected_character = 0;

	public static int centre_character = 0;

	public static int playing_character = 0;

	private float tmp_XBegan;

	private float tmp_XMove;

	private float tmp_XEnd;

	private float diff_X;

	private float fling_diffX;

	private float move_tym1;

	private float start_tym;

	private float end_tym;

	private float v_city;

	private float distance_pts;

	private float HSbtn_start_tym;

	private float HScam_move_tym;

	public static Camera HS_selectionCamera;

	public static GameObject lt;

	public static Light lt1;

	private bool IsMove;

	private bool IsTouchEnd;

	private bool bfling;

	private bool bwrongmovement;

	private static int[] Character_Buy_Coins;

	private static int[] ready_character_idx;

	private static string[] character_slogans;

	private TouchPhase tmp_phase;

	private static bool mov_btn;

	private static bool coins_fission;

	private static Animator[] CS_hero_anim;

	private static Vector2[] coin_curve;

	private static IGT_Animator coin_move;

	private static float[] coin_move_tym;

	private static float[] coin_tmp_tym;

	private static int coins_ary = 0;

	public static bool bAchievementAlert = false;

	private static string completed_achievement;

	private static IGT_Button But_achievementalert_close;

	private static IGT_Button But_sorryAlert_Quit;

	public static bool bSorry = false;

	public static IGT_Animator pAnim_sorryAlert;

	private static bool bCanShowAdd;

	private double dRewardedVideoLastShowTimeIntervelMin = 10.0;

	private double dRewardedVideoLastShowTimeIntervelSec = 60.0;

	private double dRewardedVideoLastShowIntervelSec;

	private static bool bMoreGameEnableInPurchaseWindow;

	private static float fLastShownTime_MoreGamesinPurchaseWindow;

	private static float fMoreGamesClickedTime;

	private static float fGcCollectStrtTime;

	private static double dMoregamesLastShownTimeHrs = 24.0;

	private static double dMoregamesLastShownTimeMins = 60.0;

	private static double dMoregamesLastShownTimeSecs = 60.0;

	private static double dMoregamesLastShownIntervalTimeSec;

	private static int didClickMoreGames = 0;

	private static bool bNewBadgeInMoreGames;

	private static bool bNewBadgeIsInAnim;

	private static float fNewBadgeAnimStrtTime;

	public static bool canfbShare = false;

	public static bool canwhatsappShare = false;

	public static bool cansmsShare = false;

	public static bool canmailShare = false;

	public static bool caninstaShare = false;

	public static bool cantwitterShare = false;

	public static int isPendingfbShare = 0;

	public static int isPendingwhatsappShare = 0;

	public static int isPendingsmsShare = 0;

	public static int isPendingmailShare = 0;

	public static int isPendinginstaShare = 0;

	public static int isPendingtwitterShare = 0;

	public static long fbShareTime = 0L;

	public static long whatsappShareTime = 0L;

	public static long smsShareTime = 0L;

	public static long mailShareTime = 0L;

	public static long instaShareTime = 0L;

	public static long twitterShareTime = 0L;

	public static long feedShareTime = 0L;

	public static bool bToast;

	public static bool bToast_Alpha;

	public static float fToast_StartTime;

	public static float fToastAlpha_StartTime;

	public static string pToastText;

	public static Rect rect_Toast;

	public static int nLeaderBoard_Chase_DispState;

	public static int nLeaderBoard_Mission_DispState;

	public static float fLeaderBoard_Chase_LastUpdatedTime;

	public static float fLeaderBoard_Mission_LastUpdatedTime;

	public static float fLoadingStrtTime;

	public static float fLoadingTotTime = 15f;

	public static bool bCanGetScoreFrmInternet;

	public const float LEADERBOARD_UPDATE_INTERVAL = 180f;

	public IGT_Button But_GetScoreRetry;

	private string _sLoading = "Loading...";

	private string _sNoInternet = "No Internet Connection";

	private string _sConnectionFailed = "Connection Failed";

	public static Dictionary<string, Texture> userProfilePicDict;

	public static double timeTorRefreshFBlistDict;

	public static Action<Action, Action, Action, Action> pRefreshFBlistAction = null;

	public static Action pGetCompleted = null;

	private static IGT_Button But_MissionFailedSkip;

	private static bool bSkipButNeeded;

	private static bool bSkipButEnable;

	private const int SKIPLEVEL_COINS = 1000;

	private int levNum = 10;

	private float adjX = IGT_UIcommonFunc.ScaleX(41f);

	private float adjY = IGT_UIcommonFunc.ScaleY(25f);

	private Texture2D rectBgTexture;

	private GUIStyle guiStyle;

	private static bool bPurchaseWindow_LifeAdd = false;

	private static bool bPurchaseWindow_LifeCountScroll = false;

	private static bool bPurchaseWindow_KeyAdd = false;

	private static bool bPurchaseWindow_KeyCountScroll = false;

	private static bool bPurchaseWindow_coinAdd = false;

	private static bool bPurchaseWindow_CoinCountScroll = false;

	private static int nPurchaseWindow_Anim_Life_Src;

	private static int nPurchaseWindow_Anim_Life_Des;

	private static int nPurchaseWindow_Anim_Key_Src;

	private static int nPurchaseWindow_Anim_Key_Des;

	private static int nPurchaseWindow_Anim_Coin_Src;

	private static int nPurchaseWindow_Anim_Coin_Des;

	private bool bDrawInvite_Chase;

	private bool bDrawInvite_Mission;

	public void _Start()
	{
		userProfilePicDict = new Dictionary<string, Texture>();
		pAds = new IGT_AdManager("https://veegames.com/mobileads/php/igt_intadinfo_un_streetchaser.php");
		pAds.initInterAdIDs(sIOSInterID, sAndInterID);
		pAds.initRewardAdIDs(sIOSRewardID, sAndRewardID);
		pAds.setRewardedVideoAdDelegate(delegateRewardedVideoAd, delegateRewardedVideoAd_CloseBut);
		pAds.setAdViewDelegate(delegateAdView);
		timeDiff = Time.time;
		dRewardedVideoLastShowTimeIntervelMin = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_rewardedTimeInterVal, 10);
		formFrndChase = new WWWForm();
		formFrndMission = new WWWForm();
		formTopWithMeChase = new WWWForm();
		formTopWithMeMission = new WWWForm();
		pHero = GameObject.FindGameObjectWithTag("Player").GetComponent<IGT_Hero>();
		loadTextures();
		loadAllCollectionImages();
		loadFonts();
		Instantiate_3DGUIcharacters();
		setScreenMode(20);
		bMouseTouchNeeded = true;
		pAnim_coinsBG = new IGT_Animator();
		pAnim_HS_menuBG = new IGT_Animator();
		pAnim_Alert = new IGT_Animator();
		pAnim_MissionCompleted_star1 = new IGT_Animator();
		pAnim_MissionCompleted_star2 = new IGT_Animator();
		pAnim_MissionCompleted_star3 = new IGT_Animator();
		pAnim_HS_menudwn = new IGT_Animator();
		pAnim_MailBox = new IGT_Animator();
		pAnim_GAchievement = new IGT_Animator();
		pAnim_NoInternet = new IGT_Animator();
		pAnim_sorryAlert = new IGT_Animator();
		bAllShareAlerts = false;
		strDeviceID = getDeviceID();
		bShowNickName = false;
		rectNickNameAlert = new Rect(IGT_UIcommonFunc.ScaleX(70f), IGT_UIcommonFunc.ScaleY(160f), IGT_UIcommonFunc.ScaleX(180f), IGT_UIcommonFunc.ScaleY(120f));
		btnNickNameOk = new IGT_Button(new Rect(rectNickNameAlert.x + IGT_UIcommonFunc.ScaleX(65f), rectNickNameAlert.y + IGT_UIcommonFunc.ScaleY(85f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(26f)), pIgt_Textures.GetTexture(IGT_Constants._Button_Red), 98, 0, false, 0f, Vector2.zero, 0, 0f, 0, 0f, 0f);
		btnNickNameOk.setListener(this);
		styleNickName = new GUIStyle();
		styleNickName.font = pIgt_Lable.getFont(IGT_Constants.Font_TitanOne);
		styleNickName.fontSize = (int)IGT_UIcommonFunc.ScaleX(12f);
		styleNickName.normal.background = Texture2D.whiteTexture;
		styleNickName.alignment = TextAnchor.MiddleCenter;
		if (IGT_Preference.getInstance()._Get(kNickNameAvailable, 0) == 1 && PlayerPrefs.HasKey(kGetNickName))
		{
			strNickName = PlayerPrefs.GetString(kGetNickName, strNickName);
		}
		rect_HS_LeaderBoardBg = new Rect(IGT_UIcommonFunc.ScaleX(0f), IGT_UIcommonFunc.ScaleY(0f), IGT_UIcommonFunc.ScaleX(53f), IGT_UIcommonFunc.ScaleY(53f));
		But_HS_LeaderBoard = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(2f), IGT_UIcommonFunc.ScaleY(3f), IGT_UIcommonFunc.ScaleX(35f), IGT_UIcommonFunc.ScaleY(32f)), pIgt_Textures.GetTexture(IGT_Constants._leaderBoard), 2, 0, true, 0f, Vector2.zero, 0, 3f, 1, 2f, 2f);
		But_HS_LeaderBoard.setListener(this);
		rect_HS_SettingsBg = new Rect(IGT_UIcommonFunc.ScaleX(267f), IGT_UIcommonFunc.ScaleY(0f), IGT_UIcommonFunc.ScaleX(53f), IGT_UIcommonFunc.ScaleY(53f));
		But_HS_Settings = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(285f), IGT_UIcommonFunc.ScaleY(5f), IGT_UIcommonFunc.ScaleX(32f), IGT_UIcommonFunc.ScaleY(32f)), pIgt_Textures.GetTexture(IGT_Constants._Settings), 5, 0, true, 0f, new Vector2(0.5f, 0.5f), 0, 3f, 3, 5f, 2f);
		But_HS_Settings.setListener(this);
		But_HS_Settings.setAnimProperties(0f, 0f, 10f);
		rect_HS_TopFrame = new Rect(IGT_UIcommonFunc.ScaleX(68.5f), IGT_UIcommonFunc.ScaleY(0f), IGT_UIcommonFunc.ScaleX(183f), IGT_UIcommonFunc.ScaleY(54f));
		But_HS_Life = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(145f), IGT_UIcommonFunc.ScaleY(1f), IGT_UIcommonFunc.ScaleX(28f), IGT_UIcommonFunc.ScaleY(28f)), pIgt_Textures.GetTexture(IGT_Constants._Life), 6, 0, true, 0f, Vector2.zero, 2, 2f, 2, 2f, 2f);
		But_HS_Life.setListener(this);
		But_HS_Life.setAnimProperties(0f - But_HS_Life.getHeight(), But_HS_Life.getY(), 0f);
		But_HS_Coin = new IGT_Button(7, IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(0f), IGT_UIcommonFunc.ScaleX(62f), IGT_UIcommonFunc.ScaleY(22f));
		But_HS_Coin.setListener(this);
		rect_HS_CoinImg = new Rect(IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(4f), IGT_UIcommonFunc.ScaleX(16f), IGT_UIcommonFunc.ScaleY(16f));
		rect_HS_CoinCount = new Rect(IGT_UIcommonFunc.ScaleX(87f), IGT_UIcommonFunc.ScaleY(3.5f), IGT_UIcommonFunc.ScaleX(44f), IGT_UIcommonFunc.ScaleY(18f));
		fontSize_HS_CoinCount = (int)IGT_UIcommonFunc.ScaleX(12f);
		But_HS_Key = new IGT_Button(8, IGT_UIcommonFunc.ScaleX(183f), IGT_UIcommonFunc.ScaleY(0f), IGT_UIcommonFunc.ScaleX(62f), IGT_UIcommonFunc.ScaleY(22f));
		But_HS_Key.setListener(this);
		rect_HS_KeyImg = new Rect(IGT_UIcommonFunc.ScaleX(184f), IGT_UIcommonFunc.ScaleY(3f), IGT_UIcommonFunc.ScaleX(16f), IGT_UIcommonFunc.ScaleY(16f));
		rect_HS_KeyCount = new Rect(IGT_UIcommonFunc.ScaleX(195f), IGT_UIcommonFunc.ScaleY(2.5f), IGT_UIcommonFunc.ScaleX(44f), IGT_UIcommonFunc.ScaleY(18f));
		fontSize_HS_KeyCount = (int)IGT_UIcommonFunc.ScaleX(12f);
		But_HS_MailBox = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(123f), IGT_UIcommonFunc.ScaleY(29f), IGT_UIcommonFunc.ScaleX(26f), IGT_UIcommonFunc.ScaleY(18f)), pIgt_Textures.GetTexture(IGT_Constants._Email), 9, 0, false, 0f, Vector2.zero, 2, 1f, 0, 5f, 2f);
		But_HS_MailBox.setListener(this);
		But_HS_MailBox.setAnimProperties(0f - But_HS_MailBox.getHeight(), But_HS_MailBox.getY(), 0f);
		But_HS_SendLife = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(170f), IGT_UIcommonFunc.ScaleY(29f), IGT_UIcommonFunc.ScaleX(26f), IGT_UIcommonFunc.ScaleY(18f)), pIgt_Textures.GetTexture(IGT_Constants._SendLife), 10, 0, false, 0f, Vector2.zero, 2, 1f, 0, 5f, 2f);
		But_HS_SendLife.setListener(this);
		But_HS_SendLife.setAnimProperties(0f - But_HS_SendLife.getHeight(), But_HS_SendLife.getY(), 0f);
		But_HS_Acheivement = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(0f), IGT_UIcommonFunc.ScaleY(200f), IGT_UIcommonFunc.ScaleX(60f), IGT_UIcommonFunc.ScaleY(60f)), pIgt_Textures.GetTexture(IGT_Constants._Achievement), 11, 0, true, 0f, Vector2.zero, 4, 1f, 0, 5f, 2f);
		But_HS_Acheivement.setListener(this);
		But_HS_Acheivement.setAnimProperties(0f - But_HS_Acheivement.getWidth(), But_HS_Acheivement.getX(), 0f);
		But_HS_AllShare = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(270f), IGT_UIcommonFunc.ScaleY(200f), IGT_UIcommonFunc.ScaleX(48f), IGT_UIcommonFunc.ScaleY(40f)), pIgt_Textures.GetTexture(IGT_Constants._AllShare), 108, 0, true, 0f, Vector2.zero, 5, 1f, 0, 5f, 2f);
		But_HS_AllShare.setListener(this);
		But_HS_AllShare.setAnimProperties((float)Screen.width + But_HS_AllShare.getWidth(), But_HS_AllShare.getX(), 0f);
		But_HS_MoreGames = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(5f), IGT_UIcommonFunc.ScaleY(56f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(46f)), pIgt_Textures.GetTexture(IGT_Constants._MoreGames), 12, 0, true, 0f, Vector2.zero, 4, 1f, 0, 5f, 2f);
		But_HS_MoreGames.setListener(this);
		But_HS_MoreGames.setAnimProperties(0f - But_HS_MoreGames.getWidth(), But_HS_MoreGames.getX(), 0f);
		But_HS_FreeLife = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(265f), IGT_UIcommonFunc.ScaleY(54f), IGT_UIcommonFunc.ScaleX(53f), IGT_UIcommonFunc.ScaleY(48f)), pIgt_Textures.GetTexture(IGT_Constants._WatchVideo), 13, 0, true, 0f, Vector2.zero, 5, 1f, 0, 5f, 2f);
		But_HS_FreeLife.setListener(this);
		But_HS_FreeLife.setAnimProperties((float)Screen.width + But_HS_FreeLife.getWidth(), But_HS_FreeLife.getX(), 0f);
		rect_HS_MenuBarBg = new Rect(IGT_UIcommonFunc.ScaleX(0f), IGT_UIcommonFunc.ScaleY(405f), IGT_UIcommonFunc.ScaleX(320f), IGT_UIcommonFunc.ScaleY(75f));
		But_HS_Shop = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(20f), IGT_UIcommonFunc.ScaleY(420f), IGT_UIcommonFunc.ScaleX(55f), IGT_UIcommonFunc.ScaleY(55f)), pIgt_Textures.GetTexture(IGT_Constants._Shop_HS), 15, 0, true, 0f, Vector2.zero, 4, 1f, 0, 5f, 2f);
		But_HS_Shop.setListener(this);
		But_HS_Shop.setAnimProperties(0f - But_HS_Shop.getWidth(), But_HS_Shop.getX(), 0f);
		But_HS_Shop.setSameRatioBasedOnHeight();
		But_HS_Menu = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(132.5f), IGT_UIcommonFunc.ScaleY(420f), IGT_UIcommonFunc.ScaleX(55f), IGT_UIcommonFunc.ScaleY(55f)), pIgt_Textures.GetTexture(IGT_Constants._Menu), 16, 0, true, 0f, Vector2.zero, 3, 1f, 0, 5f, 2f);
		But_HS_Menu.setListener(this);
		But_HS_Menu.setAnimProperties((float)Screen.height + But_HS_Menu.getHeight(), But_HS_Menu.getY(), 0f);
		But_HS_Menu.setSameRatioBasedOnHeight();
		But_HS_FConnect = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(245f), IGT_UIcommonFunc.ScaleY(420f), IGT_UIcommonFunc.ScaleX(55f), IGT_UIcommonFunc.ScaleY(55f)), pIgt_Textures.GetTexture(IGT_Constants._FConnect), 14, 0, true, 0f, Vector2.zero, 5, 1f, 0, 5f, 2f);
		But_HS_FConnect.setListener(this);
		But_HS_FConnect.setAnimProperties((float)Screen.width + But_HS_FConnect.getWidth(), But_HS_FConnect.getX(), 0f);
		But_HS_FConnect.setSameRatioBasedOnHeight();
		fontSize_HS_MenuBar = (int)IGT_UIcommonFunc.ScaleX(12f);
		But_HS_Chase = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(180f), IGT_UIcommonFunc.ScaleY(340f), IGT_UIcommonFunc.ScaleX(84f), IGT_UIcommonFunc.ScaleY(42f)), pIgt_Textures.GetTexture(IGT_Constants._Chase), 0, 0, false, 10f, new Vector2(1f, 0f), 1, 1.5f, 0, 5f, 3f);
		But_HS_Chase.setListener(this);
		fontSize_HS_Chase_Mission = (int)IGT_UIcommonFunc.ScaleX(18f);
		But_HS_Missions = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(56f), IGT_UIcommonFunc.ScaleY(340f), IGT_UIcommonFunc.ScaleX(84f), IGT_UIcommonFunc.ScaleY(42f)), pIgt_Textures.GetTexture(IGT_Constants._Mission), 1, 0, false, -10f, new Vector2(0f, 0f), 1, 1.5f, 0, 5f, 3f);
		But_HS_Missions.setListener(this);
		But_HS_GoogleLB = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(16f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), pIgt_Textures.GetTexture(IGT_Constants._GoogleLB), 3, 0, true, 0f, new Vector2(0f, 0f), 1, 1.5f, 0, 5f, 3f);
		But_HS_GoogleLB.setListener(this);
		But_HS_FBLB = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(8f), IGT_UIcommonFunc.ScaleY(53f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), pIgt_Textures.GetTexture(IGT_Constants._FacebookLB), 4, 0, true, 0f, new Vector2(0f, 0f), 1, 1.5f, 0, 5f, 3f);
		But_HS_FBLB.setListener(this);
		pAnim_HS_LeaderBoard = new IGT_Animator();
		settingsBarGap = (int)IGT_UIcommonFunc.ScaleX(4.2f);
		settingsIconsGapfrmBar_X = (int)IGT_UIcommonFunc.ScaleX(8f);
		settingsIconsGapfrmBar_Y = (int)IGT_UIcommonFunc.ScaleX(8f);
		settingsToggleGapfrmBar_X = (int)IGT_UIcommonFunc.ScaleX(170f);
		settingsToggleGapfrmBar_Y = (int)IGT_UIcommonFunc.ScaleX(14f);
		if (nGetCurrentPlatform() == 1 || nGetCurrentPlatform() == 2)
		{
			bRestoreEnabled = true;
			rect_settingWindow = new Rect(IGT_UIcommonFunc.ScaleX(32f), IGT_UIcommonFunc.ScaleY(50f), IGT_UIcommonFunc.ScaleX(256f), IGT_UIcommonFunc.ScaleY(370f));
			But_Settings_Music = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(57f), IGT_UIcommonFunc.ScaleY(110f), IGT_UIcommonFunc.ScaleX(205f), IGT_UIcommonFunc.ScaleY(42f)), pIgt_Textures.GetTexture(IGT_Constants._SettingsBar), 18, 0, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
			But_Settings_Sound = new IGT_Button(new Rect(But_Settings_Music.getX(), But_Settings_Music.getY() + (But_Settings_Music.getHeight() + (float)settingsBarGap) * 1f, But_Settings_Music.getWidth(), But_Settings_Music.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._SettingsBar), 19, 0, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
			But_settings_Notification = new IGT_Button(new Rect(But_Settings_Music.getX(), But_Settings_Music.getY() + (But_Settings_Music.getHeight() + (float)settingsBarGap) * 2f, But_Settings_Music.getWidth(), But_Settings_Music.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._SettingsBar), 21, 0, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
			But_Settings_RestorePurchase = new IGT_Button(new Rect(But_Settings_Music.getX(), But_Settings_Music.getY() + (But_Settings_Music.getHeight() + (float)settingsBarGap) * 3f, But_Settings_Music.getWidth(), But_Settings_Music.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._SettingsBar), 22, 0, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
			But_Settings_EditNickName = new IGT_Button(new Rect(But_Settings_Music.getX(), But_Settings_Music.getY() + (But_Settings_Music.getHeight() + (float)settingsBarGap) * 4f, But_Settings_Music.getWidth(), But_Settings_Music.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._SettingsBar), 99, 0, false, 0f, Vector2.zero, 0, 0f, 0, 0f, 0f);
			But_Settings_FBLogout = new IGT_Button(new Rect(But_Settings_Music.getX(), But_Settings_Music.getY() + (But_Settings_Music.getHeight() + (float)settingsBarGap) * 5f, But_Settings_Music.getWidth(), But_Settings_Music.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._SettingsBar), 20, 0, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		}
		else
		{
			bRestoreEnabled = false;
			rect_settingWindow = new Rect(IGT_UIcommonFunc.ScaleX(32f), IGT_UIcommonFunc.ScaleY(60f), IGT_UIcommonFunc.ScaleX(256f), IGT_UIcommonFunc.ScaleY(350f));
			But_Settings_Music = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(57f), IGT_UIcommonFunc.ScaleY(110f) + (IGT_UIcommonFunc.ScaleY(42f) + (float)settingsBarGap) * 0.5f, IGT_UIcommonFunc.ScaleX(205f), IGT_UIcommonFunc.ScaleY(42f)), pIgt_Textures.GetTexture(IGT_Constants._SettingsBar), 18, 0, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
			But_Settings_Sound = new IGT_Button(new Rect(But_Settings_Music.getX(), But_Settings_Music.getY() + (But_Settings_Music.getHeight() + (float)settingsBarGap) * 1f, But_Settings_Music.getWidth(), But_Settings_Music.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._SettingsBar), 19, 0, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
			But_settings_Notification = new IGT_Button(new Rect(But_Settings_Music.getX(), But_Settings_Music.getY() + (But_Settings_Music.getHeight() + (float)settingsBarGap) * 2f, But_Settings_Music.getWidth(), But_Settings_Music.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._SettingsBar), 21, 0, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
			But_Settings_EditNickName = new IGT_Button(new Rect(But_Settings_Music.getX(), But_Settings_Music.getY() + (But_Settings_Music.getHeight() + (float)settingsBarGap) * 3f, But_Settings_Music.getWidth(), But_Settings_Music.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._SettingsBar), 99, 0, false, 0f, Vector2.zero, 0, 0f, 0, 0f, 0f);
			But_Settings_FBLogout = new IGT_Button(new Rect(But_Settings_Music.getX(), But_Settings_Music.getY() + (But_Settings_Music.getHeight() + (float)settingsBarGap) * 4f, But_Settings_Music.getWidth(), But_Settings_Music.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._SettingsBar), 20, 0, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
			But_Settings_RestorePurchase = new IGT_Button(new Rect(But_Settings_Music.getX(), But_Settings_Music.getY() + (But_Settings_Music.getHeight() + (float)settingsBarGap) * 100f, But_Settings_Music.getWidth(), But_Settings_Music.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._SettingsBar), 22, 0, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		}
		But_settingsClose = new IGT_Button(new Rect(rect_settingWindow.x + rect_settingWindow.width - IGT_UIcommonFunc.ScaleX(37f), rect_settingWindow.y + IGT_UIcommonFunc.ScaleY(4f), IGT_UIcommonFunc.ScaleX(35f), IGT_UIcommonFunc.ScaleX(35f)), pIgt_Textures.GetTexture(IGT_Constants._CloseRect), 17, 0, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_settingsClose.setListener(this);
		But_Settings_Music.setListener(this);
		rect_Set_MusicIcon = new Rect(But_Settings_Music.getX() + (float)settingsIconsGapfrmBar_X, But_Settings_Music.getY() + (float)settingsIconsGapfrmBar_Y, IGT_UIcommonFunc.ScaleX(26f), IGT_UIcommonFunc.ScaleY(26f));
		rect_Set_MusicLable = new Rect(But_Settings_Music.getX(), But_Settings_Music.getY(), But_Settings_Music.getWidth(), But_Settings_Music.getHeight());
		fontSize_Set_Music = (int)IGT_UIcommonFunc.ScaleX(20f);
		rect_Set_MusicToggleImg = new Rect(But_Settings_Music.getX() + (float)settingsToggleGapfrmBar_X, But_Settings_Music.getY() + (float)settingsToggleGapfrmBar_Y, IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(18f));
		But_Settings_Sound.setListener(this);
		rect_Set_SoundIcon = new Rect(But_Settings_Sound.getX() + (float)settingsIconsGapfrmBar_X, But_Settings_Sound.getY() + (float)settingsIconsGapfrmBar_Y, IGT_UIcommonFunc.ScaleX(26f), IGT_UIcommonFunc.ScaleY(26f));
		rect_Set_SoundLabel = new Rect(But_Settings_Sound.getX(), But_Settings_Sound.getY(), But_Settings_Sound.getWidth(), But_Settings_Sound.getHeight());
		rect_Set_SoundToggleImg = new Rect(But_Settings_Sound.getX() + (float)settingsToggleGapfrmBar_X, But_Settings_Sound.getY() + (float)settingsToggleGapfrmBar_Y, IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(18f));
		But_settings_Notification.setListener(this);
		rect_Set_NotifyIcon = new Rect(But_settings_Notification.getX() + (float)settingsIconsGapfrmBar_X, But_settings_Notification.getY() + (float)settingsIconsGapfrmBar_Y, IGT_UIcommonFunc.ScaleX(26f), IGT_UIcommonFunc.ScaleY(26f));
		rect_Set_NotifyLabel = new Rect(But_settings_Notification.getX(), But_settings_Notification.getY(), But_settings_Notification.getWidth(), But_settings_Notification.getHeight());
		fontSize_Set_Notification = (int)IGT_UIcommonFunc.ScaleX(17f);
		rect_Set_Notify_ToggleImg = new Rect(But_settings_Notification.getX() + (float)settingsToggleGapfrmBar_X, But_settings_Notification.getY() + (float)settingsToggleGapfrmBar_Y, IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(18f));
		But_Settings_RestorePurchase.setListener(this);
		rect_Set_RestorePurchaseIcon = new Rect(But_Settings_RestorePurchase.getX() + (float)settingsIconsGapfrmBar_X, But_Settings_RestorePurchase.getY() + (float)settingsIconsGapfrmBar_Y, IGT_UIcommonFunc.ScaleX(26f), IGT_UIcommonFunc.ScaleY(26f));
		rect_Set_RestorePurchaseLabel = new Rect(But_Settings_RestorePurchase.getX(), But_Settings_RestorePurchase.getY(), But_Settings_RestorePurchase.getWidth(), But_Settings_RestorePurchase.getHeight());
		fontSize_Set_RestorePurchase = (int)IGT_UIcommonFunc.ScaleX(13f);
		But_Settings_EditNickName.setListener(this);
		rect_Set_EditNameIcon = new Rect(But_Settings_EditNickName.getX() + (float)settingsIconsGapfrmBar_X, But_Settings_EditNickName.getY() + (float)settingsIconsGapfrmBar_Y, IGT_UIcommonFunc.ScaleX(26f), IGT_UIcommonFunc.ScaleY(26f));
		rect_Set_EditNameLable = new Rect(But_Settings_EditNickName.getX(), But_Settings_EditNickName.getY(), But_Settings_EditNickName.getWidth(), But_Settings_EditNickName.getHeight());
		But_Settings_FBLogout.setListener(this);
		rect_Set_FbIcon = new Rect(But_Settings_FBLogout.getX() + (float)settingsIconsGapfrmBar_X, But_Settings_FBLogout.getY() + (float)settingsIconsGapfrmBar_Y, IGT_UIcommonFunc.ScaleX(26f), IGT_UIcommonFunc.ScaleY(26f));
		rect_Set_FbLabel = new Rect(But_Settings_FBLogout.getX(), But_Settings_FBLogout.getY(), But_Settings_FBLogout.getWidth(), But_Settings_FBLogout.getHeight());
		rect_SurviveWindowBG = new Rect(IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleY(168f), IGT_UIcommonFunc.ScaleX(240f), IGT_UIcommonFunc.ScaleY(144f));
		But_Survive_UseKey = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(0f), rect_SurviveWindowBG.y + IGT_UIcommonFunc.ScaleY(82f), IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(35f)), pIgt_Textures.GetTexture(IGT_Constants._SaveMeUseKey), 23, 0, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_Survive_UseKey.setListener(this);
		But_Survive_Watchvideo = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(0f), But_Survive_UseKey.getY(), But_Survive_UseKey.getWidth(), But_Survive_UseKey.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._SaveMeWatchVideo), 24, 0, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_Survive_Watchvideo.setListener(this);
		But_Survive_TotKey = new IGT_Button(25, rect_SurviveWindowBG.x + rect_SurviveWindowBG.width - IGT_UIcommonFunc.ScaleX(70f), rect_SurviveWindowBG.y + IGT_UIcommonFunc.ScaleY(14f), IGT_UIcommonFunc.ScaleX(53f), IGT_UIcommonFunc.ScaleY(15f));
		But_Survive_TotKey.setListener(this);
		pSaveMeText = new IGT_PrograssBar(pIgt_Textures.GetTexture(IGT_Constants._SaveMeRed), new Rect(rect_SurviveWindowBG.x + rect_SurviveWindowBG.width / 2f - IGT_UIcommonFunc.ScaleX(98f) / 2f, rect_SurviveWindowBG.y + IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleX(98f), IGT_UIcommonFunc.ScaleY(22f)), pIgt_Textures.GetTexture(IGT_Constants._SaveMeGreen), new Rect(rect_SurviveWindowBG.x + rect_SurviveWindowBG.width / 2f - IGT_UIcommonFunc.ScaleX(98f) / 2f, rect_SurviveWindowBG.y + IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleX(98f), IGT_UIcommonFunc.ScaleY(22f)), true, 1f, 1f, new Rect(0f, 0f, 1f, 1f));
		bSuriviveRewardedVideoAvailable = true;
		rect_PausescreenBG = new Rect(IGT_UIcommonFunc.ScaleX(20f), IGT_UIcommonFunc.ScaleY(154f), IGT_UIcommonFunc.ScaleX(280f), IGT_UIcommonFunc.ScaleY(150f));
		But_Pause_Boost = new IGT_Button(new Rect(rect_PausescreenBG.x + rect_PausescreenBG.width / 2f - IGT_UIcommonFunc.ScaleX(53f) / 2f, rect_PausescreenBG.y + rect_PausescreenBG.height / 2f - IGT_UIcommonFunc.ScaleY(42f) / 2f + IGT_UIcommonFunc.ScaleY(7f), IGT_UIcommonFunc.ScaleX(53f), IGT_UIcommonFunc.ScaleY(42f)), pIgt_Textures.GetTexture(IGT_Constants._Pause_Boost), 27, 0, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_Pause_Boost.setListener(this);
		But_Pause_Back = new IGT_Button(new Rect(But_Pause_Boost.getX() - But_Pause_Boost.getWidth() - IGT_UIcommonFunc.ScaleX(12f), But_Pause_Boost.getY(), But_Pause_Boost.getWidth(), But_Pause_Boost.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._Pause_Back), 26, 0, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_Pause_Back.setListener(this);
		But_Pause_Resume = new IGT_Button(new Rect(But_Pause_Boost.getX() + But_Pause_Boost.getWidth() + IGT_UIcommonFunc.ScaleX(12f), But_Pause_Boost.getY(), But_Pause_Boost.getWidth(), But_Pause_Boost.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._Pause_Resume), 28, 0, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_Pause_Resume.setListener(this);
		rect_Prob = new Rect(IGT_UIcommonFunc.ScaleX(10f), IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleX(300f), IGT_UIcommonFunc.ScaleY(40f));
		rect_AbortBg = new Rect(IGT_UIcommonFunc.ScaleX(62f), IGT_UIcommonFunc.ScaleY(154f), IGT_UIcommonFunc.ScaleX(196f), IGT_UIcommonFunc.ScaleY(150f));
		But_Abort_Ok = new IGT_Button(new Rect(rect_AbortBg.x + rect_AbortBg.width / 2f + IGT_UIcommonFunc.ScaleX(16f), rect_AbortBg.y + rect_AbortBg.height - IGT_UIcommonFunc.ScaleY(30f) - IGT_UIcommonFunc.ScaleY(20f), IGT_UIcommonFunc.ScaleX(60f), IGT_UIcommonFunc.ScaleY(30f)), pIgt_Textures.GetTexture(IGT_Constants._Abort_Ok), 29, 0, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_Abort_Ok.setListener(this);
		But_Abort_Cancel = new IGT_Button(new Rect(rect_AbortBg.x + rect_AbortBg.width / 2f - IGT_UIcommonFunc.ScaleX(16f) - But_Abort_Ok.getWidth(), But_Abort_Ok.getY(), But_Abort_Ok.getWidth(), But_Abort_Ok.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._Abort_Cancel), 30, 0, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_Abort_Cancel.setListener(this);
		rect_Abort_Heart = new Rect(rect_AbortBg.x + rect_AbortBg.width / 2f - IGT_UIcommonFunc.ScaleX(50f) / 2f, rect_AbortBg.y + rect_AbortBg.height / 2f - IGT_UIcommonFunc.ScaleY(47f) / 2f - IGT_UIcommonFunc.ScaleY(7f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(47f));
		bAbortAlert = false;
		rect_NoMoreLivesBg = new Rect(IGT_UIcommonFunc.ScaleX(48f), IGT_UIcommonFunc.ScaleY(134f), IGT_UIcommonFunc.ScaleX(224f), IGT_UIcommonFunc.ScaleY(212f));
		But_NoLives_Close = new IGT_Button(new Rect(rect_NoMoreLivesBg.x + rect_NoMoreLivesBg.width - IGT_UIcommonFunc.ScaleX(36f) - IGT_UIcommonFunc.ScaleX(1f), rect_NoMoreLivesBg.y + IGT_UIcommonFunc.ScaleY(3f), IGT_UIcommonFunc.ScaleX(33f), IGT_UIcommonFunc.ScaleX(33f)), pIgt_Textures.GetTexture(IGT_Constants._CloseRect), 31, 0, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_NoLives_Close.setListener(this);
		rect_NoMoreLivs_Heart = new Rect(rect_NoMoreLivesBg.x + rect_NoMoreLivesBg.width / 2f - IGT_UIcommonFunc.ScaleX(50f) / 2f, rect_NoMoreLivesBg.y + IGT_UIcommonFunc.ScaleY(45f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(47f));
		But_NoLives_AskFriends = new IGT_Button(new Rect(rect_NoMoreLivesBg.x + IGT_UIcommonFunc.ScaleX(25f), rect_NoMoreLivesBg.y + rect_NoMoreLivesBg.height - IGT_UIcommonFunc.ScaleY(43f) / 2f - IGT_UIcommonFunc.ScaleY(6f), IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(43f)), pIgt_Textures.GetTexture(IGT_Constants._NoMoreLives_AskFriends), 32, 0, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_NoLives_AskFriends.setListener(this);
		But_NoLives_GetFree = new IGT_Button(new Rect(rect_NoMoreLivesBg.x + rect_NoMoreLivesBg.width - But_NoLives_AskFriends.getWidth() - IGT_UIcommonFunc.ScaleX(25f), But_NoLives_AskFriends.getY(), But_NoLives_AskFriends.getWidth(), But_NoLives_AskFriends.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._NoMoreLives_GetFree), 33, 0, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_NoLives_GetFree.setListener(this);
		But_NoLives_Purchase2 = new IGT_Button(new Rect(rect_NoMoreLivesBg.x + rect_NoMoreLivesBg.width / 2f - IGT_UIcommonFunc.ScaleX(58f) / 2f, rect_NoMoreLivesBg.y + rect_NoMoreLivesBg.height / 2f + IGT_UIcommonFunc.ScaleY(25f), IGT_UIcommonFunc.ScaleX(58f), IGT_UIcommonFunc.ScaleY(48f)), pIgt_Textures.GetTexture(IGT_Constants._NoMoreLives_PriceTag), 35, 0, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_NoLives_Purchase2.setListener(this);
		But_NoLives_Purchase1 = new IGT_Button(new Rect(But_NoLives_Purchase2.getX() - But_NoLives_Purchase2.getWidth() - IGT_UIcommonFunc.ScaleX(10f), But_NoLives_Purchase2.getY(), But_NoLives_Purchase2.getWidth(), But_NoLives_Purchase2.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._NoMoreLives_PriceTag), 34, 0, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_NoLives_Purchase1.setListener(this);
		But_NoLives_Purchase3 = new IGT_Button(new Rect(But_NoLives_Purchase2.getX() + But_NoLives_Purchase2.getWidth() + IGT_UIcommonFunc.ScaleX(10f), But_NoLives_Purchase2.getY(), But_NoLives_Purchase2.getWidth(), But_NoLives_Purchase2.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._NoMoreLives_PriceTag), 36, 0, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_NoLives_Purchase3.setListener(this);
		bNoMoreLiveAlert = false;
		rect_NotEnoughKeysBG = new Rect(IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(165f), IGT_UIcommonFunc.ScaleX(260f), IGT_UIcommonFunc.ScaleY(140f));
		But_NotEnoughKeys_Close = new IGT_Button(new Rect(rect_NotEnoughKeysBG.x + rect_NotEnoughKeysBG.width - IGT_UIcommonFunc.ScaleX(35f), rect_NotEnoughKeysBG.y, IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), pIgt_Textures.GetTexture(IGT_Constants._CloseRect), 37, 0, true, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_NotEnoughKeys_Close.setListener(this);
		But_NotEnoughKeys_Purchase2 = new IGT_Button(new Rect(rect_NotEnoughKeysBG.x + rect_NotEnoughKeysBG.width / 2f - IGT_UIcommonFunc.ScaleX(58f) / 2f, rect_NotEnoughKeysBG.y + rect_NotEnoughKeysBG.height / 2f + IGT_UIcommonFunc.ScaleY(1f), IGT_UIcommonFunc.ScaleX(64f), IGT_UIcommonFunc.ScaleY(46f)), pIgt_Textures.GetTexture(IGT_Constants._NotEnoughKeys_priceTag), 39, 0, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 3f);
		But_NotEnoughKeys_Purchase2.setListener(this);
		But_NotEnoughKeys_Purchase1 = new IGT_Button(new Rect(But_NotEnoughKeys_Purchase2.getX() - But_NotEnoughKeys_Purchase2.getWidth() - IGT_UIcommonFunc.ScaleX(15f), But_NotEnoughKeys_Purchase2.getY(), But_NotEnoughKeys_Purchase2.getWidth(), But_NotEnoughKeys_Purchase2.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._NotEnoughKeys_priceTag), 38, 0, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_NotEnoughKeys_Purchase1.setListener(this);
		But_NotEnoughKeys_Purchase3 = new IGT_Button(new Rect(But_NotEnoughKeys_Purchase2.getX() + But_NotEnoughKeys_Purchase2.getWidth() + IGT_UIcommonFunc.ScaleX(15f), But_NotEnoughKeys_Purchase2.getY(), But_NotEnoughKeys_Purchase2.getWidth(), But_NotEnoughKeys_Purchase2.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._NotEnoughKeys_priceTag), 40, 0, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_NotEnoughKeys_Purchase3.setListener(this);
		pScroller_GameoverScroll = new IGT_Scroller(0.25f * (float)Screen.height, new Vector2(35f, 35f), 1);
		pScroller_GameoverScroll.setListener(this);
		rect_GameoverBg = new Rect(IGT_UIcommonFunc.ScaleX(0f), IGT_UIcommonFunc.ScaleY(0f), IGT_UIcommonFunc.ScaleX(320f), IGT_UIcommonFunc.ScaleY(480f));
		rect_GameoverScrollTitleBar = new Rect(IGT_UIcommonFunc.ScaleX(0f), IGT_UIcommonFunc.ScaleY(0f), IGT_UIcommonFunc.ScaleX(320f), IGT_UIcommonFunc.ScaleY(47f));
		ScrollViewRect_GameoverScreen = new Rect(rect_GameoverScrollTitleBar.x, rect_GameoverScrollTitleBar.y + rect_GameoverScrollTitleBar.height * 0.75f, rect_GameoverScrollTitleBar.width, IGT_UIcommonFunc.ScaleY(166f));
		ScrollViewRectImg_GameoverScreen = new Rect(ScrollViewRect_GameoverScreen.x, ScrollViewRect_GameoverScreen.y - IGT_UIcommonFunc.ScaleY(2f), ScrollViewRect_GameoverScreen.width, ScrollViewRect_GameoverScreen.height + IGT_UIcommonFunc.ScaleY(10f));
		Gameover_FBitems_StrtY = ScrollViewRect_GameoverScreen.y + IGT_UIcommonFunc.ScaleY(6f);
		GameoverScroll_BarWid = IGT_UIcommonFunc.ScaleX(281f);
		GameoverScroll_BarHeight = IGT_UIcommonFunc.ScaleY(38f);
		GameoverScroll_BarGap = IGT_UIcommonFunc.ScaleY(0f);
		GameoverScroll_BarGap_Busted = IGT_UIcommonFunc.ScaleY(2f);
		GameoverScroll_BarStrtPosX = IGT_UIcommonFunc.ScaleX(19.5f);
		GameoverScroll_CurPos = new Vector3(0f, 5f, 0f);
		GameoverScroll_BarStrtPosY = IGT_UIcommonFunc.ScaleY(GameoverScroll_CurPos.y);
		But_FbScroll = new IGT_Button(41, 0f * (rect_GameoverScrollTitleBar.width / 3f), rect_GameoverScrollTitleBar.y, rect_GameoverScrollTitleBar.width / 3f, rect_GameoverScrollTitleBar.height * 0.75f);
		But_FbScroll.setListener(this);
		But_TopchaseScroll = new IGT_Button(42, 1f * (rect_GameoverScrollTitleBar.width / 3f), rect_GameoverScrollTitleBar.y, rect_GameoverScrollTitleBar.width / 3f, rect_GameoverScrollTitleBar.height * 0.75f);
		But_TopchaseScroll.setListener(this);
		But_BustedScroll = new IGT_Button(43, 2f * (rect_GameoverScrollTitleBar.width / 3f), rect_GameoverScrollTitleBar.y, rect_GameoverScrollTitleBar.width / 3f, rect_GameoverScrollTitleBar.height * 0.75f);
		But_BustedScroll.setListener(this);
		nBustedScrollCount = 10;
		nGameoverScrollType = 0;
		GameoverScroll_DatasGapFrmBar = IGT_UIcommonFunc.ScaleY(10f);
		rect_GameoverScroll_IdxBg = new Rect(GameoverScroll_BarStrtPosX + IGT_UIcommonFunc.ScaleX(8f), IGT_UIcommonFunc.ScaleY(-8f), IGT_UIcommonFunc.ScaleX(28f), IGT_UIcommonFunc.ScaleY(28f));
		rect_GameoverScroll_Idx = new Rect(GameoverScroll_BarStrtPosX + IGT_UIcommonFunc.ScaleX(15f), IGT_UIcommonFunc.ScaleY(1f), IGT_UIcommonFunc.ScaleX(15f), IGT_UIcommonFunc.ScaleY(15f));
		rect_GameoverScroll_Dot = new Rect(GameoverScroll_BarStrtPosX + GameoverScroll_BarWid / 2f - IGT_UIcommonFunc.ScaleX(4f), IGT_UIcommonFunc.ScaleY(-3f), IGT_UIcommonFunc.ScaleX(8f), IGT_UIcommonFunc.ScaleY(16f));
		rect_GameoverScroll_pic = new Rect(GameoverScroll_BarStrtPosX + IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(-2f), IGT_UIcommonFunc.ScaleY(20f), IGT_UIcommonFunc.ScaleY(20f));
		rect_GameoverScroll_Name = new Rect(GameoverScroll_BarStrtPosX + IGT_UIcommonFunc.ScaleX(70f), IGT_UIcommonFunc.ScaleY(-5f), IGT_UIcommonFunc.ScaleX(100f), IGT_UIcommonFunc.ScaleY(30f));
		rect_GameoverScroll_Score = new Rect(GameoverScroll_BarStrtPosX + IGT_UIcommonFunc.ScaleX(180f), rect_GameoverScroll_Name.y, IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(30f));
		fontSize_GameoverScrollName = (int)IGT_UIcommonFunc.ScaleX(16f);
		fontSize_GameoverScrollScore = (int)IGT_UIcommonFunc.ScaleX(14f);
		But_GameoverscreenHome = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(5f), IGT_UIcommonFunc.ScaleY(430f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(50f)), pIgt_Textures.GetTexture(IGT_Constants._GameOver_Home), 45, 0, true, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_GameoverscreenHome.setListener(this);
		But_GameoverscreenRestart = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(265f), But_GameoverscreenHome.getY(), But_GameoverscreenHome.getWidth(), But_GameoverscreenHome.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._Retry), 44, 0, true, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_GameoverscreenRestart.setListener(this);
		rect_Gameover_Coins = new Rect(IGT_UIcommonFunc.ScaleX(230f), IGT_UIcommonFunc.ScaleY(345f), IGT_UIcommonFunc.ScaleX(82f), IGT_UIcommonFunc.ScaleY(82f));
		rect_Gameover_Key = new Rect(IGT_UIcommonFunc.ScaleX(260f), IGT_UIcommonFunc.ScaleY(285f), IGT_UIcommonFunc.ScaleX(66f), IGT_UIcommonFunc.ScaleY(66f));
		rect_Gameover_Life = new Rect(IGT_UIcommonFunc.ScaleX(230f), IGT_UIcommonFunc.ScaleY(235f), IGT_UIcommonFunc.ScaleX(52f), IGT_UIcommonFunc.ScaleY(52f));
		select_CurBustedListDatas();
		Border_White = new Texture2D(1, 1);
		Border_White.SetPixel(0, 0, Color.white);
		Border_White.Apply();
		Border_custom = new Texture2D(1, 1);
		Border_custom.SetPixel(0, 0, new Color(0.152f, 0.152f, 0.149f, 0.196f));
		Border_custom.Apply();
		Border_Black = new Texture2D(1, 1);
		Border_Black.SetPixel(0, 0, Color.black);
		Border_Black.Apply();
		Drawrect_clr1 = new Texture2D(1, 1);
		Drawrect_clr1.SetPixel(0, 0, new Color(0.16078432f, 0.11764706f, 1f / 85f, 0.5f));
		Drawrect_clr1.Apply();
		Drawrect_clr2 = new Texture2D(1, 1);
		Drawrect_clr2.SetPixel(0, 0, new Color(2f / 85f, 0.19215687f, 13f / 51f, 0.5f));
		Drawrect_clr2.Apply();
		Nickname_clr = new Texture2D(1, 1);
		Nickname_clr.SetPixel(0, 0, new Color(6f / 85f, 0.28627452f, 53f / 85f));
		Nickname_clr.Apply();
		rect_Black = new Texture2D(1, 1);
		rect_Black.SetPixel(0, 0, new Color(23f / 85f, 23f / 85f, 23f / 85f));
		rect_Black.Apply();
		isPurchaseButBtnDown = false;
		bScrollAnim = false;
		fScrollAnimTotTime = 1f;
		nPurchaseType = 0;
		rect_puchaseBG = new Rect(IGT_UIcommonFunc.ScaleX(-10f), IGT_UIcommonFunc.ScaleY(-30f), IGT_UIcommonFunc.ScaleX(350f), IGT_UIcommonFunc.ScaleY(530f));
		But_BackpurchaseWindow = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(5f), IGT_UIcommonFunc.ScaleY(440f), IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleY(40f)), pIgt_Textures.GetTexture(IGT_Constants._Shop_Back), 46, 0, true, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_BackpurchaseWindow.setListener(this);
		pScroller_PuchaseWindow = new IGT_Scroller(0.25f * (float)Screen.height, new Vector2(35f, 35f), 1);
		pScroller_PuchaseWindow.setListener(this);
		rect_purchaseTitlebar = new Rect(IGT_UIcommonFunc.ScaleX(0f), IGT_UIcommonFunc.ScaleY(50f), IGT_UIcommonFunc.ScaleX(320f), IGT_UIcommonFunc.ScaleY(32f));
		But_Store = new IGT_Button(47, 0f * (rect_purchaseTitlebar.width / 4f), rect_purchaseTitlebar.y, rect_purchaseTitlebar.width / 4f, rect_purchaseTitlebar.height);
		But_Store.setListener(this);
		But_Combo = new IGT_Button(48, 1f * (rect_purchaseTitlebar.width / 4f), rect_purchaseTitlebar.y, rect_purchaseTitlebar.width / 4f, rect_purchaseTitlebar.height);
		But_Combo.setListener(this);
		But_Boost = new IGT_Button(49, 2f * (rect_purchaseTitlebar.width / 4f), rect_purchaseTitlebar.y, rect_purchaseTitlebar.width / 4f, rect_purchaseTitlebar.height);
		But_Boost.setListener(this);
		But_Free = new IGT_Button(50, 3f * (rect_purchaseTitlebar.width / 4f), rect_purchaseTitlebar.y, rect_purchaseTitlebar.width / 4f, rect_purchaseTitlebar.height);
		But_Free.setListener(this);
		ScrollViewRectImg_purchaseWindow = new Rect(rect_purchaseTitlebar.x, rect_purchaseTitlebar.y - IGT_UIcommonFunc.ScaleY(5f), rect_purchaseTitlebar.width, IGT_UIcommonFunc.ScaleY(342f));
		ScrollViewRect_purchaseWindow = new Rect(ScrollViewRectImg_purchaseWindow.x, ScrollViewRectImg_purchaseWindow.y + IGT_UIcommonFunc.ScaleY(42f), ScrollViewRectImg_purchaseWindow.width, IGT_UIcommonFunc.ScaleY(293f));
		purchaseWindow_BarWid = IGT_UIcommonFunc.ScaleX(300f);
		purchaseWindow_BarHeight = IGT_UIcommonFunc.ScaleY(53f);
		purchaseWindow_BarGap = IGT_UIcommonFunc.ScaleY(4f);
		purchaseWindow_BarStrtPosX = IGT_UIcommonFunc.ScaleX(10f);
		purchaseWindow_CurPos = new Vector3(0f, 8f, 0f);
		purchaseWindow_BarStrtPosY = IGT_UIcommonFunc.ScaleY(purchaseWindow_CurPos.y);
		rect_purchseProductImg = new Rect(IGT_UIcommonFunc.ScaleX(0f), IGT_UIcommonFunc.ScaleY(0f), IGT_UIcommonFunc.ScaleX(64f), IGT_UIcommonFunc.ScaleY(64f));
		PurchaseScroll_ProductImgGapFrmBar = IGT_UIcommonFunc.ScaleY(-8f);
		rect_purchaseProductName = new Rect(IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleX(150f), IGT_UIcommonFunc.ScaleY(30f));
		PurchaseScroll_ProductNameGapFrmBar = IGT_UIcommonFunc.ScaleY(5f);
		rect_purchaseProductDescp = new Rect(IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleX(150f), IGT_UIcommonFunc.ScaleY(30f));
		PurchaseScroll_ProductDescpGapFrmBar = IGT_UIcommonFunc.ScaleY(25f);
		rect_purchaseBuy = new Rect(IGT_UIcommonFunc.ScaleX(238f), IGT_UIcommonFunc.ScaleY(15f), IGT_UIcommonFunc.ScaleX(64f), IGT_UIcommonFunc.ScaleY(25f));
		fontSize_purProdName = (int)IGT_UIcommonFunc.ScaleX(18f);
		fontSize_purProdDescp = (int)IGT_UIcommonFunc.ScaleX(15f);
		fontSize_purProdPrice = (int)IGT_UIcommonFunc.ScaleX(16f);
		rect_Upgrade = new Rect(IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(35f), IGT_UIcommonFunc.ScaleX(26f), IGT_UIcommonFunc.ScaleY(14f));
		fUpgradeGapX = rect_Upgrade.width + IGT_UIcommonFunc.ScaleX(1f);
		rect_KeycountPurchasewindow = new Rect(IGT_UIcommonFunc.ScaleX(150f), IGT_UIcommonFunc.ScaleY(12f), IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleY(20f));
		rect_LifecountPurchasewindow = new Rect(rect_KeycountPurchasewindow.x - IGT_UIcommonFunc.ScaleX(110f), rect_KeycountPurchasewindow.y, rect_KeycountPurchasewindow.width, rect_KeycountPurchasewindow.height);
		rect_CoincountPurchasewindow = new Rect(rect_KeycountPurchasewindow.x + IGT_UIcommonFunc.ScaleX(110f), rect_KeycountPurchasewindow.y, rect_KeycountPurchasewindow.width, rect_KeycountPurchasewindow.height);
		bExitAlert = false;
		rect_ExitBg = new Rect(IGT_UIcommonFunc.ScaleX(-10f), IGT_UIcommonFunc.ScaleY(240f), IGT_UIcommonFunc.ScaleX(350f), IGT_UIcommonFunc.ScaleY(100f));
		But_Exit_Ok = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(245f) - IGT_UIcommonFunc.ScaleX(60f), 0f, IGT_UIcommonFunc.ScaleX(60f), IGT_UIcommonFunc.ScaleY(30f)), pIgt_Textures.GetTexture(IGT_Constants._Abort_Ok), 51, 0, false, 0f, Vector2.zero, 0, 2f, 0, 5f, 2f);
		But_Exit_Ok.setListener(this);
		But_Exit_Cancel = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(75f), But_Exit_Ok.getY(), But_Exit_Ok.getWidth(), But_Exit_Ok.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._Abort_Cancel), 52, 0, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_Exit_Cancel.setListener(this);
		But_Gamescreen_Pause = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(270f), IGT_UIcommonFunc.ScaleY(430f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(50f)), pIgt_Textures.GetTexture(IGT_Constants._Game_PauseBtn), 53, 0, true, 0f, Vector2.zero, 0, 0f, 0, 0f, 0f);
		But_Gamescreen_Pause.setListener(this);
		rect_Game_ChaseHeader = new Rect(IGT_UIcommonFunc.ScaleX(0f), IGT_UIcommonFunc.ScaleY(0f), IGT_UIcommonFunc.ScaleX(320f), IGT_UIcommonFunc.ScaleY(42f));
		nHealth_hero = 1f;
		rect_HeroHealthBar = new Rect(IGT_UIcommonFunc.ScaleX(0f), rect_Game_ChaseHeader.y + IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleX(112f), IGT_UIcommonFunc.ScaleY(13f));
		pHero_Healthprograss = new IGT_PrograssBar(pIgt_Textures.GetTexture(IGT_Constants._Game_LifeBar_Red), rect_HeroHealthBar, pIgt_Textures.GetTexture(IGT_Constants._Game_LifeBar_Green), rect_HeroHealthBar, true, 1f, 1f, new Rect(0f, 0f, 1f, 1f));
		nHelath_Enemy = 1f;
		rect_EnemyHealthBar = new Rect(IGT_UIcommonFunc.ScaleX(320f) - rect_HeroHealthBar.width, rect_HeroHealthBar.y, rect_HeroHealthBar.width, rect_HeroHealthBar.height);
		pEnemy_Healthprograss = new IGT_PrograssBar(pIgt_Textures.GetTexture(IGT_Constants._Game_LifeBar_Red), rect_EnemyHealthBar, pIgt_Textures.GetTexture(IGT_Constants._Game_LifeBar_Green), rect_EnemyHealthBar, false, 1f, 1f, new Rect(0f, 0f, -1f, 1f));
		rect_Game_ScroeText = new Rect(IGT_UIcommonFunc.ScaleX(110f), rect_Game_ChaseHeader.y + IGT_UIcommonFunc.ScaleY(2f), IGT_UIcommonFunc.ScaleX(100f), IGT_UIcommonFunc.ScaleY(20f));
		rect_Game_CoinImg = new Rect(IGT_UIcommonFunc.ScaleX(0f), rect_Game_ChaseHeader.y + rect_Game_ChaseHeader.height / 2f + IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleX(20f), IGT_UIcommonFunc.ScaleX(20f));
		rect_Game_CoinBg = new Rect(rect_Game_CoinImg.x + rect_Game_CoinImg.width - IGT_UIcommonFunc.ScaleX(2f), rect_Game_CoinImg.y + IGT_UIcommonFunc.ScaleY(5f), IGT_UIcommonFunc.ScaleX(35f), IGT_UIcommonFunc.ScaleY(15f));
		rect_DirMap = new Rect(IGT_UIcommonFunc.ScaleX(260f), rect_Game_CoinImg.y + IGT_UIcommonFunc.ScaleY(5f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(50f));
		rect_DirMapHero = new Rect(rect_DirMap.x + rect_DirMap.width / 2f - IGT_UIcommonFunc.ScaleY(5f), rect_DirMap.y + rect_DirMap.height / 2f - IGT_UIcommonFunc.ScaleY(5f), IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleY(10f));
		rect_DirMapEnemy = rect_DirMapHero;
		rect_DirMapDist = new Rect(rect_DirMapHero.x, rect_DirMapHero.y + rect_DirMapHero.height + IGT_UIcommonFunc.ScaleY(2f), rect_DirMapHero.width, rect_DirMapHero.height);
		fDirMapDist = 12f;
		rect_CountDownBG = new Rect(IGT_UIcommonFunc.ScaleX(0f), IGT_UIcommonFunc.ScaleY(0f), IGT_UIcommonFunc.ScaleX(320f), IGT_UIcommonFunc.ScaleY(480f));
		nCountDownNum = 3.0;
		fontSize_MissionTargetCount = (int)IGT_UIcommonFunc.ScaleX(21f);
		rect_MultipleCollectionItemImg = new Rect[6];
		rect_MultipleCollectionItemImg[0] = new Rect(IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(-2f), IGT_UIcommonFunc.ScaleX(60f), IGT_UIcommonFunc.ScaleY(52f));
		rect_MultipleCollectionItemImg[1] = new Rect(IGT_UIcommonFunc.ScaleX(15f), rect_MultipleCollectionItemImg[0].y, rect_MultipleCollectionItemImg[0].width, rect_MultipleCollectionItemImg[0].height);
		rect_MultipleCollectionItemImg[2] = new Rect(IGT_UIcommonFunc.ScaleX(185f), rect_MultipleCollectionItemImg[0].y, rect_MultipleCollectionItemImg[0].width, rect_MultipleCollectionItemImg[0].height);
		rect_MultipleCollectionItemImg[3] = new Rect(IGT_UIcommonFunc.ScaleX(0f), rect_MultipleCollectionItemImg[0].y, IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(42f));
		rect_MultipleCollectionItemImg[4] = new Rect(IGT_UIcommonFunc.ScaleX(163f) - rect_MultipleCollectionItemImg[3].width - rect_MultipleCollectionItemImg[3].x, rect_MultipleCollectionItemImg[0].y, rect_MultipleCollectionItemImg[3].width, rect_MultipleCollectionItemImg[3].height);
		rect_MultipleCollectionItemImg[5] = new Rect(IGT_UIcommonFunc.ScaleX(275f) - rect_MultipleCollectionItemImg[3].width - rect_MultipleCollectionItemImg[3].x, rect_MultipleCollectionItemImg[0].y, rect_MultipleCollectionItemImg[3].width, rect_MultipleCollectionItemImg[3].height);
		rect_MultipleCollectionItemCount = new Rect[6];
		rect_MultipleCollectionItemCount[0] = new Rect(IGT_UIcommonFunc.ScaleX(115f), IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleX(90f), IGT_UIcommonFunc.ScaleY(30f));
		rect_MultipleCollectionItemCount[1] = new Rect(rect_MultipleCollectionItemImg[1].x + rect_MultipleCollectionItemImg[1].width / 2f + IGT_UIcommonFunc.ScaleX(0f), rect_MultipleCollectionItemCount[0].y, rect_MultipleCollectionItemCount[0].width, rect_MultipleCollectionItemCount[0].height);
		rect_MultipleCollectionItemCount[2] = new Rect(rect_MultipleCollectionItemImg[2].x + rect_MultipleCollectionItemImg[2].width / 2f + IGT_UIcommonFunc.ScaleX(0f), rect_MultipleCollectionItemCount[0].y, rect_MultipleCollectionItemCount[0].width, rect_MultipleCollectionItemCount[0].height);
		rect_MultipleCollectionItemCount[3] = new Rect(rect_MultipleCollectionItemImg[3].x + rect_MultipleCollectionItemImg[3].width / 2f, rect_MultipleCollectionItemCount[0].y, IGT_UIcommonFunc.ScaleX(70f), IGT_UIcommonFunc.ScaleY(25f));
		rect_MultipleCollectionItemCount[4] = new Rect(rect_MultipleCollectionItemImg[4].x + rect_MultipleCollectionItemImg[4].width / 2f, rect_MultipleCollectionItemCount[0].y, rect_MultipleCollectionItemCount[3].width, rect_MultipleCollectionItemCount[3].height);
		rect_MultipleCollectionItemCount[5] = new Rect(rect_MultipleCollectionItemImg[5].x + rect_MultipleCollectionItemImg[5].width / 2f, rect_MultipleCollectionItemCount[0].y, rect_MultipleCollectionItemCount[3].width, rect_MultipleCollectionItemCount[3].height);
		rect_TickMark = new Rect(IGT_UIcommonFunc.ScaleX(0f), IGT_UIcommonFunc.ScaleY(0f), IGT_UIcommonFunc.ScaleX(32f), IGT_UIcommonFunc.ScaleY(32f));
		rect_Fps = new Rect(IGT_UIcommonFunc.ScaleX(1f), IGT_UIcommonFunc.ScaleY(440f), IGT_UIcommonFunc.ScaleX(100f), IGT_UIcommonFunc.ScaleY(40f));
		pFps = "60";
		fontSize_Fps = (int)IGT_UIcommonFunc.ScaleX(16f);
		pSpdParams = "null";
		But_MissonCompleted_Retry = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(10f), IGT_UIcommonFunc.ScaleY(430f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(50f)), pIgt_Textures.GetTexture(IGT_Constants._Retry), 55, 0, true, 0f, Vector2.zero, 4, 0.75f, 1, 1f, 5f);
		But_MissonCompleted_Retry.setListener(this);
		But_MissonCompleted_Retry.setAnimProperties(0f - But_MissonCompleted_Retry.getWidth(), But_MissonCompleted_Retry.getX(), 0f);
		But_MissonCompleted_Next = new IGT_Button(new Rect((float)Screen.width - But_MissonCompleted_Retry.getWidth() - But_MissonCompleted_Retry.getX(), But_MissonCompleted_Retry.getY(), But_MissonCompleted_Retry.getWidth(), But_MissonCompleted_Retry.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._Next), 54, 0, true, 0f, Vector2.zero, 5, 0.75f, 1, 1f, 5f);
		But_MissonCompleted_Next.setListener(this);
		But_MissonCompleted_Next.setAnimProperties((float)Screen.width + But_MissonCompleted_Next.getWidth(), But_MissonCompleted_Next.getX(), 0f);
		But_MissonCompleted_Home = new IGT_Button(new Rect(But_MissonCompleted_Retry.getX(), But_MissonCompleted_Retry.getY() - But_MissonCompleted_Retry.getHeight(), But_MissonCompleted_Retry.getWidth(), But_MissonCompleted_Retry.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._GameOver_Home), 56, 0, true, 0f, Vector2.zero, 4, 0.75f, 1, 1f, 5f);
		But_MissonCompleted_Home.setListener(this);
		But_MissonCompleted_Home.setAnimProperties(0f - But_MissonCompleted_Home.getWidth(), But_MissonCompleted_Home.getX(), 0f);
		But_ChsUnlockAlert_Play = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(310f) / 2f - IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(240f), IGT_UIcommonFunc.ScaleX(70f), IGT_UIcommonFunc.ScaleY(20f)), pIgt_Textures.GetTexture(IGT_Constants._BtnEnable_MC_LB), 56, 0, false, 0f, Vector2.zero, 0, 0f, 0, 0f, 0f);
		But_ChsUnlockAlert_Play.setListener(this);
		But_ChsUnlockAlert_Close = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(276f), IGT_UIcommonFunc.ScaleY(191f), IGT_UIcommonFunc.ScaleX(25f), IGT_UIcommonFunc.ScaleY(25f)), pIgt_Textures.GetTexture(IGT_Constants._CloseRect), 60, 0, true, 0f, Vector2.zero, 0, 0f, 0, 0f, 0f);
		But_ChsUnlockAlert_Close.setListener(this);
		rect_starPos = new Rect[3];
		rect_starPos[1] = new Rect(IGT_UIcommonFunc.ScaleX(160f) - IGT_UIcommonFunc.ScaleX(20f), IGT_UIcommonFunc.ScaleY(204f), IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleY(40f));
		rect_starPos[0] = new Rect(rect_starPos[1].x - rect_starPos[1].width * 0.8f - IGT_UIcommonFunc.ScaleX(5f), rect_starPos[1].y + IGT_UIcommonFunc.ScaleY(15f), rect_starPos[1].width * 0.8f, rect_starPos[1].height * 0.8f);
		rect_starPos[2] = new Rect(rect_starPos[1].x + rect_starPos[1].width + IGT_UIcommonFunc.ScaleX(5f), rect_starPos[0].y, rect_starPos[1].width * 0.8f, rect_starPos[1].height * 0.8f);
		nMC_ScrollType = 0;
		But_MC_FB_Friends = new IGT_Button(57, 0f * (rect_GameoverScrollTitleBar.width / 2f), rect_GameoverScrollTitleBar.y, rect_GameoverScrollTitleBar.width / 2f - IGT_UIcommonFunc.ScaleX(8f), rect_GameoverScrollTitleBar.height * 0.7f);
		But_MC_FB_Friends.setListener(this);
		But_MC_FB_Global = new IGT_Button(58, 1f * (rect_GameoverScrollTitleBar.width / 2f) + IGT_UIcommonFunc.ScaleX(8f), rect_GameoverScrollTitleBar.y, rect_GameoverScrollTitleBar.width / 2f, rect_GameoverScrollTitleBar.height * 0.7f);
		But_MC_FB_Global.setListener(this);
		But_Mapback = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(0f), IGT_UIcommonFunc.ScaleY(430f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(50f)), pIgt_Textures.GetTexture(IGT_Constants._GameOver_Home), 62, 0, true, 0f, Vector2.zero, 0, 0.75f, 1, 1f, 5f);
		But_Mapback.setListener(this);
		rect_Menu_Bg = new Rect(IGT_UIcommonFunc.ScaleX(0f), IGT_UIcommonFunc.ScaleY(0f), IGT_UIcommonFunc.ScaleX(320f), IGT_UIcommonFunc.ScaleY(480f));
		But_Menu_back = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(2f), IGT_UIcommonFunc.ScaleY(440f), IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleY(40f)), pIgt_Textures.GetTexture(IGT_Constants._GameOver_Home), 65, 0, true, 0f, Vector2.zero, 0, 0.75f, 1, 1f, 5f);
		But_Menu_back.setListener(this);
		But_Menu_Shop = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(43f), IGT_UIcommonFunc.ScaleY(190f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(50f)), pIgt_Textures.GetTexture(IGT_Constants._Shop_HS), 66, 0, true, 0f, Vector2.zero, 0, 0.75f, 0, 0f, 0f);
		But_Menu_Shop.setListener(this);
		But_Menu_LeaderBoard = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(135f), But_Menu_Shop.getY(), But_Menu_Shop.getWidth(), But_Menu_Shop.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._leaderBoard), 67, 0, true, 0f, Vector2.zero, 0, 0.75f, 0, 0f, 0f);
		But_Menu_LeaderBoard.setListener(this);
		But_Menu_Achievement = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(226f), But_Menu_Shop.getY(), But_Menu_Shop.getWidth(), But_Menu_Shop.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._Achievement), 11, 0, true, 0f, Vector2.zero, 0, 0.75f, 0, 0f, 0f);
		But_Menu_Achievement.setListener(this);
		But_Menu_Free = new IGT_Button(new Rect(But_Menu_Shop.getX(), IGT_UIcommonFunc.ScaleY(277f), But_Menu_Shop.getWidth(), But_Menu_Shop.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._WatchVideo), 69, 0, true, 0f, Vector2.zero, 0, 0.75f, 0, 0f, 0f);
		But_Menu_Free.setListener(this);
		But_Menu_Share = new IGT_Button(new Rect(But_Menu_LeaderBoard.getX(), But_Menu_Free.getY(), But_Menu_Shop.getWidth(), But_Menu_Shop.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._AllShare), 108, 0, true, 0f, Vector2.zero, 0, 0.75f, 0, 0f, 0f);
		But_Menu_Share.setListener(this);
		But_Menu_Settings = new IGT_Button(new Rect(But_Menu_Achievement.getX(), But_Menu_Free.getY(), But_Menu_Shop.getWidth(), But_Menu_Shop.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._Settings_tilt), 5, 0, true, 0f, Vector2.zero, 0, 0.75f, 0, 0f, 0f);
		But_Menu_Settings.setListener(this);
		But_Menu_MoreGames = new IGT_Button(new Rect(But_Menu_Shop.getX() + IGT_UIcommonFunc.ScaleX(1f), IGT_UIcommonFunc.ScaleY(366f), But_Menu_Shop.getWidth(), But_Menu_Shop.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._MoreGames), 12, 0, true, 0f, Vector2.zero, 0, 0.75f, 0, 0f, 0f);
		But_Menu_MoreGames.setListener(this);
		But_Menu_About = new IGT_Button(new Rect(But_Menu_LeaderBoard.getX(), But_Menu_MoreGames.getY(), But_Menu_Shop.getWidth(), But_Menu_Shop.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._About), 73, 0, true, 0f, Vector2.zero, 0, 0.75f, 0, 0f, 0f);
		But_Menu_About.setListener(this);
		But_Menu_life = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(24f), IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(65f), IGT_UIcommonFunc.ScaleY(25f)), pIgt_Textures.GetTexture(IGT_Constants._lkc_btn), 76, 0, false, 0f, Vector2.zero, 0, 0.75f, 0, 0f, 0f);
		But_Menu_life.setListener(this);
		But_Menu_Key = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(125f), IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(60f), IGT_UIcommonFunc.ScaleY(25f)), pIgt_Textures.GetTexture(IGT_Constants._lkc_btn), 74, 0, false, 0f, Vector2.zero, 0, 0.75f, 0, 0f, 0f);
		But_Menu_Key.setListener(this);
		But_Menu_Coin = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(225f), IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(25f)), pIgt_Textures.GetTexture(IGT_Constants._lkc_btn), 75, 0, false, 0f, Vector2.zero, 0, 0.75f, 0, 0f, 0f);
		But_Menu_Coin.setListener(this);
		pAnim_menu_LeaderBoard = new IGT_Animator();
		But_Menu_GoogleLB = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(57f), IGT_UIcommonFunc.ScaleY(235f), IGT_UIcommonFunc.ScaleX(60f), IGT_UIcommonFunc.ScaleY(60f)), pIgt_Textures.GetTexture(IGT_Constants._GoogleLB), 3, 0, true, 0f, Vector2.zero, 0, 2f, 0, 1f, 2f);
		But_Menu_GoogleLB.setListener(this);
		But_Menu_FBLB = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(200f), IGT_UIcommonFunc.ScaleY(235f), IGT_UIcommonFunc.ScaleX(60f), IGT_UIcommonFunc.ScaleY(60f)), pIgt_Textures.GetTexture(IGT_Constants._FacebookLB), 4, 0, true, 0f, Vector2.zero, 0, 1.5f, 0, 1f, 2f);
		But_Menu_FBLB.setListener(this);
		But_FBLB_Alertclose = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(273f), IGT_UIcommonFunc.ScaleY(58.2f), IGT_UIcommonFunc.ScaleX(32f), IGT_UIcommonFunc.ScaleY(32f)), pIgt_Textures.GetTexture(IGT_Constants._CloseRect), 93, 0, true, 0f, Vector2.zero, 0, 1.5f, 0, 0f, 0f);
		But_FBLB_Alertclose.setListener(this);
		But_FBLB_AlertChase = new IGT_Button(94, IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(110f), IGT_UIcommonFunc.ScaleX(130f), IGT_UIcommonFunc.ScaleY(35f));
		But_FBLB_AlertChase.setListener(this);
		But_FBLB_AlertMission = new IGT_Button(95, IGT_UIcommonFunc.ScaleX(166f), IGT_UIcommonFunc.ScaleY(110f), IGT_UIcommonFunc.ScaleX(126f), IGT_UIcommonFunc.ScaleY(35f));
		But_FBLB_AlertMission.setListener(this);
		But_FBLB_Friends = new IGT_Button(96, IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(150f), IGT_UIcommonFunc.ScaleX(130f), IGT_UIcommonFunc.ScaleY(50f));
		But_FBLB_Friends.setListener(this);
		But_FBLB_Global = new IGT_Button(97, IGT_UIcommonFunc.ScaleX(161f), IGT_UIcommonFunc.ScaleY(150f), IGT_UIcommonFunc.ScaleX(130f), IGT_UIcommonFunc.ScaleY(30f));
		But_FBLB_Global.setListener(this);
		But_GoogleLB_Alertclose = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(270f), IGT_UIcommonFunc.ScaleY(80f), IGT_UIcommonFunc.ScaleX(20f), IGT_UIcommonFunc.ScaleY(20f)), pIgt_Textures.GetTexture(IGT_Constants._CloseRect), 92, 0, false, 0f, Vector2.zero, 0, 1.5f, 0, 0f, 0f);
		But_GoogleLB_Alertclose.setListener(this);
		menuLB_FBitems_startY = IGT_UIcommonFunc.ScaleY(194f);
		menuLB_BarWidth = IGT_UIcommonFunc.ScaleX(250f);
		menuLB_BarHeight = IGT_UIcommonFunc.ScaleY(35f);
		menuLB_BarGap = IGT_UIcommonFunc.ScaleY(3.5f);
		menuLB_BarStrtPosX = IGT_UIcommonFunc.ScaleX(35f);
		menuLB_DatasGapFrmBar = IGT_UIcommonFunc.ScaleY(9.5f);
		rect_menuLB_Idx = new Rect(menuLB_BarStrtPosX + IGT_UIcommonFunc.ScaleX(12f), IGT_UIcommonFunc.ScaleY(1f), IGT_UIcommonFunc.ScaleX(15f), IGT_UIcommonFunc.ScaleY(15f));
		rect_menuLB_dot = new Rect(menuLB_BarStrtPosX + menuLB_BarWidth / 2f - IGT_UIcommonFunc.ScaleX(6f), IGT_UIcommonFunc.ScaleY(1f), IGT_UIcommonFunc.ScaleX(8f), IGT_UIcommonFunc.ScaleY(16f));
		rect_menuLB_pic = new Rect(menuLB_BarStrtPosX + IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleY(-6f), IGT_UIcommonFunc.ScaleX(33f), IGT_UIcommonFunc.ScaleX(33f));
		rect_menuLB_Name = new Rect(menuLB_BarStrtPosX + IGT_UIcommonFunc.ScaleX(68f), IGT_UIcommonFunc.ScaleY(-5f), IGT_UIcommonFunc.ScaleX(100f), IGT_UIcommonFunc.ScaleY(30f));
		rect_menuLB_Score = new Rect(menuLB_BarStrtPosX + IGT_UIcommonFunc.ScaleX(162f), rect_menuLB_Name.y, IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(30f));
		rect_menuLB_IdxBG = new Rect(menuLB_BarStrtPosX + IGT_UIcommonFunc.ScaleX(0f), IGT_UIcommonFunc.ScaleY(-13f), IGT_UIcommonFunc.ScaleX(35f), IGT_UIcommonFunc.ScaleY(35f));
		rankbg = new Texture2D[3];
		for (int i = 0; i < 3; i++)
		{
			rankbg[i] = Resources.Load<Texture2D>("Images/UI/rankbg" + i);
		}
		But_Menu_left = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(5f), IGT_UIcommonFunc.ScaleY(80f), IGT_UIcommonFunc.ScaleY(30f), IGT_UIcommonFunc.ScaleY(30f)), pIgt_Textures.GetTexture(IGT_Constants._MoveRight), 77, 0, true, 0f, Vector2.zero, 0, 0.75f, 0, 0f, 0f);
		But_Menu_left.changeButtonTexture(pIgt_Textures.Get_MirroredTexture((Texture2D)pIgt_Textures.GetTexture(IGT_Constants._MoveRight)));
		But_Menu_left.setListener(this);
		But_Menu_Right = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(284f), IGT_UIcommonFunc.ScaleY(80f), IGT_UIcommonFunc.ScaleY(30f), IGT_UIcommonFunc.ScaleY(30f)), pIgt_Textures.GetTexture(IGT_Constants._MoveRight), 78, 0, true, 0f, Vector2.zero, 0, 0.75f, 0, 0f, 0f);
		But_Menu_Right.setListener(this);
		But_Menu_Select = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(110f), IGT_UIcommonFunc.ScaleY(145f), IGT_UIcommonFunc.ScaleX(100f), IGT_UIcommonFunc.ScaleY(30f)), pIgt_Textures.GetTexture(IGT_Constants._Button_select), 79, 0, false, menu_btn_rotAng, Vector2.zero, 4, 2f, 0, 0f, 0f);
		But_Menu_Select.setListener(this);
		But_Menu_Ready = new IGT_Button(new Rect(But_Menu_Select.getOriginalDimension().x + IGT_UIcommonFunc.ScaleX(10f), But_Menu_Select.getOriginalDimension().y, But_Menu_Select.getOriginalDimension().width - IGT_UIcommonFunc.ScaleX(20f), But_Menu_Select.getOriginalDimension().height), pIgt_Textures.GetTexture(IGT_Constants._Button_select), 65, 0, false, menu_btn_rotAng, Vector2.zero, 0, 0f, 0, 0f, 0f);
		But_Menu_Ready.setListener(this);
		But_achievementalert_close = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(272f), IGT_UIcommonFunc.ScaleY(200f), IGT_UIcommonFunc.ScaleX(20f), IGT_UIcommonFunc.ScaleY(20f)), pIgt_Textures.GetTexture(IGT_Constants._CloseRect), 63, 0, true, 0f, Vector2.zero, 0, 0.75f, 0, 0f, 0f);
		But_achievementalert_close.setListener(this);
		But_sorryAlert_Quit = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(125f), IGT_UIcommonFunc.ScaleY(290f), IGT_UIcommonFunc.ScaleX(70f), IGT_UIcommonFunc.ScaleY(30f)), pIgt_Textures.GetTexture(IGT_Constants._Mission_TagRound), 64, 0, false, 0f, Vector2.zero, 0, 0.75f, 0, 0f, 0f);
		But_sorryAlert_Quit.setListener(this);
		pIgtDispProp = new List<IGT_DisplayProperties>();
		pIgtDispProp.Clear();
		nArrowAnimType = -1;
		rect_ArrowDim = new Rect(IGT_UIcommonFunc.ScaleX(96f), IGT_UIcommonFunc.ScaleY(176f), IGT_UIcommonFunc.ScaleX(128f), IGT_UIcommonFunc.ScaleY(128f));
		pIGT_Sprites_Tap = new IGT_Sprites(pIgt_Textures.GetTexture(IGT_Constants._HandTap), 4, 1f, 1, 4, new Rect(IGT_UIcommonFunc.ScaleX(200f), IGT_UIcommonFunc.ScaleY(180f), IGT_UIcommonFunc.ScaleX(100f), IGT_UIcommonFunc.ScaleY(100f)));
		rect_TapGlow = new Rect(IGT_UIcommonFunc.ScaleX(170f), IGT_UIcommonFunc.ScaleY(175f), IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(80f));
		bChaseLockedAlert = false;
		bChaseUnlockAlertAnim = false;
		fChaseLockAlert_TotTime = 4f;
		fChaseLockAlpha_StartTime = 0f;
		rect_lockBG = new Rect(IGT_UIcommonFunc.ScaleX(12f), IGT_UIcommonFunc.ScaleY(190f), IGT_UIcommonFunc.ScaleX(300f), IGT_UIcommonFunc.ScaleY(100f));
		bNoInternetAlert = false;
		But_NoInternetAlertOK = new IGT_Button(new Rect(0f, rect_PausescreenBG.y + rect_PausescreenBG.height - IGT_UIcommonFunc.ScaleY(45f), IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(30f)), pIgt_Textures.GetTexture(IGT_Constants._Button_Blue), 80, 0, false, 0f, Vector2.zero, 0, 0f, 0, 0f, 0f);
		But_NoInternetAlertOK.setListener(this);
		bOutOfEnergyTextAlert = false;
		rect_AlertSize = new Rect(IGT_UIcommonFunc.ScaleX(10f), IGT_UIcommonFunc.ScaleY(195f), IGT_UIcommonFunc.ScaleX(300f), IGT_UIcommonFunc.ScaleY(90f));
		sAlertText = " Time's Up ";
		fOutOfEnergyTextAlert_TotTime = 2f;
		bBringBackAlert = false;
		bBringBackAlert_Alpha = false;
		fBringBack_Alert_TotTime = 1.5f;
		rect_BringBackAlert = new Rect(IGT_UIcommonFunc.ScaleX(150f), IGT_UIcommonFunc.ScaleY(285f), IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(30f));
		rect_BB_DirMap = new Rect(IGT_UIcommonFunc.ScaleX(262f), IGT_UIcommonFunc.ScaleY(7f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(50f));
		rect_BB_DirMapHero = new Rect(rect_BB_DirMap.x + rect_BB_DirMap.width / 2f - IGT_UIcommonFunc.ScaleY(5f), rect_BB_DirMap.y + rect_BB_DirMap.height / 2f - IGT_UIcommonFunc.ScaleY(5f), IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleY(10f));
		rect_BB_DirMapEnemy = new Rect(IGT_UIcommonFunc.ScaleX(20f), 0f, rect_BB_DirMapHero.width, rect_BB_DirMapHero.height);
		rect_BB_DirMapDist = new Rect(rect_BB_DirMapHero.x, rect_BB_DirMapHero.y + rect_BB_DirMapHero.height + IGT_UIcommonFunc.ScaleY(2f), rect_BB_DirMapHero.width, rect_BB_DirMapHero.height);
		bUpgradeAlert = false;
		But_Upgrade_Store = new IGT_Button(new Rect(rect_PausescreenBG.x + rect_PausescreenBG.width - IGT_UIcommonFunc.ScaleX(94f), rect_PausescreenBG.y + rect_PausescreenBG.height - IGT_UIcommonFunc.ScaleY(50f), IGT_UIcommonFunc.ScaleX(64f), IGT_UIcommonFunc.ScaleY(32f)), pIgt_Textures.GetTexture(IGT_Constants._Button_Green), 81, 0, false, 0f, Vector2.zero, 0, 0f, 0, 0f, 0f);
		But_Upgrade_Store.setListener(this);
		But_Upgrade_Cancel = new IGT_Button(new Rect(rect_PausescreenBG.x + IGT_UIcommonFunc.ScaleX(30f), rect_PausescreenBG.y + rect_PausescreenBG.height - IGT_UIcommonFunc.ScaleY(50f), IGT_UIcommonFunc.ScaleX(64f), IGT_UIcommonFunc.ScaleY(32f)), pIgt_Textures.GetTexture(IGT_Constants._Button_Red), 82, 0, false, 0f, Vector2.zero, 0, 0f, 0, 0f, 0f);
		But_Upgrade_Cancel.setListener(this);
		rect_feedInvBG = new Rect(IGT_UIcommonFunc.ScaleX(20f), IGT_UIcommonFunc.ScaleY(30f), IGT_UIcommonFunc.ScaleX(280f), IGT_UIcommonFunc.ScaleY(400f));
		taggableFriendsString = new List<string>();
		tex = new Texture2D[6];
		feedElementLoading = new bool[6];
		for (int j = 0; j < 5; j++)
		{
			tex[j] = new Texture2D(1, 1);
			feedElementLoading[j] = false;
		}
		feedElementLoading[5] = true;
		rect_postonFB = new Rect(IGT_UIcommonFunc.ScaleX(20f), IGT_UIcommonFunc.ScaleY(180f), IGT_UIcommonFunc.ScaleX(280f), IGT_UIcommonFunc.ScaleY(120f));
		But_postFB_Yes = new IGT_Button(new Rect(rect_postonFB.x + rect_postonFB.width - IGT_UIcommonFunc.ScaleX(89f), rect_postonFB.y + rect_postonFB.height - IGT_UIcommonFunc.ScaleY(47f), IGT_UIcommonFunc.ScaleX(64f), IGT_UIcommonFunc.ScaleY(32f)), pIgt_Textures.GetTexture(IGT_Constants._Button_Green), 83, 0, false, 0f, Vector2.zero, 0, 0f, 0, 0f, 0f);
		But_postFB_Yes.setListener(this);
		But_postFB_No = new IGT_Button(new Rect(rect_postonFB.x + IGT_UIcommonFunc.ScaleX(25f), rect_postonFB.y + rect_postonFB.height - IGT_UIcommonFunc.ScaleY(47f), IGT_UIcommonFunc.ScaleX(64f), IGT_UIcommonFunc.ScaleY(32f)), pIgt_Textures.GetTexture(IGT_Constants._Button_Red), 84, 0, false, 0f, Vector2.zero, 0, 0f, 0, 0f, 0f);
		But_postFB_No.setListener(this);
		But_feedInvite_Next = new IGT_Button(new Rect(rect_feedInvBG.x + rect_feedInvBG.width - IGT_UIcommonFunc.ScaleX(55f), rect_feedInvBG.y + rect_feedInvBG.height - IGT_UIcommonFunc.ScaleY(42f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(32f)), pIgt_Textures.GetTexture(IGT_Constants._Mission_TagRound), 85, 0, false, 0f, Vector2.zero, 0, 0f, 0, 0f, 0f);
		But_feedInvite_Next.setListener(this);
		But_feedInvite_Prev = new IGT_Button(new Rect(rect_feedInvBG.x + IGT_UIcommonFunc.ScaleX(5f), rect_feedInvBG.y + rect_feedInvBG.height - IGT_UIcommonFunc.ScaleY(42f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(32f)), pIgt_Textures.GetTexture(IGT_Constants._Mission_TagRound), 86, 0, false, 0f, Vector2.zero, 0, 0f, 0, 0f, 0f);
		But_feedInvite_Prev.setListener(this);
		But_feedInvite_Close = new IGT_Button(new Rect(rect_feedInvBG.x + rect_feedInvBG.width - IGT_UIcommonFunc.ScaleX(31f), rect_feedInvBG.y + IGT_UIcommonFunc.ScaleY(5f), IGT_UIcommonFunc.ScaleX(25f), IGT_UIcommonFunc.ScaleY(25f)), pIgt_Textures.GetTexture(IGT_Constants._CloseRect), 88, 0, false, 0f, Vector2.zero, 0, 0f, 0, 0f, 0f);
		But_feedInvite_Close.setListener(this);
		But_feedInvite_Submit = new IGT_Button(new Rect(rect_feedInvBG.x + rect_feedInvBG.width / 2f - IGT_UIcommonFunc.ScaleX(-3f), rect_feedInvBG.y + rect_feedInvBG.height - IGT_UIcommonFunc.ScaleY(43f), IGT_UIcommonFunc.ScaleX(60f), IGT_UIcommonFunc.ScaleY(30f)), pIgt_Textures.GetTexture(IGT_Constants._Button_Blue), 87, 0, false, 0f, Vector2.zero, 0, 0f, 0, 0f, 0f);
		But_feedInvite_Submit.setListener(this);
		But_feedInvite_Checkall = new IGT_Button(new Rect(rect_feedInvBG.x + rect_feedInvBG.width / 2f - IGT_UIcommonFunc.ScaleX(65f), rect_feedInvBG.y + rect_feedInvBG.height - IGT_UIcommonFunc.ScaleY(43f), IGT_UIcommonFunc.ScaleX(60f), IGT_UIcommonFunc.ScaleY(30f)), pIgt_Textures.GetTexture(IGT_Constants._Pause_Bg), 89, 0, false, 0f, Vector2.zero, 0, 0f, 0, 0f, 0f);
		But_feedInvite_Checkall.setListener(this);
		pAnim_postalert = new IGT_Animator();
		pAnim_feedinvite = new IGT_Animator();
		fontSize_missionPopupInfo = (int)IGT_UIcommonFunc.ScaleX(17f);
		rect_MissionPopup = new Rect(IGT_UIcommonFunc.ScaleX(0f), IGT_UIcommonFunc.ScaleY(240f), IGT_UIcommonFunc.ScaleX(320f), IGT_UIcommonFunc.ScaleY(75f));
		But_MissonInfoTapToContinue = new IGT_Button(59, 0f, 0f, IGT_UIcommonFunc.ScaleX(320f), IGT_UIcommonFunc.ScaleY(480f));
		But_MissonInfoTapToContinue.setListener(this);
		bShowMissionTapToContinue = false;
		pIGT_Sprites_MissionInfoTap = new IGT_Sprites(pIgt_Textures.GetTexture(IGT_Constants._HandTap), 4, 1f, 1, 4, new Rect(IGT_UIcommonFunc.ScaleX(200f), IGT_UIcommonFunc.ScaleY(290f), IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(80f)));
		pIGT_Sprites_ChaseNewTap = new IGT_Sprites(pIgt_Textures.GetTexture(IGT_Constants._HandTap), 4, 1f, 1, 4, new Rect(IGT_UIcommonFunc.ScaleX(225f), IGT_UIcommonFunc.ScaleY(335f), IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(80f)));
		rect_AllShareBg = new Rect(IGT_UIcommonFunc.ScaleX(20f), IGT_UIcommonFunc.ScaleY(120f), IGT_UIcommonFunc.ScaleX(280f), IGT_UIcommonFunc.ScaleY(220f));
		btn_fbLog = new IGT_Button(new Rect(rect_AllShareBg.x + IGT_UIcommonFunc.ScaleX(120f), rect_AllShareBg.y + IGT_UIcommonFunc.ScaleY(90f), IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleX(40f)), pIgt_Textures.GetTexture(IGT_Constants._FbIcon), 100, 0, true, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		btn_fbLog.setListener(this);
		btn_fbLog.setSameRatioBasedOnHeight();
		btn_Whatsapp = new IGT_Button(new Rect(rect_AllShareBg.x + IGT_UIcommonFunc.ScaleX(40f), rect_AllShareBg.y + IGT_UIcommonFunc.ScaleY(50f), IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleX(40f)), pIgt_Textures.GetTexture(IGT_Constants._Whatsapp), 109, 0, true, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		btn_Whatsapp.setListener(this);
		btn_Whatsapp.setSameRatioBasedOnHeight();
		btn_Twitter = new IGT_Button(new Rect(rect_AllShareBg.x + IGT_UIcommonFunc.ScaleX(200f), rect_AllShareBg.y + IGT_UIcommonFunc.ScaleY(50f), IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleX(40f)), pIgt_Textures.GetTexture(IGT_Constants._Twitter), 110, 0, true, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		btn_Twitter.setListener(this);
		btn_Twitter.setSameRatioBasedOnHeight();
		btn_MailShare = new IGT_Button(new Rect(rect_AllShareBg.x + IGT_UIcommonFunc.ScaleX(40f), rect_AllShareBg.y + IGT_UIcommonFunc.ScaleY(140f), IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleX(40f)), pIgt_Textures.GetTexture(IGT_Constants._EmailShare), 111, 0, true, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		btn_MailShare.setListener(this);
		btn_MailShare.setSameRatioBasedOnHeight();
		btn_SMSShare = new IGT_Button(new Rect(rect_AllShareBg.x + IGT_UIcommonFunc.ScaleX(200f), rect_AllShareBg.y + IGT_UIcommonFunc.ScaleY(140f), IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleX(40f)), pIgt_Textures.GetTexture(IGT_Constants._Message), 112, 0, true, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		btn_SMSShare.setListener(this);
		btn_SMSShare.setSameRatioBasedOnHeight();
		But_Levelupscreen_Play = new IGT_Button(pIgt_Textures.GetTexture(IGT_Constants.AlphaHalfButton), 61, IGT_UIcommonFunc.ScaleX(45f), IGT_UIcommonFunc.ScaleY(320f), IGT_UIcommonFunc.ScaleX(250f), IGT_UIcommonFunc.ScaleY(100f));
		But_Levelupscreen_Play.setListener(this);
		But_MailBox_FBConnect = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(88f), IGT_UIcommonFunc.ScaleY(225f), IGT_UIcommonFunc.ScaleX(140f), IGT_UIcommonFunc.ScaleY(48f)), pIgt_Textures.GetTexture(IGT_Constants._SettingsBar), 123, 0, true, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_MailBox_FBConnect.setListener(this);
		But_MailBox_FBInvite = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(88f), IGT_UIcommonFunc.ScaleY(240f), IGT_UIcommonFunc.ScaleX(140f), IGT_UIcommonFunc.ScaleY(48f)), pIgt_Textures.GetTexture(IGT_Constants._SettingsBar), 102, 0, true, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_MailBox_FBInvite.setListener(this);
		rect_MailBoxWin = new Rect(IGT_UIcommonFunc.ScaleX(32f), IGT_UIcommonFunc.ScaleY(50f), IGT_UIcommonFunc.ScaleX(256f), IGT_UIcommonFunc.ScaleY(320f));
		But_Mail_Accept = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(45f), IGT_UIcommonFunc.ScaleY(340f), IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(40f)), pIgt_Textures.GetTexture(IGT_Constants._Mission), 115, 0, true, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_Mail_Accept.setListener(this);
		But_Mail_CheckAll = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(195f), IGT_UIcommonFunc.ScaleY(340f), IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(40f)), pIgt_Textures.GetTexture(IGT_Constants._Mission), 116, 0, true, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_Mail_CheckAll.setListener(this);
		rect_MailBoxName = new Rect(IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(58f), IGT_UIcommonFunc.ScaleX(150f), IGT_UIcommonFunc.ScaleY(30f));
		But_AllShare_Close = new IGT_Button(new Rect(rect_AllShareBg.x + rect_AllShareBg.width - IGT_UIcommonFunc.ScaleX(38f), rect_AllShareBg.y + IGT_UIcommonFunc.ScaleY(1.8f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), pIgt_Textures.GetTexture(IGT_Constants._CloseRect), 118, 0, true, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_AllShare_Close.setListener(this);
		But_MailBox_Close = new IGT_Button(new Rect(rect_MailBoxWin.x + rect_MailBoxWin.width - IGT_UIcommonFunc.ScaleX(35f), rect_MailBoxWin.y + IGT_UIcommonFunc.ScaleY(3f), IGT_UIcommonFunc.ScaleX(32f), IGT_UIcommonFunc.ScaleX(32f)), pIgt_Textures.GetTexture(IGT_Constants._CloseRect), 117, 0, true, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_MailBox_Close.setListener(this);
		But_SendLife_Accept = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(45f), IGT_UIcommonFunc.ScaleY(340f), IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(40f)), pIgt_Textures.GetTexture(IGT_Constants._Mission), 119, 0, true, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_SendLife_Accept.setListener(this);
		But_SendLife_CheckAll = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(195f), IGT_UIcommonFunc.ScaleY(340f), IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(40f)), pIgt_Textures.GetTexture(IGT_Constants._Mission), 120, 0, true, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_SendLife_CheckAll.setListener(this);
		But_AskLife_Accept = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(45f), IGT_UIcommonFunc.ScaleY(340f), IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(40f)), pIgt_Textures.GetTexture(IGT_Constants._Mission), 121, 0, true, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_AskLife_Accept.setListener(this);
		But_AskLife_CheckAll = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(195f), IGT_UIcommonFunc.ScaleY(340f), IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(40f)), pIgt_Textures.GetTexture(IGT_Constants._Mission), 122, 0, true, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_AskLife_CheckAll.setListener(this);
		btnFBLeaderBoardInvite = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(88f), IGT_UIcommonFunc.ScaleY(260f), IGT_UIcommonFunc.ScaleX(140f), IGT_UIcommonFunc.ScaleY(48f)), pIgt_Textures.GetTexture(IGT_Constants._SettingsBar), 102, 0, true, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		btnFBLeaderBoardInvite.setListener(this);
		pScroller_MailBoxScroll = new IGT_Scroller(0.25f * (float)Screen.height, new Vector2(35f, 35f), 1);
		pScroller_MailBoxScroll.setListener(this);
		MailBoxScroll_BarWid = IGT_UIcommonFunc.ScaleX(220f);
		MailBoxScroll_BarHeight = IGT_UIcommonFunc.ScaleY(50f);
		MailBoxScroll_BarGap = IGT_UIcommonFunc.ScaleY(0.6f);
		MailBoxScroll_BarStrtPosX = IGT_UIcommonFunc.ScaleX(17f);
		MailBoxScroll_BarStrtPosY = IGT_UIcommonFunc.ScaleY(10f);
		MailBoxScroll_CurPos = new Vector3(10f, 10f, 0f);
		ScrollViewRect_MailBoxScroll = new Rect(rect_MailBoxWin.x, rect_MailBoxWin.y + rect_MailBoxName.height + IGT_UIcommonFunc.ScaleY(8.5f), rect_MailBoxWin.width, IGT_UIcommonFunc.ScaleY(242f));
		rect_MailBoxNamePos = new Rect(IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleX(150f), IGT_UIcommonFunc.ScaleY(30f));
		fontSz_fbName = (int)IGT_UIcommonFunc.ScaleX(16f);
		fontSz_fbAskSendMsg = (int)IGT_UIcommonFunc.ScaleX(10f);
		pScroller_SendLifeScroll = new IGT_Scroller(0.25f * (float)Screen.height, new Vector2(35f, 35f), 1);
		pScroller_SendLifeScroll.setListener(this);
		SendLifeScroll_BarWid = IGT_UIcommonFunc.ScaleX(220f);
		SendLifeScroll_BarHeight = IGT_UIcommonFunc.ScaleY(50f);
		SendLifeScroll_BarGap = IGT_UIcommonFunc.ScaleY(0.6f);
		SendLifeScroll_BarStrtPosX = IGT_UIcommonFunc.ScaleX(20f);
		SendLifeScroll_BarStrtPosY = IGT_UIcommonFunc.ScaleY(10f);
		SendLifeScroll_CurPos = new Vector3(10f, 10f, 0f);
		ScrollViewRect_SendLifeScroll = ScrollViewRect_MailBoxScroll;
		rect_SendLifeNamePos = new Rect(IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleX(150f), IGT_UIcommonFunc.ScaleY(30f));
		pScroller_AskLifeScroll = new IGT_Scroller(0.25f * (float)Screen.height, new Vector2(35f, 35f), 1);
		pScroller_AskLifeScroll.setListener(this);
		AskLifeScroll_BarWid = IGT_UIcommonFunc.ScaleX(220f);
		AskLifeScroll_BarHeight = IGT_UIcommonFunc.ScaleY(50f);
		AskLifeScroll_BarGap = IGT_UIcommonFunc.ScaleY(0.6f);
		AskLifeScroll_BarStrtPosX = IGT_UIcommonFunc.ScaleX(17f);
		AskLifeScroll_BarStrtPosY = IGT_UIcommonFunc.ScaleY(10f);
		AskLifeScroll_CurPos = new Vector3(10f, 10f, 0f);
		ScrollViewRect_AskLifeScroll = ScrollViewRect_MailBoxScroll;
		rect_AskLifeNamePos = new Rect(IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleX(150f), IGT_UIcommonFunc.ScaleY(30f));
		pMapObj = new MapAPI();
		pSocialShare = new igtSocialShare();
		pFacebook = new lib_FaceBook("StreetChaser1.db", fbAppActivatedSucess);
		pFacebook.setProfilePicSize(100);
		if (pFacebook.isFBLoginSucess())
		{
			pFacebook.loadDataToDic();
			pFacebook.loadFrndsMissionDataToDic();
			pFacebook.loadGlobalChaseDataToDic();
			pFacebook.loadGlobalMissionDataToDic();
			fbList = pFacebook.getFBFrndsList();
			setFBPicDataRef();
		}
		dLBUpdateTimeDiff = Time.time;
		pLeaderBoard = new IGT_LeaderboardAchievements();
		bIsShowGPluseLoginAlert = pLeaderBoard.isGpluseSigninChecking();
		rectGpluseSigninalert = new Rect(IGT_UIcommonFunc.ScaleX(20f), IGT_UIcommonFunc.ScaleY(180f), IGT_UIcommonFunc.ScaleX(280f), IGT_UIcommonFunc.ScaleY(120f));
		btnGpluseSignin = new IGT_Button(pIgt_Textures.GetTexture(IGT_Constants._gpluse_Signin_Btn), 124, rectGpluseSigninalert.x + IGT_UIcommonFunc.ScaleX(98f), rectGpluseSigninalert.y + IGT_UIcommonFunc.ScaleY(82f), IGT_UIcommonFunc.ScaleX(90f), IGT_UIcommonFunc.ScaleY(30f));
		btnGpluseSignin.setListener(this);
		btnGplusealertClose = new IGT_Button(new Rect(rectGpluseSigninalert.x + IGT_UIcommonFunc.ScaleX(248f), rectGpluseSigninalert.y + IGT_UIcommonFunc.ScaleY(2f), IGT_UIcommonFunc.ScaleX(25f), IGT_UIcommonFunc.ScaleY(25f)), pIgt_Textures.GetTexture(IGT_Constants._CloseRect), 125, 0, true, 0f, new Vector2(0f, 0f), 0, 0f, 0, 0f, 0f);
		btnGplusealertClose.setListener(this);
		bIsShowGPluseLoginAlert = false;
		bInappAlert = false;
		nAlertWin = 0;
		if (CanShowStartUpAlerts())
		{
			if (IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_GSignInOnGameFirstOpen, 0) == 0)
			{
				if (pHero.isConnectedInternet())
				{
					pLeaderBoard.LeaderAchivLogin();
				}
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_GSignInOnGameFirstOpen, 1);
			}
			else if (!bIsShowGPluseLoginAlert && IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_GSignInOnGameFirstOpen, 0) == 1)
			{
				bInappAlert = true;
				nAlertWin = Select_startupAlertWinType();
				pHero.post_Analytics_Popup(Enum.GetNames(typeof(StartupAlertWin)).GetValue(nAlertWin).ToString());
			}
		}
		rect_Inappalert_Win = new Rect(IGT_UIcommonFunc.ScaleX(10f), IGT_UIcommonFunc.ScaleY(105f), IGT_UIcommonFunc.ScaleX(300f), IGT_UIcommonFunc.ScaleY(220f));
		But_Inapp__Alert_Close = new IGT_Button(new Rect(rect_Inappalert_Win.x + rect_Inappalert_Win.width - IGT_UIcommonFunc.ScaleX(30f) - IGT_UIcommonFunc.ScaleX(7f), rect_Inappalert_Win.y + IGT_UIcommonFunc.ScaleX(4f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(26f)), pIgt_Textures.GetTexture(IGT_Constants._CloseRect), 127, 0, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_Inapp__Alert_Close.setListener(this);
		But_Inapp__Alert_Store = new IGT_Button(new Rect(rect_Inappalert_Win.x + rect_Inappalert_Win.width / 2f - IGT_UIcommonFunc.ScaleX(55f), rect_Inappalert_Win.y + rect_Inappalert_Win.height - IGT_UIcommonFunc.ScaleY(25f), IGT_UIcommonFunc.ScaleX(110f), IGT_UIcommonFunc.ScaleY(36f)), pIgt_Textures.GetTexture(IGT_Constants._Button_Blue), 130, 0, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_Inapp__Alert_Store.setListener(this);
		But_Inapp_fbconnect = new IGT_Button(new Rect(rect_Inappalert_Win.x + rect_Inappalert_Win.width / 2f - IGT_UIcommonFunc.ScaleX(70f), rect_Inappalert_Win.y + rect_Inappalert_Win.height - IGT_UIcommonFunc.ScaleY(95f), IGT_UIcommonFunc.ScaleX(140f), IGT_UIcommonFunc.ScaleY(48f)), pIgt_Textures.GetTexture(IGT_Constants._SettingsBar), 128, -1, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_Inapp_fbconnect.setListener(this);
		But_Inapp_Alert_Life2 = new IGT_Button(new Rect(rect_Inappalert_Win.x + rect_Inappalert_Win.width / 2f - IGT_UIcommonFunc.ScaleX(40f), rect_Inappalert_Win.y + rect_Inappalert_Win.height - IGT_UIcommonFunc.ScaleY(90f), IGT_UIcommonFunc.ScaleX(78f), IGT_UIcommonFunc.ScaleY(28f)), pIgt_Textures.GetTexture(IGT_Constants._Button_select), 129, 1, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_Inapp_Alert_Life2.setListener(this);
		But_Inapp_Alert_Life1 = new IGT_Button(new Rect(But_Inapp_Alert_Life2.getX() - But_Inapp_Alert_Life2.getWidth() - IGT_UIcommonFunc.ScaleX(10f), But_Inapp_Alert_Life2.getY(), But_Inapp_Alert_Life2.getWidth(), But_Inapp_Alert_Life2.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._Button_select), 129, 0, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_Inapp_Alert_Life1.setListener(this);
		But_Inapp_Alert_Life3 = new IGT_Button(new Rect(But_Inapp_Alert_Life2.getX() + But_Inapp_Alert_Life2.getWidth() + IGT_UIcommonFunc.ScaleX(10f), But_Inapp_Alert_Life2.getY(), But_Inapp_Alert_Life2.getWidth(), But_Inapp_Alert_Life2.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._Button_select), 129, 2, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_Inapp_Alert_Life3.setListener(this);
		But_Inapp_Alert_Key2 = new IGT_Button(new Rect(rect_Inappalert_Win.x + rect_Inappalert_Win.width / 2f - IGT_UIcommonFunc.ScaleX(40f), rect_Inappalert_Win.y + rect_Inappalert_Win.height - IGT_UIcommonFunc.ScaleY(90f), IGT_UIcommonFunc.ScaleX(78f), IGT_UIcommonFunc.ScaleY(28f)), pIgt_Textures.GetTexture(IGT_Constants._Button_select), 129, 4, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 3f);
		But_Inapp_Alert_Key2.setListener(this);
		But_Inapp_Alert_Key1 = new IGT_Button(new Rect(But_Inapp_Alert_Key2.getX() - But_Inapp_Alert_Key2.getWidth() - IGT_UIcommonFunc.ScaleX(10f), But_Inapp_Alert_Key2.getY(), But_Inapp_Alert_Key2.getWidth(), But_Inapp_Alert_Key2.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._Button_select), 129, 3, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_Inapp_Alert_Key1.setListener(this);
		But_Inapp_Alert_Key3 = new IGT_Button(new Rect(But_Inapp_Alert_Key2.getX() + But_Inapp_Alert_Key2.getWidth() + IGT_UIcommonFunc.ScaleX(10f), But_Inapp_Alert_Key2.getY(), But_Inapp_Alert_Key2.getWidth(), But_Inapp_Alert_Key2.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._Button_select), 129, 5, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_Inapp_Alert_Key3.setListener(this);
		But_Inapp_Alert_Coin2 = new IGT_Button(new Rect(rect_Inappalert_Win.x + rect_Inappalert_Win.width / 2f - IGT_UIcommonFunc.ScaleX(40f), rect_Inappalert_Win.y + rect_Inappalert_Win.height - IGT_UIcommonFunc.ScaleY(90f), IGT_UIcommonFunc.ScaleX(78f), IGT_UIcommonFunc.ScaleY(28f)), pIgt_Textures.GetTexture(IGT_Constants._Button_select), 129, 7, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 3f);
		But_Inapp_Alert_Coin2.setListener(this);
		But_Inapp_Alert_Coin1 = new IGT_Button(new Rect(But_Inapp_Alert_Coin2.getX() - But_Inapp_Alert_Coin2.getWidth() - IGT_UIcommonFunc.ScaleX(10f), But_Inapp_Alert_Coin2.getY(), But_Inapp_Alert_Coin2.getWidth(), But_Inapp_Alert_Coin2.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._Button_select), 129, 6, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_Inapp_Alert_Coin1.setListener(this);
		But_Inapp_Alert_Coin3 = new IGT_Button(new Rect(But_Inapp_Alert_Coin2.getX() + But_Inapp_Alert_Coin2.getWidth() + IGT_UIcommonFunc.ScaleX(10f), But_Inapp_Alert_Coin2.getY(), But_Inapp_Alert_Coin2.getWidth(), But_Inapp_Alert_Coin2.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._Button_select), 129, 8, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_Inapp_Alert_Coin3.setListener(this);
		But_Inapp_Alert_Combo2 = new IGT_Button(new Rect(rect_Inappalert_Win.x + rect_Inappalert_Win.width / 2f - IGT_UIcommonFunc.ScaleX(40f), rect_Inappalert_Win.y + rect_Inappalert_Win.height - IGT_UIcommonFunc.ScaleY(78f), IGT_UIcommonFunc.ScaleX(78f), IGT_UIcommonFunc.ScaleY(28f)), pIgt_Textures.GetTexture(IGT_Constants._Button_select), 129, 10, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 3f);
		But_Inapp_Alert_Combo2.setListener(this);
		But_Inapp_Alert_Combo1 = new IGT_Button(new Rect(But_Inapp_Alert_Combo2.getX() - But_Inapp_Alert_Combo2.getWidth() - IGT_UIcommonFunc.ScaleX(10f), But_Inapp_Alert_Combo2.getY(), But_Inapp_Alert_Combo2.getWidth(), But_Inapp_Alert_Combo2.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._Button_select), 129, 9, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_Inapp_Alert_Combo1.setListener(this);
		But_Inapp_Alert_Combo3 = new IGT_Button(new Rect(But_Inapp_Alert_Combo2.getX() + But_Inapp_Alert_Combo2.getWidth() + IGT_UIcommonFunc.ScaleX(10f), But_Inapp_Alert_Combo2.getY(), But_Inapp_Alert_Combo2.getWidth(), But_Inapp_Alert_Combo2.getHeight()), pIgt_Textures.GetTexture(IGT_Constants._Button_select), 129, 11, false, 0f, Vector2.zero, 0, 5f, 0, 5f, 2f);
		But_Inapp_Alert_Combo3.setListener(this);
		fGcCollectStrtTime = Time.time;
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_RewardedVideoLastShow))
		{
			dRewardedVideoLastShowIntervelSec = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_RewardedVideoLastShow, 0);
		}
		else
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_RewardedVideoLastShow, 0);
		}
		if (IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_isNewBadgeMoreGamesHomeScreenShown, 1) == 0)
		{
			bNewBadgeInMoreGames = true;
		}
		else
		{
			bNewBadgeInMoreGames = canEnable_NewBadge_in_MoreGames_HomeScreen();
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_MoregamesLastShow))
		{
			dMoregamesLastShownIntervalTimeSec = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_MoregamesLastShow, (float)currentTimeSecs());
		}
		else
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_MoregamesLastShow, (float)currentTimeSecs());
			dMoregamesLastShownIntervalTimeSec = currentTimeSecs();
		}
		didClickMoreGames = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_didClickMoreGames, 0);
		bMoreGameEnableInPurchaseWindow = canEnableMoreGamesButtonInPurchaseWindow();
		pMoregame = new webView(pIgt_Textures, IGT_Constants.MoregamesTitle);
		pMoregame.setWebViewMargins();
		Rect closeBtnPos = pMoregame.getCloseBtnPos();
		btn_MoregameClose = new IGT_Button(106, closeBtnPos.x, closeBtnPos.y, closeBtnPos.width, closeBtnPos.height);
		btn_MoregameClose.setListener(this);
		rectAboutBG = new Rect(IGT_UIcommonFunc.ScaleX(10f), IGT_UIcommonFunc.ScaleY(20f), IGT_UIcommonFunc.ScaleX(300f), IGT_UIcommonFunc.ScaleY(440f));
		btn_AboutClose = new IGT_Button(pIgt_Textures.GetTexture(IGT_Constants._CloseRect), 107, IGT_UIcommonFunc.ScaleX(265f), IGT_UIcommonFunc.ScaleY(25f), IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleY(40f));
		btn_AboutClose.setListener(this);
		pRateit = new IGT_RateIt();
		pMissionLevelComplitedInfo = gameMissionsLeveUpItems;
		CallGetScoreFunction_Action = callGetScoreFunction;
		Mirror_Chs_FB = pIgt_Textures.Get_MirroredTexture((Texture2D)pIgt_Textures.GetTexture(IGT_Constants._Chs_FBLB_Tab));
		Mirror_Msn_FB = pIgt_Textures.Get_MirroredTexture((Texture2D)pIgt_Textures.GetTexture(IGT_Constants._Msn_Fb_FriendsTab));
		Mirror_MC_FBtab = pIgt_Textures.Get_MirroredTexture((Texture2D)pIgt_Textures.GetTexture(IGT_Constants._MissionGameOverTab));
		Mirror_BustedTab = pIgt_Textures.Get_MirroredTexture((Texture2D)pIgt_Textures.GetTexture(IGT_Constants._EndlessRun_GameOver_BustedTab));
		bInviteReLogin = false;
		setSocialShareValues();
		feedShareTime = (long)IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_feedLastShareTime, 0f);
		fLeaderBoard_Chase_LastUpdatedTime = (fLeaderBoard_Mission_LastUpdatedTime = 0f);
		bCanGetScoreFrmInternet = false;
		pIGT_ScrollData_GameOver_Fb = new List<IGT_ScrollData>(4);
		pIGT_ScrollData_GameOver_Topchase = new List<IGT_ScrollData>(4);
		pIGT_ScrollData_MC_FbFriends = new List<IGT_ScrollData>(4);
		pIGT_ScrollData_MC_FbGlobal = new List<IGT_ScrollData>(4);
		But_GetScoreRetry = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(160f) - IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleY(140f), IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(30f)), pIgt_Textures.GetTexture(IGT_Constants._Button_Blue), 131, 0, false, 0f, Vector2.zero, 0, 0.75f, 0, 0f, 0f);
		But_GetScoreRetry.setListener(this);
		timeTorRefreshFBlistDict = currentTimeSecs();
		pGetCompleted = getfrndListCompleted;
		pRefreshFBlistAction = pFacebook.GetFriendsInfo;
		But_MissionFailedSkip = new IGT_Button(new Rect(IGT_UIcommonFunc.ScaleX(190f), IGT_UIcommonFunc.ScaleY(435f), IGT_UIcommonFunc.ScaleX(70f), IGT_UIcommonFunc.ScaleY(35f)), pIgt_Textures.GetTexture(IGT_Constants._skipLevel), 132, 0, false, 0f, Vector2.zero, 0, 0.75f, 0, 1f, 5f);
		But_MissionFailedSkip.setListener(this);
		bSkipButNeeded = true;
	}

	private IEnumerator getProfilePic(Action ProPicDownloadSuccess = null, Action ProPicDownloadFail = null)
	{
		List<string> tmpKeyList = pFacebook.UserFrndsInfo.Keys.ToList();
		int cnt = tmpKeyList.Count;
		for (int i = 0; i < cnt; i++)
		{
			string imgURL = "https://graph.facebook.com/" + tmpKeyList[i] + "/picture?width=" + pFacebook.nPicSize + "&height=" + pFacebook.nPicSize;
			WWW www = new WWW(Uri.EscapeUriString(imgURL));
			yield return www;
			if (www.error == null)
			{
				userProfilePicDict[tmpKeyList[i]] = www.texture;
			}
		}
		if (ProPicDownloadSuccess != null)
		{
			ProPicDownloadSuccess();
		}
	}

	private void ProPicDownloadSuccess()
	{
	}

	private void ProPicDownloadFailed()
	{
	}

	private void fbAppActivatedSucess()
	{
		if (pFacebook.isFBLoginSucess())
		{
			pFacebook.GetFriendsInfo(getfrndListCompleted);
		}
		if (pFacebook.isFBLoginSucess() && !bProcessDeleteAppReqCall)
		{
			pFacebook.ProcessAppRequest(ProcessAppRequestComplete);
		}
	}

	private void getfrndListCompleted()
	{
		StartCoroutine(getProfilePic(ProPicDownloadSuccess, ProPicDownloadFailed));
		fbList = pFacebook.getFBFrndsList();
		setFBPicDataRef();
	}

	private void onFBInitCompleted()
	{
	}

	public static string getDeviceID()
	{
		string deviceUniqueIdentifier = SystemInfo.deviceUniqueIdentifier;
		string str = deviceUniqueIdentifier.Substring(0, deviceUniqueIdentifier.Length / 2);
		string str2 = deviceUniqueIdentifier.Substring(deviceUniqueIdentifier.Length / 2);
		str = CRC(str).ToString();
		str2 = CRC(str2).ToString();
		if (str.Length > 10)
		{
			str = str.Substring(0, 9);
		}
		if (str2.Length > 10)
		{
			str2 = str2.Substring(0, 9);
		}
		string text = str + str2;
		if (text.Length < 20)
		{
			return text;
		}
		return text.Substring(0, 19);
	}

	private void delegateRewardedVideoAd(string _descrp, double _val)
	{
		bRewardedVideoTimeUp = false;
		if (nScreenMode != 3)
		{
			pHero.pIGt_LifeCalc.addLifeCount(1);
		}
	}

	private void delegateRewardedVideoAd_CloseBut(bool _delegateVal)
	{
		bRewardedVideoTimeUp = false;
		dRewardedVideoLastShowIntervelSec = currentTimeSecs();
		IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_RewardedVideoLastShow, (int)dRewardedVideoLastShowIntervelSec);
		if (!_delegateVal)
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_rewardedTimeInterVal, 1);
			dRewardedVideoLastShowTimeIntervelMin = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_rewardedTimeInterVal, 1);
		}
		else
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_rewardedTimeInterVal, 10);
			dRewardedVideoLastShowTimeIntervelMin = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_rewardedTimeInterVal, 10);
		}
		if (_delegateVal)
		{
			StartCoroutine(_delegateRewardedVideoAd_CloseBut());
		}
	}

	private IEnumerator _delegateRewardedVideoAd_CloseBut()
	{
		yield return new WaitForSeconds(0f);
		if (nScreenMode == 3)
		{
			UsekeyButEvent(false);
		}
	}

	private void delegateAdView(bool _bShowView)
	{
		bRewardedVideoTimeUp = false;
		StartCoroutine(_delegateAdView(_bShowView));
	}

	private IEnumerator _delegateAdView(bool _bShowView)
	{
		yield return new WaitForSeconds(0f);
		if (_bShowView)
		{
			pHero._AudioSource.Pause();
			pHero._AudioSource2.Pause();
			pHero._AudioSource3.Pause();
			pHero._AudioSource4.Pause();
		}
		else
		{
			pHero._AudioSource.UnPause();
			pHero._AudioSource2.UnPause();
			pHero._AudioSource3.UnPause();
			pHero._AudioSource4.UnPause();
		}
	}

	private bool CanShowStartUpAlerts()
	{
		DateTime dateTime = new DateTime(2017, 6, 6, 0, 0, 0, DateTimeKind.Utc);
		float num = 1440f;
		float num2 = (float)(DateTime.UtcNow - dateTime).TotalMinutes;
		bool result = false;
		float num3 = 0f;
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_startUpAlert))
		{
			num3 = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_startUpAlert, 0f);
		}
		if (num2 - num3 > num)
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_startUpAlert, num2);
			result = true;
		}
		return result;
	}

	private bool canEnable_NewBadge_in_MoreGames_HomeScreen()
	{
		bool result = false;
		float num = 864000f;
		float num2 = currentTimeSecs();
		float num3 = 0f;
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_NewBadgeMoreGamesHomeScreen_Time))
		{
			num3 = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_NewBadgeMoreGamesHomeScreen_Time, 0f);
		}
		if (num2 - num3 > num)
		{
			result = true;
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_NewBadgeMoreGamesHomeScreen_Time, num2);
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_isNewBadgeMoreGamesHomeScreenShown, 0);
			IGT_Preference.getInstance()._SaveAll();
		}
		return result;
	}

	private static bool canEnableMoreGamesButtonInPurchaseWindow()
	{
		float num = (float)(dMoregamesLastShownTimeSecs - ((double)currentTimeSecs() - dMoregamesLastShownIntervalTimeSec) % 60.0);
		float num2 = (float)(dMoregamesLastShownTimeMins - ((double)currentTimeSecs() - dMoregamesLastShownIntervalTimeSec) / 60.0 % 60.0);
		float num3 = (float)(dMoregamesLastShownTimeHrs - ((double)currentTimeSecs() - dMoregamesLastShownIntervalTimeSec) / 3600.0 % 24.0);
		if (num3 == 24f)
		{
			num3 = 0f;
		}
		if (num2 == 60f)
		{
			num2 = 0f;
		}
		if (num == 60f)
		{
			num = 0f;
		}
		if ((num3 <= 0f && num2 <= 0f && num <= 0f) || (double)currentTimeSecs() - dMoregamesLastShownIntervalTimeSec >= 86400.0 || didClickMoreGames == 0)
		{
			return true;
		}
		return false;
	}

	private static string getMoreGamesIntervalinFreeTab()
	{
		float num = (float)(dMoregamesLastShownTimeSecs - ((double)currentTimeSecs() - dMoregamesLastShownIntervalTimeSec) % 60.0);
		float num2 = (float)(dMoregamesLastShownTimeMins - ((double)currentTimeSecs() - dMoregamesLastShownIntervalTimeSec) / 60.0 % 60.0);
		float num3 = (float)(dMoregamesLastShownTimeHrs - ((double)currentTimeSecs() - dMoregamesLastShownIntervalTimeSec) / 3600.0 % 24.0);
		if (num3 == 24f)
		{
			num3 = 0f;
		}
		if (num2 == 60f)
		{
			num2 = 0f;
		}
		if (num == 60f)
		{
			num = 0f;
		}
		if ((double)currentTimeSecs() - dMoregamesLastShownIntervalTimeSec >= 86400.0 || didClickMoreGames == 0)
		{
			bMoreGameEnableInPurchaseWindow = true;
		}
		else if (didClickMoreGames == 1)
		{
			bMoreGameEnableInPurchaseWindow = false;
		}
		if (Mathf.Floor(num3) <= 0f && Mathf.Floor(num2) <= 0f && Mathf.Floor(num) <= 0f)
		{
			return "24:00:00";
		}
		return string.Format("{00:00}", Mathf.Floor(num3)).ToString() + " : " + string.Format("{00:00}", Mathf.Floor(num2)).ToString() + " : " + string.Format("{00:00}", Mathf.Floor(num)).ToString();
	}

	private int Select_startupAlertWinType()
	{
		int num = -1;
		int randomNumber = pHero.PlayerObj.getRandomNumber(100);
		if (randomNumber % 2 == 0)
		{
			return 5;
		}
		int randomNumber2 = pHero.PlayerObj.getRandomNumber(100);
		if (randomNumber2 > 90)
		{
			return 2;
		}
		if (randomNumber2 > 75)
		{
			return 3;
		}
		if (randomNumber2 > 50)
		{
			return 1;
		}
		return 4;
	}

	private void loadTextures()
	{
		pIgt_Textures = new IGT_Textures();
		pIgt_Textures.LoadTexture(IGT_Constants._leaderBoard);
		pIgt_Textures.LoadTexture(IGT_Constants._Settings);
		pIgt_Textures.LoadTexture(IGT_Constants._Settings_tilt);
		pIgt_Textures.LoadTexture(IGT_Constants._Life);
		pIgt_Textures.LoadTexture(IGT_Constants._CoinImg);
		pIgt_Textures.LoadTexture(IGT_Constants._KeyImg);
		pIgt_Textures.LoadTexture(IGT_Constants._Email);
		pIgt_Textures.LoadTexture(IGT_Constants._SendLife);
		pIgt_Textures.LoadTexture(IGT_Constants._Achievement);
		pIgt_Textures.LoadTexture(IGT_Constants._AllShare);
		pIgt_Textures.LoadTexture(IGT_Constants._MoreGames);
		pIgt_Textures.LoadTexture(IGT_Constants._WatchVideo);
		pIgt_Textures.LoadTexture(IGT_Constants._Shop_HS);
		pIgt_Textures.LoadTexture(IGT_Constants._FConnect);
		pIgt_Textures.LoadTexture(IGT_Constants._Menu);
		pIgt_Textures.LoadTexture(IGT_Constants._Chase);
		pIgt_Textures.LoadTexture(IGT_Constants._Mission);
		pIgt_Textures.LoadTexture(IGT_Constants._Blue_btn);
		pIgt_Textures.LoadTexture(IGT_Constants._CornerBoard_green);
		pIgt_Textures.LoadTexture(IGT_Constants._CornerBoard_green_Rt);
		pIgt_Textures.LoadTexture(IGT_Constants._ScoreBoard_green);
		pIgt_Textures.LoadTexture(IGT_Constants._Hs_Menu_Bg);
		pIgt_Textures.LoadTexture(IGT_Constants._SettingsBg);
		pIgt_Textures.LoadTexture(IGT_Constants._SettingsBar);
		pIgt_Textures.LoadTexture(IGT_Constants._CloseRect);
		pIgt_Textures.LoadTexture(IGT_Constants._Music);
		pIgt_Textures.LoadTexture(IGT_Constants._Sound);
		pIgt_Textures.LoadTexture(IGT_Constants._Notification);
		pIgt_Textures.LoadTexture(IGT_Constants._RestorePurchase);
		pIgt_Textures.LoadTexture(IGT_Constants._FbIcon);
		pIgt_Textures.LoadTexture(IGT_Constants._GlobeIcon);
		pIgt_Textures.LoadTexture(IGT_Constants._BustedIcon);
		pIgt_Textures.LoadTexture(IGT_Constants._TopchaseIcon);
		pIgt_Textures.LoadTexture(IGT_Constants._On);
		pIgt_Textures.LoadTexture(IGT_Constants._Off);
		pIgt_Textures.LoadTexture(IGT_Constants._SaveMeBG);
		pIgt_Textures.LoadTexture(IGT_Constants._SaveMeCorn);
		pIgt_Textures.LoadTexture(IGT_Constants._SaveMeRed);
		pIgt_Textures.LoadTexture(IGT_Constants._SaveMeWatchVideo);
		pIgt_Textures.LoadTexture(IGT_Constants._SaveMeUseKey);
		pIgt_Textures.LoadTexture(IGT_Constants._SaveMeGreen);
		pIgt_Textures.LoadTexture(IGT_Constants._Pause_Bg);
		pIgt_Textures.LoadTexture(IGT_Constants._Pause_Resume);
		pIgt_Textures.LoadTexture(IGT_Constants._Pause_Back);
		pIgt_Textures.LoadTexture(IGT_Constants._Pause_Boost);
		pIgt_Textures.LoadTexture(IGT_Constants._Abort_BG);
		pIgt_Textures.LoadTexture(IGT_Constants._Abort_Life);
		pIgt_Textures.LoadTexture(IGT_Constants._Abort_Cancel);
		pIgt_Textures.LoadTexture(IGT_Constants._Abort_Ok);
		pIgt_Textures.LoadTexture(IGT_Constants._Abort_LifeIcon);
		pIgt_Textures.LoadTexture(IGT_Constants._NoMoreLives_BG);
		pIgt_Textures.LoadTexture(IGT_Constants._NoMoreLives_AskFriends);
		pIgt_Textures.LoadTexture(IGT_Constants._NoMoreLives_GetFree);
		pIgt_Textures.LoadTexture(IGT_Constants._NoMoreLives_PriceTag);
		pIgt_Textures.LoadTexture(IGT_Constants._NotEnoughKeys_BG);
		pIgt_Textures.LoadTexture(IGT_Constants._NotEnoughKeys_priceTag);
		pIgt_Textures.LoadTexture(IGT_Constants._EndlessRun_GameOver_TabBG);
		pIgt_Textures.LoadTexture(IGT_Constants._EndlessRun_GameOver_TopChaseTab);
		pIgt_Textures.LoadTexture(IGT_Constants._EndlessRun_GameOver_BustedTab);
		pIgt_Textures.LoadTexture(IGT_Constants._GameOver_ScrollBar);
		pIgt_Textures.LoadTexture(IGT_Constants._GameOver_BG);
		pIgt_Textures.LoadTexture(IGT_Constants._GameOver_Home);
		pIgt_Textures.LoadTexture(IGT_Constants._GameOver_Play);
		pIgt_Textures.LoadTexture(IGT_Constants._GameOver_CoinCount);
		pIgt_Textures.LoadTexture(IGT_Constants._GameOver_KeyCount);
		pIgt_Textures.LoadTexture(IGT_Constants._GameOver_LifeCount);
		for (int i = 0; i < IGT_Constants.AIPlayer_FacePicx.Length; i++)
		{
			IGT_Constants.AIPlayer_FacePicx[i] = IGT_Constants.Path_AIPlayerFace + i;
			pIgt_Textures.LoadTexture(IGT_Constants.AIPlayer_FacePicx[i]);
		}
		for (int j = 0; j < IGT_Constants.Hero_FacePicx.Length; j++)
		{
			IGT_Constants.Hero_FacePicx[j] = IGT_Constants.Path_HeroFace + j;
			pIgt_Textures.LoadTexture(IGT_Constants.Hero_FacePicx[j]);
		}
		pIgt_Textures.LoadTexture(IGT_Constants.Path_Heroine_Face);
		pIgt_Textures.LoadTexture(IGT_Constants._Shop_Tab);
		pIgt_Textures.LoadTexture(IGT_Constants._Shop_Back);
		pIgt_Textures.LoadTexture(IGT_Constants._Shop_ScrollBar);
		pIgt_Textures.LoadTexture(IGT_Constants._Shop_Boost);
		pIgt_Textures.LoadTexture(IGT_Constants._Shop_Combo);
		pIgt_Textures.LoadTexture(IGT_Constants._Shop_Free);
		pIgt_Textures.LoadTexture(IGT_Constants._Shop_Store);
		pIgt_Textures.LoadTexture(IGT_Constants._Shop_PriceBg);
		pIgt_Textures.LoadTexture(IGT_Constants._Store_Icon);
		pIgt_Textures.LoadTexture(IGT_Constants._Combo_Icon);
		pIgt_Textures.LoadTexture(IGT_Constants._Boost_Icon);
		pIgt_Textures.LoadTexture(IGT_Constants._Free_Icon);
		pIgt_Textures.LoadTexture(IGT_Constants._Game_ChaseHeader);
		pIgt_Textures.LoadTexture(IGT_Constants._Game_MapDock);
		pIgt_Textures.LoadTexture(IGT_Constants._Game_LifeBar_Green);
		pIgt_Textures.LoadTexture(IGT_Constants._Game_LifeBar_Red);
		pIgt_Textures.LoadTexture(IGT_Constants._Game_PauseBtn);
		pIgt_Textures.LoadTexture(IGT_Constants._countDown_Bg);
		pIgt_Textures.LoadTexture(IGT_Constants._CountDown_Glow);
		pIgt_Textures.LoadTexture(IGT_Constants._Mission_TagRound);
		pIgt_Textures.LoadTexture(IGT_Constants._StarImg);
		pIgt_Textures.LoadTexture(IGT_Constants._Star_Empty);
		pIgt_Textures.LoadTexture(IGT_Constants._Retry);
		pIgt_Textures.LoadTexture(IGT_Constants._Next);
		pIgt_Textures.LoadTexture(IGT_Constants._DotImg);
		pIgt_Textures.LoadTexture(IGT_Constants._MissionGameOverTab);
		pIgt_Textures.LoadTexture(IGT_Constants._MC_FbLB_Tab_Bg);
		pIgt_Textures.LoadTexture(IGT_Constants._MC_FbLB_Tab_Bg_grn);
		pIgt_Textures.LoadTexture(IGT_Constants.mailCheckBox);
		pIgt_Textures.LoadTexture(IGT_Constants.mailCheckMarkBox);
		pIgt_Textures.LoadTexture(IGT_Constants.map_ScoreBoard);
		pIgt_Textures.LoadTexture(IGT_Constants._Menu_Bg);
		pIgt_Textures.LoadTexture(IGT_Constants._About);
		pIgt_Textures.LoadTexture(IGT_Constants._GreyOverLay);
		pIgt_Textures.LoadTexture(IGT_Constants._lkc_btn);
		pIgt_Textures.LoadTexture(IGT_Constants._Button_select);
		pIgt_Textures.LoadTexture(IGT_Constants._MoveRight);
		pIgt_Textures.LoadTexture(IGT_Constants._glowLB);
		pIgt_Textures.LoadTexture(IGT_Constants._BtnEnable_MC_LB);
		pIgt_Textures.LoadTexture(IGT_Constants._BtnDisable_MC_LB);
		pIgt_Textures.LoadTexture(IGT_Constants._Msn_Fb_FriendsTab);
		pIgt_Textures.LoadTexture(IGT_Constants._Chs_FBLB_Tab);
		pIgt_Textures.LoadTexture(IGT_Constants._Leaderboard_FB_Alert);
		pIgt_Textures.LoadTexture(IGT_Constants._FacebookLB);
		pIgt_Textures.LoadTexture(IGT_Constants._GoogleLB);
		pIgt_Textures.LoadTexture(IGT_Constants._Magnet);
		pIgt_Textures.LoadTexture(IGT_Constants._MedPlus);
		pIgt_Textures.LoadTexture(IGT_Constants._MedKit);
		pIgt_Textures.LoadTexture(IGT_Constants._coin2X);
		pIgt_Textures.LoadTexture(IGT_Constants._coin3x);
		pIgt_Textures.LoadTexture(IGT_Constants._coin2X_Store);
		pIgt_Textures.LoadTexture(IGT_Constants._coin3x_Store);
		pIgt_Textures.LoadTexture(IGT_Constants._Invisble);
		pIgt_Textures.LoadTexture(IGT_Constants._SpdInc);
		pIgt_Textures.LoadTexture(IGT_Constants._SpdDec);
		pIgt_Textures.LoadTexture(IGT_Constants._Busted);
		pIgt_Textures.LoadTexture(IGT_Constants._Arrow);
		pIgt_Textures.LoadTexture(IGT_Constants._HandTap);
		pIgt_Textures.LoadTexture(IGT_Constants._Lock);
		pIgt_Textures.LoadTexture(IGT_Constants._Bottle);
		pIgt_Textures.LoadTexture(IGT_Constants._Ball);
		pIgt_Textures.LoadTexture(IGT_Constants._TickMark);
		pIgt_Textures.LoadTexture(IGT_Constants._Button_Green);
		pIgt_Textures.LoadTexture(IGT_Constants._Button_Blue);
		pIgt_Textures.LoadTexture(IGT_Constants._Button_Red);
		pIgt_Textures.LoadTexture(IGT_Constants._AlertBoard_Blue);
		pIgt_Textures.LoadTexture(IGT_Constants._AlertBoard_Green);
		pIgt_Textures.LoadTexture(IGT_Constants._AlertBoard_IconBG);
		pIgt_Textures.LoadTexture(IGT_Constants._TalkingCloud);
		pIgt_Textures.LoadTexture(IGT_Constants._BBHeader);
		pIgt_Textures.LoadTexture(IGT_Constants._MapPointer);
		pIgt_Textures.LoadTexture(IGT_Constants._ScoreMultiplier);
		pIgt_Textures.LoadTexture(IGT_Constants._UpgradeON);
		pIgt_Textures.LoadTexture(IGT_Constants._UpgradeOFF);
		pIgt_Textures.LoadTexture(IGT_Constants._Jump);
		pIgt_Textures.LoadTexture(IGT_Constants._Slide);
		pIgt_Textures.LoadTexture(IGT_Constants._PopupInfoBG);
		pIgt_Textures.LoadTexture(IGT_Constants._Whatsapp);
		pIgt_Textures.LoadTexture(IGT_Constants._Twitter);
		pIgt_Textures.LoadTexture(IGT_Constants._EmailShare);
		pIgt_Textures.LoadTexture(IGT_Constants._Message);
		pIgt_Textures.LoadTexture(IGT_Constants._New);
		pIgt_Textures.LoadTexture(IGT_Constants._wordDock);
		pIgt_Textures.LoadTexture(IGT_Constants._GameIcon);
		pIgt_Textures.LoadTexture(IGT_Constants._Plus_Icon);
		pIgt_Textures.LoadTexture(IGT_Constants._RateitBg);
		pIgt_Textures.LoadTexture(IGT_Constants._EmailCount);
		pIgt_Textures.LoadTexture(IGT_Constants.defaultFB);
		pIgt_Textures.LoadTexture(IGT_Constants._skipLevel);
		pIgt_Textures.LoadTexture(IGT_Constants.Path_purchaseItemsImages + "HeapOfCoin");
		pIgt_Textures.LoadTexture(IGT_Constants.Path_purchaseItemsImages + "BagOfCoins");
		pIgt_Textures.LoadTexture(IGT_Constants.Path_purchaseItemsImages + "TrolleyOfCoin");
		pIgt_Textures.LoadTexture(IGT_Constants.Path_purchaseItemsImages + "vaultOfCoins");
		pIgt_Textures.LoadTexture(IGT_Constants.Path_purchaseItemsImages + "TruckOfCoin");
		pIgt_Textures.LoadTexture(IGT_Constants.Path_purchaseItemsImages + "HandFullOfKeys");
		pIgt_Textures.LoadTexture(IGT_Constants.Path_purchaseItemsImages + "PouchOfkeys");
		pIgt_Textures.LoadTexture(IGT_Constants.Path_purchaseItemsImages + "TrayOfKeys");
		pIgt_Textures.LoadTexture(IGT_Constants.Path_purchaseItemsImages + "BoxOfKeys");
		pIgt_Textures.LoadTexture(IGT_Constants.Path_purchaseItemsImages + "5lives");
		pIgt_Textures.LoadTexture(IGT_Constants.Path_purchaseItemsImages + "25lives");
		pIgt_Textures.LoadTexture(IGT_Constants.Path_purchaseItemsImages + "100lives");
		pIgt_Textures.LoadTexture(IGT_Constants.Path_purchaseItemsImages + "Coin_keys");
		pIgt_Textures.LoadTexture(IGT_Constants.Path_purchaseItemsImages + "Coin_Life");
		pIgt_Textures.LoadTexture(IGT_Constants.Path_purchaseItemsImages + "Keys_Life");
		pIgt_Textures.LoadTexture(IGT_Constants.Path_purchaseItemsImages + "MegaBundle");
		pIgt_Textures.LoadTexture(IGT_Constants.Path_purchaseItemsImages + "BoosterOffer1");
		pIgt_Textures.LoadTexture(IGT_Constants.Path_purchaseItemsImages + "BoosterOffer2");
		pIgt_Textures.LoadTexture(IGT_Constants.Path_purchaseItemsImages + "WatchVideo");
		pIgt_Textures.LoadTexture(IGT_Constants.Path_purchaseItemsImages + "connectFB");
		pIgt_Textures.LoadTexture(IGT_Constants.Path_purchaseItemsImages + "fInvite");
		pIgt_Textures.LoadTexture(IGT_Constants.Path_purchaseItemsImages + "igtmore");
		pIgt_Textures.LoadTexture(IGT_Constants.Path_purchaseItemsImages + "likeIGT");
		pIgt_Textures.LoadTexture(IGT_Constants.MoregamesTitle);
		pIgt_Textures.LoadTexture(IGT_Constants.aboutTxt);
		pIgt_Textures.LoadTexture(IGT_Constants.AlphaHalfButton);
		pIgt_Textures.LoadTexture(IGT_Constants.LikePageTitle);
		pIgt_Textures.LoadTexture(IGT_Constants.fbInvite);
		pIgt_Textures.LoadTexture(IGT_Constants._gpluse_Signin_Btn);
	}

	private void loadAllCollectionImages()
	{
		IGT_Constants.collectionItemsImg = new string[Enum.GetNames(typeof(CollectionItemTypes)).Length];
		for (int i = 0; i < IGT_Constants.collectionItemsImg.Length; i++)
		{
			IGT_Constants.collectionItemsImg[i] = IGT_Constants.Path_CollectionItemsImages + i;
			pIgt_Textures.LoadTexture(IGT_Constants.collectionItemsImg[i]);
		}
		IGT_Constants.BringBackItemsImg = new string[Enum.GetNames(typeof(BringBackItems)).Length];
		IGT_Constants.BringBackItemsImg[0] = IGT_Constants.collectionItemsImg[4];
		IGT_Constants.BringBackItemsImg[1] = IGT_Constants.collectionItemsImg[5];
		IGT_Constants.BringBackItemsImg[2] = IGT_Constants.collectionItemsImg[3];
		IGT_Constants.BringBackItemsImg[3] = IGT_Constants.collectionItemsImg[2];
		IGT_Constants.BringBackItemsImg[4] = IGT_Constants.collectionItemsImg[6];
		IGT_Constants.BringBackItemsImg[5] = IGT_Constants.collectionItemsImg[7];
		IGT_Constants.BringBackItemsImg[6] = IGT_Constants.collectionItemsImg[8];
	}

	private void loadFonts()
	{
		pIgt_Lable = new IGT_Lable();
		pIgt_Lable.LoadFont(IGT_Constants.Font_TitanOne);
		pIgt_Lable.LoadFont(IGT_Constants.Font_Nunito);
		pIgt_Lable.LoadFont(IGT_Constants.Font_Jellee_Roman);
		pIgt_Lable.LoadFont(IGT_Constants.Font_nulshock);
		pIgt_Lable.LoadFont(IGT_Constants.Font_Nunito_Bold);
		pIgt_Lable.LoadFont(IGT_Constants.Font_TakeYour);
		pIgt_Lable.LoadFont(IGT_Constants.Font_alpha_echo);
		pIgt_Lable.LoadFont(IGT_Constants.Font_TTMasters);
		pIgt_Lable.LoadFont(IGT_Constants.Font_chelaOne);
		pIgt_Lable.LoadFont(IGT_Constants.Font_SevenSegment);
		pIgt_Lable.LoadFont(IGT_Constants.Font_LemonR);
	}

	private void Instantiate_3DGUIcharacters()
	{
		is3dObjNeeded = true;
		pOnGui_3dObj_Hero = new GameObject[pHero.pHeroData.Count];
		for (int i = 0; i < pOnGui_3dObj_Hero.Length; i++)
		{
			pOnGui_3dObj_Hero[i] = UnityEngine.Object.Instantiate(Resources.Load(IGT_Constants.Path_Hero_Prefab + i), new Vector3(0.742f, 0.04f, -69.551f), Quaternion.Euler(new Vector3(0f, 180f, 0f))) as GameObject;
			SkinnedMeshRenderer componentInChildren = pOnGui_3dObj_Hero[i].GetComponentInChildren<SkinnedMeshRenderer>();
			componentInChildren.material = (Material)Resources.Load(IGT_Constants.Path_HeroMaterials + i, typeof(Material));
			pHero.setLayerToAllChildrens(pOnGui_3dObj_Hero[i], IGT_Constants.layer_3DUI);
			pOnGui_3dObj_Hero[i].tag = "Untagged";
			pOnGui_3dObj_Hero[i].name = "3dGuiChar" + i;
			pOnGui_3dObj_Hero[i].GetComponent<Animator>().runtimeAnimatorController = Resources.Load(IGT_Constants.Path_Controller_3DUI) as RuntimeAnimatorController;
			pOnGui_3dObj_Hero[i].GetComponent<Animator>().applyRootMotion = false;
			GameObject gameObject = new GameObject("DirLight");
			gameObject.transform.position = pOnGui_3dObj_Hero[i].transform.position;
			gameObject.transform.rotation = Quaternion.Euler(new Vector3(100f, -180f, 0f));
			gameObject.AddComponent<Light>();
			gameObject.GetComponent<Light>().type = LightType.Directional;
			gameObject.GetComponent<Light>().shadows = LightShadows.None;
			gameObject.GetComponent<Light>().intensity = 0.7f;
			gameObject.GetComponent<Light>().cullingMask = 1 << LayerMask.NameToLayer(IGT_Constants.layer_3DUI);
			gameObject.transform.SetParent(pOnGui_3dObj_Hero[i].transform);
			gameObject.transform.localPosition = new Vector3(-0.013f, 0.504f, 0.454f);
			gameObject.transform.localRotation = Quaternion.Euler(new Vector3(178.558f, -10.687f, -0.0279f));
			pOnGui_3dObj_Hero[i].SetActive(false);
		}
		Camera camera = UnityEngine.Object.Instantiate(Camera.main);
		UnityEngine.Object.Destroy(camera.GetComponent<AudioListener>());
		UnityEngine.Object.Destroy(camera.GetComponent<FlareLayer>());
		UnityEngine.Object.Destroy(camera.GetComponent<IGT_CamControl>());
		camera.name = "3duicam";
		camera.clearFlags = CameraClearFlags.Depth;
		camera.cullingMask &= -2 << LayerMask.NameToLayer(IGT_Constants.layer_Characters);
		camera.cullingMask |= 1 << LayerMask.NameToLayer(IGT_Constants.layer_3DUI);
		camera.depth = 0f;
		camera.transform.position = new Vector3(0.743f, 0.582f, -70.45f);
		camera.transform.rotation = Quaternion.Euler(new Vector3(3.611f, 0f, 0f));
		camera.orthographic = true;
		camera.orthographicSize = 0.5f;
		camera.nearClipPlane = 0.01f;
		camera.farClipPlane = 1.15f;
		camera.rect = new Rect(0f, 0f, 1f, 0.86f);
		camera.useOcclusionCulling = true;
		pOnGUI_3dObj_Camera = GameObject.Find(camera.name);
		pOnGUI_3dObj_Camera.tag = "Untagged";
		pOnGUI_3dObj_Camera.SetActive(false);
	}

	public static void InstantiateCharacter_select()
	{
		menu_btn_rotAng = 2f;
		coin_move = new IGT_Animator();
		mov_btn = false;
		int num = 5;
		characters_List = new GameObject[num];
		CS_hero_anim = new Animator[num];
		ang_btwn_Characters = 20f;
		Character_Buy_Coins = new int[num];
		ready_character_idx = new int[num];
		coins_ary = 10;
		coin_curve = new Vector2[coins_ary];
		coin_move_tym = new float[coins_ary];
		coin_tmp_tym = new float[coins_ary];
		coin_tmp_tym[0] = 0.008f;
		for (int i = 1; i < coins_ary; i++)
		{
			coin_tmp_tym[i] = coin_tmp_tym[i - 1] + 0.02f;
		}
		character_slogans = new string[6];
		character_slogans[0] = string.Empty;
		character_slogans[1] = "Super Agile";
		character_slogans[2] = "More Stamina";
		character_slogans[3] = "Champion";
		character_slogans[4] = "Special One";
		Character_Buy_Coins[0] = 0;
		Character_Buy_Coins[1] = 100000;
		Character_Buy_Coins[2] = 500000;
		Character_Buy_Coins[3] = 1000000;
		Character_Buy_Coins[4] = 5000000;
		for (int j = 0; j < 5; j++)
		{
			characters_List[j] = UnityEngine.Object.Instantiate(Resources.Load(IGT_Constants.Path_Hero_Prefab + j), new Vector3(Mathf.Cos((float)Math.PI / 180f * character_angle) * characters_circle_radius, -1000.19f, Mathf.Sin((float)Math.PI / 180f * character_angle) * characters_circle_radius), Quaternion.Euler(0f, 180f - (float)j * 20f, 0f)) as GameObject;
			SkinnedMeshRenderer componentInChildren = characters_List[j].GetComponentInChildren<SkinnedMeshRenderer>();
			componentInChildren.material = (Material)Resources.Load(IGT_Constants.Path_HeroMaterials + j, typeof(Material));
			pHero.setLayerToAllChildrens(characters_List[j], IGT_Constants.layer_selection);
			characters_List[j].tag = "Untagged";
			characters_List[j].name = "option_" + j;
			UnityEngine.Object.Destroy(characters_List[j].GetComponent<IGT_AIPlayer>());
			UnityEngine.Object.Destroy(characters_List[j].GetComponent<IGT_AIPlayerAnimStateCtrl>());
			UnityEngine.Object.Destroy(characters_List[j].GetComponent<BoxCollider>());
			character_angle += ang_btwn_Characters;
		}
		for (int k = 0; k < num; k++)
		{
			characters_List[k].transform.localScale = new Vector3(characters_List[k].transform.localScale.x + 0.085f, characters_List[k].transform.localScale.y + 0.085f, characters_List[k].transform.localScale.z + 0.085f);
			CS_hero_anim[k] = characters_List[k].GetComponent<Animator>();
			CS_hero_anim[k].runtimeAnimatorController = Resources.Load("Controller/Anim_menu") as RuntimeAnimatorController;
			characters_List[k].SetActive(false);
			characters_List[k].GetComponent<Animator>().applyRootMotion = false;
		}
		HS_selectionCamera = UnityEngine.Object.Instantiate(Camera.main);
		UnityEngine.Object.Destroy(HS_selectionCamera.GetComponent<AudioListener>());
		UnityEngine.Object.Destroy(HS_selectionCamera.GetComponent<FlareLayer>());
		UnityEngine.Object.Destroy(HS_selectionCamera.GetComponent<IGT_CamControl>());
		HS_selectionCamera.name = "s_3dcam";
		HS_selectionCamera.clearFlags = CameraClearFlags.Depth;
		HS_selectionCamera.cullingMask |= 1 << LayerMask.NameToLayer(IGT_Constants.layer_selection);
		HS_selectionCamera.depth = 0f;
		HS_selectionCamera.transform.position = new Vector3(2.7427f, -1000.4f, -2.3f);
		HS_selectionCamera.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
		HS_selectionCamera.orthographic = true;
		HS_selectionCamera.orthographicSize = 1f;
		HS_selectionCamera.nearClipPlane = 0.3f;
		HS_selectionCamera.farClipPlane = 1.44f;
		HS_selectionCamera.rect = new Rect(0f, 0f, 1f, 1f);
		HS_selectionCamera.useOcclusionCulling = true;
		heroSelection_onGUICam = GameObject.Find(HS_selectionCamera.name);
		heroSelection_onGUICam.tag = "Untagged";
		lt = new GameObject("hero_light");
		lt.AddComponent<Light>();
		lt1 = lt.GetComponent<Light>();
		lt.transform.rotation = Quaternion.Euler(new Vector3(-19.39f, -0.41f, -11.93f));
		lt1.type = LightType.Directional;
		lt1.color = Color.white;
		lt1.intensity = 0.8f;
		lt1.cullingMask |= 1 << LayerMask.NameToLayer(IGT_Constants.layer_selection);
		lt.transform.parent = heroSelection_onGUICam.transform;
		heroSelection_onGUICam.SetActive(false);
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_hero_purchase))
		{
			IGT_Constants.hero_purchase_id = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_hero_purchase, "1~0~0~0~0");
			string[] array = IGT_Constants.hero_purchase_id.Split('~');
			for (int l = 0; l < array.GetLength(0); l++)
			{
				ready_character_idx[l] = int.Parse(array[l]);
			}
		}
		else
		{
			ready_character_idx[0] = 1;
			ready_character_idx[1] = 0;
			ready_character_idx[2] = 0;
			ready_character_idx[3] = 0;
			ready_character_idx[4] = 0;
			string value = "1~0~0~0~0";
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_hero_purchase, value);
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.playerPref_hero_menu))
		{
			IGT_Constants.play_hero_idx = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_hero_menu, 0);
			playing_character = IGT_Constants.play_hero_idx;
			HScam_cur_angle = (float)playing_character * ang_btwn_Characters + HScam_start_angle;
		}
		else
		{
			playing_character = 0;
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_hero_menu, playing_character);
		}
		pHero.changeCharacter(playing_character);
		IGT_Preference.getInstance()._SaveAll();
	}

	private void select_CurBustedListDatas()
	{
		rect_Gameover_Busted_Face = new Rect[IGT_Constants.AIPlayer_FacePicx.Length];
		Rect rect = new Rect(IGT_UIcommonFunc.ScaleX(45f), IGT_UIcommonFunc.ScaleY(235f), IGT_UIcommonFunc.ScaleX(28f), IGT_UIcommonFunc.ScaleY(28f));
		float num = IGT_UIcommonFunc.ScaleX(-5f);
		float num2 = IGT_UIcommonFunc.ScaleY(-10f);
		Vector2 vector = Vector2.zero;
		rect_Gameover_Busted_Badge = new Rect[IGT_Constants.AIPlayer_FacePicx.Length];
		Vector2 vector2 = new Vector2(IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleY(14f));
		Vector2 vector3 = new Vector2(IGT_UIcommonFunc.ScaleX(4f), IGT_UIcommonFunc.ScaleY(14f));
		for (int i = 0; i < 10; i++)
		{
			if (i == 0)
			{
				rect_Gameover_Busted_Face[i] = rect;
				rect_Gameover_Busted_Badge[i] = new Rect(rect_Gameover_Busted_Face[i].x + vector3.x, rect_Gameover_Busted_Face[i].y + vector3.y, vector2.x, vector2.y);
				vector = new Vector2(rect_Gameover_Busted_Face[i].x, rect_Gameover_Busted_Face[i].y);
			}
			else if (i % 2 == 0)
			{
				rect_Gameover_Busted_Face[i] = new Rect(vector.x + rect.width + num, vector.y + rect.height + num2, rect.width, rect.height);
				rect_Gameover_Busted_Badge[i] = new Rect(rect_Gameover_Busted_Face[i].x + vector3.x, rect_Gameover_Busted_Face[i].y + vector3.y, vector2.x, vector2.y);
				vector = new Vector2(rect_Gameover_Busted_Face[i].x, rect_Gameover_Busted_Face[i].y);
			}
			else
			{
				rect_Gameover_Busted_Face[i] = new Rect(vector.x - rect.width - num, vector.y + rect.height + num2, rect.width, rect.height);
				rect_Gameover_Busted_Badge[i] = new Rect(rect_Gameover_Busted_Face[i].x - vector3.x - IGT_UIcommonFunc.ScaleX(22f), rect_Gameover_Busted_Face[i].y + vector3.y, vector2.x, vector2.y);
				vector = new Vector2(rect_Gameover_Busted_Face[i].x, rect_Gameover_Busted_Face[i].y);
			}
		}
	}

	private static void deleteScrollDatas(string key)
	{
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(key))
		{
			IGT_Preference.getInstance()._Delete_GivenKey(key);
		}
	}

	private static void saveScrollDatas(List<IGT_ScrollData> pTempDatas, string key)
	{
		deleteScrollDatas(key);
		if (pTempDatas.Count > 0)
		{
			string text = null;
			for (int i = 0; i < pTempDatas.Count; i++)
			{
				text = ((i != pTempDatas.Count - 1) ? (text + JsonUtility.ToJson(pTempDatas.ElementAt(i)) + "~") : (text + JsonUtility.ToJson(pTempDatas.ElementAt(i))));
			}
			IGT_Preference.getInstance()._Set(key, text);
		}
	}

	private static List<IGT_ScrollData> retriveScrollDatas(string key)
	{
		if (!IGT_Preference.getInstance()._isKey_AlreadyPresent(key))
		{
			return null;
		}
		string text = IGT_Preference.getInstance()._Get(key, "null");
		string[] array = text.Split('~');
		List<IGT_ScrollData> list = new List<IGT_ScrollData>(4);
		for (int i = 0; i < array.Length; i++)
		{
			list.Add(JsonUtility.FromJson<IGT_ScrollData>(array[i]));
		}
		return list;
	}

	private void Update()
	{
		Touch[] touches = Input.touches;
		for (int i = 0; i < touches.Length; i++)
		{
			Touch touch = touches[i];
			pTouchPositon = touch.position;
			pTouchPhase = touch.phase;
			CS_touchPosition = pTouchPositon;
			CS_touchPhase = pTouchPhase;
			ButtonTouchChecking();
		}
		// PC 鼠标模拟触摸（支持鼠标点击按钮）
		if (Input.touches.Length == 0)
		{
			if (Input.GetMouseButtonDown(0))
			{
				pTouchPositon = Input.mousePosition;
				pTouchPhase = TouchPhase.Began;
				CS_touchPosition = pTouchPositon;
				CS_touchPhase = pTouchPhase;
				ButtonTouchChecking();
			}
			else if (Input.GetMouseButton(0))
			{
				pTouchPositon = Input.mousePosition;
				pTouchPhase = TouchPhase.Moved;
				CS_touchPosition = pTouchPositon;
				CS_touchPhase = pTouchPhase;
			}
			else if (Input.GetMouseButtonUp(0))
			{
				pTouchPositon = Input.mousePosition;
				pTouchPhase = TouchPhase.Ended;
				CS_touchPosition = pTouchPositon;
				CS_touchPhase = pTouchPhase;
				ButtonTouchChecking();
			}
		}
		if ((nScreenMode == 7 && bShowMissionTapToContinue) || (pHero.nMissionID == 13 && bBringBackDemoTapToContinueAlert && Time.time - fBringBack_Demo__TaptoContinue_StartTime > 3f))
		{
			pHero.TchObj.TouchProcessingArea();
			if (IGT_Hero.userInputQueue.Count > 0 && IGT_Hero.userInputQueue.Dequeue() == 5)
			{
				IGT_Hero.userInputQueue.Clear();
				if (nScreenMode == 7)
				{
					bShowMissionTapToContinue = false;
					pAnim_menu_LeaderBoard.resetAllValues();
					pAnim_menu_LeaderBoard.setIsReverse(true);
				}
				else if (pHero.nMissionID == 13 && bBringBackDemoTapToContinueAlert && nScreenMode == 1)
				{
					bBringBackDemoTapToContinueAlert = false;
					freezeGame(false);
				}
				pHero.playSound(6);
			}
		}
		if (nScreenMode == 12)
		{
			if (heroSelection_onGUICam.activeSelf)
			{
				playing_character = character_Selection_movement(CS_touchPosition.x, (float)Screen.height - CS_touchPosition.y, CS_touchPhase);
			}
		}
		else if (((nScreenMode == 1 && pHero.nGameMode == 0) || (nPrevScreenMode == 1 && (nScreenMode == 5 || nScreenMode == 10 || nScreenMode == 4))) && audioclipstartTime + audioclipLength - 4f < Time.time && audioclipstartTime != 9999f)
		{
			audioclipstartTime = 9999f;
			pHero.InvokeRepeating("StopMusicWithFadeAndPlayAnother", 0f, 0.1f);
		}
		if (bScrollAnim)
		{
			if (nScreenMode == 6)
			{
				purchaseWindow_CurPos.y = IGT_UIcommonFunc.reScaleY(IGT_EaseFunction.Quad_easeOut(fScrollAnimTime, purchaseWindow_ScrollviewRectMinY, purchaseWindow_ScrollviwRectMaxY, fScrollAnimTotTime));
			}
			else if (nScreenMode == 5 && nGameoverScrollType == 2)
			{
				GameoverScroll_CurPos.y = IGT_UIcommonFunc.reScaleY(IGT_EaseFunction.Quad_easeOut(fScrollAnimTime, GameoverScroll_ScrollviewRectMinY, GameoverScroll_ScrollviwRectMaxY, fScrollAnimTotTime));
			}
			else if (bHS_mailbox)
			{
				MailBoxScroll_CurPos.y = IGT_UIcommonFunc.reScaleY(IGT_EaseFunction.Quad_easeOut(fScrollAnimTime, MailBoxScroll_ScrollviewRectMinY, MailBoxScroll_ScrollviwRectMaxY, fScrollAnimTotTime));
			}
			else if (bHS_sendlife)
			{
				SendLifeScroll_CurPos.y = IGT_UIcommonFunc.reScaleY(IGT_EaseFunction.Quad_easeOut(fScrollAnimTime, SendLifeScroll_ScrollviewRectMinY, SendLifeScroll_ScrollviwRectMaxY, fScrollAnimTotTime));
			}
			else if (bHS_asklife)
			{
				AskLifeScroll_CurPos.y = IGT_UIcommonFunc.reScaleY(IGT_EaseFunction.Quad_easeOut(fScrollAnimTime, AskLifeScroll_ScrollviewRectMinY, AskLifeScroll_ScrollviwRectMaxY, fScrollAnimTotTime));
			}
			fScrollAnimTime += Time.deltaTime;
			if (fScrollAnimTime >= fScrollAnimTotTime)
			{
				bScrollAnim = false;
				if (nScreenMode == 6)
				{
					pScroller_PuchaseWindow.forceStopFlingAction();
				}
				else if (nScreenMode == 5 && nGameoverScrollType == 2)
				{
					pScroller_GameoverScroll.forceStopFlingAction();
				}
				else if (bHS_mailbox)
				{
					pScroller_MailBoxScroll.forceStopFlingAction();
				}
				else if (bHS_sendlife)
				{
					pScroller_SendLifeScroll.forceStopFlingAction();
				}
				else if (bHS_asklife)
				{
					pScroller_AskLifeScroll.forceStopFlingAction();
				}
			}
		}
		if (nScreenMode == 0 && pFacebook.isFBLoginSucess() && !bHS_mailbox && (double)Time.time >= timeDiff + timeDifference * 60.0)
		{
			pFacebook.ProcessAppRequest(ProcessAppRequestComplete);
			timeDiff = Time.time;
			dMailBoxisProcessing = false;
			dMailBoxProcessedCount = 0;
			dMailBoxSentCount = 0;
		}
		if (isPendingfbShare == 1 && currentTimeSecs() - fbShareTime >= 30)
		{
			pHero.pIGt_LifeCalc.forceAddLifeCount(IGT_Constants.nFBShareLife);
			IGT_Constants.fbText = "+" + IGT_Constants.nFBShareLife + " Life Added";
			IGT_Preference.getInstance()._Set(IGT_Constants.pendingFBShare, 0);
			isPendingfbShare = 0;
		}
		else if (isPendingwhatsappShare == 1 && currentTimeSecs() - whatsappShareTime >= 30)
		{
			pHero.pIGt_LifeCalc.forceAddLifeCount(IGT_Constants.nWhatsappShareLife);
			IGT_Constants.whatsAppText = "+" + IGT_Constants.nWhatsappShareLife + " Life Added";
			IGT_Preference.getInstance()._Set(IGT_Constants.pendingwhatsAppShare, 0);
			isPendingwhatsappShare = 0;
		}
		else if (isPendingsmsShare == 1 && currentTimeSecs() - smsShareTime >= 30)
		{
			pHero.pIGt_LifeCalc.forceAddLifeCount(IGT_Constants.nSMSShareLife);
			IGT_Constants.smsText = "+" + IGT_Constants.nSMSShareLife + " Life Added";
			IGT_Preference.getInstance()._Set(IGT_Constants.pendingSMSShare, 0);
			isPendingsmsShare = 0;
		}
		else if (isPendinginstaShare == 1 && currentTimeSecs() - instaShareTime >= 30)
		{
			pHero.pIGt_LifeCalc.forceAddLifeCount(IGT_Constants.nInstaShareLife);
			IGT_Constants.instaText = "+" + IGT_Constants.nInstaShareLife + " Life Added";
			IGT_Preference.getInstance()._Set(IGT_Constants.pendingInstaShare, 0);
			isPendinginstaShare = 0;
		}
		else if (isPendingmailShare == 1 && currentTimeSecs() - mailShareTime >= 30)
		{
			pHero.pIGt_LifeCalc.forceAddLifeCount(IGT_Constants.nMailShareLife);
			IGT_Constants.mailText = "+" + IGT_Constants.nMailShareLife + " Life Added";
			IGT_Preference.getInstance()._Set(IGT_Constants.pendingMailShare, 0);
			isPendingmailShare = 0;
		}
		else if (isPendingtwitterShare == 1 && currentTimeSecs() - twitterShareTime >= 30)
		{
			pHero.pIGt_LifeCalc.forceAddLifeCount(IGT_Constants.nTwitterShareLife);
			IGT_Constants.twitterText = "+" + IGT_Constants.nTwitterShareLife + " Life Added";
			IGT_Preference.getInstance()._Set(IGT_Constants.pendingTwitterShare, 0);
			isPendingtwitterShare = 0;
		}
	}

	private void ButtonTouchChecking()
	{
		float x = pTouchPositon.x;
		float num = (float)Screen.height - pTouchPositon.y;
		if (bNoInternetAlert)
		{
			But_NoInternetAlertOK.checkBounce(x, num, pTouchPhase);
			return;
		}
		if (bPostFBAlert && !pRateit.bShowRateItAlert)
		{
			But_postFB_Yes.checkBounce(x, num, pTouchPhase);
			But_postFB_No.checkBounce(x, num, pTouchPhase);
			return;
		}
		if (bAchievementAlert)
		{
			if (pAnim_GAchievement.isAnimFinished())
			{
				But_achievementalert_close.checkBounce(x, num, pTouchPhase);
			}
			return;
		}
		if (bNoMoreLiveAlert)
		{
			if (pAnim_Alert.isAnimFinished())
			{
				But_NoLives_Close.checkBounce(x, num, pTouchPhase);
				But_NoLives_AskFriends.checkBounce(x, num, pTouchPhase);
				But_NoLives_GetFree.checkBounce(x, num, pTouchPhase);
				But_NoLives_Purchase1.checkBounce(x, num, pTouchPhase);
				But_NoLives_Purchase2.checkBounce(x, num, pTouchPhase);
				But_NoLives_Purchase3.checkBounce(x, num, pTouchPhase);
			}
			return;
		}
		if (bHS_asklife)
		{
			if (!pAnim_MailBox.isAnimFinished())
			{
				return;
			}
			Touch[] touches = Input.touches;
			foreach (Touch touch in touches)
			{
				if (!bScrollAnim && fbList.Count - 1 > 4)
				{
					pScroller_AskLifeScroll.handleTouch(touch, ScrollViewRect_MailBoxScroll);
				}
			}
			But_MailBox_Close.checkBounce(x, num, pTouchPhase);
			if (pFacebook.isFBLoginSucess())
			{
				if (fbList != null && fbList.Count - 1 > 0)
				{
					But_AskLife_Accept.checkBounce(x, num, pTouchPhase);
					But_AskLife_CheckAll.checkBounce(x, num, pTouchPhase);
				}
				else
				{
					But_MailBox_FBInvite.checkBounce(x, num, pTouchPhase);
				}
			}
			if (!pFacebook.isFBLoginSucess())
			{
				But_MailBox_FBConnect.checkBounce(x, num, pTouchPhase);
			}
			askLifecheckBoxBtnEvent();
			return;
		}
		switch (nScreenMode)
		{
		case 0:
			if (bSorry)
			{
				But_sorryAlert_Quit.checkBounce(x, num, pTouchPhase);
				break;
			}
			if (bIsShowGPluseLoginAlert)
			{
				checkBounceGooglePluseAlert(x, num);
				break;
			}
			if (bShowNickName)
			{
				btnNickNameOk.checkBounce(x, num, pTouchPhase);
				break;
			}
			if (bInappAlert)
			{
				checkAlertWin(nAlertWin, x, num, pTouchPhase);
			}
			else if (bleaderboardHSbtnClick)
			{
				But_HS_GoogleLB.checkBounce(x, num, pTouchPhase);
				But_HS_FBLB.checkBounce(x, num, pTouchPhase);
			}
			else if (bHS_FBbtnClick)
			{
				But_FBLB_AlertChase.checkBounce(x, num, pTouchPhase);
				But_FBLB_AlertMission.checkBounce(x, num, pTouchPhase);
				But_FBLB_Friends.checkBounce(x, num, pTouchPhase);
				But_FBLB_Global.checkBounce(x, num, pTouchPhase);
				But_FBLB_Alertclose.checkBounce(x, num, pTouchPhase);
				if (nLeaderBoard_Mission_DispState == 1 || nLeaderBoard_Mission_DispState == 3 || nLeaderBoard_Chase_DispState == 1 || nLeaderBoard_Chase_DispState == 3)
				{
					But_GetScoreRetry.checkBounce(x, num, pTouchPhase);
				}
				else if (nLeaderBoard_Mission_DispState == 2 || nLeaderBoard_Chase_DispState == 2)
				{
					if (!pFacebook.isFBLoginSucess() && ((!bFB_MsnEnablebtnClick && !bFBLBglobal) || (bFB_MsnEnablebtnClick && !bFBLBglobal)))
					{
						But_MailBox_FBConnect.checkBounce(x, num, pTouchPhase);
					}
					else if (pFacebook.isFBLoginSucess() && ((!bFB_MsnEnablebtnClick && !bFBLBglobal && bDrawInvite_Chase) || (bFB_MsnEnablebtnClick && !bFBLBglobal && bDrawInvite_Mission)))
					{
						btnFBLeaderBoardInvite.checkBounce(x, num, pTouchPhase);
					}
				}
			}
			else if (bHS_GooglebtnClick)
			{
				checkBounceGooglePluseAlert(x, num);
			}
			else if (bHS_mailbox)
			{
				if (pAnim_MailBox.isAnimFinished())
				{
					Touch[] touches2 = Input.touches;
					foreach (Touch touch2 in touches2)
					{
						if (!bScrollAnim && listAskSend.Count > 4)
						{
							pScroller_MailBoxScroll.handleTouch(touch2, ScrollViewRect_MailBoxScroll);
						}
					}
					But_MailBox_Close.checkBounce(x, num, pTouchPhase);
					if (pFacebook.isFBLoginSucess())
					{
						if (listAskSend.Count > 0 && !dMailBoxisProcessing)
						{
							But_Mail_Accept.checkBounce(x, num, pTouchPhase);
							But_Mail_CheckAll.checkBounce(x, num, pTouchPhase);
						}
						else
						{
							But_MailBox_FBInvite.checkBounce(x, num, pTouchPhase);
						}
					}
					if (!pFacebook.isFBLoginSucess())
					{
						But_MailBox_FBConnect.checkBounce(x, num, pTouchPhase);
					}
					mailBoxcheckBoxBtnEvent();
				}
			}
			else if (bHS_sendlife)
			{
				if (pAnim_MailBox.isAnimFinished())
				{
					But_MailBox_Close.checkBounce(x, num, pTouchPhase);
				}
				if (!pFacebook.isFBLoginSucess())
				{
					But_MailBox_FBConnect.checkBounce(x, num, pTouchPhase);
				}
				if (pAnim_MailBox.isAnimFinished())
				{
					Touch[] touches3 = Input.touches;
					foreach (Touch touch3 in touches3)
					{
						if (!bScrollAnim && fbList.Count - 1 > 4)
						{
							pScroller_SendLifeScroll.handleTouch(touch3, ScrollViewRect_MailBoxScroll);
						}
					}
					if (pFacebook.isFBLoginSucess())
					{
						if (fbList != null && fbList.Count - 1 > 0)
						{
							But_SendLife_Accept.checkBounce(x, num, pTouchPhase);
							But_SendLife_CheckAll.checkBounce(x, num, pTouchPhase);
						}
						else
						{
							But_MailBox_FBInvite.checkBounce(x, num, pTouchPhase);
						}
					}
					sendLifecheckBoxBtnEvent();
				}
			}
			else if (bHS_allshare)
			{
				if (pAnim_MailBox.isAnimFinished())
				{
					btn_fbLog.checkBounce(pTouchPositon.x, (float)Screen.height - pTouchPositon.y, pTouchPhase);
					btn_Whatsapp.checkBounce(pTouchPositon.x, (float)Screen.height - pTouchPositon.y, pTouchPhase);
					btn_MailShare.checkBounce(pTouchPositon.x, (float)Screen.height - pTouchPositon.y, pTouchPhase);
					btn_SMSShare.checkBounce(pTouchPositon.x, (float)Screen.height - pTouchPositon.y, pTouchPhase);
					btn_Twitter.checkBounce(pTouchPositon.x, (float)Screen.height - pTouchPositon.y, pTouchPhase);
					But_AllShare_Close.checkBounce(pTouchPositon.x, (float)Screen.height - pTouchPositon.y, pTouchPhase);
				}
			}
			else if (bHS_settings)
			{
				if (bShowNickName)
				{
					btnNickNameOk.checkBounce(x, num, pTouchPhase);
				}
				else if (pAnim_HS_menuBG.isAnimFinished())
				{
					But_settingsClose.checkBounce(x, num, pTouchPhase);
					But_Settings_Music.checkBounce(x, num, pTouchPhase);
					But_Settings_Sound.checkBounce(x, num, pTouchPhase);
					But_settings_Notification.checkBounce(x, num, pTouchPhase);
					if (bRestoreEnabled)
					{
						But_Settings_RestorePurchase.checkBounce(x, num, pTouchPhase);
					}
					But_Settings_FBLogout.checkBounce(x, num, pTouchPhase);
					But_Settings_EditNickName.checkBounce(x, num, pTouchPhase);
				}
			}
			else if (bHS_moregames)
			{
				btn_MoregameClose.checkBounce(x, num, pTouchPhase);
			}
			else if (!But_HS_Menu.isStartupAnimFinished())
			{
				if (bExitAlert)
				{
					But_Exit_Ok.checkBounce(x, num, pTouchPhase);
					But_Exit_Cancel.checkBounce(x, num, pTouchPhase);
				}
				else
				{
					But_HS_Chase.checkBounce(x, num, pTouchPhase);
					But_HS_Missions.checkBounce(x, num, pTouchPhase);
					But_HS_Shop.checkBounce(x, num, pTouchPhase);
					But_HS_FConnect.checkBounce(x, num, pTouchPhase);
					But_HS_Menu.checkBounce(x, num, pTouchPhase);
					But_HS_Acheivement.checkBounce(x, num, pTouchPhase);
					But_HS_AllShare.checkBounce(x, num, pTouchPhase);
					But_HS_MoreGames.checkBounce(x, num, pTouchPhase);
					But_HS_FreeLife.checkBounce(x, num, pTouchPhase);
					But_HS_LeaderBoard.checkBounce(x, num, pTouchPhase);
					But_HS_Settings.checkBounce(x, num, pTouchPhase);
					But_HS_Coin.checkBounce(x, num, pTouchPhase);
					But_HS_Key.checkBounce(x, num, pTouchPhase);
					But_HS_Life.checkBounce(x, num, pTouchPhase);
					But_HS_MailBox.checkBounce(x, num, pTouchPhase);
					But_HS_SendLife.checkBounce(x, num, pTouchPhase);
				}
			}
			if (!bLBwronganim && bleaderboardHSbtnClick && pTouchPhase == TouchPhase.Began && (pTouchPositon.x < But_HS_GoogleLB.getOriginalDimension().x || pTouchPositon.x > But_HS_GoogleLB.getOriginalDimension().width + But_HS_GoogleLB.getX() || (float)Screen.height - pTouchPositon.y < But_HS_GoogleLB.getOriginalDimension().y || (float)Screen.height - pTouchPositon.y > But_HS_GoogleLB.getOriginalDimension().height + But_HS_GoogleLB.getY()) && (pTouchPositon.x < But_HS_FBLB.getOriginalDimension().x || pTouchPositon.x > But_HS_FBLB.getOriginalDimension().width + But_HS_FBLB.getX() || (float)Screen.height - pTouchPositon.y < But_HS_FBLB.getOriginalDimension().y || (float)Screen.height - pTouchPositon.y > But_HS_FBLB.getOriginalDimension().height + But_HS_FBLB.getY()))
			{
				pAnim_HS_LeaderBoard.resetAllValues();
				pAnim_HS_LeaderBoard.setIsReverse(true);
				bLBwronganim = true;
			}
			break;
		case 7:
			if (bShowMissionTapToContinue && nGetCurrentPlatform() == 2)
			{
				But_MissonInfoTapToContinue.checkBounce(x, num, pTouchPhase);
			}
			break;
		case 3:
			But_Survive_UseKey.checkBounce(x, num, pTouchPhase);
			But_Survive_TotKey.checkBounce(x, num, pTouchPhase);
			if (bSuriviveRewardedVideoAvailable && string.Equals(getRewardedVideoTimeIntervel(), "00:00"))
			{
				But_Survive_Watchvideo.checkBounce(x, num, pTouchPhase);
			}
			break;
		case 2:
			if (bAbortAlert)
			{
				But_Abort_Ok.checkBounce(x, num, pTouchPhase);
				But_Abort_Cancel.checkBounce(x, num, pTouchPhase);
			}
			else
			{
				But_Pause_Back.checkBounce(x, num, pTouchPhase);
				But_Pause_Boost.checkBounce(x, num, pTouchPhase);
				But_Pause_Resume.checkBounce(x, num, pTouchPhase);
			}
			break;
		case 16:
			But_NotEnoughKeys_Close.checkBounce(x, num, pTouchPhase);
			But_NotEnoughKeys_Purchase1.checkBounce(x, num, pTouchPhase);
			But_NotEnoughKeys_Purchase2.checkBounce(x, num, pTouchPhase);
			But_NotEnoughKeys_Purchase3.checkBounce(x, num, pTouchPhase);
			break;
		case 5:
			if (pRateit.bShowRateItAlert)
			{
				pRateit.ButtonBounceChecking(pTouchPositon.x, (float)Screen.height - pTouchPositon.y, pTouchPhase);
			}
			else
			{
				if (!pAnim_HS_menuBG.isAnimFinished() && pHero.nGameMode == 0)
				{
					break;
				}
				if (pHero.nGameMode == 1)
				{
					But_MC_FB_Friends.checkBounce(x, num, pTouchPhase);
					But_MC_FB_Global.checkBounce(x, num, pTouchPhase);
					if (nLeaderBoard_Mission_DispState == 1 || nLeaderBoard_Mission_DispState == 3)
					{
						But_GetScoreRetry.checkBounce(x, num, pTouchPhase);
					}
					else if (nLeaderBoard_Mission_DispState == 2)
					{
						if (!pFacebook.isFBLoginSucess() && nMC_ScrollType == 0)
						{
							But_MailBox_FBConnect.checkBounce(x, num, pTouchPhase);
						}
						else if (pFacebook.isFBLoginSucess() && nMC_ScrollType == 0 && bDrawInvite_Mission)
						{
							btnFBLeaderBoardInvite.checkBounce(x, num, pTouchPhase);
						}
					}
				}
				else
				{
					if (nGameoverScrollType == 2)
					{
						Touch[] touches5 = Input.touches;
						foreach (Touch touch5 in touches5)
						{
							if (!bScrollAnim)
							{
								pScroller_GameoverScroll.handleTouch(touch5, ScrollViewRect_GameoverScreen);
							}
						}
					}
					else if (nLeaderBoard_Chase_DispState == 1 || nLeaderBoard_Chase_DispState == 3)
					{
						But_GetScoreRetry.checkBounce(x, num, pTouchPhase);
					}
					else if (nLeaderBoard_Chase_DispState == 2)
					{
						if (!pFacebook.isFBLoginSucess() && nGameoverScrollType == 0)
						{
							But_MailBox_FBConnect.checkBounce(x, num, pTouchPhase);
						}
						else if (pFacebook.isFBLoginSucess() && nGameoverScrollType == 0 && bDrawInvite_Chase)
						{
							btnFBLeaderBoardInvite.checkBounce(x, num, pTouchPhase);
						}
					}
					But_FbScroll.checkBounce(x, num, pTouchPhase);
					But_TopchaseScroll.checkBounce(x, num, pTouchPhase);
					But_BustedScroll.checkBounce(x, num, pTouchPhase);
				}
				if (pHero.nGameMode == 1 && pHero.pMissionData.nLevelStarCount != -1)
				{
					But_MissonCompleted_Next.checkBounce(x, num, pTouchPhase);
					But_MissonCompleted_Retry.checkBounce(x, num, pTouchPhase);
					But_MissonCompleted_Home.checkBounce(x, num, pTouchPhase);
					break;
				}
				But_GameoverscreenHome.checkBounce(x, num, pTouchPhase);
				But_GameoverscreenRestart.checkBounce(x, num, pTouchPhase);
				if (bSkipButNeeded && bSkipButEnable)
				{
					But_MissionFailedSkip.checkBounce(x, num, pTouchPhase);
				}
			}
			break;
		case 6:
			if (bUpgradeAlert)
			{
				But_Upgrade_Store.checkBounce(x, num, pTouchPhase);
				But_Upgrade_Cancel.checkBounce(x, num, pTouchPhase);
			}
			else if (bHS_moregames)
			{
				btn_MoregameClose.checkBounce(x, num, pTouchPhase);
			}
			else if (!bBoostUpgradeAnim)
			{
				Touch[] touches4 = Input.touches;
				foreach (Touch touch4 in touches4)
				{
					if (!bScrollAnim)
					{
						pScroller_PuchaseWindow.handleTouch(touch4, ScrollViewRect_purchaseWindow);
					}
				}
				But_Store.checkBounce(x, num, pTouchPhase);
				But_Combo.checkBounce(x, num, pTouchPhase);
				But_Boost.checkBounce(x, num, pTouchPhase);
				But_Free.checkBounce(x, num, pTouchPhase);
				if (nGetCurrentPlatform() != 0)
				{
					But_BackpurchaseWindow.checkBounce(x, num, pTouchPhase);
				}
				buyButevents_PurchaseWindow();
			}
			if (pMoregame.webViewObject != null && pMoregame.webViewObject.GetVisibility())
			{
				btn_MoregameClose.checkBounce(x, num, pTouchPhase);
			}
			break;
		case 1:
			if (pHero.nGameMode == 1 && pHero.nMissionID == 13)
			{
				if (bBringBackDemoTapToContinueAlert)
				{
					if (Time.time - fBringBack_Demo__TaptoContinue_StartTime > 3f)
					{
						But_MissonInfoTapToContinue.checkBounce(x, num, pTouchPhase);
					}
				}
				else
				{
					But_Gamescreen_Pause.checkBounce(x, num, pTouchPhase);
				}
			}
			else
			{
				But_Gamescreen_Pause.checkBounce(x, num, pTouchPhase);
			}
			break;
		case 10:
			if (!pAnim_HS_menuBG.isAnimFinished())
			{
				break;
			}
			if (pRateit.bShowRateItAlert)
			{
				pRateit.ButtonBounceChecking(pTouchPositon.x, (float)Screen.height - pTouchPositon.y, pTouchPhase);
				break;
			}
			if (bChaseLockedAlert)
			{
				But_ChsUnlockAlert_Play.checkBounce(x, num, pTouchPhase);
				But_ChsUnlockAlert_Close.checkBounce(x, num, pTouchPhase);
				break;
			}
			But_MissonCompleted_Next.checkBounce(x, num, pTouchPhase);
			But_MissonCompleted_Retry.checkBounce(x, num, pTouchPhase);
			But_MissonCompleted_Home.checkBounce(x, num, pTouchPhase);
			But_MC_FB_Friends.checkBounce(x, num, pTouchPhase);
			But_MC_FB_Global.checkBounce(x, num, pTouchPhase);
			if (nLeaderBoard_Mission_DispState == 1 || nLeaderBoard_Mission_DispState == 3)
			{
				But_GetScoreRetry.checkBounce(x, num, pTouchPhase);
			}
			else if (nLeaderBoard_Mission_DispState == 2)
			{
				if (!pFacebook.isFBLoginSucess() && nMC_ScrollType == 0)
				{
					But_MailBox_FBConnect.checkBounce(x, num, pTouchPhase);
				}
				else if (pFacebook.isFBLoginSucess() && nMC_ScrollType == 0 && bDrawInvite_Mission)
				{
					btnFBLeaderBoardInvite.checkBounce(x, num, pTouchPhase);
				}
			}
			break;
		case 9:
			if (!bNoMoreLiveAlert && !bHS_asklife)
			{
				pMapObj.mapButtonEventChecking(pTouchPositon, pTouchPhase, buttonClickPoint);
				But_HS_Coin.checkBounce(x, num, pTouchPhase);
				But_HS_Key.checkBounce(x, num, pTouchPhase);
				But_HS_Life.checkBounce(x, num, pTouchPhase);
				But_Mapback.checkBounce(x, num, pTouchPhase);
			}
			break;
		case 12:
			if (bLeaderBoardbtnClick)
			{
				But_Menu_GoogleLB.checkBounce(x, num, pTouchPhase);
				But_Menu_FBLB.checkBounce(x, num, pTouchPhase);
			}
			else if (bFBbtnClick)
			{
				But_FBLB_AlertChase.checkBounce(x, num, pTouchPhase);
				But_FBLB_AlertMission.checkBounce(x, num, pTouchPhase);
				But_FBLB_Friends.checkBounce(x, num, pTouchPhase);
				But_FBLB_Global.checkBounce(x, num, pTouchPhase);
				But_FBLB_Alertclose.checkBounce(x, num, pTouchPhase);
				if (nLeaderBoard_Mission_DispState == 1 || nLeaderBoard_Mission_DispState == 3 || nLeaderBoard_Chase_DispState == 1 || nLeaderBoard_Chase_DispState == 3)
				{
					But_GetScoreRetry.checkBounce(x, num, pTouchPhase);
				}
				else if (nLeaderBoard_Mission_DispState == 2 || nLeaderBoard_Chase_DispState == 2)
				{
					if (!pFacebook.isFBLoginSucess() && ((!bFB_MsnEnablebtnClick && !bFBLBglobal) || (bFB_MsnEnablebtnClick && !bFBLBglobal)))
					{
						But_MailBox_FBConnect.checkBounce(x, num, pTouchPhase);
					}
					else if (pFacebook.isFBLoginSucess() && ((!bFB_MsnEnablebtnClick && !bFBLBglobal && bDrawInvite_Chase) || (bFB_MsnEnablebtnClick && !bFBLBglobal && bDrawInvite_Mission)))
					{
						btnFBLeaderBoardInvite.checkBounce(x, num, pTouchPhase);
					}
				}
			}
			else if (bGoogleLbbtnClick)
			{
				checkBounceGooglePluseAlert(x, num);
			}
			else if (bHS_allshare)
			{
				if (pAnim_MailBox.isAnimFinished())
				{
					btn_fbLog.checkBounce(pTouchPositon.x, (float)Screen.height - pTouchPositon.y, pTouchPhase);
					btn_Whatsapp.checkBounce(pTouchPositon.x, (float)Screen.height - pTouchPositon.y, pTouchPhase);
					btn_MailShare.checkBounce(pTouchPositon.x, (float)Screen.height - pTouchPositon.y, pTouchPhase);
					btn_SMSShare.checkBounce(pTouchPositon.x, (float)Screen.height - pTouchPositon.y, pTouchPhase);
					btn_Twitter.checkBounce(pTouchPositon.x, (float)Screen.height - pTouchPositon.y, pTouchPhase);
					But_AllShare_Close.checkBounce(pTouchPositon.x, (float)Screen.height - pTouchPositon.y, pTouchPhase);
				}
			}
			else if (bHS_settings)
			{
				if (bShowNickName)
				{
					btnNickNameOk.checkBounce(x, num, pTouchPhase);
				}
				else if (pAnim_HS_menuBG.isAnimFinished())
				{
					But_settingsClose.checkBounce(x, num, pTouchPhase);
					But_Settings_Music.checkBounce(x, num, pTouchPhase);
					But_Settings_Sound.checkBounce(x, num, pTouchPhase);
					But_settings_Notification.checkBounce(x, num, pTouchPhase);
					if (bRestoreEnabled)
					{
						But_Settings_RestorePurchase.checkBounce(x, num, pTouchPhase);
					}
					But_Settings_FBLogout.checkBounce(x, num, pTouchPhase);
					But_Settings_EditNickName.checkBounce(x, num, pTouchPhase);
				}
			}
			else if (bHS_moregames)
			{
				btn_MoregameClose.checkBounce(x, num, pTouchPhase);
			}
			else if (bHS_about)
			{
				if (pAnim_MailBox.isAnimFinished())
				{
					if (pTouchPhase == TouchPhase.Began)
					{
						prevTouchPos = pTouchPositon;
						bTouchEnabled = true;
					}
					else if (pTouchPhase == TouchPhase.Moved)
					{
						bTouchEnabled = true;
						checkUpdatePos(pTouchPositon);
						prevTouchPos = pTouchPositon;
					}
					else if (pTouchPhase == TouchPhase.Ended)
					{
						bTouchEnabled = false;
					}
					btn_AboutClose.checkBounce(x, num, pTouchPhase);
				}
			}
			else
			{
				But_Menu_back.checkBounce(x, num, pTouchPhase);
				But_Menu_Shop.checkBounce(x, num, pTouchPhase);
				But_Menu_LeaderBoard.checkBounce(x, num, pTouchPhase);
				But_Menu_Achievement.checkBounce(x, num, pTouchPhase);
				But_Menu_Free.checkBounce(x, num, pTouchPhase);
				But_Menu_Share.checkBounce(x, num, pTouchPhase);
				But_Menu_Settings.checkBounce(x, num, pTouchPhase);
				But_Menu_MoreGames.checkBounce(x, num, pTouchPhase);
				But_Menu_About.checkBounce(x, num, pTouchPhase);
				if (centre_character != 0)
				{
					But_Menu_left.checkBounce(x, num, pTouchPhase);
				}
				if (centre_character != 4)
				{
					But_Menu_Right.checkBounce(x, num, pTouchPhase);
				}
				if (ready_character_idx[centre_character] != 1)
				{
					But_Menu_Select.checkBounce(x, num, pTouchPhase);
				}
				else if (ready_character_idx[centre_character] == 1)
				{
					But_Menu_Ready.checkBounce(x, num, pTouchPhase);
				}
				But_Menu_Key.checkBounce(x, num, pTouchPhase);
				But_Menu_Coin.checkBounce(x, num, pTouchPhase);
				But_Menu_life.checkBounce(x, num, pTouchPhase);
			}
			if (!bLBwronganim && bLeaderBoardbtnClick && pTouchPhase == TouchPhase.Began && (pTouchPositon.x < But_Menu_GoogleLB.getOriginalDimension().x || pTouchPositon.x > But_Menu_GoogleLB.getOriginalDimension().width + But_Menu_GoogleLB.getX() || (float)Screen.height - pTouchPositon.y < But_Menu_GoogleLB.getOriginalDimension().y || (float)Screen.height - pTouchPositon.y > But_Menu_GoogleLB.getOriginalDimension().height + But_Menu_GoogleLB.getY()) && (pTouchPositon.x < But_Menu_FBLB.getOriginalDimension().x || pTouchPositon.x > But_Menu_FBLB.getOriginalDimension().width + But_Menu_FBLB.getX() || (float)Screen.height - pTouchPositon.y < But_Menu_FBLB.getOriginalDimension().y || (float)Screen.height - pTouchPositon.y > But_Menu_FBLB.getOriginalDimension().height + But_Menu_FBLB.getY()))
			{
				pAnim_menu_LeaderBoard.resetAllValues();
				pAnim_menu_LeaderBoard.setIsReverse(true);
				bLBwronganim = true;
			}
			break;
		case 4:
			But_Levelupscreen_Play.checkBounce(pTouchPositon.x, (float)Screen.height - pTouchPositon.y, pTouchPhase);
			break;
		case 8:
		case 11:
		case 13:
		case 14:
		case 15:
			break;
		}
	}

	public void gameMissionsLeveUpItems(int _levelId, int _starCount, int _score, int _gameType)
	{
		if (_gameType == 1)
		{
			pMapObj.insertLevelStarData(_levelId + 1, _starCount);
			if (_score > 0 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQAw", 0) < _score)
			{
				pLeaderBoard.OnAddScoreToLeaderBorad("CgkInKbEoZQHEAIQAw", _score);
				IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQAw", _score);
			}
			if (_levelId + 1 == 20 || _levelId + 1 == 50 || _levelId + 1 == 100 || _levelId + 1 == 250 || _levelId + 1 == 500)
			{
				IGT_Achivements.completeAchivements(1, _levelId + 1);
			}
			if (_levelId + 1 > 10)
			{
				pMapObj.getStartAchivements();
			}
		}
		else if (_score > 0 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQAg", 0) < _score)
		{
			pLeaderBoard.OnAddScoreToLeaderBorad("CgkInKbEoZQHEAIQAg", _score);
			IGT_Preference.getInstance()._Set("CgkInKbEoZQHEAIQAg", _score);
		}
		if (pHero.isConnectedInternet())
		{
			nLeaderBoard_Chase_DispState = (nLeaderBoard_Mission_DispState = 0);
			fLoadingStrtTime = Time.time;
			postScoreURL(_levelId, _score, _gameType);
		}
		else
		{
			nLeaderBoard_Chase_DispState = (nLeaderBoard_Mission_DispState = 1);
		}
	}

	private void callGetScoreFunction(int type)
	{
		getScoreFromInternet(type);
	}

	private void MapPointChecking(int _clickedLevelPoint)
	{
		pMapObj.insertLevelStarData(_clickedLevelPoint, 3);
		mapBackButtonEvents();
	}

	private void buttonClickPoint(int _clickedLevelPoint)
	{
		pHero.playSound(31, 0.5f);
		if (canPlayGameUsingLife() || _clickedLevelPoint - 1 < 5)
		{
			mission_ButtonEvents(_clickedLevelPoint - 1);
			pMapObj.destroyMapBtnObjs();
			pHero.InvokeRepeating("StopMusicWithFade", 0f, 0.1f);
		}
		else
		{
			NoMoLiveAlertScreen();
		}
	}

	private void buyButevents_PurchaseWindow()
	{
		int num = OnClickEventsInPurchaseWindow(pTouchPositon.x, (float)Screen.height - pTouchPositon.y, pTouchPhase, IGT_UIcommonFunc.ScaleY(purchaseWindow_CurPos.y), purchaseWindow_BarHeight + purchaseWindow_BarGap, ScrollViewRect_purchaseWindow, rect_purchaseBuy);
		if (num == -1 || (nPurchaseType == 1 && ((pHero.nDealComboOffer_1 == 0 && num == pHero.pPurchaseItemsData_Deals.Count - 2) || (pHero.nDealComboOffer_2 == 0 && num == pHero.pPurchaseItemsData_Deals.Count - 1))))
		{
			return;
		}
		if (nPurchaseType == 2 && pHero.pPurchaseItemsData_Boost.ElementAt(num).nCurUpgradeState < 5)
		{
			pHero.playSound(6);
			if (canUpgrade(num))
			{
				pHero.pPurchaseItemsData_Boost.ElementAt(num).nCurUpgradeState++;
				if (pHero.pPurchaseItemsData_Boost.ElementAt(num).nCurUpgradeState > 5)
				{
					pHero.pPurchaseItemsData_Boost.ElementAt(num).nCurUpgradeState = 5;
				}
				IGT_Constants.nUpgrade_CurState[num] = pHero.pPurchaseItemsData_Boost.ElementAt(num).nCurUpgradeState;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_Upgrade_CurStateKey[num], IGT_Constants.nUpgrade_CurState[num]);
				IGT_Preference.getInstance()._SaveAll();
				pHero.update_UpgradeInfo();
				if (pHero.pPurchaseItemsData_Boost.ElementAt(num).nCurUpgradeState >= 5)
				{
					return;
				}
				pHero.fBezierGroupAnimTime = 0f;
				pHero.pBezierAnimation_Group.Clear();
				bBoostUpgradeAnim = true;
				for (int i = 0; i < 10; i++)
				{
					Vector3 end = new Vector3(rect_purchaseBuy.x - IGT_UIcommonFunc.ScaleX(8f), IGT_UIcommonFunc.ScaleY(purchaseWindow_CurPos.y) + ScrollViewRect_purchaseWindow.y + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)num + rect_purchaseBuy.y + IGT_UIcommonFunc.ScaleY(2f), 0f);
					float strtWidth = IGT_UIcommonFunc.ScaleX(32f);
					float centerWidth = IGT_UIcommonFunc.ScaleX(50f);
					float endWidth = IGT_UIcommonFunc.ScaleX(20f);
					float strtHeight = IGT_UIcommonFunc.ScaleY(32f);
					float centerHeight = IGT_UIcommonFunc.ScaleY(50f);
					float endHeight = IGT_UIcommonFunc.ScaleY(20f);
					if (num == 0 || num == 8)
					{
						Vector3 strt = new Vector3(rect_KeycountPurchasewindow.x - IGT_UIcommonFunc.ScaleX(26f), rect_KeycountPurchasewindow.y - IGT_UIcommonFunc.ScaleY(6f), 0f);
						Vector3 centre = new Vector3(IGT_UIcommonFunc.ScaleX(80f), end.y + IGT_UIcommonFunc.ScaleY(10f));
						pHero.pBezierAnimation_Group.Add(new IGT_BezierAnimation(strt, centre, end, 0f, 5f, strtWidth, strtHeight, centerWidth, centerHeight, endWidth, endHeight, pIgt_Textures.GetTexture(IGT_Constants._KeyImg)));
					}
					if (num == 2 || num == 3)
					{
						Vector3 strt = new Vector3(rect_LifecountPurchasewindow.x - IGT_UIcommonFunc.ScaleX(26f), rect_LifecountPurchasewindow.y - IGT_UIcommonFunc.ScaleY(6f), 0f);
						Vector3 centre = new Vector3((strt.x + end.x) * 0.5f, end.y + IGT_UIcommonFunc.ScaleY(10f));
						pHero.pBezierAnimation_Group.Add(new IGT_BezierAnimation(strt, centre, end, 0f, 5f, strtWidth, strtHeight, centerWidth, centerHeight, endWidth, endHeight, pIgt_Textures.GetTexture(IGT_Constants._Life)));
					}
					if (num == 1 || num == 4 || num == 5 || num == 6 || num == 7)
					{
						Vector3 strt = new Vector3(rect_CoincountPurchasewindow.x - IGT_UIcommonFunc.ScaleX(30f), rect_CoincountPurchasewindow.y - IGT_UIcommonFunc.ScaleY(6f), 0f);
						Vector3 centre = new Vector3(IGT_UIcommonFunc.ScaleX(50f), (strt.y + end.y) * 0.5f);
						pHero.pBezierAnimation_Group.Add(new IGT_BezierAnimation(strt, centre, end, 0f, 5f, strtWidth, strtHeight, centerWidth, centerHeight, endWidth, endHeight, pIgt_Textures.GetTexture(IGT_Constants._CoinImg)));
					}
				}
			}
			else
			{
				bUpgradeAlert = true;
				But_Upgrade_Store.ResetAnimationDatas();
				But_Upgrade_Cancel.ResetAnimationDatas();
				pAnim_NoInternet.resetAllValues();
			}
		}
		else if (pHero.isConnectedInternet() || (nPurchaseType == 3 && num == 0 && !bRewardedVideoTimeUp))
		{
			switch (nPurchaseType)
			{
			case 0:
				pHero.playSound(6);
				pHero.StartPurchase(pHero.pPurchaseItemsData_Store[num].ProductID_GooglePlayStore);
				break;
			case 1:
				pHero.playSound(6);
				pHero.StartPurchase(pHero.pPurchaseItemsData_Deals[num].ProductID_GooglePlayStore);
				break;
			case 2:
				break;
			case 3:
				switch (num)
				{
				case 0:
					if (pHero.pIGt_LifeCalc.getCurrentLifeCount() < pHero.pIGt_LifeCalc.getTotalGivenLifeCount() && pAds.isRewardBasedVideoAvailable() && bRewardedVideoTimeUp)
					{
						pHero.playSound(6);
						pAds.ShowRewardBasedVideo();
						bRewardedVideoTimeUp = false;
					}
					break;
				case 1:
					if (!pFacebook.isFBLoginSucess())
					{
						pHero.bCanShowAdOnForeGround = false;
						pFacebook.FBLogin(FBLoginCompleted, FBLoginFailed);
					}
					else if (pFacebook.HaveFrndListPermission)
					{
						pHero.bCanShowAdOnForeGround = false;
						pFacebook.FBInvite(fbAppInviteUri, AppInviteSucess, AppInviteFailed);
					}
					else
					{
						bInviteReLogin = true;
						pHero.bCanShowAdOnForeGround = false;
						pFacebook.FBLogin(FBLoginCompleted, FBLoginFailed);
					}
					break;
				case 2:
					if (bMoreGameEnableInPurchaseWindow)
					{
						MoreGamesButtonEvents();
						pHero.playSound(6);
						fMoreGamesClickedTime = Time.time;
					}
					break;
				case 3:
					pHero.playSound(6);
					bLikeReGamePage = true;
					if (!pFacebook.isFBLoginSucess())
					{
						pFacebook.FBLogin(FBLoginCompleted, FBLoginFailed);
					}
					else
					{
						pFacebook.FBLike(IGT_Constants.gamePageID, IGT_Constants.gamePageName, likePageOpened);
					}
					break;
				case 4:
					pHero.playSound(6);
					bLikeReCompanyPage = true;
					if (!pFacebook.isFBLoginSucess())
					{
						pFacebook.FBLogin(FBLoginCompleted, FBLoginFailed);
					}
					else
					{
						pFacebook.FBLike(IGT_Constants.companyPageID, IGT_Constants.companyPageName, likePageOpened);
					}
					break;
				}
				break;
			}
		}
		else
		{
			pHero.playSound(6);
			setNoInternetAlert();
		}
	}

	private void likePageOpened(bool islikeOpened)
	{
		if (islikeOpened)
		{
			bHS_like = true;
		}
	}

	private bool canUpgrade(int idx)
	{
		bool result = false;
		string text = pHero.pPurchaseItemsData_Boost[idx].pIGT_UpgradeData.ElementAt(pHero.pPurchaseItemsData_Boost[idx].nCurUpgradeState).Amount.Replace(",", string.Empty);
		text.Trim();
		int num = int.Parse(text);
		switch (idx)
		{
		case 1:
		case 4:
		case 5:
		case 6:
		case 7:
			if (IGT_Constants.nTotNoOfCoins >= num)
			{
				IGT_Constants.nTotNoOfCoins -= num;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotCoins, IGT_Constants.nTotNoOfCoins);
				result = true;
			}
			sUpgradeAlertItemName = "Coins";
			sUpgradeAlertItemCount = (num - IGT_Constants.nTotNoOfCoins).ToString();
			break;
		case 0:
		case 8:
			if (IGT_Constants.nTotKeysCount >= num)
			{
				IGT_Constants.nTotKeysCount -= num;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotKeyCount, IGT_Constants.nTotKeysCount);
				result = true;
			}
			sUpgradeAlertItemName = "Keys";
			sUpgradeAlertItemCount = (num - IGT_Constants.nTotKeysCount).ToString();
			break;
		case 2:
		case 3:
			if (pHero.pIGt_LifeCalc.getCurrentLifeCount() >= num)
			{
				pHero.pIGt_LifeCalc.decreaseLifeCount(num);
				result = true;
			}
			sUpgradeAlertItemName = "Lives";
			sUpgradeAlertItemCount = (num - pHero.pIGt_LifeCalc.getCurrentLifeCount()).ToString();
			break;
		}
		return result;
	}

	private void mailBoxcheckBoxBtnEvent()
	{
		if (!pFacebook.isFBLoginSucess() || listAskSend.Count <= 0 || dMailBoxisProcessing)
		{
			return;
		}
		int num = OnClickEventsInPurchaseWindow(pTouchPositon.x, (float)Screen.height - pTouchPositon.y, pTouchPhase, IGT_UIcommonFunc.ScaleY(MailBoxScroll_CurPos.y), MailBoxScroll_BarHeight + MailBoxScroll_BarGap, ScrollViewRect_MailBoxScroll, new Rect(MailBoxScroll_BarStrtPosX + IGT_UIcommonFunc.ScaleX(20f), MailBoxScroll_BarStrtPosY, MailBoxScroll_BarWid, MailBoxScroll_BarHeight));
		if (num == -1 || num >= listAskSend.Count)
		{
			return;
		}
		if (!listAskSend[num].bCheckbox)
		{
			listAskSend[num].bCheckbox = true;
		}
		else
		{
			listAskSend[num].bCheckbox = false;
		}
		int num2 = 0;
		for (int i = 0; i < listAskSend.Count; i++)
		{
			if (listAskSend[i].bCheckbox)
			{
				num2++;
			}
		}
		if (num2 > 0)
		{
			But_Mail_Accept.setEnable(true);
		}
		else
		{
			But_Mail_Accept.setEnable(false);
		}
		if (num2 == listAskSend.Count)
		{
			But_Mail_CheckAll.setEnable(false);
		}
		else
		{
			But_Mail_CheckAll.setEnable(true);
		}
	}

	private void sendLifecheckBoxBtnEvent()
	{
		if (!pFacebook.isFBLoginSucess())
		{
			return;
		}
		int num = OnClickEventsInPurchaseWindow(pTouchPositon.x, (float)Screen.height - pTouchPositon.y, pTouchPhase, IGT_UIcommonFunc.ScaleY(SendLifeScroll_CurPos.y), SendLifeScroll_BarHeight + SendLifeScroll_BarGap, ScrollViewRect_SendLifeScroll, new Rect(SendLifeScroll_BarStrtPosX + IGT_UIcommonFunc.ScaleX(20f), SendLifeScroll_BarStrtPosY, SendLifeScroll_BarWid, SendLifeScroll_BarHeight));
		if (num == -1 || num >= listSendLife.Count)
		{
			return;
		}
		if (!listSendLife[num].bCheckbox)
		{
			listSendLife[num].bCheckbox = true;
		}
		else
		{
			listSendLife[num].bCheckbox = false;
		}
		int num2 = 0;
		for (int i = 0; i < listSendLife.Count; i++)
		{
			if (listSendLife[i].bCheckbox)
			{
				num2++;
			}
		}
		if (num2 > 0)
		{
			But_SendLife_Accept.setEnable(true);
		}
		else
		{
			But_SendLife_Accept.setEnable(false);
		}
		if (num2 == listSendLife.Count)
		{
			But_SendLife_CheckAll.setEnable(false);
		}
		else
		{
			But_SendLife_CheckAll.setEnable(true);
		}
	}

	private void askLifecheckBoxBtnEvent()
	{
		if (!pFacebook.isFBLoginSucess())
		{
			return;
		}
		int num = OnClickEventsInPurchaseWindow(pTouchPositon.x, (float)Screen.height - pTouchPositon.y, pTouchPhase, IGT_UIcommonFunc.ScaleY(AskLifeScroll_CurPos.y), AskLifeScroll_BarHeight + AskLifeScroll_BarGap, ScrollViewRect_AskLifeScroll, new Rect(AskLifeScroll_BarStrtPosX + IGT_UIcommonFunc.ScaleX(20f), AskLifeScroll_BarStrtPosY, AskLifeScroll_BarWid, AskLifeScroll_BarHeight));
		if (num == -1 || num >= listAskLife.Count)
		{
			return;
		}
		if (!listAskLife[num].bCheckbox)
		{
			listAskLife[num].bCheckbox = true;
		}
		else
		{
			listAskLife[num].bCheckbox = false;
			But_AskLife_CheckAll.setEnable(true);
		}
		int num2 = 0;
		for (int i = 0; i < listAskLife.Count; i++)
		{
			if (listAskLife[i].bCheckbox)
			{
				num2++;
			}
		}
		if (num2 > 0)
		{
			But_AskLife_Accept.setEnable(true);
		}
		else
		{
			But_AskLife_Accept.setEnable(false);
		}
		if (num2 == listAskLife.Count)
		{
			But_AskLife_CheckAll.setEnable(false);
		}
		else
		{
			But_AskLife_CheckAll.setEnable(true);
		}
	}

	private void testing()
	{
	}

	private int character_Selection_movement(float selectX, float selectY, TouchPhase touch_phase)
	{
		HS_selectionCamera.transform.position = new Vector3(Mathf.Cos((float)Math.PI / 180f * HScam_cur_angle) * camera_circle_radius, -1000.4f, Mathf.Sin((float)Math.PI / 180f * HScam_cur_angle) * camera_circle_radius);
		centre_character = (int)Mathf.Round((HScam_cur_angle - HScam_start_angle) / 20f);
		HS_selectionCamera.transform.LookAt(new Vector3(0f, -1000.49f, 0f));
		tmp_phase = touch_phase;
		int num = 0;
		float num2 = 18f;
		if (!bLeaderBoardbtnClick && !bFBbtnClick && !bGoogleLbbtnClick && !bHS_allshare && !bHS_settings && !bHS_moregames && !bHS_about)
		{
			if (mov_btn)
			{
				HScam_cur_angle = Mathf.Lerp(btn_SourceAngle, btn_DestinationAngle, HScam_move_tym);
				HScam_move_tym = (Time.time - HSbtn_start_tym) * 1.5f;
				if (HScam_move_tym > 1f)
				{
					mov_btn = false;
				}
			}
			else
			{
				if (tmp_phase == TouchPhase.Began && selectX > IGT_UIcommonFunc.ScaleX(30f) && selectX < IGT_UIcommonFunc.ScaleX(270f) && selectY > IGT_UIcommonFunc.ScaleY(50f) && selectY < IGT_UIcommonFunc.ScaleY(175f))
				{
					bwrongmovement = false;
				}
				if (selectX > IGT_UIcommonFunc.ScaleX(30f) && selectX < IGT_UIcommonFunc.ScaleX(270f) && selectY > IGT_UIcommonFunc.ScaleY(50f) && selectY < IGT_UIcommonFunc.ScaleY(175f) && !bwrongmovement)
				{
					if (tmp_phase == TouchPhase.Began)
					{
						IsMove = true;
						IsTouchEnd = false;
						tmp_XBegan = selectX;
						HScam_move_tym = 0f;
						move_tym1 = 0f;
						v_city = 0f;
						start_tym = Time.time;
						source_angle = HScam_cur_angle;
						for (int i = 0; i < 10; i++)
						{
							coin_move_tym[i] = 0f;
						}
					}
					if (tmp_phase == TouchPhase.Moved)
					{
						tmp_XMove = selectX;
						diff_X = tmp_XBegan - tmp_XMove;
						HScam_cur_angle = source_angle + diff_X * 0.065f;
						IsTouchEnd = false;
					}
				}
				else
				{
					bwrongmovement = true;
				}
				if (tmp_phase == TouchPhase.Ended)
				{
					tmp_XEnd = selectX;
					end_tym = Time.time;
					float num3 = end_tym - start_tym;
					fling_diffX = tmp_XBegan - tmp_XEnd;
					distance_pts = Mathf.Abs(fling_diffX);
					v_city = distance_pts / num3;
					dest_angle = HScam_cur_angle;
					source_angle = HScam_cur_angle;
					IsTouchEnd = true;
				}
				if (v_city > 700f && IsMove)
				{
					if (diff_X > 0f)
					{
						fling_dest_angle = source_angle + 20f;
					}
					if (diff_X < 0f)
					{
						fling_dest_angle = source_angle - 20f;
					}
					IsMove = false;
					bfling = true;
				}
				if (IsTouchEnd)
				{
					if (bfling)
					{
						HScam_cur_angle = Mathf.Lerp(source_angle, fling_dest_angle, move_tym1);
						move_tym1 += 0.05f;
						if (move_tym1 > 1f)
						{
							bfling = false;
						}
					}
					else
					{
						HScam_cur_angle = Mathf.Lerp(dest_angle, (float)centre_character * ang_btwn_Characters + HScam_start_angle, HScam_move_tym);
						HScam_move_tym += 0.065f;
					}
				}
			}
		}
		if (HScam_cur_angle > 350f)
		{
			HScam_cur_angle = 350f;
		}
		if (HScam_cur_angle < 270f)
		{
			HScam_cur_angle = 270f;
		}
		for (num = 0; num < 5; num++)
		{
			float num4 = Mathf.Abs(HScam_cur_angle - (270f + (float)centre_character * 20f));
			if (num4 <= num2)
			{
				float num5 = (1f - num4 / num2) * 0.18f + 1f;
				characters_List[centre_character].transform.localScale = new Vector3(num5, num5, num5);
			}
			else
			{
				characters_List[num].transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.y, base.transform.localScale.z);
			}
		}
		for (int j = 0; j < 5; j++)
		{
			if (j == centre_character)
			{
				CS_hero_anim[j].SetInteger("animate", centre_character);
			}
			else
			{
				CS_hero_anim[j].SetInteger("animate", 10);
			}
		}
		if (IsTouchEnd)
		{
			for (int k = 1; k < coins_ary; k++)
			{
				coin_curve[k] = coin_move.Bezier_2D(new Vector2(218f, 10f), new Vector2(200f, 200f), new Vector2(118f, 149f), coin_move_tym[k]);
				coin_move_tym[k] += coin_tmp_tym[k];
			}
		}
		if (centre_character == 4)
		{
			lt1.intensity = 0.8f;
		}
		else
		{
			lt1.intensity = 1.25f;
		}
		if (coin_move_tym[1] >= 1f && ready_character_idx[centre_character] == 1)
		{
			coins_fission = false;
		}
		if (Time.time >= 1f && coin_move_tym[1] >= 1f)
		{
			coins_fission = false;
		}
		if (ready_character_idx[centre_character] == 1)
		{
			selected_character = centre_character;
			return selected_character;
		}
		return selected_character;
	}

	private void checkBounceGooglePluseAlert(float tempx, float tempY)
	{
		btnGpluseSignin.checkBounce(tempx, tempY, pTouchPhase);
		btnGplusealertClose.checkBounce(tempx, tempY, pTouchPhase);
	}

	private void OnGUI()
	{
		switch (nScreenMode)
		{
		case 21:
			if (pHero.isAIplayerAvailable)
			{
				if (pHero.nMissionID == 0 || pHero.nMissionID == 3)
				{
					pIgt_Textures.DrawTexture(IGT_Constants._Game_ChaseHeader, rect_Game_ChaseHeader, false);
					pHero_Healthprograss.draw(nHealth_hero);
					pIgt_Lable.DrawLable(new Rect(rect_HeroHealthBar.x, 0f, rect_HeroHealthBar.width, rect_HeroHealthBar.height), strNickName, IGT_Constants.Font_chelaOne, (int)IGT_UIcommonFunc.ScaleX(10f), TextAnchor.MiddleLeft, false, Color.yellow, 0f, Color.black, new Vector2(2f, 2f), Color.black);
					pIgt_Lable.DrawLable(pHero_Healthprograss.getContainerDimensions(), "<b>" + (int)(nHealth_hero * 100f)/*cast due to .constrained prefix*/ + "</b>%", IGT_Constants.Font_Nunito, (int)IGT_UIcommonFunc.ScaleX(9f), TextAnchor.MiddleRight, false, Color.white, 0.8f, Color.black, Vector2.zero, Color.black);
					pEnemy_Healthprograss.draw(nHelath_Enemy);
					pIgt_Lable.DrawLable(new Rect(rect_EnemyHealthBar.x, 0f, rect_EnemyHealthBar.width, rect_EnemyHealthBar.height), pHero.pAIPlayerData[pHero.nAIPlayerIndex].Name, IGT_Constants.Font_chelaOne, (int)IGT_UIcommonFunc.ScaleX(10f), TextAnchor.MiddleRight, false, Color.yellow, 0f, Color.black, new Vector2(2f, 2f), Color.black);
					pIgt_Lable.DrawLable(pEnemy_Healthprograss.getContainerDimensions(), "<b>" + Mathf.CeilToInt(nHelath_Enemy * 100f) + "</b>%", IGT_Constants.Font_Nunito, (int)IGT_UIcommonFunc.ScaleX(9f), TextAnchor.MiddleLeft, false, Color.white, 0.8f, Color.black, Vector2.zero, Color.black);
					pIgt_Textures.DrawTexture(IGT_Constants._Game_MapDock, rect_DirMap, true);
					pIgt_Textures.DrawTexture(IGT_Constants.Hero_FacePicx[pHero.nHeroIndex], rect_DirMapHero, false);
					pIgt_Textures.DrawTexture(IGT_Constants.AIPlayer_FacePicx[pHero.nAIPlayerIndex], new Rect(rect_DirMapHero.x + rect_DirMapEnemy.x, rect_DirMapHero.y + rect_DirMapEnemy.y, rect_DirMapHero.width, rect_DirMapHero.height), false);
					pIgt_Lable.DrawLable(rect_DirMapDist, fDirMapDist + " m", IGT_Constants.Font_chelaOne, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.black, new Vector2(2f, 2f), Color.black);
				}
				else if (pHero.nMissionID == 1 || pHero.nMissionID == 2)
				{
					pIgt_Textures.DrawTexture(IGT_Constants._Mission_TagRound, rect_MultipleCollectionItemCount[0], false);
					pIgt_Lable.DrawLable(rect_MultipleCollectionItemCount[0], pHero.nCollectedItemCount + "/" + pHero.pMissionData.nTargetCount, IGT_Constants.Font_chelaOne, fontSize_MissionTargetCount, TextAnchor.MiddleCenter, false, Color.white, 2f, Color.black, Vector2.zero, Color.black);
					if (pHero.nMissionID == 1)
					{
						pIgt_Textures.DrawTexture(IGT_Constants._Bottle, rect_MultipleCollectionItemImg[0], false);
					}
					else
					{
						pIgt_Textures.DrawTexture(IGT_Constants._Ball, rect_MultipleCollectionItemImg[0], false);
					}
				}
			}
			switch (nArrowAnimType)
			{
			case 0:
				pIgt_Textures.DrawTexture(IGT_Constants._Arrow, new Rect(rect_ArrowDim.x, pAnim_MissionCompleted_star3.easeFunctions(rect_ArrowDim.y, rect_ArrowDim.y - IGT_UIcommonFunc.ScaleY(100f), 1f, 0), rect_ArrowDim.width, rect_ArrowDim.height), true);
				break;
			case 1:
				pIgt_Textures.DrawTexture(IGT_Constants._Arrow, new Rect(rect_ArrowDim.x, pAnim_MissionCompleted_star3.easeFunctions(rect_ArrowDim.y, rect_ArrowDim.y + IGT_UIcommonFunc.ScaleY(100f), 1f, 0), rect_ArrowDim.width, rect_ArrowDim.height), 180f, new Vector2(0.5f, 0.5f));
				break;
			case 2:
				pIgt_Textures.DrawTexture(IGT_Constants._Arrow, new Rect(pAnim_MissionCompleted_star3.easeFunctions(rect_ArrowDim.x, rect_ArrowDim.x - IGT_UIcommonFunc.ScaleY(100f), 1f, 0), rect_ArrowDim.y, rect_ArrowDim.width, rect_ArrowDim.height), -90f, new Vector2(0.5f, 0.5f));
				break;
			case 3:
				pIgt_Textures.DrawTexture(IGT_Constants._Arrow, new Rect(pAnim_MissionCompleted_star3.easeFunctions(rect_ArrowDim.x, rect_ArrowDim.x + IGT_UIcommonFunc.ScaleY(100f), 1f, 0), rect_ArrowDim.y, rect_ArrowDim.width, rect_ArrowDim.height), 90f, new Vector2(0.5f, 0.5f));
				break;
			case 4:
				pIGT_Sprites_Tap.draw();
				if (pIGT_Sprites_Tap.getFramNumber() == 2)
				{
					pIgt_Textures.DrawTexture(IGT_Constants._CountDown_Glow, rect_TapGlow, false);
				}
				break;
			}
			if (pAnim_MissionCompleted_star3.isAnimFinished() && pHero.nMissionID < 3)
			{
				pAnim_MissionCompleted_star3.resetAllValues();
			}
			break;
		case 1:
			But_Gamescreen_Pause.Draw();
			if (pHero.nGameMode == 0 || (pHero.nGameMode == 1 && pHero.pMissionData.nMissionType == 2) || (pHero.nGameMode == 1 && pHero.pMissionData.nMissionType == 1 && (pHero.pMissionData.nChallengesInnerItemType == 0 || pHero.pMissionData.nChallengesInnerItemType == 1)))
			{
				pIgt_Textures.DrawTexture(IGT_Constants._Game_ChaseHeader, rect_Game_ChaseHeader, false);
				if (!bLowEnergy_Hero || !((Time.time - fLowEnergy_Hero_StrtTime) * 1000f % 500f <= 500f) || !((Time.time - fLowEnergy_Hero_StrtTime) * 1000f % 1000f <= 500f))
				{
					pHero_Healthprograss.draw(nHealth_hero);
					pIgt_Lable.DrawLable(new Rect(rect_HeroHealthBar.x, 0f, rect_HeroHealthBar.width, rect_HeroHealthBar.height), strNickName, IGT_Constants.Font_chelaOne, (int)IGT_UIcommonFunc.ScaleX(10f), TextAnchor.MiddleLeft, false, Color.yellow, 0f, Color.black, new Vector2(2f, 2f), Color.black);
					pIgt_Lable.DrawLable(pHero_Healthprograss.getContainerDimensions(), "<b>" + (int)(nHealth_hero * 100f)/*cast due to .constrained prefix*/ + "</b>%", IGT_Constants.Font_Nunito, (int)IGT_UIcommonFunc.ScaleX(9f), TextAnchor.MiddleRight, false, Color.white, 0.8f, Color.black, Vector2.zero, Color.black);
				}
				if (!bLowEnergy_Enemy || !((Time.time - fLowEnergy_Enemy_StrtTime) * 1000f % 500f <= 500f) || !((Time.time - fLowEnergy_Enemy_StrtTime) * 1000f % 1000f <= 500f))
				{
					pEnemy_Healthprograss.draw(nHelath_Enemy);
					pIgt_Lable.DrawLable(new Rect(rect_EnemyHealthBar.x, 0f, rect_EnemyHealthBar.width, rect_EnemyHealthBar.height), pHero.pAIPlayerData[pHero.nAIPlayerIndex].Name, IGT_Constants.Font_chelaOne, (int)IGT_UIcommonFunc.ScaleX(10f), TextAnchor.MiddleRight, false, Color.yellow, 0f, Color.black, new Vector2(2f, 2f), Color.black);
					pIgt_Lable.DrawLable(pEnemy_Healthprograss.getContainerDimensions(), "<b>" + Mathf.CeilToInt(nHelath_Enemy * 100f) + "</b>%", IGT_Constants.Font_Nunito, (int)IGT_UIcommonFunc.ScaleX(9f), TextAnchor.MiddleLeft, false, Color.white, 0.8f, Color.black, Vector2.zero, Color.black);
				}
				int num16;
				if (pHero.nGameMode == 1)
				{
					if (pHero.pMissionData.nMissionType == 2)
					{
						if (pHero.pMissionData.nCatchingInnerItemType == 0)
						{
							pIgt_Lable.DrawLable(rect_Game_ScroeText, "Time", IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.white, 0f, Color.black, new Vector2(2f, 2f), Color.black);
							float num15 = Time.time - (float)pHero.dMissionStrtTime;
							num15 = (float)pHero.pMissionData.nTargetCount - num15;
							if (num15 < 0f)
							{
								num15 = 0f;
							}
							if (!bCatchMode_End || !((Time.time - fCatchMode_StartTime) * 1000f % 500f <= 500f) || !((Time.time - fCatchMode_StartTime) * 1000f % 1000f <= 500f))
							{
								pIgt_Lable.DrawLable(new Rect(rect_Game_ScroeText.x, rect_Game_ScroeText.y + rect_Game_ScroeText.height - IGT_UIcommonFunc.ScaleY(7f), rect_Game_ScroeText.width, rect_Game_ScroeText.height), (Mathf.Floor(num15 / 60f) + ":" + string.Format("{0:00}", num15 % 60f)).ToString(), IGT_Constants.Font_chelaOne, (int)IGT_UIcommonFunc.ScaleX(25f), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.black, new Vector2(2f, 2f), Color.black);
							}
						}
						else if (pHero.pMissionData.nCatchingInnerItemType == 1)
						{
							pIgt_Lable.DrawLable(rect_Game_ScroeText, "Distance", IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.white, 0f, Color.black, new Vector2(2f, 2f), Color.black, 0f, Vector2.zero);
							if (!bCatchMode_End || !((Time.time - fCatchMode_StartTime) * 1000f % 500f <= 500f) || !((Time.time - fCatchMode_StartTime) * 1000f % 1000f <= 500f))
							{
								pIgt_Lable.DrawLable(new Rect(rect_Game_ScroeText.x, rect_Game_ScroeText.y + rect_Game_ScroeText.height - IGT_UIcommonFunc.ScaleY(7f), rect_Game_ScroeText.width, rect_Game_ScroeText.height), ((int)(pHero.PlayerObj.fTotDistTraveled * IGT_Constants.GAME_TO_REAL_WORLD_DIST_MULTIPLIER) + " / " + pHero.pMissionData.nTargetCount).ToString(), IGT_Constants.Font_chelaOne, (int)IGT_UIcommonFunc.ScaleX(25f), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.black, new Vector2(2f, 2f), Color.black);
							}
						}
					}
					else if (pHero.pMissionData.nMissionType == 1)
					{
						pIgt_Textures.DrawTexture(pMissionInfo_TextureName, new Rect(IGT_UIcommonFunc.ScaleX(112f), IGT_UIcommonFunc.ScaleY(5f), IGT_UIcommonFunc.ScaleX(32f), IGT_UIcommonFunc.ScaleY(32f)), true);
						pIgt_Lable.DrawLable(new Rect(rect_Game_ScroeText.x + IGT_UIcommonFunc.ScaleX(8f), rect_Game_ScroeText.y + rect_Game_ScroeText.height - IGT_UIcommonFunc.ScaleY(12f), rect_Game_ScroeText.width, rect_Game_ScroeText.height), pHero.nCollectedItemCount + " / " + pHero.pMissionData.nTargetCount, IGT_Constants.Font_chelaOne, (int)IGT_UIcommonFunc.ScaleX(25f), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.black, new Vector2(2f, 2f), Color.black);
					}
					pSpdParams = "H: " + Mathf.Round(pHero.PlayerObj.speed * 100f) / 100f + " AI: " + Mathf.Round(IGT_AIPlayer.AI_PlayerObj.speed * 100f) / 100f + " F: " + IGT_Constants.fDiffSpd_CurVal_Mission + " R: " + pHero.pMissionData.nRetryCount;
				}
				else
				{
					pIgt_Lable.DrawLable(rect_Game_ScroeText, "SCORE", IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.white, 0f, Color.black, new Vector2(2f, 2f), Color.black);
					num16 = 30 - pHero.nScore_Current.ToString().Length;
					if (num16 < 22)
					{
						num16 = 22;
					}
					pIgt_Lable.DrawLable(new Rect(rect_Game_ScroeText.x, rect_Game_ScroeText.y + rect_Game_ScroeText.height - IGT_UIcommonFunc.ScaleY(7f), rect_Game_ScroeText.width, rect_Game_ScroeText.height), pHero.nScore_Current.ToString(), IGT_Constants.Font_chelaOne, (int)IGT_UIcommonFunc.ScaleX(num16), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.black, new Vector2(2f, 2f), Color.black);
				}
				GUI.DrawTexture(new Rect(rect_Game_CoinImg.x + rect_Game_CoinImg.width - IGT_UIcommonFunc.ScaleY(5f), rect_Game_CoinImg.y + IGT_UIcommonFunc.ScaleY(1f), IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleY(15f)), Border_custom);
				pIgt_Textures.DrawTexture(IGT_Constants._CoinImg, adj_drawrect(new Rect(rect_Game_CoinImg.x + rect_Game_CoinImg.width - IGT_UIcommonFunc.ScaleY(5f), rect_Game_CoinImg.y + IGT_UIcommonFunc.ScaleY(1f), IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleY(15f)), rect_Game_CoinImg, 0), false);
				num16 = 19 - pHero.nScore_Current.ToString().Length;
				if (num16 < 14)
				{
					num16 = 14;
				}
				pIgt_Lable.DrawLable(adj_drawrect(new Rect(rect_Game_CoinImg.x + rect_Game_CoinImg.width - IGT_UIcommonFunc.ScaleY(5f), rect_Game_CoinImg.y + IGT_UIcommonFunc.ScaleY(1f), IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleY(15f)), new Rect(rect_Game_CoinImg.x + rect_Game_CoinImg.width + IGT_UIcommonFunc.ScaleX(1f), rect_Game_CoinImg.y - IGT_UIcommonFunc.ScaleY(0f), IGT_UIcommonFunc.ScaleX(35f), IGT_UIcommonFunc.ScaleY(15f)), 0), IGT_Constants.nNoOfCollectedCoins.ToString(), IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(num16), TextAnchor.MiddleLeft, false, Color.white, 1f, Color.black, Vector2.one * 2f, Color.black);
				pIgt_Textures.DrawTexture(IGT_Constants._Game_MapDock, rect_DirMap, true);
				pIgt_Textures.DrawTexture(IGT_Constants.Hero_FacePicx[pHero.nHeroIndex], rect_DirMapHero, false);
				pIgt_Textures.DrawTexture(IGT_Constants.AIPlayer_FacePicx[pHero.nAIPlayerIndex], new Rect(rect_DirMapHero.x + rect_DirMapEnemy.x, rect_DirMapHero.y + rect_DirMapEnemy.y, rect_DirMapHero.width, rect_DirMapHero.height), false);
				pIgt_Lable.DrawLable(rect_DirMapDist, fDirMapDist + " m", IGT_Constants.Font_chelaOne, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.black, new Vector2(2f, 2f), Color.black);
			}
			else if (pHero.nGameMode == 1)
			{
				switch (pHero.pMissionData.nMissionType)
				{
				case 0:
					pIgt_Textures.DrawTexture(IGT_Constants._Mission_TagRound, rect_MultipleCollectionItemCount[0], false);
					if (pHero.pMissionData.nCollectionInnerItemType == 0)
					{
						pIgt_Textures.DrawTexture(IGT_Constants.collectionItemsImg[pHero.pMissionData.nCollectionInnerItemType], new Rect(rect_MultipleCollectionItemImg[0].x + IGT_UIcommonFunc.ScaleX(7f), rect_MultipleCollectionItemImg[0].y + IGT_UIcommonFunc.ScaleY(9f), IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleY(40f)), true);
					}
					else
					{
						pIgt_Textures.DrawTexture(IGT_Constants.collectionItemsImg[pHero.pMissionData.nCollectionInnerItemType], rect_MultipleCollectionItemImg[0], false);
					}
					pIgt_Lable.DrawLable(rect_MultipleCollectionItemCount[0], pHero.nCollectedItemCount + "/" + pHero.pMissionData.nTargetCount, IGT_Constants.Font_chelaOne, fontSize_MissionTargetCount, TextAnchor.MiddleCenter, false, Color.white, 2f, Color.black, Vector2.zero, Color.black);
					break;
				case 5:
					if (pHero.pMissionData.nNumOfMultipleCollection == 2)
					{
						pIgt_Textures.DrawTexture(IGT_Constants._Mission_TagRound, rect_MultipleCollectionItemCount[1], false);
						pIgt_Lable.DrawLable(rect_MultipleCollectionItemCount[1], pHero.nCollectedMultipleItemCount[0] + "/" + pHero.pMissionData.nMultipleCollectionDatas[0, 2], IGT_Constants.Font_chelaOne, fontSize_MissionTargetCount, TextAnchor.MiddleCenter, false, Color.white, 2f, Color.black, Vector2.zero, Color.black);
						pIgt_Textures.DrawTexture(IGT_Constants.collectionItemsImg[pHero.pMissionData.nMultipleCollectionDatas[0, 0]], rect_MultipleCollectionItemImg[1], true);
						if (pHero.nCollectedMultipleItemCount[0] >= pHero.pMissionData.nMultipleCollectionDatas[0, 2])
						{
							pIgt_Textures.DrawTexture(IGT_Constants._TickMark, new Rect(rect_MultipleCollectionItemCount[1].x + rect_MultipleCollectionItemCount[1].width / 2f - rect_TickMark.width / 2f, rect_MultipleCollectionItemCount[1].y, rect_TickMark.width, rect_TickMark.height), false);
						}
						pIgt_Textures.DrawTexture(IGT_Constants._Mission_TagRound, rect_MultipleCollectionItemCount[2], false);
						pIgt_Lable.DrawLable(rect_MultipleCollectionItemCount[2], pHero.nCollectedMultipleItemCount[1] + "/" + pHero.pMissionData.nMultipleCollectionDatas[1, 2], IGT_Constants.Font_chelaOne, fontSize_MissionTargetCount, TextAnchor.MiddleCenter, false, Color.white, 2f, Color.black, Vector2.zero, Color.black);
						pIgt_Textures.DrawTexture(IGT_Constants.collectionItemsImg[pHero.pMissionData.nMultipleCollectionDatas[1, 0]], rect_MultipleCollectionItemImg[2], true);
						if (pHero.nCollectedMultipleItemCount[1] >= pHero.pMissionData.nMultipleCollectionDatas[1, 2])
						{
							pIgt_Textures.DrawTexture(IGT_Constants._TickMark, new Rect(rect_MultipleCollectionItemCount[2].x + rect_MultipleCollectionItemCount[2].width / 2f - rect_TickMark.width / 2f, rect_MultipleCollectionItemCount[2].y, rect_TickMark.width, rect_TickMark.height), false);
						}
					}
					else if (pHero.pMissionData.nNumOfMultipleCollection == 3)
					{
						pIgt_Textures.DrawTexture(IGT_Constants._Mission_TagRound, rect_MultipleCollectionItemCount[3], false);
						pIgt_Lable.DrawLable(rect_MultipleCollectionItemCount[3], pHero.nCollectedMultipleItemCount[0] + "/" + pHero.pMissionData.nMultipleCollectionDatas[0, 2], IGT_Constants.Font_chelaOne, fontSize_MissionTargetCount, TextAnchor.MiddleCenter, false, Color.white, 2f, Color.black, Vector2.zero, Color.black);
						pIgt_Textures.DrawTexture(IGT_Constants.collectionItemsImg[pHero.pMissionData.nMultipleCollectionDatas[0, 0]], rect_MultipleCollectionItemImg[3], true);
						if (pHero.nCollectedMultipleItemCount[0] >= pHero.pMissionData.nMultipleCollectionDatas[0, 2])
						{
							pIgt_Textures.DrawTexture(IGT_Constants._TickMark, new Rect(rect_MultipleCollectionItemCount[3].x + rect_MultipleCollectionItemCount[3].width / 2f - rect_TickMark.width / 2f, rect_MultipleCollectionItemCount[3].y, rect_TickMark.width, rect_TickMark.height), false);
						}
						pIgt_Textures.DrawTexture(IGT_Constants._Mission_TagRound, rect_MultipleCollectionItemCount[4], false);
						pIgt_Lable.DrawLable(rect_MultipleCollectionItemCount[4], pHero.nCollectedMultipleItemCount[1] + "/" + pHero.pMissionData.nMultipleCollectionDatas[1, 2], IGT_Constants.Font_chelaOne, fontSize_MissionTargetCount, TextAnchor.MiddleCenter, false, Color.white, 2f, Color.black, Vector2.zero, Color.black);
						pIgt_Textures.DrawTexture(IGT_Constants.collectionItemsImg[pHero.pMissionData.nMultipleCollectionDatas[1, 0]], rect_MultipleCollectionItemImg[4], false);
						if (pHero.nCollectedMultipleItemCount[1] >= pHero.pMissionData.nMultipleCollectionDatas[1, 2])
						{
							pIgt_Textures.DrawTexture(IGT_Constants._TickMark, new Rect(rect_MultipleCollectionItemCount[4].x + rect_MultipleCollectionItemCount[4].width / 2f - rect_TickMark.width / 2f, rect_MultipleCollectionItemCount[4].y, rect_TickMark.width, rect_TickMark.height), false);
						}
						pIgt_Textures.DrawTexture(IGT_Constants._Mission_TagRound, rect_MultipleCollectionItemCount[5], false);
						pIgt_Lable.DrawLable(rect_MultipleCollectionItemCount[5], pHero.nCollectedMultipleItemCount[2] + "/" + pHero.pMissionData.nMultipleCollectionDatas[2, 2], IGT_Constants.Font_chelaOne, fontSize_MissionTargetCount, TextAnchor.MiddleCenter, false, Color.white, 2f, Color.black, Vector2.zero, Color.black);
						pIgt_Textures.DrawTexture(IGT_Constants.collectionItemsImg[pHero.pMissionData.nMultipleCollectionDatas[2, 0]], rect_MultipleCollectionItemImg[5], true);
						if (pHero.nCollectedMultipleItemCount[2] >= pHero.pMissionData.nMultipleCollectionDatas[2, 2])
						{
							pIgt_Textures.DrawTexture(IGT_Constants._TickMark, new Rect(rect_MultipleCollectionItemCount[5].x + rect_MultipleCollectionItemCount[5].width / 2f - rect_TickMark.width / 2f, rect_MultipleCollectionItemCount[5].y, rect_TickMark.width, rect_TickMark.height), false);
						}
					}
					break;
				case 4:
				{
					pIgt_Textures.DrawTexture(IGT_Constants._BBHeader, new Rect(0f, 0f, Screen.width, IGT_UIcommonFunc.ScaleY(72f)), false);
					if (!bLowEnergy_Hero || !((Time.time - fLowEnergy_Hero_StrtTime) * 1000f % 500f <= 500f) || !((Time.time - fLowEnergy_Hero_StrtTime) * 1000f % 1000f <= 500f))
					{
						pHero_Healthprograss.draw(nHealth_hero);
						pIgt_Lable.DrawLable(new Rect(rect_HeroHealthBar.x, 0f, rect_HeroHealthBar.width, rect_HeroHealthBar.height), strNickName, IGT_Constants.Font_chelaOne, (int)IGT_UIcommonFunc.ScaleX(10f), TextAnchor.MiddleLeft, false, Color.yellow, 0f, Color.black, new Vector2(2f, 2f), Color.black);
						pIgt_Lable.DrawLable(pHero_Healthprograss.getContainerDimensions(), "<b>" + (int)(nHealth_hero * 100f)/*cast due to .constrained prefix*/ + "</b>%", IGT_Constants.Font_Nunito, (int)IGT_UIcommonFunc.ScaleX(9f), TextAnchor.MiddleRight, false, Color.white, 0.8f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
					}
					pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(18f), IGT_UIcommonFunc.ScaleY(30f), IGT_UIcommonFunc.ScaleX(64f), IGT_UIcommonFunc.ScaleY(27f)), (Mathf.Floor(pHero.nTimeLeft_in_BringBackMode / 60) + ":" + string.Format("{0:00}", pHero.nTimeLeft_in_BringBackMode % 60)).ToString(), IGT_Constants.Font_SevenSegment, (int)IGT_UIcommonFunc.ScaleX(17f), TextAnchor.MiddleLeft, true, Color.yellow, 0f, Color.black, new Vector2(1f, 1f), Color.black);
					pIgt_Textures.DrawTexture(IGT_Constants.BringBackItemsImg[pHero.pMissionData.nBringBackItemInnerType], new Rect(IGT_UIcommonFunc.ScaleX(200f), IGT_UIcommonFunc.ScaleY(-5f), IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleY(40f)), false);
					if (pHero.bHasPicked_BBitem)
					{
						pIgt_Textures.DrawTexture(IGT_Constants._TickMark, new Rect(IGT_UIcommonFunc.ScaleX(205f), IGT_UIcommonFunc.ScaleY(5f), IGT_UIcommonFunc.ScaleX(25f), IGT_UIcommonFunc.ScaleY(25f)), false);
					}
					if (bBringBackAlert)
					{
						float num17 = 1f;
						float num18 = 0f;
						if (bBringBackAlert_Alpha)
						{
							num18 = Time.time - fBringBack_Alert_Alpha_StartTime;
							num17 = IGT_EaseFunction.Linear_ease(num18, 1f, 0.1f, 0.5f);
							if (num18 > 0.5f)
							{
								bBringBackAlert = false;
								bBringBackAlert_Alpha = false;
								if (pHero.nMissionID == 13)
								{
									fBringBack_Demo__TaptoContinue_StartTime = Time.time;
									bBringBackDemoTapToContinueAlert = true;
									freezeGame(true);
								}
							}
						}
						else
						{
							num18 = Time.time - fBringBack_Alert_Alpha_StartTime;
							if (num18 > 0.5f)
							{
								num18 = 0.5f;
							}
							num17 = IGT_EaseFunction.Linear_ease(num18, 0.2f, 1f, 0.5f);
						}
						if (Time.time - fBringBack_Alert_StrtTime > fBringBack_Alert_TotTime && !bBringBackAlert_Alpha)
						{
							fBringBack_Alert_Alpha_StartTime = Time.time;
							bBringBackAlert_Alpha = true;
						}
						rect_BringBackAlert.x = Camera.main.WorldToScreenPoint(pHero.Hero_HeadPos.transform.position).x - IGT_UIcommonFunc.ScaleX(15f);
						rect_BringBackAlert.y = Camera.main.WorldToScreenPoint(pHero.Hero_HeadPos.transform.position).y + IGT_UIcommonFunc.ScaleY(125f);
						Color color2 = GUI.color;
						GUI.color = new Color(color2.r, color2.g, color2.b, num17);
						pIgt_Textures.DrawTexture(IGT_Constants._TalkingCloud, rect_BringBackAlert, false);
						pIgt_Lable.DrawLable(new Rect(rect_BringBackAlert.x, rect_BringBackAlert.y - IGT_UIcommonFunc.ScaleY(4f), rect_BringBackAlert.width, rect_BringBackAlert.height), sBringBackAlertText, IGT_Constants.Font_Nunito, (int)IGT_UIcommonFunc.ScaleX(10f), TextAnchor.MiddleCenter, true, Color.white, 0f, Color.black, new Vector2(1f, 1f), Color.black);
						GUI.color = color2;
					}
					if (pHero.nMissionID == 13 && bBringBackDemoTapToContinueAlert)
					{
						pIgt_Textures.DrawTexture(IGT_Constants._countDown_Bg, new Rect(IGT_UIcommonFunc.ScaleX(0f), IGT_UIcommonFunc.ScaleY(0f), IGT_UIcommonFunc.ScaleX(320f), IGT_UIcommonFunc.ScaleY(480f)), false);
						pIgt_Textures.DrawTexture(IGT_Constants._PopupInfoBG, rect_MissionPopup.x, rect_MissionPopup.y, rect_MissionPopup.width, rect_MissionPopup.height * 1.2f);
						pIgt_Lable.DrawLable(new Rect(rect_MissionPopup.x, rect_MissionPopup.y, rect_MissionPopup.width, rect_MissionPopup.height), sBringBackDemoText, IGT_Constants.Font_TitanOne, fontSize_missionPopupInfo, TextAnchor.MiddleCenter, true, Color.white, Vector2.one * 2f, Color.black);
						if (pAnim_MissionCompleted_star3.isAnimFinished())
						{
							pAnim_MissionCompleted_star3.resetAllValues();
						}
						Matrix4x4 matrix = GUI.matrix;
						GUIUtility.RotateAroundPivot(35f, new Vector2((float)Screen.width * 0.5f, (float)Screen.height * 0.5f));
						pIgt_Textures.DrawTexture(IGT_Constants._Arrow, new Rect(rect_ArrowDim.x + IGT_UIcommonFunc.ScaleX(20f), pAnim_MissionCompleted_star3.easeFunctions(IGT_UIcommonFunc.ScaleY(100f), IGT_UIcommonFunc.ScaleY(50f), 1f, 0), rect_ArrowDim.width * 0.5f, rect_ArrowDim.height * 0.5f), false);
						GUI.matrix = matrix;
						if (Time.time - fBringBack_Demo__TaptoContinue_StartTime > 3f)
						{
							pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(125f), IGT_UIcommonFunc.ScaleY(375f), IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(30f)), "Tap to Continue...", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(18f), Color.white, TextAnchor.MiddleCenter, false);
							if (Time.time - fBringBack_Demo__TaptoContinue_StartTime > 5f && Time.time - fBringBack_Demo__TaptoContinue_StartTime <= 6f)
							{
								pIGT_Sprites_MissionInfoTap.draw();
								if (pIGT_Sprites_MissionInfoTap.getFramNumber() == 2)
								{
									pIgt_Textures.DrawTexture(IGT_Constants._CountDown_Glow, new Rect(IGT_UIcommonFunc.ScaleX(180f), IGT_UIcommonFunc.ScaleY(285f), IGT_UIcommonFunc.ScaleX(60f), IGT_UIcommonFunc.ScaleY(60f)), false);
								}
							}
						}
					}
					pIgt_Textures.DrawTexture(IGT_Constants._Game_MapDock, rect_BB_DirMap, true);
					Matrix4x4 matrix2 = GUI.matrix;
					GUIUtility.RotateAroundPivot(180f - pHero.fBB_DirMapAngle, new Vector2(rect_BB_DirMap.x + rect_BB_DirMap.width * 0.5f, rect_BB_DirMap.y + rect_BB_DirMap.height * 0.5f));
					pIgt_Textures.DrawTexture(IGT_Constants._MapPointer, rect_BB_DirMap, true);
					GUI.matrix = matrix2;
					if (pHero.bHasPicked_BBitem)
					{
						if (pHero.nHeroIndex != 1)
						{
							pIgt_Textures.DrawTexture(IGT_Constants.Path_Heroine_Face, new Rect(rect_BB_DirMapHero.x + rect_BB_DirMapEnemy.x, rect_BB_DirMapHero.y + rect_BB_DirMapEnemy.y, rect_BB_DirMapHero.width * 1.5f, rect_BB_DirMapHero.height * 1.5f), false);
						}
						else
						{
							pIgt_Textures.DrawTexture(IGT_Constants.Hero_FacePicx[0], new Rect(rect_BB_DirMapHero.x + rect_BB_DirMapEnemy.x, rect_BB_DirMapHero.y + rect_BB_DirMapEnemy.y, rect_BB_DirMapHero.width * 1.5f, rect_BB_DirMapHero.height * 1.5f), false);
						}
					}
					else
					{
						pIgt_Textures.DrawTexture(IGT_Constants.BringBackItemsImg[pHero.pMissionData.nBringBackItemInnerType], new Rect(rect_BB_DirMapHero.x + rect_BB_DirMapEnemy.x, rect_BB_DirMapHero.y + rect_BB_DirMapEnemy.y, rect_BB_DirMapHero.width * 2f, rect_BB_DirMapHero.height * 2f), false);
					}
					pIgt_Lable.DrawLable(rect_BB_DirMapDist, fDirMapDist + " m", IGT_Constants.Font_chelaOne, (int)IGT_UIcommonFunc.ScaleX(10f), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.black, new Vector2(2f, 2f), Color.black);
					break;
				}
				case 1:
					pIgt_Textures.DrawTexture(IGT_Constants._Mission_TagRound, rect_MultipleCollectionItemCount[0], false);
					pIgt_Lable.DrawLable(rect_MultipleCollectionItemCount[0], pHero.nCollectedItemCount + "/" + pHero.pMissionData.nTargetCount, IGT_Constants.Font_chelaOne, fontSize_MissionTargetCount, TextAnchor.MiddleCenter, false, Color.white, 2f, Color.black, Vector2.zero, Color.black);
					if (pHero.pMissionData.nChallengesInnerItemType == 2)
					{
						pIgt_Textures.DrawTexture(IGT_Constants._Jump, new Rect(rect_MultipleCollectionItemImg[0].x + IGT_UIcommonFunc.ScaleX(0f), rect_MultipleCollectionItemImg[0].y + IGT_UIcommonFunc.ScaleY(3f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(50f)), true);
					}
					else
					{
						pIgt_Textures.DrawTexture(IGT_Constants._Slide, new Rect(rect_MultipleCollectionItemImg[0].x + IGT_UIcommonFunc.ScaleX(0f), rect_MultipleCollectionItemImg[0].y + IGT_UIcommonFunc.ScaleY(3f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(50f)), true);
					}
					GUI.DrawTexture(new Rect(rect_Game_CoinImg.x + rect_Game_CoinImg.width - IGT_UIcommonFunc.ScaleY(5f), rect_Game_CoinImg.y + IGT_UIcommonFunc.ScaleY(1f), IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleY(15f)), Border_custom);
					pIgt_Textures.DrawTexture(IGT_Constants._CoinImg, adj_drawrect(new Rect(rect_Game_CoinImg.x + rect_Game_CoinImg.width - IGT_UIcommonFunc.ScaleY(5f), rect_Game_CoinImg.y + IGT_UIcommonFunc.ScaleY(1f), IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleY(15f)), rect_Game_CoinImg, 0), false);
					pIgt_Lable.DrawLable(adj_drawrect(new Rect(rect_Game_CoinImg.x + rect_Game_CoinImg.width - IGT_UIcommonFunc.ScaleY(5f), rect_Game_CoinImg.y + IGT_UIcommonFunc.ScaleY(1f), IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleY(15f)), new Rect(rect_Game_CoinImg.x + rect_Game_CoinImg.width + IGT_UIcommonFunc.ScaleX(1f), rect_Game_CoinImg.y - IGT_UIcommonFunc.ScaleY(0f), IGT_UIcommonFunc.ScaleX(35f), IGT_UIcommonFunc.ScaleY(15f)), 0), IGT_Constants.nNoOfCollectedCoins.ToString(), IGT_Constants.Font_chelaOne, (int)IGT_UIcommonFunc.ScaleX(17f), TextAnchor.MiddleLeft, false, Color.white, 1f, Color.black, Vector2.one * 2f, Color.black);
					break;
				case 3:
				{
					pIgt_Textures.DrawTexture(IGT_Constants._Game_ChaseHeader, rect_Game_ChaseHeader, false);
					pIgt_Lable.DrawLable(rect_Game_ScroeText, "Time", IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.white, 0f, Color.black, new Vector2(2f, 2f), Color.black);
					pIgt_Lable.DrawLable(new Rect(rect_Game_ScroeText.x, rect_Game_ScroeText.y + rect_Game_ScroeText.height - IGT_UIcommonFunc.ScaleY(7f), rect_Game_ScroeText.width, rect_Game_ScroeText.height), (Mathf.Floor(pHero.nTimeLeft_in_WordFindingMode / 60) + ":" + string.Format("{0:00}", pHero.nTimeLeft_in_WordFindingMode % 60)).ToString(), IGT_Constants.Font_chelaOne, (int)IGT_UIcommonFunc.ScaleX(25f), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.black, new Vector2(2f, 2f), Color.black);
					if (!bLowEnergy_Hero || !((Time.time - fLowEnergy_Hero_StrtTime) * 1000f % 500f <= 500f) || !((Time.time - fLowEnergy_Hero_StrtTime) * 1000f % 1000f <= 500f))
					{
						pHero_Healthprograss.draw(nHealth_hero);
						pIgt_Lable.DrawLable(new Rect(rect_HeroHealthBar.x, 0f, rect_HeroHealthBar.width, rect_HeroHealthBar.height), strNickName, IGT_Constants.Font_chelaOne, (int)IGT_UIcommonFunc.ScaleX(10f), TextAnchor.MiddleLeft, false, Color.yellow, 0f, Color.black, new Vector2(2f, 2f), Color.black);
						pIgt_Lable.DrawLable(pHero_Healthprograss.getContainerDimensions(), "<b>" + (int)(nHealth_hero * 100f)/*cast due to .constrained prefix*/ + "</b>%", IGT_Constants.Font_Nunito, (int)IGT_UIcommonFunc.ScaleX(9f), TextAnchor.MiddleRight, false, Color.white, 0.8f, Color.black, Vector2.zero, Color.black);
					}
					for (int j = 0; j < pHero.pCharArray.Length; j++)
					{
						pIgt_Textures.DrawTexture(IGT_Constants._wordDock, new Rect(pHero.pCharArray[j].X, pHero.pCharArray[j].Y, pHero.pCharArray[j].fwidth, pHero.pCharArray[j].fHeight), false);
						if (pHero.pCharArray[j].isEnable)
						{
							pIgt_Lable.DrawLable(pHero.pCharArray[j].X, pHero.pCharArray[j].Y, pHero.pCharArray[j].fwidth, pHero.pCharArray[j].fHeight, pHero.pCharArray[j].character.ToString(), IGT_Constants.Font_TitanOne, pHero.pCharArray[j].fFontSize, Color.yellow, TextAnchor.MiddleCenter);
						}
						else
						{
							pIgt_Lable.DrawLable(pHero.pCharArray[j].X, pHero.pCharArray[j].Y, pHero.pCharArray[j].fwidth, pHero.pCharArray[j].fHeight, pHero.pCharArray[j].character.ToString(), IGT_Constants.Font_TitanOne, pHero.pCharArray[j].fFontSize, Color.gray, TextAnchor.MiddleCenter);
						}
					}
					break;
				}
				}
			}
			if (pHero.pBezierAnimation.Count > 0)
			{
				pHero.BezierMovement_UiElements();
			}
			if (pHero.bSplPowersActivated && pIgtDispProp.Count > 0)
			{
				for (int k = 0; k < pIgtDispProp.Count; k++)
				{
					GUI.DrawTexture(pIgtDispProp[k].drawPos, pIgtDispProp[k].pTexture);
					Matrix4x4 matrix3 = GUI.matrix;
					float num19 = IGT_EaseFunction.Back_easeInOut(pIgtDispProp[k].fAnimStrtTime, 1f, 0.01f, pIgtDispProp[k].fAnimTotTime);
					GUIUtility.ScaleAroundPivot(new Vector2(num19, num19), new Vector2(pIgtDispProp[k].drawPos.x + pIgtDispProp[k].drawPos.width * 0.5f, pIgtDispProp[k].drawPos.y + pIgtDispProp[k].drawPos.height * 0.5f));
					pIgt_Lable.DrawLable(new Rect(pIgtDispProp[k].drawPos.x, pIgtDispProp[k].drawPos.y, pIgtDispProp[k].drawPos.width, pIgtDispProp[k].drawPos.height), ((int)(pIgtDispProp[k].fTotTime - (Time.time - pIgtDispProp[k].fStrtTime))/*cast due to .constrained prefix*/).ToString(), IGT_Constants.Font_chelaOne, (int)IGT_UIcommonFunc.ScaleX(30f), TextAnchor.MiddleCenter, false, Color.white, 2f, Color.black, Vector2.zero, Color.black);
					GUI.matrix = matrix3;
					pIgtDispProp[k].fAnimStrtTime = (pIgtDispProp[k].fTotTime - (Time.time - pIgtDispProp[k].fStrtTime)) % 1f;
					if (pIgtDispProp[k].fAnimStrtTime > pIgtDispProp[k].fAnimTotTime)
					{
						pIgtDispProp[k].fAnimStrtTime = 0f;
					}
				}
			}
			if (pHero.bTestingTeamPurpose && GUI.Button(new Rect(But_Gamescreen_Pause.getX(), But_Gamescreen_Pause.getY() - IGT_UIcommonFunc.ScaleY(80f), But_Gamescreen_Pause.getWidth() * 0.7f, But_Gamescreen_Pause.getHeight() * 0.7f), "LevelUp"))
			{
				if (pHero.nGameMode == 1)
				{
					pHero.setData_MissionCompleted();
					break;
				}
				pHero.PlayerObj.nEnergyMeter = 0.52f;
				IGT_AnimStatesCntrler.HeroAnimator.Play("GameOverHit", 1);
			}
			break;
		case 5:
		{
			pIgt_Textures.DrawTexture(IGT_Constants._GameOver_BG, rect_GameoverBg, false);
			pIgt_Textures.DrawTexture(IGT_Constants._GameOver_CoinCount, rect_Gameover_Coins, true);
			float num = 30f - (float)(IGT_Constants.nNoOfCollectedCoins.ToString().Length * 2);
			if (num < 18f)
			{
				num = 18f;
			}
			pIgt_Lable.DrawLable(new Rect(rect_Gameover_Coins.x + IGT_UIcommonFunc.ScaleX(12f), rect_Gameover_Coins.y + IGT_UIcommonFunc.ScaleY(35f), rect_Gameover_Coins.width - IGT_UIcommonFunc.ScaleX(25f), IGT_UIcommonFunc.ScaleY(20f)), IGT_Constants.nNoOfCollectedCoins.ToString(), IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(num), TextAnchor.MiddleCenter, false, new Color(0.96f, 0.93f, 0.47f), 0f, Color.black, new Vector2(2f, 2f), Color.black, -10f, new Vector2(0f, 0f));
			pIgt_Textures.DrawTexture(IGT_Constants._GameOver_KeyCount, rect_Gameover_Key, true);
			num = 28f - (float)(IGT_Constants.nTotKeysCount.ToString().Length * 2);
			if (num < 18f)
			{
				num = 18f;
			}
			pIgt_Lable.DrawLable(new Rect(rect_Gameover_Key.x + IGT_UIcommonFunc.ScaleX(12f), rect_Gameover_Key.y + IGT_UIcommonFunc.ScaleY(22f), rect_Gameover_Key.width - IGT_UIcommonFunc.ScaleX(25f), IGT_UIcommonFunc.ScaleY(24f)), IGT_Constants.nTotKeysCount.ToString(), IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(num), TextAnchor.MiddleCenter, false, new Color(0.96f, 0.93f, 0.47f), 0f, Color.black, new Vector2(2f, 2f), Color.black, -10f, new Vector2(0f, 0f));
			pIgt_Textures.DrawTexture(IGT_Constants._GameOver_LifeCount, rect_Gameover_Life, true);
			num = 26f - (float)(pHero.pIGt_LifeCalc.getCurrentLifeCount().ToString().Length * 2);
			if (num < 18f)
			{
				num = 18f;
			}
			pIgt_Lable.DrawLable(new Rect(rect_Gameover_Life.x + IGT_UIcommonFunc.ScaleX(10f), rect_Gameover_Life.y + IGT_UIcommonFunc.ScaleY(18f), rect_Gameover_Life.width - IGT_UIcommonFunc.ScaleX(25f), IGT_UIcommonFunc.ScaleY(20f)), pHero.pIGt_LifeCalc.getCurrentLifeCount().ToString(), IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(num), TextAnchor.MiddleCenter, false, new Color(0.96f, 0.93f, 0.47f), 0f, Color.black, new Vector2(2f, 2f), Color.black, -10f, new Vector2(0f, 0f));
			if (pHero.nGameMode == 0)
			{
				draw_ChaseGameOverScreen();
				But_GameoverscreenHome.Draw();
				But_GameoverscreenRestart.Draw();
				pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(110f), IGT_UIcommonFunc.ScaleY(210f), IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(40f)), "Score", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(16f), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.black, new Vector2(2f, 2f), Color.black, -10f, new Vector2(0f, 0f));
				num = 38f - (float)pHero.nScore_Current.ToString().Length;
				if (num < 30f)
				{
					num = 30f;
				}
				pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(90f), IGT_UIcommonFunc.ScaleY(240f), IGT_UIcommonFunc.ScaleX(125f), IGT_UIcommonFunc.ScaleY(40f)), ((int)pAnim_HS_menuBG.easeFunctions(0f, pHero.nScore_Current, 1f, 0)/*cast due to .constrained prefix*/).ToString(), IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(num), TextAnchor.MiddleCenter, false, Color.white, 0f, Color.black, new Vector2(2f, 2f), Color.black, -10f, new Vector2(0f, 0f));
				if (pHero.nSound == 0)
				{
					if (!pHero._AudioSource2.isPlaying && !pAnim_HS_menuBG.isAnimFinished())
					{
						pHero._AudioSource2.clip = pHero._AudioClips[16];
						pHero._AudioSource2.loop = true;
						pHero._AudioSource2.Play();
						pHero._AudioSource2.transform.position = pHero.player.transform.position;
					}
					else if (pAnim_HS_menuBG.isAnimFinished() && pHero._AudioSource2.isPlaying)
					{
						pHero._AudioSource2.Stop();
					}
				}
				pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(183f), IGT_UIcommonFunc.ScaleY(290f), IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(40f)), "Distance", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.black, new Vector2(2f, 2f), Color.black, -10f, new Vector2(0f, 0f));
				pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(191f), IGT_UIcommonFunc.ScaleY(310f), IGT_UIcommonFunc.ScaleX(70f), IGT_UIcommonFunc.ScaleY(30f)), (int)pHero.PlayerObj.fTotDistTraveled/*cast due to .constrained prefix*/ + string.Empty, IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.white, 0f, Color.black, new Vector2(2f, 2f), Color.black, -10f, new Vector2(0f, 0f));
				pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(189f), IGT_UIcommonFunc.ScaleY(314f), IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(40f)), "meters", IGT_Constants.Font_LemonR, (int)IGT_UIcommonFunc.ScaleX(8f), TextAnchor.MiddleCenter, false, Color.white, 0f, Color.black, new Vector2(2f, 2f), Color.black, -10f, new Vector2(0f, 0f));
				for (int m = 0; m < nCurBustedFaceIdx; m++)
				{
					if (m <= pHero.nAIPlayerIndex)
					{
						pIgt_Textures.DrawTexture(IGT_Constants.AIPlayer_FacePicx[m], rect_Gameover_Busted_Face[m], true);
						continue;
					}
					Color color3 = GUI.color;
					GUI.color = new Color(0f, 0.352f, 0.552f, 0.75f);
					pIgt_Textures.DrawTexture(IGT_Constants.AIPlayer_FacePicx[m], rect_Gameover_Busted_Face[m], true);
					GUI.color = color3;
				}
				if (nCurBustedFaceIdx < 10)
				{
					float fTotDuration = 0.15f;
					if (nCurBustedFaceIdx < pHero.nAIPlayerIndex)
					{
						fTotDuration = 0.35f;
					}
					float num23 = pAnim_MissionCompleted_star1.easeFunctions(4f, 1f, fTotDuration, 29);
					pIgt_Textures.DrawTexture(IGT_Constants.AIPlayer_FacePicx[nCurBustedFaceIdx], new Rect(rect_Gameover_Busted_Face[nCurBustedFaceIdx].x + rect_Gameover_Busted_Face[nCurBustedFaceIdx].width * 0.5f - rect_Gameover_Busted_Face[nCurBustedFaceIdx].width * 0.5f * num23, rect_Gameover_Busted_Face[nCurBustedFaceIdx].y + rect_Gameover_Busted_Face[nCurBustedFaceIdx].height * 0.5f - rect_Gameover_Busted_Face[nCurBustedFaceIdx].height * 0.5f * num23, rect_Gameover_Busted_Face[nCurBustedFaceIdx].width * num23, rect_Gameover_Busted_Face[nCurBustedFaceIdx].height * num23), false);
					if (pAnim_MissionCompleted_star1.isAnimFinished())
					{
						pAnim_MissionCompleted_star1.resetAllValues();
						nCurBustedFaceIdx++;
						if (nCurBustedFaceIdx == 10)
						{
							pAnim_MissionCompleted_star2.resetAllValues();
							nCurBustedBadgeIdx = 0;
						}
					}
				}
				else
				{
					if (nCurBustedBadgeIdx < pHero.nAIPlayerIndex)
					{
						float num24 = pAnim_MissionCompleted_star2.easeFunctions(5f, 1f, 0.25f, 28);
						pIgt_Textures.DrawTexture(IGT_Constants._Busted, new Rect(rect_Gameover_Busted_Badge[nCurBustedBadgeIdx].x + rect_Gameover_Busted_Badge[nCurBustedBadgeIdx].width * 0.5f - rect_Gameover_Busted_Badge[nCurBustedBadgeIdx].width * 0.5f * num24, rect_Gameover_Busted_Badge[nCurBustedBadgeIdx].y + rect_Gameover_Busted_Badge[nCurBustedBadgeIdx].height * 0.5f - rect_Gameover_Busted_Badge[nCurBustedBadgeIdx].height * 0.5f * num24, rect_Gameover_Busted_Badge[nCurBustedBadgeIdx].width * num24, rect_Gameover_Busted_Badge[nCurBustedBadgeIdx].height * num24), false);
						if (pAnim_MissionCompleted_star2.isAnimFinished())
						{
							pAnim_MissionCompleted_star2.resetAllValues();
							nCurBustedBadgeIdx++;
							if (pHero.nAIPlayerIndex == 9)
							{
								nCurBustedBadgeIdx++;
							}
						}
					}
					for (int n = 0; n < nCurBustedBadgeIdx; n++)
					{
						pIgt_Textures.DrawTexture(IGT_Constants._Busted, rect_Gameover_Busted_Badge[n], false);
					}
				}
				if (is3dObjNeeded && Event.current.type == EventType.Repaint)
				{
					pOnGUI_3dObj_Camera.GetComponent<Camera>().Render();
				}
				if (pRateit.bShowRateItAlert)
				{
					pRateit.drawRateItAlert();
				}
				else if (!pHero.bRemoveAds && bCanShowAdd && CanIgnoreAdOnFirstInstall())
				{
					bCanShowAdd = false;
					pAds.ShowInterstitial();
				}
				break;
			}
			pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(97f), IGT_UIcommonFunc.ScaleY(240f), IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(40f)), "Mission \n \t Failed", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(20f), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.black, new Vector2(2f, 2f), Color.black, -15f, Vector2.zero);
			draw_MissionGameOverScreen();
			if (pHero.pMissionData.nLevelStarCount == -1)
			{
				But_GameoverscreenHome.Draw();
				But_GameoverscreenRestart.Draw();
				if (bSkipButNeeded && bSkipButEnable)
				{
					But_MissionFailedSkip.Draw_Button();
					pIgt_Lable.DrawLable(new Rect(But_MissionFailedSkip.getX(), But_MissionFailedSkip.getY() + IGT_UIcommonFunc.ScaleY(2f), But_MissionFailedSkip.getWidth(), But_MissionFailedSkip.getHeight() / 2f), "Skip >>", IGT_Constants.Font_Nunito_Bold, (int)(But_MissionFailedSkip.getCurrentDimension().width - IGT_UIcommonFunc.ScaleX(57f)), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.black, new Vector2(0f, 0f), Color.black, 0f, Vector2.zero);
					pIgt_Lable.DrawLable(new Rect(But_MissionFailedSkip.getX() + IGT_UIcommonFunc.ScaleX(21f) + IGT_UIcommonFunc.ScaleX(6f), But_MissionFailedSkip.getY() + But_MissionFailedSkip.getHeight() / 2f + IGT_UIcommonFunc.ScaleY(2f), But_MissionFailedSkip.getWidth(), But_MissionFailedSkip.getHeight() / 2f - IGT_UIcommonFunc.ScaleY(8f)), 1000.ToString(), IGT_Constants.Font_alpha_echo, (int)(But_MissionFailedSkip.getCurrentDimension().width - IGT_UIcommonFunc.ScaleX(57f)), TextAnchor.MiddleLeft, false, Color.white, 0f, Color.black, new Vector2(0f, 0f), Color.black, 0f, Vector2.zero);
					pIgt_Textures.DrawTexture(IGT_Constants._CoinImg, adj_drawrect(new Rect(But_MissionFailedSkip.getX() + IGT_UIcommonFunc.ScaleY(20f) + IGT_UIcommonFunc.ScaleY(2f), But_MissionFailedSkip.getCurrentDimension().y + But_MissionFailedSkip.getCurrentDimension().height / 2f + IGT_UIcommonFunc.ScaleY(2f), But_MissionFailedSkip.getWidth(), But_MissionFailedSkip.getHeight() / 2f - IGT_UIcommonFunc.ScaleY(8f)), new Rect(But_MissionFailedSkip.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(10f), But_MissionFailedSkip.getY(), But_MissionFailedSkip.getCurrentDimension().width - IGT_UIcommonFunc.ScaleX(56f), But_MissionFailedSkip.getCurrentDimension().width - IGT_UIcommonFunc.ScaleX(56f)), 0), false);
				}
			}
			else
			{
				But_MissonCompleted_Next.Draw();
				But_MissonCompleted_Retry.Draw();
				But_MissonCompleted_Home.Draw();
			}
			if (is3dObjNeeded && Event.current.type == EventType.Repaint)
			{
				pOnGUI_3dObj_Camera.GetComponent<Camera>().Render();
			}
			if (!pHero.bRemoveAds && bCanShowAdd && CanIgnoreAdOnFirstInstall())
			{
				bCanShowAdd = false;
				pAds.ShowInterstitial();
			}
			break;
		}
		case 10:
		{
			pIgt_Textures.DrawTexture(IGT_Constants._GameOver_BG, rect_GameoverBg, false);
			draw_MissionGameOverScreen();
			But_MissonCompleted_Next.Draw();
			But_MissonCompleted_Retry.Draw();
			But_MissonCompleted_Home.Draw();
			for (int l = 0; l < 3; l++)
			{
				pIgt_Textures.DrawTexture(IGT_Constants._Star_Empty, rect_starPos[l], false);
			}
			float num20 = 1f;
			if (pHero.nStar_Current > 2 && pAnim_MissionCompleted_star1.isAnimFinished() && pAnim_MissionCompleted_star2.isAnimFinished())
			{
				pIgt_Textures.DrawTexture(IGT_Constants._StarImg, rect_starPos[0], false);
				pIgt_Textures.DrawTexture(IGT_Constants._StarImg, rect_starPos[1], false);
				num20 = pAnim_MissionCompleted_star3.easeFunctions(3f, 1f, 0.5f, 14);
				pIgt_Textures.DrawTexture(IGT_Constants._StarImg, new Rect(rect_starPos[2].x + rect_starPos[2].width * 0.5f - rect_starPos[2].width * 0.5f * num20, rect_starPos[2].y + rect_starPos[2].height * 0.5f - rect_starPos[2].height * 0.5f * num20, rect_starPos[2].width * num20, rect_starPos[2].height * num20), false);
			}
			else if (pHero.nStar_Current > 1 && pAnim_MissionCompleted_star1.isAnimFinished())
			{
				pIgt_Textures.DrawTexture(IGT_Constants._StarImg, rect_starPos[0], false);
				num20 = pAnim_MissionCompleted_star2.easeFunctions(3f, 1f, 0.5f, 14);
				pIgt_Textures.DrawTexture(IGT_Constants._StarImg, new Rect(rect_starPos[1].x + rect_starPos[1].width * 0.5f - rect_starPos[1].width * 0.5f * num20, rect_starPos[1].y + rect_starPos[1].height * 0.5f - rect_starPos[1].height * 0.5f * num20, rect_starPos[1].width * num20, rect_starPos[1].height * num20), false);
				if (pAnim_MissionCompleted_star2.isAnimFinished())
				{
					pAnim_MissionCompleted_star3.resetAllValues();
				}
			}
			else if (pHero.nStar_Current > 0)
			{
				num20 = pAnim_MissionCompleted_star1.easeFunctions(3f, 1f, 0.5f, 14);
				pIgt_Textures.DrawTexture(IGT_Constants._StarImg, new Rect(rect_starPos[0].x + rect_starPos[0].width * 0.5f - rect_starPos[0].width * 0.5f * num20, rect_starPos[0].y + rect_starPos[0].height * 0.5f - rect_starPos[0].height * 0.5f * num20, rect_starPos[0].width * num20, rect_starPos[0].height * num20), false);
				if (pAnim_MissionCompleted_star1.isAnimFinished())
				{
					pAnim_MissionCompleted_star2.resetAllValues();
				}
			}
			float num = 30f - (float)pHero.nScore_Current.ToString().Length;
			if (num < 22f)
			{
				num = 22f;
			}
			pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(100f), IGT_UIcommonFunc.ScaleY(240f), IGT_UIcommonFunc.ScaleX(125f), IGT_UIcommonFunc.ScaleY(40f)), ((int)pAnim_HS_menuBG.easeFunctions(0f, pHero.nScore_Current, 1f, 0)/*cast due to .constrained prefix*/).ToString(), IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(num), TextAnchor.MiddleCenter, false, Color.white, 0f, Color.black, new Vector2(2f, 2f), Color.black);
			if (pHero.nSound == 0)
			{
				if (!pHero._AudioSource2.isPlaying && !pAnim_HS_menuBG.isAnimFinished())
				{
					pHero._AudioSource2.clip = pHero._AudioClips[16];
					pHero._AudioSource2.loop = true;
					pHero._AudioSource2.Play();
					pHero._AudioSource2.transform.position = pHero.player.transform.position;
				}
				else if (pAnim_HS_menuBG.isAnimFinished() && pHero._AudioSource2.isPlaying)
				{
					pHero._AudioSource2.Stop();
				}
			}
			pIgt_Textures.DrawTexture(IGT_Constants._GameOver_CoinCount, rect_Gameover_Coins, true);
			num = 30f - (float)(IGT_Constants.nNoOfCollectedCoins.ToString().Length * 2);
			if (num < 18f)
			{
				num = 18f;
			}
			pIgt_Lable.DrawLable(new Rect(rect_Gameover_Coins.x + IGT_UIcommonFunc.ScaleX(12f), rect_Gameover_Coins.y + IGT_UIcommonFunc.ScaleY(35f), rect_Gameover_Coins.width - IGT_UIcommonFunc.ScaleX(25f), IGT_UIcommonFunc.ScaleY(20f)), IGT_Constants.nNoOfCollectedCoins.ToString(), IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(num), TextAnchor.MiddleCenter, false, new Color(0.96f, 0.93f, 0.47f), 0f, Color.black, new Vector2(2f, 2f), Color.black, -10f, new Vector2(0f, 0f));
			pIgt_Textures.DrawTexture(IGT_Constants._GameOver_KeyCount, rect_Gameover_Key, true);
			num = 28f - (float)(IGT_Constants.nTotKeysCount.ToString().Length * 2);
			if (num < 18f)
			{
				num = 18f;
			}
			pIgt_Lable.DrawLable(new Rect(rect_Gameover_Key.x + IGT_UIcommonFunc.ScaleX(12f), rect_Gameover_Key.y + IGT_UIcommonFunc.ScaleY(22f), rect_Gameover_Key.width - IGT_UIcommonFunc.ScaleX(25f), IGT_UIcommonFunc.ScaleY(24f)), IGT_Constants.nTotKeysCount.ToString(), IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(num), TextAnchor.MiddleCenter, false, new Color(0.96f, 0.93f, 0.47f), 0f, Color.black, new Vector2(2f, 2f), Color.black, -10f, new Vector2(0f, 0f));
			pIgt_Textures.DrawTexture(IGT_Constants._GameOver_LifeCount, rect_Gameover_Life, true);
			num = 26f - (float)(pHero.pIGt_LifeCalc.getCurrentLifeCount().ToString().Length * 2);
			if (num < 18f)
			{
				num = 18f;
			}
			pIgt_Lable.DrawLable(new Rect(rect_Gameover_Life.x + IGT_UIcommonFunc.ScaleX(10f), rect_Gameover_Life.y + IGT_UIcommonFunc.ScaleY(18f), rect_Gameover_Life.width - IGT_UIcommonFunc.ScaleX(25f), IGT_UIcommonFunc.ScaleY(20f)), pHero.pIGt_LifeCalc.getCurrentLifeCount().ToString(), IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(num), TextAnchor.MiddleCenter, false, new Color(0.96f, 0.93f, 0.47f), 0f, Color.black, new Vector2(2f, 2f), Color.black, -10f, new Vector2(0f, 0f));
			if (bChaseLockedAlert && pAnim_HS_menuBG.isAnimFinished())
			{
				if (!bChaseUnlockAlertAnim)
				{
					bChaseUnlockAlertAnim = true;
					pAnim_menu_LeaderBoard.resetAllValues();
				}
				float num21 = pAnim_menu_LeaderBoard.easeFunctions(0.1f, 1f, 1f, 30);
				GUIUtility.ScaleAroundPivot(new Vector2(num21, num21), new Vector2((float)Screen.width * 0.5f, (float)Screen.height * 0.5f));
				pIgt_Textures.DrawTexture(IGT_Constants._Abort_BG, rect_lockBG, false);
				pIgt_Textures.DrawTexture(IGT_Constants._GameIcon, new Rect(rect_lockBG.x + IGT_UIcommonFunc.ScaleX(14f), rect_lockBG.y + IGT_UIcommonFunc.ScaleY(26f), IGT_UIcommonFunc.ScaleX(70f), IGT_UIcommonFunc.ScaleY(70f)), false);
				pIgt_Lable.DrawLable(new Rect(rect_lockBG.x, rect_lockBG.y - IGT_UIcommonFunc.ScaleY(28f), rect_lockBG.width, rect_lockBG.height), " CHASE  GAME  UNLOCKED ", IGT_Constants.Font_LemonR, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, true, Color.blue, 3f, Color.yellow, new Vector2(1f, 1f), Color.black, 0f, Vector2.zero);
				But_ChsUnlockAlert_Play.Draw();
				pIgt_Lable.DrawLable(new Rect(But_ChsUnlockAlert_Play.getCurrentDimension().x, But_ChsUnlockAlert_Play.getCurrentDimension().y, But_ChsUnlockAlert_Play.getCurrentDimension().width, But_ChsUnlockAlert_Play.getCurrentDimension().height), "PLAY", IGT_Constants.Font_LemonR, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, true, Color.white, 1f, Color.black, new Vector2(1f, 1f), Color.black, 0f, Vector2.zero);
				But_ChsUnlockAlert_Close.Draw();
				GUI.matrix = Matrix4x4.identity;
			}
			if (is3dObjNeeded && Event.current.type == EventType.Repaint)
			{
				pOnGUI_3dObj_Camera.GetComponent<Camera>().Render();
			}
			if (pRateit.bShowRateItAlert)
			{
				pRateit.drawRateItAlert();
			}
			else if (!pHero.bRemoveAds && bCanShowAdd && pAnim_HS_menuBG.isAnimFinished() && CanIgnoreAdOnFirstInstall())
			{
				bCanShowAdd = false;
				pAds.ShowInterstitial();
			}
			break;
		}
		case 6:
			pIgt_Textures.DrawTexture(IGT_Constants._SettingsBg, rect_puchaseBG, false);
			if (nGetCurrentPlatform() != 0)
			{
				But_BackpurchaseWindow.Draw();
			}
			pIgt_Textures.DrawTexture(IGT_Constants._Shop_Tab, rect_purchaseTitlebar, false);
			if (nPurchaseType == 0)
			{
				pIgt_Textures.DrawTexture(IGT_Constants._Shop_Store, ScrollViewRectImg_purchaseWindow, false);
				pIgt_Textures.DrawTexture(IGT_Constants._Store_Icon, new Rect(0f * (rect_purchaseTitlebar.width / 4f) + IGT_UIcommonFunc.ScaleX(6f), rect_purchaseTitlebar.y + IGT_UIcommonFunc.ScaleY(4f), IGT_UIcommonFunc.ScaleX(20f), IGT_UIcommonFunc.ScaleY(20f)), false);
				pIgt_Lable.DrawLable(new Rect(0f * (rect_purchaseTitlebar.width / 4f) + IGT_UIcommonFunc.ScaleX(13f), rect_purchaseTitlebar.y, rect_purchaseTitlebar.width / 4f, rect_purchaseTitlebar.height), "Store", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(16f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(1f, 1f), Color.black);
			}
			else if (nPurchaseType == 1)
			{
				pIgt_Textures.DrawTexture(IGT_Constants._Shop_Combo, ScrollViewRectImg_purchaseWindow, false);
				pIgt_Textures.DrawTexture(IGT_Constants._Combo_Icon, new Rect(1f * (rect_purchaseTitlebar.width / 4f) + IGT_UIcommonFunc.ScaleX(3.5f), rect_purchaseTitlebar.y + IGT_UIcommonFunc.ScaleY(5f), IGT_UIcommonFunc.ScaleX(20f), IGT_UIcommonFunc.ScaleY(20f)), false);
				pIgt_Lable.DrawLable(new Rect(1f * (rect_purchaseTitlebar.width / 4f) + IGT_UIcommonFunc.ScaleX(11f), rect_purchaseTitlebar.y, rect_purchaseTitlebar.width / 4f, rect_purchaseTitlebar.height), "Combo", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(16f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(1f, 1f), Color.black);
			}
			else if (nPurchaseType == 2)
			{
				pIgt_Textures.DrawTexture(IGT_Constants._Shop_Boost, ScrollViewRectImg_purchaseWindow, false);
				pIgt_Textures.DrawTexture(IGT_Constants._Boost_Icon, new Rect(2f * (rect_purchaseTitlebar.width / 4f) + IGT_UIcommonFunc.ScaleX(-1f), rect_purchaseTitlebar.y + IGT_UIcommonFunc.ScaleY(5f), IGT_UIcommonFunc.ScaleX(20f), IGT_UIcommonFunc.ScaleY(20f)), false);
				pIgt_Lable.DrawLable(new Rect(2f * (rect_purchaseTitlebar.width / 4f) + IGT_UIcommonFunc.ScaleX(6f), rect_purchaseTitlebar.y, rect_purchaseTitlebar.width / 4f, rect_purchaseTitlebar.height), "Boost", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(16f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(1f, 1f), Color.black);
			}
			else if (nPurchaseType == 3)
			{
				pIgt_Textures.DrawTexture(IGT_Constants._Shop_Free, ScrollViewRectImg_purchaseWindow, false);
				pIgt_Textures.DrawTexture(IGT_Constants._Free_Icon, new Rect(3f * (rect_purchaseTitlebar.width / 4f) + IGT_UIcommonFunc.ScaleX(4f), rect_purchaseTitlebar.y + IGT_UIcommonFunc.ScaleY(5f), IGT_UIcommonFunc.ScaleX(20f), IGT_UIcommonFunc.ScaleY(20f)), false);
				pIgt_Lable.DrawLable(new Rect(3f * (rect_purchaseTitlebar.width / 4f) + IGT_UIcommonFunc.ScaleX(6f), rect_purchaseTitlebar.y, rect_purchaseTitlebar.width / 4f, rect_purchaseTitlebar.height), "Free", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(16f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(1f, 1f), Color.black);
			}
			PurchaseWindowDataSelection();
			if (nPurchaseType == 3 && pMoregame.webViewObject != null && pMoregame.webViewObject.GetVisibility())
			{
				pMoregame.draw(pIgt_Textures, IGT_Constants.LikePageTitle);
			}
			if (bBoostUpgradeAnim)
			{
				if (pHero.pBezierAnimation_Group.Count > 0)
				{
					pHero.BezierMovementGroupAnimation();
				}
				else
				{
					bBoostUpgradeAnim = false;
				}
			}
			if (bHS_moregames)
			{
				Moregames_window();
			}
			if (!pHero.bRemoveAds)
			{
				pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(0f), ScrollViewRectImg_purchaseWindow.y + ScrollViewRectImg_purchaseWindow.height - IGT_UIcommonFunc.ScaleY(3f), IGT_UIcommonFunc.ScaleX(320f), IGT_UIcommonFunc.ScaleY(40f)), "* Any game item purchase will remove ads! *", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(13f), TextAnchor.MiddleCenter, false, new Color(1f, 1f, 1f, pAnim_menu_LeaderBoard.easeFunctions(0f, 1f, 0.95f, 0)), new Vector2(1f, 1f), Color.black);
				if (pAnim_menu_LeaderBoard.isAnimFinished() && pAnim_menu_LeaderBoard.getIsReverse())
				{
					pAnim_menu_LeaderBoard.resetAllValues();
				}
				if (pAnim_menu_LeaderBoard.isAnimFinished() && !pAnim_menu_LeaderBoard.getIsReverse())
				{
					pAnim_menu_LeaderBoard.resetAllValues();
					pAnim_menu_LeaderBoard.setIsReverse(true);
				}
			}
			break;
		case 12:
		{
			pIgt_Textures.DrawTexture(IGT_Constants._Menu_Bg, rect_Menu_Bg, false);
			But_Menu_life.Draw();
			But_Menu_Key.Draw();
			But_Menu_Coin.Draw();
			pIgt_Textures.DrawTexture(IGT_Constants._Life, adj_drawrect(But_Menu_life.getOriginalDimension(), new Rect(But_Menu_life.getCurrentDimension().x - IGT_UIcommonFunc.ScaleX(10.5f), But_Menu_life.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(3f), IGT_UIcommonFunc.ScaleX(32f), But_Menu_life.getCurrentDimension().height + IGT_UIcommonFunc.ScaleY(6f)), 0), false);
			pIgt_Textures.DrawTexture(IGT_Constants._KeyImg, adj_drawrect(But_Menu_Key.getOriginalDimension(), new Rect(But_Menu_Key.getCurrentDimension().x - IGT_UIcommonFunc.ScaleX(4f), But_Menu_Key.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(5f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(32f)), 0), false);
			float x = IGT_UIcommonFunc.ScaleX(1.75f) + (float)(IGT_Constants.nTotNoOfCoins.ToString().Length * 2);
			pIgt_Textures.DrawTexture(IGT_Constants._CoinImg, adj_drawrect(But_Menu_Coin.getOriginalDimension(), new Rect(But_Menu_Coin.getCurrentDimension().x - IGT_UIcommonFunc.ScaleX(x), But_Menu_Coin.getCurrentDimension().y, IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleX(30f)), 0), false);
			float num = 22f - (float)(IGT_Constants.nTotKeysCount.ToString().Length * 2);
			if (num < 14f)
			{
				num = 14f;
			}
			pIgt_Lable.DrawLable(new Rect(But_Menu_Key.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(4f), But_Menu_Key.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(1f), But_Menu_Key.getCurrentDimension().width, But_Menu_Key.getCurrentDimension().height), IGT_Constants.nTotKeysCount.ToString(), IGT_Constants.Font_TTMasters, (int)(IGT_UIcommonFunc.ScaleX(num) * But_Menu_Key.getCurrentDimension().width / But_Menu_Key.getWidth()), TextAnchor.MiddleCenter, false, new Color(1f, 1f, 1f, 1f), 1.5f, Color.black, new Vector2(0f, 0f), Color.black);
			num = 24f - (float)(IGT_Constants.nTotNoOfCoins.ToString().Length * 2);
			if (num < 14f)
			{
				num = 14f;
			}
			pIgt_Lable.DrawLable(new Rect(But_Menu_Coin.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(3f), But_Menu_Coin.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(1f), But_Menu_Coin.getCurrentDimension().width, But_Menu_Coin.getCurrentDimension().height), IGT_Constants.nTotNoOfCoins.ToString(), IGT_Constants.Font_TTMasters, (int)(IGT_UIcommonFunc.ScaleX(num) * But_Menu_Coin.getCurrentDimension().width / But_Menu_Coin.getWidth()), TextAnchor.MiddleCenter, false, new Color(1f, 1f, 1f, 1f), 1.5f, Color.black, new Vector2(0f, 0f), Color.black);
			num = 22f - (float)(pHero.pIGt_LifeCalc.getCurrentLifeCount().ToString().Length * 2);
			if (num < 14f)
			{
				num = 14f;
			}
			pIgt_Lable.DrawLable(new Rect(But_Menu_life.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(6f), But_Menu_life.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(1f), But_Menu_life.getCurrentDimension().width, But_Menu_life.getCurrentDimension().height), pHero.pIGt_LifeCalc.getCurrentLifeCount().ToString(), IGT_Constants.Font_TTMasters, (int)(IGT_UIcommonFunc.ScaleX(num) * But_Menu_life.getCurrentDimension().width / But_Menu_life.getWidth()), TextAnchor.MiddleCenter, false, new Color(1f, 1f, 1f, 1f), 1.5f, Color.black, new Vector2(0f, 0f), Color.black);
			But_Menu_Shop.Draw();
			But_Menu_LeaderBoard.Draw();
			But_Menu_Achievement.Draw();
			But_Menu_Free.Draw();
			But_Menu_Share.Draw();
			But_Menu_Settings.Draw();
			But_Menu_MoreGames.Draw();
			But_Menu_About.Draw();
			But_Menu_back.Draw();
			if (Event.current.type == EventType.Repaint)
			{
				heroSelection_onGUICam.GetComponent<Camera>().Render();
			}
			if (ready_character_idx[centre_character] == 1 && !coins_fission)
			{
				But_Menu_Ready.Draw_Button();
				pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(155f), IGT_UIcommonFunc.ScaleY(135f), IGT_UIcommonFunc.ScaleX(10f), IGT_UIcommonFunc.ScaleY(50f)), " Ready", IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.white, 2f, Color.black, new Vector2(1f, 1f), Color.black, 0f, Vector2.zero);
				menu_btn_rotAng = 0f;
			}
			else
			{
				But_Menu_Select.Draw_Button();
				pIgt_Textures.DrawTexture(IGT_Constants._CoinImg, adj_drawrect(But_Menu_Select.getOriginalDimension(), new Rect(But_Menu_Select.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(7.6f), But_Menu_Select.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(6f), IGT_UIcommonFunc.ScaleX(20f), IGT_UIcommonFunc.ScaleX(20f)), 0), false);
				pIgt_Lable.DrawLable(new Rect(But_Menu_Select.getCurrentDimension().x, But_Menu_Select.getCurrentDimension().y, But_Menu_Select.getCurrentDimension().width, But_Menu_Select.getCurrentDimension().height), "        " + Character_Buy_Coins[centre_character], IGT_Constants.Font_TitanOne, (int)(But_Menu_Select.getCurrentDimension().width / 8f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, new Vector2(1f, 1f), Color.gray, 0f, Vector2.zero);
			}
			pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(155f), IGT_UIcommonFunc.ScaleY(113f), IGT_UIcommonFunc.ScaleX(10f), IGT_UIcommonFunc.ScaleY(50f)), string.Empty + character_slogans[centre_character], IGT_Constants.Font_LemonR, (int)(But_Menu_Select.getCurrentDimension().width / 8f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, new Vector2(1f, 1f), Color.gray, 0f, Vector2.zero);
			if (ready_character_idx[centre_character] == 1 && coins_fission)
			{
				for (int i = 1; i < 10; i++)
				{
					pIgt_Textures.DrawTexture(IGT_Constants._CoinImg, new Rect(IGT_UIcommonFunc.ScaleX(coin_curve[i].x), IGT_UIcommonFunc.ScaleY(coin_curve[i].y), IGT_UIcommonFunc.ScaleX(20f), IGT_UIcommonFunc.ScaleY(20f)), true);
				}
			}
			if (centre_character != 0)
			{
				But_Menu_left.Draw();
			}
			if (centre_character != 4)
			{
				But_Menu_Right.Draw();
			}
			if (bLeaderBoardbtnClick)
			{
				pIgt_Textures.DrawTexture(IGT_Constants._GreyOverLay, new Rect(0f, 0f, Screen.width, Screen.height), false);
				float num2 = pAnim_menu_LeaderBoard.easeFunctions(0.01f, 1f, 1f, 14);
				GUIUtility.ScaleAroundPivot(new Vector2(num2, num2), new Vector2(rect_Menu_Bg.x + rect_Menu_Bg.width * 0.5f, rect_Menu_Bg.y + rect_Menu_Bg.height * 0.5f));
				if (pAnim_menu_LeaderBoard.getIsReverse() && pAnim_menu_LeaderBoard.isAnimFinished())
				{
					bLeaderBoardbtnClick = false;
				}
				else
				{
					But_Menu_GoogleLB.Draw();
					But_Menu_FBLB.Draw();
					pIgt_Textures.DrawTexture(IGT_Constants._glowLB, new Rect(IGT_UIcommonFunc.ScaleX(121f), IGT_UIcommonFunc.ScaleY(170f), IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(80f)), false);
					But_Menu_LeaderBoard.Draw();
				}
				GUI.matrix = Matrix4x4.identity;
			}
			else if (bFBbtnClick)
			{
				draw_Leaderboard_FBAlert();
			}
			else if (bGoogleLbbtnClick)
			{
				pIgt_Textures.DrawTexture(IGT_Constants._GreyOverLay, new Rect(0f, 0f, Screen.width, Screen.height), false);
				GplusAlertWindow();
			}
			else if (bHS_allshare)
			{
				drawAllShare();
			}
			else if (bHS_moregames)
			{
				Moregames_window();
			}
			else if (bHS_settings)
			{
				settings_window();
			}
			else if (bHS_about)
			{
				pIgt_Textures.DrawTexture(IGT_Constants._GreyOverLay, new Rect(0f, 0f, Screen.width, Screen.height), false);
				if (pAnim_MailBox.getIsReverse() && pAnim_MailBox.isAnimFinished())
				{
					bHS_about = false;
					break;
				}
				float num3 = pAnim_MailBox.easeFunctions(0.01f, 1f, 0.8f, 28);
				GUIUtility.ScaleAroundPivot(new Vector2(num3, num3), new Vector2(rect_AllShareBg.x + rect_AllShareBg.width * 0.5f, rect_AllShareBg.y + rect_AllShareBg.height * 0.5f));
				pIgt_Textures.DrawTexture(IGT_Constants._SettingsBg, rectAboutBG.x, rectAboutBG.y, rectAboutBG.width, rectAboutBG.height);
				drawAbout();
				btn_AboutClose.Draw_Button();
				GUI.matrix = Matrix4x4.identity;
			}
			break;
		}
		case 16:
			pIgt_Textures.DrawTexture(IGT_Constants._NotEnoughKeys_BG, rect_NotEnoughKeysBG, false);
			pIgt_Textures.DrawTexture(IGT_Constants._KeyImg, new Rect(rect_NotEnoughKeysBG.x - IGT_UIcommonFunc.ScaleX(37f) / 3f, rect_NotEnoughKeysBG.y - IGT_UIcommonFunc.ScaleY(30f) / 3f, IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(50f)), true);
			But_NotEnoughKeys_Close.Draw();
			pIgt_Lable.DrawLable(new Rect(rect_NotEnoughKeysBG.x + rect_NotEnoughKeysBG.width / 2f - IGT_UIcommonFunc.ScaleX(50f) / 2f, rect_NotEnoughKeysBG.y + IGT_UIcommonFunc.ScaleY(18f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(40f)), "NOT ENOUGH KEYS", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(18f), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(4f, 4f), Color.black);
			But_NotEnoughKeys_Purchase2.Draw();
			But_NotEnoughKeys_Purchase1.Draw();
			But_NotEnoughKeys_Purchase3.Draw();
			pIgt_Lable.DrawLable(new Rect(But_NotEnoughKeys_Purchase2.getCurrentDimension().x + But_NotEnoughKeys_Purchase2.getCurrentDimension().width / 4.5f, But_NotEnoughKeys_Purchase2.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(6f), But_NotEnoughKeys_Purchase2.getCurrentDimension().width / 3f, But_NotEnoughKeys_Purchase2.getCurrentDimension().height / 3f), pHero.pPurchaseItemsData_Store[6].ProductDescription.Split(' ')[0], IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(13f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, new Vector2(1f, 1f), Color.black);
			pIgt_Lable.DrawLable(new Rect(But_NotEnoughKeys_Purchase1.getCurrentDimension().x + But_NotEnoughKeys_Purchase1.getCurrentDimension().width / 4.5f + IGT_UIcommonFunc.ScaleX(2.5f), But_NotEnoughKeys_Purchase1.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(6f), But_NotEnoughKeys_Purchase1.getCurrentDimension().width / 3f, But_NotEnoughKeys_Purchase1.getCurrentDimension().height / 3f), pHero.pPurchaseItemsData_Store[5].ProductDescription.Split(' ')[0], IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(13f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, new Vector2(1f, 1f), Color.black);
			pIgt_Lable.DrawLable(new Rect(But_NotEnoughKeys_Purchase3.getCurrentDimension().x + But_NotEnoughKeys_Purchase3.getCurrentDimension().width / 4.5f, But_NotEnoughKeys_Purchase3.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(6f), But_NotEnoughKeys_Purchase3.getCurrentDimension().width / 3f, But_NotEnoughKeys_Purchase3.getCurrentDimension().height / 3f), pHero.pPurchaseItemsData_Store[7].ProductDescription.Split(' ')[0], IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, new Vector2(1f, 1f), Color.black);
			if (pHero.pIGT_IAPManagerAssist.isInitialisedSuccess())
			{
				pIgt_Lable.DrawLable(new Rect(But_NotEnoughKeys_Purchase2.getCurrentDimension().x, But_NotEnoughKeys_Purchase2.getCurrentDimension().y + But_NotEnoughKeys_Purchase2.getCurrentDimension().height / 2f + IGT_UIcommonFunc.ScaleY(1.5f), But_NotEnoughKeys_Purchase2.getCurrentDimension().width, But_NotEnoughKeys_Purchase2.getCurrentDimension().height / 2.3f), pHero.pIGT_IAPManagerAssist.GetPriceforEachProduct(pHero.pPurchaseItemsData_Store[6].ProductID_GooglePlayStore), IGT_Constants.Font_Nunito, (int)IGT_UIcommonFunc.ScaleX(10f), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black, 0f, Vector2.zero);
				pIgt_Lable.DrawLable(new Rect(But_NotEnoughKeys_Purchase1.getCurrentDimension().x, But_NotEnoughKeys_Purchase1.getCurrentDimension().y + But_NotEnoughKeys_Purchase1.getCurrentDimension().height / 2f + IGT_UIcommonFunc.ScaleY(1.5f), But_NotEnoughKeys_Purchase1.getCurrentDimension().width, But_NotEnoughKeys_Purchase1.getCurrentDimension().height / 2.3f), pHero.pIGT_IAPManagerAssist.GetPriceforEachProduct(pHero.pPurchaseItemsData_Store[5].ProductID_GooglePlayStore), IGT_Constants.Font_Nunito, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black, 0f, Vector2.zero);
				pIgt_Lable.DrawLable(new Rect(But_NotEnoughKeys_Purchase3.getCurrentDimension().x, But_NotEnoughKeys_Purchase3.getCurrentDimension().y + But_NotEnoughKeys_Purchase3.getCurrentDimension().height / 2f + IGT_UIcommonFunc.ScaleY(1.5f), But_NotEnoughKeys_Purchase3.getCurrentDimension().width, But_NotEnoughKeys_Purchase3.getCurrentDimension().height / 2.3f), pHero.pIGT_IAPManagerAssist.GetPriceforEachProduct(pHero.pPurchaseItemsData_Store[7].ProductID_GooglePlayStore), IGT_Constants.Font_Nunito, (int)IGT_UIcommonFunc.ScaleX(10f), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black, 0f, Vector2.zero);
			}
			else
			{
				pIgt_Lable.DrawLable(new Rect(But_NotEnoughKeys_Purchase2.getCurrentDimension().x, But_NotEnoughKeys_Purchase2.getCurrentDimension().y + But_NotEnoughKeys_Purchase2.getCurrentDimension().height / 2f + IGT_UIcommonFunc.ScaleY(1.5f), But_NotEnoughKeys_Purchase2.getCurrentDimension().width, But_NotEnoughKeys_Purchase2.getCurrentDimension().height / 2.3f), pHero.pPurchaseItemsData_Store[6].DefaultPrice, IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black);
				pIgt_Lable.DrawLable(new Rect(But_NotEnoughKeys_Purchase1.getCurrentDimension().x, But_NotEnoughKeys_Purchase1.getCurrentDimension().y + But_NotEnoughKeys_Purchase1.getCurrentDimension().height / 2f + IGT_UIcommonFunc.ScaleY(1.5f), But_NotEnoughKeys_Purchase1.getCurrentDimension().width, But_NotEnoughKeys_Purchase1.getCurrentDimension().height / 2.3f), pHero.pPurchaseItemsData_Store[5].DefaultPrice, IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black);
				pIgt_Lable.DrawLable(new Rect(But_NotEnoughKeys_Purchase3.getCurrentDimension().x, But_NotEnoughKeys_Purchase3.getCurrentDimension().y + But_NotEnoughKeys_Purchase3.getCurrentDimension().height / 2f + IGT_UIcommonFunc.ScaleY(1.5f), But_NotEnoughKeys_Purchase3.getCurrentDimension().width, But_NotEnoughKeys_Purchase3.getCurrentDimension().height / 2.3f), pHero.pPurchaseItemsData_Store[7].DefaultPrice, IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black);
			}
			break;
		case 0:
			if (!bNoMoreLiveAlert && !bInappAlert && !bHS_mailbox && !bHS_sendlife && !bHS_asklife && !bHS_settings && !bHS_allshare)
			{
				But_HS_Missions.Draw();
				pIgt_Lable.DrawLable(But_HS_Missions.getOriginalDimension(), IGT_Constants.HomeScreen_MissionLableName, IGT_Constants.Font_TakeYour, (int)((float)fontSize_HS_Chase_Mission * But_HS_Missions.getCurrentDimension().width / But_HS_Missions.getWidth()), Color.black, TextAnchor.MiddleCenter, false, -10f);
				But_HS_Chase.Draw();
				pIgt_Lable.DrawLable(But_HS_Chase.getOriginalDimension(), "Chase", IGT_Constants.Font_TakeYour, (int)((float)fontSize_HS_Chase_Mission * But_HS_Chase.getCurrentDimension().width / But_HS_Chase.getWidth()), Color.black, TextAnchor.MiddleCenter, false, 10f, 1f);
				if (pHero.nTutorial == 0 && !But_HS_Chase.getStartupAnimFinished())
				{
					pIgt_Textures.DrawTexture(IGT_Constants._Lock, new Rect(But_HS_Chase.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(60f), But_HS_Chase.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(20f), IGT_UIcommonFunc.ScaleX(20f), IGT_UIcommonFunc.ScaleY(25f)), 10f, new Vector2(1f, 0f));
				}
				if (pHero.nChaseNewBadge == 0 && !But_HS_Chase.getStartupAnimFinished())
				{
					if (Time.time - fChaseNewTap_StrtTime > 4f && Time.time - fChaseNewTap_StrtTime <= 5f)
					{
						pIGT_Sprites_ChaseNewTap.draw();
						if (pIGT_Sprites_ChaseNewTap.getFramNumber() == 2)
						{
							pIgt_Textures.DrawTexture(IGT_Constants._CountDown_Glow, new Rect(IGT_UIcommonFunc.ScaleX(202f), IGT_UIcommonFunc.ScaleY(325f), IGT_UIcommonFunc.ScaleX(60f), IGT_UIcommonFunc.ScaleY(60f)), false);
						}
					}
					else if (Time.time - fChaseNewTap_StrtTime > 5f)
					{
						fChaseNewTap_StrtTime = Time.time;
					}
					if (!bNewBadgeIsInAnim && !But_HS_Chase.getStartupAnimFinished() && Time.time - fNewBadgeAnimStrtTime > 4f)
					{
						pAnim_MissionCompleted_star1.resetAllValues();
						bNewBadgeIsInAnim = true;
					}
					if (bNewBadgeIsInAnim)
					{
						float num4 = pAnim_MissionCompleted_star1.easeFunctions(1f, 1.3f, 0.5f, 0);
						if (pAnim_MissionCompleted_star1.isAnimFinished() && !pAnim_MissionCompleted_star1.getIsReverse())
						{
							pAnim_MissionCompleted_star1.resetAllValues();
							pAnim_MissionCompleted_star1.setIsReverse(true);
						}
						if (bNewBadgeIsInAnim && pAnim_MissionCompleted_star1.isAnimFinished() && pAnim_MissionCompleted_star1.getIsReverse())
						{
							bNewBadgeIsInAnim = false;
							fNewBadgeAnimStrtTime = Time.time;
						}
						GUIUtility.ScaleAroundPivot(new Vector2(num4, num4), new Vector2(But_HS_Chase.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(69f) + IGT_UIcommonFunc.ScaleX(45f) * 0.5f, But_HS_Chase.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(20f) + IGT_UIcommonFunc.ScaleY(29f) * 0.5f));
						pIgt_Textures.DrawTexture(IGT_Constants._New, new Rect(But_HS_Chase.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(69f), But_HS_Chase.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(20f), IGT_UIcommonFunc.ScaleX(45f), IGT_UIcommonFunc.ScaleY(29f)), false);
						GUI.matrix = Matrix4x4.identity;
					}
					else
					{
						pIgt_Textures.DrawTexture(IGT_Constants._New, new Rect(But_HS_Chase.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(69f), But_HS_Chase.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(20f), IGT_UIcommonFunc.ScaleX(45f), IGT_UIcommonFunc.ScaleY(29f)), false);
					}
				}
			}
			pIgt_Textures.DrawTexture(IGT_Constants._CornerBoard_green, rect_HS_LeaderBoardBg, true);
			But_HS_LeaderBoard.Draw();
			pIgt_Textures.DrawTexture(IGT_Constants._CornerBoard_green_Rt, rect_HS_SettingsBg, true);
			But_HS_Settings.Draw();
			pIgt_Textures.DrawTexture(IGT_Constants._ScoreBoard_green, rect_HS_TopFrame, false);
			But_HS_MailBox.Draw();
			if (pFacebook.isFBLoginSucess() && listAskSend.Count > 0)
			{
				pIgt_Textures.DrawTexture(IGT_Constants._EmailCount, new Rect(But_HS_MailBox.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(18f), But_HS_MailBox.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(2f), IGT_UIcommonFunc.ScaleX(12f), IGT_UIcommonFunc.ScaleY(12f)), true);
				int num5 = (int)IGT_UIcommonFunc.ScaleX(10f);
				switch (listAskSend.Count.ToString().Length)
				{
				case 1:
					num5 = (int)IGT_UIcommonFunc.ScaleX(10f);
					break;
				case 2:
					num5 = (int)IGT_UIcommonFunc.ScaleX(9f);
					break;
				default:
					num5 = (int)IGT_UIcommonFunc.ScaleX(8f);
					break;
				}
				pIgt_Lable.DrawLable(new Rect(But_HS_MailBox.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(18f), But_HS_MailBox.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(4f), IGT_UIcommonFunc.ScaleX(12f), IGT_UIcommonFunc.ScaleY(12f)), listAskSend.Count.ToString(), IGT_Constants.Font_LemonR, num5, TextAnchor.MiddleCenter, false, Color.white, Vector2.one * 2f, Color.black);
			}
			But_HS_SendLife.Draw();
			But_HS_Life.Draw();
			fontSize_HS_LifeCount = (int)(18f - (float)(pHero.pIGt_LifeCalc.getCurrentLifeCount().ToString().Length * 2));
			pIgt_Lable.DrawLable(But_HS_Life.getCurrentDimension(), pHero.pIGt_LifeCalc.getCurrentLifeCount().ToString(), IGT_Constants.Font_TTMasters, (int)(IGT_UIcommonFunc.ScaleX(fontSize_HS_LifeCount) * But_HS_Life.getCurrentDimension().width / But_HS_Life.getWidth()), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black);
			pIgt_Textures.DrawTexture(IGT_Constants._Plus_Icon, new Rect(IGT_UIcommonFunc.ScaleX(165.5f), IGT_UIcommonFunc.ScaleY(1f), IGT_UIcommonFunc.ScaleX(10f), IGT_UIcommonFunc.ScaleY(10f)), true);
			rect_samp = new Rect(IGT_UIcommonFunc.ScaleX(71f), IGT_UIcommonFunc.ScaleY(3f), IGT_UIcommonFunc.ScaleX(68f), IGT_UIcommonFunc.ScaleY(20f));
			zz11 = rect_samp.x + rect_samp.width / 2f - (float)IGT_Constants.nTotNoOfCoins.ToString().Length * IGT_UIcommonFunc.ScaleX(2f);
			fontSize_HS_CoinCount = (int)(21f - (float)(IGT_Constants.nTotNoOfCoins.ToString().Length * 2));
			if (fontSize_HS_CoinCount < 10)
			{
				fontSize_HS_CoinCount = 10;
			}
			pIgt_Lable.DrawLable(new Rect(zz11, rect_HS_CoinCount.y, IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(16f)), IGT_Constants.nTotNoOfCoins.ToString(), IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(fontSize_HS_CoinCount), TextAnchor.MiddleLeft, false, Color.white, 1f, Color.black);
			if (IGT_Constants.nTotNoOfCoins.ToString().Length >= 4)
			{
				rect_HS_CoinImg.width = IGT_UIcommonFunc.ScaleX(16f) - (float)IGT_Constants.nTotNoOfCoins.ToString().Length;
				rect_HS_CoinImg.y = rect_HS_CoinCount.y + IGT_UIcommonFunc.ScaleY(2f);
			}
			rect_HS_CoinImg.x = zz11 - (IGT_UIcommonFunc.ScaleX(2.5f) + rect_HS_CoinImg.width);
			pIgt_Textures.DrawTexture(IGT_Constants._CoinImg, rect_HS_CoinImg, true);
			fontSize_HS_KeyCount = (int)(21f - (float)(IGT_Constants.nTotKeysCount.ToString().Length * 2));
			if (fontSize_HS_KeyCount < 10)
			{
				fontSize_HS_KeyCount = 10;
			}
			ck = ((float)IGT_Constants.nTotKeysCount.ToString().Length * 4f + rect_HS_KeyImg.width + IGT_UIcommonFunc.ScaleX(2f)) / 2f;
			rect_HS_KeyImg.x = IGT_UIcommonFunc.ScaleX(205f) - ck;
			pIgt_Textures.DrawTexture(IGT_Constants._KeyImg, rect_HS_KeyImg, false);
			rect_HS_KeyCount.x = rect_HS_KeyImg.x + rect_HS_KeyImg.width + IGT_UIcommonFunc.ScaleX(1f);
			pIgt_Lable.DrawLable(rect_HS_KeyCount, IGT_Constants.nTotKeysCount.ToString(), IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(fontSize_HS_KeyCount), TextAnchor.MiddleLeft, false, Color.white, 1f, Color.black);
			if (!bHS_mailbox && !bHS_sendlife && !bHS_asklife && !bHS_settings && !bHS_allshare)
			{
				But_HS_Acheivement.Draw();
				But_HS_AllShare.Draw();
				But_HS_FreeLife.Draw();
				But_HS_MoreGames.Draw();
				if (bNewBadgeInMoreGames && pHero.nChaseNewBadge != 0)
				{
					if (!bNewBadgeIsInAnim && !But_HS_MoreGames.getStartupAnimFinished() && Time.time - fNewBadgeAnimStrtTime > 4f)
					{
						pAnim_MissionCompleted_star1.resetAllValues();
						bNewBadgeIsInAnim = true;
					}
					if (bNewBadgeIsInAnim)
					{
						float num6 = pAnim_MissionCompleted_star1.easeFunctions(1f, 1.3f, 0.5f, 0);
						if (pAnim_MissionCompleted_star1.isAnimFinished() && !pAnim_MissionCompleted_star1.getIsReverse())
						{
							pAnim_MissionCompleted_star1.resetAllValues();
							pAnim_MissionCompleted_star1.setIsReverse(true);
						}
						if (bNewBadgeIsInAnim && pAnim_MissionCompleted_star1.isAnimFinished() && pAnim_MissionCompleted_star1.getIsReverse())
						{
							bNewBadgeIsInAnim = false;
							fNewBadgeAnimStrtTime = Time.time;
						}
						GUIUtility.ScaleAroundPivot(new Vector2(num6, num6), new Vector2(But_HS_MoreGames.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(40f) + IGT_UIcommonFunc.ScaleX(33f) * 0.5f, But_HS_MoreGames.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(8f) + IGT_UIcommonFunc.ScaleY(21f) * 0.5f));
						pIgt_Textures.DrawTexture(IGT_Constants._New, new Rect(But_HS_MoreGames.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(40f), But_HS_MoreGames.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(33f), IGT_UIcommonFunc.ScaleY(21f)), false);
						GUI.matrix = Matrix4x4.identity;
					}
					else
					{
						pIgt_Textures.DrawTexture(IGT_Constants._New, new Rect(But_HS_MoreGames.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(40f), But_HS_MoreGames.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(33f), IGT_UIcommonFunc.ScaleY(21f)), false);
					}
				}
			}
			pIgt_Textures.DrawTexture(IGT_Constants._Hs_Menu_Bg, pAnim_HS_menudwn.comingfrm_Top(rect_HS_MenuBarBg, 0f - rect_HS_MenuBarBg.width, 0.75f, 20f, 2f, 1f), false);
			if (pAnim_HS_menudwn.isAnimFinished())
			{
				But_HS_Shop.Draw();
				pIgt_Lable.DrawLable(new Rect(But_HS_Shop.getCurrentDimension().x + IGT_UIcommonFunc.ScaleY(7f), But_HS_Shop.getCurrentDimension().y + But_HS_Shop.getCurrentDimension().height - IGT_UIcommonFunc.ScaleY(7f), But_HS_Shop.getCurrentDimension().width, IGT_UIcommonFunc.ScaleY(10f)), IGT_Constants.HS_Shop_Name, IGT_Constants.Font_TitanOne, fontSize_HS_MenuBar, Color.white, TextAnchor.MiddleCenter, false);
				But_HS_Menu.Draw();
				pIgt_Lable.DrawLable(new Rect(But_HS_Menu.getCurrentDimension().x, But_HS_Menu.getCurrentDimension().y + But_HS_Menu.getCurrentDimension().height - IGT_UIcommonFunc.ScaleY(7f), But_HS_Menu.getCurrentDimension().width, IGT_UIcommonFunc.ScaleY(10f)), IGT_Constants.HS_Menu_Name, IGT_Constants.Font_TitanOne, fontSize_HS_MenuBar, Color.white, TextAnchor.MiddleCenter, false);
				But_HS_FConnect.Draw();
				pIgt_Lable.DrawLable(new Rect(But_HS_FConnect.getCurrentDimension().x, But_HS_FConnect.getCurrentDimension().y + But_HS_FConnect.getCurrentDimension().height - IGT_UIcommonFunc.ScaleY(7f), But_HS_FConnect.getCurrentDimension().width, IGT_UIcommonFunc.ScaleY(10f)), IGT_Constants.HS_Fconnect_Name, IGT_Constants.Font_TitanOne, fontSize_HS_MenuBar, Color.white, TextAnchor.MiddleCenter, false);
				if (!pFacebook.isFBLoginSucess() && IGT_Preference.getInstance()._Get(kFBLoginfirstTime, 0) == 0)
				{
					pIgt_Textures.DrawTexture(IGT_Constants._Life, new Rect(But_HS_FConnect.getCurrentDimension().x + But_HS_FConnect.getCurrentDimension().width - IGT_UIcommonFunc.ScaleX(36f), But_HS_FConnect.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(25f), IGT_UIcommonFunc.ScaleY(25f)), -26f, Vector2.zero);
					pIgt_Lable.DrawLable(new Rect(But_HS_FConnect.getCurrentDimension().x + But_HS_FConnect.getCurrentDimension().width - IGT_UIcommonFunc.ScaleX(36f), But_HS_FConnect.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(25f), IGT_UIcommonFunc.ScaleY(25f)), "+5", IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, -30f, Vector2.zero);
				}
				else if (pFacebook.isFBLoginSucess() && (long)IGT_Preference.getInstance()._Get(kFBInviteLastUpdateTime, 0f) + IGT_Constants.dFBInviteTime <= (long)currentTimeMins())
				{
					pIgt_Textures.DrawTexture(IGT_Constants._Life, new Rect(But_HS_FConnect.getCurrentDimension().x + But_HS_FConnect.getCurrentDimension().width - IGT_UIcommonFunc.ScaleX(36f), But_HS_FConnect.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(25f), IGT_UIcommonFunc.ScaleY(25f)), -26f, Vector2.zero);
					pIgt_Lable.DrawLable(new Rect(But_HS_FConnect.getCurrentDimension().x + But_HS_FConnect.getCurrentDimension().width - IGT_UIcommonFunc.ScaleX(36f), But_HS_FConnect.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(25f), IGT_UIcommonFunc.ScaleY(25f)), "+2", IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, -30f, Vector2.zero);
				}
			}
			if (bSorry)
			{
				draw_sorryAlert();
			}
			else if (bIsShowGPluseLoginAlert)
			{
				GplusAlertWindow();
			}
			else if (bInappAlert)
			{
				draw_Inapp_AlertWindow(nAlertWin);
			}
			else if (bHS_allshare)
			{
				drawAllShare();
			}
			else if (bHS_moregames)
			{
				Moregames_window();
			}
			else if (bHS_settings)
			{
				settings_window();
			}
			else if (bShowNickName)
			{
				drawNickNameWindow();
			}
			else if (bleaderboardHSbtnClick)
			{
				pIgt_Textures.DrawTexture(IGT_Constants._GreyOverLay, new Rect(0f, 0f, Screen.width, Screen.height), false);
				float num7 = pAnim_HS_LeaderBoard.easeFunctions(0.01f, 1f, 1f, 14);
				GUIUtility.ScaleAroundPivot(new Vector2(num7, num7), new Vector2(5f, 5f));
				if (bleaderboardHSbtnClick)
				{
					if (pAnim_HS_LeaderBoard.getIsReverse() && pAnim_HS_LeaderBoard.isAnimFinished())
					{
						bleaderboardHSbtnClick = false;
					}
					else
					{
						pIgt_Textures.DrawTexture(IGT_Constants._CornerBoard_green, new Rect(IGT_UIcommonFunc.ScaleX(0f), IGT_UIcommonFunc.ScaleY(0f), IGT_UIcommonFunc.ScaleX(100f), IGT_UIcommonFunc.ScaleY(100f)), false);
						But_HS_GoogleLB.Draw();
						But_HS_FBLB.Draw();
						But_HS_LeaderBoard.Draw();
					}
					GUI.matrix = Matrix4x4.identity;
				}
			}
			else if (bHS_FBbtnClick)
			{
				draw_Leaderboard_FBAlert();
			}
			else if (bHS_GooglebtnClick)
			{
				pIgt_Textures.DrawTexture(IGT_Constants._GreyOverLay, new Rect(0f, 0f, Screen.width, Screen.height), false);
				GplusAlertWindow();
			}
			else if (bChaseLockedAlert)
			{
				float a = 1f;
				if (bChaseLock_Alpha)
				{
					a = IGT_EaseFunction.Linear_ease(fChaseLockAlpha_StartTime, 1f, 0.1f, 1f);
					fChaseLockAlpha_StartTime += Time.deltaTime;
					if (fChaseLockAlpha_StartTime > 1f)
					{
						bChaseLockedAlert = false;
						bChaseLock_Alpha = false;
					}
				}
				else if (Time.time - fChaseLockAlert_StartTime > fChaseLockAlert_TotTime && !bChaseLock_Alpha)
				{
					fChaseLockAlpha_StartTime = 0f;
					bChaseLock_Alpha = true;
				}
				Color color = GUI.color;
				GUI.color = new Color(color.r, color.g, color.b, a);
				pIgt_Textures.DrawTexture(IGT_Constants._GreyOverLay, new Rect(IGT_UIcommonFunc.ScaleX(10f), IGT_UIcommonFunc.ScaleY(200f), IGT_UIcommonFunc.ScaleX(300f), IGT_UIcommonFunc.ScaleY(80f)), false);
				pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(10f), IGT_UIcommonFunc.ScaleY(200f), IGT_UIcommonFunc.ScaleX(300f), IGT_UIcommonFunc.ScaleY(80f)), "COMPLETE 5  LEVELS  IN MISSIONS  TO PLAY CHASE ", IGT_Constants.Font_Jellee_Roman, (int)IGT_UIcommonFunc.ScaleX(14f), TextAnchor.MiddleCenter, true, Color.white, 1f, Color.black, Vector2.one, Color.black);
				GUI.color = color;
			}
			else if (bHS_mailbox)
			{
				pIgt_Textures.DrawTexture(IGT_Constants._GreyOverLay, new Rect(0f, 0f, Screen.width, Screen.height), false);
				float num8 = pAnim_MailBox.easeFunctions(0.01f, 1f, 0.5f, 0);
				if (pAnim_MailBox.isAnimFinished() && pAnim_MailBox.getIsReverse())
				{
					bHS_mailbox = false;
					But_HS_Acheivement.ResetAnimationDatas();
					But_HS_AllShare.ResetAnimationDatas();
					But_HS_MoreGames.ResetAnimationDatas();
					But_HS_FreeLife.ResetAnimationDatas();
					break;
				}
				GUIUtility.ScaleAroundPivot(new Vector2(num8, num8), new Vector2(rect_MailBoxWin.x + rect_MailBoxWin.width * 0.5f, rect_MailBoxWin.y + rect_MailBoxWin.height * 0.5f));
				pIgt_Textures.DrawTexture(IGT_Constants._SettingsBg, rect_MailBoxWin, false);
				GUI.DrawTexture(new Rect(rect_MailBoxWin.x + IGT_UIcommonFunc.ScaleX(5f), rect_MailBoxName.y, rect_MailBoxWin.width - IGT_UIcommonFunc.ScaleX(11f), rect_MailBoxName.height), Drawrect_clr1);
				pIgt_Textures.DrawTexture(IGT_Constants._Email, new Rect(rect_MailBoxWin.x - IGT_UIcommonFunc.ScaleX(40f) / 4f, rect_MailBoxWin.y - IGT_UIcommonFunc.ScaleY(40f) / 4f, IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleY(40f)), false);
				pIgt_Lable.DrawLable(rect_MailBoxName, IGT_Constants.MailBox, IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(20f), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.black, new Vector2(4f, 4f), Color.black);
				But_MailBox_Close.Draw_Button();
				if (pFacebook.isFBLoginSucess() && listAskSend.Count > 0 && !dMailBoxisProcessing)
				{
					But_Mail_Accept.Draw_Button();
					But_Mail_CheckAll.Draw_Button();
					pIgt_Lable.DrawLable(But_Mail_Accept.getOriginalDimension(), "Accept", IGT_Constants.Font_LemonR, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.black, 1f, Color.black, Vector2.zero, Color.clear);
					pIgt_Lable.DrawLable(But_Mail_CheckAll.getOriginalDimension(), "Check All", IGT_Constants.Font_LemonR, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.black, 1f, Color.black, Vector2.zero, Color.clear);
				}
				GUI.matrix = Matrix4x4.identity;
				if (pAnim_MailBox.isAnimFinished())
				{
					MailBoxWindowDataSelection();
				}
			}
			else if (bHS_sendlife)
			{
				pIgt_Textures.DrawTexture(IGT_Constants._GreyOverLay, new Rect(0f, 0f, Screen.width, Screen.height), false);
				float num9 = pAnim_MailBox.easeFunctions(0.01f, 1f, 0.5f, 0);
				if (pAnim_MailBox.isAnimFinished() && pAnim_MailBox.getIsReverse())
				{
					bHS_sendlife = false;
					But_HS_Acheivement.ResetAnimationDatas();
					But_HS_AllShare.ResetAnimationDatas();
					But_HS_MoreGames.ResetAnimationDatas();
					But_HS_FreeLife.ResetAnimationDatas();
					break;
				}
				GUIUtility.ScaleAroundPivot(new Vector2(num9, num9), new Vector2(rect_MailBoxWin.x + rect_MailBoxWin.width * 0.5f, rect_MailBoxWin.y + rect_MailBoxWin.height * 0.5f));
				pIgt_Textures.DrawTexture(IGT_Constants._SettingsBg, rect_MailBoxWin, false);
				GUI.DrawTexture(new Rect(rect_MailBoxWin.x + IGT_UIcommonFunc.ScaleX(5f), rect_MailBoxName.y, rect_MailBoxWin.width - IGT_UIcommonFunc.ScaleX(11f), rect_MailBoxName.height), Drawrect_clr1);
				pIgt_Textures.DrawTexture(IGT_Constants._SendLife, new Rect(rect_MailBoxWin.x - IGT_UIcommonFunc.ScaleX(40f) / 4f, rect_MailBoxWin.y - IGT_UIcommonFunc.ScaleY(40f) / 4f, IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleY(40f)), false);
				pIgt_Lable.DrawLable(rect_MailBoxName, IGT_Constants.SendLife, IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(20f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, new Vector2(4f, 4f), Color.black);
				But_MailBox_Close.Draw_Button();
				if (pFacebook.isFBLoginSucess() && fbList != null && fbList.Count - 1 > 0)
				{
					But_SendLife_Accept.Draw_Button();
					But_SendLife_CheckAll.Draw_Button();
					pIgt_Lable.DrawLable(But_SendLife_Accept.getOriginalDimension(), "Send", IGT_Constants.Font_LemonR, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.black, 1f, Color.black, Vector2.zero, Color.clear);
					pIgt_Lable.DrawLable(But_SendLife_CheckAll.getOriginalDimension(), "Check All", IGT_Constants.Font_LemonR, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.black, 1f, Color.black, Vector2.zero, Color.clear);
					GUI.matrix = Matrix4x4.identity;
				}
				if (pAnim_MailBox.isAnimFinished())
				{
					SendLifeWindowDataSelection();
				}
			}
			else if (bExitAlert)
			{
				float num10 = pAnim_Alert.easeFunctions(IGT_UIcommonFunc.ScaleY(400f), 0f, 1f, 29);
				if (pAnim_Alert.isAnimFinished() && pAnim_Alert.getIsReverse())
				{
					bExitAlert = false;
					break;
				}
				pIgt_Textures.DrawTexture(IGT_Constants._NoMoreLives_BG, new Rect(rect_ExitBg.x, rect_ExitBg.y - rect_ExitBg.height / 2f + num10, rect_ExitBg.width, rect_ExitBg.height), false);
				pIgt_Lable.DrawLable(new Rect(rect_ExitBg.x + rect_ExitBg.width / 2f - IGT_UIcommonFunc.ScaleX(50f) / 2f, rect_ExitBg.y - rect_ExitBg.height / 2f + IGT_UIcommonFunc.ScaleY(7f) + num10, IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(40f)), "ARE YOU SURE WANT TO LEAVE ?", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(16f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, new Vector2(0f, 0f), Color.black);
				But_Exit_Ok.setY(rect_ExitBg.y - rect_ExitBg.height / 2f + num10 + rect_ExitBg.height - But_Exit_Ok.getHeight() - IGT_UIcommonFunc.ScaleY(10f));
				But_Exit_Ok.Draw();
				But_Exit_Cancel.setY(But_Exit_Ok.getY());
				But_Exit_Cancel.Draw();
			}
			break;
		case 3:
		{
			float num11 = pAnim_HS_menuBG.easeFunctions(IGT_UIcommonFunc.ScaleY(400f), 0f, 1f, 29);
			pIgt_Textures.DrawTexture(IGT_Constants._SaveMeBG, new Rect(rect_SurviveWindowBG.x, rect_SurviveWindowBG.y + num11, rect_SurviveWindowBG.width, rect_SurviveWindowBG.height), false);
			pIgt_Textures.DrawTexture(IGT_Constants._SaveMeCorn, new Rect(rect_SurviveWindowBG.x + rect_SurviveWindowBG.width - IGT_UIcommonFunc.ScaleX(63f), IGT_UIcommonFunc.ScaleY(11f) + rect_SurviveWindowBG.y + num11, IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(20f)), false);
			pIgt_Textures.DrawTexture(IGT_Constants._KeyImg, new Rect(rect_SurviveWindowBG.x + rect_SurviveWindowBG.width - IGT_UIcommonFunc.ScaleX(72f), IGT_UIcommonFunc.ScaleY(11f) + rect_SurviveWindowBG.y + num11, IGT_UIcommonFunc.ScaleX(20f), IGT_UIcommonFunc.ScaleY(20f)), false);
			But_Survive_TotKey.setY(But_Survive_TotKey.getOriginalDimension().y + num11);
			pIgt_Lable.DrawLable(new Rect(But_Survive_TotKey.getX(), But_Survive_TotKey.getY(), But_Survive_TotKey.getWidth(), But_Survive_TotKey.getHeight()), IGT_Constants.nTotKeysCount.ToString(), IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(10f), TextAnchor.MiddleCenter, false, Color.white, 1.5f, Color.black, new Vector2(0.5f, 0.5f), Color.black, 0f, Vector2.one);
			if (pAnim_HS_menuBG.isAnimFinished())
			{
				fSaveMeTextFillingCurTime = Time.time - IGT_Constants.useKeyLifeStartTime;
				pSaveMeText.draw(IGT_EaseFunction.Linear_ease(fSaveMeTextFillingCurTime, 1f, 0f, IGT_Constants.useKeyTotLifeTime));
			}
			else
			{
				pIgt_Textures.DrawTexture(IGT_Constants._SaveMeGreen, new Rect(pSaveMeText.getContainerDimensions().x, pSaveMeText.getContainerDimensions().y + num11, pSaveMeText.getContainerDimensions().width, pSaveMeText.getContainerDimensions().height), false);
				IGT_Constants.useKeyLifeStartTime = Time.time;
			}
			if (bSuriviveRewardedVideoAvailable && string.Equals(getRewardedVideoTimeIntervel(), "00:00"))
			{
				float num12 = rect_SurviveWindowBG.x + rect_SurviveWindowBG.width / 2f;
				But_Survive_Watchvideo.setX(num12 - IGT_UIcommonFunc.ScaleX(10f) - But_Survive_Watchvideo.getWidth());
				But_Survive_Watchvideo.setY(rect_SurviveWindowBG.y + IGT_UIcommonFunc.ScaleY(82f) + num11);
				But_Survive_Watchvideo.Draw();
				num12 = rect_SurviveWindowBG.x + rect_SurviveWindowBG.width / 2f;
				But_Survive_UseKey.setX(num12 + IGT_UIcommonFunc.ScaleX(10f));
				But_Survive_UseKey.setY(rect_SurviveWindowBG.y + IGT_UIcommonFunc.ScaleY(82f) + num11);
				But_Survive_UseKey.Draw();
			}
			else
			{
				float num12 = rect_SurviveWindowBG.x + rect_SurviveWindowBG.width / 2f;
				But_Survive_UseKey.setX(num12 - But_Survive_UseKey.getWidth() / 2f);
				But_Survive_UseKey.setY(rect_SurviveWindowBG.y + IGT_UIcommonFunc.ScaleY(82f) + num11);
				But_Survive_UseKey.Draw();
			}
			float num13 = 21f - (float)(IGT_Constants.nNoOfKeysToRevive.ToString().Length * 2);
			if (num13 < 12f)
			{
				num13 = 12f;
			}
			pIgt_Textures.DrawTexture(IGT_Constants._KeyImg, new Rect(But_Survive_UseKey.getX() + IGT_UIcommonFunc.ScaleX(39.5f) + IGT_UIcommonFunc.ScaleX(IGT_Constants.nNoOfKeysToRevive.ToString().Length), But_Survive_UseKey.getY() + IGT_UIcommonFunc.ScaleY(9f), IGT_UIcommonFunc.ScaleX(20f), IGT_UIcommonFunc.ScaleX(20f)), 75f, new Vector2(0.5f, 0.5f));
			pIgt_Lable.DrawLable(new Rect(But_Survive_UseKey.getX() - IGT_UIcommonFunc.ScaleX(43f) + IGT_UIcommonFunc.ScaleX(IGT_Constants.nNoOfKeysToRevive.ToString().Length), But_Survive_UseKey.getY(), But_Survive_UseKey.getWidth(), But_Survive_UseKey.getHeight()), IGT_Constants.nNoOfKeysToRevive.ToString(), IGT_Constants.Font_TTMasters, (int)(IGT_UIcommonFunc.ScaleX(num13) * But_Survive_UseKey.getCurrentDimension().width / But_Survive_UseKey.getWidth()), TextAnchor.MiddleRight, false, Color.black, 3f, Color.white);
			break;
		}
		case 2:
		{
			float num14 = pAnim_HS_menuBG.easeFunctions(0.01f, 1f, 1f, 29);
			GUIUtility.ScaleAroundPivot(new Vector2(num14, num14), new Vector2(rect_PausescreenBG.x + rect_PausescreenBG.width * 0.5f, rect_PausescreenBG.y + rect_PausescreenBG.height * 0.5f));
			pIgt_Textures.DrawTexture(IGT_Constants._Pause_Bg, rect_PausescreenBG, false);
			pIgt_Lable.DrawLable(new Rect(rect_PausescreenBG.x + rect_PausescreenBG.width / 2f - IGT_UIcommonFunc.ScaleX(120f) / 2f, rect_PausescreenBG.y + IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleX(120f), IGT_UIcommonFunc.ScaleY(40f)), "Paused", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(20f), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.yellow, new Vector2(1f, 1f), Color.black);
			But_Pause_Boost.Draw();
			But_Pause_Back.Draw();
			But_Pause_Resume.Draw();
			pIgt_Lable.DrawLable(new Rect(But_Pause_Boost.getX(), But_Pause_Boost.getY() + But_Pause_Boost.getHeight(), But_Pause_Boost.getWidth(), But_Pause_Boost.getHeight()), "Boost", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.UpperCenter, false, Color.white, 0f, Color.white, new Vector2(1.5f, 1.5f), Color.black);
			pIgt_Lable.DrawLable(new Rect(But_Pause_Back.getX(), But_Pause_Back.getY() + But_Pause_Back.getHeight(), But_Pause_Back.getWidth(), But_Pause_Back.getHeight()), "Quit", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.UpperCenter, false, Color.white, 0f, Color.white, new Vector2(1.5f, 1.5f), Color.black);
			pIgt_Lable.DrawLable(new Rect(But_Pause_Resume.getX(), But_Pause_Resume.getY() + But_Pause_Resume.getHeight(), But_Pause_Resume.getWidth(), But_Pause_Resume.getHeight()), "Resume", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.UpperCenter, false, Color.white, 0f, Color.white, new Vector2(1.5f, 1.5f), Color.black);
			GUI.matrix = Matrix4x4.identity;
			if (pHero.bTestingTeamPurpose)
			{
				pIgt_Lable.DrawLable(rect_Prob, "3dModelUsageMode : " + Enum.GetNames(typeof(Game3dModelUsageMode)).GetValue(pHero.n3dModelUsageMode).ToString(), IGT_Constants.Font_Nunito_Bold, fontSize_Fps, TextAnchor.MiddleCenter, true, Color.red, 0f, Color.white, Vector2.zero, Color.white);
				if (GUI.Button(new Rect(But_Gamescreen_Pause.getX(), But_Gamescreen_Pause.getY() - IGT_UIcommonFunc.ScaleY(80f), But_Gamescreen_Pause.getWidth() * 0.7f, But_Gamescreen_Pause.getHeight() * 0.7f), "quality: " + QualitySettings.GetQualityLevel()))
				{
					if (QualitySettings.GetQualityLevel() == 0)
					{
						QualitySettings.SetQualityLevel(1, false);
					}
					else if (QualitySettings.GetQualityLevel() == 1)
					{
						QualitySettings.SetQualityLevel(2, false);
					}
					else if (QualitySettings.GetQualityLevel() == 2)
					{
						QualitySettings.SetQualityLevel(0, false);
					}
				}
			}
			if (bAbortAlert)
			{
				GUIUtility.RotateAroundPivot(pAnim_MissionCompleted_star3.easeFunctions(0f, 720f, 0.75f, 29), new Vector2(rect_AbortBg.x + rect_AbortBg.width * 0.5f, rect_AbortBg.y + rect_AbortBg.height * 0.5f));
				float num22 = pAnim_MissionCompleted_star2.easeFunctions(0.1f, 1f, 0.75f, 29);
				GUIUtility.ScaleAroundPivot(new Vector2(num22, num22), new Vector2(rect_AbortBg.x + rect_AbortBg.width * 0.5f, rect_AbortBg.y + rect_AbortBg.height * 0.5f));
				if (pAnim_MissionCompleted_star3.isAnimFinished() && pAnim_MissionCompleted_star3.getIsReverse())
				{
					bAbortAlert = false;
				}
				else
				{
					pIgt_Textures.DrawTexture(IGT_Constants._Abort_BG, rect_AbortBg, false);
					pIgt_Textures.DrawTexture(IGT_Constants._Abort_LifeIcon, new Rect(rect_AbortBg.x - IGT_UIcommonFunc.ScaleX(46f) / 3f, rect_AbortBg.y - IGT_UIcommonFunc.ScaleY(35f) / 3f, IGT_UIcommonFunc.ScaleX(46f), IGT_UIcommonFunc.ScaleY(35f)), false);
					pIgt_Lable.DrawLable(new Rect(rect_AbortBg.x + rect_AbortBg.width / 2f - IGT_UIcommonFunc.ScaleX(50f) / 2f, rect_AbortBg.y + IGT_UIcommonFunc.ScaleY(7f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(40f)), "ARE YOU SURE?", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(16f), TextAnchor.MiddleCenter, false, Color.white, 2f, Color.black, new Vector2(1f, 1f), Color.black);
					pIgt_Textures.DrawTexture(IGT_Constants._Abort_Life, rect_Abort_Heart, false);
					But_Abort_Cancel.Draw();
					But_Abort_Ok.Draw();
				}
				GUI.matrix = Matrix4x4.identity;
			}
			break;
		}
		case 8:
		{
			pIgt_Textures.DrawTexture(IGT_Constants._countDown_Bg, rect_CountDownBG, false);
			float num14 = pAnim_HS_menuBG.easeFunctions(0.01f, 1f, 1f, 2);
			if (pAnim_HS_menuBG.isAnimFinished())
			{
				pAnim_HS_menuBG.resetAllValues();
			}
			GUIUtility.ScaleAroundPivot(new Vector2(num14, num14), new Vector2(rect_CountDownBG.x + rect_CountDownBG.width * 0.5f, rect_CountDownBG.y + rect_CountDownBG.height * 0.5f));
			pIgt_Textures.DrawTexture(IGT_Constants._CountDown_Glow, new Rect(rect_CountDownBG.x + rect_CountDownBG.width / 2f - IGT_UIcommonFunc.ScaleX(40f), rect_CountDownBG.y + rect_CountDownBG.height / 2f - IGT_UIcommonFunc.ScaleX(55f), IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(110f)), false);
			pIgt_Lable.DrawLable(rect_CountDownBG, nCountDownNum.ToString(), IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(100f), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.black, new Vector2(2f, 2f), Color.black);
			GUI.matrix = Matrix4x4.identity;
			break;
		}
		case 9:
			pIgt_Textures.DrawTexture(IGT_Constants.map_ScoreBoard, new Rect(rect_HS_TopFrame.x, rect_HS_TopFrame.y - 1f, rect_HS_TopFrame.width, IGT_UIcommonFunc.ScaleY(32f)), false);
			But_HS_Life.Draw();
			fontSize_HS_LifeCount = (int)(18f - (float)(pHero.pIGt_LifeCalc.getCurrentLifeCount().ToString().Length * 2));
			pIgt_Lable.DrawLable(But_HS_Life.getCurrentDimension(), pHero.pIGt_LifeCalc.getCurrentLifeCount().ToString(), IGT_Constants.Font_TTMasters, (int)((float)(int)IGT_UIcommonFunc.ScaleX(fontSize_HS_LifeCount) * But_HS_Life.getCurrentDimension().width / But_HS_Life.getWidth()), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black);
			pIgt_Textures.DrawTexture(IGT_Constants._Plus_Icon, new Rect(IGT_UIcommonFunc.ScaleX(165.5f), IGT_UIcommonFunc.ScaleY(1f), IGT_UIcommonFunc.ScaleX(10f), IGT_UIcommonFunc.ScaleY(10f)), true);
			fontSize_HS_CoinCount = (int)(21f - (float)(IGT_Constants.nTotNoOfCoins.ToString().Length * 2));
			if (fontSize_HS_CoinCount < 10)
			{
				fontSize_HS_CoinCount = 10;
			}
			pIgt_Lable.DrawLable(new Rect(zz11, rect_HS_CoinCount.y, IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(16f)), IGT_Constants.nTotNoOfCoins.ToString(), IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(fontSize_HS_CoinCount), TextAnchor.MiddleLeft, false, Color.white, 1f, Color.black);
			if (IGT_Constants.nTotNoOfCoins.ToString().Length >= 4)
			{
				rect_HS_CoinImg.width = IGT_UIcommonFunc.ScaleX(16f) - (float)IGT_Constants.nTotNoOfCoins.ToString().Length;
				rect_HS_CoinImg.y = rect_HS_CoinCount.y + IGT_UIcommonFunc.ScaleY(2f);
			}
			rect_HS_CoinImg.x = zz11 - (IGT_UIcommonFunc.ScaleX(2.5f) + rect_HS_CoinImg.width);
			pIgt_Textures.DrawTexture(IGT_Constants._CoinImg, rect_HS_CoinImg, true);
			fontSize_HS_KeyCount = (int)(21f - (float)(IGT_Constants.nTotKeysCount.ToString().Length * 2));
			if (fontSize_HS_KeyCount < 10)
			{
				fontSize_HS_KeyCount = 10;
			}
			ck = ((float)IGT_Constants.nTotKeysCount.ToString().Length * 4f + rect_HS_KeyImg.width + IGT_UIcommonFunc.ScaleX(2f)) / 2f;
			rect_HS_KeyImg.x = IGT_UIcommonFunc.ScaleX(205f) - ck;
			pIgt_Textures.DrawTexture(IGT_Constants._KeyImg, rect_HS_KeyImg, false);
			rect_HS_KeyCount.x = rect_HS_KeyImg.x + rect_HS_KeyImg.width + IGT_UIcommonFunc.ScaleX(1f);
			pIgt_Lable.DrawLable(rect_HS_KeyCount, IGT_Constants.nTotKeysCount.ToString(), IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(fontSize_HS_KeyCount), TextAnchor.MiddleLeft, false, Color.white, 1f, Color.black);
			But_Mapback.Draw();
			break;
		case 4:
			But_Levelupscreen_Play.Draw_Button();
			pIgt_Lable.DrawLable(But_Levelupscreen_Play.getX(), But_Levelupscreen_Play.getY(), But_Levelupscreen_Play.getWidth(), But_Levelupscreen_Play.getHeight(), "Tap to Continue", IGT_Constants.Font_TitanOne, fontSize_HS_Chase_Mission, Color.white, TextAnchor.MiddleCenter);
			break;
		case 7:
			MissionInfoScreenAnimation();
			break;
		}
		if (bPostFBAlert && !pRateit.bShowRateItAlert)
		{
			PostonFB_AlertWindow();
		}
		else if (bFeedInviteFriendAlert)
		{
			drawfeedInvite_Alert();
		}
		else if (bOutOfEnergyTextAlert)
		{
			float num25 = 0f;
			num25 = (pAnim_MissionCompleted_star2.getIsReverse() ? pAnim_MissionCompleted_star2.easeFunctions(Screen.width, 0f, 1f, 28) : pAnim_MissionCompleted_star2.easeFunctions(0f - rect_AlertSize.x - rect_AlertSize.width * 1.25f, 0f, 1f, 29));
			if (pAnim_MissionCompleted_star2.isAnimFinished() && pAnim_MissionCompleted_star2.getIsReverse())
			{
				bOutOfEnergyTextAlert = false;
				IGT_AnimStatesCntrler.nGameOverAnimFinshd = 1;
				if (pHero.PlayerObj.nEnergyMeter <= 0f)
				{
					pHero.bMissionManualEnding = false;
				}
			}
			else
			{
				pIgt_Lable.DrawLable(new Rect(rect_AlertSize.x + num25, rect_AlertSize.y, rect_AlertSize.width, rect_AlertSize.height), sAlertText, IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(30f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, new Vector2(1f, 1f), Color.black);
			}
			if (Time.time - fOutOfEnergyTextAlert_StrtTime > fOutOfEnergyTextAlert_TotTime && !pAnim_MissionCompleted_star2.getIsReverse())
			{
				pAnim_MissionCompleted_star2.resetAllValues();
				pAnim_MissionCompleted_star2.setIsReverse(true);
			}
		}
		else if (bNoMoreLiveAlert)
		{
			if (!bHS_asklife)
			{
				pIgt_Textures.DrawTexture(IGT_Constants._GreyOverLay, new Rect(0f, 0f, Screen.width, Screen.height), false);
			}
			float num26 = pAnim_Alert.easeFunctions(0f - rect_NoMoreLivesBg.y - rect_NoMoreLivesBg.height * 1.25f, 0f, 1f, 29);
			if (pAnim_Alert.isAnimFinished() && pAnim_Alert.getIsReverse())
			{
				bNoMoreLiveAlert = false;
			}
			else
			{
				pIgt_Textures.DrawTexture(IGT_Constants._AlertBoard_Green, new Rect(rect_NoMoreLivesBg.x, rect_NoMoreLivesBg.y + num26, rect_NoMoreLivesBg.width, rect_NoMoreLivesBg.height), false);
				pIgt_Textures.DrawTexture(IGT_Constants._Abort_LifeIcon, new Rect(rect_NoMoreLivesBg.x - IGT_UIcommonFunc.ScaleX(46f) / 3f, rect_NoMoreLivesBg.y + num26 - IGT_UIcommonFunc.ScaleY(35f) / 3f, IGT_UIcommonFunc.ScaleX(46f), IGT_UIcommonFunc.ScaleY(35f)), false);
				if (pHero.pIGt_LifeCalc.getCurrentLifeCount() <= 0)
				{
					pIgt_Lable.DrawLable(new Rect(rect_NoMoreLivesBg.x + rect_NoMoreLivesBg.width / 2f - IGT_UIcommonFunc.ScaleX(50f) / 2f, rect_NoMoreLivesBg.y + IGT_UIcommonFunc.ScaleY(7f) + num26, IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(40f)), "NO MORE LIVES", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(18f), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(4f, 4f), Color.black);
				}
				else
				{
					pIgt_Lable.DrawLable(new Rect(rect_NoMoreLivesBg.x + rect_NoMoreLivesBg.width / 2f - IGT_UIcommonFunc.ScaleX(50f) / 2f, rect_NoMoreLivesBg.y + IGT_UIcommonFunc.ScaleY(7f) + num26, IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(40f)), "REMAINING LIVES", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(18f), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(4f, 4f), Color.black);
				}
				pIgt_Textures.DrawTexture(IGT_Constants._Life, new Rect(rect_NoMoreLivs_Heart.x, rect_NoMoreLivs_Heart.y + num26, rect_NoMoreLivs_Heart.width, rect_NoMoreLivs_Heart.height), false);
				float x2 = (int)(22f - (float)(pHero.pIGt_LifeCalc.getCurrentLifeCount().ToString().Length * 2));
				pIgt_Lable.DrawLable(new Rect(rect_NoMoreLivs_Heart.x, rect_NoMoreLivs_Heart.y + num26, rect_NoMoreLivs_Heart.width, rect_NoMoreLivs_Heart.height), pHero.pIGt_LifeCalc.getCurrentLifeCount().ToString(), IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(x2), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, new Vector2(1f, 1f), Color.black);
				But_NoLives_Close.setY(But_NoLives_Close.getOriginalDimension().y + num26);
				But_NoLives_Close.Draw();
				But_NoLives_AskFriends.setY(rect_NoMoreLivesBg.y + rect_NoMoreLivesBg.height - But_NoLives_AskFriends.getHeight() / 2f - IGT_UIcommonFunc.ScaleY(6f) + num26);
				But_NoLives_AskFriends.Draw();
				But_NoLives_GetFree.setY(But_NoLives_AskFriends.getY());
				But_NoLives_GetFree.Draw();
				But_NoLives_Purchase2.setY(rect_NoMoreLivesBg.y + rect_NoMoreLivesBg.height / 2f + IGT_UIcommonFunc.ScaleY(25f) + num26);
				But_NoLives_Purchase2.Draw();
				But_NoLives_Purchase1.setY(rect_NoMoreLivesBg.y + rect_NoMoreLivesBg.height / 2f + IGT_UIcommonFunc.ScaleY(25f) + num26);
				But_NoLives_Purchase1.Draw();
				But_NoLives_Purchase3.setY(rect_NoMoreLivesBg.y + rect_NoMoreLivesBg.height / 2f + IGT_UIcommonFunc.ScaleY(25f) + num26);
				But_NoLives_Purchase3.Draw();
				pIgt_Lable.DrawLable(new Rect(But_NoLives_Purchase2.getCurrentDimension().x + But_NoLives_Purchase2.getCurrentDimension().width / 3f, But_NoLives_Purchase2.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(6f), But_NoLives_Purchase2.getCurrentDimension().width / 3f, But_NoLives_Purchase2.getCurrentDimension().height / 3f), pHero.pPurchaseItemsData_Store[pHero.pPurchaseItemsData_Store.Count - 2].ProductDescription.Split(' ')[0], IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(10f), TextAnchor.MiddleCenter, false, Color.white, 0f, Color.green, new Vector2(1f, 1f), Color.black);
				pIgt_Lable.DrawLable(new Rect(But_NoLives_Purchase1.getCurrentDimension().x + But_NoLives_Purchase1.getCurrentDimension().width / 3f, But_NoLives_Purchase1.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(6f), But_NoLives_Purchase1.getCurrentDimension().width / 3f, But_NoLives_Purchase1.getCurrentDimension().height / 3f), pHero.pPurchaseItemsData_Store[pHero.pPurchaseItemsData_Store.Count - 3].ProductDescription.Split(' ')[0], IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(10f), TextAnchor.MiddleCenter, false, Color.white, 0f, Color.green, new Vector2(1f, 1f), Color.black);
				pIgt_Lable.DrawLable(new Rect(But_NoLives_Purchase3.getCurrentDimension().x + But_NoLives_Purchase3.getCurrentDimension().width / 3f, But_NoLives_Purchase3.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(6f), But_NoLives_Purchase3.getCurrentDimension().width / 3f, But_NoLives_Purchase3.getCurrentDimension().height / 3f), pHero.pPurchaseItemsData_Store[pHero.pPurchaseItemsData_Store.Count - 1].ProductDescription.Split(' ')[0], IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(10f), TextAnchor.MiddleCenter, false, Color.white, 0f, Color.green, new Vector2(1f, 1f), Color.black);
				if (pHero.pIGT_IAPManagerAssist.isInitialisedSuccess())
				{
					pIgt_Lable.DrawLable(new Rect(But_NoLives_Purchase2.getCurrentDimension().x, But_NoLives_Purchase2.getCurrentDimension().y + But_NoLives_Purchase2.getCurrentDimension().height / 2f + IGT_UIcommonFunc.ScaleY(1.5f), But_NoLives_Purchase2.getCurrentDimension().width, But_NoLives_Purchase2.getCurrentDimension().height / 2.3f), pHero.pIGT_IAPManagerAssist.GetPriceforEachProduct(pHero.pPurchaseItemsData_Store[pHero.pPurchaseItemsData_Store.Count - 2].ProductID_GooglePlayStore), IGT_Constants.Font_Nunito, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black, 0f, Vector2.zero);
					pIgt_Lable.DrawLable(new Rect(But_NoLives_Purchase1.getCurrentDimension().x, But_NoLives_Purchase1.getCurrentDimension().y + But_NoLives_Purchase1.getCurrentDimension().height / 2f + IGT_UIcommonFunc.ScaleY(1.5f), But_NoLives_Purchase1.getCurrentDimension().width, But_NoLives_Purchase1.getCurrentDimension().height / 2.3f), pHero.pIGT_IAPManagerAssist.GetPriceforEachProduct(pHero.pPurchaseItemsData_Store[pHero.pPurchaseItemsData_Store.Count - 3].ProductID_GooglePlayStore), IGT_Constants.Font_Nunito, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black, 0f, Vector2.zero);
					pIgt_Lable.DrawLable(new Rect(But_NoLives_Purchase3.getCurrentDimension().x, But_NoLives_Purchase3.getCurrentDimension().y + But_NoLives_Purchase3.getCurrentDimension().height / 2f + IGT_UIcommonFunc.ScaleY(1.5f), But_NoLives_Purchase3.getCurrentDimension().width, But_NoLives_Purchase3.getCurrentDimension().height / 2.3f), pHero.pIGT_IAPManagerAssist.GetPriceforEachProduct(pHero.pPurchaseItemsData_Store[pHero.pPurchaseItemsData_Store.Count - 1].ProductID_GooglePlayStore), IGT_Constants.Font_Nunito, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black, 0f, Vector2.zero);
				}
				else
				{
					pIgt_Lable.DrawLable(new Rect(But_NoLives_Purchase2.getCurrentDimension().x, But_NoLives_Purchase2.getCurrentDimension().y + But_NoLives_Purchase2.getCurrentDimension().height / 2f + IGT_UIcommonFunc.ScaleY(1.5f), But_NoLives_Purchase2.getCurrentDimension().width, But_NoLives_Purchase2.getCurrentDimension().height / 2.3f), pHero.pPurchaseItemsData_Store[pHero.pPurchaseItemsData_Store.Count - 2].DefaultPrice, IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black);
					pIgt_Lable.DrawLable(new Rect(But_NoLives_Purchase1.getCurrentDimension().x, But_NoLives_Purchase1.getCurrentDimension().y + But_NoLives_Purchase1.getCurrentDimension().height / 2f + IGT_UIcommonFunc.ScaleY(1.5f), But_NoLives_Purchase1.getCurrentDimension().width, But_NoLives_Purchase1.getCurrentDimension().height / 2.3f), pHero.pPurchaseItemsData_Store[pHero.pPurchaseItemsData_Store.Count - 3].DefaultPrice, IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black);
					pIgt_Lable.DrawLable(new Rect(But_NoLives_Purchase3.getCurrentDimension().x, But_NoLives_Purchase3.getCurrentDimension().y + But_NoLives_Purchase3.getCurrentDimension().height / 2f + IGT_UIcommonFunc.ScaleY(1.5f), But_NoLives_Purchase3.getCurrentDimension().width, But_NoLives_Purchase3.getCurrentDimension().height / 2.3f), pHero.pPurchaseItemsData_Store[pHero.pPurchaseItemsData_Store.Count - 1].DefaultPrice, IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black);
				}
				if (pHero.pIGt_LifeCalc.getCurrentLifeCount() < pHero.pIGt_LifeCalc.getTotalGivenLifeCount())
				{
					pIgt_Lable.DrawLable(new Rect(rect_NoMoreLivesBg.x + rect_NoMoreLivesBg.width / 2f - IGT_UIcommonFunc.ScaleX(200f) / 2f, rect_NoMoreLivesBg.y + rect_NoMoreLivesBg.height / 2f + IGT_UIcommonFunc.ScaleY(25f) + num26 - IGT_UIcommonFunc.ScaleY(35f), IGT_UIcommonFunc.ScaleX(200f), IGT_UIcommonFunc.ScaleY(30f)), "You will get +1 life in  <b>" + Mathf.Floor((float)pHero.pIGt_LifeCalc.getRemainingTimeFrLifeAdding() / 60f).ToString("0") + " : " + Mathf.Floor((float)pHero.pIGt_LifeCalc.getRemainingTimeFrLifeAdding() % 60f).ToString("00") + "</b>", IGT_Constants.Font_Nunito, (int)IGT_UIcommonFunc.ScaleX(13f), TextAnchor.MiddleCenter, false, Color.white, Vector2.one * 2f, Color.black);
				}
			}
		}
		else if (bHS_asklife)
		{
			pIgt_Textures.DrawTexture(IGT_Constants._GreyOverLay, new Rect(0f, 0f, Screen.width, Screen.height), false);
			float num27 = pAnim_MailBox.easeFunctions(0.01f, 1f, 0.5f, 0);
			if (pAnim_MailBox.isAnimFinished() && pAnim_MailBox.getIsReverse())
			{
				bHS_asklife = false;
				NoMoLiveAlertScreen();
			}
			else
			{
				GUIUtility.ScaleAroundPivot(new Vector2(num27, num27), new Vector2(rect_MailBoxWin.x + rect_MailBoxWin.width * 0.5f, rect_MailBoxWin.y + rect_MailBoxWin.height * 0.5f));
				pIgt_Textures.DrawTexture(IGT_Constants._SettingsBg, rect_MailBoxWin, false);
				GUI.DrawTexture(new Rect(rect_MailBoxWin.x + IGT_UIcommonFunc.ScaleX(5f), rect_MailBoxName.y, rect_MailBoxWin.width - IGT_UIcommonFunc.ScaleX(11f), rect_MailBoxName.height), Drawrect_clr1);
				pIgt_Textures.DrawTexture(IGT_Constants._Abort_LifeIcon, new Rect(rect_MailBoxWin.x - IGT_UIcommonFunc.ScaleX(40f) / 4f, rect_MailBoxWin.y - IGT_UIcommonFunc.ScaleY(40f) / 4f, IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(40f)), false);
				pIgt_Lable.DrawLable(rect_MailBoxName, IGT_Constants.AskLife, IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(20f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, new Vector2(4f, 4f), Color.black);
				But_MailBox_Close.Draw_Button();
				if (pFacebook.isFBLoginSucess() && fbList != null && fbList.Count - 1 > 0)
				{
					But_AskLife_Accept.Draw_Button();
					But_AskLife_CheckAll.Draw_Button();
					pIgt_Lable.DrawLable(But_AskLife_Accept.getOriginalDimension(), "Ask", IGT_Constants.Font_LemonR, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.black, 1f, Color.black, Vector2.zero, Color.clear);
					pIgt_Lable.DrawLable(But_AskLife_CheckAll.getOriginalDimension(), "Check All", IGT_Constants.Font_LemonR, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.black, 1f, Color.black, Vector2.zero, Color.clear);
				}
				GUI.matrix = Matrix4x4.identity;
				if (pAnim_MailBox.isAnimFinished())
				{
					AskLifeWindowDataSelection();
				}
			}
		}
		if (bNoInternetAlert)
		{
			float num28 = 0f;
			num28 = (pAnim_NoInternet.getIsReverse() ? pAnim_NoInternet.easeFunctions(Screen.width, 0f, 1f, 28) : pAnim_NoInternet.easeFunctions(0f - rect_PausescreenBG.x - rect_PausescreenBG.width * 1.25f, 0f, 0.75f, 29));
			if (pAnim_NoInternet.isAnimFinished() && pAnim_NoInternet.getIsReverse())
			{
				bNoInternetAlert = false;
			}
			else
			{
				pIgt_Textures.DrawTexture(IGT_Constants._Pause_Bg, new Rect(rect_PausescreenBG.x + num28, rect_PausescreenBG.y, rect_PausescreenBG.width, rect_PausescreenBG.height), false);
				But_NoInternetAlertOK.setX(rect_PausescreenBG.x + rect_PausescreenBG.width / 2f - But_NoInternetAlertOK.getWidth() / 2f + num28);
				But_NoInternetAlertOK.Draw();
				pIgt_Lable.DrawLable(But_NoInternetAlertOK.getCurrentDimension(), "OK", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(16f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, new Vector2(1f, 1f), Color.black);
				pIgt_Lable.DrawLable(new Rect(rect_PausescreenBG.x + num28, rect_PausescreenBG.y - IGT_UIcommonFunc.ScaleY(48f), rect_PausescreenBG.width, rect_PausescreenBG.height), "No Internet Connection !", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(18f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, new Vector2(1f, 1f), Color.black);
				pIgt_Lable.DrawLable(new Rect(rect_PausescreenBG.x + num28, rect_PausescreenBG.y - IGT_UIcommonFunc.ScaleY(7f), rect_PausescreenBG.width, rect_PausescreenBG.height), "Please check your Internet \nConnection and try again.", IGT_Constants.Font_LemonR, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black);
			}
		}
		if (bAchievementAlert)
		{
			achievement_alertdraw(completed_achievement);
		}
		if (bToast)
		{
			draw_ToastMessage();
		}
		if (pHero.bTestingTeamPurpose)
		{
			pIgt_Lable.DrawLable(rect_Fps, pFps, IGT_Constants.Font_TakeYour, fontSize_Fps, Color.white, TextAnchor.LowerLeft, false);
		}
	}

	public static void start_sorryAlert()
	{
		bSorry = true;
		pAnim_sorryAlert.resetAllValues();
	}

	public static void draw_sorryAlert()
	{
		pIgt_Textures.DrawTexture(IGT_Constants._GreyOverLay, new Rect(0f, 0f, Screen.width, Screen.height), false);
		float num = pAnim_sorryAlert.easeFunctions(0f - IGT_UIcommonFunc.ScaleY(330f), IGT_UIcommonFunc.ScaleY(0f), 1f, 29);
		Rect imgRect = new Rect(IGT_UIcommonFunc.ScaleX(10f), num + IGT_UIcommonFunc.ScaleY(150f), IGT_UIcommonFunc.ScaleX(310f), IGT_UIcommonFunc.ScaleY(170f));
		pIgt_Textures.DrawTexture(IGT_Constants._SaveMeBG, imgRect, false);
		pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(20f), imgRect.y, IGT_UIcommonFunc.ScaleX(280f), imgRect.height / 2f), "Sorry, Your device is not playing this game adequately for a good gaming experience. ", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(14f), TextAnchor.MiddleCenter, true, Color.yellow, 2f, Color.black, Vector2.one, Color.white);
		pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(20f), imgRect.y + IGT_UIcommonFunc.ScaleY(60f), IGT_UIcommonFunc.ScaleX(280f), imgRect.height / 2f), "We will try to improve game performance for your device in future updates, \n   Please Check Later.", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(13f), TextAnchor.MiddleCenter, true, Color.yellow, 2f, Color.black, Vector2.one, Color.white);
		But_sorryAlert_Quit.setDimensions(imgRect.x + imgRect.width / 2f - But_sorryAlert_Quit.getWidth() / 2f, imgRect.y + IGT_UIcommonFunc.ScaleY(130f), But_sorryAlert_Quit.getWidth(), But_sorryAlert_Quit.getHeight());
		But_sorryAlert_Quit.Draw();
		pIgt_Lable.DrawLable(new Rect(imgRect.x + imgRect.width / 2f - But_sorryAlert_Quit.getWidth() / 2f, But_sorryAlert_Quit.getY(), But_sorryAlert_Quit.getWidth(), But_sorryAlert_Quit.getHeight()), "Quit", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, true, Color.white, 3f, Color.black, Vector2.zero, Color.white);
	}

	public static void stop_sorryAlert()
	{
		bSorry = false;
		Application.Quit();
	}

	private static void Start_Toast(string text)
	{
		bToast = true;
		fToast_StartTime = Time.time;
		pToastText = text;
		Rect rect = new Rect(IGT_UIcommonFunc.ScaleX(100f), IGT_UIcommonFunc.ScaleY(400f), IGT_UIcommonFunc.ScaleX(120f), IGT_UIcommonFunc.ScaleY(25f));
		if (pToastText.Length > 30)
		{
			rect.width = IGT_UIcommonFunc.ScaleX(280f);
		}
		else
		{
			rect.width = IGT_UIcommonFunc.ScaleX(20f) + IGT_UIcommonFunc.ScaleX(pToastText.Length * 10);
		}
		rect_Toast = new Rect((float)(Screen.width / 2) - rect.width / 2f, IGT_UIcommonFunc.ScaleY(400f), rect.width, IGT_UIcommonFunc.ScaleY(25f));
	}

	private void draw_ToastMessage()
	{
		float a = 1f;
		if (bToast_Alpha)
		{
			a = IGT_EaseFunction.Linear_ease(fToastAlpha_StartTime, 1f, 0.1f, 1f);
			fToastAlpha_StartTime += Time.deltaTime;
			if (fToastAlpha_StartTime > 1f)
			{
				bToast = false;
				bToast_Alpha = false;
			}
		}
		else if (Time.time - fToast_StartTime > 2f && !bToast_Alpha)
		{
			fToastAlpha_StartTime = 0f;
			bToast_Alpha = true;
		}
		Color color = GUI.color;
		GUI.color = new Color(color.r, color.g, color.b, a);
		GUI.DrawTexture(rect_Toast, rect_Black);
		int num;
		if (pToastText.Length < 20)
		{
			num = 15;
		}
		else
		{
			num = (int)(16f - (float)(pToastText.Length * 2));
			if (num < 10)
			{
				num = 10;
			}
		}
		pIgt_Lable.DrawLable(rect_Toast, pToastText, IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(num), TextAnchor.MiddleCenter, true, Color.white, 1f, Color.black, Vector2.one, Color.black);
		GUI.color = color;
	}

	private void draw_ChaseGameOverScreen()
	{
		pIgt_Textures.DrawTexture(IGT_Constants._EndlessRun_GameOver_TabBG, ScrollViewRectImg_GameoverScreen, false);
		if (nGameoverScrollType == 0)
		{
			GUI.DrawTexture(rect_GameoverScrollTitleBar, Mirror_BustedTab);
			pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, adj_drawrect(new Rect(But_FbScroll.getX() + IGT_UIcommonFunc.ScaleX(15f), But_FbScroll.getY() + IGT_UIcommonFunc.ScaleY(2f), But_FbScroll.getWidth(), But_FbScroll.getHeight()), new Rect(But_FbScroll.getX() + IGT_UIcommonFunc.ScaleX(11f), But_FbScroll.getY() + IGT_UIcommonFunc.ScaleY(9f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleY(22f)), 0), true);
			pIgt_Lable.DrawLable(new Rect(But_FbScroll.getX() + IGT_UIcommonFunc.ScaleX(15f), But_FbScroll.getY() + IGT_UIcommonFunc.ScaleY(2f), But_FbScroll.getWidth(), But_FbScroll.getHeight()), "Friends", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(16f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(2f, 2f), Color.black);
			pIgt_Textures.DrawTexture(IGT_Constants._TopchaseIcon, adj_drawrect(new Rect(But_TopchaseScroll.getX() + IGT_UIcommonFunc.ScaleX(10f), But_TopchaseScroll.getY() + IGT_UIcommonFunc.ScaleY(3f), But_TopchaseScroll.getWidth(), But_TopchaseScroll.getHeight()), new Rect(But_TopchaseScroll.getX() + IGT_UIcommonFunc.ScaleX(10f), But_TopchaseScroll.getY() + IGT_UIcommonFunc.ScaleY(13f), IGT_UIcommonFunc.ScaleX(17f), IGT_UIcommonFunc.ScaleY(17f)), 0), true);
			pIgt_Lable.DrawLable(new Rect(But_TopchaseScroll.getX() + IGT_UIcommonFunc.ScaleX(10f), But_TopchaseScroll.getY() + IGT_UIcommonFunc.ScaleY(3f), But_TopchaseScroll.getWidth(), But_TopchaseScroll.getHeight()), "Topchase", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(13f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(2f, 2f), Color.black);
			pIgt_Textures.DrawTexture(IGT_Constants._BustedIcon, adj_drawrect(new Rect(But_BustedScroll.getX() + IGT_UIcommonFunc.ScaleX(10f), But_BustedScroll.getY() + IGT_UIcommonFunc.ScaleY(4f), But_BustedScroll.getWidth(), But_BustedScroll.getHeight()), new Rect(But_BustedScroll.getX() + IGT_UIcommonFunc.ScaleX(17f), But_BustedScroll.getY() + IGT_UIcommonFunc.ScaleY(13f), IGT_UIcommonFunc.ScaleX(17f), IGT_UIcommonFunc.ScaleY(17f)), 0), true);
			pIgt_Lable.DrawLable(new Rect(But_BustedScroll.getX() + IGT_UIcommonFunc.ScaleX(10f), But_BustedScroll.getY() + IGT_UIcommonFunc.ScaleY(4f), But_BustedScroll.getWidth(), But_BustedScroll.getHeight()), "Caught", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(13f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(2f, 2f), Color.black);
		}
		else if (nGameoverScrollType == 1)
		{
			pIgt_Textures.DrawTexture(IGT_Constants._EndlessRun_GameOver_TopChaseTab, rect_GameoverScrollTitleBar, false);
			pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, adj_drawrect(new Rect(But_FbScroll.getX() + IGT_UIcommonFunc.ScaleX(11f), But_FbScroll.getY() + IGT_UIcommonFunc.ScaleY(4f), But_FbScroll.getWidth(), But_FbScroll.getHeight()), new Rect(But_FbScroll.getX() + IGT_UIcommonFunc.ScaleX(15f), But_FbScroll.getY() + IGT_UIcommonFunc.ScaleY(13f), IGT_UIcommonFunc.ScaleX(17f), IGT_UIcommonFunc.ScaleY(17f)), 0), true);
			pIgt_Lable.DrawLable(new Rect(But_FbScroll.getX() + IGT_UIcommonFunc.ScaleX(11f), But_FbScroll.getY() + IGT_UIcommonFunc.ScaleY(4f), But_FbScroll.getWidth(), But_FbScroll.getHeight()), "Friends", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(13f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(2f, 2f), Color.black);
			pIgt_Textures.DrawTexture(IGT_Constants._TopchaseIcon, adj_drawrect(new Rect(But_TopchaseScroll.getX() + IGT_UIcommonFunc.ScaleX(9f), But_TopchaseScroll.getY() + IGT_UIcommonFunc.ScaleY(3f), But_TopchaseScroll.getWidth(), But_TopchaseScroll.getHeight()), new Rect(But_TopchaseScroll.getX() + IGT_UIcommonFunc.ScaleX(1f), But_TopchaseScroll.getY() + IGT_UIcommonFunc.ScaleY(11f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleY(22f)), 0), true);
			pIgt_Lable.DrawLable(new Rect(But_TopchaseScroll.getX() + IGT_UIcommonFunc.ScaleX(9f), But_TopchaseScroll.getY() + IGT_UIcommonFunc.ScaleY(3f), But_TopchaseScroll.getWidth(), But_TopchaseScroll.getHeight()), "Topchase", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(16f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(2f, 2f), Color.black);
			pIgt_Textures.DrawTexture(IGT_Constants._BustedIcon, adj_drawrect(new Rect(But_BustedScroll.getX() + IGT_UIcommonFunc.ScaleX(10f), But_BustedScroll.getY() + IGT_UIcommonFunc.ScaleY(4f), But_BustedScroll.getWidth(), But_BustedScroll.getHeight()), new Rect(But_BustedScroll.getX() + IGT_UIcommonFunc.ScaleX(17f), But_BustedScroll.getY() + IGT_UIcommonFunc.ScaleY(13f), IGT_UIcommonFunc.ScaleX(17f), IGT_UIcommonFunc.ScaleY(17f)), 0), true);
			pIgt_Lable.DrawLable(new Rect(But_BustedScroll.getX() + IGT_UIcommonFunc.ScaleX(10f), But_BustedScroll.getY() + IGT_UIcommonFunc.ScaleY(4f), But_BustedScroll.getWidth(), But_BustedScroll.getHeight()), "Caught", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(13f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(2f, 2f), Color.black);
		}
		else if (nGameoverScrollType == 2)
		{
			pIgt_Textures.DrawTexture(IGT_Constants._EndlessRun_GameOver_BustedTab, rect_GameoverScrollTitleBar, false);
			pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, adj_drawrect(new Rect(But_FbScroll.getX() + IGT_UIcommonFunc.ScaleX(11f), But_FbScroll.getY() + IGT_UIcommonFunc.ScaleY(4f), But_FbScroll.getWidth(), But_FbScroll.getHeight()), new Rect(But_FbScroll.getX() + IGT_UIcommonFunc.ScaleX(15f), But_FbScroll.getY() + IGT_UIcommonFunc.ScaleY(13f), IGT_UIcommonFunc.ScaleX(17f), IGT_UIcommonFunc.ScaleY(17f)), 0), true);
			pIgt_Lable.DrawLable(new Rect(But_FbScroll.getX() + IGT_UIcommonFunc.ScaleX(11f), But_FbScroll.getY() + IGT_UIcommonFunc.ScaleY(4f), But_FbScroll.getWidth(), But_FbScroll.getHeight()), "Friends", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(13f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(2f, 2f), Color.black);
			pIgt_Textures.DrawTexture(IGT_Constants._TopchaseIcon, adj_drawrect(new Rect(But_TopchaseScroll.getX() + IGT_UIcommonFunc.ScaleX(10f), But_TopchaseScroll.getY() + IGT_UIcommonFunc.ScaleY(3f), But_TopchaseScroll.getWidth(), But_TopchaseScroll.getHeight()), new Rect(But_TopchaseScroll.getX() + IGT_UIcommonFunc.ScaleX(10f), But_TopchaseScroll.getY() + IGT_UIcommonFunc.ScaleY(13f), IGT_UIcommonFunc.ScaleX(17f), IGT_UIcommonFunc.ScaleY(17f)), 0), true);
			pIgt_Lable.DrawLable(new Rect(But_TopchaseScroll.getX() + IGT_UIcommonFunc.ScaleX(10f), But_TopchaseScroll.getY() + IGT_UIcommonFunc.ScaleY(3f), But_TopchaseScroll.getWidth(), But_TopchaseScroll.getHeight()), "Topchase", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(13f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(2f, 2f), Color.black);
			pIgt_Textures.DrawTexture(IGT_Constants._BustedIcon, adj_drawrect(new Rect(But_BustedScroll.getX() + IGT_UIcommonFunc.ScaleX(8f), But_BustedScroll.getY() + IGT_UIcommonFunc.ScaleY(1f), But_BustedScroll.getWidth(), But_BustedScroll.getHeight()), new Rect(But_BustedScroll.getX() + IGT_UIcommonFunc.ScaleX(6f), But_BustedScroll.getY() + IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleY(22f)), 0), true);
			pIgt_Lable.DrawLable(new Rect(But_BustedScroll.getX() + IGT_UIcommonFunc.ScaleX(8f), But_BustedScroll.getY() + IGT_UIcommonFunc.ScaleY(1f), But_BustedScroll.getWidth(), But_BustedScroll.getHeight()), "Caught", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(16f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(2f, 2f), Color.black);
		}
		float num = IGT_UIcommonFunc.ScaleX(180f);
		float num2 = IGT_UIcommonFunc.ScaleY(60f);
		float y = rect_GameoverScrollTitleBar.y + rect_GameoverScrollTitleBar.height * 0.5f + ScrollViewRectImg_GameoverScreen.height / 2f - num2 * 0.5f;
		float x = IGT_UIcommonFunc.ScaleX(160f) - num * 0.5f;
		Rect position = new Rect(x, y, num, num2);
		if (nLeaderBoard_Chase_DispState == 2 || nGameoverScrollType == 2)
		{
			Alt_gameOverScrollDataSel();
		}
		else if (nLeaderBoard_Chase_DispState == 1)
		{
			pIgt_Lable.DrawLable(position, _sNoInternet, IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(18f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black);
		}
		else if (nLeaderBoard_Chase_DispState == 3)
		{
			pIgt_Lable.DrawLable(position, _sConnectionFailed, IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(18f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black);
		}
		else if (nLeaderBoard_Chase_DispState == 0)
		{
			pIgt_Lable.DrawLable(position, _sLoading, IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(20f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black);
			if (Time.time - fLoadingStrtTime > fLoadingTotTime)
			{
				nLeaderBoard_Chase_DispState = 3;
			}
		}
		if (nGameoverScrollType != 2 && (nLeaderBoard_Chase_DispState == 1 || nLeaderBoard_Chase_DispState == 3))
		{
			But_GetScoreRetry.setY(position.y + IGT_UIcommonFunc.ScaleY(50f));
			But_GetScoreRetry.Draw_Button();
			pIgt_Lable.DrawLable(But_GetScoreRetry.getCurrentDimension(), "Retry", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(16f), TextAnchor.MiddleCenter, false, Color.white, Vector2.one * 2f, Color.black);
		}
	}

	private void draw_MissionGameOverScreen()
	{
		pIgt_Textures.DrawTexture(IGT_Constants._EndlessRun_GameOver_TabBG, ScrollViewRectImg_GameoverScreen, false);
		if (nMC_ScrollType == 0)
		{
			pIgt_Textures.DrawTexture(IGT_Constants._MissionGameOverTab, rect_GameoverScrollTitleBar, false);
			pIgt_Lable.DrawLable(new Rect(But_MC_FB_Global.getX() + IGT_UIcommonFunc.ScaleX(3f), But_MC_FB_Global.getY() + IGT_UIcommonFunc.ScaleY(3f), But_MC_FB_Global.getWidth(), But_MC_FB_Global.getHeight()), "World", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(13f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(1f, 1f), Color.black);
			pIgt_Lable.DrawLable(new Rect(But_MC_FB_Friends.getX() + IGT_UIcommonFunc.ScaleX(26f), But_MC_FB_Friends.getY() + IGT_UIcommonFunc.ScaleY(4f), But_MC_FB_Friends.getWidth(), But_MC_FB_Friends.getHeight()), "Friends", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(16f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(1f, 1f), Color.black);
			pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, adj_drawrect(new Rect(But_MC_FB_Friends.getX() + IGT_UIcommonFunc.ScaleX(26f), But_MC_FB_Friends.getY() + IGT_UIcommonFunc.ScaleY(4f), But_MC_FB_Friends.getWidth(), But_MC_FB_Friends.getHeight()), new Rect(But_MC_FB_Friends.getX() + IGT_UIcommonFunc.ScaleX(41f), But_MC_FB_Friends.getY() + IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleX(22f)), 0), false);
			pIgt_Textures.DrawTexture(IGT_Constants._GlobeIcon, adj_drawrect(new Rect(But_MC_FB_Global.getX() + IGT_UIcommonFunc.ScaleX(3f), But_MC_FB_Global.getY() + IGT_UIcommonFunc.ScaleY(3f), But_MC_FB_Global.getWidth(), But_MC_FB_Global.getHeight()), new Rect(But_MC_FB_Global.getX() + IGT_UIcommonFunc.ScaleX(38f), But_MC_FB_Global.getY() + IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleX(17f), IGT_UIcommonFunc.ScaleX(17f)), 0), false);
		}
		else if (nMC_ScrollType == 1)
		{
			GUI.DrawTexture(new Rect(rect_GameoverScrollTitleBar.x, rect_GameoverScrollTitleBar.y + IGT_UIcommonFunc.ScaleY(1f), rect_GameoverScrollTitleBar.width, rect_GameoverScrollTitleBar.height), Mirror_MC_FBtab);
			pIgt_Lable.DrawLable(new Rect(But_MC_FB_Global.getX() + IGT_UIcommonFunc.ScaleX(6f), But_MC_FB_Global.getY() + IGT_UIcommonFunc.ScaleY(4f), But_MC_FB_Global.getWidth(), But_MC_FB_Global.getHeight()), "World", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(16f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(1f, 1f), Color.black);
			pIgt_Lable.DrawLable(new Rect(But_MC_FB_Friends.getX() + IGT_UIcommonFunc.ScaleX(11f), But_MC_FB_Friends.getY() + IGT_UIcommonFunc.ScaleY(4f), But_MC_FB_Friends.getWidth(), But_MC_FB_Friends.getHeight()), "Friends", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(13f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(1f, 1f), Color.black);
			pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, adj_drawrect(new Rect(But_MC_FB_Friends.getX() + IGT_UIcommonFunc.ScaleX(11f), But_MC_FB_Friends.getY() + IGT_UIcommonFunc.ScaleY(4f), But_MC_FB_Friends.getWidth(), But_MC_FB_Friends.getHeight()), new Rect(But_MC_FB_Friends.getX() + IGT_UIcommonFunc.ScaleX(39f), But_MC_FB_Friends.getY() + IGT_UIcommonFunc.ScaleY(11f), IGT_UIcommonFunc.ScaleX(17f), IGT_UIcommonFunc.ScaleX(17f)), 0), false);
			pIgt_Textures.DrawTexture(IGT_Constants._GlobeIcon, adj_drawrect(new Rect(But_MC_FB_Global.getX() + IGT_UIcommonFunc.ScaleX(6f), But_MC_FB_Global.getY() + IGT_UIcommonFunc.ScaleY(4f), But_MC_FB_Global.getWidth(), But_MC_FB_Global.getHeight()), new Rect(But_MC_FB_Global.getX() + IGT_UIcommonFunc.ScaleX(30f), But_MC_FB_Global.getY() + IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleX(22f)), 0), false);
		}
		float num = IGT_UIcommonFunc.ScaleX(180f);
		float num2 = IGT_UIcommonFunc.ScaleY(60f);
		float y = rect_GameoverScrollTitleBar.y + rect_GameoverScrollTitleBar.height * 0.5f + ScrollViewRectImg_GameoverScreen.height / 2f - num2 * 0.5f;
		float x = IGT_UIcommonFunc.ScaleX(160f) - num * 0.5f;
		Rect position = new Rect(x, y, num, num2);
		if (nLeaderBoard_Mission_DispState == 1)
		{
			pIgt_Lable.DrawLable(position, _sNoInternet, IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(18f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black);
		}
		else if (nLeaderBoard_Mission_DispState == 3)
		{
			pIgt_Lable.DrawLable(position, _sConnectionFailed, IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(18f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black);
		}
		else if (nLeaderBoard_Mission_DispState == 0)
		{
			pIgt_Lable.DrawLable(position, _sLoading, IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(20f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black);
			if (Time.time - fLoadingStrtTime > fLoadingTotTime)
			{
				nLeaderBoard_Mission_DispState = 3;
			}
		}
		else if (nLeaderBoard_Mission_DispState == 2)
		{
			Alt_missionCompletedScrollDataSel();
		}
		pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(12f), IGT_UIcommonFunc.ScaleY(295f), IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(40f)), "Total Score ", IGT_Constants.Font_LemonR, (int)IGT_UIcommonFunc.ScaleX(10f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, new Vector2(2f, 2f), Color.black, -10f, new Vector2(0f, 0f));
		pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(12f), IGT_UIcommonFunc.ScaleY(310f), IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(40f)), pHero.nTotScore_Mission.ToString(), IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(16f), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.black, new Vector2(2f, 2f), Color.black, -10f, new Vector2(0f, 0f));
		if (nLeaderBoard_Mission_DispState == 1 || nLeaderBoard_Mission_DispState == 3)
		{
			But_GetScoreRetry.setY(position.y + IGT_UIcommonFunc.ScaleY(50f));
			But_GetScoreRetry.Draw_Button();
			pIgt_Lable.DrawLable(But_GetScoreRetry.getCurrentDimension(), "Retry", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(16f), TextAnchor.MiddleCenter, false, Color.white, Vector2.one * 2f, Color.black);
		}
	}

	private void isFBPageLiked(bool bLike)
	{
	}

	private void drawMapTesting()
	{
		levNum = int.Parse(GUI.TextField(new Rect(IGT_UIcommonFunc.ScaleX(90f), IGT_UIcommonFunc.ScaleY(380f), IGT_UIcommonFunc.ScaleX(45f), IGT_UIcommonFunc.ScaleY(18f)), string.Empty + levNum, styleNickName));
		if (GUI.Button(new Rect(IGT_UIcommonFunc.ScaleX(160f), IGT_UIcommonFunc.ScaleY(380f), IGT_UIcommonFunc.ScaleX(60f), IGT_UIcommonFunc.ScaleY(22f)), "SetLevel"))
		{
			pMapObj.levUnlockPoints(levNum);
		}
	}

	private void drawDebugMsg()
	{
		pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(10f), IGT_UIcommonFunc.ScaleY(120f), IGT_UIcommonFunc.ScaleX(300f), IGT_UIcommonFunc.ScaleY(140f)), "strTest : " + strTest, IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleLeft, true, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
	}

	private static string iOSInstalledAppList()
	{
		string text = string.Empty;
		for (int i = 0; i < IGT_Constants.iosBundleId.Count(); i++)
		{
			if (pMoregame.isInstalledApp("com.igoldtech." + IGT_Constants.iosBundleId[i]))
			{
				text = ((!text.Equals(string.Empty)) ? (text + "~" + IGT_Constants.iosBundleId[i]) : IGT_Constants.iosBundleId[i]);
			}
		}
		return text;
	}

	private void drawNickNameWindow()
	{
		pIgt_Textures.DrawTexture(IGT_Constants._GreyOverLay, new Rect(0f, 0f, Screen.width, Screen.height), false);
		float num = pAnim_MailBox.easeFunctions(0.01f, 1f, 1f, 28);
		GUIUtility.ScaleAroundPivot(new Vector2(num, num), new Vector2(rectNickNameAlert.x + rectNickNameAlert.width * 0.5f, rectNickNameAlert.y + rectNickNameAlert.height * 0.5f));
		GUI.DrawTexture(rectNickNameAlert, Nickname_clr);
		pIgt_Textures.drawBorder(rectNickNameAlert, 3f, Border_White);
		pIgt_Lable.DrawLable(new Rect(rectNickNameAlert.x + IGT_UIcommonFunc.ScaleX(30f), rectNickNameAlert.y + IGT_UIcommonFunc.ScaleY(15f), IGT_UIcommonFunc.ScaleX(120f), IGT_UIcommonFunc.ScaleY(30f)), "Enter NickName", IGT_Constants.Font_Jellee_Roman, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, false, Color.yellow, Vector2.zero, Color.black);
		Rect rect = new Rect(rectNickNameAlert.x + IGT_UIcommonFunc.ScaleX(30f), rectNickNameAlert.y + IGT_UIcommonFunc.ScaleY(55f), IGT_UIcommonFunc.ScaleX(120f), IGT_UIcommonFunc.ScaleY(22f));
		GUI.SetNextControlName("gopi");
		strNickName = GUI.TextField(rect, strNickName, 10, styleNickName);
		if (!bDefaultNickNameText && GUI.GetNameOfFocusedControl() == "gopi")
		{
			bDefaultNickNameText = true;
		}
		if (!bDefaultNickNameText)
		{
			pIgt_Lable.DrawLable(rect, "Click here...", IGT_Constants.Font_Jellee_Roman, (int)IGT_UIcommonFunc.ScaleX(11f), Color.gray, TextAnchor.MiddleCenter, true);
		}
		pIgt_Textures.drawBorder(rect, 3f, Border_Black);
		btnNickNameOk.Draw_Button();
		pIgt_Lable.DrawLable(new Rect(btnNickNameOk.getCurrentDimension().x, btnNickNameOk.getCurrentDimension().y, btnNickNameOk.getCurrentDimension().width, btnNickNameOk.getCurrentDimension().height), "OK", IGT_Constants.Font_Jellee_Roman, (int)IGT_UIcommonFunc.ScaleX(16f), TextAnchor.MiddleCenter, false, Color.yellow, Vector2.zero, Color.black);
		GUI.matrix = Matrix4x4.identity;
	}

	private void checkAlertWin(int _alertID, float touchX, float touchY, TouchPhase touchPhase)
	{
		if (_alertID != 0)
		{
			But_Inapp__Alert_Close.checkBounce(touchX, touchY, touchPhase);
			if (_alertID == 5)
			{
				But_Inapp_fbconnect.checkBounce(touchX, touchY, touchPhase);
			}
			else
			{
				But_Inapp__Alert_Store.checkBounce(touchX, touchY, touchPhase);
			}
		}
		switch (_alertID)
		{
		case 0:
			bInappAlert = false;
			break;
		case 5:
			break;
		case 1:
			But_Inapp_Alert_Coin1.checkBounce(touchX, touchY, touchPhase);
			But_Inapp_Alert_Coin2.checkBounce(touchX, touchY, touchPhase);
			But_Inapp_Alert_Coin3.checkBounce(touchX, touchY, touchPhase);
			break;
		case 2:
			But_Inapp_Alert_Key1.checkBounce(touchX, touchY, touchPhase);
			But_Inapp_Alert_Key2.checkBounce(touchX, touchY, touchPhase);
			But_Inapp_Alert_Key3.checkBounce(touchX, touchY, touchPhase);
			break;
		case 3:
			But_Inapp_Alert_Life1.checkBounce(touchX, touchY, touchPhase);
			But_Inapp_Alert_Life2.checkBounce(touchX, touchY, touchPhase);
			But_Inapp_Alert_Life3.checkBounce(touchX, touchY, touchPhase);
			break;
		case 4:
			But_Inapp_Alert_Combo1.checkBounce(touchX, touchY, touchPhase);
			But_Inapp_Alert_Combo2.checkBounce(touchX, touchY, touchPhase);
			But_Inapp_Alert_Combo3.checkBounce(touchX, touchY, touchPhase);
			break;
		}
	}

	private void draw_Inapp_AlertWindow(int _alertID)
	{
		float num = 0f;
		num = (pAnim_MailBox.getIsReverse() ? pAnim_MailBox.easeFunctions(Screen.width, 0f, 1f, 28) : pAnim_MailBox.easeFunctions(0f - rect_Inappalert_Win.x - rect_Inappalert_Win.width * 1.25f, 0f, 1f, 29));
		if (pAnim_MailBox.isAnimFinished() && pAnim_MailBox.getIsReverse())
		{
			bInappAlert = false;
			return;
		}
		if (_alertID != 0)
		{
			pIgt_Textures.DrawTexture(IGT_Constants._AlertBoard_Green, new Rect(rect_Inappalert_Win.x + num, rect_Inappalert_Win.y, rect_Inappalert_Win.width, rect_Inappalert_Win.height), false);
			But_Inapp__Alert_Close.setX(But_Inapp__Alert_Close.getOriginalDimension().x + num);
			But_Inapp__Alert_Close.Draw();
			if (_alertID == 5)
			{
				But_Inapp_fbconnect.setX(But_Inapp_fbconnect.getOriginalDimension().x + num);
				But_Inapp_fbconnect.Draw();
				string text = "Connect Facebook \nand earn free Lives";
				string text2 = "Connect";
				if (pFacebook.isFBLoginSucess())
				{
					text = "Invite friends";
					text2 = "Invite";
					pIgt_Lable.DrawLable(new Rect(rect_Inappalert_Win.x + num, rect_Inappalert_Win.y - IGT_UIcommonFunc.ScaleY(16f), rect_Inappalert_Win.width, rect_Inappalert_Win.height), "Get Free Lives by Inviting friends \n and compete with them.", IGT_Constants.Font_LemonR, (int)IGT_UIcommonFunc.ScaleX(14f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, new Vector2(2f, 2f), Color.black);
				}
				pIgt_Lable.DrawLable(new Rect(rect_Inappalert_Win.x + num, rect_Inappalert_Win.y - IGT_UIcommonFunc.ScaleY(60f), rect_Inappalert_Win.width, rect_Inappalert_Win.height), text, IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(19f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, new Vector2(2f, 2f), Color.black);
				pIgt_Lable.DrawLable(new Rect(But_Inapp_fbconnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(10f), But_Inapp_fbconnect.getCurrentDimension().y, But_Inapp_fbconnect.getCurrentDimension().width, But_Inapp_fbconnect.getCurrentDimension().height), text2, IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(16f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
				pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, new Rect(But_Inapp_fbconnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(8f), But_Inapp_fbconnect.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), false);
				if (pFacebook.isFBLoginSucess())
				{
					pIgt_Textures.DrawTexture(IGT_Constants._Life, new Rect(But_Inapp_fbconnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(130f), But_Inapp_fbconnect.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(13f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), 20f, Vector2.zero);
					pIgt_Lable.DrawLable(new Rect(But_Inapp_fbconnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(132f), But_Inapp_fbconnect.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(-10f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleY(22f)), "+" + IGT_Constants.nFBInviteLife, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black, 24f, Vector2.zero);
				}
				if (!pFacebook.isFBLoginSucess() && IGT_Preference.getInstance()._Get(kFBLoginfirstTime, 0) == 0)
				{
					pIgt_Textures.DrawTexture(IGT_Constants._Life, new Rect(But_Inapp_fbconnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(130f), But_Inapp_fbconnect.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(13f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), 20f, Vector2.zero);
					pIgt_Lable.DrawLable(new Rect(But_Inapp_fbconnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(132f), But_Inapp_fbconnect.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleY(22f)), "+" + IGT_Constants.nFBLoginLife, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black, 24f, Vector2.zero);
				}
			}
			else
			{
				pIgt_Lable.DrawLable(new Rect(rect_Inappalert_Win.x + num, rect_Inappalert_Win.y - IGT_UIcommonFunc.ScaleY(74f), rect_Inappalert_Win.width, rect_Inappalert_Win.height), "Grab the Offer Now !!!", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(17f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, new Vector2(2f, 2f), Color.black);
				But_Inapp__Alert_Store.setX(But_Inapp__Alert_Store.getOriginalDimension().x + num);
				But_Inapp__Alert_Store.Draw();
				pIgt_Textures.DrawTexture(IGT_Constants._Shop_HS, new Rect(But_Inapp__Alert_Store.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(10f), But_Inapp__Alert_Store.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(4.5f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), true);
				pIgt_Lable.DrawLable(new Rect(rect_Inappalert_Win.x + IGT_UIcommonFunc.ScaleX(75f) + num, rect_Inappalert_Win.y + rect_Inappalert_Win.height - IGT_UIcommonFunc.ScaleY(46f), IGT_UIcommonFunc.ScaleX(150f), IGT_UIcommonFunc.ScaleY(30f)), "For More Offers", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, new Vector2(2f, 2f), Color.black);
				pIgt_Lable.DrawLable(new Rect(But_Inapp__Alert_Store.getOriginalDimension().x + IGT_UIcommonFunc.ScaleX(16f) + num, But_Inapp__Alert_Store.getOriginalDimension().y, But_Inapp__Alert_Store.getOriginalDimension().width, But_Inapp__Alert_Store.getOriginalDimension().height), "Store", IGT_Constants.Font_alpha_echo, (int)(IGT_UIcommonFunc.ScaleX(16f) * But_Inapp__Alert_Store.getCurrentDimension().width / But_Inapp__Alert_Store.getWidth()), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black);
				if (!pHero.bRemoveAds)
				{
					if (_alertID == 4)
					{
						pIgt_Lable.DrawLable(new Rect(rect_Inappalert_Win.x + IGT_UIcommonFunc.ScaleX(75f) + num, rect_Inappalert_Win.y + rect_Inappalert_Win.height - IGT_UIcommonFunc.ScaleY(59f), IGT_UIcommonFunc.ScaleX(150f), IGT_UIcommonFunc.ScaleY(30f)), "* Any game item purchase will remove ads! *", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, new Color(1f, 1f, 1f, pAnim_menu_LeaderBoard.easeFunctions(0f, 1f, 0.95f, 0)), new Vector2(1f, 1f), Color.black);
					}
					else
					{
						pIgt_Lable.DrawLable(new Rect(rect_Inappalert_Win.x + IGT_UIcommonFunc.ScaleX(75f) + num, rect_Inappalert_Win.y + rect_Inappalert_Win.height - IGT_UIcommonFunc.ScaleY(64f), IGT_UIcommonFunc.ScaleX(150f), IGT_UIcommonFunc.ScaleY(30f)), "*  Any game item purchase will remove ads! *", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, new Color(1f, 1f, 1f, pAnim_menu_LeaderBoard.easeFunctions(0f, 1f, 0.95f, 0)), new Vector2(1f, 1f), Color.black);
					}
					if (pAnim_menu_LeaderBoard.isAnimFinished() && pAnim_menu_LeaderBoard.getIsReverse())
					{
						pAnim_menu_LeaderBoard.resetAllValues();
					}
					if (pAnim_menu_LeaderBoard.isAnimFinished() && !pAnim_menu_LeaderBoard.getIsReverse())
					{
						pAnim_menu_LeaderBoard.resetAllValues();
						pAnim_menu_LeaderBoard.setIsReverse(true);
					}
				}
			}
		}
		switch (_alertID)
		{
		case 0:
			bInappAlert = false;
			break;
		case 5:
			break;
		case 3:
			But_Inapp_Alert_Life1.setX(But_Inapp_Alert_Life1.getOriginalDimension().x + num);
			But_Inapp_Alert_Life1.Draw();
			But_Inapp_Alert_Life2.setX(But_Inapp_Alert_Life2.getOriginalDimension().x + num);
			But_Inapp_Alert_Life2.Draw();
			But_Inapp_Alert_Life3.setX(But_Inapp_Alert_Life3.getOriginalDimension().x + num);
			But_Inapp_Alert_Life3.Draw();
			pIgt_Textures.DrawTexture(IGT_Constants._AlertBoard_IconBG, new Rect(But_Inapp_Alert_Life2.getX() + IGT_UIcommonFunc.ScaleX(2f), But_Inapp_Alert_Life2.getY() - IGT_UIcommonFunc.ScaleY(82f), IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(85f)), false);
			pIgt_Textures.DrawTexture(IGT_Constants.Path_purchaseItemsImages + pHero.pPurchaseItemsData_Store[10].ImageName, new Rect(But_Inapp_Alert_Life2.getX() + IGT_UIcommonFunc.ScaleX(2f), But_Inapp_Alert_Life2.getY() - IGT_UIcommonFunc.ScaleY(80f), IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(60f)), false);
			pIgt_Textures.DrawTexture(IGT_Constants._AlertBoard_IconBG, new Rect(But_Inapp_Alert_Life1.getX() + IGT_UIcommonFunc.ScaleX(2f), But_Inapp_Alert_Life1.getY() - IGT_UIcommonFunc.ScaleY(82f), IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(85f)), false);
			pIgt_Textures.DrawTexture(IGT_Constants.Path_purchaseItemsImages + pHero.pPurchaseItemsData_Store[9].ImageName, new Rect(But_Inapp_Alert_Life1.getX() + IGT_UIcommonFunc.ScaleX(2f), But_Inapp_Alert_Life1.getY() - IGT_UIcommonFunc.ScaleY(80f), IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(60f)), false);
			pIgt_Textures.DrawTexture(IGT_Constants._AlertBoard_IconBG, new Rect(But_Inapp_Alert_Life3.getX() + IGT_UIcommonFunc.ScaleX(2f), But_Inapp_Alert_Life3.getY() - IGT_UIcommonFunc.ScaleY(82f), IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(85f)), false);
			pIgt_Textures.DrawTexture(IGT_Constants.Path_purchaseItemsImages + pHero.pPurchaseItemsData_Store[11].ImageName, new Rect(But_Inapp_Alert_Life3.getX() + IGT_UIcommonFunc.ScaleX(2f), But_Inapp_Alert_Life3.getY() - IGT_UIcommonFunc.ScaleY(80f), IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(60f)), false);
			pIgt_Lable.DrawLable(new Rect(But_Inapp_Alert_Life2.getX() + IGT_UIcommonFunc.ScaleX(2f), But_Inapp_Alert_Life2.getY() - IGT_UIcommonFunc.ScaleY(40f), IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(60f)), "25 Lives", IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(13f), TextAnchor.MiddleCenter, false, Color.white, 0f, Color.black);
			pIgt_Lable.DrawLable(new Rect(But_Inapp_Alert_Life1.getX() + IGT_UIcommonFunc.ScaleX(2f), But_Inapp_Alert_Life1.getY() - IGT_UIcommonFunc.ScaleY(40f), IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(60f)), "5 Lives", IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(13f), TextAnchor.MiddleCenter, false, Color.white, 0f, Color.black);
			pIgt_Lable.DrawLable(new Rect(But_Inapp_Alert_Life3.getX() + IGT_UIcommonFunc.ScaleX(2f), But_Inapp_Alert_Life3.getY() - IGT_UIcommonFunc.ScaleY(40f), IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(60f)), "100 Lives", IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(13f), TextAnchor.MiddleCenter, false, Color.white, 0f, Color.black);
			if (pHero.pIGT_IAPManagerAssist.isInitialisedSuccess())
			{
				pIgt_Lable.DrawLable(But_Inapp_Alert_Life2.getCurrentDimension(), pHero.pIGT_IAPManagerAssist.GetPriceforEachProduct(pHero.pPurchaseItemsData_Store[10].ProductID_GooglePlayStore), IGT_Constants.Font_Nunito_Bold, (int)(IGT_UIcommonFunc.ScaleX(13f) * But_Inapp_Alert_Life2.getCurrentDimension().width / But_Inapp_Alert_Life2.getWidth()), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black, 0f, Vector2.zero);
				pIgt_Lable.DrawLable(But_Inapp_Alert_Life1.getCurrentDimension(), pHero.pIGT_IAPManagerAssist.GetPriceforEachProduct(pHero.pPurchaseItemsData_Store[9].ProductID_GooglePlayStore), IGT_Constants.Font_Nunito_Bold, (int)(IGT_UIcommonFunc.ScaleX(14f) * But_Inapp_Alert_Life1.getCurrentDimension().width / But_Inapp_Alert_Life1.getWidth()), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black, 0f, Vector2.zero);
				pIgt_Lable.DrawLable(But_Inapp_Alert_Life3.getCurrentDimension(), pHero.pIGT_IAPManagerAssist.GetPriceforEachProduct(pHero.pPurchaseItemsData_Store[11].ProductID_GooglePlayStore), IGT_Constants.Font_Nunito_Bold, (int)(IGT_UIcommonFunc.ScaleX(13f) * But_Inapp_Alert_Life3.getCurrentDimension().width / But_Inapp_Alert_Life3.getWidth()), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black, 0f, Vector2.zero);
			}
			else
			{
				pIgt_Lable.DrawLable(But_Inapp_Alert_Life2.getCurrentDimension(), pHero.pPurchaseItemsData_Store[10].DefaultPrice, IGT_Constants.Font_Nunito_Bold, (int)(IGT_UIcommonFunc.ScaleX(13f) * But_Inapp_Alert_Life2.getCurrentDimension().width / But_Inapp_Alert_Life2.getWidth()), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black);
				pIgt_Lable.DrawLable(But_Inapp_Alert_Life1.getCurrentDimension(), pHero.pPurchaseItemsData_Store[9].DefaultPrice, IGT_Constants.Font_Nunito_Bold, (int)(IGT_UIcommonFunc.ScaleX(14f) * But_Inapp_Alert_Life1.getCurrentDimension().width / But_Inapp_Alert_Life1.getWidth()), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black);
				pIgt_Lable.DrawLable(But_Inapp_Alert_Life3.getCurrentDimension(), pHero.pPurchaseItemsData_Store[11].DefaultPrice, IGT_Constants.Font_Nunito_Bold, (int)(IGT_UIcommonFunc.ScaleX(13f) * But_Inapp_Alert_Life3.getCurrentDimension().width / But_Inapp_Alert_Life3.getWidth()), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black);
			}
			break;
		case 2:
			But_Inapp_Alert_Key1.setX(But_Inapp_Alert_Key1.getOriginalDimension().x + num);
			But_Inapp_Alert_Key1.Draw();
			But_Inapp_Alert_Key2.setX(But_Inapp_Alert_Key2.getOriginalDimension().x + num);
			But_Inapp_Alert_Key2.Draw();
			But_Inapp_Alert_Key3.setX(But_Inapp_Alert_Key3.getOriginalDimension().x + num);
			But_Inapp_Alert_Key3.Draw();
			pIgt_Textures.DrawTexture(IGT_Constants._AlertBoard_IconBG, new Rect(But_Inapp_Alert_Key2.getX() + IGT_UIcommonFunc.ScaleX(2f), But_Inapp_Alert_Key2.getY() - IGT_UIcommonFunc.ScaleY(82f), IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(85f)), false);
			pIgt_Textures.DrawTexture(IGT_Constants.Path_purchaseItemsImages + pHero.pPurchaseItemsData_Store[6].ImageName, new Rect(But_Inapp_Alert_Key2.getX() + IGT_UIcommonFunc.ScaleX(2f), But_Inapp_Alert_Key2.getY() - IGT_UIcommonFunc.ScaleY(80f), IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(60f)), false);
			pIgt_Textures.DrawTexture(IGT_Constants._AlertBoard_IconBG, new Rect(But_Inapp_Alert_Key1.getX() + IGT_UIcommonFunc.ScaleX(2f), But_Inapp_Alert_Key1.getY() - IGT_UIcommonFunc.ScaleY(82f), IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(85f)), false);
			pIgt_Textures.DrawTexture(IGT_Constants.Path_purchaseItemsImages + pHero.pPurchaseItemsData_Store[5].ImageName, new Rect(But_Inapp_Alert_Key1.getX() + IGT_UIcommonFunc.ScaleX(2f), But_Inapp_Alert_Key1.getY() - IGT_UIcommonFunc.ScaleY(75f), IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(60f)), false);
			pIgt_Textures.DrawTexture(IGT_Constants._AlertBoard_IconBG, new Rect(But_Inapp_Alert_Key3.getX() + IGT_UIcommonFunc.ScaleX(2f), But_Inapp_Alert_Key3.getY() - IGT_UIcommonFunc.ScaleY(82f), IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(85f)), false);
			pIgt_Textures.DrawTexture(IGT_Constants.Path_purchaseItemsImages + pHero.pPurchaseItemsData_Store[7].ImageName, new Rect(But_Inapp_Alert_Key3.getX() + IGT_UIcommonFunc.ScaleX(2f), But_Inapp_Alert_Key3.getY() - IGT_UIcommonFunc.ScaleY(80f), IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(60f)), false);
			pIgt_Lable.DrawLable(new Rect(But_Inapp_Alert_Key2.getX() + IGT_UIcommonFunc.ScaleX(2f), But_Inapp_Alert_Key2.getY() - IGT_UIcommonFunc.ScaleY(40f), IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(60f)), "120 keys", IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(14f), TextAnchor.MiddleCenter, false, Color.white, 0f, Color.black);
			pIgt_Lable.DrawLable(new Rect(But_Inapp_Alert_Key1.getX() + IGT_UIcommonFunc.ScaleX(2f), But_Inapp_Alert_Key1.getY() - IGT_UIcommonFunc.ScaleY(40f), IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(60f)), "30 keys", IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(14f), TextAnchor.MiddleCenter, false, Color.white, 0f, Color.black);
			pIgt_Lable.DrawLable(new Rect(But_Inapp_Alert_Key3.getX() + IGT_UIcommonFunc.ScaleX(2f), But_Inapp_Alert_Key3.getY() - IGT_UIcommonFunc.ScaleY(40f), IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(60f)), "300 keys", IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(14f), TextAnchor.MiddleCenter, false, Color.white, 0f, Color.black);
			if (pHero.pIGT_IAPManagerAssist.isInitialisedSuccess())
			{
				pIgt_Lable.DrawLable(But_Inapp_Alert_Key2.getCurrentDimension(), pHero.pIGT_IAPManagerAssist.GetPriceforEachProduct(pHero.pPurchaseItemsData_Store[6].ProductID_GooglePlayStore), IGT_Constants.Font_Nunito_Bold, (int)(IGT_UIcommonFunc.ScaleX(13f) * But_Inapp_Alert_Key2.getCurrentDimension().width / But_Inapp_Alert_Key2.getWidth()), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black, 0f, Vector2.zero);
				pIgt_Lable.DrawLable(But_Inapp_Alert_Key1.getCurrentDimension(), pHero.pIGT_IAPManagerAssist.GetPriceforEachProduct(pHero.pPurchaseItemsData_Store[5].ProductID_GooglePlayStore), IGT_Constants.Font_Nunito_Bold, (int)(IGT_UIcommonFunc.ScaleX(14f) * But_Inapp_Alert_Key1.getCurrentDimension().width / But_Inapp_Alert_Key1.getWidth()), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black, 0f, Vector2.zero);
				pIgt_Lable.DrawLable(But_Inapp_Alert_Key3.getCurrentDimension(), pHero.pIGT_IAPManagerAssist.GetPriceforEachProduct(pHero.pPurchaseItemsData_Store[7].ProductID_GooglePlayStore), IGT_Constants.Font_Nunito_Bold, (int)(IGT_UIcommonFunc.ScaleX(13f) * But_Inapp_Alert_Key3.getCurrentDimension().width / But_Inapp_Alert_Key3.getWidth()), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black, 0f, Vector2.zero);
			}
			else
			{
				pIgt_Lable.DrawLable(But_Inapp_Alert_Key2.getCurrentDimension(), pHero.pPurchaseItemsData_Store[6].DefaultPrice, IGT_Constants.Font_Nunito_Bold, (int)(IGT_UIcommonFunc.ScaleX(13f) * But_Inapp_Alert_Key2.getCurrentDimension().width / But_Inapp_Alert_Key2.getWidth()), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black, 0f, Vector2.zero);
				pIgt_Lable.DrawLable(But_Inapp_Alert_Key1.getCurrentDimension(), pHero.pPurchaseItemsData_Store[5].DefaultPrice, IGT_Constants.Font_Nunito_Bold, (int)(IGT_UIcommonFunc.ScaleX(14f) * But_Inapp_Alert_Key1.getCurrentDimension().width / But_Inapp_Alert_Key1.getWidth()), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black, 0f, Vector2.zero);
				pIgt_Lable.DrawLable(But_Inapp_Alert_Key3.getCurrentDimension(), pHero.pPurchaseItemsData_Store[7].DefaultPrice, IGT_Constants.Font_Nunito_Bold, (int)(IGT_UIcommonFunc.ScaleX(13f) * But_Inapp_Alert_Key3.getCurrentDimension().width / But_Inapp_Alert_Key3.getWidth()), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black, 0f, Vector2.zero);
			}
			break;
		case 1:
			But_Inapp_Alert_Coin1.setX(But_Inapp_Alert_Coin1.getOriginalDimension().x + num);
			But_Inapp_Alert_Coin1.Draw();
			But_Inapp_Alert_Coin2.setX(But_Inapp_Alert_Coin2.getOriginalDimension().x + num);
			But_Inapp_Alert_Coin2.Draw();
			But_Inapp_Alert_Coin3.setX(But_Inapp_Alert_Coin3.getOriginalDimension().x + num);
			But_Inapp_Alert_Coin3.Draw();
			pIgt_Textures.DrawTexture(IGT_Constants._AlertBoard_IconBG, new Rect(But_Inapp_Alert_Coin2.getX() + IGT_UIcommonFunc.ScaleX(2f), But_Inapp_Alert_Coin2.getY() - IGT_UIcommonFunc.ScaleY(83f), IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(85f)), false);
			pIgt_Textures.DrawTexture(IGT_Constants.Path_purchaseItemsImages + pHero.pPurchaseItemsData_Store[2].ImageName, new Rect(But_Inapp_Alert_Coin2.getX() + IGT_UIcommonFunc.ScaleX(4f), But_Inapp_Alert_Coin2.getY() - IGT_UIcommonFunc.ScaleY(83f), IGT_UIcommonFunc.ScaleX(70f), IGT_UIcommonFunc.ScaleY(55f)), false);
			pIgt_Textures.DrawTexture(IGT_Constants._AlertBoard_IconBG, new Rect(But_Inapp_Alert_Coin1.getX() + IGT_UIcommonFunc.ScaleX(2f), But_Inapp_Alert_Coin1.getY() - IGT_UIcommonFunc.ScaleY(83f), IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(85f)), false);
			pIgt_Textures.DrawTexture(IGT_Constants.Path_purchaseItemsImages + pHero.pPurchaseItemsData_Store[1].ImageName, new Rect(But_Inapp_Alert_Coin1.getX() + IGT_UIcommonFunc.ScaleX(4f), But_Inapp_Alert_Coin1.getY() - IGT_UIcommonFunc.ScaleY(83f), IGT_UIcommonFunc.ScaleX(70f), IGT_UIcommonFunc.ScaleY(55f)), false);
			pIgt_Textures.DrawTexture(IGT_Constants._AlertBoard_IconBG, new Rect(But_Inapp_Alert_Coin3.getX() + IGT_UIcommonFunc.ScaleX(2f), But_Inapp_Alert_Coin3.getY() - IGT_UIcommonFunc.ScaleY(83f), IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(85f)), false);
			pIgt_Textures.DrawTexture(IGT_Constants.Path_purchaseItemsImages + pHero.pPurchaseItemsData_Store[4].ImageName, new Rect(But_Inapp_Alert_Coin3.getX() + IGT_UIcommonFunc.ScaleX(4f), But_Inapp_Alert_Coin3.getY() - IGT_UIcommonFunc.ScaleY(83f), IGT_UIcommonFunc.ScaleX(70f), IGT_UIcommonFunc.ScaleY(55f)), false);
			pIgt_Lable.DrawLable(new Rect(But_Inapp_Alert_Coin2.getX() + IGT_UIcommonFunc.ScaleX(2f), But_Inapp_Alert_Coin2.getY() - IGT_UIcommonFunc.ScaleY(28f), IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(30f)), "125000\nCoins", IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(13f), TextAnchor.MiddleCenter, false, Color.white, 0f, Color.black);
			pIgt_Lable.DrawLable(new Rect(But_Inapp_Alert_Coin1.getX() + IGT_UIcommonFunc.ScaleX(2f), But_Inapp_Alert_Coin1.getY() - IGT_UIcommonFunc.ScaleY(28f), IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(30f)), "30000\nCoins", IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(13f), TextAnchor.MiddleCenter, false, Color.white, 0f, Color.black);
			pIgt_Lable.DrawLable(new Rect(But_Inapp_Alert_Coin3.getX() + IGT_UIcommonFunc.ScaleX(2f), But_Inapp_Alert_Coin3.getY() - IGT_UIcommonFunc.ScaleY(28f), IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(30f)), "1000000\nCoins", IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(13f), TextAnchor.MiddleCenter, false, Color.white, 0f, Color.black);
			if (pHero.pIGT_IAPManagerAssist.isInitialisedSuccess())
			{
				pIgt_Lable.DrawLable(But_Inapp_Alert_Coin2.getCurrentDimension(), pHero.pIGT_IAPManagerAssist.GetPriceforEachProduct(pHero.pPurchaseItemsData_Store[2].ProductID_GooglePlayStore), IGT_Constants.Font_Nunito_Bold, (int)(IGT_UIcommonFunc.ScaleX(13f) * But_Inapp_Alert_Coin2.getCurrentDimension().width / But_Inapp_Alert_Coin2.getWidth()), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black, 0f, Vector2.zero);
				pIgt_Lable.DrawLable(But_Inapp_Alert_Coin1.getCurrentDimension(), pHero.pIGT_IAPManagerAssist.GetPriceforEachProduct(pHero.pPurchaseItemsData_Store[1].ProductID_GooglePlayStore), IGT_Constants.Font_Nunito_Bold, (int)(IGT_UIcommonFunc.ScaleX(14f) * But_Inapp_Alert_Coin1.getCurrentDimension().width / But_Inapp_Alert_Coin1.getWidth()), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black, 0f, Vector2.zero);
				pIgt_Lable.DrawLable(But_Inapp_Alert_Coin3.getCurrentDimension(), pHero.pIGT_IAPManagerAssist.GetPriceforEachProduct(pHero.pPurchaseItemsData_Store[4].ProductID_GooglePlayStore), IGT_Constants.Font_Nunito_Bold, (int)(IGT_UIcommonFunc.ScaleX(13f) * But_Inapp_Alert_Coin3.getCurrentDimension().width / But_Inapp_Alert_Coin3.getWidth()), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black, 0f, Vector2.zero);
			}
			else
			{
				pIgt_Lable.DrawLable(But_Inapp_Alert_Coin2.getCurrentDimension(), pHero.pPurchaseItemsData_Store[2].DefaultPrice, IGT_Constants.Font_Nunito_Bold, (int)(IGT_UIcommonFunc.ScaleX(13f) * But_Inapp_Alert_Coin2.getCurrentDimension().width / But_Inapp_Alert_Coin2.getWidth()), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black);
				pIgt_Lable.DrawLable(But_Inapp_Alert_Coin1.getCurrentDimension(), pHero.pPurchaseItemsData_Store[1].DefaultPrice, IGT_Constants.Font_Nunito_Bold, (int)(IGT_UIcommonFunc.ScaleX(14f) * But_Inapp_Alert_Coin1.getCurrentDimension().width / But_Inapp_Alert_Coin1.getWidth()), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black);
				pIgt_Lable.DrawLable(But_Inapp_Alert_Coin3.getCurrentDimension(), pHero.pPurchaseItemsData_Store[4].DefaultPrice, IGT_Constants.Font_Nunito_Bold, (int)(IGT_UIcommonFunc.ScaleX(13f) * But_Inapp_Alert_Coin3.getCurrentDimension().width / But_Inapp_Alert_Coin3.getWidth()), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black);
			}
			break;
		case 4:
			But_Inapp_Alert_Combo1.setX(But_Inapp_Alert_Combo1.getOriginalDimension().x + num);
			But_Inapp_Alert_Combo1.Draw();
			But_Inapp_Alert_Combo2.setX(But_Inapp_Alert_Combo2.getOriginalDimension().x + num);
			But_Inapp_Alert_Combo2.Draw();
			But_Inapp_Alert_Combo3.setX(But_Inapp_Alert_Combo3.getOriginalDimension().x + num);
			But_Inapp_Alert_Combo3.Draw();
			pIgt_Textures.DrawTexture(IGT_Constants._AlertBoard_IconBG, new Rect(But_Inapp_Alert_Combo2.getX() + IGT_UIcommonFunc.ScaleX(2f), But_Inapp_Alert_Combo2.getY() - IGT_UIcommonFunc.ScaleY(97f), IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(100f)), false);
			pIgt_Textures.DrawTexture(IGT_Constants.Path_purchaseItemsImages + pHero.pPurchaseItemsData_Deals[1].ImageName, new Rect(But_Inapp_Alert_Combo2.getX() + IGT_UIcommonFunc.ScaleX(12f), But_Inapp_Alert_Combo2.getY() - IGT_UIcommonFunc.ScaleY(93f), IGT_UIcommonFunc.ScaleX(55f), IGT_UIcommonFunc.ScaleY(40f)), false);
			pIgt_Textures.DrawTexture(IGT_Constants._AlertBoard_IconBG, new Rect(But_Inapp_Alert_Combo1.getX() + IGT_UIcommonFunc.ScaleX(2f), But_Inapp_Alert_Combo1.getY() - IGT_UIcommonFunc.ScaleY(97f), IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(100f)), false);
			pIgt_Textures.DrawTexture(IGT_Constants.Path_purchaseItemsImages + pHero.pPurchaseItemsData_Deals[0].ImageName, new Rect(But_Inapp_Alert_Combo1.getX() + IGT_UIcommonFunc.ScaleX(12f), But_Inapp_Alert_Combo1.getY() - IGT_UIcommonFunc.ScaleY(93f), IGT_UIcommonFunc.ScaleX(55f), IGT_UIcommonFunc.ScaleY(40f)), false);
			pIgt_Textures.DrawTexture(IGT_Constants._AlertBoard_IconBG, new Rect(But_Inapp_Alert_Combo3.getX() + IGT_UIcommonFunc.ScaleX(2f), But_Inapp_Alert_Combo3.getY() - IGT_UIcommonFunc.ScaleY(97f), IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(100f)), false);
			pIgt_Textures.DrawTexture(IGT_Constants.Path_purchaseItemsImages + pHero.pPurchaseItemsData_Deals[3].ImageName, new Rect(But_Inapp_Alert_Combo3.getX() + IGT_UIcommonFunc.ScaleX(12f), But_Inapp_Alert_Combo3.getY() - IGT_UIcommonFunc.ScaleY(95f), IGT_UIcommonFunc.ScaleX(55f), IGT_UIcommonFunc.ScaleY(40f)), false);
			pIgt_Lable.DrawLable(new Rect(But_Inapp_Alert_Combo2.getX() + IGT_UIcommonFunc.ScaleX(3f), But_Inapp_Alert_Combo2.getY() - IGT_UIcommonFunc.ScaleY(58f), IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(60f)), "50000 Coins\n+\n30 Lives", IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black);
			pIgt_Lable.DrawLable(new Rect(But_Inapp_Alert_Combo1.getX() + IGT_UIcommonFunc.ScaleX(3f), But_Inapp_Alert_Combo1.getY() - IGT_UIcommonFunc.ScaleY(58f), IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(60f)), "25000 Coins\n+\n25 Keys", IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black);
			pIgt_Lable.DrawLable(new Rect(But_Inapp_Alert_Combo3.getX() + IGT_UIcommonFunc.ScaleX(3f), But_Inapp_Alert_Combo3.getY() - IGT_UIcommonFunc.ScaleY(58f), IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(60f)), "150000 Coins\n+\n150 keys\n+\n150 Lives", IGT_Constants.Font_TTMasters, (int)IGT_UIcommonFunc.ScaleX(10f), TextAnchor.MiddleCenter, false, Color.white, 0f, Color.black);
			if (pHero.pIGT_IAPManagerAssist.isInitialisedSuccess())
			{
				pIgt_Lable.DrawLable(But_Inapp_Alert_Combo2.getCurrentDimension(), pHero.pIGT_IAPManagerAssist.GetPriceforEachProduct(pHero.pPurchaseItemsData_Deals[1].ProductID_GooglePlayStore), IGT_Constants.Font_Nunito_Bold, (int)(IGT_UIcommonFunc.ScaleX(13f) * But_Inapp_Alert_Combo2.getCurrentDimension().width / But_Inapp_Alert_Combo2.getWidth()), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black, 0f, Vector2.zero);
				pIgt_Lable.DrawLable(But_Inapp_Alert_Combo1.getCurrentDimension(), pHero.pIGT_IAPManagerAssist.GetPriceforEachProduct(pHero.pPurchaseItemsData_Deals[0].ProductID_GooglePlayStore), IGT_Constants.Font_Nunito_Bold, (int)(IGT_UIcommonFunc.ScaleX(14f) * But_Inapp_Alert_Combo1.getCurrentDimension().width / But_Inapp_Alert_Combo1.getWidth()), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black, 0f, Vector2.zero);
				pIgt_Lable.DrawLable(But_Inapp_Alert_Combo3.getCurrentDimension(), pHero.pIGT_IAPManagerAssist.GetPriceforEachProduct(pHero.pPurchaseItemsData_Deals[3].ProductID_GooglePlayStore), IGT_Constants.Font_Nunito_Bold, (int)(IGT_UIcommonFunc.ScaleX(13f) * But_Inapp_Alert_Combo3.getCurrentDimension().width / But_Inapp_Alert_Combo3.getWidth()), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black, 0f, Vector2.zero);
			}
			else
			{
				pIgt_Lable.DrawLable(But_Inapp_Alert_Combo2.getCurrentDimension(), pHero.pPurchaseItemsData_Deals[1].DefaultPrice, IGT_Constants.Font_Nunito_Bold, (int)(IGT_UIcommonFunc.ScaleX(13f) * But_Inapp_Alert_Combo2.getCurrentDimension().width / But_Inapp_Alert_Combo2.getWidth()), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black);
				pIgt_Lable.DrawLable(But_Inapp_Alert_Combo1.getCurrentDimension(), pHero.pPurchaseItemsData_Deals[0].DefaultPrice, IGT_Constants.Font_Nunito_Bold, (int)(IGT_UIcommonFunc.ScaleX(14f) * But_Inapp_Alert_Combo1.getCurrentDimension().width / But_Inapp_Alert_Combo1.getWidth()), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black);
				pIgt_Lable.DrawLable(But_Inapp_Alert_Combo3.getCurrentDimension(), pHero.pPurchaseItemsData_Deals[3].DefaultPrice, IGT_Constants.Font_Nunito_Bold, (int)(IGT_UIcommonFunc.ScaleX(13f) * But_Inapp_Alert_Combo3.getCurrentDimension().width / But_Inapp_Alert_Combo3.getWidth()), TextAnchor.MiddleCenter, false, Color.yellow, 0f, Color.green, new Vector2(1f, 1f), Color.black);
			}
			break;
		}
	}

	public static void Inapp_Alert_Window_Close_ButtonEvents()
	{
		if (pAnim_MailBox.isAnimFinished())
		{
			pAnim_MailBox.resetAllValues();
			pAnim_MailBox.setIsReverse(true);
		}
	}

	private void drawAllShare()
	{
		pIgt_Textures.DrawTexture(IGT_Constants._GreyOverLay, new Rect(0f, 0f, Screen.width, Screen.height), false);
		float num = pAnim_MailBox.easeFunctions((float)Screen.width - IGT_UIcommonFunc.ScaleX(20f), 0f, 1f, 29);
		if (pAnim_MailBox.getIsReverse())
		{
			bAppNotInstalledAlert = false;
		}
		if (pAnim_MailBox.isAnimFinished() && pAnim_MailBox.getIsReverse())
		{
			bAllShareAlerts = false;
			bHS_allshare = false;
		}
		else
		{
			pIgt_Textures.DrawTexture(IGT_Constants._NotEnoughKeys_BG, new Rect(rect_AllShareBg.x + num, rect_AllShareBg.y, rect_AllShareBg.width, rect_AllShareBg.height), false);
			pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(160f) - IGT_UIcommonFunc.ScaleX(75f) + num, rect_AllShareBg.y + IGT_UIcommonFunc.ScaleY(9f), IGT_UIcommonFunc.ScaleX(150f), IGT_UIcommonFunc.ScaleY(30f)), IGT_Constants.AllShare, IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(22f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, new Vector2(4f, 4f), Color.black);
			pIgt_Textures.DrawTexture(IGT_Constants._AllShare, new Rect(rect_AllShareBg.x - IGT_UIcommonFunc.ScaleX(40f) / 4f + num, rect_AllShareBg.y - IGT_UIcommonFunc.ScaleY(40f) / 4f, IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleY(40f)), true);
			But_AllShare_Close.setX(But_AllShare_Close.getOriginalDimension().x + num);
			But_AllShare_Close.Draw_Button_CenterPoint();
			btn_fbLog.setX(btn_fbLog.getOriginalDimension().x + num);
			btn_fbLog.Draw_Button();
			if (currentTimeSecs() - fbShareTime >= 86400 && !canfbShare)
			{
				canfbShare = true;
				IGT_Constants.fbText = "Get " + IGT_Constants.nFBShareLife + "  Lives";
			}
			if (canfbShare)
			{
				pIgt_Textures.DrawTextureFromCenter(IGT_Constants._Life, new Rect(btn_fbLog.getOriginalDimension().x + adjX + num, btn_fbLog.getOriginalDimension().y, IGT_UIcommonFunc.ScaleX(27f), IGT_UIcommonFunc.ScaleY(25f)), 22f, Vector2.zero);
				pIgt_Lable.DrawLableFromCenter(new Rect(btn_fbLog.getOriginalDimension().x + adjX + num + IGT_UIcommonFunc.ScaleX(5f), btn_fbLog.getOriginalDimension().y - adjY + IGT_UIcommonFunc.ScaleY(19f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleY(22f)), "+" + IGT_Constants.nFBShareLife, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black, 24f, Vector2.zero);
			}
			pIgt_Textures.DrawTextureFromCenter(IGT_Constants._Button_Blue, new Rect(num + btn_fbLog.getOriginalDimension().x + IGT_UIcommonFunc.ScaleX(20f), btn_fbLog.getOriginalDimension().y + btn_fbLog.getOriginalDimension().height + IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleX(58f), IGT_UIcommonFunc.ScaleY(18f)), 0f, Vector2.zero);
			pIgt_Lable.DrawLableFromCenter(new Rect(num + btn_fbLog.getOriginalDimension().x + IGT_UIcommonFunc.ScaleX(20f), btn_fbLog.getOriginalDimension().y + btn_fbLog.getOriginalDimension().height + IGT_UIcommonFunc.ScaleY(9f), IGT_UIcommonFunc.ScaleX(2f), IGT_UIcommonFunc.ScaleY(22f)), IGT_Constants.fbText, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(7f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
			btn_Whatsapp.setX(btn_Whatsapp.getOriginalDimension().x + num);
			btn_Whatsapp.Draw_Button();
			if (currentTimeSecs() - whatsappShareTime >= 86400 && !canwhatsappShare)
			{
				canwhatsappShare = true;
				IGT_Constants.whatsAppText = "Get " + IGT_Constants.nWhatsappShareLife + "  Life";
			}
			if (canwhatsappShare)
			{
				pIgt_Textures.DrawTextureFromCenter(IGT_Constants._Life, new Rect(btn_Whatsapp.getOriginalDimension().x + adjX + num, btn_Whatsapp.getOriginalDimension().y, IGT_UIcommonFunc.ScaleX(27f), IGT_UIcommonFunc.ScaleY(25f)), 22f, Vector2.zero);
				pIgt_Lable.DrawLableFromCenter(new Rect(btn_Whatsapp.getOriginalDimension().x + adjX + num + IGT_UIcommonFunc.ScaleX(5f), btn_Whatsapp.getOriginalDimension().y - adjY + IGT_UIcommonFunc.ScaleY(19f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleY(22f)), "+" + IGT_Constants.nWhatsappShareLife, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black, 24f, Vector2.zero);
			}
			pIgt_Textures.DrawTextureFromCenter(IGT_Constants._Button_Blue, new Rect(num + btn_Whatsapp.getOriginalDimension().x + IGT_UIcommonFunc.ScaleX(20f), btn_Whatsapp.getOriginalDimension().y + btn_Whatsapp.getOriginalDimension().height + IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleX(58f), IGT_UIcommonFunc.ScaleY(18f)), 0f, Vector2.zero);
			pIgt_Lable.DrawLableFromCenter(new Rect(num + btn_Whatsapp.getOriginalDimension().x + IGT_UIcommonFunc.ScaleX(20f), btn_Whatsapp.getOriginalDimension().y + btn_Whatsapp.getOriginalDimension().height + IGT_UIcommonFunc.ScaleY(9f), IGT_UIcommonFunc.ScaleX(2f), IGT_UIcommonFunc.ScaleY(22f)), IGT_Constants.whatsAppText, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(7f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
			btn_MailShare.setX(btn_MailShare.getOriginalDimension().x + num);
			btn_MailShare.Draw_Button();
			if (currentTimeSecs() - mailShareTime >= 86400 && !canmailShare)
			{
				canmailShare = true;
				IGT_Constants.mailText = "Get " + IGT_Constants.nMailShareLife + "  Life";
			}
			if (canmailShare)
			{
				pIgt_Textures.DrawTextureFromCenter(IGT_Constants._Life, new Rect(btn_MailShare.getOriginalDimension().x + adjX + num, btn_MailShare.getOriginalDimension().y, IGT_UIcommonFunc.ScaleX(27f), IGT_UIcommonFunc.ScaleY(25f)), 22f, Vector2.zero);
				pIgt_Lable.DrawLableFromCenter(new Rect(btn_MailShare.getOriginalDimension().x + adjX + num + IGT_UIcommonFunc.ScaleX(5f), btn_MailShare.getOriginalDimension().y - adjY + IGT_UIcommonFunc.ScaleY(19f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleY(22f)), "+" + IGT_Constants.nMailShareLife, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black, 24f, Vector2.zero);
			}
			pIgt_Textures.DrawTextureFromCenter(IGT_Constants._Button_Blue, new Rect(num + btn_MailShare.getOriginalDimension().x + IGT_UIcommonFunc.ScaleX(20f), btn_MailShare.getOriginalDimension().y + btn_MailShare.getOriginalDimension().height + IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleX(58f), IGT_UIcommonFunc.ScaleY(18f)), 0f, Vector2.zero);
			pIgt_Lable.DrawLableFromCenter(new Rect(num + btn_MailShare.getOriginalDimension().x + IGT_UIcommonFunc.ScaleX(20f), btn_MailShare.getOriginalDimension().y + btn_MailShare.getOriginalDimension().height + IGT_UIcommonFunc.ScaleY(9f), IGT_UIcommonFunc.ScaleX(2f), IGT_UIcommonFunc.ScaleY(22f)), IGT_Constants.mailText, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(7f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
			btn_SMSShare.setX(btn_SMSShare.getOriginalDimension().x + num);
			btn_SMSShare.Draw_Button();
			if (currentTimeSecs() - smsShareTime >= 86400 && !cansmsShare)
			{
				cansmsShare = true;
				IGT_Constants.smsText = "Get " + IGT_Constants.nSMSShareLife + "  Life";
			}
			if (cansmsShare)
			{
				pIgt_Textures.DrawTextureFromCenter(IGT_Constants._Life, new Rect(btn_SMSShare.getOriginalDimension().x + adjX + num, btn_SMSShare.getOriginalDimension().y, IGT_UIcommonFunc.ScaleX(27f), IGT_UIcommonFunc.ScaleY(25f)), 22f, Vector2.zero);
				pIgt_Lable.DrawLableFromCenter(new Rect(btn_SMSShare.getOriginalDimension().x + adjX + num + IGT_UIcommonFunc.ScaleX(5f), btn_SMSShare.getOriginalDimension().y - adjY + IGT_UIcommonFunc.ScaleY(19f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleY(22f)), "+" + IGT_Constants.nSMSShareLife, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black, 24f, Vector2.zero);
			}
			pIgt_Textures.DrawTextureFromCenter(IGT_Constants._Button_Blue, new Rect(num + btn_SMSShare.getOriginalDimension().x + IGT_UIcommonFunc.ScaleX(20f), btn_SMSShare.getOriginalDimension().y + btn_SMSShare.getOriginalDimension().height + IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleX(58f), IGT_UIcommonFunc.ScaleY(18f)), 0f, Vector2.zero);
			pIgt_Lable.DrawLableFromCenter(new Rect(num + btn_SMSShare.getOriginalDimension().x + IGT_UIcommonFunc.ScaleX(20f), btn_SMSShare.getOriginalDimension().y + btn_SMSShare.getOriginalDimension().height + IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleX(2f), IGT_UIcommonFunc.ScaleY(22f)), IGT_Constants.smsText, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(7f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
			btn_Twitter.setX(btn_Twitter.getOriginalDimension().x + num);
			btn_Twitter.Draw_Button();
			if (currentTimeSecs() - twitterShareTime >= 86400 && !cantwitterShare)
			{
				cantwitterShare = true;
				IGT_Constants.twitterText = "Get " + IGT_Constants.nTwitterShareLife + "  Life";
			}
			if (cantwitterShare)
			{
				pIgt_Textures.DrawTextureFromCenter(IGT_Constants._Life, new Rect(btn_Twitter.getOriginalDimension().x + adjX + num, btn_Twitter.getOriginalDimension().y, IGT_UIcommonFunc.ScaleX(27f), IGT_UIcommonFunc.ScaleY(25f)), 22f, Vector2.zero);
				pIgt_Lable.DrawLableFromCenter(new Rect(btn_Twitter.getOriginalDimension().x + adjX + num + IGT_UIcommonFunc.ScaleX(5f), btn_Twitter.getOriginalDimension().y - adjY + IGT_UIcommonFunc.ScaleY(19f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleY(22f)), "+" + IGT_Constants.nTwitterShareLife, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black, 24f, Vector2.zero);
			}
			pIgt_Textures.DrawTextureFromCenter(IGT_Constants._Button_Blue, new Rect(num + btn_Twitter.getOriginalDimension().x + IGT_UIcommonFunc.ScaleX(20f), btn_Twitter.getOriginalDimension().y + btn_Twitter.getOriginalDimension().height + IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleX(58f), IGT_UIcommonFunc.ScaleY(18f)), 0f, Vector2.zero);
			pIgt_Lable.DrawLableFromCenter(new Rect(num + btn_Twitter.getOriginalDimension().x + IGT_UIcommonFunc.ScaleX(20f), btn_Twitter.getOriginalDimension().y + btn_Twitter.getOriginalDimension().height + IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleX(2f), IGT_UIcommonFunc.ScaleY(22f)), IGT_Constants.twitterText, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(7f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
			if (currentTimeSecs() - instaShareTime >= 86400 && !caninstaShare)
			{
				caninstaShare = true;
				IGT_Constants.instaText = "Get " + IGT_Constants.nInstaShareLife + "  Life";
			}
		}
		drawAllShareCheckingAlert();
	}

	public static void setScreenMode(int screenIDx)
	{
		nBeforePrevScreenMode = nPrevScreenMode;
		nPrevScreenMode = nScreenMode;
		nScreenMode = screenIDx;
		if (!pHero.bRemoveAds && nScreenMode == 0 && !bIsShowGPluseLoginAlert && !bInappAlert && CanIgnoreAdOnFirstInstall())
		{
			pAds.ShowInterstitial();
		}
		reSetAnimationsInCurScreen(screenIDx);
		if (nPrevScreenMode == 2 && (nScreenMode == 9 || nScreenMode == 0))
		{
			pHero.MusicAudioSelector();
			pHero.InvokeRepeating("StopMusicWithFadeAndPlayAnother", 0f, 0.1f);
		}
		else if (nPrevScreenMode == 20 && nScreenMode == 1)
		{
			pHero.MusicAudioSelector();
			pHero.InvokeRepeating("StopMusicWithFadeAndPlayAnother", 0f, 0.1f);
		}
		else if (nScreenMode == 10 || nScreenMode == 5)
		{
			pHero.InvokeRepeating("StopMusicWithFadeAndPlayAfterDelay", 0f, 0.1f);
		}
		else if (nPrevScreenMode == 10 || nPrevScreenMode == 5)
		{
			pHero._AudioSource2.Stop();
		}
		else if (nPrevScreenMode == 7 && nScreenMode == 9)
		{
			pHero.MusicAudioSelector();
			pHero.InvokeRepeating("StopMusicWithFadeAndPlayAnother", 0f, 0.1f);
		}
		if (nScreenMode != 9)
		{
			Camera.main.rect = new Rect(0f, 0f, 1f, 1f);
		}
		if (!pHero.b30FpsMode && (nScreenMode == 1 || nScreenMode == 21 || nScreenMode == 20 || nScreenMode == 9))
		{
			Application.targetFrameRate = 60;
		}
		else
		{
			Application.targetFrameRate = pHero.nTargetFrameRate;
		}
		if (nScreenMode == 5 || nScreenMode == 10)
		{
			pHero.FpsBased3dModelUsage_Calc();
		}
	}

	private static void reSetAnimationsInCurScreen(int screenID)
	{
		pOnGUI_3dObj_Camera.SetActive(false);
		for (int i = 0; i < pOnGui_3dObj_Hero.Length; i++)
		{
			pOnGui_3dObj_Hero[i].SetActive(false);
		}
		if (heroSelection_onGUICam != null)
		{
			heroSelection_onGUICam.SetActive(false);
		}
		if (characters_List != null)
		{
			for (int j = 0; j < characters_List.Length; j++)
			{
				characters_List[j].SetActive(false);
			}
		}
		if (nGetCurrentPlatform() == 0)
		{
			Screen.fullScreen = true;
		}
		switch (screenID)
		{
		case 1:
			But_Gamescreen_Pause.ResetAnimationDatas();
			if (pHero._AudioSource2.isPlaying)
			{
				pHero._AudioSource2.Stop();
			}
			pRateit.setCloseButEvents(false);
			break;
		case 5:
			pAnim_HS_menuBG.resetAllValues();
			But_GameoverscreenHome.ResetAnimationDatas();
			But_GameoverscreenRestart.ResetAnimationDatas();
			But_MissonCompleted_Next.ResetAnimationDatas();
			But_MissonCompleted_Retry.ResetAnimationDatas();
			But_MissonCompleted_Home.ResetAnimationDatas();
			pAnim_MissionCompleted_star1.resetAllValues();
			nCurBustedFaceIdx = 0;
			if (is3dObjNeeded)
			{
				pOnGUI_3dObj_Camera.SetActive(true);
				pOnGui_3dObj_Hero[pHero.nHeroIndex].SetActive(true);
				pOnGui_3dObj_Hero[pHero.nHeroIndex].GetComponent<Animator>().speed = 1f;
				if (pHero.nGameMode == 0 && pHero.nAIPlayerIndex == 9)
				{
					pOnGui_3dObj_Hero[pHero.nHeroIndex].GetComponent<Animator>().SetBool("Isgameover", false);
				}
				else
				{
					pOnGui_3dObj_Hero[pHero.nHeroIndex].GetComponent<Animator>().SetBool("Isgameover", true);
				}
			}
			if (pHero.nGameMode == 0)
			{
				pHero.nChaseNewBadge = 1;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_chaseNewBadge, pHero.nChaseNewBadge);
				IGT_Preference.getInstance()._SaveAll();
			}
			if (pHero.nGameMode == 1 && pHero.pMissionData != null && pHero.nMissionID + 1 >= pMapObj.getUnlockedLevel() && pHero.pMissionData.nRetryCount >= 4)
			{
				bSkipButEnable = true;
			}
			else
			{
				bSkipButEnable = false;
			}
			break;
		case 16:
			But_NotEnoughKeys_Close.ResetAnimationDatas();
			But_NotEnoughKeys_Purchase2.ResetAnimationDatas();
			But_NotEnoughKeys_Purchase1.ResetAnimationDatas();
			But_NotEnoughKeys_Purchase3.ResetAnimationDatas();
			break;
		case 0:
			But_HS_LeaderBoard.ResetAnimationDatas();
			But_HS_Settings.ResetAnimationDatas();
			But_HS_MailBox.ResetAnimationDatas();
			But_HS_SendLife.ResetAnimationDatas();
			But_HS_Life.ResetAnimationDatas();
			But_HS_Acheivement.ResetAnimationDatas();
			But_HS_AllShare.ResetAnimationDatas();
			But_HS_MoreGames.ResetAnimationDatas();
			But_HS_FreeLife.ResetAnimationDatas();
			But_HS_Shop.ResetAnimationDatas();
			But_HS_FConnect.ResetAnimationDatas();
			But_HS_Menu.ResetAnimationDatas();
			But_HS_Missions.ResetAnimationDatas();
			But_HS_Chase.ResetAnimationDatas();
			if (!pFacebook.isFBLoginSucess())
			{
				But_HS_FConnect.changeButtonTexture(pIgt_Textures.GetTexture(IGT_Constants._FConnect));
			}
			else
			{
				But_HS_FConnect.changeButtonTexture(pIgt_Textures.GetTexture(IGT_Constants.fbInvite));
			}
			pAnim_HS_menuBG.resetAllValues();
			pAnim_HS_menudwn.resetAllValues();
			bChaseLockedAlert = false;
			pAnim_MailBox.resetAllValues();
			But_Menu_GoogleLB.ResetAnimationDatas();
			But_Menu_FBLB.ResetAnimationDatas();
			But_Menu_LeaderBoard.ResetAnimationDatas();
			fNewBadgeAnimStrtTime = Time.time;
			bNewBadgeIsInAnim = false;
			if (Time.time - fGcCollectStrtTime > 50f)
			{
				fGcCollectStrtTime = Time.time;
				Resources.UnloadUnusedAssets();
			}
			if (pHero.bFpsBased3dModelUsage_FirstTime)
			{
				pHero.fTimeForFpsBased3dModelUsage = Time.time;
				pHero.nDispFrames_3dModelUsage = 0;
				pHero.nTargetFrameRate = 60;
			}
			fChaseNewTap_StrtTime = Time.time;
			break;
		case 3:
			But_Survive_UseKey.ResetAnimationDatas();
			But_Survive_Watchvideo.ResetAnimationDatas();
			pAnim_HS_menuBG.resetAllValues();
			bSuriviveRewardedVideoAvailable = pAds.isRewardBasedVideoAvailable();
			if (bRewardedVideoTimeUp && !pAds.isRewardBasedVideoAvailable())
			{
				pAds.RequestRewardBasedVideo();
			}
			break;
		case 2:
			But_Pause_Boost.ResetAnimationDatas();
			But_Pause_Back.ResetAnimationDatas();
			But_Pause_Resume.ResetAnimationDatas();
			pAnim_HS_menuBG.resetAllValues();
			break;
		case 8:
			pAnim_HS_menuBG.resetAllValues();
			break;
		case 10:
			But_MissonCompleted_Retry.ResetAnimationDatas();
			But_MissonCompleted_Next.ResetAnimationDatas();
			But_MissonCompleted_Home.ResetAnimationDatas();
			pAnim_MissionCompleted_star1.resetAllValues();
			pAnim_HS_menuBG.resetAllValues();
			if (is3dObjNeeded)
			{
				pOnGUI_3dObj_Camera.SetActive(true);
				pOnGui_3dObj_Hero[pHero.nHeroIndex].SetActive(true);
				pOnGui_3dObj_Hero[pHero.nHeroIndex].GetComponent<Animator>().SetBool("Isgameover", false);
				pOnGui_3dObj_Hero[pHero.nHeroIndex].GetComponent<Animator>().speed = 1f;
			}
			break;
		case 9:
			But_Mapback.ResetAnimationDatas();
			loadMapButtons();
			pHero.player.transform.position = new Vector3(-100f, -100f, -100f);
			if (pHero.isAIplayerAvailable && IGT_AIPlayer.AI_Player != null)
			{
				IGT_AIPlayer.AI_Player.transform.position = new Vector3(-100f, -100f, -100f);
			}
			if (pHero.Heroine.transform != null)
			{
				pHero.Heroine.transform.position = new Vector3(-100f, -100f, -100f);
			}
			break;
		case 12:
		{
			But_Menu_back.ResetAnimationDatas();
			But_Menu_Shop.ResetAnimationDatas();
			But_Menu_LeaderBoard.ResetAnimationDatas();
			But_Menu_Achievement.ResetAnimationDatas();
			But_Menu_Free.ResetAnimationDatas();
			But_Menu_Share.ResetAnimationDatas();
			But_Menu_Settings.ResetAnimationDatas();
			But_Menu_MoreGames.ResetAnimationDatas();
			But_Menu_About.ResetAnimationDatas();
			heroSelection_onGUICam.SetActive(true);
			for (int k = 0; k < 5; k++)
			{
				characters_List[k].SetActive(true);
			}
			pAnim_coinsBG.resetAllValues();
			But_Menu_GoogleLB.ResetAnimationDatas();
			But_Menu_FBLB.ResetAnimationDatas();
			break;
		}
		case 21:
			if (pHero._AudioSource2.isPlaying)
			{
				pHero._AudioSource2.Stop();
			}
			pAnim_MissionCompleted_star3.resetAllValues();
			break;
		case 6:
			if (nGetCurrentPlatform() == 0)
			{
				Screen.fullScreen = false;
			}
			bBoostUpgradeAnim = false;
			break;
		case 4:
			pHero.nChaseNewBadge = 1;
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_chaseNewBadge, pHero.nChaseNewBadge);
			IGT_Preference.getInstance()._SaveAll();
			break;
		}
		bCanShowAdd = true;
		if (!pHero.bRemoveAds && (nScreenMode == 9 || nScreenMode == 12) && CanIgnoreAdOnFirstInstall())
		{
			pAds.ShowInterstitial();
		}
	}

	public static bool CanIgnoreAdOnFirstInstall()
	{
		bool flag = true;
		if (IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_AdsIgonreFirstInstall, 1) == 1)
		{
			return true;
		}
		if ((float)currentTimeSecs() - IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_AdsIgonreFirstInstall_StrtTime, (float)currentTimeSecs()) < 300f)
		{
			return false;
		}
		IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_AdsIgonreFirstInstall, 1);
		return true;
	}

	public static int nGetCurrentPlatform()
	{
		int num = 3;
		return 0;
	}

	private void drawAbout()
	{
		float num = Time.deltaTime * 12f + 0.6f;
		if (!bTouchEnabled)
		{
			fAbtTexY -= num;
		}
		if (fAbtTexY < -532f)
		{
			fAbtTexY = 440f;
		}
		if (fAbtTexY > 500f)
		{
			fAbtTexY = -532f;
		}
		Vector2 zero = Vector2.zero;
		zero = GUI.BeginScrollView(new Rect(rectAboutBG.x + IGT_UIcommonFunc.ScaleX(20f), rectAboutBG.y + IGT_UIcommonFunc.ScaleY(15f), rectAboutBG.width, rectAboutBG.height - IGT_UIcommonFunc.ScaleY(30f)), zero, default(Rect));
		pIgt_Textures.DrawTexture(IGT_Constants.aboutTxt, rectAboutBG.x - IGT_UIcommonFunc.ScaleX(28f), IGT_UIcommonFunc.ScaleY(fAbtTexY), rectAboutBG.width, rectAboutBG.height + IGT_UIcommonFunc.ScaleY(100f));
		GUI.EndScrollView();
	}

	private void checkUpdatePos(Vector2 _touchPos)
	{
		if (prevTouchPos.y < _touchPos.y)
		{
			fAbtTexY -= 5f;
		}
		else if (prevTouchPos.y > _touchPos.y)
		{
			fAbtTexY += 5f;
		}
	}

	private void MissionInfoScreenAnimation()
	{
		pIgt_Textures.DrawTexture(IGT_Constants._countDown_Bg, new Rect(IGT_UIcommonFunc.ScaleX(0f), IGT_UIcommonFunc.ScaleY(0f), IGT_UIcommonFunc.ScaleX(320f), IGT_UIcommonFunc.ScaleY(480f)), false);
		float num = 0f;
		num = (pAnim_menu_LeaderBoard.getIsReverse() ? pAnim_menu_LeaderBoard.easeFunctions(0f - rect_MissionPopup.height, IGT_UIcommonFunc.ScaleY(240f) - rect_MissionPopup.height * 0.5f, 1f, 28) : pAnim_menu_LeaderBoard.easeFunctions(0f, IGT_UIcommonFunc.ScaleY(240f) - rect_MissionPopup.height * 0.5f, 1.5f, 29));
		if (pAnim_menu_LeaderBoard.isAnimFinished() && pAnim_menu_LeaderBoard.getIsReverse())
		{
			if (pHero.nMissionID < pHero.nTutorialLevelCount - 1)
			{
				nArrowAnimType = -1;
				setScreenMode(21);
				IGT_Hero.bMissionIntro = true;
			}
			else
			{
				setScreenMode(1);
				if (pHero.pMissionData.nMissionType == 4)
				{
					bBringBackAlert = true;
					bBringBackAlert_Alpha = false;
					fBringBack_Alert_StrtTime = Time.time;
					sBringBackAlertText = "Going for it...";
					sBringBackDemoText = "See Map to locate the item";
					fBringBack_Alert_Alpha_StartTime = Time.time;
				}
			}
			if (IGT_Hero.bRobbingSceneFinished)
			{
				IGT_Hero.bMissionIntro = true;
				IGT_AnimStatesCntrler.HeroAnimator.Play("IdleToRun", 0, 0.35f);
				pAnim_MissionCompleted_star1.resetAllValues();
				IGT_AnimStatesCntrler.nHeroAnimState = 1;
				if (pHero.isAIplayerAvailable)
				{
					IGT_AIPlayer.pAIPlayerAnimController.nHeroAnimState = 1;
				}
			}
			pHero.MusicAudioSelector();
			pHero.InvokeRepeating("StopMusicWithFadeAndPlayAnother", 0f, 0.1f);
			pHero.dMissionStrtTime = Time.time - 1f;
		}
		else
		{
			pIgt_Textures.DrawTexture(IGT_Constants._PopupInfoBG, rect_MissionPopup.x, num - IGT_UIcommonFunc.ScaleY(7f), rect_MissionPopup.width, rect_MissionPopup.height * 1.2f);
			if (pMissionInfo_TextureName == "Null")
			{
				if (pHero.pMissionData.nMissionType == 3)
				{
					pIgt_Lable.DrawLable(new Rect(rect_MissionPopup.x, num + IGT_UIcommonFunc.ScaleY(10f), rect_MissionPopup.width, rect_MissionPopup.height), MissionInfo, IGT_Constants.Font_TitanOne, fontSize_missionPopupInfo, TextAnchor.UpperCenter, true, Color.white, Vector2.one * 2f, Color.black);
					pIgt_Lable.DrawLable(new Rect(rect_MissionPopup.x, num + IGT_UIcommonFunc.ScaleY(12f), rect_MissionPopup.width, rect_MissionPopup.height), pHero.pMissionData.WordTobeFind, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(28f), TextAnchor.MiddleCenter, false, Color.yellow, 2f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
				}
				else if (pHero.nMissionID == 0)
				{
					pIgt_Textures.DrawTexture(IGT_Constants._GameIcon, adj_drawrect(new Rect(rect_MissionPopup.x, num, rect_MissionPopup.width, rect_MissionPopup.height), new Rect(rect_MissionPopup.x + IGT_UIcommonFunc.ScaleX(35f), num, IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(80f)), 0), true);
					pIgt_Lable.DrawLable(new Rect(rect_MissionPopup.x + IGT_UIcommonFunc.ScaleX(40f), num, rect_MissionPopup.width, rect_MissionPopup.height), MissionInfo, IGT_Constants.Font_TitanOne, fontSize_missionPopupInfo, TextAnchor.MiddleCenter, true, Color.white, Vector2.one * 2f, Color.black);
				}
				else
				{
					pIgt_Textures.DrawTexture(IGT_Constants.AIPlayer_FacePicx[pHero.nAIPlayerIndex], adj_drawrect(new Rect(rect_MissionPopup.x, num, rect_MissionPopup.width, rect_MissionPopup.height), new Rect(rect_MissionPopup.x + IGT_UIcommonFunc.ScaleX(35f), num, IGT_UIcommonFunc.ScaleX(64f), IGT_UIcommonFunc.ScaleX(64f)), 0), false);
					pIgt_Lable.DrawLable(new Rect(rect_MissionPopup.x + IGT_UIcommonFunc.ScaleX(40f), num, rect_MissionPopup.width, rect_MissionPopup.height), MissionInfo, IGT_Constants.Font_TitanOne, fontSize_missionPopupInfo, TextAnchor.MiddleCenter, true, Color.white, Vector2.one * 2f, Color.black);
				}
			}
			else
			{
				pIgt_Lable.DrawLable(new Rect(rect_MissionPopup.x, num, rect_MissionPopup.width, rect_MissionPopup.height), MissionInfo, IGT_Constants.Font_TitanOne, fontSize_missionPopupInfo, TextAnchor.UpperCenter, true, Color.white, Vector2.one * 2f, Color.black);
				if (pHero.pMissionData.nMissionType == 5)
				{
					if (pHero.pMissionData.nNumOfMultipleCollection == 3)
					{
						pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(8f), num + IGT_UIcommonFunc.ScaleY(25f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(50f)), pHero.pMissionData.nMultipleCollectionDatas[0, 2].ToString(), IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(30f), Color.white, TextAnchor.MiddleCenter, false);
						pIgt_Lable.DrawLable(adj_drawrect(new Rect(IGT_UIcommonFunc.ScaleX(13.5f), num + IGT_UIcommonFunc.ScaleY(25f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(50f)), new Rect(IGT_UIcommonFunc.ScaleX(17f), num + IGT_UIcommonFunc.ScaleY(45f), IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(20f)), 0), "x", IGT_Constants.Font_Jellee_Roman, (int)IGT_UIcommonFunc.ScaleX(15f), Color.white, TextAnchor.MiddleCenter, false);
						pIgt_Textures.DrawTexture(IGT_Constants.collectionItemsImg[pHero.pMissionData.nMultipleCollectionDatas[0, 0]], adj_drawrect(new Rect(IGT_UIcommonFunc.ScaleX(35f), num + IGT_UIcommonFunc.ScaleY(25f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(50f)), new Rect(IGT_UIcommonFunc.ScaleX(64f), num + IGT_UIcommonFunc.ScaleY(25f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(50f)), 0), false);
						pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(110f), num + IGT_UIcommonFunc.ScaleY(25f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(50f)), pHero.pMissionData.nMultipleCollectionDatas[1, 2].ToString(), IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(30f), Color.white, TextAnchor.MiddleCenter, false);
						pIgt_Lable.DrawLable(adj_drawrect(new Rect(IGT_UIcommonFunc.ScaleX(110.5f), num + IGT_UIcommonFunc.ScaleY(25f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(50f)), new Rect(IGT_UIcommonFunc.ScaleX(120f), num + IGT_UIcommonFunc.ScaleY(45f), IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(20f)), 0), "x", IGT_Constants.Font_Jellee_Roman, (int)IGT_UIcommonFunc.ScaleX(15f), Color.white, TextAnchor.MiddleCenter, false);
						pIgt_Textures.DrawTexture(IGT_Constants.collectionItemsImg[pHero.pMissionData.nMultipleCollectionDatas[1, 0]], adj_drawrect(new Rect(IGT_UIcommonFunc.ScaleX(140f), num + IGT_UIcommonFunc.ScaleY(25f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(50f)), new Rect(IGT_UIcommonFunc.ScaleX(159.5f), num + IGT_UIcommonFunc.ScaleY(25f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(50f)), 0), false);
						pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(204f), num + IGT_UIcommonFunc.ScaleY(25f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(50f)), pHero.pMissionData.nMultipleCollectionDatas[2, 2].ToString(), IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(30f), Color.white, TextAnchor.MiddleCenter, false);
						pIgt_Lable.DrawLable(adj_drawrect(new Rect(IGT_UIcommonFunc.ScaleX(200.5f), num + IGT_UIcommonFunc.ScaleY(25f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(50f)), new Rect(IGT_UIcommonFunc.ScaleX(213f), num + IGT_UIcommonFunc.ScaleY(45f), IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(20f)), 0), "x", IGT_Constants.Font_Jellee_Roman, (int)IGT_UIcommonFunc.ScaleX(15f), Color.white, TextAnchor.MiddleCenter, false);
						pIgt_Textures.DrawTexture(IGT_Constants.collectionItemsImg[pHero.pMissionData.nMultipleCollectionDatas[2, 0]], adj_drawrect(new Rect(IGT_UIcommonFunc.ScaleX(250f), num + IGT_UIcommonFunc.ScaleY(25f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(50f)), new Rect(IGT_UIcommonFunc.ScaleX(258.5f), num + IGT_UIcommonFunc.ScaleY(25f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(50f)), 0), false);
					}
					else
					{
						pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(25f), num + IGT_UIcommonFunc.ScaleY(25f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(50f)), pHero.pMissionData.nMultipleCollectionDatas[0, 2].ToString(), IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(30f), Color.white, TextAnchor.MiddleCenter, false);
						pIgt_Lable.DrawLable(adj_drawrect(new Rect(IGT_UIcommonFunc.ScaleX(30f), num + IGT_UIcommonFunc.ScaleY(25f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(50f)), new Rect(IGT_UIcommonFunc.ScaleX(20f), num + IGT_UIcommonFunc.ScaleY(45f), IGT_UIcommonFunc.ScaleX(130f), IGT_UIcommonFunc.ScaleY(20f)), 0), "x", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(15f), Color.white, TextAnchor.MiddleCenter, false);
						pIgt_Textures.DrawTexture(IGT_Constants.collectionItemsImg[pHero.pMissionData.nMultipleCollectionDatas[0, 0]], adj_drawrect(new Rect(IGT_UIcommonFunc.ScaleX(25f), num + IGT_UIcommonFunc.ScaleY(25f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(50f)), new Rect(IGT_UIcommonFunc.ScaleX(90f), num + IGT_UIcommonFunc.ScaleY(25f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(50f)), 0), false);
						pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(175f), num + IGT_UIcommonFunc.ScaleY(25f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(50f)), pHero.pMissionData.nMultipleCollectionDatas[1, 2].ToString(), IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(30f), Color.white, TextAnchor.MiddleCenter, false);
						pIgt_Lable.DrawLable(adj_drawrect(new Rect(IGT_UIcommonFunc.ScaleX(180f), num + IGT_UIcommonFunc.ScaleY(25f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(50f)), new Rect(IGT_UIcommonFunc.ScaleX(170f), num + IGT_UIcommonFunc.ScaleY(45f), IGT_UIcommonFunc.ScaleX(130f), IGT_UIcommonFunc.ScaleY(20f)), 0), "x", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(15f), Color.white, TextAnchor.MiddleCenter, false);
						pIgt_Textures.DrawTexture(IGT_Constants.collectionItemsImg[pHero.pMissionData.nMultipleCollectionDatas[1, 0]], adj_drawrect(new Rect(IGT_UIcommonFunc.ScaleX(185f), num + IGT_UIcommonFunc.ScaleY(25f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(50f)), new Rect(IGT_UIcommonFunc.ScaleX(245f), num + IGT_UIcommonFunc.ScaleY(25f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(50f)), 0), false);
					}
				}
				else if (pHero.pMissionData.nMissionType != 4)
				{
					float num2 = IGT_UIcommonFunc.ScaleX(100f);
					num2 = ((pHero.pMissionData.nTargetCount.ToString().Length == 1) ? IGT_UIcommonFunc.ScaleX(100f) : ((pHero.pMissionData.nTargetCount.ToString().Length != 2) ? IGT_UIcommonFunc.ScaleX(90f) : IGT_UIcommonFunc.ScaleX(95f)));
					pIgt_Lable.DrawLable(new Rect(num2, num + IGT_UIcommonFunc.ScaleY(25f), IGT_UIcommonFunc.ScaleX(60f), IGT_UIcommonFunc.ScaleY(50f)), pHero.pMissionData.nTargetCount.ToString(), IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(30f), TextAnchor.MiddleCenter, false, Color.white, Vector2.one * 2f, Color.black);
					pIgt_Lable.DrawLable(adj_drawrect(new Rect(num2, num + IGT_UIcommonFunc.ScaleY(25f), IGT_UIcommonFunc.ScaleX(60f), IGT_UIcommonFunc.ScaleY(50f)), new Rect(IGT_UIcommonFunc.ScaleX(160f) - IGT_UIcommonFunc.ScaleX(20f) / 2f, num + IGT_UIcommonFunc.ScaleY(55f), IGT_UIcommonFunc.ScaleX(20f), IGT_UIcommonFunc.ScaleY(20f)), 0), "x", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, false, Color.white, Vector2.one * 2f, Color.black);
					pIgt_Textures.DrawTexture(pMissionInfo_TextureName, adj_drawrect(new Rect(num2, num + IGT_UIcommonFunc.ScaleY(25f), IGT_UIcommonFunc.ScaleX(60f), IGT_UIcommonFunc.ScaleY(50f)), new Rect(IGT_UIcommonFunc.ScaleX(150f) + IGT_UIcommonFunc.ScaleX(25f), num + IGT_UIcommonFunc.ScaleY(25f), IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleX(40f)), 0), false);
				}
				else
				{
					pIgt_Textures.DrawTexture(pMissionInfo_TextureName, new Rect(IGT_UIcommonFunc.ScaleX(160f) - IGT_UIcommonFunc.ScaleX(50f) / 2f, num + IGT_UIcommonFunc.ScaleY(25f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(50f)), true);
				}
			}
		}
		if (!pAnim_menu_LeaderBoard.isAnimFinished() || !(num > 0f))
		{
			return;
		}
		pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(125f), IGT_UIcommonFunc.ScaleY(375f), IGT_UIcommonFunc.ScaleX(75f), IGT_UIcommonFunc.ScaleY(30f)), "Tap to Continue...", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(18f), Color.white, TextAnchor.MiddleCenter, false);
		if (!bShowMissionTapToContinue)
		{
			bShowMissionTapToContinue = true;
			fMissionInfoTapToContinue_StartTime = Time.time;
		}
		if (Time.time - fMissionInfoTapToContinue_StartTime > 5f && Time.time - fMissionInfoTapToContinue_StartTime <= 6f)
		{
			pIGT_Sprites_MissionInfoTap.draw();
			if (pIGT_Sprites_MissionInfoTap.getFramNumber() == 2)
			{
				pIgt_Textures.DrawTexture(IGT_Constants._CountDown_Glow, new Rect(IGT_UIcommonFunc.ScaleX(180f), IGT_UIcommonFunc.ScaleY(285f), IGT_UIcommonFunc.ScaleX(60f), IGT_UIcommonFunc.ScaleY(60f)), false);
			}
		}
	}

	private void AppRequestSucess(int _actiontype)
	{
	}

	private void AppRequestFailed(int _actiontype)
	{
	}

	private static void ProcessAppRequestComplete()
	{
		processAppReqDataHandling();
	}

	public static void processAppReqDataHandling()
	{
		if (!pFacebook.isFBLoginSucess() || bProcessDeleteAppReqCall)
		{
			return;
		}
		listAskSend.Clear();
		dictAskReqID = pFacebook.getDictAskReqID();
		foreach (KeyValuePair<string, string> item in dictAskReqID)
		{
			MailBoxAskSendInfo mailBoxAskSendInfo = new MailBoxAskSendInfo();
			mailBoxAskSendInfo.userID = item.Key;
			mailBoxAskSendInfo.msg = "Asked a life";
			mailBoxAskSendInfo.bCheckbox = false;
			listAskSend.Add(mailBoxAskSendInfo);
		}
		dictSendReqID = pFacebook.getDictSendReqID();
		foreach (KeyValuePair<string, string> item2 in dictSendReqID)
		{
			MailBoxAskSendInfo mailBoxAskSendInfo2 = new MailBoxAskSendInfo();
			mailBoxAskSendInfo2.userID = item2.Key;
			mailBoxAskSendInfo2.msg = "Sent a life";
			mailBoxAskSendInfo2.bCheckbox = false;
			listAskSend.Add(mailBoxAskSendInfo2);
		}
	}

	public void OnButtonClick(IGT_Button button)
	{
		switch (button.getID())
		{
		case 45:
			homeScreenButtonEvents();
			break;
		case 44:
			if (canPlayGameUsingLife() || (pHero.nGameMode == 0 && pHero.nChaseTotAttemps < 5) || (pHero.nGameMode == 1 && pHero.nMissionID < 5))
			{
				if (pHero.nGameMode == 0)
				{
					pHero.Chase_RobbScene_DataSel();
					Chase_ButtonEvents();
				}
				else if (pHero.nGameMode == 1)
				{
					pHero.bRestart = true;
					mission_ButtonEvents(pHero.nMissionID);
				}
			}
			else
			{
				NoMoLiveAlertScreen();
			}
			break;
		case 0:
			if (pHero.nTutorial == 1)
			{
				if (canPlayGameUsingLife() || pHero.nChaseTotAttemps < 5)
				{
					Chase_ButtonEvents();
				}
				else
				{
					NoMoLiveAlertScreen();
				}
			}
			else
			{
				bChaseLockedAlert = true;
				fChaseLockAlert_StartTime = Time.time;
			}
			break;
		case 98:
			nickNameOkEvent();
			break;
		case 1:
			if (IGT_Preference.getInstance()._Get(kNickNameAvailable, 0) == 0 && !PlayerPrefs.HasKey(kGetNickName))
			{
				bShowNickName = true;
				bDefaultNickNameText = false;
				pAnim_MailBox.resetAllValues();
			}
			else
			{
				pHero.nGameMode = 1;
				setScreenMode(9);
			}
			break;
		case 15:
			nPurchaseType = 0;
			bScrollAnim = true;
			fScrollAnimTime = 0f;
			purchaseWindow_ScrollviwRectMaxY = purchaseWindow_BarStrtPosY;
			purchaseWindow_ScrollviewRectMinY = ScrollViewRect_purchaseWindow.y + ScrollViewRect_purchaseWindow.height - (float)pHero.pPurchaseItemsData_Store.Count * (purchaseWindow_BarHeight + purchaseWindow_BarGap) - (ScrollViewRect_purchaseWindow.y + purchaseWindow_BarStrtPosY);
			setScreenMode(6);
			break;
		case 14:
			if (pHero.isConnectedInternet())
			{
				if (!pFacebook.isFBLoginSucess())
				{
					pFacebook.FBLogin(FBLoginCompleted, FBLoginFailed);
				}
				else if (pFacebook.HaveFrndListPermission)
				{
					pFacebook.FBInvite(fbAppInviteUri, AppInviteSucess, AppInviteFailed);
				}
				else
				{
					bInviteReLogin = true;
					pFacebook.FBLogin(FBLoginCompleted, FBLoginFailed);
				}
				pHero.bCanShowAdOnForeGround = false;
			}
			else
			{
				setNoInternetAlert();
			}
			break;
		case 16:
		{
			centre_character = selected_character;
			for (int j = 0; j < 5; j++)
			{
				characters_List[j].transform.localScale = new Vector3(1.085f, 1.085f, 1.085f);
			}
			bLeaderBoardbtnClick = false;
			setScreenMode(12);
			break;
		}
		case 11:
			if (pLeaderBoard == null)
			{
				pLeaderBoard = new IGT_LeaderboardAchievements();
			}
			if (pLeaderBoard.isLogInSucess())
			{
				pLeaderBoard.OnShowAchievements();
			}
			else if (pHero.isConnectedInternet())
			{
				pHero.bCanShowAdOnForeGround = false;
				pLeaderBoard.LeaderAchivLogin();
				pLeaderBoard.OnShowAchievements();
			}
			else
			{
				setNoInternetAlert();
			}
			break;
		case 12:
			MoreGamesButtonEvents();
			break;
		case 13:
			setScreenMode(6);
			if (nPurchaseType != 3)
			{
				nPurchaseType = 3;
				bScrollAnim = true;
				fScrollAnimTime = 0f;
				purchaseWindow_ScrollviwRectMaxY = purchaseWindow_BarStrtPosY;
				purchaseWindow_ScrollviewRectMinY = ScrollViewRect_purchaseWindow.y + ScrollViewRect_purchaseWindow.height - (float)pHero.pPurchaseItemsData_Free.Count * (purchaseWindow_BarHeight + purchaseWindow_BarGap) - (ScrollViewRect_purchaseWindow.y + purchaseWindow_BarStrtPosY);
			}
			pHero.post_Analytics_Screen_Button_Datas("HomeScreen", "FreeLives");
			break;
		case 2:
			bleaderboardHSbtnClick = true;
			bLBwronganim = false;
			pAnim_HS_LeaderBoard.resetAllValues();
			But_HS_GoogleLB.ResetAnimationDatas();
			But_HS_FBLB.ResetAnimationDatas();
			pHero.post_Analytics_Screen_Button_Datas("HomeScreen", "LeaderBoard");
			break;
		case 3:
			bleaderboardHSbtnClick = false;
			bLeaderBoardbtnClick = false;
			if (pLeaderBoard == null)
			{
				pLeaderBoard = new IGT_LeaderboardAchievements();
			}
			if (pLeaderBoard.isLogInSucess())
			{
				pLeaderBoard.OnShowLeaderBoard();
			}
			else if (pHero.isConnectedInternet())
			{
				pHero.bCanShowAdOnForeGround = false;
				pLeaderBoard.LeaderAchivLogin();
				pLeaderBoard.OnShowLeaderBoard();
			}
			else
			{
				setNoInternetAlert();
			}
			break;
		case 4:
			bHS_FBbtnClick = true;
			bleaderboardHSbtnClick = false;
			bFBbtnClick = true;
			bLeaderBoardbtnClick = false;
			if (!bFB_MsnEnablebtnClick)
			{
				nGameoverScrollType = 0;
				bFBLBglobal = false;
			}
			else
			{
				nMC_ScrollType = 1;
				bFBLBglobal = true;
			}
			getScoreFromInternet(2);
			break;
		case 5:
			bHS_settings = true;
			But_settingsClose.ResetAnimationDatas();
			But_Settings_Music.ResetAnimationDatas();
			But_Settings_Sound.ResetAnimationDatas();
			But_settings_Notification.ResetAnimationDatas();
			But_Settings_RestorePurchase.ResetAnimationDatas();
			But_Settings_FBLogout.ResetAnimationDatas();
			pAnim_HS_menuBG.resetAllValues();
			break;
		case 99:
			bShowNickName = true;
			pAnim_MailBox.resetAllValues();
			if (strNickName.Length > 0)
			{
				bDefaultNickNameText = true;
			}
			break;
		case 59:
			bShowMissionTapToContinue = false;
			pAnim_menu_LeaderBoard.resetAllValues();
			pAnim_menu_LeaderBoard.setIsReverse(true);
			if (pHero.nGameMode == 1 && pHero.nMissionID == 13)
			{
				bBringBackDemoTapToContinueAlert = false;
				freezeGame(false);
			}
			break;
		case 7:
			nPurchaseType = 0;
			bScrollAnim = true;
			fScrollAnimTime = 0f;
			purchaseWindow_ScrollviwRectMaxY = purchaseWindow_BarStrtPosY;
			purchaseWindow_ScrollviewRectMinY = ScrollViewRect_purchaseWindow.y + ScrollViewRect_purchaseWindow.height - (float)pHero.pPurchaseItemsData_Store.Count * (purchaseWindow_BarHeight + purchaseWindow_BarGap) - (ScrollViewRect_purchaseWindow.y + purchaseWindow_BarStrtPosY);
			setScreenMode(6);
			pHero.post_Analytics_Screen_Button_Datas("HomeScreen", "AddCoin");
			break;
		case 8:
			setScreenMode(6);
			nPurchaseType = 0;
			bScrollAnim = true;
			fScrollAnimTime = 0f;
			purchaseWindow_ScrollviwRectMaxY = purchaseWindow_BarStrtPosY - 5f * (purchaseWindow_BarHeight + purchaseWindow_BarGap);
			purchaseWindow_ScrollviewRectMinY = ScrollViewRect_purchaseWindow.y + ScrollViewRect_purchaseWindow.height - (float)pHero.pPurchaseItemsData_Store.Count * (purchaseWindow_BarHeight + purchaseWindow_BarGap) - (ScrollViewRect_purchaseWindow.y + purchaseWindow_BarStrtPosY);
			pHero.post_Analytics_Screen_Button_Datas("HomeScreen", "AddKey");
			break;
		case 6:
			NoMoLiveAlertScreen();
			pHero.post_Analytics_Screen_Button_Datas("HomeScreen", "AddLife");
			break;
		case 123:
			if (pHero.isConnectedInternet())
			{
				pFacebook.FBLogin(FBLoginCompleted, FBLoginFailed);
				pHero.bCanShowAdOnForeGround = false;
				if (nScreenMode == 0 || nScreenMode == 12 || nScreenMode == 5 || nScreenMode == 10)
				{
					nLeaderBoard_Chase_DispState = (nLeaderBoard_Mission_DispState = 0);
					fLoadingStrtTime = Time.time;
				}
			}
			else
			{
				setNoInternetAlert();
			}
			pHero.post_Analytics_Screen_Button_Datas("HomeScreen", "FConnect");
			break;
		case 9:
			refreshFBListIfneeded();
			if (pHero.isConnectedInternet())
			{
				if (!pFacebook.isFBLoginSucess())
				{
					bHS_mailbox = true;
					pAnim_MailBox.resetAllValues();
					dMailBoxisProcessing = false;
					dMailBoxProcessedCount = 0;
					dMailBoxSentCount = 0;
				}
				else if (!dMailBoxisProcessing)
				{
					But_Mail_Accept.setEnable(false);
					bHS_mailbox = true;
					pAnim_MailBox.resetAllValues();
					if (pFacebook.isFBLoginSucess() && !bProcessDeleteAppReqCall)
					{
						pFacebook.ProcessAppRequest(ProcessAppRequestComplete);
					}
					if (!bScrollAnim && listAskSend != null)
					{
						MailBoxScroll_CurPos.y = IGT_UIcommonFunc.ScaleY(0f);
						int count = listAskSend.Count;
						if (count > 4)
						{
							bScrollAnim = true;
							fScrollAnimTime = 0f;
							MailBoxScroll_ScrollviwRectMaxY = MailBoxScroll_BarStrtPosY;
							MailBoxScroll_ScrollviewRectMinY = ScrollViewRect_MailBoxScroll.y + ScrollViewRect_MailBoxScroll.height - (float)count * (MailBoxScroll_BarHeight + MailBoxScroll_BarGap) - (ScrollViewRect_MailBoxScroll.y + MailBoxScroll_BarStrtPosY);
						}
					}
				}
				else
				{
					Start_Toast("Processing...");
				}
			}
			else
			{
				setNoInternetAlert();
			}
			break;
		case 10:
			refreshFBListIfneeded();
			if (pHero.isConnectedInternet())
			{
				But_SendLife_Accept.setEnable(false);
				bHS_sendlife = true;
				pAnim_MailBox.resetAllValues();
				if (pFacebook.isFBLoginSucess())
				{
					listSendLife.Clear();
					foreach (KeyValuePair<string, FBFriendInfoList> fb in fbList)
					{
						if (!fb.Value.userName.Equals("Me"))
						{
							MailBoxAskSendInfo mailBoxAskSendInfo2 = new MailBoxAskSendInfo();
							mailBoxAskSendInfo2.userID = fb.Key;
							mailBoxAskSendInfo2.bCheckbox = false;
							listSendLife.Add(mailBoxAskSendInfo2);
						}
					}
				}
				if (bHS_sendlife && listSendLife != null)
				{
					SendLifeScroll_CurPos.y = IGT_UIcommonFunc.ScaleY(0f);
					int num6 = fbList.Count - 1;
					if (num6 > 4)
					{
						bScrollAnim = true;
						fScrollAnimTime = 0f;
						SendLifeScroll_ScrollviwRectMaxY = SendLifeScroll_BarStrtPosY;
						SendLifeScroll_ScrollviewRectMinY = ScrollViewRect_SendLifeScroll.y + ScrollViewRect_SendLifeScroll.height - (float)num6 * (SendLifeScroll_BarHeight + SendLifeScroll_BarGap) - (ScrollViewRect_SendLifeScroll.y + SendLifeScroll_BarStrtPosY);
					}
				}
			}
			else
			{
				setNoInternetAlert();
			}
			break;
		case 17:
			settingCloseButEvents();
			break;
		case 18:
			if (pHero.nMusic == 0)
			{
				pHero.nMusic = 1;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_Music, 1);
				pHero.InvokeRepeating("StopMusicWithFade", 0f, 0.1f);
			}
			else
			{
				pHero.nMusic = 0;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_Music, 0);
				pHero.MusicAudioSelector();
				pHero.InvokeRepeating("StopMusicWithFadeAndPlayAnother", 0f, 0.1f);
			}
			IGT_Preference.getInstance()._SaveAll();
			pHero.post_Analytics_Screen_Button_Datas("Settings", "Music");
			break;
		case 19:
			if (pHero.nSound == 0)
			{
				pHero.nSound = 1;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_Sound, 1);
			}
			else
			{
				pHero.nSound = 0;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_Sound, 0);
			}
			IGT_Preference.getInstance()._SaveAll();
			pHero.post_Analytics_Screen_Button_Datas("Settings", "Sound");
			break;
		case 21:
			if (pHero.nGameNotification == 0)
			{
				pHero.nGameNotification = 1;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_Notification, 1);
				IGT_AndroidLocalNotificationManager.getInstance().cancelAllNotification();
			}
			else
			{
				pHero.nGameNotification = 0;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_Notification, 0);
				IGT_AndroidLocalNotificationManager.getInstance().setGameNotification(3, 7, 14);
			}
			IGT_Preference.getInstance()._SaveAll();
			break;
		case 20:
			if (pHero.isConnectedInternet())
			{
				if (!pFacebook.isFBLoginSucess())
				{
					pHero.bCanShowAdOnForeGround = false;
					pFacebook.FBLogin(FBLoginCompleted, FBLoginFailed);
				}
				else
				{
					pFacebook.FBLogout(FBLogoutCompleted);
				}
			}
			else
			{
				setNoInternetAlert();
			}
			break;
		case 23:
			if (IGT_Constants.nTotKeysCount - IGT_Constants.nNoOfKeysToRevive >= 0)
			{
				UsekeyButEvent(true);
				break;
			}
			setScreenMode(16);
			pHero.post_Analytics_Popup("NotEnoughKeys");
			break;
		case 24:
			pHero.post_Analytics_Screen_Button_Datas("Survive", "WatchVideo");
			if (pHero.isConnectedInternet())
			{
				pAds.ShowRewardBasedVideo();
			}
			else
			{
				Start_Toast("No Internet Connection ");
			}
			break;
		case 25:
			setScreenMode(16);
			pHero.post_Analytics_Popup("NotEnoughKeys");
			break;
		case 26:
			if (pHero.nGameMode == 1 && pHero.nMissionID < pHero.nTutorialLevelCount)
			{
				setScreenMode(9);
				break;
			}
			if (pHero.nGameMode == 0 && pHero.nChaseTotAttemps < 5)
			{
				homeScreenButtonEvents();
				break;
			}
			bAbortAlert = true;
			But_Abort_Cancel.ResetAnimationDatas();
			But_Abort_Ok.ResetAnimationDatas();
			pAnim_MissionCompleted_star2.resetAllValues();
			pAnim_MissionCompleted_star3.resetAllValues();
			break;
		case 27:
			setScreenMode(6);
			nPurchaseType = 2;
			pHero.post_Analytics_Screen_Button_Datas("Pause", "Boost");
			break;
		case 28:
			ResumeButtonEvents();
			break;
		case 29:
			bAbortAlert = false;
			pHero.canDecrease_Life();
			if (pHero.nGameMode == 0)
			{
				homeScreenButtonEvents();
			}
			else if (pHero.nGameMode == 1)
			{
				setScreenMode(9);
			}
			break;
		case 30:
			abortAlertCloseButEvents();
			break;
		case 31:
			exitAlertCloseButEvents();
			break;
		case 32:
			exitAlertCloseButEvents();
			refreshFBListIfneeded();
			if (pHero.isConnectedInternet())
			{
				But_AskLife_Accept.setEnable(false);
				bHS_asklife = true;
				pAnim_MailBox.resetAllValues();
				if (pFacebook.isFBLoginSucess())
				{
					listAskLife.Clear();
					foreach (KeyValuePair<string, FBFriendInfoList> fb2 in fbList)
					{
						if (!fb2.Value.userName.Equals("Me"))
						{
							MailBoxAskSendInfo mailBoxAskSendInfo = new MailBoxAskSendInfo();
							mailBoxAskSendInfo.userID = fb2.Key;
							mailBoxAskSendInfo.bCheckbox = false;
							listAskLife.Add(mailBoxAskSendInfo);
						}
					}
				}
				if (bHS_asklife && listAskLife != null)
				{
					AskLifeScroll_CurPos.y = IGT_UIcommonFunc.ScaleY(0f);
					int num4 = fbList.Count - 1;
					if (num4 > 4)
					{
						bScrollAnim = true;
						fScrollAnimTime = 0f;
						AskLifeScroll_ScrollviwRectMaxY = AskLifeScroll_BarStrtPosY;
						AskLifeScroll_ScrollviewRectMinY = ScrollViewRect_AskLifeScroll.y + ScrollViewRect_AskLifeScroll.height - (float)num4 * (AskLifeScroll_BarHeight + AskLifeScroll_BarGap) - (ScrollViewRect_AskLifeScroll.y + AskLifeScroll_BarStrtPosY);
					}
				}
			}
			else
			{
				setNoInternetAlert();
			}
			break;
		case 33:
			exitAlertCloseButEvents();
			setScreenMode(6);
			if (nPurchaseType != 3)
			{
				nPurchaseType = 3;
				bScrollAnim = true;
				fScrollAnimTime = 0f;
				purchaseWindow_ScrollviwRectMaxY = purchaseWindow_BarStrtPosY;
				purchaseWindow_ScrollviewRectMinY = ScrollViewRect_purchaseWindow.y + ScrollViewRect_purchaseWindow.height - (float)pHero.pPurchaseItemsData_Free.Count * (purchaseWindow_BarHeight + purchaseWindow_BarGap) - (ScrollViewRect_purchaseWindow.y + purchaseWindow_BarStrtPosY);
			}
			break;
		case 34:
			checkAlertScreens_Purchase_for_GivenIDs(0, 9);
			break;
		case 35:
			checkAlertScreens_Purchase_for_GivenIDs(0, 10);
			break;
		case 36:
			checkAlertScreens_Purchase_for_GivenIDs(0, 11);
			break;
		case 37:
			setScreenMode(nPrevScreenMode);
			break;
		case 38:
			checkAlertScreens_Purchase_for_GivenIDs(0, 5);
			break;
		case 39:
			checkAlertScreens_Purchase_for_GivenIDs(0, 6);
			break;
		case 40:
			checkAlertScreens_Purchase_for_GivenIDs(0, 7);
			break;
		case 51:
			Application.Quit();
			break;
		case 52:
			exitAlertCloseButEvents();
			break;
		case 115:
			MailBoxAcceptEvent();
			break;
		case 116:
		{
			int num = 0;
			for (int i = 0; i < listAskSend.Count; i++)
			{
				listAskSend[i].bCheckbox = true;
				num++;
			}
			if (num > 0)
			{
				But_Mail_Accept.setEnable(true);
			}
			else
			{
				But_Mail_Accept.setEnable(false);
			}
			But_Mail_CheckAll.setEnable(false);
			break;
		}
		case 120:
		{
			int num8 = 0;
			for (int num9 = 0; num9 < listSendLife.Count; num9++)
			{
				listSendLife[num9].bCheckbox = true;
				num8++;
			}
			if (num8 > 0)
			{
				But_SendLife_Accept.setEnable(true);
			}
			else
			{
				But_SendLife_Accept.setEnable(false);
			}
			But_SendLife_CheckAll.setEnable(false);
			break;
		}
		case 122:
		{
			int num7 = 0;
			for (int n = 0; n < listAskLife.Count; n++)
			{
				listAskLife[n].bCheckbox = true;
				num7++;
			}
			if (num7 > 0)
			{
				But_AskLife_Accept.setEnable(true);
			}
			else
			{
				But_AskLife_Accept.setEnable(false);
			}
			But_AskLife_CheckAll.setEnable(false);
			break;
		}
		case 118:
			pAnim_MailBox.resetAllValues();
			pAnim_MailBox.setIsReverse(true);
			break;
		case 117:
			pAnim_MailBox.resetAllValues();
			pAnim_MailBox.setIsReverse(true);
			mailBoxCloseBtnEvent();
			break;
		case 119:
		{
			List<string> list2 = new List<string>();
			for (int m = 0; m < listSendLife.Count; m++)
			{
				if (listSendLife[m].bCheckbox)
				{
					list2.Add(listSendLife[m].userID);
				}
			}
			if (list2.Count > 0)
			{
				pHero.bCanShowAdOnForeGround = false;
				pFacebook.AppRequestPassToList("Send Life", "sent a life", list2, "life~Send~1", sendSucess, sendFailed);
			}
			break;
		}
		case 121:
		{
			List<string> list = new List<string>();
			for (int l = 0; l < listAskLife.Count; l++)
			{
				if (listAskLife[l].bCheckbox)
				{
					list.Add(listAskLife[l].userID);
				}
			}
			if (list.Count > 0)
			{
				pHero.bCanShowAdOnForeGround = false;
				pFacebook.AppRequestPassToList("Ask Life", "asked a life", list, "life~Ask~1", askSucess, askFailed);
			}
			break;
		}
		case 53:
			pauseButtonEvents();
			break;
		case 61:
			setScreenMode(20);
			pHero.bLevelUpButtonPressed = true;
			break;
		case 47:
			if (nPurchaseType != 0)
			{
				nPurchaseType = 0;
				bScrollAnim = true;
				fScrollAnimTime = 0f;
				purchaseWindow_ScrollviwRectMaxY = purchaseWindow_BarStrtPosY;
				purchaseWindow_ScrollviewRectMinY = ScrollViewRect_purchaseWindow.y + ScrollViewRect_purchaseWindow.height - (float)pHero.pPurchaseItemsData_Store.Count * (purchaseWindow_BarHeight + purchaseWindow_BarGap) - (ScrollViewRect_purchaseWindow.y + purchaseWindow_BarStrtPosY);
				pHero.pBezierAnimation_Group.Clear();
				break;
			}
			return;
		case 48:
			if (nPurchaseType != 1)
			{
				nPurchaseType = 1;
				bScrollAnim = true;
				fScrollAnimTime = 0f;
				purchaseWindow_ScrollviwRectMaxY = purchaseWindow_BarStrtPosY;
				purchaseWindow_ScrollviewRectMinY = ScrollViewRect_purchaseWindow.y + ScrollViewRect_purchaseWindow.height - (float)pHero.pPurchaseItemsData_Deals.Count * (purchaseWindow_BarHeight + purchaseWindow_BarGap) - (ScrollViewRect_purchaseWindow.y + purchaseWindow_BarStrtPosY);
				pHero.pBezierAnimation_Group.Clear();
				break;
			}
			return;
		case 49:
			if (nPurchaseType != 2)
			{
				nPurchaseType = 2;
				bScrollAnim = true;
				fScrollAnimTime = 0f;
				purchaseWindow_ScrollviwRectMaxY = purchaseWindow_BarStrtPosY;
				purchaseWindow_ScrollviewRectMinY = ScrollViewRect_purchaseWindow.y + ScrollViewRect_purchaseWindow.height - (float)pHero.pPurchaseItemsData_Boost.Count * (purchaseWindow_BarHeight + purchaseWindow_BarGap) - (ScrollViewRect_purchaseWindow.y + purchaseWindow_BarStrtPosY);
				break;
			}
			return;
		case 50:
			if (nPurchaseType != 3)
			{
				nPurchaseType = 3;
				bScrollAnim = true;
				fScrollAnimTime = 0f;
				purchaseWindow_ScrollviwRectMaxY = purchaseWindow_BarStrtPosY;
				purchaseWindow_ScrollviewRectMinY = ScrollViewRect_purchaseWindow.y + ScrollViewRect_purchaseWindow.height - (float)pHero.pPurchaseItemsData_Free.Count * (purchaseWindow_BarHeight + purchaseWindow_BarGap) - (ScrollViewRect_purchaseWindow.y + purchaseWindow_BarStrtPosY);
				pHero.pBezierAnimation_Group.Clear();
				if (!pAds.isRewardBasedVideoAvailable())
				{
					pAds.RequestRewardBasedVideo();
				}
				break;
			}
			return;
		case 46:
			if (nPrevScreenMode == nScreenMode)
			{
				setScreenMode(nBeforePrevScreenMode);
			}
			else
			{
				setScreenMode(nPrevScreenMode);
			}
			pHero.pBezierAnimation_Group.Clear();
			break;
		case 81:
		{
			nPurchaseType = 0;
			bScrollAnim = true;
			fScrollAnimTime = 0f;
			int num5 = ((!sUpgradeAlertItemName.StartsWith("C")) ? (sUpgradeAlertItemName.StartsWith("K") ? 5 : (sUpgradeAlertItemName.StartsWith("L") ? 7 : 0)) : 0);
			purchaseWindow_ScrollviwRectMaxY = purchaseWindow_BarStrtPosY - (float)num5 * (purchaseWindow_BarHeight + purchaseWindow_BarGap);
			purchaseWindow_ScrollviewRectMinY = ScrollViewRect_purchaseWindow.y + ScrollViewRect_purchaseWindow.height - (float)pHero.pPurchaseItemsData_Store.Count * (purchaseWindow_BarHeight + purchaseWindow_BarGap) - (ScrollViewRect_purchaseWindow.y + purchaseWindow_BarStrtPosY);
			bUpgradeAlert = false;
			break;
		}
		case 82:
			NoInternetAlertOkButtonEvents();
			break;
		case 41:
			if (nGameoverScrollType != 0)
			{
				nGameoverScrollType = 0;
				break;
			}
			return;
		case 85:
			feedTagListNext();
			break;
		case 86:
			feedTagListPrev();
			break;
		case 88:
		{
			pAnim_feedinvite.resetAllValues();
			pAnim_feedinvite.setIsReverse(true);
			feedshareFailed();
			int num3 = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_feedDeclinedCount, 1);
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_feedDeclinedCount, ++num3);
			break;
		}
		case 87:
			feedTagListSubmit();
			break;
		case 89:
			feedCheckAll();
			break;
		case 83:
			if (pHero.isConnectedInternet())
			{
				pAnim_postalert.resetAllValues();
				pAnim_postalert.setIsReverse(true);
				pAnim_feedinvite.resetAllValues();
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_feedDeclinedCount, 1);
				if (bnormalFeedShare)
				{
					if (feedType == 1)
					{
						pFacebook.FBFeedShare("https://www.veegames.com/fb/streetchaser/feedstory/crossedscore/" + feedChaseScore, feedshareSuccess, feedshareFailed);
					}
					else if (feedType == 0)
					{
						pFacebook.FBFeedShare("https://www.veegames.com/fb/streetchaser/feedstory/milestone/" + feedLeveld, feedshareSuccess, feedshareFailed);
					}
				}
				else
				{
					pHero.bCanShowAdOnForeGround = false;
					pFacebook.requestPublishPermission(givenPermission);
				}
			}
			else
			{
				setNoInternetAlert();
			}
			break;
		case 84:
		{
			pAnim_postalert.resetAllValues();
			pAnim_postalert.setIsReverse(true);
			int num2 = IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_feedDeclinedCount, 1);
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_feedDeclinedCount, ++num2);
			break;
		}
		case 42:
			if (nGameoverScrollType != 1)
			{
				nGameoverScrollType = 1;
				break;
			}
			return;
		case 43:
			if (nGameoverScrollType != 2)
			{
				nGameoverScrollType = 2;
				bScrollAnim = true;
				fScrollAnimTime = 0f;
				GameoverScroll_ScrollviwRectMaxY = GameoverScroll_BarStrtPosY;
				GameoverScroll_ScrollviewRectMinY = ScrollViewRect_GameoverScreen.y + ScrollViewRect_GameoverScreen.height - (float)nBustedScrollCount * (GameoverScroll_BarHeight + GameoverScroll_BarGap_Busted) - (ScrollViewRect_GameoverScreen.y + GameoverScroll_BarStrtPosY);
				break;
			}
			return;
		case 62:
			mapBackButtonEvents();
			break;
		case 65:
			menubackbtnevent();
			break;
		case 74:
			setScreenMode(6);
			nPurchaseType = 0;
			bScrollAnim = true;
			fScrollAnimTime = 0f;
			purchaseWindow_ScrollviwRectMaxY = purchaseWindow_BarStrtPosY - 5f * (purchaseWindow_BarHeight + purchaseWindow_BarGap);
			purchaseWindow_ScrollviewRectMinY = ScrollViewRect_purchaseWindow.y + ScrollViewRect_purchaseWindow.height - (float)pHero.pPurchaseItemsData_Store.Count * (purchaseWindow_BarHeight + purchaseWindow_BarGap) - (ScrollViewRect_purchaseWindow.y + purchaseWindow_BarStrtPosY);
			pHero.post_Analytics_Screen_Button_Datas("Menu", "Addkey");
			break;
		case 75:
			nPurchaseType = 0;
			bScrollAnim = true;
			fScrollAnimTime = 0f;
			purchaseWindow_ScrollviwRectMaxY = purchaseWindow_BarStrtPosY;
			purchaseWindow_ScrollviewRectMinY = ScrollViewRect_purchaseWindow.y + ScrollViewRect_purchaseWindow.height - (float)pHero.pPurchaseItemsData_Store.Count * (purchaseWindow_BarHeight + purchaseWindow_BarGap) - (ScrollViewRect_purchaseWindow.y + purchaseWindow_BarStrtPosY);
			setScreenMode(6);
			pHero.post_Analytics_Screen_Button_Datas("Menu", "AddCoin");
			break;
		case 76:
			nPurchaseType = 0;
			bScrollAnim = true;
			fScrollAnimTime = 0f;
			purchaseWindow_ScrollviwRectMaxY = purchaseWindow_BarStrtPosY - 7f * (purchaseWindow_BarHeight + purchaseWindow_BarGap);
			purchaseWindow_ScrollviewRectMinY = ScrollViewRect_purchaseWindow.y + ScrollViewRect_purchaseWindow.height - (float)pHero.pPurchaseItemsData_Store.Count * (purchaseWindow_BarHeight + purchaseWindow_BarGap) - (ScrollViewRect_purchaseWindow.y + purchaseWindow_BarStrtPosY);
			setScreenMode(6);
			pHero.post_Analytics_Screen_Button_Datas("Menu", "AddLife");
			break;
		case 66:
			nPurchaseType = 0;
			bScrollAnim = true;
			fScrollAnimTime = 0f;
			purchaseWindow_ScrollviwRectMaxY = purchaseWindow_BarStrtPosY;
			purchaseWindow_ScrollviewRectMinY = ScrollViewRect_purchaseWindow.y + ScrollViewRect_purchaseWindow.height - (float)pHero.pPurchaseItemsData_Store.Count * (purchaseWindow_BarHeight + purchaseWindow_BarGap) - (ScrollViewRect_purchaseWindow.y + purchaseWindow_BarStrtPosY);
			setScreenMode(6);
			pHero.post_Analytics_Screen_Button_Datas("Menu", "Shop");
			break;
		case 67:
			bLeaderBoardbtnClick = true;
			bLBwronganim = false;
			pAnim_menu_LeaderBoard.resetAllValues();
			But_Menu_GoogleLB.ResetAnimationDatas();
			But_Menu_FBLB.ResetAnimationDatas();
			break;
		case 92:
			bGoogleLbbtnClick = false;
			bHS_GooglebtnClick = false;
			break;
		case 93:
			bFBbtnClick = false;
			bHS_FBbtnClick = false;
			break;
		case 94:
			if (bFB_MsnEnablebtnClick)
			{
				bFB_MsnEnablebtnClick = false;
				bFBLBglobal = false;
				nGameoverScrollType = 0;
			}
			break;
		case 95:
			if (!bFB_MsnEnablebtnClick)
			{
				bFB_MsnEnablebtnClick = true;
				bFBLBglobal = true;
				nMC_ScrollType = 1;
			}
			break;
		case 96:
			bFBLBglobal = false;
			if (bFB_MsnEnablebtnClick)
			{
				if (nMC_ScrollType != 0)
				{
					nMC_ScrollType = 0;
				}
			}
			else if (nGameoverScrollType != 0)
			{
				nGameoverScrollType = 0;
			}
			break;
		case 97:
			bFBLBglobal = true;
			if (bFB_MsnEnablebtnClick)
			{
				if (nMC_ScrollType != 1)
				{
					nMC_ScrollType = 1;
				}
			}
			else if (nGameoverScrollType != 1)
			{
				nGameoverScrollType = 1;
			}
			break;
		case 69:
			setScreenMode(6);
			if (nPurchaseType != 3)
			{
				nPurchaseType = 3;
				bScrollAnim = true;
				fScrollAnimTime = 0f;
				purchaseWindow_ScrollviwRectMaxY = purchaseWindow_BarStrtPosY;
				purchaseWindow_ScrollviewRectMinY = ScrollViewRect_purchaseWindow.y + ScrollViewRect_purchaseWindow.height - (float)pHero.pPurchaseItemsData_Free.Count * (purchaseWindow_BarHeight + purchaseWindow_BarGap) - (ScrollViewRect_purchaseWindow.y + purchaseWindow_BarStrtPosY);
			}
			pHero.post_Analytics_Screen_Button_Datas("Menu", "Free");
			break;
		case 73:
			pAnim_MailBox.resetAllValues();
			bHS_about = true;
			fAbtTexY = 440f;
			if (pHero.bTestingTeamPurpose)
			{
				IGT_Constants.nTotNoOfCoins += 1000000;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotCoins, IGT_Constants.nTotNoOfCoins);
				IGT_Constants.nTotKeysCount += 100;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotKeyCount, IGT_Constants.nTotKeysCount);
				pHero.pIGt_LifeCalc.forceAddLifeCount(100);
			}
			break;
		case 63:
			pAnim_GAchievement.resetAllValues();
			pAnim_GAchievement.setIsReverse(true);
			break;
		case 64:
			stop_sorryAlert();
			break;
		case 80:
			NoInternetAlertOkButtonEvents();
			break;
		case 77:
			if (HScam_cur_angle != 270f)
			{
				btn_SourceAngle = HScam_cur_angle;
				btn_DestinationAngle = HScam_cur_angle - ang_btwn_Characters;
				mov_btn = true;
				HScam_move_tym = 0f;
				HSbtn_start_tym = Time.time;
				pAnim_coinsBG.resetAllValues();
			}
			break;
		case 78:
			if (HScam_cur_angle != 350f)
			{
				btn_SourceAngle = HScam_cur_angle;
				btn_DestinationAngle = HScam_cur_angle + ang_btwn_Characters;
				mov_btn = true;
				HScam_move_tym = 0f;
				HSbtn_start_tym = Time.time;
				pAnim_coinsBG.resetAllValues();
			}
			break;
		case 79:
		{
			string text = string.Empty;
			if (Character_Buy_Coins[centre_character] <= IGT_Constants.nTotNoOfCoins && ready_character_idx[centre_character] != 1)
			{
				ready_character_idx[centre_character] = 1;
				coins_fission = true;
				IGT_Constants.nTotNoOfCoins -= Character_Buy_Coins[centre_character];
			}
			else if (ready_character_idx[centre_character] == 0)
			{
				setScreenMode(6);
				nPurchaseType = 0;
			}
			for (int k = 0; k < 5; k++)
			{
				text += ready_character_idx[k];
				if (k != ready_character_idx.GetLength(0) - 1)
				{
					text += "~";
				}
			}
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_hero_purchase, text);
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotCoins, IGT_Constants.nTotNoOfCoins);
			IGT_Preference.getInstance()._SaveAll();
			break;
		}
		case 54:
			if (canPlayGameUsingLife() || pHero.nMissionID + 1 < 5)
			{
				pHero.InvokeRepeating("StopMusicWithFade", 0f, 0.1f);
				mission_ButtonEvents(pHero.nMissionID + 1);
			}
			else
			{
				NoMoLiveAlertScreen();
			}
			break;
		case 55:
			if (canPlayGameUsingLife() || pHero.nMissionID < 5)
			{
				pHero.InvokeRepeating("StopMusicWithFade", 0f, 0.1f);
				pHero.bRestart = true;
				mission_ButtonEvents(pHero.nMissionID);
			}
			else
			{
				NoMoLiveAlertScreen();
			}
			break;
		case 56:
			homeScreenButtonEvents();
			bChaseLockedAlert = false;
			pAnim_menu_LeaderBoard.resetAllValues();
			break;
		case 132:
			if (canPlayGameUsingLife() || pHero.nMissionID + 1 < 5)
			{
				if (IGT_Constants.nTotNoOfCoins >= 1000)
				{
					IGT_Constants.nTotNoOfCoins -= 1000;
					IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotCoins, IGT_Constants.nTotNoOfCoins);
					pMapObj.insertLevelStarData(pHero.nMissionID + 1, -1);
					pHero.InvokeRepeating("StopMusicWithFade", 0f, 0.1f);
					mission_ButtonEvents(pHero.nMissionID + 1);
				}
				else
				{
					Start_Toast("Not Enough Coins");
				}
			}
			else
			{
				NoMoLiveAlertScreen();
			}
			break;
		case 60:
			bChaseLockedAlert = false;
			break;
		case 57:
			if (nMC_ScrollType != 0)
			{
				nMC_ScrollType = 0;
			}
			break;
		case 58:
			if (nMC_ScrollType != 1)
			{
				nMC_ScrollType = 1;
			}
			break;
		case 100:
			bAppNotInstalledAlert = false;
			if (pHero.isConnectedInternet())
			{
				if (!pFacebook.isFBLoginSucess())
				{
					bShareReLogin = true;
					pHero.bCanShowAdOnForeGround = false;
					pFacebook.FBLogin(FBLoginCompleted, FBLoginFailed);
				}
				else
				{
					pHero.bCanShowAdOnForeGround = false;
					pFacebook.FBShare(shareTitle, shareMsg, shareURL, ShareReqSucess, ShareReqFailed);
				}
			}
			else
			{
				setNoInternetAlert();
			}
			break;
		case 101:
			pFacebook.FBLogout();
			break;
		case 102:
			if (pHero.isConnectedInternet())
			{
				if (pFacebook.HaveFrndListPermission)
				{
					pHero.bCanShowAdOnForeGround = false;
					pFacebook.FBInvite(fbAppInviteUri, AppInviteSucess, AppInviteFailed);
				}
				else
				{
					bInviteReLogin = true;
					pHero.bCanShowAdOnForeGround = false;
					pFacebook.FBLogin(FBLoginCompleted, FBLoginFailed);
				}
			}
			else
			{
				setNoInternetAlert();
			}
			break;
		case 106:
			if (nScreenMode == 6 && nPurchaseType == 3 && Time.time - fMoreGamesClickedTime > 5f && bHS_moregames)
			{
				IGT_Constants.nTotNoOfCoins += 200;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotCoins, IGT_Constants.nTotNoOfCoins);
				bMoreGameEnableInPurchaseWindow = false;
				dMoregamesLastShownIntervalTimeSec = currentTimeSecs();
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_MoregamesLastShow, (float)(int)dMoregamesLastShownIntervalTimeSec);
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_didClickMoreGames, 1);
				didClickMoreGames = 1;
			}
			pMoregame.OnClose();
			bHS_moregames = false;
			break;
		case 107:
			pAnim_MailBox.resetAllValues();
			pAnim_MailBox.setIsReverse(true);
			break;
		case 108:
			bAllShareAlerts = true;
			pAnim_MailBox.resetAllValues();
			bHS_allshare = true;
			if (nScreenMode == 12)
			{
				pHero.post_Analytics_Screen_Button_Datas("Menu", "Share");
			}
			break;
		case 109:
			if (pHero.isConnectedInternet())
			{
				pHero.bCanShowAdOnForeGround = false;
				pSocialShare.shareToWhatsApp(shareTitle, shareMsg, whatappShareUrl, shareWhatsAppSucess);
			}
			else
			{
				setNoInternetAlert();
			}
			break;
		case 110:
			if (pHero.isConnectedInternet())
			{
				pHero.bCanShowAdOnForeGround = false;
				pSocialShare.shareToTwitter(shareTitle, shareMsg, twitterShareUrl, shareTwitterSucess);
			}
			else
			{
				setNoInternetAlert();
			}
			break;
		case 111:
			if (pHero.isConnectedInternet())
			{
				pHero.bCanShowAdOnForeGround = false;
				pSocialShare.shareToMail(string.Empty, shareTitle, "Hi, \n\n" + shareMsg + "\n\n" + mailShareUrl, shareMailSucess);
			}
			else
			{
				setNoInternetAlert();
			}
			break;
		case 112:
			pHero.bCanShowAdOnForeGround = false;
			pSocialShare.shareToMessage(string.Empty, shareMsg + " " + smsShareUrl, shareSMSSucess);
			break;
		case 113:
			pSocialShare.shareToGooglePluse(shareTitle, shareMsg, shareURL);
			break;
		case 125:
			bIsShowGPluseLoginAlert = false;
			bHS_GooglebtnClick = false;
			bGoogleLbbtnClick = false;
			break;
		case 124:
			if (pHero.isConnectedInternet())
			{
				pLeaderBoard.LeaderAchivLogin();
			}
			else
			{
				setNoInternetAlert();
			}
			bIsShowGPluseLoginAlert = false;
			bHS_GooglebtnClick = false;
			bGoogleLbbtnClick = false;
			break;
		case 127:
			Inapp_Alert_Window_Close_ButtonEvents();
			break;
		case 128:
			if (pHero.isConnectedInternet())
			{
				if (!pFacebook.isFBLoginSucess())
				{
					pHero.bCanShowAdOnForeGround = false;
					pFacebook.FBLogin(FBLoginCompleted, FBLoginFailed);
				}
				else if (pFacebook.HaveFrndListPermission)
				{
					pHero.bCanShowAdOnForeGround = false;
					pFacebook.FBInvite(fbAppInviteUri, AppInviteSucess, AppInviteFailed);
				}
				else
				{
					bInviteReLogin = true;
					pHero.bCanShowAdOnForeGround = false;
					pFacebook.FBLogin(FBLoginCompleted, FBLoginFailed);
				}
			}
			else
			{
				setNoInternetAlert();
			}
			bInappAlert = false;
			break;
		case 129:
			switch (button.getID_Index())
			{
			case 0:
				checkAlertScreens_Purchase_for_GivenIDs(0, 9);
				break;
			case 1:
				checkAlertScreens_Purchase_for_GivenIDs(0, 10);
				break;
			case 2:
				checkAlertScreens_Purchase_for_GivenIDs(0, 11);
				break;
			case 3:
				checkAlertScreens_Purchase_for_GivenIDs(0, 5);
				break;
			case 4:
				checkAlertScreens_Purchase_for_GivenIDs(0, 6);
				break;
			case 5:
				checkAlertScreens_Purchase_for_GivenIDs(0, 7);
				break;
			case 6:
				checkAlertScreens_Purchase_for_GivenIDs(0, 1);
				break;
			case 7:
				checkAlertScreens_Purchase_for_GivenIDs(0, 2);
				break;
			case 8:
				checkAlertScreens_Purchase_for_GivenIDs(0, 4);
				break;
			case 9:
				checkAlertScreens_Purchase_for_GivenIDs(1, 0);
				break;
			case 10:
				checkAlertScreens_Purchase_for_GivenIDs(1, 1);
				break;
			case 11:
				checkAlertScreens_Purchase_for_GivenIDs(1, 3);
				break;
			}
			pHero.post_Analytics_Screen_Button_Datas("InAppAlert", getInappAlertButtonName(button.getID_Index()));
			break;
		case 130:
			bInappAlert = false;
			setScreenMode(6);
			if (nAlertWin == 4)
			{
				nPurchaseType = 1;
			}
			else
			{
				nPurchaseType = 0;
			}
			break;
		case 131:
		{
			int flag = ((nScreenMode == 0 || nScreenMode == 12) ? 2 : ((nScreenMode == 10) ? 1 : ((nScreenMode != 5) ? 2 : ((pHero.nGameMode != 0) ? 1 : 0))));
			getScoreFromInternet(flag);
			break;
		}
		}
		pHero.playSound(6);
	}

	private void nickNameOkEvent()
	{
		if (strNickName != null && !strNickName.Equals(string.Empty) && !PlayerPrefs.HasKey(kGetNickName))
		{
			if (!bHS_settings)
			{
				pHero.nGameMode = 1;
				setScreenMode(9);
			}
			bShowNickName = false;
			IGT_Preference.getInstance()._Set(kNickNameAvailable, 1);
			PlayerPrefs.SetString(kGetNickName, strNickName);
		}
		else if (PlayerPrefs.HasKey(kGetNickName) && strNickName != null && !strNickName.Equals(string.Empty))
		{
			PlayerPrefs.SetString(kGetNickName, strNickName);
			strNickName = PlayerPrefs.GetString(kGetNickName, "Player");
			bShowNickName = false;
		}
	}

	private void MailBoxAcceptEvent()
	{
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		for (int i = 0; i < listAskSend.Count; i++)
		{
			if (listAskSend[i].bCheckbox)
			{
				if (listAskSend[i].msg.Equals("Sent a life"))
				{
					list2.Add(listAskSend[i].userID);
				}
				if (listAskSend[i].msg.Equals("Asked a life"))
				{
					list.Add(listAskSend[i].userID);
				}
			}
		}
		if (list2.Count > 0)
		{
			bProcessDeleteAppReqCall = true;
			pFacebook.processDeleteAppReq(list2, 0, processDeleteAppReqSucess, processDeleteAppReqFailed);
			if (list.Count <= 0)
			{
				mailBoxCloseBtnEvent();
			}
		}
		if (list.Count > 0)
		{
			pFacebook.AppRequestPassToList("Send Life", "send a life", list, "life~Send~1", sendLifeMailSucess, sendLifeMailFailed);
		}
	}

	private static void MoreGamesButtonEvents()
	{
		if (pHero.isConnectedInternet())
		{
			bHS_moregames = true;
			string text = "https://www.veegames.com/mobileads/moregames/an/an_moregames_v2.php?src=streetchaser&insts=";
			text = "https://www.veegames.com/mobileads/moregames/an/an_moregames_v2.php?src=streetchaser&insts=" + pMoregame.androidInstalledApps();
			Coroutiner.StartCoroutine(pMoregame.LoadUrl(text));
			if (bNewBadgeInMoreGames && nScreenMode == 0)
			{
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_NewBadgeMoreGamesHomeScreen_Time, (float)currentTimeSecs());
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_isNewBadgeMoreGamesHomeScreenShown, 1);
				IGT_Preference.getInstance()._SaveAll();
				bNewBadgeInMoreGames = false;
			}
		}
		else
		{
			setNoInternetAlert();
		}
		pHero.post_Analytics_Screen_Button_Datas("HomeScreen", "MoreGames");
	}

	private static void UsekeyButEvent(bool bKey)
	{
		if (bKey)
		{
			IGT_Constants.nTotKeysCount -= IGT_Constants.nNoOfKeysToRevive;
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotKeyCount, IGT_Constants.nTotKeysCount);
			if (IGT_Constants.nNoOfKeysToRevive == 1)
			{
				IGT_Constants.nNoOfKeysToRevive = 2;
			}
			else
			{
				IGT_Constants.nNoOfKeysToRevive *= 2;
			}
		}
		pHero.bUseKey = true;
		IGT_Constants.fUseKeyCountDownStrtTime = Time.time;
		setScreenMode(8);
		nCountDownNum = 3.0;
		IGT_AnimStatesCntrler.HeroAnimator.Play("Idle", 0);
		if (pHero.isAIplayerAvailable)
		{
			IGT_AIPlayer.pAIPlayerAnimController.AIHeroAnimator.Play("Idle", 0);
		}
		pHero.playSound(30);
	}

	private void checkAlertScreens_Purchase_for_GivenIDs(int purchaseType, int id)
	{
		if (pHero.isConnectedInternet())
		{
			switch (purchaseType)
			{
			case 0:
				pHero.StartPurchase(pHero.pPurchaseItemsData_Store[id].ProductID_GooglePlayStore);
				break;
			case 1:
				pHero.StartPurchase(pHero.pPurchaseItemsData_Deals[id].ProductID_GooglePlayStore);
				break;
			}
		}
		else
		{
			setNoInternetAlert();
		}
	}

	private string getInappAlertButtonName(int index)
	{
		string result = "Others";
		switch (index)
		{
		case 0:
			result = "Life_1";
			break;
		case 1:
			result = "Life_2";
			break;
		case 2:
			result = "Life_3";
			break;
		case 3:
			result = "Key_1";
			break;
		case 4:
			result = "Key_2";
			break;
		case 5:
			result = "Key_3";
			break;
		case 6:
			result = "Coin_1";
			break;
		case 7:
			result = "Coin_2";
			break;
		case 8:
			result = "Coin_3";
			break;
		case 9:
			result = "Combo_1";
			break;
		case 10:
			result = "Combo_2";
			break;
		case 11:
			result = "Combo_3";
			break;
		}
		return result;
	}

	public static void loadMapButtons()
	{
		pMapObj.placeLevelObjects1();
		pHero.PlayerObj.DestroyAllTypesofObjects();
	}

	private float currentTimeMins()
	{
		return (float)(DateTime.UtcNow - Junt2017).TotalMinutes;
	}

	public static long currentTimeSecs()
	{
		return (long)(DateTime.UtcNow - Junt2017).TotalSeconds;
	}

	public string getRewardedVideoTimeIntervel()
	{
		double num = (dRewardedVideoLastShowTimeIntervelMin - ((double)currentTimeSecs() - dRewardedVideoLastShowIntervelSec) / 60.0) % dRewardedVideoLastShowTimeIntervelMin;
		double num2 = dRewardedVideoLastShowTimeIntervelSec - ((double)currentTimeSecs() - dRewardedVideoLastShowIntervelSec) % 60.0;
		if (num2 == 60.0)
		{
			num2 = 0.0;
		}
		if (num == 0.0 && num2 == 0.0)
		{
			bRewardedVideoTimeUp = true;
			if (!pAds.isRewardBasedVideoAvailable())
			{
				pAds.RequestRewardBasedVideo();
			}
		}
		else
		{
			bRewardedVideoTimeUp = false;
		}
		if (num < 0.0)
		{
			bRewardedVideoTimeUp = true;
			return "00:00";
		}
		return Mathf.Floor((float)num).ToString("00") + ":" + Mathf.Floor((float)num2).ToString("00");
	}

	private void shareWhatsAppSucess()
	{
		if (canwhatsappShare)
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.whatsAppLastShare, (float)currentTimeSecs());
			IGT_Preference.getInstance()._Set(IGT_Constants.pendingwhatsAppShare, 1);
			whatsappShareTime = currentTimeSecs();
			canwhatsappShare = false;
			isPendingwhatsappShare = 1;
			IGT_Constants.whatsAppText = " Processing ";
		}
	}

	private void shareTwitterSucess()
	{
		if (cantwitterShare)
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.twitterLastShare, (float)currentTimeSecs());
			IGT_Preference.getInstance()._Set(IGT_Constants.pendingTwitterShare, 1);
			twitterShareTime = currentTimeSecs();
			cantwitterShare = false;
			isPendingtwitterShare = 1;
			IGT_Constants.twitterText = " Processing ";
		}
	}

	private void shareMailSucess()
	{
		if (canmailShare)
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.mailLastShare, (float)currentTimeSecs());
			IGT_Preference.getInstance()._Set(IGT_Constants.pendingMailShare, 1);
			isPendingmailShare = 1;
			mailShareTime = currentTimeSecs();
			canmailShare = false;
			IGT_Constants.mailText = " Processing ";
		}
	}

	private void shareInstaSucess()
	{
		if (caninstaShare)
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.instaLastShare, (float)currentTimeSecs());
			IGT_Preference.getInstance()._Set(IGT_Constants.pendingInstaShare, 1);
			instaShareTime = currentTimeSecs();
			caninstaShare = false;
			IGT_Constants.instaText = " Processing ";
			isPendinginstaShare = 1;
		}
	}

	private void shareSMSSucess()
	{
		if (cansmsShare)
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.smsLastShare, (float)currentTimeSecs());
			IGT_Preference.getInstance()._Set(IGT_Constants.pendingSMSShare, 1);
			smsShareTime = currentTimeSecs();
			cansmsShare = false;
			IGT_Constants.smsText = " Processing ";
			isPendingsmsShare = 1;
		}
	}

	private void AppInviteSucess(string result)
	{
		long num = (long)IGT_Preference.getInstance()._Get(kFBInviteLastUpdateTime, 0f);
		if (num + IGT_Constants.dFBInviteTime <= (long)currentTimeMins())
		{
			num = (long)currentTimeMins();
			IGT_Preference.getInstance()._Set(kFBInviteLastUpdateTime, (float)num);
			pHero.pIGt_LifeCalc.forceAddLifeCount(IGT_Constants.nFBInviteLife);
		}
		mailBoxCloseBtnEvent();
	}

	private void AppInviteFailed(string error)
	{
	}

	public static void mailBoxCloseBtnEvent()
	{
		if (bHS_mailbox)
		{
			if (bHS_mailbox && listAskSend != null)
			{
				MailBoxScroll_CurPos.y = IGT_UIcommonFunc.ScaleY(0f);
			}
			bHS_mailbox = false;
			But_Mail_CheckAll.setEnable(true);
		}
		if (bHS_sendlife)
		{
			if (bHS_sendlife && listSendLife != null)
			{
				SendLifeScroll_CurPos.y = IGT_UIcommonFunc.ScaleY(0f);
			}
			bHS_sendlife = false;
			But_SendLife_CheckAll.setEnable(true);
		}
		if (bHS_asklife)
		{
			if (bHS_asklife && listAskLife != null)
			{
				AskLifeScroll_CurPos.y = IGT_UIcommonFunc.ScaleY(0f);
			}
			bHS_asklife = false;
			But_AskLife_CheckAll.setEnable(true);
		}
		if (pFacebook.isFBLoginSucess() && !bProcessDeleteAppReqCall)
		{
			pFacebook.ProcessAppRequest(ProcessAppRequestComplete);
		}
	}

	private void processDeleteAppReqSucess(int val)
	{
		if (val == 0)
		{
			pHero.pIGt_LifeCalc.forceAddLifeCount(1);
			dMailBoxProcessedCount++;
			if (dMailBoxProcessedCount == dMailBoxSentCount)
			{
				dMailBoxisProcessing = false;
			}
			else
			{
				dMailBoxisProcessing = true;
			}
		}
		bProcessDeleteAppReqCall = false;
		if (pFacebook.isFBLoginSucess() && !bProcessDeleteAppReqCall)
		{
			pFacebook.ProcessAppRequest(ProcessAppRequestComplete);
		}
	}

	private void processDeleteAppReqFailed(int val)
	{
		if (val == 0)
		{
			dMailBoxProcessedCount++;
			if (dMailBoxProcessedCount == dMailBoxSentCount)
			{
				dMailBoxisProcessing = false;
			}
			else
			{
				dMailBoxisProcessing = true;
			}
		}
		bProcessDeleteAppReqCall = false;
		if (pFacebook.isFBLoginSucess() && !bProcessDeleteAppReqCall)
		{
			pFacebook.ProcessAppRequest(ProcessAppRequestComplete);
		}
	}

	private void sendLifeMailSucess(List<string> _reqID)
	{
		bProcessDeleteAppReqCall = true;
		pFacebook.processDeleteAppReq(_reqID, 1, processDeleteAppReqSucess, processDeleteAppReqFailed);
		mailBoxCloseBtnEvent();
	}

	private void sendLifeMailFailed(string errorMsg)
	{
		Start_Toast("Send Failed");
		But_Mail_Accept.setEnable(false);
		But_Mail_CheckAll.setEnable(true);
		for (int i = 0; i < listAskSend.Count; i++)
		{
			listAskSend[i].bCheckbox = false;
		}
		if (bHS_mailbox && listAskSend != null)
		{
			MailBoxScroll_CurPos.y = IGT_UIcommonFunc.ScaleY(0f);
		}
		if (listAskSend.Count == 0)
		{
			mailBoxCloseBtnEvent();
		}
	}

	private void sendSucess(List<string> _reqID)
	{
		Start_Toast("Sent Successfully");
		mailBoxCloseBtnEvent();
	}

	private void sendFailed(string msg)
	{
		Start_Toast("Send Failed");
		But_Mail_Accept.setEnable(false);
		But_Mail_CheckAll.setEnable(true);
		if (bHS_sendlife && listSendLife != null)
		{
			SendLifeScroll_CurPos.y = IGT_UIcommonFunc.ScaleY(0f);
		}
	}

	private void askSucess(List<string> _reqID)
	{
		Start_Toast("Request Sent");
		mailBoxCloseBtnEvent();
	}

	private void askFailed(string msg)
	{
		Start_Toast("Request Failed");
		But_Mail_Accept.setEnable(false);
		But_Mail_CheckAll.setEnable(true);
		if (bHS_asklife && listAskLife != null)
		{
			AskLifeScroll_CurPos.y = IGT_UIcommonFunc.ScaleY(0f);
		}
	}

	private void FBLoginCompleted()
	{
		if (nScreenMode == 0)
		{
			But_HS_FConnect.changeButtonTexture(pIgt_Textures.GetTexture(IGT_Constants.fbInvite));
		}
		if (bHS_allshare)
		{
			btn_fbLog.changeButtonTexture(pIgt_Textures.GetTexture(IGT_Constants._FbIcon));
		}
		mailBoxCloseBtnEvent();
		if (IGT_Preference.getInstance()._Get(kFBLoginfirstTime, 0) == 0)
		{
			pHero.pIGt_LifeCalc.forceAddLifeCount(IGT_Constants.nFBLoginLife);
			IGT_Preference.getInstance()._Set(kFBLoginfirstTime, 1);
		}
		pFacebook.GetFriendsInfo(getFBFriendsListCompleted, getFBFriendsListEmpty, loadFBFriendsPicSucess, loadFBFriendsPicFailed);
		if (bInviteReLogin && pFacebook.HaveFrndListPermission)
		{
			bInviteReLogin = false;
			pFacebook.FBInvite(fbAppInviteUri, AppInviteSucess, AppInviteFailed);
		}
		else if (bShareReLogin)
		{
			bShareReLogin = false;
			pFacebook.FBShare(shareTitle, shareMsg, shareURL, ShareReqSucess, ShareReqFailed);
		}
		else if (bLikeReGamePage && nScreenMode == 6 && nPurchaseType == 3)
		{
			bLikeReGamePage = false;
			pFacebook.FBLike(IGT_Constants.gamePageID, IGT_Constants.gamePageName, likePageOpened);
		}
		else if (bLikeReCompanyPage && nScreenMode == 6 && nPurchaseType == 3)
		{
			bLikeReCompanyPage = false;
			pFacebook.FBLike(IGT_Constants.companyPageID, IGT_Constants.companyPageName, likePageOpened);
		}
		Start_Toast("Conected to Facebook");
	}

	private void FBLogoutCompleted()
	{
		if (nScreenMode == 0)
		{
			But_HS_FConnect.changeButtonTexture(pIgt_Textures.GetTexture(IGT_Constants._FConnect));
		}
		if (bHS_allshare)
		{
			btn_fbLog.changeButtonTexture(pIgt_Textures.GetTexture(IGT_Constants._FbIcon));
		}
		fLeaderBoard_Chase_LastUpdatedTime = (fLeaderBoard_Mission_LastUpdatedTime = 0f);
		getScoreFromInternet(2);
		Start_Toast("Logout Successful");
	}

	private void FBLoginFailed()
	{
		Start_Toast("Login Failed");
		if (pIGT_ScrollData_GameOver_Topchase != null && pIGT_ScrollData_GameOver_Topchase.Count > 0)
		{
			nLeaderBoard_Chase_DispState = (nLeaderBoard_Mission_DispState = 2);
		}
	}

	private void ShareReqSucess()
	{
		if (canfbShare)
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.fbLastShare, (float)currentTimeSecs());
			IGT_Preference.getInstance()._Set(IGT_Constants.pendingFBShare, 1);
			fbShareTime = currentTimeSecs();
			canfbShare = false;
			isPendingfbShare = 1;
			IGT_Constants.fbText = " Processing ";
		}
	}

	private void ShareReqFailed()
	{
	}

	private void getFBFriendsListCompleted()
	{
		StartCoroutine(getProfilePic(ProPicDownloadSuccess, ProPicDownloadFailed));
		fbList = pFacebook.getFBFrndsList();
		listSendLife.Clear();
		foreach (KeyValuePair<string, FBFriendInfoList> fb in fbList)
		{
			if (!fb.Value.userName.Equals("Me"))
			{
				MailBoxAskSendInfo mailBoxAskSendInfo = new MailBoxAskSendInfo();
				mailBoxAskSendInfo.userID = fb.Key;
				mailBoxAskSendInfo.bCheckbox = false;
				listSendLife.Add(mailBoxAskSendInfo);
			}
		}
		listAskLife.Clear();
		foreach (KeyValuePair<string, FBFriendInfoList> fb2 in fbList)
		{
			if (!fb2.Value.userName.Equals("Me"))
			{
				MailBoxAskSendInfo mailBoxAskSendInfo2 = new MailBoxAskSendInfo();
				mailBoxAskSendInfo2.userID = fb2.Key;
				mailBoxAskSendInfo2.bCheckbox = false;
				listAskLife.Add(mailBoxAskSendInfo2);
			}
		}
	}

	private void getScoreFromInternet(int flag)
	{
		if (flag == 2 && bCanGetScoreFrmInternet)
		{
			return;
		}
		bool flag2 = false;
		bool flag3 = false;
		if ((flag == 0 || flag == 2) && pIGT_ScrollData_GameOver_Fb.Count == 0 && pIGT_ScrollData_GameOver_Topchase.Count == 0)
		{
			flag2 = true;
			flag3 = true;
		}
		if ((flag == 1 || flag == 2) && pIGT_ScrollData_MC_FbFriends.Count == 0 && pIGT_ScrollData_MC_FbGlobal.Count == 0)
		{
			flag3 = true;
			flag2 = true;
		}
		if (!flag2 && (flag == 0 || flag == 2) && (fLeaderBoard_Chase_LastUpdatedTime == 0f || Time.time - fLeaderBoard_Chase_LastUpdatedTime > 180f))
		{
			flag2 = true;
		}
		if (!flag3 && (flag == 1 || flag == 2) && (fLeaderBoard_Mission_LastUpdatedTime == 0f || Time.time - fLeaderBoard_Mission_LastUpdatedTime > 180f))
		{
			flag3 = true;
		}
		nLeaderBoard_Chase_DispState = (nLeaderBoard_Mission_DispState = 4);
		if (pHero.isConnectedInternet())
		{
			if (((flag == 0 || flag == 2) && !flag2) || ((flag == 1 || flag == 2) && !flag3))
			{
				LocalSorting_ScrollData(flag);
				nLeaderBoard_Chase_DispState = (nLeaderBoard_Mission_DispState = 2);
				return;
			}
			bCanGetScoreFrmInternet = true;
			fLoadingStrtTime = Time.time;
			nLeaderBoard_Chase_DispState = (nLeaderBoard_Mission_DispState = 0);
			if (pFacebook.isFBLoginSucess())
			{
				string text = string.Empty;
				string text2 = string.Empty;
				if (flag == 0 || flag == 2)
				{
					foreach (KeyValuePair<string, FBFriendInfoList> fb in fbList)
					{
						if (fb.Value.userName.Equals("Me"))
						{
							text2 = fb.Key;
							continue;
						}
						text += fb.Key;
						text += ",";
					}
					text += text2;
					formFrndChase.AddField("uid", text2);
					formFrndChase.AddField("mode", "6");
					formFrndChase.AddField("gametype", "0");
					formFrndChase.AddField("friendsid", text);
					formFrndChase.AddField("installid", "0");
					formFrndChase.AddField("lb", "0,1");
					StartCoroutine(pFacebook.getDatafromURL(sGameUrl, formFrndChase, "6", "0", getScoreFromInternet_Sucess_Chase, 0, getScoreFromInternet_Failed_Chase));
				}
				if (flag != 1 && flag != 2)
				{
					return;
				}
				text = string.Empty;
				text2 = string.Empty;
				foreach (KeyValuePair<string, FBFriendInfoList> fb2 in fbList)
				{
					if (fb2.Value.userName.Equals("Me"))
					{
						text2 = fb2.Key;
						continue;
					}
					text += fb2.Key;
					text += ",";
				}
				text += text2;
				formFrndMission.AddField("uid", text2);
				formFrndMission.AddField("mode", "6");
				formFrndMission.AddField("gametype", "1");
				formFrndMission.AddField("friendsid", text);
				formFrndMission.AddField("installid", "0");
				formFrndMission.AddField("lb", "0,1");
				StartCoroutine(pFacebook.getDatafromURL(sGameUrl, formFrndMission, "6", "1", getScoreFromInternet_Sucess_Mission, 0, getScoreFromInternet_Failed_Misison));
			}
			else
			{
				if (flag == 0 || flag == 2)
				{
					formTopWithMeChase.AddField("mode", "4");
					formTopWithMeChase.AddField("uid", "0");
					formTopWithMeChase.AddField("gametype", "0");
					formTopWithMeChase.AddField("installid", strDeviceID);
					StartCoroutine(pFacebook.getDatafromURL(sGameUrl, formTopWithMeChase, "4", "0", getScoreFromInternet_Sucess_Chase, 0, getScoreFromInternet_Failed_Chase));
				}
				if (flag == 1 || flag == 2)
				{
					formTopWithMeMission.AddField("mode", "4");
					formTopWithMeMission.AddField("uid", "0");
					formTopWithMeMission.AddField("gametype", "1");
					formTopWithMeMission.AddField("installid", strDeviceID);
					StartCoroutine(pFacebook.getDatafromURL(sGameUrl, formTopWithMeMission, "4", "1", getScoreFromInternet_Sucess_Mission, 0, getScoreFromInternet_Failed_Misison));
				}
			}
		}
		else
		{
			nLeaderBoard_Chase_DispState = (nLeaderBoard_Mission_DispState = 1);
		}
	}

	private void getScoreFromInternet_Sucess_Chase(int nCheck = 0)
	{
		StartCoroutine(copyScoreDatas_Chase(copyScoreDatas_Chase_Success));
	}

	private void getScoreFromInternet_Failed_Chase(int val = 0)
	{
		bCanGetScoreFrmInternet = false;
	}

	private void getScoreFromInternet_Sucess_Mission(int nCheck = 0)
	{
		StartCoroutine(copyScoreDatas_Mission(copyScoreDatas_Mission_Success));
	}

	private void getScoreFromInternet_Failed_Misison(int val = 0)
	{
		bCanGetScoreFrmInternet = false;
	}

	private void copyScoreDatas_Chase_Success(int flag)
	{
		nLeaderBoard_Chase_DispState = 2;
		bCanGetScoreFrmInternet = false;
		fLeaderBoard_Chase_LastUpdatedTime = Time.time;
		if (!pFacebook.isFBLoginSucess())
		{
			return;
		}
		for (int i = 0; i < pIGT_ScrollData_GameOver_Fb.Count; i++)
		{
			if (userProfilePicDict != null && pIGT_ScrollData_GameOver_Fb.ElementAt(i).Id != null && userProfilePicDict.ContainsKey(pIGT_ScrollData_GameOver_Fb.ElementAt(i).Id))
			{
				pIGT_ScrollData_GameOver_Fb.ElementAt(i).pTexture = (Texture2D)userProfilePicDict[pIGT_ScrollData_GameOver_Fb.ElementAt(i).Id];
			}
			else if (pFacebook.UserFrndsInfo.ContainsKey(pIGT_ScrollData_GameOver_Fb.ElementAt(i).Id))
			{
				byte[] userProfilePicData = pFacebook.UserFrndsInfo[pIGT_ScrollData_GameOver_Fb.ElementAt(i).Id].userProfilePicData;
				if (userProfilePicData != null)
				{
					Texture2D pTexture = new Texture2D(1, 1);
					pTexture.LoadImage(userProfilePicData);
					pIGT_ScrollData_GameOver_Fb.ElementAt(i).pTexture = pTexture;
				}
			}
		}
		for (int j = 0; j < pIGT_ScrollData_GameOver_Topchase.Count; j++)
		{
			if (long.Parse(pIGT_ScrollData_GameOver_Topchase.ElementAt(j).Id) < 1 || long.Parse(pIGT_ScrollData_GameOver_Topchase.ElementAt(j).Id) > 20)
			{
				StartCoroutine(pFacebook.getProfilePicture(pIGT_ScrollData_GameOver_Topchase.ElementAt(j).Id, pIGT_ScrollData_GameOver_Topchase.ElementAt(j).pTexture, j, pIGT_ScrollData_GameOver_Topchase.ElementAt(j).Name, chaseglobalimgsuccess));
			}
		}
	}

	private void copyScoreDatas_Mission_Success(int flag)
	{
		nLeaderBoard_Mission_DispState = 2;
		bCanGetScoreFrmInternet = false;
		fLeaderBoard_Mission_LastUpdatedTime = Time.time;
		if (pFacebook.isFBLoginSucess())
		{
			for (int i = 0; i < pIGT_ScrollData_MC_FbFriends.Count; i++)
			{
				if (userProfilePicDict != null && pIGT_ScrollData_MC_FbFriends.ElementAt(i).Id != null && userProfilePicDict.ContainsKey(pIGT_ScrollData_MC_FbFriends.ElementAt(i).Id))
				{
					pIGT_ScrollData_MC_FbFriends.ElementAt(i).pTexture = (Texture2D)userProfilePicDict[pIGT_ScrollData_MC_FbFriends.ElementAt(i).Id];
				}
				else if (pFacebook.Mission_Friends.ContainsKey(pIGT_ScrollData_MC_FbFriends.ElementAt(i).Id))
				{
					byte[] userProfilePicData = pFacebook.Mission_Friends[pIGT_ScrollData_MC_FbFriends.ElementAt(i).Id].userProfilePicData;
					if (userProfilePicData != null)
					{
						Texture2D pTexture = new Texture2D(1, 1);
						pTexture.LoadImage(userProfilePicData);
						pIGT_ScrollData_MC_FbFriends.ElementAt(i).pTexture = pTexture;
					}
				}
			}
			for (int j = 0; j < pIGT_ScrollData_MC_FbGlobal.Count; j++)
			{
				if (long.Parse(pIGT_ScrollData_MC_FbGlobal.ElementAt(j).Id) < 1 || long.Parse(pIGT_ScrollData_MC_FbGlobal.ElementAt(j).Id) > 100)
				{
					StartCoroutine(pFacebook.getProfilePicture(pIGT_ScrollData_MC_FbGlobal.ElementAt(j).Id, pIGT_ScrollData_MC_FbGlobal.ElementAt(j).pTexture, j, pIGT_ScrollData_MC_FbGlobal.ElementAt(j).Name, missionglobalimgsuccess));
				}
			}
		}
		LeaderBoardBasedAcheivementCompletionChecking();
	}

	private void LeaderBoardBasedAcheivementCompletionChecking()
	{
		string mEUserID = strDeviceID;
		if (pFacebook.isFBLoginSucess())
		{
			mEUserID = pFacebook.getMEUserID();
		}
		if ((IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQHw", 0) == 0 || IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQHg", 0) == 0) && pIGT_ScrollData_MC_FbGlobal != null && pIGT_ScrollData_MC_FbGlobal.Count > 0)
		{
			for (int i = 0; i < pIGT_ScrollData_MC_FbGlobal.Count; i++)
			{
				if (pIGT_ScrollData_MC_FbGlobal[i].Id == mEUserID)
				{
					if (int.Parse(pIGT_ScrollData_MC_FbGlobal[i].Rank) <= 10 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQHw", 0) == 0)
					{
						IGT_Achivements.completeAchivements(7, 10);
						break;
					}
					if (int.Parse(pIGT_ScrollData_MC_FbGlobal[i].Rank) <= 100 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQHg", 0) == 0)
					{
						IGT_Achivements.completeAchivements(7, 100);
						break;
					}
				}
			}
		}
		if (!pFacebook.isFBLoginSucess() || IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQHQ", 0) != 0 || pIGT_ScrollData_MC_FbFriends == null || pIGT_ScrollData_MC_FbFriends.Count < 5)
		{
			return;
		}
		for (int j = 0; j < pIGT_ScrollData_MC_FbFriends.Count; j++)
		{
			if (pIGT_ScrollData_MC_FbFriends[j].Id == pFacebook.getMEUserID() && int.Parse(pIGT_ScrollData_MC_FbFriends[j].Rank) <= 5 && IGT_Preference.getInstance()._Get("CgkInKbEoZQHEAIQHQ", 0) == 0)
			{
				IGT_Achivements.completeAchivements(7, 5);
				break;
			}
		}
	}

	public void missionglobalimgsuccess(int ival, byte[] data, string name)
	{
		Texture2D pTexture = new Texture2D(1, 1);
		pTexture.LoadImage(data);
		pIGT_ScrollData_MC_FbGlobal.ElementAt(ival).pTexture = pTexture;
		pIGT_ScrollData_MC_FbGlobal.ElementAt(ival).Name = name;
	}

	public void chaseglobalimgsuccess(int ival, byte[] data, string name)
	{
		Texture2D pTexture = new Texture2D(1, 1);
		pTexture.LoadImage(data);
		pIGT_ScrollData_GameOver_Topchase.ElementAt(ival).pTexture = pTexture;
		pIGT_ScrollData_GameOver_Topchase.ElementAt(ival).Name = name;
	}

	public static IEnumerator copyScoreDatas_Chase(Action<int> didFinishd)
	{
		yield return 0;
		pIGT_ScrollData_GameOver_Fb = new List<IGT_ScrollData>(4);
		pIGT_ScrollData_GameOver_Topchase = new List<IGT_ScrollData>(4);
		if (pFacebook.isFBLoginSucess())
		{
			string mEUserID = pFacebook.getMEUserID();
			IOrderedEnumerable<FBFriendInfoList> source = pFacebook.Chase_Friends.Values.OrderByDescending((FBFriendInfoList FBFriendInfoList) => FBFriendInfoList.userScore);
			List<string> list = new List<string>(pFacebook.Chase_Friends.Keys);
			for (int num = 0; num < 5; num++)
			{
				if (num >= list.Count)
				{
					continue;
				}
				if (pFacebook.Chase_Friends.ContainsKey(mEUserID))
				{
					if (pFacebook.Chase_Friends[mEUserID].rank <= 5 || pFacebook.Chase_Friends[mEUserID].userScore == 0)
					{
						if (pFacebook.Chase_Friends[source.ElementAt(num).userID].userScore != 0)
						{
							new Texture2D(100, 100);
							Texture2D texture2D = (Texture2D)Resources.Load(IGT_Constants.defaultFB);
							pIGT_ScrollData_GameOver_Fb.Add(new IGT_ScrollData(pFacebook.Chase_Friends[source.ElementAt(num).userID].userID, string.Empty + pFacebook.Chase_Friends[source.ElementAt(num).userID].rank, pFacebook.Chase_Friends[source.ElementAt(num).userID].userName, string.Empty + pFacebook.Chase_Friends[source.ElementAt(num).userID].userScore, texture2D));
						}
						continue;
					}
					if (num < 3)
					{
						new Texture2D(100, 100);
						Texture2D texture2D2 = (Texture2D)Resources.Load(IGT_Constants.defaultFB);
						pIGT_ScrollData_GameOver_Fb.Add(new IGT_ScrollData(pFacebook.Chase_Friends[source.ElementAt(num).userID].userID, string.Empty + pFacebook.Chase_Friends[source.ElementAt(num).userID].rank, pFacebook.Chase_Friends[source.ElementAt(num).userID].userName, string.Empty + pFacebook.Chase_Friends[source.ElementAt(num).userID].userScore, texture2D2));
						continue;
					}
					switch (num)
					{
					case 3:
					{
						for (int num2 = 3; num2 < list.Count; num2++)
						{
							if (pFacebook.Chase_Friends[mEUserID].rank - 1 == pFacebook.Chase_Friends[source.ElementAt(num2).userID].rank)
							{
								new Texture2D(100, 100);
								Texture2D texture2D4 = (Texture2D)Resources.Load(IGT_Constants.defaultFB);
								pIGT_ScrollData_GameOver_Fb.Add(new IGT_ScrollData(pFacebook.Chase_Friends[source.ElementAt(num2).userID].userID, string.Empty + pFacebook.Chase_Friends[source.ElementAt(num2).userID].rank, pFacebook.Chase_Friends[source.ElementAt(num2).userID].userName, string.Empty + pFacebook.Chase_Friends[source.ElementAt(num2).userID].userScore, texture2D4));
							}
						}
						break;
					}
					case 4:
					{
						new Texture2D(100, 100);
						Texture2D texture2D3 = (Texture2D)Resources.Load(IGT_Constants.defaultFB);
						pIGT_ScrollData_GameOver_Fb.Add(new IGT_ScrollData(mEUserID, string.Empty + pFacebook.Chase_Friends[mEUserID].rank, pFacebook.Chase_Friends[mEUserID].userName, string.Empty + pFacebook.Chase_Friends[mEUserID].userScore, texture2D3));
						break;
					}
					}
				}
				else
				{
					new Texture2D(100, 100);
					Texture2D texture2D5 = (Texture2D)Resources.Load(IGT_Constants.defaultFB);
					pIGT_ScrollData_GameOver_Fb.Add(new IGT_ScrollData(pFacebook.Chase_Friends[source.ElementAt(num).userID].userID, string.Empty + pFacebook.Chase_Friends[source.ElementAt(num).userID].rank, pFacebook.Chase_Friends[source.ElementAt(num).userID].userName, string.Empty + pFacebook.Chase_Friends[source.ElementAt(num).userID].userScore, texture2D5));
				}
			}
			if (pFacebook.Chase_Global != null && pFacebook.Chase_Global.Count > 0)
			{
				new List<string>(pFacebook.Chase_Global.Count);
				List<string> list2 = pFacebook.Chase_Global.Keys.ToList();
				for (int num3 = 0; num3 < 5; num3++)
				{
					if (num3 < list2.Count)
					{
						if (pFacebook.Chase_Global[list2[num3]].userName == null || pFacebook.Chase_Global[list2[num3]].userName.Equals(string.Empty))
						{
							pFacebook.Chase_Global[list2[num3]].userName = "Player";
						}
						if (long.Parse(pFacebook.Chase_Global[list2[num3]].userID) >= 1 && long.Parse(pFacebook.Chase_Global[list2[num3]].userID) <= 20)
						{
							pFacebook.Chase_Global[list2[num3]].userName = IGT_Constants.CHASE_GLOBAL_VIRTUAL_NAMES[long.Parse(pFacebook.Chase_Global[list2[num3]].userID) - 1];
						}
						new Texture2D(100, 100);
						Texture2D texture2D6 = (Texture2D)Resources.Load(IGT_Constants.defaultFB);
						pIGT_ScrollData_GameOver_Topchase.Add(new IGT_ScrollData(pFacebook.Chase_Global[list2[num3]].userID, string.Empty + pFacebook.Chase_Global[list2[num3]].rank, pFacebook.Chase_Global[list2[num3]].userName, string.Empty + pFacebook.Chase_Global[list2[num3]].userScore, texture2D6));
					}
				}
			}
		}
		else if (pFacebook.Chase_Global != null && pFacebook.Chase_Global.Count > 0)
		{
			new List<string>(pFacebook.Chase_Global.Count);
			List<string> list3 = pFacebook.Chase_Global.Keys.ToList();
			if (!strNickName.Equals(string.Empty) && list3.Contains(strDeviceID) && !strNickName.Equals(pFacebook.Chase_Global[strDeviceID].userName))
			{
				pFacebook.Chase_Global[strDeviceID].userName = strNickName;
			}
			for (int num4 = 0; num4 < 5; num4++)
			{
				if (num4 < list3.Count)
				{
					pIGT_ScrollData_GameOver_Topchase.Add(new IGT_ScrollData(pFacebook.Chase_Global[list3[num4]].userID, string.Empty + pFacebook.Chase_Global[list3[num4]].rank, pFacebook.Chase_Global[list3[num4]].userName, string.Empty + pFacebook.Chase_Global[list3[num4]].userScore, null));
				}
			}
		}
		didFinishd(0);
	}

	public static IEnumerator copyScoreDatas_Mission(Action<int> didFinishd)
	{
		yield return 0;
		pIGT_ScrollData_MC_FbFriends = new List<IGT_ScrollData>(4);
		pIGT_ScrollData_MC_FbGlobal = new List<IGT_ScrollData>(4);
		if (pFacebook.isFBLoginSucess())
		{
			string mEUserID = pFacebook.getMEUserID();
			IOrderedEnumerable<FBFriendInfoList> source = pFacebook.Mission_Friends.Values.OrderByDescending((FBFriendInfoList FBFriendInfoList) => FBFriendInfoList.userScore);
			List<string> list = new List<string>(pFacebook.Mission_Friends.Keys);
			for (int num = 0; num < 5; num++)
			{
				if (num >= list.Count)
				{
					continue;
				}
				if (pFacebook.Mission_Friends.ContainsKey(mEUserID))
				{
					if (pFacebook.Mission_Friends[mEUserID].rank <= 5 || pFacebook.Mission_Friends[mEUserID].userScore == 0)
					{
						if (pFacebook.Mission_Friends[source.ElementAt(num).userID].userScore != 0)
						{
							Texture2D texture2D = (Texture2D)Resources.Load(IGT_Constants.defaultFB);
							pIGT_ScrollData_MC_FbFriends.Add(new IGT_ScrollData(pFacebook.Mission_Friends[source.ElementAt(num).userID].userID, string.Empty + pFacebook.Mission_Friends[source.ElementAt(num).userID].rank, pFacebook.Mission_Friends[source.ElementAt(num).userID].userName, string.Empty + pFacebook.Mission_Friends[source.ElementAt(num).userID].userScore, texture2D));
						}
						continue;
					}
					if (num < 3)
					{
						Texture2D texture2D2 = (Texture2D)Resources.Load(IGT_Constants.defaultFB);
						pIGT_ScrollData_MC_FbFriends.Add(new IGT_ScrollData(pFacebook.Mission_Friends[source.ElementAt(num).userID].userID, string.Empty + pFacebook.Mission_Friends[source.ElementAt(num).userID].rank, pFacebook.Mission_Friends[source.ElementAt(num).userID].userName, string.Empty + pFacebook.Mission_Friends[source.ElementAt(num).userID].userScore, texture2D2));
						continue;
					}
					switch (num)
					{
					case 3:
					{
						for (int num2 = 3; num2 < list.Count; num2++)
						{
							if (pFacebook.Mission_Friends[mEUserID].rank - 1 == pFacebook.Mission_Friends[source.ElementAt(num2).userID].rank)
							{
								Texture2D texture2D4 = (Texture2D)Resources.Load(IGT_Constants.defaultFB);
								pIGT_ScrollData_MC_FbFriends.Add(new IGT_ScrollData(pFacebook.Mission_Friends[source.ElementAt(num2).userID].userID, string.Empty + pFacebook.Mission_Friends[source.ElementAt(num2).userID].rank, pFacebook.Mission_Friends[source.ElementAt(num2).userID].userName, string.Empty + pFacebook.Mission_Friends[source.ElementAt(num2).userID].userScore, texture2D4));
							}
						}
						break;
					}
					case 4:
					{
						Texture2D texture2D3 = (Texture2D)Resources.Load(IGT_Constants.defaultFB);
						pIGT_ScrollData_MC_FbFriends.Add(new IGT_ScrollData(mEUserID, string.Empty + pFacebook.Mission_Friends[mEUserID].rank, pFacebook.Mission_Friends[mEUserID].userName, string.Empty + pFacebook.Mission_Friends[mEUserID].userScore, texture2D3));
						break;
					}
					}
				}
				else
				{
					Texture2D texture2D5 = (Texture2D)Resources.Load(IGT_Constants.defaultFB);
					pIGT_ScrollData_MC_FbFriends.Add(new IGT_ScrollData(pFacebook.Mission_Friends[source.ElementAt(num).userID].userID, string.Empty + pFacebook.Mission_Friends[source.ElementAt(num).userID].rank, pFacebook.Mission_Friends[source.ElementAt(num).userID].userName, string.Empty + pFacebook.Mission_Friends[source.ElementAt(num).userID].userScore, texture2D5));
				}
			}
			if (pFacebook.Mission_Global != null && pFacebook.Mission_Global.Count > 0)
			{
				List<string> list2 = new List<string>(pFacebook.Mission_Global.Keys);
				for (int num3 = 0; num3 < 5; num3++)
				{
					if (num3 < list2.Count)
					{
						if (pFacebook.Mission_Global[list2[num3]].userName == null || pFacebook.Mission_Global[list2[num3]].userName.Equals(string.Empty))
						{
							pFacebook.Mission_Global[list2[num3]].userName = "Player";
						}
						if (long.Parse(pFacebook.Mission_Global[list2[num3]].userID) >= 1 && long.Parse(pFacebook.Mission_Global[list2[num3]].userID) <= 100)
						{
							pFacebook.Mission_Global[list2[num3]].userName = IGT_Constants.MISSION_GLOBAL_VIRTUAL_NAMES[long.Parse(pFacebook.Mission_Global[list2[num3]].userID) - 1];
						}
						Texture2D texture2D6 = (Texture2D)Resources.Load(IGT_Constants.defaultFB);
						pIGT_ScrollData_MC_FbGlobal.Add(new IGT_ScrollData(pFacebook.Mission_Global[list2[num3]].userID, string.Empty + pFacebook.Mission_Global[list2[num3]].rank, pFacebook.Mission_Global[list2[num3]].userName, string.Empty + pFacebook.Mission_Global[list2[num3]].userScore, texture2D6));
					}
				}
			}
		}
		else if (pFacebook.Mission_Global != null && pFacebook.Mission_Global.Count > 0)
		{
			new List<string>(pFacebook.Mission_Global.Count);
			List<string> list3 = pFacebook.Mission_Global.Keys.ToList();
			if (!strNickName.Equals(string.Empty) && list3.Contains(strDeviceID) && !strNickName.Equals(pFacebook.Mission_Global[strDeviceID].userName))
			{
				pFacebook.Mission_Global[strDeviceID].userName = strNickName;
			}
			for (int num4 = 0; num4 < 5; num4++)
			{
				if (num4 < list3.Count)
				{
					pIGT_ScrollData_MC_FbGlobal.Add(new IGT_ScrollData(pFacebook.Mission_Global[list3[num4]].userID, string.Empty + pFacebook.Mission_Global[list3[num4]].rank, pFacebook.Mission_Global[list3[num4]].userName, string.Empty + pFacebook.Mission_Global[list3[num4]].userScore, null));
				}
			}
		}
		didFinishd(0);
	}

	private void LocalSorting_ScrollData(int nVal)
	{
		string mEUserID = strDeviceID;
		if (pFacebook.isFBLoginSucess())
		{
			mEUserID = pFacebook.getMEUserID();
		}
		int num = 0;
		if (nVal == 0 || nVal == 2)
		{
			num = 0;
			if (pIGT_ScrollData_GameOver_Fb != null)
			{
				num = pIGT_ScrollData_GameOver_Fb.Count;
			}
			for (int i = 0; i < num; i++)
			{
				if (mEUserID == pIGT_ScrollData_GameOver_Fb[i].Id)
				{
					pIGT_ScrollData_GameOver_Fb[i].Score = pHero.nHigh_Score_Chase.ToString();
					SelectionSort(ref pIGT_ScrollData_GameOver_Fb);
					break;
				}
			}
			num = 0;
			if (pIGT_ScrollData_GameOver_Topchase != null)
			{
				num = pIGT_ScrollData_GameOver_Topchase.Count;
			}
			for (int j = 0; j < num; j++)
			{
				if (mEUserID == pIGT_ScrollData_GameOver_Topchase[j].Id)
				{
					pIGT_ScrollData_GameOver_Topchase[j].Score = pHero.nHigh_Score_Chase.ToString();
					SelectionSort(ref pIGT_ScrollData_GameOver_Topchase);
					break;
				}
			}
			for (int k = 0; k < num; k++)
			{
				if (mEUserID == pIGT_ScrollData_GameOver_Topchase[k].Id && int.Parse(pIGT_ScrollData_GameOver_Topchase[k].Rank) <= 5)
				{
					pFacebook.bGlobalTop5inChase = true;
					break;
				}
			}
		}
		if (nVal == 1 || nVal == 2)
		{
			num = 0;
			if (pIGT_ScrollData_MC_FbFriends != null)
			{
				num = pIGT_ScrollData_MC_FbFriends.Count;
			}
			for (int l = 0; l < num; l++)
			{
				if (mEUserID == pIGT_ScrollData_MC_FbFriends[l].Id)
				{
					pIGT_ScrollData_MC_FbFriends[l].Score = pHero.nTotScore_Mission.ToString();
					SelectionSort(ref pIGT_ScrollData_MC_FbFriends);
					break;
				}
			}
			num = 0;
			if (pIGT_ScrollData_MC_FbGlobal != null)
			{
				num = pIGT_ScrollData_MC_FbGlobal.Count;
			}
			for (int m = 0; m < num; m++)
			{
				if (mEUserID == pIGT_ScrollData_MC_FbGlobal[m].Id)
				{
					pIGT_ScrollData_MC_FbGlobal[m].Score = pHero.nTotScore_Mission.ToString();
					SelectionSort(ref pIGT_ScrollData_MC_FbGlobal);
					break;
				}
			}
			for (int n = 0; n < num; n++)
			{
				if (mEUserID == pIGT_ScrollData_MC_FbGlobal[n].Id && int.Parse(pIGT_ScrollData_MC_FbGlobal[n].Rank) <= 5)
				{
					pFacebook.bGlobalTop5inMission = true;
					break;
				}
			}
		}
		LeaderBoardBasedAcheivementCompletionChecking();
	}

	private void SelectionSort(ref List<IGT_ScrollData> ScrollList)
	{
		IGT_ScrollData iGT_ScrollData = null;
		int num = -1;
		string mEUserID = strDeviceID;
		if (pFacebook.isFBLoginSucess())
		{
			mEUserID = pFacebook.getMEUserID();
		}
		for (int i = 0; i < ScrollList.Count; i++)
		{
			if (ScrollList[i].Id == mEUserID)
			{
				num = i;
				iGT_ScrollData = ScrollList[i];
				break;
			}
		}
		if (num == -1)
		{
			return;
		}
		int index = num;
		for (int num2 = num - 1; num2 >= 0; num2--)
		{
			if (int.Parse(iGT_ScrollData.Score) > int.Parse(ScrollList[num2].Score))
			{
				IGT_ScrollData iGT_ScrollData2 = ScrollList[num2];
				string rank = iGT_ScrollData2.Rank;
				iGT_ScrollData2.Rank = iGT_ScrollData.Rank;
				iGT_ScrollData.Rank = rank;
				ScrollList[num2] = iGT_ScrollData;
				ScrollList[index] = iGT_ScrollData2;
				index = num2;
			}
		}
		int num3 = -1;
		for (int j = 0; j < ScrollList.Count; j++)
		{
			if (ScrollList[j].Id == mEUserID)
			{
				num3 = j;
				break;
			}
		}
		if (num3 == -1 || num3 >= 3)
		{
			return;
		}
		int num4 = 1;
		for (int k = 0; k < ScrollList.Count; k++)
		{
			if (k > num3)
			{
				ScrollList[k].Rank = (int.Parse(ScrollList[num3].Rank) + num4).ToString();
				num4++;
			}
		}
	}

	public IEnumerator getLBScoreFromURL(int mode = 10, int nCheck = 0)
	{
		yield return new WaitForSeconds(0f);
		switch (mode)
		{
		case 0:
			StartCoroutine(getChaseFrrndScore(nCheck));
			yield break;
		case 1:
			StartCoroutine(getMissonsFrrndScore(nCheck));
			yield break;
		case 2:
			StartCoroutine(getChaseFrrndScore(nCheck));
			StartCoroutine(getMissonsFrrndScore(nCheck));
			dLBUpdateTimeDiff = Time.time;
			yield break;
		}
		if ((double)Time.time >= dLBUpdateTimeDiff + 180.0)
		{
			StartCoroutine(getChaseFrrndScore(nCheck));
			StartCoroutine(getMissonsFrrndScore(nCheck));
			dLBUpdateTimeDiff = Time.time;
		}
	}

	private IEnumerator getChaseFrrndScore(int nCheck = 0)
	{
		yield return new WaitForSeconds(0f);
		if (!pHero.isConnectedInternet())
		{
			yield break;
		}
		if (pFacebook.isFBLoginSucess())
		{
			string text = string.Empty;
			string text2 = string.Empty;
			foreach (KeyValuePair<string, FBFriendInfoList> fb in fbList)
			{
				if (fb.Value.userName.Equals("Me"))
				{
					text2 = fb.Key;
					continue;
				}
				text += fb.Key;
				text += ",";
			}
			text += text2;
			formFrndChase.AddField("uid", text2);
			formFrndChase.AddField("mode", "6");
			formFrndChase.AddField("gametype", "0");
			formFrndChase.AddField("friendsid", text);
			formFrndChase.AddField("installid", "0");
			formFrndChase.AddField("lb", "0,1");
			StartCoroutine(pFacebook.getDatafromURL(sGameUrl, formFrndChase, "6", "0", getUrlDataReceivedSucess, nCheck));
		}
		else
		{
			formTopWithMeChase.AddField("mode", "4");
			formTopWithMeChase.AddField("uid", "0");
			formTopWithMeChase.AddField("gametype", "0");
			formTopWithMeChase.AddField("installid", strDeviceID);
			StartCoroutine(pFacebook.getDatafromURL(sGameUrl, formTopWithMeChase, "4", "0", getUrlDataReceivedSucess, nCheck));
		}
	}

	private IEnumerator getMissonsFrrndScore(int nCheck = 0)
	{
		yield return new WaitForSeconds(0f);
		if (!pHero.isConnectedInternet())
		{
			yield break;
		}
		if (pFacebook.isFBLoginSucess())
		{
			string text = string.Empty;
			string text2 = string.Empty;
			foreach (KeyValuePair<string, FBFriendInfoList> fb in fbList)
			{
				if (fb.Value.userName.Equals("Me"))
				{
					text2 = fb.Key;
					continue;
				}
				text += fb.Key;
				text += ",";
			}
			text += text2;
			formFrndMission.AddField("uid", text2);
			formFrndMission.AddField("mode", "6");
			formFrndMission.AddField("gametype", "1");
			formFrndMission.AddField("friendsid", text);
			formFrndMission.AddField("installid", "0");
			formFrndMission.AddField("lb", "0,1");
			StartCoroutine(pFacebook.getDatafromURL(sGameUrl, formFrndMission, "6", "1", getUrlDataReceivedSucess, nCheck));
		}
		else
		{
			formTopWithMeMission.AddField("mode", "4");
			formTopWithMeMission.AddField("uid", "0");
			formTopWithMeMission.AddField("gametype", "1");
			formTopWithMeMission.AddField("installid", strDeviceID);
			StartCoroutine(pFacebook.getDatafromURL(sGameUrl, formTopWithMeMission, "4", "1", getUrlDataReceivedSucess, nCheck));
		}
	}

	private void postScoreURL(int currLevel, int userCurrentScore, int gametype)
	{
		bool flag = false;
		if (strDeviceID == null)
		{
			strDeviceID = getDeviceID();
		}
		if (pFacebook.isFBLoginSucess())
		{
			string mEUserID = pFacebook.getMEUserID();
			if (mEUserID != null)
			{
				switch (gametype)
				{
				case 0:
					if (pFacebook.UserFrndsInfo != null && pFacebook.Chase_Friends.ContainsKey(mEUserID) && userCurrentScore > 0 && pFacebook.Chase_Friends[mEUserID].userScore <= userCurrentScore)
					{
						flag = true;
						if (pFacebook.Chase_Friends[mEUserID].userScore <= 0)
						{
							fLeaderBoard_Chase_LastUpdatedTime = (fLeaderBoard_Mission_LastUpdatedTime = 0f);
						}
					}
					else if (pFacebook.UserFrndsInfo != null && userCurrentScore > 0 && !pFacebook.Chase_Friends.ContainsKey(mEUserID))
					{
						flag = true;
						fLeaderBoard_Chase_LastUpdatedTime = (fLeaderBoard_Mission_LastUpdatedTime = 0f);
					}
					break;
				case 1:
					if (pFacebook.Mission_Friends != null && pFacebook.Mission_Friends.ContainsKey(mEUserID) && userCurrentScore > 0 && pFacebook.Mission_Friends[mEUserID].userScore <= userCurrentScore)
					{
						flag = true;
						if (pFacebook.Mission_Friends[mEUserID].userScore <= 0)
						{
							fLeaderBoard_Chase_LastUpdatedTime = (fLeaderBoard_Mission_LastUpdatedTime = 0f);
						}
					}
					else if (pFacebook.Mission_Friends != null && userCurrentScore > 0 && !pFacebook.Mission_Friends.ContainsKey(mEUserID))
					{
						flag = true;
						fLeaderBoard_Chase_LastUpdatedTime = (fLeaderBoard_Mission_LastUpdatedTime = 0f);
					}
					break;
				}
				if (mEUserID != null && flag)
				{
					WWWForm wWWForm = new WWWForm();
					wWWForm.AddField("uid", mEUserID);
					wWWForm.AddField("installid", strDeviceID);
					wWWForm.AddField("name", strNickName);
					wWWForm.AddField("mode", "2");
					wWWForm.AddField("gametype", string.Empty + gametype);
					wWWForm.AddField("score", string.Empty + userCurrentScore);
					wWWForm.AddField("complevels", string.Empty + currLevel);
					wWWForm.AddField("crc", string.Empty + CRC(mEUserID + userCurrentScore + currLevel + "igtstreetchaser43554948"));
					StartCoroutine(pFacebook.getDatafromURL(sGameUrl, wWWForm, "2", string.Empty + gametype, PostDataSucess, 0, PostData_Failed));
				}
			}
		}
		else
		{
			switch (gametype)
			{
			case 0:
				if (pFacebook.Chase_Global != null && pFacebook.Chase_Global.ContainsKey(strDeviceID) && userCurrentScore > 0 && pFacebook.Chase_Global[strDeviceID].userScore <= userCurrentScore)
				{
					flag = true;
				}
				else if (pFacebook.Chase_Global != null && !pFacebook.Chase_Global.ContainsKey(strDeviceID))
				{
					flag = true;
				}
				break;
			case 1:
				if (pFacebook.Mission_Global != null && pFacebook.Mission_Global.ContainsKey(strDeviceID) && userCurrentScore > 0 && pFacebook.Mission_Global[strDeviceID].userScore <= userCurrentScore)
				{
					flag = true;
				}
				else if (pFacebook.Mission_Global != null && !pFacebook.Mission_Global.ContainsKey(strDeviceID))
				{
					flag = true;
				}
				break;
			}
			if (flag)
			{
				WWWForm wWWForm2 = new WWWForm();
				wWWForm2.AddField("uid", "0");
				wWWForm2.AddField("installid", strDeviceID);
				wWWForm2.AddField("name", strNickName);
				wWWForm2.AddField("mode", "2");
				wWWForm2.AddField("gametype", string.Empty + gametype);
				wWWForm2.AddField("score", string.Empty + userCurrentScore);
				wWWForm2.AddField("complevels", string.Empty + currLevel);
				wWWForm2.AddField("crc", string.Empty + CRC(strDeviceID + userCurrentScore + currLevel + "igtstreetchaser43554948"));
				StartCoroutine(pFacebook.getDatafromURL(sGameUrl, wWWForm2, "2", string.Empty + gametype, PostDataSucess, 0, PostData_Failed));
			}
		}
		if (!flag)
		{
			if (userCurrentScore <= 0)
			{
				getScoreFromInternet(2);
				return;
			}
			LocalSorting_ScrollData(gametype);
			nLeaderBoard_Chase_DispState = (nLeaderBoard_Mission_DispState = 2);
		}
	}

	private void PostDataSucess(int type = 0)
	{
		getScoreFromInternet(type);
	}

	private void PostData_Failed(int type = 0)
	{
		getScoreFromInternet(type);
	}

	public static long CRC(string str)
	{
		long num = 65521L;
		long num2 = 1L;
		long num3 = 0L;
		int length = str.Length;
		for (int i = 0; i < length; i++)
		{
			long num4 = (int)str[i];
			num2 = (num2 + num4) % num;
			num3 = (num3 + num2) % num;
		}
		return (num3 << 16) | num2;
	}

	private void getUrlDataReceivedSucess(int nCheck = 0)
	{
	}

	private void getFBFriendsListEmpty()
	{
	}

	private void loadFBFriendsPicSucess()
	{
		setFBPicDataRef();
		FBFriendInfoList fBFriendInfoList = new FBFriendInfoList();
		fBFriendInfoList.userID = pFacebook.getMEUserID();
		if (pFacebook.Chase_Friends != null && !pFacebook.Chase_Friends.ContainsKey(fBFriendInfoList.userID))
		{
			pFacebook.Chase_Friends.Add(fBFriendInfoList.userID, fBFriendInfoList);
		}
		if (pFacebook.Mission_Friends != null && !pFacebook.Mission_Friends.ContainsKey(fBFriendInfoList.userID))
		{
			pFacebook.Mission_Friends.Add(fBFriendInfoList.userID, fBFriendInfoList);
		}
		fLoadingStrtTime = Time.time;
		fLeaderBoard_Chase_LastUpdatedTime = (fLeaderBoard_Mission_LastUpdatedTime = 0f);
		postScoreURL(1, pHero.nHigh_Score_Chase, 0);
		postScoreURL(pHero.nMissionID, pHero.nTotScore_Mission, 1);
	}

	private void loadFBFriendsPicFailed()
	{
	}

	private void setFBPicDataRef()
	{
		if (pFacebook.UserFrndsInfo.Count <= 0)
		{
			return;
		}
		foreach (KeyValuePair<string, FBFriendInfoList> item in pFacebook.UserFrndsInfo)
		{
			pIgt_Textures.forceLoadTextureByData(item.Value.userProfilePicData, item.Key);
		}
	}

	public static void homeScreenButtonEvents()
	{
		setScreenMode(0);
		pHero.ReducingPlayerAlphaWhileUsingUseKey(true);
		pHero.Chase_RobbScene_DataSel();
	}

	private static void Chase_ButtonEvents()
	{
		IGT_Hero.bStrtButton = true;
		IGT_Hero.bPauseButton = false;
		IGT_Hero.bMissionIntro = true;
		IGT_Hero.fdist_robbingscene = 0f;
		IGT_Hero.fTime_robbScene = 0f;
		IGT_Hero.fTime_CamJoint = 0f;
		pHero.ChasingMode_AIPlayerInfoSel(0);
		setScreenMode(20);
		pHero.pIgtCamControl.pCamFollow.pAnim.resetAllValues();
		pHero.nGameMode = 0;
		pHero.setLevelData();
		pHero.InvokeRepeating("StopMusicWithFade", 0f, 0.1f);
	}

	public static void mission_ButtonEvents(int buttonID)
	{
		pHero.nGameMode = 1;
		if (buttonID < pHero.nTutorialLevelCount - 2)
		{
			pHero.Chase_RobbScene_DataSel();
			IGT_Hero.fdist_robbingscene = 0f;
			IGT_Hero.fTime_robbScene = 0f;
			IGT_Hero.fTime_CamJoint = 0f;
			pHero.pMissionData.nMissionType = -1;
			pHero.nMissionID = buttonID;
			IGT_Hero.bMissionIntro = false;
			switch (pHero.nMissionID)
			{
			case 0:
				pMissionInfo_TextureName = "Null";
				MissionInfo = " LEARN TO CHASE ";
				break;
			case 1:
				MissionInfo = " THROW 2 BOTTLES ";
				pMissionInfo_TextureName = IGT_Constants._Bottle;
				pHero.pMissionData.nTargetCount = 2;
				break;
			case 2:
				MissionInfo = " KICK 2 BALLS ";
				pMissionInfo_TextureName = IGT_Constants._Ball;
				pHero.pMissionData.nTargetCount = 2;
				break;
			}
			pHero.pIgtCamControl.pCamFollow.pAnim.resetAllValues();
			pHero.ChasingMode_AIPlayerInfoSel(pHero.nTutorialAIindex[pHero.nMissionID]);
		}
		else
		{
			IGT_Hero.bRobbingSceneFinished = true;
			IGT_Hero.bAIplayerStart = true;
			IGT_Hero.bMissionIntro = false;
		}
		pHero.setLevelData(buttonID);
		IGT_Hero.bStrtButton = true;
		IGT_Hero.bPauseButton = false;
		set_MissionInfoScreenData();
	}

	public static void mapBackButtonEvents()
	{
		pMapObj.destroyMapBtnObjs();
		homeScreenButtonEvents();
	}

	public static void pauseButtonEvents()
	{
		IGT_Hero.bPauseButton = true;
		pHero.bCanResume = false;
		setScreenMode(2);
		IGT_Constants.fPauseScreenStrtTime = Time.time;
		IGT_AnimStatesCntrler.HeroAnimator.StartPlayback();
		if (pHero.isAIplayerAvailable)
		{
			IGT_AIPlayer.pAIPlayerAnimController.AIHeroAnimator.StartPlayback();
		}
		if (pHero.isSurpriseAiAvailable)
		{
			IGT_SurpriseAIplayer.surpriseAIAnimator.StartPlayback();
		}
		pHero.isPausedSounds(true);
	}

	public static void freezeGame(bool flag)
	{
		if (flag)
		{
			IGT_Hero.bPauseButton = true;
			pHero.bCanResume = false;
			IGT_AnimStatesCntrler.HeroAnimator.StartPlayback();
			if (pHero.isAIplayerAvailable)
			{
				IGT_AIPlayer.pAIPlayerAnimController.AIHeroAnimator.StartPlayback();
			}
			if (pHero.isSurpriseAiAvailable)
			{
				IGT_SurpriseAIplayer.surpriseAIAnimator.StartPlayback();
			}
			pHero.isPausedSounds(true);
		}
		else
		{
			IGT_Hero.bPauseButton = false;
			IGT_AnimStatesCntrler.HeroAnimator.StopPlayback();
			if (pHero.isAIplayerAvailable)
			{
				IGT_AIPlayer.pAIPlayerAnimController.AIHeroAnimator.StopPlayback();
			}
			if (pHero.isSurpriseAiAvailable)
			{
				IGT_SurpriseAIplayer.surpriseAIAnimator.StopPlayback();
			}
			pHero.isPausedSounds(false);
		}
	}

	public static void ResumeButtonEvents()
	{
		setScreenMode(8);
		nCountDownNum = 3.0;
		pHero.bCanResume = true;
		pHero.playSound(30);
		IGT_Constants.fResumeCountDownStartTime = Time.time;
	}

	public static void settingCloseButEvents()
	{
		pAnim_HS_menuBG.resetAllValues();
		pAnim_HS_menuBG.setIsReverse(true);
	}

	public static void exitAlertCloseButEvents()
	{
		if (pAnim_Alert.isAnimFinished())
		{
			pAnim_Alert.resetAllValues();
			pAnim_Alert.setIsReverse(true);
		}
	}

	public static void NoInternetAlertOkButtonEvents()
	{
		if (pAnim_NoInternet.isAnimFinished())
		{
			pAnim_NoInternet.resetAllValues();
			pAnim_NoInternet.setIsReverse(true);
		}
	}

	public static void abortAlertCloseButEvents()
	{
		if (pAnim_MissionCompleted_star2.isAnimFinished() && pAnim_MissionCompleted_star3.isAnimFinished())
		{
			pAnim_MissionCompleted_star2.resetAllValues();
			pAnim_MissionCompleted_star2.setIsReverse(true);
			pAnim_MissionCompleted_star3.resetAllValues();
			pAnim_MissionCompleted_star3.setIsReverse(true);
		}
	}

	public static void NoMoLiveAlertScreen()
	{
		if (!bNoMoreLiveAlert)
		{
			bNoMoreLiveAlert = true;
			pAnim_Alert.resetAllValues();
			But_NoLives_Close.ResetAnimationDatas();
			But_NoLives_AskFriends.ResetAnimationDatas();
			But_NoLives_GetFree.ResetAnimationDatas();
			But_NoLives_Purchase2.ResetAnimationDatas();
			But_NoLives_Purchase1.ResetAnimationDatas();
			But_NoLives_Purchase3.ResetAnimationDatas();
			pHero.post_Analytics_Popup("NoMoreLives");
		}
	}

	public static void setNoInternetAlert()
	{
		if (!bNoInternetAlert)
		{
			bNoInternetAlert = true;
			pAnim_NoInternet.resetAllValues();
			But_NoInternetAlertOK.ResetAnimationDatas();
		}
	}

	public static void surviveCloseButEvents()
	{
		IGT_Hero.bLevelFailed = true;
		IGT_AnimStatesCntrler.nGameOverAnimFinshd = 0;
	}

	public static void set_MissionInfoScreenData()
	{
		setScreenMode(7);
		pAnim_menu_LeaderBoard.resetAllValues();
		bShowMissionTapToContinue = false;
	}

	private bool canPlayGameUsingLife()
	{
		if (pHero.pIGt_LifeCalc.getCurrentLifeCount() > 0)
		{
			return true;
		}
		return false;
	}

	public void OnScroll(float x, float y)
	{
		if (nScreenMode == 6)
		{
			purchaseWindow_CurPos.y += IGT_UIcommonFunc.reScaleY(y);
		}
		else if (nScreenMode == 5 && nGameoverScrollType == 2)
		{
			GameoverScroll_CurPos.y += IGT_UIcommonFunc.reScaleY(y);
		}
		else if (bHS_mailbox)
		{
			MailBoxScroll_CurPos.y += IGT_UIcommonFunc.reScaleY(y);
		}
		else if (bHS_sendlife)
		{
			SendLifeScroll_CurPos.y += IGT_UIcommonFunc.reScaleY(y);
		}
		else if (bHS_asklife)
		{
			AskLifeScroll_CurPos.y += IGT_UIcommonFunc.reScaleY(y);
		}
	}

	public void OnFling(float x, float y, float velocityX, float velocityY)
	{
		if (nScreenMode == 6)
		{
			int num = 0;
			switch (nPurchaseType)
			{
			case 0:
				num = pHero.pPurchaseItemsData_Store.Count;
				break;
			case 1:
				num = pHero.pPurchaseItemsData_Deals.Count;
				break;
			case 2:
				num = pHero.pPurchaseItemsData_Boost.Count;
				break;
			case 3:
				num = pHero.pPurchaseItemsData_Free.Count;
				break;
			}
			purchaseWindow_ScrollviwRectMaxY = purchaseWindow_BarStrtPosY;
			purchaseWindow_ScrollviewRectMinY = ScrollViewRect_purchaseWindow.y + ScrollViewRect_purchaseWindow.height - (float)num * (purchaseWindow_BarHeight + purchaseWindow_BarGap) - (ScrollViewRect_purchaseWindow.y + purchaseWindow_BarStrtPosY);
			pScroller_PuchaseWindow.fling(0f, IGT_UIcommonFunc.ScaleY(purchaseWindow_CurPos.y), 0f, velocityY, 0f, 0f, purchaseWindow_ScrollviewRectMinY, purchaseWindow_ScrollviwRectMaxY);
		}
		else if (nScreenMode == 5 && nGameoverScrollType == 2)
		{
			GameoverScroll_ScrollviwRectMaxY = GameoverScroll_BarStrtPosY;
			GameoverScroll_ScrollviewRectMinY = ScrollViewRect_GameoverScreen.y + ScrollViewRect_GameoverScreen.height - (float)nBustedScrollCount * (GameoverScroll_BarHeight + GameoverScroll_BarGap_Busted) - (ScrollViewRect_GameoverScreen.y + GameoverScroll_BarStrtPosY);
			pScroller_GameoverScroll.fling(0f, IGT_UIcommonFunc.ScaleY(GameoverScroll_CurPos.y), 0f, velocityY, 0f, 0f, GameoverScroll_ScrollviewRectMinY, GameoverScroll_ScrollviwRectMaxY);
		}
		else if (bHS_mailbox)
		{
			int count = listAskSend.Count;
			MailBoxScroll_ScrollviwRectMaxY = MailBoxScroll_BarStrtPosY;
			MailBoxScroll_ScrollviewRectMinY = ScrollViewRect_MailBoxScroll.y + ScrollViewRect_MailBoxScroll.height - (float)count * (MailBoxScroll_BarHeight + MailBoxScroll_BarGap) - (ScrollViewRect_MailBoxScroll.y + MailBoxScroll_BarStrtPosY);
			pScroller_MailBoxScroll.fling(0f, IGT_UIcommonFunc.ScaleY(MailBoxScroll_CurPos.y), 0f, velocityY, 0f, 0f, MailBoxScroll_ScrollviewRectMinY, MailBoxScroll_ScrollviwRectMaxY);
		}
		else if (bHS_sendlife)
		{
			int num2 = fbList.Count - 1;
			SendLifeScroll_ScrollviwRectMaxY = SendLifeScroll_BarStrtPosY;
			SendLifeScroll_ScrollviewRectMinY = ScrollViewRect_SendLifeScroll.y + ScrollViewRect_SendLifeScroll.height - (float)num2 * (SendLifeScroll_BarHeight + SendLifeScroll_BarGap) - (ScrollViewRect_SendLifeScroll.y + SendLifeScroll_BarStrtPosY);
			pScroller_SendLifeScroll.fling(0f, IGT_UIcommonFunc.ScaleY(SendLifeScroll_CurPos.y), 0f, velocityY, 0f, 0f, SendLifeScroll_ScrollviewRectMinY, SendLifeScroll_ScrollviwRectMaxY);
		}
		else if (bHS_asklife)
		{
			int num3 = fbList.Count - 1;
			AskLifeScroll_ScrollviwRectMaxY = AskLifeScroll_BarStrtPosY;
			AskLifeScroll_ScrollviewRectMinY = ScrollViewRect_AskLifeScroll.y + ScrollViewRect_AskLifeScroll.height - (float)num3 * (AskLifeScroll_BarHeight + AskLifeScroll_BarGap) - (ScrollViewRect_AskLifeScroll.y + AskLifeScroll_BarStrtPosY);
			pScroller_AskLifeScroll.fling(0f, IGT_UIcommonFunc.ScaleY(AskLifeScroll_CurPos.y), 0f, velocityY, 0f, 0f, AskLifeScroll_ScrollviewRectMinY, AskLifeScroll_ScrollviwRectMaxY);
		}
	}

	public void OnViewRectBounceChecking()
	{
		if (nScreenMode == 6)
		{
			int num = 0;
			switch (nPurchaseType)
			{
			case 0:
				num = pHero.pPurchaseItemsData_Store.Count;
				break;
			case 1:
				num = pHero.pPurchaseItemsData_Deals.Count;
				break;
			case 2:
				num = pHero.pPurchaseItemsData_Boost.Count;
				break;
			case 3:
				num = pHero.pPurchaseItemsData_Free.Count;
				break;
			}
			purchaseWindow_ScrollviwRectMaxY = purchaseWindow_BarStrtPosY;
			purchaseWindow_ScrollviewRectMinY = ScrollViewRect_purchaseWindow.y + ScrollViewRect_purchaseWindow.height - (float)num * (purchaseWindow_BarHeight + purchaseWindow_BarGap) - (ScrollViewRect_purchaseWindow.y + purchaseWindow_BarStrtPosY);
			pScroller_PuchaseWindow.checkOutOfEdge(0f, IGT_UIcommonFunc.ScaleY(purchaseWindow_CurPos.y), 0f, 0f, purchaseWindow_ScrollviewRectMinY, purchaseWindow_ScrollviwRectMaxY);
		}
		else if (nScreenMode == 5 && nGameoverScrollType == 2)
		{
			GameoverScroll_ScrollviwRectMaxY = GameoverScroll_BarStrtPosY;
			GameoverScroll_ScrollviewRectMinY = ScrollViewRect_GameoverScreen.y + ScrollViewRect_GameoverScreen.height - (float)nBustedScrollCount * (GameoverScroll_BarHeight + GameoverScroll_BarGap_Busted) - (ScrollViewRect_GameoverScreen.y + GameoverScroll_BarStrtPosY);
			pScroller_GameoverScroll.checkOutOfEdge(0f, IGT_UIcommonFunc.ScaleY(GameoverScroll_CurPos.y), 0f, 0f, GameoverScroll_ScrollviewRectMinY, GameoverScroll_ScrollviwRectMaxY);
		}
		else if (bHS_mailbox)
		{
			int count = listAskSend.Count;
			MailBoxScroll_ScrollviwRectMaxY = MailBoxScroll_BarStrtPosY;
			MailBoxScroll_ScrollviewRectMinY = ScrollViewRect_MailBoxScroll.y + ScrollViewRect_MailBoxScroll.height - (float)count * (MailBoxScroll_BarHeight + MailBoxScroll_BarGap) - (ScrollViewRect_MailBoxScroll.y + MailBoxScroll_BarStrtPosY);
			pScroller_MailBoxScroll.checkOutOfEdge(0f, IGT_UIcommonFunc.ScaleY(MailBoxScroll_CurPos.y), 0f, 0f, MailBoxScroll_ScrollviewRectMinY, MailBoxScroll_ScrollviwRectMaxY);
		}
		else if (bHS_sendlife)
		{
			int num2 = fbList.Count - 1;
			SendLifeScroll_ScrollviwRectMaxY = SendLifeScroll_BarStrtPosY;
			SendLifeScroll_ScrollviewRectMinY = ScrollViewRect_SendLifeScroll.y + ScrollViewRect_SendLifeScroll.height - (float)num2 * (SendLifeScroll_BarHeight + SendLifeScroll_BarGap) - (ScrollViewRect_SendLifeScroll.y + SendLifeScroll_BarStrtPosY);
			pScroller_SendLifeScroll.checkOutOfEdge(0f, IGT_UIcommonFunc.ScaleY(SendLifeScroll_CurPos.y), 0f, 0f, SendLifeScroll_ScrollviewRectMinY, SendLifeScroll_ScrollviwRectMaxY);
		}
		else if (bHS_asklife)
		{
			int num3 = fbList.Count - 1;
			AskLifeScroll_ScrollviwRectMaxY = AskLifeScroll_BarStrtPosY;
			AskLifeScroll_ScrollviewRectMinY = ScrollViewRect_AskLifeScroll.y + ScrollViewRect_AskLifeScroll.height - (float)num3 * (AskLifeScroll_BarHeight + AskLifeScroll_BarGap) - (ScrollViewRect_AskLifeScroll.y + AskLifeScroll_BarStrtPosY);
			pScroller_AskLifeScroll.checkOutOfEdge(0f, IGT_UIcommonFunc.ScaleY(AskLifeScroll_CurPos.y), 0f, 0f, AskLifeScroll_ScrollviewRectMinY, AskLifeScroll_ScrollviwRectMaxY);
		}
	}

	public void onOutOfRectScroll()
	{
		if (nScreenMode == 6)
		{
			int num = 0;
			switch (nPurchaseType)
			{
			case 0:
				num = pHero.pPurchaseItemsData_Store.Count;
				break;
			case 1:
				num = pHero.pPurchaseItemsData_Deals.Count;
				break;
			case 2:
				num = pHero.pPurchaseItemsData_Boost.Count;
				break;
			case 3:
				num = pHero.pPurchaseItemsData_Free.Count;
				break;
			}
			purchaseWindow_ScrollviwRectMaxY = purchaseWindow_BarStrtPosY;
			purchaseWindow_ScrollviewRectMinY = ScrollViewRect_purchaseWindow.y + ScrollViewRect_purchaseWindow.height - (float)num * (purchaseWindow_BarHeight + purchaseWindow_BarGap) - (ScrollViewRect_purchaseWindow.y + purchaseWindow_BarStrtPosY);
			pScroller_PuchaseWindow.checkOutOfEdge(0f, IGT_UIcommonFunc.ScaleY(purchaseWindow_CurPos.y), 0f, 0f, purchaseWindow_ScrollviewRectMinY, purchaseWindow_ScrollviwRectMaxY);
		}
		else if (nScreenMode == 5 && nGameoverScrollType == 2)
		{
			GameoverScroll_ScrollviwRectMaxY = GameoverScroll_BarStrtPosY;
			GameoverScroll_ScrollviewRectMinY = ScrollViewRect_GameoverScreen.y + ScrollViewRect_GameoverScreen.height - (float)nBustedScrollCount * (GameoverScroll_BarHeight + GameoverScroll_BarGap_Busted) - (ScrollViewRect_GameoverScreen.y + GameoverScroll_BarStrtPosY);
			pScroller_GameoverScroll.checkOutOfEdge(0f, IGT_UIcommonFunc.ScaleY(GameoverScroll_CurPos.y), 0f, 0f, GameoverScroll_ScrollviewRectMinY, GameoverScroll_ScrollviwRectMaxY);
		}
		else if (bHS_mailbox)
		{
			int count = listAskSend.Count;
			MailBoxScroll_ScrollviwRectMaxY = MailBoxScroll_BarStrtPosY;
			MailBoxScroll_ScrollviewRectMinY = ScrollViewRect_MailBoxScroll.y + ScrollViewRect_MailBoxScroll.height - (float)count * (MailBoxScroll_BarHeight + MailBoxScroll_BarGap) - (ScrollViewRect_MailBoxScroll.y + MailBoxScroll_BarStrtPosY);
			pScroller_MailBoxScroll.checkOutOfEdge(0f, IGT_UIcommonFunc.ScaleY(MailBoxScroll_CurPos.y), 0f, 0f, MailBoxScroll_ScrollviewRectMinY, MailBoxScroll_ScrollviwRectMaxY);
		}
		else if (bHS_sendlife)
		{
			int num2 = fbList.Count - 1;
			SendLifeScroll_ScrollviwRectMaxY = SendLifeScroll_BarStrtPosY;
			SendLifeScroll_ScrollviewRectMinY = ScrollViewRect_SendLifeScroll.y + ScrollViewRect_SendLifeScroll.height - (float)num2 * (SendLifeScroll_BarHeight + SendLifeScroll_BarGap) - (ScrollViewRect_SendLifeScroll.y + SendLifeScroll_BarStrtPosY);
			pScroller_SendLifeScroll.checkOutOfEdge(0f, IGT_UIcommonFunc.ScaleY(SendLifeScroll_CurPos.y), 0f, 0f, SendLifeScroll_ScrollviewRectMinY, SendLifeScroll_ScrollviwRectMaxY);
		}
		else if (bHS_asklife)
		{
			int num3 = fbList.Count - 1;
			AskLifeScroll_ScrollviwRectMaxY = AskLifeScroll_BarStrtPosY;
			AskLifeScroll_ScrollviewRectMinY = ScrollViewRect_AskLifeScroll.y + ScrollViewRect_AskLifeScroll.height - (float)num3 * (AskLifeScroll_BarHeight + AskLifeScroll_BarGap) - (ScrollViewRect_AskLifeScroll.y + AskLifeScroll_BarStrtPosY);
			pScroller_AskLifeScroll.checkOutOfEdge(0f, IGT_UIcommonFunc.ScaleY(AskLifeScroll_CurPos.y), 0f, 0f, AskLifeScroll_ScrollviewRectMinY, AskLifeScroll_ScrollviwRectMaxY);
		}
	}

	public void AskLifeWindowDataSelection()
	{
		if (!bScrollAnim)
		{
			if (pScroller_AskLifeScroll.computeFlingScroller())
			{
				AskLifeScroll_CurPos.y = IGT_UIcommonFunc.reScaleY(pScroller_AskLifeScroll.getFlingY());
			}
			if (pScroller_AskLifeScroll.CalcEdgeEffect())
			{
				AskLifeScroll_CurPos.y = IGT_UIcommonFunc.reScaleY(pScroller_AskLifeScroll.getEdgeY());
			}
		}
		float num = IGT_UIcommonFunc.ScaleY(AskLifeScroll_CurPos.y);
		if (pFacebook.isFBLoginSucess())
		{
			if (fbList != null && fbList.Count - 1 > 0)
			{
				AskLifeScroll_beginScrollViewScrollPos = GUI.BeginScrollView(new Rect(ScrollViewRect_AskLifeScroll.x, ScrollViewRect_AskLifeScroll.y, ScrollViewRect_AskLifeScroll.width, ScrollViewRect_AskLifeScroll.height), AskLifeScroll_beginScrollViewScrollPos, default(Rect));
				for (int i = 0; i < listAskLife.Count; i++)
				{
					if (num + (AskLifeScroll_BarHeight + AskLifeScroll_BarGap) * (float)i >= 0f - (AskLifeScroll_BarHeight + AskLifeScroll_BarGap) && num + (AskLifeScroll_BarHeight + AskLifeScroll_BarGap) * (float)i <= ScrollViewRect_AskLifeScroll.height)
					{
						pIgt_Textures.DrawTexture(IGT_Constants._SettingsBar, AskLifeScroll_BarStrtPosX, num + (AskLifeScroll_BarHeight + AskLifeScroll_BarGap) * (float)i, AskLifeScroll_BarWid, AskLifeScroll_BarHeight);
						if (userProfilePicDict == null || listAskLife[i].userID == null || !userProfilePicDict.ContainsKey(listAskLife[i].userID))
						{
							pIgt_Textures.DrawTexture(IGT_Constants.defaultFB, adj_drawrect(new Rect(AskLifeScroll_BarStrtPosX, num + (AskLifeScroll_BarHeight + AskLifeScroll_BarGap) * (float)i, AskLifeScroll_BarWid, AskLifeScroll_BarHeight), new Rect(rect_AskLifeNamePos.x, num + (AskLifeScroll_BarHeight + AskLifeScroll_BarGap) * (float)i + PurchaseScroll_ProductNameGapFrmBar + IGT_UIcommonFunc.ScaleY(5f), IGT_UIcommonFunc.ScaleX(32f), IGT_UIcommonFunc.ScaleX(32f)), 0), false);
						}
						else
						{
							GUI.DrawTexture(adj_drawrect(new Rect(AskLifeScroll_BarStrtPosX, num + (AskLifeScroll_BarHeight + AskLifeScroll_BarGap) * (float)i, AskLifeScroll_BarWid, AskLifeScroll_BarHeight), new Rect(rect_AskLifeNamePos.x, num + (AskLifeScroll_BarHeight + AskLifeScroll_BarGap) * (float)i + PurchaseScroll_ProductNameGapFrmBar + IGT_UIcommonFunc.ScaleY(5f), IGT_UIcommonFunc.ScaleX(32f), IGT_UIcommonFunc.ScaleX(32f)), 0), userProfilePicDict[listAskLife[i].userID]);
						}
						pIgt_Textures.drawBorder(adj_drawrect(new Rect(AskLifeScroll_BarStrtPosX, num + (AskLifeScroll_BarHeight + AskLifeScroll_BarGap) * (float)i, AskLifeScroll_BarWid, AskLifeScroll_BarHeight), new Rect(rect_AskLifeNamePos.x, num + (AskLifeScroll_BarHeight + AskLifeScroll_BarGap) * (float)i + PurchaseScroll_ProductNameGapFrmBar + IGT_UIcommonFunc.ScaleY(5f), IGT_UIcommonFunc.ScaleX(32f), IGT_UIcommonFunc.ScaleX(32f)), 0), 2f, Border_White);
						if (pFacebook.UserFrndsInfo != null && pFacebook.UserFrndsInfo.ContainsKey(listAskLife[i].userID))
						{
							pIgt_Lable.DrawLable(rect_AskLifeNamePos.x + IGT_UIcommonFunc.ScaleX(20f), num + (AskLifeScroll_BarHeight + AskLifeScroll_BarGap) * (float)i + PurchaseScroll_ProductNameGapFrmBar + IGT_UIcommonFunc.ScaleY(3f), rect_AskLifeNamePos.width, rect_AskLifeNamePos.height, fbList[listAskLife[i].userID].userName, IGT_Constants.Font_Nunito_Bold, fontSz_fbName, Color.yellow, TextAnchor.MiddleCenter);
						}
						else
						{
							pIgt_Lable.DrawLable(rect_AskLifeNamePos.x + IGT_UIcommonFunc.ScaleX(20f), num + (AskLifeScroll_BarHeight + AskLifeScroll_BarGap) * (float)i + PurchaseScroll_ProductNameGapFrmBar + IGT_UIcommonFunc.ScaleY(3f), rect_AskLifeNamePos.width, rect_AskLifeNamePos.height, "Player", IGT_Constants.Font_Nunito_Bold, fontSz_fbName, Color.yellow, TextAnchor.MiddleCenter);
						}
						if (!listAskLife[i].bCheckbox)
						{
							pIgt_Textures.DrawTexture(IGT_Constants.mailCheckBox, rect_AskLifeNamePos.x + IGT_UIcommonFunc.ScaleX(155f), num + (AskLifeScroll_BarHeight + AskLifeScroll_BarGap) * (float)i + PurchaseScroll_ProductNameGapFrmBar + IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(25f), IGT_UIcommonFunc.ScaleX(25f));
						}
						else
						{
							pIgt_Textures.DrawTexture(IGT_Constants.mailCheckMarkBox, rect_AskLifeNamePos.x + IGT_UIcommonFunc.ScaleX(155f), num + (AskLifeScroll_BarHeight + AskLifeScroll_BarGap) * (float)i + PurchaseScroll_ProductNameGapFrmBar + IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(25f), IGT_UIcommonFunc.ScaleX(25f));
						}
					}
				}
				GUI.EndScrollView();
			}
			else
			{
				pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(160f) - rect_purchaseProductDescp.width * 0.5f, IGT_UIcommonFunc.ScaleY(180f), rect_purchaseProductDescp.width, rect_purchaseProductDescp.height), "Your Friends List is Empty...", IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
				But_MailBox_FBInvite.Draw_Button();
				pIgt_Lable.DrawLable(new Rect(But_MailBox_FBInvite.getOriginalDimension().x + IGT_UIcommonFunc.ScaleX(10f), But_MailBox_FBInvite.getOriginalDimension().y, But_MailBox_FBInvite.getOriginalDimension().width, But_MailBox_FBInvite.getOriginalDimension().height), "Invite", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
				pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, new Rect(But_MailBox_FBInvite.getOriginalDimension().x + IGT_UIcommonFunc.ScaleX(8f), But_MailBox_FBInvite.getOriginalDimension().y + IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), false);
				long num2 = (long)IGT_Preference.getInstance()._Get(kFBInviteLastUpdateTime, 0f);
				if (num2 + IGT_Constants.dFBInviteTime <= (long)currentTimeMins())
				{
					pIgt_Textures.DrawTexture(IGT_Constants._Life, new Rect(But_MailBox_FBInvite.getOriginalDimension().x + IGT_UIcommonFunc.ScaleX(130f), But_MailBox_FBInvite.getOriginalDimension().y - IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), 20f, Vector2.zero);
					pIgt_Lable.DrawLable(new Rect(But_MailBox_FBInvite.getOriginalDimension().x + IGT_UIcommonFunc.ScaleX(130f), But_MailBox_FBInvite.getOriginalDimension().y - IGT_UIcommonFunc.ScaleY(4f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleY(22f)), "+2", IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black, 22f, Vector2.zero);
				}
			}
		}
		else
		{
			pIgt_Lable.DrawLable(new Rect(rect_purchaseProductDescp.x + IGT_UIcommonFunc.ScaleX(10f), IGT_UIcommonFunc.ScaleY(180f), rect_purchaseProductDescp.width, rect_purchaseProductDescp.height), fbLogInTxt, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
			But_MailBox_FBConnect.setY(IGT_UIcommonFunc.ScaleY(225f));
			But_MailBox_FBConnect.Draw_Button();
			if (IGT_Preference.getInstance()._Get(kFBLoginfirstTime, 0) == 0)
			{
				pIgt_Textures.DrawTexture(IGT_Constants._Life, new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(130f), But_MailBox_FBConnect.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), 20f, Vector2.zero);
				pIgt_Lable.DrawLable(new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(130f), But_MailBox_FBConnect.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(4f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleY(22f)), "+" + IGT_Constants.nFBLoginLife, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black, 22f, Vector2.zero);
			}
			pIgt_Lable.DrawLable(new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(10f), But_MailBox_FBConnect.getCurrentDimension().y, But_MailBox_FBConnect.getCurrentDimension().width, But_MailBox_FBConnect.getCurrentDimension().height), "Connect", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
			pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(8f), But_MailBox_FBConnect.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), false);
		}
	}

	public void SendLifeWindowDataSelection()
	{
		if (!bScrollAnim)
		{
			if (pScroller_SendLifeScroll.computeFlingScroller())
			{
				SendLifeScroll_CurPos.y = IGT_UIcommonFunc.reScaleY(pScroller_SendLifeScroll.getFlingY());
			}
			if (pScroller_SendLifeScroll.CalcEdgeEffect())
			{
				SendLifeScroll_CurPos.y = IGT_UIcommonFunc.reScaleY(pScroller_SendLifeScroll.getEdgeY());
			}
		}
		float num = IGT_UIcommonFunc.ScaleY(SendLifeScroll_CurPos.y);
		if (pFacebook.isFBLoginSucess())
		{
			if (fbList != null && fbList.Count - 1 > 0)
			{
				SendLifeScroll_beginScrollViewScrollPos = GUI.BeginScrollView(new Rect(ScrollViewRect_SendLifeScroll.x, ScrollViewRect_SendLifeScroll.y, ScrollViewRect_SendLifeScroll.width, ScrollViewRect_SendLifeScroll.height), SendLifeScroll_beginScrollViewScrollPos, default(Rect));
				for (int i = 0; i < listSendLife.Count; i++)
				{
					if (num + (SendLifeScroll_BarHeight + SendLifeScroll_BarGap) * (float)i >= 0f - (SendLifeScroll_BarHeight + SendLifeScroll_BarGap) && num + (SendLifeScroll_BarHeight + SendLifeScroll_BarGap) * (float)i <= ScrollViewRect_SendLifeScroll.height)
					{
						pIgt_Textures.DrawTexture(IGT_Constants._SettingsBar, SendLifeScroll_BarStrtPosX, num + (SendLifeScroll_BarHeight + SendLifeScroll_BarGap) * (float)i, SendLifeScroll_BarWid, SendLifeScroll_BarHeight);
						if (userProfilePicDict == null || listSendLife[i].userID == null || !userProfilePicDict.ContainsKey(listSendLife[i].userID))
						{
							pIgt_Textures.DrawTexture(IGT_Constants.defaultFB, adj_drawrect(new Rect(SendLifeScroll_BarStrtPosX, num + (SendLifeScroll_BarHeight + SendLifeScroll_BarGap) * (float)i, SendLifeScroll_BarWid, SendLifeScroll_BarHeight), new Rect(rect_SendLifeNamePos.x, num + (SendLifeScroll_BarHeight + SendLifeScroll_BarGap) * (float)i + PurchaseScroll_ProductNameGapFrmBar + IGT_UIcommonFunc.ScaleY(5f), IGT_UIcommonFunc.ScaleX(32f), IGT_UIcommonFunc.ScaleX(32f)), 0), false);
						}
						else
						{
							GUI.DrawTexture(adj_drawrect(new Rect(SendLifeScroll_BarStrtPosX, num + (SendLifeScroll_BarHeight + SendLifeScroll_BarGap) * (float)i, SendLifeScroll_BarWid, SendLifeScroll_BarHeight), new Rect(rect_SendLifeNamePos.x, num + (SendLifeScroll_BarHeight + SendLifeScroll_BarGap) * (float)i + PurchaseScroll_ProductNameGapFrmBar + IGT_UIcommonFunc.ScaleY(5f), IGT_UIcommonFunc.ScaleX(32f), IGT_UIcommonFunc.ScaleX(32f)), 0), userProfilePicDict[listSendLife[i].userID]);
						}
						pIgt_Textures.drawBorder(adj_drawrect(new Rect(SendLifeScroll_BarStrtPosX, num + (SendLifeScroll_BarHeight + SendLifeScroll_BarGap) * (float)i, SendLifeScroll_BarWid, SendLifeScroll_BarHeight), new Rect(rect_SendLifeNamePos.x, num + (SendLifeScroll_BarHeight + SendLifeScroll_BarGap) * (float)i + PurchaseScroll_ProductNameGapFrmBar + IGT_UIcommonFunc.ScaleY(5f), IGT_UIcommonFunc.ScaleX(32f), IGT_UIcommonFunc.ScaleX(32f)), 0), 2f, Border_White);
						if (pFacebook.UserFrndsInfo != null && pFacebook.UserFrndsInfo.ContainsKey(listSendLife[i].userID))
						{
							pIgt_Lable.DrawLable(rect_SendLifeNamePos.x + IGT_UIcommonFunc.ScaleX(20f), num + (SendLifeScroll_BarHeight + SendLifeScroll_BarGap) * (float)i + PurchaseScroll_ProductNameGapFrmBar + IGT_UIcommonFunc.ScaleY(3f), rect_SendLifeNamePos.width, rect_SendLifeNamePos.height, fbList[listSendLife[i].userID].userName, IGT_Constants.Font_Nunito_Bold, fontSz_fbName, Color.yellow, TextAnchor.MiddleCenter);
						}
						else
						{
							pIgt_Lable.DrawLable(rect_SendLifeNamePos.x + IGT_UIcommonFunc.ScaleX(20f), num + (SendLifeScroll_BarHeight + SendLifeScroll_BarGap) * (float)i + PurchaseScroll_ProductNameGapFrmBar + IGT_UIcommonFunc.ScaleY(3f), rect_SendLifeNamePos.width, rect_SendLifeNamePos.height, "Player", IGT_Constants.Font_Nunito_Bold, fontSz_fbName, Color.yellow, TextAnchor.MiddleCenter);
						}
						if (listSendLife.Count >= i && !listSendLife[i].bCheckbox)
						{
							pIgt_Textures.DrawTexture(IGT_Constants.mailCheckBox, rect_SendLifeNamePos.x + IGT_UIcommonFunc.ScaleX(155f), num + (SendLifeScroll_BarHeight + SendLifeScroll_BarGap) * (float)i + PurchaseScroll_ProductNameGapFrmBar + IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(25f), IGT_UIcommonFunc.ScaleX(25f));
						}
						else
						{
							pIgt_Textures.DrawTexture(IGT_Constants.mailCheckMarkBox, rect_SendLifeNamePos.x + IGT_UIcommonFunc.ScaleX(155f), num + (SendLifeScroll_BarHeight + SendLifeScroll_BarGap) * (float)i + PurchaseScroll_ProductNameGapFrmBar + IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(25f), IGT_UIcommonFunc.ScaleX(25f));
						}
					}
				}
				GUI.EndScrollView();
			}
			else
			{
				pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(160f) - rect_purchaseProductDescp.width * 0.5f, IGT_UIcommonFunc.ScaleY(180f), rect_purchaseProductDescp.width, rect_purchaseProductDescp.height), "Your Friends List is Empty...", IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
				But_MailBox_FBInvite.Draw_Button();
				pIgt_Lable.DrawLable(new Rect(But_MailBox_FBInvite.getOriginalDimension().x + IGT_UIcommonFunc.ScaleX(10f), But_MailBox_FBInvite.getOriginalDimension().y, But_MailBox_FBInvite.getOriginalDimension().width, But_MailBox_FBInvite.getOriginalDimension().height), "Invite", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
				pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, new Rect(But_MailBox_FBInvite.getOriginalDimension().x + IGT_UIcommonFunc.ScaleX(8f), But_MailBox_FBInvite.getOriginalDimension().y + IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), false);
				long num2 = (long)IGT_Preference.getInstance()._Get(kFBInviteLastUpdateTime, 0f);
				if (num2 + IGT_Constants.dFBInviteTime <= (long)currentTimeMins())
				{
					pIgt_Textures.DrawTexture(IGT_Constants._Life, new Rect(But_MailBox_FBInvite.getOriginalDimension().x + IGT_UIcommonFunc.ScaleX(130f), But_MailBox_FBInvite.getOriginalDimension().y - IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), 20f, Vector2.zero);
					pIgt_Lable.DrawLable(new Rect(But_MailBox_FBInvite.getOriginalDimension().x + IGT_UIcommonFunc.ScaleX(130f), But_MailBox_FBInvite.getOriginalDimension().y - IGT_UIcommonFunc.ScaleY(4f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleY(22f)), "+2", IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black, 22f, Vector2.zero);
				}
			}
		}
		else
		{
			pIgt_Lable.DrawLable(new Rect(rect_purchaseProductDescp.x + IGT_UIcommonFunc.ScaleX(10f), IGT_UIcommonFunc.ScaleY(180f), rect_purchaseProductDescp.width, rect_purchaseProductDescp.height), fbLogInTxt, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
			But_MailBox_FBConnect.setY(IGT_UIcommonFunc.ScaleY(225f));
			But_MailBox_FBConnect.Draw_Button();
			if (IGT_Preference.getInstance()._Get(kFBLoginfirstTime, 0) == 0)
			{
				pIgt_Textures.DrawTexture(IGT_Constants._Life, new Rect(But_MailBox_FBConnect.getOriginalDimension().x + IGT_UIcommonFunc.ScaleX(130f), But_MailBox_FBConnect.getOriginalDimension().y - IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), 20f, Vector2.zero);
				pIgt_Lable.DrawLable(new Rect(But_MailBox_FBConnect.getOriginalDimension().x + IGT_UIcommonFunc.ScaleX(130f), But_MailBox_FBConnect.getOriginalDimension().y - IGT_UIcommonFunc.ScaleY(4f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleY(22f)), "+" + IGT_Constants.nFBLoginLife, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black, 22f, Vector2.zero);
			}
			pIgt_Lable.DrawLable(new Rect(But_MailBox_FBConnect.getOriginalDimension().x + IGT_UIcommonFunc.ScaleX(10f), But_MailBox_FBConnect.getOriginalDimension().y, But_MailBox_FBConnect.getOriginalDimension().width, But_MailBox_FBConnect.getOriginalDimension().height), "Connect", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
			pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, new Rect(But_MailBox_FBConnect.getOriginalDimension().x + IGT_UIcommonFunc.ScaleX(8f), But_MailBox_FBConnect.getOriginalDimension().y + IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), false);
		}
	}

	public void MailBoxWindowDataSelection()
	{
		if (!bScrollAnim)
		{
			if (pScroller_MailBoxScroll.computeFlingScroller())
			{
				MailBoxScroll_CurPos.y = IGT_UIcommonFunc.reScaleY(pScroller_MailBoxScroll.getFlingY());
			}
			if (pScroller_MailBoxScroll.CalcEdgeEffect())
			{
				MailBoxScroll_CurPos.y = IGT_UIcommonFunc.reScaleY(pScroller_MailBoxScroll.getEdgeY());
			}
		}
		float num = IGT_UIcommonFunc.ScaleY(MailBoxScroll_CurPos.y);
		if (pFacebook.isFBLoginSucess())
		{
			if (listAskSend != null && listAskSend.Count > 0)
			{
				if (!dMailBoxisProcessing)
				{
					MailBoxScroll_beginScrollViewScrollPos = GUI.BeginScrollView(new Rect(ScrollViewRect_MailBoxScroll.x, ScrollViewRect_MailBoxScroll.y, ScrollViewRect_MailBoxScroll.width, ScrollViewRect_MailBoxScroll.height), MailBoxScroll_beginScrollViewScrollPos, default(Rect));
					for (int i = 0; i < listAskSend.Count; i++)
					{
						if (num + (MailBoxScroll_BarHeight + MailBoxScroll_BarGap) * (float)i >= 0f - (MailBoxScroll_BarHeight + MailBoxScroll_BarGap) && num + (MailBoxScroll_BarHeight + MailBoxScroll_BarGap) * (float)i <= ScrollViewRect_MailBoxScroll.height)
						{
							pIgt_Textures.DrawTexture(IGT_Constants._SettingsBar, MailBoxScroll_BarStrtPosX, num + (MailBoxScroll_BarHeight + MailBoxScroll_BarGap) * (float)i, MailBoxScroll_BarWid, MailBoxScroll_BarHeight);
							if (userProfilePicDict == null || listAskSend[i].userID == null || !userProfilePicDict.ContainsKey(listAskSend[i].userID))
							{
								pIgt_Textures.DrawTexture(IGT_Constants.defaultFB, rect_MailBoxNamePos.x, num + (MailBoxScroll_BarHeight + MailBoxScroll_BarGap) * (float)i + PurchaseScroll_ProductNameGapFrmBar + IGT_UIcommonFunc.ScaleY(5f), IGT_UIcommonFunc.ScaleX(32f), IGT_UIcommonFunc.ScaleX(32f));
							}
							else
							{
								GUI.DrawTexture(new Rect(rect_MailBoxNamePos.x, num + (MailBoxScroll_BarHeight + MailBoxScroll_BarGap) * (float)i + PurchaseScroll_ProductNameGapFrmBar + IGT_UIcommonFunc.ScaleY(5f), IGT_UIcommonFunc.ScaleX(32f), IGT_UIcommonFunc.ScaleX(32f)), userProfilePicDict[listAskSend[i].userID]);
							}
							pIgt_Textures.drawBorder(new Rect(rect_MailBoxNamePos.x, num + (MailBoxScroll_BarHeight + MailBoxScroll_BarGap) * (float)i + PurchaseScroll_ProductNameGapFrmBar + IGT_UIcommonFunc.ScaleY(5f), IGT_UIcommonFunc.ScaleX(32f), IGT_UIcommonFunc.ScaleX(32f)), 2f, Border_White);
							if (pFacebook.UserFrndsInfo != null && pFacebook.UserFrndsInfo.ContainsKey(listAskSend[i].userID))
							{
								pIgt_Lable.DrawLable(rect_MailBoxNamePos.x + IGT_UIcommonFunc.ScaleX(20f), num + (MailBoxScroll_BarHeight + MailBoxScroll_BarGap) * (float)i + PurchaseScroll_ProductNameGapFrmBar - IGT_UIcommonFunc.ScaleY(6f), rect_MailBoxNamePos.width, rect_MailBoxNamePos.height, pFacebook.UserFrndsInfo[listAskSend[i].userID].userName, IGT_Constants.Font_Nunito_Bold, fontSz_fbName, Color.yellow, TextAnchor.MiddleCenter);
							}
							else
							{
								pIgt_Lable.DrawLable(rect_MailBoxNamePos.x + IGT_UIcommonFunc.ScaleX(20f), num + (MailBoxScroll_BarHeight + MailBoxScroll_BarGap) * (float)i + PurchaseScroll_ProductNameGapFrmBar - IGT_UIcommonFunc.ScaleY(6f), rect_MailBoxNamePos.width, rect_MailBoxNamePos.height, "Player", IGT_Constants.Font_Nunito_Bold, fontSz_fbName, Color.yellow, TextAnchor.MiddleCenter);
							}
							pIgt_Lable.DrawLable(rect_MailBoxNamePos.x + IGT_UIcommonFunc.ScaleX(20f), num + (MailBoxScroll_BarHeight + MailBoxScroll_BarGap) * (float)i + PurchaseScroll_ProductNameGapFrmBar + IGT_UIcommonFunc.ScaleY(12f), rect_MailBoxNamePos.width, rect_MailBoxNamePos.height, listAskSend[i].msg, IGT_Constants.Font_TitanOne, fontSz_fbAskSendMsg, Color.white, TextAnchor.MiddleCenter);
							if (!listAskSend[i].bCheckbox)
							{
								pIgt_Textures.DrawTexture(IGT_Constants.mailCheckBox, rect_MailBoxNamePos.x + IGT_UIcommonFunc.ScaleX(155f), num + (MailBoxScroll_BarHeight + MailBoxScroll_BarGap) * (float)i + PurchaseScroll_ProductNameGapFrmBar + IGT_UIcommonFunc.ScaleY(7f), IGT_UIcommonFunc.ScaleX(25f), IGT_UIcommonFunc.ScaleX(25f));
							}
							else
							{
								pIgt_Textures.DrawTexture(IGT_Constants.mailCheckMarkBox, rect_MailBoxNamePos.x + IGT_UIcommonFunc.ScaleX(155f), num + (MailBoxScroll_BarHeight + MailBoxScroll_BarGap) * (float)i + PurchaseScroll_ProductNameGapFrmBar + IGT_UIcommonFunc.ScaleY(7f), IGT_UIcommonFunc.ScaleX(25f), IGT_UIcommonFunc.ScaleX(25f));
							}
						}
					}
					GUI.EndScrollView();
				}
				else
				{
					pIgt_Lable.DrawLable(new Rect(But_MailBox_FBInvite.getOriginalDimension().x, IGT_UIcommonFunc.ScaleY(190f), But_MailBox_FBInvite.getOriginalDimension().width, But_MailBox_FBInvite.getOriginalDimension().height), "Loading...", IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, false, new Color(0.96f, 0.96f, 0.52f), 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
				}
			}
			else
			{
				pIgt_Lable.DrawLable(new Rect(But_MailBox_FBInvite.getOriginalDimension().x, IGT_UIcommonFunc.ScaleY(120f), But_MailBox_FBInvite.getOriginalDimension().width, But_MailBox_FBInvite.getOriginalDimension().height), "No New Messages..", IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
				pIgt_Lable.DrawLable(new Rect(But_MailBox_FBInvite.getOriginalDimension().x, IGT_UIcommonFunc.ScaleY(190f), But_MailBox_FBInvite.getOriginalDimension().width, But_MailBox_FBInvite.getOriginalDimension().height), "Invite your Friends to \nask Free Lives", IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, new Color(0.96f, 0.96f, 0.52f), 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
				But_MailBox_FBInvite.Draw_Button();
				pIgt_Lable.DrawLable(new Rect(But_MailBox_FBInvite.getOriginalDimension().x + IGT_UIcommonFunc.ScaleX(10f), But_MailBox_FBInvite.getOriginalDimension().y, But_MailBox_FBInvite.getOriginalDimension().width, But_MailBox_FBInvite.getOriginalDimension().height), "Invite", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
				pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, new Rect(But_MailBox_FBInvite.getOriginalDimension().x + IGT_UIcommonFunc.ScaleX(8f), But_MailBox_FBInvite.getOriginalDimension().y + IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), false);
				long num2 = (long)IGT_Preference.getInstance()._Get(kFBInviteLastUpdateTime, 0f);
				if (num2 + IGT_Constants.dFBInviteTime <= (long)currentTimeMins())
				{
					pIgt_Textures.DrawTexture(IGT_Constants._Life, new Rect(But_MailBox_FBInvite.getOriginalDimension().x + IGT_UIcommonFunc.ScaleX(130f), But_MailBox_FBInvite.getOriginalDimension().y - IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), 20f, Vector2.zero);
					pIgt_Lable.DrawLable(new Rect(But_MailBox_FBInvite.getOriginalDimension().x + IGT_UIcommonFunc.ScaleX(130f), But_MailBox_FBInvite.getOriginalDimension().y - IGT_UIcommonFunc.ScaleY(4f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleY(22f)), "+2", IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black, 22f, Vector2.zero);
				}
			}
		}
		else
		{
			pIgt_Lable.DrawLable(new Rect(rect_purchaseProductDescp.x + IGT_UIcommonFunc.ScaleX(10f), IGT_UIcommonFunc.ScaleY(180f), rect_purchaseProductDescp.width, rect_purchaseProductDescp.height), fbLogInTxt, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
			But_MailBox_FBConnect.setY(IGT_UIcommonFunc.ScaleY(225f));
			But_MailBox_FBConnect.Draw_Button();
			if (IGT_Preference.getInstance()._Get(kFBLoginfirstTime, 0) == 0)
			{
				pIgt_Textures.DrawTexture(IGT_Constants._Life, new Rect(But_MailBox_FBConnect.getOriginalDimension().x + IGT_UIcommonFunc.ScaleX(130f), But_MailBox_FBConnect.getOriginalDimension().y - IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), 20f, Vector2.zero);
				pIgt_Lable.DrawLable(new Rect(But_MailBox_FBConnect.getOriginalDimension().x + IGT_UIcommonFunc.ScaleX(130f), But_MailBox_FBConnect.getOriginalDimension().y - IGT_UIcommonFunc.ScaleY(4f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleY(22f)), "+" + IGT_Constants.nFBLoginLife, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black, 22f, Vector2.zero);
			}
			pIgt_Lable.DrawLable(new Rect(But_MailBox_FBConnect.getOriginalDimension().x + IGT_UIcommonFunc.ScaleX(10f), But_MailBox_FBConnect.getOriginalDimension().y, But_MailBox_FBConnect.getOriginalDimension().width, But_MailBox_FBConnect.getOriginalDimension().height), "Connect", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
			pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, new Rect(But_MailBox_FBConnect.getOriginalDimension().x + IGT_UIcommonFunc.ScaleX(8f), But_MailBox_FBConnect.getOriginalDimension().y + IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), false);
		}
	}

	public void drawRectBorder(Rect rect, float thickness, Color color)
	{
		drawRect(new Rect(rect.xMin, rect.yMin, rect.width, thickness), color);
		drawRect(new Rect(rect.xMin, rect.yMin, thickness, rect.height), color);
		drawRect(new Rect(rect.xMax - thickness, rect.yMin, thickness, rect.height), color);
		drawRect(new Rect(rect.xMin, rect.yMax - thickness, rect.width, thickness), color);
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

	public void PurchaseWindowDataSelection()
	{
		if (!bScrollAnim && !bBoostUpgradeAnim)
		{
			if (pScroller_PuchaseWindow.computeFlingScroller())
			{
				purchaseWindow_CurPos.y = IGT_UIcommonFunc.reScaleY(pScroller_PuchaseWindow.getFlingY());
			}
			if (pScroller_PuchaseWindow.CalcEdgeEffect())
			{
				purchaseWindow_CurPos.y = IGT_UIcommonFunc.reScaleY(pScroller_PuchaseWindow.getEdgeY());
			}
		}
		float num = IGT_UIcommonFunc.ScaleY(purchaseWindow_CurPos.y);
		purchaseWindow_beginScrollViewScrollPos = GUI.BeginScrollView(new Rect(ScrollViewRect_purchaseWindow.x, ScrollViewRect_purchaseWindow.y, ScrollViewRect_purchaseWindow.width, ScrollViewRect_purchaseWindow.height), purchaseWindow_beginScrollViewScrollPos, default(Rect));
		switch (nPurchaseType)
		{
		case 0:
		{
			int num5 = pHero.pPurchaseItemsData_Store.Count();
			for (int l = 0; l < num5; l++)
			{
				if (num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)l >= 0f - (purchaseWindow_BarHeight + purchaseWindow_BarGap) && num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)l <= ScrollViewRect_purchaseWindow.height)
				{
					pIgt_Textures.DrawTexture(IGT_Constants._Shop_ScrollBar, new Rect(purchaseWindow_BarStrtPosX, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)l, purchaseWindow_BarWid, purchaseWindow_BarHeight), false);
					pIgt_Textures.DrawTexture(IGT_Constants.Path_purchaseItemsImages + pHero.pPurchaseItemsData_Store[l].ImageName, new Rect(rect_purchseProductImg.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)l + PurchaseScroll_ProductImgGapFrmBar, rect_purchseProductImg.width, rect_purchseProductImg.height), true);
					pIgt_Lable.DrawLable(new Rect(rect_purchaseProductName.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)l + PurchaseScroll_ProductNameGapFrmBar, rect_purchaseProductName.width, rect_purchaseProductName.height), pHero.pPurchaseItemsData_Store[l].ProductTitle, IGT_Constants.Font_chelaOne, fontSize_purProdName, TextAnchor.MiddleCenter, false, Color.white, new Vector2(2f, 2f), Color.black);
					pIgt_Lable.DrawLable(new Rect(rect_purchaseProductDescp.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)l + PurchaseScroll_ProductDescpGapFrmBar, rect_purchaseProductDescp.width, rect_purchaseProductDescp.height), pHero.pPurchaseItemsData_Store[l].ProductDescription, IGT_Constants.Font_Jellee_Roman, fontSize_purProdDescp, TextAnchor.MiddleCenter, false, new Color(0.98f, 0.964f, 0.501f), new Vector2(2f, 2f), Color.black);
					pIgt_Textures.DrawTexture(IGT_Constants._Shop_PriceBg, new Rect(rect_purchaseBuy.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)l + rect_purchaseBuy.y, rect_purchaseBuy.width, rect_purchaseBuy.height), false);
					if (pHero.pIGT_IAPManagerAssist.isInitialisedSuccess())
					{
						string text2 = "$1";
						text2 = pHero.pIGT_IAPManagerAssist.GetPriceforEachProduct(pHero.pPurchaseItemsData_Store[l].ProductID_GooglePlayStore);
						int fontSize2 = ((text2.Length > 9) ? ((int)IGT_UIcommonFunc.ScaleX(13f)) : ((text2.Length <= 7) ? ((int)IGT_UIcommonFunc.ScaleX(17f)) : ((int)IGT_UIcommonFunc.ScaleX(15f))));
						pIgt_Lable.DrawLable(new Rect(rect_purchaseBuy.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)l + rect_purchaseBuy.y - IGT_UIcommonFunc.ScaleY(2f), rect_purchaseBuy.width, rect_purchaseBuy.height), text2, IGT_Constants.Font_chelaOne, fontSize2, TextAnchor.MiddleCenter, false, Color.black, 0f, Color.black);
					}
					else
					{
						pIgt_Lable.DrawLable(new Rect(rect_purchaseBuy.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)l + rect_purchaseBuy.y - IGT_UIcommonFunc.ScaleY(2f), rect_purchaseBuy.width, rect_purchaseBuy.height), pHero.pPurchaseItemsData_Store[l].DefaultPrice, IGT_Constants.Font_chelaOne, fontSize_purProdPrice, TextAnchor.MiddleCenter, false, Color.black, 0f, Color.black);
					}
				}
			}
			break;
		}
		case 1:
		{
			int num3 = pHero.pPurchaseItemsData_Deals.Count();
			for (int j = 0; j < num3; j++)
			{
				if (!(num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)j >= 0f - (purchaseWindow_BarHeight + purchaseWindow_BarGap)) || !(num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)j <= ScrollViewRect_purchaseWindow.height))
				{
					continue;
				}
				Color color = GUI.color;
				if ((pHero.nDealComboOffer_1 == 0 && j == num3 - 2) || (pHero.nDealComboOffer_2 == 0 && j == num3 - 1))
				{
					GUI.color = new Color(color.r, color.g, color.b, 0.4f);
				}
				else
				{
					GUI.color = new Color(color.r, color.g, color.b, 1f);
				}
				pIgt_Textures.DrawTexture(IGT_Constants._Shop_ScrollBar, new Rect(purchaseWindow_BarStrtPosX, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)j, purchaseWindow_BarWid, purchaseWindow_BarHeight), false);
				pIgt_Textures.DrawTexture(IGT_Constants.Path_purchaseItemsImages + pHero.pPurchaseItemsData_Deals[j].ImageName, new Rect(rect_purchseProductImg.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)j + PurchaseScroll_ProductImgGapFrmBar, rect_purchseProductImg.width, rect_purchseProductImg.height), true);
				pIgt_Lable.DrawLable(new Rect(rect_purchaseProductName.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)j + PurchaseScroll_ProductNameGapFrmBar, rect_purchaseProductName.width, rect_purchaseProductName.height), pHero.pPurchaseItemsData_Deals[j].ProductTitle, IGT_Constants.Font_chelaOne, fontSize_purProdName, TextAnchor.MiddleCenter, false, Color.white, new Vector2(2f, 2f), Color.black);
				int fontSize = ((pHero.pPurchaseItemsData_Deals[j].ProductDescription.Length > 40) ? ((int)IGT_UIcommonFunc.ScaleX(12f)) : ((pHero.pPurchaseItemsData_Deals[j].ProductDescription.Length <= 35) ? ((int)IGT_UIcommonFunc.ScaleX(15f)) : ((int)IGT_UIcommonFunc.ScaleX(14f))));
				pIgt_Lable.DrawLable(new Rect(rect_purchaseProductDescp.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)j + PurchaseScroll_ProductDescpGapFrmBar, rect_purchaseProductDescp.width, rect_purchaseProductDescp.height), pHero.pPurchaseItemsData_Deals[j].ProductDescription, IGT_Constants.Font_chelaOne, fontSize, TextAnchor.MiddleCenter, false, new Color(0.98f, 0.964f, 0.501f), new Vector2(2f, 2f), Color.black);
				if ((pHero.nDealComboOffer_1 == 0 && j == num3 - 2) || (pHero.nDealComboOffer_2 == 0 && j == num3 - 1))
				{
					pIgt_Textures.DrawTexture(IGT_Constants._TickMark, new Rect(purchaseWindow_BarStrtPosX + purchaseWindow_BarWid * 0.8f, purchaseWindow_BarHeight * 0.2f + num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)j, IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleX(35f)), false);
				}
				else
				{
					pIgt_Textures.DrawTexture(IGT_Constants._Shop_PriceBg, new Rect(rect_purchaseBuy.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)j + rect_purchaseBuy.y, rect_purchaseBuy.width, rect_purchaseBuy.height), false);
					if (pHero.pIGT_IAPManagerAssist.isInitialisedSuccess())
					{
						string text = "$0";
						text = pHero.pIGT_IAPManagerAssist.GetPriceforEachProduct(pHero.pPurchaseItemsData_Deals[j].ProductID_GooglePlayStore);
						fontSize = ((text.Length > 9) ? ((int)IGT_UIcommonFunc.ScaleX(13f)) : ((text.Length <= 7) ? ((int)IGT_UIcommonFunc.ScaleX(17f)) : ((int)IGT_UIcommonFunc.ScaleX(15f))));
						pIgt_Lable.DrawLable(new Rect(rect_purchaseBuy.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)j + rect_purchaseBuy.y - IGT_UIcommonFunc.ScaleY(2f), rect_purchaseBuy.width, rect_purchaseBuy.height), text, IGT_Constants.Font_chelaOne, fontSize, TextAnchor.MiddleCenter, false, Color.black, Vector2.zero, Color.black);
					}
					else
					{
						pIgt_Lable.DrawLable(new Rect(rect_purchaseBuy.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)j + rect_purchaseBuy.y - IGT_UIcommonFunc.ScaleY(2f), rect_purchaseBuy.width, rect_purchaseBuy.height), pHero.pPurchaseItemsData_Deals[j].DefaultPrice, IGT_Constants.Font_chelaOne, fontSize_purProdPrice, TextAnchor.MiddleCenter, false, Color.black, Vector2.zero, Color.black);
					}
				}
				GUI.color = color;
			}
			break;
		}
		case 3:
		{
			int num2 = pHero.pPurchaseItemsData_Free.Count();
			for (int k = 0; k < num2; k++)
			{
				if (!(num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k >= 0f - (purchaseWindow_BarHeight + purchaseWindow_BarGap)) || !(num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k <= ScrollViewRect_purchaseWindow.height))
				{
					continue;
				}
				pIgt_Textures.DrawTexture(IGT_Constants._Shop_ScrollBar, new Rect(purchaseWindow_BarStrtPosX, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k, purchaseWindow_BarWid, purchaseWindow_BarHeight), false);
				if (k == 3)
				{
					pIgt_Textures.DrawTexture(IGT_Constants._GameIcon, new Rect(rect_purchseProductImg.x + IGT_UIcommonFunc.ScaleX(16f), num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k + PurchaseScroll_ProductImgGapFrmBar + IGT_UIcommonFunc.ScaleY(14f), rect_purchseProductImg.width * 0.75f, rect_purchseProductImg.height * 0.75f), true);
				}
				else if (k == 1 && pFacebook.isFBLoginSucess())
				{
					pIgt_Textures.DrawTexture(IGT_Constants.Path_purchaseItemsImages + "fInvite", new Rect(rect_purchseProductImg.x + IGT_UIcommonFunc.ScaleX(16f), num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k + PurchaseScroll_ProductImgGapFrmBar + IGT_UIcommonFunc.ScaleY(14f), rect_purchseProductImg.width * 0.75f, rect_purchseProductImg.height * 0.75f), true);
				}
				else
				{
					pIgt_Textures.DrawTexture(IGT_Constants.Path_purchaseItemsImages + pHero.pPurchaseItemsData_Free[k].ImageName, new Rect(rect_purchseProductImg.x + IGT_UIcommonFunc.ScaleX(16f), num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k + PurchaseScroll_ProductImgGapFrmBar + IGT_UIcommonFunc.ScaleY(14f), rect_purchseProductImg.width * 0.75f, rect_purchseProductImg.height * 0.75f), true);
				}
				int num4 = ((pHero.pPurchaseItemsData_Free[k].ProductDescription.Length > 25) ? ((int)IGT_UIcommonFunc.ScaleX(13f)) : ((pHero.pPurchaseItemsData_Free[k].ProductDescription.Length <= 20) ? ((int)IGT_UIcommonFunc.ScaleX(15f)) : ((int)IGT_UIcommonFunc.ScaleX(14f))));
				if (k < 3)
				{
					switch (k)
					{
					case 0:
						pIgt_Lable.DrawLable(new Rect(rect_purchaseProductName.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k + PurchaseScroll_ProductNameGapFrmBar, rect_purchaseProductName.width, rect_purchaseProductName.height), pHero.pPurchaseItemsData_Free[k].ProductTitle, IGT_Constants.Font_chelaOne, (int)IGT_UIcommonFunc.ScaleX(17f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(2f, 2f), Color.black);
						pIgt_Lable.DrawLable(new Rect(rect_purchaseProductDescp.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k + PurchaseScroll_ProductDescpGapFrmBar, rect_purchaseProductDescp.width, rect_purchaseProductDescp.height), pHero.pPurchaseItemsData_Free[k].ProductDescription, IGT_Constants.Font_Nunito, num4 - (int)IGT_UIcommonFunc.ScaleX(3f), TextAnchor.MiddleCenter, false, new Color(0.98f, 0.964f, 0.501f), new Vector2(2f, 2f), Color.black);
						if (pHero.pIGt_LifeCalc.getCurrentLifeCount() < pHero.pIGt_LifeCalc.getTotalGivenLifeCount())
						{
							if (pAds.isRewardBasedVideoAvailable() && bRewardedVideoTimeUp)
							{
								getRewardedVideoTimeIntervel();
								pIgt_Textures.DrawTexture(IGT_Constants._Shop_PriceBg, new Rect(rect_purchaseBuy.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k + rect_purchaseBuy.y, rect_purchaseBuy.width, rect_purchaseBuy.height), false);
								pIgt_Lable.DrawLable(new Rect(rect_purchaseBuy.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k + rect_purchaseBuy.y, rect_purchaseBuy.width, rect_purchaseBuy.height), pHero.pPurchaseItemsData_Free[k].DefaultPrice, IGT_Constants.Font_Jellee_Roman, fontSize_purProdPrice - (int)IGT_UIcommonFunc.ScaleX(4f), TextAnchor.MiddleCenter, false, Color.black, Vector2.zero, Color.black);
							}
							else if (bRewardedVideoTimeUp)
							{
								Color color2 = GUI.color;
								GUI.color = new Color(color2.r, color2.g, color2.b, 0.2f);
								pIgt_Textures.DrawTexture(IGT_Constants._Shop_PriceBg, new Rect(rect_purchaseBuy.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k + rect_purchaseBuy.y, rect_purchaseBuy.width, rect_purchaseBuy.height), false);
								pIgt_Lable.DrawLable(new Rect(rect_purchaseBuy.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k + rect_purchaseBuy.y, rect_purchaseBuy.width, rect_purchaseBuy.height), pHero.pPurchaseItemsData_Free[k].DefaultPrice, IGT_Constants.Font_Jellee_Roman, fontSize_purProdPrice - (int)IGT_UIcommonFunc.ScaleX(4f), TextAnchor.MiddleCenter, false, Color.black, Vector2.zero, Color.black);
								bRewardedVideoTimeUp = false;
								GUI.color = color2;
							}
							else
							{
								pIgt_Lable.DrawLable(new Rect(rect_purchaseBuy.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k + rect_purchaseBuy.y, rect_purchaseBuy.width, rect_purchaseBuy.height), getRewardedVideoTimeIntervel(), IGT_Constants.Font_SevenSegment, fontSize_purProdPrice + (int)IGT_UIcommonFunc.ScaleX(5f), TextAnchor.MiddleCenter, false, Color.white, Vector2.one * 3f, Color.black);
							}
						}
						else
						{
							Color color3 = GUI.color;
							GUI.color = new Color(color3.r, color3.g, color3.b, 0.2f);
							pIgt_Textures.DrawTexture(IGT_Constants._Shop_PriceBg, new Rect(rect_purchaseBuy.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k + rect_purchaseBuy.y, rect_purchaseBuy.width, rect_purchaseBuy.height), false);
							pIgt_Lable.DrawLable(new Rect(rect_purchaseBuy.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k + rect_purchaseBuy.y, rect_purchaseBuy.width, rect_purchaseBuy.height), "Life full", IGT_Constants.Font_Jellee_Roman, fontSize_purProdPrice - (int)IGT_UIcommonFunc.ScaleX(4f), TextAnchor.MiddleCenter, false, Color.black, Vector2.zero, Color.black);
							GUI.color = color3;
						}
						break;
					case 1:
						if (!pFacebook.isFBLoginSucess())
						{
							if (IGT_Preference.getInstance()._Get(kFBLoginfirstTime, 0) == 0)
							{
								pIgt_Lable.DrawLable(new Rect(rect_purchaseProductName.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k + PurchaseScroll_ProductNameGapFrmBar, rect_purchaseProductName.width, rect_purchaseProductName.height), pHero.pPurchaseItemsData_Free[k].ProductTitle, IGT_Constants.Font_chelaOne, (int)IGT_UIcommonFunc.ScaleX(17f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(2f, 2f), Color.black);
								pIgt_Lable.DrawLable(new Rect(rect_purchaseProductDescp.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k + PurchaseScroll_ProductDescpGapFrmBar, rect_purchaseProductDescp.width, rect_purchaseProductDescp.height), pHero.pPurchaseItemsData_Free[k].ProductDescription, IGT_Constants.Font_Nunito, num4 - (int)IGT_UIcommonFunc.ScaleX(3f), TextAnchor.MiddleCenter, false, new Color(0.98f, 0.964f, 0.501f), new Vector2(2f, 2f), Color.black);
							}
							else
							{
								pIgt_Lable.DrawLable(new Rect(rect_purchaseProductName.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k + (PurchaseScroll_ProductNameGapFrmBar + IGT_UIcommonFunc.ScaleY(8f)), rect_purchaseProductName.width, rect_purchaseProductName.height), pHero.pPurchaseItemsData_Free[k].ProductTitle, IGT_Constants.Font_chelaOne, (int)IGT_UIcommonFunc.ScaleX(17f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(2f, 2f), Color.black);
							}
						}
						else if ((long)IGT_Preference.getInstance()._Get(kFBInviteLastUpdateTime, 0f) + IGT_Constants.dFBInviteTime <= (long)currentTimeMins())
						{
							pIgt_Lable.DrawLable(new Rect(rect_purchaseProductName.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k + PurchaseScroll_ProductNameGapFrmBar, rect_purchaseProductName.width, rect_purchaseProductName.height), "Invite Friends", IGT_Constants.Font_chelaOne, (int)IGT_UIcommonFunc.ScaleX(17f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(2f, 2f), Color.black);
							pIgt_Lable.DrawLable(new Rect(rect_purchaseProductDescp.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k + PurchaseScroll_ProductDescpGapFrmBar, rect_purchaseProductDescp.width, rect_purchaseProductDescp.height), "Earn +2 lives", IGT_Constants.Font_Nunito, num4 - (int)IGT_UIcommonFunc.ScaleX(3f), TextAnchor.MiddleCenter, false, new Color(0.98f, 0.964f, 0.501f), new Vector2(2f, 2f), Color.black);
						}
						else
						{
							pIgt_Lable.DrawLable(new Rect(rect_purchaseProductName.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k + (PurchaseScroll_ProductNameGapFrmBar + IGT_UIcommonFunc.ScaleY(8f)), rect_purchaseProductName.width, rect_purchaseProductName.height), "Invite Friends", IGT_Constants.Font_chelaOne, (int)IGT_UIcommonFunc.ScaleX(17f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(2f, 2f), Color.black);
						}
						pIgt_Textures.DrawTexture(IGT_Constants._Shop_PriceBg, new Rect(rect_purchaseBuy.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k + rect_purchaseBuy.y, rect_purchaseBuy.width, rect_purchaseBuy.height), false);
						pIgt_Lable.DrawLable(new Rect(rect_purchaseBuy.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k + rect_purchaseBuy.y, rect_purchaseBuy.width, rect_purchaseBuy.height), pHero.pPurchaseItemsData_Free[k].DefaultPrice, IGT_Constants.Font_Jellee_Roman, fontSize_purProdPrice - (int)IGT_UIcommonFunc.ScaleX(4f), TextAnchor.MiddleCenter, false, Color.black, Vector2.zero, Color.black);
						break;
					case 2:
						pIgt_Lable.DrawLable(new Rect(rect_purchaseProductName.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k + PurchaseScroll_ProductNameGapFrmBar, rect_purchaseProductName.width, rect_purchaseProductName.height), pHero.pPurchaseItemsData_Free[k].ProductTitle, IGT_Constants.Font_chelaOne, (int)IGT_UIcommonFunc.ScaleX(17f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(2f, 2f), Color.black);
						pIgt_Lable.DrawLable(new Rect(rect_purchaseProductDescp.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k + PurchaseScroll_ProductDescpGapFrmBar, rect_purchaseProductDescp.width, rect_purchaseProductDescp.height), pHero.pPurchaseItemsData_Free[k].ProductDescription, IGT_Constants.Font_Nunito, num4 - (int)IGT_UIcommonFunc.ScaleX(3f), TextAnchor.MiddleCenter, false, new Color(0.98f, 0.964f, 0.501f), new Vector2(2f, 2f), Color.black);
						if (bMoreGameEnableInPurchaseWindow)
						{
							pIgt_Textures.DrawTexture(IGT_Constants._Shop_PriceBg, new Rect(rect_purchaseBuy.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k + rect_purchaseBuy.y, rect_purchaseBuy.width, rect_purchaseBuy.height), false);
							pIgt_Lable.DrawLable(new Rect(rect_purchaseBuy.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k + rect_purchaseBuy.y, rect_purchaseBuy.width, rect_purchaseBuy.height), pHero.pPurchaseItemsData_Free[k].DefaultPrice, IGT_Constants.Font_Jellee_Roman, fontSize_purProdPrice - (int)IGT_UIcommonFunc.ScaleX(4f), TextAnchor.MiddleCenter, false, Color.black, Vector2.zero, Color.black);
						}
						else
						{
							pIgt_Lable.DrawLable(new Rect(rect_purchaseBuy.x - IGT_UIcommonFunc.ScaleX(4f), num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k + rect_purchaseBuy.y, rect_purchaseBuy.width, rect_purchaseBuy.height), getMoreGamesIntervalinFreeTab(), IGT_Constants.Font_SevenSegment, fontSize_purProdPrice + (int)IGT_UIcommonFunc.ScaleX(3f), TextAnchor.MiddleCenter, false, Color.white, Vector2.one * 3f, Color.black);
						}
						break;
					}
				}
				else
				{
					pIgt_Lable.DrawLable(new Rect(rect_purchaseProductName.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k + (PurchaseScroll_ProductNameGapFrmBar + IGT_UIcommonFunc.ScaleY(8f)), rect_purchaseProductName.width, rect_purchaseProductName.height), pHero.pPurchaseItemsData_Free[k].ProductTitle, IGT_Constants.Font_chelaOne, (int)IGT_UIcommonFunc.ScaleX(17f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(2f, 2f), Color.black);
					switch (k)
					{
					case 3:
						pIgt_Textures.DrawTexture(IGT_Constants._BtnDisable_MC_LB, new Rect(rect_purchaseBuy.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k + rect_purchaseBuy.y, rect_purchaseBuy.width, rect_purchaseBuy.height), false);
						pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, new Rect(rect_purchaseBuy.x + IGT_UIcommonFunc.ScaleX(2f), num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k + rect_purchaseBuy.y + IGT_UIcommonFunc.ScaleY(2f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleX(22f)), true);
						pIgt_Lable.DrawLable(new Rect(rect_purchaseBuy.x + IGT_UIcommonFunc.ScaleX(8f), num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k + rect_purchaseBuy.y, rect_purchaseBuy.width, rect_purchaseBuy.height), "Like", IGT_Constants.Font_Jellee_Roman, fontSize_purProdPrice - (int)IGT_UIcommonFunc.ScaleX(4f), TextAnchor.MiddleCenter, false, Color.white, Vector2.one * 2f, Color.black);
						break;
					case 4:
						pIgt_Textures.DrawTexture(IGT_Constants._BtnDisable_MC_LB, new Rect(rect_purchaseBuy.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k + rect_purchaseBuy.y, rect_purchaseBuy.width, rect_purchaseBuy.height), false);
						pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, new Rect(rect_purchaseBuy.x + IGT_UIcommonFunc.ScaleX(2f), num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k + rect_purchaseBuy.y + IGT_UIcommonFunc.ScaleY(2f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleX(22f)), true);
						pIgt_Lable.DrawLable(new Rect(rect_purchaseBuy.x + IGT_UIcommonFunc.ScaleX(8f), num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)k + rect_purchaseBuy.y, rect_purchaseBuy.width, rect_purchaseBuy.height), "Like", IGT_Constants.Font_Jellee_Roman, fontSize_purProdPrice - (int)IGT_UIcommonFunc.ScaleX(4f), TextAnchor.MiddleCenter, false, Color.white, Vector2.one * 2f, Color.black);
						break;
					}
				}
			}
			break;
		}
		case 2:
		{
			int num2 = pHero.pPurchaseItemsData_Boost.Count();
			for (int i = 0; i < num2; i++)
			{
				if (num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)i >= 0f - (purchaseWindow_BarHeight + purchaseWindow_BarGap) && num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)i <= ScrollViewRect_purchaseWindow.height)
				{
					pIgt_Textures.DrawTexture(IGT_Constants._Shop_ScrollBar, new Rect(purchaseWindow_BarStrtPosX, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)i, purchaseWindow_BarWid, purchaseWindow_BarHeight), false);
					pIgt_Textures.DrawTexture(pHero.pPurchaseItemsData_Boost[i].ImageName, new Rect(rect_purchseProductImg.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)i + IGT_UIcommonFunc.ScaleY(2f), rect_purchseProductImg.width * 0.75f, rect_purchseProductImg.height * 0.75f), true);
					pIgt_Lable.DrawLable(new Rect(rect_purchaseProductName.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)i + IGT_UIcommonFunc.ScaleY(-1f), rect_purchaseProductName.width, rect_purchaseProductName.height), pHero.pPurchaseItemsData_Boost[i].ProductTitle, IGT_Constants.Font_chelaOne, fontSize_purProdName, TextAnchor.MiddleCenter, false, Color.white, new Vector2(2f, 2f), Color.black);
					if (pHero.pPurchaseItemsData_Boost[i].nCurUpgradeState < 5)
					{
						pIgt_Lable.DrawLable(new Rect(rect_purchaseProductDescp.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)i + IGT_UIcommonFunc.ScaleY(13f), rect_purchaseProductDescp.width, rect_purchaseProductDescp.height), pHero.pPurchaseItemsData_Boost[i].pIGT_UpgradeData.ElementAt(pHero.pPurchaseItemsData_Boost[i].nCurUpgradeState).Description, IGT_Constants.Font_Nunito, (int)IGT_UIcommonFunc.ScaleX(8f), TextAnchor.MiddleCenter, false, new Color(0.98f, 0.964f, 0.501f), Vector2.zero, Color.black);
						pIgt_Textures.DrawTexture(IGT_Constants._BtnEnable_MC_LB, new Rect(rect_purchaseBuy.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)i + rect_purchaseBuy.y, rect_purchaseBuy.width, rect_purchaseBuy.height), false);
						pIgt_Textures.DrawTexture(pHero.pPurchaseItemsData_Boost[i].priceNotationImg, adj_drawrect(new Rect(rect_purchaseBuy.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)i + rect_purchaseBuy.y, rect_purchaseBuy.width, rect_purchaseBuy.height), new Rect(rect_purchaseBuy.x - IGT_UIcommonFunc.ScaleX(9f), num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)i + rect_purchaseBuy.y, IGT_UIcommonFunc.ScaleX(20f), IGT_UIcommonFunc.ScaleX(20f)), 0), false);
						float x = 23 - pHero.pPurchaseItemsData_Boost[i].pIGT_UpgradeData.ElementAt(pHero.pPurchaseItemsData_Boost[i].nCurUpgradeState).Amount.Length;
						pIgt_Lable.DrawLable(new Rect(rect_purchaseBuy.x + IGT_UIcommonFunc.ScaleX(3f), num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)i + rect_purchaseBuy.y - IGT_UIcommonFunc.ScaleY(2f), rect_purchaseBuy.width, rect_purchaseBuy.height), pHero.pPurchaseItemsData_Boost[i].pIGT_UpgradeData.ElementAt(pHero.pPurchaseItemsData_Boost[i].nCurUpgradeState).Amount, IGT_Constants.Font_chelaOne, (int)IGT_UIcommonFunc.ScaleX(x), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black);
					}
					pIgt_Textures.DrawTexture(IGT_Constants._UpgradeOFF, new Rect(rect_Upgrade.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)i + rect_Upgrade.y, rect_Upgrade.width + 4f * fUpgradeGapX, rect_Upgrade.height), false);
					pIgt_Textures.DrawTexture_coords(IGT_Constants._UpgradeON, new Rect(rect_Upgrade.x, num + (purchaseWindow_BarHeight + purchaseWindow_BarGap) * (float)i + rect_Upgrade.y, rect_Upgrade.width + (float)(pHero.pPurchaseItemsData_Boost[i].nCurUpgradeState - 1) * fUpgradeGapX, rect_Upgrade.height), new Rect(0f, 0f, (float)pHero.pPurchaseItemsData_Boost[i].nCurUpgradeState * 0.2f, 1f));
				}
			}
			break;
		}
		}
		GUI.EndScrollView();
		if (!bPurchaseWindow_LifeAdd)
		{
			pIgt_Textures.DrawTexture(IGT_Constants._Button_Blue, new Rect(rect_LifecountPurchasewindow.x - IGT_UIcommonFunc.ScaleX(11f), rect_LifecountPurchasewindow.y - IGT_UIcommonFunc.ScaleY(3f), IGT_UIcommonFunc.ScaleX(60f), IGT_UIcommonFunc.ScaleY(25f)), false);
			pIgt_Textures.DrawTexture(IGT_Constants._Life, new Rect(rect_LifecountPurchasewindow.x - IGT_UIcommonFunc.ScaleX(26f), rect_LifecountPurchasewindow.y - IGT_UIcommonFunc.ScaleY(7f), IGT_UIcommonFunc.ScaleX(32f), rect_LifecountPurchasewindow.height + IGT_UIcommonFunc.ScaleY(12f)), false);
			pIgt_Lable.DrawLable(rect_LifecountPurchasewindow, pHero.pIGt_LifeCalc.getCurrentLifeCount().ToString(), IGT_Constants.Font_TTMasters, findFontSize_In_PurchaseWindow(pHero.pIGt_LifeCalc.getCurrentLifeCount().ToString().Length), TextAnchor.MiddleCenter, false, new Color(0.96f, 0.93f, 0.47f), 0f, Color.black, new Vector2(2f, 2f), Color.black);
		}
		else
		{
			float num6 = pAnim_HS_menuBG.easeFunctions(1f, 1.5f, 1f, 29);
			GUIUtility.ScaleAroundPivot(new Vector2(num6, num6), new Vector2(rect_LifecountPurchasewindow.x + rect_LifecountPurchasewindow.width * 0.5f, rect_LifecountPurchasewindow.y + rect_LifecountPurchasewindow.height * 0.5f));
			pIgt_Textures.DrawTexture(IGT_Constants._Button_Blue, new Rect(rect_LifecountPurchasewindow.x - IGT_UIcommonFunc.ScaleX(11f), rect_LifecountPurchasewindow.y - IGT_UIcommonFunc.ScaleY(3f), IGT_UIcommonFunc.ScaleX(60f), IGT_UIcommonFunc.ScaleY(25f)), false);
			pIgt_Textures.DrawTexture(IGT_Constants._Life, adj_drawrect(new Rect(rect_LifecountPurchasewindow.x - IGT_UIcommonFunc.ScaleX(11f), rect_LifecountPurchasewindow.y - IGT_UIcommonFunc.ScaleY(3f), IGT_UIcommonFunc.ScaleX(60f), IGT_UIcommonFunc.ScaleY(25f)), new Rect(rect_LifecountPurchasewindow.x - IGT_UIcommonFunc.ScaleX(26f), rect_LifecountPurchasewindow.y - IGT_UIcommonFunc.ScaleY(6f), IGT_UIcommonFunc.ScaleX(29f), IGT_UIcommonFunc.ScaleY(29f)), 0), true);
			int num7 = pHero.pIGt_LifeCalc.getCurrentLifeCount();
			if (bPurchaseWindow_LifeCountScroll)
			{
				num7 = (int)pAnim_MissionCompleted_star1.easeFunctions(nPurchaseWindow_Anim_Life_Src, nPurchaseWindow_Anim_Life_Des, 1f, 0);
			}
			if (pAnim_MissionCompleted_star1.isAnimFinished())
			{
				num7 = nPurchaseWindow_Anim_Life_Des;
			}
			pIgt_Lable.DrawLable(rect_LifecountPurchasewindow, num7.ToString(), IGT_Constants.Font_TTMasters, findFontSize_In_PurchaseWindow(num7.ToString().Length), TextAnchor.MiddleCenter, false, new Color(0.96f, 0.93f, 0.47f), 0f, Color.black, new Vector2(2f, 2f), Color.black, 0f, Vector2.zero);
			GUI.matrix = Matrix4x4.identity;
			if (pAnim_HS_menuBG.isAnimFinished() && pAnim_HS_menuBG.getIsReverse())
			{
				bPurchaseWindow_LifeAdd = false;
				pHero.pIGt_LifeCalc.forceAddLifeCount(nPurchaseWindow_Anim_Life_Des - nPurchaseWindow_Anim_Life_Src);
			}
			else if (pAnim_HS_menuBG.isAnimFinished() && !bPurchaseWindow_LifeCountScroll)
			{
				pAnim_MissionCompleted_star1.resetAllValues();
				bPurchaseWindow_LifeCountScroll = true;
			}
			else if (pAnim_MissionCompleted_star1.isAnimFinished() && !pAnim_HS_menuBG.getIsReverse() && bPurchaseWindow_LifeCountScroll)
			{
				pAnim_HS_menuBG.resetAllValues();
				pAnim_HS_menuBG.setIsReverse(true);
				bPurchaseWindow_LifeCountScroll = false;
			}
		}
		if (!bPurchaseWindow_KeyAdd)
		{
			pIgt_Textures.DrawTexture(IGT_Constants._Button_Blue, new Rect(rect_KeycountPurchasewindow.x - IGT_UIcommonFunc.ScaleX(18f), rect_KeycountPurchasewindow.y - IGT_UIcommonFunc.ScaleY(3f), IGT_UIcommonFunc.ScaleX(60f), IGT_UIcommonFunc.ScaleY(25f)), false);
			pIgt_Textures.DrawTexture(IGT_Constants._KeyImg, adj_drawrect(new Rect(rect_KeycountPurchasewindow.x - IGT_UIcommonFunc.ScaleX(18f), rect_KeycountPurchasewindow.y - IGT_UIcommonFunc.ScaleY(3f), IGT_UIcommonFunc.ScaleX(60f), IGT_UIcommonFunc.ScaleY(25f)), new Rect(rect_KeycountPurchasewindow.x - IGT_UIcommonFunc.ScaleX(30f), rect_KeycountPurchasewindow.y - IGT_UIcommonFunc.ScaleY(6f), IGT_UIcommonFunc.ScaleX(33f), IGT_UIcommonFunc.ScaleY(30f)), 0), false);
			pIgt_Lable.DrawLable(new Rect(rect_KeycountPurchasewindow.x - IGT_UIcommonFunc.ScaleX(7f), rect_KeycountPurchasewindow.y, rect_KeycountPurchasewindow.width, rect_KeycountPurchasewindow.height), IGT_Constants.nTotKeysCount.ToString(), IGT_Constants.Font_TTMasters, findFontSize_In_PurchaseWindow(IGT_Constants.nTotKeysCount.ToString().Length), TextAnchor.MiddleCenter, false, new Color(0.96f, 0.93f, 0.47f), 0f, Color.black, new Vector2(2f, 2f), Color.black);
		}
		else
		{
			float num8 = pAnim_Alert.easeFunctions(1f, 1.5f, 1f, 29);
			GUIUtility.ScaleAroundPivot(new Vector2(num8, num8), new Vector2(rect_KeycountPurchasewindow.x + rect_KeycountPurchasewindow.width * 0.5f, rect_KeycountPurchasewindow.y + rect_KeycountPurchasewindow.height * 0.5f));
			pIgt_Textures.DrawTexture(IGT_Constants._Button_Blue, new Rect(rect_KeycountPurchasewindow.x - IGT_UIcommonFunc.ScaleX(18f), rect_KeycountPurchasewindow.y - IGT_UIcommonFunc.ScaleY(3f), IGT_UIcommonFunc.ScaleX(60f), IGT_UIcommonFunc.ScaleY(25f)), false);
			pIgt_Textures.DrawTexture(IGT_Constants._KeyImg, new Rect(rect_KeycountPurchasewindow.x - IGT_UIcommonFunc.ScaleX(30f), rect_KeycountPurchasewindow.y - IGT_UIcommonFunc.ScaleY(6f), IGT_UIcommonFunc.ScaleX(33f), IGT_UIcommonFunc.ScaleY(30f)), false);
			int num9 = IGT_Constants.nTotKeysCount;
			if (bPurchaseWindow_KeyCountScroll)
			{
				num9 = (int)pAnim_MissionCompleted_star2.easeFunctions(nPurchaseWindow_Anim_Key_Src, nPurchaseWindow_Anim_Key_Des, 1f, 0);
			}
			if (pAnim_MissionCompleted_star2.isAnimFinished())
			{
				num9 = nPurchaseWindow_Anim_Key_Des;
			}
			pIgt_Lable.DrawLable(new Rect(rect_KeycountPurchasewindow.x - IGT_UIcommonFunc.ScaleX(7f), rect_KeycountPurchasewindow.y, rect_KeycountPurchasewindow.width, rect_KeycountPurchasewindow.height), num9.ToString(), IGT_Constants.Font_TTMasters, findFontSize_In_PurchaseWindow(num9.ToString().Length), TextAnchor.MiddleCenter, false, new Color(0.96f, 0.93f, 0.47f), 0f, Color.black, new Vector2(2f, 2f), Color.black, 0f, Vector2.zero);
			GUI.matrix = Matrix4x4.identity;
			if (pAnim_Alert.isAnimFinished() && pAnim_Alert.getIsReverse())
			{
				bPurchaseWindow_KeyAdd = false;
				IGT_Constants.nTotKeysCount = nPurchaseWindow_Anim_Key_Des;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotKeyCount, IGT_Constants.nTotKeysCount);
				IGT_Preference.getInstance()._SaveAll();
			}
			else if (pAnim_Alert.isAnimFinished() && !bPurchaseWindow_KeyCountScroll)
			{
				pAnim_MissionCompleted_star2.resetAllValues();
				bPurchaseWindow_KeyCountScroll = true;
			}
			else if (pAnim_MissionCompleted_star2.isAnimFinished() && !pAnim_Alert.getIsReverse() && bPurchaseWindow_KeyCountScroll)
			{
				pAnim_Alert.resetAllValues();
				pAnim_Alert.setIsReverse(true);
				bPurchaseWindow_KeyCountScroll = false;
			}
		}
		if (!bPurchaseWindow_coinAdd)
		{
			pIgt_Textures.DrawTexture(IGT_Constants._Button_Blue, new Rect(rect_CoincountPurchasewindow.x - IGT_UIcommonFunc.ScaleX(20f), rect_CoincountPurchasewindow.y - IGT_UIcommonFunc.ScaleY(3f), IGT_UIcommonFunc.ScaleX(65f), IGT_UIcommonFunc.ScaleY(25f)), false);
			pIgt_Textures.DrawTexture(IGT_Constants._CoinImg, adj_drawrect(new Rect(rect_CoincountPurchasewindow.x - IGT_UIcommonFunc.ScaleX(20f), rect_CoincountPurchasewindow.y - IGT_UIcommonFunc.ScaleY(3f), IGT_UIcommonFunc.ScaleX(65f), IGT_UIcommonFunc.ScaleY(25f)), new Rect(rect_CoincountPurchasewindow.x - IGT_UIcommonFunc.ScaleX(39f), rect_CoincountPurchasewindow.y - IGT_UIcommonFunc.ScaleY(4f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleX(30f)), 0), false);
			pIgt_Lable.DrawLable(new Rect(rect_CoincountPurchasewindow.x - IGT_UIcommonFunc.ScaleX(5f), rect_CoincountPurchasewindow.y, rect_CoincountPurchasewindow.width, rect_CoincountPurchasewindow.height), IGT_Constants.nTotNoOfCoins.ToString(), IGT_Constants.Font_TTMasters, findFontSize_In_PurchaseWindow(IGT_Constants.nTotNoOfCoins.ToString().Length), TextAnchor.MiddleCenter, false, new Color(0.96f, 0.93f, 0.47f), 0f, Color.black, new Vector2(2f, 2f), Color.black);
		}
		else
		{
			float num10 = pAnim_MailBox.easeFunctions(1f, 1.5f, 1f, 29);
			GUIUtility.ScaleAroundPivot(new Vector2(num10, num10), new Vector2(rect_CoincountPurchasewindow.x + rect_CoincountPurchasewindow.width * 0.5f, rect_CoincountPurchasewindow.y + rect_CoincountPurchasewindow.height * 0.5f));
			pIgt_Textures.DrawTexture(IGT_Constants._Button_Blue, new Rect(rect_CoincountPurchasewindow.x - IGT_UIcommonFunc.ScaleX(20f), rect_CoincountPurchasewindow.y - IGT_UIcommonFunc.ScaleY(3f), IGT_UIcommonFunc.ScaleX(65f), IGT_UIcommonFunc.ScaleY(25f)), false);
			pIgt_Textures.DrawTexture(IGT_Constants._CoinImg, new Rect(rect_CoincountPurchasewindow.x - IGT_UIcommonFunc.ScaleX(39f), rect_CoincountPurchasewindow.y - IGT_UIcommonFunc.ScaleY(4f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), true);
			int num11 = IGT_Constants.nTotNoOfCoins;
			if (bPurchaseWindow_CoinCountScroll)
			{
				num11 = (int)pAnim_MissionCompleted_star3.easeFunctions(nPurchaseWindow_Anim_Coin_Src, nPurchaseWindow_Anim_Coin_Des, 1f, 0);
			}
			if (pAnim_MissionCompleted_star3.isAnimFinished())
			{
				num11 = nPurchaseWindow_Anim_Coin_Des;
			}
			pIgt_Lable.DrawLable(new Rect(rect_CoincountPurchasewindow.x - IGT_UIcommonFunc.ScaleX(5f), rect_CoincountPurchasewindow.y, rect_CoincountPurchasewindow.width, rect_CoincountPurchasewindow.height), num11.ToString(), IGT_Constants.Font_TTMasters, findFontSize_In_PurchaseWindow(num11.ToString().Length), TextAnchor.MiddleCenter, false, new Color(0.96f, 0.93f, 0.47f), 0f, Color.black, new Vector2(2f, 2f), Color.black, 0f, Vector2.zero);
			GUI.matrix = Matrix4x4.identity;
			if (pAnim_MailBox.isAnimFinished() && pAnim_MailBox.getIsReverse())
			{
				bPurchaseWindow_coinAdd = false;
				IGT_Constants.nTotNoOfCoins = nPurchaseWindow_Anim_Coin_Des;
				IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_TotCoins, IGT_Constants.nTotNoOfCoins);
				IGT_Preference.getInstance()._SaveAll();
			}
			else if (pAnim_MailBox.isAnimFinished() && !bPurchaseWindow_CoinCountScroll)
			{
				pAnim_MissionCompleted_star3.resetAllValues();
				bPurchaseWindow_CoinCountScroll = true;
			}
			else if (pAnim_MissionCompleted_star3.isAnimFinished() && !pAnim_MailBox.getIsReverse() && bPurchaseWindow_CoinCountScroll)
			{
				pAnim_MailBox.resetAllValues();
				pAnim_MailBox.setIsReverse(true);
				bPurchaseWindow_CoinCountScroll = false;
			}
		}
		if (pHero.nSound == 0 && !pHero._AudioSource2.isPlaying && (bPurchaseWindow_KeyCountScroll || bPurchaseWindow_LifeCountScroll || bPurchaseWindow_CoinCountScroll))
		{
			pHero._AudioSource2.clip = pHero._AudioClips[16];
			pHero._AudioSource2.loop = true;
			pHero._AudioSource2.Play();
			pHero._AudioSource2.volume = 1f;
			pHero._AudioSource2.transform.position = pHero.player.transform.position;
		}
		else if (!bPurchaseWindow_KeyCountScroll && !bPurchaseWindow_LifeCountScroll && !bPurchaseWindow_CoinCountScroll && pHero._AudioSource2.isPlaying)
		{
			pHero._AudioSource2.Stop();
		}
		if (bUpgradeAlert)
		{
			float num12 = 0f;
			num12 = (pAnim_NoInternet.getIsReverse() ? pAnim_NoInternet.easeFunctions(Screen.width, 0f, 1f, 28) : pAnim_NoInternet.easeFunctions(0f - rect_PausescreenBG.x - rect_PausescreenBG.width * 1.25f, 0f, 0.75f, 29));
			if (pAnim_NoInternet.isAnimFinished() && pAnim_NoInternet.getIsReverse())
			{
				bUpgradeAlert = false;
				return;
			}
			pIgt_Textures.DrawTexture(IGT_Constants._AlertBoard_Blue, new Rect(rect_PausescreenBG.x + num12, rect_PausescreenBG.y, rect_PausescreenBG.width, rect_PausescreenBG.height), false);
			But_Upgrade_Store.setX(But_Upgrade_Store.getOriginalDimension().x + num12);
			But_Upgrade_Store.Draw_Button();
			pIgt_Lable.DrawLable(But_Upgrade_Store.getCurrentDimension(), "Store", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(16f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(1.25f, 1.25f), Color.black);
			But_Upgrade_Cancel.setX(But_Upgrade_Cancel.getOriginalDimension().x + num12);
			But_Upgrade_Cancel.Draw_Button();
			pIgt_Lable.DrawLable(But_Upgrade_Cancel.getCurrentDimension(), "Later", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(16f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(1.25f, 1.25f), Color.black);
			pIgt_Lable.DrawLable(new Rect(rect_PausescreenBG.x + IGT_UIcommonFunc.ScaleX(2f) + num12, rect_PausescreenBG.y + IGT_UIcommonFunc.ScaleY(10f), rect_PausescreenBG.width, IGT_UIcommonFunc.ScaleY(50f)), "Need <color=yellow>" + sUpgradeAlertItemCount + "</color> " + sUpgradeAlertItemName, IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(20f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, new Vector2(1f, 1f), Color.black);
			pIgt_Lable.DrawLable(new Rect(rect_PausescreenBG.x + IGT_UIcommonFunc.ScaleX(1f) + num12, rect_PausescreenBG.y + IGT_UIcommonFunc.ScaleY(60f), rect_PausescreenBG.width, IGT_UIcommonFunc.ScaleY(30f)), "Would you like to get more " + sUpgradeAlertItemName + " ? ", IGT_Constants.Font_Nunito, (int)IGT_UIcommonFunc.ScaleX(14f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black);
		}
	}

	public static void purchase_Items_Adding_Anim(int type, int src, int dest)
	{
		switch (type)
		{
		case 0:
			nPurchaseWindow_Anim_Life_Src = src;
			nPurchaseWindow_Anim_Life_Des = dest;
			bPurchaseWindow_LifeAdd = true;
			bPurchaseWindow_LifeCountScroll = false;
			pAnim_HS_menuBG.resetAllValues();
			break;
		case 1:
			nPurchaseWindow_Anim_Key_Src = src;
			nPurchaseWindow_Anim_Key_Des = dest;
			bPurchaseWindow_KeyAdd = true;
			bPurchaseWindow_KeyCountScroll = false;
			pAnim_Alert.resetAllValues();
			break;
		case 2:
			nPurchaseWindow_Anim_Coin_Src = src;
			nPurchaseWindow_Anim_Coin_Des = dest;
			bPurchaseWindow_coinAdd = true;
			bPurchaseWindow_CoinCountScroll = false;
			pAnim_MailBox.resetAllValues();
			break;
		}
	}

	private int findFontSize_In_PurchaseWindow(int lenth)
	{
		int num = (int)IGT_UIcommonFunc.ScaleX(16f);
		if (lenth < 2)
		{
			return (int)IGT_UIcommonFunc.ScaleX(18f);
		}
		if (lenth < 4)
		{
			return (int)IGT_UIcommonFunc.ScaleX(16f);
		}
		if (lenth < 7)
		{
			return (int)IGT_UIcommonFunc.ScaleX(14f);
		}
		if (lenth < 10)
		{
			return (int)IGT_UIcommonFunc.ScaleX(12f);
		}
		return (int)IGT_UIcommonFunc.ScaleX(8f);
	}

	private int OnClickEventsInPurchaseWindow(float touchx, float touchY, TouchPhase touchphase, float scrollCurPosY, float barHeight, Rect scrollRect, Rect butRect)
	{
		if (touchx >= scrollRect.x && touchx <= scrollRect.x + scrollRect.width && touchY >= scrollRect.y && touchY <= scrollRect.y + scrollRect.height)
		{
			int num = (int)((touchY - (scrollRect.y + scrollCurPosY)) / barHeight);
			if (isPurchaseButBtnDown && touchphase == TouchPhase.Ended)
			{
				if (touchx >= butRect.x && touchx <= butRect.x + butRect.width && touchY >= scrollRect.y + scrollCurPosY + barHeight * (float)num + butRect.y && touchY <= scrollRect.y + scrollCurPosY + butRect.y + barHeight * (float)num + butRect.height)
				{
					return num;
				}
				isPurchaseButBtnDown = false;
			}
			else if (touchphase == TouchPhase.Began && touchx >= butRect.x && touchx <= butRect.x + butRect.width && touchY >= scrollRect.y + scrollCurPosY + barHeight * (float)num + butRect.y && touchY <= scrollRect.y + scrollCurPosY + butRect.y + barHeight * (float)num + butRect.height)
			{
				isPurchaseButBtnDown = true;
			}
		}
		return -1;
	}

	private void Alt_gameOverScrollDataSel()
	{
		string text = null;
		if (pFacebook.isFBLoginSucess())
		{
			text = pFacebook.getMEUserID();
		}
		float num = 0f;
		bDrawInvite_Chase = false;
		Color white = Color.white;
		switch (nGameoverScrollType)
		{
		case 0:
			if (pFacebook.isFBLoginSucess())
			{
				bool flag = false;
				int num3 = -1;
				if (pFacebook.Chase_Friends != null && pFacebook.Chase_Friends.ContainsKey(text))
				{
					for (int j = 0; j < pIGT_ScrollData_GameOver_Fb.Count; j++)
					{
						if (pIGT_ScrollData_GameOver_Fb.ElementAt(j).Id.Equals(text) && int.Parse(pIGT_ScrollData_GameOver_Fb.ElementAt(j).Rank) > 4)
						{
							flag = true;
						}
					}
				}
				int num4 = ((!flag) ? 4 : 5);
				for (int k = 0; k < num4; k++)
				{
					if (k < pIGT_ScrollData_GameOver_Fb.Count)
					{
						white = ((!pIGT_ScrollData_GameOver_Fb.ElementAt(k).Id.Equals(text)) ? Color.white : Color.yellow);
						if (flag)
						{
							if (k != 2)
							{
								num3++;
								num = IGT_UIcommonFunc.ScaleY(0.1f);
								if (k == 3)
								{
									pIgt_Textures.DrawTexture(IGT_Constants._DotImg, new Rect(rect_GameoverScroll_Dot.x, Gameover_FBitems_StrtY + GameoverScroll_BarHeight * (float)num3 + rect_GameoverScroll_Dot.y, rect_GameoverScroll_Dot.width, rect_GameoverScroll_Dot.height), false);
									num = IGT_UIcommonFunc.ScaleY(4.7f);
								}
								else if (k >= 3)
								{
									num = IGT_UIcommonFunc.ScaleY(3.2f);
								}
								pIgt_Textures.DrawTexture(IGT_Constants._GameOver_ScrollBar, new Rect(GameoverScroll_BarStrtPosX, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num3, GameoverScroll_BarWid, GameoverScroll_BarHeight), false);
								GUI.DrawTexture(new Rect(rect_GameoverScroll_pic.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num3 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), pIGT_ScrollData_GameOver_Fb.ElementAt(k).pTexture);
								pIgt_Textures.drawBorder(new Rect(rect_GameoverScroll_pic.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num3 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), 2f, Border_White);
								if (k < 3)
								{
									GUI.DrawTexture(new Rect(rect_GameoverScroll_IdxBg.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)k + rect_GameoverScroll_IdxBg.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_IdxBg.width, rect_GameoverScroll_IdxBg.height), rankbg[k]);
									pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Idx.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num3 + rect_GameoverScroll_Idx.y + GameoverScroll_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(3f), rect_GameoverScroll_Idx.width, rect_GameoverScroll_Idx.height), pIGT_ScrollData_GameOver_Fb.ElementAt(k).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName - (int)IGT_UIcommonFunc.ScaleX(2f), white, TextAnchor.MiddleCenter, false);
								}
								else
								{
									pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Idx.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num3 + rect_GameoverScroll_Idx.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Idx.width, rect_GameoverScroll_Idx.height), pIGT_ScrollData_GameOver_Fb.ElementAt(k).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
								}
								if (pIGT_ScrollData_GameOver_Fb.ElementAt(k).Name != null)
								{
									pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Name.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num3 + rect_GameoverScroll_Name.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Name.width, rect_GameoverScroll_Name.height), pIGT_ScrollData_GameOver_Fb.ElementAt(k).Name, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
								}
								else
								{
									pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Name.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num3 + rect_GameoverScroll_Name.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Name.width, rect_GameoverScroll_Name.height), "Player_" + (k + 1), IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
								}
								pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Score.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num3 + rect_GameoverScroll_Score.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Score.width, rect_GameoverScroll_Score.height), pIGT_ScrollData_GameOver_Fb.ElementAt(k).Score, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollScore, white, TextAnchor.MiddleCenter, false);
							}
						}
						else
						{
							num3++;
							num = IGT_UIcommonFunc.ScaleY(1f);
							pIgt_Textures.DrawTexture(IGT_Constants._GameOver_ScrollBar, new Rect(GameoverScroll_BarStrtPosX, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num3, GameoverScroll_BarWid, GameoverScroll_BarHeight), false);
							GUI.DrawTexture(new Rect(rect_GameoverScroll_pic.x, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num3 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), pIGT_ScrollData_GameOver_Fb.ElementAt(k).pTexture);
							pIgt_Textures.drawBorder(new Rect(rect_GameoverScroll_pic.x, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num3 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), 2f, Border_White);
							if (k < 3)
							{
								GUI.DrawTexture(new Rect(rect_GameoverScroll_IdxBg.x, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)k + rect_GameoverScroll_IdxBg.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_IdxBg.width, rect_GameoverScroll_IdxBg.height), rankbg[k]);
								pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Idx.x, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num3 + rect_GameoverScroll_Idx.y + GameoverScroll_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(3f), rect_GameoverScroll_Idx.width, rect_GameoverScroll_Idx.height), pIGT_ScrollData_GameOver_Fb.ElementAt(k).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName - (int)IGT_UIcommonFunc.ScaleX(2f), white, TextAnchor.MiddleCenter, false);
							}
							else
							{
								pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Idx.x, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num3 + rect_GameoverScroll_Idx.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Idx.width, rect_GameoverScroll_Idx.height), pIGT_ScrollData_GameOver_Fb.ElementAt(k).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
							}
							if (pIGT_ScrollData_GameOver_Fb.ElementAt(k).Name != null)
							{
								pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Name.x, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num3 + rect_GameoverScroll_Name.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Name.width, rect_GameoverScroll_Name.height), pIGT_ScrollData_GameOver_Fb.ElementAt(k).Name, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
							}
							else
							{
								pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Name.x, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num3 + rect_GameoverScroll_Name.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Name.width, rect_GameoverScroll_Name.height), "Player_" + (k + 1), IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
							}
							pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Score.x, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num3 + rect_GameoverScroll_Score.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Score.width, rect_GameoverScroll_Score.height), pIGT_ScrollData_GameOver_Fb.ElementAt(k).Score, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollScore, white, TextAnchor.MiddleCenter, false);
						}
					}
					else
					{
						bDrawInvite_Chase = true;
					}
				}
				if (bDrawInvite_Chase)
				{
					Rect base_rect = GO_Invitebtn_decide_rect(pIGT_ScrollData_GameOver_Fb.Count);
					btnFBLeaderBoardInvite.setX(base_rect.x);
					btnFBLeaderBoardInvite.setY(base_rect.y);
					btnFBLeaderBoardInvite.setWidth(base_rect.width);
					btnFBLeaderBoardInvite.setHeight(base_rect.height);
					btnFBLeaderBoardInvite.Draw_Button();
					pIgt_Lable.DrawLable(new Rect(btnFBLeaderBoardInvite.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(10f), btnFBLeaderBoardInvite.getCurrentDimension().y, btnFBLeaderBoardInvite.getCurrentDimension().width, btnFBLeaderBoardInvite.getCurrentDimension().height), "Invite", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
					pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, adj_drawrect(base_rect, new Rect(btnFBLeaderBoardInvite.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(8f), btnFBLeaderBoardInvite.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), 0), false);
					if (pFacebook.isFBLoginSucess() && (long)IGT_Preference.getInstance()._Get(kFBInviteLastUpdateTime, 0f) + IGT_Constants.dFBInviteTime <= (long)currentTimeMins())
					{
						pIgt_Textures.DrawTexture(IGT_Constants._Life, new Rect(btnFBLeaderBoardInvite.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(115f), btnFBLeaderBoardInvite.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(12f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), 24f, Vector2.zero);
						pIgt_Lable.DrawLable(new Rect(btnFBLeaderBoardInvite.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(115f), btnFBLeaderBoardInvite.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleY(22f)), "+2", IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black, 20f, Vector2.zero);
					}
				}
			}
			else
			{
				pIgt_Lable.DrawLable(new Rect(rect_purchaseProductDescp.x + IGT_UIcommonFunc.ScaleX(10f), IGT_UIcommonFunc.ScaleY(70f), rect_purchaseProductDescp.width, rect_purchaseProductDescp.height), fbLogInTxt, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black);
				But_MailBox_FBConnect.setY(IGT_UIcommonFunc.ScaleY(120f));
				But_MailBox_FBConnect.Draw_Button();
				if (IGT_Preference.getInstance()._Get(kFBLoginfirstTime, 0) == 0)
				{
					pIgt_Textures.DrawTexture(IGT_Constants._Life, new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(130f), But_MailBox_FBConnect.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), 20f, Vector2.zero);
					pIgt_Lable.DrawLable(new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(130f), But_MailBox_FBConnect.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(4f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleY(22f)), "+" + IGT_Constants.nFBLoginLife, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black, 22f, Vector2.zero);
				}
				pIgt_Lable.DrawLable(new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(10f), But_MailBox_FBConnect.getCurrentDimension().y, But_MailBox_FBConnect.getCurrentDimension().width, But_MailBox_FBConnect.getCurrentDimension().height), "Connect", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
				pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(8f), But_MailBox_FBConnect.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), false);
			}
			break;
		case 1:
		{
			if (pIGT_ScrollData_GameOver_Topchase == null)
			{
				break;
			}
			bool flag2 = false;
			int num5 = -1;
			string text2 = null;
			text2 = ((!pFacebook.isFBLoginSucess()) ? strDeviceID : text);
			if (pFacebook.Chase_Global != null && pFacebook.Chase_Global.ContainsKey(text2))
			{
				for (int l = 0; l < pIGT_ScrollData_GameOver_Topchase.Count; l++)
				{
					if (pIGT_ScrollData_GameOver_Topchase.ElementAt(l).Id.Equals(text2) && int.Parse(pIGT_ScrollData_GameOver_Topchase.ElementAt(l).Rank) > 4)
					{
						flag2 = true;
					}
				}
			}
			int num6 = ((!flag2) ? 4 : 5);
			for (int m = 0; m < num6; m++)
			{
				if (m >= pIGT_ScrollData_GameOver_Topchase.Count)
				{
					continue;
				}
				white = ((!pIGT_ScrollData_GameOver_Topchase.ElementAt(m).Id.Equals(text2)) ? Color.white : Color.yellow);
				if (flag2)
				{
					if (m == 2)
					{
						continue;
					}
					num5++;
					num = IGT_UIcommonFunc.ScaleY(0.1f);
					if (m == 3)
					{
						pIgt_Textures.DrawTexture(IGT_Constants._DotImg, new Rect(rect_GameoverScroll_Dot.x, Gameover_FBitems_StrtY + GameoverScroll_BarHeight * (float)num5 + rect_GameoverScroll_Dot.y, rect_GameoverScroll_Dot.width, rect_GameoverScroll_Dot.height), false);
						num = IGT_UIcommonFunc.ScaleY(4.7f);
					}
					else if (m >= 3)
					{
						num = IGT_UIcommonFunc.ScaleY(3.2f);
					}
					pIgt_Textures.DrawTexture(IGT_Constants._GameOver_ScrollBar, new Rect(GameoverScroll_BarStrtPosX, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num5, GameoverScroll_BarWid, GameoverScroll_BarHeight), false);
					if (pFacebook.isFBLoginSucess())
					{
						if (pIGT_ScrollData_GameOver_Topchase.ElementAt(m).pTexture == null)
						{
							pIgt_Textures.DrawTexture(IGT_Constants.defaultFB, new Rect(rect_GameoverScroll_pic.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num5 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), false);
						}
						else
						{
							GUI.DrawTexture(new Rect(rect_GameoverScroll_pic.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num5 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(m).pTexture);
						}
						pIgt_Textures.drawBorder(new Rect(rect_GameoverScroll_pic.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num5 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), 2f, Border_White);
					}
					if (m < 3)
					{
						GUI.DrawTexture(new Rect(rect_GameoverScroll_IdxBg.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)m + rect_GameoverScroll_IdxBg.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_IdxBg.width, rect_GameoverScroll_IdxBg.height), rankbg[m]);
						pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Idx.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num5 + rect_GameoverScroll_Idx.y + GameoverScroll_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(3f), rect_GameoverScroll_Idx.width, rect_GameoverScroll_Idx.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(m).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName - (int)IGT_UIcommonFunc.ScaleX(2f), white, TextAnchor.MiddleCenter, false);
					}
					else
					{
						pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Idx.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num5 + rect_GameoverScroll_Idx.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Idx.width, rect_GameoverScroll_Idx.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(m).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
					}
					if (pIGT_ScrollData_GameOver_Topchase.ElementAt(m).Name != null)
					{
						pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Name.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num5 + rect_GameoverScroll_Name.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Name.width, rect_GameoverScroll_Name.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(m).Name, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
					}
					else
					{
						pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Name.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num5 + rect_GameoverScroll_Name.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Name.width, rect_GameoverScroll_Name.height), "Player_" + (m + 1), IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
					}
					pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Score.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num5 + rect_GameoverScroll_Score.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Score.width, rect_GameoverScroll_Score.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(m).Score, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollScore, white, TextAnchor.MiddleCenter, false);
					continue;
				}
				num5++;
				num = IGT_UIcommonFunc.ScaleY(1f);
				pIgt_Textures.DrawTexture(IGT_Constants._GameOver_ScrollBar, new Rect(GameoverScroll_BarStrtPosX, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num5, GameoverScroll_BarWid, GameoverScroll_BarHeight), false);
				if (pFacebook.isFBLoginSucess())
				{
					if (pIGT_ScrollData_GameOver_Topchase.ElementAt(m).pTexture == null)
					{
						pIgt_Textures.DrawTexture(IGT_Constants.defaultFB, new Rect(rect_GameoverScroll_pic.x, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num5 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), false);
					}
					else
					{
						GUI.DrawTexture(new Rect(rect_GameoverScroll_pic.x, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num5 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(m).pTexture);
					}
					pIgt_Textures.drawBorder(new Rect(rect_GameoverScroll_pic.x, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num5 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), 2f, Border_White);
				}
				if (m < 3)
				{
					GUI.DrawTexture(new Rect(rect_GameoverScroll_IdxBg.x, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)m + rect_GameoverScroll_IdxBg.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_IdxBg.width, rect_GameoverScroll_IdxBg.height), rankbg[m]);
					pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Idx.x, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num5 + rect_GameoverScroll_Idx.y + GameoverScroll_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(3f), rect_GameoverScroll_Idx.width, rect_GameoverScroll_Idx.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(m).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName - (int)IGT_UIcommonFunc.ScaleX(2f), white, TextAnchor.MiddleCenter, false);
				}
				else
				{
					pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Idx.x, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num5 + rect_GameoverScroll_Idx.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Idx.width, rect_GameoverScroll_Idx.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(m).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
				}
				if (pIGT_ScrollData_GameOver_Topchase.ElementAt(m).Name != null)
				{
					pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Name.x, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num5 + rect_GameoverScroll_Name.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Name.width, rect_GameoverScroll_Name.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(m).Name, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
				}
				else
				{
					pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Name.x, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num5 + rect_GameoverScroll_Name.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Name.width, rect_GameoverScroll_Name.height), "Player_" + (m + 1), IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
				}
				pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Score.x, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num5 + rect_GameoverScroll_Score.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Score.width, rect_GameoverScroll_Score.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(m).Score, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollScore, white, TextAnchor.MiddleCenter, false);
			}
			break;
		}
		case 2:
		{
			if (!bScrollAnim)
			{
				if (pScroller_GameoverScroll.computeFlingScroller())
				{
					GameoverScroll_CurPos.y = IGT_UIcommonFunc.reScaleY(pScroller_GameoverScroll.getFlingY());
				}
				if (pScroller_GameoverScroll.CalcEdgeEffect())
				{
					GameoverScroll_CurPos.y = IGT_UIcommonFunc.reScaleY(pScroller_GameoverScroll.getEdgeY());
				}
			}
			float num2 = IGT_UIcommonFunc.ScaleY(GameoverScroll_CurPos.y);
			GameoverScroll_beginScrollViewScrollPos = GUI.BeginScrollView(new Rect(ScrollViewRect_GameoverScreen.x, ScrollViewRect_GameoverScreen.y, ScrollViewRect_GameoverScreen.width, ScrollViewRect_GameoverScreen.height), GameoverScroll_beginScrollViewScrollPos, default(Rect));
			for (int i = 0; i < nBustedScrollCount; i++)
			{
				if (num2 + (GameoverScroll_BarHeight + GameoverScroll_BarGap_Busted) * (float)i >= 0f - (GameoverScroll_BarHeight + GameoverScroll_BarGap_Busted) && num2 + (GameoverScroll_BarHeight + GameoverScroll_BarGap_Busted) * (float)i <= ScrollViewRect_GameoverScreen.height)
				{
					pIgt_Textures.DrawTexture(IGT_Constants._GameOver_ScrollBar, new Rect(GameoverScroll_BarStrtPosX, num2 + (GameoverScroll_BarHeight + GameoverScroll_BarGap_Busted) * (float)i, GameoverScroll_BarWid, GameoverScroll_BarHeight), false);
					pIgt_Textures.DrawTexture(IGT_Constants.AIPlayer_FacePicx[i], new Rect(rect_GameoverScroll_pic.x, num2 + (GameoverScroll_BarHeight + GameoverScroll_BarGap_Busted) * (float)i + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar - IGT_UIcommonFunc.ScaleY(4f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), true);
					pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Idx.x, num2 + (GameoverScroll_BarHeight + GameoverScroll_BarGap_Busted) * (float)i + rect_GameoverScroll_Idx.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Idx.width, rect_GameoverScroll_Idx.height), i + 1 + ".", IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.white, TextAnchor.MiddleCenter, false);
					pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Name.x + IGT_UIcommonFunc.ScaleX(20f), num2 + (GameoverScroll_BarHeight + GameoverScroll_BarGap_Busted) * (float)i + rect_GameoverScroll_Name.y + GameoverScroll_DatasGapFrmBar - IGT_UIcommonFunc.ScaleY(3f), rect_GameoverScroll_Name.width, rect_GameoverScroll_Name.height), pHero.pIGT_CaughtDet[i].Name, IGT_Constants.Font_chelaOne, (int)IGT_UIcommonFunc.ScaleX(17f), Color.white, TextAnchor.MiddleLeft, false);
					pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Score.x, num2 + (GameoverScroll_BarHeight + GameoverScroll_BarGap_Busted) * (float)i + rect_GameoverScroll_Score.y + GameoverScroll_DatasGapFrmBar - IGT_UIcommonFunc.ScaleY(8f), rect_GameoverScroll_Score.width, rect_GameoverScroll_Score.height), "Caught :  " + pHero.pIGT_CaughtDet[i].nCaughtCount, IGT_Constants.Font_chelaOne, (int)IGT_UIcommonFunc.ScaleX(16f), Color.white, TextAnchor.MiddleCenter, false);
					if (pHero.pIGT_CaughtDet[i].nAttempts < 2)
					{
						pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Score.x, num2 + (GameoverScroll_BarHeight + GameoverScroll_BarGap_Busted) * (float)i + rect_GameoverScroll_Score.y + GameoverScroll_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(6f), rect_GameoverScroll_Score.width, rect_GameoverScroll_Score.height), pHero.pIGT_CaughtDet[i].nAttempts + "  Attempt", IGT_Constants.Font_chelaOne, (int)IGT_UIcommonFunc.ScaleX(10f), new Color(1f, 1f, 0.501f), TextAnchor.MiddleCenter, false);
					}
					else
					{
						pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Score.x, num2 + (GameoverScroll_BarHeight + GameoverScroll_BarGap_Busted) * (float)i + rect_GameoverScroll_Score.y + GameoverScroll_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(6f), rect_GameoverScroll_Score.width, rect_GameoverScroll_Score.height), pHero.pIGT_CaughtDet[i].nAttempts + "  Attempts", IGT_Constants.Font_chelaOne, (int)IGT_UIcommonFunc.ScaleX(10f), new Color(1f, 1f, 0.501f), TextAnchor.MiddleCenter, false);
					}
				}
			}
			GUI.EndScrollView();
			break;
		}
		}
	}

	private void gameOverScrollDataSel()
	{
		string text = null;
		if (pFacebook.isFBLoginSucess())
		{
			text = pFacebook.getMEUserID();
		}
		float num = 0f;
		bDrawInvite_Chase = false;
		switch (nGameoverScrollType)
		{
		case 0:
			if (pFacebook.isFBLoginSucess())
			{
				int num3 = -1;
				int num4 = 4;
				if (pFacebook.UserFrndsInfo[text].rank > 4)
				{
					num4 = 5;
				}
				for (int j = 0; j < num4; j++)
				{
					if (j == 2 && pFacebook.UserFrndsInfo[text].rank > 4)
					{
						continue;
					}
					num3++;
					if (j < pIGT_ScrollData_GameOver_Fb.Count)
					{
						if (j == 3 && pFacebook.UserFrndsInfo[text].rank > 4)
						{
							pIgt_Textures.DrawTexture(IGT_Constants._DotImg, new Rect(rect_GameoverScroll_Dot.x, Gameover_FBitems_StrtY + GameoverScroll_BarHeight * (float)num3 + rect_GameoverScroll_Dot.y, rect_GameoverScroll_Dot.width, rect_GameoverScroll_Dot.height), false);
							num = IGT_UIcommonFunc.ScaleY(3f);
						}
						if (pIGT_ScrollData_GameOver_Fb.ElementAt(j).Name.Equals("Me"))
						{
							pIgt_Textures.DrawTexture(IGT_Constants._GameOver_ScrollBar, new Rect(GameoverScroll_BarStrtPosX, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num3, GameoverScroll_BarWid, GameoverScroll_BarHeight), false);
							GUI.DrawTexture(new Rect(rect_GameoverScroll_pic.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num3 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), pIGT_ScrollData_GameOver_Fb.ElementAt(j).pTexture);
							pIgt_Textures.drawBorder(new Rect(rect_GameoverScroll_pic.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num3 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), 2f, Border_White);
							if (j < 3)
							{
								GUI.DrawTexture(new Rect(rect_GameoverScroll_IdxBg.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)j + rect_GameoverScroll_IdxBg.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_IdxBg.width, rect_GameoverScroll_IdxBg.height), rankbg[j]);
								pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Idx.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num3 + rect_GameoverScroll_Idx.y + GameoverScroll_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(3f), rect_GameoverScroll_Idx.width, rect_GameoverScroll_Idx.height), pIGT_ScrollData_GameOver_Fb.ElementAt(j).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName - (int)IGT_UIcommonFunc.ScaleX(2f), Color.yellow, TextAnchor.MiddleCenter, false);
							}
							else
							{
								pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Idx.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num3 + rect_GameoverScroll_Idx.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Idx.width, rect_GameoverScroll_Idx.height), pIGT_ScrollData_GameOver_Fb.ElementAt(j).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.yellow, TextAnchor.MiddleCenter, false);
							}
							pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Name.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num3 + rect_GameoverScroll_Name.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Name.width, rect_GameoverScroll_Name.height), pIGT_ScrollData_GameOver_Fb.ElementAt(j).Name, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.yellow, TextAnchor.MiddleCenter, false);
							pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Score.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num3 + rect_GameoverScroll_Score.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Score.width, rect_GameoverScroll_Score.height), pIGT_ScrollData_GameOver_Fb.ElementAt(j).Score, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollScore, Color.yellow, TextAnchor.MiddleCenter, false);
						}
						else
						{
							pIgt_Textures.DrawTexture(IGT_Constants._GameOver_ScrollBar, new Rect(GameoverScroll_BarStrtPosX, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num3, GameoverScroll_BarWid, GameoverScroll_BarHeight), false);
							GUI.DrawTexture(new Rect(rect_GameoverScroll_pic.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num3 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), pIGT_ScrollData_GameOver_Fb.ElementAt(j).pTexture);
							pIgt_Textures.drawBorder(new Rect(rect_GameoverScroll_pic.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num3 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), 2f, Border_White);
							if (j < 3)
							{
								GUI.DrawTexture(new Rect(rect_GameoverScroll_IdxBg.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)j + rect_GameoverScroll_IdxBg.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_IdxBg.width, rect_GameoverScroll_IdxBg.height), rankbg[j]);
								pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Idx.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num3 + rect_GameoverScroll_Idx.y + GameoverScroll_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(3f), rect_GameoverScroll_Idx.width, rect_GameoverScroll_Idx.height), pIGT_ScrollData_GameOver_Fb.ElementAt(j).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName - (int)IGT_UIcommonFunc.ScaleX(2f), Color.white, TextAnchor.MiddleCenter, false);
							}
							else
							{
								pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Idx.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num3 + rect_GameoverScroll_Idx.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Idx.width, rect_GameoverScroll_Idx.height), pIGT_ScrollData_GameOver_Fb.ElementAt(j).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.white, TextAnchor.MiddleCenter, false);
							}
							pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Name.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num3 + rect_GameoverScroll_Name.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Name.width, rect_GameoverScroll_Name.height), pIGT_ScrollData_GameOver_Fb.ElementAt(j).Name, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.white, TextAnchor.MiddleCenter, false);
							pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Score.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num3 + rect_GameoverScroll_Score.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Score.width, rect_GameoverScroll_Score.height), pIGT_ScrollData_GameOver_Fb.ElementAt(j).Score, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollScore, Color.white, TextAnchor.MiddleCenter, false);
						}
					}
					else
					{
						bDrawInvite_Chase = true;
					}
				}
				if (bDrawInvite_Chase)
				{
					Rect rect = new Rect(IGT_UIcommonFunc.ScaleX(88f), IGT_UIcommonFunc.ScaleY(165f), IGT_UIcommonFunc.ScaleX(130f), IGT_UIcommonFunc.ScaleY(42f));
					btnFBLeaderBoardInvite.setX(rect.x);
					btnFBLeaderBoardInvite.setY(rect.y);
					btnFBLeaderBoardInvite.setWidth(rect.width);
					btnFBLeaderBoardInvite.setHeight(rect.height);
					btnFBLeaderBoardInvite.Draw_Button();
					pIgt_Lable.DrawLable(new Rect(btnFBLeaderBoardInvite.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(10f), btnFBLeaderBoardInvite.getCurrentDimension().y, btnFBLeaderBoardInvite.getCurrentDimension().width, btnFBLeaderBoardInvite.getCurrentDimension().height), "Invite", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
					pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, new Rect(btnFBLeaderBoardInvite.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(8f), btnFBLeaderBoardInvite.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), false);
				}
			}
			else
			{
				pIgt_Lable.DrawLable(new Rect(rect_purchaseProductDescp.x + IGT_UIcommonFunc.ScaleX(10f), IGT_UIcommonFunc.ScaleY(70f), rect_purchaseProductDescp.width, rect_purchaseProductDescp.height), fbLogInTxt, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black);
				But_MailBox_FBConnect.setY(IGT_UIcommonFunc.ScaleY(120f));
				But_MailBox_FBConnect.Draw_Button();
				if (IGT_Preference.getInstance()._Get(kFBLoginfirstTime, 0) == 0)
				{
					pIgt_Textures.DrawTexture(IGT_Constants._Life, new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(130f), But_MailBox_FBConnect.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), 20f, Vector2.zero);
					pIgt_Lable.DrawLable(new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(130f), But_MailBox_FBConnect.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(4f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleY(22f)), "+" + IGT_Constants.nFBLoginLife, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black, 22f, Vector2.zero);
				}
				pIgt_Lable.DrawLable(new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(10f), But_MailBox_FBConnect.getCurrentDimension().y, But_MailBox_FBConnect.getCurrentDimension().width, But_MailBox_FBConnect.getCurrentDimension().height), "Connect", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
				pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(8f), But_MailBox_FBConnect.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), false);
			}
			break;
		case 1:
		{
			if (pIGT_ScrollData_GameOver_Topchase == null)
			{
				break;
			}
			int num5 = -1;
			int num6 = 4;
			string text2 = null;
			text2 = ((!pFacebook.isFBLoginSucess()) ? strDeviceID : text);
			if (pFacebook.Chase_Global[text2].rank > 4)
			{
				num6 = 5;
			}
			for (int k = 0; k < num6; k++)
			{
				if (k == 2 && pFacebook.Chase_Global[text2].rank > 4)
				{
					continue;
				}
				num5++;
				if (k >= pIGT_ScrollData_GameOver_Topchase.Count)
				{
					continue;
				}
				if (k == 3 && pFacebook.Chase_Global[text2].rank > 4)
				{
					pIgt_Textures.DrawTexture(IGT_Constants._DotImg, new Rect(rect_GameoverScroll_Dot.x, Gameover_FBitems_StrtY + GameoverScroll_BarHeight * (float)num5 + rect_GameoverScroll_Dot.y, rect_GameoverScroll_Dot.width, rect_GameoverScroll_Dot.height), false);
					num = IGT_UIcommonFunc.ScaleY(4f);
				}
				else
				{
					num = IGT_UIcommonFunc.ScaleY(3f);
				}
				if (pIGT_ScrollData_GameOver_Topchase.ElementAt(k).Id.Equals(text2))
				{
					pIgt_Textures.DrawTexture(IGT_Constants._GameOver_ScrollBar, new Rect(GameoverScroll_BarStrtPosX, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num5, GameoverScroll_BarWid, GameoverScroll_BarHeight), false);
					if (pFacebook.isFBLoginSucess())
					{
						GUI.DrawTexture(new Rect(rect_GameoverScroll_pic.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num5 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(k).pTexture);
						pIgt_Textures.drawBorder(new Rect(rect_GameoverScroll_pic.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num5 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), 2f, Border_White);
					}
					if (k < 3)
					{
						GUI.DrawTexture(new Rect(rect_GameoverScroll_IdxBg.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)k + rect_GameoverScroll_IdxBg.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_IdxBg.width, rect_GameoverScroll_IdxBg.height), rankbg[k]);
						pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Idx.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num5 + rect_GameoverScroll_Idx.y + GameoverScroll_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(3f), rect_GameoverScroll_Idx.width, rect_GameoverScroll_Idx.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(k).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName - (int)IGT_UIcommonFunc.ScaleX(2f), Color.yellow, TextAnchor.MiddleCenter, false);
					}
					else
					{
						pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Idx.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num5 + rect_GameoverScroll_Idx.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Idx.width, rect_GameoverScroll_Idx.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(k).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.yellow, TextAnchor.MiddleCenter, false);
					}
					pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Name.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num5 + rect_GameoverScroll_Name.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Name.width, rect_GameoverScroll_Name.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(k).Name, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.yellow, TextAnchor.MiddleCenter, false);
					pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Score.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num5 + rect_GameoverScroll_Score.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Score.width, rect_GameoverScroll_Score.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(k).Score, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollScore, Color.yellow, TextAnchor.MiddleCenter, false);
				}
				else
				{
					pIgt_Textures.DrawTexture(IGT_Constants._GameOver_ScrollBar, new Rect(GameoverScroll_BarStrtPosX, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num5, GameoverScroll_BarWid, GameoverScroll_BarHeight), false);
					if (pFacebook.isFBLoginSucess())
					{
						GUI.DrawTexture(new Rect(rect_GameoverScroll_pic.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num5 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(k).pTexture);
						pIgt_Textures.drawBorder(new Rect(rect_GameoverScroll_pic.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num5 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), 2f, Border_White);
					}
					if (k < 3)
					{
						GUI.DrawTexture(new Rect(rect_GameoverScroll_IdxBg.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)k + rect_GameoverScroll_IdxBg.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_IdxBg.width, rect_GameoverScroll_IdxBg.height), rankbg[k]);
						pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Idx.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num5 + rect_GameoverScroll_Idx.y + GameoverScroll_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(3f), rect_GameoverScroll_Idx.width, rect_GameoverScroll_Idx.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(k).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName - (int)IGT_UIcommonFunc.ScaleX(2f), Color.white, TextAnchor.MiddleCenter, false);
					}
					else
					{
						pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Idx.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num5 + rect_GameoverScroll_Idx.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Idx.width, rect_GameoverScroll_Idx.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(k).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.white, TextAnchor.MiddleCenter, false);
					}
					pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Name.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num5 + rect_GameoverScroll_Name.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Name.width, rect_GameoverScroll_Name.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(k).Name, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.white, TextAnchor.MiddleCenter, false);
					pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Score.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num5 + rect_GameoverScroll_Score.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Score.width, rect_GameoverScroll_Score.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(k).Score, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollScore, Color.white, TextAnchor.MiddleCenter, false);
				}
			}
			break;
		}
		case 2:
		{
			if (!bScrollAnim)
			{
				if (pScroller_GameoverScroll.computeFlingScroller())
				{
					GameoverScroll_CurPos.y = IGT_UIcommonFunc.reScaleY(pScroller_GameoverScroll.getFlingY());
				}
				if (pScroller_GameoverScroll.CalcEdgeEffect())
				{
					GameoverScroll_CurPos.y = IGT_UIcommonFunc.reScaleY(pScroller_GameoverScroll.getEdgeY());
				}
			}
			float num2 = IGT_UIcommonFunc.ScaleY(GameoverScroll_CurPos.y);
			GameoverScroll_beginScrollViewScrollPos = GUI.BeginScrollView(new Rect(ScrollViewRect_GameoverScreen.x, ScrollViewRect_GameoverScreen.y, ScrollViewRect_GameoverScreen.width, ScrollViewRect_GameoverScreen.height), GameoverScroll_beginScrollViewScrollPos, default(Rect));
			for (int i = 0; i < nBustedScrollCount; i++)
			{
				if (num2 + (GameoverScroll_BarHeight + GameoverScroll_BarGap_Busted) * (float)i >= 0f - (GameoverScroll_BarHeight + GameoverScroll_BarGap_Busted) && num2 + (GameoverScroll_BarHeight + GameoverScroll_BarGap_Busted) * (float)i <= ScrollViewRect_GameoverScreen.height)
				{
					pIgt_Textures.DrawTexture(IGT_Constants._GameOver_ScrollBar, new Rect(GameoverScroll_BarStrtPosX, num2 + (GameoverScroll_BarHeight + GameoverScroll_BarGap_Busted) * (float)i, GameoverScroll_BarWid, GameoverScroll_BarHeight), false);
					pIgt_Textures.DrawTexture(IGT_Constants.AIPlayer_FacePicx[i], new Rect(rect_GameoverScroll_pic.x, num2 + (GameoverScroll_BarHeight + GameoverScroll_BarGap_Busted) * (float)i + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar - IGT_UIcommonFunc.ScaleY(4f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), true);
					pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Idx.x, num2 + (GameoverScroll_BarHeight + GameoverScroll_BarGap_Busted) * (float)i + rect_GameoverScroll_Idx.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Idx.width, rect_GameoverScroll_Idx.height), i + 1 + ".", IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.white, TextAnchor.MiddleCenter, false);
					pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Name.x + IGT_UIcommonFunc.ScaleX(20f), num2 + (GameoverScroll_BarHeight + GameoverScroll_BarGap_Busted) * (float)i + rect_GameoverScroll_Name.y + GameoverScroll_DatasGapFrmBar - IGT_UIcommonFunc.ScaleY(3f), rect_GameoverScroll_Name.width, rect_GameoverScroll_Name.height), pHero.pIGT_CaughtDet[i].Name, IGT_Constants.Font_chelaOne, (int)IGT_UIcommonFunc.ScaleX(17f), Color.white, TextAnchor.MiddleLeft, false);
					pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Score.x, num2 + (GameoverScroll_BarHeight + GameoverScroll_BarGap_Busted) * (float)i + rect_GameoverScroll_Score.y + GameoverScroll_DatasGapFrmBar - IGT_UIcommonFunc.ScaleY(8f), rect_GameoverScroll_Score.width, rect_GameoverScroll_Score.height), "Caught :  " + pHero.pIGT_CaughtDet[i].nCaughtCount, IGT_Constants.Font_chelaOne, (int)IGT_UIcommonFunc.ScaleX(16f), Color.white, TextAnchor.MiddleCenter, false);
					if (pHero.pIGT_CaughtDet[i].nAttempts < 2)
					{
						pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Score.x, num2 + (GameoverScroll_BarHeight + GameoverScroll_BarGap_Busted) * (float)i + rect_GameoverScroll_Score.y + GameoverScroll_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(6f), rect_GameoverScroll_Score.width, rect_GameoverScroll_Score.height), pHero.pIGT_CaughtDet[i].nAttempts + "  Attempt", IGT_Constants.Font_chelaOne, (int)IGT_UIcommonFunc.ScaleX(10f), new Color(1f, 1f, 0.501f), TextAnchor.MiddleCenter, false);
					}
					else
					{
						pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Score.x, num2 + (GameoverScroll_BarHeight + GameoverScroll_BarGap_Busted) * (float)i + rect_GameoverScroll_Score.y + GameoverScroll_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(6f), rect_GameoverScroll_Score.width, rect_GameoverScroll_Score.height), pHero.pIGT_CaughtDet[i].nAttempts + "  Attempts", IGT_Constants.Font_chelaOne, (int)IGT_UIcommonFunc.ScaleX(10f), new Color(1f, 1f, 0.501f), TextAnchor.MiddleCenter, false);
					}
				}
			}
			GUI.EndScrollView();
			break;
		}
		}
	}

	public void Alt_missionCompletedScrollDataSel()
	{
		string text = null;
		if (pFacebook.isFBLoginSucess())
		{
			text = pFacebook.getMEUserID();
		}
		float num = 0f;
		bDrawInvite_Mission = false;
		int num2 = -1;
		Color white = Color.white;
		switch (nMC_ScrollType)
		{
		case 0:
			if (pFacebook.isFBLoginSucess())
			{
				if (pIGT_ScrollData_MC_FbFriends == null)
				{
					break;
				}
				bool flag2 = false;
				if (pFacebook.Mission_Friends != null && pFacebook.Mission_Friends.ContainsKey(text))
				{
					for (int k = 0; k < pIGT_ScrollData_MC_FbFriends.Count; k++)
					{
						if (pIGT_ScrollData_MC_FbFriends.ElementAt(k).Id.Equals(text) && int.Parse(pIGT_ScrollData_MC_FbFriends.ElementAt(k).Rank) > 4)
						{
							flag2 = true;
						}
					}
				}
				int num3 = ((!flag2) ? 4 : 5);
				for (int l = 0; l < num3; l++)
				{
					if (l < pIGT_ScrollData_MC_FbFriends.Count)
					{
						white = ((pIGT_ScrollData_MC_FbFriends.ElementAt(l) == null || !pIGT_ScrollData_MC_FbFriends.ElementAt(l).Id.Equals(text)) ? Color.white : Color.yellow);
						if (flag2)
						{
							if (l != 2)
							{
								num2++;
								num = IGT_UIcommonFunc.ScaleY(0.1f);
								if (l == 3)
								{
									pIgt_Textures.DrawTexture(IGT_Constants._DotImg, new Rect(rect_GameoverScroll_Dot.x, Gameover_FBitems_StrtY + GameoverScroll_BarHeight * (float)num2 + rect_GameoverScroll_Dot.y, rect_GameoverScroll_Dot.width, rect_GameoverScroll_Dot.height), false);
									num = IGT_UIcommonFunc.ScaleY(4.7f);
								}
								else if (l >= 3)
								{
									num = IGT_UIcommonFunc.ScaleY(3.2f);
								}
								pIgt_Textures.DrawTexture(IGT_Constants._GameOver_ScrollBar, new Rect(GameoverScroll_BarStrtPosX, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2, GameoverScroll_BarWid, GameoverScroll_BarHeight), false);
								GUI.DrawTexture(new Rect(rect_GameoverScroll_pic.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), pIGT_ScrollData_MC_FbFriends.ElementAt(l).pTexture);
								pIgt_Textures.drawBorder(new Rect(rect_GameoverScroll_pic.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), 2f, Border_White);
								if (l < 3)
								{
									GUI.DrawTexture(new Rect(rect_GameoverScroll_IdxBg.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_IdxBg.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_IdxBg.width, rect_GameoverScroll_IdxBg.height), rankbg[l]);
									pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Idx.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_Idx.y + GameoverScroll_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(3f), rect_GameoverScroll_Idx.width, rect_GameoverScroll_Idx.height), pIGT_ScrollData_MC_FbFriends.ElementAt(l).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName - (int)IGT_UIcommonFunc.ScaleX(2f), white, TextAnchor.MiddleCenter, false);
								}
								else
								{
									pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Idx.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_Idx.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Idx.width, rect_GameoverScroll_Idx.height), pIGT_ScrollData_MC_FbFriends.ElementAt(l).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
								}
								if (pIGT_ScrollData_MC_FbFriends.ElementAt(l).Name != null)
								{
									pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Name.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_Name.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Name.width, rect_GameoverScroll_Name.height), pIGT_ScrollData_MC_FbFriends.ElementAt(l).Name, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
								}
								else
								{
									pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Name.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_Name.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Name.width, rect_GameoverScroll_Name.height), "Player_" + (l + 1), IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
								}
								pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Score.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_Score.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Score.width, rect_GameoverScroll_Score.height), pIGT_ScrollData_MC_FbFriends.ElementAt(l).Score, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollScore, white, TextAnchor.MiddleCenter, false);
							}
						}
						else
						{
							num2++;
							num = IGT_UIcommonFunc.ScaleY(1f);
							pIgt_Textures.DrawTexture(IGT_Constants._GameOver_ScrollBar, new Rect(GameoverScroll_BarStrtPosX, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2, GameoverScroll_BarWid, GameoverScroll_BarHeight), false);
							GUI.DrawTexture(new Rect(rect_GameoverScroll_pic.x, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), pIGT_ScrollData_MC_FbFriends.ElementAt(l).pTexture);
							pIgt_Textures.drawBorder(new Rect(rect_GameoverScroll_pic.x, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), 2f, Border_White);
							if (l < 3)
							{
								GUI.DrawTexture(new Rect(rect_GameoverScroll_IdxBg.x, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)l + rect_GameoverScroll_IdxBg.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_IdxBg.width, rect_GameoverScroll_IdxBg.height), rankbg[l]);
								pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Idx.x, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_Idx.y + GameoverScroll_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(3f), rect_GameoverScroll_Idx.width, rect_GameoverScroll_Idx.height), pIGT_ScrollData_MC_FbFriends.ElementAt(l).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName - (int)IGT_UIcommonFunc.ScaleX(2f), white, TextAnchor.MiddleCenter, false);
							}
							else
							{
								pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Idx.x, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_Idx.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Idx.width, rect_GameoverScroll_Idx.height), pIGT_ScrollData_MC_FbFriends.ElementAt(l).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
							}
							if (pIGT_ScrollData_MC_FbFriends.ElementAt(l).Name != null)
							{
								pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Name.x, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_Name.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Name.width, rect_GameoverScroll_Name.height), pIGT_ScrollData_MC_FbFriends.ElementAt(l).Name, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
							}
							else
							{
								pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Name.x, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_Name.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Name.width, rect_GameoverScroll_Name.height), "Player_" + (l + 1), IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
							}
							pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Score.x, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_Score.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Score.width, rect_GameoverScroll_Score.height), pIGT_ScrollData_MC_FbFriends.ElementAt(l).Score, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollScore, white, TextAnchor.MiddleCenter, false);
						}
					}
					else
					{
						bDrawInvite_Mission = true;
					}
				}
				if (bDrawInvite_Mission)
				{
					Rect base_rect = GO_Invitebtn_decide_rect(pIGT_ScrollData_MC_FbFriends.Count);
					btnFBLeaderBoardInvite.setX(base_rect.x);
					btnFBLeaderBoardInvite.setY(base_rect.y);
					btnFBLeaderBoardInvite.setWidth(base_rect.width);
					btnFBLeaderBoardInvite.setHeight(base_rect.height);
					btnFBLeaderBoardInvite.Draw_Button();
					pIgt_Lable.DrawLable(new Rect(btnFBLeaderBoardInvite.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(10f), btnFBLeaderBoardInvite.getCurrentDimension().y, btnFBLeaderBoardInvite.getCurrentDimension().width, btnFBLeaderBoardInvite.getCurrentDimension().height), "Invite", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
					pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, adj_drawrect(base_rect, new Rect(btnFBLeaderBoardInvite.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(8f), btnFBLeaderBoardInvite.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), 0), false);
					if (pFacebook.isFBLoginSucess() && (long)IGT_Preference.getInstance()._Get(kFBInviteLastUpdateTime, 0f) + IGT_Constants.dFBInviteTime <= (long)currentTimeMins())
					{
						pIgt_Textures.DrawTexture(IGT_Constants._Life, new Rect(btnFBLeaderBoardInvite.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(115f), btnFBLeaderBoardInvite.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), 24f, Vector2.zero);
						pIgt_Lable.DrawLable(new Rect(btnFBLeaderBoardInvite.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(115f), btnFBLeaderBoardInvite.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(4f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleY(22f)), "+2", IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black, 20f, Vector2.zero);
					}
				}
			}
			else
			{
				pIgt_Lable.DrawLable(new Rect(rect_purchaseProductDescp.x + IGT_UIcommonFunc.ScaleX(10f), IGT_UIcommonFunc.ScaleY(70f), rect_purchaseProductDescp.width, rect_purchaseProductDescp.height), fbLogInTxt, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
				But_MailBox_FBConnect.setY(IGT_UIcommonFunc.ScaleY(120f));
				But_MailBox_FBConnect.Draw_Button();
				if (IGT_Preference.getInstance()._Get(kFBLoginfirstTime, 0) == 0)
				{
					pIgt_Textures.DrawTexture(IGT_Constants._Life, new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(130f), But_MailBox_FBConnect.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), 20f, Vector2.zero);
					pIgt_Lable.DrawLable(new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(130f), But_MailBox_FBConnect.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(4f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleY(22f)), "+" + IGT_Constants.nFBLoginLife, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black, 22f, Vector2.zero);
				}
				pIgt_Lable.DrawLable(new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(10f), But_MailBox_FBConnect.getCurrentDimension().y, But_MailBox_FBConnect.getCurrentDimension().width, But_MailBox_FBConnect.getCurrentDimension().height), "Connect", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
				pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(8f), But_MailBox_FBConnect.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), false);
			}
			break;
		case 1:
		{
			if (pIGT_ScrollData_MC_FbGlobal == null)
			{
				break;
			}
			bool flag = false;
			num2 = -1;
			int num3 = 4;
			string text2 = null;
			text2 = ((!pFacebook.isFBLoginSucess()) ? strDeviceID : text);
			if (pFacebook.Mission_Global != null && pFacebook.Mission_Global.ContainsKey(text2))
			{
				for (int i = 0; i < pIGT_ScrollData_MC_FbGlobal.Count; i++)
				{
					if (pIGT_ScrollData_MC_FbGlobal.ElementAt(i).Id.Equals(text2) && int.Parse(pIGT_ScrollData_MC_FbGlobal.ElementAt(i).Rank) > 4)
					{
						flag = true;
					}
				}
			}
			num3 = ((!flag) ? 4 : 5);
			for (int j = 0; j < num3; j++)
			{
				if (j >= pIGT_ScrollData_MC_FbGlobal.Count)
				{
					continue;
				}
				white = ((!pIGT_ScrollData_MC_FbGlobal.ElementAt(j).Id.Equals(text2)) ? Color.white : Color.yellow);
				if (flag)
				{
					num = IGT_UIcommonFunc.ScaleY(0.1f);
					if (j == 2)
					{
						continue;
					}
					num2++;
					if (j == 3)
					{
						pIgt_Textures.DrawTexture(IGT_Constants._DotImg, new Rect(rect_GameoverScroll_Dot.x, Gameover_FBitems_StrtY + GameoverScroll_BarHeight * (float)num2 + rect_GameoverScroll_Dot.y, rect_GameoverScroll_Dot.width, rect_GameoverScroll_Dot.height), false);
						num = IGT_UIcommonFunc.ScaleY(4.7f);
					}
					else if (j >= 3)
					{
						num = IGT_UIcommonFunc.ScaleY(3.2f);
					}
					pIgt_Textures.DrawTexture(IGT_Constants._GameOver_ScrollBar, new Rect(GameoverScroll_BarStrtPosX, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2, GameoverScroll_BarWid, GameoverScroll_BarHeight), false);
					if (pFacebook.isFBLoginSucess())
					{
						if (pIGT_ScrollData_MC_FbGlobal.ElementAt(j).pTexture == null)
						{
							pIgt_Textures.DrawTexture(IGT_Constants.defaultFB, new Rect(rect_GameoverScroll_pic.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), false);
						}
						else
						{
							GUI.DrawTexture(new Rect(rect_GameoverScroll_pic.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(j).pTexture);
						}
						pIgt_Textures.drawBorder(new Rect(rect_GameoverScroll_pic.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), 2f, Border_White);
					}
					if (j < 3)
					{
						GUI.DrawTexture(new Rect(rect_GameoverScroll_IdxBg.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_IdxBg.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_IdxBg.width, rect_GameoverScroll_IdxBg.height), rankbg[j]);
						pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Idx.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_Idx.y + GameoverScroll_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(3f), rect_GameoverScroll_Idx.width, rect_GameoverScroll_Idx.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(j).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName - (int)IGT_UIcommonFunc.ScaleX(2f), white, TextAnchor.MiddleCenter, false);
					}
					else
					{
						pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Idx.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_Idx.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Idx.width, rect_GameoverScroll_Idx.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(j).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
					}
					if (pIGT_ScrollData_MC_FbGlobal.ElementAt(j).Name != null)
					{
						pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Name.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_Name.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Name.width, rect_GameoverScroll_Name.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(j).Name, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
					}
					else
					{
						pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Name.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_Name.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Name.width, rect_GameoverScroll_Name.height), "Player_" + (j + 1), IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
					}
					pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Score.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_Score.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Score.width, rect_GameoverScroll_Score.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(j).Score, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollScore, white, TextAnchor.MiddleCenter, false);
					continue;
				}
				num = IGT_UIcommonFunc.ScaleY(1f);
				num2++;
				pIgt_Textures.DrawTexture(IGT_Constants._GameOver_ScrollBar, new Rect(GameoverScroll_BarStrtPosX, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2, GameoverScroll_BarWid, GameoverScroll_BarHeight), false);
				if (pFacebook.isFBLoginSucess())
				{
					if (pIGT_ScrollData_MC_FbGlobal.ElementAt(j).pTexture == null)
					{
						pIgt_Textures.DrawTexture(IGT_Constants.defaultFB, new Rect(rect_GameoverScroll_pic.x, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), false);
					}
					else
					{
						GUI.DrawTexture(new Rect(rect_GameoverScroll_pic.x, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(j).pTexture);
					}
					pIgt_Textures.drawBorder(new Rect(rect_GameoverScroll_pic.x, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), 2f, Border_White);
				}
				if (j < 3)
				{
					GUI.DrawTexture(new Rect(rect_GameoverScroll_IdxBg.x, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_IdxBg.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_IdxBg.width, rect_GameoverScroll_IdxBg.height), rankbg[j]);
					pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Idx.x, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_Idx.y + GameoverScroll_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(3f), rect_GameoverScroll_Idx.width, rect_GameoverScroll_Idx.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(j).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName - (int)IGT_UIcommonFunc.ScaleX(2f), white, TextAnchor.MiddleCenter, false);
				}
				else
				{
					pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Idx.x, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_Idx.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Idx.width, rect_GameoverScroll_Idx.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(j).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
				}
				if (pIGT_ScrollData_MC_FbGlobal.ElementAt(j).Name != null)
				{
					pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Name.x, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_Name.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Name.width, rect_GameoverScroll_Name.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(j).Name, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
				}
				else
				{
					pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Name.x, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_Name.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Name.width, rect_GameoverScroll_Name.height), "Player_" + (j + 1), IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
				}
				pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Score.x, IGT_UIcommonFunc.ScaleY(3f) + Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_Score.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Score.width, rect_GameoverScroll_Score.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(j).Score, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollScore, white, TextAnchor.MiddleCenter, false);
			}
			break;
		}
		}
	}

	public void missionCompletedScrollDataSel()
	{
		string text = null;
		if (pFacebook.isFBLoginSucess())
		{
			text = pFacebook.getMEUserID();
		}
		float num = 0f;
		bDrawInvite_Mission = false;
		switch (nMC_ScrollType)
		{
		case 0:
			if (pFacebook.isFBLoginSucess())
			{
				if (pIGT_ScrollData_MC_FbFriends == null)
				{
					break;
				}
				int num4 = -1;
				int num5 = 4;
				if (pFacebook.Mission_Friends[text].rank > 4)
				{
					num5 = 5;
				}
				for (int j = 0; j < num5; j++)
				{
					if (j == 2 && pFacebook.Mission_Friends[text].rank > 4)
					{
						continue;
					}
					num4++;
					if (j < pIGT_ScrollData_MC_FbFriends.Count)
					{
						if (j == 3 && pFacebook.Mission_Friends[text].rank > 4)
						{
							pIgt_Textures.DrawTexture(IGT_Constants._DotImg, new Rect(rect_GameoverScroll_Dot.x, Gameover_FBitems_StrtY + GameoverScroll_BarHeight * (float)num4 + rect_GameoverScroll_Dot.y, rect_GameoverScroll_Dot.width, rect_GameoverScroll_Dot.height), false);
							num = IGT_UIcommonFunc.ScaleY(3f);
						}
						if (pIGT_ScrollData_MC_FbFriends.ElementAt(j).Name.Equals("Me"))
						{
							pIgt_Textures.DrawTexture(IGT_Constants._GameOver_ScrollBar, new Rect(GameoverScroll_BarStrtPosX, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num4, GameoverScroll_BarWid, GameoverScroll_BarHeight), false);
							GUI.DrawTexture(new Rect(rect_GameoverScroll_pic.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num4 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), pIGT_ScrollData_MC_FbFriends.ElementAt(j).pTexture);
							pIgt_Textures.drawBorder(new Rect(rect_GameoverScroll_pic.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num4 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), 2f, Border_White);
							if (j < 3)
							{
								GUI.DrawTexture(new Rect(rect_GameoverScroll_IdxBg.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num4 + rect_GameoverScroll_IdxBg.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_IdxBg.width, rect_GameoverScroll_IdxBg.height), rankbg[j]);
								pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Idx.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num4 + rect_GameoverScroll_Idx.y + GameoverScroll_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(3f), rect_GameoverScroll_Idx.width, rect_GameoverScroll_Idx.height), pIGT_ScrollData_MC_FbFriends.ElementAt(j).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName - (int)IGT_UIcommonFunc.ScaleX(2f), Color.yellow, TextAnchor.MiddleCenter, false);
							}
							else
							{
								pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Idx.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num4 + rect_GameoverScroll_Idx.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Idx.width, rect_GameoverScroll_Idx.height), pIGT_ScrollData_MC_FbFriends.ElementAt(j).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.yellow, TextAnchor.MiddleCenter, false);
							}
							pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Name.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num4 + rect_GameoverScroll_Name.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Name.width, rect_GameoverScroll_Name.height), pIGT_ScrollData_MC_FbFriends.ElementAt(j).Name, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.yellow, TextAnchor.MiddleCenter, false);
							pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Score.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num4 + rect_GameoverScroll_Score.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Score.width, rect_GameoverScroll_Score.height), pIGT_ScrollData_MC_FbFriends.ElementAt(j).Score, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollScore, Color.yellow, TextAnchor.MiddleCenter, false);
						}
						else
						{
							pIgt_Textures.DrawTexture(IGT_Constants._GameOver_ScrollBar, new Rect(GameoverScroll_BarStrtPosX, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num4, GameoverScroll_BarWid, GameoverScroll_BarHeight), false);
							GUI.DrawTexture(new Rect(rect_GameoverScroll_pic.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num4 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), pIGT_ScrollData_MC_FbFriends.ElementAt(j).pTexture);
							pIgt_Textures.drawBorder(new Rect(rect_GameoverScroll_pic.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num4 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), 2f, Border_White);
							if (j < 3)
							{
								GUI.DrawTexture(new Rect(rect_GameoverScroll_IdxBg.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)j + rect_GameoverScroll_IdxBg.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_IdxBg.width, rect_GameoverScroll_IdxBg.height), rankbg[j]);
								pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Idx.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num4 + rect_GameoverScroll_Idx.y + GameoverScroll_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(3f), rect_GameoverScroll_Idx.width, rect_GameoverScroll_Idx.height), pIGT_ScrollData_MC_FbFriends.ElementAt(j).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName - (int)IGT_UIcommonFunc.ScaleX(2f), Color.white, TextAnchor.MiddleCenter, false);
							}
							else
							{
								pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Idx.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num4 + rect_GameoverScroll_Idx.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Idx.width, rect_GameoverScroll_Idx.height), pIGT_ScrollData_MC_FbFriends.ElementAt(j).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.white, TextAnchor.MiddleCenter, false);
							}
							pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Name.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num4 + rect_GameoverScroll_Name.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Name.width, rect_GameoverScroll_Name.height), pIGT_ScrollData_MC_FbFriends.ElementAt(j).Name, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.white, TextAnchor.MiddleCenter, false);
							pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Score.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num4 + rect_GameoverScroll_Score.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Score.width, rect_GameoverScroll_Score.height), pIGT_ScrollData_MC_FbFriends.ElementAt(j).Score, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollScore, Color.white, TextAnchor.MiddleCenter, false);
						}
					}
					else
					{
						bDrawInvite_Mission = true;
					}
				}
				if (bDrawInvite_Mission)
				{
					Rect rect = new Rect(IGT_UIcommonFunc.ScaleX(88f), IGT_UIcommonFunc.ScaleY(165f), IGT_UIcommonFunc.ScaleX(130f), IGT_UIcommonFunc.ScaleY(42f));
					btnFBLeaderBoardInvite.setX(rect.x);
					btnFBLeaderBoardInvite.setY(rect.y);
					btnFBLeaderBoardInvite.setWidth(rect.width);
					btnFBLeaderBoardInvite.setHeight(rect.height);
					btnFBLeaderBoardInvite.Draw_Button();
					pIgt_Lable.DrawLable(new Rect(btnFBLeaderBoardInvite.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(10f), btnFBLeaderBoardInvite.getCurrentDimension().y, btnFBLeaderBoardInvite.getCurrentDimension().width, btnFBLeaderBoardInvite.getCurrentDimension().height), "Invite", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
					pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, new Rect(btnFBLeaderBoardInvite.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(8f), btnFBLeaderBoardInvite.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), false);
				}
			}
			else
			{
				pIgt_Lable.DrawLable(new Rect(rect_purchaseProductDescp.x + IGT_UIcommonFunc.ScaleX(10f), IGT_UIcommonFunc.ScaleY(70f), rect_purchaseProductDescp.width, rect_purchaseProductDescp.height), fbLogInTxt, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
				But_MailBox_FBConnect.setY(IGT_UIcommonFunc.ScaleY(120f));
				But_MailBox_FBConnect.Draw_Button();
				if (IGT_Preference.getInstance()._Get(kFBLoginfirstTime, 0) == 0)
				{
					pIgt_Textures.DrawTexture(IGT_Constants._Life, new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(130f), But_MailBox_FBConnect.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), 20f, Vector2.zero);
					pIgt_Lable.DrawLable(new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(130f), But_MailBox_FBConnect.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(4f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleY(22f)), "+" + IGT_Constants.nFBLoginLife, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black, 22f, Vector2.zero);
				}
				pIgt_Lable.DrawLable(new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(10f), But_MailBox_FBConnect.getCurrentDimension().y, But_MailBox_FBConnect.getCurrentDimension().width, But_MailBox_FBConnect.getCurrentDimension().height), "Connect", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
				pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(8f), But_MailBox_FBConnect.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), false);
			}
			break;
		case 1:
		{
			if (pIGT_ScrollData_MC_FbGlobal == null)
			{
				break;
			}
			int num2 = -1;
			int num3 = 4;
			string text2 = null;
			text2 = ((!pFacebook.isFBLoginSucess()) ? strDeviceID : text);
			if (pFacebook.Mission_Global[text2].rank > 4)
			{
				num3 = 5;
			}
			for (int i = 0; i < num3; i++)
			{
				if (i == 2 && pFacebook.Mission_Global[text2].rank > 4)
				{
					continue;
				}
				num2++;
				if (i >= pIGT_ScrollData_MC_FbGlobal.Count)
				{
					continue;
				}
				if (i == 3 && pFacebook.Mission_Global[text2].rank > 4)
				{
					pIgt_Textures.DrawTexture(IGT_Constants._DotImg, new Rect(rect_GameoverScroll_Dot.x, Gameover_FBitems_StrtY + GameoverScroll_BarHeight * (float)num2 + rect_GameoverScroll_Dot.y, rect_GameoverScroll_Dot.width, rect_GameoverScroll_Dot.height), false);
					num = IGT_UIcommonFunc.ScaleY(3f);
				}
				if (pIGT_ScrollData_MC_FbGlobal.ElementAt(i).Id.Equals(text2))
				{
					pIgt_Textures.DrawTexture(IGT_Constants._GameOver_ScrollBar, new Rect(GameoverScroll_BarStrtPosX, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2, GameoverScroll_BarWid, GameoverScroll_BarHeight), false);
					if (pFacebook.isFBLoginSucess())
					{
						GUI.DrawTexture(new Rect(rect_GameoverScroll_pic.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(i).pTexture);
						pIgt_Textures.drawBorder(new Rect(rect_GameoverScroll_pic.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), 2f, Border_White);
					}
					if (i < 3)
					{
						GUI.DrawTexture(new Rect(rect_GameoverScroll_IdxBg.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_IdxBg.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_IdxBg.width, rect_GameoverScroll_IdxBg.height), rankbg[i]);
						pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Idx.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_Idx.y + GameoverScroll_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(3f), rect_GameoverScroll_Idx.width, rect_GameoverScroll_Idx.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(i).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName - (int)IGT_UIcommonFunc.ScaleX(2f), Color.yellow, TextAnchor.MiddleCenter, false);
					}
					else
					{
						pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Idx.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_Idx.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Idx.width, rect_GameoverScroll_Idx.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(i).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.yellow, TextAnchor.MiddleCenter, false);
					}
					pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Name.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_Name.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Name.width, rect_GameoverScroll_Name.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(i).Name, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.yellow, TextAnchor.MiddleCenter, false);
					pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Score.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_Score.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Score.width, rect_GameoverScroll_Score.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(i).Score, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollScore, Color.yellow, TextAnchor.MiddleCenter, false);
				}
				else
				{
					pIgt_Textures.DrawTexture(IGT_Constants._GameOver_ScrollBar, new Rect(GameoverScroll_BarStrtPosX, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2, GameoverScroll_BarWid, GameoverScroll_BarHeight), false);
					if (pFacebook.isFBLoginSucess())
					{
						GUI.DrawTexture(new Rect(rect_GameoverScroll_pic.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(i).pTexture);
						pIgt_Textures.drawBorder(new Rect(rect_GameoverScroll_pic.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_pic.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_pic.width, rect_GameoverScroll_pic.height), 2f, Border_White);
					}
					if (i < 3)
					{
						GUI.DrawTexture(new Rect(rect_GameoverScroll_IdxBg.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_IdxBg.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_IdxBg.width, rect_GameoverScroll_IdxBg.height), rankbg[i]);
						pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Idx.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_Idx.y + GameoverScroll_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(3f), rect_GameoverScroll_Idx.width, rect_GameoverScroll_Idx.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(i).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName - (int)IGT_UIcommonFunc.ScaleX(2f), Color.white, TextAnchor.MiddleCenter, false);
					}
					else
					{
						pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Idx.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_Idx.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Idx.width, rect_GameoverScroll_Idx.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(i).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.white, TextAnchor.MiddleCenter, false);
					}
					pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Name.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_Name.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Name.width, rect_GameoverScroll_Name.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(i).Name, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.white, TextAnchor.MiddleCenter, false);
					pIgt_Lable.DrawLable(new Rect(rect_GameoverScroll_Score.x, Gameover_FBitems_StrtY + (GameoverScroll_BarHeight + GameoverScroll_BarGap + num) * (float)num2 + rect_GameoverScroll_Score.y + GameoverScroll_DatasGapFrmBar, rect_GameoverScroll_Score.width, rect_GameoverScroll_Score.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(i).Score, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollScore, Color.white, TextAnchor.MiddleCenter, false);
				}
			}
			break;
		}
		}
	}

	public void GFBleaderBoardData()
	{
		string text = null;
		if (pFacebook.isFBLoginSucess())
		{
			text = pFacebook.getMEUserID();
		}
		float num = 0f;
		bDrawInvite_Mission = false;
		switch (nMC_ScrollType)
		{
		case 0:
			if (pFacebook.isFBLoginSucess())
			{
				if (pIGT_ScrollData_MC_FbFriends == null)
				{
					break;
				}
				for (int j = 0; j < 5; j++)
				{
					if (j < pIGT_ScrollData_MC_FbFriends.Count)
					{
						if (j == 3 && pFacebook.Mission_Friends[text].rank > 5)
						{
							pIgt_Textures.DrawTexture(IGT_Constants._DotImg, new Rect(rect_menuLB_dot.x, menuLB_FBitems_startY + menuLB_BarHeight * (float)j + IGT_UIcommonFunc.ScaleY(6f), rect_menuLB_dot.width, rect_menuLB_dot.height), false);
							num = IGT_UIcommonFunc.ScaleY(5f);
						}
						if (pIGT_ScrollData_MC_FbFriends.ElementAt(j).Name.Equals("Me"))
						{
							if (pFacebook.Mission_Friends[text].rank > 5)
							{
								num = IGT_UIcommonFunc.ScaleY(4f);
							}
							GUI.DrawTexture(new Rect(menuLB_BarStrtPosX, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)j, menuLB_BarWidth, menuLB_BarHeight), Drawrect_clr1);
							GUI.DrawTexture(new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)j + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), pIGT_ScrollData_MC_FbFriends.ElementAt(j).pTexture);
							pIgt_Textures.drawBorder(new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)j + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), 2f, Border_White);
							if (j < 3)
							{
								GUI.DrawTexture(new Rect(rect_menuLB_IdxBG.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)j + rect_menuLB_IdxBG.y + menuLB_DatasGapFrmBar, rect_menuLB_IdxBG.width + IGT_UIcommonFunc.ScaleX(5f), rect_menuLB_IdxBG.height + IGT_UIcommonFunc.ScaleY(5f)), rankbg[j]);
								pIgt_Lable.DrawLable(new Rect(rect_menuLB_Idx.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)j + rect_menuLB_Idx.y + menuLB_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(5f), rect_menuLB_Idx.width, rect_menuLB_Idx.height), pIGT_ScrollData_MC_FbFriends.ElementAt(j).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.white, TextAnchor.MiddleCenter, false);
							}
							else
							{
								pIgt_Lable.DrawLable(new Rect(rect_menuLB_Idx.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)j + rect_menuLB_Idx.y + menuLB_DatasGapFrmBar, rect_menuLB_Idx.width, rect_menuLB_Idx.height), pIGT_ScrollData_MC_FbFriends.ElementAt(j).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.white, TextAnchor.MiddleCenter, false);
							}
							pIgt_Lable.DrawLable(new Rect(rect_menuLB_Name.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)j + rect_menuLB_Name.y + menuLB_DatasGapFrmBar, rect_menuLB_Name.width, rect_GameoverScroll_Name.height), pIGT_ScrollData_MC_FbFriends.ElementAt(j).Name, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.yellow, TextAnchor.MiddleCenter, false);
							pIgt_Lable.DrawLable(new Rect(rect_menuLB_Score.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)j + rect_menuLB_Score.y + menuLB_DatasGapFrmBar, rect_menuLB_Score.width, rect_menuLB_Score.height), pIGT_ScrollData_MC_FbFriends.ElementAt(j).Score, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollScore, Color.yellow, TextAnchor.MiddleCenter, false);
						}
						else
						{
							GUI.DrawTexture(new Rect(menuLB_BarStrtPosX, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)j, menuLB_BarWidth, menuLB_BarHeight), Drawrect_clr2);
							GUI.DrawTexture(new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)j + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), pIGT_ScrollData_MC_FbFriends.ElementAt(j).pTexture);
							pIgt_Textures.drawBorder(new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)j + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), 2f, Border_White);
							if (j < 3)
							{
								GUI.DrawTexture(new Rect(rect_menuLB_IdxBG.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)j + rect_menuLB_IdxBG.y + menuLB_DatasGapFrmBar, rect_menuLB_IdxBG.width + IGT_UIcommonFunc.ScaleX(5f), rect_menuLB_IdxBG.height + IGT_UIcommonFunc.ScaleY(5f)), rankbg[j]);
								pIgt_Lable.DrawLable(new Rect(rect_menuLB_Idx.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)j + rect_menuLB_Idx.y + menuLB_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(5f), rect_menuLB_Idx.width, rect_menuLB_Idx.height), pIGT_ScrollData_MC_FbFriends.ElementAt(j).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.white, TextAnchor.MiddleCenter, false);
							}
							else
							{
								pIgt_Lable.DrawLable(new Rect(rect_menuLB_Idx.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)j + rect_menuLB_Idx.y + menuLB_DatasGapFrmBar, rect_menuLB_Idx.width, rect_menuLB_Idx.height), pIGT_ScrollData_MC_FbFriends.ElementAt(j).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.white, TextAnchor.MiddleCenter, false);
							}
							pIgt_Lable.DrawLable(new Rect(rect_menuLB_Name.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)j + rect_menuLB_Name.y + menuLB_DatasGapFrmBar, rect_menuLB_Name.width, rect_GameoverScroll_Name.height), pIGT_ScrollData_MC_FbFriends.ElementAt(j).Name, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.white, TextAnchor.MiddleCenter, false);
							pIgt_Lable.DrawLable(new Rect(rect_menuLB_Score.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)j + rect_menuLB_Score.y + menuLB_DatasGapFrmBar, rect_menuLB_Score.width, rect_menuLB_Score.height), pIGT_ScrollData_MC_FbFriends.ElementAt(j).Score, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollScore, Color.white, TextAnchor.MiddleCenter, false);
						}
					}
					else
					{
						bDrawInvite_Mission = true;
					}
				}
				if (bDrawInvite_Mission)
				{
					Rect rect = new Rect(IGT_UIcommonFunc.ScaleX(88f), IGT_UIcommonFunc.ScaleY(358f), IGT_UIcommonFunc.ScaleX(120f), IGT_UIcommonFunc.ScaleY(40f));
					btnFBLeaderBoardInvite.setX(rect.x);
					btnFBLeaderBoardInvite.setY(rect.y);
					btnFBLeaderBoardInvite.setWidth(rect.width);
					btnFBLeaderBoardInvite.setHeight(rect.height);
					btnFBLeaderBoardInvite.Draw_Button();
					pIgt_Lable.DrawLable(new Rect(btnFBLeaderBoardInvite.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(10f), btnFBLeaderBoardInvite.getCurrentDimension().y, btnFBLeaderBoardInvite.getCurrentDimension().width, btnFBLeaderBoardInvite.getCurrentDimension().height), "Invite", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
					pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, new Rect(btnFBLeaderBoardInvite.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(8f), btnFBLeaderBoardInvite.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(6f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), false);
				}
			}
			else
			{
				pIgt_Lable.DrawLable(new Rect(rect_purchaseProductDescp.x + IGT_UIcommonFunc.ScaleX(10f), IGT_UIcommonFunc.ScaleY(220f), rect_purchaseProductDescp.width, rect_purchaseProductDescp.height), fbLogInTxt, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
				But_MailBox_FBConnect.setY(IGT_UIcommonFunc.ScaleY(270f));
				But_MailBox_FBConnect.Draw_Button();
				if (IGT_Preference.getInstance()._Get(kFBLoginfirstTime, 0) == 0)
				{
					pIgt_Textures.DrawTexture(IGT_Constants._Life, new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(130f), But_MailBox_FBConnect.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), 20f, Vector2.zero);
					pIgt_Lable.DrawLable(new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(130f), But_MailBox_FBConnect.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(4f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleY(22f)), "+" + IGT_Constants.nFBLoginLife, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black, 22f, Vector2.zero);
				}
				pIgt_Lable.DrawLable(new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(10f), But_MailBox_FBConnect.getCurrentDimension().y, But_MailBox_FBConnect.getCurrentDimension().width, But_MailBox_FBConnect.getCurrentDimension().height), "Connect", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
				pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(8f), But_MailBox_FBConnect.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), false);
			}
			break;
		case 1:
		{
			if (pIGT_ScrollData_MC_FbGlobal == null)
			{
				break;
			}
			string text2 = null;
			text2 = ((!pFacebook.isFBLoginSucess()) ? strDeviceID : text);
			for (int i = 0; i < 5; i++)
			{
				if (i >= pIGT_ScrollData_MC_FbGlobal.Count)
				{
					continue;
				}
				if (i == 3 && !pFacebook.bGlobalTop5inMission)
				{
					pIgt_Textures.DrawTexture(IGT_Constants._DotImg, new Rect(rect_menuLB_dot.x, menuLB_FBitems_startY + menuLB_BarHeight * (float)i + IGT_UIcommonFunc.ScaleY(6f), rect_menuLB_dot.width, rect_menuLB_dot.height), false);
					num = IGT_UIcommonFunc.ScaleY(4.5f);
				}
				if (pIGT_ScrollData_MC_FbGlobal.ElementAt(i).Id.Equals(text2))
				{
					if (!pFacebook.bGlobalTop5inMission)
					{
						num = IGT_UIcommonFunc.ScaleY(3.5f);
					}
					GUI.DrawTexture(new Rect(menuLB_BarStrtPosX, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)i, menuLB_BarWidth, menuLB_BarHeight), Drawrect_clr1);
					if (pFacebook.isFBLoginSucess())
					{
						GUI.DrawTexture(new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)i + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(i).pTexture);
						pIgt_Textures.drawBorder(new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)i + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), 2f, Border_White);
					}
					if (i < 3)
					{
						GUI.DrawTexture(new Rect(rect_menuLB_IdxBG.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)i + rect_menuLB_IdxBG.y + menuLB_DatasGapFrmBar, rect_menuLB_IdxBG.width + IGT_UIcommonFunc.ScaleX(5f), rect_menuLB_IdxBG.height + IGT_UIcommonFunc.ScaleY(5f)), rankbg[i]);
						pIgt_Lable.DrawLable(new Rect(rect_menuLB_Idx.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)i + rect_menuLB_Idx.y + menuLB_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(5f), rect_menuLB_Idx.width, rect_menuLB_Idx.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(i).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.white, TextAnchor.MiddleCenter, false);
					}
					else
					{
						pIgt_Lable.DrawLable(new Rect(rect_menuLB_Idx.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)i + rect_menuLB_Idx.y + menuLB_DatasGapFrmBar, rect_menuLB_Idx.width, rect_menuLB_Idx.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(i).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.white, TextAnchor.MiddleCenter, false);
					}
					pIgt_Lable.DrawLable(new Rect(rect_menuLB_Name.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)i + rect_menuLB_Name.y + menuLB_DatasGapFrmBar, rect_menuLB_Name.width, rect_menuLB_Name.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(i).Name, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.yellow, TextAnchor.MiddleCenter, false);
					pIgt_Lable.DrawLable(new Rect(rect_menuLB_Score.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)i + rect_menuLB_Score.y + menuLB_DatasGapFrmBar, rect_menuLB_Score.width, rect_menuLB_Score.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(i).Score, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollScore, Color.yellow, TextAnchor.MiddleCenter, false);
				}
				else
				{
					GUI.DrawTexture(new Rect(menuLB_BarStrtPosX, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)i, menuLB_BarWidth, menuLB_BarHeight), Drawrect_clr2);
					if (pFacebook.isFBLoginSucess())
					{
						GUI.DrawTexture(new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)i + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(i).pTexture);
						pIgt_Textures.drawBorder(new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)i + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), 2f, Border_White);
					}
					if (i < 3)
					{
						GUI.DrawTexture(new Rect(rect_menuLB_IdxBG.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)i + rect_menuLB_IdxBG.y + menuLB_DatasGapFrmBar, rect_menuLB_IdxBG.width + IGT_UIcommonFunc.ScaleX(5f), rect_menuLB_IdxBG.height + IGT_UIcommonFunc.ScaleY(5f)), rankbg[i]);
						pIgt_Lable.DrawLable(new Rect(rect_menuLB_Idx.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)i + rect_menuLB_Idx.y + menuLB_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(5f), rect_menuLB_Idx.width, rect_menuLB_Idx.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(i).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.white, TextAnchor.MiddleCenter, false);
					}
					else
					{
						pIgt_Lable.DrawLable(new Rect(rect_menuLB_Idx.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)i + rect_menuLB_Idx.y + menuLB_DatasGapFrmBar, rect_menuLB_Idx.width, rect_menuLB_Idx.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(i).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.white, TextAnchor.MiddleCenter, false);
					}
					pIgt_Lable.DrawLable(new Rect(rect_menuLB_Name.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)i + rect_menuLB_Name.y + menuLB_DatasGapFrmBar, rect_menuLB_Name.width, rect_menuLB_Name.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(i).Name, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.white, TextAnchor.MiddleCenter, false);
					pIgt_Lable.DrawLable(new Rect(rect_menuLB_Score.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)i + rect_menuLB_Score.y + menuLB_DatasGapFrmBar, rect_menuLB_Score.width, rect_menuLB_Score.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(i).Score, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollScore, Color.white, TextAnchor.MiddleCenter, false);
				}
			}
			break;
		}
		}
	}

	public void Alt_GFBleaderBoardData()
	{
		string text = null;
		if (pFacebook.isFBLoginSucess())
		{
			text = pFacebook.getMEUserID();
		}
		float num = 0f;
		bDrawInvite_Mission = false;
		Color white = Color.white;
		switch (nMC_ScrollType)
		{
		case 0:
			if (pFacebook.isFBLoginSucess())
			{
				if (pIGT_ScrollData_MC_FbFriends == null)
				{
					break;
				}
				bool flag = false;
				if (pFacebook.Mission_Friends != null && pFacebook.Mission_Friends.ContainsKey(text))
				{
					for (int j = 0; j < pIGT_ScrollData_MC_FbFriends.Count; j++)
					{
						if (pIGT_ScrollData_MC_FbFriends.ElementAt(j).Id.Equals(text) && int.Parse(pIGT_ScrollData_MC_FbFriends.ElementAt(j).Rank) > 5)
						{
							flag = true;
						}
					}
				}
				for (int k = 0; k < 5; k++)
				{
					if (k < pIGT_ScrollData_MC_FbFriends.Count)
					{
						white = ((!pIGT_ScrollData_MC_FbFriends.ElementAt(k).Id.Equals(text)) ? Color.white : Color.yellow);
						if (flag)
						{
							num = IGT_UIcommonFunc.ScaleY(0.8f);
							if (k == 3)
							{
								pIgt_Textures.DrawTexture(IGT_Constants._DotImg, new Rect(rect_menuLB_dot.x, menuLB_FBitems_startY + menuLB_BarHeight * (float)k + IGT_UIcommonFunc.ScaleY(8f), rect_menuLB_dot.width, rect_menuLB_dot.height), false);
								num = IGT_UIcommonFunc.ScaleY(2.4f);
							}
							else if (k >= 3)
							{
								num = IGT_UIcommonFunc.ScaleY(1.8f);
							}
							GUI.DrawTexture(new Rect(menuLB_BarStrtPosX, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k, menuLB_BarWidth, menuLB_BarHeight), Drawrect_clr1);
							GUI.DrawTexture(new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), pIGT_ScrollData_MC_FbFriends.ElementAt(k).pTexture);
							pIgt_Textures.drawBorder(new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), 2f, Border_White);
							if (k < 3)
							{
								GUI.DrawTexture(new Rect(rect_menuLB_IdxBG.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k + rect_menuLB_IdxBG.y + menuLB_DatasGapFrmBar, rect_menuLB_IdxBG.width + IGT_UIcommonFunc.ScaleX(5f), rect_menuLB_IdxBG.height + IGT_UIcommonFunc.ScaleY(5f)), rankbg[k]);
								pIgt_Lable.DrawLable(new Rect(rect_menuLB_Idx.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k + rect_menuLB_Idx.y + menuLB_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(5f), rect_menuLB_Idx.width, rect_menuLB_Idx.height), pIGT_ScrollData_MC_FbFriends.ElementAt(k).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
							}
							else
							{
								pIgt_Lable.DrawLable(new Rect(rect_menuLB_Idx.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k + rect_menuLB_Idx.y + menuLB_DatasGapFrmBar, rect_menuLB_Idx.width, rect_menuLB_Idx.height), pIGT_ScrollData_MC_FbFriends.ElementAt(k).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
							}
							if (pIGT_ScrollData_MC_FbFriends.ElementAt(k).Name != null)
							{
								pIgt_Lable.DrawLable(new Rect(rect_menuLB_Name.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k + rect_menuLB_Name.y + menuLB_DatasGapFrmBar, rect_menuLB_Name.width, rect_GameoverScroll_Name.height), pIGT_ScrollData_MC_FbFriends.ElementAt(k).Name, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
							}
							else
							{
								pIgt_Lable.DrawLable(new Rect(rect_menuLB_Name.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k + rect_menuLB_Name.y + menuLB_DatasGapFrmBar, rect_menuLB_Name.width, rect_GameoverScroll_Name.height), "Player_" + (k + 1), IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
							}
							pIgt_Lable.DrawLable(new Rect(rect_menuLB_Score.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k + rect_menuLB_Score.y + menuLB_DatasGapFrmBar, rect_menuLB_Score.width, rect_menuLB_Score.height), pIGT_ScrollData_MC_FbFriends.ElementAt(k).Score, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollScore, white, TextAnchor.MiddleCenter, false);
						}
						else
						{
							num = IGT_UIcommonFunc.ScaleY(1f);
							GUI.DrawTexture(new Rect(menuLB_BarStrtPosX, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k, menuLB_BarWidth, menuLB_BarHeight), Drawrect_clr1);
							GUI.DrawTexture(new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), pIGT_ScrollData_MC_FbFriends.ElementAt(k).pTexture);
							pIgt_Textures.drawBorder(new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), 2f, Border_White);
							if (k < 3)
							{
								GUI.DrawTexture(new Rect(rect_menuLB_IdxBG.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k + rect_menuLB_IdxBG.y + menuLB_DatasGapFrmBar, rect_menuLB_IdxBG.width + IGT_UIcommonFunc.ScaleX(5f), rect_menuLB_IdxBG.height + IGT_UIcommonFunc.ScaleY(5f)), rankbg[k]);
								pIgt_Lable.DrawLable(new Rect(rect_menuLB_Idx.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k + rect_menuLB_Idx.y + menuLB_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(5f), rect_menuLB_Idx.width, rect_menuLB_Idx.height), pIGT_ScrollData_MC_FbFriends.ElementAt(k).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
							}
							else
							{
								pIgt_Lable.DrawLable(new Rect(rect_menuLB_Idx.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k + rect_menuLB_Idx.y + menuLB_DatasGapFrmBar, rect_menuLB_Idx.width, rect_menuLB_Idx.height), pIGT_ScrollData_MC_FbFriends.ElementAt(k).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
							}
							if (pIGT_ScrollData_MC_FbFriends.ElementAt(k).Name != null)
							{
								pIgt_Lable.DrawLable(new Rect(rect_menuLB_Name.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k + rect_menuLB_Name.y + menuLB_DatasGapFrmBar, rect_menuLB_Name.width, rect_GameoverScroll_Name.height), pIGT_ScrollData_MC_FbFriends.ElementAt(k).Name, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
							}
							else
							{
								pIgt_Lable.DrawLable(new Rect(rect_menuLB_Name.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k + rect_menuLB_Name.y + menuLB_DatasGapFrmBar, rect_menuLB_Name.width, rect_GameoverScroll_Name.height), "Player_" + (k + 1), IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
							}
							pIgt_Lable.DrawLable(new Rect(rect_menuLB_Score.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k + rect_menuLB_Score.y + menuLB_DatasGapFrmBar, rect_menuLB_Score.width, rect_menuLB_Score.height), pIGT_ScrollData_MC_FbFriends.ElementAt(k).Score, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollScore, white, TextAnchor.MiddleCenter, false);
						}
					}
					else
					{
						bDrawInvite_Mission = true;
					}
				}
				if (bDrawInvite_Mission)
				{
					Rect base_rect = HS_Invitebtn_decide_rect(pIGT_ScrollData_MC_FbFriends.Count);
					btnFBLeaderBoardInvite.setX(base_rect.x);
					btnFBLeaderBoardInvite.setY(base_rect.y);
					btnFBLeaderBoardInvite.setWidth(base_rect.width);
					btnFBLeaderBoardInvite.setHeight(base_rect.height);
					btnFBLeaderBoardInvite.Draw_Button();
					pIgt_Lable.DrawLable(new Rect(btnFBLeaderBoardInvite.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(10f), btnFBLeaderBoardInvite.getCurrentDimension().y, btnFBLeaderBoardInvite.getCurrentDimension().width, btnFBLeaderBoardInvite.getCurrentDimension().height), "Invite", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
					pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, adj_drawrect(base_rect, new Rect(btnFBLeaderBoardInvite.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(8f), btnFBLeaderBoardInvite.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(6f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), 0), false);
					if (pFacebook.isFBLoginSucess() && (long)IGT_Preference.getInstance()._Get(kFBInviteLastUpdateTime, 0f) + IGT_Constants.dFBInviteTime <= (long)currentTimeMins())
					{
						pIgt_Textures.DrawTexture(IGT_Constants._Life, new Rect(btnFBLeaderBoardInvite.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(115f), btnFBLeaderBoardInvite.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), 24f, Vector2.zero);
						pIgt_Lable.DrawLable(new Rect(btnFBLeaderBoardInvite.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(115f), btnFBLeaderBoardInvite.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(4f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleY(22f)), "+2", IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black, 20f, Vector2.zero);
					}
				}
			}
			else
			{
				pIgt_Lable.DrawLable(new Rect(rect_purchaseProductDescp.x + IGT_UIcommonFunc.ScaleX(10f), IGT_UIcommonFunc.ScaleY(220f), rect_purchaseProductDescp.width, rect_purchaseProductDescp.height), fbLogInTxt, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
				But_MailBox_FBConnect.setY(IGT_UIcommonFunc.ScaleY(270f));
				But_MailBox_FBConnect.Draw_Button();
				if (IGT_Preference.getInstance()._Get(kFBLoginfirstTime, 0) == 0)
				{
					pIgt_Textures.DrawTexture(IGT_Constants._Life, new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(130f), But_MailBox_FBConnect.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), 20f, Vector2.zero);
					pIgt_Lable.DrawLable(new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(130f), But_MailBox_FBConnect.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(4f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleY(22f)), "+" + IGT_Constants.nFBLoginLife, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black, 22f, Vector2.zero);
				}
				pIgt_Lable.DrawLable(new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(10f), But_MailBox_FBConnect.getCurrentDimension().y, But_MailBox_FBConnect.getCurrentDimension().width, But_MailBox_FBConnect.getCurrentDimension().height), "Connect", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
				pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(8f), But_MailBox_FBConnect.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), false);
			}
			break;
		case 1:
		{
			if (pIGT_ScrollData_MC_FbGlobal == null)
			{
				break;
			}
			string text2 = null;
			text2 = ((!pFacebook.isFBLoginSucess()) ? strDeviceID : text);
			for (int i = 0; i < 5; i++)
			{
				if (i >= pIGT_ScrollData_MC_FbGlobal.Count)
				{
					continue;
				}
				white = ((!pIGT_ScrollData_MC_FbGlobal.ElementAt(i).Id.Equals(text2)) ? Color.white : Color.yellow);
				if (!pFacebook.bGlobalTop5inMission)
				{
					num = IGT_UIcommonFunc.ScaleY(0.8f);
					if (i == 3)
					{
						pIgt_Textures.DrawTexture(IGT_Constants._DotImg, new Rect(rect_menuLB_dot.x, menuLB_FBitems_startY + menuLB_BarHeight * (float)i + IGT_UIcommonFunc.ScaleY(8f), rect_menuLB_dot.width, rect_menuLB_dot.height), false);
						num = IGT_UIcommonFunc.ScaleY(2.4f);
					}
					else if (i >= 3)
					{
						num = IGT_UIcommonFunc.ScaleY(1.8f);
					}
					GUI.DrawTexture(new Rect(menuLB_BarStrtPosX, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i, menuLB_BarWidth, menuLB_BarHeight), Drawrect_clr1);
					if (pFacebook.isFBLoginSucess())
					{
						if (pIGT_ScrollData_MC_FbGlobal.ElementAt(i).pTexture == null)
						{
							pIgt_Textures.DrawTexture(IGT_Constants.defaultFB, new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), false);
						}
						else
						{
							GUI.DrawTexture(new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(i).pTexture);
						}
						pIgt_Textures.drawBorder(new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), 2f, Border_White);
					}
					if (i < 3)
					{
						GUI.DrawTexture(new Rect(rect_menuLB_IdxBG.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_IdxBG.y + menuLB_DatasGapFrmBar, rect_menuLB_IdxBG.width + IGT_UIcommonFunc.ScaleX(5f), rect_menuLB_IdxBG.height + IGT_UIcommonFunc.ScaleY(5f)), rankbg[i]);
						pIgt_Lable.DrawLable(new Rect(rect_menuLB_Idx.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_Idx.y + menuLB_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(5f), rect_menuLB_Idx.width, rect_menuLB_Idx.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(i).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
					}
					else
					{
						pIgt_Lable.DrawLable(new Rect(rect_menuLB_Idx.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_Idx.y + menuLB_DatasGapFrmBar, rect_menuLB_Idx.width, rect_menuLB_Idx.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(i).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
					}
					if (pIGT_ScrollData_MC_FbGlobal.ElementAt(i).Name != null)
					{
						pIgt_Lable.DrawLable(new Rect(rect_menuLB_Name.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_Name.y + menuLB_DatasGapFrmBar, rect_menuLB_Name.width, rect_menuLB_Name.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(i).Name, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
					}
					else
					{
						pIgt_Lable.DrawLable(new Rect(rect_menuLB_Name.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_Name.y + menuLB_DatasGapFrmBar, rect_menuLB_Name.width, rect_menuLB_Name.height), "Player_" + (i + 1), IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
					}
					pIgt_Lable.DrawLable(new Rect(rect_menuLB_Score.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_Score.y + menuLB_DatasGapFrmBar, rect_menuLB_Score.width, rect_menuLB_Score.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(i).Score, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollScore, white, TextAnchor.MiddleCenter, false);
					continue;
				}
				num = IGT_UIcommonFunc.ScaleY(1f);
				GUI.DrawTexture(new Rect(menuLB_BarStrtPosX, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i, menuLB_BarWidth, menuLB_BarHeight), Drawrect_clr1);
				if (pFacebook.isFBLoginSucess())
				{
					if (pIGT_ScrollData_MC_FbGlobal.ElementAt(i).pTexture == null)
					{
						pIgt_Textures.DrawTexture(IGT_Constants.defaultFB, new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), false);
					}
					else
					{
						GUI.DrawTexture(new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(i).pTexture);
					}
					pIgt_Textures.drawBorder(new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), 2f, Border_White);
				}
				if (i < 3)
				{
					GUI.DrawTexture(new Rect(rect_menuLB_IdxBG.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_IdxBG.y + menuLB_DatasGapFrmBar, rect_menuLB_IdxBG.width + IGT_UIcommonFunc.ScaleX(5f), rect_menuLB_IdxBG.height + IGT_UIcommonFunc.ScaleY(5f)), rankbg[i]);
					pIgt_Lable.DrawLable(new Rect(rect_menuLB_Idx.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_Idx.y + menuLB_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(5f), rect_menuLB_Idx.width, rect_menuLB_Idx.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(i).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
				}
				else
				{
					pIgt_Lable.DrawLable(new Rect(rect_menuLB_Idx.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_Idx.y + menuLB_DatasGapFrmBar, rect_menuLB_Idx.width, rect_menuLB_Idx.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(i).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
				}
				if (pIGT_ScrollData_MC_FbGlobal.ElementAt(i).Name != null)
				{
					pIgt_Lable.DrawLable(new Rect(rect_menuLB_Name.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_Name.y + menuLB_DatasGapFrmBar, rect_menuLB_Name.width, rect_menuLB_Name.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(i).Name, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
				}
				else
				{
					pIgt_Lable.DrawLable(new Rect(rect_menuLB_Name.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_Name.y + menuLB_DatasGapFrmBar, rect_menuLB_Name.width, rect_menuLB_Name.height), "Player_" + (i + 1), IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
				}
				pIgt_Lable.DrawLable(new Rect(rect_menuLB_Score.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_Score.y + menuLB_DatasGapFrmBar, rect_menuLB_Score.width, rect_menuLB_Score.height), pIGT_ScrollData_MC_FbGlobal.ElementAt(i).Score, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollScore, white, TextAnchor.MiddleCenter, false);
			}
			break;
		}
		}
	}

	private Rect HS_Invitebtn_decide_rect(int listDataCount)
	{
		if (listDataCount < 2)
		{
			return adj_drawrect(new Rect(IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(190f), IGT_UIcommonFunc.ScaleX(260f), IGT_UIcommonFunc.ScaleY(215f)), new Rect(IGT_UIcommonFunc.ScaleX(88f), IGT_UIcommonFunc.ScaleY(270f), IGT_UIcommonFunc.ScaleX(120f), IGT_UIcommonFunc.ScaleY(40f)), 1);
		}
		return adj_drawrect(new Rect(IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(190f), IGT_UIcommonFunc.ScaleX(260f), IGT_UIcommonFunc.ScaleY(215f)), new Rect(IGT_UIcommonFunc.ScaleX(88f), IGT_UIcommonFunc.ScaleY(358f), IGT_UIcommonFunc.ScaleX(120f), IGT_UIcommonFunc.ScaleY(40f)), 1);
	}

	private Rect GO_Invitebtn_decide_rect(int listDataCount)
	{
		if (listDataCount < 2)
		{
			return adj_drawrect(ScrollViewRectImg_GameoverScreen, new Rect(IGT_UIcommonFunc.ScaleX(88f), IGT_UIcommonFunc.ScaleY(120f), IGT_UIcommonFunc.ScaleX(130f), IGT_UIcommonFunc.ScaleY(42f)), 1);
		}
		return adj_drawrect(ScrollViewRectImg_GameoverScreen, new Rect(IGT_UIcommonFunc.ScaleX(88f), IGT_UIcommonFunc.ScaleY(161f), IGT_UIcommonFunc.ScaleX(130f), IGT_UIcommonFunc.ScaleY(42f)), 1);
	}

	public void GFBleaderboardChase()
	{
		string text = null;
		if (pFacebook.isFBLoginSucess())
		{
			text = pFacebook.getMEUserID();
		}
		float num = 0f;
		bDrawInvite_Chase = false;
		switch (nGameoverScrollType)
		{
		case 0:
			if (pFacebook.isFBLoginSucess())
			{
				for (int j = 0; j < 5; j++)
				{
					if (j < pIGT_ScrollData_GameOver_Fb.Count)
					{
						if (j == 3 && pFacebook.UserFrndsInfo[text].rank > 5)
						{
							pIgt_Textures.DrawTexture(IGT_Constants._DotImg, new Rect(rect_menuLB_dot.x, menuLB_FBitems_startY + menuLB_BarHeight * (float)j + IGT_UIcommonFunc.ScaleY(6f), rect_menuLB_dot.width, rect_menuLB_dot.height), false);
							num = IGT_UIcommonFunc.ScaleY(4.5f);
						}
						if (pIGT_ScrollData_GameOver_Fb.ElementAt(j).Name.Equals("Me"))
						{
							if (pFacebook.UserFrndsInfo[text].rank > 5)
							{
								num = IGT_UIcommonFunc.ScaleY(3.5f);
							}
							GUI.DrawTexture(new Rect(menuLB_BarStrtPosX, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)j, menuLB_BarWidth, menuLB_BarHeight), Drawrect_clr1);
							GUI.DrawTexture(new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)j + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), pIGT_ScrollData_GameOver_Fb.ElementAt(j).pTexture);
							pIgt_Textures.drawBorder(new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)j + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), 2f, Border_White);
							if (j < 3)
							{
								GUI.DrawTexture(new Rect(rect_menuLB_IdxBG.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)j + rect_menuLB_IdxBG.y + menuLB_DatasGapFrmBar, rect_menuLB_IdxBG.width + IGT_UIcommonFunc.ScaleX(5f), rect_menuLB_IdxBG.height + IGT_UIcommonFunc.ScaleY(5f)), rankbg[j]);
								pIgt_Lable.DrawLable(new Rect(rect_menuLB_Idx.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)j + rect_menuLB_Idx.y + menuLB_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(5f), rect_menuLB_Idx.width, rect_menuLB_Idx.height), pIGT_ScrollData_GameOver_Fb.ElementAt(j).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.yellow, TextAnchor.MiddleCenter, false);
							}
							else
							{
								pIgt_Lable.DrawLable(new Rect(rect_menuLB_Idx.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)j + rect_menuLB_Idx.y + menuLB_DatasGapFrmBar, rect_menuLB_Idx.width, rect_menuLB_Idx.height), pIGT_ScrollData_GameOver_Fb.ElementAt(j).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.yellow, TextAnchor.MiddleCenter, false);
							}
							pIgt_Lable.DrawLable(new Rect(rect_menuLB_Name.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)j + rect_menuLB_Name.y + menuLB_DatasGapFrmBar, rect_menuLB_Name.width, rect_GameoverScroll_Name.height), pIGT_ScrollData_GameOver_Fb.ElementAt(j).Name, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.yellow, TextAnchor.MiddleCenter, false);
							pIgt_Lable.DrawLable(new Rect(rect_menuLB_Score.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)j + rect_menuLB_Score.y + menuLB_DatasGapFrmBar, rect_menuLB_Score.width, rect_menuLB_Score.height), pIGT_ScrollData_GameOver_Fb.ElementAt(j).Score, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollScore, Color.yellow, TextAnchor.MiddleCenter, false);
						}
						else
						{
							GUI.DrawTexture(new Rect(menuLB_BarStrtPosX, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)j, menuLB_BarWidth, menuLB_BarHeight), Drawrect_clr1);
							GUI.DrawTexture(new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)j + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), pIGT_ScrollData_GameOver_Fb.ElementAt(j).pTexture);
							pIgt_Textures.drawBorder(new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)j + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), 2f, Border_White);
							if (j < 3)
							{
								GUI.DrawTexture(new Rect(rect_menuLB_IdxBG.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)j + rect_menuLB_IdxBG.y + menuLB_DatasGapFrmBar, rect_menuLB_IdxBG.width + IGT_UIcommonFunc.ScaleX(5f), rect_menuLB_IdxBG.height + IGT_UIcommonFunc.ScaleY(5f)), rankbg[j]);
								pIgt_Lable.DrawLable(new Rect(rect_menuLB_Idx.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)j + rect_menuLB_Idx.y + menuLB_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(5f), rect_menuLB_Idx.width, rect_menuLB_Idx.height), pIGT_ScrollData_GameOver_Fb.ElementAt(j).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.white, TextAnchor.MiddleCenter, false);
							}
							else
							{
								pIgt_Lable.DrawLable(new Rect(rect_menuLB_Idx.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)j + rect_menuLB_Idx.y + menuLB_DatasGapFrmBar, rect_menuLB_Idx.width, rect_menuLB_Idx.height), pIGT_ScrollData_GameOver_Fb.ElementAt(j).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.white, TextAnchor.MiddleCenter, false);
							}
							pIgt_Lable.DrawLable(new Rect(rect_menuLB_Name.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)j + rect_menuLB_Name.y + menuLB_DatasGapFrmBar, rect_menuLB_Name.width, rect_GameoverScroll_Name.height), pIGT_ScrollData_GameOver_Fb.ElementAt(j).Name, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.white, TextAnchor.MiddleCenter, false);
							pIgt_Lable.DrawLable(new Rect(rect_menuLB_Score.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)j + rect_menuLB_Score.y + menuLB_DatasGapFrmBar, rect_menuLB_Score.width, rect_menuLB_Score.height), pIGT_ScrollData_GameOver_Fb.ElementAt(j).Score, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollScore, Color.white, TextAnchor.MiddleCenter, false);
						}
					}
					else
					{
						bDrawInvite_Chase = true;
					}
				}
				if (bDrawInvite_Chase)
				{
					Rect rect = new Rect(IGT_UIcommonFunc.ScaleX(88f), IGT_UIcommonFunc.ScaleY(358f), IGT_UIcommonFunc.ScaleX(120f), IGT_UIcommonFunc.ScaleY(40f));
					btnFBLeaderBoardInvite.setX(rect.x);
					btnFBLeaderBoardInvite.setY(rect.y);
					btnFBLeaderBoardInvite.setWidth(rect.width);
					btnFBLeaderBoardInvite.setHeight(rect.height);
					btnFBLeaderBoardInvite.Draw_Button();
					pIgt_Lable.DrawLable(new Rect(btnFBLeaderBoardInvite.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(10f), btnFBLeaderBoardInvite.getCurrentDimension().y, btnFBLeaderBoardInvite.getCurrentDimension().width, btnFBLeaderBoardInvite.getCurrentDimension().height), "Invite", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
					pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, new Rect(btnFBLeaderBoardInvite.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(8f), btnFBLeaderBoardInvite.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), false);
				}
			}
			else
			{
				pIgt_Lable.DrawLable(new Rect(rect_purchaseProductDescp.x + IGT_UIcommonFunc.ScaleX(10f), IGT_UIcommonFunc.ScaleY(220f), rect_purchaseProductDescp.width, rect_purchaseProductDescp.height), fbLogInTxt, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
				But_MailBox_FBConnect.setY(IGT_UIcommonFunc.ScaleY(270f));
				But_MailBox_FBConnect.Draw_Button();
				if (IGT_Preference.getInstance()._Get(kFBLoginfirstTime, 0) == 0)
				{
					pIgt_Textures.DrawTexture(IGT_Constants._Life, new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(130f), But_MailBox_FBConnect.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), 20f, Vector2.zero);
					pIgt_Lable.DrawLable(new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(130f), But_MailBox_FBConnect.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(4f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleY(22f)), "+" + IGT_Constants.nFBLoginLife, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black, 22f, Vector2.zero);
				}
				pIgt_Lable.DrawLable(new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(10f), But_MailBox_FBConnect.getCurrentDimension().y, But_MailBox_FBConnect.getCurrentDimension().width, But_MailBox_FBConnect.getCurrentDimension().height), "Connect", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
				pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(8f), But_MailBox_FBConnect.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), false);
			}
			break;
		case 1:
		{
			if (pIGT_ScrollData_GameOver_Topchase == null)
			{
				break;
			}
			string text2 = null;
			text2 = ((!pFacebook.isFBLoginSucess()) ? strDeviceID : text);
			for (int i = 0; i < 5; i++)
			{
				if (i >= pIGT_ScrollData_GameOver_Topchase.Count)
				{
					continue;
				}
				if (i == 3 && !pFacebook.bGlobalTop5inChase)
				{
					pIgt_Textures.DrawTexture(IGT_Constants._DotImg, new Rect(rect_menuLB_dot.x, menuLB_FBitems_startY + menuLB_BarHeight * (float)i + IGT_UIcommonFunc.ScaleY(6f), rect_menuLB_dot.width, rect_menuLB_dot.height), false);
					num = IGT_UIcommonFunc.ScaleY(4.5f);
				}
				if (pIGT_ScrollData_GameOver_Topchase.ElementAt(i).Id.Equals(text2))
				{
					if (!pFacebook.bGlobalTop5inChase)
					{
						num = IGT_UIcommonFunc.ScaleY(3.5f);
					}
					GUI.DrawTexture(new Rect(menuLB_BarStrtPosX, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)i, menuLB_BarWidth, menuLB_BarHeight), Drawrect_clr1);
					if (pFacebook.isFBLoginSucess())
					{
						GUI.DrawTexture(new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)i + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(i).pTexture);
						pIgt_Textures.drawBorder(new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)i + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), 2f, Border_White);
					}
					if (i < 3)
					{
						GUI.DrawTexture(new Rect(rect_menuLB_IdxBG.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)i + rect_menuLB_IdxBG.y + menuLB_DatasGapFrmBar, rect_menuLB_IdxBG.width + IGT_UIcommonFunc.ScaleX(5f), rect_menuLB_IdxBG.height + IGT_UIcommonFunc.ScaleY(5f)), rankbg[i]);
						pIgt_Lable.DrawLable(new Rect(rect_menuLB_Idx.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)i + rect_menuLB_Idx.y + menuLB_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(5f), rect_menuLB_Idx.width, rect_menuLB_Idx.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(i).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.yellow, TextAnchor.MiddleCenter, false);
					}
					else
					{
						pIgt_Lable.DrawLable(new Rect(rect_menuLB_Idx.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)i + rect_menuLB_Idx.y + menuLB_DatasGapFrmBar, rect_menuLB_Idx.width, rect_menuLB_Idx.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(i).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.yellow, TextAnchor.MiddleCenter, false);
					}
					pIgt_Lable.DrawLable(new Rect(rect_menuLB_Name.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)i + rect_menuLB_Name.y + menuLB_DatasGapFrmBar, rect_menuLB_Name.width, rect_menuLB_Name.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(i).Name, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.yellow, TextAnchor.MiddleCenter, false);
					pIgt_Lable.DrawLable(new Rect(rect_menuLB_Score.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)i + rect_menuLB_Score.y + menuLB_DatasGapFrmBar, rect_menuLB_Score.width, rect_menuLB_Score.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(i).Score, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollScore, Color.yellow, TextAnchor.MiddleCenter, false);
				}
				else
				{
					GUI.DrawTexture(new Rect(menuLB_BarStrtPosX, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)i, menuLB_BarWidth, menuLB_BarHeight), Drawrect_clr2);
					if (pFacebook.isFBLoginSucess())
					{
						GUI.DrawTexture(new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)i + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(i).pTexture);
						pIgt_Textures.drawBorder(new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)i + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), 2f, Border_White);
					}
					if (i < 3)
					{
						GUI.DrawTexture(new Rect(rect_menuLB_IdxBG.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)i + rect_menuLB_IdxBG.y + menuLB_DatasGapFrmBar, rect_menuLB_IdxBG.width + IGT_UIcommonFunc.ScaleX(5f), rect_menuLB_IdxBG.height + IGT_UIcommonFunc.ScaleY(5f)), rankbg[i]);
						pIgt_Lable.DrawLable(new Rect(rect_menuLB_Idx.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)i + rect_menuLB_Idx.y + menuLB_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(5f), rect_menuLB_Idx.width, rect_menuLB_Idx.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(i).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.white, TextAnchor.MiddleCenter, false);
					}
					else
					{
						pIgt_Lable.DrawLable(new Rect(rect_menuLB_Idx.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)i + rect_menuLB_Idx.y + menuLB_DatasGapFrmBar, rect_menuLB_Idx.width, rect_menuLB_Idx.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(i).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.white, TextAnchor.MiddleCenter, false);
					}
					pIgt_Lable.DrawLable(new Rect(rect_menuLB_Name.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)i + rect_menuLB_Name.y + menuLB_DatasGapFrmBar, rect_menuLB_Name.width, rect_menuLB_Name.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(i).Name, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, Color.white, TextAnchor.MiddleCenter, false);
					pIgt_Lable.DrawLable(new Rect(rect_menuLB_Score.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + num) * (float)i + rect_menuLB_Score.y + menuLB_DatasGapFrmBar, rect_menuLB_Score.width, rect_menuLB_Score.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(i).Score, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollScore, Color.white, TextAnchor.MiddleCenter, false);
				}
			}
			break;
		}
		}
	}

	public void Alt_GFBleaderboardChase()
	{
		Color white = Color.white;
		string text = null;
		if (pFacebook.isFBLoginSucess())
		{
			text = pFacebook.getMEUserID();
		}
		float num = 0f;
		bDrawInvite_Chase = false;
		switch (nGameoverScrollType)
		{
		case 0:
			if (pFacebook.isFBLoginSucess())
			{
				bool flag = false;
				if (pFacebook.Chase_Friends != null && pFacebook.Chase_Friends.ContainsKey(text))
				{
					for (int j = 0; j < pIGT_ScrollData_GameOver_Fb.Count; j++)
					{
						if (pIGT_ScrollData_GameOver_Fb.ElementAt(j).Id.Equals(text) && int.Parse(pIGT_ScrollData_GameOver_Fb.ElementAt(j).Rank) > 5)
						{
							flag = true;
						}
					}
				}
				for (int k = 0; k < 5; k++)
				{
					if (k < pIGT_ScrollData_GameOver_Fb.Count)
					{
						white = ((!pIGT_ScrollData_GameOver_Fb.ElementAt(k).Id.Equals(text)) ? Color.white : Color.yellow);
						if (flag)
						{
							num = IGT_UIcommonFunc.ScaleY(0.8f);
							if (k == 3)
							{
								pIgt_Textures.DrawTexture(IGT_Constants._DotImg, new Rect(rect_menuLB_dot.x, menuLB_FBitems_startY + menuLB_BarHeight * (float)k + IGT_UIcommonFunc.ScaleY(8f), rect_menuLB_dot.width, rect_menuLB_dot.height), false);
								num = IGT_UIcommonFunc.ScaleY(2.4f);
							}
							else if (k >= 3)
							{
								num = IGT_UIcommonFunc.ScaleY(1.8f);
							}
							GUI.DrawTexture(new Rect(menuLB_BarStrtPosX, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k, menuLB_BarWidth, menuLB_BarHeight), Drawrect_clr1);
							GUI.DrawTexture(new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), pIGT_ScrollData_GameOver_Fb.ElementAt(k).pTexture);
							pIgt_Textures.drawBorder(new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), 2f, Border_White);
							if (k < 3)
							{
								GUI.DrawTexture(new Rect(rect_menuLB_IdxBG.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k + rect_menuLB_IdxBG.y + menuLB_DatasGapFrmBar, rect_menuLB_IdxBG.width + IGT_UIcommonFunc.ScaleX(5f), rect_menuLB_IdxBG.height + IGT_UIcommonFunc.ScaleY(5f)), rankbg[k]);
								pIgt_Lable.DrawLable(new Rect(rect_menuLB_Idx.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k + rect_menuLB_Idx.y + menuLB_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(5f), rect_menuLB_Idx.width, rect_menuLB_Idx.height), pIGT_ScrollData_GameOver_Fb.ElementAt(k).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
							}
							else
							{
								pIgt_Lable.DrawLable(new Rect(rect_menuLB_Idx.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k + rect_menuLB_Idx.y + menuLB_DatasGapFrmBar, rect_menuLB_Idx.width, rect_menuLB_Idx.height), pIGT_ScrollData_GameOver_Fb.ElementAt(k).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
							}
							if (pIGT_ScrollData_GameOver_Fb.ElementAt(k).Name != null)
							{
								pIgt_Lable.DrawLable(new Rect(rect_menuLB_Name.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k + rect_menuLB_Name.y + menuLB_DatasGapFrmBar, rect_menuLB_Name.width, rect_GameoverScroll_Name.height), pIGT_ScrollData_GameOver_Fb.ElementAt(k).Name, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
							}
							else
							{
								pIgt_Lable.DrawLable(new Rect(rect_menuLB_Name.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k + rect_menuLB_Name.y + menuLB_DatasGapFrmBar, rect_menuLB_Name.width, rect_GameoverScroll_Name.height), "Player_" + (k + 1), IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
							}
							pIgt_Lable.DrawLable(new Rect(rect_menuLB_Score.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k + rect_menuLB_Score.y + menuLB_DatasGapFrmBar, rect_menuLB_Score.width, rect_menuLB_Score.height), pIGT_ScrollData_GameOver_Fb.ElementAt(k).Score, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollScore, white, TextAnchor.MiddleCenter, false);
						}
						else
						{
							num = IGT_UIcommonFunc.ScaleY(1f);
							GUI.DrawTexture(new Rect(menuLB_BarStrtPosX, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k, menuLB_BarWidth, menuLB_BarHeight), Drawrect_clr1);
							GUI.DrawTexture(new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), pIGT_ScrollData_GameOver_Fb.ElementAt(k).pTexture);
							pIgt_Textures.drawBorder(new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), 2f, Border_White);
							if (k < 3)
							{
								GUI.DrawTexture(new Rect(rect_menuLB_IdxBG.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k + rect_menuLB_IdxBG.y + menuLB_DatasGapFrmBar, rect_menuLB_IdxBG.width + IGT_UIcommonFunc.ScaleX(5f), rect_menuLB_IdxBG.height + IGT_UIcommonFunc.ScaleY(5f)), rankbg[k]);
								pIgt_Lable.DrawLable(new Rect(rect_menuLB_Idx.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k + rect_menuLB_Idx.y + menuLB_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(5f), rect_menuLB_Idx.width, rect_menuLB_Idx.height), pIGT_ScrollData_GameOver_Fb.ElementAt(k).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
							}
							else
							{
								pIgt_Lable.DrawLable(new Rect(rect_menuLB_Idx.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k + rect_menuLB_Idx.y + menuLB_DatasGapFrmBar, rect_menuLB_Idx.width, rect_menuLB_Idx.height), pIGT_ScrollData_GameOver_Fb.ElementAt(k).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
							}
							if (pIGT_ScrollData_GameOver_Fb.ElementAt(k).Name != null)
							{
								pIgt_Lable.DrawLable(new Rect(rect_menuLB_Name.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k + rect_menuLB_Name.y + menuLB_DatasGapFrmBar, rect_menuLB_Name.width, rect_GameoverScroll_Name.height), pIGT_ScrollData_GameOver_Fb.ElementAt(k).Name, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
							}
							else
							{
								pIgt_Lable.DrawLable(new Rect(rect_menuLB_Name.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k + rect_menuLB_Name.y + menuLB_DatasGapFrmBar, rect_menuLB_Name.width, rect_GameoverScroll_Name.height), "Player_" + (k + 1), IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
							}
							pIgt_Lable.DrawLable(new Rect(rect_menuLB_Score.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)k + rect_menuLB_Score.y + menuLB_DatasGapFrmBar, rect_menuLB_Score.width, rect_menuLB_Score.height), pIGT_ScrollData_GameOver_Fb.ElementAt(k).Score, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollScore, white, TextAnchor.MiddleCenter, false);
						}
					}
					else
					{
						bDrawInvite_Chase = true;
					}
				}
				if (bDrawInvite_Chase)
				{
					Rect base_rect = HS_Invitebtn_decide_rect(pIGT_ScrollData_GameOver_Fb.Count);
					btnFBLeaderBoardInvite.setX(base_rect.x);
					btnFBLeaderBoardInvite.setY(base_rect.y);
					btnFBLeaderBoardInvite.setWidth(base_rect.width);
					btnFBLeaderBoardInvite.setHeight(base_rect.height);
					btnFBLeaderBoardInvite.Draw_Button();
					pIgt_Lable.DrawLable(new Rect(btnFBLeaderBoardInvite.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(10f), btnFBLeaderBoardInvite.getCurrentDimension().y, btnFBLeaderBoardInvite.getCurrentDimension().width, btnFBLeaderBoardInvite.getCurrentDimension().height), "Invite", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
					pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, adj_drawrect(base_rect, new Rect(btnFBLeaderBoardInvite.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(8f), btnFBLeaderBoardInvite.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), 0), false);
					if (pFacebook.isFBLoginSucess() && (long)IGT_Preference.getInstance()._Get(kFBInviteLastUpdateTime, 0f) + IGT_Constants.dFBInviteTime <= (long)currentTimeMins())
					{
						pIgt_Textures.DrawTexture(IGT_Constants._Life, new Rect(btnFBLeaderBoardInvite.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(115f), btnFBLeaderBoardInvite.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), 24f, Vector2.zero);
						pIgt_Lable.DrawLable(new Rect(btnFBLeaderBoardInvite.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(115f), btnFBLeaderBoardInvite.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(4f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleY(22f)), "+2", IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black, 20f, Vector2.zero);
					}
				}
			}
			else
			{
				pIgt_Lable.DrawLable(new Rect(rect_purchaseProductDescp.x + IGT_UIcommonFunc.ScaleX(10f), IGT_UIcommonFunc.ScaleY(220f), rect_purchaseProductDescp.width, rect_purchaseProductDescp.height), fbLogInTxt, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
				But_MailBox_FBConnect.setY(IGT_UIcommonFunc.ScaleY(270f));
				But_MailBox_FBConnect.Draw_Button();
				if (IGT_Preference.getInstance()._Get(kFBLoginfirstTime, 0) == 0)
				{
					pIgt_Textures.DrawTexture(IGT_Constants._Life, new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(130f), But_MailBox_FBConnect.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(8f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), 20f, Vector2.zero);
					pIgt_Lable.DrawLable(new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(130f), But_MailBox_FBConnect.getCurrentDimension().y - IGT_UIcommonFunc.ScaleY(4f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleY(22f)), "+" + IGT_Constants.nFBLoginLife, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black, 22f, Vector2.zero);
				}
				pIgt_Lable.DrawLable(new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(10f), But_MailBox_FBConnect.getCurrentDimension().y, But_MailBox_FBConnect.getCurrentDimension().width, But_MailBox_FBConnect.getCurrentDimension().height), "Connect", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black, 0f, Vector2.zero);
				pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, new Rect(But_MailBox_FBConnect.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(8f), But_MailBox_FBConnect.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(10f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), false);
			}
			break;
		case 1:
		{
			if (pIGT_ScrollData_GameOver_Topchase == null)
			{
				break;
			}
			string text2 = null;
			text2 = ((!pFacebook.isFBLoginSucess()) ? strDeviceID : text);
			for (int i = 0; i < 5; i++)
			{
				if (i >= pIGT_ScrollData_GameOver_Topchase.Count)
				{
					continue;
				}
				white = ((!pIGT_ScrollData_GameOver_Topchase.ElementAt(i).Id.Equals(text2)) ? Color.white : Color.yellow);
				if (!pFacebook.bGlobalTop5inChase)
				{
					num = IGT_UIcommonFunc.ScaleY(0.8f);
					if (i == 3)
					{
						pIgt_Textures.DrawTexture(IGT_Constants._DotImg, new Rect(rect_menuLB_dot.x, menuLB_FBitems_startY + menuLB_BarHeight * (float)i + IGT_UIcommonFunc.ScaleY(8f), rect_menuLB_dot.width, rect_menuLB_dot.height), false);
						num = IGT_UIcommonFunc.ScaleY(2.4f);
					}
					else if (i >= 3)
					{
						num = IGT_UIcommonFunc.ScaleY(1.8f);
					}
					GUI.DrawTexture(new Rect(menuLB_BarStrtPosX, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i, menuLB_BarWidth, menuLB_BarHeight), Drawrect_clr1);
					if (pFacebook.isFBLoginSucess())
					{
						if (pIGT_ScrollData_GameOver_Topchase.ElementAt(i).pTexture == null)
						{
							pIgt_Textures.DrawTexture(IGT_Constants.defaultFB, new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), false);
						}
						else
						{
							GUI.DrawTexture(new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(i).pTexture);
						}
						pIgt_Textures.drawBorder(new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), 2f, Border_White);
					}
					if (i < 3)
					{
						GUI.DrawTexture(new Rect(rect_menuLB_IdxBG.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_IdxBG.y + menuLB_DatasGapFrmBar, rect_menuLB_IdxBG.width + IGT_UIcommonFunc.ScaleX(5f), rect_menuLB_IdxBG.height + IGT_UIcommonFunc.ScaleY(5f)), rankbg[i]);
						pIgt_Lable.DrawLable(new Rect(rect_menuLB_Idx.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_Idx.y + menuLB_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(5f), rect_menuLB_Idx.width, rect_menuLB_Idx.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(i).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
					}
					else
					{
						pIgt_Lable.DrawLable(new Rect(rect_menuLB_Idx.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_Idx.y + menuLB_DatasGapFrmBar, rect_menuLB_Idx.width, rect_menuLB_Idx.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(i).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
					}
					if (pIGT_ScrollData_GameOver_Topchase.ElementAt(i).Name != null)
					{
						pIgt_Lable.DrawLable(new Rect(rect_menuLB_Name.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_Name.y + menuLB_DatasGapFrmBar, rect_menuLB_Name.width, rect_menuLB_Name.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(i).Name, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
					}
					else
					{
						pIgt_Lable.DrawLable(new Rect(rect_menuLB_Name.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_Name.y + menuLB_DatasGapFrmBar, rect_menuLB_Name.width, rect_menuLB_Name.height), "Player_" + (i + 1), IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
					}
					pIgt_Lable.DrawLable(new Rect(rect_menuLB_Score.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_Score.y + menuLB_DatasGapFrmBar, rect_menuLB_Score.width, rect_menuLB_Score.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(i).Score, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollScore, white, TextAnchor.MiddleCenter, false);
					continue;
				}
				num = IGT_UIcommonFunc.ScaleY(1f);
				GUI.DrawTexture(new Rect(menuLB_BarStrtPosX, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i, menuLB_BarWidth, menuLB_BarHeight), Drawrect_clr1);
				if (pFacebook.isFBLoginSucess())
				{
					if (pIGT_ScrollData_GameOver_Topchase.ElementAt(i).pTexture == null)
					{
						pIgt_Textures.DrawTexture(IGT_Constants.defaultFB, new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), false);
					}
					else
					{
						GUI.DrawTexture(new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(i).pTexture);
					}
					pIgt_Textures.drawBorder(new Rect(rect_menuLB_pic.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_pic.y + menuLB_DatasGapFrmBar, rect_menuLB_pic.width, rect_menuLB_pic.height), 2f, Border_White);
				}
				if (i < 3)
				{
					GUI.DrawTexture(new Rect(rect_menuLB_IdxBG.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_IdxBG.y + menuLB_DatasGapFrmBar, rect_menuLB_IdxBG.width + IGT_UIcommonFunc.ScaleX(5f), rect_menuLB_IdxBG.height + IGT_UIcommonFunc.ScaleY(5f)), rankbg[i]);
					pIgt_Lable.DrawLable(new Rect(rect_menuLB_Idx.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_Idx.y + menuLB_DatasGapFrmBar + IGT_UIcommonFunc.ScaleY(5f), rect_menuLB_Idx.width, rect_menuLB_Idx.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(i).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
				}
				else
				{
					pIgt_Lable.DrawLable(new Rect(rect_menuLB_Idx.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_Idx.y + menuLB_DatasGapFrmBar, rect_menuLB_Idx.width, rect_menuLB_Idx.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(i).Rank + string.Empty, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
				}
				if (pIGT_ScrollData_GameOver_Topchase.ElementAt(i).Name != null)
				{
					pIgt_Lable.DrawLable(new Rect(rect_menuLB_Name.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_Name.y + menuLB_DatasGapFrmBar, rect_menuLB_Name.width, rect_menuLB_Name.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(i).Name, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
				}
				else
				{
					pIgt_Lable.DrawLable(new Rect(rect_menuLB_Name.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_Name.y + menuLB_DatasGapFrmBar, rect_menuLB_Name.width, rect_menuLB_Name.height), "Player_" + (i + 1), IGT_Constants.Font_TTMasters, fontSize_GameoverScrollName, white, TextAnchor.MiddleCenter, false);
				}
				pIgt_Lable.DrawLable(new Rect(rect_menuLB_Score.x, menuLB_FBitems_startY + (menuLB_BarHeight + menuLB_BarGap + IGT_UIcommonFunc.ScaleY(1f) + num) * (float)i + rect_menuLB_Score.y + menuLB_DatasGapFrmBar, rect_menuLB_Score.width, rect_menuLB_Score.height), pIGT_ScrollData_GameOver_Topchase.ElementAt(i).Score, IGT_Constants.Font_TTMasters, fontSize_GameoverScrollScore, white, TextAnchor.MiddleCenter, false);
			}
			break;
		}
		}
	}

	public void clearData()
	{
		IGT_Preference.getInstance()._deleteAll();
		pMapObj.deleteMapData();
		pHero.pIgtSavelevelData.dropTable();
		Caching.ClearCache();
		DirectoryInfo directoryInfo = new DirectoryInfo(Application.persistentDataPath);
		directoryInfo.Delete(true);
		Application.Quit();
	}

	private Rect findXY(float cenX, float cenY, float imgWid, float imgHeight)
	{
		float x = cenX - imgWid / 2f;
		float y = cenY - imgHeight / 2f;
		return new Rect(x, y, imgWid, imgHeight);
	}

	public void GplusAlertWindow()
	{
		float num = pAnim_MailBox.easeFunctions(0.01f, 1f, 1f, 29);
		GUIUtility.ScaleAroundPivot(new Vector2(num, num), new Vector2(rect_MailBoxWin.x + rect_MailBoxWin.width * 0.5f, rect_MailBoxWin.y + rect_MailBoxWin.height * 0.5f));
		pIgt_Textures.DrawTexture(IGT_Constants._AlertBoard_Green, rectGpluseSigninalert, false);
		pIgt_Lable.DrawLable(new Rect(rectGpluseSigninalert.x, rectGpluseSigninalert.y - IGT_UIcommonFunc.ScaleY(10f), rectGpluseSigninalert.width, rectGpluseSigninalert.height), sGpluseSignInTxt, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(13f), TextAnchor.MiddleCenter, false, new Color(1f, 0.95686275f, 0.4627451f, 1f), 1f, Color.black, new Vector2(1f, 1f), Color.black);
		btnGpluseSignin.Draw_Button();
		btnGplusealertClose.Draw_Button();
		GUI.matrix = Matrix4x4.identity;
	}

	public void settings_window()
	{
		pIgt_Textures.DrawTexture(IGT_Constants._GreyOverLay, new Rect(0f, 0f, Screen.width, Screen.height), false);
		GUIUtility.RotateAroundPivot(pAnim_HS_menuBG.easeFunctions(-85f, 0f, 1f, 29), Vector2.zero);
		if (pAnim_HS_menuBG.isAnimFinished() && pAnim_HS_menuBG.getIsReverse())
		{
			bHS_settings = false;
		}
		else
		{
			pIgt_Textures.DrawTexture(IGT_Constants._SettingsBg, rect_settingWindow, false);
			pIgt_Textures.DrawTexture(IGT_Constants._Settings_tilt, new Rect(rect_settingWindow.x - IGT_UIcommonFunc.ScaleX(40f) / 4f, rect_settingWindow.y - IGT_UIcommonFunc.ScaleY(40f) / 4f, IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleX(40f)), false);
			But_settingsClose.Draw();
			But_Settings_Music.Draw();
			But_Settings_Sound.Draw();
			But_settings_Notification.Draw();
			if (bRestoreEnabled)
			{
				But_Settings_RestorePurchase.Draw();
			}
			But_Settings_FBLogout.Draw();
			But_Settings_EditNickName.Draw();
			if (!pFacebook.isFBLoginSucess() && IGT_Preference.getInstance()._Get(kFBLoginfirstTime, 0) == 0)
			{
				pIgt_Textures.DrawTexture(IGT_Constants._Life, new Rect(rect_Set_MusicToggleImg.x, But_Settings_FBLogout.getOriginalDimension().y + IGT_UIcommonFunc.ScaleY(2f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), 20f, Vector2.zero);
				pIgt_Lable.DrawLable(new Rect(rect_Set_MusicToggleImg.x, But_Settings_FBLogout.getOriginalDimension().y - IGT_UIcommonFunc.ScaleY(0f), IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(30f)), "+" + IGT_Constants.nFBLoginLife, IGT_Constants.Font_TitanOne, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black, 24f, Vector2.zero);
			}
			pIgt_Textures.DrawTexture(IGT_Constants._Music, rect_Set_MusicIcon, false);
			pIgt_Textures.DrawTexture(IGT_Constants._Sound, rect_Set_SoundIcon, false);
			pIgt_Textures.DrawTexture(IGT_Constants._Notification, rect_Set_NotifyIcon, false);
			if (bRestoreEnabled)
			{
				pIgt_Textures.DrawTexture(IGT_Constants._RestorePurchase, rect_Set_RestorePurchaseIcon, false);
			}
			pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, rect_Set_FbIcon, false);
			pIgt_Textures.DrawTexture(IGT_Constants._GameIcon, rect_Set_EditNameIcon, false);
			if (pHero.nMusic == 0)
			{
				pIgt_Textures.DrawTexture(IGT_Constants._On, rect_Set_MusicToggleImg, false);
			}
			else
			{
				pIgt_Textures.DrawTexture(IGT_Constants._Off, rect_Set_MusicToggleImg, false);
			}
			if (pHero.nSound == 0)
			{
				pIgt_Textures.DrawTexture(IGT_Constants._On, rect_Set_SoundToggleImg, false);
			}
			else
			{
				pIgt_Textures.DrawTexture(IGT_Constants._Off, rect_Set_SoundToggleImg, false);
			}
			if (pHero.nGameNotification == 0)
			{
				pIgt_Textures.DrawTexture(IGT_Constants._On, rect_Set_Notify_ToggleImg, false);
			}
			else
			{
				pIgt_Textures.DrawTexture(IGT_Constants._Off, rect_Set_Notify_ToggleImg, false);
			}
			pIgt_Lable.DrawLable(new Rect(rect_settingWindow.x + IGT_UIcommonFunc.ScaleX(48f), rect_settingWindow.y + IGT_UIcommonFunc.ScaleY(20f), IGT_UIcommonFunc.ScaleX(150f), IGT_UIcommonFunc.ScaleY(30f)), IGT_Constants.Settings, IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(20f), TextAnchor.MiddleCenter, false, Color.yellow, new Vector2(2f, 2f), Color.black);
			pIgt_Lable.DrawLable(rect_Set_MusicLable, IGT_Constants.Music, IGT_Constants.Font_alpha_echo, fontSize_Set_Music, TextAnchor.MiddleCenter, false, Color.white, new Vector2(1f, 1f), Color.black);
			pIgt_Lable.DrawLable(rect_Set_SoundLabel, IGT_Constants.Sound, IGT_Constants.Font_alpha_echo, fontSize_Set_Music, TextAnchor.MiddleCenter, false, Color.white, new Vector2(1f, 1f), Color.black);
			pIgt_Lable.DrawLable(rect_Set_NotifyLabel, IGT_Constants.Notification, IGT_Constants.Font_alpha_echo, fontSize_Set_Notification, TextAnchor.MiddleCenter, false, Color.white, new Vector2(1f, 1f), Color.black);
			if (bRestoreEnabled)
			{
				pIgt_Lable.DrawLable(rect_Set_RestorePurchaseLabel, IGT_Constants.RestorePurchase, IGT_Constants.Font_alpha_echo, fontSize_Set_RestorePurchase, TextAnchor.MiddleCenter, false, Color.white, new Vector2(1f, 1f), Color.black);
			}
			if (!pFacebook.isFBLoginSucess())
			{
				pIgt_Lable.DrawLable(rect_Set_FbLabel, IGT_Constants.FbConnect, IGT_Constants.Font_alpha_echo, fontSize_Set_Music, TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black);
			}
			else
			{
				pIgt_Lable.DrawLable(rect_Set_FbLabel, IGT_Constants.FbLogOut, IGT_Constants.Font_alpha_echo, fontSize_Set_Music, TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black);
			}
			pIgt_Lable.DrawLable(rect_Set_EditNameLable, IGT_Constants.EditName, IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black);
		}
		GUI.matrix = Matrix4x4.identity;
		if (bShowNickName)
		{
			drawNickNameWindow();
		}
	}

	public static void menubackbtnevent()
	{
		bleaderboardHSbtnClick = false;
		centre_character = selected_character;
		HScam_cur_angle = (float)playing_character * ang_btwn_Characters + HScam_start_angle;
		IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_hero_menu, playing_character);
		IGT_Preference.getInstance()._SaveAll();
		setScreenMode(0);
		if (pHero.nHeroIndex != playing_character)
		{
			pHero.changeCharacter(playing_character);
		}
	}

	public void Moregames_window()
	{
		pIgt_Textures.DrawTexture(IGT_Constants._GreyOverLay, new Rect(0f, 0f, Screen.width, Screen.height), false);
		pIgt_Textures.DrawTexture(IGT_Constants._countDown_Bg, new Rect(IGT_UIcommonFunc.ScaleX(25f), IGT_UIcommonFunc.ScaleY(52f), (float)Screen.width - IGT_UIcommonFunc.ScaleX(50f), (float)Screen.height - IGT_UIcommonFunc.ScaleY(70f)), false);
		pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(25f), IGT_UIcommonFunc.ScaleY(20f), (float)Screen.width - IGT_UIcommonFunc.ScaleX(50f), (float)Screen.height - IGT_UIcommonFunc.ScaleY(70f)), "Loading...", IGT_Constants.Font_LemonR, (int)IGT_UIcommonFunc.ScaleX(17f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.one, Color.black);
		pIgt_Textures.drawBorder(new Rect(IGT_UIcommonFunc.ScaleX(25f), IGT_UIcommonFunc.ScaleY(50f), (float)Screen.width - IGT_UIcommonFunc.ScaleX(50f), (float)Screen.height - IGT_UIcommonFunc.ScaleY(70f)), 5f, Border_White);
		pMoregame.draw(pIgt_Textures, IGT_Constants.MoregamesTitle);
	}

	public static void start_AchievementAlert(string achievement_name)
	{
		if (!bInappAlert && !bIsShowGPluseLoginAlert && nScreenMode != 1 && nScreenMode != 21)
		{
			pAnim_GAchievement.resetAllValues();
			bAchievementAlert = true;
			completed_achievement = achievement_name;
		}
	}

	public void achievement_alertdraw(string achieve_name)
	{
		pIgt_Textures.DrawTexture(IGT_Constants._GreyOverLay, new Rect(0f, 0f, Screen.width, Screen.height), false);
		float num = 0f;
		num = pAnim_GAchievement.easeFunctions(0f - IGT_UIcommonFunc.ScaleY(280f), IGT_UIcommonFunc.ScaleY(0f), 1f, 29);
		if (pAnim_GAchievement.isAnimFinished() && pAnim_GAchievement.getIsReverse())
		{
			bAchievementAlert = false;
			return;
		}
		pIgt_Textures.DrawTexture(IGT_Constants._NoMoreLives_BG, new Rect(IGT_UIcommonFunc.ScaleX(20f), num + IGT_UIcommonFunc.ScaleY(200f), IGT_UIcommonFunc.ScaleX(280f), IGT_UIcommonFunc.ScaleY(80f)), false);
		pIgt_Textures.DrawTexture(IGT_Constants._Achievement, new Rect(IGT_UIcommonFunc.ScaleX(2f), num + IGT_UIcommonFunc.ScaleY(185f), IGT_UIcommonFunc.ScaleX(50f), IGT_UIcommonFunc.ScaleY(50f)), false);
		But_achievementalert_close.setY(num + IGT_UIcommonFunc.ScaleY(200f));
		But_achievementalert_close.Draw();
		pIgt_Textures.DrawTexture(IGT_Constants._ScoreMultiplier, new Rect(IGT_UIcommonFunc.ScaleX(83f), num + IGT_UIcommonFunc.ScaleY(203f), IGT_UIcommonFunc.ScaleX(20f), IGT_UIcommonFunc.ScaleY(20f)), false);
		pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(30f), num + IGT_UIcommonFunc.ScaleY(175f), IGT_UIcommonFunc.ScaleX(283f), IGT_UIcommonFunc.ScaleY(80f)), "New Achievement!", IGT_Constants.Font_Jellee_Roman, (int)IGT_UIcommonFunc.ScaleX(13f), TextAnchor.MiddleCenter, false, Color.blue, 2f, Color.white, Vector2.one, Color.white);
		pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(50f), num + IGT_UIcommonFunc.ScaleY(205f), IGT_UIcommonFunc.ScaleX(220f), IGT_UIcommonFunc.ScaleY(80f)), achieve_name, IGT_Constants.Font_LemonR, (int)IGT_UIcommonFunc.ScaleX(12f), TextAnchor.MiddleCenter, true, Color.yellow, 2f, Color.black, Vector2.zero, Color.white);
	}

	public Rect adj_drawrect(Rect base_rect, Rect cur_rect, int flag)
	{
		switch (flag)
		{
		case 0:
		{
			float y = base_rect.y + base_rect.height / 2f - cur_rect.height / 2f;
			return new Rect(cur_rect.x, y, cur_rect.width, cur_rect.height);
		}
		case 1:
		{
			float x = base_rect.x + base_rect.width / 2f - cur_rect.width / 2f;
			return new Rect(x, cur_rect.y, cur_rect.width, cur_rect.height);
		}
		default:
		{
			float y = base_rect.y + base_rect.height / 2f - cur_rect.height / 2f;
			float x = base_rect.x + base_rect.width / 2f - cur_rect.width / 2f;
			return new Rect(x, y, cur_rect.width, cur_rect.height);
		}
		}
	}

	public void drawAllShareCheckingAlert()
	{
		if (pSocialShare.appInstalledMsg == null || !bAppNotInstalledAlert)
		{
			return;
		}
		float a = 1f;
		if (bChaseLock_Alpha)
		{
			a = IGT_EaseFunction.Linear_ease(fChaseLockAlpha_StartTime, 1f, 0.1f, 1f);
			fChaseLockAlpha_StartTime += Time.deltaTime;
			if (fChaseLockAlpha_StartTime > 1f)
			{
				bAppNotInstalledAlert = false;
				bChaseLock_Alpha = false;
			}
		}
		else if (Time.time - fChaseLockAlert_StartTime > 1f && !bChaseLock_Alpha)
		{
			fChaseLockAlpha_StartTime = 0f;
			bChaseLock_Alpha = true;
		}
		Color color = GUI.color;
		GUI.color = new Color(color.r, color.g, color.b, a);
		pIgt_Textures.DrawTexture(IGT_Constants._GreyOverLay, new Rect(IGT_UIcommonFunc.ScaleX(32f), IGT_UIcommonFunc.ScaleY(215f), IGT_UIcommonFunc.ScaleX(253f), IGT_UIcommonFunc.ScaleY(50f)), false);
		pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(32f), IGT_UIcommonFunc.ScaleY(190f), IGT_UIcommonFunc.ScaleX(260f), IGT_UIcommonFunc.ScaleY(100f)), pSocialShare.appInstalledMsg, IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(13f), TextAnchor.MiddleCenter, true, Color.white, 0f, Color.black, new Vector2(1f, 1f), Color.black);
		GUI.color = color;
	}

	public static void feedshareSuccess()
	{
		IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_feedLastShareTime, (float)currentTimeSecs());
		feedShareTime = (long)IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_feedLastShareTime, 0f);
		if (feedType == 0)
		{
			IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_feedShareCount, (float)(int.Parse(feedLeveld) / 5));
		}
	}

	public static void feedshareFailed()
	{
		IGT_Preference.getInstance()._Set(IGT_Constants.playerPref_feedLastShareTime, (float)currentTimeSecs());
		feedShareTime = (long)IGT_Preference.getInstance()._Get(IGT_Constants.playerPref_feedLastShareTime, 0f);
	}

	public static void feedTagListCompleted(Dictionary<string, FBFriendInfoList> dict)
	{
		fbTagableFriends = dict;
		feedTagkeys = dict.Keys.ToList();
		showNetworkError = false;
		showFriendListError = false;
		for (int i = 0; i < 5; i++)
		{
			tex[i] = Resources.Load<Texture2D>("Images/UI/default_fb");
			feedElementLoading[i] = true;
		}
		if (feedElementLoading[5])
		{
			feedElementLoading[5] = true;
			if (feedType == 1)
			{
				Coroutiner.StartCoroutine(getImageData(6, "https://www.veegames.com/fb/games/comm/streetchaser/feedstory/image/streetchaser_chase.jpg"));
			}
			else if (feedType == 0)
			{
				Coroutiner.StartCoroutine(getImageData(6, "https://www.veegames.com/fb/games/comm/streetchaser/feedstory/image/streetchaser_mission.jpg"));
			}
		}
		else
		{
			showPartialLoading = true;
		}
		if (fbTagableFriends != null && feedTagkeys != null && feedTagkeys.Count > 5 * (currentPage - 1) && fbTagableFriends.ContainsKey(feedTagkeys[5 * (currentPage - 1)]) && fbTagableFriends[feedTagkeys[5 * (currentPage - 1)]].userProfilePicData != null)
		{
			getProPicImageData(1, dict[feedTagkeys[5 * (currentPage - 1)]].userProfilePicData);
		}
		if (fbTagableFriends != null && feedTagkeys != null && feedTagkeys.Count > 5 * (currentPage - 1) + 1 && fbTagableFriends.ContainsKey(feedTagkeys[5 * (currentPage - 1) + 1]) && fbTagableFriends[feedTagkeys[5 * (currentPage - 1) + 1]].userProfilePicData != null)
		{
			getProPicImageData(2, dict[feedTagkeys[5 * (currentPage - 1) + 1]].userProfilePicData);
		}
		if (fbTagableFriends != null && feedTagkeys != null && feedTagkeys.Count > 5 * (currentPage - 1) + 2 && fbTagableFriends.ContainsKey(feedTagkeys[5 * (currentPage - 1) + 2]) && fbTagableFriends[feedTagkeys[5 * (currentPage - 1) + 2]].userProfilePicData != null)
		{
			getProPicImageData(3, dict[feedTagkeys[5 * (currentPage - 1) + 2]].userProfilePicData);
		}
		if (fbTagableFriends != null && feedTagkeys != null && feedTagkeys.Count > 5 * (currentPage - 1) + 3 && fbTagableFriends.ContainsKey(feedTagkeys[5 * (currentPage - 1) + 3]) && fbTagableFriends[feedTagkeys[5 * (currentPage - 1) + 3]].userProfilePicData != null)
		{
			getProPicImageData(4, dict[feedTagkeys[5 * (currentPage - 1) + 3]].userProfilePicData);
		}
		if (fbTagableFriends != null && feedTagkeys != null && feedTagkeys.Count > 5 * (currentPage - 1) + 4 && fbTagableFriends.ContainsKey(feedTagkeys[5 * (currentPage - 1) + 4]) && fbTagableFriends[feedTagkeys[5 * (currentPage - 1) + 4]].userProfilePicData != null)
		{
			getProPicImageData(5, dict[feedTagkeys[5 * (currentPage - 1) + 4]].userProfilePicData);
		}
	}

	public static void feedTagListFailed()
	{
		showLoading = false;
		showNetworkError = true;
		showPartialLoading = false;
		showFriendListError = false;
	}

	public static void feedTagNoFriends()
	{
		showLoading = false;
		showNetworkError = false;
		showPartialLoading = false;
		showFriendListError = false;
		if (bFeedInviteFriendAlert)
		{
			bFeedInviteFriendAlert = false;
			pAnim_feedinvite.resetAllValues();
			pAnim_feedinvite.setIsReverse(true);
		}
		if (feedType == 1)
		{
			pFacebook.FBFeedShare("https://www.veegames.com/fb/streetchaser/feedstory/crossedscore/" + feedChaseScore, feedshareSuccess, feedshareFailed);
		}
		else if (feedType == 0)
		{
			pFacebook.FBFeedShare("https://www.veegames.com/fb/streetchaser/feedstory/milestone/" + feedLeveld, feedshareSuccess, feedshareFailed);
		}
	}

	public static void feedTagListNext()
	{
		if (!showLoading && !showNetworkError && !showPartialLoading && !showFriendListError)
		{
			int num = fbTagableFriends.Count / 5;
			if (fbTagableFriends.Count % 5 != 0)
			{
				num++;
			}
			feedLoadingTime = Time.time;
			if (!feedElementLoading[5])
			{
				showPartialLoading = true;
				showLoading = false;
				showNetworkError = false;
				showFriendListError = false;
			}
			else
			{
				showPartialLoading = false;
				showLoading = true;
				showNetworkError = false;
				showFriendListError = false;
			}
			currentPage++;
			feedTagListCompleted(fbTagableFriends);
		}
	}

	public static void feedTagListPrev()
	{
		if (!showLoading && !showNetworkError && !showPartialLoading && !showFriendListError)
		{
			feedLoadingTime = Time.time;
			if (!feedElementLoading[5])
			{
				showPartialLoading = true;
				showLoading = false;
			}
			else
			{
				showPartialLoading = false;
				showLoading = true;
			}
			showNetworkError = false;
			showFriendListError = false;
			currentPage--;
			feedTagListCompleted(fbTagableFriends);
			int num = fbTagableFriends.Count / 5;
			if (fbTagableFriends.Count % 5 != 0)
			{
				num++;
			}
		}
	}

	public static void feedTagListSubmit()
	{
		if (!showLoading && !showNetworkError && !showPartialLoading && !showFriendListError)
		{
			if (bFeedInviteFriendAlert)
			{
				bFeedInviteFriendAlert = false;
				pAnim_feedinvite.resetAllValues();
				pAnim_feedinvite.setIsReverse(true);
			}
			if (feedType == 1)
			{
				pFacebook.FBFeedShare("https://www.veegames.com/fb/streetchaser/feedstory/crossedscore/" + feedChaseScore, feedshareSuccess, feedshareFailed, listSeperatedByCommas(taggableFriendsString));
			}
			else if (feedType == 0)
			{
				pFacebook.FBFeedShare("https://www.veegames.com/fb/streetchaser/feedstory/milestone/" + feedLeveld, feedshareSuccess, feedshareFailed, listSeperatedByCommas(taggableFriendsString));
			}
		}
	}

	public void feedCheckAll()
	{
		if (!showLoading && !showNetworkError && !showFriendListError)
		{
			int num = 5;
			num = ((currentPage > fbTagableFriends.Count / 5) ? (fbTagableFriends.Count % 5) : 5);
			for (int i = 0; i < num; i++)
			{
				fbTagableFriends[feedTagkeys[5 * (currentPage - 1) + i]].isCheckBoxTicked = true;
				addItemToList(feedTagkeys[5 * (currentPage - 1) + i]);
			}
		}
	}

	public void addItemToList(string item)
	{
		if (!taggableFriendsString.Contains(item))
		{
			taggableFriendsString.Add(item);
		}
	}

	public void removeItemFromList(string item)
	{
		if (taggableFriendsString.Contains(item))
		{
			taggableFriendsString.Remove(item);
		}
	}

	public static string listSeperatedByCommas(List<string> list)
	{
		string text = null;
		foreach (string item in list)
		{
			text = ((!string.IsNullOrEmpty(text)) ? string.Concat(text + "," + item) : string.Concat(item));
		}
		return text;
	}

	public static void givenPermission(bool val)
	{
		if (val)
		{
			pAnim_postalert.resetAllValues();
			pAnim_postalert.setIsReverse(true);
			showNetworkError = false;
			showFriendListError = false;
			bFeedInviteFriendAlert = true;
			pFacebook.FBTaggableFriends(feedTagListCompleted, feedTagListFailed, feedTagNoFriends);
			feedLoadingTime = Time.time;
			pAnim_feedinvite.resetAllValues();
		}
		else
		{
			pAnim_postalert.resetAllValues();
			pAnim_postalert.setIsReverse(true);
		}
	}

	public static void getProPicImageData(int id, byte[] _url)
	{
		Texture2D texture2D = new Texture2D(1, 1);
		texture2D.LoadImage(_url);
		tex[id - 1] = texture2D;
		feedElementLoading[id - 1] = false;
	}

	public static IEnumerator getImageData(int id, string _url)
	{
		WWW url = new WWW(_url);
		yield return url;
		if (url.error == null)
		{
			tex[id - 1] = url.texture;
			feedElementLoading[id - 1] = false;
		}
	}

	private void setSocialShareValues()
	{
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.fbLastShare))
		{
			fbShareTime = (long)IGT_Preference.getInstance()._Get(IGT_Constants.fbLastShare, (float)currentTimeSecs());
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.whatsAppLastShare))
		{
			whatsappShareTime = (long)IGT_Preference.getInstance()._Get(IGT_Constants.whatsAppLastShare, (float)currentTimeSecs());
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.smsLastShare))
		{
			smsShareTime = (long)IGT_Preference.getInstance()._Get(IGT_Constants.smsLastShare, (float)currentTimeSecs());
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.mailLastShare))
		{
			mailShareTime = (long)IGT_Preference.getInstance()._Get(IGT_Constants.mailLastShare, (float)currentTimeSecs());
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.instaLastShare))
		{
			instaShareTime = (long)IGT_Preference.getInstance()._Get(IGT_Constants.instaLastShare, (float)currentTimeSecs());
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.twitterLastShare))
		{
			twitterShareTime = (long)IGT_Preference.getInstance()._Get(IGT_Constants.twitterLastShare, (float)currentTimeSecs());
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.pendingFBShare))
		{
			isPendingfbShare = IGT_Preference.getInstance()._Get(IGT_Constants.pendingFBShare, 0);
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.pendingwhatsAppShare))
		{
			isPendingwhatsappShare = IGT_Preference.getInstance()._Get(IGT_Constants.pendingwhatsAppShare, 0);
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.pendingSMSShare))
		{
			isPendingsmsShare = IGT_Preference.getInstance()._Get(IGT_Constants.pendingSMSShare, 0);
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.pendingMailShare))
		{
			isPendingmailShare = IGT_Preference.getInstance()._Get(IGT_Constants.pendingMailShare, 0);
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.pendingInstaShare))
		{
			isPendinginstaShare = IGT_Preference.getInstance()._Get(IGT_Constants.pendingInstaShare, 0);
		}
		if (IGT_Preference.getInstance()._isKey_AlreadyPresent(IGT_Constants.pendingTwitterShare))
		{
			isPendingtwitterShare = IGT_Preference.getInstance()._Get(IGT_Constants.pendingTwitterShare, 0);
		}
		if (currentTimeSecs() - fbShareTime >= 86400)
		{
			IGT_Constants.fbText = "Get " + IGT_Constants.nFBShareLife + " Lives";
		}
		else if (isPendingfbShare == 1)
		{
			IGT_Constants.fbText = " Processing ";
		}
		else
		{
			IGT_Constants.fbText = "+" + IGT_Constants.nFBShareLife + " Life Added";
		}
		if (currentTimeSecs() - whatsappShareTime >= 86400)
		{
			IGT_Constants.whatsAppText = "Get " + IGT_Constants.nWhatsappShareLife + " Lives";
		}
		else if (isPendingwhatsappShare == 1)
		{
			IGT_Constants.whatsAppText = " Processing ";
		}
		else
		{
			IGT_Constants.whatsAppText = "+" + IGT_Constants.nWhatsappShareLife + " Life Added";
		}
		if (currentTimeSecs() - smsShareTime >= 86400)
		{
			IGT_Constants.smsText = "Get " + IGT_Constants.nSMSShareLife + " Lives";
		}
		else if (isPendingsmsShare == 1)
		{
			IGT_Constants.smsText = " Processing ";
		}
		else
		{
			IGT_Constants.smsText = "+" + IGT_Constants.nSMSShareLife + " Life Added";
		}
		if (currentTimeSecs() - mailShareTime >= 86400)
		{
			IGT_Constants.mailText = "Get " + IGT_Constants.nMailShareLife + " Lives";
		}
		else if (isPendingmailShare == 1)
		{
			IGT_Constants.mailText = " Processing ";
		}
		else
		{
			IGT_Constants.mailText = "+" + IGT_Constants.nMailShareLife + " Life Added";
		}
		if (currentTimeSecs() - instaShareTime >= 86400)
		{
			IGT_Constants.instaText = "Get " + IGT_Constants.nInstaShareLife + " Lives";
		}
		else if (isPendinginstaShare == 1)
		{
			IGT_Constants.instaText = " Processing ";
		}
		else
		{
			IGT_Constants.instaText = "+" + IGT_Constants.nInstaShareLife + " Life Added";
		}
		if (currentTimeSecs() - twitterShareTime >= 86400)
		{
			IGT_Constants.twitterText = "Get " + IGT_Constants.nTwitterShareLife + " Lives";
		}
		else if (isPendingtwitterShare == 1)
		{
			IGT_Constants.twitterText = " Processing ";
		}
		else
		{
			IGT_Constants.twitterText = "+" + IGT_Constants.nTwitterShareLife + " Life Added";
		}
	}

	public static void postFeedStory(int type, string levelId, string chaseScore)
	{
		if (!pFacebook.isFBLoginSucess() || !pHero.isConnectedInternet())
		{
			return;
		}
		feedType = type;
		feedLeveld = levelId;
		feedChaseScore = chaseScore;
		bnormalFeedShare = true;
		if (pFacebook.HavePublishPermission)
		{
			if (feedType == 1)
			{
				pFacebook.FBFeedShare("https://www.veegames.com/fb/streetchaser/feedstory/crossedscore/" + feedChaseScore, feedshareSuccess, feedshareFailed);
			}
			else if (feedType == 0)
			{
				pFacebook.FBFeedShare("https://www.veegames.com/fb/streetchaser/feedstory/milestone/" + feedLeveld, feedshareSuccess, feedshareFailed);
			}
		}
		else
		{
			bPostFBAlert = true;
			pAnim_postalert.resetAllValues();
			pHero.post_Analytics_Popup("FeedStory");
		}
	}

	private void PostonFB_AlertWindow()
	{
		pIgt_Textures.DrawTexture(IGT_Constants._GreyOverLay, new Rect(0f, 0f, Screen.width, Screen.height), false);
		float num = pAnim_postalert.easeFunctions((float)Screen.width - IGT_UIcommonFunc.ScaleX(10f), 0f, 1f, 29);
		if (pAnim_postalert.isAnimFinished() && pAnim_postalert.getIsReverse())
		{
			bPostFBAlert = false;
			return;
		}
		pIgt_Textures.DrawTexture(IGT_Constants._NotEnoughKeys_BG, new Rect(rect_postonFB.x + num, rect_postonFB.y, rect_postonFB.width, rect_postonFB.height), false);
		pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, new Rect(rect_postonFB.x + num - IGT_UIcommonFunc.ScaleX(5f), rect_postonFB.y - IGT_UIcommonFunc.ScaleY(5f), IGT_UIcommonFunc.ScaleX(33f), IGT_UIcommonFunc.ScaleX(33f)), false);
		pIgt_Lable.DrawLable(new Rect(rect_postonFB.x + num, rect_postonFB.y + IGT_UIcommonFunc.ScaleY(35f), rect_postonFB.width, IGT_UIcommonFunc.ScaleY(15f)), "Would You like to share on Facebook?", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(16f), TextAnchor.MiddleCenter, true, Color.white, 0f, Color.black, new Vector2(2f, 2f), Color.black);
		But_postFB_Yes.setX(But_postFB_Yes.getOriginalDimension().x + num);
		But_postFB_Yes.Draw_Button();
		But_postFB_No.setX(But_postFB_No.getOriginalDimension().x + num);
		But_postFB_No.Draw_Button();
		pIgt_Lable.DrawLable(But_postFB_Yes.getCurrentDimension(), "Yes", IGT_Constants.Font_LemonR, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, true, Color.white, 2f, Color.black, new Vector2(1f, 1f), Color.black);
		pIgt_Lable.DrawLable(But_postFB_No.getCurrentDimension(), "No", IGT_Constants.Font_LemonR, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, true, Color.white, 2f, Color.black, new Vector2(1f, 1f), Color.black);
	}

	public void drawfeedInvite_Alert()
	{
		float num = pAnim_feedinvite.easeFunctions(0f - IGT_UIcommonFunc.ScaleX(300f), 0f, 1f, 29);
		if (pAnim_feedinvite.isAnimFinished() && pAnim_feedinvite.getIsReverse())
		{
			bFeedInviteFriendAlert = false;
			return;
		}
		showLoading = false;
		pIgt_Textures.DrawTexture(IGT_Constants._Leaderboard_FB_Alert, new Rect(rect_feedInvBG.x + num, rect_feedInvBG.y, rect_feedInvBG.width, rect_feedInvBG.height), false);
		pIgt_Lable.DrawLable(new Rect(rect_feedInvBG.x + IGT_UIcommonFunc.ScaleX(60f) + num, rect_feedInvBG.y + IGT_UIcommonFunc.ScaleY(5f), IGT_UIcommonFunc.ScaleX(150f), IGT_UIcommonFunc.ScaleY(30f)), "Tag Your Friends", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(16f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, new Vector2(1f, 1f), Color.black);
		if (showLoading)
		{
			pIgt_Lable.DrawLable(new Rect(rect_feedInvBG.x + IGT_UIcommonFunc.ScaleX(100f) + num, rect_feedInvBG.y + IGT_UIcommonFunc.ScaleY(150f), IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(80f)), "Loading...", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleLeft, false, Color.white, 1f, Color.black, Vector2.zero, Color.black);
			if (Time.time - feedLoadingTime > 10f)
			{
				showLoading = false;
				showPartialLoading = false;
				showNetworkError = true;
				showFriendListError = false;
			}
		}
		else if (showPartialLoading)
		{
			if (Time.time - feedLoadingTime > 10f)
			{
				showLoading = false;
				showPartialLoading = false;
				showNetworkError = true;
				showFriendListError = false;
			}
			pIgt_Lable.DrawLable(new Rect(rect_feedInvBG.x + IGT_UIcommonFunc.ScaleX(100f) + num, rect_feedInvBG.y + IGT_UIcommonFunc.ScaleY(220f), IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(80f)), "Loading...", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleLeft, false, Color.white, 1f, Color.black, Vector2.zero, Color.black);
			pIgt_Textures.DrawTexture(IGT_Constants._Hs_Menu_Bg, new Rect(rect_feedInvBG.x + IGT_UIcommonFunc.ScaleX(9f) + num, rect_feedInvBG.y + IGT_UIcommonFunc.ScaleY(154f), IGT_UIcommonFunc.ScaleX(262f), IGT_UIcommonFunc.ScaleY(30f)), false);
			pIgt_Textures.drawBorder(new Rect(rect_feedInvBG.x + IGT_UIcommonFunc.ScaleX(9f) + num, rect_feedInvBG.y + IGT_UIcommonFunc.ScaleY(156f), IGT_UIcommonFunc.ScaleX(262f), IGT_UIcommonFunc.ScaleY(30f)), 2f, Border_White);
			if (feedType == 1)
			{
				pIgt_Lable.DrawLable(new Rect(rect_feedInvBG.x + IGT_UIcommonFunc.ScaleX(9f) + num, rect_feedInvBG.y + IGT_UIcommonFunc.ScaleY(155f), IGT_UIcommonFunc.ScaleX(262f), IGT_UIcommonFunc.ScaleY(29f)), "Chase Score Street Chaser for Testing", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black);
			}
			else
			{
				pIgt_Lable.DrawLable(new Rect(rect_feedInvBG.x + IGT_UIcommonFunc.ScaleX(9f) + num, rect_feedInvBG.y + IGT_UIcommonFunc.ScaleY(155f), IGT_UIcommonFunc.ScaleX(262f), IGT_UIcommonFunc.ScaleY(29f)), "Mission milestone Street Chaser for Testing", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black);
			}
			if (tex[5] != null)
			{
				GUI.DrawTexture(new Rect(rect_feedInvBG.x + IGT_UIcommonFunc.ScaleX(9f) + num, rect_feedInvBG.y + IGT_UIcommonFunc.ScaleY(30f), IGT_UIcommonFunc.ScaleX(262f), IGT_UIcommonFunc.ScaleY(130f)), tex[5]);
				pIgt_Textures.drawBorder(new Rect(rect_feedInvBG.x + IGT_UIcommonFunc.ScaleX(9f) + num, rect_feedInvBG.y + IGT_UIcommonFunc.ScaleY(30f), IGT_UIcommonFunc.ScaleX(262f), IGT_UIcommonFunc.ScaleY(130f)), 2f, Border_White);
			}
		}
		else if (showNetworkError)
		{
			pIgt_Lable.DrawLable(new Rect(rect_feedInvBG.x + IGT_UIcommonFunc.ScaleX(100f) + num, rect_feedInvBG.y + IGT_UIcommonFunc.ScaleY(150f), IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(80f)), "Connection Failed! \n Please Retry Later.", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black);
		}
		else if (showFriendListError)
		{
			pIgt_Lable.DrawLable(new Rect(rect_feedInvBG.x + IGT_UIcommonFunc.ScaleX(100f) + num, rect_feedInvBG.y + IGT_UIcommonFunc.ScaleY(150f), IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(80f)), "FriendList Error! \n No Permission Given.", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black);
		}
		else
		{
			pIgt_Textures.DrawTexture(IGT_Constants._Hs_Menu_Bg, new Rect(rect_feedInvBG.x + IGT_UIcommonFunc.ScaleX(9f) + num, rect_feedInvBG.y + IGT_UIcommonFunc.ScaleY(154f), IGT_UIcommonFunc.ScaleX(262f), IGT_UIcommonFunc.ScaleY(30f)), false);
			pIgt_Textures.drawBorder(new Rect(rect_feedInvBG.x + IGT_UIcommonFunc.ScaleX(9f) + num, rect_feedInvBG.y + IGT_UIcommonFunc.ScaleY(156f), IGT_UIcommonFunc.ScaleX(262f), IGT_UIcommonFunc.ScaleY(30f)), 2f, Border_White);
			if (feedType == 1)
			{
				pIgt_Lable.DrawLable(new Rect(rect_feedInvBG.x + IGT_UIcommonFunc.ScaleX(9f) + num, rect_feedInvBG.y + IGT_UIcommonFunc.ScaleY(155f), IGT_UIcommonFunc.ScaleX(262f), IGT_UIcommonFunc.ScaleY(29f)), "Chase Score Street Chaser for Testing", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black);
			}
			else
			{
				pIgt_Lable.DrawLable(new Rect(rect_feedInvBG.x + IGT_UIcommonFunc.ScaleX(9f) + num, rect_feedInvBG.y + IGT_UIcommonFunc.ScaleY(155f), IGT_UIcommonFunc.ScaleX(262f), IGT_UIcommonFunc.ScaleY(29f)), "Mission milestone Street Chaser for Testing", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black);
			}
			if (tex[5] != null)
			{
				GUI.DrawTexture(new Rect(rect_feedInvBG.x + IGT_UIcommonFunc.ScaleX(9f) + num, rect_feedInvBG.y + IGT_UIcommonFunc.ScaleY(30f), IGT_UIcommonFunc.ScaleX(262f), IGT_UIcommonFunc.ScaleY(130f)), tex[5]);
				pIgt_Textures.drawBorder(new Rect(rect_feedInvBG.x + IGT_UIcommonFunc.ScaleX(9f) + num, rect_feedInvBG.y + IGT_UIcommonFunc.ScaleY(30f), IGT_UIcommonFunc.ScaleX(262f), IGT_UIcommonFunc.ScaleY(130f)), 2f, Border_White);
			}
			for (int i = 0; i < 5; i++)
			{
				if (fbTagableFriends != null && feedTagkeys != null && feedTagkeys.Count > 5 * (currentPage - 1) + i && fbTagableFriends.ContainsKey(feedTagkeys[5 * (currentPage - 1) + i]) && fbTagableFriends[feedTagkeys[5 * (currentPage - 1) + i]].userName != null)
				{
					pIgt_Lable.DrawLable(new Rect(rect_feedInvBG.x + IGT_UIcommonFunc.ScaleX(-50f) + num, rect_feedInvBG.y + IGT_UIcommonFunc.ScaleY(170f + 30f * (float)i), IGT_UIcommonFunc.ScaleX(150f), IGT_UIcommonFunc.ScaleY(80f)), 5 * (currentPage - 1) + i + 1 + string.Empty, IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(11f), TextAnchor.MiddleCenter, false, Color.white, 1f, Color.black, Vector2.zero, Color.black);
					GUI.DrawTexture(new Rect(rect_feedInvBG.x + IGT_UIcommonFunc.ScaleX(50f) + num, rect_feedInvBG.y + IGT_UIcommonFunc.ScaleY(198f + 30f * (float)i), IGT_UIcommonFunc.ScaleX(25f), IGT_UIcommonFunc.ScaleY(25f)), tex[i]);
					pIgt_Textures.drawBorder(new Rect(rect_feedInvBG.x + IGT_UIcommonFunc.ScaleX(50f) + num, rect_feedInvBG.y + IGT_UIcommonFunc.ScaleY(198f + 30f * (float)i), IGT_UIcommonFunc.ScaleX(25f), IGT_UIcommonFunc.ScaleY(25f)), 2f, Border_White);
					pIgt_Lable.DrawLable(new Rect(rect_feedInvBG.x + IGT_UIcommonFunc.ScaleX(90f) + num, rect_feedInvBG.y + IGT_UIcommonFunc.ScaleY(170f + 30f * (float)i), IGT_UIcommonFunc.ScaleX(80f), IGT_UIcommonFunc.ScaleY(80f)), fbTagableFriends[feedTagkeys[5 * (currentPage - 1) + i]].userName, IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(10f), TextAnchor.MiddleLeft, false, Color.white, 1f, Color.black, Vector2.zero, Color.black);
					if (fbTagableFriends[feedTagkeys[5 * (currentPage - 1) + i]].isCheckBoxTicked)
					{
						pIgt_Textures.DrawTexture(IGT_Constants.mailCheckMarkBox, new Rect(rect_feedInvBG.x + IGT_UIcommonFunc.ScaleX(220f) + num, rect_feedInvBG.y + IGT_UIcommonFunc.ScaleY(198f + 30f * (float)i), IGT_UIcommonFunc.ScaleX(23f), IGT_UIcommonFunc.ScaleY(23f)), false);
					}
					else
					{
						pIgt_Textures.DrawTexture(IGT_Constants.mailCheckBox, new Rect(rect_feedInvBG.x + IGT_UIcommonFunc.ScaleX(220f) + num, rect_feedInvBG.y + IGT_UIcommonFunc.ScaleY(198f + 30f * (float)i), IGT_UIcommonFunc.ScaleX(23f), IGT_UIcommonFunc.ScaleY(23f)), false);
					}
					if (currentPage == 1)
					{
						prevBtnEnabled = false;
					}
					else
					{
						prevBtnEnabled = true;
					}
					if (5 * (currentPage - 1) + 1 + i == fbTagableFriends.Count)
					{
						nextBtnEnabled = false;
					}
					else
					{
						nextBtnEnabled = true;
					}
				}
			}
		}
		But_feedInvite_Close.setX(But_feedInvite_Close.getOriginalDimension().x + num);
		But_feedInvite_Close.Draw_Button();
		if (!showLoading && !showNetworkError && !showPartialLoading && !showFriendListError)
		{
			But_feedInvite_Next.setX(But_feedInvite_Next.getOriginalDimension().x + num);
			But_feedInvite_Next.Draw_Button();
			if (!nextBtnEnabled)
			{
				pIgt_Textures.DrawTexture(IGT_Constants._countDown_Bg, new Rect(But_feedInvite_Next.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(2.5f), But_feedInvite_Next.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(2.5f), But_feedInvite_Next.getCurrentDimension().width - IGT_UIcommonFunc.ScaleX(5f), But_feedInvite_Next.getCurrentDimension().height - IGT_UIcommonFunc.ScaleY(6f)), false);
			}
			But_feedInvite_Prev.setX(But_feedInvite_Prev.getOriginalDimension().x + num);
			But_feedInvite_Prev.Draw_Button();
			if (!prevBtnEnabled)
			{
				pIgt_Textures.DrawTexture(IGT_Constants._countDown_Bg, new Rect(But_feedInvite_Prev.getCurrentDimension().x + IGT_UIcommonFunc.ScaleX(2.5f), But_feedInvite_Prev.getCurrentDimension().y + IGT_UIcommonFunc.ScaleY(2.5f), But_feedInvite_Prev.getCurrentDimension().width - IGT_UIcommonFunc.ScaleX(5f), But_feedInvite_Prev.getCurrentDimension().height - IGT_UIcommonFunc.ScaleY(6f)), false);
			}
			But_feedInvite_Submit.setX(But_feedInvite_Submit.getOriginalDimension().x + num);
			But_feedInvite_Submit.Draw_Button();
			But_feedInvite_Checkall.setX(But_feedInvite_Checkall.getOriginalDimension().x + num);
			But_feedInvite_Checkall.Draw_Button();
			pIgt_Lable.DrawLable(But_feedInvite_Next.getCurrentDimension(), ">>", IGT_Constants.Font_LemonR, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, true, Color.white, 2f, Color.black, new Vector2(1f, 1f), Color.black);
			pIgt_Lable.DrawLable(But_feedInvite_Prev.getCurrentDimension(), "<<", IGT_Constants.Font_LemonR, (int)IGT_UIcommonFunc.ScaleX(15f), TextAnchor.MiddleCenter, true, Color.white, 2f, Color.black, new Vector2(1f, 1f), Color.black);
			pIgt_Lable.DrawLable(But_feedInvite_Submit.getCurrentDimension(), "Share", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(13f), TextAnchor.MiddleCenter, true, Color.white, 2f, Color.black, new Vector2(1f, 1f), Color.black);
			pIgt_Lable.DrawLable(But_feedInvite_Checkall.getCurrentDimension(), "Check All", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(10f), TextAnchor.MiddleCenter, true, Color.white, 2f, Color.black, new Vector2(1f, 1f), Color.black);
		}
	}

	private void draw_Leaderboard_FBAlert()
	{
		pIgt_Textures.DrawTexture(IGT_Constants._GreyOverLay, new Rect(0f, 0f, Screen.width, Screen.height), false);
		pIgt_Textures.DrawTexture(IGT_Constants._Leaderboard_FB_Alert, new Rect(IGT_UIcommonFunc.ScaleX(10f), IGT_UIcommonFunc.ScaleY(55f), IGT_UIcommonFunc.ScaleX(300f), IGT_UIcommonFunc.ScaleY(370f)), false);
		pIgt_Textures.DrawTexture(IGT_Constants._leaderBoard, new Rect(IGT_UIcommonFunc.ScaleX(0f), IGT_UIcommonFunc.ScaleY(45f), IGT_UIcommonFunc.ScaleX(55f), IGT_UIcommonFunc.ScaleY(60f)), -20f, new Vector2(0.5f, 0.5f));
		pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(150f), IGT_UIcommonFunc.ScaleY(70f), IGT_UIcommonFunc.ScaleX(40f), IGT_UIcommonFunc.ScaleY(40f)), "LEADERBOARDS", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(22f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(2f, 2f), Color.black);
		But_FBLB_Alertclose.Draw();
		But_FBLB_AlertChase.Draw();
		But_FBLB_AlertMission.Draw();
		float num = IGT_UIcommonFunc.ScaleX(180f);
		float num2 = IGT_UIcommonFunc.ScaleY(60f);
		float y = IGT_UIcommonFunc.ScaleY(170f) + IGT_UIcommonFunc.ScaleY(107.5f) - num2 * 0.5f;
		float x = IGT_UIcommonFunc.ScaleX(160f) - num * 0.5f;
		Rect position = new Rect(x, y, num, num2);
		if (bFB_MsnEnablebtnClick)
		{
			pIgt_Textures.DrawTexture(IGT_Constants._BtnEnable_MC_LB, new Rect(IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(110f), IGT_UIcommonFunc.ScaleX(110f), IGT_UIcommonFunc.ScaleY(35f)), false);
			pIgt_Textures.DrawTexture(IGT_Constants._BtnDisable_MC_LB, new Rect(IGT_UIcommonFunc.ScaleX(150f), IGT_UIcommonFunc.ScaleY(110f), IGT_UIcommonFunc.ScaleX(140f), IGT_UIcommonFunc.ScaleY(40f)), false);
			But_FBLB_Friends.Draw();
			But_FBLB_Global.Draw();
			pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(110f), IGT_UIcommonFunc.ScaleX(110f), IGT_UIcommonFunc.ScaleY(35f)), "CHASE", IGT_Constants.Font_TitanOne, (int)((float)fontSize_HS_Chase_Mission * But_FBLB_AlertChase.getCurrentDimension().width / But_FBLB_AlertChase.getWidth()), TextAnchor.MiddleCenter, false, Color.white, new Vector2(2f, 2f), Color.black);
			pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(150f), IGT_UIcommonFunc.ScaleY(110f), IGT_UIcommonFunc.ScaleX(140f), IGT_UIcommonFunc.ScaleY(35f)), "MISSION", IGT_Constants.Font_TitanOne, (int)((float)fontSize_HS_Chase_Mission * But_FBLB_AlertMission.getCurrentDimension().width / But_FBLB_AlertMission.getWidth()), TextAnchor.MiddleCenter, false, Color.white, new Vector2(2f, 2f), Color.black);
			pIgt_Textures.DrawTexture(IGT_Constants._MC_FbLB_Tab_Bg_grn, new Rect(IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(190f), IGT_UIcommonFunc.ScaleX(260f), IGT_UIcommonFunc.ScaleY(215f)), false);
			if (bFBLBglobal)
			{
				GUI.DrawTexture(new Rect(IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(150f), IGT_UIcommonFunc.ScaleX(260f), IGT_UIcommonFunc.ScaleY(50f)), Mirror_Msn_FB);
				pIgt_Lable.DrawLable(new Rect(But_FBLB_Friends.getX() + IGT_UIcommonFunc.ScaleX(7f), But_FBLB_Friends.getY() - IGT_UIcommonFunc.ScaleY(4f), But_FBLB_Friends.getWidth(), But_FBLB_Friends.getHeight()), "FRIENDS", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(14f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(2f, 2f), Color.black);
				pIgt_Lable.DrawLable(new Rect(But_FBLB_Global.getX() + IGT_UIcommonFunc.ScaleX(5f), But_FBLB_Friends.getY() + IGT_UIcommonFunc.ScaleY(-2f), But_FBLB_Friends.getWidth(), But_FBLB_Friends.getHeight()), "WORLD", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(17f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(2f, 2f), Color.black);
				pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, new Rect(But_FBLB_Friends.getX() + IGT_UIcommonFunc.ScaleX(19f), But_FBLB_Friends.getY() + IGT_UIcommonFunc.ScaleY(13f), IGT_UIcommonFunc.ScaleX(17f), IGT_UIcommonFunc.ScaleX(17f)), false);
				pIgt_Textures.DrawTexture(IGT_Constants._GlobeIcon, new Rect(But_FBLB_Global.getX() + IGT_UIcommonFunc.ScaleX(12f), But_FBLB_Global.getY() + IGT_UIcommonFunc.ScaleY(12f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleX(22f)), false);
			}
			else
			{
				pIgt_Textures.DrawTexture(IGT_Constants._Msn_Fb_FriendsTab, new Rect(IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(150f), IGT_UIcommonFunc.ScaleX(260f), IGT_UIcommonFunc.ScaleY(50f)), false);
				pIgt_Lable.DrawLable(new Rect(But_FBLB_Friends.getX() + IGT_UIcommonFunc.ScaleX(16f), But_FBLB_Friends.getY() - IGT_UIcommonFunc.ScaleY(4f), But_FBLB_Friends.getWidth(), But_FBLB_Friends.getHeight()), "FRIENDS", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(17f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(2f, 2f), Color.black);
				pIgt_Lable.DrawLable(new Rect(But_FBLB_Global.getX() + IGT_UIcommonFunc.ScaleX(10f), But_FBLB_Friends.getY() + IGT_UIcommonFunc.ScaleY(-4f), But_FBLB_Friends.getWidth(), But_FBLB_Friends.getHeight()), "WORLD", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(14f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(2f, 2f), Color.black);
				pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, new Rect(But_FBLB_Friends.getX() + IGT_UIcommonFunc.ScaleX(19f), But_FBLB_Friends.getY() + IGT_UIcommonFunc.ScaleY(12.5f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleX(22f)), false);
				pIgt_Textures.DrawTexture(IGT_Constants._GlobeIcon, new Rect(But_FBLB_Global.getX() + IGT_UIcommonFunc.ScaleX(29f), But_FBLB_Global.getY() + IGT_UIcommonFunc.ScaleY(13f), IGT_UIcommonFunc.ScaleX(17f), IGT_UIcommonFunc.ScaleX(17f)), false);
			}
			if (nLeaderBoard_Mission_DispState == 1)
			{
				pIgt_Lable.DrawLable(position, _sNoInternet, IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(18f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black);
			}
			else if (nLeaderBoard_Mission_DispState == 3)
			{
				pIgt_Lable.DrawLable(position, _sConnectionFailed, IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(18f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black);
			}
			else if (nLeaderBoard_Mission_DispState == 0)
			{
				pIgt_Lable.DrawLable(position, _sLoading, IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(20f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black);
				if (Time.time - fLoadingStrtTime > fLoadingTotTime)
				{
					nLeaderBoard_Mission_DispState = 3;
				}
			}
			else if (nLeaderBoard_Mission_DispState == 2)
			{
				Alt_GFBleaderBoardData();
			}
			if (nLeaderBoard_Mission_DispState == 1 || nLeaderBoard_Mission_DispState == 3)
			{
				But_GetScoreRetry.setY(position.y + IGT_UIcommonFunc.ScaleY(50f));
				But_GetScoreRetry.Draw_Button();
				pIgt_Lable.DrawLable(But_GetScoreRetry.getCurrentDimension(), "Retry", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(16f), TextAnchor.MiddleCenter, false, Color.white, Vector2.one * 2f, Color.black);
			}
			return;
		}
		pIgt_Textures.DrawTexture(IGT_Constants._BtnEnable_MC_LB, new Rect(IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(110f), IGT_UIcommonFunc.ScaleX(140f), IGT_UIcommonFunc.ScaleY(40f)), false);
		pIgt_Textures.DrawTexture(IGT_Constants._BtnDisable_MC_LB, new Rect(IGT_UIcommonFunc.ScaleX(180f), IGT_UIcommonFunc.ScaleY(110f), IGT_UIcommonFunc.ScaleX(110f), IGT_UIcommonFunc.ScaleY(35f)), false);
		But_FBLB_Friends.Draw();
		But_FBLB_Global.Draw();
		pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(110f), IGT_UIcommonFunc.ScaleX(140f), IGT_UIcommonFunc.ScaleY(35f)), "CHASE", IGT_Constants.Font_TitanOne, (int)((float)fontSize_HS_Chase_Mission * But_FBLB_AlertChase.getCurrentDimension().width / But_FBLB_AlertChase.getWidth()), TextAnchor.MiddleCenter, false, Color.white, new Vector2(2f, 2f), Color.black);
		pIgt_Lable.DrawLable(new Rect(IGT_UIcommonFunc.ScaleX(180f), IGT_UIcommonFunc.ScaleY(110f), IGT_UIcommonFunc.ScaleX(110f), IGT_UIcommonFunc.ScaleY(35f)), "MISSION", IGT_Constants.Font_TitanOne, (int)((float)fontSize_HS_Chase_Mission * But_FBLB_AlertMission.getCurrentDimension().width / But_FBLB_AlertMission.getWidth()), TextAnchor.MiddleCenter, false, Color.white, new Vector2(2f, 2f), Color.black);
		pIgt_Textures.DrawTexture(IGT_Constants._MC_FbLB_Tab_Bg, new Rect(IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(190f), IGT_UIcommonFunc.ScaleX(260f), IGT_UIcommonFunc.ScaleY(215f)), false);
		if (bFBLBglobal)
		{
			GUI.DrawTexture(new Rect(IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(151f), IGT_UIcommonFunc.ScaleX(260f), IGT_UIcommonFunc.ScaleY(50f)), Mirror_Chs_FB);
			pIgt_Lable.DrawLable(new Rect(But_FBLB_Friends.getX() + IGT_UIcommonFunc.ScaleX(7f), But_FBLB_Friends.getY() - IGT_UIcommonFunc.ScaleY(4f), But_FBLB_Friends.getWidth(), But_FBLB_Friends.getHeight()), "FRIENDS", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(14f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(2f, 2f), Color.black);
			pIgt_Lable.DrawLable(new Rect(But_FBLB_Global.getX() + IGT_UIcommonFunc.ScaleX(5f), But_FBLB_Friends.getY() + IGT_UIcommonFunc.ScaleY(-2f), But_FBLB_Friends.getWidth(), But_FBLB_Friends.getHeight()), "WORLD", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(17f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(2f, 2f), Color.black);
			pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, new Rect(But_FBLB_Friends.getX() + IGT_UIcommonFunc.ScaleX(19f), But_FBLB_Friends.getY() + IGT_UIcommonFunc.ScaleY(13f), IGT_UIcommonFunc.ScaleX(17f), IGT_UIcommonFunc.ScaleX(17f)), false);
			pIgt_Textures.DrawTexture(IGT_Constants._GlobeIcon, new Rect(But_FBLB_Global.getX() + IGT_UIcommonFunc.ScaleX(12f), But_FBLB_Global.getY() + IGT_UIcommonFunc.ScaleY(12f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleX(22f)), false);
		}
		else
		{
			pIgt_Textures.DrawTexture(IGT_Constants._Chs_FBLB_Tab, new Rect(IGT_UIcommonFunc.ScaleX(30f), IGT_UIcommonFunc.ScaleY(150f), IGT_UIcommonFunc.ScaleX(260f), IGT_UIcommonFunc.ScaleY(50f)), false);
			pIgt_Lable.DrawLable(new Rect(But_FBLB_Friends.getX() + IGT_UIcommonFunc.ScaleX(16f), But_FBLB_Friends.getY() - IGT_UIcommonFunc.ScaleY(4f), But_FBLB_Friends.getWidth(), But_FBLB_Friends.getHeight()), "FRIENDS", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(17f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(2f, 2f), Color.black);
			pIgt_Lable.DrawLable(new Rect(But_FBLB_Global.getX() + IGT_UIcommonFunc.ScaleX(10f), But_FBLB_Friends.getY() + IGT_UIcommonFunc.ScaleY(-4f), But_FBLB_Friends.getWidth(), But_FBLB_Friends.getHeight()), "WORLD", IGT_Constants.Font_alpha_echo, (int)IGT_UIcommonFunc.ScaleX(14f), TextAnchor.MiddleCenter, false, Color.white, new Vector2(2f, 2f), Color.black);
			pIgt_Textures.DrawTexture(IGT_Constants._FbIcon, new Rect(But_FBLB_Friends.getX() + IGT_UIcommonFunc.ScaleX(19f), But_FBLB_Friends.getY() + IGT_UIcommonFunc.ScaleY(12.5f), IGT_UIcommonFunc.ScaleX(22f), IGT_UIcommonFunc.ScaleX(22f)), false);
			pIgt_Textures.DrawTexture(IGT_Constants._GlobeIcon, new Rect(But_FBLB_Global.getX() + IGT_UIcommonFunc.ScaleX(29f), But_FBLB_Global.getY() + IGT_UIcommonFunc.ScaleY(13f), IGT_UIcommonFunc.ScaleX(17f), IGT_UIcommonFunc.ScaleX(17f)), false);
		}
		if (nLeaderBoard_Chase_DispState == 1)
		{
			pIgt_Lable.DrawLable(position, _sNoInternet, IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(18f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black);
		}
		else if (nLeaderBoard_Chase_DispState == 3)
		{
			pIgt_Lable.DrawLable(position, _sConnectionFailed, IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(18f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black);
		}
		else if (nLeaderBoard_Chase_DispState == 0)
		{
			pIgt_Lable.DrawLable(position, _sLoading, IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(20f), TextAnchor.MiddleCenter, false, Color.yellow, 1f, Color.black, Vector2.zero, Color.black);
			if (Time.time - fLoadingStrtTime > fLoadingTotTime)
			{
				nLeaderBoard_Chase_DispState = 3;
			}
		}
		else if (nLeaderBoard_Chase_DispState == 2)
		{
			Alt_GFBleaderboardChase();
		}
		if (nLeaderBoard_Chase_DispState == 1 || nLeaderBoard_Chase_DispState == 3)
		{
			But_GetScoreRetry.setY(position.y + IGT_UIcommonFunc.ScaleY(50f));
			But_GetScoreRetry.Draw_Button();
			pIgt_Lable.DrawLable(But_GetScoreRetry.getCurrentDimension(), "Retry", IGT_Constants.Font_Nunito_Bold, (int)IGT_UIcommonFunc.ScaleX(16f), TextAnchor.MiddleCenter, false, Color.white, Vector2.one * 2f, Color.black);
		}
	}

	private void refreshFBListIfneeded()
	{
		if (!pFacebook.isFBLoginSucess() || !pHero.isConnectedInternet())
		{
			return;
		}
		if (pFacebook.UserFrndsInfo.Keys.Count == 0)
		{
			pFacebook.GetFriendsInfo(getfrndListCompleted);
			return;
		}
		List<string> list = pFacebook.UserFrndsInfo.Keys.ToList();
		if (pFacebook.UserFrndsInfo.Count > 0 && pFacebook.UserFrndsInfo != null && list.Count > 0 && string.IsNullOrEmpty(list[0]))
		{
			pFacebook.GetFriendsInfo(getfrndListCompleted);
		}
	}
}
