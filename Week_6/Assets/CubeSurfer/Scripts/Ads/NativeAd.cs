using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class NativeAd : MonoBehaviour
{
    // Ad settings
    private AdLoader adLoader;
    private string adUnitId = "ca-app-pub-3940256099942544/2247696110";  // Replace with your Ad Unit ID
    private GoogleMobileAds.Api.NativeAd nativeAd;
    private bool adLoaded = false;
    private bool adClicked = false;
    private bool adDisplaying = false;  // New flag for ad displaying
    private bool isMoving = true;  // New flag for moving status
    public GameObject cubeBlueVariantAd1;
    public GameObject cubeBlueVariantAd2;
    public GameObject cubeBlueVariantAd3;
    public GameObject cubeBlueVariantAd4;
    public GameObject clickTextObject; // Reference to your 3D text object
    public GameObject holderObject;



    // Moving settings
    public float moveSpeed = 0.7f;
    private Vector3 moveDirection = Vector3.forward;

    // Object settings
    public GameObject[] adObjects;

    private void Start()
    {
        // Initialize the Google Mobile Ads SDK
        MobileAds.Initialize(initStatus => { });
        foreach (GameObject adObject in adObjects)
        {
            if (adObject != null)
            {
                Debug.Log("Activating object: " + adObject.name);
                adObject.SetActive(false);
            }
            else
            {
                Debug.Log("Found null object in adObjects array");
            }
        }

        // Load the ad after a delay of 2 seconds
        Invoke("LoadAd", 2f);
    }

    private void Update()
    {
        if (adClicked && isMoving)
        {
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }

    private void LoadAd()
    {
        adLoader = new AdLoader.Builder(adUnitId)
            .ForNativeAd()
            .Build();

        adLoader.OnNativeAdLoaded += HandleNativeAdLoaded;
        adLoader.OnAdFailedToLoad += HandleNativeAdFailedToLoad;

        adLoader.LoadAd(new AdRequest.Builder().Build());
    }

    private void HandleNativeAdLoaded(object sender, NativeAdEventArgs args)
    {
        nativeAd = args.nativeAd;
        adLoaded = true;
        adDisplaying = true;  // Set the ad displaying flag


        // If registration of an ad asset is unsuccessful, impressions and clicks on the corresponding native ad won't be recognized.
        if (!nativeAd.RegisterIconImageGameObject(gameObject))
        {
            Debug.LogError("Failed to register the icon ad asset.");
        }
        Debug.Log("Native Ad has loaded successfully");
    }
    private void HandleNativeAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        string message = args.LoadAdError.GetMessage();
        Debug.LogError("Native ad failed to load: " + message);
        adDisplaying = false;  // Set the ad displaying flag
    }

    private void OnMouseDown()
    {
        clickTextObject.SetActive(false); // Disable the 3D text object
        holderObject.SetActive(true); // Enable the Holder object
        if (!adLoaded)
        {
            Debug.LogError("Ad was clicked but it's not loaded yet.");
            adDisplaying = true;  // Set the ad displaying flag
        }

        adClicked = true;
        Debug.Log("Thanks for interacting.");

        foreach (GameObject adObject in adObjects)
        {
            if (adObject != null)
            {
                Debug.Log("Activating object: " + adObject.name);
                adObject.SetActive(true);
            }
            else
            {
                Debug.Log("Found null object in adObjects array");
            }
        }
        // Start the timer
        StartCoroutine(StopMovingAfterSeconds(10));
    }
    IEnumerator StopMovingAfterSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        isMoving = false;  // Set the moving flag to false
    }


}
