using BabysitterKata.Extensions;
using System;

namespace BabysitterKata.Entities
{
    internal sealed class FamilyB : Family
    {

        public FamilyB()
            : base("B")
        {
        }

        public override int GetRateAtTime(Int32 time)
        {
            
            if (time.IsBetweenExclusiveLowerBound(0, 4))
            {
                return 16;
            }
            else if(time.IsBetweenExlusiveUpperBound(17,22))
            {
                return 12;
            }
               return 8;
        }
    }
}
