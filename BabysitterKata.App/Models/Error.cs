using System;

namespace BabysitterKata.App.Models
{
    public sealed class Error
    {
        public Error(String message)
        {
            if(String.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException(nameof(message));
            }

            Message = message;
        }

        public String Message { get; private set; }

        public override string ToString()
        {
            return Message;
        }
    }
}
