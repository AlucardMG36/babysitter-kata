using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKata.App.IntegrationTests.Http
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

            hashCode *= (41 * Href.GetHashCode());
            hashCode *= (41 * Name.GetHashCode());

            return hashCode;
        }

        public override String ToString()
        {
            return $"{Name}: {Href}";
        }
    }
}
