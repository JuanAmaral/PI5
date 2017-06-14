using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class MenuUpgrades : MonoBehaviour
    {
        public GameObject Player;


        public GameObject ButtonUpgrade;
        public Button Opcao1;
        public Text btn1_text;
        public Button Opcao2;
        public Text btn2_text;
        public Button Opcao3;
        public Text btn3_text;


        public static int levelPlayer;
        public static bool ReadyUpgrade;
        // Use this for initialization
        void Start()
        {
            // ReadyUpgrade = true;
            //levelPlayer = 1;
            //levelPlayer = 2;



            Button btn = Opcao1.GetComponent<Button>();
            btn.onClick.AddListener(Opcao1Click);
            Button btn2 = Opcao2.GetComponent<Button>();
            btn2.onClick.AddListener(Opcao2Click);
            Button btn3 = Opcao3.GetComponent<Button>();
            btn3.onClick.AddListener(Opcao3Click);

        }

        // Update is called once per frame
        void Update()
        {
            if (ReadyUpgrade)
            {
                ButtonUpgrade.SetActive(true);
                if (levelPlayer == 1)
                {
                    btn1_text.text = "Dobra o dano e  dobra a velocidade do tiro";
                    btn2_text.text = "Dois tiros consecutivos";
                    btn3_text.text = "Menor colisor e perde apenas metade de experiencia";
                }
                if (levelPlayer == 2)
                {
                    btn1_text.text = "Dobra velocidade do tiro";
                    btn2_text.text = "Mais um tiro consecutivos";
                    btn3_text.text = "Dobra a velocidade de atack";
                }
            }
            else
            {
                ButtonUpgrade.SetActive(false);
            }

        }
        void Opcao1Click()
        {
            if (levelPlayer == 1)
            {
                //Debug.Log("selecionei 1 opção");
                bullet.speedBullet *= 2;
                Shooting1.DamagePlayer *= 2;
                ReadyUpgrade = false;
            }
            if (levelPlayer == 2)
            {
                bullet.speedBullet *= 2;
                ReadyUpgrade = false;
            }
        }
        void Opcao2Click()
        {
            if (levelPlayer == 1)
            {
               // Debug.Log("selecionei 2 opção");
                Shooting1.TwoBullet = true;
                ReadyUpgrade = false;
            }
            if (levelPlayer == 2)
            {
                if(Shooting1.TwoBullet == false)
                {
                    Shooting1.TwoBullet = true;

                }
                else
                {
                    Shooting1.TreeBullet = true;
                }
                ReadyUpgrade = false;
            }

        }
        void Opcao3Click()
        {
            if (levelPlayer == 1)
            {
                //Debug.Log("selecionei 3 opção");
                Exp.dmgEnemyBullet = 1.3f;
                Exp.dmgEnemyCollider = 0.3f;

                Player.transform.localScale = new Vector3(0.48f, 0.48f, 0.48f);
                ReadyUpgrade = false;
            }
            if (levelPlayer == 2)
            {
                Shooting1.velAtack2 /= 2;
                ReadyUpgrade = false;
            }

        }
    }

}
