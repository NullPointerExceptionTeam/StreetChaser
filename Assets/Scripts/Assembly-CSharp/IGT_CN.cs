using System.Collections.Generic;

/// <summary>
/// 英译中运行时翻译器，用于硬编码 UI 字符串的即时翻译
/// </summary>
public static class IGT_CN
{
	private static readonly Dictionary<string, string> dict = new Dictionary<string, string>();

	/// <summary>前缀匹配翻译，用于 "前缀 + 动态数字" 拼接的文本</summary>
	private static readonly List<KeyValuePair<string, string>> prefixDict = new List<KeyValuePair<string, string>>();

	static IGT_CN()
	{
		dict["Score"] = "分数";
		dict["SCORE"] = "分数";
		dict["Total Score "] = "总分 ";
		dict["Distance"] = "距离";
		dict["Time"] = "时间";
		dict["meters"] = "米";
		dict["Tap to Continue"] = "点击继续";
		dict["Tap to Continue..."] = "点击继续...";
		dict["Paused"] = "已暂停";
		dict["Resume"] = "继续";
		dict["PLAY"] = "开始游戏";
		dict["MISSION"] = "任务";
		dict["CHASE"] = "追逐";
		dict["Chase"] = "追逐";
		dict["Mission \n \t Failed"] = "任务\n失败";
		dict["Skip >>"] = "跳过 >>";
		dict["CHASE  GAME  UNLOCKED"] = "追逐游戏已解锁";
		dict["COMPLETE 5  LEVELS  IN MISSIONS  TO PLAY CHASE"] = "完成任务中的 5 个关卡即可解锁追逐模式";
		dict["No Internet Connection !"] = "没有网络连接！";
		dict["Please check your Internet \nConnection and try again."] = "请检查网络连接后重试。";
		dict["Connection Failed! \n Please Retry Later."] = "连接失败！\n请稍后重试。";
		dict["FriendList Error! \n No Permission Given."] = "好友列表错误！\n没有权限。";
		dict["Loading..."] = "加载中...";
		dict["OK"] = "确定";
		dict["Retry"] = "重试";
		dict["Quit"] = "退出";
		dict["Yes"] = "是";
		dict["No"] = "否";
		dict["Later"] = "稍后";
		dict["Share"] = "分享";
		dict["Send"] = "发送";
		dict["Accept"] = "接受";
		dict["Check All"] = "全部查看";
		dict["Ask"] = "请求";
		dict["Invite"] = "邀请";
		dict["Invite Friends"] = "邀请好友";
		dict["Invite your Friends to \nask Free Lives"] = "邀请好友获取免费生命";
		dict["Send Feedback"] = "发送反馈";
		dict["Rate It"] = "评分";
		dict["Like"] = "点赞";
		dict["Store"] = "商店";
		dict["Connect"] = "连接";
		dict["Friends"] = "好友";
		dict["FRIENDS"] = "好友";
		dict["World"] = "世界";
		dict["WORLD"] = "世界";
		dict["Topchase"] = "追逐排行";
		dict["Caught"] = "被追";
		dict["Caught :  "] = "被追：";
		dict["Combo"] = "连击";
		dict["Boost"] = "加速";
		dict["Free"] = "免费";
		dict["LEADERBOARDS"] = "排行榜";
		dict["REMAINING LIVES"] = "剩余生命";
		dict["NO MORE LIVES"] = "生命不足";
		dict["NOT ENOUGH KEYS"] = "钥匙不足";
		dict["New Achievement!"] = "新成就！";
		dict["Life full"] = "生命已满";
		dict["Enter NickName"] = "输入昵称";
		dict["Click here..."] = "点击输入...";
		dict["ARE YOU SURE WANT TO LEAVE ?"] = "确定要离开吗？";
		dict["ARE YOU SURE?"] = "确定吗？";
		dict["Earn +2 lives"] = "获得 +2 生命";
		dict["Get Free Lives by Inviting friends \n and compete with them."] = "邀请好友获取免费生命\n并和他们竞争。";
		dict["Grab the Offer Now !!!"] = "立即获取优惠！";
		dict["For More Offers"] = "更多优惠";
		dict["5 Lives"] = "5 条命";
		dict["25 Lives"] = "25 条命";
		dict["100 Lives"] = "100 条命";
		dict["30 keys"] = "30 钥匙";
		dict["120 keys"] = "120 钥匙";
		dict["300 keys"] = "300 钥匙";
		dict["125000\nCoins"] = "125000\n金币";
		dict["30000\nCoins"] = "30000\n金币";
		dict["1000000\nCoins"] = "1000000\n金币";
		dict["25000 Coins\n+\n25 Keys"] = "25000 金币\n+\n25 钥匙";
		dict["50000 Coins\n+\n30 Lives"] = "50000 金币\n+\n30 条命";
		dict["150000 Coins\n+\n150 keys\n+\n150 Lives"] = "150000 金币\n+\n150 钥匙\n+\n150 条命";
		dict["Would you like to get more "] = "想要更多";
		dict["Would You like to share on Facebook?"] = "要在 Facebook 上分享吗？";
		dict["Your Friends List is Empty..."] = "好友列表为空...";
		dict["No New Messages.."] = "没有新消息...";
		dict["Sorry, Your device is not playing this game adequately for a good gaming experience. "] = "抱歉，您的设备无法流畅运行此游戏。";
		dict["We will try to improve game performance for your device in future updates, \n   Please Check Later."] = "我们将努力在后续更新中优化游戏性能，\n请稍后再试。";
		dict["Thanks for your feedback"] = "感谢您的反馈";
		dict["To           :"] = "收件人：";
		dict["Subject   :"] = "主题：";
		dict["Message :"] = "消息：";
		dict["Tag Your Friends"] = "标记好友";
		dict["3dModelUsageMode : "] = "3D模型使用模式：";
		dict["strTest : "] = "测试：";
		dict["Need <color=yellow>"] = "需要 <color=yellow>";
		dict["* Any game item purchase will remove ads! *"] = "* 购买任意游戏道具即可移除广告！*";
		dict["*  Any game item purchase will remove ads! *"] = "* 购买任意游戏道具即可移除广告！*";
		dict["Attempt"] = "尝试";
		dict["Attempts"] = "尝试次数";
		dict["Ready"] = "就绪";
		dict["Player"] = "玩家";
		dict["Player_"] = "玩家_";
		dict["Chase Score Street Chaser for Testing"] = "追逐分数（测试用）";
		dict["Mission milestone Street Chaser for Testing"] = "任务里程碑（测试用）";
		dict["LevelUp"] = "升级";
		dict["SetLevel"] = "设置关卡";
		dict["quality: "] = "画质：";

		// 前缀匹配（动态拼接：前缀 + 数字/时间）
		prefixDict.Add(new KeyValuePair<string, string>("You will get +1 life in  <b>", "将在 <b>"));
		prefixDict.Add(new KeyValuePair<string, string>("You will get +1 life in <b>", "将在 <b>"));
		prefixDict.Add(new KeyValuePair<string, string>("Quality Level : ", "画质等级："));
	}

	public static string Translate(string text)
	{
		if (string.IsNullOrEmpty(text)) return text;
		string result;
		if (dict.TryGetValue(text, out result))
			return result;
		for (int i = 0; i < prefixDict.Count; i++)
		{
			if (text.StartsWith(prefixDict[i].Key))
				return prefixDict[i].Value + text.Substring(prefixDict[i].Key.Length);
		}
		return text;
	}
}