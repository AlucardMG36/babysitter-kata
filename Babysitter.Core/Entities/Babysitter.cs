using System;

namespace BabysitterKata.Entities
{
    public sealed class Babysitter : Entity
    {
        public Babysitter()
            :base()
        { }

        public Babysitter(String familyId)
        {
            CurrentFamily = familyId;
        }

        public String CurrentFamily { get; set; }

        public Int32 PayForShift { get; set; }
        
    }
}
