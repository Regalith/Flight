using UnityEngine;
using System.Collections;

public class Gizmo : MonoBehaviour {

	private GameObject translate;
	private GameObject rotate;

	private GameObject buildCam;
	private float buildCamDistance;

	public float minScale;
	public float maxScale;

	public float minDistance;
	public float maxDistance;
	//private Vector3 currentScale;


	void Start()
	{
		translate = transform.Find ("TranslateGizmo").gameObject;
		rotate = transform.Find ("RotateGizmo").gameObject;
		buildCam = GameObject.FindGameObjectWithTag("MainCamera");
	}

	void Update()
	{
		ResizeGizmo();
	}


	private void ResizeGizmo()
	{
		float tempDistance = Vector3.Distance(this.transform.position, buildCam.transform.position);

		//Exit function if no change in distance between camera and gizmo
		if(tempDistance == buildCamDistance)
			return;
		else
			buildCamDistance = Mathf.Clamp(tempDistance,minDistance,maxDistance);


		Vector3 tempScale = this.transform.localScale;

		tempScale.x = Mathf.Clamp(buildCamDistance,minScale, maxScale);
		tempScale.y = Mathf.Clamp(buildCamDistance,minScale, maxScale);
		tempScale.z = Mathf.Clamp(buildCamDistance,minScale, maxScale);

		this.transform.localScale = tempScale;

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
