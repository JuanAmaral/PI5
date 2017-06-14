using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class PlayerCollider : MonoBehaviour
    {

        
        public static bool CollisionBulletEnemy;
        public static bool CollisionEnemy;

     
        void OnTriggerEnter2D(Collider2D col)
        {
            //colidindo com a bala
            if (col.tag == "BulletEnemy")
            {
                CollisionBulletEnemy = true;
                //Debug.Log("Colidiu");
            }
            //colidindo com a experiencia
            //collider with experience
            if (col.tag == "Exp")
            {
                Exp.addExp = true;
                //Debug.Log("pegou xp");
            }
        }
    }

}
