using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class EnemyCollider : MonoBehaviour
    {
        private float life = 100;
        public GameObject Expp;
        bool enableExp = false;
        public bool DmgToPlayer;
        // Use this for initialization
        void Start()
        {
            DmgToPlayer = false;
        }

        // Update is called once per frame
        void Update()
        {
            //morte do inimigo
            //enemy dead
            if (life <= 0)
            {
                Destroy(gameObject);
            }

        }
        //instanciar experiência
        //create experience
        void InvokeExp()
        {
            Instantiate(Expp, transform.position, Quaternion.identity);

        }
        void OnTriggerStay2D(Collider2D col)
        {
            if (col.tag == "Player")
            {
                //Debug.Log("Colidiu");
                if (DmgToPlayer)
                {
                   // Debug.Log("deu dano");
                    PlayerCollider.CollisionEnemy = true;
                }

                //Debug.Log("Colidiu");
            }
        }
        void OnTriggerEnter2D(Collider2D col)
        {

            if (col.tag == "BulletPlayer")
            {
                //recebendo dano do tiro
                //receiving damage with the shot
                life -= Shooting1.DamagePlayer;
                //criando experiencia com a colisao
                //creating experience with the collider
                if (life == 80)
                {
                    Debug.Log("10 de xp");
                    InvokeExp();

                }
                if (life == 60)
                {
                    Debug.Log("20 de xp");
                    InvokeExp();
                }
                if (life == 20)
                {
                    Debug.Log("30 de xp");
                    InvokeExp();
                }
                //Debug.Log("ColidiuBulet");
            }
        }
    }

}
