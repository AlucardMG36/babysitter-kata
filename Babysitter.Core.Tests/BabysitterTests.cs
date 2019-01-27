using BabysitterKata.Entities;
using Shouldly;
using System;
using Xunit;

namespace BabysitterKata.Core.Tests
{
    public class BabysitterTests
    {
        [Fact]
        public void WorkShiftShouldThrowExceptionIfEndTimeIsInvalid()
        {
            //ARRANGE
            var testSitter = new Babysitter("A");

            //ACT & ASSERT
            Should.Throw<Exception>(() => { testSitter.WorkShift(5, 17); });
        }

        [Fact]
        public void WorkShiftShouldThrowExceptionIfStartTimeIsInvalid()
        {
            //ARRANGE
            var testSitter = new Babysitter("A");

            //ACT & ASSERT
            Should.Throw<Exception>(() => testSitter.WorkShift(0, 16));
        }
    }
}
