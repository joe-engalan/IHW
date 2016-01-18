using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace IHW.Tests
{
	[Binding]
	public class TestSteps
	{
		Queue<int> operands = new Queue<int>();
		
		[Given ("I have entered (.*) into the calculator")]
		public void GivenIHaveEnteredSomethingIntoTheCalculator (int number)
		{
			operands.Enqueue (number);
		}

		[When ("I press add")]
		public void WhenIPressAdd ()
		{
			int op1 = operands.Dequeue ();
			int op2 = operands.Dequeue ();
			operands.Enqueue (op1 + op2);
		}

		[Then ("the result should be (.*) on the screen")]
		public void ThenTheResultShouldBe (int result)
		{
			Assert.That (operands.Peek (), Is.EqualTo (result));
		}
	}
}
        
