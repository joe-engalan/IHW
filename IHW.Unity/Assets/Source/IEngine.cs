﻿using UnityEngine;
using System.Collections;

namespace IHW {

	public interface IEngine  {

		float thrust { get; set; }
		float acceleration { get; set; }
		float maxThrust { get; set; }

		void accelerate(float dt);
		void decelerate(float dt);
	}

}