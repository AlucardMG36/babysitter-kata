using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKata.Api.IntegrationTests.Http
{
   public class Error
    {
        public String Message { get; set; }

        public override Boolean Equals(object obj)
        {
            if(ReferenceEquals(this, obj))
            {
                return true;
            }


            return (obj is Error other) && Message.Equals(other.Message);
        }

        public override Int32 GetHashCode()
        {
            return Message.GetHashCode();
        }
    }
}
