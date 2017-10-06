using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PS2_Methods;

namespace part4_10_UnitTest
{
	[TestClass]
	public class part4_10_UnitTest
	{
		static Func<double, double> Function = x => Math.Pow(Math.Cos(Math.Sqrt(x)), 2);
		static double a = 0, b = 4;
		static int n = 1000000;
		[TestMethod]
		public void part4_10_Method1()
		{
			var result = Methods.IntegrateLRect(a, b, n, Function);

			Assert.AreEqual(0.82979, Math.Round(result, 5));
		}
		[TestMethod]
		public void part4_10_Method2()
		{
			var result = Methods.IntegrateRRect(a, b, n, Function);

			Assert.AreEqual(0.82978, Math.Round(result, 5));
		}
		[TestMethod]
		public void part4_10_Method3()
		{
			var result = Methods.IntegrateTrap(a, b, n, Function);

			Assert.AreEqual(0.82979, Math.Round(result, 5));
		}
		[TestMethod]
		public void part4_10_Method4()
		{
			var result = Methods.IntegrateSimp(a, b, n, Function);

			Assert.AreEqual(0.82979, Math.Round(result, 5));
		}
		[TestMethod]
		public void part4_10_Method5()
		{
			var result = Methods.IntegrateMCarlo(a, b, n, Function);

			Assert.AreEqual(0.82979, Math.Round(result, 4));
		}

	}
}
