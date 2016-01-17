using UnityEngine;

namespace IHW {

	public interface IPilot {

		Vector3 currentPosition { get; set; }
		Vector3 velocity { get; set; }
		float maxVelocity { get; set; }
		IEngine engine { get; set ; }
		IHeading heading { get; set; }

		void moveTowards(Vector3 taretPosition, float dt);
		void moveAwayFrom(Vector3 targetPosition, float dt);
	}
}