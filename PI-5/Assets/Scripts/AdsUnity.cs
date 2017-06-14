using System.Collections;
using System.Collections.Generic;
using UnityEngine.Advertisements;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class AdsUnity : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void ShowAd()
        {
            if (Advertisement.IsReady())
            {
                Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdResult });
            }
        }
        private void HandleAdResult(ShowResult result)
        {
            switch (result)
            {
                case ShowResult.Finished:
                    Debug.Log("bola especial");
                    Shooting1.SpecialBullet = true;
                    break;
                case ShowResult.Skipped:
                    Debug.Log("pulou propaganda");
                    break;
            }
        }
    }

}
