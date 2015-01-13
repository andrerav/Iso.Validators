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
	public static class Iso2108Isbn
	{

		/// <summary>
		/// Returns true if this ISBN (10 or 13) is valid
		/// </summary>
		/// <param name="isbn"></param>
		/// <returns></returns>
		public static bool IsValid(string isbn)
		{
			return IsValidIsbn10(isbn) || IsValidIsbn13(isbn);
		}

		/// <summary>
		/// Returns true if this ISBN-10 string is valid
		/// </summary>
		/// <param name="isbn10"></param>
		/// <returns></returns>
		public static bool IsValidIsbn13(string isbn10)
		{
			if (string.IsNullOrEmpty(isbn10))
				return false;

			isbn10 = RemoveSpaceAndHyphens(isbn10);

			if (isbn10.Length != 13)
				return false;

			var check = 0;
			for (var i = 0; i < 13; i += 2)
			{
				check += Int32.Parse(isbn10.Substring(i, 1));
			}
			for (var i = 1; i < 12; i += 2)
			{
				check += 3 * Int32.Parse(isbn10.Substring(i, 1));
			}
			return (check % 10) == 0;
		}


		/// <summary>
		/// Returns true if this ISBN-13 string is valid
		/// </summary>
		/// <param name="isbn13"></param>
		/// <returns></returns>
		public static bool IsValidIsbn10(string isbn13)
		{
			if (string.IsNullOrEmpty(isbn13))
				return false;

			isbn13 = RemoveSpaceAndHyphens(isbn13);

			if (isbn13.Length != 10)
				return false;

			var check = 0;
			for (var i = 0; i < 10; i++)
			{
				if (isbn13.ToUpper()[i] == 'X')
				{
					check += 10 * (10 - i);
				}
				else
				{
					check += Int32.Parse(isbn13.Substring(i, 1)) * (10 - i);
				}
			}
			return (check % 11) == 0;
		}
		private static string RemoveSpaceAndHyphens(string subject)
		{
			return subject.Replace(" ", string.Empty).Replace("-", string.Empty).Trim();
		}
	}
}
