using UnityEngine;
using System.Collections;
using IHW;

public class Ship : MonoBehaviour {

	public Pilot pilot;
	public Vector3 targetPosition;
	public float acceleration = 20.0f;
	public float maxThrust = 100.0f;
	public float maxVelocity = 10.0f;
	public float turnRate = 180.0f;

	// Use this for initialization
	void Start () {
		pilot = new Pilot();
		pilot.engine = new Engine();
		pilot.engine.acceleration = acceleration;
		pilot.engine.maxThrust = maxThrust;
		pilot.heading = new Heading();
		pilot.heading.turnRate = turnRate;
		pilot.maxVelocity = maxVelocity;
	}
	
	// Update is called once per frame
	void Update () {

		if(Vector3.Distance(transform.position, targetPosition) > pilot.engine.thrust) {
			pilot.moveTowards(targetPosition, Time.deltaTime);
			transform.rotation = pilot.heading.heading;
			transform.position = pilot.currentPosition;
		}
	
	}
}
