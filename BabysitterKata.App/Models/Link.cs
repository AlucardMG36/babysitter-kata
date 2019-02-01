using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabysitterKata.App.Models
{
    public sealed class Link
    {
        public Link(String name, String href)
        {
            SetHref(href);
            SetName(name);
        }

        public String Href { get; private set; }

        public String Name { get; private set; }

        public override string ToString()
        {
            return $"{Name}: {Href}";
        }

        private void SetHref(String href)
        {
            Href = href ?? throw new ArgumentNullException(nameof(href));
        }

        private void SetName(String name)
        {
            if(String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
        }
    }
}
