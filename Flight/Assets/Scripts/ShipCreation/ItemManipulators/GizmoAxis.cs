using UnityEngine;
using System.Collections;

public class GizmoAxis : MonoBehaviour {

	//Material variables
	public Material highlightMaterial;
	private Material defaultMaterial;
	public string axis;


	bool selected= false;
	bool hovered = false;

	private int layerMask;

	// Use this for initialization
	void Start () 
	{
		defaultMaterial = this.renderer.material;

		//Generate LayerMask
		layerMask = 1 << 8;

	}

	void Update()
	{
		if(!selected)
			CheckMouseOver ();
	}

	void CheckMouseOver()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray,out hit,Mathf.Infinity,layerMask))
		{
			if(hit.collider == this.gameObject.collider || hit.collider == this.gameObject.transform.GetComponentInChildren<Collider>())
			{
				this.renderer.material = highlightMaterial;
				hovered = true;
			}
		}
		else
		{
			this.renderer.material = defaultMaterial;
			hovered = false;
		}
	}

	public void Reset()
	{
		this.renderer.material = defaultMaterial;
		selected = false;
		hovered = false;
	}

	//Getters and Setters

	public bool GetSelected()
	{
		return selected;
	}

	public void SetSelected(bool b)
	{
		selected = b;
	}

	public bool GetHovered()
	{
		return hovered;
	}
	
	public void SetHovered(bool b)
	{
		hovered = b;
	}
}
