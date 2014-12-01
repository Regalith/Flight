﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof (MouseListener))]

public class TranslateGizmoController : MonoBehaviour {

	public TranslateGizmoAxis[] axis;
	public float translateSpeed;
	private GameObject parent;
	private TranslateGizmoAxis selected;
	private MouseListener mListener;
	private GameObject mainCamera;

	// Use this for initialization
	void Start () 
	{
		parent = this.gameObject.transform.parent.gameObject;
		mListener = this.gameObject.GetComponent<MouseListener> ();
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			FindSelected();
		}

		if(Input.GetMouseButton(0))
		{
			TranslateObject();
		}
		if(Input.GetMouseButtonUp(0))
		{
			Reset();
		}
	}

	/// <summary>
	/// Translates the object based on the selected Axis.
	/// </summary>
	void TranslateObject()
	{
		if(selected == null)
			return;

		switch(selected.axis)
		{
		case "x":
			parent.transform.Translate(translateSpeed * determineCameraOrientation(0) * mListener.GetMouseDeltaX() * Time.deltaTime,0,0);
			break;
		case "y":
			parent.transform.Translate(0,translateSpeed * mListener.GetMouseDeltaY() * Time.deltaTime,0);
			break;
		case "z":
			parent.transform.Translate(0,0,translateSpeed * determineCameraOrientation(1) * mListener.GetMouseDeltaX() * Time.deltaTime);
			break;
		}
	}

	/// <summary>
	/// Finds the selected axis which is being hovered over.
	/// </summary>
	void FindSelected()
	{
		foreach (TranslateGizmoAxis t in axis)
		{
			if(t.GetHovered())
			{
				selected = t;
				t.SetSelected(true);
				break;
			}
		}
	}
	/// <summary>
	/// Reset the Gizmo Controller.
	/// </summary>
	void Reset()
	{
		//reset selected to null
		selected = null;

		//reset attributes for each axis
		foreach (TranslateGizmoAxis t in axis)
		{
			t.Reset();
		}
	}


	int determineCameraOrientation(int axis)
	{
		int direction = 0;
		switch(axis)
		{
		case 0:
			if(mainCamera.transform.position.z < this.transform.position.z)
				direction = 1;
			else
				direction = -1;
			break;
		case 1:
			if(mainCamera.transform.position.x > this.transform.position.x)
				direction = 1;
			else
				direction = -1;
			break;
		}
		return direction;
	}


}
