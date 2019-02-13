using System;

namespace BabysitterKata.Entities
{
    public sealed class Babysitter : Entity
    {
        public Babysitter()
            :base()
        { }
        
        public Babysitter(BabysitterRequestData data)
            :base()
        {
            CurrentFamily = data.FamilyId;
            StartTime = data.StartTime;
            EndTime = data.EndTime;
        }
        
        
        public String CurrentFamily { get; set; }

        public Int32 StartTime { get; set; }

        public Int32 EndTime { get; set; }

        public Int32 PayForShift { get; set; }
        
    }
}
