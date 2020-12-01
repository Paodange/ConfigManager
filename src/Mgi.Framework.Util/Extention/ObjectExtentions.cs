using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Mgi.Framework.Util.Extention
{
    public static class ObjectExtentions
    {
        public static IDictionary<string, object> ToDictionary(this object obj, bool keyCamelCase = false)
        {
            if (obj is null) return null;
            if (obj is IEnumerable)
            {
                throw new Exception("ToDictionary does not support array or collections");
            }
            var settings = new JsonSerializerSettings();
            if (keyCamelCase)
            {
                settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            }
            else
            {
                settings.ContractResolver = new DefaultContractResolver();
            }
            return JsonConvert.DeserializeObject<IDictionary<string, object>>(JsonConvert.SerializeObject(obj, settings), settings);
        }

        public static IEnumerable<IDictionary<string, object>> ToDictionaries(this IEnumerable obj, bool keyCamelCase = false)
        {
            if (obj == null) return null;
            var settings = new JsonSerializerSettings();
            if (keyCamelCase)
            {
                settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            }
            else
            {
                settings.ContractResolver = new DefaultContractResolver();
            }
            return JsonConvert.DeserializeObject<IEnumerable<IDictionary<string, object>>>(JsonConvert.SerializeObject(obj, settings), settings);
        }
    }
}
