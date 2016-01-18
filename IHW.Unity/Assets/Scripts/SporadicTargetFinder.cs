using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SU_CameraFollow))]
public class SporadicTargetFinder : MonoBehaviour {

	public GameObject shipRootObject;
	public GameObject target;

	SU_CameraFollow cameraFollowScript;

	// Use this for initialization
	void Start () {
		cameraFollowScript = GetComponent<SU_CameraFollow> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (cameraFollowScript.target == null) {
			IHW_Spaceship[] ships = shipRootObject.GetComponentsInChildren<IHW_Spaceship> ();
			if (ships.GetLength(0) > 0) {
				int newShipIndex = Random.Range (0, ships.GetLength (0));
				IHW_Spaceship newTarget = ships [newShipIndex];
				cameraFollowScript.target = newTarget.transform;
			}
		}
	}
}
