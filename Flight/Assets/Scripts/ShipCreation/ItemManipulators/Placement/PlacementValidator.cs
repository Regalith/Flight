using UnityEngine;
using System.Collections;

public class PlacementValidator : MonoBehaviour {

	public PlacementNode[] nodes;
	private GameObject parent;
	private ItemModifier parentModifier;


	// Use this for initialization
	void Start () {
		parent = DetermineParent (this.gameObject);
		parentModifier = parent.GetComponent<ItemModifier> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		UpdateValidityColor ();
	}

	void UpdateValidityColor()
	{
		if (ValidPlacement ())
			parentModifier.ChangeMaterialColors (parentModifier.GetDefaultMaterial ());
		else
			parentModifier.ChangeMaterialColors (parentModifier.GetHighlightMaterialIncorrect());
	}



	public bool ValidPlacement()
	{	
		return ValidBasePlacement() && ValidComponentPlacement();
	}

	private bool ValidComponentPlacement()
	{
		return parent.GetComponent<OverlapValidator>().overLap;
	}

	public bool ValidBasePlacement()
	{	
		int cornersCorrect = 0;
		foreach(PlacementNode n in nodes)
		{
			if(n.Valid())
				cornersCorrect++;
		}
		if(cornersCorrect == 4)
			return true;
		else
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
