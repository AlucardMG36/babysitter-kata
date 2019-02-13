using BabysitterKata.Entities;
using System;
using System.Collections.Generic;

namespace BabysitterKata.App.Models
{
    public sealed class Error: Entity
    {
        public Error(String message)
            :base()
        {
            if(String.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException(nameof(message));
            }

            Message = message;
        }
        
        public String Message { get; private set; }
        
        public List<Link> Links { get; }

        public override string ToString()
        {
            return Message;
        }
    }
}
