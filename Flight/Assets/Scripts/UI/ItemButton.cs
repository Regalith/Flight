using UnityEngine;
using System.Collections;


[RequireComponent (typeof (ComponentDragDropItem))]

public class ItemButton : MonoBehaviour {

	public string itemPath;
	private ShipComponent item;

	private GameObject weaponInspector;
	private GameObject activeInspector;

	// Use this for initialization
	void Start () 
	{
		GameObject tempItem = Resources.Load (itemPath) as GameObject;
		Debug.Log (tempItem.name);
		item = tempItem.GetComponent<ShipComponent> ();
		weaponInspector = FindInspectors ("WeaponInspector");
		this.gameObject.GetComponent<ComponentDragDropItem> ().setItemPath (itemPath);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void DisplayInspector()
	{
		switch(item.componentType)
		{
		case ComponentType.Weapon:
			//weaponInspector.SetActive(true);
			weaponInspector.GetComponent<WeaponInspector>().SetShipComponent(item);
			weaponInspector.GetComponent<WeaponInspector>().SetPath(itemPath);
			weaponInspector.GetComponent<WeaponInspector>().TurnOn();
			activeInspector = weaponInspector;
			break;
		}
	}

	void HideInspector()
	{
		//activeInspector.SetActive (false);
		activeInspector.GetComponent<Inspector>().TurnOff ();
		activeInspector.GetComponent<UIWidget> ().alpha = 0;

	}


	private GameObject FindInspectors(string name)
	{
		GameObject[] inspectors = GameObject.FindGameObjectsWithTag ("Inspector");
		for(int i = 0; i < inspectors.Length; i++)
		{
			if(inspectors[i].name == name)
				return inspectors[i];
		}
		return null;
	}

	void OnHover(bool isOver)
	{
		if (isOver)
			DisplayInspector ();
		else
			HideInspector();
	}

}
