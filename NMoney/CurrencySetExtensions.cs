using System;

namespace NMoney
{
	/// <summary>
	/// any extensions
	/// </summary>
	public static class CurrencySetExtensions
	{
		public static bool Contain<T>(this ICurrencySet<T> currencySet, T currency) where T: class, ICurrency
		{
			var candidate = currencySet.TryParse(currency.CharCode);
			return candidate != null && candidate.Equals(currency);
		}

		/// <summary>
		/// Return currency from character code
		/// </summary>
		/// <param name="currencySet">
		/// currency set
		/// </param>
		/// <param name="charCode">
		/// character code
		/// </param>
		/// <param name="currency">
		/// currency
		/// </param>
		/// <returns>
		/// true if set contain this currency
		/// </returns>
		public static bool TryParse<T>(this ICurrencySet<T> currencySet, string charCode, out T currency) where T : class, ICurrency
		{
			currency = currencySet.TryParse(charCode);
			return currency != null;
		}
	}
}

