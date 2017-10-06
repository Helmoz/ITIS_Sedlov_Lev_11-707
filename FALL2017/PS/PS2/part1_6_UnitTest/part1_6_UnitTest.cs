using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PS2_Methods;

namespace part1_6_UnitTest
{
	[TestClass]
	public class part1_6_UnitTest
	{
		[TestMethod]
		public void part1_6_Method1()
		{
			var x = 0.1;

			var eps = 0.00000001;

			var result = Methods.SummaArctg(x, eps);

			Assert.IsTrue(result - Math.Abs(Math.Tan(x)) < eps);
		}
		[TestMethod]
		public void part1_6_Method2()
		{
			var x = 0.5;

			var eps = 0.00000001;

			var result = Methods.SummaArctg(x, eps);

			Assert.IsTrue(result - Math.Abs(Math.Tan(x)) < eps);
		}
		[TestMethod]
		public void part1_6_Method3()
		{
			var x = 0.99;

			var eps = 0.00000001;

			var result = Methods.SummaArctg(x, eps);

			Assert.IsTrue(result - Math.Abs(Math.Tan(x)) < eps);
		}
		[TestMethod]
		public void part1_6_Method4()
		{
			var x = 1;

			var eps = 0.000000001;

			var result = Methods.SummaArctg(x, eps);

			Assert.IsTrue(result - Math.Abs(Math.Tan(x)) < eps);
		}
	}
}