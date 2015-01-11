using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iso.Validators.Test
{
	[TestClass]
	public class Iso6346Tests
	{
		[TestMethod]
		public void ValidateValidContainerNumbers()
		{
			Assert.IsTrue(Iso6346.IsValid("CSQU3054383"));
			Assert.IsTrue(Iso6346.IsValid("MSKU6011672"));
			Assert.IsTrue(Iso6346.IsValid("TRLU4284746"));
		}

		[TestMethod]
		public void ValidateContainerNumbersWithSpaces()
		{
			Assert.IsTrue(Iso6346.IsValid(" CSQU3054383"));
			Assert.IsTrue(Iso6346.IsValid("CSQU3054383 "));
			Assert.IsTrue(Iso6346.IsValid(" CSQU3054383 "));
			Assert.IsTrue(Iso6346.IsValid("CSQ U3054383"));
			Assert.IsTrue(Iso6346.IsValid("CSQU 3054383"));
			Assert.IsTrue(Iso6346.IsValid("CSQU3 054383"));
			Assert.IsTrue(Iso6346.IsValid("CSQU3 05438 3 "));
			Assert.IsTrue(Iso6346.IsValid("CS  QU3  05438 3 "));
		}
		
		[TestMethod]
		public void ValidateContainerNumbersWithMixedCase()
		{
			Assert.IsTrue(Iso6346.IsValid("CSQU3054383"));
			Assert.IsTrue(Iso6346.IsValid("csqu3054383"));
			Assert.IsTrue(Iso6346.IsValid("CSqu3054383"));
			Assert.IsTrue(Iso6346.IsValid("csqU3054383"));
		}

		[TestMethod]
		public void FailValidationForInvalidContainerNumbers()
		{
			Assert.IsFalse(Iso6346.IsValid("CSQU3054381"));
			Assert.IsFalse(Iso6346.IsValid("CSQU3054382"));
			Assert.IsFalse(Iso6346.IsValid("CSQU3053385"));
			Assert.IsFalse(Iso6346.IsValid("CSQU3054385"));
		}
	
	}
}
