using UnityEngine;
using System.Collections;

public class PlacementNode : MonoBehaviour {

	bool correctlyPlaced = false;

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "PlacementZone")
		{
			correctlyPlaced = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.tag == "PlacementZone")
			correctlyPlaced = false;
	}

	public bool Valid()
	{
		return correctlyPlaced;
	}
}
