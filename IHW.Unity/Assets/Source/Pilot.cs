using UnityEngine;

namespace IHW {

	public class Pilot : IPilot {

		public Vector3 currentPosition { get; set; }
		public Vector3 velocity { get; set; }
		public float maxVelocity { get; set; }
		public IEngine engine { get; set ; }
		public IHeading heading { get; set; }

		public Pilot() {
			velocity = Vector3.zero;
		}
		
		public void moveTowards(Vector3 targetPosition, float dt) {
			Quaternion targetHeading = Quaternion.LookRotation(targetPosition - currentPosition);
			heading.rotateTo(targetHeading, dt);
			engine.accelerate(dt);

			updateVelocity();
			updatePosition();

		}

		public void moveAwayFrom(Vector3 targetPosition, float dt) {
			Quaternion targetHeading = Quaternion.LookRotation(currentPosition - targetPosition);
			heading.rotateTo(targetHeading, dt);
			engine.accelerate(dt);
			
			updateVelocity();
			updatePosition();

		}

		void updateVelocity() {
			Vector3 facingVector = heading.heading * Vector3.forward;
			
			velocity += facingVector.normalized * engine.thrust;

			if(velocity.magnitude > maxVelocity) {
				velocity = velocity.normalized * maxVelocity;
			}
		}

		void updatePosition() {
			currentPosition += velocity;
		}

	}
}