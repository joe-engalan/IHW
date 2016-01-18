using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Ship))]
public class SporadicFiring : MonoBehaviour
{
	[Range(0.25f, 5.0f)]
	public float cooldownTime = 0.5f;

	float currentCooldown;
	Ship ship;

	// Use this for initialization
	void Start ()
	{
		ship = GetComponent<Ship> ();

		currentCooldown = cooldownTime;
	
	}
	
	// Update is called once per frame
	void Update ()
	{

		currentCooldown -= Time.deltaTime;
		ship.canFire = currentCooldown <= 0.0f;
		if (currentCooldown < 0.0f) {
			currentCooldown += cooldownTime;
		}
			
	
	}
}

