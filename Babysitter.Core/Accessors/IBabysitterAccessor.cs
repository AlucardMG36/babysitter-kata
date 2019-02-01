using BabysitterKata.Core.Data;
using BabysitterKata.Entities;
using System;

namespace BabysitterKata.Core.Accessors
{
    public interface IBabysitterAccessor
    {
        Babysitter GetBabysitterWorkingShift(BabysitterRequestData requestData);
    }
}
