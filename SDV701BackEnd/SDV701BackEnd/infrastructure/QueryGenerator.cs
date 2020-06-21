/*
 * Author: Oleg Sivers
 * Date: 01.06.2020
 * Desc: Generate SQL queries, based on Types
*/
using SDV701BackEnd.DB;
using SDV701common;
using System;
using System.Linq;
using System.Reflection;

namespace SDV701BackEnd.infrastructure
{
    public class query
    {
        public string sql { get; set; }
        public ParamList paramList { get; set; }
    }
    public static class QueryGenerator
    {
        private static object GenerateObject(Assembly asm, Type t, string JSON)
        {
            MethodInfo method = typeof(utils).GetMethod(nameof(utils.DeserializeJsonWithTypesSingle));
            MethodInfo generic = method.MakeGenericMethod(t);
            object obj = generic.Invoke(null, new object[] { JSON });
            if (!(obj is Model)) {
                throw new Exception("Provided object should have Model class on top of hierararchy");
            }
            string validationResult = (obj as Model).IsValid();
            if (validationResult!="")
            {
                throw new Exception($"Validation error: {validationResult}");
            }
            return obj;
        }
        public static query Update(string assemblyName, string typeName, string JSON, string TPHType)
        {
            Assembly asm = utils.GetAssemblyByName(assemblyName);
            Type t = asm.GetType(typeName);
            object o = GenerateObject(asm, t, JSON);
            ParamList pl = new ParamList();
            string updParams = "";
            string idField = "id";
            int idVal = (int)t.GetProperties().ToList().Find(x => x.Name == idField).GetValue(o);
            
            string table = TPHType == "" ? t.Name : TPHType;
            var props = t.GetProperties().Where(
                            prop => !Attribute.IsDefined(prop, typeof(ExcludeFromInsertUpdate)));
            props.ToList().ForEach(prop => {
                pl.Add(prop.Name, prop.GetValue(o));
                if (prop.Name != idField)
                    updParams += $"[{prop.Name}] = @{prop.Name},";
            });
            updParams = updParams.Remove(updParams.Length - 1);

            return new query()
            {
                paramList = pl,
                sql = $"UPDATE [{table}] SET {updParams} WHERE [{idField}]=@{idField}"
            };
        }

        public static query Insert(string assemblyName, string typeName, string JSON, string TPHType)
        {
            Assembly asm = utils.GetAssemblyByName(assemblyName);
            Type t = asm.GetType(typeName);
            object o = GenerateObject(asm, t, JSON);
            ParamList pl = new ParamList();
            string insFields = "";
            string insValues = "";
            string idField = "id";
            int idVal = (int)t.GetProperties().ToList().Find(x => x.Name == idField).GetValue(o);

            string table = TPHType == "" ? t.Name : TPHType;
            var props = t.GetProperties().Where(
                prop => !Attribute.IsDefined(prop, typeof(ExcludeFromInsertUpdate)));

            props.ToList().FindAll(x => x.Name != idField).ForEach(prop => {
                pl.Add(prop.Name, prop.GetValue(o));
                insFields += $"[{prop.Name}],";
                insValues += $"@{prop.Name},";
            });
            insFields = insFields.Remove(insFields.Length - 1);
            insValues = insValues.Remove(insValues.Length - 1);

            return new query()
            {
                paramList = pl,
                sql = $"INSERT INTO [{table}] ({insFields}) VALUES ({insValues}) SELECT CAST(scope_identity() AS int)"
            };
        }


        public static query Delete(string assemblyName, string typeName, string JSON, string TPHType)
        {
            Assembly asm = utils.GetAssemblyByName(assemblyName);
            Type t = asm.GetType(typeName);
            object o = GenerateObject(asm, t, JSON);
            ParamList pl = new ParamList();
            string idField = "id";
            int idVal = (int)t.GetProperties().ToList().Find(x => x.Name == idField).GetValue(o);

            string table = TPHType == "" ? t.Name : TPHType;
            t.GetProperties().ToList().FindAll(x => x.Name == idField).ForEach(prop => {
                pl.Add(prop.Name, prop.GetValue(o));
            });

            return new query()
            {
                paramList = pl,
                sql = $"DELETE FROM [{table}] WHERE [{idField}]=@{idField}"
            };
        }

    }
}
