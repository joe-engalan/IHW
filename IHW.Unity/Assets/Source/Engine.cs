using UnityEngine;
using System.Collections;

namespace IHW {

	public class Engine : IEngine {

		public float thrust { get; set; }
		public float acceleration { get; set; }
		public float maxThrust { get; set; }

		public void accelerate(float dt) {
			applyThrust(acceleration, dt);
		}

		public void decelerate(float dt) {
			applyThrust(-acceleration, dt);
		}

		void applyThrust(float accel, float dt) {
			thrust += accel * dt;
			clampThrust();
		}

		void clampThrust() {
			thrust = Mathf.Clamp(thrust, -maxThrust, maxThrust);
		}


	}
}