using BabysitterKata.Extensions;
using Shouldly;
using Xunit;

namespace BabysitterKata.Core.Tests
{
    public class BetweenExtensionsTests
    {
        [Fact]
        public void IsBetweenMethodsShouldReturnFalseWhenValueIsNotInRange()
        {
            //ARRANGE
            var lowerBound = -1;
            var upperBound = 1;
            var testValLower = -2;
            var testValUpper = 2;

            //ACT & ASSERT
            testValLower.IsBetween(lowerBound, upperBound).ShouldBeFalse();
            testValLower.IsBetweenExclusiveBounds(lowerBound, upperBound).ShouldBeFalse();
            testValLower.IsBetweenExclusiveLowerBound(lowerBound, upperBound).ShouldBeFalse();
            testValLower.IsBetweenExlusiveUpperBound(lowerBound, upperBound).ShouldBeFalse();
            
            testValUpper.IsBetween(lowerBound, upperBound).ShouldBeFalse();
            testValUpper.IsBetweenExclusiveBounds(lowerBound, upperBound).ShouldBeFalse();
            testValUpper.IsBetweenExclusiveLowerBound(lowerBound, upperBound).ShouldBeFalse();
            testValUpper.IsBetweenExlusiveUpperBound(lowerBound, upperBound).ShouldBeFalse();
        }

        [Fact]
        public void IsBetweenShouldReturnTrueWhenValueIsAtEndPoints()
        {
            //ARRANGE
            var lowerBound = -1;
            var upperBound = 1;
            var testVal1 = -1;
            var testVal2 = 1;
            //ACT & ASSERT
            testVal1.IsBetween(lowerBound, upperBound).ShouldBeTrue();
            testVal2.IsBetween(lowerBound, upperBound).ShouldBeTrue();
        }

        [Fact]
        public void IsBetweenExclusiveLowerBoundShouldReturnTrueWhenValueIsNotEqualToLowerBound()
        {
            //ARRANGE
            var lowerBound = -1;
            var upperBound = 1;
            var testVal = 0;

            //ACT & ASSERT
            testVal.IsBetweenExclusiveLowerBound(lowerBound, upperBound).ShouldBeTrue();
        }

        [Fact]
        public void IsBetweenExclusiveLowerBoundShouldReturnFalseWhenValueIsEqualToLowerBound()
        {
            //ARRANGE
            var lowerBound = -1;
            var upperBound = 1;
            var testVal = -1;

            //ACT & ASSERT
            testVal.IsBetweenExclusiveLowerBound(lowerBound, upperBound).ShouldBeFalse();
        }

        [Fact]
        public void IsBetweenExclusiveUpperBoundShouldReturnTrueWhenValueIsNotEqualToUpperBound()
        {
            //ARRANGE
            var lowerBound = -1;
            var upperBound = 1;
            var testVal = 0;

            //ACT & ASSERT
            testVal.IsBetweenExlusiveUpperBound(lowerBound, upperBound).ShouldBeTrue();
        }

        [Fact]
        public void IsBetweenExclusiveUpperBoundShouldReturnFalseWhenValueIsEqualToUpperBound()
        {
            //ARRANGE
            var lowerBound = -1;
            var upperBound = 1;
            var testVal = 1;

            //ACT & ASSERT
            testVal.IsBetweenExlusiveUpperBound(lowerBound, upperBound).ShouldBeFalse();
        }

        [Fact]
        public void IsBetweenExclusiveBoundsShouldReturnTrueWhenValueIsNotEqualToEitherEndPoint()
        {
            //ARRANGE
            var lowerBound = -1;
            var upperBound = 1;
            var testVal = 0;

            //ACT & ASSERT
            testVal.IsBetweenExclusiveBounds(lowerBound, upperBound).ShouldBeTrue();
        }

        [Fact]
        public void IsBetweenExclusiveBoundsShouldReturnFalseWhenValueIsEqualToEitherEndPoint()
        {
            //ARRANGE
            var lowerBound = -1;
            var upperBound = 1;
            var testVal1 = -1;
            var testVal2 = 1;

            testVal1.IsBetweenExclusiveBounds(lowerBound, upperBound).ShouldBeFalse();
            testVal2.IsBetweenExclusiveBounds(lowerBound, upperBound).ShouldBeFalse();
        }
    }
}
