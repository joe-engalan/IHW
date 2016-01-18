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
		public void shouldApplyPositiveThrustWhenAccelerating() {

			engine.accelerate(1.0f);

			Assert.That(engine.thrust, Is.EqualTo(10.0f));
		}

		[Test]
		public void shouldApplyNegativeThrushWhenDecelerating() {
			engine.decelerate(1.0f);
			Assert.That(engine.thrust, Is.EqualTo(-10.0f));
		}

		[Test]
		public void shouldNotExceedMaximumThrustWhenAccelerating() {
			engine.accelerate(1000.0f);
			Assert.That(engine.thrust, Is.EqualTo(engine.maxThrust));
		}

		[Test]
		public void shouldNotExceedMaxNegativeThrustWhenDecelerating() {
			engine.decelerate(1000.0f);
			Assert.That(engine.thrust, Is.EqualTo(-engine.maxThrust));
		}

		[Test]
		public void shouldStartWithZeroThrust() {
			Assert.That (engine.thrust, Is.EqualTo(0.0f));
		}

		[Test]
		public void shouldIncrementInitialThrustWhenAccelerating() {
			engine.thrust = 50.0f;
			engine.accelerate(0.5f);

			Assert.That (engine.thrust, Is.EqualTo(55.0f));
		}
	}
}
