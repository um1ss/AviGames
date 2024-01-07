using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
using UnityEngine;

public class AppodealManager : MonoBehaviour, IRewardedVideoAdListener
{
    [SerializeField] private bool testingMode;

    private const string APP_KEY = "b03561a905873083e067b357b3a96a1a31c40b017a94873c";

    private void Awake()
    {
        EventBus.Instance.OnStartCheckAds += ShowInterAds;
    }

    private void OnDestroy()
    {
        EventBus.Instance.OnStartCheckAds -= ShowInterAds;
    }

    private void Start()
    {
        Initialized();
    }

    private void ShowInterAds()
    {
        if (Appodeal.canShow(Appodeal.INTERSTITIAL))
        {
            Appodeal.show(Appodeal.INTERSTITIAL);
        }
    }

    private void Initialized()
    {
        Appodeal.setTesting(testingMode);

        Appodeal.disableLocationPermissionCheck();

        Appodeal.muteVideosIfCallsMuted(true);

        Appodeal.initialize(APP_KEY, Appodeal.INTERSTITIAL | Appodeal.REWARDED_VIDEO);

        Appodeal.setRewardedVideoCallbacks(this);
    }

    public void onRewardedVideoLoaded(bool precache)
    {
        Debug.Log("Video loaded");
    }

    public void onRewardedVideoFailedToLoad()
    {
        Debug.Log("Video failed");
    }

    public void onRewardedVideoShowFailed()
    {
        Debug.Log("Video show failed");
    }

    public void onRewardedVideoShown()
    {
        Debug.Log("Video shown");
    }

    public void onRewardedVideoFinished(double amount, string name)
    {
        Debug.Log("Video finished");
    }

    public void onRewardedVideoClosed(bool finished)
    {
        Debug.Log("Video closed");
    }

    public void onRewardedVideoExpired()
    {
        Debug.Log("Video expired");
    }

    public void onRewardedVideoClicked()
    {
        Debug.Log("Video Clicked");
    }
}
