using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKata.Api.IntegrationTests.Http
{
    public class Link
    {
        public String Href { get; set; }
        
        public String Name { get; set; }

        public override Boolean Equals(object obj)
        {
            if(ReferenceEquals(this, obj))
            {
                return true;
            }


            return (obj is Link other) && Href.Equals(other.Href) && Name.Equals(other.Name);
        }

        public override Int32 GetHashCode()
        {
            var hashCode = 19;

            hashCode *= (43 * Href.GetHashCode());
            hashCode *= (43 * Name.GetHashCode());

            return hashCode;
        }

        public override String ToString()
        {
            return $"{Name}: {Href}";
        }
    }
}
