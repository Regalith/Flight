using UnityEngine;
using System.Collections;

public class BuildManager : MonoBehaviour {

	public ItemModifier selected;
	private Gizmo selectedGizmo;
	public bool buttonHovered { get; set; }
	public ShipComponent component;

	private GameObject currentMouseSelection;

	//Here is a private reference only this class can access
	private static BuildManager _instance;
	
	//This is the public reference that other classes will use
	public static BuildManager instance
	{
		get
		{
			//If _instance hasn't been set yet, we grab it from the scene!
			//This will only happen the first time this reference is used.
			if(_instance == null)
				_instance = GameObject.FindObjectOfType<BuildManager>();
			return _instance;
		}
	}

	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			currentMouseSelection = CheckItemMouseOver();
		}
		
		if(Input.GetMouseButtonUp(0) && CheckItemMouseOver() == currentMouseSelection && currentMouseSelection != null)
		{
			SetSelected(currentMouseSelection.GetComponent<ItemModifier>());
		}
		if(selected != null)
		{
			if(Input.GetMouseButtonUp(0) && CheckItemMouseOver() != selected.gameObject && !buttonHovered && currentMouseSelection == null)
			{
				RemoveSelected();
			}
		}
	}

	/// <summary>
	/// Checks whether the cursor is currently on top of this game Object.
	/// </summary>
	/// <returns><c>true</c>, if mouse is object this object, <c>false</c> otherwise.</returns>
	GameObject CheckItemMouseOver()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray,out hit,Mathf.Infinity))
		{
			GameObject parent = DetermineParent(hit.collider.gameObject);
			Collider[] colliders = parent.GetComponentsInChildren<Collider>();

			//If the parent doesnt contain an Item Modifier, return null
			if(parent.GetComponent<ItemModifier>() == null)
				return null;

			//If the parent collider is the collider hit, return true
			if(hit.collider == parent.collider)
				return parent;

			//check if childeren colldiers are hit
			for(int i = 0; i < colliders.Length; i++)
			{
				if(hit.collider == colliders[i])
				{
					return parent;
				}
			}
		}
		return null;
		
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

	/*
	void DisplayInspector()
	{
		switch(component.componentType)
		{
		case ComponentType.Weapon:
			weaponInspector.GetComponent<WeaponInspector>().SetShipComponent(item);
			weaponInspector.GetComponent<WeaponInspector>().SetPath(itemPath);
			weaponInspector.GetComponent<WeaponInspector>().TurnOn();
			activeInspector = weaponInspector;
			break;
		}
	}*/

	public void TurnOnTranslate()
	{
		if(selected != null)
			selectedGizmo.TurnOnTranslate ();
	}

	public void TurnOnRotate()
	{
		if(selected != null)
			selectedGizmo.TurnOnRotate ();
	}

	public void Delete()
	{
		if (selected != null)
			selectedGizmo.Delete ();
	}

	public void SetSelected(ItemModifier s)
	{
		//Deselect a previous selection if there is one;
		if (selected != null)
			RemoveSelected ();

		selected = s;
		selectedGizmo = selected.GetComponent<Gizmo> ();
		selected.enabled = true;
	}

	public void RemoveSelected()
	{
		selected.enabled = false;
		selected = null;
		selectedGizmo = null;

	}
	public void ButtonHoverEnter()
	{
		buttonHovered = true;
	}
	public void ButtonHoverExit ()
	{
		buttonHovered = false;
	}

}
