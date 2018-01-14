using System.Collections.Generic;

namespace NMoney
{
	/// <summary>
	/// Supported currency collection in your application or any serializer
	/// </summary>
	public interface ICurrencySet: ICurrencySet<ICurrency>
	{
	}
}
