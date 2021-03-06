﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iso.Validators.Test
{
	[TestClass]
	public class Iso6346Tests
	{
		[TestMethod]
		public void ValidateValidContainerNumbers()
		{
			Assert.IsTrue(Iso6346Bic.IsValid("CSQU3054383"));
			Assert.IsTrue(Iso6346Bic.IsValid("MSKU6011672"));
			Assert.IsTrue(Iso6346Bic.IsValid("TRLU4284746"));
		}

		[TestMethod]
		public void ValidateContainerNumbersWithSpaces()
		{
			Assert.IsTrue(Iso6346Bic.IsValid(" CSQU3054383"));
			Assert.IsTrue(Iso6346Bic.IsValid("CSQU3054383 "));
			Assert.IsTrue(Iso6346Bic.IsValid(" CSQU3054383 "));
			Assert.IsTrue(Iso6346Bic.IsValid("CSQ U3054383"));
			Assert.IsTrue(Iso6346Bic.IsValid("CSQU 3054383"));
			Assert.IsTrue(Iso6346Bic.IsValid("CSQU3 054383"));
			Assert.IsTrue(Iso6346Bic.IsValid("CSQU3 05438 3 "));
			Assert.IsTrue(Iso6346Bic.IsValid("CS  QU3  05438 3 "));
		}
		
		[TestMethod]
		public void ValidateContainerNumbersWithMixedCase()
		{
			Assert.IsTrue(Iso6346Bic.IsValid("CSQU3054383"));
			Assert.IsTrue(Iso6346Bic.IsValid("csqu3054383"));
			Assert.IsTrue(Iso6346Bic.IsValid("CSqu3054383"));
			Assert.IsTrue(Iso6346Bic.IsValid("csqU3054383"));
		}

		[TestMethod]
		public void FailValidationForInvalidContainerNumbers()
		{
			Assert.IsFalse(Iso6346Bic.IsValid("CSQU3054381"));
			Assert.IsFalse(Iso6346Bic.IsValid("CSQU3054382"));
			Assert.IsFalse(Iso6346Bic.IsValid("CSQU3053385"));
			Assert.IsFalse(Iso6346Bic.IsValid("CSQU3054385"));
		}
	
	}
}
