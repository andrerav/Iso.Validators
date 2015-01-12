// Copyright © 2015 Andreas Ravnestad
//
// Iso.Validators is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// Iso.Validators is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU Lesser General Public License for more details.
// You should have received a copy of the GNU Lesser General Public License
// along with Iso.Validators; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA 

using System;

namespace Iso.Validators
{
    public static class Iso6346Bic
    {

		const string CharCode = "0123456789A?BCDEFGHIJK?LMNOPQRSTU?VWXYZ";

		/// <summary>
		/// Validate an ISO 6346 (BIC) container code. Based on example code from <a href="http://en.wikipedia.org/wiki/ISO_6346">http://en.wikipedia.org/wiki/ISO_6346</a>
		/// </summary>
		/// <param name="containerCode"></param>
		/// <returns></returns>
		public static bool IsValid(string containerCode)
		{
			// Trim and remove spaces
			containerCode = containerCode.Trim().Replace(" ", string.Empty);

			// Container code can not be an empty string or have a length other than 11
			if (string.IsNullOrEmpty(containerCode) || containerCode.Length != 11) {
				return false;
			}

			int num = 0;

			// Convert characters to uppercase
			containerCode = containerCode.ToUpper();

			for (var i = 0; i < 10; i++) {
				var chr = containerCode.Substring(i, 1);

				// Ensure that the current character is in the valid alphabet
				int idx = chr == "?" ? -1 : CharCode.IndexOf(chr, System.StringComparison.Ordinal);
				if (idx < 0) {
					return false;
				}

				// Calculate power and convert to int
				idx = idx * (int)Math.Pow(2, i);
				num += idx;
			}
			num = (num % 11) % 10;

			// Return true if check digit equals num
			return Int32.Parse(containerCode.Substring(10, 1)) == num;
		}
	}
}
