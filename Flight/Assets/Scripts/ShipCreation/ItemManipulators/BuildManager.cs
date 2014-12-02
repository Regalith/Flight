using UnityEngine;
using System.Collections;

public class BuildManager : MonoBehaviour {

	private Gizmo selected;
	static BuildManager instance;

	static BuildManager GetInstance()
	{
		if(instance == null)
		{
			instance = new BuildManager();
		}
		
		return instance;
	}

	public void TurnOnTranslate()
	{

	}

}
