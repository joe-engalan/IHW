using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Ship))]
public class SporadicMovement : MonoBehaviour {

	public float maxDistanceToNextPoint = 1000.0f;
	public float minDistanceToNextPoint = 200.0f;
	public float timeTilChangePosition = 3.0f;
	public Vector3 targetPosition = Vector3.zero;
	public bool forcePositionChange = false;
	public Ship ship;
    
	float currentTimeTilChangePosition;

	// Use this for initialization
	void Start () {
		currentTimeTilChangePosition = 0;

		if(ship == null) {
			ship = gameObject.GetComponent<Ship>();
		}
	}
	
	// Update is called once per frame
	void Update () {

		currentTimeTilChangePosition -= Time.deltaTime;
        if(currentTimeTilChangePosition <= 0 || forcePositionChange) {
			changePosition();

			if(forcePositionChange) {
				currentTimeTilChangePosition = timeTilChangePosition;
				forcePositionChange = false;
                
			} else {
				currentTimeTilChangePosition = currentTimeTilChangePosition + timeTilChangePosition;
                
			}
		}

		ship.targetPosition = targetPosition;
	}

	void changePosition() {
		Vector3 offset = Random.onUnitSphere * Random.Range(minDistanceToNextPoint, maxDistanceToNextPoint);
		targetPosition = offset;
	}
}
