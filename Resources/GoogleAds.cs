using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api; //Google Admobを使うために必要


public class GoogleAds : MonoBehaviour
{
    private BannerView bannerView;

    public void Start()
    {
        MobileAds.Initialize(initStatus => { });

        this.RequestBanner();
    }

    private void RequestBanner()
    {
#if UNITY_ANDROID
        string adUnitId = " ";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
        string adUnitId = "unexpected_platform";
#endif

        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);

        AdRequest request = new AdRequest.Builder().Build();

        this.bannerView.LoadAd(request);

    }
}
