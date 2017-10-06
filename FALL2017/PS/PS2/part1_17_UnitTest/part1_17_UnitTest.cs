using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PS2_Methods;

namespace part1_17_UnitTest
{
	[TestClass]
	public class part1_17_UnitTest
	{
		private const double CatalansConstant = 0.915965594177219015054603514932384110774;

		[TestMethod]
		public void part1_17_Method1()
		{
			var eps = 0.000000001;

			var result = Methods.CatalansConstant(eps);

			Assert.IsTrue(Math.Abs(result - CatalansConstant) < eps);
		}

		[TestMethod]
		public void part1_17_Method2()
		{
			var eps = 0.000000000001;

			var result = Methods.CatalansConstant(eps);

			Assert.IsTrue(Math.Abs(result - CatalansConstant) < eps);
		}
		[TestMethod]
		public void part1_17_Method3()
		{
			var eps = 0.000000000000001;

			var result = Methods.CatalansConstant(eps);

			Assert.IsTrue(Math.Abs(result - CatalansConstant) < eps);
		}
	}
}

