using GoogleMobileAds.Api;
using UnityEngine;

public class Interstitial : MonoBehaviour
{
    // These ad units are configured to always serve test ads.
#if UNITY_ANDROID
    private string _adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
    private string _adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
    private string _adUnitId = "unused";
#endif

    private InterstitialAd interstitialAd;

    public void ShowAd()
    {
        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            interstitialAd.Show();
        }
        else
        {
            Debug.LogError("Interstitial ad not ready to be shown.");
        }
    }

    void Start()
    {
        LoadInterstitialAd();
    }

    public void LoadInterstitialAd()
    {
        // Clean up the old ad before loading a new one.
        if (interstitialAd != null)
        {
            interstitialAd.OnAdFullScreenContentClosed -= HandleOnAdClosed;
            interstitialAd.Destroy();
            interstitialAd = null;
        }

        Debug.Log("Loading the interstitial ad.");

        // Create our request used to load the ad.
        var adRequest = new AdRequest.Builder().AddKeyword("unity-admob-sample").Build();

        // Send the request to load the ad.
        InterstitialAd.Load(_adUnitId, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                if (error != null)
                {
                    Debug.LogError("Interstitial ad failed to load an ad with error : " + error);
                    return;
                }

                Debug.Log("Interstitial ad loaded with response : " + ad.GetResponseInfo());
                interstitialAd = ad;

                // Set up listener for when the ad is closed.
                interstitialAd.OnAdFullScreenContentClosed += HandleOnAdClosed;
            });
    }

    private void HandleOnAdClosed()
    {
        // Reload the interstitial ad when it's closed.
        LoadInterstitialAd();
    }

    void OnDestroy()
    {
        if (interstitialAd != null)
        {
            interstitialAd.OnAdFullScreenContentClosed -= HandleOnAdClosed;
            interstitialAd.Destroy();
        }
    }
}
