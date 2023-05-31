using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinDisplay : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    private void OnEnable()
    {
        GameManager.Instance.OnCoinsChanged += UpdateDisplay;
        UpdateDisplay();
    }

    private void OnDisable()
    {
        GameManager.Instance.OnCoinsChanged -= UpdateDisplay;
    }

    private void UpdateDisplay()
    {
        coinText.text = GameManager.Instance.Coins.ToString();
    }
}
