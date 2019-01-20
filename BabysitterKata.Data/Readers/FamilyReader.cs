using BabysitterKata.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BabysitterKata.Readers
{
    internal sealed class FamilyReader
    {
        public Family Family { get; set; }

        private void ReadFamilyInformation(String Id)
        {
            using (var file = File.OpenText(@"../familyData.json"))
            using (var reader = new JsonTextReader(file))
            {
                var o2 = (JObject)JToken.ReadFrom(reader);
                var parsedObject = JArray.Parse(o2.ToString());

                
            }
            
        }

        internal Int32 GetRateData(String timeCondition)
        {
            throw new NotImplementedException();
        }
    }
}
