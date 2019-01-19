using Babysitter.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Babysitter.Core.Data
{
    public interface IBabysitterRepository
    {

        void AddFamily(Family family);
        void AddHours(Int32 start, Int32 End);
    }
}
