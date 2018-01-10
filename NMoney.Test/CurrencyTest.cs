using System;
using NUnit.Framework;
using System.Threading;
using System.Globalization;

namespace NMoney
{
	[TestFixture]
	public class CurrencyTest
	{
		[Test]
		public void AllCurrensiesFromIso4217()
		{

			foreach (var c in Iso4217.CurrencySet.Instance)
			{
				Assert.AreEqual(c, Iso4217.CurrencySet.Instance.Parse(c.CharCode));
				Assert.AreEqual(c, Iso4217.CurrencySet.Instance.Parse(c.NumCode));
			}
		}

		[TestCase("USD")]
		[TestCase("XXX")]
		public void Contains(string code)
		{
			Assert.IsTrue(Iso4217.CurrencySet.Instance.Contain(code));
			Assert.IsTrue(Iso4217.CurrencySet.Instance.Contain(Iso4217.CurrencySet.Instance.Parse(code)));
		}

		[Test]
		public void NotContainCode()
		{
			Assert.IsFalse(Iso4217.CurrencySet.Instance.Contain("???"));
		}

		[Test]
		public void NotContainCurrency()
		{
			Assert.IsFalse(Iso4217.CurrencySet.Instance.Contain(new FakeCurrency()));
		}

		private class FakeCurrency: ICurrency
		{
			public string CharCode
			{
				get { throw new NotImplementedException(); }
			}

			public int NumCode
			{
				get { throw new NotImplementedException(); }
			}

			public string Symbol
			{
				get { throw new NotImplementedException(); }
			}

			public decimal MinorUnit
			{
				get { throw new NotImplementedException(); }
			}

			public bool Equals(ICurrency other)
			{
				throw new NotImplementedException();
			}
		}

		[Test]
		public void TryParseNumCodeFail()
		{
			ICurrency c;
			Assert.IsFalse(Iso4217.CurrencySet.Instance.TryParse("???", out c));
		}

		[Test]
		public void TryParseCharCodeFail()
		{
			ICurrency c;
			Assert.IsFalse(Iso4217.CurrencySet.Instance.TryParse(12345, out c));
		}

		[TestCase(784, "AED")]
		[TestCase(971, "AFN")]
		public void TryParseNumCode(int code, string exp)
		{
			ICurrency c;
			Assert.IsTrue(Iso4217.CurrencySet.Instance.TryParse(code, out c));
			Assert.AreEqual(exp, c.CharCode);
		}

		[TestCase("USD", "USD")]
		[TestCase("XXX", "XXX")]
		public void TryParseCharCode(string code, string exp)
		{
			ICurrency c;
			Assert.IsTrue(Iso4217.CurrencySet.Instance.TryParse(code, out c));
			Assert.AreEqual(exp, c.CharCode);
		}

		[TestCase(784, "AED")]
		[TestCase(971, "AFN")]
		public void ParseNumCode(int code, string exp)
		{
			Assert.AreEqual(exp, Iso4217.CurrencySet.Instance.Parse(code).CharCode);
		}

		[TestCase("USD", "USD")]
		[TestCase("XXX", "XXX")]
		public void ParseCharCode(string code, string exp)
		{
			Assert.AreEqual(exp, Iso4217.CurrencySet.Instance.Parse(code).CharCode);
		}

		[Test]
		public void ParseCharFalse()
		{
			Assert.Throws<NotSupportedException>(() =>
			{
				Iso4217.CurrencySet.Instance.Parse("???");
			});
		}

		[Test]
		public void ParseNumFalse()
		{
			Assert.Throws<NotSupportedException>(() =>
			{
				Iso4217.CurrencySet.Instance.Parse(12345);
			});
		}

		[Test]
		public void Equals()
		{
			ICurrency c1 = Iso4217.CurrencySet.RUB;
			ICurrency c2 = Iso4217.CurrencySet.AED;
			Assert.AreNotEqual(c1, c2);
			Assert.IsFalse(c1 == c2);

			ICurrency c3 = Iso4217.CurrencySet.RUB;
			Assert.AreEqual(c1, c3);
			Assert.IsTrue(c1 == c3);
		}
		
		[Test]
		public void ViewUYU()
		{
			Assert.AreEqual("UYU", Iso4217.CurrencySet.UYU.CharCode);
			Assert.AreEqual("$U", Iso4217.CurrencySet.UYU.Symbol);
			Assert.AreEqual(858, Iso4217.CurrencySet.UYU.NumCode);
			Assert.AreEqual(0.01m, Iso4217.CurrencySet.UYU.MinorUnit);
		}

		[TestCase("USD", "ru-RU", "Доллар США")]
		[TestCase("USD", "en-GB", "US Dollar")]
		[TestCase("ALL", "ru-RU", "Лек")]
		[TestCase("ALL", "en-GB", "Lek")]
		[TestCase("XDR", "ru-RU", "Специальные права заимствования")]
		public void Localization(string code, string culture, string exp)
		{
			CultureInfo ci = CultureInfo.GetCultureInfo(culture);
			Thread.CurrentThread.CurrentCulture = ci;
			Thread.CurrentThread.CurrentUICulture = ci;
			Assert.AreEqual(exp, Iso4217.CurrencySet.Instance.Parse(code).ToString());
		}
	}
}

