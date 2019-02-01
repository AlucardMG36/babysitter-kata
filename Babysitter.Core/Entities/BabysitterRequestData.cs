using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabysitterKata.Entities
{
    public class BabysitterRequestData
    {

        public BabysitterRequestData() { }

        public String FamilyId { get; set; }
        public Int32 StartTime { get; set; }
        public Int32 EndTime  { get; set; }
    }
}
