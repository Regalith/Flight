using UnityEngine;
using System.Collections;

[AddComponentMenu("Scripts/Inspector/Inspector")]

public class Inspector : MonoBehaviour {


	protected ShipComponent shipComponent;
	private string shipComponentPath;
	public UIWidget widget;
	public float fadeInSpeed;
	public float fillInSpeed;
	public UILabel componentName;


	private PreviewCamera pCamera;

	void Start()
	{
		pCamera = GameObject.Find ("PreviewCamera").GetComponent<PreviewCamera> ();
	}

	public void StartFade()
	{
		StartCoroutine(FadeIn());
	}
	public void StartFill()
	{
		FillInAttributes ();
	}

	protected virtual void FillInAttributes(){return;}

	protected IEnumerator FadeIn()
	{
		float counter = 0;
		while(counter < 1)
		{

			widget.alpha += .1f * fadeInSpeed * Time.deltaTime;
			counter += .1f * fadeInSpeed * Time.deltaTime;
			yield return null;
		}
	}

	protected IEnumerator FillIn(UIProgressBar bar, float attValue)
	{

		float displacement = attValue - bar.value;
		if(displacement > 0)
		{
			while(displacement > 0)
			{
				float delta = .1f * fillInSpeed * Time.deltaTime;
				bar.value += delta;
				displacement -= delta;
				yield return null;
			}
		}
		else
		{
			while(displacement > 0)
			{
				float delta = .1f * fillInSpeed * Time.deltaTime;
				bar.value -= delta;
				displacement += delta;
				yield return null;
			}
		}


	}

	public void TurnOn()
	{
		StartFade();
		StartFill();
		StartPreview();
	}
	public void TurnOff ()
	{
		EndPreview ();
	}

	public void StartPreview()
	{
		pCamera.SpawnItem (shipComponentPath);
	}
	public void EndPreview()
	{
		pCamera.RemoveItem ();
	}

	public void SetShipComponent(ShipComponent comp){	shipComponent = comp;}

	public ShipComponent GetShipComponent(){	return shipComponent;}

	public void SetPath(string s){ shipComponentPath = s;}
}
