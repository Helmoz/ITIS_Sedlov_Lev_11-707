using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PS2_Methods;

namespace part4_4_UnitTest
{
	[TestClass]
	public class part4_4_UnitTest
	{
		static Func<double, double> Function = x => -1 * Math.Sin(Math.Tan(x));
		static double a = 2, b = 3;
		static int n = 1000000;

		[TestMethod]
		public void part4_4_Method1()
		{
			var result = Methods.IntegrateLRect(a, b, n, Function);

			Assert.AreEqual(0.647199, Math.Round(result, 6));
		}
		[TestMethod]
		public void part4_4_Method2()
		{
			var result = Methods.IntegrateRRect(a, b, n, Function);

			Assert.AreEqual(0.647199, Math.Round(result, 6));
		}
		[TestMethod]
		public void part4_4_Method3()
		{
			var result = Methods.IntegrateTrap(a, b, n, Function);

			Assert.AreEqual(0.647199, Math.Round(result, 6));
		}
		[TestMethod]
		public void part4_4_Method4()
		{
			var result = Methods.IntegrateSimp(a, b, n, Function);

			Assert.AreEqual(0.647199, Math.Round(result, 6));
		}
		[TestMethod]
		public void part4_4_Method5()
		{
			var result = Methods.IntegrateMCarlo(a, b, n, Function);

			Assert.AreEqual(0.6471, Math.Round(result, 4));
		}

	}
}
