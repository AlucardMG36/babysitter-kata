using System;
using System.Collections.Generic;
using System.Text;

namespace Babysitter.Core.Accessors
{
    public interface IFamilyAccessor
    {
        Int32 GetRateAtTime(Int32 time);
    }
}
