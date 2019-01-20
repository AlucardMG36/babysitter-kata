using BabysitterKata.Entities;
using Exceptionless;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BabysitterKata.Core.Tests
{
    public class ShiftTests
    {
        [Fact]
        public void CalculatePayForNightWorkedShouldReturnRateForFamilyABeforeElevenPm()
        {
            //ARRANGE
            var shift = new Shift
            {
                StartTime = 17,
                EndTime = 22,
                FamilyWorkedUnder = new FamilyA()
            };

            //ACT
            shift.CalculatePayForNightWorked();
            var totalPay = shift.Pay;

            //ASSERT
            totalPay.ShouldBe(75);
        }

        [Fact]
        public void CalculatePayForNightWorkedShouldReturnRateForFamilyAAfterMidnight()
        {
            //ARRANGE
            var shift = new Shift
            {
                StartTime = 0,
                EndTime = 4,
                FamilyWorkedUnder = new FamilyA()
            };

            //ACT
            shift.CalculatePayForNightWorked();
            var totalPay = shift.Pay;

            //ASSERT
            totalPay.ShouldBe(80);
        }

        [Fact]
        public void CalculatePayForNightWorkedShouldReturnRateForOvernightWorkWithFamilyA()
        {
            //ARRANGE
            var shift = new Shift
            {
                StartTime = 17,
                EndTime = 4,
                FamilyWorkedUnder = new FamilyA()
            };

            //ACT
            shift.CalculatePayForNightWorked();
            var totalPay = shift.Pay;

            //ASSERT
            totalPay.ShouldBe(190);
        }

        [Fact]
        public void CalculatePayForNightWorkedShouldReturnRateForFamilyBBeforeTenPm()
        {
            //ARRANGE
            var shift = new Shift
            {
                StartTime = 17,
                EndTime = 21,
                FamilyWorkedUnder = new FamilyB()
            };

            //ACT
            shift.CalculatePayForNightWorked();
            var totalPay = shift.Pay;

            //ASSERT
            totalPay.ShouldBe(60);
        }

        [Fact]
        public void CalculatePayForNightWorkedShouldReturnRateForFamilyBBetweenTenAndMidnight()
        {
            //ARRANGE
            var shift = new Shift
            {
                StartTime = 22,
                EndTime = 0,
                FamilyWorkedUnder = new FamilyB()
            };

            //ACT
            shift.CalculatePayForNightWorked();
            var totalPay = shift.Pay;

            //ASSERT
            totalPay.ShouldBe(16);
        }

        [Fact]
        public void CalculatePayForNightWorkedShouldReturnRateForFamilyBUntilMidnight()
        {
            //ARRANGE
            var shift = new Shift
            {
                StartTime = 17,
                EndTime = 0,
                FamilyWorkedUnder = new FamilyB()
            };

            //ACT
            shift.CalculatePayForNightWorked();
            var totalPay = shift.Pay;

            //ASSERT
            totalPay.ShouldBe(76);
        }

        [Fact]
        public void CalculatePayForNightWorkedShouldReturnRateForFamilyBAfterMidnight()
        {
            //ARRANGE
            var shift = new Shift
            {
                StartTime = 1,
                EndTime = 4,
                FamilyWorkedUnder = new FamilyB()
            };

            //ACT
            shift.CalculatePayForNightWorked();
            var totalPay = shift.Pay;

            //ASSERT
            totalPay.ShouldBe(48);
        }


        [Fact]
        public void CalculatePayForNightWorkedShouldReturnRateForFamilyBOverNight()
        {
            //ARRANGE
            var shift = new Shift
            {
                StartTime = 17,
                EndTime = 4,
                FamilyWorkedUnder = new FamilyB()
            };

            //ACT
            shift.CalculatePayForNightWorked();
            var totalPay = shift.Pay;
            
            //ASSERT
            totalPay.ShouldBe(140);
        }

        [Fact]
        public void CalculatePayForNightWorkedShouldReturnRateForBeforeNineWithFamilyC()
        {
            //ARRANGE
            var shift = new Shift
            {
                StartTime = 17,
                EndTime = 20,
                FamilyWorkedUnder = new FamilyC()
            };

            //ACT
            shift.CalculatePayForNightWorked();
            var totalPay = shift.Pay;

            //ASSERT
            totalPay.ShouldBe(63);
        }

        [Fact]
        public void CalculatePayForNightWorkedShouldReturnRateForAfterNineBeforeMidnightWithFamilyC()
        {
            //ARRANGE
            var shift = new Shift
            {
                StartTime = 21,
                EndTime = 23,
                FamilyWorkedUnder = new FamilyC()
            };

            //ACT
            shift.CalculatePayForNightWorked();
            var totalPay = shift.Pay;

            //ASSERT
            totalPay.ShouldBe(30);
        }

        [Fact]
        public void CalculatePayForNightWorkedShouldReturnRateForOvernightWithFamilyC()
        {
            //ARRANGE
            var shift = new Shift
            {
                StartTime = 17,
                EndTime = 4,
                FamilyWorkedUnder = new FamilyC()
            };

            //ACT
            shift.CalculatePayForNightWorked();
            var totalPay = shift.Pay;

            //ASSERT
            totalPay.ShouldBe(189);
        }
    }
}
