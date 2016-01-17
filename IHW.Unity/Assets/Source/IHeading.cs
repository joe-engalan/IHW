using UnityEngine;

namespace IHW {

	public interface IHeading {

		float turnRate { get; set; }
		Quaternion heading { get; set; }

		void rotateTo(Quaternion targetHeading, float dt);
	}
}