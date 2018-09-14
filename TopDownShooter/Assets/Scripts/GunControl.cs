using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour {

    public int fireInTheRole = 0;

    public BulletControl bullet;
    public float bullletSpeed;    

    public Transform firePoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {            
            if (fireInTheRole > 0)
            {                
                BulletControl newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
                newBullet.speed = bullletSpeed;
                fireInTheRole--;
            }
              
	}
}
