using System;

namespace BabysitterKata.Entities
{
    internal sealed class Shift
    {
        private Family _familyWorkedUnder;
        private PayCalculator _payCalculator;

        private Shift()
        { }
        
        internal static Shift Create(Int32 endTime, String familyId, Int32 startTime )
        {
            return new Shift()
            {
                _familyWorkedUnder = Family.Create(familyId),
               _payCalculator = PayCalculator.Create(endTime,startTime)
            };
        }

        public Int32 CalculatePayForNightWorked()
        {
            if (_familyWorkedUnder.Id is "A")
            {
                return _payCalculator.CalculateFamilyAPay();
            }

            else if (_familyWorkedUnder.Id is "B")
            {
                return _payCalculator.CalculateFamilyBPay();
            }

            else if (_familyWorkedUnder.Id is "C")
            {
                return _payCalculator.CalculateFamilyCPay();
            }

            else
            {
                throw new Exception("Invalid Family");
            }
            
        }        
    }
}
