using UnityEngine;
using System.Collections;

public class MouseListener : MonoBehaviour {

	private float mouseDeltaX;
	private float mouseDeltaY;

	private Vector2 previousMousePosition;


	// Use this for initialization
	void Start () {
		//initilize mouse position
		previousMousePosition = Input.mousePosition;
	}
	
	// Update is called once per frame
	void Update () 
	{
		GenerateMouseDelta ();
	}

	void GenerateMouseDelta()
	{
		mouseDeltaX = Input.mousePosition.x - previousMousePosition.x;
		mouseDeltaY = Input.mousePosition.y - previousMousePosition.y;
		previousMousePosition = Input.mousePosition;
	}

	public float GetMouseDeltaX()
	{
		return mouseDeltaX;
	}

	public float GetMouseDeltaY()
	{
		return mouseDeltaY;
	}
}
