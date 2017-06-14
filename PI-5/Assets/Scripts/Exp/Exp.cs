using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class Exp : MonoBehaviour
    {

        public float MaxExp = 100f;
        public float CurrentExp = 0f;
        public static bool addExp = false;
        public static float dmgEnemyBullet;
        public static float dmgEnemyCollider;



        public GameObject ExpBar;

        // Use this for initialization
        void Start()
        {
            dmgEnemyBullet = 2.0f;
            dmgEnemyCollider = 0.5f;
        }
        // Update is called once per frame
        void Update()
        {
            if (addExp)
            {
                //Debug.Log("AddExp");
                CurrentExp += 10;
                float calc_Exp = CurrentExp / MaxExp;
                SetHealbar(calc_Exp);
                addExp = false;
            }


            if (PlayerCollider.CollisionEnemy)
            {
                TakeDamage();
                 float calc_Exp = CurrentExp / MaxExp;
                 SetHealbar(calc_Exp);
                PlayerCollider.CollisionEnemy = false;
            }
            if (PlayerCollider.CollisionBulletEnemy)
            {
                TakeBulletDamage();
                 float calc_Exp = CurrentExp / MaxExp;
                 SetHealbar(calc_Exp);
                PlayerCollider.CollisionBulletEnemy = false;
            }
            if (CurrentExp >= 100)
            {
                //Debug.Log("Upgrade");
                CurrentExp = 100;
                MenuUpgrades.levelPlayer += 1;
                MenuUpgrades.ReadyUpgrade = true;
                CurrentExp = 0;
                float calc_Exp = CurrentExp / MaxExp;
                SetHealbar(calc_Exp);
            }

            if (CurrentExp <= 0)
            {
                CurrentExp = 0;
            }
        }
        public void SetHealbar(float MyExp)
        {
            ExpBar.transform.localScale = new Vector3(MyExp, ExpBar.transform.localScale.y, ExpBar.transform.localScale.z);
        }
        void TakeBulletDamage()
        {
            CurrentExp -= dmgEnemyBullet;
        }
        void TakeDamage()
        {
            CurrentExp -= dmgEnemyCollider;
        }
    }

}
