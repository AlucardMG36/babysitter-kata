﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Babysitter.Core.Data
{
    public interface IFamilyRepository
    {
        Int32 GetRateAtTime(Int32 time);
    }
}
