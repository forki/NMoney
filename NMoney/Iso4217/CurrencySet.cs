using System;
using System.Collections.Generic;

namespace NMoney.Iso4217
{
	/// <summary>
	/// The currencies standard ISO 4217
	/// </summary>
	public partial class CurrencySet : NMoney.CurrencySet<Iso4217.Currency>
	{
		private static readonly Lazy<CurrencySet> _lazy = new Lazy<CurrencySet>(() => new CurrencySet(), true);

		public static CurrencySet Instance => _lazy.Value;

		private CurrencySet() : base(GetAll())
		{
		}

		/// <summary>
		/// ISO 4217 contain this instance of currency
		/// </summary>
		/// <param name="currency">
		/// instance
		/// </param>
		public bool Contain(ICurrency currency)
		{
			return currency is Iso4217.Currency;
		}
		
		/// <summary>
		/// ISO 4217 contains an instance of a character code
		/// </summary>
		/// <param name="charCode">
		/// character code
		/// </param>
		public bool Contain(string charCode)
		{
			return TryParse(charCode) != null;
		}

		/// <summary>
		/// Return currency from character code
		/// </summary>
		/// <param name="charCode">
		/// character code
		/// </param>
		/// <exception cref="System.NotSupportedException">if ISO 4217 not contain this currency</exception>
		public ICurrency Parse(string charCode)
		{
			var currency = TryParse(charCode);
			if (currency != null)
				return currency;

			throw new NotSupportedException("currency code '" + charCode + "' not supported in ISO4217");
		}

		/// <summary>
		/// Return currency from number code
		/// </summary>
		/// <param name="numCode">
		/// number code
		/// </param>
		/// <exception cref="System.NotSupportedException">if ISO 4217 not contain this currency</exception>
		public ICurrency Parse(int numCode)
		{
			var currency = TryParse(numCode);
			if (currency != null)
				return currency;

			throw new NotSupportedException("currency code '" + numCode + "' not supported in ISO4217");
		}
		
		/// <summary>
		/// Return currency from number code
		/// </summary>
		/// <param name="numCode">
		/// number code
		/// </param>
		/// <param name="currency">
		/// currency
		/// </param>
		/// <returns>
		/// true if ISO 4217 contain this currency
		/// </returns>
		public bool TryParse(int numCode, out ICurrency currency)
		{
			currency = TryParse(numCode);
			return currency != null;
		}
	}
}