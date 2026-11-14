using System.Collections.Generic;

public class IGT_PurchaseItemsData
{
	public string ProductID_GooglePlayStore;

	public string ProductID_IOSAppStore;

	public string ProductTitle;

	public string ProductDescription;

	public string DefaultPrice;

	public string ImageName;

	public string priceNotationImg;

	public int ProductType;

	public int PurchaseType;

	public List<IGT_UpgradeData> pIGT_UpgradeData;

	public int nCurUpgradeState;

	public IGT_PurchaseItemsData(string pID_Android, string pID_Ios, string pTitle, string pDescrip, string pPrice, string sImgName, int prdType, int purType)
	{
		ProductID_GooglePlayStore = pID_Android;
		ProductID_IOSAppStore = pID_Ios;
		ProductTitle = pTitle;
		ProductDescription = pDescrip;
		DefaultPrice = pPrice;
		ImageName = sImgName;
		ProductType = prdType;
		PurchaseType = purType;
	}

	public IGT_PurchaseItemsData(string pTitle, string sImgName, string priceImg, int state, List<IGT_UpgradeData> upgradeData)
	{
		ProductTitle = pTitle;
		ImageName = sImgName;
		priceNotationImg = priceImg;
		nCurUpgradeState = state;
		pIGT_UpgradeData = upgradeData;
	}
}
