using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PS2_Methods;

namespace part2_6_UnitTest
{
	[TestClass]
	public class part2_6_UnitTest
	{
		[TestMethod]
		public void part2_6_Method1()
		{
			var eps = 0.000000001;

			var result = Methods.Pi(eps);

			Assert.IsTrue(result - Math.Abs(Math.PI) < eps);
		}
		[TestMethod]
		public void part2_6_Method2()
		{
			var eps = 0.000000000001;

			var result = Methods.Pi(eps);

			Assert.IsTrue(result - Math.Abs(Math.PI) < eps);
		}
		[TestMethod]
		public void part2_6_Method3()
		{
			var eps = 0.000000000000001;

			var result = Methods.Pi(eps);

			Assert.IsTrue(result - Math.Abs(Math.PI) < eps);
		}
	}
}
