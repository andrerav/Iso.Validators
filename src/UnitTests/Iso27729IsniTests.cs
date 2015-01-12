using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iso.Validators.Test
{
	[TestClass]
	public class Iso27729IsniTests
	{
		[TestMethod]
		public void ValidateValidIsnis()
		{
			Assert.IsTrue(Iso27729Isni.IsValid("1234 6834 9573 0495"));
			Assert.IsTrue(Iso27729Isni.IsValid("0000 0001 2103 2683"));
			Assert.IsTrue(Iso27729Isni.IsValid("0000 0001 1449 9592"));
		}

		[TestMethod]
		public void ValidateValidIsnisWithHyphens()
		{
			Assert.IsTrue(Iso27729Isni.IsValid("1234-6834-9573-0495"));
			Assert.IsTrue(Iso27729Isni.IsValid("0000 0001 2103-2683"));
			Assert.IsTrue(Iso27729Isni.IsValid("0000 0001-1449 9592"));
		}

		[TestMethod]
		public void FailValidationForInvalidIsnis()
		{
			Assert.IsFalse(Iso27729Isni.IsValid("1234 6834 9573 0491"));
			Assert.IsFalse(Iso27729Isni.IsValid("0000 0001 2103 2681"));
			Assert.IsFalse(Iso27729Isni.IsValid("0000 0001 1449 9591"));
		}
	}
}
