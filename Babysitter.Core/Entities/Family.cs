using System;
using System.Collections.Generic;
using System.Text;

namespace Babysitter.Core.Entities
{
    public abstract class Family
    {
        protected Family()
        { }

        public Int32 Rate { get; set; }

        protected Family(char FamilyId)
        {
            Id = FamilyId;
        }

        public char Id { get; protected set; }

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

    }
}
