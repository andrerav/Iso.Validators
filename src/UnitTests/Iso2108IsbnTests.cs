using System;

using Xunit;

namespace Iso.Validators.Test
{
	public class Iso2108IsbnTests
	{
		[Fact]
		public void ValidateValidIsbn10()
		{
			Assert.True(Iso2108Isbn.IsValidIsbn10("0465026567"));
			Assert.True(Iso2108Isbn.IsValidIsbn10("0345453743"));
			Assert.True(Iso2108Isbn.IsValidIsbn10("0814758371"));
			Assert.True(Iso2108Isbn.IsValidIsbn10("0140386335"));
		}
		[Fact]
		public void ValidateValidIsbn13()
		{
			Assert.True(Iso2108Isbn.IsValidIsbn13("978-0465026562"));
			Assert.True(Iso2108Isbn.IsValidIsbn13("978-0345453747"));
			Assert.True(Iso2108Isbn.IsValidIsbn13("978-0814758373"));
			Assert.True(Iso2108Isbn.IsValidIsbn13("978-0140386332"));
		}
		[Fact]
		public void ValidateValidIsbn10WithSpaceAndHyphens()
		{
			Assert.True(Iso2108Isbn.IsValidIsbn10("04650 26567"));
			Assert.True(Iso2108Isbn.IsValidIsbn10("034-5453743"));
			Assert.True(Iso2108Isbn.IsValidIsbn10("08 14758371"));
			Assert.True(Iso2108Isbn.IsValidIsbn10("0140386-335"));
		}
		[Fact]
		public void ValidateValidIsbn13WithSpaceAndHyphens()
		{
			Assert.True(Iso2108Isbn.IsValidIsbn13("978-04-65026562"));
			Assert.True(Iso2108Isbn.IsValidIsbn13("978-03454 53747"));
			Assert.True(Iso2108Isbn.IsValidIsbn13("978-08147  58373 "));
			Assert.True(Iso2108Isbn.IsValidIsbn13("978-0-1-4----0-3-8-6-332"));
		}


		[Fact]
		public void ValidateInvalidIsbn10()
		{
			Assert.False(Iso2108Isbn.IsValidIsbn10("046506567"));
			Assert.False(Iso2108Isbn.IsValidIsbn10("03454253743"));
			Assert.False(Iso2108Isbn.IsValidIsbn10("0814748371"));
			Assert.False(Iso2108Isbn.IsValidIsbn10("0140376335"));
		}
		[Fact]
		public void ValidateInvalidIsbn13()
		{
			Assert.False(Iso2108Isbn.IsValidIsbn13("978-065026562"));
			Assert.False(Iso2108Isbn.IsValidIsbn13("978-04345453747"));
			Assert.False(Iso2108Isbn.IsValidIsbn13("978-081475-a-8373"));
			Assert.False(Iso2108Isbn.IsValidIsbn13("978-0140386 as332"));
		}
	}
}
