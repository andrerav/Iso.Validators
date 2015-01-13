using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iso.Validators.Test
{
	[TestClass]
	public class Iso2108IsbnTests
	{
		[TestMethod]
		public void ValidateValidIsbn10()
		{
			Assert.IsTrue(Iso2108Isbn.IsValidIsbn10("0465026567"));
			Assert.IsTrue(Iso2108Isbn.IsValidIsbn10("0345453743"));
			Assert.IsTrue(Iso2108Isbn.IsValidIsbn10("0814758371"));
			Assert.IsTrue(Iso2108Isbn.IsValidIsbn10("0140386335"));
		}
		[TestMethod]
		public void ValidateValidIsbn13()
		{
			Assert.IsTrue(Iso2108Isbn.IsValidIsbn13("978-0465026562"));
			Assert.IsTrue(Iso2108Isbn.IsValidIsbn13("978-0345453747"));
			Assert.IsTrue(Iso2108Isbn.IsValidIsbn13("978-0814758373"));
			Assert.IsTrue(Iso2108Isbn.IsValidIsbn13("978-0140386332"));
		}
		[TestMethod]
		public void ValidateValidIsbn10WithSpaceAndHyphens()
		{
			Assert.IsTrue(Iso2108Isbn.IsValidIsbn10("04650 26567"));
			Assert.IsTrue(Iso2108Isbn.IsValidIsbn10("034-5453743"));
			Assert.IsTrue(Iso2108Isbn.IsValidIsbn10("08 14758371"));
			Assert.IsTrue(Iso2108Isbn.IsValidIsbn10("0140386-335"));
		}
		[TestMethod]
		public void ValidateValidIsbn13WithSpaceAndHyphens()
		{
			Assert.IsTrue(Iso2108Isbn.IsValidIsbn13("978-04-65026562"));
			Assert.IsTrue(Iso2108Isbn.IsValidIsbn13("978-03454 53747"));
			Assert.IsTrue(Iso2108Isbn.IsValidIsbn13("978-08147  58373 "));
			Assert.IsTrue(Iso2108Isbn.IsValidIsbn13("978-0-1-4----0-3-8-6-332"));
		}


		[TestMethod]
		public void ValidateInvalidIsbn10()
		{
			Assert.IsFalse(Iso2108Isbn.IsValidIsbn10("046506567"));
			Assert.IsFalse(Iso2108Isbn.IsValidIsbn10("03454253743"));
			Assert.IsFalse(Iso2108Isbn.IsValidIsbn10("0814748371"));
			Assert.IsFalse(Iso2108Isbn.IsValidIsbn10("0140376335"));
		}
		[TestMethod]
		public void ValidateInvalidIsbn13()
		{
			Assert.IsFalse(Iso2108Isbn.IsValidIsbn13("978-065026562"));
			Assert.IsFalse(Iso2108Isbn.IsValidIsbn13("978-04345453747"));
			Assert.IsFalse(Iso2108Isbn.IsValidIsbn13("978-081475-a-8373"));
			Assert.IsFalse(Iso2108Isbn.IsValidIsbn13("978-0140386 as332"));
		}
	}
}
