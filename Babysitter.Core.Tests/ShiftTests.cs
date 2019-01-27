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
            var shift = Shift.Create(22,"A",17);

            //ACT
            var totalPay = shift.CalculatePayForNightWorked();
            
            //ASSERT
            totalPay.ShouldBe(75);
        }

        [Fact]
        public void CalculatePayForNightWorkedShouldReturnRateForFamilyAAfterMidnight()
        {
            //ARRANGE
            var shift = Shift.Create(4, "A", 0);

            //ACT
            var totalPay = shift.CalculatePayForNightWorked();
            
            //ASSERT
            totalPay.ShouldBe(80);
        }

        [Fact]
        public void CalculatePayForNightWorkedShouldReturnRateForOvernightWorkWithFamilyA()
        {
            //ARRANGE
            var shift = Shift.Create(4, "A", 17);

            //ACT
            var totalPay = shift.CalculatePayForNightWorked();
            
            //ASSERT
            totalPay.ShouldBe(190);
        }

        [Fact]
        public void CalculatePayForNightWorkedShouldReturnRateForFamilyBBeforeTenPm()
        {
            //ARRANGE
            var shift = Shift.Create(21, "B", 17);

            //ACT
            var totalPay = shift.CalculatePayForNightWorked();
            
            //ASSERT
            totalPay.ShouldBe(48);
        }

        [Fact]
        public void CalculatePayForNightWorkedShouldReturnRateForFamilyBBetweenTenAndMidnight()
        {
            //ARRANGE
            var shift = Shift.Create(0, "B", 22);

            //ACT
            var totalPay = shift.CalculatePayForNightWorked();
            
            //ASSERT
            totalPay.ShouldBe(16);
        }

        [Fact]
        public void CalculatePayForNightWorkedShouldReturnRateForFamilyBUntilMidnight()
        {
            //ARRANGE
            var shift = Shift.Create(0, "B", 17);

            //ACT
            var totalPay = shift.CalculatePayForNightWorked();
            
            //ASSERT
            totalPay.ShouldBe(76);
        }

        [Fact]
        public void CalculatePayForNightWorkedShouldReturnRateForFamilyBAfterMidnight()
        {
            //ARRANGE
            var shift = Shift.Create(4, "B", 1);

            //ACT
            var totalPay = shift.CalculatePayForNightWorked();
            
            //ASSERT
            totalPay.ShouldBe(48);
        }


        [Fact]
        public void CalculatePayForNightWorkedShouldReturnRateForFamilyBOverNight()
        {
            //ARRANGE
            var shift = Shift.Create(4, "B", 17);

            //ACT
            var totalPay = shift.CalculatePayForNightWorked();
            
            //ASSERT
            totalPay.ShouldBe(140);
        }

        [Fact]
        public void CalculatePayForNightWorkedShouldReturnRateForBeforeNineWithFamilyC()
        {
            //ARRANGE
            var shift = Shift.Create(20, "C", 17);

            //ACT
            var totalPay = shift.CalculatePayForNightWorked();
            
            //ASSERT
            totalPay.ShouldBe(63);
        }

        [Fact]
        public void CalculatePayForNightWorkedShouldReturnRateForAfterNineBeforeMidnightWithFamilyC()
        {
            //ARRANGE
            var shift = Shift.Create(23, "C", 21);

            //ACT
            var totalPay = shift.CalculatePayForNightWorked();
            
            //ASSERT
            totalPay.ShouldBe(30);
        }

        [Fact]
        public void CalculatePayForNightWorkedShouldReturnRateForOvernightWithFamilyC()
        {
            //ARRANGE
            var shift = Shift.Create(4, "C", 17);

            //ACT
            var totalPay = shift.CalculatePayForNightWorked();
            
            //ASSERT
            totalPay.ShouldBe(189);
        }
    }
}
