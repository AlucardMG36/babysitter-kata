using System;

namespace BabysitterKata.Entities
{
    internal sealed class Family
    {
        private Family()
        { }
        
        public String Id { get; private set; }

        internal static Family Create(String id)
        {
            return new Family()
            {
                Id = id
            };
        }

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
