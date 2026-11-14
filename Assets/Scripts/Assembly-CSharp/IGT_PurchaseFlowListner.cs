public interface IGT_PurchaseFlowListner
{
	void PurchaseStarted(string productID);

	void PurchaseSuccess(string productID);

	void PurchaseFailed(string productID, string purchaseFailureReason);
}
