using System;
using System.Resources;
using System.Globalization;

namespace NMoney
{
	public class Currency: ICurrency
	{
		public Currency(string charCode, string sym, decimal mu)
		{
			CharCode = charCode;
			Symbol = sym;
			MinorUnit = mu;
		}
		
		public override string ToString()
		{
			return CharCode;
		}

		public virtual bool Equals(ICurrency other)
		{
			if (object.ReferenceEquals(other, null))
				return false;

			return object.ReferenceEquals(other, this);
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as ICurrency);
		}

		public virtual string ToString(string format, IFormatProvider formatProvider)
		{
			return ToString();
		}

		public string CharCode { get; private set; }

		public string Symbol { get; private set; }

		public decimal MinorUnit { get; private set; }
}
}
