using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDV701BackEnd.infrastructure
{
    public abstract class AbstractPerson
    {

    }
    public class Person:AbstractPerson
    {
        public string Name { get; set; }
    }

    public class Student:Person
    {
        public string CourseName { get; set; }
    }
    public class SerializationTests
    {
        public static List<AbstractPerson> Ser()
        {
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            List<AbstractPerson> plist = new List<AbstractPerson> { 
                new Person { Name = "Person" }, 
                new Student { Name = "Student", CourseName = "SomeCourse" } 
            };
            var json = JsonConvert.SerializeObject(plist, settings);
            var deserialized = JsonConvert.DeserializeObject<List<AbstractPerson>>(json, settings);
            return deserialized;
        }
    }
}
