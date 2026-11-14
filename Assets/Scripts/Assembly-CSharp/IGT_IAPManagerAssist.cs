using UnityEngine;

public class IGT_IAPManagerAssist
{
	private IGT_IAPManager pIGT_IAPManager;

	public IGT_IAPManagerAssist(string googlePlayConfigKey)
	{
		pIGT_IAPManager = new IGT_IAPManager(googlePlayConfigKey);
	}

	public void AddProduct(string productID_Android, string productID_IOS, int productType)
	{
		pIGT_IAPManager.AddProduct(productID_Android, productID_IOS, productType);
	}

	public void restorePurchasesManually()
	{
		pIGT_IAPManager.restorePurchases();
	}

	public void InitializeBuilder()
	{
		pIGT_IAPManager.InitializeBuilder();
	}

	public bool isInitialisedSuccess()
	{
		return pIGT_IAPManager.isInitialisedSuccess();
	}

	public bool isAnyPurchaseInProgress()
	{
		return pIGT_IAPManager.isAnyPurchaseInProgress();
	}

	public void startPurchase(string productId)
	{
		Debug.Log("====assist  : product id: " + productId);
		pIGT_IAPManager.OnPurchaseClicked(productId);
	}

	public void setPurchaseListner(IGT_PurchaseFlowListner listner)
	{
		pIGT_IAPManager.setPurchaseListner(listner);
	}

	public string GetPriceforEachProduct(string productID)
	{
		return PlayerPrefs.GetString(productID);
	}
}
