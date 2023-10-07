using Newtonsoft.Json;

namespace DemoTelerik.Modules.Extensions
{
	public static class SessionExtensions
	{
		public static void Set<T>(this ISession session, string key, T value)
		{
			session.SetString(key, JsonConvert.SerializeObject(value));
			//try
			//{

			//}
			//catch (Exception ex)
			//{
			//	var error = ex.ToString();
			//	throw;
			//}

		}

		public static T Get<T>(this ISession session, string key)
		{
			try
			{
				var value = session.GetString(key);

				return value == null ? default(T) :
					JsonConvert.DeserializeObject<T>(value);
			}
			catch (Exception ex)
			{
				return default(T);
			}
		}

	}
}
