using Babysitter.Core.Data;
using BabysitterKata.Extensions;
using System;

namespace BabysitterKata.Entities
{
    public abstract class Family : IFamilyRepository
    {
        protected Family()
        { }

        protected Family(String FamilyId)
        {
            Id = FamilyId;
        }


        public Int32 Rate { get; set; }

        public String Id { get; protected set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return (obj is Family other) && Id.Equals(other.Id);
        }

        public static bool operator ==(Family f1, Family f2)
        {
            if (ReferenceEquals(f1, f2))
            {
                return true;
            }
            else if ((f1 is null) || (f2 is null))
            {
                return false;
            }
            else
            {
                return (f1.Id.CompareTo(f2.Id) == 0);
            }
        }

        public static bool operator !=(Family f1, Family f2)
        {
            return !(f1.Id == f2.Id);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        
        public abstract int GetRateAtTime(Int32 time);
    }
}
