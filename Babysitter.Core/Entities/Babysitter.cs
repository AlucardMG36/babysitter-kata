using BabysitterKata.Core.Accessors;
using BabysitterKata.Extensions;
using System;

namespace BabysitterKata.Entities
{
    public sealed class Babysitter: IBabysitterAccessor
    {
        private Int32 _payForShift;
        private readonly Family _familyCurrentlySitting;
        public Babysitter() { }

        public Babysitter(String familyId)
        {
            _familyCurrentlySitting = Family.Create(familyId);
        }
        public Int32 GetPayForNightWorked()
        {
            return _payForShift;
        }

        public void WorkShift(Int32 end, Int32 start)
        {
            if(start.IsBetween(5,16) || end.IsBetween(5, 16))
            {
                throw new Exception("Invalid Start time or End Time");
            }
            var shiftWorked= Shift.Create(end, _familyCurrentlySitting.Id, start);

            _payForShift = shiftWorked.CalculatePayForNightWorked();
        }
    }
}
