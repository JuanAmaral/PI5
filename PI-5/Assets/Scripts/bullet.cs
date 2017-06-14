using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet: MonoBehaviour {
    public GameObject PartcCollisionBullet;
    float timer;
    public static float  speedBullet = 0.4f;
     Rigidbody2D rb;




    // Use this for initialization
    void Start () {
        //speedBullet = 8;
        rb = GetComponent<Rigidbody2D>();
        

    }
	
	// Update is called once per frame
	void Update () {
        //Vector2 position = transform.position;
        //position = new Vector2(position.x, position.y + speedBullet * Time.deltaTime);
        //transform.position = position;

      
        timer += 1.0F * Time.deltaTime;
        
        rb.AddForce(transform.up * speedBullet);
        if (timer >= 1)
        {
            GameObject.Destroy(gameObject);
        }



        //Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        //if(transform.position.y >= max.y)
        //{
        //    Destroy(gameObject);
        //}




    }

        void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            
            Instantiate(PartcCollisionBullet, transform.position, Quaternion.identity);
            //Destroy(PartcCollisionBullet);
            //Debug.Log("Particulaaa");
            Destroy(gameObject);
            
        }
        if (col.tag == "EnemyBullet")
        {

            Instantiate(PartcCollisionBullet, transform.position, Quaternion.identity);
            //Destroy(PartcCollisionBullet);
            //Debug.Log("Particulaaa");
            Destroy(gameObject);

        }

    }
}
