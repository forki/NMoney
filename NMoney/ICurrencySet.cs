using System.Collections.Generic;

namespace NMoney
{
	/// <summary>
	/// Supported currency collection in your application or any serializer
	/// </summary>
	public interface ICurrencySet<out T>: IReadOnlyCollection<T> where T: class, ICurrency
	{
		/// <summary>
		/// Parse char code of currency in this set
		/// </summary>
		/// <param name="charCode">
		/// char code of currency
		/// </param>
		/// <returns>
		/// null if not found
		/// </returns>
		T TryParse(string charCode);
	}
}
