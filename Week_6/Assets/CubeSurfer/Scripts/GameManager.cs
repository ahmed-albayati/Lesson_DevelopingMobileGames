using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton pattern to easily access the GameManager from anywhere
    public static GameManager Instance { get; private set; }

    // Use a property to automatically read and write coins to PlayerPrefs
    public int Coins
    {
        get { return PlayerPrefs.GetInt("Coins", 0); }
        set
        {
            PlayerPrefs.SetInt("Coins", value);
            OnCoinsChanged.Invoke();
        }
    }

    public event Action OnCoinsChanged = delegate { };

    private void Awake()
    {
        // Enforce singleton pattern (there should only ever be one GameManager)
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Don't destroy GameManager when loading new scenes
        }
    }

    public void AddCoins(int amount)
    {
        Coins += amount;
    }
}
