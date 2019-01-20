using BabysitterKata.Core.Accessors;
using BabysitterKata.Core.Data;
using BabysitterKata.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKata.Data.Repositories
{
    internal sealed class BabysitterRepository : IBabysitterAccessor, IBabysitterRepository
    {
        public void AddFamily(Family family)
        {
            if(IsAlreadyWorkingForAFamily())
            {
                throw new Exception();
            }
        }

        public int CalculatePay(Shift shift)
        {
            if (shift is null)
            {
                throw new ArgumentNullException(nameof(shift));
            }

            throw new NotImplementedException();
        }

        private bool IsAlreadyWorkingForAFamily()
        {
            
            return true;
        }
        
    }
}
