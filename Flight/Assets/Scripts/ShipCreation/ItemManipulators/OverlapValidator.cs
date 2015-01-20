using UnityEngine;
using System.Collections;

public class OverlapValidator : MonoBehaviour {

	public bool overLap { get; set; }
	
	void OnTriggerEnter(Collider other)
	{
		overLap = true;
	}
	
	void OnTriggerExit(Collider other)
	{
		overLap = false;
	}
}
