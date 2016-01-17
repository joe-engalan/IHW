using UnityEngine;

namespace IHW {

	public class Heading : IHeading {

		public float turnRate { get; set; }
		public Quaternion heading { get; set; }

		public Heading() {
			heading = Quaternion.identity;
		}

		public void rotateTo(Quaternion targetHeading, float dt) {
			heading = Quaternion.RotateTowards(heading, targetHeading, turnRate * dt);
		}
	}
}