using System;
using System.Collections.Generic;

namespace BabysitterKata.Api.IntegrationTests.Http
{
    public abstract class ResourceBase
    {
        public List<Error> Errors { get; set; }
        public List<Link> Links { get; set; }

        public override Boolean Equals(object obj)
        {
            if(ReferenceEquals(this,obj))
            {
                return true;
            }

            var other = obj as ResourceBase;

            if(other is null)
            {
                return false;
            }

            return Equals(Errors, other.Errors) && Equals(Links, other.Links);
        }

        public override Int32 GetHashCode()
        {
            var hashCode = 19;

            hashCode *= (43 * Errors.GetHashCode());
            hashCode *= (43 * Links.GetHashCode());

            return hashCode;
        }
    }
}