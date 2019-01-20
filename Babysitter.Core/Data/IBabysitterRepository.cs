using BabysitterKata.Entities;
using System;

namespace BabysitterKata.Core.Data
{
    public interface IBabysitterRepository
    {

        void AddFamily(Family family);
    }
}
