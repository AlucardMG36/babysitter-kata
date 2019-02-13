using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKata.App.IntegrationTests.Http
{
    public class Resource: ResourceBase
    {
        public Dictionary<String, Object> Data { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as Resource;

            return base.Equals(obj) && (other != null) && Equals(Data, other.Data);
        }

        public static Resource From(String json)
        {
            return JsonConvert.DeserializeObject<Resource>(json);
        }

        public override int GetHashCode()
        {
            var hashCode = base.GetHashCode();

            hashCode *= (41 * Data.GetHashCode());

            return hashCode;
        }   
    }

    public class Resource<T>: ResourceBase
    {
        public T Data { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as Resource<T>;

            return base.Equals(obj) && (other != null) && Equals(Data, other.Data);
        }

        public static Resource<T> From(String json)
        {
            return JsonConvert.DeserializeObject<Resource<T>>(json);
        }

        public override int GetHashCode()
        {
            var hashCode = base.GetHashCode();

            hashCode *= (41 * Data.GetHashCode());

            return hashCode;
        }
    }
}
