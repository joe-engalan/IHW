using UnityEngine;
using System.Collections;

public class ShipSpawner : MonoBehaviour {

	public GameObject shipPrefab;

	[Range(10, 30)]
	public int minShips;

	[Range(10, 30)]
	public int maxShips;

	[Range(0.5f, 10.0f)]
	public float timeBetweenChecks;

	float currentTimeBetweenChecks;

	// Use this for initialization
	void Start () {
		currentTimeBetweenChecks = timeBetweenChecks;
	}
	
	// Update is called once per frame
	void Update () {

		currentTimeBetweenChecks -= Time.deltaTime;
		if (currentTimeBetweenChecks < 0.0f) {
			IHW_Spaceship[] ships = GetComponentsInChildren<IHW_Spaceship> ();
			if (ships.GetLength (0) < minShips) {
				int numShipsToSpawn = maxShips - ships.GetLength (0);
				spawnShips (numShipsToSpawn);
			}
		}
	
	}

	void spawnShips(int numToSpawn) {
		for (int i = 0; i < numToSpawn; i++) {
			GameObject spawnedShip = GameObject.Instantiate (shipPrefab);
			spawnedShip.transform.parent = transform;
		}
	}
}
