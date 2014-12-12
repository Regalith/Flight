using UnityEngine;
using System.Collections;

public class PreviewCamera : MonoBehaviour {

	public GameObject spawnPoint;
	private GameObject item;
	public int rotateSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(item != null)
			RotateItem ();
	}

	public void SpawnItem(string path)
	{
		item = (GameObject)Instantiate (Resources.Load (path) as GameObject, spawnPoint.transform.position, spawnPoint.transform.rotation);
		item.layer = 9;
		Transform[] children = item.GetComponentsInChildren<Transform> ();
		foreach(Transform child in children)
		{
			child.gameObject.layer = 9;
		}
	}
	public void RemoveItem()
	{
		Destroy (item);
	}

	private void RotateItem()
	{
		item.transform.Rotate (0, rotateSpeed * Time.deltaTime, 0);
	}
	
}
