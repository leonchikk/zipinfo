using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace ZipInfo.Domain.Extensions
{
    public static class DynamicExtensions
    {
        public static bool HasProperty(dynamic obj, string propertyName)
        {
            if (obj == null) return false;
            if (obj is ExpandoObject)
                return ((IDictionary<string, object>)obj).ContainsKey(propertyName);
            if (obj is IDictionary<string, object> dict1)
                return dict1.ContainsKey(propertyName);
            if (obj is IDictionary<string, JToken> dict2)
                return dict2.ContainsKey(propertyName);
            return obj.GetType().GetProperty(propertyName) != null;
        }
    }
}
