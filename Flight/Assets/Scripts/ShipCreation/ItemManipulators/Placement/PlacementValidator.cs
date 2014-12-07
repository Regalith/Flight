using UnityEngine;
using System.Collections;

public class PlacementValidator : MonoBehaviour {

	public PlacementNode[] nodes;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool ValidPlacement()
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
}
