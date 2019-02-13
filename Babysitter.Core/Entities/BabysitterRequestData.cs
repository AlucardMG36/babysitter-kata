using System;

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
