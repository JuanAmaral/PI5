using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using admob;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class AdManager : MonoBehaviour
    {

        public static AdManager Instance { set; get; }

        public string bannerId;
        public string videoId;
        // Use this for initialization
        void Start()
        {
           
            Instance = this;
            DontDestroyOnLoad(gameObject);
#if UNITY_EDTOR
#elif UNITY_EDITOR
            Admob.Instance().setTesting(true);
            Admob.Instance().initAdmob(bannerId, videoId);
            Admob.Instance().loadInterstitial();
#endif
            Instance.ShowBanner();
        }

        // Update is called once per frame
        void Update()
        {
            Instance.ShowBanner();
        }
        public void ShowBanner()
        {
#if UNITY_EDTOR
#elif UNITY_ANDROID
            Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.TOP_CENTER, 5);
#endif
        }
        public void ShowVideo()
        {
            #if UNITY_EDTOR
            #elif UNITY_EDITOR
            if (Admob.Instance().isInterstitialReady())
            {
                Admob.Instance().showInterstitial();
            }
#endif
        }
    }

}
