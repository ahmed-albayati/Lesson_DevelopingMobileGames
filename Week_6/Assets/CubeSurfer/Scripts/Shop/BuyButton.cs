using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    public int itemPrice = 1;
    public string itemID;
    public Button buyButton;
    public Button equipButton;

    private bool isItemBought = false;

    private void Start()
    {
        // Get item state from PlayerPrefs
        isItemBought = PlayerPrefs.GetInt("IsItemBought", 0) == 1;

        // Update button states
        buyButton.gameObject.SetActive(!isItemBought);
        equipButton.gameObject.SetActive(isItemBought);
    }

    public void OnBuyButtonClick()
    {
        int playerCoins = PlayerPrefs.GetInt("PlayerCoins", 0);

        if (GameManager.Instance.Coins >= itemPrice)
        {
            Debug.Log("Buy button clicked. Item ID: " + itemID + ", Price: " + itemPrice);
            GameManager.Instance.Coins -= itemPrice;
            PlayerPrefs.SetInt("PlayerCoins", playerCoins);
            isItemBought = true;
            PlayerPrefs.SetInt("IsItemBought", 1);

            buyButton.gameObject.SetActive(false);
            equipButton.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Not enough coins to buy item.");
        }
    }

}
