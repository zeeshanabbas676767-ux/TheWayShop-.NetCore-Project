using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace NewCoreProject.Helpers
{
    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T? GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }

        public static void SetDouble(this ISession session, string key, double value)
        {
            session.SetString(key, value.ToString());
        }

        public static double GetDouble(this ISession session, string key)
        {
            var str = session.GetString(key);
            return double.TryParse(str, out double result) ? result : 0;
        }
    }
}
