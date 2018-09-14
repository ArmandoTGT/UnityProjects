using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody myRigidbody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera mainCamera;

    public GunControl theGun;

	public bool isFragmentComplete = false;
	public bool isKey = false;
	private int numKey = 0;
	private int numFrags = 0;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		walk();
		changeTheLook();
		shooting();
    }

    private void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }

	void walk()
	{
		moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
		moveVelocity = moveInput * moveSpeed;
	}

	void shooting()
	{
		if (Input.GetMouseButtonDown(0))
		{
			theGun.fireInTheRole++;
		}
        /*
		if (Input.GetMouseButtonUp(0))
		{
			theGun.isFiring = false;
		}
        */
	}

	void changeTheLook()
	{
		Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
		Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
		float rayLength;

		if (groundPlane.Raycast(cameraRay, out rayLength))
		{
			Vector3 pointToLook = cameraRay.GetPoint(rayLength);
			transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
		}
	}

	
		
	
	 void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Key") {
			isKey = true;
			numKey++;
			if(numKey == 0)
			{
				isKey = false;
			}
		}
		if (collision.gameObject.tag == "Fragment") {
			numFrags++;
			//ver quantos frags são nescessarios pra ficar completo
		}
		if (collision.gameObject.tag == "Enimy") {
			//Morre
		}
		if (collision.gameObject.tag == "Door") {
			numKey--;
			if (numKey == 0)
			{
				isKey = false;
			}
		}

	}
}
