using UnityEngine;
using GoogleMobileAds.Api;

public class GoogleMobileAdsInitializer : MonoBehaviour
{
    void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });
    }
}
