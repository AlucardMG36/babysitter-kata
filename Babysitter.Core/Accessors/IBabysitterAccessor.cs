using BabysitterKata.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKata.Core.Accessors
{
   public interface IBabysitterAccessor
    {
        void WorkShift(Int32 end, Int32 start);

        Int32 GetPayForNightWorked();
    }
}
