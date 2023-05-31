/**using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

[RequireComponent(typeof(IAPButton))]
public class BuyButtonIAP : MonoBehaviour
{
    private IAPButton iapButton;

    private void Start()
    {
        iapButton = GetComponent<IAPButton>();

        if (iapButton == null)
        {
            Debug.LogError("IAPButton component not found.");
            return;
        }

        // Add the event listeners
        iapButton.onPurchaseComplete += HandlePurchaseComplete;
        iapButton.onPurchaseFailed += HandlePurchaseFailed;
    }

    private void HandlePurchaseComplete(Product product)
    {
        Debug.Log("Purchase Completed: " + product.definition.id);

        if (product.definition.id == iapButton.productId)
        {
            GameManager.Instance.AddCoins(100);
            // Handle what you want to do after a successful purchase here
        }
    }

    private void HandlePurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("Purchase Failed: " + product.definition.id + ", reason: " + reason);

        // Handle what you want to do after a failed purchase here
    }
}**/
