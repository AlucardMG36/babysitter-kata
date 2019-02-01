using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKata.Api.IntegrationTests.Http
{
    public class Resource: ResourceBase
    {
        public Dictionary<String, Object> Data { get; set; }

        public override Boolean Equals(object obj)
        {
            var other = obj as Resource;

            return base.Equals(obj) && (other != null) && Equals(Data, other.Data);
        }

        public static Resource From(string json)
        {
            return JsonConvert.DeserializeObject<Resource>(json);
        }

        public override Int32 GetHashCode()
        {
            var hashCode = base.GetHashCode();

            hashCode *= (43 * Data.GetHashCode());

            return hashCode;
        }
    }

    public class Resource<T>: ResourceBase
    {
        public T Data { get; set; }

        public override Boolean Equals(object obj)
        {
            var other = obj as Resource<T>;

            return base.Equals(obj) && (other != null) && Equals(Data, other.Data);
        }

        public static Resource<T> From(string json)
        {
            return JsonConvert.DeserializeObject<Resource<T>>(json);
        }

        public override Int32 GetHashCode()
        {
            var hashCode = base.GetHashCode();

            hashCode *= (43 * Data.GetHashCode());

            return hashCode;
        }
    }
}
