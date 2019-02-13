using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKata.App.IntegrationTests.Http
{
    public abstract class ResourceBase
    {
        public List<Error> Errors { get; set; }

        public List<Link> Links { get; set; }

        public override bool Equals(object obj)
        {
            if(ReferenceEquals(this, obj))
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

        public override int GetHashCode()
        {
            var hashCode = 19;

            hashCode *= (41 * Errors.GetHashCode());
            hashCode *= (41 * Links.GetHashCode());

            return hashCode;
        }
    }
}
