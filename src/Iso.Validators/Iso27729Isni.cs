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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iso.Validators
{
	public static class Iso27729Isni
	{
		/// <summary>
		/// Validate an International Naming Standard Identifier string.
		/// </summary>
		/// <param name="isni"></param>
		/// <returns>True if the ISNI string is valid</returns>
		public static bool IsValid(string isni)
		{
			if (string.IsNullOrEmpty(isni))
				return false;
			isni = isni.Replace(" ", string.Empty).Replace("-", string.Empty);
			if (isni.Length != 16)
				return false;
			return GenerateCheckDigit(isni.Substring(0,15)) == isni.Substring(15,1);
		}

		/// <summary>
		/// Calculates check digit for a given ISNI string. Based on example code from http://support.orcid.org/knowledgebase/articles/116780-structure-of-the-orcid-identifier
		/// </summary>
		/// <param name="isniBaseDigits"></param>
		/// <returns></returns>
		public static string GenerateCheckDigit(string isniBaseDigits)
		{
			var total = 0;
			for (var i = 0; i < isniBaseDigits.Length; i++)
			{
				var digit = (int)Char.GetNumericValue(isniBaseDigits.ToCharArray()[i]);
				total = (total + digit) * 2;
			}
			var remainder = total % 11;
			var result = (12 - remainder) % 11;
			return result == 10 ? "X" : result.ToString(CultureInfo.InvariantCulture);
		}
	}
}
