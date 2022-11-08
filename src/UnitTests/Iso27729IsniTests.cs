using Xunit;

namespace Iso.Validators.Test
{
	public class Iso27729IsniTests
	{
		[Fact]
		public void ValidateValidIsnis()
		{
			Assert.True(Iso27729Isni.IsValid("1234 6834 9573 0495"));
			Assert.True(Iso27729Isni.IsValid("0000 0001 2103 2683"));
			Assert.True(Iso27729Isni.IsValid("0000 0001 1449 9592"));
		}

		[Fact]
		public void ValidateValidIsnisWithHyphens()
		{
			Assert.True(Iso27729Isni.IsValid("1234-6834-9573-0495"));
			Assert.True(Iso27729Isni.IsValid("0000 0001 2103-2683"));
			Assert.True(Iso27729Isni.IsValid("0000 0001-1449 9592"));
		}

		[Fact]
		public void FailValidationForInvalidIsnis()
		{
			Assert.False(Iso27729Isni.IsValid("1234 6834 9573 0491"));
			Assert.False(Iso27729Isni.IsValid("0000 0001 2103 2681"));
			Assert.False(Iso27729Isni.IsValid("0000 0001 1449 9591"));
		}
	}
}
