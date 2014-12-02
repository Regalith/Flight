using UnityEngine;
using System.Collections;

public class ItemModifier : MonoBehaviour {

	private Gizmo gizmo;
	public Material highlightMat;
	private Material defaultMat;



	void Awake()
	{
		defaultMat = this.renderer.material;
		highlightMat = Resources.Load ("Utility/Outlined") as Material;
	}

	// Update is called once per frame
	void Update () 
	{
		CheckInput ();
	}

	void SpawnGizmo()
	{
		GameObject tempGiz = Instantiate(Resources.Load("Prefabs/Gizmo")) as GameObject;
		tempGiz.transform.parent = this.gameObject.transform;
		tempGiz.transform.localPosition = new Vector3 (0, 0, 0);
		gizmo = tempGiz.GetComponent<Gizmo> ();
	}

	void CheckInput()
	{
		if(Input.GetKey(KeyCode.Alpha1))
		{
			gizmo.TurnOnTranslate();

		}
		if(Input.GetKey(KeyCode.Alpha2))
		{
			gizmo.TurnOnRotate();
		}
	}

	void OnEnable()
	{
		if(gizmo == null)
			SpawnGizmo ();
		this.renderer.material = highlightMat;

	}

	void OnDisable ()
	{
		if(gizmo.CheckActive())
		{
			this.enabled = true;
			return;
		}
		Destroy (gizmo.gameObject);
		gizmo = null;
		this.renderer.material = defaultMat;

	}
}
