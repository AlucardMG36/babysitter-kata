using BabysitterKata.Core.Data;
using BabysitterKata.Extensions;
using System;

namespace BabysitterKata.Entities
{
    internal sealed class Shift
    {
        private PayCalculator _payCalculator;

        private Shift()
        { }

        public string FamilyId { get; private set; }
        public int StartTime { get; private set; }
        public int EndTime { get; private set; }

        internal static Shift Create(String familyId, Int32 startTime, Int32 endTime)
        {
            if(!(endTime.IsBetween(0,4)) && startTime > endTime)
            {
                throw new ArgumentException($"{nameof(startTime)} cannot be later than {nameof(endTime)}");
            }
            else if(endTime.IsBetween(0,4) && startTime.IsBetween(0,4) && startTime > endTime)
            {
                throw new ArgumentException($"{nameof(startTime)} cannot be later than {nameof(endTime)}");
            }
            else if(endTime.IsBetween(17,23) && startTime.IsBetween(0,4))
            {
                throw new ArgumentException($"{nameof(startTime)} cannot be later than {nameof(endTime)}");
            }


            return new Shift()
            {
                FamilyId = familyId,
                StartTime = startTime,
                EndTime = endTime,
               _payCalculator = PayCalculator.Create(startTime, endTime)
            };
        }

        public Int32 CalculatePayForNightWorked()
        {
            if (FamilyId is "A")
            {
                return _payCalculator.CalculateFamilyAPay();
            }

            else if (FamilyId is "B")
            {
                return _payCalculator.CalculateFamilyBPay();
            }

            else if (FamilyId is "C")
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
