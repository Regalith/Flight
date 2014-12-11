using UnityEngine;
using System.Collections;

public class MouseSelector : MonoBehaviour {

	public MonoBehaviour script;
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

		if((Input.GetMouseButtonUp(0) && !CheckMouseOver()) && !BuildManager.instance.buttonHovered && !currentSelected)
		{
			script.enabled = false;
		}
	}
	/// <summary>
	/// Checks whether the cursor is currently on top of this game Object.
	/// </summary>
	/// <returns><c>true</c>, if mouse is object this object, <c>false</c> otherwise.</returns>
	bool CheckMouseOver()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray,out hit,Mathf.Infinity))
		{
			GameObject parent = DetermineParent(this.gameObject);
			Collider[] colliders = parent.GetComponentsInChildren<Collider>();

			//If the parent collider is the collider hit, return true
			if(hit.collider == parent.collider)
				return true;

			for(int i = 0; i < colliders.Length; i++)
			{
				if(hit.collider == colliders[i])
				{
					return true;
				}
			}
		}
		else
		{
			return false;
		}
		
		return false;
		
	}

	/// <summary>
	/// Determines the parent of any gameobject passed in
	/// </summary>
	/// <returns>The parent.</returns>
	/// <param name="child">Child hit by raycast.</param>
	GameObject DetermineParent(GameObject child)
	{
		GameObject potentialParent = child;

		while(potentialParent.transform.parent != null)
		{
			potentialParent = potentialParent.transform.parent.gameObject;

		}
		return potentialParent;
	}

}
