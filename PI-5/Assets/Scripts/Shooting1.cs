using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace UnityStandardAssets.CrossPlatformInput
{
    public class Shooting1 : MonoBehaviour
    {
        bool ShootingBool = false;
        public static float DamagePlayer;

        float VelAtack;
        public static float velAtack2;

        public GameObject Bullet;
        public GameObject bulletPosition;

        //atirando 2 balas
        //shooting two bullets
        public GameObject TwoBullet1;
        public GameObject TwoBullet2;
        public GameObject TwobulletPosition1;
        public GameObject TwobulletPosition2;
        public static bool TwoBullet;

        public static bool TreeBullet;

        public GameObject ButtonADS;
        public GameObject SpecialBulletADS;
        public static bool SpecialBullet;

        // Use this for initialization
        void Start()
        {
            velAtack2 = 0.7f;
            //TreeBullet = true;
            //TwoBullet = true;
            DamagePlayer += 10;
            //Button btn = botao.GetComponent<Button>();

        }



        IEnumerator Wait()
        {
            yield return new WaitForSeconds(3.0f);
        }
        //public void StopShoting()
        //{
        //    ShootingBool = false;
        //}
        public void StopShooting()
        {
            ShootingBool = false;

        }
        public void Shooting()
        {
            ShootingBool = true;
        }

        //Shooting = false;

        void Update()
        {
            VelAtack += Time.deltaTime;
            if (SpecialBullet)
            {
                Bullet = SpecialBulletADS;
                ButtonADS.SetActive(false);
            }




            if (VelAtack > velAtack2)
            {




                if (ShootingBool)
                {
                    if (TreeBullet)
                    {

                        Instantiate(TwoBullet1, TwobulletPosition1.transform.position, TwobulletPosition1.transform.rotation);
                        Instantiate(TwoBullet2, TwobulletPosition2.transform.position, TwobulletPosition2.transform.rotation);
                        Instantiate(Bullet, transform.position, transform.rotation);

                    }
                    if (TwoBullet)
                    {
                        Instantiate(TwoBullet1, TwobulletPosition1.transform.position, TwobulletPosition1.transform.rotation);
                        Instantiate(TwoBullet2, TwobulletPosition2.transform.position, TwobulletPosition2.transform.rotation);
                    }
                    else
                    {
                        Instantiate(Bullet, transform.position, transform.rotation);
                    }
                }
                VelAtack = 0;
            }
        }
    }
}
