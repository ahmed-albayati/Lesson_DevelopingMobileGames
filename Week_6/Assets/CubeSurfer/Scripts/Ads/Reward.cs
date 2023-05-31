using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;
using System;

public class Reward : MonoBehaviour
{
    private RewardedAd rewardedAd;

    private string adUnitId = "ca-app-pub-3940256099942544/5224354917";  // Replace with your Ad Unit ID

    private void Start()
    {
        LoadRewardedAd();
    }

    private void LoadRewardedAd()
    {
        // Create an empty ad request.
        var adRequest = new AdRequest.Builder().Build();

        // Load the rewarded ad.
        RewardedAd.Load(adUnitId, adRequest, (RewardedAd ad, LoadAdError error) =>
        {
            if (error != null)
            {
                Debug.Log($"Rewarded ad failed to load with error: {error}");
                return;
            }

            rewardedAd = ad;
            RegisterEventHandlers(ad);
            Debug.Log("Rewarded ad loaded.");
        });
    }

    private void RegisterEventHandlers(RewardedAd ad)
    {
        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () =>
        {
            Debug.Log("Rewarded ad was clicked.");
        };

        // Raised when an ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Rewarded ad full screen content opened.");
        };

        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Rewarded ad full screen content closed.");
            // Reload the ad so that we can show another as soon as possible.
            LoadRewardedAd();
        };

        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Rewarded ad failed to open full screen content " +
                           "with error : " + error);
        };
    }

    public void ShowRewardedAd()
    {
        if (rewardedAd != null)
        {
            if (rewardedAd.CanShowAd())
            {
                rewardedAd.Show((GoogleMobileAds.Api.Reward reward) =>
                {
                    // TODO: Reward the user.
                    Debug.Log(String.Format("Rewarded ad rewarded the user. Type: {0}, amount: {1}.", reward.Type, reward.Amount));
                    // the 1 indecate the AdCoin will increce by 1
                    GameManager.Instance.AddCoins((int)1);
                });
            }
            else
            {
                Debug.Log("Reward ad is not ready to be shown.");
            }
        }
        else
        {
            Debug.Log("Reward ad is null.");
        }
    }
}

