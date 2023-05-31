using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }

    public event Action OnCoinsChanged = delegate { };

    private int coins;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadCoins();
    }

    public int GetCoins()
    {
        return coins;
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        SaveCoins();
        OnCoinsChanged.Invoke();
    }

    private void LoadCoins()
    {
        coins = PlayerPrefs.GetInt("coins", 0);
    }

    private void SaveCoins()
    {
        PlayerPrefs.SetInt("coins", coins);
    }
}

