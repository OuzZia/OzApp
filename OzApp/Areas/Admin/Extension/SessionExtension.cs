using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzApp.Areas.Admin.Extension
{
    public static class SessionExtension
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            string jsonStr = JsonConvert.SerializeObject(value);
            session.SetString(key, jsonStr);
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            string jsonStr = session.GetString(key);
            return JsonConvert.DeserializeObject<T>(jsonStr);

        }
    }
}
