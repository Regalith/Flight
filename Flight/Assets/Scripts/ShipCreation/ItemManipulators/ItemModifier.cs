using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Gizmo))]

public class ItemModifier : MonoBehaviour {

	private Gizmo gizmo;
	private Material highlightMatIncorrect;
	private Material highlightMatCorrect;
	private Material defaultMat;
	private PlacementValidator pValidator;
	public bool baseComponent = false;

	void Awake()
	{
		defaultMat = this.renderer.material;
		highlightMatIncorrect = Resources.Load ("Utility/OutlinedRed") as Material;
		highlightMatCorrect = Resources.Load ("Utility/OutlinedWhite") as Material;

		if(!baseComponent)
			pValidator = transform.Find ("PlacementValidator").GetComponent<PlacementValidator>();
	}

	// Update is called once per frame
	void Update () 
	{
		CheckInput ();

		if(!baseComponent)
			CheckValidPlacement ();
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
	

	void CheckValidPlacement()
	{
		if (pValidator.ValidPlacement ())
		{
			ChangeMaterialColors(highlightMatCorrect);
		}
		else
		{
			ChangeMaterialColors(highlightMatIncorrect);
		}
	}

	void OnEnable()
	{

		this.renderer.material = highlightMatIncorrect;
		ChangeMaterialColors (highlightMatIncorrect);
		SpawnGizmo ();
		BuildManager.instance.selectedGizmo = gizmo;
	}

	void OnDisable ()
	{

		Destroy (gizmo.gameObject);
		gizmo = null;
		ChangeMaterialColors(defaultMat);

	}
	public PlacementValidator GetPlacementValidator()
	{
		return pValidator;
	}

	public void ChangeMaterialColors(Material mat)
	{
		this.renderer.material = mat;
		Transform[] allChildren = this.GetComponentsInChildren<Transform>();
		foreach (Transform child in allChildren) 
		{
			if(child.tag != "Gizmo" && child.tag != "PlacementValidator")
				child.renderer.material = mat;	
		}
	}

	public Material GetHighlightMaterialIncorrect()
	{
		return highlightMatIncorrect;
	}
	public Material GetHighlightMaterialCorrect()
	{
		return highlightMatCorrect;
	}
	public Material GetDefaultMaterial()
	{
		return defaultMat;
	}
}
