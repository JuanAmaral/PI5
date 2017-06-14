using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {
    bool ShootingBool = false;


    float VelAtack;

    public GameObject Bullet;
    public GameObject bulletPosition;
    // Use this for initialization
    void Start () {
        ShootingBool = true;

    }
	
	// Update is called once per frame
	void Update () {
        VelAtack += Time.deltaTime;
        if (VelAtack > 0.5)
        {
            if (ShootingBool)
            {
                Instantiate(Bullet, transform.position, transform.rotation);
            }
            VelAtack = 0;
        }

    }
}
