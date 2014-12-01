using UnityEngine;
using System.Collections;

public class TranslateGizmo :GizmoController {

	protected override void ModifyObject()
	{
		if(selected == null)
			return;
		
		switch(selected.axis)
		{
		case "x":
			parent.transform.parent.transform.Translate(translateSpeed * determineCameraOrientation(0) * mListener.GetMouseDeltaX() * Time.deltaTime,0,0);
			break;
		case "y":
			parent.transform.parent.transform.Translate(0,translateSpeed * mListener.GetMouseDeltaY() * Time.deltaTime,0);
			break;
		case "z":
			parent.transform.parent.transform.Translate(0,0,translateSpeed * determineCameraOrientation(1) * mListener.GetMouseDeltaX() * Time.deltaTime);
			break;
		}
	}
}
