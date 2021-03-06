﻿using UnityEngine;
using NUnit.Framework;

namespace IHW.Core {

	[TestFixture]
	internal class HeadingTest {

		Heading heading;

		[SetUp]
		public void init() {
			heading = new Heading();
			heading.turnRate = 1.0f;
		}

		[Test]
		public void shouldInitializeHeadingToQuaternionIdentity() {
			Assert.That(heading.heading, Is.EqualTo(Quaternion.identity));
		}

		[Test]
		public void shouldBeAbleToInitializeHeading() {
			Quaternion expected = Quaternion.LookRotation(Vector3.up);

			heading.heading = expected;

			Assert.That (heading.heading, Is.EqualTo(expected));
		}

		[Test]
		public void shouldRotateTowardsTheNewHeading() {
			Quaternion newHeading = Quaternion.LookRotation(Vector3.down);

			heading.heading = Quaternion.Euler(Vector3.up);
			heading.rotateTo(newHeading, 180.0f);

			Assert.That(heading.heading, Is.EqualTo(newHeading));
		}
	}

}
