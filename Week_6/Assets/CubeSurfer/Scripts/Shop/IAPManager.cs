using System;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour, IStoreListener
{
    private IStoreController controller; // The Unity Purchasing system.
    private IExtensionProvider extensions; // The store-specific Purchasing subsystems.

    public const string item2Id = "2"; // Your item id here.

    void Start()
    {
        InitializePurchasing();
    }

    private bool IsInitialized
    {
        get { return controller != null && extensions != null; }
    }

    public void InitializePurchasing()
    {
        if (IsInitialized) return;

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        builder.AddProduct(item2Id, ProductType.Consumable);

        UnityPurchasing.Initialize(this, builder);
    }

    public void BuyProductID(string productId)
    {
        // If the stores are not yet initialized, we can't buy anything,
        // so we return
        if (IsInitialized)
        {
            // If the product has a valid ID
            Product product = controller.products.WithID(productId);

            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                // Buy the product, expect a response either through ProcessPurchase or OnPurchaseFailed asynchronously.
                controller.InitiatePurchase(product);
            }
            else
            {
                // Otherwise, report the product look-up failure situation  
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        else
        {
            // Otherwise, report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or retrying initiailization.
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("OnInitialized: Completed!");

        this.controller = controller;
        this.extensions = extensions;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.LogError("OnInitializeFailed InitializationFailureReason:" + error);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
    {
        if (string.Equals(e.purchasedProduct.definition.id, item2Id, StringComparison.Ordinal))
        {
            Debug.Log("You've just bought item: " + e.purchasedProduct.definition.id);
            GameManager.Instance.AddCoins(100);
            Debug.Log("Purchase Completed");
        }
        else
        {
            Debug.Log("Purchase Failed: Unrecognized product: " + e.purchasedProduct.definition.id);
        }

        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log("Failed Purchase: FAIL. Product: " + product.definition.storeSpecificId + ", Reason: " + failureReason);
    }
}
