using UnityEngine;
using System.Collections;

[RequireComponent (typeof (MouseListener))]

public class ShipCreationCameraController : MonoBehaviour {
	
	public float rotationSpeed;
	public float movementSpeed;

	private MouseListener mListener;

	// Use this for initialization
	void Start () 
	{
		mListener = this.gameObject.GetComponent<MouseListener> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		CheckInput ();
	}

	void CheckInput()
	{
		if(Input.GetMouseButton(1))
		{
			Debug.Log ("ROTATE");
			transform.Rotate(-mListener.GetMouseDeltaY() * rotationSpeed * Time.deltaTime,mListener.GetMouseDeltaX() * rotationSpeed * Time.deltaTime,0);
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
