using System;
using System.Resources;
using System.Globalization;

namespace NMoney.Iso4217
{
	internal class Currency: ICurrency, IFormattable
	{
		private static readonly ResourceManager _rMan = new ResourceManager("NMoney.Dic", typeof(Currency).Assembly);
		
		private readonly string _charCode;
		private readonly int _numCode;
		private readonly string _symbol;
		private readonly decimal _minorUnit;
		
		internal Currency(string charCode, string sym, int num, decimal mu)
		{
			_charCode = charCode;
			_numCode = num;
			_symbol = sym;
			_minorUnit = mu;
		}
		
		public override string ToString()
		{
			return ToString("n", null);
		}

		public string ToString(string format, IFormatProvider formatProvider)
		{
			switch(format)
			{
				case "s":
					return _symbol;
				case "c":
					return _charCode;
				case null:
				case "":
				case "n":
					return _rMan.GetString(_charCode, formatProvider as CultureInfo);
				default:
					throw new FormatException($"unexpected format '{format}'");
			}
		}

		#region ICurrency implementation
		public string CharCode => _charCode;

		public int NumCode => _numCode;

		public string Symbol => _symbol;

		public decimal MinorUnit => _minorUnit;
		#endregion
	}
}

