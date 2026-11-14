using UnityEngine;
using UnityEngine.Purchasing;

public class IGT_IAPManager : IStoreListener
{
	private IStoreController controller;

	private IExtensionProvider extensions;

	private ConfigurationBuilder builder;

	private bool bInitiallised;

	private bool bPurchaseInProgress;

	public IGT_PurchaseFlowListner pPurchaseFlowListner;

	public IGT_IAPManager(string googlePlayConfigKey)
	{
		StandardPurchasingModule standardPurchasingModule = StandardPurchasingModule.Instance();
		standardPurchasingModule.useFakeStoreUIMode = FakeStoreUIMode.StandardUser;
		builder = ConfigurationBuilder.Instance(standardPurchasingModule);
		bInitiallised = false;
		bPurchaseInProgress = false;
	}

	public void setPurchaseListner(IGT_PurchaseFlowListner listner)
	{
		pPurchaseFlowListner = listner;
	}

	public void AddProduct(string productID_Android, string productID_IOS, int productType)
	{
		switch (productType)
		{
		case 0:
			builder.AddProduct(productID_IOS, ProductType.Consumable, new IDs
			{
				{ productID_Android, "GooglePlay" },
				{ productID_IOS, "AppleAppStore" }
			});
			break;
		case 1:
			builder.AddProduct(productID_IOS, ProductType.NonConsumable, new IDs
			{
				{ productID_Android, "GooglePlay" },
				{ productID_IOS, "AppleAppStore" }
			});
			break;
		case 2:
			builder.AddProduct(productID_IOS, ProductType.Subscription, new IDs
			{
				{ productID_Android, "GooglePlay" },
				{ productID_IOS, "AppleAppStore" }
			});
			break;
		}
	}

	public void InitializeBuilder()
	{
		UnityPurchasing.Initialize(this, builder);
	}

	public bool isInitialisedSuccess()
	{
		return bInitiallised;
	}

	public bool isAnyPurchaseInProgress()
	{
		return bPurchaseInProgress;
	}

	public void OnPurchaseClicked(string productId)
	{
		Debug.Log("=======onpurchase clicked " + productId);
		Debug.Log("=======onpurchase clicked :  is avail : " + controller.products.WithID(productId).availableToPurchase + "  def: " + controller.products.WithID(productId).definition);
		if (controller.products.WithID(productId).availableToPurchase)
		{
			bPurchaseInProgress = true;
			controller.InitiatePurchase(productId);
			pPurchaseFlowListner.PurchaseStarted(productId);
		}
	}

	public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
	{
		this.controller = controller;
		this.extensions = extensions;
		Product[] all = controller.products.all;
		foreach (Product product in all)
		{
			if (product.availableToPurchase)
			{
				PlayerPrefs.SetString(product.definition.storeSpecificId, product.metadata.localizedPriceString);
			}
		}
		PlayerPrefs.Save();
		bInitiallised = true;
		extensions.GetExtension<IAppleExtensions>().RestoreTransactions(delegate(bool result)
		{
			if (!result)
			{
			}
		});
	}

	public void OnInitializeFailed(InitializationFailureReason error)
	{
		OnInitializeFailed(error, string.Empty);
	}

	public void OnInitializeFailed(InitializationFailureReason error, string message)
	{
		Debug.Log("======Billing failed to initialize!");
		switch (error)
		{
		case InitializationFailureReason.AppNotKnown:
			Debug.LogError("=======Is your App correctly uploaded on the relevant publisher console?");
			break;
		case InitializationFailureReason.PurchasingUnavailable:
			Debug.Log("==========Billing disabled!");
			break;
		case InitializationFailureReason.NoProductsAvailable:
			Debug.Log("============No products available for purchase!");
			break;
		}
		bInitiallised = false;
	}

	public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
	{
		bPurchaseInProgress = false;
		pPurchaseFlowListner.PurchaseSuccess(e.purchasedProduct.definition.id);
		return PurchaseProcessingResult.Complete;
	}

	public void OnPurchaseFailed(Product i, PurchaseFailureReason p)
	{
		bPurchaseInProgress = false;
		Debug.Log("=======Purchase failed: " + i.definition.id);
		Debug.Log(p);
		switch (p)
		{
		case PurchaseFailureReason.PurchasingUnavailable:
			pPurchaseFlowListner.PurchaseFailed(i.definition.id, "======PurchasingUnavailable");
			break;
		case PurchaseFailureReason.ExistingPurchasePending:
			pPurchaseFlowListner.PurchaseFailed(i.definition.id, "========ExistingPurchasePending");
			break;
		case PurchaseFailureReason.PaymentDeclined:
			pPurchaseFlowListner.PurchaseFailed(i.definition.id, "=========PaymentDeclined");
			break;
		case PurchaseFailureReason.ProductUnavailable:
			pPurchaseFlowListner.PurchaseFailed(i.definition.id, "===========ProductUnavailable");
			break;
		case PurchaseFailureReason.SignatureInvalid:
			pPurchaseFlowListner.PurchaseFailed(i.definition.id, "===========SignatureInvalid");
			break;
		case PurchaseFailureReason.UserCancelled:
			pPurchaseFlowListner.PurchaseFailed(i.definition.id, "============UserCancelled");
			break;
		default:
			pPurchaseFlowListner.PurchaseFailed(i.definition.id, "===========Unknown");
			break;
		}
	}

	public void restorePurchases()
	{
		extensions.GetExtension<IAppleExtensions>().RestoreTransactions(delegate(bool result)
		{
			if (!result)
			{
			}
		});
	}

	private void OnTransactionsRestored(bool success)
	{
		Debug.Log("=========Transactions restored." + success);
	}

	private void OnDeferred(Product item)
	{
		Debug.Log("========Purchase deferred: " + item.definition.id);
	}
}
