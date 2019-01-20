using BabysitterKata.Extensions;
using System;

namespace BabysitterKata.Entities
{
    internal sealed class FamilyA : Family
    {

        public FamilyA()
            : base("A")
        {
        }

        public override int GetRateAtTime(Int32 time)
        {
            
            if (time.IsBetweenExlusiveUpperBound(17,23))
            {
                return 15;
            }

            return 20;
        }
    }
}
