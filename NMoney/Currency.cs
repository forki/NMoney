using System;
using System.Resources;
using System.Globalization;

namespace NMoney
{
	public class Currency: ICurrency
	{
		internal Currency(string charCode, string sym, decimal mu)
		{
			CharCode = charCode;
			Symbol = sym;
			MinorUnit = mu;
		}
		
		public override string ToString()
		{
			return CharCode;
		}

		public bool Equals(ICurrency other)
		{
			if (object.ReferenceEquals(other, null))
				return false;

			return string.Equals(CharCode, other.CharCode, StringComparison.OrdinalIgnoreCase);
		}

		public string CharCode { get; private set; }

		public string Symbol { get; private set; }

		public decimal MinorUnit { get; private set; }
}
}

