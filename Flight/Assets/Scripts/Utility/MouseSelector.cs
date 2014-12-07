using UnityEngine;
using System.Collections;

public class MouseSelector : MonoBehaviour {

	public MonoBehaviour script;
	private bool button = false;
	private bool currentSelected;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			currentSelected = CheckMouseOver();
		}

		if(Input.GetMouseButtonUp(0) && CheckMouseOver() && currentSelected)
		{
			script.enabled = true;
		}

		if((Input.GetMouseButtonUp(0) && !CheckMouseOver()) && !button)
		{
			script.enabled = false;
		}
	}

	bool CheckMouseOver()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray,out hit,Mathf.Infinity))
		{
			if(hit.collider == this.gameObject.collider || hit.collider == this.gameObject.transform.GetComponentInChildren<Collider>())
			{
				return true;
			}
		}
		else
		{
			return false;
		}
		
		return false;
		
	}

	public void ButtonHoverEnter()
	{
		button = true;
		Debug.Log ("HOVERED");
	}
	public void ButtonHoverExit ()
	{
		button = false;
	}

}
