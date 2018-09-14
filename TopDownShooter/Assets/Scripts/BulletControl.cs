using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {

    public float speed;
	public float lifetime = 1.0f;

	// Use this for initialization
	void Start (){
		Destroy(this.gameObject, lifetime * 5);
	}
	
	// Update is called once per frame
	void Update (){
        transform.Translate(Vector3.forward * speed * Time.deltaTime);		
	}

	private void OnCollisionEnter(Collision collision)
	{
		Destroy(this.gameObject);
	}
}
