using Newtonsoft.Json;

namespace Mgi.Framework.Util
{
    public class JsonUtil
    {
        public static string Serialize(object o, bool prettify = false)
        {
            Formatting f = prettify ? Formatting.Indented : Formatting.None;
            return JsonConvert.SerializeObject(o, f);
        }

        public static T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }
        public static T ConvertTo<T>(object o)
        {
            return Deserialize<T>(Serialize(o));
        }
    }
}
