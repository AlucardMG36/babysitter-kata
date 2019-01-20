using BabysitterKata.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKata.Core.Accessors
{
   public interface IBabysitterAccessor
    {
       Int32 CalculatePay(Shift shift);
    }
}
