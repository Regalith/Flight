using UnityEngine;
using System.Collections;

public class RotateGizmo : GizmoController {

	protected override void ModifyObject()
	{

		if(selected == null)
			return;

		switch(selected.axis)
		{
		case "x":
			parent.transform.parent.transform.Rotate(determineCameraOrientation(0) *translateSpeed *  mListener.GetMouseDeltaY() * Time.deltaTime,0,0);
			break;
		case "y":
			parent.transform.parent.transform.Rotate(0,-translateSpeed * mListener.GetMouseDeltaX() * Time.deltaTime,0);
			break;
		case "z":
			parent.transform.parent.transform.Rotate(0,0,determineCameraOrientation(1) * translateSpeed * mListener.GetMouseDeltaY() * Time.deltaTime);
			break;
		}
	}
}
