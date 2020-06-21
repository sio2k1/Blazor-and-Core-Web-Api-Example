/*
 * Author: Oleg Sivers
 * Date: 01.06.2020
 * Desc: Common utils
*/

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SDV701common
{
    public class utils
    {
        public static Assembly GetAssemblyByName(string name)
        {
            return AppDomain.CurrentDomain.GetAssemblies().
                   SingleOrDefault(assembly => assembly.GetName().Name == name);
        }
        public static string GetAssemblyNameByType<T>()
        {
            Assembly asm = typeof(T).Assembly;
            return asm.FullName;
        }
        public static List<T> DeserializeJsonWithTypes<T>(string json)
        {
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All};
            return JsonConvert.DeserializeObject<List<T>>(json.Replace("System.Private.CoreLib", "mscorlib"), settings); // workaround to make newtonsoftjson work in net.Core
        }

        public static T DeserializeJsonWithTypesSingle<T>(string json)
        {
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.DeserializeObject<T>(json.Replace("System.Private.CoreLib", "mscorlib"), settings); // workaround to make newtonsoftjson work in net.Core
        }

        public static T CloneObject<T>(T obj)
        {
            return DeserializeJsonWithTypesSingle<T>(SerializeJsonWithTypes(obj));
        }

        public static string SerializeJsonWithTypes(object obj)
        {
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.SerializeObject(obj, settings);
        }

    }
}




