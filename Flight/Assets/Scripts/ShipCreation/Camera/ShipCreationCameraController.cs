using UnityEngine;
using System.Collections;

[RequireComponent (typeof (MouseLook))]

public class ShipCreationCameraController : MonoBehaviour {
	
	public float rotationSpeed;
	public float movementSpeed;

	private MouseLook mLook;
	// Use this for initialization
	void Start () 
	{
		mLook = this.gameObject.GetComponent<MouseLook> ();
		mLook.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		CheckInput ();
	}

	void CheckInput()
	{
		if(Input.GetMouseButtonDown(1))
		{
			mLook.enabled = true;
			Screen.lockCursor = true;
		}
		if(Input.GetMouseButtonUp(1))
		{
			mLook.enabled = false;
			Screen.lockCursor = false;
		}
		if(Input.GetKey(KeyCode.W))
		{
			transform.Translate(0,0,movementSpeed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.A))
		{
			transform.Translate(-movementSpeed * Time.deltaTime,0,0);
		}
		if(Input.GetKey(KeyCode.S))
		{
			transform.Translate(0,0,-movementSpeed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.D))
		{
			transform.Translate(movementSpeed * Time.deltaTime,0,0);
		}
	}
}
