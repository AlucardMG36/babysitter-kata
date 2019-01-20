using BabysitterKata.Entities;
using BabysitterKata.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKata.Entities
{
    public class Shift
    {
        public Shift()
        { }

        public Shift(Int32 startTime, Int32 endTime, Family family)
        {
            EndTime = endTime;
            FamilyWorkedUnder = family;
            StartTime = startTime;
        }

        public Int32 EndTime { get; set; }
        public Family FamilyWorkedUnder { get; set; }
        public Int32 Pay { get; set; }
        public Int32 StartTime { get; set; }

        public void CalculatePayForNightWorked()
        {
            var totalPay = 0;

            if (FamilyWorkedUnder.Id is "A")
            {
                totalPay += CalculateFamilyAPay();
            }

            else if (FamilyWorkedUnder.Id is "B")
            {
                totalPay += CalculateFamilyBPay();
            }

            else if (FamilyWorkedUnder.Id is "C")
            {
                totalPay += CalculateFamilyCPay();
            }

            Pay = totalPay;
            
        }


        private Int32 CalculateFamilyAPay()
        {
            if (StartTime.IsBetween(0, 4))
            {
                return FamilyWorkedUnder.GetRateAtTime(StartTime) * (EndTime - StartTime);
            }

            else if (EndTime.IsBetween(17, 22))
            {
                return FamilyWorkedUnder.GetRateAtTime(EndTime) * (EndTime - StartTime);
            }
            else
            {
                return CalculateFamilyAOverNightPay();
            }
        }

        private int CalculateFamilyBPay()
        {
            if(EndTime.IsBetween(17,21))
            {
                return FamilyWorkedUnder.GetRateAtTime(StartTime) * (22-StartTime);
            }
            else if (EndTime == 0 && StartTime >= 22)
            {
                return FamilyWorkedUnder.GetRateAtTime(StartTime) * (24 - StartTime);
            }
            else if(StartTime <= 4)
            {
                return FamilyWorkedUnder.GetRateAtTime(StartTime) * (EndTime - StartTime);
            }
            else
            {
                return CalculateFamilyBOverNightPay();
            }
        }

        private int CalculateFamilyCPay()
        {
            if(EndTime.IsBetweenExlusiveUpperBound(17,21))
            {
                return FamilyWorkedUnder.GetRateAtTime(EndTime) * (EndTime - StartTime);
            }
            else if (StartTime.IsBetween(21,23) && EndTime <= 23)
            {
                return FamilyWorkedUnder.GetRateAtTime(EndTime) * (EndTime - StartTime);
            }
            else
            {
                return CalculateFamilyCOverNightPay();
            }
        }


        private Int32 CalculateFamilyAOverNightPay()
        {
            var hoursBeforeEleven = 23 - StartTime;
            var wageBeforeEleven = FamilyWorkedUnder.GetRateAtTime(StartTime) * (hoursBeforeEleven);
            var wageAfterEleven = FamilyWorkedUnder.GetRateAtTime(EndTime) * (1 + EndTime);
            return wageBeforeEleven + wageAfterEleven;
        }

        private Int32 CalculateFamilyBOverNightPay()
        {
            var hoursBeforeTen = 22 - StartTime;
            var wageBeforeTen = FamilyWorkedUnder.GetRateAtTime(StartTime) * (hoursBeforeTen);
            var wageBetweenTenAndMidnight = FamilyWorkedUnder.GetRateAtTime(22) * (2);
            var wageAfterMidnight = FamilyWorkedUnder.GetRateAtTime(EndTime) * (EndTime);
            return wageBeforeTen + wageBetweenTenAndMidnight + wageAfterMidnight;
        }

        private Int32 CalculateFamilyCOverNightPay()
        {
            var hoursBeforeNine = 21 - StartTime;
            var wageBeforeNine = FamilyWorkedUnder.GetRateAtTime(StartTime) * hoursBeforeNine;
            var wageAfterNine = FamilyWorkedUnder.GetRateAtTime(EndTime) * (3 + EndTime);

            return wageBeforeNine + wageAfterNine;
        }

    }
}
