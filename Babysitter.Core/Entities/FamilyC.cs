using BabysitterKata.Extensions;
using System;

namespace BabysitterKata.Entities
{
    internal sealed class FamilyC : Family
    {

        public FamilyC()
            : base("C")
        {
        }

        public override int GetRateAtTime(Int32 time)
        {
            
            if(time.IsBetweenExlusiveUpperBound(17,21))
            {
                return 21;
            }

            return 15;
        }
    }
}
