using System;
using System.Collections.Generic;
using System.Text;

namespace Babysitter.Core.Entities
{
    internal sealed class Babysitter
    { 
        public Babysitter() { }

        public Int32 EndTime { get; set; }

        public Family Family { get; set; }

        public Int32 StartTime { get; set; }
    }
}
