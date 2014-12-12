using UnityEngine;
using System.Collections;

public enum WeaponType {Cannon, MachineGun};

[AddComponentMenu("Scripts/ShipComponents/Weapons/Weapon")]
public class Weapon : ShipComponent 
{
	public WeaponType weaponType;
	public int damage = 0;
	public int range = 0;
	public int rateOfFire = 0;
	public int health = 0;
	public int armor = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
