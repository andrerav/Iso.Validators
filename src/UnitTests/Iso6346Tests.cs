
using Xunit;

namespace Iso.Validators.Test
{
	public class Iso6346Tests
	{
		[Fact]
		public void ValidateValidContainerNumbers()
		{
			Assert.True(Iso6346Bic.IsValid("CSQU3054383"));
			Assert.True(Iso6346Bic.IsValid("MSKU6011672"));
			Assert.True(Iso6346Bic.IsValid("TRLU4284746"));
		}

		[Fact]
		public void ValidateContainerNumbersWithSpaces()
		{
			Assert.True(Iso6346Bic.IsValid(" CSQU3054383"));
			Assert.True(Iso6346Bic.IsValid("CSQU3054383 "));
			Assert.True(Iso6346Bic.IsValid(" CSQU3054383 "));
			Assert.True(Iso6346Bic.IsValid("CSQ U3054383"));
			Assert.True(Iso6346Bic.IsValid("CSQU 3054383"));
			Assert.True(Iso6346Bic.IsValid("CSQU3 054383"));
			Assert.True(Iso6346Bic.IsValid("CSQU3 05438 3 "));
			Assert.True(Iso6346Bic.IsValid("CS  QU3  05438 3 "));
		}
		
		[Fact]
		public void ValidateContainerNumbersWithMixedCase()
		{
			Assert.True(Iso6346Bic.IsValid("CSQU3054383"));
			Assert.True(Iso6346Bic.IsValid("csqu3054383"));
			Assert.True(Iso6346Bic.IsValid("CSqu3054383"));
			Assert.True(Iso6346Bic.IsValid("csqU3054383"));
		}

		[Fact]
		public void FailValidationForInvalidContainerNumbers()
		{
			Assert.False(Iso6346Bic.IsValid("CSQU3054381"));
			Assert.False(Iso6346Bic.IsValid("CSQU3054382"));
			Assert.False(Iso6346Bic.IsValid("CSQU3053385"));
			Assert.False(Iso6346Bic.IsValid("CSQU3054385"));
		}
	
	}
}
