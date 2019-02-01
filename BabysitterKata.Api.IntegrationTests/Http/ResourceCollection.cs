using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKata.Api.IntegrationTests.Http
{
    public class ResourceCollection: ResourceBase
    {   
        public List<Resource> Data { get; set; }

        public static ResourceCollection From(String json)
        {
            return JsonConvert.DeserializeObject<ResourceCollection>(json);
        }
    }

    public class ResourceCollection<T>: ResourceBase
    {
        public List<Resource<T>> Data { get; set; }

        public static ResourceCollection<T> From(String json)
        {
            return JsonConvert.DeserializeObject<ResourceCollection<T>>(json);
        }
    }
}
