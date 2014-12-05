using UnityEngine;
using System.Collections;

public class ItemModifier : MonoBehaviour {

	private Gizmo gizmo;
	public Material highlightMat;
	private Material defaultMat;



	void Awake()
	{
		defaultMat = this.renderer.material;
		highlightMat = Resources.Load ("Utility/OutlinedRed") as Material;
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
		tempGiz.transform.rotation = this.gameObject.transform.rotation;
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

		this.renderer.material = highlightMat;
		Transform[] allChildren = this.GetComponentsInChildren<Transform>();
		foreach (Transform child in allChildren) 
		{
			if(child.tag != "Gizmo" && child.tag != "Placement")
				child.renderer.material = highlightMat;	
		}
		if(gizmo == null)
		{
			SpawnGizmo ();
			BuildManager.instance.SetSelected (gizmo);
			
		}

	}

	void OnDisable ()
	{
		if(gizmo.CheckActive())
		{
			this.enabled = true;
		}
		else
		{
			Destroy (gizmo.gameObject);
			gizmo = null;
			this.renderer.material = defaultMat;
			Transform[] allChildren = this.GetComponentsInChildren<Transform>();
			foreach (Transform child in allChildren) 
			{
				if(child.tag != "Gizmo" && child.tag != "Placement")
					child.renderer.material = defaultMat;	
			}
		}

	}
}
