using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {


	public GameObject target;
	public Vector3 offset = new Vector3(0, 0, 0);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (target)
		{
			
			// Always Update to Exactly Targets Position + Offset
			transform.position = new Vector3(
				target.transform.position.x + offset.x,
				transform.position.y,
				target.transform.position.z + offset.z);
		}
	}


}
