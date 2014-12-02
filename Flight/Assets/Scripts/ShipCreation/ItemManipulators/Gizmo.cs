using UnityEngine;
using System.Collections;

public class Gizmo : MonoBehaviour {

	private GameObject translate;
	private GameObject rotate;

	void Start()
	{
		translate = transform.Find ("TranslateGizmo").gameObject;
		rotate = transform.Find ("RotateGizmo").gameObject;
	}

	public void TurnOnTranslate()
	{
		translate.SetActive (true);
		rotate.SetActive (false);
	}

	public void TurnOnRotate()
	{
		rotate.SetActive (true);
		translate.SetActive (false);
	}

	public void TurnOffAll()
	{
		translate.SetActive (false);
		rotate.SetActive (false);
	}

	public void Delete()
	{
		Destroy (this.gameObject.transform.parent.gameObject);
	}

	public bool CheckActive()
	{
		if(translate.GetComponent<GizmoController>().CheckSelected() || rotate.GetComponent<GizmoController>().CheckSelected())
			return true;
		else
			return false;
	}
}
