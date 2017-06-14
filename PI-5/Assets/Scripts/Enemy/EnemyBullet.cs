using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    public GameObject PartcCollisionBullet;
    float timer;
    float speedBullet = 0.6f;
    Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        //speedBullet = 8;
        rb = GetComponent<Rigidbody2D>();


    }
    // Update is called once per frame
    void Update()
    {
        //Vector2 position = transform.position;
        //position = new Vector2(position.x, position.y + speedBullet * Time.deltaTime);
        //transform.position = position;

        timer += 1.0F * Time.deltaTime;

        rb.AddForce(transform.up * speedBullet);
        if (timer >= 1)
        {
            GameObject.Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Instantiate(PartcCollisionBullet, transform.position, Quaternion.identity);
            //Destroy(PartcCollisionBullet);
            //Debug.Log("Particulaaa");
            Destroy(gameObject);

        }
        if (col.tag == "BulletPlayer")
        {
            Instantiate(PartcCollisionBullet, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }
}