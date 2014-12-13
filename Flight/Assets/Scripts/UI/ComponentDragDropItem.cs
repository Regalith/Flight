using UnityEngine;
using System.Collections;

[RequireComponent (typeof (ItemButton))]

public class ComponentDragDropItem : UIDragDropItem
{
	/// <summary>
	/// Prefab object that will be instantiated on the DragDropSurface if it receives the OnDrop event.
	/// </summary>
	
	private string itemPath;
	public float autoPlacementDistance = 25f;
	/// <summary>
	/// Drop a 3D game object onto the surface.
	/// </summary>
	

	protected override void OnDragDropRelease (GameObject surface)
	{
		if (surface != null)
		{				
			Debug.Log (itemPath);
			SpawnItemAtPoint(DeterminePlacementPosition());
			// Destroy this icon as it's no longer needed
			NGUITools.Destroy(gameObject);
			return;
		}
	}

	private Vector3 DeterminePlacementPosition()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray,out hit,Mathf.Infinity))
		{

			//If the parent collider is the collider hit, return true
			return hit.point;
		}
		else
		{
			return ray.GetPoint(autoPlacementDistance);
		}
	}

	private void SpawnItemAtPoint(Vector3 position)
	{
		GameObject tempItem = (GameObject)Instantiate ((GameObject)Resources.Load (itemPath), position, Quaternion.identity);
		BuildManager.instance.SetSelected (tempItem.GetComponent<ItemModifier> ());
	}

	public void setItemPath(string path)
	{
		itemPath = path;
	}
}
