using UnityEngine;
using System.Collections;

[RequireComponent (typeof (MouseListener))]

public class GizmoController : MonoBehaviour {

	public GizmoAxis[] axis;
	public float translateSpeed;
	protected GameObject parent;
	protected GizmoAxis selected;
	protected MouseListener mListener;
	protected GameObject mainCamera;

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
			ModifyObject();
		}
		if(Input.GetMouseButtonUp(0))
		{
			Reset();
		}
	}

	/// <summary>
	/// Modifies the object based on the selected Axis.
	/// </summary>
	protected virtual void ModifyObject(){return;}
	

	/// <summary>
	/// Finds the selected axis which is being hovered over.
	/// </summary>
	protected void FindSelected()
	{
		foreach (GizmoAxis t in axis)
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
		foreach (GizmoAxis t in axis)
		{
			t.Reset();
		}
	}

	/// <summary>
	/// Determines the camera orientation.
	/// </summary>
	/// <returns>Modifier direction</returns>
	/// <param name="axis">Axis being modified</param>
	protected int determineCameraOrientation(int axis)
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
