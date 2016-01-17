using NUnit.Framework;
using UnityEngine;

namespace IHW {

	[TestFixture]
	[Category("Core Tests")]
	internal class EngineTest {

		private Engine engine;

		[SetUp]
		public void setup() {
			engine = new Engine();
			engine.acceleration = 10.0f;
			engine.maxThrust = 100.0f;
		}

		[Test]
		public void accelerates() {

			engine.accelerate(1.0f);

			Assert.That(engine.thrust, Is.EqualTo(10.0f));
		}

		[Test]
		public void decelerates() {
			engine.decelerate(1.0f);
			Assert.That(engine.thrust, Is.EqualTo(-10.0f));
		}

		[Test]
		public void clampsAcceleration() {
			engine.accelerate(1000.0f);
			Assert.That(engine.thrust, Is.EqualTo(engine.maxThrust));
		}

		[Test]
		public void clampsDecleration() {
			engine.decelerate(1000.0f);
			Assert.That(engine.thrust, Is.EqualTo(-engine.maxThrust));
		}

		[Test]
		public void initialThrustIsZero() {
			Assert.That (engine.thrust, Is.EqualTo(0.0f));
		}

		[Test]
		public void initialThrustIsAddedTo() {
			engine.thrust = 50.0f;
			engine.accelerate(0.5f);

			Assert.That (engine.thrust, Is.EqualTo(55.0f));
		}
	}
}
