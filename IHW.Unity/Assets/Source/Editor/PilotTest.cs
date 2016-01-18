using UnityEngine;
using NUnit.Framework;
using NSubstitute;

namespace IHW {

	[TestFixture]
	internal class PilotTest {

		private Pilot pilot;
		private IEngine engine;
		private IHeading heading;

		[SetUp]
		public void init() {
			engine = Substitute.For<IEngine>();
			heading = Substitute.For<IHeading>();

			pilot = new Pilot() {
				currentPosition = Vector3.zero,
				engine = engine,
				heading = heading,
				maxVelocity = 10.0f
			};
		}

		[Test]
		public void shouldInitializeVelocityToZero() {
			Assert.That (pilot.velocity, Is.EqualTo(Vector3.zero));
		}

		[Test]
		public void shouldMoveTowardsTargetPosition() {
			Vector3 targetPosition = new Vector3(50.0f, 50.0f, 100.0f);
			Quaternion targetHeading = Quaternion.LookRotation(targetPosition - pilot.currentPosition);
			float dt = 1.0f;

			pilot.moveTowards(targetPosition, dt);

			engine.Received().accelerate(dt);
			heading.Received().rotateTo(targetHeading, dt);

		}

		[Test]
		public void shouldMoveAwayFromTargetPosition() {
			Vector3 targetPosition = new Vector3(50.0f, 50.0f, 100.0f);
			Quaternion targetHeading = Quaternion.LookRotation(pilot.currentPosition - targetPosition);
			float dt = 1.0f;

			pilot.moveAwayFrom(targetPosition, dt);

			engine.Received().accelerate(dt);
			heading.Received().rotateTo(targetHeading, dt);
		}

		[Test]
		public void shouldIncreaseVelocityWhenMovingTowards() {
			engine.thrust.Returns(1.0f);
			pilot.heading.heading = Quaternion.LookRotation(Vector3.forward);

			pilot.moveTowards(Vector3.forward * 10.0f, 1.0f);

			Assert.That(pilot.velocity, Is.EqualTo(Vector3.forward));
		}

		[Test]
		public void shouldAccumulateVelocityWhenMovingTowards() {
			engine.thrust.Returns(1.0f, 2.0f);
			pilot.heading.heading = Quaternion.LookRotation(Vector3.forward);
			Vector3 targetPosition = Vector3.forward * 10.0f;
			
			pilot.moveTowards(targetPosition, 1.0f);
			pilot.moveTowards(targetPosition, 1.0f);

			Assert.That(pilot.velocity, Is.EqualTo(Vector3.forward * 3.0f));

		}

		[Test]
		public void shouldUpdatePositionWhenMovingTowards() {
			engine.thrust.Returns(1.0f);
			pilot.heading.heading = Quaternion.LookRotation(Vector3.forward);
			Vector3 targetPosition = Vector3.forward * 10.0f;
			
			pilot.moveTowards(targetPosition, 1.0f);

			Assert.That(pilot.currentPosition, Is.EqualTo(Vector3.forward));

		}

		[Test]
		public void shouldNotExceedMaxVelocity() {
			engine.thrust.Returns(1000.0f);
			pilot.heading.heading = Quaternion.LookRotation(Vector3.forward);
			Vector3 targetPosition = Vector3.forward * 10000.0f;

			pilot.moveTowards(targetPosition, 1.0f);

			Assert.That (pilot.velocity.magnitude, Is.LessThanOrEqualTo(pilot.maxVelocity));
		}
	}
}