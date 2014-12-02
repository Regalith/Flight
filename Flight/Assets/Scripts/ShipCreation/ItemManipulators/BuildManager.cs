using UnityEngine;
using System.Collections;

public class BuildManager : MonoBehaviour {

	private Gizmo selected;

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


	public void TurnOnTranslate()
	{
		if(selected != null)
			selected.TurnOnTranslate ();
	}

	public void TurnOnRotate()
	{
		if(selected != null)
			selected.TurnOnRotate ();
	}

	public void Delete()
	{
		if (selected != null)
			selected.Delete ();
	}

	public void SetSelected(Gizmo s)
	{
		selected = s;
	}

	public void ButtonHoverEnter()
	{
		if(selected != null)
			selected.transform.parent.gameObject.GetComponent<MouseSelector> ().ButtonHoverEnter ();
	}
	public void ButtonHoverExit ()
	{
		if(selected != null)
			selected.transform.parent.gameObject.GetComponent<MouseSelector> ().ButtonHoverExit ();
	}

}
