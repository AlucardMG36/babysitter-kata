using BabysitterKata.Extensions;
using System;

namespace BabysitterKata.Entities
{
    internal sealed class PayCalculator
    {
        private Int32 _endTime;
        private Int32 _startTime;

        private PayCalculator() { }

        internal static PayCalculator Create(Int32 endTime, Int32 startTime)
        {
            return new PayCalculator()
            {
                _endTime = endTime,
                _startTime = startTime
            };
        }

        public Int32 CalculateFamilyAPay()
        {
            if(_endTime <= 4 && _startTime >= 17)
            {
                return CalculateFamilyAOverNightPay();
            }

            return (_endTime.IsBetweenExlusiveUpperBound(17,23) ? 15 : 20) * (_endTime - _startTime);
        }

        public Int32 CalculateFamilyBPay()
        {
            if (_startTime == 22 && (_endTime.IsBetween(22, 23) || _endTime == 0))
            {
                return 8 * ((_endTime == 0 ? 24 : _endTime) - _startTime);
            }
            
            else if(_endTime.IsBetweenExlusiveUpperBound(17,22))
            {
                return 12 * (_endTime - _startTime);
            }

            else if(_endTime == 0  && _startTime.IsBetweenExlusiveUpperBound(17,22))
            {
                return (12 * (22 - _startTime)) + 16;
                

            }

            else if (_endTime <= 4 && _startTime >= 17)
            {
                return CalculateFamilyBOverNightPay();
            }

            return 16 * (_endTime - _startTime);
        }

        public Int32 CalculateFamilyCPay()
        {
            if (_endTime <= 4 && _startTime >= 17)
            {
                return CalculateFamilyCOverNightPay();
            }
                return (_endTime.IsBetweenExlusiveUpperBound(17,21) ? 21 : 15) * (_endTime - _startTime);
        }


        private Int32 CalculateFamilyAOverNightPay()
        {
            //Add 20 to account for 11pm -> 12am
            var wageBeforeMidnight = 15 * (23 - _startTime) + 20;

            var wageAfterMidnight = 20 * ((4 - _endTime) == 0 ? 4 :( 4 - _endTime));
            return wageBeforeMidnight + wageAfterMidnight;
        }

        private Int32 CalculateFamilyBOverNightPay()
        {
            //Add 16 to account for 10pm -> 12am
            var wageBeforeMidnight = 12 * (22 - _startTime) + 16;

            var wageAfterMidnight = 16 * ((4 - _endTime) == 0 ? 4 : (4 - _endTime));
            return wageBeforeMidnight + wageAfterMidnight;
        }

        private Int32 CalculateFamilyCOverNightPay()
        {
            //Add 45 to account for 9pm -> 12am
            var wageBeforeMidnight = 21 * (21 - _startTime) + 45;
            var wageAfterMidnight = 15 * ((4 - _endTime) == 0 ? 4 : (4 - _endTime));

            return wageBeforeMidnight + wageAfterMidnight;
        }
    }
}

