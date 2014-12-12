using UnityEngine;
using System.Collections;

[AddComponentMenu("Scripts/Inspector/WeaponInspector")]
public class WeaponInspector : Inspector 
{

	public UIProgressBar damage;
	public UIProgressBar range;
	public UIProgressBar rateOfFire;
	public UIProgressBar health;
	public UIProgressBar armor;


	

	// Update is called once per frame
	void Update () {
	
	}

	override protected void FillInAttributes()
	{
		Weapon wep = (Weapon)shipComponent;
		componentName.text = shipComponent.componentName;
		StartCoroutine (FillIn (damage, (float)wep.damage/100));
		StartCoroutine (FillIn (range, (float)wep.range/100));
		StartCoroutine (FillIn (rateOfFire, (float)wep.rateOfFire/100));
		StartCoroutine (FillIn (health, (float)wep.health/100));
		StartCoroutine (FillIn (armor, (float)wep.armor/100));
	}
}
