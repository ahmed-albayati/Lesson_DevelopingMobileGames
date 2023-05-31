using UnityEngine;

public class PurchaseCompleted : MonoBehaviour
{
    public void OnPurchaseCompleted()
    {
        GameManager.Instance.AddCoins(100); // Or use the AdCoins if you want to add coins that way
        Debug.Log("Purchase Completed: Added 100 coins to player.");
    }
}
